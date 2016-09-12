using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace He4.Projects.SafeBits.Tests
{

  [TestClass]
  public class UnpackedInt32Tests
  {

    [TestMethod]
    public void ParsingWorks()
    {

      var a = UnpackedInt32.Make();

      a.HighWord = 12;
      a.LowWord = 88;
      Assert.AreEqual(a, UnpackedInt32.Parse(a.ToInt32()));

      a.HighWord = 12;
      a.LowWord = -88;
      Assert.AreEqual(a, UnpackedInt32.Parse(a.ToInt32()));

      a.HighWord = -12;
      a.LowWord = 88;
      Assert.AreEqual(a, UnpackedInt32.Parse(a.ToInt32()));

      a.HighWord = -12;
      a.LowWord = -88;
      Assert.AreEqual(a, UnpackedInt32.Parse(a.ToInt32()));
    }
  }
}
