using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace COG_Model
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      FrmEnvironmentSetup envSetup = new FrmEnvironmentSetup();
      envSetup.ShowDialog();
      Application.Run(new frmCogMain());
    }
  }
}