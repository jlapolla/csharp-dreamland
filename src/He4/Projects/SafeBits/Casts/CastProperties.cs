namespace He4.Projects.SafeBits.Casts
{

  public static class CastProperties
  {

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

    public static bool IsValueCopy(Cast<sbyte, byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // byte.MaxValue >= sbyte.MaxValue && sbyte.MinValue >= byte.MinValue
        result = (cast.Destination == ((byte) cast.Source));
#elif true // byte.MaxValue >= sbyte.MaxValue && sbyte.MinValue < byte.MinValue
        if (cast.Source >= byte.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((byte) cast.Source));
        }
#elif false // byte.MaxValue < sbyte.MaxValue && sbyte.MinValue >= byte.MinValue
        if (cast.Source <= byte.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((byte) cast.Source));
        }
#elif false // byte.MaxValue < sbyte.MaxValue && sbyte.MinValue < byte.MinValue
        result = (cast.Source == ((sbyte) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<sbyte, byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        sbyte sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<sbyte, byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        sbyte sourceBit = 1;
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

    public static bool IsValueCopy(Cast<sbyte, short> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if true // short.MaxValue >= sbyte.MaxValue && sbyte.MinValue >= short.MinValue
        result = (cast.Destination == ((short) cast.Source));
#elif false // short.MaxValue >= sbyte.MaxValue && sbyte.MinValue < short.MinValue
        if (cast.Source >= short.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((short) cast.Source));
        }
#elif false // short.MaxValue < sbyte.MaxValue && sbyte.MinValue >= short.MinValue
        if (cast.Source <= short.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((short) cast.Source));
        }
#elif false // short.MaxValue < sbyte.MaxValue && sbyte.MinValue < short.MinValue
        result = (cast.Source == ((sbyte) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<sbyte, short> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        sbyte sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<sbyte, short> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        sbyte sourceBit = 1;
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

    public static bool IsValueCopy(Cast<sbyte, ushort> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // ushort.MaxValue >= sbyte.MaxValue && sbyte.MinValue >= ushort.MinValue
        result = (cast.Destination == ((ushort) cast.Source));
#elif true // ushort.MaxValue >= sbyte.MaxValue && sbyte.MinValue < ushort.MinValue
        if (cast.Source >= ushort.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ushort) cast.Source));
        }
#elif false // ushort.MaxValue < sbyte.MaxValue && sbyte.MinValue >= ushort.MinValue
        if (cast.Source <= ushort.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ushort) cast.Source));
        }
#elif false // ushort.MaxValue < sbyte.MaxValue && sbyte.MinValue < ushort.MinValue
        result = (cast.Source == ((sbyte) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<sbyte, ushort> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        sbyte sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<sbyte, ushort> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        sbyte sourceBit = 1;
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

    public static bool IsValueCopy(Cast<sbyte, int> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if true // int.MaxValue >= sbyte.MaxValue && sbyte.MinValue >= int.MinValue
        result = (cast.Destination == ((int) cast.Source));
#elif false // int.MaxValue >= sbyte.MaxValue && sbyte.MinValue < int.MinValue
        if (cast.Source >= int.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((int) cast.Source));
        }
#elif false // int.MaxValue < sbyte.MaxValue && sbyte.MinValue >= int.MinValue
        if (cast.Source <= int.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((int) cast.Source));
        }
#elif false // int.MaxValue < sbyte.MaxValue && sbyte.MinValue < int.MinValue
        result = (cast.Source == ((sbyte) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<sbyte, int> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        sbyte sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<sbyte, int> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        sbyte sourceBit = 1;
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

    public static bool IsValueCopy(Cast<sbyte, uint> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // uint.MaxValue >= sbyte.MaxValue && sbyte.MinValue >= uint.MinValue
        result = (cast.Destination == ((uint) cast.Source));
#elif true // uint.MaxValue >= sbyte.MaxValue && sbyte.MinValue < uint.MinValue
        if (cast.Source >= uint.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((uint) cast.Source));
        }
#elif false // uint.MaxValue < sbyte.MaxValue && sbyte.MinValue >= uint.MinValue
        if (cast.Source <= uint.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((uint) cast.Source));
        }
#elif false // uint.MaxValue < sbyte.MaxValue && sbyte.MinValue < uint.MinValue
        result = (cast.Source == ((sbyte) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<sbyte, uint> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        sbyte sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<sbyte, uint> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        sbyte sourceBit = 1;
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

    public static bool IsValueCopy(Cast<sbyte, long> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if true // long.MaxValue >= sbyte.MaxValue && sbyte.MinValue >= long.MinValue
        result = (cast.Destination == ((long) cast.Source));
#elif false // long.MaxValue >= sbyte.MaxValue && sbyte.MinValue < long.MinValue
        if (cast.Source >= long.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((long) cast.Source));
        }
#elif false // long.MaxValue < sbyte.MaxValue && sbyte.MinValue >= long.MinValue
        if (cast.Source <= long.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((long) cast.Source));
        }
#elif false // long.MaxValue < sbyte.MaxValue && sbyte.MinValue < long.MinValue
        result = (cast.Source == ((sbyte) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<sbyte, long> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        sbyte sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<sbyte, long> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        sbyte sourceBit = 1;
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

    public static bool IsValueCopy(Cast<sbyte, ulong> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // ulong.MaxValue >= sbyte.MaxValue && sbyte.MinValue >= ulong.MinValue
        result = (cast.Destination == ((ulong) cast.Source));
#elif true // ulong.MaxValue >= sbyte.MaxValue && sbyte.MinValue < ulong.MinValue
        if (cast.Source >= ulong.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ulong) cast.Source));
        }
#elif false // ulong.MaxValue < sbyte.MaxValue && sbyte.MinValue >= ulong.MinValue
        if (cast.Source <= ulong.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ulong) cast.Source));
        }
#elif false // ulong.MaxValue < sbyte.MaxValue && sbyte.MinValue < ulong.MinValue
        result = (cast.Source == ((sbyte) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<sbyte, ulong> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        sbyte sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<sbyte, ulong> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        sbyte sourceBit = 1;
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

    public static bool IsValueCopy(Cast<byte, sbyte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // sbyte.MaxValue >= byte.MaxValue && byte.MinValue >= sbyte.MinValue
        result = (cast.Destination == ((sbyte) cast.Source));
#elif false // sbyte.MaxValue >= byte.MaxValue && byte.MinValue < sbyte.MinValue
        if (cast.Source >= sbyte.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((sbyte) cast.Source));
        }
#elif true // sbyte.MaxValue < byte.MaxValue && byte.MinValue >= sbyte.MinValue
        if (cast.Source <= sbyte.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((sbyte) cast.Source));
        }
#elif false // sbyte.MaxValue < byte.MaxValue && byte.MinValue < sbyte.MinValue
        result = (cast.Source == ((byte) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<byte, sbyte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        byte sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<byte, sbyte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        byte sourceBit = 1;
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

    public static bool IsValueCopy(Cast<byte, byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if true // byte.MaxValue >= byte.MaxValue && byte.MinValue >= byte.MinValue
        result = (cast.Destination == ((byte) cast.Source));
#elif false // byte.MaxValue >= byte.MaxValue && byte.MinValue < byte.MinValue
        if (cast.Source >= byte.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((byte) cast.Source));
        }
#elif false // byte.MaxValue < byte.MaxValue && byte.MinValue >= byte.MinValue
        if (cast.Source <= byte.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((byte) cast.Source));
        }
#elif false // byte.MaxValue < byte.MaxValue && byte.MinValue < byte.MinValue
        result = (cast.Source == ((byte) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<byte, byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        byte sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<byte, byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        byte sourceBit = 1;
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

    public static bool IsValueCopy(Cast<byte, short> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if true // short.MaxValue >= byte.MaxValue && byte.MinValue >= short.MinValue
        result = (cast.Destination == ((short) cast.Source));
#elif false // short.MaxValue >= byte.MaxValue && byte.MinValue < short.MinValue
        if (cast.Source >= short.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((short) cast.Source));
        }
#elif false // short.MaxValue < byte.MaxValue && byte.MinValue >= short.MinValue
        if (cast.Source <= short.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((short) cast.Source));
        }
#elif false // short.MaxValue < byte.MaxValue && byte.MinValue < short.MinValue
        result = (cast.Source == ((byte) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<byte, short> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        byte sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<byte, short> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        byte sourceBit = 1;
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

    public static bool IsValueCopy(Cast<byte, ushort> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if true // ushort.MaxValue >= byte.MaxValue && byte.MinValue >= ushort.MinValue
        result = (cast.Destination == ((ushort) cast.Source));
#elif false // ushort.MaxValue >= byte.MaxValue && byte.MinValue < ushort.MinValue
        if (cast.Source >= ushort.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ushort) cast.Source));
        }
#elif false // ushort.MaxValue < byte.MaxValue && byte.MinValue >= ushort.MinValue
        if (cast.Source <= ushort.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ushort) cast.Source));
        }
#elif false // ushort.MaxValue < byte.MaxValue && byte.MinValue < ushort.MinValue
        result = (cast.Source == ((byte) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<byte, ushort> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        byte sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<byte, ushort> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        byte sourceBit = 1;
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

    public static bool IsValueCopy(Cast<byte, int> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if true // int.MaxValue >= byte.MaxValue && byte.MinValue >= int.MinValue
        result = (cast.Destination == ((int) cast.Source));
#elif false // int.MaxValue >= byte.MaxValue && byte.MinValue < int.MinValue
        if (cast.Source >= int.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((int) cast.Source));
        }
#elif false // int.MaxValue < byte.MaxValue && byte.MinValue >= int.MinValue
        if (cast.Source <= int.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((int) cast.Source));
        }
#elif false // int.MaxValue < byte.MaxValue && byte.MinValue < int.MinValue
        result = (cast.Source == ((byte) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<byte, int> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        byte sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<byte, int> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        byte sourceBit = 1;
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

    public static bool IsValueCopy(Cast<byte, uint> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if true // uint.MaxValue >= byte.MaxValue && byte.MinValue >= uint.MinValue
        result = (cast.Destination == ((uint) cast.Source));
#elif false // uint.MaxValue >= byte.MaxValue && byte.MinValue < uint.MinValue
        if (cast.Source >= uint.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((uint) cast.Source));
        }
#elif false // uint.MaxValue < byte.MaxValue && byte.MinValue >= uint.MinValue
        if (cast.Source <= uint.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((uint) cast.Source));
        }
#elif false // uint.MaxValue < byte.MaxValue && byte.MinValue < uint.MinValue
        result = (cast.Source == ((byte) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<byte, uint> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        byte sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<byte, uint> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        byte sourceBit = 1;
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

    public static bool IsValueCopy(Cast<byte, long> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if true // long.MaxValue >= byte.MaxValue && byte.MinValue >= long.MinValue
        result = (cast.Destination == ((long) cast.Source));
#elif false // long.MaxValue >= byte.MaxValue && byte.MinValue < long.MinValue
        if (cast.Source >= long.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((long) cast.Source));
        }
#elif false // long.MaxValue < byte.MaxValue && byte.MinValue >= long.MinValue
        if (cast.Source <= long.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((long) cast.Source));
        }
#elif false // long.MaxValue < byte.MaxValue && byte.MinValue < long.MinValue
        result = (cast.Source == ((byte) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<byte, long> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        byte sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<byte, long> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        byte sourceBit = 1;
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

    public static bool IsValueCopy(Cast<byte, ulong> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if true // ulong.MaxValue >= byte.MaxValue && byte.MinValue >= ulong.MinValue
        result = (cast.Destination == ((ulong) cast.Source));
#elif false // ulong.MaxValue >= byte.MaxValue && byte.MinValue < ulong.MinValue
        if (cast.Source >= ulong.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ulong) cast.Source));
        }
#elif false // ulong.MaxValue < byte.MaxValue && byte.MinValue >= ulong.MinValue
        if (cast.Source <= ulong.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ulong) cast.Source));
        }
#elif false // ulong.MaxValue < byte.MaxValue && byte.MinValue < ulong.MinValue
        result = (cast.Source == ((byte) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<byte, ulong> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        byte sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<byte, ulong> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        byte sourceBit = 1;
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

    public static bool IsValueCopy(Cast<short, sbyte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // sbyte.MaxValue >= short.MaxValue && short.MinValue >= sbyte.MinValue
        result = (cast.Destination == ((sbyte) cast.Source));
#elif false // sbyte.MaxValue >= short.MaxValue && short.MinValue < sbyte.MinValue
        if (cast.Source >= sbyte.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((sbyte) cast.Source));
        }
#elif false // sbyte.MaxValue < short.MaxValue && short.MinValue >= sbyte.MinValue
        if (cast.Source <= sbyte.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((sbyte) cast.Source));
        }
#elif true // sbyte.MaxValue < short.MaxValue && short.MinValue < sbyte.MinValue
        result = (cast.Source == ((short) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<short, sbyte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        short sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<short, sbyte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        short sourceBit = 1;
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

    public static bool IsValueCopy(Cast<short, byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // byte.MaxValue >= short.MaxValue && short.MinValue >= byte.MinValue
        result = (cast.Destination == ((byte) cast.Source));
#elif false // byte.MaxValue >= short.MaxValue && short.MinValue < byte.MinValue
        if (cast.Source >= byte.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((byte) cast.Source));
        }
#elif false // byte.MaxValue < short.MaxValue && short.MinValue >= byte.MinValue
        if (cast.Source <= byte.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((byte) cast.Source));
        }
#elif true // byte.MaxValue < short.MaxValue && short.MinValue < byte.MinValue
        result = (cast.Source == ((short) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<short, byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        short sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<short, byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        short sourceBit = 1;
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

    public static bool IsValueCopy(Cast<short, short> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if true // short.MaxValue >= short.MaxValue && short.MinValue >= short.MinValue
        result = (cast.Destination == ((short) cast.Source));
#elif false // short.MaxValue >= short.MaxValue && short.MinValue < short.MinValue
        if (cast.Source >= short.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((short) cast.Source));
        }
#elif false // short.MaxValue < short.MaxValue && short.MinValue >= short.MinValue
        if (cast.Source <= short.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((short) cast.Source));
        }
#elif false // short.MaxValue < short.MaxValue && short.MinValue < short.MinValue
        result = (cast.Source == ((short) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<short, short> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        short sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<short, short> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        short sourceBit = 1;
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

    public static bool IsValueCopy(Cast<short, ushort> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // ushort.MaxValue >= short.MaxValue && short.MinValue >= ushort.MinValue
        result = (cast.Destination == ((ushort) cast.Source));
#elif true // ushort.MaxValue >= short.MaxValue && short.MinValue < ushort.MinValue
        if (cast.Source >= ushort.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ushort) cast.Source));
        }
#elif false // ushort.MaxValue < short.MaxValue && short.MinValue >= ushort.MinValue
        if (cast.Source <= ushort.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ushort) cast.Source));
        }
#elif false // ushort.MaxValue < short.MaxValue && short.MinValue < ushort.MinValue
        result = (cast.Source == ((short) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<short, ushort> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        short sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<short, ushort> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        short sourceBit = 1;
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

    public static bool IsValueCopy(Cast<short, int> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if true // int.MaxValue >= short.MaxValue && short.MinValue >= int.MinValue
        result = (cast.Destination == ((int) cast.Source));
#elif false // int.MaxValue >= short.MaxValue && short.MinValue < int.MinValue
        if (cast.Source >= int.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((int) cast.Source));
        }
#elif false // int.MaxValue < short.MaxValue && short.MinValue >= int.MinValue
        if (cast.Source <= int.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((int) cast.Source));
        }
#elif false // int.MaxValue < short.MaxValue && short.MinValue < int.MinValue
        result = (cast.Source == ((short) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<short, int> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        short sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<short, int> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        short sourceBit = 1;
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

    public static bool IsValueCopy(Cast<short, uint> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // uint.MaxValue >= short.MaxValue && short.MinValue >= uint.MinValue
        result = (cast.Destination == ((uint) cast.Source));
#elif true // uint.MaxValue >= short.MaxValue && short.MinValue < uint.MinValue
        if (cast.Source >= uint.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((uint) cast.Source));
        }
#elif false // uint.MaxValue < short.MaxValue && short.MinValue >= uint.MinValue
        if (cast.Source <= uint.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((uint) cast.Source));
        }
#elif false // uint.MaxValue < short.MaxValue && short.MinValue < uint.MinValue
        result = (cast.Source == ((short) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<short, uint> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        short sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<short, uint> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        short sourceBit = 1;
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

    public static bool IsValueCopy(Cast<short, long> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if true // long.MaxValue >= short.MaxValue && short.MinValue >= long.MinValue
        result = (cast.Destination == ((long) cast.Source));
#elif false // long.MaxValue >= short.MaxValue && short.MinValue < long.MinValue
        if (cast.Source >= long.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((long) cast.Source));
        }
#elif false // long.MaxValue < short.MaxValue && short.MinValue >= long.MinValue
        if (cast.Source <= long.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((long) cast.Source));
        }
#elif false // long.MaxValue < short.MaxValue && short.MinValue < long.MinValue
        result = (cast.Source == ((short) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<short, long> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        short sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<short, long> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        short sourceBit = 1;
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

    public static bool IsValueCopy(Cast<short, ulong> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // ulong.MaxValue >= short.MaxValue && short.MinValue >= ulong.MinValue
        result = (cast.Destination == ((ulong) cast.Source));
#elif true // ulong.MaxValue >= short.MaxValue && short.MinValue < ulong.MinValue
        if (cast.Source >= ulong.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ulong) cast.Source));
        }
#elif false // ulong.MaxValue < short.MaxValue && short.MinValue >= ulong.MinValue
        if (cast.Source <= ulong.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ulong) cast.Source));
        }
#elif false // ulong.MaxValue < short.MaxValue && short.MinValue < ulong.MinValue
        result = (cast.Source == ((short) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<short, ulong> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        short sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<short, ulong> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        short sourceBit = 1;
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

    public static bool IsValueCopy(Cast<ushort, sbyte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // sbyte.MaxValue >= ushort.MaxValue && ushort.MinValue >= sbyte.MinValue
        result = (cast.Destination == ((sbyte) cast.Source));
#elif false // sbyte.MaxValue >= ushort.MaxValue && ushort.MinValue < sbyte.MinValue
        if (cast.Source >= sbyte.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((sbyte) cast.Source));
        }
#elif true // sbyte.MaxValue < ushort.MaxValue && ushort.MinValue >= sbyte.MinValue
        if (cast.Source <= sbyte.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((sbyte) cast.Source));
        }
#elif false // sbyte.MaxValue < ushort.MaxValue && ushort.MinValue < sbyte.MinValue
        result = (cast.Source == ((ushort) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<ushort, sbyte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ushort sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<ushort, sbyte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ushort sourceBit = 1;
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

    public static bool IsValueCopy(Cast<ushort, byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // byte.MaxValue >= ushort.MaxValue && ushort.MinValue >= byte.MinValue
        result = (cast.Destination == ((byte) cast.Source));
#elif false // byte.MaxValue >= ushort.MaxValue && ushort.MinValue < byte.MinValue
        if (cast.Source >= byte.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((byte) cast.Source));
        }
#elif true // byte.MaxValue < ushort.MaxValue && ushort.MinValue >= byte.MinValue
        if (cast.Source <= byte.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((byte) cast.Source));
        }
#elif false // byte.MaxValue < ushort.MaxValue && ushort.MinValue < byte.MinValue
        result = (cast.Source == ((ushort) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<ushort, byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ushort sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<ushort, byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ushort sourceBit = 1;
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

    public static bool IsValueCopy(Cast<ushort, short> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // short.MaxValue >= ushort.MaxValue && ushort.MinValue >= short.MinValue
        result = (cast.Destination == ((short) cast.Source));
#elif false // short.MaxValue >= ushort.MaxValue && ushort.MinValue < short.MinValue
        if (cast.Source >= short.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((short) cast.Source));
        }
#elif true // short.MaxValue < ushort.MaxValue && ushort.MinValue >= short.MinValue
        if (cast.Source <= short.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((short) cast.Source));
        }
#elif false // short.MaxValue < ushort.MaxValue && ushort.MinValue < short.MinValue
        result = (cast.Source == ((ushort) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<ushort, short> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ushort sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<ushort, short> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ushort sourceBit = 1;
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

    public static bool IsValueCopy(Cast<ushort, ushort> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if true // ushort.MaxValue >= ushort.MaxValue && ushort.MinValue >= ushort.MinValue
        result = (cast.Destination == ((ushort) cast.Source));
#elif false // ushort.MaxValue >= ushort.MaxValue && ushort.MinValue < ushort.MinValue
        if (cast.Source >= ushort.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ushort) cast.Source));
        }
#elif false // ushort.MaxValue < ushort.MaxValue && ushort.MinValue >= ushort.MinValue
        if (cast.Source <= ushort.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ushort) cast.Source));
        }
#elif false // ushort.MaxValue < ushort.MaxValue && ushort.MinValue < ushort.MinValue
        result = (cast.Source == ((ushort) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<ushort, ushort> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ushort sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<ushort, ushort> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ushort sourceBit = 1;
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

    public static bool IsValueCopy(Cast<ushort, int> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if true // int.MaxValue >= ushort.MaxValue && ushort.MinValue >= int.MinValue
        result = (cast.Destination == ((int) cast.Source));
#elif false // int.MaxValue >= ushort.MaxValue && ushort.MinValue < int.MinValue
        if (cast.Source >= int.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((int) cast.Source));
        }
#elif false // int.MaxValue < ushort.MaxValue && ushort.MinValue >= int.MinValue
        if (cast.Source <= int.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((int) cast.Source));
        }
#elif false // int.MaxValue < ushort.MaxValue && ushort.MinValue < int.MinValue
        result = (cast.Source == ((ushort) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<ushort, int> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ushort sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<ushort, int> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ushort sourceBit = 1;
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

    public static bool IsValueCopy(Cast<ushort, uint> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if true // uint.MaxValue >= ushort.MaxValue && ushort.MinValue >= uint.MinValue
        result = (cast.Destination == ((uint) cast.Source));
#elif false // uint.MaxValue >= ushort.MaxValue && ushort.MinValue < uint.MinValue
        if (cast.Source >= uint.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((uint) cast.Source));
        }
#elif false // uint.MaxValue < ushort.MaxValue && ushort.MinValue >= uint.MinValue
        if (cast.Source <= uint.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((uint) cast.Source));
        }
#elif false // uint.MaxValue < ushort.MaxValue && ushort.MinValue < uint.MinValue
        result = (cast.Source == ((ushort) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<ushort, uint> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ushort sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<ushort, uint> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ushort sourceBit = 1;
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

    public static bool IsValueCopy(Cast<ushort, long> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if true // long.MaxValue >= ushort.MaxValue && ushort.MinValue >= long.MinValue
        result = (cast.Destination == ((long) cast.Source));
#elif false // long.MaxValue >= ushort.MaxValue && ushort.MinValue < long.MinValue
        if (cast.Source >= long.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((long) cast.Source));
        }
#elif false // long.MaxValue < ushort.MaxValue && ushort.MinValue >= long.MinValue
        if (cast.Source <= long.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((long) cast.Source));
        }
#elif false // long.MaxValue < ushort.MaxValue && ushort.MinValue < long.MinValue
        result = (cast.Source == ((ushort) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<ushort, long> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ushort sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<ushort, long> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ushort sourceBit = 1;
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

    public static bool IsValueCopy(Cast<ushort, ulong> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if true // ulong.MaxValue >= ushort.MaxValue && ushort.MinValue >= ulong.MinValue
        result = (cast.Destination == ((ulong) cast.Source));
#elif false // ulong.MaxValue >= ushort.MaxValue && ushort.MinValue < ulong.MinValue
        if (cast.Source >= ulong.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ulong) cast.Source));
        }
#elif false // ulong.MaxValue < ushort.MaxValue && ushort.MinValue >= ulong.MinValue
        if (cast.Source <= ulong.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ulong) cast.Source));
        }
#elif false // ulong.MaxValue < ushort.MaxValue && ushort.MinValue < ulong.MinValue
        result = (cast.Source == ((ushort) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<ushort, ulong> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ushort sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<ushort, ulong> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        ushort sourceBit = 1;
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

    public static bool IsValueCopy(Cast<int, sbyte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // sbyte.MaxValue >= int.MaxValue && int.MinValue >= sbyte.MinValue
        result = (cast.Destination == ((sbyte) cast.Source));
#elif false // sbyte.MaxValue >= int.MaxValue && int.MinValue < sbyte.MinValue
        if (cast.Source >= sbyte.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((sbyte) cast.Source));
        }
#elif false // sbyte.MaxValue < int.MaxValue && int.MinValue >= sbyte.MinValue
        if (cast.Source <= sbyte.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((sbyte) cast.Source));
        }
#elif true // sbyte.MaxValue < int.MaxValue && int.MinValue < sbyte.MinValue
        result = (cast.Source == ((int) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<int, sbyte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        int sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<int, sbyte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        int sourceBit = 1;
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

    public static bool IsValueCopy(Cast<int, byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // byte.MaxValue >= int.MaxValue && int.MinValue >= byte.MinValue
        result = (cast.Destination == ((byte) cast.Source));
#elif false // byte.MaxValue >= int.MaxValue && int.MinValue < byte.MinValue
        if (cast.Source >= byte.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((byte) cast.Source));
        }
#elif false // byte.MaxValue < int.MaxValue && int.MinValue >= byte.MinValue
        if (cast.Source <= byte.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((byte) cast.Source));
        }
#elif true // byte.MaxValue < int.MaxValue && int.MinValue < byte.MinValue
        result = (cast.Source == ((int) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<int, byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        int sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<int, byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        int sourceBit = 1;
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

    public static bool IsValueCopy(Cast<int, short> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // short.MaxValue >= int.MaxValue && int.MinValue >= short.MinValue
        result = (cast.Destination == ((short) cast.Source));
#elif false // short.MaxValue >= int.MaxValue && int.MinValue < short.MinValue
        if (cast.Source >= short.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((short) cast.Source));
        }
#elif false // short.MaxValue < int.MaxValue && int.MinValue >= short.MinValue
        if (cast.Source <= short.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((short) cast.Source));
        }
#elif true // short.MaxValue < int.MaxValue && int.MinValue < short.MinValue
        result = (cast.Source == ((int) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<int, short> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        int sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<int, short> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        int sourceBit = 1;
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

    public static bool IsValueCopy(Cast<int, ushort> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // ushort.MaxValue >= int.MaxValue && int.MinValue >= ushort.MinValue
        result = (cast.Destination == ((ushort) cast.Source));
#elif false // ushort.MaxValue >= int.MaxValue && int.MinValue < ushort.MinValue
        if (cast.Source >= ushort.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ushort) cast.Source));
        }
#elif false // ushort.MaxValue < int.MaxValue && int.MinValue >= ushort.MinValue
        if (cast.Source <= ushort.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ushort) cast.Source));
        }
#elif true // ushort.MaxValue < int.MaxValue && int.MinValue < ushort.MinValue
        result = (cast.Source == ((int) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<int, ushort> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        int sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<int, ushort> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        int sourceBit = 1;
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

    public static bool IsValueCopy(Cast<int, int> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if true // int.MaxValue >= int.MaxValue && int.MinValue >= int.MinValue
        result = (cast.Destination == ((int) cast.Source));
#elif false // int.MaxValue >= int.MaxValue && int.MinValue < int.MinValue
        if (cast.Source >= int.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((int) cast.Source));
        }
#elif false // int.MaxValue < int.MaxValue && int.MinValue >= int.MinValue
        if (cast.Source <= int.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((int) cast.Source));
        }
#elif false // int.MaxValue < int.MaxValue && int.MinValue < int.MinValue
        result = (cast.Source == ((int) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<int, int> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        int sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<int, int> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        int sourceBit = 1;
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

    public static bool IsValueCopy(Cast<int, uint> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // uint.MaxValue >= int.MaxValue && int.MinValue >= uint.MinValue
        result = (cast.Destination == ((uint) cast.Source));
#elif true // uint.MaxValue >= int.MaxValue && int.MinValue < uint.MinValue
        if (cast.Source >= uint.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((uint) cast.Source));
        }
#elif false // uint.MaxValue < int.MaxValue && int.MinValue >= uint.MinValue
        if (cast.Source <= uint.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((uint) cast.Source));
        }
#elif false // uint.MaxValue < int.MaxValue && int.MinValue < uint.MinValue
        result = (cast.Source == ((int) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<int, uint> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        int sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<int, uint> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        int sourceBit = 1;
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

    public static bool IsValueCopy(Cast<int, long> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if true // long.MaxValue >= int.MaxValue && int.MinValue >= long.MinValue
        result = (cast.Destination == ((long) cast.Source));
#elif false // long.MaxValue >= int.MaxValue && int.MinValue < long.MinValue
        if (cast.Source >= long.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((long) cast.Source));
        }
#elif false // long.MaxValue < int.MaxValue && int.MinValue >= long.MinValue
        if (cast.Source <= long.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((long) cast.Source));
        }
#elif false // long.MaxValue < int.MaxValue && int.MinValue < long.MinValue
        result = (cast.Source == ((int) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<int, long> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        int sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<int, long> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        int sourceBit = 1;
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

    public static bool IsValueCopy(Cast<int, ulong> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // ulong.MaxValue >= int.MaxValue && int.MinValue >= ulong.MinValue
        result = (cast.Destination == ((ulong) cast.Source));
#elif true // ulong.MaxValue >= int.MaxValue && int.MinValue < ulong.MinValue
        if (cast.Source >= ulong.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ulong) cast.Source));
        }
#elif false // ulong.MaxValue < int.MaxValue && int.MinValue >= ulong.MinValue
        if (cast.Source <= ulong.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ulong) cast.Source));
        }
#elif false // ulong.MaxValue < int.MaxValue && int.MinValue < ulong.MinValue
        result = (cast.Source == ((int) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<int, ulong> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        int sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<int, ulong> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        int sourceBit = 1;
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

    public static bool IsValueCopy(Cast<uint, sbyte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // sbyte.MaxValue >= uint.MaxValue && uint.MinValue >= sbyte.MinValue
        result = (cast.Destination == ((sbyte) cast.Source));
#elif false // sbyte.MaxValue >= uint.MaxValue && uint.MinValue < sbyte.MinValue
        if (cast.Source >= sbyte.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((sbyte) cast.Source));
        }
#elif true // sbyte.MaxValue < uint.MaxValue && uint.MinValue >= sbyte.MinValue
        if (cast.Source <= sbyte.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((sbyte) cast.Source));
        }
#elif false // sbyte.MaxValue < uint.MaxValue && uint.MinValue < sbyte.MinValue
        result = (cast.Source == ((uint) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<uint, sbyte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        uint sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<uint, sbyte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        uint sourceBit = 1;
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

    public static bool IsValueCopy(Cast<uint, byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // byte.MaxValue >= uint.MaxValue && uint.MinValue >= byte.MinValue
        result = (cast.Destination == ((byte) cast.Source));
#elif false // byte.MaxValue >= uint.MaxValue && uint.MinValue < byte.MinValue
        if (cast.Source >= byte.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((byte) cast.Source));
        }
#elif true // byte.MaxValue < uint.MaxValue && uint.MinValue >= byte.MinValue
        if (cast.Source <= byte.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((byte) cast.Source));
        }
#elif false // byte.MaxValue < uint.MaxValue && uint.MinValue < byte.MinValue
        result = (cast.Source == ((uint) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<uint, byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        uint sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<uint, byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        uint sourceBit = 1;
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

    public static bool IsValueCopy(Cast<uint, short> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // short.MaxValue >= uint.MaxValue && uint.MinValue >= short.MinValue
        result = (cast.Destination == ((short) cast.Source));
#elif false // short.MaxValue >= uint.MaxValue && uint.MinValue < short.MinValue
        if (cast.Source >= short.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((short) cast.Source));
        }
#elif true // short.MaxValue < uint.MaxValue && uint.MinValue >= short.MinValue
        if (cast.Source <= short.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((short) cast.Source));
        }
#elif false // short.MaxValue < uint.MaxValue && uint.MinValue < short.MinValue
        result = (cast.Source == ((uint) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<uint, short> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        uint sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<uint, short> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        uint sourceBit = 1;
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

    public static bool IsValueCopy(Cast<uint, ushort> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // ushort.MaxValue >= uint.MaxValue && uint.MinValue >= ushort.MinValue
        result = (cast.Destination == ((ushort) cast.Source));
#elif false // ushort.MaxValue >= uint.MaxValue && uint.MinValue < ushort.MinValue
        if (cast.Source >= ushort.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ushort) cast.Source));
        }
#elif true // ushort.MaxValue < uint.MaxValue && uint.MinValue >= ushort.MinValue
        if (cast.Source <= ushort.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ushort) cast.Source));
        }
#elif false // ushort.MaxValue < uint.MaxValue && uint.MinValue < ushort.MinValue
        result = (cast.Source == ((uint) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<uint, ushort> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        uint sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<uint, ushort> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        uint sourceBit = 1;
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

    public static bool IsValueCopy(Cast<uint, int> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // int.MaxValue >= uint.MaxValue && uint.MinValue >= int.MinValue
        result = (cast.Destination == ((int) cast.Source));
#elif false // int.MaxValue >= uint.MaxValue && uint.MinValue < int.MinValue
        if (cast.Source >= int.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((int) cast.Source));
        }
#elif true // int.MaxValue < uint.MaxValue && uint.MinValue >= int.MinValue
        if (cast.Source <= int.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((int) cast.Source));
        }
#elif false // int.MaxValue < uint.MaxValue && uint.MinValue < int.MinValue
        result = (cast.Source == ((uint) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<uint, int> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        uint sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<uint, int> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        uint sourceBit = 1;
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

    public static bool IsValueCopy(Cast<uint, uint> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if true // uint.MaxValue >= uint.MaxValue && uint.MinValue >= uint.MinValue
        result = (cast.Destination == ((uint) cast.Source));
#elif false // uint.MaxValue >= uint.MaxValue && uint.MinValue < uint.MinValue
        if (cast.Source >= uint.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((uint) cast.Source));
        }
#elif false // uint.MaxValue < uint.MaxValue && uint.MinValue >= uint.MinValue
        if (cast.Source <= uint.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((uint) cast.Source));
        }
#elif false // uint.MaxValue < uint.MaxValue && uint.MinValue < uint.MinValue
        result = (cast.Source == ((uint) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<uint, uint> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        uint sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<uint, uint> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        uint sourceBit = 1;
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

    public static bool IsValueCopy(Cast<uint, long> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if true // long.MaxValue >= uint.MaxValue && uint.MinValue >= long.MinValue
        result = (cast.Destination == ((long) cast.Source));
#elif false // long.MaxValue >= uint.MaxValue && uint.MinValue < long.MinValue
        if (cast.Source >= long.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((long) cast.Source));
        }
#elif false // long.MaxValue < uint.MaxValue && uint.MinValue >= long.MinValue
        if (cast.Source <= long.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((long) cast.Source));
        }
#elif false // long.MaxValue < uint.MaxValue && uint.MinValue < long.MinValue
        result = (cast.Source == ((uint) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<uint, long> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        uint sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<uint, long> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        uint sourceBit = 1;
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

    public static bool IsValueCopy(Cast<uint, ulong> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if true // ulong.MaxValue >= uint.MaxValue && uint.MinValue >= ulong.MinValue
        result = (cast.Destination == ((ulong) cast.Source));
#elif false // ulong.MaxValue >= uint.MaxValue && uint.MinValue < ulong.MinValue
        if (cast.Source >= ulong.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ulong) cast.Source));
        }
#elif false // ulong.MaxValue < uint.MaxValue && uint.MinValue >= ulong.MinValue
        if (cast.Source <= ulong.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ulong) cast.Source));
        }
#elif false // ulong.MaxValue < uint.MaxValue && uint.MinValue < ulong.MinValue
        result = (cast.Source == ((uint) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<uint, ulong> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        uint sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<uint, ulong> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        uint sourceBit = 1;
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

    public static bool IsValueCopy(Cast<long, sbyte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // sbyte.MaxValue >= long.MaxValue && long.MinValue >= sbyte.MinValue
        result = (cast.Destination == ((sbyte) cast.Source));
#elif false // sbyte.MaxValue >= long.MaxValue && long.MinValue < sbyte.MinValue
        if (cast.Source >= sbyte.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((sbyte) cast.Source));
        }
#elif false // sbyte.MaxValue < long.MaxValue && long.MinValue >= sbyte.MinValue
        if (cast.Source <= sbyte.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((sbyte) cast.Source));
        }
#elif true // sbyte.MaxValue < long.MaxValue && long.MinValue < sbyte.MinValue
        result = (cast.Source == ((long) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<long, sbyte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        long sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<long, sbyte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        long sourceBit = 1;
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

    public static bool IsValueCopy(Cast<long, byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // byte.MaxValue >= long.MaxValue && long.MinValue >= byte.MinValue
        result = (cast.Destination == ((byte) cast.Source));
#elif false // byte.MaxValue >= long.MaxValue && long.MinValue < byte.MinValue
        if (cast.Source >= byte.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((byte) cast.Source));
        }
#elif false // byte.MaxValue < long.MaxValue && long.MinValue >= byte.MinValue
        if (cast.Source <= byte.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((byte) cast.Source));
        }
#elif true // byte.MaxValue < long.MaxValue && long.MinValue < byte.MinValue
        result = (cast.Source == ((long) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<long, byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        long sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<long, byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        long sourceBit = 1;
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

    public static bool IsValueCopy(Cast<long, short> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // short.MaxValue >= long.MaxValue && long.MinValue >= short.MinValue
        result = (cast.Destination == ((short) cast.Source));
#elif false // short.MaxValue >= long.MaxValue && long.MinValue < short.MinValue
        if (cast.Source >= short.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((short) cast.Source));
        }
#elif false // short.MaxValue < long.MaxValue && long.MinValue >= short.MinValue
        if (cast.Source <= short.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((short) cast.Source));
        }
#elif true // short.MaxValue < long.MaxValue && long.MinValue < short.MinValue
        result = (cast.Source == ((long) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<long, short> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        long sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<long, short> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        long sourceBit = 1;
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

    public static bool IsValueCopy(Cast<long, ushort> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // ushort.MaxValue >= long.MaxValue && long.MinValue >= ushort.MinValue
        result = (cast.Destination == ((ushort) cast.Source));
#elif false // ushort.MaxValue >= long.MaxValue && long.MinValue < ushort.MinValue
        if (cast.Source >= ushort.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ushort) cast.Source));
        }
#elif false // ushort.MaxValue < long.MaxValue && long.MinValue >= ushort.MinValue
        if (cast.Source <= ushort.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ushort) cast.Source));
        }
#elif true // ushort.MaxValue < long.MaxValue && long.MinValue < ushort.MinValue
        result = (cast.Source == ((long) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<long, ushort> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        long sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<long, ushort> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        long sourceBit = 1;
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

    public static bool IsValueCopy(Cast<long, int> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // int.MaxValue >= long.MaxValue && long.MinValue >= int.MinValue
        result = (cast.Destination == ((int) cast.Source));
#elif false // int.MaxValue >= long.MaxValue && long.MinValue < int.MinValue
        if (cast.Source >= int.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((int) cast.Source));
        }
#elif false // int.MaxValue < long.MaxValue && long.MinValue >= int.MinValue
        if (cast.Source <= int.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((int) cast.Source));
        }
#elif true // int.MaxValue < long.MaxValue && long.MinValue < int.MinValue
        result = (cast.Source == ((long) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<long, int> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        long sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<long, int> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        long sourceBit = 1;
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

    public static bool IsValueCopy(Cast<long, uint> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // uint.MaxValue >= long.MaxValue && long.MinValue >= uint.MinValue
        result = (cast.Destination == ((uint) cast.Source));
#elif false // uint.MaxValue >= long.MaxValue && long.MinValue < uint.MinValue
        if (cast.Source >= uint.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((uint) cast.Source));
        }
#elif false // uint.MaxValue < long.MaxValue && long.MinValue >= uint.MinValue
        if (cast.Source <= uint.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((uint) cast.Source));
        }
#elif true // uint.MaxValue < long.MaxValue && long.MinValue < uint.MinValue
        result = (cast.Source == ((long) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<long, uint> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        long sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<long, uint> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        long sourceBit = 1;
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

    public static bool IsValueCopy(Cast<long, long> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if true // long.MaxValue >= long.MaxValue && long.MinValue >= long.MinValue
        result = (cast.Destination == ((long) cast.Source));
#elif false // long.MaxValue >= long.MaxValue && long.MinValue < long.MinValue
        if (cast.Source >= long.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((long) cast.Source));
        }
#elif false // long.MaxValue < long.MaxValue && long.MinValue >= long.MinValue
        if (cast.Source <= long.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((long) cast.Source));
        }
#elif false // long.MaxValue < long.MaxValue && long.MinValue < long.MinValue
        result = (cast.Source == ((long) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<long, long> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        long sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<long, long> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        long sourceBit = 1;
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

    public static bool IsValueCopy(Cast<long, ulong> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if false // ulong.MaxValue >= long.MaxValue && long.MinValue >= ulong.MinValue
        result = (cast.Destination == ((ulong) cast.Source));
#elif true // ulong.MaxValue >= long.MaxValue && long.MinValue < ulong.MinValue
        if (cast.Source >= ulong.MinValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ulong) cast.Source));
        }
#elif false // ulong.MaxValue < long.MaxValue && long.MinValue >= ulong.MinValue
        if (cast.Source <= ulong.MaxValue)
        {

          // Cast will succeed
          result = (cast.Destination == ((ulong) cast.Source));
        }
#elif false // ulong.MaxValue < long.MaxValue && long.MinValue < ulong.MinValue
        result = (cast.Source == ((long) cast.Destination));
#else
        // Force a compile time error
        You must select one of these branches by replacing "false" with "true"
#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<long, ulong> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        long sourceBit = 1;
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

    public static bool IsOneFillBinaryCopy(Cast<long, ulong> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        long sourceBit = 1;
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
