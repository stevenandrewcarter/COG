using Clockwork.Execution;
using COG_Model.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace COG_Model
{
  public partial class ucExecutionTree : UserControl
  {
    private Clockwork.Environment env;

    public ucExecutionTree(ref Clockwork.Environment environment)
    {
      InitializeComponent();
      env = environment;
      trvCurPln.Nodes.Add(env.Execution.Root);
    }
  }
}
