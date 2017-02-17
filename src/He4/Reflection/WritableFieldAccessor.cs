using System;
using System.Reflection;

namespace He4.Reflection
{

  public class WritableFieldAccessor<TTarget, TMember> : WritableMemberAccessor<TTarget, TMember>
  {

    public static WritableFieldAccessor<TTarget, TMember> Make(FieldInfo field)
    {

      var instance = new WritableFieldAccessor<TTarget, TMember>();

      if (!field.FieldType.IsAssignableFrom(typeof(TMember)))
      {

        throw new Exception(typeof(TTarget) + "." + field.Name + " must be assignable from " + typeof(TMember) + ".");
      }

      instance.Field = field;

      return instance;
    }

    public static WritableFieldAccessor<TTarget, TMember> Make(WritableFieldAccessor<TTarget, TMember> template)
    {

      var instance = new WritableFieldAccessor<TTarget, TMember>();

      instance.Field = template.Field;
      instance.Method = template.Method;

      return instance;
    }

    protected WritableFieldAccessor()
      : base()
    {
    }
  }
}

