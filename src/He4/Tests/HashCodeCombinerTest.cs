#if NUNIT
using NUnit.Framework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

using System;

namespace He4.Tests
{

#if NUNIT
  [TestFixture]
#else
  [TestClass]
#endif
  public class HashCodeCombinerTest
  {

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeIntializesValue()
    {

      var hash = HashCodeCombiner.Make(1009, 9176);
      Assert.AreEqual(1009, hash.Value);
    }
  }
}
