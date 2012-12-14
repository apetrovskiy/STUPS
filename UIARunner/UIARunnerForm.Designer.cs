using System;
/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/28/2012
 * Time: 6:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIARunner
{
    partial class UIARunnerForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        //private void InitializeComponent(RunModes mode, string path)
        private void InitializeComponent() //RunModes mode, string path)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIARunnerForm));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.breakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripResults = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelPassed = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelPassedCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelFailed = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelFailedCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelState = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelAverage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelAverageCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonRun = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBreak = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBoxInput = new System.Windows.Forms.ToolStripTextBox();
            this.dgvTestResults = new System.Windows.Forms.DataGridView();
            this.colDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScreenshot = new System.Windows.Forms.DataGridViewLinkColumn();
            this.menuStripMain.SuspendLayout();
            this.statusStripResults.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestResults)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "*.ps1";
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.fileToolStripMenuItem,
                                    this.scriptToolStripMenuItem,
                                    this.helpToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(681, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStripMain";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.openToolStripMenuItem,
                                    this.toolStripSeparator1,
                                    this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // scriptToolStripMenuItem
            // 
            this.scriptToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.inputToolStripTextBox,
                                    this.runToolStripMenuItem,
                                    this.breakToolStripMenuItem});
            this.scriptToolStripMenuItem.Name = "scriptToolStripMenuItem";
            this.scriptToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.scriptToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.scriptToolStripMenuItem.Text = "Script";
            // 
            // inputToolStripTextBox
            // 
            this.inputToolStripTextBox.Name = "inputToolStripTextBox";
            this.inputToolStripTextBox.Size = new System.Drawing.Size(100, 23);
            this.inputToolStripTextBox.ModifiedChanged += new System.EventHandler(this.ToolStripTextBoxInputParametersModifiedChanged);
            //this.inputToolStripTextBox.Click += new System.EventHandler(this.inputToolStripTextBoxClick);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Enabled = false;
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.runToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.OnRunScript);
            // 
            // breakToolStripMenuItem
            // 
            this.breakToolStripMenuItem.Enabled = false;
            this.breakToolStripMenuItem.Name = "breakToolStripMenuItem";
            this.breakToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.breakToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.breakToolStripMenuItem.Text = "Break";
            this.breakToolStripMenuItem.Click += new System.EventHandler(this.BreakToolStripMenuItemClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
            // 
            // statusStripResults
            // 
            this.statusStripResults.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.toolStripStatusLabelPassed,
                                    this.toolStripStatusLabelPassedCount,
                                    this.toolStripStatusLabelFailed,
                                    this.toolStripStatusLabelFailedCount,
                                    this.toolStripStatusLabelState,
                                    this.toolStripStatusLabelAverage,
                                    this.toolStripStatusLabelAverageCount});
            this.statusStripResults.Location = new System.Drawing.Point(0, 394);
            this.statusStripResults.Name = "statusStripResults";
            this.statusStripResults.Size = new System.Drawing.Size(681, 22);
            this.statusStripResults.TabIndex = 2;
            this.statusStripResults.Text = "statusStrip1";
            // 
            // toolStripStatusLabelPassed
            // 
            this.toolStripStatusLabelPassed.AutoSize = false;
            this.toolStripStatusLabelPassed.Name = "toolStripStatusLabelPassed";
            this.toolStripStatusLabelPassed.Size = new System.Drawing.Size(50, 17);
            this.toolStripStatusLabelPassed.Text = "Passed:";
            // 
            // toolStripStatusLabelPassedCount
            // 
            this.toolStripStatusLabelPassedCount.AutoSize = false;
            this.toolStripStatusLabelPassedCount.Name = "toolStripStatusLabelPassedCount";
            this.toolStripStatusLabelPassedCount.Size = new System.Drawing.Size(30, 17);
            // 
            // toolStripStatusLabelFailed
            // 
            this.toolStripStatusLabelFailed.AutoSize = false;
            this.toolStripStatusLabelFailed.Name = "toolStripStatusLabelFailed";
            this.toolStripStatusLabelFailed.Size = new System.Drawing.Size(50, 17);
            this.toolStripStatusLabelFailed.Text = "Failed:";
            // 
            // toolStripStatusLabelFailedCount
            // 
            this.toolStripStatusLabelFailedCount.AutoSize = false;
            this.toolStripStatusLabelFailedCount.Name = "toolStripStatusLabelFailedCount";
            this.toolStripStatusLabelFailedCount.Size = new System.Drawing.Size(30, 17);
            // 
            // toolStripStatusLabelState
            // 
            this.toolStripStatusLabelState.AutoSize = false;
            this.toolStripStatusLabelState.Name = "toolStripStatusLabelState";
            this.toolStripStatusLabelState.Size = new System.Drawing.Size(80, 17);
            // 
            // toolStripStatusLabelAverage
            // 
            this.toolStripStatusLabelAverage.AutoSize = false;
            this.toolStripStatusLabelAverage.Name = "toolStripStatusLabelAverage";
            this.toolStripStatusLabelAverage.Size = new System.Drawing.Size(100, 17);
            this.toolStripStatusLabelAverage.Text = "Average velocity:";
            // 
            // toolStripStatusLabelAverageCount
            // 
            this.toolStripStatusLabelAverageCount.AutoSize = false;
            this.toolStripStatusLabelAverageCount.Name = "toolStripStatusLabelAverageCount";
            this.toolStripStatusLabelAverageCount.Size = new System.Drawing.Size(50, 17);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.toolStripButtonOpen,
                                    this.toolStripSeparator2,
                                    this.toolStripButtonRun,
                                    this.toolStripButtonBreak,
                                    this.toolStripTextBoxInput});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(681, 25);
            this.toolStrip.TabIndex = 3;
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOpen.Image")));
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOpen.Text = "Open";
            this.toolStripButtonOpen.Click += new System.EventHandler(this.ToolStripButtonOpenClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonRun
            // 
            this.toolStripButtonRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRun.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRun.Image")));
            this.toolStripButtonRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRun.Name = "toolStripButtonRun";
            this.toolStripButtonRun.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRun.Click += new System.EventHandler(this.ToolStripButtonRunClick);
            // 
            // toolStripButtonBreak
            // 
            this.toolStripButtonBreak.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBreak.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBreak.Image")));
            this.toolStripButtonBreak.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBreak.Name = "toolStripButtonBreak";
            this.toolStripButtonBreak.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonBreak.Click += new System.EventHandler(this.ToolStripButtonBreakClick);
            // 
            // toolStripTextBoxInput
            // 
            this.toolStripTextBoxInput.Name = "toolStripTextBoxInput";
            this.toolStripTextBoxInput.Size = new System.Drawing.Size(100, 25);
            this.toolStripTextBoxInput.ModifiedChanged += new System.EventHandler(this.ToolStripTextBoxInputModifiedChanged);
            // 
            // dgvTestResults
            // 
            this.dgvTestResults.AllowUserToAddRows = false;
            this.dgvTestResults.AllowUserToDeleteRows = false;
            this.dgvTestResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                                    this.colDateTime,
                                    this.colStatus,
                                    this.colName,
                                    this.colLine,
                                    this.colPosition,
                                    this.colCode,
                                    this.colError,
                                    this.colScreenshot});
            this.dgvTestResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTestResults.Location = new System.Drawing.Point(0, 49);
            this.dgvTestResults.Name = "dgvTestResults";
            this.dgvTestResults.RowHeadersVisible = false;
            this.dgvTestResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTestResults.Size = new System.Drawing.Size(681, 345);
            this.dgvTestResults.TabIndex = 4;
            this.dgvTestResults.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DgvTestResultsMouseMove);
            // 
            // colDateTime
            // 
            this.colDateTime.HeaderText = "Date Time";
            this.colDateTime.Name = "colDateTime";
            this.colDateTime.ReadOnly = true;
            this.colDateTime.Width = 81;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 62;
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 60;
            // 
            // colLine
            // 
            this.colLine.HeaderText = "Line";
            this.colLine.Name = "colLine";
            this.colLine.ReadOnly = true;
            this.colLine.Width = 52;
            // 
            // colPosition
            // 
            this.colPosition.HeaderText = "Pos.";
            this.colPosition.Name = "colPosition";
            this.colPosition.ReadOnly = true;
            this.colPosition.Width = 69;
            // 
            // colCode
            // 
            this.colCode.HeaderText = "Script";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            this.colCode.Width = 57;
            // 
            // colError
            // 
            this.colError.HeaderText = "Error";
            this.colError.Name = "colError";
            this.colError.ReadOnly = true;
            // 
            // colScreenshot
            // 
            this.colScreenshot.HeaderText = "Screenshot";
            this.colScreenshot.Name = "colScreenshot";
            this.colScreenshot.ReadOnly = true;
            this.colScreenshot.Width = 67;
            // 
            // UIARunnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 416);
            this.Controls.Add(this.dgvTestResults);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStripResults);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UIARunnerForm";
            this.Text = "UIARunner";
            this.Deactivate += new System.EventHandler(this.UIARunnerFormDeactivate);
            this.Load += new System.EventHandler(this.UIARunnerFormLoad);
            this.Leave += new System.EventHandler(this.UIARunnerFormLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UIARunnerFormMouseMove);
            this.Resize += new System.EventHandler(this.UIARunnerFormResize);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.statusStripResults.ResumeLayout(false);
            this.statusStripResults.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxInput;
        private System.Windows.Forms.ToolStripTextBox inputToolStripTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn colError;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelAverageCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelAverage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLine;
        private System.Windows.Forms.ToolStripButton toolStripButtonBreak;
        private System.Windows.Forms.ToolStripButton toolStripButtonRun;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelState;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFailedCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFailed;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelPassedCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelPassed;
        private System.Windows.Forms.StatusStrip statusStripResults;
        private System.Windows.Forms.DataGridViewLinkColumn colScreenshot;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateTime;
        private System.Windows.Forms.DataGridView dgvTestResults;
        private System.Windows.Forms.ToolStripMenuItem breakToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}
