using System;
using System.Reflection;

namespace He4.Reflection
{

  public class ReadableFieldAccessor<TTarget, TMember> : ReadableMemberAccessor<TTarget, TMember>
  {

    protected ReadableFieldAccessor()
      : base()
    {
    }
  }
}

