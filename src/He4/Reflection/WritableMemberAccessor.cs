using System;
using System.Reflection;

namespace He4.Reflection
{

  public class WritableMemberAccessor<TTarget, TMember> : IWritableMemberAccessor<TMember>
  {

    protected const BindingFlags DefaultBindingFlags = BindingFlags.Instance | BindingFlags.Public;
    protected FieldInfo Field;
    protected MethodInfo Method;

    /// <summary>
    /// Object that owns the member.
    /// </summary>
    public TTarget Target { get; set; }

    /// <summary>
    /// Implements IWritableMemberAccessor<T>.Member.
    /// </summary>
    public TMember Member
    {

      set
      {

        while (true)
        {

          if (Method != null)
          {

            Method.Invoke(Target, new object[1] { value });
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
    /// Implements IWritableMemberAccessor<T>.SetMember.
    /// </summary>
    public void SetMember(TMember value)
    {

      Member = value;
    }

    public static WritableMemberAccessor<TTarget, TMember> Make(string memberName)
    {

      var instance = new WritableMemberAccessor<TTarget, TMember>();

      Type targetType = typeof(TTarget);

      while (true)
      {

        PropertyInfo property = targetType.GetProperty(memberName, DefaultBindingFlags);

        if (property != null)
        {

          SetupWithProperty(instance, property);
          break;
        }

        MethodInfo method = targetType.GetMethod(memberName, DefaultBindingFlags, Type.DefaultBinder, new Type[1] { typeof(TMember) }, new ParameterModifier[1] { new ParameterModifier(1) });

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

        throw new Exception("\"" + memberName + "\" must be a public, non-static property, one-argument method, or field of " + targetType + " which is assignable from " + typeof(TMember) + ".");
      }

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

        throw new Exception(typeof(TTarget) + "." + property.Name + " must be assignable from " + typeof(TMember) + ".");
      }

      instance.Method = property.GetSetMethod();

      if (instance.Method == null)
      {

        throw new Exception(typeof(TTarget) + "." + property.Name + " must have a public set accessor.");
      }
    }

    private static void SetupWithMethod(WritableMemberAccessor<TTarget, TMember> instance, MethodInfo method)
    {

      instance.Method = method;
    }

    private static void SetupWithField(WritableMemberAccessor<TTarget, TMember> instance, FieldInfo field)
    {

      if (!field.FieldType.IsAssignableFrom(typeof(TMember)))
      {

        throw new Exception(typeof(TTarget) + "." + field.Name + " must be assignable from " + typeof(TMember) + ".");
      }

      instance.Field = field;
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
