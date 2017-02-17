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
  public class ReadablePropertyAccessorTest
  {

    /* String tests */
#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeThrowsWhenPropertyDoesNotExist()
    {

      bool throwsError = false;

      try
      {

        ReadablePropertyAccessor<SampleClass, ValueType>.Make("NonExistentProperty");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"NonExistentProperty\" must be a public, non-static property of He4.Reflection.Tests.SampleClass.", ex.Message);
      }

      Assert.IsTrue(throwsError);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeThrowsWhenPropertyIsNotPublic()
    {

      bool throwsError = false;

      try
      {

        ReadablePropertyAccessor<SampleClass, ValueType>.Make("PrivateValueProperty");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"PrivateValueProperty\" must be a public, non-static property of He4.Reflection.Tests.SampleClass.", ex.Message);
      }

      Assert.IsTrue(throwsError);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeThrowsWhenPropertyIsStatic()
    {

      bool throwsError = false;

      try
      {

        ReadablePropertyAccessor<SampleClass, ValueType>.Make("StaticValueProperty");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"StaticValueProperty\" must be a public, non-static property of He4.Reflection.Tests.SampleClass.", ex.Message);
      }

      Assert.IsTrue(throwsError);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeThrowsWhenMemberIsNotAProperty()
    {

      bool throwsError = false;

      try
      {

        ReadablePropertyAccessor<SampleClass, ValueType>.Make("Value");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"Value\" must be a public, non-static property of He4.Reflection.Tests.SampleClass.", ex.Message);
      }

      Assert.IsTrue(throwsError);
    }

    /* Property tests */
#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeThrowsWhenPropertyDoesNotConform()
    {

      bool throwsError = false;

      try
      {

        ReadablePropertyAccessor<SampleClass, string>.Make("ValueProperty");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("He4.Reflection.Tests.SampleClass.ValueProperty must conform to System.String.", ex.Message);
      }

      Assert.IsTrue(throwsError);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeThrowsWhenPropertyDoesNotHavePublicGetAccessor()
    {

      bool throwsError = false;

      try
      {

        ReadablePropertyAccessor<SampleClass, ValueType>.Make("ValuePropertySetOnly");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("He4.Reflection.Tests.SampleClass.ValuePropertySetOnly must have a public get accessor.", ex.Message);
      }

      Assert.IsTrue(throwsError);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void WorksWithReadablePublicProperty()
    {

      var target = SampleClass.Make();
      var accessor = ReadablePropertyAccessor<SampleClass, ValueType>.Make("ValuePropertyGetOnly");
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
    public void WorksWithCovarianceInProperties()
    {

      var target = SampleClass.Make();
      var accessor = ReadablePropertyAccessor<SampleClass, object>.Make("ValueProperty");
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

    /* Duplication tests */
#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeDuplicatesTemplateBinding()
    {

      var target = SampleClass.Make();
      var accessor = ReadablePropertyAccessor<SampleClass, ValueType>.Make(
          ReadablePropertyAccessor<SampleClass, ValueType>.Make("ValueProperty"));
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

