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

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeThrowsWhenMethodHasArguments()
    {

      bool throwsError = false;

      try
      {

        ReadableMemberAccessor<SampleClass, ValueType>.Make("GetValueWithExtraArguments");
      }
      catch (Exception ex)
      {

        throwsError = true;
        Assert.AreEqual("\"GetValueWithExtraArguments\" must be a public, non-static property, zero-argument method, or field of He4.Reflection.Tests.SampleClass.", ex.Message);
      }

      Assert.IsTrue(throwsError);
    }

    /* Subclass tests */
#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void WorksWithReadablePublicProperty()
    {

      var target = SampleClass.Make();
      var accessor = ReadableMemberAccessor<SampleClass, ValueType>.Make("ValuePropertyGetOnly");
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
    public void WorksWithZeroArgumentMethods()
    {

      var target = SampleClass.Make();
      var accessor = ReadableMemberAccessor<SampleClass, ValueType>.Make("GetValue");
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
    public void WorksWithPublicField()
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

    /* Duplication tests */
#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeDuplicatesTemplatePropertyBinding()
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

#if NUNIT
    [Test]
#else
    [TestMethod]
#endif
    public void MakeDuplicatesTemplateMethodBinding()
    {

      var target = SampleClass.Make();
      var accessor = ReadableMemberAccessor<SampleClass, ValueType>.Make(
          ReadableMemberAccessor<SampleClass, ValueType>.Make("GetValue"));
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
    public void MakeDuplicatesTemplateFieldBinding()
    {

      var target = SampleClass.Make();
      var accessor = ReadableMemberAccessor<SampleClass, ValueType>.Make(
          ReadableMemberAccessor<SampleClass, ValueType>.Make("Value"));
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
