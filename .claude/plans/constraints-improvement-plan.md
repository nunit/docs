# NUnit Constraints Documentation Improvement Plan

This plan tracks the implementation of constraint documentation improvements. For the documentation template and guidelines, see the [Constraint Documentation Skill](../.claude/skills/constraint-documentation/skill.md).

## Source Code Analysis (2024)

Analysis of NUnit framework source code revealed significant documentation gaps:

### Missing Constraint Documentation

These constraints exist in source but have NO documentation:

| Constraint | Syntax | Description | Priority |
|------------|--------|-------------|----------|
| MultipleOfConstraint | `Is.MultipleOf(n)`, `Is.Even`, `Is.Odd` | Tests if value is multiple of another | High |
| EmptyGuidConstraint | (internal, via `Is.Empty` on Guid) | Tests if a Guid is empty/default | Low |
| ContainsConstraint | `Does.Contain()` | Routes to Substring/SomeItems based on type | Medium |

### Undocumented Features/Modifiers

These features exist in source but are not well documented:

| Feature | Constraints Affected | Status |
|---------|---------------------|--------|
| `UsingPropertiesComparer()` | EqualConstraint | ✅ **Well documented** in EqualConstraint.md |
| `IgnoreWhiteSpace` | EqualConstraint, ContainsConstraint | ✅ Documented in EqualConstraint.md |
| `Is.Even`, `Is.Odd`, `Is.MultipleOf(n)` | MultipleOfConstraint | ❌ **Not documented** |
| `ApplyToAsync<T>()` | All constraints via IAsyncConstraint | ❌ **Not documented** |
| `IgnoreLineEndingFormat` | ContainsConstraint | ❌ **Not documented** (ContainsConstraint needs docs) |
| `Contains.*` syntax helper | Various | ⚠️ Partially documented within other constraint pages |

### Deprecated/Removed Constraints

| Constraint | Status | Notes |
|------------|--------|-------|
| BinarySerializableConstraint | **DEPRECATED** | Removed in NUnit 4.x due to .NET 8 binary serialization removal |

### Syntax Helper Coverage

The source exposes constraints via 4 helper classes:

- **Is.*** - 50+ members (most well-documented)
- **Does.*** - 10+ members (partially documented)
- **Has.*** - 20+ members (partially documented)
- **Contains.*** - 4 members (needs documentation)

## Constraint Inventory

### Priority 1: High-Traffic Constraints (Improve First)

These are commonly used and should have excellent documentation:

| Constraint | Current State | Needs |
|------------|---------------|-------|
| EqualConstraint | ✅ **Excellent** - comprehensive with UsingPropertiesComparer | UID fixed ✅ |
| NullConstraint | Minimal (1 example ref) | Full rewrite with inline examples |
| TrueConstraint | Minimal | Full rewrite |
| FalseConstraint | Minimal | Full rewrite |
| GreaterThanConstraint | Good examples, has modifiers | UID fixed ✅, add section headers |
| LessThanConstraint | Same as GreaterThan | UID fixed ✅, add section headers |
| ThrowsConstraint | Good | UID fixed ✅, minor cleanup |
| ContainsConstraint | **No dedicated doc** | Create new doc explaining routing |
| CollectionEquivalentConstraint | Moderate | Add more examples, sections |

### Priority 2: Comparison Constraints

| Constraint | Current State | Needs |
|------------|---------------|-------|
| GreaterThanOrEqualConstraint | Moderate | Section headers, more context |
| LessThanOrEqualConstraint | Moderate | Section headers, more context |
| RangeConstraint | External ref only | Add inline examples |
| SameAsConstraint | Minimal | Add examples showing reference equality |

### Priority 3: String Constraints

| Constraint | Current State | Needs |
|------------|---------------|-------|
| StartsWithConstraint | Good | Minor cleanup |
| EndsWithConstraint | Moderate | Match StartsWithConstraint quality |
| SubstringConstraint | Good | Minor cleanup |
| RegexConstraint | Moderate | Add pattern examples |
| EmptyStringConstraint | Minimal | Add examples |
| WhiteSpaceConstraint | Unknown | Review and improve |

### Priority 4: Collection Constraints

| Constraint | Current State | Needs |
|------------|---------------|-------|
| AllItemsConstraint | Moderate | Add subsections |
| SomeItemsConstraint | Good modifiers | Add example sections |
| NoItemConstraint | Minimal | Add examples |
| UniqueItemsConstraint | Good modifiers | Add example sections |
| CollectionOrderedConstraint | Excellent | Minor cleanup only |
| CollectionSubsetConstraint | Moderate | Add examples |
| CollectionSupersetConstraint | Moderate | Add examples |
| ExactCountConstraint | Unknown | Review |
| EmptyCollectionConstraint | Minimal | Add examples |

### Priority 5: Type Constraints

| Constraint | Current State | Needs |
|------------|---------------|-------|
| InstanceOfTypeConstraint | External ref only | Add inline examples |
| ExactTypeConstraint | Minimal | Add examples |
| AssignableFromConstraint | Minimal (2 one-liners) | Add context, examples |
| AssignableToConstraint | Minimal | Add examples |
| AttributeConstraint | Unknown | Review |
| AttributeExistsConstraint | Unknown | Review |

### Priority 6: Dictionary Constraints

| Constraint | Current State | Needs |
|------------|---------------|-------|
| DictionaryContainsKeyConstraint | Excellent | Minor cleanup |
| DictionaryContainsValueConstraint | Unknown | Review, match Key quality |
| DictionaryContainsKeyValuePairConstraint | Unknown | Review |

### Priority 7: Property Constraints

| Constraint | Current State | Needs |
|------------|---------------|-------|
| PropertyConstraint | External ref only | Add inline examples |
| PropertyExistsConstraint | Unknown | Review |

### Priority 8: Path/File Constraints

| Constraint | Current State | Needs |
|------------|---------------|-------|
| FileOrDirectoryExistsConstraint | Has modifiers (wrong format) | Fix modifier format |
| SamePathConstraint | Unknown | Review |
| SamePathOrUnderConstraint | Unknown | Review |
| SubPathConstraint | Unknown | Review |
| EmptyDirectoryConstraint | Minimal | Add examples |

### Priority 9: Compound Constraints

| Constraint | Current State | Needs |
|------------|---------------|-------|
| AndConstraint | Minimal | Add examples of combining |
| OrConstraint | Minimal | Add examples |
| NotConstraint | **BROKEN** - wrong example ref | Fix reference, add examples |

### Priority 10: Special Constraints

| Constraint | Current State | Needs |
|------------|---------------|-------|
| DelayedConstraint | Has table format | Standardize, document async support |
| ReusableConstraint | Unknown | Review |
| DefaultConstraint | Has version info | Review |
| ThrowsNothingConstraint | Unknown | Review |
| NaNConstraint | Minimal (2 one-liners) | Add context |
| BinarySerializableConstraint | **DEPRECATED** | Add deprecation notice, mark as removed in NUnit 4.x |
| XmlSerializableConstraint | Unknown | Review |
| AnyOfConstraint | Unknown | Review |

### Priority 11: Missing Documentation (NEW)

| Constraint | Syntax | Needs |
|------------|--------|-------|
| MultipleOfConstraint | `Is.MultipleOf(n)`, `Is.Even`, `Is.Odd` | Create new doc page |
| ContainsConstraint | `Does.Contain()` | Create clarification doc explaining routing behavior |

### Priority 12: Feature Documentation (NEW)

| Feature | Current State | Needs |
|---------|---------------|-------|
| Async Constraint Support | Not documented | Create guide for ApplyToAsync patterns |
| Contains.* syntax helper | Partially documented | Consider dedicated Contains helper page |
| IgnoreLineEndingFormat | Not documented | Add to ContainsConstraint when created |

## Critical Fixes (Do First)

1. **NotConstraint.md** - Fix wrong example reference (currently points to PropertyConstraintExamples)
2. **FileOrDirectoryExistsConstraint.md** - Fix modifier format (missing `.` prefix)
3. **UID standardization** - Update all UIDs to `constraint-<name>` pattern

## Snippet File Organization

Current: All examples in single `ConstraintExamples.cs` file with regions.

Proposed: Keep single file but ensure:
- Every constraint has at least one region
- Regions are named consistently: `<ConstraintName>Examples`
- Each region has comments explaining what's being demonstrated
- Complex constraints have multiple regions for different scenarios

## Estimated Scope

| Category | Files | Effort |
|----------|-------|--------|
| Critical fixes | 3 | Small | ✅ Complete |
| Full rewrites needed | ~25 | Large |
| Moderate improvements | ~15 | Medium |
| Minor cleanup only | ~12 | Small |
| **Existing docs subtotal** | **55** | |
| New constraint docs needed | 2 | Small (MultipleOf, ContainsConstraint) |
| New feature docs needed | 2 | Medium (Async support, Contains.* helper) |
| **Total** | **59** | |

## Implementation Order

1. **Phase 1**: Critical fixes (NotConstraint, FileOrDirectoryExists, UID standardization) ✅ Complete
2. **Phase 2**: Priority 1 high-traffic constraints
3. **Phase 3**: Priority 2-4 constraints (comparison, string, collection)
4. **Phase 4**: Priority 5-10 remaining constraints
5. **Phase 5**: Priority 11 missing constraint documentation (MultipleOfConstraint, ContainsConstraint)
6. **Phase 6**: Priority 12 feature documentation (Async support, Contains.* helper)

## Progress Tracking

### Phase 1: Critical Fixes
| Task | Status | Notes |
|------|--------|-------|
| Fix NotConstraint.md example reference | Complete | Fixed #PropertyConstraintExamples → #NotConstraintExamples |
| Fix FileOrDirectoryExistsConstraint.md modifiers | Complete | Added `.` prefix to IgnoreDirectories and IgnoreFiles |
| Standardize all UIDs to `constraint-<name>` | Complete | Added UIDs to all 55 constraint files, updated 11 xref references |

### Phase 2: Priority 1 Constraints
| Constraint | Status | Notes |
|------------|--------|-------|
| EqualConstraint | Pending | |
| NullConstraint | Pending | |
| TrueConstraint | Pending | |
| FalseConstraint | Pending | |
| GreaterThanConstraint | Pending | |
| LessThanConstraint | Pending | |
| ThrowsConstraint | Pending | |
| CollectionEquivalentConstraint | Pending | |
