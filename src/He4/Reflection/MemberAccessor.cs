using System;
using System.Reflection;

namespace He4.Reflection
{

  public class MemberAccessor<TTarget, TMember> : IMemberAccessor<TMember>
  {

    protected ReadableMemberAccessor<TTarget, TMember> Readable;
    protected WritableMemberAccessor<TTarget, TMember> Writable;

    /// <summary>
    /// Object that owns the member.
    /// </summary>
    public TTarget Target
    {

      get
      {

        return Readable.Target;
      }

      set
      {

        Readable.Target = value;
        Writable.Target = value;
      }
    }

    /// <summary>
    /// Implements IMemberAccessor<T>.Value.
    /// </summary>
    public TMember Value
    {

      get
      {

        return Readable.Value;
      }

      set
      {

        Writable.Value = value;
      }
    }

    /// <summary>
    /// Implements IMemberAccessor<T>.Get.
    /// </summary>
    public TMember Get()
    {

      return Value;
    }

    /// <summary>
    /// Implements IMemberAccessor<T>.Set.
    /// </summary>
    public void Set(TMember value)
    {

      Value = value;
    }

    public static MemberAccessor<TTarget, TMember> Make(string memberName)
    {

      var instance = new MemberAccessor<TTarget, TMember>();
      Setup(instance, memberName, memberName);
      return instance;
    }

    public static MemberAccessor<TTarget, TMember> Make(string readableMemberName, string writableMemberName)
    {

      var instance = new MemberAccessor<TTarget, TMember>();
      Setup(instance, readableMemberName, writableMemberName);
      return instance;
    }

    public static MemberAccessor<TTarget, TMember> Make(MemberAccessor<TTarget, TMember> template)
    {

      var instance = new MemberAccessor<TTarget, TMember>();
      Setup(instance, template);
      return instance;
    }

    protected static void Setup(MemberAccessor<TTarget, TMember> instance, string readableMemberName, string writableMemberName)
    {

      instance.Readable = ReadableMemberAccessor<TTarget, TMember>.Make(readableMemberName);
      instance.Writable = WritableMemberAccessor<TTarget, TMember>.Make(writableMemberName);
    }

    protected static void Setup(MemberAccessor<TTarget, TMember> instance, MemberAccessor<TTarget, TMember> template)
    {

      instance.Readable = ReadableMemberAccessor<TTarget, TMember>.Make(template.Readable);
      instance.Writable = WritableMemberAccessor<TTarget, TMember>.Make(template.Writable);
    }

    protected MemberAccessor()
    {
    }
  }
}
