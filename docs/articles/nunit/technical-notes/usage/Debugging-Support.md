# Debugging Support

This document describes framework functionality for debugging support of tests and tested code.

## `ThrowOnEachFailureUnderDebugger` Setting

(From version 4.2.0)

Setting name defined by `FrameworkPackageSettings.ThrowOnEachFailureUnderDebugger` constant.


It may sometimes be necessary to debug the current state of a test during an `Assertion.Multiple` block. Typically, assertion exceptions are thrown only after the block is completed.

This boolean framework setting will cause the debugger to throw on a failed assertion during an `Assert.Multiple`
block. This allows user to break execution on exception and inspect tested code state
at time of failure.

Because this behavior is useful only for debugging, it is not active without attached debugger
(`Debugger.IsAttached = true`).
