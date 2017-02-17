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
    public void MakeThrowsWhenMethodArgumenTypeDoesNotConform()
    {

      bool throwsError = false;

      try
      {

        WritableMemberAccessor<SampleClass, object>.Make("SetValue");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"SetValue\" must be a public, non-static property, one-argument method, or field of He4.Reflection.Tests.SampleClass which is assignable from System.Object.", ex.Message);
      }

      Assert.IsTrue(throwsError);
    }

    /* Subclass tests */
#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void WorksWithWritablePublicProperty()
    {

      var target = SampleClass.Make();
      var accessor = WritableMemberAccessor<SampleClass, ValueType>.Make("ValuePropertySetOnly");
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
    public void WorksWithOneArgumentMethods()
    {

      var target = SampleClass.Make();
      var accessor = WritableMemberAccessor<SampleClass, ValueType>.Make("SetValue");
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
    public void WorksWithFields()
    {

      var target = SampleClass.Make();
      var accessor = WritableMemberAccessor<SampleClass, ValueType>.Make("Value");
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
    public void MakeDuplicatesTemplatePropertyBinding()
    {

      var target = SampleClass.Make();
      var accessor = WritableMemberAccessor<SampleClass, ValueType>.Make(
          WritableMemberAccessor<SampleClass, ValueType>.Make("ValueProperty"));
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
    public void MakeDuplicatesTemplateMethodBinding()
    {

      var target = SampleClass.Make();
      var accessor = WritableMemberAccessor<SampleClass, ValueType>.Make(
          WritableMemberAccessor<SampleClass, ValueType>.Make("SetValue"));
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
    public void MakeDuplicatesTemplateFieldBinding()
    {

      var target = SampleClass.Make();
      var accessor = WritableMemberAccessor<SampleClass, ValueType>.Make(
          WritableMemberAccessor<SampleClass, ValueType>.Make("Value"));
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
