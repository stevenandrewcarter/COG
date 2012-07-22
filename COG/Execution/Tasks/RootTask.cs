
namespace Clockwork.Execution.Tasks {
  // Place holder task to represent the root of the execution tree
  public class RootTask : Task {
    public RootTask()
      : base() {
      // Can't actually activate the Root Execution Node.
      status = true;
    }

    public override string ToString() {
      return "Execution Tree";
    }

    public override void Reset() {
      status = true;
      agent = null;
    }

    // Type level accessors
    public const int ID = 0;
  }
}
