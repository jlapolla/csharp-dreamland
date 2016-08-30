using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace He4.Projects.WinFormsScrolling
{

  /// <summary>
  /// C# implementation of mouse input related macros in Windows.h.
  /// </summary>
  ///
  /// <remarks>
  /// For details, refer to
  /// https://msdn.microsoft.com/en-us/library/ff468876.aspx.
  /// </remarks>
  public static class Win32MouseMacro
  {

    /// <summary>
    /// Virtual key state flags.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// For details, refer to
    /// https://msdn.microsoft.com/en-us/library/ms646251.aspx.
    /// </para>
    ///
    /// <para>
    /// This enumeration has the FlagsAttribute applied to it.
    /// </para>
    /// </remarks>
    [Flags]
    public enum KeyStates : int
    {

      /// <summary>
      /// No flags are set.
      /// </summary>
      MK_NONE     = 0x0000,

      /// <summary>
      /// The SHIFT key is down.
      /// </summary>
      MK_SHIFT    = 0x0004,

      /// <summary>
      /// The CTRL key is down.
      /// </summary>
      MK_CONTROL  = 0x0008,

      /// <summary>
      /// The left mouse button is down.
      /// </summary>
      MK_LBUTTON  = 0x0001,

      /// <summary>
      /// The right mouse button is down.
      /// </summary>
      MK_RBUTTON  = 0x0002,

      /// <summary>
      /// The middle mouse button is down.
      /// </summary>
      MK_MBUTTON  = 0x0010,

      /// <summary>
      /// The first X button is down.
      /// </summary>
      MK_XBUTTON1 = 0x0020,

      /// <summary>
      /// The second X button is down.
      /// </summary>
      MK_XBUTTON2 = 0x0040,
    }

    /// <summary>
    /// Implements the GET_KEYSTATE_WPARAM macro.
    /// </summary>
    ///
    /// <remarks>
    /// For details, refer to
    /// https://msdn.microsoft.com/en-us/library/ms646251.aspx.
    /// </remarks>
    public static KeyStates GetKeyStateWParam(IntPtr wParam)
    {

      byte[] source = BitConverter.GetBytes(wParam.ToInt64());
      byte[] intermediate = new byte[2];
      Win32Utilities.CopyLeastSignificantBytes(source, intermediate);
      byte[] final = new byte[4];
      Win32Utilities.CopyLeastSignificantBytes(intermediate, final);

      return (KeyStates) BitConverter.ToInt32(final, 0);
    }

    /// <summary>
    /// Implements the GET_WHEEL_DELTA_WPARAM macro.
    /// </summary>
    ///
    /// <remarks>
    /// For details, refer to
    /// https://msdn.microsoft.com/en-us/library/ms646254.aspx.
    /// </remarks>
    public static short GetWheelDeltaWParam(IntPtr wParam)
    {

      byte[] source = BitConverter.GetBytes(wParam.ToInt64());
      byte[] final = new byte[2];
      Win32Utilities.CopyLeastSignificantBytes(source, final, 2);

      return BitConverter.ToInt16(final, 0);
    }
  }
}
