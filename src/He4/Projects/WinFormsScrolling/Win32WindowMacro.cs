using System;
using System.Diagnostics;

namespace He4.Projects.WinFormsScrolling
{

  /// <summary>
  /// C# implementation of window related macros in Windows.h.
  /// </summary>
  ///
  /// <remarks>
  /// For details, refer to
  /// https://msdn.microsoft.com/en-us/library/ff468920.aspx.
  /// </remarks>
  public static class Win32WindowMacro
  {

    /// <summary>
    /// Implements the GET_X_LPARAM macro.
    /// </summary>
    ///
    /// <remarks>
    /// For details, refer to
    /// https://msdn.microsoft.com/en-us/library/ms632654.aspx.
    /// </remarks>
    public static int GetXLParam(IntPtr lParam)
    {

      byte[] source = BitConverter.GetBytes(lParam.ToInt64());
      byte[] intermediate = new byte[2];
      Win32Utilities.CopyLeastSignificantBytes(source, intermediate);
      byte[] final = new byte[4];
      Win32Utilities.CopyLeastSignificantBytes(intermediate, final);

      return BitConverter.ToInt32(final, 0);
    }

    /// <summary>
    /// Implements the GET_Y_LPARAM macro.
    /// </summary>
    ///
    /// <remarks>
    /// For details, refer to
    /// https://msdn.microsoft.com/en-us/library/ms632655.aspx.
    /// </remarks>
    public static int GetYLParam(IntPtr lParam)
    {

      byte[] source = BitConverter.GetBytes(lParam.ToInt64());
      byte[] intermediate = new byte[2];
      Win32Utilities.CopyLeastSignificantBytes(source, intermediate, 2);
      byte[] final = new byte[4];
      Win32Utilities.CopyLeastSignificantBytes(intermediate, final);

      return BitConverter.ToInt32(final, 0);
    }
  }
}
