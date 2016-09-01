using System;
using System.Diagnostics;
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

  public interface IMessageFilterElement
  {

    /// <remarks>
    /// Calling this function must not produce side effects. For example,
    /// calling this function must not cause a message to be sent to a window.
    /// The sole purpose of this function is to observe the message that is
    /// passed in, and return a (possibly modified) message.
    /// </remarks>
    Nullable<Message> DoFilter(Nullable<Message> message);

    /// <summary>
    /// The next IMessageFilterElement in the filter chain.
    /// </summary>
    ///
    /// <remarks>
    /// Implementations of DoFilter(Message?) may call Next.DoFilter(Message?)
    /// to pass a message onto the next filter in the filter chain.
    /// </remarks>
    IMessageFilterElement Next { get; set; }
  }

  public class MessageFilterAdapter : EmptyMessageFilterElement, IMessageFilter
  {

    /// <summary>
    /// Filters the message using its Next IMessageFilterElement. Handles the
    /// filtered message if it differs from the original message.
    /// </summary>
    ///
    /// <remarks>
    /// If the filtering process returns the original message, the original
    /// message is dispatched as normal. If the filtering process returns a new
    /// message, the new message is sent, and the original message is not
    /// dispatched. If the filtering process returns null, no message is sent
    /// or dispatched.
    /// </remarks>
    public bool PreFilterMessage(ref Message message)
    {

      bool result = false;

      Nullable<Message> filteredMessage = DoFilter(message);
      if (filteredMessage.HasValue)
      {

        Message unboxedMessage = filteredMessage.Value;
        if (message != unboxedMessage)
        {

          User32WinFormsApi.SendMessage(ref unboxedMessage);
          result = true;
        }
      }
      else
      {

        // Stop message from being dispatched
        result = true;
      }

      return result;
    }
  }

  /// <summary>
  /// Default implementation of IMessageFilterElement.
  /// </summary>
  ///
  /// <remarks>
  /// Other implementations of IMessageFilterElement are encouraged to inherit
  /// from this class. Derived classes should override Dofilter(Message?),
  /// calling DoNextFilter(Message?) to run the next IMessageFilterElement.
  /// </remarks>
  public class EmptyMessageFilterElement : IMessageFilterElement
  {

    public virtual Nullable<Message> DoFilter(Nullable<Message> message)
    {

      return DoNextFilter(message);
    }

    public IMessageFilterElement Next { get; set; }

    protected Nullable<Message> DoNextFilter(Nullable<Message> message)
    {

      Nullable<Message> result = message;

      if (Next != null)
      {

        result = Next.DoFilter(message);
      }

      return result;
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

      switch ((Win32Messages)message.Msg)
      {

        case Win32Messages.WM_MOUSEWHEEL:
        case Win32Messages.WM_MOUSEHWHEEL:
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
