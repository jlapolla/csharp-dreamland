using System;

namespace He4.Reflection.Tests
{

  public class SampleClass
  {

    /* Fields */
    public static ValueType StaticValue;

    public ValueType Value;

    private ValueType PrivateValue;

    /* Properties */
    public static ValueType StaticValueProperty
    {

      get
      {

        return StaticValue;
      }

      set
      {

        StaticValue = value;
      }
    }

    public ValueType ValueProperty
    {

      get
      {

        return Value;
      }

      set
      {

        Value = value;
      }
    }

    public ValueType ValuePropertyGetOnly
    {

      get
      {

        return Value;
      }

      private set
      {

        Value = value;
      }
    }

    public ValueType ValuePropertySetOnly
    {

      private get
      {

        return Value;
      }

      set
      {

        Value = value;
      }
    }

    private ValueType PrivateValueProperty
    {

      get
      {

        return Value;
      }

      set
      {

        Value = value;
      }
    }

    /* Get functions */
    public static ValueType GetStaticValue()
    {

      return StaticValue;
    }

    public ValueType GetValue()
    {

      return Value;
    }

    // Important to ensure MemberAccessor classes select the appropriate overload
    public ValueType GetValue(ValueType dummy)
    {

      return 0;
    }

    public ValueType GetValueWithExtraArguments(ValueType dummy)
    {

      return Value;
    }

    private ValueType GetPrivateValue()
    {

      return PrivateValue;
    }

    /* Set functions */
    public static void SetStaticValue(ValueType value)
    {

      StaticValue = value;
    }

    public void SetValue(ValueType value)
    {

      Value = value;
    }

    // Important to ensure MemberAccessor classes select the appropriate overload
    public void SetValue(ValueType value, ValueType dummy)
    {

      Value = 0;
    }

    public void SetValueWithExtraArguments(ValueType value, ValueType dummy)
    {

      Value = value;
    }

    private void SetPrivateValue(ValueType value)
    {

      PrivateValue = value;
    }

    /* Creation */
    public static SampleClass Make()
    {

      var instance = new SampleClass();
      return instance;
    }

    protected SampleClass()
    {
    }
  }
}
