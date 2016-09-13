using System;

namespace He4.Projects.SafeBits
{

  public enum CastTypes
  {
    Implicit,
    Explicit,
    Unchecked,
  }

  public sealed class SByteSByteImplicit : ImplicitSameCast<sbyte>
  {
  }

  public abstract class Cast<TSource, TDestination>
  {

    protected abstract void Evaluate();
    public abstract CastTypes CastType { get; }
    public abstract bool IsValueCopy { get; }
    public abstract bool IsZeroFillBinaryCopy { get; }
    public abstract bool IsOneFillBinaryCopy { get; }
    public abstract bool IsCompileTimeError { get; }
    public abstract bool IsValueCompatible { get; }

    public Exception Exception { get; protected set; }

    public TDestination Destination { get; protected set; }

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
        Evaluate();
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

    public bool IsRuntimeError
    {

      get
      {

        return Exception != null;
      }
    }
  }

  public abstract class ImplicitCast<TSource, TDestination> : Cast<TSource, TDestination>
  {

    public sealed override CastTypes CastType
    {

      get
      {

        return CastTypes.Implicit;
      }
    }
  }

  public abstract class SameCast<T> : Cast<T, T>
  {

    public sealed override bool IsValueCompatible
    {

      get
      {

        return true;
      }
    }
  }

  public abstract class ImplicitSameCast<T> : SameCast<T>
  {

    protected sealed override void Evaluate()
    {

      Destination = Source;
    }

    public sealed override CastTypes CastType
    {

      get
      {

        return CastTypes.Implicit;
      }
    }

    public sealed override bool IsValueCopy
    {

      get
      {

        return true;
      }
    }

    public sealed override bool IsZeroFillBinaryCopy
    {

      get
      {

        return true;
      }
    }

    public sealed override bool IsOneFillBinaryCopy
    {

      get
      {

        return true;
      }
    }

    public sealed override bool IsCompileTimeError
    {

      get
      {

        return false;
      }
    }
  }
}
