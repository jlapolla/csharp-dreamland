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

#if false

    /*
     * Copy these templates and find / replace T1 and T2
     */

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
#endif

    public static bool IsValueCopy(Cast<ulong, sbyte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // sbyte.MaxValue >= ulong.MaxValue && ulong.MinValue >= sbyte.MinValue
        result = (cast.Destination == ((sbyte) cast.Source));
#elif false // sbyte.MaxValue >= ulong.MaxValue && ulong.MinValue < sbyte.MinValue
        if (cast.Source >= sbyte.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((sbyte) cast.Source));
        }
#elif true // sbyte.MaxValue < ulong.MaxValue && ulong.MinValue >= sbyte.MinValue
        if (cast.Source <= (ulong) sbyte.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((sbyte) cast.Source));
        }
#elif false // sbyte.MaxValue < ulong.MaxValue && ulong.MinValue < sbyte.MinValue
        result = (cast.Source == ((ulong) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<ulong, sbyte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ulong sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<ulong, sbyte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ulong sourceBit = 1;
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

    public static bool IsValueCopy(Cast<ulong, byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // byte.MaxValue >= ulong.MaxValue && ulong.MinValue >= byte.MinValue
        result = (cast.Destination == ((byte) cast.Source));
#elif false // byte.MaxValue >= ulong.MaxValue && ulong.MinValue < byte.MinValue
        if (cast.Source >= byte.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((byte) cast.Source));
        }
#elif true // byte.MaxValue < ulong.MaxValue && ulong.MinValue >= byte.MinValue
        if (cast.Source <= byte.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((byte) cast.Source));
        }
#elif false // byte.MaxValue < ulong.MaxValue && ulong.MinValue < byte.MinValue
        result = (cast.Source == ((ulong) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<ulong, byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ulong sourceBit = 1;
        byte destinationBit = 1;

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

    public static bool IsOneFillBinaryCopy(Cast<ulong, byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ulong sourceBit = 1;
        byte destinationBit = 1;

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

    public static bool IsValueCopy(Cast<ulong, short> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // short.MaxValue >= ulong.MaxValue && ulong.MinValue >= short.MinValue
        result = (cast.Destination == ((short) cast.Source));
#elif false // short.MaxValue >= ulong.MaxValue && ulong.MinValue < short.MinValue
        if (cast.Source >= short.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((short) cast.Source));
        }
#elif true // short.MaxValue < ulong.MaxValue && ulong.MinValue >= short.MinValue
        if (cast.Source <= (ulong) short.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((short) cast.Source));
        }
#elif false // short.MaxValue < ulong.MaxValue && ulong.MinValue < short.MinValue
        result = (cast.Source == ((ulong) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<ulong, short> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ulong sourceBit = 1;
        short destinationBit = 1;

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

    public static bool IsOneFillBinaryCopy(Cast<ulong, short> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ulong sourceBit = 1;
        short destinationBit = 1;

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

    public static bool IsValueCopy(Cast<ulong, ushort> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // ushort.MaxValue >= ulong.MaxValue && ulong.MinValue >= ushort.MinValue
        result = (cast.Destination == ((ushort) cast.Source));
#elif false // ushort.MaxValue >= ulong.MaxValue && ulong.MinValue < ushort.MinValue
        if (cast.Source >= ushort.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ushort) cast.Source));
        }
#elif true // ushort.MaxValue < ulong.MaxValue && ulong.MinValue >= ushort.MinValue
        if (cast.Source <= ushort.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ushort) cast.Source));
        }
#elif false // ushort.MaxValue < ulong.MaxValue && ulong.MinValue < ushort.MinValue
        result = (cast.Source == ((ulong) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<ulong, ushort> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ulong sourceBit = 1;
        ushort destinationBit = 1;

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

    public static bool IsOneFillBinaryCopy(Cast<ulong, ushort> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ulong sourceBit = 1;
        ushort destinationBit = 1;

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

    public static bool IsValueCopy(Cast<ulong, int> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // int.MaxValue >= ulong.MaxValue && ulong.MinValue >= int.MinValue
        result = (cast.Destination == ((int) cast.Source));
#elif false // int.MaxValue >= ulong.MaxValue && ulong.MinValue < int.MinValue
        if (cast.Source >= int.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((int) cast.Source));
        }
#elif true // int.MaxValue < ulong.MaxValue && ulong.MinValue >= int.MinValue
        if (cast.Source <= int.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((int) cast.Source));
        }
#elif false // int.MaxValue < ulong.MaxValue && ulong.MinValue < int.MinValue
        result = (cast.Source == ((ulong) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<ulong, int> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ulong sourceBit = 1;
        int destinationBit = 1;

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

    public static bool IsOneFillBinaryCopy(Cast<ulong, int> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ulong sourceBit = 1;
        int destinationBit = 1;

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

    public static bool IsValueCopy(Cast<ulong, uint> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // uint.MaxValue >= ulong.MaxValue && ulong.MinValue >= uint.MinValue
        result = (cast.Destination == ((uint) cast.Source));
#elif false // uint.MaxValue >= ulong.MaxValue && ulong.MinValue < uint.MinValue
        if (cast.Source >= uint.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((uint) cast.Source));
        }
#elif true // uint.MaxValue < ulong.MaxValue && ulong.MinValue >= uint.MinValue
        if (cast.Source <= uint.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((uint) cast.Source));
        }
#elif false // uint.MaxValue < ulong.MaxValue && ulong.MinValue < uint.MinValue
        result = (cast.Source == ((ulong) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<ulong, uint> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ulong sourceBit = 1;
        uint destinationBit = 1;

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

    public static bool IsOneFillBinaryCopy(Cast<ulong, uint> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ulong sourceBit = 1;
        uint destinationBit = 1;

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
