using System;
using System.Reflection;

namespace He4.Reflection
{

  public class WritablePropertyAccessor<TTarget, TMember> : WritableMemberAccessor<TTarget, TMember>
  {

    public static WritablePropertyAccessor<TTarget, TMember> Make(PropertyInfo property)
    {

      var instance = new WritablePropertyAccessor<TTarget, TMember>();

      if (!property.PropertyType.IsAssignableFrom(typeof(TMember)))
      {

        throw new Exception(typeof(TTarget) + "." + property.Name + " must be assignable from " + typeof(TMember) + ".");
      }

      instance.Method = property.GetSetMethod();

      if (instance.Method == null)
      {

        throw new Exception(typeof(TTarget) + "." + property.Name + " must have a public set accessor.");
      }

      return instance;
    }

    protected WritablePropertyAccessor()
      : base()
    {
    }
  }
}

