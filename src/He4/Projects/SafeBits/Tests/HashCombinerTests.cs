using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace He4.Projects.SafeBits.Tests
{

  [TestClass]
  public class HashCombinerTests
  {

    [TestMethod]
    public void MakeIntializesValue()
    {

      var hash = HashCombiner.Make();
      Assert.AreEqual(1009, hash.Value);
    }
  }
}
