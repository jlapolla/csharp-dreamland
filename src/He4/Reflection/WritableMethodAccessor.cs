using System;
using System.Reflection;

namespace He4.Reflection
{

  public class WritableMethodAccessor<TTarget, TMember> : WritableMemberAccessor<TTarget, TMember>
  {

    public static WritableMethodAccessor<TTarget, TMember> Make(MethodInfo method)
    {

      var instance = new WritableMethodAccessor<TTarget, TMember>();

      instance.Method = method;

      return instance;
    }

    protected WritableMethodAccessor()
      : base()
    {
    }
  }
}

