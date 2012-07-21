namespace COG_Model
{
  partial class AgentPopulationPane
  {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("COG Model Agents");
      System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Transport (0)");
      System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Suppliers (0)");
      System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Manufacturers (0)");
      System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Clients (0)");
      System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Simulation Agents", 5, 5, new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgentPopulationPane));
      this.trvCurPln = new System.Windows.Forms.TreeView();
      this.imgDrawList = new System.Windows.Forms.ImageList(this.components);
      this.lblExeHdg = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // trvCurPln
      // 
      this.trvCurPln.Dock = System.Windows.Forms.DockStyle.Fill;
      this.trvCurPln.FullRowSelect = true;
      this.trvCurPln.HotTracking = true;
      this.trvCurPln.ImageIndex = 0;
      this.trvCurPln.ImageList = this.imgDrawList;
      this.trvCurPln.Location = new System.Drawing.Point(0, 20);
      this.trvCurPln.Name = "trvCurPln";
      treeNode1.ImageKey = "gear.png";
      treeNode1.Name = "COG Model Agents";
      treeNode1.SelectedImageKey = "gear.png";
      treeNode1.Text = "COG Model Agents";
      treeNode2.ImageKey = "bullet_ball_yellow.png";
      treeNode2.Name = "Transport";
      treeNode2.SelectedImageKey = "bullet_ball_yellow.png";
      treeNode2.Text = "Transport (0)";
      treeNode3.ImageKey = "bullet_square_blue.png";
      treeNode3.Name = "Suppliers";
      treeNode3.SelectedImageKey = "bullet_square_blue.png";
      treeNode3.Text = "Suppliers (0)";
      treeNode4.ImageKey = "bullet_square_green.png";
      treeNode4.Name = "Manufacturers";
      treeNode4.SelectedImageKey = "bullet_square_green.png";
      treeNode4.Text = "Manufacturers (0)";
      treeNode5.ImageKey = "bullet_square_red.png";
      treeNode5.Name = "Clients";
      treeNode5.SelectedImageKey = "bullet_square_red.png";
      treeNode5.Text = "Clients (0)";
      treeNode6.ImageIndex = 5;
      treeNode6.Name = "Simulation Agents";
      treeNode6.SelectedImageIndex = 5;
      treeNode6.Text = "Simulation Agents";
      this.trvCurPln.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode6});
      this.trvCurPln.SelectedImageIndex = 0;
      this.trvCurPln.ShowNodeToolTips = true;
      this.trvCurPln.Size = new System.Drawing.Size(150, 130);
      this.trvCurPln.TabIndex = 5;
      // 
      // imgDrawList
      // 
      this.imgDrawList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgDrawList.ImageStream")));
      this.imgDrawList.TransparentColor = System.Drawing.Color.White;
      this.imgDrawList.Images.SetKeyName(0, "bullet_ball_yellow.png");
      this.imgDrawList.Images.SetKeyName(1, "bullet_square_blue.png");
      this.imgDrawList.Images.SetKeyName(2, "bullet_square_green.png");
      this.imgDrawList.Images.SetKeyName(3, "bullet_square_red.png");
      this.imgDrawList.Images.SetKeyName(4, "gear.png");
      this.imgDrawList.Images.SetKeyName(5, "earth_view.png");
      this.imgDrawList.Images.SetKeyName(6, "telephone.png");
      this.imgDrawList.Images.SetKeyName(7, "cpu.png");
      this.imgDrawList.Images.SetKeyName(8, "box.png");
      // 
      // lblExeHdg
      // 
      this.lblExeHdg.BackColor = System.Drawing.SystemColors.ControlDark;
      this.lblExeHdg.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblExeHdg.ForeColor = System.Drawing.SystemColors.HighlightText;
      this.lblExeHdg.Location = new System.Drawing.Point(0, 0);
      this.lblExeHdg.Name = "lblExeHdg";
      this.lblExeHdg.Size = new System.Drawing.Size(150, 20);
      this.lblExeHdg.TabIndex = 6;
      this.lblExeHdg.Text = "Population";
      this.lblExeHdg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // AgentPopulationPane
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.trvCurPln);
      this.Controls.Add(this.lblExeHdg);
      this.Name = "AgentPopulationPane";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TreeView trvCurPln;
    private System.Windows.Forms.Label lblExeHdg;
    private System.Windows.Forms.ImageList imgDrawList;
  }
}
