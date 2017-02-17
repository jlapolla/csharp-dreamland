using System;
using System.Reflection;

namespace He4.Reflection
{

  public class WritableMethodAccessor<TTarget, TMember> : WritableMemberAccessor<TTarget, TMember>
  {

    protected MethodInfo Method;

    /// <summary>
    /// Overrides WritableMemberAccessor<TTarget, TMember>.Member.
    /// </summary>
    public override TMember Member
    {

      set
      {

        Method.Invoke(Target, new object[1] { value });
      }
    }

    public static new WritableMethodAccessor<TTarget, TMember> Make(string methodName)
    {

      Type targetType = typeof(TTarget);
      MethodInfo method = targetType.GetMethod(methodName, DefaultBindingFlags, Type.DefaultBinder, new Type[1] { typeof(TMember) }, new ParameterModifier[1] { new ParameterModifier(1) });

      if (method == null)
      {

        throw new Exception("\"" + methodName + "\" must be a public, non-static, one-argument method of " + targetType + " whose argument is assignable from " + typeof(TMember) + ".");
      }

      return Make(method);
    }

    public static WritableMethodAccessor<TTarget, TMember> Make(MethodInfo method)
    {

      var instance = new WritableMethodAccessor<TTarget, TMember>();
      Setup(instance, method);
      return instance;
    }

    public static WritableMethodAccessor<TTarget, TMember> Make(WritableMethodAccessor<TTarget, TMember> template)
    {

      var instance = new WritableMethodAccessor<TTarget, TMember>();
      Setup(instance, template);
      return instance;
    }

    protected static void Setup(WritableMethodAccessor<TTarget, TMember> instance, MethodInfo method)
    {

      instance.Method = method;
    }

    protected static void Setup(WritableMethodAccessor<TTarget, TMember> instance, WritableMethodAccessor<TTarget, TMember> template)
    {

      instance.Method = template.Method;
    }

    protected WritableMethodAccessor()
      : base()
    {
    }
  }
}

