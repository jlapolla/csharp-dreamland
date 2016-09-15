namespace He4.Projects.SafeBits.Casts
{

  public static class CastProperties
  {

    /*
     * Copy these templates and find / replace T1 and T2
     *

    public static bool IsValueCopy(Cast<T1, T2> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = cast.Destination == cast.Source;
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

    public static bool IsValueCopy(Cast<sbyte, sbyte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = cast.Destination == cast.Source;
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
  }
}
