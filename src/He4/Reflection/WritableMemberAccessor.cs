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

      WritableMemberAccessor<TTarget, TMember> instance = null;

      Type targetType = typeof(TTarget);

      while (true)
      {

        PropertyInfo property = targetType.GetProperty(memberName, DefaultBindingFlags);

        if (property != null)
        {

          instance = WritablePropertyAccessor<TTarget, TMember>.Make(property);
          break;
        }

        MethodInfo method = targetType.GetMethod(memberName, DefaultBindingFlags, Type.DefaultBinder, new Type[1] { typeof(TMember) }, new ParameterModifier[1] { new ParameterModifier(1) });

        if (method != null)
        {

          instance = WritableMethodAccessor<TTarget, TMember>.Make(method);
          break;
        }

        FieldInfo field = targetType.GetField(memberName, DefaultBindingFlags);

        if (field != null)
        {

          instance = WritableFieldAccessor<TTarget, TMember>.Make(field);
          break;
        }

        throw new Exception("\"" + memberName + "\" must be a public, non-static property, one-argument method, or field of " + targetType + " which is assignable from " + typeof(TMember) + ".");
      }

      return instance;
    }

    public static WritableMemberAccessor<TTarget, TMember> Make(WritableMemberAccessor<TTarget, TMember> template)
    {

      WritableMemberAccessor<TTarget, TMember> instance = null;

      while (true)
      {

        if (template is WritablePropertyAccessor<TTarget, TMember>)
        {

          instance = WritablePropertyAccessor<TTarget, TMember>.Make((WritablePropertyAccessor<TTarget, TMember>) template);
          break;
        }

        if (template is WritableMethodAccessor<TTarget, TMember>)
        {

          instance = WritableMethodAccessor<TTarget, TMember>.Make((WritableMethodAccessor<TTarget, TMember>) template);
          break;
        }

        if (template is WritableFieldAccessor<TTarget, TMember>)
        {

          instance = WritableFieldAccessor<TTarget, TMember>.Make((WritableFieldAccessor<TTarget, TMember>) template);
          break;
        }

        throw new Exception("Unsupported subclass: " + template.GetType() + ".");
      }

      return instance;
    }

    protected WritableMemberAccessor()
    {
    }
  }
}
