using System.Windows.Forms;

namespace COG_Model {
  public partial class ucExecutionTree : UserControl {
    private Clockwork.Environment env;

    public ucExecutionTree(ref Clockwork.Environment environment) {
      InitializeComponent();
      env = environment;
      trvCurPln.Nodes.Add(env.Execution.Root);
    }
  }
}
