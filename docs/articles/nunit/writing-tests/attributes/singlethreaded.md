# SingleThreaded

`SingleThreadedAttribute` is used on a TestFixture and indicates that the OneTimeSetUp, OneTimeTearDown and all the child tests must run on the same thread.

When using this attribute, any `ParallelScope` setting is ignored.
