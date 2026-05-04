# NUnit Attribute Documentation Improvement Plan

## Overview

This plan outlines the work needed to improve the documentation for NUnit attributes located in `docs/articles/nunit/writing-tests/attributes/`. The goal is to bring all attribute documentation up to a consistent standard using the template established in `retry.md`.

## Template Structure

Each attribute documentation file should follow this structure:

1. **Title** - `# AttributeName`
2. **Introduction** - Brief description of what the attribute does
3. **Constructor(s)** - Code signature with parameter table (Parameter, Type, Description)
4. **Properties** - Table with Property, Type, Description, and Default columns
5. **Example(s)** - Code snippets demonstrating usage
6. **Notes** - Important behavioral information, limitations, edge cases
7. **See Also** - Links to related attributes

## Priority List - Top 10 Attributes Needing Updates

### 1. SingleThreaded (Score: 9/10 - Critical)
- **File:** `singlethreaded.md`
- **Current State:** Minimal (only 7 lines)
- **Missing:**
  - No Constructor section
  - No Properties section
  - No usage examples
  - No detailed explanation of behavior with ParallelScope settings
- **Source file to check:** `SingleThreadedAttribute.cs`

### 2. SetCulture (Score: 8.5/10)
- **File:** `setculture.md`
- **Current State:** Minimal/Partial
- **Missing:**
  - No Constructor section with parameter details
  - No Properties section
  - No culture inheritance behavior documentation
  - Missing culture reset behavior after test completes
  - No supported culture format details
- **Source file to check:** `SetCultureAttribute.cs`

### 3. SetUICulture (Score: 8.5/10)
- **File:** `setuiculture.md`
- **Current State:** Minimal/Partial
- **Missing:**
  - No Constructor section
  - No Properties section
  - Missing UI culture vs regular culture differences
  - No default culture value documentation
- **Source file to check:** `SetUICultureAttribute.cs`

### 4. Culture (Score: 8/10)
- **File:** `culture.md`
- **Current State:** Minimal
- **Missing:**
  - No formal Constructor section
  - No Properties/Parameters table
  - Limited culture format guidance (en-GB vs de syntax)
  - No exclude behavior examples
  - Missing interaction notes with SetCulture
- **Source file to check:** `CultureAttribute.cs`

### 5. Property (Score: 7.5/10)
- **File:** `property.md`
- **Current State:** Partial
- **Missing:**
  - No formal Constructor parameters table
  - No type information for name/value pairs
  - Limited examples
  - Missing multiple property support documentation
- **Source file to check:** `PropertyAttribute.cs`

### 6. Datapoint (Score: 7/10)
- **File:** `datapoint.md`
- **Current State:** Minimal
- **Missing:**
  - No Constructor section (field-only attribute)
  - Missing explicit list of supported types
  - No behavior matrix for automatic datapoint generation
  - No type-matching rules explanation
- **Source file to check:** `DatapointAttribute.cs`

### 7. DatapointSource (Score: 7/10)
- **File:** `datapointsource.md`
- **Current State:** Minimal
- **Missing:**
  - No formal Constructor section
  - Missing parameter documentation
  - No IEnumerable vs array pattern examples
  - No method vs property vs field usage guidance
- **Source file to check:** `DatapointSourceAttribute.cs`

### 8. MaxTime (Score: 6.5/10)
- **File:** `maxtime.md`
- **Current State:** Partial (31 lines)
- **Missing:**
  - No formal Constructor section
  - Missing property documentation
  - No timeout behavior details (immediate vs graceful)
  - No timing precision discussion
- **Source file to check:** `MaxTimeAttribute.cs`

### 9. Order (Score: 6.5/10)
- **File:** `order.md`
- **Current State:** Partial
- **Missing:**
  - No formal Constructor parameters table
  - Missing property documentation
  - No ordering scope rules across nested fixtures
  - No edge case handling (negative orders, same order values)
- **Source file to check:** `OrderAttribute.cs`

### 10. Repeat (Score: 6.5/10)
- **File:** `repeat.md`
- **Current State:** Partial
- **Missing:**
  - No formal Constructor section
  - Missing `StopOnFailure` property table with defaults
  - No RepeatAttribute with parameterized tests interaction docs
  - No failure collection behavior details
- **Source file to check:** `RepeatAttribute.cs`

## Additional Attributes Needing Work (Ranks 11-15)

### 11. Random (Score: 6/10)
- Constructor signatures exist but not in table format
- Missing property defaults and Guid constraints

### 12. NonTestAssembly (Score: 5.5/10)
- Parameterless attribute, minimal but functional
- Needs more context and edge case examples

### 13. LevelOfParallelism (Score: 5/10)
- No formal Constructor section
- Missing performance tuning guidance

### 14. Apartment (Score: 5/10)
- No formal Constructor parameters section
- Missing ApartmentState enum documentation

### 15. TestOf (Score: 5/10)
- Minimal documentation
- Missing constructor and property details

## Documentation Quality Summary

| Quality Level | Count | Attributes |
|---------------|-------|------------|
| Good | ~14 | CancelAfter, NetPlatform, NoTests, OneTimeSetUp, OneTimeTearDown, Parallelizable, TestFixture, TestCaseSource, Test, TestCase, Explicit, Theory, UnhandledExceptionHandling, FixtureLifeCycle |
| Adequate | ~14 | Apartment, Combinatorial, DefaultFloatingPointTolerance, Description, Ignore, Range, Sequential, Setup, SetupFixture, TearDown, Values, ValueSource, Timeout, Platform, Pairwise |
| Minimal | ~23 | SingleThreaded, SetCulture, SetUICulture, Culture, Property, Datapoint, DatapointSource, MaxTime, Order, Repeat, Random, NonTestAssembly, LevelOfParallelism, TestOf, and others |

## Key Documentation Gaps Across All Attributes

1. **Parameter documentation:** Most attributes lack formal parameter tables with types, defaults, and ranges
2. **Property documentation:** Even when constructors exist, properties/defaults rarely documented
3. **Interaction documentation:** Limited guidance on how attributes combine
4. **Edge cases:** Minimal discussion of boundary conditions, invalid values, error handling
5. **Performance notes:** Almost no documentation on performance implications
6. **Real-world examples:** Most have 1-2 basic examples only

## Reference: Completed Template

See `retry.md` for the completed template example with:
- Constructor section with parameter table
- Properties section with defaults
- Version notes where applicable
- Structured examples
- Consolidated notes section
- See Also links

## Progress Tracking

| Attribute | Status | Notes |
|-----------|--------|-------|
| Retry | Done | Template established |
| SingleThreaded | Done | Parameterless attribute, added Usage/Example/Notes/See Also |
| SetCulture | Done | Added Constructor table, Applies To section, 3 examples |
| SetUICulture | Done | Added Constructor table, Applies To section, 3 examples |
| Culture | Done | Added Constructors, Properties table, Include/Exclude examples |
| Property | Done | Added Constructors, custom attribute examples, TestContext access |
| Datapoint | Done | Added Usage section, examples with enums, auto-datapoints table |
| DatapointSource | Done | Added Usage section, field/property/method examples |
| MaxTime | Done | Added Constructor, examples, comparison with CancelAfter |
| Order | Done | Added Constructor, examples with gaps pattern |
| Repeat | Done | Added Constructors, Properties table with StopOnFailure |
