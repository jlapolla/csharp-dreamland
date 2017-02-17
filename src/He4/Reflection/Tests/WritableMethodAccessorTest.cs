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
  public class WritableMethodAccessorTest
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

        WritableMethodAccessor<SampleClass, ValueType>.Make("NonExistentMember");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"NonExistentMember\" must be a public, non-static, one-argument method of He4.Reflection.Tests.SampleClass whose argument is assignable from System.ValueType.", ex.Message);
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

        WritableMethodAccessor<SampleClass, ValueType>.Make("SetPrivateValue");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"SetPrivateValue\" must be a public, non-static, one-argument method of He4.Reflection.Tests.SampleClass whose argument is assignable from System.ValueType.", ex.Message);
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

        WritableMethodAccessor<SampleClass, ValueType>.Make("SetStaticValue");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"SetStaticValue\" must be a public, non-static, one-argument method of He4.Reflection.Tests.SampleClass whose argument is assignable from System.ValueType.", ex.Message);
      }

      Assert.IsTrue(throwsError);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeThrowsWhenMethodHasMoreThanOneArgument()
    {

      bool throwsError = false;

      try
      {

        WritableMethodAccessor<SampleClass, ValueType>.Make("SetValueWithExtraArguments");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"SetValueWithExtraArguments\" must be a public, non-static, one-argument method of He4.Reflection.Tests.SampleClass whose argument is assignable from System.ValueType.", ex.Message);
      }

      Assert.IsTrue(throwsError);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeThrowsWhenMethodArgumenTypeDoesNotConform()
    {

      bool throwsError = false;

      try
      {

        WritableMethodAccessor<SampleClass, object>.Make("SetValue");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"SetValue\" must be a public, non-static, one-argument method of He4.Reflection.Tests.SampleClass whose argument is assignable from System.Object.", ex.Message);
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

        WritableMethodAccessor<SampleClass, ValueType>.Make("Value");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"Value\" must be a public, non-static, one-argument method of He4.Reflection.Tests.SampleClass whose argument is assignable from System.ValueType.", ex.Message);
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
      var accessor = WritableMethodAccessor<SampleClass, ValueType>.Make(
          WritableMethodAccessor<SampleClass, ValueType>.Make("SetValue"));
      accessor.Target = target;

      accessor.Member = 0;
      Assert.AreEqual(0, target.Value);

      accessor.SetMember(1);
      Assert.AreEqual(1, target.Value);

      accessor.Member = 2;
      Assert.AreEqual(2, target.Value);
    }
  }
}

