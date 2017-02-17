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

    public static new WritableFieldAccessor<TTarget, TMember> Make(string fieldName)
    {

      Type targetType = typeof(TTarget);
      FieldInfo field = targetType.GetField(fieldName, DefaultBindingFlags);

      if (field == null)
      {

        throw new Exception("\"" + fieldName + "\" must be a public, non-static field of " + targetType + " which is assignable from " + typeof(TMember) + ".");
      }

      return Make(field);
    }

    public static WritableFieldAccessor<TTarget, TMember> Make(FieldInfo field)
    {

      var instance = new WritableFieldAccessor<TTarget, TMember>();
      Setup(instance, field);
      return instance;
    }

    public static WritableFieldAccessor<TTarget, TMember> Make(WritableFieldAccessor<TTarget, TMember> template)
    {

      var instance = new WritableFieldAccessor<TTarget, TMember>();
      Setup(instance, template);
      return instance;
    }

    protected static void Setup(WritableFieldAccessor<TTarget, TMember> instance, FieldInfo field)
    {

      if (!field.FieldType.IsAssignableFrom(typeof(TMember)))
      {

        throw new Exception(typeof(TTarget) + "." + field.Name + " must be assignable from " + typeof(TMember) + ".");
      }

      instance.Field = field;
    }

    protected static void Setup(WritableFieldAccessor<TTarget, TMember> instance, WritableFieldAccessor<TTarget, TMember> template)
    {

      instance.Field = template.Field;
    }

    protected WritableFieldAccessor()
      : base()
    {
    }
  }
}

