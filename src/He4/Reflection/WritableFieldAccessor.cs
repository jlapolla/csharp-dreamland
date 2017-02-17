using System;
using System.Reflection;

namespace He4.Reflection
{

  public class WritableFieldAccessor<TTarget, TMember> : WritableMemberAccessor<TTarget, TMember>
  {

    protected FieldInfo Field;

    /// <summary>
    /// Overrides WritableMemberAccessor<TTarget, TMember>.Member.
    /// </summary>
    public override TMember Member
    {

      set
      {

        Field.SetValue(Target, value);
      }
    }

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

      return instance;
    }

    protected WritableFieldAccessor()
      : base()
    {
    }
  }
}

