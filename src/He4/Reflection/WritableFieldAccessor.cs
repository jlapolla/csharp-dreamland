using System;
using System.Reflection;

namespace He4.Reflection
{

  public class WritableFieldAccessor<TTarget, TMember> : WritableMemberAccessor<TTarget, TMember>
  {

    protected WritableFieldAccessor()
      : base()
    {
    }
  }
}

