using System;
using System.Reflection;

namespace He4.Reflection
{

  public abstract class ReadableMemberAccessor<TTarget, TMember> : IReadableMemberAccessor<TMember>
  {

    protected const BindingFlags DefaultBindingFlags = BindingFlags.Instance | BindingFlags.Public;

    /// <summary>
    /// Object that owns the member.
    /// </summary>
    public TTarget Target { get; set; }

    /// <summary>
    /// Implements IReadableMemberAccessor<T>.Member.
    /// </summary>
    public abstract TMember Member { get; }

    /// <summary>
    /// Implements IReadableMemberAccessor<T>.GetMember.
    /// </summary>
    public TMember GetMember()
    {

      return Member;
    }

    public static ReadableMemberAccessor<TTarget, TMember> Make(string memberName)
    {

      ReadableMemberAccessor<TTarget, TMember> instance = null;

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

          instance = ReadableFieldAccessor<TTarget, TMember>.Make(field);
          break;
        }

        throw new Exception("\"" + memberName + "\" must be a public, non-static property, zero-argument method, or field of " + targetType + ".");
      }

      return instance;
    }

    public static ReadableMemberAccessor<TTarget, TMember> Make(ReadableMemberAccessor<TTarget, TMember> template)
    {

      ReadableMemberAccessor<TTarget, TMember> instance = null;

      while (true)
      {

        if (template is ReadablePropertyAccessor<TTarget, TMember>)
        {

          instance = ReadablePropertyAccessor<TTarget, TMember>.Make((ReadablePropertyAccessor<TTarget, TMember>) template);
          break;
        }

        if (template is ReadableMethodAccessor<TTarget, TMember>)
        {

          instance = ReadableMethodAccessor<TTarget, TMember>.Make((ReadableMethodAccessor<TTarget, TMember>) template);
          break;
        }

        if (template is ReadableFieldAccessor<TTarget, TMember>)
        {

          instance = ReadableFieldAccessor<TTarget, TMember>.Make((ReadableFieldAccessor<TTarget, TMember>) template);
          break;
        }

#if DEBUG
        throw new Exception("Unknown subclass: " + template.GetType() + ".");
#endif
      }

      return instance;
    }

    protected ReadableMemberAccessor()
    {
    }
  }
}
