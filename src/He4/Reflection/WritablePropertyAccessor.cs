using System;
using System.Reflection;

namespace He4.Reflection
{

  public class WritablePropertyAccessor<TTarget, TMember> : WritableMemberAccessor<TTarget, TMember>
  {

    protected WritablePropertyAccessor()
      : base()
    {
    }
  }
}

