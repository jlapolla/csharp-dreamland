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
    /// Synchronously sends the specified message to an unmanaged window or
    /// windows.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Do not use this function when hWnd is a handle owned by a managed
    /// object. Instead, use the SendMessage(HandleRef, uint, IntPtr, IntPtr)
    /// overload. For discussion, see the Remarks section at
    /// https://msdn.microsoft.com/en-us/library/system.runtime.interopservices.handleref.aspx.
    /// </para>
    ///
    /// <para>
    /// For details, refer to
    /// https://msdn.microsoft.com/en-us/library/ms644950.aspx.
    /// </para>
    /// </remarks>
    [DllImport("User32.dll", CharSet = CharSet.Auto, ThrowOnUnmappableChar = true)]
    public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Synchronously sends the specified message to a managed window or
    /// windows.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// To send a message to an unmanaged window, use the SendMessage(IntPtr,
    /// uint, IntPtr, IntPtr) overload.
    /// </para>
    ///
    /// <para>
    /// For details, refer to
    /// https://msdn.microsoft.com/en-us/library/ms644950.aspx.
    /// </para>
    /// </remarks>
    [DllImport("User32.dll", CharSet = CharSet.Auto, ThrowOnUnmappableChar = true)]
    public static extern IntPtr SendMessage(HandleRef hWnd, uint msg, IntPtr wParam, IntPtr lParam);

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
    [DllImport("User32.dll", CharSet = CharSet.Auto, ThrowOnUnmappableChar = true)]
    public static extern IntPtr WindowFromPoint(System.Drawing.Point point);
  }
}
