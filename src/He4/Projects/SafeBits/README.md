# C# Integral Cast Characterization

## Sets

- *IntegralTypes = { SByte, Byte, Int16, UInt16, Int32, UInt32, Int64, UInt64
  }*
- *CastTypes = { Implicit, Explicit, Unchecked }*
- *IntegralCasts = {〈td, ts, vs, ct〉 | (td ∈ IntegralTypes) ∧ (ts ∈
  IntegralTypes) ∧ (vs ∈ valueSet(ts)) ∧ (ct ∈ CastTypes)}*
  - *td =* type of destination
  - *ts =* type of source
  - *vs =* value of source
  - *ct =* cast type
- *ResizeModes = { Shrink, Equal, Grow }*
- *ValueModes = { Compatible, Incompatible }*
- *IntegralCastEffects = { ValueCopy, BitWiseCopy, RunTimeError,
  CompileTimeError }*

## Functions

- *sizeOf(x | x ∈ IntegralTypes) ∈ ℤ*
  - The size (in bytes) of *x*
- *valueSet(x | x ∈ IntegralTypes) ⊂ ℤ*
  - The set of integers representable by *x*
- *resizeMode(c | c ∈ IntegralCasts) ∈ ResizeModes*
  - *resizeMode(c) = Shrink ⇔ sizeOf(p1(c)) < sizeOf(p2(c))*
  - *resizeMode(c) = Equal ⇔ sizeOf(p1(c)) = sizeOf(p2(c))*
  - *resizeMode(c) = Grow ⇔ sizeOf(p1(c)) > sizeOf(p2(c))*
- *isSigned(x | x ∈ IntegralTypes) ∈ 𝔹*
  - *isSigned(x) = __t__ ⇔ x ∈ { SByte, Int16, Int32, Int64 }*
  - *isSigned(x) = __f__ ⇔ x ∈ { Byte, UInt16, UInt32, UInt64 }*
- *isSameSigned(c | c ∈ IntegralCasts) ∈ 𝔹*
  - *isSameSigned(c) = __t__ ⇔ isSigned(p1(c)) = isSigned(p2(c))*
  - *isSameSigned(c) = __f__ ⇔ ¬(isSigned(p1(c)) = isSigned(p2(c)))*
- *valueMode(c | c ∈ IntegralCasts) ∈ ValueModes*
  - *valueMode(c) = Compatible ⇔ p3(c) ∈ valueSet(p1(c))*
  - *valueMode(c) = Incompatible ⇔ ¬(p3(c) ∈ valueSet(p1(c)))*
- *effect(c | c ∈ IntegralCasts) ∈ IntegralCastEffects*
  - The effect of the cast

*Note: p1, p2, ... pi are projections.*

## Intuitive explanation of *effect* function

  - *effect(c) = ValueCopy ⇒* Destination value is made equal to source value
  - *(effect(c) = BitWiseCopy) ∧ (resizeMode(c) = Equal) ⇒* Destination binary
    representation is made equal to source binary representation
  - *(effect(c) = BitWiseCopy) ∧ (resizeMode(c) = Shrink) ⇒* Destination binary
    representation is made equal to least significant bits of source binary
    representation
  - *(effect(c) = BitWiseCopy) ∧ (resizeMode(c) = Grow) ⇒* Least significant bits
    of destination binary representation are made equal to source binary
    representation, and other bits of destination binary representation are set
    to 0
  - *effect(c) = RunTimeError ⇒* The cast fails at run time
  - *effect(c) = CompileTimeError ⇒* The cast fails to compile

## Predicates

- *Succeeds(c | c ∈ IntegralCasts) ⇔ ¬((effect(c) = RunTimeError) ∨ (effect(c)
  = CompileTimeError))*
- *Fails(c | c ∈ IntegralCasts) ⇔ ¬Succeeds(c)*

## Theorems

- *(isSameSigned(c) = true) ∧ ¬(resizeMode(c) = Shrink) ⇒ (valueMode(c) =
  Compatible)*

## Hypothesis

The value of *effect(c)* is fully characterized by *〈resizeMode(c),
valueMode(c), p4(c)〉* according to the following table:

| resizeMode(c) | valueMode(c) | p4(c)     | effect(c)        |
| ------------- | ------------ | --------- | ---------------- |
| Shrink        | Compatible   | Implicit  | CompileTimeError |
| Shrink        | Compatible   | Explicit  | ValueCopy        |
| Shrink        | Compatible   | Unchecked | BitWiseCopy      |
| Shrink        | Incompatible | Implicit  | CompileTimeError |
| Shrink        | Incompatible | Explicit  | RunTimeError     |
| Shrink        | Incompatible | Unchecked | BitWiseCopy      |
| Equal         | Compatible   | Implicit  | ValueCopy        |
| Equal         | Compatible   | Explicit  | ValueCopy        |
| Equal         | Compatible   | Unchecked | BitWiseCopy      |
| Equal         | Incompatible | Implicit  | RunTimeError     |
| Equal         | Incompatible | Explicit  | RunTimeError     |
| Equal         | Incompatible | Unchecked | BitWiseCopy      |
| Grow          | Compatible   | Implicit  | ValueCopy        |
| Grow          | Compatible   | Explicit  | ValueCopy        |
| Grow          | Compatible   | Unchecked | BitWiseCopy      |
| Grow          | Incompatible | Implicit  | RunTimeError     |
| Grow          | Incompatible | Explicit  | RunTimeError     |
| Grow          | Incompatible | Unchecked | BitWiseCopy      |

## Conclusions

If the hypothesis is correct, we can draw the following conclusions:

- *(p4(c) = Unchecked) ⇔ (effect(c) = BitWiseCopy)*
- *(resizeMode(c) = Shrink) ∧ (p4(c) = Implicit) ⇔ (effect(c) = CompileTimeError)*
- *(valueMode(c) = Incompatible) ∧ ¬(p4(c)= Unchecked) ⇒ Fails(c)*

## Notes

Implicit, explicit, and bitwise operators are not shown in the [reference
source][Int32 Reference Source] of System.Int32.

[Int32 Reference Source]: http://referencesource.microsoft.com/#mscorlib/system/int32.cs

# Value Compatibility Code Template Verification

## Sets

- IntegralTypes = { SByte, Byte, Int16, UInt16, Int32, UInt32, Int64, UInt64 }
- CastTypes = { Implicit, Explicit, Unchecked }
- IntegralCasts = {〈td, ts, vs, ct〉 | (td ∈ IntegralTypes) ∧ (ts ∈ IntegralTypes) ∧ (vs ∈ valueSet(ts)) ∧ (ct ∈ CastTypes)}
  - td = type of destination
  - ts = type of source
  - vs = value of source
  - ct = cast type
- IntegralCastEffects = { ValueCopy, BitWiseCopy, RunTimeError, CompileTimeError }

## Functions

- max(X | X ∈ IntegralTypes) ∈ ℤ
  - Maximum value in valueSet(X)
- min(X | X ∈ IntegralTypes) ∈ ℤ
  - Minimum value in valueSet(X)
- valueSet(X | X ∈ IntegralTypes) ⊂ ℤ
  - The set of integers representable by X

## Predicates

- IsSigned(X | X ∈ IntegralTypes) ⇔ X ∈ { SByte, Int16, Int32, Int64 }
- Succeeds(c | c ∈ IntegralCasts) ⇔ ¬Fails(c)
- Fails(c | c ∈ IntegralCasts) ⇔ (effect(c) = RunTimeError) ∨ (effect(c) = CompileTimeError)

## Variables

- D ∈ IntegralTypes
  - Destination type
- S ∈ IntegralTypes
  - Source type
- s ∈ valueSet(S)
  - Source value
- c ∈ IntegralCasts | (p1(c) = D) ∧ (p2(c) = S) ∧ (p3(c) = s)
  - Cast

## Theorems

- s <= d ⇔ ¬(s > d)
- s >= d ⇔ ¬(s < d)
- ¬IsSigned(X | X ∈ IntegralTypes) ⇔ (min(X) = 0)
- IsSigned(X | X ∈ IntegralTypes) ⇔ (min(X) < 0)

## Proof 1

### Hypothesis

(max(A) >= max(B)) ∧ (min(A) > min(B)) ⇒ ¬IsSigned(A) ∧ IsSigned(B)

### Proof

(max(A) >= max(B)) ∧ (min(A) > min(B)) ⇒ ¬IsSigned(A) ∧ IsSigned(B)
  C ∨ ¬C
    C ⇔ (max(A) >= max(B)) ∧ (min(A) > min(B)) ⇒ ¬IsSigned(A) ∧ IsSigned(B)

C ∨ ¬((max(A) >= max(B)) ∧ (min(A) > min(B)) ⇒ ¬IsSigned(A) ∧ IsSigned(B))
  P ⇒ Q ⇔ ¬P ∨ Q
    P ⇔ (max(A) >= max(B)) ∧ (min(A) > min(B))
    Q ⇔ ¬IsSigned(A) ∧ IsSigned(B)
  (max(A) >= max(B)) ∧ (min(A) > min(B)) ⇒ ¬IsSigned(A) ∧ IsSigned(B) ⇔ ¬((max(A) >= max(B)) ∧ (min(A) > min(B))) ∨ (¬IsSigned(A) ∧ IsSigned(B))

C ∨ ¬(¬((max(A) >= max(B)) ∧ (min(A) > min(B))) ∨ (¬IsSigned(A) ∧ IsSigned(B)))
  ¬(P ∨ Q) ⇔ ¬P ∧ ¬Q
    P ⇔ ¬((max(A) >= max(B)) ∧ (min(A) > min(B)))
    Q ⇔ (¬IsSigned(A) ∧ IsSigned(B))
  ¬(¬((max(A) >= max(B)) ∧ (min(A) > min(B))) ∨ (¬IsSigned(A) ∧ IsSigned(B))) ⇔ ¬¬((max(A) >= max(B)) ∧ (min(A) > min(B))) ∧ ¬(¬IsSigned(A) ∧ IsSigned(B))

C ∨ ¬¬((max(A) >= max(B)) ∧ (min(A) > min(B))) ∧ ¬(¬IsSigned(A) ∧ IsSigned(B))
  ¬¬P ⇔ P
    P ⇔ ((max(A) >= max(B)) ∧ (min(A) > min(B)))
  ¬¬((max(A) >= max(B)) ∧ (min(A) > min(B))) ⇔ ((max(A) >= max(B)) ∧ (min(A) > min(B)))

C ∨ ((max(A) >= max(B)) ∧ (min(A) > min(B))) ∧ ¬(¬IsSigned(A) ∧ IsSigned(B))
C ∨ (max(A) >= max(B)) ∧ (min(A) > min(B)) ∧ ¬(¬IsSigned(A) ∧ IsSigned(B))
  ¬IsSigned(X) ⇔ (min(X) = 0)
    X = A
  ¬IsSigned(A) ⇔ (min(A) = 0)

C ∨ (max(A) >= max(B)) ∧ (min(A) > min(B)) ∧ ¬((min(A) = 0) ∧ IsSigned(B))
  IsSigned(X) ⇔ (min(X) < 0)
    X = B
  IsSigned(B) ⇔ (min(B) < 0)

C ∨ (max(A) >= max(B)) ∧ (min(A) > min(B)) ∧ ¬((min(A) = 0) ∧ (min(B) < 0))
  ¬(P ∧ Q) ⇔ ¬P ∨ ¬Q
    P ⇔ (min(A) = 0)
    Q ⇔ (min(B) < 0)
  ¬((min(A) = 0) ∧ (min(B) < 0)) ⇔ (¬(min(A) = 0) ∨ ¬(min(B) < 0))

C ∨ (max(A) >= max(B)) ∧ (min(A) > min(B)) ∧ (¬(min(A) = 0) ∨ ¬(min(B) < 0))
  ¬(x = 0) ⇔ (x > 0) ∨ (x < 0)
    x = min(A)
  ¬(min(A) = 0) ⇔ (min(A) > 0) ∨ (min(A) < 0)

C ∨ (max(A) >= max(B)) ∧ (min(A) > min(B)) ∧ ((min(A) > 0) ∨ (min(A) < 0) ∨ ¬(min(B) < 0))
  ¬(x < 0) ⇔ (x = 0) ∨ (x > 0)
    x = min(B)
  ¬(min(B) < 0) ⇔ (min(B) = 0) ∨ (min(B) > 0)

C ∨ (max(A) >= max(B)) ∧ (min(A) > min(B)) ∧ ((min(A) > 0) ∨ (min(A) < 0) ∨ (min(B) = 0) ∨ (min(B) > 0))

  X ∈ IntegralTypes ⇒ IsSigned(X) ∨ ¬IsSigned(X)
    ¬IsSigned(X) ⇔ (min(X) = 0)
    IsSigned(X) ⇔ (min(X) < 0)

  X ∈ IntegralTypes ⇒ (min(X) < 0) ∨ (min(X) = 0)
    X = B

  B ∈ IntegralTypes ⇒ (min(B) < 0) ∨ (min(B) = 0)
    P ⇒ Q ⇔ ¬P ∨ Q
      P ⇔ (B ∈ IntegralTypes)
      Q ⇔ ((min(B) < 0) ∨ (min(B) = 0))
    B ∈ IntegralTypes ⇒ (min(B) < 0) ∨ (min(B) = 0) ⇔ ¬(B ∈ IntegralTypes) ∨ ((min(B) < 0) ∨ (min(B) = 0))

  ¬(B ∈ IntegralTypes) ∨ ((min(B) < 0) ∨ (min(B) = 0))
  ¬(B ∈ IntegralTypes) ∨ (min(B) < 0) ∨ (min(B) = 0)
    B ∈ IntegralTypes ⇔ t

  ¬(t) ∨ (min(B) < 0) ∨ (min(B) = 0)
  ¬t ∨ (min(B) < 0) ∨ (min(B) = 0)
    ¬t ⇔ f

  f ∨ (min(B) < 0) ∨ (min(B) = 0)
    f ∨ P ⇔ P
      P ⇔ (min(B) < 0) ∨ (min(B) = 0)
    f ∨ (min(B) < 0) ∨ (min(B) = 0) ⇔ (min(B) < 0) ∨ (min(B) = 0)

  (min(B) < 0) ∨ (min(B) = 0)
    (x < 0) ∨ (x = 0) ⇒ ¬(x > 0)
      x = min(B)
    (min(B) < 0) ∨ (min(B) = 0) ⇒ ¬(min(B) > 0)

  ∴ ¬(min(B) > 0)
  ∴ (min(B) > 0) ⇔ f

C ∨ (max(A) >= max(B)) ∧ (min(A) > min(B)) ∧ ((min(A) > 0) ∨ (min(A) < 0) ∨ (min(B) = 0) ∨ f)
C ∨ (max(A) >= max(B)) ∧ (min(A) > min(B)) ∧ ((min(A) > 0) ∨ (min(A) < 0) ∨ (min(B) = 0))
  By the same logic, (min(A) > 0) ⇔ f

C ∨ (max(A) >= max(B)) ∧ (min(A) > min(B)) ∧ (f ∨ (min(A) < 0) ∨ (min(B) = 0))
C ∨ (max(A) >= max(B)) ∧ (min(A) > min(B)) ∧ ((min(A) < 0) ∨ (min(B) = 0))
  P ∧ (Q ∨ R) ⇔ (P ∧ Q) ∨ (P ∧ R)
    P ⇔ (min(A) > min(B))
    Q ⇔ (min(A) < 0)
    R ⇔ (min(B) = 0)
  (min(A) > min(B)) ∧ ((min(A) < 0) ∨ (min(B) = 0)) ⇔ (((min(A) > min(B)) ∧ (min(A) < 0)) ∨ ((min(A) > min(B)) ∧ (min(B) = 0)))

C ∨ (max(A) >= max(B)) ∧ (((min(A) > min(B)) ∧ (min(A) < 0)) ∨ ((min(A) > min(B)) ∧ (min(B) = 0)))
  (x > y) ∧ (y = 0) ⇒ (x > 0)
    x = min(A)
    y = min(B)

  (min(A) > min(B)) ∧ (min(B) = 0) ⇒ (min(A) > 0)
    P ⇒ Q ⇔ ¬P ∨ Q
      P ⇔ (min(A) > min(B)) ∧ (min(B) = 0)
      Q ⇔ (min(A) > 0)
    (min(A) > min(B)) ∧ (min(B) = 0) ⇒ (min(A) > 0) ⇔ ¬((min(A) > min(B)) ∧ (min(B) = 0)) ∨ (min(A) > 0)

  ¬((min(A) > min(B)) ∧ (min(B) = 0)) ∨ (min(A) > 0)
    From above, we know that (min(A) > 0) ⇔ f

  ¬((min(A) > min(B)) ∧ (min(B) = 0)) ∨ f
  ¬((min(A) > min(B)) ∧ (min(B) = 0))
  ∴ (min(A) > min(B)) ∧ (min(B) = 0) ⇔ f

C ∨ (max(A) >= max(B)) ∧ (((min(A) > min(B)) ∧ (min(A) < 0)) ∨ (f))
C ∨ (max(A) >= max(B)) ∧ (((min(A) > min(B)) ∧ (min(A) < 0)))
C ∨ (max(A) >= max(B)) ∧ ((min(A) > min(B)) ∧ (min(A) < 0))
C ∨ (max(A) >= max(B)) ∧ (min(A) > min(B)) ∧ (min(A) < 0)
  ∀A,B ∈ IntegralTypes ((max(A) >= max(B)) ∧ (min(A) > min(B)) ∧ (min(A) < 0) ⇔ f)

C ∨ f
C

Not as formal as I would have liked to make it. Maybe I'll try again tomorrow.
