using System;

namespace He4.Projects.WinFormsScrolling
{

  /// <summary>
  /// Windows system defined messages.
  /// </summary>
  ///
  /// <remarks>
  /// <para>
  /// For details, refer to
  /// https://msdn.microsoft.com/en-us/library/ms644927.aspx#system_defined.
  /// </para>
  /// </remarks>
  public enum Win32Messages
  {

    // Mouse input notifications
    //
    // For details, refer to
    // https://msdn.microsoft.com/en-us/library/ff468877.aspx.

    // Mouse wheel messages

    /// <summary>
    /// Sent to the focus window when the mouse wheel is rotated.
    /// </summary>
    WM_MOUSEWHEEL      = 0x020A,

    /// <summary>
    /// Sent to the active window when the mouse's horizontal scroll wheel is
    /// tilted or rotated.
    /// </summary>
    WM_MOUSEHWHEEL     = 0x020E,

    // Client area mouse messages

    /// <summary>
    /// Posted to a window when the cursor moves.
    /// </summary>
    WM_MOUSEMOVE       = 0x0200,

    /// <summary>
    /// Posted to a window when the cursor hovers.
    /// </summary>
    WM_MOUSEHOVER      = 0x02A1,

    /// <summary>
    /// Posted to a window when the cursor leaves.
    /// </summary>
    WM_MOUSELEAVE      = 0x02A3,

    /// <summary>
    /// Posted when the user presses the left mouse button.
    /// </summary>
    WM_LBUTTONDOWN     = 0x0201,

    /// <summary>
    /// Posted when the user presses the right mouse button.
    /// </summary>
    WM_RBUTTONDOWN     = 0x0204,

    /// <summary>
    /// Posted when the user presses the middle mouse button.
    /// </summary>
    WM_MBUTTONDOWN     = 0x0207,

    /// <summary>
    /// Posted when the user presses the first or second X button.
    /// </summary>
    WM_XBUTTONDOWN     = 0x020B,

    /// <summary>
    /// Posted when the user releases the left mouse button.
    /// </summary>
    WM_LBUTTONUP       = 0x0202,

    /// <summary>
    /// Posted when the user releases the right mouse button.
    /// </summary>
    WM_RBUTTONUP       = 0x0205,

    /// <summary>
    /// Posted when the user releases the middle mouse button.
    /// </summary>
    WM_MBUTTONUP       = 0x0208,

    /// <summary>
    /// Posted when the user releases the first or second X button.
    /// </summary>
    WM_XBUTTONUP       = 0x020C,

    /// <summary>
    /// Posted when the user double-clicks the left mouse button.
    /// </summary>
    WM_LBUTTONDBLCLK   = 0x0203,

    /// <summary>
    /// Posted when the user double-clicks the right mouse button.
    /// </summary>
    WM_RBUTTONDBLCLK   = 0x0206,

    /// <summary>
    /// Posted when the user double-clicks the middle mouse button.
    /// </summary>
    WM_MBUTTONDBLCLK   = 0x0209,

    /// <summary>
    /// Posted when the user double-clicks the first or second X button.
    /// </summary>
    WM_XBUTTONDBLCLK   = 0x020D,

    // Nonclient area mouse messages

    /// <summary>
    /// Posted to a window when the cursor is moved within the nonclient area
    /// of the window.
    /// </summary>
    WM_NCMOUSEMOVE     = 0x00A0,

    /// <summary>
    /// Posted to a window when the cursor hovers over the nonclient area of
    /// the window.
    /// </summary>
    WM_NCMOUSEHOVER    = 0x02A0,

    /// <summary>
    /// Posted to a window when the cursor leaves the nonclient area of the
    /// window.
    /// </summary>
    WM_NCMOUSELEAVE    = 0x02A2,

    /// <summary>
    /// Posted when the user presses the left mouse button while the cursor is
    /// within the nonclient area of a window.
    /// </summary>
    WM_NCLBUTTONDOWN   = 0x00A1,

    /// <summary>
    /// Posted when the user presses the right mouse button while the cursor is
    /// within the nonclient area of a window.
    /// </summary>
    WM_NCRBUTTONDOWN   = 0x00A4,

    /// <summary>
    /// Posted when the user presses the middle mouse button while the cursor
    /// is within the nonclient area of a window.
    /// </summary>
    WM_NCMBUTTONDOWN   = 0x00A7,

    /// <summary>
    /// Posted when the user presses the first or second X button while the
    /// cursor is in the nonclient area of a window.
    /// </summary>
    WM_NCXBUTTONDOWN   = 0x00AB,

    /// <summary>
    /// Posted when the user releases the left mouse button while the cursor is
    /// within the nonclient area of a window.
    /// </summary>
    WM_NCLBUTTONUP     = 0x00A2,

    /// <summary>
    /// Posted when the user releases the right mouse button while the cursor
    /// is within the nonclient area of a window.
    /// </summary>
    WM_NCRBUTTONUP     = 0x00A5,

    /// <summary>
    /// Posted when the user releases the middle mouse button while the cursor
    /// is within the nonclient area of a window.
    /// </summary>
    WM_NCMBUTTONUP     = 0x00A8,

    /// <summary>
    /// Posted when the user releases the first or second X button while the
    /// cursor is in the nonclient area of a window.
    /// </summary>
    WM_NCXBUTTONUP     = 0x00AC,

    /// <summary>
    /// Posted when the user double-clicks the left mouse button while the
    /// cursor is within the nonclient area of a window.
    /// </summary>
    WM_NCLBUTTONDBLCLK = 0x00A3,

    /// <summary>
    /// Posted when the user double-clicks the right mouse button while the
    /// cursor is within the nonclient area of a window.
    /// </summary>
    WM_NCRBUTTONDBLCLK = 0x00A6,

    /// <summary>
    /// Posted when the user double-clicks the middle mouse button while the
    /// cursor is within the nonclient area of a window.
    /// </summary>
    WM_NCMBUTTONDBLCLK = 0x00A9,

    /// <summary>
    /// Posted when the user double-clicks the first or second X button while
    /// the cursor is in the nonclient area of a window.
    /// </summary>
    WM_NCXBUTTONDBLCLK = 0x00AD,

    // Miscellaneous mouse messages

    /// <summary>
    /// Sent to a window in order to determine what part of the window
    /// corresponds to a particular screen coordinate.
    /// </summary>
    WM_NCHITTEST       = 0x0084,

    /// <summary>
    /// Sent when the cursor is in an inactive window and the user presses a
    /// mouse button.
    /// </summary>
    WM_MOUSEACTIVATE   = 0x0021,

    /// <summary>
    /// Sent to the window that is losing the mouse capture.
    /// </summary>
    WM_CAPTURECHANGED  = 0x0215,
  }
}
