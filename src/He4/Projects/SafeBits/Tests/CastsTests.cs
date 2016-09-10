using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace He4.Projects.SafeBits.Tests
{

  /// <summary>
  /// Experiments with casting.
  /// </summary>
  [TestClass]
  public class CastsTests
  {

    [TestMethod]
    public void CastToByte()
    {

      Byte val;

      val = 0x00;
      Assert.AreEqual(0, val);

      val = 0xFF;
      Assert.AreEqual(255, val);
    }

    [TestMethod]
    public void UncheckedCastToByte()
    {

      Byte val;

      val = unchecked((Byte) 0x100);
      Assert.AreEqual(0, val);

      val = unchecked((Byte) 0x1FF);
      Assert.AreEqual(255, val);
    }

    [TestMethod]
    public void CastToSByte()
    {

      SByte val;

      val = -0x80;
      Assert.AreEqual(-128, val);

      val = 0x7F;
      Assert.AreEqual(127, val);
    }

    [TestMethod]
    public void UncheckedCastToSByte()
    {

      SByte val;

      val = unchecked((SByte) 0x80);
      Assert.AreEqual(-128, val);

      val = unchecked((SByte) 0xFF);
      Assert.AreEqual(-1, val);

      val = unchecked((SByte) 0x100);
      Assert.AreEqual(0, val);

      val = unchecked((SByte) 0x17F);
      Assert.AreEqual(127, val);
    }

    [TestMethod]
    public void CastToUInt16()
    {

      UInt16 val;

      val = 0x0000;
      Assert.AreEqual(0, val);

      val = 0xFFFF;
      Assert.AreEqual(65535, val);
    }

    [TestMethod]
    public void UncheckedCastToUInt16()
    {

      UInt16 val;

      val = unchecked((UInt16) 0x10000);
      Assert.AreEqual(0, val);

      val = unchecked((UInt16) 0x1FFFF);
      Assert.AreEqual(65535, val);
    }

    [TestMethod]
    public void CastToInt16()
    {

      Int16 val;

      val = -0x8000;
      Assert.AreEqual(-32768, val);

      val = 0x7FFF;
      Assert.AreEqual(32767, val);
    }

    [TestMethod]
    public void UncheckedCastToInt16()
    {

      Int16 val;

      val = unchecked((Int16) 0x8000);
      Assert.AreEqual(-32768, val);

      val = unchecked((Int16) 0xFFFF);
      Assert.AreEqual(-1, val);

      val = unchecked((Int16) 0x10000);
      Assert.AreEqual(0, val);

      val = unchecked((Int16) 0x17FFF);
      Assert.AreEqual(32767, val);
    }

    [TestMethod]
    public void CastToUInt32()
    {

      UInt32 val;

      val = 0x00000000;
      Assert.AreEqual((UInt32) 0, val);

      val = 0xFFFFFFFF;
      Assert.AreEqual(4294967295, val);
    }

    [TestMethod]
    public void UncheckedCastToUInt32()
    {

      UInt32 val;

      val = unchecked((UInt32) 0x100000000);
      Assert.AreEqual((UInt32) 0, val);

      val = unchecked((UInt32) 0x1FFFFFFFF);
      Assert.AreEqual(4294967295, val);
    }

    [TestMethod]
    public void CastToInt32()
    {

      Int32 val;

      val = -0x80000000;
      Assert.AreEqual(-2147483648, val);

      val = 0x7FFFFFFF;
      Assert.AreEqual(2147483647, val);
    }

    [TestMethod]
    public void UncheckedCastToInt32()
    {

      Int32 val;

      val = unchecked((Int32) 0x80000000);
      Assert.AreEqual(-2147483648, val);

      val = unchecked((Int32) 0xFFFFFFFF);
      Assert.AreEqual(-1, val);

      val = unchecked((Int32) 0x100000000);
      Assert.AreEqual(0, val);

      val = unchecked((Int32) 0x17FFFFFFF);
      Assert.AreEqual(2147483647, val);
    }

    [TestMethod]
    public void CastToUInt64()
    {

      UInt64 val;

      val = 0x0000000000000000;
      Assert.AreEqual((UInt64) 0, val);

      val = 0xFFFFFFFFFFFFFFFF;
      Assert.AreEqual(18446744073709551615, val);
    }

    /// <remarks>
    /// Cannot compile this function. Produces compilation error CS1021
    /// Integral constant is too large.
    /// </remarks>
    [TestMethod]
    public void UncheckedCastToUInt64()
    {

      // UInt64 val;

      // val = unchecked((UInt64) 0x10000000000000000);
      // Assert.AreEqual((UInt64) 0, val);

      // val = unchecked((UInt64) 0x1FFFFFFFFFFFFFFFF);
      // Assert.AreEqual(18446744073709551615, val);
    }
  }
}
