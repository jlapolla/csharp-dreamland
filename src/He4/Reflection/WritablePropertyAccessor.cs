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

    public static new WritablePropertyAccessor<TTarget, TMember> Make(string propertyName)
    {

      Type targetType = typeof(TTarget);
      PropertyInfo property = targetType.GetProperty(propertyName, DefaultBindingFlags);

      if (property == null)
      {

        throw new Exception("\"" + propertyName + "\" must be a public, non-static property of " + targetType + " which is assignable from " + typeof(TMember) + ".");
      }

      return Make(property);
    }

    public static WritablePropertyAccessor<TTarget, TMember> Make(PropertyInfo property)
    {

      var instance = new WritablePropertyAccessor<TTarget, TMember>();
      Setup(instance, property);
      return instance;
    }

    public static WritablePropertyAccessor<TTarget, TMember> Make(WritablePropertyAccessor<TTarget, TMember> template)
    {

      var instance = new WritablePropertyAccessor<TTarget, TMember>();
      Setup(instance, template);
      return instance;
    }

    protected static void Setup(WritablePropertyAccessor<TTarget, TMember> instance, PropertyInfo property)
    {

      if (!property.PropertyType.IsAssignableFrom(typeof(TMember)))
      {

        throw new Exception(typeof(TTarget) + "." + property.Name + " must be assignable from " + typeof(TMember) + ".");
      }

      instance.PropertySetMethod = property.GetSetMethod();

      if (instance.PropertySetMethod == null)
      {

        throw new Exception(typeof(TTarget) + "." + property.Name + " must have a public set accessor.");
      }
    }

    protected static void Setup(WritablePropertyAccessor<TTarget, TMember> instance, WritablePropertyAccessor<TTarget, TMember> template)
    {

      instance.PropertySetMethod = template.PropertySetMethod;
    }

    protected WritablePropertyAccessor()
      : base()
    {
    }
  }
}

