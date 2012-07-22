namespace COG_Model {
  partial class ucExecutionTree {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucExecutionTree));
      this.pnlSelPln = new System.Windows.Forms.Panel();
      this.trvCurPln = new System.Windows.Forms.TreeView();
      this.imgTsk = new System.Windows.Forms.ImageList(this.components);
      this.lblExeHdg = new System.Windows.Forms.Label();
      this.pnlSelPln.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlSelPln
      // 
      this.pnlSelPln.Controls.Add(this.trvCurPln);
      this.pnlSelPln.Controls.Add(this.lblExeHdg);
      this.pnlSelPln.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlSelPln.Location = new System.Drawing.Point(0, 0);
      this.pnlSelPln.Name = "pnlSelPln";
      this.pnlSelPln.Size = new System.Drawing.Size(150, 150);
      this.pnlSelPln.TabIndex = 2;
      // 
      // trvCurPln
      // 
      this.trvCurPln.Dock = System.Windows.Forms.DockStyle.Fill;
      this.trvCurPln.FullRowSelect = true;
      this.trvCurPln.HotTracking = true;
      this.trvCurPln.ImageIndex = 0;
      this.trvCurPln.ImageList = this.imgTsk;
      this.trvCurPln.Location = new System.Drawing.Point(0, 20);
      this.trvCurPln.Name = "trvCurPln";
      this.trvCurPln.SelectedImageIndex = 0;
      this.trvCurPln.ShowNodeToolTips = true;
      this.trvCurPln.Size = new System.Drawing.Size(150, 130);
      this.trvCurPln.TabIndex = 0;
      // 
      // imgTsk
      // 
      this.imgTsk.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgTsk.ImageStream")));
      this.imgTsk.TransparentColor = System.Drawing.Color.Transparent;
      this.imgTsk.Images.SetKeyName(0, "branch.png");
      this.imgTsk.Images.SetKeyName(1, "pin_blue.png");
      this.imgTsk.Images.SetKeyName(2, "pin_green.png");
      this.imgTsk.Images.SetKeyName(3, "pin_red.png");
      // 
      // lblExeHdg
      // 
      this.lblExeHdg.BackColor = System.Drawing.SystemColors.ControlDark;
      this.lblExeHdg.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblExeHdg.ForeColor = System.Drawing.SystemColors.HighlightText;
      this.lblExeHdg.Location = new System.Drawing.Point(0, 0);
      this.lblExeHdg.Name = "lblExeHdg";
      this.lblExeHdg.Size = new System.Drawing.Size(150, 20);
      this.lblExeHdg.TabIndex = 1;
      this.lblExeHdg.Text = "Execution Tree";
      this.lblExeHdg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // ucExecutionTree
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.pnlSelPln);
      this.Name = "ucExecutionTree";
      this.pnlSelPln.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlSelPln;
    private System.Windows.Forms.TreeView trvCurPln;
    private System.Windows.Forms.Label lblExeHdg;
    private System.Windows.Forms.ImageList imgTsk;
  }
}
