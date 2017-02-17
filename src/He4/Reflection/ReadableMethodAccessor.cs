using System;
using System.Reflection;

namespace He4.Reflection
{

  public class ReadableMethodAccessor<TTarget, TMember> : ReadableMemberAccessor<TTarget, TMember>
  {

    public static ReadableMethodAccessor<TTarget, TMember> Make(MethodInfo method)
    {

      var instance = new ReadableMethodAccessor<TTarget, TMember>();
      Setup(instance, method);
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

    protected ReadableMethodAccessor()
      : base()
    {
    }
  }

}

