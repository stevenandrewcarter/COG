using System.Windows.Forms;
using Clockwork.Execution.Tasks;

namespace Clockwork.Execution {
  public class ExecutionNode : TreeNode {
    private delegate void ViewCallBack();
    private delegate void UpdateCallBack(string label);
    private delegate void AddCallBack(ExecutionNode aNode);
    private delegate void RemoveCallBack();
    private delegate void RemoveTaskCallBack(Task t);

    private ExecutionNode parent;
    private Task task;

    #region Constructor

    public ExecutionNode(Task nodeTask) {
      parent = null;
      task = nodeTask;
      // Register with the task event
      Load();
      if (task != null)
        task.TaskChange += new Task.Changed(task_TaskChange);
    }

    void task_TaskChange() {
      Load();
    }

    #endregion

    #region Properties

    public Task Task { get { return task; } }

    public new ExecutionNode Parent { get { return parent; } set { parent = value; } }

    #endregion

    #region Methods

    #region Private Methods

    private void Load() {
      if (TreeView != null && TreeView.InvokeRequired) {
        ViewCallBack d = new ViewCallBack(Load);
        TreeView.Invoke(d, new object[] { });
      } else {
        if (!task.Status && task.Agent == null) {
          ImageIndex = 3;
          SelectedImageIndex = 3;
        } else if (!task.Status && task.Agent != null) {
          ImageIndex = 2;
          SelectedImageIndex = 2;
        } else if (task.Status && task.Agent != null) {
          ImageIndex = 1;
          SelectedImageIndex = 1;
        }
        Text = task.ToString();
        ToolTipText = "Task: " + task.ToString() + "\n";
      }
    }


    #endregion

    public void SetLabel(string label) {
      if (TreeView != null && TreeView.InvokeRequired) {
        UpdateCallBack d = new UpdateCallBack(SetLabel);
        TreeView.Invoke(d, new object[] { label });
      } else {
        Text = label;
      }
    }

    public void Reset() {
      foreach (ExecutionNode child in Nodes) {
        child.Reset();
      }
      // task.Reset();
    }

    public void Add(Task owner, Task child) {
      if (task.Equals(owner)) {
        ExecutionNode n = new ExecutionNode(child);
        Add(n);
      } else {
        foreach (ExecutionNode c in Nodes)
          c.Add(owner, child);
      }
    }

    public void Add(ExecutionNode aNode) {
      if (TreeView != null && TreeView.InvokeRequired) {
        AddCallBack d = new AddCallBack(Add);
        TreeView.Invoke(d, new object[] { aNode });
      } else {
        Nodes.Add(aNode);
        aNode.Parent = this;
      }
    }

    public void Remove(Task t) {
      if (TreeView != null && TreeView.InvokeRequired) {
        RemoveTaskCallBack d = new RemoveTaskCallBack(Remove);
        TreeView.Invoke(d, new object[] { t });
      } else {
        foreach (ExecutionNode child in Nodes) {
          if (child.Task == t)
            child.Remove();
          else
            child.Remove(t);
        }
      }
    }

    public new void Remove() {
      if (TreeView != null && TreeView.InvokeRequired) {
        RemoveCallBack d = new RemoveCallBack(Remove);
        TreeView.Invoke(d, new object[] { });
      } else {
        foreach (ExecutionNode child in Nodes) {
          child.Remove();
        }
        Nodes.Remove(this);
        parent = null;
      }
    }

    #endregion
  }
}
