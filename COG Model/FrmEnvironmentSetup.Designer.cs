namespace COG_Model
{
  partial class FrmEnvironmentSetup
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
      this.pnlOptions = new System.Windows.Forms.TableLayoutPanel();
      this.lblSizeOfPopulation = new System.Windows.Forms.Label();
      this.lblNumRun = new System.Windows.Forms.Label();
      this.lblTimeRun = new System.Windows.Forms.Label();
      this.nudNumIterations = new System.Windows.Forms.NumericUpDown();
      this.nudTimeIteration = new System.Windows.Forms.NumericUpDown();
      this.cmbSizePop = new System.Windows.Forms.ComboBox();
      this.pnlControl = new System.Windows.Forms.Panel();
      this.btnAccept = new System.Windows.Forms.Button();
      this.pnlOptions.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudNumIterations)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudTimeIteration)).BeginInit();
      this.pnlControl.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlOptions
      // 
      this.pnlOptions.AutoSize = true;
      this.pnlOptions.ColumnCount = 2;
      this.pnlOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.pnlOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.pnlOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.pnlOptions.Controls.Add(this.lblSizeOfPopulation, 0, 0);
      this.pnlOptions.Controls.Add(this.lblNumRun, 0, 1);
      this.pnlOptions.Controls.Add(this.lblTimeRun, 0, 2);
      this.pnlOptions.Controls.Add(this.nudNumIterations, 1, 1);
      this.pnlOptions.Controls.Add(this.nudTimeIteration, 1, 2);
      this.pnlOptions.Controls.Add(this.cmbSizePop, 1, 0);
      this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlOptions.Location = new System.Drawing.Point(0, 0);
      this.pnlOptions.Name = "pnlOptions";
      this.pnlOptions.RowCount = 3;
      this.pnlOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
      this.pnlOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
      this.pnlOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
      this.pnlOptions.Size = new System.Drawing.Size(284, 81);
      this.pnlOptions.TabIndex = 0;
      // 
      // lblSizeOfPopulation
      // 
      this.lblSizeOfPopulation.AutoSize = true;
      this.lblSizeOfPopulation.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblSizeOfPopulation.Location = new System.Drawing.Point(3, 0);
      this.lblSizeOfPopulation.Name = "lblSizeOfPopulation";
      this.lblSizeOfPopulation.Size = new System.Drawing.Size(136, 27);
      this.lblSizeOfPopulation.TabIndex = 1;
      this.lblSizeOfPopulation.Text = "Size Of Population:";
      this.lblSizeOfPopulation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblNumRun
      // 
      this.lblNumRun.AutoSize = true;
      this.lblNumRun.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblNumRun.Location = new System.Drawing.Point(3, 27);
      this.lblNumRun.Name = "lblNumRun";
      this.lblNumRun.Size = new System.Drawing.Size(136, 27);
      this.lblNumRun.TabIndex = 3;
      this.lblNumRun.Text = "Number of Iterations:";
      this.lblNumRun.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblTimeRun
      // 
      this.lblTimeRun.AutoSize = true;
      this.lblTimeRun.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblTimeRun.Location = new System.Drawing.Point(3, 54);
      this.lblTimeRun.Name = "lblTimeRun";
      this.lblTimeRun.Size = new System.Drawing.Size(136, 27);
      this.lblTimeRun.TabIndex = 4;
      this.lblTimeRun.Text = "Time to run Iteration:";
      this.lblTimeRun.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // nudNumIterations
      // 
      this.nudNumIterations.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::COG_Model.Properties.Settings.Default, "NumberIterations", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.nudNumIterations.Dock = System.Windows.Forms.DockStyle.Fill;
      this.nudNumIterations.Location = new System.Drawing.Point(145, 30);
      this.nudNumIterations.Name = "nudNumIterations";
      this.nudNumIterations.Size = new System.Drawing.Size(136, 20);
      this.nudNumIterations.TabIndex = 6;
      this.nudNumIterations.Value = global::COG_Model.Properties.Settings.Default.NumberIterations;
      // 
      // nudTimeIteration
      // 
      this.nudTimeIteration.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::COG_Model.Properties.Settings.Default, "TimeIteration", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.nudTimeIteration.Dock = System.Windows.Forms.DockStyle.Fill;
      this.nudTimeIteration.Location = new System.Drawing.Point(145, 57);
      this.nudTimeIteration.Name = "nudTimeIteration";
      this.nudTimeIteration.Size = new System.Drawing.Size(136, 20);
      this.nudTimeIteration.TabIndex = 7;
      this.nudTimeIteration.Value = global::COG_Model.Properties.Settings.Default.TimeIteration;
      // 
      // cmbSizePop
      // 
      this.cmbSizePop.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cmbSizePop.FormattingEnabled = true;
      this.cmbSizePop.Location = new System.Drawing.Point(145, 3);
      this.cmbSizePop.Name = "cmbSizePop";
      this.cmbSizePop.Size = new System.Drawing.Size(136, 21);
      this.cmbSizePop.TabIndex = 8;
      // 
      // pnlControl
      // 
      this.pnlControl.BackColor = System.Drawing.SystemColors.ControlDark;
      this.pnlControl.Controls.Add(this.btnAccept);
      this.pnlControl.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pnlControl.Location = new System.Drawing.Point(0, 122);
      this.pnlControl.Name = "pnlControl";
      this.pnlControl.Size = new System.Drawing.Size(284, 31);
      this.pnlControl.TabIndex = 1;
      // 
      // btnAccept
      // 
      this.btnAccept.Location = new System.Drawing.Point(206, 3);
      this.btnAccept.Name = "btnAccept";
      this.btnAccept.Size = new System.Drawing.Size(75, 23);
      this.btnAccept.TabIndex = 0;
      this.btnAccept.Text = "OK";
      this.btnAccept.UseVisualStyleBackColor = true;
      this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
      // 
      // FrmEnvironmentSetup
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 153);
      this.Controls.Add(this.pnlControl);
      this.Controls.Add(this.pnlOptions);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "FrmEnvironmentSetup";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "COG Model";
      this.pnlOptions.ResumeLayout(false);
      this.pnlOptions.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudNumIterations)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudTimeIteration)).EndInit();
      this.pnlControl.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel pnlOptions;
    private System.Windows.Forms.Panel pnlControl;
    private System.Windows.Forms.Label lblSizeOfPopulation;
    private System.Windows.Forms.Label lblNumRun;
    private System.Windows.Forms.Label lblTimeRun;
    private System.Windows.Forms.NumericUpDown nudNumIterations;
    private System.Windows.Forms.NumericUpDown nudTimeIteration;
    private System.Windows.Forms.ComboBox cmbSizePop;
    private System.Windows.Forms.Button btnAccept;
  }
}