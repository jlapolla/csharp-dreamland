using System;

namespace He4.Projects.SafeBits.Casts
{

  public interface ICast
  {
  }

  public abstract class Cast<TSource, TDestination>
  {

    protected abstract void Evaluate();
    public abstract bool IsCheckedCast { get; }
    public abstract bool IsImplicitCast { get; }
    public abstract bool IsValueCopy { get; }
    public abstract bool IsZeroFillBinaryCopy { get; }
    public abstract bool IsOneFillBinaryCopy { get; }
    public abstract bool IsCompileTimeError { get; }
    public abstract bool IsValueCompatible { get; }

    public Exception Exception { get; protected set; }

    private TDestination _Destination;
    public TDestination Destination
    {

      get
      {

        if (IsRunTimeError || IsCompileTimeError)
        {

          throw new InvalidOperationException();
        }

        return _Destination;
      }

      protected set
      {

        _Destination = value;
      }
    }

    private TSource _Source;
    public TSource Source
    {

      get
      {

        return _Source;
      }

      protected set
      {

        _Source = value;
        Exception = null;

        try
        {

          Evaluate();
        }
        catch (Exception e)
        {

          Exception = e;
        }
      }
    }

    public Type SourceType
    {

      get
      {

        return typeof(TSource);
      }
    }

    public Type DestinationType
    {

      get
      {

        return typeof(TDestination);
      }
    }

    public bool IsSourceTypeSigned
    {

      get
      {

        return TypeProperties.IsSigned(SourceType);
      }
    }

    public bool IsDestinationTypeSigned
    {

      get
      {

        return TypeProperties.IsSigned(DestinationType);
      }
    }

    public bool IsResizeShrink
    {

      get
      {

        return TypeProperties.SizeOf(DestinationType) < TypeProperties.SizeOf(SourceType);
      }
    }

    public bool IsResizeNone
    {

      get
      {

        return TypeProperties.SizeOf(DestinationType) == TypeProperties.SizeOf(SourceType);
      }
    }

    public bool IsResizeGrow
    {

      get
      {

        return TypeProperties.SizeOf(DestinationType) > TypeProperties.SizeOf(SourceType);
      }
    }

    public bool IsRunTimeError
    {

      get
      {

        return Exception != null;
      }
    }
  }

  public abstract class SameCastBase<T> : Cast<T, T>
  {

    public override bool IsValueCompatible
    {

      get
      {

        return true;
      }
    }
  }

  public abstract class SameCast<T> : SameCastBase<T>
  {

    protected override void Evaluate()
    {

      Destination = Source;
    }

    public override bool IsCheckedCast
    {

      get
      {

        return true;
      }
    }

    public override bool IsImplicitCast
    {

      get
      {

        return true;
      }
    }

    public override bool IsCompileTimeError
    {

      get
      {

        return false;
      }
    }
  }

  public abstract class ExplicitSameCast<T> : SameCastBase<T>
  {

    protected override void Evaluate()
    {

      Destination = (T) Source;
    }

    public override bool IsCheckedCast
    {

      get
      {

        return true;
      }
    }

    public override bool IsImplicitCast
    {

      get
      {

        return false;
      }
    }

    public override bool IsCompileTimeError
    {

      get
      {

        return false;
      }
    }
  }

  public abstract class UncheckedSameCast<T> : SameCastBase<T>
  {

    protected override void Evaluate()
    {

      unchecked
      {

        Destination = Source;
      }
    }

    public override bool IsCheckedCast
    {

      get
      {

        return false;
      }
    }

    public override bool IsImplicitCast
    {

      get
      {

        return true;
      }
    }

    public override bool IsCompileTimeError
    {

      get
      {

        return false;
      }
    }
  }

  public abstract class UncheckedExplicitSameCast<T> : SameCastBase<T>
  {

    protected override void Evaluate()
    {

      unchecked
      {

        Destination = (T) Source;
      }
    }

    public override bool IsCheckedCast
    {

      get
      {

        return false;
      }
    }

    public override bool IsImplicitCast
    {

      get
      {

        return false;
      }
    }

    public override bool IsCompileTimeError
    {

      get
      {

        return false;
      }
    }
  }

  public sealed class SByteSByte : SameCast<sbyte>
  {

    public override bool IsValueCopy
    {

      get
      {

        bool result = false;

        if (!(IsCompileTimeError || IsRunTimeError))
        {

          result = Destination == Source;
        }

        return result;
      }
    }

    public override bool IsZeroFillBinaryCopy
    {

      get
      {

        bool result = false;

        if (!(IsCompileTimeError || IsRunTimeError))
        {

          result = true;

          System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(SourceType);
          System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(DestinationType);
          sbyte sourceBit = 1;
          sbyte destinationBit = 1;

          for (var i = 0; i < destinationLimit; i++)
          {

            if (i < sourceLimit)
            {

              if (((Source & sourceBit) == 0) != ((Destination & destinationBit) == 0))
              {

                result = false;
                break;
              }

              sourceBit <<= 1;
            }
            else
            {

              if ((Destination & destinationBit) != 0)
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

    public override bool IsOneFillBinaryCopy
    {

      get
      {

        bool result = false;

        if (!(IsCompileTimeError || IsRunTimeError))
        {

          result = true;

          System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(SourceType);
          System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(DestinationType);
          sbyte sourceBit = 1;
          sbyte destinationBit = 1;

          for (var i = 0; i < destinationLimit; i++)
          {

            if (i < sourceLimit)
            {

              if (((Source & sourceBit) == 0) != ((Destination & destinationBit) == 0))
              {

                result = false;
                break;
              }

              sourceBit <<= 1;
            }
            else
            {

              if ((Destination & destinationBit) == 0)
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

    public static SByteSByte Make(Random2 random)
    {

      var instance = new SByteSByte();
      instance.Source = random.NextSByte();
      return instance;
    }

    private SByteSByte()
    {
    }
  }

  public sealed class SByteSByteExplicit : ExplicitSameCast<sbyte>
  {

    public override bool IsValueCopy
    {

      get
      {

        bool result = false;

        if (!(IsCompileTimeError || IsRunTimeError))
        {

          result = Destination == Source;
        }

        return result;
      }
    }

    public override bool IsZeroFillBinaryCopy
    {

      get
      {

        bool result = false;

        if (!(IsCompileTimeError || IsRunTimeError))
        {

          result = true;

          System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(SourceType);
          System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(DestinationType);
          sbyte sourceBit = 1;
          sbyte destinationBit = 1;

          for (var i = 0; i < destinationLimit; i++)
          {

            if (i < sourceLimit)
            {

              if (((Source & sourceBit) == 0) != ((Destination & destinationBit) == 0))
              {

                result = false;
                break;
              }

              sourceBit <<= 1;
            }
            else
            {

              if ((Destination & destinationBit) != 0)
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

    public override bool IsOneFillBinaryCopy
    {

      get
      {

        bool result = false;

        if (!(IsCompileTimeError || IsRunTimeError))
        {

          result = true;

          System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(SourceType);
          System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(DestinationType);
          sbyte sourceBit = 1;
          sbyte destinationBit = 1;

          for (var i = 0; i < destinationLimit; i++)
          {

            if (i < sourceLimit)
            {

              if (((Source & sourceBit) == 0) != ((Destination & destinationBit) == 0))
              {

                result = false;
                break;
              }

              sourceBit <<= 1;
            }
            else
            {

              if ((Destination & destinationBit) == 0)
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

    public static SByteSByteExplicit Make(Random2 random)
    {

      var instance = new SByteSByteExplicit();
      instance.Source = random.NextSByte();
      return instance;
    }

    private SByteSByteExplicit()
    {
    }
  }

  public sealed class SByteSByteUnchecked : UncheckedSameCast<sbyte>
  {

    public override bool IsValueCopy
    {

      get
      {

        bool result = false;

        if (!(IsCompileTimeError || IsRunTimeError))
        {

          result = Destination == Source;
        }

        return result;
      }
    }

    public override bool IsZeroFillBinaryCopy
    {

      get
      {

        bool result = false;

        if (!(IsCompileTimeError || IsRunTimeError))
        {

          result = true;

          System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(SourceType);
          System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(DestinationType);
          sbyte sourceBit = 1;
          sbyte destinationBit = 1;

          for (var i = 0; i < destinationLimit; i++)
          {

            if (i < sourceLimit)
            {

              if (((Source & sourceBit) == 0) != ((Destination & destinationBit) == 0))
              {

                result = false;
                break;
              }

              sourceBit <<= 1;
            }
            else
            {

              if ((Destination & destinationBit) != 0)
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

    public override bool IsOneFillBinaryCopy
    {

      get
      {

        bool result = false;

        if (!(IsCompileTimeError || IsRunTimeError))
        {

          result = true;

          System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(SourceType);
          System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(DestinationType);
          sbyte sourceBit = 1;
          sbyte destinationBit = 1;

          for (var i = 0; i < destinationLimit; i++)
          {

            if (i < sourceLimit)
            {

              if (((Source & sourceBit) == 0) != ((Destination & destinationBit) == 0))
              {

                result = false;
                break;
              }

              sourceBit <<= 1;
            }
            else
            {

              if ((Destination & destinationBit) == 0)
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

    public static SByteSByteUnchecked Make(Random2 random)
    {

      var instance = new SByteSByteUnchecked();
      instance.Source = random.NextSByte();
      return instance;
    }

    private SByteSByteUnchecked()
    {
    }
  }

  public sealed class SByteSByteUncheckedExplicit : UncheckedExplicitSameCast<sbyte>
  {

    public override bool IsValueCopy
    {

      get
      {

        bool result = false;

        if (!(IsCompileTimeError || IsRunTimeError))
        {

          result = Destination == Source;
        }

        return result;
      }
    }

    public override bool IsZeroFillBinaryCopy
    {

      get
      {

        bool result = false;

        if (!(IsCompileTimeError || IsRunTimeError))
        {

          result = true;

          System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(SourceType);
          System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(DestinationType);
          sbyte sourceBit = 1;
          sbyte destinationBit = 1;

          for (var i = 0; i < destinationLimit; i++)
          {

            if (i < sourceLimit)
            {

              if (((Source & sourceBit) == 0) != ((Destination & destinationBit) == 0))
              {

                result = false;
                break;
              }

              sourceBit <<= 1;
            }
            else
            {

              if ((Destination & destinationBit) != 0)
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

    public override bool IsOneFillBinaryCopy
    {

      get
      {

        bool result = false;

        if (!(IsCompileTimeError || IsRunTimeError))
        {

          result = true;

          System.Int32 sourceLimit = 8 * TypeProperties.SizeOf(SourceType);
          System.Int32 destinationLimit = 8 * TypeProperties.SizeOf(DestinationType);
          sbyte sourceBit = 1;
          sbyte destinationBit = 1;

          for (var i = 0; i < destinationLimit; i++)
          {

            if (i < sourceLimit)
            {

              if (((Source & sourceBit) == 0) != ((Destination & destinationBit) == 0))
              {

                result = false;
                break;
              }

              sourceBit <<= 1;
            }
            else
            {

              if ((Destination & destinationBit) == 0)
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

    public static SByteSByteUncheckedExplicit Make(Random2 random)
    {

      var instance = new SByteSByteUncheckedExplicit();
      instance.Source = random.NextSByte();
      return instance;
    }

    private SByteSByteUncheckedExplicit()
    {
    }
  }
}
