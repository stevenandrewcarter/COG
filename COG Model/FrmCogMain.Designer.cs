namespace COG_Model
{
    partial class frmCogMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
          this.components = new System.ComponentModel.Container();
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCogMain));
          this.pnlCogTab = new System.Windows.Forms.Panel();
          this.pnlSimulation = new System.Windows.Forms.Panel();
          this.panel1 = new System.Windows.Forms.Panel();
          this.trkSimSpeed = new System.Windows.Forms.TrackBar();
          this.btnStop = new System.Windows.Forms.Button();
          this.btnStart = new System.Windows.Forms.Button();
          this.pnlEnvironmentStats = new System.Windows.Forms.Panel();
          this.pnlStats = new System.Windows.Forms.TableLayoutPanel();
          this.lblStatHead4 = new System.Windows.Forms.Label();
          this.lblStatHead3 = new System.Windows.Forms.Label();
          this.lblStatHead2 = new System.Windows.Forms.Label();
          this.lblPStat3 = new System.Windows.Forms.Label();
          this.lblPStat2 = new System.Windows.Forms.Label();
          this.lblMStat3 = new System.Windows.Forms.Label();
          this.lblMStat2 = new System.Windows.Forms.Label();
          this.lblDStat3 = new System.Windows.Forms.Label();
          this.lblDStat2 = new System.Windows.Forms.Label();
          this.lblSStat3 = new System.Windows.Forms.Label();
          this.lblSStat2 = new System.Windows.Forms.Label();
          this.lblDStat1 = new System.Windows.Forms.Label();
          this.label1 = new System.Windows.Forms.Label();
          this.lblSStat1 = new System.Windows.Forms.Label();
          this.lblStatDet1 = new System.Windows.Forms.Label();
          this.label2 = new System.Windows.Forms.Label();
          this.label3 = new System.Windows.Forms.Label();
          this.lblMStat1 = new System.Windows.Forms.Label();
          this.lblPStat1 = new System.Windows.Forms.Label();
          this.lblStatHead1 = new System.Windows.Forms.Label();
          this.imgTabList = new System.Windows.Forms.ImageList(this.components);
          this.imgDrawList = new System.Windows.Forms.ImageList(this.components);
          this.pnlExePln = new System.Windows.Forms.Panel();
          this.spltInfo = new System.Windows.Forms.SplitContainer();
          this.populationStatus = new COG_Model.AgentPopulationPane();
          this.pnlCogTab.SuspendLayout();
          this.panel1.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.trkSimSpeed)).BeginInit();
          this.pnlEnvironmentStats.SuspendLayout();
          this.pnlStats.SuspendLayout();
          this.pnlExePln.SuspendLayout();
          this.spltInfo.Panel1.SuspendLayout();
          this.spltInfo.SuspendLayout();
          this.SuspendLayout();
          // 
          // pnlCogTab
          // 
          this.pnlCogTab.Controls.Add(this.pnlSimulation);
          this.pnlCogTab.Controls.Add(this.panel1);
          this.pnlCogTab.Controls.Add(this.pnlEnvironmentStats);
          this.pnlCogTab.Dock = System.Windows.Forms.DockStyle.Fill;
          this.pnlCogTab.Location = new System.Drawing.Point(200, 0);
          this.pnlCogTab.Name = "pnlCogTab";
          this.pnlCogTab.Padding = new System.Windows.Forms.Padding(1, 0, 1, 1);
          this.pnlCogTab.Size = new System.Drawing.Size(424, 464);
          this.pnlCogTab.TabIndex = 4;
          // 
          // pnlSimulation
          // 
          this.pnlSimulation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.pnlSimulation.Dock = System.Windows.Forms.DockStyle.Fill;
          this.pnlSimulation.Location = new System.Drawing.Point(1, 22);
          this.pnlSimulation.Name = "pnlSimulation";
          this.pnlSimulation.Size = new System.Drawing.Size(422, 335);
          this.pnlSimulation.TabIndex = 9;
          this.pnlSimulation.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlSimulation_MouseClick);
          // 
          // panel1
          // 
          this.panel1.Controls.Add(this.trkSimSpeed);
          this.panel1.Controls.Add(this.btnStop);
          this.panel1.Controls.Add(this.btnStart);
          this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
          this.panel1.Location = new System.Drawing.Point(1, 0);
          this.panel1.Name = "panel1";
          this.panel1.Size = new System.Drawing.Size(422, 22);
          this.panel1.TabIndex = 10;
          // 
          // trkSimSpeed
          // 
          this.trkSimSpeed.AutoSize = false;
          this.trkSimSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
          this.trkSimSpeed.LargeChange = 1;
          this.trkSimSpeed.Location = new System.Drawing.Point(44, 0);
          this.trkSimSpeed.Name = "trkSimSpeed";
          this.trkSimSpeed.Size = new System.Drawing.Size(378, 22);
          this.trkSimSpeed.TabIndex = 8;
          this.trkSimSpeed.Value = 5;
          this.trkSimSpeed.Scroll += new System.EventHandler(this.trkSimSpeed_Scroll);
          // 
          // btnStop
          // 
          this.btnStop.BackColor = System.Drawing.SystemColors.Control;
          this.btnStop.Dock = System.Windows.Forms.DockStyle.Left;
          this.btnStop.FlatAppearance.BorderSize = 0;
          this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
          this.btnStop.Location = new System.Drawing.Point(22, 0);
          this.btnStop.Name = "btnStop";
          this.btnStop.Size = new System.Drawing.Size(22, 22);
          this.btnStop.TabIndex = 10;
          this.btnStop.UseVisualStyleBackColor = false;
          this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
          // 
          // btnStart
          // 
          this.btnStart.BackColor = System.Drawing.SystemColors.Control;
          this.btnStart.Dock = System.Windows.Forms.DockStyle.Left;
          this.btnStart.FlatAppearance.BorderSize = 0;
          this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
          this.btnStart.Location = new System.Drawing.Point(0, 0);
          this.btnStart.Name = "btnStart";
          this.btnStart.Size = new System.Drawing.Size(22, 22);
          this.btnStart.TabIndex = 9;
          this.btnStart.UseVisualStyleBackColor = false;
          this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
          // 
          // pnlEnvironmentStats
          // 
          this.pnlEnvironmentStats.AutoSize = true;
          this.pnlEnvironmentStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.pnlEnvironmentStats.Controls.Add(this.pnlStats);
          this.pnlEnvironmentStats.Dock = System.Windows.Forms.DockStyle.Bottom;
          this.pnlEnvironmentStats.Location = new System.Drawing.Point(1, 357);
          this.pnlEnvironmentStats.Name = "pnlEnvironmentStats";
          this.pnlEnvironmentStats.Padding = new System.Windows.Forms.Padding(2);
          this.pnlEnvironmentStats.Size = new System.Drawing.Size(422, 106);
          this.pnlEnvironmentStats.TabIndex = 4;
          // 
          // pnlStats
          // 
          this.pnlStats.AutoSize = true;
          this.pnlStats.ColumnCount = 4;
          this.pnlStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
          this.pnlStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
          this.pnlStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
          this.pnlStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
          this.pnlStats.Controls.Add(this.lblStatHead4, 3, 0);
          this.pnlStats.Controls.Add(this.lblStatHead3, 2, 0);
          this.pnlStats.Controls.Add(this.lblStatHead2, 1, 0);
          this.pnlStats.Controls.Add(this.lblPStat3, 3, 4);
          this.pnlStats.Controls.Add(this.lblPStat2, 2, 4);
          this.pnlStats.Controls.Add(this.lblMStat3, 3, 3);
          this.pnlStats.Controls.Add(this.lblMStat2, 2, 3);
          this.pnlStats.Controls.Add(this.lblDStat3, 3, 2);
          this.pnlStats.Controls.Add(this.lblDStat2, 2, 2);
          this.pnlStats.Controls.Add(this.lblSStat3, 3, 1);
          this.pnlStats.Controls.Add(this.lblSStat2, 2, 1);
          this.pnlStats.Controls.Add(this.lblDStat1, 1, 2);
          this.pnlStats.Controls.Add(this.label1, 0, 2);
          this.pnlStats.Controls.Add(this.lblSStat1, 1, 1);
          this.pnlStats.Controls.Add(this.lblStatDet1, 0, 1);
          this.pnlStats.Controls.Add(this.label2, 0, 3);
          this.pnlStats.Controls.Add(this.label3, 0, 4);
          this.pnlStats.Controls.Add(this.lblMStat1, 1, 3);
          this.pnlStats.Controls.Add(this.lblPStat1, 1, 4);
          this.pnlStats.Controls.Add(this.lblStatHead1, 0, 0);
          this.pnlStats.Dock = System.Windows.Forms.DockStyle.Top;
          this.pnlStats.Location = new System.Drawing.Point(2, 2);
          this.pnlStats.Name = "pnlStats";
          this.pnlStats.RowCount = 5;
          this.pnlStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
          this.pnlStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
          this.pnlStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
          this.pnlStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
          this.pnlStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
          this.pnlStats.Size = new System.Drawing.Size(416, 100);
          this.pnlStats.TabIndex = 1;
          // 
          // lblStatHead4
          // 
          this.lblStatHead4.AutoSize = true;
          this.lblStatHead4.BackColor = System.Drawing.SystemColors.ControlDark;
          this.lblStatHead4.Dock = System.Windows.Forms.DockStyle.Fill;
          this.lblStatHead4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lblStatHead4.ForeColor = System.Drawing.SystemColors.ButtonFace;
          this.lblStatHead4.Location = new System.Drawing.Point(361, 0);
          this.lblStatHead4.Margin = new System.Windows.Forms.Padding(0);
          this.lblStatHead4.Name = "lblStatHead4";
          this.lblStatHead4.Size = new System.Drawing.Size(55, 20);
          this.lblStatHead4.TabIndex = 23;
          this.lblStatHead4.Text = "Lost";
          this.lblStatHead4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          // 
          // lblStatHead3
          // 
          this.lblStatHead3.AutoSize = true;
          this.lblStatHead3.BackColor = System.Drawing.SystemColors.ControlDark;
          this.lblStatHead3.Dock = System.Windows.Forms.DockStyle.Fill;
          this.lblStatHead3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lblStatHead3.ForeColor = System.Drawing.SystemColors.ButtonFace;
          this.lblStatHead3.Location = new System.Drawing.Point(306, 0);
          this.lblStatHead3.Margin = new System.Windows.Forms.Padding(0);
          this.lblStatHead3.Name = "lblStatHead3";
          this.lblStatHead3.Size = new System.Drawing.Size(55, 20);
          this.lblStatHead3.TabIndex = 22;
          this.lblStatHead3.Text = "Used";
          this.lblStatHead3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          // 
          // lblStatHead2
          // 
          this.lblStatHead2.AutoSize = true;
          this.lblStatHead2.BackColor = System.Drawing.SystemColors.ControlDark;
          this.lblStatHead2.Dock = System.Windows.Forms.DockStyle.Fill;
          this.lblStatHead2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lblStatHead2.ForeColor = System.Drawing.SystemColors.ButtonFace;
          this.lblStatHead2.Location = new System.Drawing.Point(251, 0);
          this.lblStatHead2.Margin = new System.Windows.Forms.Padding(0);
          this.lblStatHead2.Name = "lblStatHead2";
          this.lblStatHead2.Size = new System.Drawing.Size(55, 20);
          this.lblStatHead2.TabIndex = 21;
          this.lblStatHead2.Text = "Total";
          this.lblStatHead2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          // 
          // lblPStat3
          // 
          this.lblPStat3.AutoSize = true;
          this.lblPStat3.Dock = System.Windows.Forms.DockStyle.Fill;
          this.lblPStat3.Location = new System.Drawing.Point(364, 80);
          this.lblPStat3.Name = "lblPStat3";
          this.lblPStat3.Size = new System.Drawing.Size(49, 20);
          this.lblPStat3.TabIndex = 18;
          this.lblPStat3.Text = "-";
          this.lblPStat3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          // 
          // lblPStat2
          // 
          this.lblPStat2.AutoSize = true;
          this.lblPStat2.Dock = System.Windows.Forms.DockStyle.Fill;
          this.lblPStat2.Location = new System.Drawing.Point(309, 80);
          this.lblPStat2.Name = "lblPStat2";
          this.lblPStat2.Size = new System.Drawing.Size(49, 20);
          this.lblPStat2.TabIndex = 17;
          this.lblPStat2.Text = "-";
          this.lblPStat2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          // 
          // lblMStat3
          // 
          this.lblMStat3.AutoSize = true;
          this.lblMStat3.Dock = System.Windows.Forms.DockStyle.Fill;
          this.lblMStat3.Location = new System.Drawing.Point(364, 60);
          this.lblMStat3.Name = "lblMStat3";
          this.lblMStat3.Size = new System.Drawing.Size(49, 20);
          this.lblMStat3.TabIndex = 15;
          this.lblMStat3.Text = "0";
          this.lblMStat3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          // 
          // lblMStat2
          // 
          this.lblMStat2.AutoSize = true;
          this.lblMStat2.Dock = System.Windows.Forms.DockStyle.Fill;
          this.lblMStat2.Location = new System.Drawing.Point(309, 60);
          this.lblMStat2.Name = "lblMStat2";
          this.lblMStat2.Size = new System.Drawing.Size(49, 20);
          this.lblMStat2.TabIndex = 14;
          this.lblMStat2.Text = "0";
          this.lblMStat2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          // 
          // lblDStat3
          // 
          this.lblDStat3.AutoSize = true;
          this.lblDStat3.Dock = System.Windows.Forms.DockStyle.Fill;
          this.lblDStat3.Location = new System.Drawing.Point(364, 40);
          this.lblDStat3.Name = "lblDStat3";
          this.lblDStat3.Size = new System.Drawing.Size(49, 20);
          this.lblDStat3.TabIndex = 12;
          this.lblDStat3.Text = "0";
          this.lblDStat3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          // 
          // lblDStat2
          // 
          this.lblDStat2.AutoSize = true;
          this.lblDStat2.Dock = System.Windows.Forms.DockStyle.Fill;
          this.lblDStat2.Location = new System.Drawing.Point(309, 40);
          this.lblDStat2.Name = "lblDStat2";
          this.lblDStat2.Size = new System.Drawing.Size(49, 20);
          this.lblDStat2.TabIndex = 11;
          this.lblDStat2.Text = "0";
          this.lblDStat2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          // 
          // lblSStat3
          // 
          this.lblSStat3.AutoSize = true;
          this.lblSStat3.Dock = System.Windows.Forms.DockStyle.Fill;
          this.lblSStat3.Location = new System.Drawing.Point(364, 20);
          this.lblSStat3.Name = "lblSStat3";
          this.lblSStat3.Size = new System.Drawing.Size(49, 20);
          this.lblSStat3.TabIndex = 9;
          this.lblSStat3.Text = "0";
          this.lblSStat3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          // 
          // lblSStat2
          // 
          this.lblSStat2.AutoSize = true;
          this.lblSStat2.Dock = System.Windows.Forms.DockStyle.Fill;
          this.lblSStat2.Location = new System.Drawing.Point(309, 20);
          this.lblSStat2.Name = "lblSStat2";
          this.lblSStat2.Size = new System.Drawing.Size(49, 20);
          this.lblSStat2.TabIndex = 4;
          this.lblSStat2.Text = "0";
          this.lblSStat2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          // 
          // lblDStat1
          // 
          this.lblDStat1.AutoSize = true;
          this.lblDStat1.Dock = System.Windows.Forms.DockStyle.Fill;
          this.lblDStat1.Location = new System.Drawing.Point(254, 40);
          this.lblDStat1.Name = "lblDStat1";
          this.lblDStat1.Size = new System.Drawing.Size(49, 20);
          this.lblDStat1.TabIndex = 8;
          this.lblDStat1.Text = "0";
          this.lblDStat1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
          this.label1.Location = new System.Drawing.Point(3, 40);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(245, 20);
          this.label1.TabIndex = 1;
          this.label1.Text = "Stock Delivered:";
          this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // lblSStat1
          // 
          this.lblSStat1.AutoSize = true;
          this.lblSStat1.Dock = System.Windows.Forms.DockStyle.Fill;
          this.lblSStat1.Location = new System.Drawing.Point(254, 20);
          this.lblSStat1.Name = "lblSStat1";
          this.lblSStat1.Size = new System.Drawing.Size(49, 20);
          this.lblSStat1.TabIndex = 3;
          this.lblSStat1.Text = "0";
          this.lblSStat1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          // 
          // lblStatDet1
          // 
          this.lblStatDet1.AutoSize = true;
          this.lblStatDet1.Dock = System.Windows.Forms.DockStyle.Fill;
          this.lblStatDet1.Location = new System.Drawing.Point(3, 20);
          this.lblStatDet1.Name = "lblStatDet1";
          this.lblStatDet1.Size = new System.Drawing.Size(245, 20);
          this.lblStatDet1.TabIndex = 0;
          this.lblStatDet1.Text = "Stock Produced:";
          this.lblStatDet1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
          this.label2.Location = new System.Drawing.Point(3, 60);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(245, 20);
          this.label2.TabIndex = 1;
          this.label2.Text = "Product Manufactured:";
          this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // label3
          // 
          this.label3.AutoSize = true;
          this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
          this.label3.Location = new System.Drawing.Point(3, 80);
          this.label3.Name = "label3";
          this.label3.Size = new System.Drawing.Size(245, 20);
          this.label3.TabIndex = 2;
          this.label3.Text = "Product Delivered:";
          this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // lblMStat1
          // 
          this.lblMStat1.AutoSize = true;
          this.lblMStat1.Dock = System.Windows.Forms.DockStyle.Fill;
          this.lblMStat1.Location = new System.Drawing.Point(254, 60);
          this.lblMStat1.Name = "lblMStat1";
          this.lblMStat1.Size = new System.Drawing.Size(49, 20);
          this.lblMStat1.TabIndex = 6;
          this.lblMStat1.Text = "0";
          this.lblMStat1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          // 
          // lblPStat1
          // 
          this.lblPStat1.AutoSize = true;
          this.lblPStat1.Dock = System.Windows.Forms.DockStyle.Fill;
          this.lblPStat1.Location = new System.Drawing.Point(254, 80);
          this.lblPStat1.Name = "lblPStat1";
          this.lblPStat1.Size = new System.Drawing.Size(49, 20);
          this.lblPStat1.TabIndex = 7;
          this.lblPStat1.Text = "0";
          this.lblPStat1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          // 
          // lblStatHead1
          // 
          this.lblStatHead1.AutoSize = true;
          this.lblStatHead1.BackColor = System.Drawing.SystemColors.ControlDark;
          this.lblStatHead1.Dock = System.Windows.Forms.DockStyle.Fill;
          this.lblStatHead1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lblStatHead1.ForeColor = System.Drawing.SystemColors.ButtonFace;
          this.lblStatHead1.Location = new System.Drawing.Point(0, 0);
          this.lblStatHead1.Margin = new System.Windows.Forms.Padding(0);
          this.lblStatHead1.Name = "lblStatHead1";
          this.lblStatHead1.Size = new System.Drawing.Size(251, 20);
          this.lblStatHead1.TabIndex = 20;
          this.lblStatHead1.Text = "Item";
          this.lblStatHead1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // imgTabList
          // 
          this.imgTabList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgTabList.ImageStream")));
          this.imgTabList.TransparentColor = System.Drawing.Color.Transparent;
          this.imgTabList.Images.SetKeyName(0, "earth_view.png");
          this.imgTabList.Images.SetKeyName(1, "cpu.png");
          this.imgTabList.Images.SetKeyName(2, "telephone.png");
          // 
          // imgDrawList
          // 
          this.imgDrawList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgDrawList.ImageStream")));
          this.imgDrawList.TransparentColor = System.Drawing.Color.White;
          this.imgDrawList.Images.SetKeyName(0, "bullet_ball_yellow.png");
          this.imgDrawList.Images.SetKeyName(1, "bullet_square_blue.png");
          this.imgDrawList.Images.SetKeyName(2, "bullet_square_green.png");
          this.imgDrawList.Images.SetKeyName(3, "bullet_square_red.png");
          this.imgDrawList.Images.SetKeyName(4, "telephone.png");
          this.imgDrawList.Images.SetKeyName(5, "cpu.png");
          // 
          // pnlExePln
          // 
          this.pnlExePln.Controls.Add(this.spltInfo);
          this.pnlExePln.Dock = System.Windows.Forms.DockStyle.Left;
          this.pnlExePln.Location = new System.Drawing.Point(0, 0);
          this.pnlExePln.Name = "pnlExePln";
          this.pnlExePln.Size = new System.Drawing.Size(200, 464);
          this.pnlExePln.TabIndex = 3;
          // 
          // spltInfo
          // 
          this.spltInfo.Dock = System.Windows.Forms.DockStyle.Fill;
          this.spltInfo.Location = new System.Drawing.Point(0, 0);
          this.spltInfo.Name = "spltInfo";
          this.spltInfo.Orientation = System.Windows.Forms.Orientation.Horizontal;
          // 
          // spltInfo.Panel1
          // 
          this.spltInfo.Panel1.Controls.Add(this.populationStatus);
          this.spltInfo.Size = new System.Drawing.Size(200, 464);
          this.spltInfo.SplitterDistance = 214;
          this.spltInfo.TabIndex = 0;
          // 
          // populationStatus
          // 
          this.populationStatus.Dock = System.Windows.Forms.DockStyle.Fill;
          this.populationStatus.Location = new System.Drawing.Point(0, 0);
          this.populationStatus.Name = "populationStatus";
          this.populationStatus.Size = new System.Drawing.Size(200, 214);
          this.populationStatus.TabIndex = 0;
          // 
          // frmCogMain
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(624, 464);
          this.Controls.Add(this.pnlCogTab);
          this.Controls.Add(this.pnlExePln);
          this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
          this.Name = "frmCogMain";
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Text = "COG Model";
          this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCogMain_FormClosing);
          this.pnlCogTab.ResumeLayout(false);
          this.pnlCogTab.PerformLayout();
          this.panel1.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.trkSimSpeed)).EndInit();
          this.pnlEnvironmentStats.ResumeLayout(false);
          this.pnlEnvironmentStats.PerformLayout();
          this.pnlStats.ResumeLayout(false);
          this.pnlStats.PerformLayout();
          this.pnlExePln.ResumeLayout(false);
          this.spltInfo.Panel1.ResumeLayout(false);
          this.spltInfo.ResumeLayout(false);
          this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel pnlCogTab;
        private System.Windows.Forms.ImageList imgDrawList;
        private System.Windows.Forms.Panel pnlExePln;
        private System.Windows.Forms.SplitContainer spltInfo;
        private AgentPopulationPane populationStatus;
        private System.Windows.Forms.ImageList imgTabList;
        private System.Windows.Forms.Panel pnlSimulation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar trkSimSpeed;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel pnlEnvironmentStats;
        private System.Windows.Forms.TableLayoutPanel pnlStats;
        private System.Windows.Forms.Label lblStatHead4;
        private System.Windows.Forms.Label lblStatHead3;
        private System.Windows.Forms.Label lblStatHead2;
        private System.Windows.Forms.Label lblPStat3;
        private System.Windows.Forms.Label lblPStat2;
        private System.Windows.Forms.Label lblMStat3;
        private System.Windows.Forms.Label lblMStat2;
        private System.Windows.Forms.Label lblDStat3;
        private System.Windows.Forms.Label lblDStat2;
        private System.Windows.Forms.Label lblSStat3;
        private System.Windows.Forms.Label lblSStat2;
        private System.Windows.Forms.Label lblDStat1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSStat1;
        private System.Windows.Forms.Label lblStatDet1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMStat1;
        private System.Windows.Forms.Label lblPStat1;
        private System.Windows.Forms.Label lblStatHead1;
    }
}

