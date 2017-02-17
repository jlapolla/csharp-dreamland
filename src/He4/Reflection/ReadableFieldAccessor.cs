using System;
using System.Reflection;

namespace He4.Reflection
{

  public class ReadableFieldAccessor<TTarget, TMember> : ReadableMemberAccessor<TTarget, TMember>
  {

    protected FieldInfo Field;

    /// <summary>
    /// Overrides ReadableMemberAccessor<TTarget, TMember>.Member.
    /// </summary>
    public override TMember Member
    {

      get
      {

        return (TMember) Field.GetValue(Target);
      }
    }

    public static new ReadableFieldAccessor<TTarget, TMember> Make(string fieldName)
    {

      Type targetType = typeof(TTarget);
      FieldInfo field = targetType.GetField(fieldName, DefaultBindingFlags);

      if (field == null)
      {

        throw new Exception("\"" + fieldName + "\" must be a public, non-static field of " + targetType + ".");
      }

      return Make(field);
    }

    public static ReadableFieldAccessor<TTarget, TMember> Make(FieldInfo field)
    {

      var instance = new ReadableFieldAccessor<TTarget, TMember>();
      Setup(instance, field);
      return instance;
    }

    public static ReadableFieldAccessor<TTarget, TMember> Make(ReadableFieldAccessor<TTarget, TMember> template)
    {

      var instance = new ReadableFieldAccessor<TTarget, TMember>();
      Setup(instance, template);
      return instance;
    }

    protected static void Setup(ReadableFieldAccessor<TTarget, TMember> instance, FieldInfo field)
    {

      if (!typeof(TMember).IsAssignableFrom(field.FieldType))
      {

        throw new Exception(typeof(TTarget) + "." + field.Name + " must conform to " + typeof(TMember) + ".");
      }

      instance.Field = field;
    }

    protected static void Setup(ReadableFieldAccessor<TTarget, TMember> instance, ReadableFieldAccessor<TTarget, TMember> template)
    {

      instance.Field = template.Field;
    }

    protected ReadableFieldAccessor()
      : base()
    {
    }
  }
}

