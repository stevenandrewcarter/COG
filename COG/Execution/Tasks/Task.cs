using System.Collections.Generic;
using System.Windows.Forms;
using Clockwork.Agents;

namespace Clockwork.Execution.Tasks {
  /// <summary>
  /// A COG_Task is a set of coordinated actions that a group of agents is required
  /// in order to complete. Created as a factory so that any agent that utilises
  /// this factory does not need to understand the exact details of each task.
  /// </summary>
  public abstract class Task : TreeNode {
    // Events
    public delegate void Changed();
    public event Changed TaskChange;

    // Local variables
    protected bool status;
    protected Agent agent;

    // A list of the agents which are able to perform the given task to allow the controller to help assign to a coordination group.
    protected List<TaskComparer> agents;

    #region Properties

    public List<TaskComparer> RegisteredAgents { get { return agents; } }

    /// <summary>
    /// Indicates if this task has been completed or not.
    /// </summary>
    public bool Status {
      get { return status; }
      set {
        status = value;
        if (TaskChange != null) TaskChange();
      }
    }

    public Agent Agent {
      set {
        agent = value;
        if (TaskChange != null)
          TaskChange();
      }
      get {
        return agent;
      }
    }

    #endregion

    #region Methods

    public virtual void Reset() {
      status = false;
      agent = null;
      TaskChange();
    }

    #endregion
  }

  /// <summary>
  /// Represents a list item value which is comparable.
  /// </summary>
  public class TaskComparer : IComparer<TaskComparer> {
    private Agent agent;
    private double payOff;

    public TaskComparer(double aPayoff, Agent aAgent) {
      agent = aAgent;
      payOff = aPayoff;
    }

    public int Compare(TaskComparer first, TaskComparer second) {
      if (first.payOff < second.payOff)
        return -1;
      else if (first.payOff > second.payOff)
        return 1;
      else
        return 0;
    }

    public Agent TaskAgent { get { return agent; } }

    public override string ToString() {
      return agent.ToString() + " [" + payOff.ToString() + "]";
    }
  }
}
