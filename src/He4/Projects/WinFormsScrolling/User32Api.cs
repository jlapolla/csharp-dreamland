using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace He4.Projects.WinFormsScrolling
{

  /// <summary>
  /// Provides access to the functions in User32.dll.
  /// </summary>
  ///
  /// <remarks>
  /// For method signatures, refer to http://www.pinvoke.net/.
  /// </remarks>
  public static class User32Api
  {

    /// <summary>
    /// Synchronously sends the specified message to a window or windows.
    /// </summary>
    ///
    /// <remarks>
    /// For details, refer to
    /// https://msdn.microsoft.com/en-us/library/ms644950.aspx.
    /// </remarks>
    [DllImport("User32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto, ThrowOnUnmappableChar = true)]
    public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Retrieves a handle to the window that contains the specified point.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Returns IntPtr.Zero if no window exists at the given point, or if the
    /// point is within a hidden or disabled window.
    /// </para>
    ///
    /// <para>
    /// The point is given in screen coordinates.
    /// </para>
    ///
    /// <para>
    /// For details, refer to
    /// https://msdn.microsoft.com/en-us/library/ms633558.aspx.
    /// </para>
    /// </remarks>
    [DllImport("User32.dll", EntryPoint = "WindowFromPoint", CharSet = CharSet.Auto, ThrowOnUnmappableChar = true)]
    public static extern IntPtr WindowFromPoint(System.Drawing.Point point);
  }
}
