namespace He4.Projects.SafeBits
{

  public class HashCombiner
  {

    private int Factor;

    public int Value
    {

      get;
      protected set;
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

      var instance = new HashCombiner();
      Setup(instance, 1009, 9176); // http://stackoverflow.com/a/34006336
      return instance;
    }

    protected static void Setup(HashCombiner instance, int seed, int factor)
    {

      instance.Value = seed;
      instance.Factor = factor;
    }

    protected HashCombiner()
    {
    }
  }
}
