using System;

namespace He4.Projects.SafeBits
{

  public class Random2 : Random, IRandom<byte>, IRandom<sbyte>, IRandom<short>, IRandom<ushort>, IRandom<int>, IRandom<uint>, IRandom<long>, IRandom<ulong>
  {

    protected byte CurrentByte;
    protected sbyte CurrentSByte;
    protected short CurrentInt16;
    protected ushort CurrentUInt16;
    protected int CurrentInt32;
    protected uint CurrentUInt32;
    protected long CurrentInt64;
    protected ulong CurrentUInt64;

    public byte NextByte()
    {

      return (byte) Next(byte.MinValue, byte.MaxValue + 1);
    }

    public sbyte NextSByte()
    {

      return (sbyte) Next(sbyte.MinValue, sbyte.MaxValue + 1);
    }

    public short NextInt16()
    {

      return (short) Next(short.MinValue, short.MaxValue + 1);
    }

    public ushort NextUInt16()
    {

      return (ushort) Next(ushort.MinValue, ushort.MaxValue + 1);
    }

    public int NextInt32()
    {

      return unchecked((int) NextUInt32());
    }

    public uint NextUInt32()
    {

      return (uint) (NextDouble() * uint.MaxValue);
    }

    public long NextInt64()
    {

      return unchecked((long) NextUInt64());
    }

    public ulong NextUInt64()
    {

      return (ulong) (NextDouble() * ulong.MaxValue);
    }

    void IRandom<byte>.Next()
    {

      CurrentByte = NextByte();
    }

    byte IRandom<byte>.Item
    {

      get
      {

        return CurrentByte;
      }
    }

    void IRandom<sbyte>.Next()
    {

      CurrentSByte = NextSByte();
    }

    sbyte IRandom<sbyte>.Item
    {

      get
      {

        return CurrentSByte;
      }
    }

    void IRandom<short>.Next()
    {

      CurrentInt16 = NextInt16();
    }

    short IRandom<short>.Item
    {

      get
      {

        return CurrentInt16;
      }
    }

    void IRandom<ushort>.Next()
    {

      CurrentUInt16 = NextUInt16();
    }

    ushort IRandom<ushort>.Item
    {

      get
      {

        return CurrentUInt16;
      }
    }

    void IRandom<int>.Next()
    {

      CurrentInt32 = NextInt32();
    }

    int IRandom<int>.Item
    {

      get
      {

        return CurrentInt32;
      }
    }

    void IRandom<uint>.Next()
    {

      CurrentUInt32 = NextUInt32();
    }

    uint IRandom<uint>.Item
    {

      get
      {

        return CurrentUInt32;
      }
    }

    void IRandom<long>.Next()
    {

      CurrentInt64 = NextInt64();
    }

    long IRandom<long>.Item
    {

      get
      {

        return CurrentInt64;
      }
    }

    void IRandom<ulong>.Next()
    {

      CurrentUInt64 = NextUInt64();
    }

    ulong IRandom<ulong>.Item
    {

      get
      {

        return CurrentUInt64;
      }
    }

    public static Random2 Make()
    {

      Random2 instance = new Random2();
      Setup(instance);
      return instance;
    }

    public static Random2 Make(int seed)
    {

      Random2 instance = new Random2(seed);
      Setup(instance);
      return instance;
    }

    protected static void Setup(Random2 instance)
    {

      ((IRandom<byte>) instance).Next();
      ((IRandom<sbyte>) instance).Next();
      ((IRandom<short>) instance).Next();
      ((IRandom<ushort>) instance).Next();
      ((IRandom<int>) instance).Next();
      ((IRandom<uint>) instance).Next();
      ((IRandom<long>) instance).Next();
      ((IRandom<ulong>) instance).Next();
    }

    protected Random2()
      : base()
    {
    }

    protected Random2(int seed)
      : base(seed)
    {
    }
  }
}
