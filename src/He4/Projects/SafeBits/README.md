# C# Integral Cast Characterization

## Independent Variables

- TDestination ∈ Type
- TSource ∈ Type
- SourceValue ∈ ℤ
- CastType ∈ { Implicit, Explicit, Unchecked }

## Functions

- sizeof(*x: Type*) ∈ ℤ

## Dependent Variables

- DestinationSet(TDestination) ⊂ ℤ
- CastResize(TDestination, TSource) ∈ { Shrink, Equal, Grow }
  - CastResize = Shrink ⇔ sizeof(TDestination) < sizeof(TSource)
  - CastResize = Equal ⇔ sizeof(TDestination) = sizeof(TSource)
  - CastResize = Grow ⇔ sizeof(TDestination) > sizeof(TSource)
- CastValue(SourceValue, DestinationSet) ∈ { Compatible, Incompatible }
  - CastValue = Compatible ⇔ SourceValue ∈ DestinationSet
  - CastValue = Incompatible ⇔ ¬(CastValue = Compatible)
- CastEffect(CastResize, CastValue, CastType) ∈ { ValueCopy, BitWiseCopy,
  RunTimeError, CompileTimeError }
  - CastEffect = ValueCopy ⇔ The destination's value is made equal to
    SourceValue.
  - (CastEffect = BitWiseCopy) ∧ (CastResize = Shrink) ⇔ Least significant bits
    from source are copied to destination, until destination bits are filled.
  - (CastEffect = BitWiseCopy) ∧ (CastResize = Equal) ⇔ The destination's
    binary representation is a bitwise copy of the source's binary
    representation.
  - (CastEffect = BitWiseCopy) ∧ (CastResize = Grow) ⇔ All bits from source are
    copied to the least significant bits of destination, and remaining bits of
    destination are set to 0.
  - CastEffect = RunTimeError ⇔ The cast fails at run time.
  - CastEffect = CompileTimeError ⇔ The cast fails to compile.
- Signedness(TDestination, TSource) ∈ { Same, Different }
  - Signedness = Same ⇔ ((TDestination is signed) ∧ (TSource is signed)) ∨ ((TDestination is unsigned) ∧ (TSource is unsigned))
  - Signedness = Different ⇔ ¬(Signedness = Same)

## Theorems

- (Signedness = Same) ∧ ((CastResize = Equal) ∨ (CastResize = Grow)) ⇒ (CastValue = Compatible)

## CastEffect Truth Table

| CastResize | CastValue    | CastType  | CastEffect       |
| ---------- | ------------ | --------- | ---------------- |
| Shrink     | Compatible   | Implicit  | CompileTimeError |
| Shrink     | Compatible   | Explicit  | ValueCopy        |
| Shrink     | Compatible   | Unchecked | BitWiseCopy      |
| Shrink     | Incompatible | Implicit  | CompileTimeError |
| Shrink     | Incompatible | Explicit  | RunTimeError     |
| Shrink     | Incompatible | Unchecked | BitWiseCopy      |
| Equal      | Compatible   | Implicit  | ValueCopy        |
| Equal      | Compatible   | Explicit  | ValueCopy        |
| Equal      | Compatible   | Unchecked | BitWiseCopy      |
| Equal      | Incompatible | Implicit  | RunTimeError     |
| Equal      | Incompatible | Explicit  | RunTimeError     |
| Equal      | Incompatible | Unchecked | BitWiseCopy      |
| Grow       | Compatible   | Implicit  | ValueCopy        |
| Grow       | Compatible   | Explicit  | ValueCopy        |
| Grow       | Compatible   | Unchecked | BitWiseCopy      |
| Grow       | Incompatible | Implicit  | RunTimeError     |
| Grow       | Incompatible | Explicit  | RunTimeError     |
| Grow       | Incompatible | Unchecked | BitWiseCopy      |

## Hypotheses

- (CastType = Unchecked) ⇔ (CastEffect = BitWiseCopy)
- (CastResize = Shrink) ∧ (CastType = Implicit) ⇔ (CastEffect = CompileTimeError)
