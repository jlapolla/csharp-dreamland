using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace He4.Projects.WinFormsScrolling
{

  /// <summary>
  /// Redirects WM_MOUSEWHEEL and WM_MOUSEHWHEEL messages to the window beneath
  /// the cursor.
  /// </summary>
  ///
  /// <remarks>
  /// <para>
  /// Most Windows mouse input messages are sent to the window under the
  /// cursor. The WM_MOUSEWHEEL and WM_MOUSEHWHEEL messages are an exception to
  /// this general rule. Instead of sending WM_MOUSEWHEEL and WM_MOUSEHWHEEL
  /// messages to the window under the cursor, Windows sends these messages to
  /// the active (or focused) window. As a result of this behavior, a window
  /// must be focused in order to scroll it with the mouse wheel. Thic can
  /// cause undesirable behavior in Windows Forms applications that use
  /// scrollable ContainerControl's.
  /// </para>
  ///
  /// <para>
  /// This message filter makes the WM_MOUSEWHEEL and WM_MOUSEHWHEEL messages
  /// behave like the other mouse input messages: it sends the messages to the
  /// window under the cursor regardless of which window is focused. This
  /// causes Windows Forms controls to scroll whenever the cursor is over them,
  /// without having to receive focus first. This affects some controls in
  /// unexpected ways (for example, ComboBox controls will scroll through their
  /// items).
  /// </para>
  ///
  /// <para>
  /// To use this message filter, add it to the Windows Forms application by
  /// calling Application.AddMessageFilter(IMessageFilter). While the message
  /// filter can be added to the Application at any time, we suggest adding the
  /// message filter in your program's Main function before calling
  /// Application.Run(Form).
  /// </para>
  ///
  /// <para>
  /// For a list of controls that scroll, refer to
  /// https://msdn.microsoft.com/en-us/library/ms645601.aspx#Controls_that_Scroll.
  /// </para>
  ///
  /// <para>
  /// Windows 10 Update
  /// </para>
  ///
  /// <para>
  /// Windows 10 sends the WM_MOUSEWHEEL and WM_MOUSEHWHEEL messages to the
  /// window under the cursor if the user has turned on the "Scroll inactive
  /// windows when I hover over them" option in "Mouse and touchpad settings".
  /// This fixes the scrolling problem in most cases, but can cause unexpected
  /// behavior (for example, ComboBox controls will scroll through their
  /// items).
  /// </para>
  /// </remarks>
  public class MouseWheelRedirectFilter : IMessageFilter
  {

    public bool PreFilterMessage(ref Message message)
    {

      return false;
    }
  }

  /// <summary>
  /// Provides access to the functions in User32.dll.
  /// </summary>
  ///
  /// <remarks>
  /// <para>
  /// This class does not include all functions in User32.dll.
  /// </para>
  /// </remarks>
  public static class User32Api
  {
  }

  /// <summary>
  /// C# implementation of mouse input related macros in Windows.h.
  /// </summary>
  ///
  /// <remarks>
  /// For details, refer to
  /// https://msdn.microsoft.com/en-us/library/ff468876.aspx
  /// </remarks>
  public static class Win32MouseMacro
  {

    /// <summary>
    /// Virtual key states.
    /// </summary>
    ///
    /// <remarks>
    /// For details, refer to
    /// https://msdn.microsoft.com/en-us/library/ms646251.aspx
    /// </remarks>
    [Flags]
    public enum KeyStates : int
    {

      MK_NONE     = 0x0000,
      MK_SHIFT    = 0x0004, // The SHIFT key is down.
      MK_CONTROL  = 0x0008, // The CTRL key is down.
      MK_LBUTTON  = 0x0001, // The left mouse button is down.
      MK_RBUTTON  = 0x0002, // The right mouse button is down.
      MK_MBUTTON  = 0x0010, // The middle mouse button is down.
      MK_XBUTTON1 = 0x0020, // The first X button is down.
      MK_XBUTTON2 = 0x0040, // The second X button is down.
    }

    /// <summary>
    /// Implements the GET_KEYSTATE_WPARAM macro.
    /// </summary>
    ///
    /// <remarks>
    /// For details, refer to
    /// https://msdn.microsoft.com/en-us/library/ms646251.aspx
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
    /// https://msdn.microsoft.com/en-us/library/ms646254.aspx
    /// </remarks>
    public static short GetWheelDeltaWParam(IntPtr wParam)
    {

      byte[] source = BitConverter.GetBytes(wParam.ToInt64());
      byte[] final = new byte[2];
      Win32Utilities.CopyLeastSignificantBytes(source, final, 2);

      return BitConverter.ToInt16(final, 0);
    }
  }

  /// <summary>
  /// C# implementation of window related macros in Windows.h.
  /// </summary>
  ///
  /// <remarks>
  /// For details, refer to
  /// https://msdn.microsoft.com/en-us/library/ff468920.aspx
  /// </remarks>
  public static class Win32WindowMacro
  {

    /// <summary>
    /// Implements the GET_X_LPARAM macro.
    /// </summary>
    ///
    /// <remarks>
    /// For details, refer to
    /// https://msdn.microsoft.com/en-us/library/ms632654.aspx
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
    /// https://msdn.microsoft.com/en-us/library/ms632655.aspx
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

  public static class Win32Utilities
  {

    /// <summary>
    /// Copies bytes from source to destination, taking into account the
    /// endianness of the current computer architecture. Designed for use with
    /// System.BitConverter.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// When copying bytes, this function takes into account the endianness of
    /// the current computer architecture. It is designed to be used directly
    /// with the arrays that are output by (and consumed by)
    /// System.BitConverter, without having to use Array.Reverse to account for
    /// endianness.
    /// </para>
    ///
    /// <para>
    /// 'startByte' is the zero-based index of the least significant byte to
    /// copy from 'source'. A 'startByte' of 0 means "Copy bytes from source to
    /// destination, starting with the least significant byte of source." If
    /// the function runs out of bytes in 'source' before it has filled all
    /// indices in 'destination', it fills remaining indicies with 0.
    /// </para>
    ///
    /// <para>
    /// 'startByte' may be negative. A 'startByte' of -2 means "Put 0 in the
    /// first two indices of destination, then copy bytes from source to
    /// destination, starting with the least significant byte of source."
    /// </para>
    /// </remarks>
    public static void CopyLeastSignificantBytes(byte[] source, byte[] destination, int startByte = 0)
    {

      int sourceIndex;

      if (BitConverter.IsLittleEndian)
      {

        sourceIndex = startByte;
      }
      else
      {

        sourceIndex = source.Length - startByte - destination.Length;
      }

      for (int destinationIndex = 0; destinationIndex < destination.Length; destinationIndex++, sourceIndex++)
      {

        byte nextByte;

        if (0 <= sourceIndex && sourceIndex < source.Length)
        {

          nextByte = source[sourceIndex];
        }
        else
        {

          nextByte = 0;
        }

        destination[destinationIndex] = nextByte;
      }
    }
  }

  public interface IMessageTranslator
  {

    bool CanTranslate(Message message);
    EventArgs Translate(Message message);
  }

  /// <remarks>
  ///
  /// <para>
  /// There is no way to send an event directly to a Control from outside the
  /// Control. This is because all of the Control's On[SomeEvent] methods are
  /// protected. Therefore, we cannot use a message filter to translate and
  /// send MouseWheelEventArgs events to any arbitrary control. Instead we have
  /// to subclass the control, and override the WndProc(Message) method.
  /// </para>
  ///
  /// <para>
  /// The MouseWheelMessageTranslator is useful when overriding the
  /// WndProc(Message) method in a Control. Use it to translate the message,
  /// then send it to an overriden OnMouseWeel(MouseEventArgs) method. In the
  /// OnMouseWheel(MouseEventArgs) method, check if the event is a
  /// MouseWheelEventArgs, and respond appropriately. For example, in a
  /// ScrollableControl, you could use the MouseWheelEventArgs to generate a
  /// vertical or horizontal ScrollEventArgs, and then pass that to the
  /// OnScroll(ScrollEventArgs) method.
  /// </para>
  ///
  /// </remarks>
  public class MouseWheelMessageTranslator : IMessageTranslator
  {

    public bool CanTranslate(Message message)
    {

      bool result;

      switch ((Win32MouseMessages)message.Msg)
      {

        case Win32MouseMessages.WM_MOUSEWHEEL:
          result = true;
          break;

        case Win32MouseMessages.WM_MOUSEHWHEEL:
          result = true;
          break;

        default:
          result = false;
          break;
      }

      return result;
    }

    public MouseWheelEventArgs Translate(Message message)
    {

      MouseWheelEventArgs result = null;

      if (CanTranslate(message))
      {
      }

      return result;
    }

    EventArgs IMessageTranslator.Translate(Message message)
    {

      return Translate(message);
    }
  }

  /// <summary>
  /// Windows mouse input messages.
  /// </summary>
  ///
  /// <remarks>
  /// <para>
  /// This enumeration only includes mouse input messages. For details on
  /// each message, refer to
  /// https://msdn.microsoft.com/en-us/library/ff468877.aspx.
  /// </para>
  ///
  /// <para>
  /// For a full list of Windows message types, refer to
  /// https://msdn.microsoft.com/en-us/library/ms644927.aspx (see the table
  /// of system defined messages in the Message Types section).
  /// </para>
  /// </remarks>
  public enum Win32MouseMessages
  {

    // Mouse wheel messages
    WM_MOUSEWHEEL      = 0x020A, // Sent to the focus window when the mouse wheel is rotated.
    WM_MOUSEHWHEEL     = 0x020E, // Sent to the active window when the mouse's horizontal scroll wheel is tilted or rotated.

    // Client area mouse messages
    WM_MOUSEMOVE       = 0x0200, // Posted to a window when the cursor moves.
    WM_MOUSEHOVER      = 0x02A1, // Posted to a window when the cursor hovers.
    WM_MOUSELEAVE      = 0x02A3, // Posted to a window when the cursor leaves.
    WM_LBUTTONDOWN     = 0x0201, // Posted when the user presses the left mouse button.
    WM_RBUTTONDOWN     = 0x0204, // Posted when the user presses the right mouse button.
    WM_MBUTTONDOWN     = 0x0207, // Posted when the user presses the middle mouse button.
    WM_XBUTTONDOWN     = 0x020B, // Posted when the user presses the first or second X button.
    WM_LBUTTONUP       = 0x0202, // Posted when the user releases the left mouse button.
    WM_RBUTTONUP       = 0x0205, // Posted when the user releases the right mouse button.
    WM_MBUTTONUP       = 0x0208, // Posted when the user releases the middle mouse button.
    WM_XBUTTONUP       = 0x020C, // Posted when the user releases the first or second X button.
    WM_LBUTTONDBLCLK   = 0x0203, // Posted when the user double-clicks the left mouse button.
    WM_RBUTTONDBLCLK   = 0x0206, // Posted when the user double-clicks the right mouse button.
    WM_MBUTTONDBLCLK   = 0x0209, // Posted when the user double-clicks the middle mouse button.
    WM_XBUTTONDBLCLK   = 0x020D, // Posted when the user double-clicks the first or second X button.

    // Nonclient area mouse messages
    WM_NCMOUSEMOVE     = 0x00A0, // Posted to a window when the cursor is moved within the nonclient area of the window.
    WM_NCMOUSEHOVER    = 0x02A0, // Posted to a window when the cursor hovers over the nonclient area of the window.
    WM_NCMOUSELEAVE    = 0x02A2, // Posted to a window when the cursor leaves the nonclient area of the window.
    WM_NCLBUTTONDOWN   = 0x00A1, // Posted when the user presses the left mouse button while the cursor is within the nonclient area of a window.
    WM_NCRBUTTONDOWN   = 0x00A4, // Posted when the user presses the right mouse button while the cursor is within the nonclient area of a window.
    WM_NCMBUTTONDOWN   = 0x00A7, // Posted when the user presses the middle mouse button while the cursor is within the nonclient area of a window.
    WM_NCXBUTTONDOWN   = 0x00AB, // Posted when the user presses the first or second X button while the cursor is in the nonclient area of a window.
    WM_NCLBUTTONUP     = 0x00A2, // Posted when the user releases the left mouse button while the cursor is within the nonclient area of a window.
    WM_NCRBUTTONUP     = 0x00A5, // Posted when the user releases the right mouse button while the cursor is within the nonclient area of a window.
    WM_NCMBUTTONUP     = 0x00A8, // Posted when the user releases the middle mouse button while the cursor is within the nonclient area of a window.
    WM_NCXBUTTONUP     = 0x00AC, // Posted when the user releases the first or second X button while the cursor is in the nonclient area of a window.
    WM_NCLBUTTONDBLCLK = 0x00A3, // Posted when the user double-clicks the left mouse button while the cursor is within the nonclient area of a window.
    WM_NCRBUTTONDBLCLK = 0x00A6, // Posted when the user double-clicks the right mouse button while the cursor is within the nonclient area of a window.
    WM_NCMBUTTONDBLCLK = 0x00A9, // Posted when the user double-clicks the middle mouse button while the cursor is within the nonclient area of a window.
    WM_NCXBUTTONDBLCLK = 0x00AD, // Posted when the user double-clicks the first or second X button while the cursor is in the nonclient area of a window.

    // Miscellaneous mouse messages
    WM_NCHITTEST       = 0x0084, // Sent to a window in order to determine what part of the window corresponds to a particular screen coordinate.
    WM_MOUSEACTIVATE   = 0x0021, // Sent when the cursor is in an inactive window and the user presses a mouse button.
    WM_CAPTURECHANGED  = 0x0215, // Sent to the window that is losing the mouse capture.
  }

  public enum MouseWheelOrientations
  {
    Vertical,
    Horizontal
  }

  public class MouseWheelEventArgs : MouseEventArgs
  {

    private readonly MouseWheelOrientations _WheelOrientation;
    public MouseWheelOrientations WheelOrientation
    {

      get
      {

        return _WheelOrientation;
      }
    }

    public MouseWheelEventArgs(MouseButtons button, int clicks, int x, int y, int delta, MouseWheelOrientations wheelOrientation)
      : base(button, clicks, x, y, delta)
    {

      _WheelOrientation = wheelOrientation;
    }
  }
}
