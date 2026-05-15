---
uid: configurationfiles
---

# Configuration Files

Normally, a configuration file used to provide settings or to control the environment
in which tests are run, should be given the name as the assembly file with the
suffix ".config" added. For example, the configuration file used to run nunit.tests.dll must
be named nunit.tests.dll.config and located in the same directory as the dll.

**Notes:**

1. When multiple assemblies are specified in an NUnit project (file extension `.nunit`),
it is possible to specify a common config file for the included test assemblies.

2. A custom path to a configuration file can be specified on the command line using the
`--configfile=/path/to/custom.app.config` option if using version 3.8 or higher of the
console runner.

4. When multiple assemblies are specified on the command-line using the `--domain:Single`
option, no config file is currently used.

