#if NUNIT
using NUnit.Framework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

using System;

namespace He4.Reflection.Tests
{

#if NUNIT
  [TestFixture]
#else
  [TestClass]
#endif
  public class MemberAccessorTest
  {

    /* Basic tests */
#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeWorksWithSameNameMethod()
    {

      var target = SampleClass.Make();
      var accessor = MemberAccessor<SampleClass, ValueType>.Make("ComboValue");
      accessor.Target = target;

      accessor.Member = 0;
      Assert.AreEqual(0, target.Value);
      Assert.AreEqual(0, accessor.Member);

      target.Value = 1;
      Assert.AreEqual(1, target.Value);
      Assert.AreEqual(1, accessor.Member);

      accessor.Member = 2;
      Assert.AreEqual(2, target.Value);
      Assert.AreEqual(2, accessor.Member);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeWorksWithDifferentNameMethod()
    {

      var target = SampleClass.Make();
      var accessor = MemberAccessor<SampleClass, ValueType>.Make("GetValue", "SetValue");
      accessor.Target = target;

      accessor.Member = 0;
      Assert.AreEqual(0, target.Value);
      Assert.AreEqual(0, accessor.Member);

      target.Value = 1;
      Assert.AreEqual(1, target.Value);
      Assert.AreEqual(1, accessor.Member);

      accessor.Member = 2;
      Assert.AreEqual(2, target.Value);
      Assert.AreEqual(2, accessor.Member);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeDuplicatesTemplateBinding()
    {

      var target = SampleClass.Make();
      var accessor = MemberAccessor<SampleClass, ValueType>.Make(
          MemberAccessor<SampleClass, ValueType>.Make("ValueProperty"));
      accessor.Target = target;

      accessor.Member = 0;
      Assert.AreEqual(0, target.Value);
      Assert.AreEqual(0, accessor.Member);

      target.Value = 1;
      Assert.AreEqual(1, target.Value);
      Assert.AreEqual(1, accessor.Member);

      accessor.Member = 2;
      Assert.AreEqual(2, target.Value);
      Assert.AreEqual(2, accessor.Member);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void WorksThroughIMemberAccessorInterface()
    {

      var target = SampleClass.Make();
      var implementation = MemberAccessor<SampleClass, ValueType>.Make("ValueProperty");
      implementation.Target = target;
      IMemberAccessor<ValueType> accessor = implementation;

      accessor.Member = 0;
      Assert.AreEqual(0, target.Value);
      Assert.AreEqual(0, accessor.Member);

      target.Value = 1;
      Assert.AreEqual(1, target.Value);
      Assert.AreEqual(1, accessor.Member);

      accessor.Member = 2;
      Assert.AreEqual(2, target.Value);
      Assert.AreEqual(2, accessor.Member);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void WorksThroughIReadableMemberAccessorInterface()
    {

      var target = SampleClass.Make();
      var implementation = MemberAccessor<SampleClass, ValueType>.Make("ValueProperty");
      implementation.Target = target;
      IReadableMemberAccessor<ValueType> accessor = implementation;

      target.Value = 0;
      Assert.AreEqual(0, accessor.Member);
      Assert.AreEqual(0, accessor.Get());
      Assert.AreNotEqual(1, accessor.Get());

      target.Value = 1;
      Assert.AreEqual(1, accessor.Member);
      Assert.AreEqual(1, accessor.Get());
      Assert.AreNotEqual(0, accessor.Get());
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void WorksThroughIWritableMemberAccessorInterface()
    {

      var target = SampleClass.Make();
      var implementation = MemberAccessor<SampleClass, ValueType>.Make("ValueProperty");
      implementation.Target = target;
      IWritableMemberAccessor<ValueType> accessor = implementation;

      accessor.Member = 0;
      Assert.AreEqual(0, target.Value);

      accessor.Set(1);
      Assert.AreEqual(1, target.Value);

      accessor.Member = 2;
      Assert.AreEqual(2, target.Value);
    }
  }
}
