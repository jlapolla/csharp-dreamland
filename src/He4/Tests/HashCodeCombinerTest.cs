#if NUNIT
using NUnit.Framework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

using System;
using System.Collections.Generic;

namespace He4.Tests
{

#if NUNIT
  [TestFixture]
#else
  [TestClass]
#endif
  public class HashCodeCombinerTest
  {

    private class CustomEqualityComparer : EqualityComparer<int>
    {

      public override bool Equals(int left, int right)
      {

        return Default.Equals(left, right);
      }

      public override int GetHashCode(int obj)
      {

        return 10;
      }
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeIntializesValue()
    {

      var hash = HashCodeCombiner.Make(17, 31);

      Assert.AreEqual(17, hash.Value);
      Assert.AreEqual(31, hash.Factor);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void PutWorksWithSameValues()
    {

      var hash1 = HashCodeCombiner.Make();
      var hash2 = HashCodeCombiner.Make();

      int hashCode = hash1.Value;

      hash1.Put(32);
      hash2.Put(32);

      Assert.AreEqual(hash1.Value, hash2.Value);
      Assert.AreNotEqual(hashCode, hash1.Value);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void PutWorksWithDifferentValues()
    {

      var hash1 = HashCodeCombiner.Make();
      var hash2 = HashCodeCombiner.Make();

      int hashCode = hash1.Value;

      hash1.Put(32);
      hash2.Put(31);

      Assert.AreNotEqual(hash1.Value, hash2.Value);
      Assert.AreNotEqual(hashCode, hash1.Value);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void PutWorksWithNullValues()
    {

      var hash1 = HashCodeCombiner.Make();
      var hash2 = HashCodeCombiner.Make();

      int hashCode = hash1.Value;

      hash1.Put(null);
      hash2.Put(null);

      Assert.AreEqual(hash1.Value, hash2.Value);
      Assert.AreNotEqual(hashCode, hash1.Value);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void PutGivesDifferentResultsForDifferentNumberOfNulls()
    {

      var hash1 = HashCodeCombiner.Make();
      var hash2 = HashCodeCombiner.Make();

      int hashCode = hash1.Value;

      hash1.Put(null);
      hash1.Put(null);
      hash2.Put(null);

      Assert.AreNotEqual(hash1.Value, hash2.Value);
      Assert.AreNotEqual(hashCode, hash1.Value);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void GenericPutUsesProvidedEqualityComparer()
    {

      var hash1 = HashCodeCombiner.Make(0, 1);
      var hash2 = HashCodeCombiner.Make(0, 1);

      int hashCode = hash1.Value;

      hash1.Put<int>(32, new CustomEqualityComparer());
      hash2.Put(32);

      Assert.AreEqual(10, hash1.Value);
      Assert.AreNotEqual(hash1.Value, hash2.Value);
      Assert.AreNotEqual(hashCode, hash1.Value);
      Assert.AreNotEqual(hashCode, hash2.Value);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void PutHandlesIntegerOverflow()
    {

      var hash = HashCodeCombiner.Make(2147483647, 1);

      hash.Put<int>(32, new CustomEqualityComparer());

      Assert.AreEqual(-2147483639, hash.Value);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void TypedEqualsWorks()
    {

      var hash1 = HashCodeCombiner.Make(1, 2);
      var hash2 = HashCodeCombiner.Make(1, 2);
      var hash3 = HashCodeCombiner.Make(2, 1);

      Assert.IsTrue(hash1.Equals(hash2));
      Assert.IsFalse(hash1.Equals(hash3));
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void ObjectEqualsWorks()
    {

      var hash1 = HashCodeCombiner.Make(1, 2);
      var hash2 = HashCodeCombiner.Make(1, 2);
      var hash3 = HashCodeCombiner.Make(2, 1);

      Assert.IsTrue(hash1.Equals((object) hash2));
      Assert.IsFalse(hash1.Equals((object) hash3));
      Assert.IsFalse(hash1.Equals((object) 32));
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void GetHashCodeWorks()
    {
      var hash1 = HashCodeCombiner.Make(1, 2);
      var hash2 = HashCodeCombiner.Make(1, 2);
      var hash3 = HashCodeCombiner.Make(2, 1);

      Assert.AreEqual(hash1.GetHashCode(), hash2.GetHashCode());
      Assert.AreNotEqual(hash1.GetHashCode(), hash3.GetHashCode());
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void EqualityOperatorWorks()
    {

      var hash1 = HashCodeCombiner.Make(1, 2);
      var hash2 = HashCodeCombiner.Make(1, 2);
      var hash3 = HashCodeCombiner.Make(2, 1);

      Assert.IsTrue(hash1 == hash2);
      Assert.IsFalse(hash1 == hash3);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void InequalityOperatorWorks()
    {

      var hash1 = HashCodeCombiner.Make(1, 2);
      var hash2 = HashCodeCombiner.Make(1, 2);
      var hash3 = HashCodeCombiner.Make(2, 1);

      Assert.IsFalse(hash1 != hash2);
      Assert.IsTrue(hash1 != hash3);
    }
  }
}
