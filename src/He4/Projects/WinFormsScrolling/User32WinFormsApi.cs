using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace He4.Projects.WinFormsScrolling
{

  /// <summary>
  /// Provides access to User32Api for Windows Forms applications.
  /// </summary>
  ///
  /// <remarks>
  /// Use this class to access functions in User32Api from a Windows Forms
  /// application. Direct use of User32Api is discouraged.
  /// </remarks>
  public static class User32WinFormsApi
  {

    /// <summary>
    /// Synchronously sends the specified message to a window or windows.
    /// </summary>
    ///
    /// <remarks>
    /// See also: User32Api.SendMessage(IntPtr, uint, IntPtr, IntPtr).
    /// </remarks>
    public static void SendMessage(ref Message message)
    {

      uint msg = unchecked((uint) message.Msg);

      Control control = Control.FromChildHandle(message.HWnd);
      if (control == null)
      {

        message.Result = User32Api.SendMessage(message.HWnd, msg, message.WParam, message.LParam);
      }
      else
      {

        HandleRef hRef = new HandleRef(control, message.HWnd);
        message.Result = User32Api.SendMessage(hRef, msg, message.WParam, message.LParam);
      }
    }

    /// <summary>
    /// Retrieves the control that contains the specified point.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Returns null if no control exists at the given point, or if the point
    /// is within a hidden or disabled control.
    /// </para>
    ///
    /// <para>
    /// </para>
    ///
    /// <para>
    /// The point is given in screen coordinates.
    /// </para>
    ///
    /// <para>
    /// See also: User32Api.WindowFromPoint(Point).
    /// </para>
    /// </remarks>
    public static Control ControlFromPoint(System.Drawing.Point point)
    {

      return Control.FromChildHandle(User32Api.WindowFromPoint(point));
    }
  }
}
