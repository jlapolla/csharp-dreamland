using System;

namespace He4.Projects.SafeBits
{

  public interface ICast
  {
  }

  public abstract class Cast<TSource, TDestination>
  {

    protected abstract void Evaluate();
    public abstract bool IsCheckedCast { get; }
    public abstract bool IsExplicitCast { get; }
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

  public abstract class SameCast<T> : Cast<T, T>
  {

    public override bool IsValueCompatible
    {

      get
      {

        return true;
      }
    }
  }

  public abstract class ImplicitCheckedSameCast<T> : SameCast<T>
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

    public override bool IsExplicitCast
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

  public sealed class SByteSByteImplicitChecked : ImplicitCheckedSameCast<sbyte>
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

          int sourceLimit = 8 * TypeProperties.SizeOf(SourceType);
          int destinationLimit = 8 * TypeProperties.SizeOf(DestinationType);
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

          int sourceLimit = 8 * TypeProperties.SizeOf(SourceType);
          int destinationLimit = 8 * TypeProperties.SizeOf(DestinationType);
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

    public static SByteSByteImplicitChecked Make(Random2 random)
    {

      var instance = new SByteSByteImplicitChecked();
      instance.Source = random.NextSByte();
      return instance;
    }
  }
}
