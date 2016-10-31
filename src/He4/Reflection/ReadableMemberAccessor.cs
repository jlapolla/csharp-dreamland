using System;
using System.Reflection;

namespace He4.Reflection
{

  public class ReadableMemberAccessor<TTarget, TMember> : IReadableMemberAccessor<TMember>
  {

    private const BindingFlags DefaultBindingFlags = BindingFlags.Instance | BindingFlags.Public;
    protected FieldInfo Field;
    protected MethodInfo Method;

    /// <summary>
    /// Object that owns the member.
    /// </summary>
    public TTarget Target { get; set; }

    /// <summary>
    /// Implements IReadableMemberAccessor<T>.Value.
    /// </summary>
    public TMember Value
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

      return Value;
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

        throw new Exception(property + " must conform to " + typeof(TMember) + ".");
      }

      instance.Method = property.GetGetMethod();

      if (instance.Method == null)
      {

        throw new Exception(property + " must have a public get accessor.");
      }
    }

    private static void SetupWithField(ReadableMemberAccessor<TTarget, TMember> instance, FieldInfo field)
    {

      if (!typeof(TMember).IsAssignableFrom(field.FieldType))
      {

        throw new Exception(field + " must conform to " + typeof(TMember) + ".");
      }

      instance.Field = field;
    }

    private static void SetupWithMethod(ReadableMemberAccessor<TTarget, TMember> instance, MethodInfo method)
    {

      if (!typeof(TMember).IsAssignableFrom(method.ReturnType))
      {

        throw new Exception(method + " return type must conform to " + typeof(TMember) + ".");
      }

      if (method.GetParameters().Length != 0)
      {

        throw new Exception(method + " must have no arguments.");
      }

      instance.Method = method;
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

        MethodInfo method = targetType.GetMethod(memberName, DefaultBindingFlags);

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

        throw new Exception("Member \"" + memberName + "\" not found in " + targetType + ".");
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
