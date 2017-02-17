using System;
using System.Reflection;

namespace He4.Reflection
{

  public class ReadableMethodAccessor<TTarget, TMember> : ReadableMemberAccessor<TTarget, TMember>
  {

    protected MethodInfo Method;

    /// <summary>
    /// Overrides ReadableMemberAccessor<TTarget, TMember>.Member.
    /// </summary>
    public override TMember Member
    {

      get
      {

        return (TMember) Method.Invoke(Target, null);
      }
    }

    public static new ReadableMethodAccessor<TTarget, TMember> Make(string methodName)
    {

      Type targetType = typeof(TTarget);
      MethodInfo method = targetType.GetMethod(methodName, DefaultBindingFlags, Type.DefaultBinder, Type.EmptyTypes, new ParameterModifier[0]);

      if (method == null)
      {

        throw new Exception("\"" + methodName + "\" must be a public, non-static, zero-argument method of " + targetType + ".");
      }

      return Make(method);
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

      instance.Method = template.Method;
    }

    protected ReadableMethodAccessor()
      : base()
    {
    }
  }

}
