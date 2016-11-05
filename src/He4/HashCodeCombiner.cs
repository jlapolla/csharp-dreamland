namespace He4
{

  public struct HashCodeCombiner
  {

    public int Value { get; set; }

    public int Factor { get; set; }

    public void Put(object field)
    {

      int hashCode = 0;

      if (field != null)
      {

        hashCode = field.GetHashCode();
      }

      // Adding an "unchecked" block here is unnecessary. The calculation will
      // be unchecked by default because expressions that contain non-constant
      // terms are unchecked by default at compile time and run time.
      //
      // https://msdn.microsoft.com/en-us/library/a569z7k8.aspx

      Value = (Value * Factor) + hashCode;
    }

    public static HashCodeCombiner Make()
    {

      // The constants 1009 and 9176 provide low hash collision rates for
      // common use cases.
      //
      // http://stackoverflow.com/a/34006336

      return Make(1009, 9176);
    }

    public static HashCodeCombiner Make(int seed, int factor)
    {

      var instance = default(HashCodeCombiner);
      Setup(ref instance, seed, factor);
      return instance;
    }

    private static void Setup(ref HashCodeCombiner instance, int seed, int factor)
    {

      instance.Value = seed;
      instance.Factor = factor;
    }
  }
}
