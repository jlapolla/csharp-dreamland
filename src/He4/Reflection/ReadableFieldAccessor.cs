using System;
using System.Reflection;

namespace He4.Reflection
{

  public class ReadableFieldAccessor<TTarget, TMember> : ReadableMemberAccessor<TTarget, TMember>
  {

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
      instance.Method = template.Method;
    }

    protected ReadableFieldAccessor()
      : base()
    {
    }
  }
}

