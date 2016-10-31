using System;
using System.Reflection;

namespace He4.Reflection
{

  public class WritableMemberAccessor<TTarget, TMember> : IWritableMemberAccessor<TMember>
  {

    private const BindingFlags DefaultBindingFlags = BindingFlags.Instance | BindingFlags.Public;
    protected FieldInfo Field;
    protected MethodInfo Method;

    /// <summary>
    /// Object that owns the member.
    /// </summary>
    public TTarget Target { get; set; }

    /// <summary>
    /// Implements IWritableMemberAccessor<T>.Value.
    /// </summary>
    public TMember Value
    {

      set
      {

        while (true)
        {

          if (Method != null)
          {

            object[] parameters = new object[1];
            parameters[0] = value;
            Method.Invoke(Target, parameters);
            break;
          }

          if (Field != null)
          {

            Field.SetValue(Target, value);
            break;
          }

          break;
        }
      }
    }

    /// <summary>
    /// Implements IWritableMemberAccessor<T>.Set.
    /// </summary>
    public void Set(TMember value)
    {

      Value = value;
    }

    public static WritableMemberAccessor<TTarget, TMember> Make(string memberName)
    {

      var instance = new WritableMemberAccessor<TTarget, TMember>();
      Setup(instance, memberName);
      return instance;
    }

    public static WritableMemberAccessor<TTarget, TMember> Make(WritableMemberAccessor<TTarget, TMember> template)
    {

      var instance = new WritableMemberAccessor<TTarget, TMember>();
      Setup(instance, template);
      return instance;
    }

    private static void SetupWithProperty(WritableMemberAccessor<TTarget, TMember> instance, PropertyInfo property)
    {

      if (!property.PropertyType.IsAssignableFrom(typeof(TMember)))
      {

        throw new Exception(property + " must be assignable from " + typeof(TMember) + ".");
      }

      instance.Method = property.GetSetMethod();

      if (instance.Method == null)
      {

        throw new Exception(property + " must have a public set accessor.");
      }
    }

    private static void SetupWithField(WritableMemberAccessor<TTarget, TMember> instance, FieldInfo field)
    {

      if (!field.FieldType.IsAssignableFrom(typeof(TMember)))
      {

        throw new Exception(field + " must be assignable from " + typeof(TMember) + ".");
      }

      instance.Field = field;
    }

    private static void SetupWithMethod(WritableMemberAccessor<TTarget, TMember> instance, MethodInfo method)
    {

      ParameterInfo[] parameters = method.GetParameters();

      if (parameters.Length == 1)
      {

        if (!parameters[0].ParameterType.IsAssignableFrom(typeof(TMember)))
        {

          throw new Exception(method + " argument must be assignable from " + typeof(TMember) + ".");
        }
      }
      else
      {

        throw new Exception(method + " must have one argument.");
      }

      instance.Method = method;
    }

    protected static void Setup(WritableMemberAccessor<TTarget, TMember> instance, string memberName)
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

    protected static void Setup(WritableMemberAccessor<TTarget, TMember> instance, WritableMemberAccessor<TTarget, TMember> template)
    {

      instance.Field = template.Field;
      instance.Method = template.Method;
    }

    protected WritableMemberAccessor()
    {
    }
  }
}
