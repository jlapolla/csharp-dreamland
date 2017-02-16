using System;
using System.Collections;
using System.Collections.Generic;

namespace He4
{

  public struct HashCodeCombiner : IEquatable<HashCodeCombiner>
  {

    public int Value { get; set; }

    public int Factor { get; set; }

    private void PutHashCode(int hashCode)
    {

      // Adding an "unchecked" block here is unnecessary. The calculation is
      // unchecked by default because it contains non-constant terms.
      // Expressions that contain non-constant terms are unchecked by default
      // at compile time and run time.
      //
      // https://msdn.microsoft.com/en-us/library/a569z7k8.aspx

      Value = (Value * Factor) + hashCode;
    }

    public void Put(object field)
    {

      int hashCode = 0;

      if (field != null)
      {

        hashCode = field.GetHashCode();
      }

      PutHashCode(hashCode);
    }

    public void Put(object field, IEqualityComparer comparer)
    {

      int hashCode = 0;

      if (field != null)
      {

        hashCode = comparer.GetHashCode(field);
      }

      PutHashCode(hashCode);
    }

    public void Put<T>(T field, IEqualityComparer<T> comparer)
    {

      int hashCode = 0;

      if (field != null)
      {

        hashCode = comparer.GetHashCode(field);
      }

      PutHashCode(hashCode);
    }

    public bool Equals(HashCodeCombiner other)
    {

      return Value.Equals(other.Value) && Factor.Equals(other.Factor);
    }

    public override bool Equals(object other)
    {

      bool result = false;

      if (other is HashCodeCombiner)
      {

        result = Equals((HashCodeCombiner) other);
      }

      return result;
    }

    public override int GetHashCode()
    {

      var hash = HashCodeCombiner.Make();

      hash.Put(Value);
      hash.Put(Factor);

      return hash.Value;
    }

    public static bool operator ==(HashCodeCombiner left, HashCodeCombiner right)
    {

      return left.Equals(right);
    }

    public static bool operator !=(HashCodeCombiner left, HashCodeCombiner right)
    {

      return !left.Equals(right);
    }

    public static HashCodeCombiner Make()
    {

      // The constants 1009 and 9176 provide low hash collision rates for
      // common use cases.
      //
      // http://stackoverflow.com/a/34006336

      return Make(1009, 9176);
    }

    public static HashCodeCombiner Make(int seed, int factor)
    {

      var instance = default(HashCodeCombiner);
      Setup(ref instance, seed, factor);
      return instance;
    }

    private static void Setup(ref HashCodeCombiner instance, int seed, int factor)
    {

      instance.Value = seed;
      instance.Factor = factor;
    }
  }
}
