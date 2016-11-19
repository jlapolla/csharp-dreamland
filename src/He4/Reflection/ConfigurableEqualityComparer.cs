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

    protected enum Optimizations : byte { Space, Time }

    protected Optimizations CurrentOptimization;
    protected ICollection<Spec> Specs;

    public void Use(string memberName)
    {

      Use(memberName, null);
    }

    public void Use(string memberName, IEqualityComparer comparer)
    {

      Optimize(Optimizations.Time);

      var accessor = ReadableMemberAccessor<TTarget, object>.Make(memberName);
      Specs.Add(Spec.Make(accessor, comparer));
    }

    public override bool Equals(TTarget left, TTarget right)
    {

      Optimize(Optimizations.Space);

      bool result = true;

      foreach (Spec spec in Specs)
      {

        spec.Accessor.Target = left;
        object leftVal = spec.Accessor.Value;
        spec.Accessor.Target = right;
        object rightVal = spec.Accessor.Value;

        // Reset Accessor.Target to default(TTarget) since we should not retain
        // a reference to 'left' or 'right'.
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

      Optimize(Optimizations.Space);

      if (obj == null)
      {

        throw new ArgumentNullException();
      }

      var hash = HashCodeCombiner.Make();

      foreach (Spec spec in Specs)
      {

        spec.Accessor.Target = obj;
        object val = spec.Accessor.Value;

        // Reset Accessor.Target to default(TTarget) since we should not retain
        // a reference to 'obj'.
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

    protected void Optimize(Optimizations optimization)
    {

      if (optimization != CurrentOptimization)
      {

        switch (optimization)
        {

          case Optimizations.Time:
            Specs = new LinkedList<Spec>(Specs);
            break;

          case Optimizations.Space:
            Specs = new List<Spec>(Specs);
            break;

#if DEBUG
          default:
            throw new Exception();
#endif
        }

        CurrentOptimization = optimization;
      }
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
      instance.CurrentOptimization = Optimizations.Time;
    }

    protected ConfigurableEqualityComparer()
      : base()
    {
    }
  }
}
