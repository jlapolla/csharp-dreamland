using System;
using System.Reflection;

namespace He4.Reflection
{

  public class WritableMethodAccessor<TTarget, TMember> : WritableMemberAccessor<TTarget, TMember>
  {

    protected FieldInfo Field;
    protected MethodInfo Method;

    /// <summary>
    /// Overrides WritableMemberAccessor<TTarget, TMember>.Member.
    /// </summary>
    public override TMember Member
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

    public static WritableMethodAccessor<TTarget, TMember> Make(MethodInfo method)
    {

      var instance = new WritableMethodAccessor<TTarget, TMember>();

      instance.Method = method;

      return instance;
    }

    public static WritableMethodAccessor<TTarget, TMember> Make(WritableMethodAccessor<TTarget, TMember> template)
    {

      var instance = new WritableMethodAccessor<TTarget, TMember>();

      instance.Field = template.Field;
      instance.Method = template.Method;

      return instance;
    }

    protected WritableMethodAccessor()
      : base()
    {
    }
  }
}

