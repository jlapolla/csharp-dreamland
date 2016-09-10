using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace He4.Projects.SafeBits.Tests
{

  /// <summary>
  /// Experiments with numeric literals.
  /// </summary>
  ///
  /// <remarks>
  /// Refer to https://msdn.microsoft.com/en-us/library/exx3b86w.aspx
  /// </remarks>
  [TestClass]
  public class LiteralsTests
  {

    /// <summary>
    /// Examines the types and values of decimal and hexadecimal literals.
    /// </summary>
    [TestMethod]
    public void LiteralTypesAndValues()
    {

      /* 8 bits */

      // 0x01
      Assert.AreEqual(1, 0x01); // 2^0
      Assert.AreEqual(-1, -0x01); // -2^0
      Assert.AreEqual(typeof(Int32), (0x01).GetType());
      Assert.AreEqual(typeof(Int32), (-0x01).GetType());
      Assert.AreEqual(typeof(Int32), (1).GetType());
      Assert.AreEqual(typeof(Int32), (-1).GetType());

      // 0x80
      Assert.AreEqual(128, 0x80); // 2^7
      Assert.AreEqual(-128, -0x80); // -2^7
      Assert.AreEqual(typeof(Int32), (0x80).GetType());
      Assert.AreEqual(typeof(Int32), (-0x80).GetType());
      Assert.AreEqual(typeof(Int32), (128).GetType());
      Assert.AreEqual(typeof(Int32), (-128).GetType());

      /* 16 bits */

      // 0x01 00
      Assert.AreEqual(256, 0x0100); // 2^8
      Assert.AreEqual(-256, -0x0100); // -2^8
      Assert.AreEqual(typeof(Int32), (0x0100).GetType());
      Assert.AreEqual(typeof(Int32), (-0x0100).GetType());
      Assert.AreEqual(typeof(Int32), (256).GetType());
      Assert.AreEqual(typeof(Int32), (-256).GetType());

      // 0x80 00
      Assert.AreEqual(32768, 0x8000); // 2^15
      Assert.AreEqual(-32768, -0x8000); // -2^15
      Assert.AreEqual(typeof(Int32), (0x8000).GetType());
      Assert.AreEqual(typeof(Int32), (-0x8000).GetType());
      Assert.AreEqual(typeof(Int32), (32768).GetType());
      Assert.AreEqual(typeof(Int32), (-32768).GetType());

      /* 32 bits */

      // 0x0001 0000
      Assert.AreEqual(65536, 0x00010000); // 2^16
      Assert.AreEqual(-65536, -0x00010000); // -2^16
      Assert.AreEqual(typeof(Int32), (0x00010000).GetType());
      Assert.AreEqual(typeof(Int32), (-0x00010000).GetType());
      Assert.AreEqual(typeof(Int32), (65536).GetType());
      Assert.AreEqual(typeof(Int32), (-65536).GetType());

      // 0x8000 0000
      Assert.AreEqual(2147483648, 0x80000000); // 2^31
      Assert.AreEqual(-2147483648, -0x80000000); // -2^31
      Assert.AreEqual(typeof(UInt32), (0x80000000).GetType());
      Assert.AreEqual(typeof(Int32), (-0x80000000).GetType());
      Assert.AreEqual(typeof(UInt32), (2147483648).GetType());
      Assert.AreEqual(typeof(Int32), (-2147483648).GetType());

      /* 64 bits */

      // 0x0000 0001 0000 0000
      Assert.AreEqual(4294967296, 0x0000000100000000); // 2^32
      Assert.AreEqual(-4294967296, -0x0000000100000000); // -2^32
      Assert.AreEqual(typeof(Int64), (0x0000000100000000).GetType());
      Assert.AreEqual(typeof(Int64), (-0x0000000100000000).GetType());
      Assert.AreEqual(typeof(Int64), (4294967296).GetType());
      Assert.AreEqual(typeof(Int64), (-4294967296).GetType());

      // 0x8000 0000 0000 0000
      Assert.AreEqual(9223372036854775808, 0x8000000000000000); // 2^63
      Assert.AreEqual(-9223372036854775808, -0x8000000000000000); // -2^63
      Assert.AreEqual(typeof(UInt64), (0x8000000000000000).GetType());
      Assert.AreEqual(typeof(Int64), (-0x8000000000000000).GetType());
      Assert.AreEqual(typeof(UInt64), (9223372036854775808).GetType());
      Assert.AreEqual(typeof(Int64), (-9223372036854775808).GetType());

      /* 65 bits (causes compiler error) */

      // 0x1 0000 0000 0000 0000
      // Causes compiler error CS1021: Integral constant is too large

      /*
       * Assert.AreEqual(0x10000000000000000, 0x10000000000000000); // 2^64
       * Assert.AreEqual(-0x10000000000000000, -0x10000000000000000); // -2^64
       */
    }
  }
}
