using System;
using System.Reflection;

namespace He4.Reflection
{

  public class ReadableMethodAccessor<TTarget, TMember> : ReadableMemberAccessor<TTarget, TMember>
  {

    protected ReadableMethodAccessor()
      : base()
    {
    }
  }

}

