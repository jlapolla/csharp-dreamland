using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using He4.Projects.SafeBits;

namespace He4.Projects.SafeBits.Tests
{

  [TestClass]
  public class UnsafeFunctionsTests
  {

    [TestMethod]
    [Description("Masking int's with short's.")]
    public void Mask_Int32WithInt16()
    {

      int data = 0xFFFFFF;

      /* This works as expected because the mask is positive */
      Assert.AreEqual(0x00007FFF, UnsafeFunctions.DoMask(data, 0x7FFF));

      /* This does not work as expected because the mask is negative */
      /* Compilation error: Assert.AreEqual(0x8000, UnsafeFunctions.DoMask(data, 0x8000)); */
      Assert.AreNotEqual(0x00008000, UnsafeFunctions.DoMask(data, unchecked((short) 0x8000)));
      Assert.AreEqual(0x00FF8000, UnsafeFunctions.DoMask(data, unchecked((short) 0x8000)));
    }
  }
}
