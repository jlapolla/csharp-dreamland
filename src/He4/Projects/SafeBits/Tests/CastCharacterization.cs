using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace He4.Projects.SafeBits.Tests
{

  [TestClass]
  public class CastCharacterization
  {

    /// <remarks>
    /// </para>
    /// Build fails with CS0266 Cannot Implicitly convert type 'int' to
    /// 'short'. An explicit conversion exists (are you missing a cast?)
    /// </para>
    ///
    /// </para>
    /// Notice that the build fails even though the numeric value of the Int32
    /// is within the range of Int16. The compiler only allows implicit
    /// truncating casts when the source of the cast is a constant that is
    /// known at compile time, and the constant is within the numeric range of
    /// the destination of the cast.
    /// </para>
    /// </remarks>
    [TestMethod]
    public void ImplicitTruncateCast_DoesNotCompile()
    {

      // Int32 a = 0;
      // Int16 b = a; // Build fails here
    }
  }
}
