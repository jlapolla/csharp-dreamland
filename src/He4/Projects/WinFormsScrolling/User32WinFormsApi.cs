using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace He4.Projects.WinFormsScrolling
{

  /// <summary>
  /// Wraps functions in User32Api for use with System.Windows.Forms.
  /// </summary>
  public static class User32WinFormsApi
  {

    public static void SendMessage(ref Message message)
    {

      IntPtr hWnd = message.HWnd;
      uint msg = unchecked((uint) message.Msg);

      Control control = Control.FromChildHandle(hWnd);
      if (control == null)
      {

        message.Result = User32Api.SendMessage(hWnd, msg, message.WParam, message.LParam);
      }
      else
      {

        HandleRef hRef = new HandleRef(control, hWnd);
        message.Result = User32Api.SendMessage(hRef, msg, message.WParam, message.LParam);
      }
    }
  }
}
