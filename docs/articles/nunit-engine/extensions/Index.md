---
uid: engineextensionsindex
---

# Engine Extensions

The NUnit Test Engine uses a plugin architecture that allows users and third parties to add new functionality to the engine. The extensibility model defines a number of Extension Points to which Extensions may be added.

There are currently four extension points:

* [Project Loaders](Project-Loaders.md)
* [Result Writers](Result-Writers.md)
* [Framework Drivers](Framework-Drivers.md)
* [Event Listeners](Event-Listeners.md)

Extensions are generally created in their own assemblies, with some shared characteristics described in [Writing Engine Extensions](xref:writingengineextensions). They then need to be installed to the engine, which is covered in [Installing Engine Extensions](xref:installingextensions).
