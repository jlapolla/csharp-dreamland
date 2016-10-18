
    public static bool IsValueCopy(Cast<TYPE1, TYPE2> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

#if TYPE2IncludesTYPE1
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ TYPE2
         *   S ⇔ TYPE1
         */
        result = (cast.Destination == ((TYPE2) cast.Source));

#elif TYPE2OverlapsTYPE1
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ TYPE2
         *   S ⇔ TYPE1
         */
        if (cast.Source >= 0)
        {

          result = (cast.Destination == ((TYPE2) cast.Source));
        }

#elif TYPE1OverlapsTYPE2
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ TYPE1
         *   S ⇔ TYPE2
         */
        if (cast.Destination >= 0)
        {

          result = (cast.Source == ((TYPE1) cast.Destination));
        }

#elif TYPE1IncludesTYPE2
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ TYPE1
         *   S ⇔ TYPE2
         */
        result = (cast.Source == ((TYPE1) cast.Destination));

#else
#error Relation between TYPE1 and TYPE2 is undefined.

#endif
      }

      return result;
    }

    public static bool IsZeroFillBinaryCopy(Cast<TYPE1, TYPE2> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        TYPE1 sourceBit = 1;
        TYPE2 destinationBit = 1;

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

    public static bool IsOneFillBinaryCopy(Cast<TYPE1, TYPE2> cast)
    {

      bool result = false;

      if (!(cast.IsCompileTimeError || cast.IsRunTimeError))
      {

        result = true;

        int sourceLimit = 8 * TypeProperties.SizeOf(cast.SourceType);
        int destinationLimit = 8 * TypeProperties.SizeOf(cast.DestinationType);
        TYPE1 sourceBit = 1;
        TYPE2 destinationBit = 1;

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
