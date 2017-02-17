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
  public class WritableMemberAccessorTest
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

        WritableMemberAccessor<SampleClass, ValueType>.Make("NonExistentMember");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"NonExistentMember\" must be a public, non-static property, one-argument method, or field of He4.Reflection.Tests.SampleClass which is assignable from System.ValueType.", ex.Message);
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

        WritableMemberAccessor<SampleClass, ValueType>.Make("PrivateValue");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"PrivateValue\" must be a public, non-static property, one-argument method, or field of He4.Reflection.Tests.SampleClass which is assignable from System.ValueType.", ex.Message);
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

        WritableMemberAccessor<SampleClass, ValueType>.Make("StaticValue");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"StaticValue\" must be a public, non-static property, one-argument method, or field of He4.Reflection.Tests.SampleClass which is assignable from System.ValueType.", ex.Message);
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

        WritableMemberAccessor<SampleClass, string>.Make("ValueProperty");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("He4.Reflection.Tests.SampleClass.ValueProperty must be assignable from System.String.", ex.Message);
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

        WritableMemberAccessor<SampleClass, ValueType>.Make("ValuePropertyGetOnly");
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
    public void WorksWithReadablePublicProperty()
    {

      var target = SampleClass.Make();
      var accessor = WritableMemberAccessor<SampleClass, ValueType>.Make("ValuePropertySetOnly");
      accessor.Target = target;

      accessor.Member = 0;
      Assert.AreEqual(0, target.Value);

      accessor.Set(1);
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
      var accessor = WritableMemberAccessor<SampleClass, int>.Make("ValueProperty");
      accessor.Target = target;

      accessor.Member = 0;
      Assert.AreEqual(0, target.Value);

      accessor.Set(1);
      Assert.AreEqual(1, target.Value);

      accessor.Member = 2;
      Assert.AreEqual(2, target.Value);
    }

    /* Method tests */
#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeThrowsWhenMethodArgumentTypeIsNotAssignable()
    {

      bool throwsError = false;

      try
      {

        WritableMemberAccessor<SampleClass, string>.Make("SetValue");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"SetValue\" must be a public, non-static property, one-argument method, or field of He4.Reflection.Tests.SampleClass which is assignable from System.String.", ex.Message);
      }

      Assert.IsTrue(throwsError);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeThrowsWhenMethodHasExtraArguments()
    {

      bool throwsError = false;

      try
      {

        WritableMemberAccessor<SampleClass, ValueType>.Make("SetValueWithExtraArguments");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"SetValueWithExtraArguments\" must be a public, non-static property, one-argument method, or field of He4.Reflection.Tests.SampleClass which is assignable from System.ValueType.", ex.Message);
      }

      Assert.IsTrue(throwsError);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void WorksWithOneArgumentMethods()
    {

      var target = SampleClass.Make();
      var accessor = WritableMemberAccessor<SampleClass, ValueType>.Make("SetValue");
      accessor.Target = target;

      accessor.Member = 0;
      Assert.AreEqual(0, target.Value);

      accessor.Set(1);
      Assert.AreEqual(1, target.Value);

      accessor.Member = 2;
      Assert.AreEqual(2, target.Value);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void WorksWithContravarianceInMethods()
    {

      var target = SampleClass.Make();
      var accessor = WritableMemberAccessor<SampleClass, int>.Make("SetValue");
      accessor.Target = target;

      accessor.Member = 0;
      Assert.AreEqual(0, target.Value);

      accessor.Set(1);
      Assert.AreEqual(1, target.Value);

      accessor.Member = 2;
      Assert.AreEqual(2, target.Value);
    }

    /* Field tests */
#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeThrowsWhenFieldIsNotAssignable()
    {

      bool throwsError = false;

      try
      {

        WritableMemberAccessor<SampleClass, string>.Make("Value");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("He4.Reflection.Tests.SampleClass.Value must be assignable from System.String.", ex.Message);
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
      var accessor = WritableMemberAccessor<SampleClass, ValueType>.Make("Value");
      accessor.Target = target;

      accessor.Member = 0;
      Assert.AreEqual(0, target.Value);

      accessor.Set(1);
      Assert.AreEqual(1, target.Value);

      accessor.Member = 2;
      Assert.AreEqual(2, target.Value);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void WorksWithContravarianceInFields()
    {

      var target = SampleClass.Make();
      var accessor = WritableMemberAccessor<SampleClass, int>.Make("Value");
      accessor.Target = target;

      accessor.Member = 0;
      Assert.AreEqual(0, target.Value);

      accessor.Set(1);
      Assert.AreEqual(1, target.Value);

      accessor.Member = 2;
      Assert.AreEqual(2, target.Value);
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
      var accessor = WritableMemberAccessor<SampleClass, ValueType>.Make(
          WritableMemberAccessor<SampleClass, ValueType>.Make("ValueProperty"));
      accessor.Target = target;

      accessor.Member = 0;
      Assert.AreEqual(0, target.Value);

      accessor.Set(1);
      Assert.AreEqual(1, target.Value);

      accessor.Member = 2;
      Assert.AreEqual(2, target.Value);
    }
  }
}
