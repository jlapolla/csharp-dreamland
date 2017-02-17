using System;
using System.Reflection;

namespace He4.Reflection
{

  public class WritableMethodAccessor<TTarget, TMember> : WritableMemberAccessor<TTarget, TMember>
  {

    protected WritableMethodAccessor()
      : base()
    {
    }
  }
}

