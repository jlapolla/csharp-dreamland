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
  public class WritableFieldAccessorTest
  {

    /* String tests */
#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeThrowsWhenFieldDoesNotExist()
    {

      bool throwsError = false;

      try
      {

        WritableFieldAccessor<SampleClass, ValueType>.Make("NonExistentMember");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"NonExistentMember\" must be a public, non-static field of He4.Reflection.Tests.SampleClass which is assignable from System.ValueType.", ex.Message);
      }

      Assert.IsTrue(throwsError);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeThrowsWhenFieldIsNotPublic()
    {

      bool throwsError = false;

      try
      {

        WritableFieldAccessor<SampleClass, ValueType>.Make("PrivateValue");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"PrivateValue\" must be a public, non-static field of He4.Reflection.Tests.SampleClass which is assignable from System.ValueType.", ex.Message);
      }

      Assert.IsTrue(throwsError);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeThrowsWhenFieldIsStatic()
    {

      bool throwsError = false;

      try
      {

        WritableFieldAccessor<SampleClass, ValueType>.Make("StaticValue");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"StaticValue\" must be a public, non-static field of He4.Reflection.Tests.SampleClass which is assignable from System.ValueType.", ex.Message);
      }

      Assert.IsTrue(throwsError);
    }

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeThrowsWhenMemberIsNotAField()
    {

      bool throwsError = false;

      try
      {

        WritableFieldAccessor<SampleClass, ValueType>.Make("ValueProperty");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"ValueProperty\" must be a public, non-static field of He4.Reflection.Tests.SampleClass which is assignable from System.ValueType.", ex.Message);
      }

      Assert.IsTrue(throwsError);
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

        WritableFieldAccessor<SampleClass, object>.Make("Value");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("He4.Reflection.Tests.SampleClass.Value must be assignable from System.Object.", ex.Message);
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
      var accessor = WritableFieldAccessor<SampleClass, ValueType>.Make("Value");
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
    public void WorksWithContravarianceInFields()
    {

      var target = SampleClass.Make();
      var accessor = WritableFieldAccessor<SampleClass, int>.Make("Value");
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
      var accessor = WritableFieldAccessor<SampleClass, ValueType>.Make(
          WritableFieldAccessor<SampleClass, ValueType>.Make("Value"));
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

