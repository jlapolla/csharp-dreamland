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
  public class ReadableMethodAccessorTest
  {

    /* String tests */
#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeThrowsWhenMethodDoesNotExist()
    {

      bool throwsError = false;

      try
      {

        ReadableMethodAccessor<SampleClass, ValueType>.Make("NonExistentProperty");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"NonExistentProperty\" must be a public, non-static, zero-argument method of He4.Reflection.Tests.SampleClass.", ex.Message);
      }

      Assert.IsTrue(throwsError);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeThrowsWhenMethodIsNotPublic()
    {

      bool throwsError = false;

      try
      {

        ReadableMethodAccessor<SampleClass, ValueType>.Make("GerPrivateValue");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"GerPrivateValue\" must be a public, non-static, zero-argument method of He4.Reflection.Tests.SampleClass.", ex.Message);
      }

      Assert.IsTrue(throwsError);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeThrowsWhenMethodIsStatic()
    {

      bool throwsError = false;

      try
      {

        ReadableMethodAccessor<SampleClass, ValueType>.Make("GetStaticValue");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"GetStaticValue\" must be a public, non-static, zero-argument method of He4.Reflection.Tests.SampleClass.", ex.Message);
      }

      Assert.IsTrue(throwsError);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeThrowsWhenMemberIsNotAMethod()
    {

      bool throwsError = false;

      try
      {

        ReadableMethodAccessor<SampleClass, ValueType>.Make("Value");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"Value\" must be a public, non-static, zero-argument method of He4.Reflection.Tests.SampleClass.", ex.Message);
      }

      Assert.IsTrue(throwsError);
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
      var accessor = ReadableMethodAccessor<SampleClass, ValueType>.Make(
          ReadableMethodAccessor<SampleClass, ValueType>.Make("GetValue"));
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

