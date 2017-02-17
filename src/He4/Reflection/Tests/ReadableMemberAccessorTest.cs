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
  public class ReadableMemberAccessorTest
  {

    /* Basic tests */
#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeThrowsWhenMemberDoesNotExist()
    {

      bool throwsError = false;

      try
      {

        ReadableMemberAccessor<SampleClass, ValueType>.Make("NonExistentMember");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"NonExistentMember\" must be a public, non-static property, zero-argument method, or field of He4.Reflection.Tests.SampleClass.", ex.Message);
      }

      Assert.IsTrue(throwsError);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeThrowsWhenMemberIsNotPublic()
    {

      bool throwsError = false;

      try
      {

        ReadableMemberAccessor<SampleClass, ValueType>.Make("PrivateValue");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"PrivateValue\" must be a public, non-static property, zero-argument method, or field of He4.Reflection.Tests.SampleClass.", ex.Message);
      }

      Assert.IsTrue(throwsError);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeThrowsWhenMemberIsStatic()
    {

      bool throwsError = false;

      try
      {

        ReadableMemberAccessor<SampleClass, ValueType>.Make("StaticValue");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"StaticValue\" must be a public, non-static property, zero-argument method, or field of He4.Reflection.Tests.SampleClass.", ex.Message);
      }

      Assert.IsTrue(throwsError);
    }

    /* Field tests */
#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeThrowsWhenFieldDoesNotConform()
    {

      bool throwsError = false;

      try
      {

        ReadableMemberAccessor<SampleClass, string>.Make("Value");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("He4.Reflection.Tests.SampleClass.Value must conform to System.String.", ex.Message);
      }

      Assert.IsTrue(throwsError);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void WorksWithFields()
    {

      var target = SampleClass.Make();
      var accessor = ReadableMemberAccessor<SampleClass, ValueType>.Make("Value");
      accessor.Target = target;

      target.Value = 0;
      Assert.AreEqual(0, accessor.Member);
      Assert.AreEqual(0, accessor.GetMember());
      Assert.AreNotEqual(1, accessor.GetMember());

      target.Value = 1;
      Assert.AreEqual(1, accessor.Member);
      Assert.AreEqual(1, accessor.GetMember());
      Assert.AreNotEqual(0, accessor.GetMember());
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void WorksWithCovarianceInFields()
    {

      var target = SampleClass.Make();
      var accessor = ReadableMemberAccessor<SampleClass, object>.Make("Value");
      accessor.Target = target;

      target.Value = 0;
      Assert.AreEqual((object) 0, accessor.Member);
      Assert.AreEqual((object) 0, accessor.GetMember());
      Assert.AreNotEqual((object) 1, accessor.GetMember());

      target.Value = 1;
      Assert.AreEqual((object) 1, accessor.Member);
      Assert.AreEqual((object) 1, accessor.GetMember());
      Assert.AreNotEqual((object) 0, accessor.GetMember());
    }

    /* Other tests */
#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeDuplicatesTemplateBinding()
    {

      var target = SampleClass.Make();
      var accessor = ReadableMemberAccessor<SampleClass, ValueType>.Make(
          ReadableMemberAccessor<SampleClass, ValueType>.Make("ValueProperty"));
      accessor.Target = target;

      target.Value = 0;
      Assert.AreEqual(0, accessor.Member);
      Assert.AreEqual(0, accessor.GetMember());
      Assert.AreNotEqual(1, accessor.GetMember());

      target.Value = 1;
      Assert.AreEqual(1, accessor.Member);
      Assert.AreEqual(1, accessor.GetMember());
      Assert.AreNotEqual(0, accessor.GetMember());
    }
  }
}
