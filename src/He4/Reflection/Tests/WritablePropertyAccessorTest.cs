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
  public class WritablePropertyAccessorTest
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

        WritablePropertyAccessor<SampleClass, ValueType>.Make("NonExistentMember");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"NonExistentMember\" must be a public, non-static property of He4.Reflection.Tests.SampleClass which is assignable from System.ValueType.", ex.Message);
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

        WritablePropertyAccessor<SampleClass, ValueType>.Make("PrivateValueProperty");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"PrivateValueProperty\" must be a public, non-static property of He4.Reflection.Tests.SampleClass which is assignable from System.ValueType.", ex.Message);
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

        WritablePropertyAccessor<SampleClass, ValueType>.Make("StaticValueProperty");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"StaticValueProperty\" must be a public, non-static property of He4.Reflection.Tests.SampleClass which is assignable from System.ValueType.", ex.Message);
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

        WritablePropertyAccessor<SampleClass, ValueType>.Make("Value");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"Value\" must be a public, non-static property of He4.Reflection.Tests.SampleClass which is assignable from System.ValueType.", ex.Message);
      }

      Assert.IsTrue(throwsError);
    }

    /* Property tests */
#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeThrowsWhenPropertyIsNotAssignable()
    {

      bool throwsError = false;

      try
      {

        WritablePropertyAccessor<SampleClass, object>.Make("ValueProperty");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("He4.Reflection.Tests.SampleClass.ValueProperty must be assignable from System.Object.", ex.Message);
      }

      Assert.IsTrue(throwsError);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeThrowsWhenPropertyDoesNotHavePublicSetAccessor()
    {

      bool throwsError = false;

      try
      {

        WritablePropertyAccessor<SampleClass, ValueType>.Make("ValuePropertyGetOnly");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("He4.Reflection.Tests.SampleClass.ValuePropertyGetOnly must have a public set accessor.", ex.Message);
      }

      Assert.IsTrue(throwsError);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void WorksWithWritablePublicProperty()
    {

      var target = SampleClass.Make();
      var accessor = WritablePropertyAccessor<SampleClass, ValueType>.Make("ValuePropertySetOnly");
      accessor.Target = target;

      accessor.Member = 0;
      Assert.AreEqual(0, target.Value);

      accessor.SetMember(1);
      Assert.AreEqual(1, target.Value);

      accessor.Member = 2;
      Assert.AreEqual(2, target.Value);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void WorksWithContravarianceInProperties()
    {

      var target = SampleClass.Make();
      var accessor = WritablePropertyAccessor<SampleClass, int>.Make("ValueProperty");
      accessor.Target = target;

      accessor.Member = 0;
      Assert.AreEqual(0, target.Value);

      accessor.SetMember(1);
      Assert.AreEqual(1, target.Value);

      accessor.Member = 2;
      Assert.AreEqual(2, target.Value);
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
      var accessor = WritablePropertyAccessor<SampleClass, ValueType>.Make(
          WritablePropertyAccessor<SampleClass, ValueType>.Make("ValueProperty"));
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
