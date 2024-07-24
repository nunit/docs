# Debugging Support

This document describes framework functionality for debugging support of tests and tested code.

## `ThrowOnEachFailureUnderDebugger` Setting

(From version 4.2.0)

Setting name defined by `FrameworkPackageSettings.ThrowOnEachFailureUnderDebugger` constant.

This boolean framework setting enables throwing of immediately catched assertion exception from `Assert.Multiple`
block on each failed assertion. This allows user to break execution on exception and inspect tested code state
at time of failure. In contrast default behavior of `Assert.Multiple` is to throw assertion exception only after
whole block executed. In this situation tested code state could change or be unavailable.

Because this behavior is useful only for debugging, it is not active without attached debugger
(`Debugger.IsAttached = true`).
