using System;
using System.Reflection;

namespace He4.Reflection
{

  public class ReadablePropertyAccessor<TTarget, TMember> : ReadableMemberAccessor<TTarget, TMember>
  {

    /// <summary>
    /// Overrides ReadableMemberAccessor<TTarget, TMember>.Member.
    /// </summary>
    public override TMember Member
    {

      get
      {

        TMember result = default(TMember);

        while (true)
        {

          if (Method != null)
          {

            result = (TMember) Method.Invoke(Target, null);
            break;
          }

          if (Field != null)
          {

            result = (TMember) Field.GetValue(Target);
            break;
          }

          break;
        }

        return result;
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

      instance.Field = template.Field;
      instance.Method = template.Method;
    }

    protected ReadablePropertyAccessor()
      : base()
    {
    }
  }
}

