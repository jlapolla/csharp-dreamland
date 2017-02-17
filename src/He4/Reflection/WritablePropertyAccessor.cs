using System;
using System.Reflection;

namespace He4.Reflection
{

  public class WritablePropertyAccessor<TTarget, TMember> : WritableMemberAccessor<TTarget, TMember>
  {

    protected FieldInfo Field;
    protected MethodInfo Method;

    /// <summary>
    /// Overrides WritableMemberAccessor<TTarget, TMember>.Member.
    /// </summary>
    public override TMember Member
    {

      set
      {

        while (true)
        {

          if (Method != null)
          {

            Method.Invoke(Target, new object[1] { value });
            break;
          }

          if (Field != null)
          {

            Field.SetValue(Target, value);
            break;
          }

          break;
        }
      }
    }

    public static WritablePropertyAccessor<TTarget, TMember> Make(PropertyInfo property)
    {

      var instance = new WritablePropertyAccessor<TTarget, TMember>();

      if (!property.PropertyType.IsAssignableFrom(typeof(TMember)))
      {

        throw new Exception(typeof(TTarget) + "." + property.Name + " must be assignable from " + typeof(TMember) + ".");
      }

      instance.Method = property.GetSetMethod();

      if (instance.Method == null)
      {

        throw new Exception(typeof(TTarget) + "." + property.Name + " must have a public set accessor.");
      }

      return instance;
    }

    public static WritablePropertyAccessor<TTarget, TMember> Make(WritablePropertyAccessor<TTarget, TMember> template)
    {

      var instance = new WritablePropertyAccessor<TTarget, TMember>();

      instance.Field = template.Field;
      instance.Method = template.Method;

      return instance;
    }

    protected WritablePropertyAccessor()
      : base()
    {
    }
  }
}

