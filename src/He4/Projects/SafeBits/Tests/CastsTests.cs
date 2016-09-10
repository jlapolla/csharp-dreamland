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

    public const Byte A08 = 0x40;
    public const UInt16 A16 = 0x4140;
    public const UInt32 A32 = 0x40014140;
    public const UInt64 A64 = 0x4000000140014140;

    public const Byte B08 = 0x80;
    public const UInt16 B16 = 0x8180;
    public const UInt32 B32 = 0x80018180;
    public const UInt64 B64 = 0x8000000180018180;

    public const SByte C08 = unchecked((SByte) 0x40);
    public const Int16 C16 = unchecked((Int16) 0x4140);
    public const Int32 C32 = unchecked((Int32) 0x40014140);
    public const Int64 C64 = unchecked((Int64) 0x4000000140014140);

    public const SByte D08 = unchecked((SByte) 0x80);
    public const Int16 D16 = unchecked((Int16) 0x8180);
    public const Int32 D32 = unchecked((Int32) 0x80018180);
    public const Int64 D64 = unchecked((Int64) 0x8000000180018180);

    [TestMethod]
    public void ByteCasts()
    {

      Assert.AreEqual(A08, (Byte) A08);
      Assert.AreEqual(A08, unchecked((Byte) A16));
      Assert.AreEqual(A08, unchecked((Byte) A32));
      Assert.AreEqual(A08, unchecked((Byte) A64));
      // CS0221: Constant value '16704' cannot be converted to a 'byte' (use 'unchecked' syntax to override).
      // Assert.AreEqual(A08, (Byte) A16);
      // CS0221: Constant value '1073824064' cannot be converted to a 'byte' (use 'unchecked' syntax to override).
      // Assert.AreEqual(A08, (Byte) A32);
      // CS0221: Constant value '4611686023796179264' cannot be converted to a 'byte' (use 'unchecked' syntax to override).
      // Assert.AreEqual(A08, (Byte) A64);

      Assert.AreEqual(B08, (Byte) B08);
      Assert.AreEqual(B08, unchecked((Byte) B16));
      Assert.AreEqual(B08, unchecked((Byte) B32));
      Assert.AreEqual(B08, unchecked((Byte) B64));
      // CS0221: Constant value '33152' cannot be converted to a 'byte' (use 'unchecked' syntax to override).
      // Assert.AreEqual(B08, (Byte) B16);
      // CS0221: Constant value '2147582336' cannot be converted to a 'byte' (use 'unchecked' syntax to override).
      // Assert.AreEqual(B08, (Byte) B32);
      // CS0221: Constant value '9223372043297325440' cannot be converted to a 'byte' (use 'unchecked' syntax to override).
      // Assert.AreEqual(B08, (Byte) B64);

      Assert.AreEqual(A08, (Byte) C08);
      Assert.AreEqual(A08, unchecked((Byte) C16));
      Assert.AreEqual(A08, unchecked((Byte) C32));
      Assert.AreEqual(A08, unchecked((Byte) C64));
      // CS0221: Constant value '16704' cannot be converted to a 'byte' (use 'unchecked' syntax to override).
      // Assert.AreEqual(A08, (Byte) C16);
      // CS0221: Constant value '1073824064' cannot be converted to a 'byte' (use 'unchecked' syntax to override).
      // Assert.AreEqual(A08, (Byte) C32);
      // CS0221: Constant value '4611686023796179264' cannot be converted to a 'byte' (use 'unchecked' syntax to override).
      // Assert.AreEqual(A08, (Byte) C64);

      Assert.AreEqual(B08, unchecked((Byte) D08));
      Assert.AreEqual(B08, unchecked((Byte) D16));
      Assert.AreEqual(B08, unchecked((Byte) D32));
      Assert.AreEqual(B08, unchecked((Byte) D64));
      // CS0221: Constant value '-128' cannot be converted to a 'byte' (use 'unchecked' syntax to override).
      // Assert.AreEqual(B08, (Byte) D08);
      // CS0221: Constant value '-32384' cannot be converted to a 'byte' (use 'unchecked' syntax to override).
      // Assert.AreEqual(B08, (Byte) D16);
      // CS0221: Constant value '-2147384960' cannot be converted to a 'byte' (use 'unchecked' syntax to override).
      // Assert.AreEqual(B08, (Byte) D32);
      // CS0221: Constant value '-9223372030412226176' cannot be converted to a 'byte' (use 'unchecked' syntax to override).
      // Assert.AreEqual(B08, (Byte) D64);
    }
  }
}
