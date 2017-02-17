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
    /// Implements IReadableMemberAccessor<T>.GetMember.
    /// </summary>
    public TMember GetMember()
    {

      return Member;
    }

    public static ReadableMemberAccessor<TTarget, TMember> Make(string memberName)
    {

      var instance = new ReadableMemberAccessor<TTarget, TMember>();

      Type targetType = typeof(TTarget);

      while (true)
      {

        PropertyInfo property = targetType.GetProperty(memberName, DefaultBindingFlags);

        if (property != null)
        {

          instance = ReadablePropertyAccessor<TTarget, TMember>.Make(property);
          break;
        }

        MethodInfo method = targetType.GetMethod(memberName, DefaultBindingFlags, Type.DefaultBinder, Type.EmptyTypes, new ParameterModifier[0]);

        if (method != null)
        {

          instance = ReadableMethodAccessor<TTarget, TMember>.Make(method);
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

      return instance;
    }

    public static ReadableMemberAccessor<TTarget, TMember> Make(ReadableMemberAccessor<TTarget, TMember> template)
    {

      var instance = new ReadableMemberAccessor<TTarget, TMember>();
      Setup(instance, template);
      return instance;
    }

    private static void SetupWithField(ReadableMemberAccessor<TTarget, TMember> instance, FieldInfo field)
    {

      if (!typeof(TMember).IsAssignableFrom(field.FieldType))
      {

        throw new Exception(typeof(TTarget) + "." + field.Name + " must conform to " + typeof(TMember) + ".");
      }

      instance.Field = field;
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
