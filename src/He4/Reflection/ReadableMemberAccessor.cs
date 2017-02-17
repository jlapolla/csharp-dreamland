using System;
using System.Reflection;

namespace He4.Reflection
{

  public class ReadableMemberAccessor<TTarget, TMember> : IReadableMemberAccessor<TMember>
  {

    protected const BindingFlags DefaultBindingFlags = BindingFlags.Instance | BindingFlags.Public;
    protected FieldInfo Field;
    protected MethodInfo Method;

    /// <summary>
    /// Object that owns the member.
    /// </summary>
    public TTarget Target { get; set; }

    /// <summary>
    /// Implements IReadableMemberAccessor<T>.Member.
    /// </summary>
    public TMember Member
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

    /// <summary>
    /// Implements IReadableMemberAccessor<T>.Get.
    /// </summary>
    public TMember Get()
    {

      return Member;
    }

    public static ReadableMemberAccessor<TTarget, TMember> Make(string memberName)
    {

      var instance = new ReadableMemberAccessor<TTarget, TMember>();
      Setup(instance, memberName);
      return instance;
    }

    public static ReadableMemberAccessor<TTarget, TMember> Make(ReadableMemberAccessor<TTarget, TMember> template)
    {

      var instance = new ReadableMemberAccessor<TTarget, TMember>();
      Setup(instance, template);
      return instance;
    }

    private static void SetupWithProperty(ReadableMemberAccessor<TTarget, TMember> instance, PropertyInfo property)
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

    private static void SetupWithMethod(ReadableMemberAccessor<TTarget, TMember> instance, MethodInfo method)
    {

      if (!typeof(TMember).IsAssignableFrom(method.ReturnType))
      {

        throw new Exception(typeof(TTarget) + "." + method.Name + " return type must conform to " + typeof(TMember) + ".");
      }

      instance.Method = method;
    }

    private static void SetupWithField(ReadableMemberAccessor<TTarget, TMember> instance, FieldInfo field)
    {

      if (!typeof(TMember).IsAssignableFrom(field.FieldType))
      {

        throw new Exception(typeof(TTarget) + "." + field.Name + " must conform to " + typeof(TMember) + ".");
      }

      instance.Field = field;
    }

    protected static void Setup(ReadableMemberAccessor<TTarget, TMember> instance, string memberName)
    {

      Type targetType = typeof(TTarget);

      while (true)
      {

        PropertyInfo property = targetType.GetProperty(memberName, DefaultBindingFlags);

        if (property != null)
        {

          SetupWithProperty(instance, property);
          break;
        }

        MethodInfo method = targetType.GetMethod(memberName, DefaultBindingFlags, Type.DefaultBinder, Type.EmptyTypes, new ParameterModifier[0]);

        if (method != null)
        {

          SetupWithMethod(instance, method);
          break;
        }

        FieldInfo field = targetType.GetField(memberName, DefaultBindingFlags);

        if (field != null)
        {

          SetupWithField(instance, field);
          break;
        }

        throw new Exception("\"" + memberName + "\" must be a public, non-static property, zero-argument method, or field of " + targetType + ".");
      }
    }

    protected static void Setup(ReadableMemberAccessor<TTarget, TMember> instance, ReadableMemberAccessor<TTarget, TMember> template)
    {

      instance.Field = template.Field;
      instance.Method = template.Method;
    }

    protected ReadableMemberAccessor()
    {
    }
  }
}
