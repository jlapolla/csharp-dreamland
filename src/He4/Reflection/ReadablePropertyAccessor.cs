using System;
using System.Reflection;

namespace He4.Reflection
{

  public class ReadablePropertyAccessor<TTarget, TMember> : ReadableMemberAccessor<TTarget, TMember>
  {

    protected MethodInfo PropertyGetMethod;

    /// <summary>
    /// Overrides ReadableMemberAccessor<TTarget, TMember>.Member.
    /// </summary>
    public override TMember Member
    {

      get
      {

        return (TMember) PropertyGetMethod.Invoke(Target, null);
      }
    }

    public static new ReadablePropertyAccessor<TTarget, TMember> Make(string propertyName)
    {

      Type targetType = typeof(TTarget);
      PropertyInfo property = targetType.GetProperty(propertyName, DefaultBindingFlags);

      if (property == null)
      {

        throw new Exception("\"" + propertyName + "\" must be a public, non-static property of " + targetType + ".");
      }

      return Make(property);
    }

    public static ReadablePropertyAccessor<TTarget, TMember> Make(PropertyInfo property)
    {

      var instance = new ReadablePropertyAccessor<TTarget, TMember>();
      Setup(instance, property);
      return instance;
    }

    public static ReadablePropertyAccessor<TTarget, TMember> Make(ReadablePropertyAccessor<TTarget, TMember> template)
    {

      var instance = new ReadablePropertyAccessor<TTarget, TMember>();
      Setup(instance, template);
      return instance;
    }

    protected static void Setup(ReadablePropertyAccessor<TTarget, TMember> instance, PropertyInfo property)
    {

      if (!typeof(TMember).IsAssignableFrom(property.PropertyType))
      {

        throw new Exception(typeof(TTarget) + "." + property.Name + " must conform to " + typeof(TMember) + ".");
      }

      instance.PropertyGetMethod = property.GetGetMethod();

      if (instance.PropertyGetMethod == null)
      {

        throw new Exception(typeof(TTarget) + "." + property.Name + " must have a public get accessor.");
      }
    }

    protected static void Setup(ReadablePropertyAccessor<TTarget, TMember> instance, ReadablePropertyAccessor<TTarget, TMember> template)
    {

      instance.PropertyGetMethod = template.PropertyGetMethod;
    }

    protected ReadablePropertyAccessor()
      : base()
    {
    }
  }
}

