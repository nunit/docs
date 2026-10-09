---
uid: partitioningtests
---

# Partitioning Tests

When a test suite is too large to run as one job, split it into numbered partitions and run each partition separately.
NUnit assigns each test to a partition, so the jobs together cover the suite without selecting tests by hand.

## Selecting a partition

Use the `partition` property in a Test Selection Language expression. The value has the form `PARTITION/TOTAL`:

```shell
# Run partition 2 of 5
nunit3-console MyTests.dll --where "partition == 2/5"

# Or, with dotnet test and an NUnit adapter that supports partition filters
dotnet test -- NUnit.Where="partition == 2/5"
```

Partition numbers start at **1**, not 0. To run the whole suite, start one job for each partition from `1` to the same
total. For five jobs, use `1/5`, `2/5`, `3/5`, `4/5` and `5/5`. Keep the total the same for every job.

NUnit uses a hash of each test's full name to assign it to a partition. This makes assignment repeatable for a given
suite, but does not balance partitions by test duration. Renaming tests can also change their assignments.

## Keeping fixtures together

By default, NUnit partitions individual test cases. Tests from one fixture can therefore run in different jobs, with
fixture setup and teardown occurring in more than one job.

To keep each fixture together, add `:fixture` to the partition value:

```shell
nunit3-console MyTests.dll --where "partition == 2/5:fixture"
dotnet test -- NUnit.Where="partition == 2/5:fixture"
```

Fixture partitioning assigns a fixture as a unit. It may result in less even runtimes when fixtures differ in size.
Explicitly specifying `:test` selects the default test-case partitioning mode.

## Things to keep in mind

- Run every partition with the same test assembly and partition count. Changing the total can assign tests to different
  partitions.
- Use a runner that supports partition filters. For `dotnet test`, this requires a compatible NUnit adapter.
- Test dependencies may cause a dependent test or fixture to be included in more than one partition. See
  [Tests That Depend on Other Tests](xref:dependenttests) for details.

See the [Test Selection Language](xref:testselectionlanguage) for more about filter expressions.
