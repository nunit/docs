# Extending NUnit

NUnit is intended to be extensible. We can't do everything for everybody but we want to make it reasonably easy to
extend NUnit. In many cases, users will be able to implement a special feature outside of our scope by simply creating a
new attribute that embeds the required logic. In other cases, particularly in extending the engine, we rely on a
plugin-architecture.

## Types of Extensibility

* [Framework Extensibility](Framework-Extensibility.md)
* [Engine Extensibility](xref:engineextensionsindex)
