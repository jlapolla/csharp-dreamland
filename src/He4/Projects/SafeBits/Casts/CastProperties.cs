namespace He4.Projects.SafeBits.Casts
{

  public static class CastProperties
  {

    public static bool IsValueCopy(Cast<sbyte, sbyte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if true // sbyte.MaxValue >= sbyte.MaxValue && sbyte.MinValue >= sbyte.MinValue
        result = (cast.Destination == ((sbyte) cast.Source));
#elif false // sbyte.MaxValue >= sbyte.MaxValue && sbyte.MinValue < sbyte.MinValue
        if (cast.Source >= sbyte.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((sbyte) cast.Source));
        }
#elif false // sbyte.MaxValue < sbyte.MaxValue && sbyte.MinValue >= sbyte.MinValue
        if (cast.Source <= sbyte.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((sbyte) cast.Source));
        }
#elif false // sbyte.MaxValue < sbyte.MaxValue && sbyte.MinValue < sbyte.MinValue
        result = (cast.Source == ((sbyte) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<sbyte, sbyte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        sbyte sourceBit = 1;
        sbyte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          if (i < sourceLimit)
          {

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break;
            }

            sourceBit <<= 1;
          }
          else
          {

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break;
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<sbyte, sbyte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        sbyte sourceBit = 1;
        sbyte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          if (i < sourceLimit)
          {

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break;
            }

            sourceBit <<= 1;
          }
          else
          {

            if ((cast.Destination & destinationBit) == 0)
            {

              result = false;
              break;
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    /*
     * Copy these templates and find / replace T1 and T2
     *

    public static bool IsValueCopy(Cast<T1, T2> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // T2.MaxValue >= T1.MaxValue && T1.MinValue >= T2.MinValue
        result = (cast.Destination == ((T2) cast.Source));
#elif false // T2.MaxValue >= T1.MaxValue && T1.MinValue < T2.MinValue
        if (cast.Source >= T2.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((T2) cast.Source));
        }
#elif false // T2.MaxValue < T1.MaxValue && T1.MinValue >= T2.MinValue
        if (cast.Source <= T2.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((T2) cast.Source));
        }
#elif false // T2.MaxValue < T1.MaxValue && T1.MinValue < T2.MinValue
        result = (cast.Source == ((T1) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<T1, T2> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        T1 sourceBit = 1;
        T2 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          if (i < sourceLimit)
          {

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break;
            }

            sourceBit <<= 1;
          }
          else
          {

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break;
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<T1, T2> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        T1 sourceBit = 1;
        T2 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          if (i < sourceLimit)
          {

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break;
            }

            sourceBit <<= 1;
          }
          else
          {

            if ((cast.Destination & destinationBit) == 0)
            {

              result = false;
              break;
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }
    */

    public static bool IsValueCopy(Cast<ulong, long> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // long.MaxValue >= ulong.MaxValue && ulong.MinValue >= long.MinValue
        result = (cast.Destination == ((long) cast.Source));
#elif false // long.MaxValue >= ulong.MaxValue && ulong.MinValue < long.MinValue
        if (cast.Source >= long.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((long) cast.Source));
        }
#elif true // long.MaxValue < ulong.MaxValue && ulong.MinValue >= long.MinValue
        if (cast.Source <= long.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((long) cast.Source));
        }
#elif false // long.MaxValue < ulong.MaxValue && ulong.MinValue < long.MinValue
        result = (cast.Source == ((ulong) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<ulong, long> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ulong sourceBit = 1;
        long destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          if (i < sourceLimit)
          {

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break;
            }

            sourceBit <<= 1;
          }
          else
          {

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break;
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<ulong, long> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ulong sourceBit = 1;
        long destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          if (i < sourceLimit)
          {

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break;
            }

            sourceBit <<= 1;
          }
          else
          {

            if ((cast.Destination & destinationBit) == 0)
            {

              result = false;
              break;
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<ulong, ulong> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if true // ulong.MaxValue >= ulong.MaxValue && ulong.MinValue >= ulong.MinValue
        result = (cast.Destination == ((ulong) cast.Source));
#elif false // ulong.MaxValue >= ulong.MaxValue && ulong.MinValue < ulong.MinValue
        if (cast.Source >= ulong.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ulong) cast.Source));
        }
#elif false // ulong.MaxValue < ulong.MaxValue && ulong.MinValue >= ulong.MinValue
        if (cast.Source <= ulong.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ulong) cast.Source));
        }
#elif false // ulong.MaxValue < ulong.MaxValue && ulong.MinValue < ulong.MinValue
        result = (cast.Source == ((ulong) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<ulong, ulong> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ulong sourceBit = 1;
        ulong destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          if (i < sourceLimit)
          {

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break;
            }

            sourceBit <<= 1;
          }
          else
          {

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break;
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<ulong, ulong> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ulong sourceBit = 1;
        ulong destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          if (i < sourceLimit)
          {

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break;
            }

            sourceBit <<= 1;
          }
          else
          {

            if ((cast.Destination & destinationBit) == 0)
            {

              result = false;
              break;
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }
  }
}
