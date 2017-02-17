using System;
using System.Reflection;

namespace He4.Reflection
{

  public class WritablePropertyAccessor<TTarget, TMember> : WritableMemberAccessor<TTarget, TMember>
  {

    protected MethodInfo PropertySetMethod;

    /// <summary>
    /// Overrides WritableMemberAccessor<TTarget, TMember>.Member.
    /// </summary>
    public override TMember Member
    {

      set
      {

        PropertySetMethod.Invoke(Target, new object[1] { value });
      }
    }

    public static WritablePropertyAccessor<TTarget, TMember> Make(PropertyInfo property)
    {

      var instance = new WritablePropertyAccessor<TTarget, TMember>();

      if (!property.PropertyType.IsAssignableFrom(typeof(TMember)))
      {

        throw new Exception(typeof(TTarget) + "." + property.Name + " must be assignable from " + typeof(TMember) + ".");
      }

      instance.PropertySetMethod = property.GetSetMethod();

      if (instance.PropertySetMethod == null)
      {

        throw new Exception(typeof(TTarget) + "." + property.Name + " must have a public set accessor.");
      }

      return instance;
    }

    public static WritablePropertyAccessor<TTarget, TMember> Make(WritablePropertyAccessor<TTarget, TMember> template)
    {

      var instance = new WritablePropertyAccessor<TTarget, TMember>();

      instance.PropertySetMethod = template.PropertySetMethod;

      return instance;
    }

    protected WritablePropertyAccessor()
      : base()
    {
    }
  }
}

