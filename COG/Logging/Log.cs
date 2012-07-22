
using System.Windows.Forms;

namespace Clockwork.Logging {
  /// <summary>
  /// Allows agents to log current actions. This is used by the application to
  /// determine what each agent is current doing. Each action should be logged
  /// that will change the state of the environment is some manner.
  /// </summary>
  public class Log {
    delegate void WriteCallBack(LogItem aLogItem);
    delegate void ClearCallBack();

    private RichTextBox logItems;

    public Log(ref RichTextBox log) {
      logItems = log;
    }

    public void Clear() {
      if (logItems != null) {
        if (logItems.InvokeRequired) {
          ClearCallBack d = new ClearCallBack(Clear);
          logItems.Invoke(d, new object[] { });
        } else {
          logItems.Clear();
        }
      }
    }

    public void Write(LogItem aLogItem) {
      if (aLogItem != null) {
        if (logItems.InvokeRequired) {
          WriteCallBack d = new WriteCallBack(Write);
          logItems.Invoke(d, new object[] { aLogItem });
        } else {
          logItems.SelectionColor = aLogItem.Status;
          logItems.AppendText(aLogItem.Message);
        }
      }
    }
  }
}
