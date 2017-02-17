using System;
using System.Reflection;

namespace He4.Reflection
{

  public class ReadableMethodAccessor<TTarget, TMember> : ReadableMemberAccessor<TTarget, TMember>
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

    public static ReadableMethodAccessor<TTarget, TMember> Make(MethodInfo method)
    {

      var instance = new ReadableMethodAccessor<TTarget, TMember>();
      Setup(instance, method);
      return instance;
    }

    public static ReadableMethodAccessor<TTarget, TMember> Make(ReadableMethodAccessor<TTarget, TMember> template)
    {

      var instance = new ReadableMethodAccessor<TTarget, TMember>();
      Setup(instance, template);
      return instance;
    }

    protected static void Setup(ReadableMethodAccessor<TTarget, TMember> instance, MethodInfo method)
    {

      if (!typeof(TMember).IsAssignableFrom(method.ReturnType))
      {

        throw new Exception(typeof(TTarget) + "." + method.Name + " return type must conform to " + typeof(TMember) + ".");
      }

      instance.Method = method;
    }

    protected static void Setup(ReadableMethodAccessor<TTarget, TMember> instance, ReadableMethodAccessor<TTarget, TMember> template)
    {

      instance.Field = template.Field;
      instance.Method = template.Method;
    }

    protected ReadableMethodAccessor()
      : base()
    {
    }
  }

}

