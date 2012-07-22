using System;
using System.ComponentModel;
using System.Windows.Forms;
using UtilityClasses;

namespace COG_Model {
  public partial class FrmEnvironmentSetup : Form {
    public FrmEnvironmentSetup() {
      InitializeComponent();
      cmbSizePop.Items.Add(new ComboBoxItem(0, "Small Population"));
      cmbSizePop.Items.Add(new ComboBoxItem(1, "Medium Population"));
      cmbSizePop.Items.Add(new ComboBoxItem(2, "Large Population"));
      cmbSizePop.SelectedIndex = COG_Model.Properties.Settings.Default.NumberOfAgents;
    }

    protected override void OnClosing(CancelEventArgs e) {
      COG_Model.Properties.Settings.Default.NumberOfAgents = cmbSizePop.SelectedIndex;
      COG_Model.Properties.Settings.Default.Save();
    }

    private void btnAccept_Click(object sender, EventArgs e) {
      Dispose();
    }
  }
}
