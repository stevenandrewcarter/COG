using System;
using System.Drawing;

namespace Clockwork.Logging {
  /// <summary>
  /// Forms the items kept in the message log.
  /// </summary>
  public class LogItem {
    private string message;                 // Message in this log item
    private DateTime stampTime;             // Date/Time value when log item was created
    private Color itemColor;                // Colour of this log item

    public LogItem(string aMessage, Color status) {
      itemColor = status;
      message = aMessage;
      stampTime = DateTime.Now;
    }

    #region Properties

    public string Message {
      get {
        return "<" + stampTime.ToString("hh:mm:ss") + ">  " + message + "\n";
      }
    }

    public Color Status {
      get {
        return itemColor;
      }
    }

    #endregion
  }
}
