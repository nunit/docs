# StringAssert

The StringAssert class provides a number of methods that are useful
when examining string values.

```csharp
StringAssert.Contains(string expected, string actual);
StringAssert.Contains(string expected, string actual,
                      string message, params object[] args);

StringAssert.DoesNotContain(string expected, string actual);
StringAssert.DoesNotContain(string expected, string actual,
                            string message, params object[] args);

StringAssert.StartsWith(string expected, string actual);
StringAssert.StartsWith(string expected, string actual,
                        string message, params object[] args);

StringAssert.DoesNotStartWith(string expected, string actual);
StringAssert.DoesNotStartWith(string expected, string actual,
                               string message, params object[] args);

StringAssert.EndsWith(string expected, string actual);
StringAssert.EndsWith(string expected, string actual,
                      string message, params object[] args);

StringAssert.DoesNotEndWith(string expected, string actual);
StringAssert.DoesNotEndWith(string expected, string actual,
                            string message, params object[] args);

StringAssert.AreEqualIgnoringCase(string expected, string actual);
StringAssert.AreEqualIgnoringCase(string expected, string actual,
                                  string message params object[] args);

StringAssert.AreNotEqualIgnoringCase(string expected, string actual);
StringAssert.AreNotEqualIgnoringCase(string expected, string actual,
                                     string message params object[] args);

StringAssert.IsMatch(string regexPattern, string actual);
StringAssert.IsMatch(string regexPattern, string actual,
                    string message, params object[] args);

StringAssert.DoesNotMatch(string regexPattern, string actual);
StringAssert.DoesNotMatch(string regexPattern, string actual,
                          string message, params object[] args);

// Functions below are available in NUnit 4.5 and later
StringAssert.IsNullOrEmpty(string? actual);
StringAssert.IsNullOrEmpty(string? actual,
                           string message, params object[] args);

StringAssert.IsNotNullNorEmpty(string? actual);
StringAssert.IsNotNullNorEmpty(string? actual,
                               string message, params object[] args);

StringAssert.IsNullOrWhiteSpace(string? actual);
StringAssert.IsNullOrWhiteSpace(string? actual,
                                string message, params object[] args);

StringAssert.IsNotNullNorWhiteSpace(string? actual);
StringAssert.IsNotNullNorWhiteSpace(string? actual,
                                    string message, params object[] args);
```

## See Also

* [String Constraints](xref:constraints#string-constraints)
