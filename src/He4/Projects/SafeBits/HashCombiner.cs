namespace He4.Projects.SafeBits
{

  public struct HashCombiner
  {

    private int Factor;

    public int Value
    {

      get;
      private set;
    }

    public void Put(object field)
    {

      int hashCode = 0;

      if (field != null)
      {

        hashCode = field.GetHashCode();
      }

      Value = (Value * Factor) + hashCode;
    }

    public static HashCombiner Make()
    {

      var instance = default(HashCombiner);
      Setup(ref instance, 1009, 9176); // http://stackoverflow.com/a/34006336
      return instance;
    }

    private static void Setup(ref HashCombiner instance, int seed, int factor)
    {

      instance.Value = seed;
      instance.Factor = factor;
    }
  }
}
