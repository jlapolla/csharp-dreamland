using System;
using System.Collections;
using System.Collections.Generic;

namespace He4.Reflection
{

  public class ConfigurableEqualityComparer<TTarget> : EqualityComparer<TTarget>
  {

    protected class Spec
    {

      public ReadableMemberAccessor<TTarget, object> Accessor { get; set; }
      public IEqualityComparer Comparer { get; set; }

      public static Spec Make()
      {

        var instance = new Spec();
        return instance;
      }

      public static Spec Make(ReadableMemberAccessor<TTarget, object> accessor, IEqualityComparer comparer)
      {

        var instance = new Spec();
        Setup(instance, accessor, comparer);
        return instance;
      }

      protected static void Setup(Spec instance, ReadableMemberAccessor<TTarget, object> accessor, IEqualityComparer comparer)
      {

        instance.Accessor = accessor;
        instance.Comparer = comparer;
      }

      protected Spec()
        : base()
      {
      }
    }

    protected ICollection<Spec> Specs { get; set; }

    public void Use(string memberName)
    {

      Use(memberName, null);
    }

    public void Use(string memberName, IEqualityComparer comparer)
    {

      var accessor = ReadableMemberAccessor<TTarget, object>.Make(memberName);
      Specs.Add(Spec.Make(accessor, comparer));
    }

    public override bool Equals(TTarget left, TTarget right)
    {

      bool result = true;

      foreach (Spec spec in Specs)
      {

        spec.Accessor.Target = left;
        object leftVal = spec.Accessor.Value;
        spec.Accessor.Target = right;
        object rightVal = spec.Accessor.Value;
        spec.Accessor.Target = default(TTarget);

        if (spec.Comparer == null)
        {

          result = Object.Equals(leftVal, rightVal);
        }
        else
        {

          result = spec.Comparer.Equals(leftVal, rightVal);
        }

        if (!result)
        {

          break;
        }
      }

      return result;
    }

    public override int GetHashCode(TTarget obj)
    {

      if (obj == null)
      {

        throw new ArgumentNullException();
      }

      var hash = HashCodeCombiner.Make();

      foreach (Spec spec in Specs)
      {

        spec.Accessor.Target = obj;
        object val = spec.Accessor.Value;
        spec.Accessor.Target = default(TTarget);

        if (spec.Comparer == null)
        {

          hash.Put(val);
        }
        else
        {

          hash.Put(val, spec.Comparer);
        }
      }

      return hash.Value;
    }

    public static ConfigurableEqualityComparer<TTarget> Make()
    {

      var instance = new ConfigurableEqualityComparer<TTarget>();
      Setup(instance);
      return instance;
    }

    protected static void Setup(ConfigurableEqualityComparer<TTarget> instance)
    {

      instance.Specs = new LinkedList<Spec>();
    }

    protected ConfigurableEqualityComparer()
      : base()
    {
    }
  }
}
