using Clockwork.Execution.Tasks;

namespace Clockwork.Execution {
  public class ExecutionTree {
    private Environment env;
    private ExecutionNode root;

    #region Constructor

    public ExecutionTree(ref Environment environment) {
      env = environment;
      root = new ExecutionNode(new RootTask());
    }

    #endregion

    #region Properties

    public ExecutionNode Root { get { return root; } }

    #endregion

    #region Methods

    public void Reset() {
      root.Reset();
    }

    public void AddChild(Task parent, Task child) {
      root.Add(parent, child);
      root.SetLabel("Execution Tree (" + root.Nodes.Count + ")");
    }

    public void Remove(Task task) {
      root.Remove(task);
      root.SetLabel("Execution Tree (" + root.Nodes.Count + ")");
    }

    #endregion
  }
}
