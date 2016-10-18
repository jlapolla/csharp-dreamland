/*
 * Define integral type range characteristics
 *
 * TYPEXIncludesTYPEY ⇔ (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D)))
 *   D ⇔ TYPEX
 *   S ⇔ TYPEY
 *
 * TYPEXOverlapsTYPEY ⇔ (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D)))
 *   D ⇔ TYPEX
 *   S ⇔ TYPEY
 */

#define SByteIncludesSByte

#define ByteOverlapsSByte
#define ByteIncludesByte

#define Int16IncludesSByte
#define Int16IncludesByte
#define Int16IncludesInt16

#define UInt16OverlapsSByte
#define UInt16IncludesByte
#define UInt16OverlapsInt16
#define UInt16IncludesUInt16

#define Int32IncludesSByte
#define Int32IncludesByte
#define Int32IncludesInt16
#define Int32IncludesUInt16
#define Int32IncludesInt32

#define UInt32OverlapsSByte
#define UInt32IncludesByte
#define UInt32OverlapsInt16
#define UInt32IncludesUInt16
#define UInt32OverlapsInt32
#define UInt32IncludesUInt32

#define Int64IncludesSByte
#define Int64IncludesByte
#define Int64IncludesInt16
#define Int64IncludesUInt16
#define Int64IncludesInt32
#define Int64IncludesUInt32
#define Int64IncludesInt64

#define UInt64OverlapsSByte
#define UInt64IncludesByte
#define UInt64OverlapsInt16
#define UInt64IncludesUInt16
#define UInt64OverlapsInt32
#define UInt64IncludesUInt32
#define UInt64OverlapsInt64
#define UInt64IncludesUInt64

using System;

namespace He4.Projects.SafeBits.Casts
{

  /// <remarks>
  /// The source code of this class is generated from
  /// CastProperties.Template.cs and CastProperties.Generate.pl. To
  /// update the source code, update the CastProperties.Template.cs
  /// file, then run CastProperties.Generate.pl.
  /// </remarks>
  public static class CastProperties
  {

    public static bool IsValueCopy(Cast<SByte, SByte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if SByteIncludesSByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ SByte
         */
        result = (cast.Destination == ((SByte) cast.Source));

#elif SByteOverlapsSByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ SByte
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((SByte) cast.Source));
        }

#elif SByteOverlapsSByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ SByte
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((SByte) cast.Destination));
        }

#elif SByteIncludesSByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ SByte
         */
        result = (cast.Source == ((SByte) cast.Destination));

#else
#error Relation between SByte and SByte is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<SByte, SByte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        SByte sourceBit = 1;
        SByte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<SByte, SByte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        SByte sourceBit = 1;
        SByte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<SByte, Byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if ByteIncludesSByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ SByte
         */
        result = (cast.Destination == ((Byte) cast.Source));

#elif ByteOverlapsSByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ SByte
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Byte) cast.Source));
        }

#elif SByteOverlapsByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ Byte
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((SByte) cast.Destination));
        }

#elif SByteIncludesByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ Byte
         */
        result = (cast.Source == ((SByte) cast.Destination));

#else
#error Relation between SByte and Byte is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<SByte, Byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        SByte sourceBit = 1;
        Byte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<SByte, Byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        SByte sourceBit = 1;
        Byte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<SByte, Int16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if Int16IncludesSByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ SByte
         */
        result = (cast.Destination == ((Int16) cast.Source));

#elif Int16OverlapsSByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ SByte
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Int16) cast.Source));
        }

#elif SByteOverlapsInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ Int16
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((SByte) cast.Destination));
        }

#elif SByteIncludesInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ Int16
         */
        result = (cast.Source == ((SByte) cast.Destination));

#else
#error Relation between SByte and Int16 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<SByte, Int16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        SByte sourceBit = 1;
        Int16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<SByte, Int16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        SByte sourceBit = 1;
        Int16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<SByte, UInt16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if UInt16IncludesSByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ SByte
         */
        result = (cast.Destination == ((UInt16) cast.Source));

#elif UInt16OverlapsSByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ SByte
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((UInt16) cast.Source));
        }

#elif SByteOverlapsUInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ UInt16
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((SByte) cast.Destination));
        }

#elif SByteIncludesUInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ UInt16
         */
        result = (cast.Source == ((SByte) cast.Destination));

#else
#error Relation between SByte and UInt16 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<SByte, UInt16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        SByte sourceBit = 1;
        UInt16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<SByte, UInt16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        SByte sourceBit = 1;
        UInt16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<SByte, Int32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if Int32IncludesSByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ SByte
         */
        result = (cast.Destination == ((Int32) cast.Source));

#elif Int32OverlapsSByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ SByte
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Int32) cast.Source));
        }

#elif SByteOverlapsInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ Int32
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((SByte) cast.Destination));
        }

#elif SByteIncludesInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ Int32
         */
        result = (cast.Source == ((SByte) cast.Destination));

#else
#error Relation between SByte and Int32 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<SByte, Int32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        SByte sourceBit = 1;
        Int32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<SByte, Int32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        SByte sourceBit = 1;
        Int32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<SByte, UInt32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if UInt32IncludesSByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ SByte
         */
        result = (cast.Destination == ((UInt32) cast.Source));

#elif UInt32OverlapsSByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ SByte
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((UInt32) cast.Source));
        }

#elif SByteOverlapsUInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ UInt32
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((SByte) cast.Destination));
        }

#elif SByteIncludesUInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ UInt32
         */
        result = (cast.Source == ((SByte) cast.Destination));

#else
#error Relation between SByte and UInt32 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<SByte, UInt32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        SByte sourceBit = 1;
        UInt32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<SByte, UInt32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        SByte sourceBit = 1;
        UInt32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<SByte, Int64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if Int64IncludesSByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ SByte
         */
        result = (cast.Destination == ((Int64) cast.Source));

#elif Int64OverlapsSByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ SByte
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Int64) cast.Source));
        }

#elif SByteOverlapsInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ Int64
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((SByte) cast.Destination));
        }

#elif SByteIncludesInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ Int64
         */
        result = (cast.Source == ((SByte) cast.Destination));

#else
#error Relation between SByte and Int64 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<SByte, Int64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        SByte sourceBit = 1;
        Int64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<SByte, Int64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        SByte sourceBit = 1;
        Int64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<SByte, UInt64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if UInt64IncludesSByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ SByte
         */
        result = (cast.Destination == ((UInt64) cast.Source));

#elif UInt64OverlapsSByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ SByte
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((UInt64) cast.Source));
        }

#elif SByteOverlapsUInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ UInt64
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((SByte) cast.Destination));
        }

#elif SByteIncludesUInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ UInt64
         */
        result = (cast.Source == ((SByte) cast.Destination));

#else
#error Relation between SByte and UInt64 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<SByte, UInt64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        SByte sourceBit = 1;
        UInt64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<SByte, UInt64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        SByte sourceBit = 1;
        UInt64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Byte, SByte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if SByteIncludesByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ Byte
         */
        result = (cast.Destination == ((SByte) cast.Source));

#elif SByteOverlapsByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ Byte
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((SByte) cast.Source));
        }

#elif ByteOverlapsSByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ SByte
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Byte) cast.Destination));
        }

#elif ByteIncludesSByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ SByte
         */
        result = (cast.Source == ((Byte) cast.Destination));

#else
#error Relation between Byte and SByte is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Byte, SByte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Byte sourceBit = 1;
        SByte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Byte, SByte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Byte sourceBit = 1;
        SByte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Byte, Byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if ByteIncludesByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ Byte
         */
        result = (cast.Destination == ((Byte) cast.Source));

#elif ByteOverlapsByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ Byte
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Byte) cast.Source));
        }

#elif ByteOverlapsByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ Byte
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Byte) cast.Destination));
        }

#elif ByteIncludesByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ Byte
         */
        result = (cast.Source == ((Byte) cast.Destination));

#else
#error Relation between Byte and Byte is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Byte, Byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Byte sourceBit = 1;
        Byte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Byte, Byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Byte sourceBit = 1;
        Byte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Byte, Int16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if Int16IncludesByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ Byte
         */
        result = (cast.Destination == ((Int16) cast.Source));

#elif Int16OverlapsByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ Byte
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Int16) cast.Source));
        }

#elif ByteOverlapsInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ Int16
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Byte) cast.Destination));
        }

#elif ByteIncludesInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ Int16
         */
        result = (cast.Source == ((Byte) cast.Destination));

#else
#error Relation between Byte and Int16 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Byte, Int16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Byte sourceBit = 1;
        Int16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Byte, Int16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Byte sourceBit = 1;
        Int16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Byte, UInt16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if UInt16IncludesByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ Byte
         */
        result = (cast.Destination == ((UInt16) cast.Source));

#elif UInt16OverlapsByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ Byte
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((UInt16) cast.Source));
        }

#elif ByteOverlapsUInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ UInt16
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Byte) cast.Destination));
        }

#elif ByteIncludesUInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ UInt16
         */
        result = (cast.Source == ((Byte) cast.Destination));

#else
#error Relation between Byte and UInt16 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Byte, UInt16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Byte sourceBit = 1;
        UInt16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Byte, UInt16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Byte sourceBit = 1;
        UInt16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Byte, Int32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if Int32IncludesByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ Byte
         */
        result = (cast.Destination == ((Int32) cast.Source));

#elif Int32OverlapsByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ Byte
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Int32) cast.Source));
        }

#elif ByteOverlapsInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ Int32
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Byte) cast.Destination));
        }

#elif ByteIncludesInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ Int32
         */
        result = (cast.Source == ((Byte) cast.Destination));

#else
#error Relation between Byte and Int32 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Byte, Int32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Byte sourceBit = 1;
        Int32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Byte, Int32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Byte sourceBit = 1;
        Int32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Byte, UInt32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if UInt32IncludesByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ Byte
         */
        result = (cast.Destination == ((UInt32) cast.Source));

#elif UInt32OverlapsByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ Byte
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((UInt32) cast.Source));
        }

#elif ByteOverlapsUInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ UInt32
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Byte) cast.Destination));
        }

#elif ByteIncludesUInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ UInt32
         */
        result = (cast.Source == ((Byte) cast.Destination));

#else
#error Relation between Byte and UInt32 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Byte, UInt32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Byte sourceBit = 1;
        UInt32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Byte, UInt32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Byte sourceBit = 1;
        UInt32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Byte, Int64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if Int64IncludesByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ Byte
         */
        result = (cast.Destination == ((Int64) cast.Source));

#elif Int64OverlapsByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ Byte
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Int64) cast.Source));
        }

#elif ByteOverlapsInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ Int64
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Byte) cast.Destination));
        }

#elif ByteIncludesInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ Int64
         */
        result = (cast.Source == ((Byte) cast.Destination));

#else
#error Relation between Byte and Int64 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Byte, Int64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Byte sourceBit = 1;
        Int64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Byte, Int64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Byte sourceBit = 1;
        Int64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Byte, UInt64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if UInt64IncludesByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ Byte
         */
        result = (cast.Destination == ((UInt64) cast.Source));

#elif UInt64OverlapsByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ Byte
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((UInt64) cast.Source));
        }

#elif ByteOverlapsUInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ UInt64
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Byte) cast.Destination));
        }

#elif ByteIncludesUInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ UInt64
         */
        result = (cast.Source == ((Byte) cast.Destination));

#else
#error Relation between Byte and UInt64 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Byte, UInt64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Byte sourceBit = 1;
        UInt64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Byte, UInt64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Byte sourceBit = 1;
        UInt64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Int16, SByte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if SByteIncludesInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ Int16
         */
        result = (cast.Destination == ((SByte) cast.Source));

#elif SByteOverlapsInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ Int16
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((SByte) cast.Source));
        }

#elif Int16OverlapsSByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ SByte
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Int16) cast.Destination));
        }

#elif Int16IncludesSByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ SByte
         */
        result = (cast.Source == ((Int16) cast.Destination));

#else
#error Relation between Int16 and SByte is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Int16, SByte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int16 sourceBit = 1;
        SByte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Int16, SByte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int16 sourceBit = 1;
        SByte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Int16, Byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if ByteIncludesInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ Int16
         */
        result = (cast.Destination == ((Byte) cast.Source));

#elif ByteOverlapsInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ Int16
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Byte) cast.Source));
        }

#elif Int16OverlapsByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ Byte
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Int16) cast.Destination));
        }

#elif Int16IncludesByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ Byte
         */
        result = (cast.Source == ((Int16) cast.Destination));

#else
#error Relation between Int16 and Byte is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Int16, Byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int16 sourceBit = 1;
        Byte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Int16, Byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int16 sourceBit = 1;
        Byte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Int16, Int16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if Int16IncludesInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ Int16
         */
        result = (cast.Destination == ((Int16) cast.Source));

#elif Int16OverlapsInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ Int16
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Int16) cast.Source));
        }

#elif Int16OverlapsInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ Int16
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Int16) cast.Destination));
        }

#elif Int16IncludesInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ Int16
         */
        result = (cast.Source == ((Int16) cast.Destination));

#else
#error Relation between Int16 and Int16 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Int16, Int16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int16 sourceBit = 1;
        Int16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Int16, Int16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int16 sourceBit = 1;
        Int16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Int16, UInt16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if UInt16IncludesInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ Int16
         */
        result = (cast.Destination == ((UInt16) cast.Source));

#elif UInt16OverlapsInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ Int16
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((UInt16) cast.Source));
        }

#elif Int16OverlapsUInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ UInt16
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Int16) cast.Destination));
        }

#elif Int16IncludesUInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ UInt16
         */
        result = (cast.Source == ((Int16) cast.Destination));

#else
#error Relation between Int16 and UInt16 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Int16, UInt16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int16 sourceBit = 1;
        UInt16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Int16, UInt16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int16 sourceBit = 1;
        UInt16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Int16, Int32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if Int32IncludesInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ Int16
         */
        result = (cast.Destination == ((Int32) cast.Source));

#elif Int32OverlapsInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ Int16
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Int32) cast.Source));
        }

#elif Int16OverlapsInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ Int32
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Int16) cast.Destination));
        }

#elif Int16IncludesInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ Int32
         */
        result = (cast.Source == ((Int16) cast.Destination));

#else
#error Relation between Int16 and Int32 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Int16, Int32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int16 sourceBit = 1;
        Int32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Int16, Int32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int16 sourceBit = 1;
        Int32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Int16, UInt32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if UInt32IncludesInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ Int16
         */
        result = (cast.Destination == ((UInt32) cast.Source));

#elif UInt32OverlapsInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ Int16
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((UInt32) cast.Source));
        }

#elif Int16OverlapsUInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ UInt32
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Int16) cast.Destination));
        }

#elif Int16IncludesUInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ UInt32
         */
        result = (cast.Source == ((Int16) cast.Destination));

#else
#error Relation between Int16 and UInt32 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Int16, UInt32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int16 sourceBit = 1;
        UInt32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Int16, UInt32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int16 sourceBit = 1;
        UInt32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Int16, Int64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if Int64IncludesInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ Int16
         */
        result = (cast.Destination == ((Int64) cast.Source));

#elif Int64OverlapsInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ Int16
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Int64) cast.Source));
        }

#elif Int16OverlapsInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ Int64
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Int16) cast.Destination));
        }

#elif Int16IncludesInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ Int64
         */
        result = (cast.Source == ((Int16) cast.Destination));

#else
#error Relation between Int16 and Int64 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Int16, Int64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int16 sourceBit = 1;
        Int64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Int16, Int64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int16 sourceBit = 1;
        Int64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Int16, UInt64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if UInt64IncludesInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ Int16
         */
        result = (cast.Destination == ((UInt64) cast.Source));

#elif UInt64OverlapsInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ Int16
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((UInt64) cast.Source));
        }

#elif Int16OverlapsUInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ UInt64
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Int16) cast.Destination));
        }

#elif Int16IncludesUInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ UInt64
         */
        result = (cast.Source == ((Int16) cast.Destination));

#else
#error Relation between Int16 and UInt64 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Int16, UInt64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int16 sourceBit = 1;
        UInt64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Int16, UInt64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int16 sourceBit = 1;
        UInt64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<UInt16, SByte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if SByteIncludesUInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ UInt16
         */
        result = (cast.Destination == ((SByte) cast.Source));

#elif SByteOverlapsUInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ UInt16
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((SByte) cast.Source));
        }

#elif UInt16OverlapsSByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ SByte
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((UInt16) cast.Destination));
        }

#elif UInt16IncludesSByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ SByte
         */
        result = (cast.Source == ((UInt16) cast.Destination));

#else
#error Relation between UInt16 and SByte is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<UInt16, SByte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt16 sourceBit = 1;
        SByte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<UInt16, SByte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt16 sourceBit = 1;
        SByte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<UInt16, Byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if ByteIncludesUInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ UInt16
         */
        result = (cast.Destination == ((Byte) cast.Source));

#elif ByteOverlapsUInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ UInt16
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Byte) cast.Source));
        }

#elif UInt16OverlapsByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ Byte
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((UInt16) cast.Destination));
        }

#elif UInt16IncludesByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ Byte
         */
        result = (cast.Source == ((UInt16) cast.Destination));

#else
#error Relation between UInt16 and Byte is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<UInt16, Byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt16 sourceBit = 1;
        Byte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<UInt16, Byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt16 sourceBit = 1;
        Byte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<UInt16, Int16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if Int16IncludesUInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ UInt16
         */
        result = (cast.Destination == ((Int16) cast.Source));

#elif Int16OverlapsUInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ UInt16
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Int16) cast.Source));
        }

#elif UInt16OverlapsInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ Int16
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((UInt16) cast.Destination));
        }

#elif UInt16IncludesInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ Int16
         */
        result = (cast.Source == ((UInt16) cast.Destination));

#else
#error Relation between UInt16 and Int16 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<UInt16, Int16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt16 sourceBit = 1;
        Int16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<UInt16, Int16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt16 sourceBit = 1;
        Int16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<UInt16, UInt16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if UInt16IncludesUInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ UInt16
         */
        result = (cast.Destination == ((UInt16) cast.Source));

#elif UInt16OverlapsUInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ UInt16
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((UInt16) cast.Source));
        }

#elif UInt16OverlapsUInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ UInt16
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((UInt16) cast.Destination));
        }

#elif UInt16IncludesUInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ UInt16
         */
        result = (cast.Source == ((UInt16) cast.Destination));

#else
#error Relation between UInt16 and UInt16 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<UInt16, UInt16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt16 sourceBit = 1;
        UInt16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<UInt16, UInt16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt16 sourceBit = 1;
        UInt16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<UInt16, Int32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if Int32IncludesUInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ UInt16
         */
        result = (cast.Destination == ((Int32) cast.Source));

#elif Int32OverlapsUInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ UInt16
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Int32) cast.Source));
        }

#elif UInt16OverlapsInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ Int32
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((UInt16) cast.Destination));
        }

#elif UInt16IncludesInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ Int32
         */
        result = (cast.Source == ((UInt16) cast.Destination));

#else
#error Relation between UInt16 and Int32 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<UInt16, Int32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt16 sourceBit = 1;
        Int32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<UInt16, Int32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt16 sourceBit = 1;
        Int32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<UInt16, UInt32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if UInt32IncludesUInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ UInt16
         */
        result = (cast.Destination == ((UInt32) cast.Source));

#elif UInt32OverlapsUInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ UInt16
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((UInt32) cast.Source));
        }

#elif UInt16OverlapsUInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ UInt32
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((UInt16) cast.Destination));
        }

#elif UInt16IncludesUInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ UInt32
         */
        result = (cast.Source == ((UInt16) cast.Destination));

#else
#error Relation between UInt16 and UInt32 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<UInt16, UInt32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt16 sourceBit = 1;
        UInt32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<UInt16, UInt32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt16 sourceBit = 1;
        UInt32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<UInt16, Int64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if Int64IncludesUInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ UInt16
         */
        result = (cast.Destination == ((Int64) cast.Source));

#elif Int64OverlapsUInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ UInt16
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Int64) cast.Source));
        }

#elif UInt16OverlapsInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ Int64
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((UInt16) cast.Destination));
        }

#elif UInt16IncludesInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ Int64
         */
        result = (cast.Source == ((UInt16) cast.Destination));

#else
#error Relation between UInt16 and Int64 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<UInt16, Int64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt16 sourceBit = 1;
        Int64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<UInt16, Int64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt16 sourceBit = 1;
        Int64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<UInt16, UInt64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if UInt64IncludesUInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ UInt16
         */
        result = (cast.Destination == ((UInt64) cast.Source));

#elif UInt64OverlapsUInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ UInt16
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((UInt64) cast.Source));
        }

#elif UInt16OverlapsUInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ UInt64
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((UInt16) cast.Destination));
        }

#elif UInt16IncludesUInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ UInt64
         */
        result = (cast.Source == ((UInt16) cast.Destination));

#else
#error Relation between UInt16 and UInt64 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<UInt16, UInt64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt16 sourceBit = 1;
        UInt64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<UInt16, UInt64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt16 sourceBit = 1;
        UInt64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Int32, SByte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if SByteIncludesInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ Int32
         */
        result = (cast.Destination == ((SByte) cast.Source));

#elif SByteOverlapsInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ Int32
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((SByte) cast.Source));
        }

#elif Int32OverlapsSByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ SByte
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Int32) cast.Destination));
        }

#elif Int32IncludesSByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ SByte
         */
        result = (cast.Source == ((Int32) cast.Destination));

#else
#error Relation between Int32 and SByte is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Int32, SByte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int32 sourceBit = 1;
        SByte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Int32, SByte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int32 sourceBit = 1;
        SByte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Int32, Byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if ByteIncludesInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ Int32
         */
        result = (cast.Destination == ((Byte) cast.Source));

#elif ByteOverlapsInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ Int32
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Byte) cast.Source));
        }

#elif Int32OverlapsByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ Byte
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Int32) cast.Destination));
        }

#elif Int32IncludesByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ Byte
         */
        result = (cast.Source == ((Int32) cast.Destination));

#else
#error Relation between Int32 and Byte is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Int32, Byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int32 sourceBit = 1;
        Byte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Int32, Byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int32 sourceBit = 1;
        Byte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Int32, Int16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if Int16IncludesInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ Int32
         */
        result = (cast.Destination == ((Int16) cast.Source));

#elif Int16OverlapsInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ Int32
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Int16) cast.Source));
        }

#elif Int32OverlapsInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ Int16
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Int32) cast.Destination));
        }

#elif Int32IncludesInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ Int16
         */
        result = (cast.Source == ((Int32) cast.Destination));

#else
#error Relation between Int32 and Int16 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Int32, Int16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int32 sourceBit = 1;
        Int16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Int32, Int16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int32 sourceBit = 1;
        Int16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Int32, UInt16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if UInt16IncludesInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ Int32
         */
        result = (cast.Destination == ((UInt16) cast.Source));

#elif UInt16OverlapsInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ Int32
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((UInt16) cast.Source));
        }

#elif Int32OverlapsUInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ UInt16
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Int32) cast.Destination));
        }

#elif Int32IncludesUInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ UInt16
         */
        result = (cast.Source == ((Int32) cast.Destination));

#else
#error Relation between Int32 and UInt16 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Int32, UInt16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int32 sourceBit = 1;
        UInt16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Int32, UInt16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int32 sourceBit = 1;
        UInt16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Int32, Int32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if Int32IncludesInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ Int32
         */
        result = (cast.Destination == ((Int32) cast.Source));

#elif Int32OverlapsInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ Int32
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Int32) cast.Source));
        }

#elif Int32OverlapsInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ Int32
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Int32) cast.Destination));
        }

#elif Int32IncludesInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ Int32
         */
        result = (cast.Source == ((Int32) cast.Destination));

#else
#error Relation between Int32 and Int32 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Int32, Int32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int32 sourceBit = 1;
        Int32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Int32, Int32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int32 sourceBit = 1;
        Int32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Int32, UInt32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if UInt32IncludesInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ Int32
         */
        result = (cast.Destination == ((UInt32) cast.Source));

#elif UInt32OverlapsInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ Int32
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((UInt32) cast.Source));
        }

#elif Int32OverlapsUInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ UInt32
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Int32) cast.Destination));
        }

#elif Int32IncludesUInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ UInt32
         */
        result = (cast.Source == ((Int32) cast.Destination));

#else
#error Relation between Int32 and UInt32 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Int32, UInt32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int32 sourceBit = 1;
        UInt32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Int32, UInt32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int32 sourceBit = 1;
        UInt32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Int32, Int64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if Int64IncludesInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ Int32
         */
        result = (cast.Destination == ((Int64) cast.Source));

#elif Int64OverlapsInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ Int32
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Int64) cast.Source));
        }

#elif Int32OverlapsInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ Int64
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Int32) cast.Destination));
        }

#elif Int32IncludesInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ Int64
         */
        result = (cast.Source == ((Int32) cast.Destination));

#else
#error Relation between Int32 and Int64 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Int32, Int64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int32 sourceBit = 1;
        Int64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Int32, Int64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int32 sourceBit = 1;
        Int64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Int32, UInt64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if UInt64IncludesInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ Int32
         */
        result = (cast.Destination == ((UInt64) cast.Source));

#elif UInt64OverlapsInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ Int32
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((UInt64) cast.Source));
        }

#elif Int32OverlapsUInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ UInt64
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Int32) cast.Destination));
        }

#elif Int32IncludesUInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ UInt64
         */
        result = (cast.Source == ((Int32) cast.Destination));

#else
#error Relation between Int32 and UInt64 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Int32, UInt64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int32 sourceBit = 1;
        UInt64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Int32, UInt64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int32 sourceBit = 1;
        UInt64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<UInt32, SByte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if SByteIncludesUInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ UInt32
         */
        result = (cast.Destination == ((SByte) cast.Source));

#elif SByteOverlapsUInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ UInt32
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((SByte) cast.Source));
        }

#elif UInt32OverlapsSByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ SByte
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((UInt32) cast.Destination));
        }

#elif UInt32IncludesSByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ SByte
         */
        result = (cast.Source == ((UInt32) cast.Destination));

#else
#error Relation between UInt32 and SByte is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<UInt32, SByte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt32 sourceBit = 1;
        SByte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<UInt32, SByte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt32 sourceBit = 1;
        SByte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<UInt32, Byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if ByteIncludesUInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ UInt32
         */
        result = (cast.Destination == ((Byte) cast.Source));

#elif ByteOverlapsUInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ UInt32
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Byte) cast.Source));
        }

#elif UInt32OverlapsByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ Byte
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((UInt32) cast.Destination));
        }

#elif UInt32IncludesByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ Byte
         */
        result = (cast.Source == ((UInt32) cast.Destination));

#else
#error Relation between UInt32 and Byte is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<UInt32, Byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt32 sourceBit = 1;
        Byte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<UInt32, Byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt32 sourceBit = 1;
        Byte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<UInt32, Int16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if Int16IncludesUInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ UInt32
         */
        result = (cast.Destination == ((Int16) cast.Source));

#elif Int16OverlapsUInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ UInt32
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Int16) cast.Source));
        }

#elif UInt32OverlapsInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ Int16
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((UInt32) cast.Destination));
        }

#elif UInt32IncludesInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ Int16
         */
        result = (cast.Source == ((UInt32) cast.Destination));

#else
#error Relation between UInt32 and Int16 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<UInt32, Int16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt32 sourceBit = 1;
        Int16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<UInt32, Int16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt32 sourceBit = 1;
        Int16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<UInt32, UInt16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if UInt16IncludesUInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ UInt32
         */
        result = (cast.Destination == ((UInt16) cast.Source));

#elif UInt16OverlapsUInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ UInt32
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((UInt16) cast.Source));
        }

#elif UInt32OverlapsUInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ UInt16
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((UInt32) cast.Destination));
        }

#elif UInt32IncludesUInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ UInt16
         */
        result = (cast.Source == ((UInt32) cast.Destination));

#else
#error Relation between UInt32 and UInt16 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<UInt32, UInt16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt32 sourceBit = 1;
        UInt16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<UInt32, UInt16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt32 sourceBit = 1;
        UInt16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<UInt32, Int32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if Int32IncludesUInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ UInt32
         */
        result = (cast.Destination == ((Int32) cast.Source));

#elif Int32OverlapsUInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ UInt32
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Int32) cast.Source));
        }

#elif UInt32OverlapsInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ Int32
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((UInt32) cast.Destination));
        }

#elif UInt32IncludesInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ Int32
         */
        result = (cast.Source == ((UInt32) cast.Destination));

#else
#error Relation between UInt32 and Int32 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<UInt32, Int32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt32 sourceBit = 1;
        Int32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<UInt32, Int32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt32 sourceBit = 1;
        Int32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<UInt32, UInt32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if UInt32IncludesUInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ UInt32
         */
        result = (cast.Destination == ((UInt32) cast.Source));

#elif UInt32OverlapsUInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ UInt32
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((UInt32) cast.Source));
        }

#elif UInt32OverlapsUInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ UInt32
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((UInt32) cast.Destination));
        }

#elif UInt32IncludesUInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ UInt32
         */
        result = (cast.Source == ((UInt32) cast.Destination));

#else
#error Relation between UInt32 and UInt32 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<UInt32, UInt32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt32 sourceBit = 1;
        UInt32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<UInt32, UInt32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt32 sourceBit = 1;
        UInt32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<UInt32, Int64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if Int64IncludesUInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ UInt32
         */
        result = (cast.Destination == ((Int64) cast.Source));

#elif Int64OverlapsUInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ UInt32
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Int64) cast.Source));
        }

#elif UInt32OverlapsInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ Int64
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((UInt32) cast.Destination));
        }

#elif UInt32IncludesInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ Int64
         */
        result = (cast.Source == ((UInt32) cast.Destination));

#else
#error Relation between UInt32 and Int64 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<UInt32, Int64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt32 sourceBit = 1;
        Int64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<UInt32, Int64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt32 sourceBit = 1;
        Int64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<UInt32, UInt64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if UInt64IncludesUInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ UInt32
         */
        result = (cast.Destination == ((UInt64) cast.Source));

#elif UInt64OverlapsUInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ UInt32
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((UInt64) cast.Source));
        }

#elif UInt32OverlapsUInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ UInt64
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((UInt32) cast.Destination));
        }

#elif UInt32IncludesUInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ UInt64
         */
        result = (cast.Source == ((UInt32) cast.Destination));

#else
#error Relation between UInt32 and UInt64 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<UInt32, UInt64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt32 sourceBit = 1;
        UInt64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<UInt32, UInt64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt32 sourceBit = 1;
        UInt64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Int64, SByte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if SByteIncludesInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ Int64
         */
        result = (cast.Destination == ((SByte) cast.Source));

#elif SByteOverlapsInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ Int64
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((SByte) cast.Source));
        }

#elif Int64OverlapsSByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ SByte
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Int64) cast.Destination));
        }

#elif Int64IncludesSByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ SByte
         */
        result = (cast.Source == ((Int64) cast.Destination));

#else
#error Relation between Int64 and SByte is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Int64, SByte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int64 sourceBit = 1;
        SByte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Int64, SByte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int64 sourceBit = 1;
        SByte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Int64, Byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if ByteIncludesInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ Int64
         */
        result = (cast.Destination == ((Byte) cast.Source));

#elif ByteOverlapsInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ Int64
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Byte) cast.Source));
        }

#elif Int64OverlapsByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ Byte
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Int64) cast.Destination));
        }

#elif Int64IncludesByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ Byte
         */
        result = (cast.Source == ((Int64) cast.Destination));

#else
#error Relation between Int64 and Byte is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Int64, Byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int64 sourceBit = 1;
        Byte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Int64, Byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int64 sourceBit = 1;
        Byte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Int64, Int16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if Int16IncludesInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ Int64
         */
        result = (cast.Destination == ((Int16) cast.Source));

#elif Int16OverlapsInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ Int64
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Int16) cast.Source));
        }

#elif Int64OverlapsInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ Int16
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Int64) cast.Destination));
        }

#elif Int64IncludesInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ Int16
         */
        result = (cast.Source == ((Int64) cast.Destination));

#else
#error Relation between Int64 and Int16 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Int64, Int16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int64 sourceBit = 1;
        Int16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Int64, Int16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int64 sourceBit = 1;
        Int16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Int64, UInt16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if UInt16IncludesInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ Int64
         */
        result = (cast.Destination == ((UInt16) cast.Source));

#elif UInt16OverlapsInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ Int64
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((UInt16) cast.Source));
        }

#elif Int64OverlapsUInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ UInt16
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Int64) cast.Destination));
        }

#elif Int64IncludesUInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ UInt16
         */
        result = (cast.Source == ((Int64) cast.Destination));

#else
#error Relation between Int64 and UInt16 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Int64, UInt16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int64 sourceBit = 1;
        UInt16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Int64, UInt16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int64 sourceBit = 1;
        UInt16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Int64, Int32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if Int32IncludesInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ Int64
         */
        result = (cast.Destination == ((Int32) cast.Source));

#elif Int32OverlapsInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ Int64
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Int32) cast.Source));
        }

#elif Int64OverlapsInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ Int32
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Int64) cast.Destination));
        }

#elif Int64IncludesInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ Int32
         */
        result = (cast.Source == ((Int64) cast.Destination));

#else
#error Relation between Int64 and Int32 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Int64, Int32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int64 sourceBit = 1;
        Int32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Int64, Int32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int64 sourceBit = 1;
        Int32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Int64, UInt32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if UInt32IncludesInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ Int64
         */
        result = (cast.Destination == ((UInt32) cast.Source));

#elif UInt32OverlapsInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ Int64
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((UInt32) cast.Source));
        }

#elif Int64OverlapsUInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ UInt32
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Int64) cast.Destination));
        }

#elif Int64IncludesUInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ UInt32
         */
        result = (cast.Source == ((Int64) cast.Destination));

#else
#error Relation between Int64 and UInt32 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Int64, UInt32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int64 sourceBit = 1;
        UInt32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Int64, UInt32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int64 sourceBit = 1;
        UInt32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Int64, Int64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if Int64IncludesInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ Int64
         */
        result = (cast.Destination == ((Int64) cast.Source));

#elif Int64OverlapsInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ Int64
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Int64) cast.Source));
        }

#elif Int64OverlapsInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ Int64
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Int64) cast.Destination));
        }

#elif Int64IncludesInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ Int64
         */
        result = (cast.Source == ((Int64) cast.Destination));

#else
#error Relation between Int64 and Int64 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Int64, Int64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int64 sourceBit = 1;
        Int64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Int64, Int64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int64 sourceBit = 1;
        Int64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<Int64, UInt64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if UInt64IncludesInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ Int64
         */
        result = (cast.Destination == ((UInt64) cast.Source));

#elif UInt64OverlapsInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ Int64
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((UInt64) cast.Source));
        }

#elif Int64OverlapsUInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ UInt64
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((Int64) cast.Destination));
        }

#elif Int64IncludesUInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ UInt64
         */
        result = (cast.Source == ((Int64) cast.Destination));

#else
#error Relation between Int64 and UInt64 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<Int64, UInt64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int64 sourceBit = 1;
        UInt64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<Int64, UInt64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        Int64 sourceBit = 1;
        UInt64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<UInt64, SByte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if SByteIncludesUInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ UInt64
         */
        result = (cast.Destination == ((SByte) cast.Source));

#elif SByteOverlapsUInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ SByte
         *   S ⇔ UInt64
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((SByte) cast.Source));
        }

#elif UInt64OverlapsSByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ SByte
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((UInt64) cast.Destination));
        }

#elif UInt64IncludesSByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ SByte
         */
        result = (cast.Source == ((UInt64) cast.Destination));

#else
#error Relation between UInt64 and SByte is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<UInt64, SByte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt64 sourceBit = 1;
        SByte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<UInt64, SByte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt64 sourceBit = 1;
        SByte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<UInt64, Byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if ByteIncludesUInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ UInt64
         */
        result = (cast.Destination == ((Byte) cast.Source));

#elif ByteOverlapsUInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Byte
         *   S ⇔ UInt64
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Byte) cast.Source));
        }

#elif UInt64OverlapsByte
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ Byte
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((UInt64) cast.Destination));
        }

#elif UInt64IncludesByte
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ Byte
         */
        result = (cast.Source == ((UInt64) cast.Destination));

#else
#error Relation between UInt64 and Byte is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<UInt64, Byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt64 sourceBit = 1;
        Byte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<UInt64, Byte> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt64 sourceBit = 1;
        Byte destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<UInt64, Int16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if Int16IncludesUInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ UInt64
         */
        result = (cast.Destination == ((Int16) cast.Source));

#elif Int16OverlapsUInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int16
         *   S ⇔ UInt64
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Int16) cast.Source));
        }

#elif UInt64OverlapsInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ Int16
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((UInt64) cast.Destination));
        }

#elif UInt64IncludesInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ Int16
         */
        result = (cast.Source == ((UInt64) cast.Destination));

#else
#error Relation between UInt64 and Int16 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<UInt64, Int16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt64 sourceBit = 1;
        Int16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<UInt64, Int16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt64 sourceBit = 1;
        Int16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<UInt64, UInt16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if UInt16IncludesUInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ UInt64
         */
        result = (cast.Destination == ((UInt16) cast.Source));

#elif UInt16OverlapsUInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt16
         *   S ⇔ UInt64
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((UInt16) cast.Source));
        }

#elif UInt64OverlapsUInt16
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ UInt16
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((UInt64) cast.Destination));
        }

#elif UInt64IncludesUInt16
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ UInt16
         */
        result = (cast.Source == ((UInt64) cast.Destination));

#else
#error Relation between UInt64 and UInt16 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<UInt64, UInt16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt64 sourceBit = 1;
        UInt16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<UInt64, UInt16> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt64 sourceBit = 1;
        UInt16 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<UInt64, Int32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if Int32IncludesUInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ UInt64
         */
        result = (cast.Destination == ((Int32) cast.Source));

#elif Int32OverlapsUInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int32
         *   S ⇔ UInt64
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Int32) cast.Source));
        }

#elif UInt64OverlapsInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ Int32
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((UInt64) cast.Destination));
        }

#elif UInt64IncludesInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ Int32
         */
        result = (cast.Source == ((UInt64) cast.Destination));

#else
#error Relation between UInt64 and Int32 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<UInt64, Int32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt64 sourceBit = 1;
        Int32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<UInt64, Int32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt64 sourceBit = 1;
        Int32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<UInt64, UInt32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if UInt32IncludesUInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ UInt64
         */
        result = (cast.Destination == ((UInt32) cast.Source));

#elif UInt32OverlapsUInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt32
         *   S ⇔ UInt64
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((UInt32) cast.Source));
        }

#elif UInt64OverlapsUInt32
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ UInt32
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((UInt64) cast.Destination));
        }

#elif UInt64IncludesUInt32
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ UInt32
         */
        result = (cast.Source == ((UInt64) cast.Destination));

#else
#error Relation between UInt64 and UInt32 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<UInt64, UInt32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt64 sourceBit = 1;
        UInt32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<UInt64, UInt32> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt64 sourceBit = 1;
        UInt32 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<UInt64, Int64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if Int64IncludesUInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ UInt64
         */
        result = (cast.Destination == ((Int64) cast.Source));

#elif Int64OverlapsUInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ Int64
         *   S ⇔ UInt64
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((Int64) cast.Source));
        }

#elif UInt64OverlapsInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ Int64
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((UInt64) cast.Destination));
        }

#elif UInt64IncludesInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ Int64
         */
        result = (cast.Source == ((UInt64) cast.Destination));

#else
#error Relation between UInt64 and Int64 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<UInt64, Int64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt64 sourceBit = 1;
        Int64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<UInt64, Int64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt64 sourceBit = 1;
        Int64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsValueCopy(Cast<UInt64, UInt64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if UInt64IncludesUInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ UInt64
         */
        result = (cast.Destination == ((UInt64) cast.Source));

#elif UInt64OverlapsUInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ UInt64
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((UInt64) cast.Source));
        }

#elif UInt64OverlapsUInt64
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ UInt64
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((UInt64) cast.Destination));
        }

#elif UInt64IncludesUInt64
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ UInt64
         *   S ⇔ UInt64
         */
        result = (cast.Source == ((UInt64) cast.Destination));

#else
#error Relation between UInt64 and UInt64 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<UInt64, UInt64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt64 sourceBit = 1;
        UInt64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 0)
            {

              result = false;
              break; // Destination does not have zero-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }

    public static bool IsOneFillBinaryCopy(Cast<UInt64, UInt64> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        UInt64 sourceBit = 1;
        UInt64 destinationBit = 1;

        for (var i = 0; i < destinationLimit; i++)
        {

          // Assert
          // i < destinationLimit

          if (i < sourceLimit)
          {

            // Assert
            // i < destinationLimit
            // i < sourceLimit

            if (((cast.Source & sourceBit) == 0) != ((cast.Destination & destinationBit) == 0))
            {

              result = false;
              break; // Bitwise mismatch
            }

            sourceBit <<= 1;
          }
          else
          {

            // Assert
            // i < destinationLimit
            // i >= sourceLimit
            //
            // Conclusion
            // destinationLimit > sourceLimit

            if ((cast.Destination & destinationBit) != 1)
            {

              result = false;
              break; // Destination does not have one-filled high bits
            }
          }

          destinationBit <<= 1;
        }
      }

      return result;
    }
  }
}
