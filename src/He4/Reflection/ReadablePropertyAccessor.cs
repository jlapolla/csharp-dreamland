using System;
using System.Reflection;

namespace He4.Reflection
{

  public class ReadablePropertyAccessor<TTarget, TMember> : ReadableMemberAccessor<TTarget, TMember>
  {

    protected MethodInfo Method;

    /// <summary>
    /// Overrides ReadableMemberAccessor<TTarget, TMember>.Member.
    /// </summary>
    public override TMember Member
    {

      get
      {

        return (TMember) Method.Invoke(Target, null);
      }
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

      instance.Method = property.GetGetMethod();

      if (instance.Method == null)
      {

        throw new Exception(typeof(TTarget) + "." + property.Name + " must have a public get accessor.");
      }
    }

    protected static void Setup(ReadablePropertyAccessor<TTarget, TMember> instance, ReadablePropertyAccessor<TTarget, TMember> template)
    {

      instance.Method = template.Method;
    }

    protected ReadablePropertyAccessor()
      : base()
    {
    }
  }
}

