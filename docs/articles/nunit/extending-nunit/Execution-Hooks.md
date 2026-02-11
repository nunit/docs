# Execution Hooks

Added in **NUnit 4.5**

Execution Hooks provide structured, ordered, exception-aware extension points around each core test lifecycle phase. They complement (and can wrap) [Action Attributes](Action-Attributes.md) while staying focused on execution.

Key differences to Action Attributes:

- Execution Hooks focus on the immediate test invocation phases (before/after setup, test, teardown and test action callbacks).
- Only overridden hook methods are registered, keeping runtime overhead low.
- After-hooks run in reverse order (stack behavior) to naturally unwind resources paired with the corresponding before-hooks.

## When to use Execution Hooks

Execution Hooks should be used when there is a need to:

- Time, log, trace or audit test phases precisely.
- Inject state around each SetUp/TearDown.
- Pair resource acquisition/release symmetrically (BeforeX/AfterX).
- React to exceptions thrown by setup, test or teardown methods.
- Integrate with or augment existing Action Attributes behavior at a finer granularity.

## Getting started

Derive from `ExecutionHookAttribute` and override only the methods that are relevant:

| Method | Triggered immediately | Applies To |
|--------|-----------------------|------------|
| `BeforeEverySetUpHook` | Before each `[SetUp]` or `[OneTimeSetUp]` method | All fixture & base fixture setup methods |
| `AfterEverySetUpHook`  | After each `[SetUp]` or `[OneTimeSetUp]` method | All fixture & base fixture setup methods |
| `BeforeTestHook`       | Before the test method | The test method |
| `AfterTestHook`        | After the test method | The test method |
| `BeforeEveryTearDownHook` | Before each `[TearDown]` or `[OneTimeTearDown]` method | All fixture & base fixture teardown methods |
| `AfterEveryTearDownHook`  | After each `[TearDown]` or `[OneTimeTearDown]` method | All fixture & base fixture teardown methods |
| `BeforeTestActionBeforeTestHook` | Before an `ITestAction.BeforeTest(ITest)` executes | Each applicable Action Attribute |
| `BeforeTestActionAfterTestHook`  | After an `ITestAction.BeforeTest(ITest)` executes | Each applicable Action Attribute |
| `AfterTestActionBeforeTestHook`  | Before an `ITestAction.AfterTest(ITest)` executes | Each applicable Action Attribute |
| `AfterTestActionAfterTestHook`   | After an `ITestAction.AfterTest(ITest)` executes | Each applicable Action Attribute |

This derived attribute can be applied at the method, class, or assembly level.

Each hook receives a `HookData` instance:

- `Context`: A `TestContext` snapshot (current test, properties, etc.).
- `HookedMethod`: The `MethodInfoAdapter` of the method currently executing (e.g., the specific `[SetUp]`, test, or `[TearDown]`).
- `Exception`: Non-null only for after-hooks when the hooked method threw.

Use these fields for logging, conditional logic, or adaptive cleanup.

## One-Time vs Per-Test Setup/TearDown

`BeforeEverySetUpHook`/`AfterEverySetUpHook` and `BeforeEveryTearDownHook`/`AfterEveryTearDownHook` run for both per-test and one-time setup/teardown. Inside a hook, the supported way to distinguish the two is the current test context: `Context.Test.IsSuite` is `true` for [OneTimeSetUp]/[OneTimeTearDown] (suite context) and `false` for [SetUp]/[TearDown] (test method context).

See [Example: One-Time vs Per-Test Setup and TearDown](#example-one-time-vs-per-test-setup-and-teardown) for a complete hook implementation.

## Example: One-Time vs Per-Test Setup and TearDown

[!code-csharp[ExecutionHookAttributeExample](~/snippets/Snippets.NUnit/ExecutionHookExamples.cs#OneTimeVsPerTestSetupTearDownExample)]

## Example: Measure Time for Setup

[!code-csharp[ExecutionHookAttributeExample](~/snippets/Snippets.NUnit/ExecutionHookExamples.cs#TimingHookAttribute)]

Usage:

[!code-csharp[ExecutionHookAttributeExample](~/snippets/Snippets.NUnit/ExecutionHookExamples.cs#Usage)]

## Example: Logging All Phases

[!code-csharp[ExecutionHookAttributeExample](~/snippets/Snippets.NUnit/ExecutionHookExamples.cs#LoggingAllPhases)]

## Exception Handling

In general:

- If an Execution Hook throws an exception, NUnit treats it in the same way as if the hooked method had thrown it.
For example, an exception from a before/after setup hook is handled the same way as an exception from the setup method itself.
- Independent if a before hook method or the hooked method itself is throwing an exception it is always guaranteed that the after hook method is called and contains the exception details within the `HookData`.

Behavior illustrated by hooking a test method:

- If a `BeforeTestHook` throws, the test method body is skipped, but its `AfterTestHook` still runs (with `HookData.Exception` set) allowing cleanup/logging.
- If an `AfterTestHook` throws, NUnit still proceeds with TearDown phases (remaining hooks and teardown methods run).
- Failures inside a test body still trigger all `AfterTestHook` executions.
- Setup/TearDown exceptions are reported by the corresponding after-hook with `HookData.Exception` populated.

## Ordering Semantics

If multiple attributes are applied:

- Before-hooks (`BeforeEverySetUpHook`, `BeforeTestHook`, etc.) execute in the order, attributes were applied (declaration order on the method/class/assembly).
- After-hooks execute in reverse order, enabling natural stacking:
  - Attribute A before, Attribute B before - Attribute B after, then Attribute A after.
- When multiple attributes appear at different scopes (assembly, class, method), hooks from broader scopes run before narrower scopes for "before" phases, and after narrower scopes for "after" phases (as shown in sequence tests).

## Scope: Method vs Class vs Assembly

Because the `AttributeUsage` targets can be chosen on the derived attribute, control over where hooks can be applied is provided:

- Method: affects only that test method.
- Class: affects all tests within the fixture and inherited base fixture methods.
- Assembly: affects every test in the assembly.

Hooks from broader scopes wrap those from narrower scopes. For a single test method with an assembly-level and a method-level TimingHook:

1. Assembly `BeforeTestHook` runs first.
2. Method `BeforeTestHook` runs.
3. Test executes.
4. Method `AfterTestHook` runs.
5. Assembly `AfterTestHook` runs.

## See Also

- [Action Attributes](~/articles/nunit/extending-nunit/Action-Attributes.md)
- [Custom Attributes](~/articles/nunit/extending-nunit/Custom-Attributes.md)
- [Framework Extensibility](~/articles/nunit/extending-nunit/Framework-Extensibility.md)
