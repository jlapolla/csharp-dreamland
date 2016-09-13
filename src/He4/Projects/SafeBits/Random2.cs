using System;

namespace He4.Projects.SafeBits
{

  public class Random2 : Random
  {

    public byte NextByte()
    {

      return (byte) Next(Byte.MinValue, Byte.MaxValue + 1);
    }

    public sbyte NextSByte()
    {

      return (sbyte) Next(SByte.MinValue, SByte.MaxValue + 1);
    }

    public short NextInt16()
    {

      return (short) Next(Int16.MinValue, Int16.MaxValue + 1);
    }

    public ushort NextUInt16()
    {

      return (ushort) Next(UInt16.MinValue, UInt16.MaxValue + 1);
    }

    public int NextInt32()
    {

      return unchecked((int) NextUInt32());
    }

    public uint NextUInt32()
    {

      return (uint) (NextDouble() * UInt32.MaxValue);
    }

    public long NextInt64()
    {

      return unchecked((long) NextUInt64());
    }

    public ulong NextUInt64()
    {

      return (ulong) (NextDouble() * UInt64.MaxValue);
    }

    public static Random2 Make()
    {

      return new Random2();
    }

    public static Random2 Make(int seed)
    {

      return new Random2(seed);
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
