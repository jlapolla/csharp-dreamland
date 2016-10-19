
  public class CastTYPE1TYPE2 : Cast<TYPE1, TYPE2>
  {

    protected override void Evaluate()
    {

#if TYPE2IncludesTYPE1
      Destination = Source;

#else
      // Implicit cast results in compile-time error.

#endif
    }

    public override bool IsUncheckedCast
    {

      get
      {

        return false;
      }
    }

    public override bool IsExplicitCast
    {

      get
      {

        return false;
      }
    }

    public override bool IsValueCopy
    {

      get
      {

        return CastProperties.IsValueCopy(this);
      }
    }

    public override bool IsZeroFillBinaryCopy
    {

      get
      {

        return CastProperties.IsZeroFillBinaryCopy(this);
      }
    }

    public override bool IsOneFillBinaryCopy
    {

      get
      {

        return CastProperties.IsOneFillBinaryCopy(this);
      }
    }

    public override bool IsCompileTimeError
    {

      get
      {

#if TYPE2IncludesTYPE1
        return false;

#else
        return true;

#endif
      }
    }

    public override bool IsValueCompatible
    {

      get
      {

#if TYPE2IncludesTYPE1
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ TYPE2
         *   S ⇔ TYPE1
         */

        return true;

#elif TYPE2OverlapsTYPE1
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ TYPE2
         *   S ⇔ TYPE1
         */

        return Source >= 0;

#elif TYPE1OverlapsTYPE2
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ TYPE1
         *   S ⇔ TYPE2
         */

        return ((TYPE1) TYPE2.MaxValue) >= Source;

#elif TYPE1IncludesTYPE2
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ TYPE1
         *   S ⇔ TYPE2
         */

        return (TYPE2.MaxValue >= Source) && (Source >= TYPE2.MinValue);

#else
#error Relation between TYPE1 and TYPE2 is undefined.

#endif
      }
    }

    public static CastTYPE1TYPE2 Make(Random2 random)
    {

#if TYPE2IncludesTYPE1
      /*
       * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
       * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
       * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
       *   D ⇔ TYPE2
       *   S ⇔ TYPE1
       */

      // 100% IsValueCompatible
      IRandom<TYPE1> randomTYPE1Interface = random;
      randomTYPE1Interface.Next();
      return Make(randomTYPE1Interface.Item);

#elif TYPE2OverlapsTYPE1
      /*
       * 9088a52d-d371-4363-9009-2f7f58abde72
       * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
       * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
       *   D ⇔ TYPE2
       *   S ⇔ TYPE1
       */

      // 50% IsValueCompatible
      IRandom<TYPE1> randomTYPE1Interface = random;
      randomTYPE1Interface.Next();
      return Make(randomTYPE1Interface.Item);

#elif TYPE1OverlapsTYPE2
      /*
       * 9088a52d-d371-4363-9009-2f7f58abde72
       * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
       * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
       *   D ⇔ TYPE1
       *   S ⇔ TYPE2
       */

      // < 50% IsValueCompatible

      // We want to bring IsValueCompatible probability to >= 50%. To do this,
      // we'll manually ensure compatibility 50% of the time. Remember that for
      // the 50% of the time that we are NOT manually ensuring compatibility,
      // we still have a small chance of getting a compatible value anyway, so
      // the actual probability of IsValueCompatible being true is greater than
      // 50%. In fact, we expect 75% when TYPE1 is the unsigned version of
      // TYPE2. When TYPE1 is a larger unsigned type than TYPE2, we expect
      // IsValueCompatible probability to be only slightly greater than 50%.

      CastTYPE1TYPE2 result;

      IRandom<TYPE2> randomTYPE2Interface = random;
      randomTYPE2Interface.Next();
      if (randomTYPE2Interface.Item >= 0) // 50% randomTYPE2Interface.Item >= 0
      {

        // IsValueCompatible == true
        result = Make((TYPE1) randomTYPE2Interface.Item);
      }
      else
      {

        // IsValueCompatible may be true or false
        IRandom<TYPE1> randomTYPE1Interface = random;
        randomTYPE1Interface.Next();
        result = Make(randomTYPE1Interface.Item);
      }

      return result;
#elif TYPE1IncludesTYPE2
      /*
       * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
       * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
       * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
       *   D ⇔ TYPE1
       *   S ⇔ TYPE2
       */

      // < 50% IsValueCompatible

      // Just like above, we want to bring IsValueCompatible probability to >=
      // 50%.

      CastTYPE1TYPE2 result;

      if (random.Next(0, 2) == 0) // 50% random.Next(0, 2) == 0
      {

        // IsValueCompatible == true
        IRandom<TYPE2> randomTYPE2Interface = random;
        randomTYPE2Interface.Next();
        result = Make((TYPE1) randomTYPE2Interface.Item);
      }
      else
      {

        // IsValueCompatible may be true or false
        IRandom<TYPE1> randomTYPE1Interface = random;
        randomTYPE1Interface.Next();
        result = Make(randomTYPE1Interface.Item);
      }

      return result;
#else
#error Relation between TYPE1 and TYPE2 is undefined.

#endif
    }

    public static CastTYPE1TYPE2 Make(TYPE1 source)
    {

      CastTYPE1TYPE2 instance = new CastTYPE1TYPE2();
      Setup(instance, source);
      return instance;
    }

    protected static void Setup(CastTYPE1TYPE2 instance, TYPE1 source)
    {

      instance.Source = source;
    }

    protected CastTYPE1TYPE2()
    {
    }
  }

  public class ExplicitCastTYPE1TYPE2 : Cast<TYPE1, TYPE2>
  {

    protected override void Evaluate()
    {

      Destination = (TYPE2) Source;
    }

    public override bool IsUncheckedCast
    {

      get
      {

        return false;
      }
    }

    public override bool IsExplicitCast
    {

      get
      {

        return true;
      }
    }

    public override bool IsValueCopy
    {

      get
      {

        return CastProperties.IsValueCopy(this);
      }
    }

    public override bool IsZeroFillBinaryCopy
    {

      get
      {

        return CastProperties.IsZeroFillBinaryCopy(this);
      }
    }

    public override bool IsOneFillBinaryCopy
    {

      get
      {

        return CastProperties.IsOneFillBinaryCopy(this);
      }
    }

    public override bool IsCompileTimeError
    {

      get
      {

        return false;
      }
    }

    public override bool IsValueCompatible
    {

      get
      {

#if TYPE2IncludesTYPE1
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ TYPE2
         *   S ⇔ TYPE1
         */

        return true;

#elif TYPE2OverlapsTYPE1
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ TYPE2
         *   S ⇔ TYPE1
         */

        return Source >= 0;

#elif TYPE1OverlapsTYPE2
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ TYPE1
         *   S ⇔ TYPE2
         */

        return ((TYPE1) TYPE2.MaxValue) >= Source;

#elif TYPE1IncludesTYPE2
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ TYPE1
         *   S ⇔ TYPE2
         */

        return (TYPE2.MaxValue >= Source) && (Source >= TYPE2.MinValue);

#else
#error Relation between TYPE1 and TYPE2 is undefined.

#endif
      }
    }

    public static ExplicitCastTYPE1TYPE2 Make(Random2 random)
    {

#if TYPE2IncludesTYPE1
      /*
       * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
       * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
       * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
       *   D ⇔ TYPE2
       *   S ⇔ TYPE1
       */

      // 100% IsValueCompatible
      IRandom<TYPE1> randomTYPE1Interface = random;
      randomTYPE1Interface.Next();
      return Make(randomTYPE1Interface.Item);

#elif TYPE2OverlapsTYPE1
      /*
       * 9088a52d-d371-4363-9009-2f7f58abde72
       * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
       * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
       *   D ⇔ TYPE2
       *   S ⇔ TYPE1
       */

      // 50% IsValueCompatible
      IRandom<TYPE1> randomTYPE1Interface = random;
      randomTYPE1Interface.Next();
      return Make(randomTYPE1Interface.Item);

#elif TYPE1OverlapsTYPE2
      /*
       * 9088a52d-d371-4363-9009-2f7f58abde72
       * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
       * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
       *   D ⇔ TYPE1
       *   S ⇔ TYPE2
       */

      // < 50% IsValueCompatible

      // We want to bring IsValueCompatible probability to >= 50%. To do this,
      // we'll manually ensure compatibility 50% of the time. Remember that for
      // the 50% of the time that we are NOT manually ensuring compatibility,
      // we still have a small chance of getting a compatible value anyway, so
      // the actual probability of IsValueCompatible being true is greater than
      // 50%. In fact, we expect 75% when TYPE1 is the unsigned version of
      // TYPE2. When TYPE1 is a larger unsigned type than TYPE2, we expect
      // IsValueCompatible probability to be only slightly greater than 50%.

      ExplicitCastTYPE1TYPE2 result;

      IRandom<TYPE2> randomTYPE2Interface = random;
      randomTYPE2Interface.Next();
      if (randomTYPE2Interface.Item >= 0) // 50% randomTYPE2Interface.Item >= 0
      {

        // IsValueCompatible == true
        result = Make((TYPE1) randomTYPE2Interface.Item);
      }
      else
      {

        // IsValueCompatible may be true or false
        IRandom<TYPE1> randomTYPE1Interface = random;
        randomTYPE1Interface.Next();
        result = Make(randomTYPE1Interface.Item);
      }

      return result;
#elif TYPE1IncludesTYPE2
      /*
       * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
       * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
       * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
       *   D ⇔ TYPE1
       *   S ⇔ TYPE2
       */

      // < 50% IsValueCompatible

      // Just like above, we want to bring IsValueCompatible probability to >=
      // 50%.

      ExplicitCastTYPE1TYPE2 result;

      if (random.Next(0, 2) == 0) // 50% random.Next(0, 2) == 0
      {

        // IsValueCompatible == true
        IRandom<TYPE2> randomTYPE2Interface = random;
        randomTYPE2Interface.Next();
        result = Make((TYPE1) randomTYPE2Interface.Item);
      }
      else
      {

        // IsValueCompatible may be true or false
        IRandom<TYPE1> randomTYPE1Interface = random;
        randomTYPE1Interface.Next();
        result = Make(randomTYPE1Interface.Item);
      }

      return result;
#else
#error Relation between TYPE1 and TYPE2 is undefined.

#endif
    }

    public static ExplicitCastTYPE1TYPE2 Make(TYPE1 source)
    {

      ExplicitCastTYPE1TYPE2 instance = new ExplicitCastTYPE1TYPE2();
      Setup(instance, source);
      return instance;
    }

    protected static void Setup(ExplicitCastTYPE1TYPE2 instance, TYPE1 source)
    {

      instance.Source = source;
    }

    protected ExplicitCastTYPE1TYPE2()
    {
    }
  }

  public class UncheckedCastTYPE1TYPE2 : Cast<TYPE1, TYPE2>
  {

    protected override void Evaluate()
    {

      unchecked
      {

#if TYPE2IncludesTYPE1
        Destination = Source;

#else
        // Implicit cast results in compile-time error.

#endif
      }
    }

    public override bool IsUncheckedCast
    {

      get
      {

        return true;
      }
    }

    public override bool IsExplicitCast
    {

      get
      {

        return false;
      }
    }

    public override bool IsValueCopy
    {

      get
      {

        return CastProperties.IsValueCopy(this);
      }
    }

    public override bool IsZeroFillBinaryCopy
    {

      get
      {

        return CastProperties.IsZeroFillBinaryCopy(this);
      }
    }

    public override bool IsOneFillBinaryCopy
    {

      get
      {

        return CastProperties.IsOneFillBinaryCopy(this);
      }
    }

    public override bool IsCompileTimeError
    {

      get
      {

#if TYPE2IncludesTYPE1
        return false;

#else
        return true;

#endif
      }
    }

    public override bool IsValueCompatible
    {

      get
      {

#if TYPE2IncludesTYPE1
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ TYPE2
         *   S ⇔ TYPE1
         */

        return true;

#elif TYPE2OverlapsTYPE1
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ TYPE2
         *   S ⇔ TYPE1
         */

        return Source >= 0;

#elif TYPE1OverlapsTYPE2
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ TYPE1
         *   S ⇔ TYPE2
         */

        return ((TYPE1) TYPE2.MaxValue) >= Source;

#elif TYPE1IncludesTYPE2
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ TYPE1
         *   S ⇔ TYPE2
         */

        return (TYPE2.MaxValue >= Source) && (Source >= TYPE2.MinValue);

#else
#error Relation between TYPE1 and TYPE2 is undefined.

#endif
      }
    }

    public static UncheckedCastTYPE1TYPE2 Make(Random2 random)
    {

#if TYPE2IncludesTYPE1
      /*
       * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
       * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
       * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
       *   D ⇔ TYPE2
       *   S ⇔ TYPE1
       */

      // 100% IsValueCompatible
      IRandom<TYPE1> randomTYPE1Interface = random;
      randomTYPE1Interface.Next();
      return Make(randomTYPE1Interface.Item);

#elif TYPE2OverlapsTYPE1
      /*
       * 9088a52d-d371-4363-9009-2f7f58abde72
       * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
       * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
       *   D ⇔ TYPE2
       *   S ⇔ TYPE1
       */

      // 50% IsValueCompatible
      IRandom<TYPE1> randomTYPE1Interface = random;
      randomTYPE1Interface.Next();
      return Make(randomTYPE1Interface.Item);

#elif TYPE1OverlapsTYPE2
      /*
       * 9088a52d-d371-4363-9009-2f7f58abde72
       * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
       * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
       *   D ⇔ TYPE1
       *   S ⇔ TYPE2
       */

      // < 50% IsValueCompatible

      // We want to bring IsValueCompatible probability to >= 50%. To do this,
      // we'll manually ensure compatibility 50% of the time. Remember that for
      // the 50% of the time that we are NOT manually ensuring compatibility,
      // we still have a small chance of getting a compatible value anyway, so
      // the actual probability of IsValueCompatible being true is greater than
      // 50%. In fact, we expect 75% when TYPE1 is the unsigned version of
      // TYPE2. When TYPE1 is a larger unsigned type than TYPE2, we expect
      // IsValueCompatible probability to be only slightly greater than 50%.

      UncheckedCastTYPE1TYPE2 result;

      IRandom<TYPE2> randomTYPE2Interface = random;
      randomTYPE2Interface.Next();
      if (randomTYPE2Interface.Item >= 0) // 50% randomTYPE2Interface.Item >= 0
      {

        // IsValueCompatible == true
        result = Make((TYPE1) randomTYPE2Interface.Item);
      }
      else
      {

        // IsValueCompatible may be true or false
        IRandom<TYPE1> randomTYPE1Interface = random;
        randomTYPE1Interface.Next();
        result = Make(randomTYPE1Interface.Item);
      }

      return result;
#elif TYPE1IncludesTYPE2
      /*
       * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
       * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
       * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
       *   D ⇔ TYPE1
       *   S ⇔ TYPE2
       */

      // < 50% IsValueCompatible

      // Just like above, we want to bring IsValueCompatible probability to >=
      // 50%.

      UncheckedCastTYPE1TYPE2 result;

      if (random.Next(0, 2) == 0) // 50% random.Next(0, 2) == 0
      {

        // IsValueCompatible == true
        IRandom<TYPE2> randomTYPE2Interface = random;
        randomTYPE2Interface.Next();
        result = Make((TYPE1) randomTYPE2Interface.Item);
      }
      else
      {

        // IsValueCompatible may be true or false
        IRandom<TYPE1> randomTYPE1Interface = random;
        randomTYPE1Interface.Next();
        result = Make(randomTYPE1Interface.Item);
      }

      return result;
#else
#error Relation between TYPE1 and TYPE2 is undefined.

#endif
    }

    public static UncheckedCastTYPE1TYPE2 Make(TYPE1 source)
    {

      UncheckedCastTYPE1TYPE2 instance = new UncheckedCastTYPE1TYPE2();
      Setup(instance, source);
      return instance;
    }

    protected static void Setup(UncheckedCastTYPE1TYPE2 instance, TYPE1 source)
    {

      instance.Source = source;
    }

    protected UncheckedCastTYPE1TYPE2()
    {
    }
  }

  public class ExplicitUncheckedCastTYPE1TYPE2 : Cast<TYPE1, TYPE2>
  {

    protected override void Evaluate()
    {

      unchecked
      {

        Destination = (TYPE2) Source;
      }
    }

    public override bool IsUncheckedCast
    {

      get
      {

        return true;
      }
    }

    public override bool IsExplicitCast
    {

      get
      {

        return true;
      }
    }

    public override bool IsValueCopy
    {

      get
      {

        return CastProperties.IsValueCopy(this);
      }
    }

    public override bool IsZeroFillBinaryCopy
    {

      get
      {

        return CastProperties.IsZeroFillBinaryCopy(this);
      }
    }

    public override bool IsOneFillBinaryCopy
    {

      get
      {

        return CastProperties.IsOneFillBinaryCopy(this);
      }
    }

    public override bool IsCompileTimeError
    {

      get
      {

        return false;
      }
    }

    public override bool IsValueCompatible
    {

      get
      {

#if TYPE2IncludesTYPE1
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ TYPE2
         *   S ⇔ TYPE1
         */

        return true;

#elif TYPE2OverlapsTYPE1
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ TYPE2
         *   S ⇔ TYPE1
         */

        return Source >= 0;

#elif TYPE1OverlapsTYPE2
        /*
         * 9088a52d-d371-4363-9009-2f7f58abde72
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
         *   D ⇔ TYPE1
         *   S ⇔ TYPE2
         */

        return ((TYPE1) TYPE2.MaxValue) >= Source;

#elif TYPE1IncludesTYPE2
        /*
         * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
         * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
         * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
         *   D ⇔ TYPE1
         *   S ⇔ TYPE2
         */

        return (TYPE2.MaxValue >= Source) && (Source >= TYPE2.MinValue);

#else
#error Relation between TYPE1 and TYPE2 is undefined.

#endif
      }
    }

    public static ExplicitUncheckedCastTYPE1TYPE2 Make(Random2 random)
    {

#if TYPE2IncludesTYPE1
      /*
       * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
       * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
       * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
       *   D ⇔ TYPE2
       *   S ⇔ TYPE1
       */

      // 100% IsValueCompatible
      IRandom<TYPE1> randomTYPE1Interface = random;
      randomTYPE1Interface.Next();
      return Make(randomTYPE1Interface.Item);

#elif TYPE2OverlapsTYPE1
      /*
       * 9088a52d-d371-4363-9009-2f7f58abde72
       * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
       * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
       *   D ⇔ TYPE2
       *   S ⇔ TYPE1
       */

      // 50% IsValueCompatible
      IRandom<TYPE1> randomTYPE1Interface = random;
      randomTYPE1Interface.Next();
      return Make(randomTYPE1Interface.Item);

#elif TYPE1OverlapsTYPE2
      /*
       * 9088a52d-d371-4363-9009-2f7f58abde72
       * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
       * (max(values(D)) >= max(values(S))) ∧ ¬(min(values(S)) >= min(values(D))) ∧ (s >= 0) ⇒ s ∈ values(D)
       *   D ⇔ TYPE1
       *   S ⇔ TYPE2
       */

      // < 50% IsValueCompatible

      // We want to bring IsValueCompatible probability to >= 50%. To do this,
      // we'll manually ensure compatibility 50% of the time. Remember that for
      // the 50% of the time that we are NOT manually ensuring compatibility,
      // we still have a small chance of getting a compatible value anyway, so
      // the actual probability of IsValueCompatible being true is greater than
      // 50%. In fact, we expect 75% when TYPE1 is the unsigned version of
      // TYPE2. When TYPE1 is a larger unsigned type than TYPE2, we expect
      // IsValueCompatible probability to be only slightly greater than 50%.

      ExplicitUncheckedCastTYPE1TYPE2 result;

      IRandom<TYPE2> randomTYPE2Interface = random;
      randomTYPE2Interface.Next();
      if (randomTYPE2Interface.Item >= 0) // 50% randomTYPE2Interface.Item >= 0
      {

        // IsValueCompatible == true
        result = Make((TYPE1) randomTYPE2Interface.Item);
      }
      else
      {

        // IsValueCompatible may be true or false
        IRandom<TYPE1> randomTYPE1Interface = random;
        randomTYPE1Interface.Next();
        result = Make(randomTYPE1Interface.Item);
      }

      return result;
#elif TYPE1IncludesTYPE2
      /*
       * 5c9244e4-8bcb-4779-b65d-8986ce67d6a7
       * D ∈ IT ∧ S ∈ IT ∧ s ∈ values(S) ⇒
       * (max(values(D)) >= max(values(S))) ∧ (min(values(S)) >= min(values(D))) ⇒ s ∈ values(D)
       *   D ⇔ TYPE1
       *   S ⇔ TYPE2
       */

      // < 50% IsValueCompatible

      // Just like above, we want to bring IsValueCompatible probability to >=
      // 50%.

      ExplicitUncheckedCastTYPE1TYPE2 result;

      if (random.Next(0, 2) == 0) // 50% random.Next(0, 2) == 0
      {

        // IsValueCompatible == true
        IRandom<TYPE2> randomTYPE2Interface = random;
        randomTYPE2Interface.Next();
        result = Make((TYPE1) randomTYPE2Interface.Item);
      }
      else
      {

        // IsValueCompatible may be true or false
        IRandom<TYPE1> randomTYPE1Interface = random;
        randomTYPE1Interface.Next();
        result = Make(randomTYPE1Interface.Item);
      }

      return result;
#else
#error Relation between TYPE1 and TYPE2 is undefined.

#endif
    }

    public static ExplicitUncheckedCastTYPE1TYPE2 Make(TYPE1 source)
    {

      ExplicitUncheckedCastTYPE1TYPE2 instance = new ExplicitUncheckedCastTYPE1TYPE2();
      Setup(instance, source);
      return instance;
    }

    protected static void Setup(ExplicitUncheckedCastTYPE1TYPE2 instance, TYPE1 source)
    {

      instance.Source = source;
    }

    protected ExplicitUncheckedCastTYPE1TYPE2()
    {
    }
  }
