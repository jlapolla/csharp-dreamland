# Definitions and Theorems

## 1

### Name

**IT**, **IntegralTypes**

### Definition

**IT** ≡ { SByte, Byte, Int16, UInt16, Int32, UInt32, Int64, UInt64 }

### Synopsis

The set of all .NET integral types.

### Description

Does not include **Char** since **Char** is does not hold numeric data.

### Links

- [Integral Types Table (C# Reference)](https://msdn.microsoft.com/en-us/library/exx3b86w.aspx)
- [Built-In Types Table (C# Reference)](https://msdn.microsoft.com/en-us/library/ya5y69ds.aspx)

## 2

### Name

ℤ, **Integers**

### Synopsis

The set of all integers.

### Links

- [Integer (Wikipedia)](https://en.wikipedia.org/wiki/Integer)

## 3

### Name

values(*X* ∈ **IT**)

### Defintion

| *X*    | values(*X*) |
| ------ | ----------- |
| SByte  | { *x* ∈ ℤ \| (-128 <= *x*) ∧ (*x* < 128) }                                             |
| Byte   | { *x* ∈ ℤ \| (0 <= *x*) ∧ (*x* < 256) }                                                |
| Int16  | { *x* ∈ ℤ \| (-32,768 <= *x*) ∧ (*x* < 32,768) }                                       |
| UInt16 | { *x* ∈ ℤ \| (0 <= *x*) ∧ (*x* < 65536) }                                              |
| Int32  | { *x* ∈ ℤ \| (-2,147,483,648 <= *x*) ∧ (*x* < 2,147,483,648) }                         |
| UInt32 | { *x* ∈ ℤ \| (0 <= *x*) ∧ (*x* < 4,294,967,296) }                                      |
| Int64  | { *x* ∈ ℤ \| (-9,223,372,036,854,775,808 <= *x*) ∧ (*x* < 9,223,372,036,854,775,808) } |
| UInt64 | { *x* ∈ ℤ \| (0 <= *x*) ∧ (*x* < 18,446,744,073,709,551,616) }                         |

### Synopsis

Range of values of integral type *X*.

### Depends

- #1, #2

### Links

- [Integral Types Table (C# Reference)](https://msdn.microsoft.com/en-us/library/exx3b86w.aspx)

## 4

### Name

𝔹, **Booleans**

### Definition

𝔹 ≡ { **T**, **F** }

### Synopsis

The set of all boolean values.

## 5

### Name

unsigned(*X* ∈ **IT**)

### Definition

| *X*    | unsigned(*X*) |
| ------ | ------------- |
| SByte  | **F**         |
| Byte   | **T**         |
| Int16  | **F**         |
| UInt16 | **T**         |
| Int32  | **F**         |
| UInt32 | **T**         |
| Int64  | **F**         |
| UInt64 | **T**         |

### Synopsis

True if *X* is an unsigned type.

### Depends

- #1, #4

## 6

### Name

proj1(*x*), proj2(*x*), ... , proji(*x*)

### Synopsis

The i'th projection of tuple *x*.

### Examples

proj1(〈*a*, *b*, *c*〉) = *a*

proj2(〈*a*, *b*, *c*〉) = *b*

proj3(〈*a*, *b*, *c*〉) = *c*

### Links

- [Projection (Wikipedia)](https://en.wikipedia.org/wiki/Projection_(set_theory))

## 7

### Name

**IC**, **IntegralCasts**

### Definition

**IC** ≡ {〈*D* ∈ **IT**, *S* ∈ **IT**, *s* ∈ ℤ, *ex* ∈ 𝔹, *uc* ∈ 𝔹〉| *s* ∈ values(*S*) }

### Synopsis

The set of all integral casts.

### Description

The following intuitive definitions apply to all *C* ∈ **IC**

- proj1(*C*) = destination type
- proj2(*C*) = source type
- proj3(*C*) = source value
- proj4(*C*) = true if cast is explicit, false if cast is implicit
- proj5(*C*) = true if cast is unchecked, false if cast is checked

### Depends

- #1, #2, #3, #4, #6

## 8

### Name

explicit(*C* ∈ **IC**)

### Definition

explicit(*C*) ≡ proj4(*C*)

### Synopsis

True if *C* is an explicit cast, false if *C* is an implicit cast.

### Properties

explicit(*C*) ⇔ proj4(*C*)

### Depends

- #6, #7

## 9

### Name

unchecked(*C* ∈ **IC**)

### Definition

unchecked(*C*) ≡ proj5(*C*)

### Synopsis

True if *C* is an unchecked cast, false if *C* is a checked cast.

### Properties

unchecked(*C*) ⇔ proj5(*C*)

### Depends

- #6, #7

## 10

### Name

succeeds(*C* ∈ **IC**)

### Synopsis

True if the execution of cast *C* completes successfully. False if cast *C*
does not compile. Fals if the execution cast *C* results in a run time error
(exception).

### Depends

- #7

## 11

### Name

max(*X* ⊂ ℤ)

### Synopsis

The largest integer in a set of integers.

### Depends

- #2

## 12

### Name

min(*X* ⊂ ℤ)

### Synopsis

The smallest integer in a set of integers.

### Depends

- #2

## 13

### Axiom

- ∀ *X* ∈ **IT**, *x* ∈ ℤ
  - (max(values(*X*)) >= *x*) ∧ (*x* >= min(values(*X*))) ⇔ x ∈ values(*X*)

## 14

### Axiom

- ∀ *X* ∈ **IT**
  - min(values(*X*)) < max(values(*X*))

### Depends

- #1, #2, #3, #11, #12

## X14 **UNPROVEN**

### Theorem

- ∀ *D* ∈ **IT**, *S* ∈ **IT**, *s* ∈ values(*S*)
  - (max(values(*D*)) >= max(values(*S*))) ∧ (min(values(*S*)) >= min(values(*D*))) ⇒ s ∈ values(*D*)
