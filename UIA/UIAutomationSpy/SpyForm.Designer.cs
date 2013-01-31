/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 24/02/2012
 * Time: 07:18 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationSpy
{
	//extern alias UIACOM;
	using System;
	using System.Windows.Automation;
	using System.Windows.Forms;
	using System.Drawing;
	//using UIACOM3;
	//using UIAutomationClient;
	
	using System.Management.Automation;
    using System.Security.Cryptography;

    partial class SpyForm
    {
        private bool stopNow = false;
        
        private string scriptCurrentString = string.Empty;
        private string scriptPreviousString = string.Empty;
        
        System.Collections.Generic.List<string> ancestorsNodesList = 
            new System.Collections.Generic.List<string>();
        System.Collections.Generic.List<string> ancestorsCodeList = 
            new System.Collections.Generic.List<string>();
        
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing" > true if managed resources should be disposed; otherwise, false.</param > 
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components  !=  null) {
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpyForm));
            this.btnStart = new System.Windows.Forms.Button();
            this.richControlCode = new System.Windows.Forms.RichTextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.chkClipboard = new System.Windows.Forms.CheckBox();
            this.tabOuter = new System.Windows.Forms.TabControl();
            this.tabCode = new System.Windows.Forms.TabPage();
            this.chkTestCode = new System.Windows.Forms.CheckBox();
            this.tabInner = new System.Windows.Forms.TabControl();
            this.tabControl = new System.Windows.Forms.TabPage();
            this.txtFullCode = new System.Windows.Forms.TextBox();
            this.richPatterns = new System.Windows.Forms.RichTextBox();
            this.tabHierarchy = new System.Windows.Forms.TabPage();
            this.tvwHierarhy = new System.Windows.Forms.TreeView();
            this.tabProperties = new System.Windows.Forms.TabPage();
            this.pGridElement = new System.Windows.Forms.PropertyGrid();
            this.tabScript = new System.Windows.Forms.TabPage();
            this.splitContScript = new System.Windows.Forms.SplitContainer();
            this.btnBreakPS = new System.Windows.Forms.Button();
            this.btnRunSel = new System.Windows.Forms.Button();
            this.btnRunAll = new System.Windows.Forms.Button();
            this.txtScript = new System.Windows.Forms.TextBox();
            this.tabResults = new System.Windows.Forms.TabPage();
            this.richResults = new System.Windows.Forms.RichTextBox();
            this.tabTree = new System.Windows.Forms.TabPage();
            this.tvUIAHierarchy = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codeGenerationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ancestryTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.scriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.notImplementedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uIAutomationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleniumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.automationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startRecordingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopRecorgingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.breakScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabOuter.SuspendLayout();
            this.tabCode.SuspendLayout();
            this.tabInner.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabHierarchy.SuspendLayout();
            this.tabProperties.SuspendLayout();
            this.tabScript.SuspendLayout();
            this.splitContScript.Panel1.SuspendLayout();
            this.splitContScript.Panel2.SuspendLayout();
            this.splitContScript.SuspendLayout();
            this.tabResults.SuspendLayout();
            this.tabTree.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 6);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 30);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStartClick);
            // 
            // richControlCode
            // 
            this.richControlCode.AutoWordSelection = true;
            this.richControlCode.HideSelection = false;
            this.richControlCode.Location = new System.Drawing.Point(6, 6);
            this.richControlCode.Name = "richControlCode";
            this.richControlCode.Size = new System.Drawing.Size(348, 50);
            this.richControlCode.TabIndex = 3;
            this.richControlCode.Text = "";
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(86, 6);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 30);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BtnStopClick);
            // 
            // chkClipboard
            // 
            this.chkClipboard.Location = new System.Drawing.Point(176, 5);
            this.chkClipboard.Name = "chkClipboard";
            this.chkClipboard.Size = new System.Drawing.Size(190, 17);
            this.chkClipboard.TabIndex = 4;
            this.chkClipboard.Text = "Write code to clipboard";
            this.chkClipboard.UseVisualStyleBackColor = true;
            // 
            // tabOuter
            // 
            this.tabOuter.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.tabOuter.Controls.Add(this.tabCode);
            this.tabOuter.Controls.Add(this.tabScript);
            this.tabOuter.Controls.Add(this.tabResults);
            this.tabOuter.Controls.Add(this.tabTree);
            this.tabOuter.Location = new System.Drawing.Point(12, 22);
            this.tabOuter.Multiline = true;
            this.tabOuter.Name = "tabOuter";
            this.tabOuter.SelectedIndex = 0;
            this.tabOuter.Size = new System.Drawing.Size(418, 302);
            this.tabOuter.TabIndex = 5;
            // 
            // tabCode
            // 
            this.tabCode.Controls.Add(this.chkTestCode);
            this.tabCode.Controls.Add(this.tabInner);
            this.tabCode.Controls.Add(this.chkClipboard);
            this.tabCode.Controls.Add(this.btnStart);
            this.tabCode.Controls.Add(this.btnStop);
            this.tabCode.Location = new System.Drawing.Point(4, 4);
            this.tabCode.Name = "tabCode";
            this.tabCode.Padding = new System.Windows.Forms.Padding(3);
            this.tabCode.Size = new System.Drawing.Size(391, 294);
            this.tabCode.TabIndex = 0;
            this.tabCode.Text = "Code";
            this.tabCode.UseVisualStyleBackColor = true;
            // 
            // chkTestCode
            // 
            this.chkTestCode.Location = new System.Drawing.Point(176, 23);
            this.chkTestCode.Name = "chkTestCode";
            this.chkTestCode.Size = new System.Drawing.Size(190, 17);
            this.chkTestCode.TabIndex = 5;
            this.chkTestCode.Text = "Test generated code";
            this.chkTestCode.UseVisualStyleBackColor = true;
            // 
            // tabInner
            // 
            this.tabInner.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabInner.Controls.Add(this.tabControl);
            this.tabInner.Controls.Add(this.tabHierarchy);
            this.tabInner.Controls.Add(this.tabProperties);
            this.tabInner.Location = new System.Drawing.Point(3, 42);
            this.tabInner.Multiline = true;
            this.tabInner.Name = "tabInner";
            this.tabInner.SelectedIndex = 0;
            this.tabInner.Size = new System.Drawing.Size(388, 251);
            this.tabInner.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.txtFullCode);
            this.tabControl.Controls.Add(this.richPatterns);
            this.tabControl.Controls.Add(this.richControlCode);
            this.tabControl.Location = new System.Drawing.Point(23, 4);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Windows.Forms.Padding(3);
            this.tabControl.Size = new System.Drawing.Size(361, 243);
            this.tabControl.TabIndex = 0;
            this.tabControl.Text = "Control";
            this.tabControl.UseVisualStyleBackColor = true;
            // 
            // txtFullCode
            // 
            this.txtFullCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullCode.Location = new System.Drawing.Point(6, 148);
            this.txtFullCode.Multiline = true;
            this.txtFullCode.Name = "txtFullCode";
            this.txtFullCode.Size = new System.Drawing.Size(348, 97);
            this.txtFullCode.TabIndex = 5;
            // 
            // richPatterns
            // 
            this.richPatterns.Location = new System.Drawing.Point(6, 62);
            this.richPatterns.Name = "richPatterns";
            this.richPatterns.Size = new System.Drawing.Size(348, 80);
            this.richPatterns.TabIndex = 4;
            this.richPatterns.Text = "";
            // 
            // tabHierarchy
            // 
            this.tabHierarchy.Controls.Add(this.tvwHierarhy);
            this.tabHierarchy.Location = new System.Drawing.Point(23, 4);
            this.tabHierarchy.Name = "tabHierarchy";
            this.tabHierarchy.Padding = new System.Windows.Forms.Padding(3);
            this.tabHierarchy.Size = new System.Drawing.Size(361, 243);
            this.tabHierarchy.TabIndex = 1;
            this.tabHierarchy.Text = "Hierarchy";
            this.tabHierarchy.UseVisualStyleBackColor = true;
            // 
            // tvwHierarhy
            // 
            this.tvwHierarhy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwHierarhy.Location = new System.Drawing.Point(3, 3);
            this.tvwHierarhy.Name = "tvwHierarhy";
            this.tvwHierarhy.Size = new System.Drawing.Size(355, 237);
            this.tvwHierarhy.TabIndex = 0;
            // 
            // tabProperties
            // 
            this.tabProperties.Controls.Add(this.pGridElement);
            this.tabProperties.Location = new System.Drawing.Point(23, 4);
            this.tabProperties.Name = "tabProperties";
            this.tabProperties.Size = new System.Drawing.Size(361, 243);
            this.tabProperties.TabIndex = 2;
            this.tabProperties.Text = "Properties";
            this.tabProperties.UseVisualStyleBackColor = true;
            // 
            // pGridElement
            // 
            this.pGridElement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGridElement.Location = new System.Drawing.Point(0, 0);
            this.pGridElement.Name = "pGridElement";
            this.pGridElement.Size = new System.Drawing.Size(361, 243);
            this.pGridElement.TabIndex = 0;
            // 
            // tabScript
            // 
            this.tabScript.Controls.Add(this.splitContScript);
            this.tabScript.Location = new System.Drawing.Point(4, 4);
            this.tabScript.Name = "tabScript";
            this.tabScript.Size = new System.Drawing.Size(391, 294);
            this.tabScript.TabIndex = 2;
            this.tabScript.Text = "Script";
            this.tabScript.UseVisualStyleBackColor = true;
            // 
            // splitContScript
            // 
            this.splitContScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContScript.Location = new System.Drawing.Point(0, 0);
            this.splitContScript.Name = "splitContScript";
            this.splitContScript.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContScript.Panel1
            // 
            this.splitContScript.Panel1.Controls.Add(this.btnBreakPS);
            this.splitContScript.Panel1.Controls.Add(this.btnRunSel);
            this.splitContScript.Panel1.Controls.Add(this.btnRunAll);
            // 
            // splitContScript.Panel2
            // 
            this.splitContScript.Panel2.Controls.Add(this.txtScript);
            this.splitContScript.Size = new System.Drawing.Size(391, 294);
            this.splitContScript.SplitterDistance = 51;
            this.splitContScript.TabIndex = 1;
            // 
            // btnBreakPS
            // 
            this.btnBreakPS.Location = new System.Drawing.Point(175, 12);
            this.btnBreakPS.Name = "btnBreakPS";
            this.btnBreakPS.Size = new System.Drawing.Size(75, 30);
            this.btnBreakPS.TabIndex = 2;
            this.btnBreakPS.Text = "Break";
            this.btnBreakPS.UseVisualStyleBackColor = true;
            this.btnBreakPS.Click += new System.EventHandler(this.BtnBreakPSClick);
            // 
            // btnRunSel
            // 
            this.btnRunSel.Location = new System.Drawing.Point(94, 12);
            this.btnRunSel.Name = "btnRunSel";
            this.btnRunSel.Size = new System.Drawing.Size(75, 30);
            this.btnRunSel.TabIndex = 1;
            this.btnRunSel.Text = "Selection";
            this.btnRunSel.UseVisualStyleBackColor = true;
            this.btnRunSel.Click += new System.EventHandler(this.BtnRunSelClick);
            // 
            // btnRunAll
            // 
            this.btnRunAll.Location = new System.Drawing.Point(13, 12);
            this.btnRunAll.Name = "btnRunAll";
            this.btnRunAll.Size = new System.Drawing.Size(75, 30);
            this.btnRunAll.TabIndex = 0;
            this.btnRunAll.Text = "Run all";
            this.btnRunAll.UseVisualStyleBackColor = true;
            this.btnRunAll.Click += new System.EventHandler(this.BtnRunAllClick);
            // 
            // txtScript
            // 
            this.txtScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScript.Location = new System.Drawing.Point(0, 0);
            this.txtScript.Multiline = true;
            this.txtScript.Name = "txtScript";
            this.txtScript.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtScript.Size = new System.Drawing.Size(391, 239);
            this.txtScript.TabIndex = 0;
            // 
            // tabResults
            // 
            this.tabResults.Controls.Add(this.richResults);
            this.tabResults.Location = new System.Drawing.Point(4, 4);
            this.tabResults.Name = "tabResults";
            this.tabResults.Size = new System.Drawing.Size(391, 294);
            this.tabResults.TabIndex = 3;
            this.tabResults.Text = "Results";
            this.tabResults.UseVisualStyleBackColor = true;
            // 
            // richResults
            // 
            this.richResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richResults.Location = new System.Drawing.Point(0, 0);
            this.richResults.Name = "richResults";
            this.richResults.Size = new System.Drawing.Size(391, 294);
            this.richResults.TabIndex = 0;
            this.richResults.Text = "";
            // 
            // tabTree
            // 
            this.tabTree.Controls.Add(this.tvUIAHierarchy);
            this.tabTree.Location = new System.Drawing.Point(4, 4);
            this.tabTree.Name = "tabTree";
            this.tabTree.Padding = new System.Windows.Forms.Padding(3);
            this.tabTree.Size = new System.Drawing.Size(391, 294);
            this.tabTree.TabIndex = 1;
            this.tabTree.Text = "Tree";
            this.tabTree.UseVisualStyleBackColor = true;
            // 
            // tvUIAHierarchy
            // 
            this.tvUIAHierarchy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvUIAHierarchy.Location = new System.Drawing.Point(3, 3);
            this.tvUIAHierarchy.Name = "tvUIAHierarchy";
            this.tvUIAHierarchy.Size = new System.Drawing.Size(385, 288);
            this.tvUIAHierarchy.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.fileToolStripMenuItem,
                                    this.editToolStripMenuItem,
                                    this.viewToolStripMenuItem,
                                    this.modeToolStripMenuItem,
                                    this.automationToolStripMenuItem,
                                    this.toolsToolStripMenuItem,
                                    this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(444, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.newToolStripMenuItem,
                                    this.openToolStripMenuItem,
                                    this.toolStripSeparator,
                                    this.saveToolStripMenuItem,
                                    this.saveAsToolStripMenuItem,
                                    this.toolStripSeparator3,
                                    this.printToolStripMenuItem,
                                    this.printPreviewToolStripMenuItem,
                                    this.toolStripSeparator4,
                                    this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(143, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.printToolStripMenuItem.Text = "&Print";
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(143, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.undoToolStripMenuItem,
                                    this.redoToolStripMenuItem,
                                    this.toolStripSeparator5,
                                    this.cutToolStripMenuItem,
                                    this.copyToolStripMenuItem,
                                    this.pasteToolStripMenuItem,
                                    this.toolStripSeparator6,
                                    this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(141, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(141, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.codeGenerationToolStripMenuItem,
                                    this.ancestryTreeToolStripMenuItem,
                                    this.propertiesToolStripMenuItem,
                                    this.toolStripSeparator1,
                                    this.scriptToolStripMenuItem,
                                    this.scriptResultsToolStripMenuItem,
                                    this.toolStripSeparator2,
                                    this.notImplementedToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // codeGenerationToolStripMenuItem
            // 
            this.codeGenerationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("codeGenerationToolStripMenuItem.Image")));
            this.codeGenerationToolStripMenuItem.Name = "codeGenerationToolStripMenuItem";
            this.codeGenerationToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.codeGenerationToolStripMenuItem.Text = "Code generation";
            this.codeGenerationToolStripMenuItem.Click += new System.EventHandler(this.CodeGenerationToolStripMenuItemClick);
            // 
            // ancestryTreeToolStripMenuItem
            // 
            this.ancestryTreeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ancestryTreeToolStripMenuItem.Image")));
            this.ancestryTreeToolStripMenuItem.Name = "ancestryTreeToolStripMenuItem";
            this.ancestryTreeToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.ancestryTreeToolStripMenuItem.Text = "Ancestry tree";
            this.ancestryTreeToolStripMenuItem.Click += new System.EventHandler(this.AncestryTreeToolStripMenuItemClick);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("propertiesToolStripMenuItem.Image")));
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.PropertiesToolStripMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(163, 6);
            // 
            // scriptToolStripMenuItem
            // 
            this.scriptToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("scriptToolStripMenuItem.Image")));
            this.scriptToolStripMenuItem.Name = "scriptToolStripMenuItem";
            this.scriptToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.scriptToolStripMenuItem.Text = "Script";
            this.scriptToolStripMenuItem.Click += new System.EventHandler(this.ScriptToolStripMenuItemClick);
            // 
            // scriptResultsToolStripMenuItem
            // 
            this.scriptResultsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("scriptResultsToolStripMenuItem.Image")));
            this.scriptResultsToolStripMenuItem.Name = "scriptResultsToolStripMenuItem";
            this.scriptResultsToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.scriptResultsToolStripMenuItem.Text = "Script results";
            this.scriptResultsToolStripMenuItem.Click += new System.EventHandler(this.ScriptResultsToolStripMenuItemClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(163, 6);
            // 
            // notImplementedToolStripMenuItem
            // 
            this.notImplementedToolStripMenuItem.Name = "notImplementedToolStripMenuItem";
            this.notImplementedToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.notImplementedToolStripMenuItem.Text = "not implemented";
            this.notImplementedToolStripMenuItem.Click += new System.EventHandler(this.NotImplementedToolStripMenuItemClick);
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.uIAutomationToolStripMenuItem,
                                    this.seleniumToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.modeToolStripMenuItem.Text = "Mode";
            // 
            // uIAutomationToolStripMenuItem
            // 
            this.uIAutomationToolStripMenuItem.Checked = true;
            this.uIAutomationToolStripMenuItem.CheckOnClick = true;
            this.uIAutomationToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.uIAutomationToolStripMenuItem.Name = "uIAutomationToolStripMenuItem";
            this.uIAutomationToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.uIAutomationToolStripMenuItem.Text = "UI Automation";
            this.uIAutomationToolStripMenuItem.Click += new System.EventHandler(this.UIAutomationToolStripMenuItemClick);
            // 
            // seleniumToolStripMenuItem
            // 
            this.seleniumToolStripMenuItem.CheckOnClick = true;
            this.seleniumToolStripMenuItem.Name = "seleniumToolStripMenuItem";
            this.seleniumToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.seleniumToolStripMenuItem.Text = "Selenium";
            this.seleniumToolStripMenuItem.Click += new System.EventHandler(this.SeleniumToolStripMenuItemClick);
            // 
            // automationToolStripMenuItem
            // 
            this.automationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.startRecordingToolStripMenuItem,
                                    this.stopRecorgingToolStripMenuItem,
                                    this.runScriptToolStripMenuItem,
                                    this.runSelectionToolStripMenuItem,
                                    this.breakScriptToolStripMenuItem});
            this.automationToolStripMenuItem.Name = "automationToolStripMenuItem";
            this.automationToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.automationToolStripMenuItem.Text = "Automation";
            // 
            // startRecordingToolStripMenuItem
            // 
            this.startRecordingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("startRecordingToolStripMenuItem.Image")));
            this.startRecordingToolStripMenuItem.Name = "startRecordingToolStripMenuItem";
            this.startRecordingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.startRecordingToolStripMenuItem.Text = "Start recording";
            this.startRecordingToolStripMenuItem.Click += new System.EventHandler(this.StartRecordingToolStripMenuItemClick);
            // 
            // stopRecorgingToolStripMenuItem
            // 
            this.stopRecorgingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("stopRecorgingToolStripMenuItem.Image")));
            this.stopRecorgingToolStripMenuItem.Name = "stopRecorgingToolStripMenuItem";
            this.stopRecorgingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.stopRecorgingToolStripMenuItem.Text = "Stop recorging";
            this.stopRecorgingToolStripMenuItem.Click += new System.EventHandler(this.StopRecorgingToolStripMenuItemClick);
            // 
            // runScriptToolStripMenuItem
            // 
            this.runScriptToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("runScriptToolStripMenuItem.Image")));
            this.runScriptToolStripMenuItem.Name = "runScriptToolStripMenuItem";
            this.runScriptToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.runScriptToolStripMenuItem.Text = "Run script";
            this.runScriptToolStripMenuItem.Click += new System.EventHandler(this.RunScriptToolStripMenuItemClick);
            // 
            // runSelectionToolStripMenuItem
            // 
            this.runSelectionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("runSelectionToolStripMenuItem.Image")));
            this.runSelectionToolStripMenuItem.Name = "runSelectionToolStripMenuItem";
            this.runSelectionToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.runSelectionToolStripMenuItem.Text = "Run selection";
            this.runSelectionToolStripMenuItem.Click += new System.EventHandler(this.RunSelectionToolStripMenuItemClick);
            // 
            // breakScriptToolStripMenuItem
            // 
            this.breakScriptToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("breakScriptToolStripMenuItem.Image")));
            this.breakScriptToolStripMenuItem.Name = "breakScriptToolStripMenuItem";
            this.breakScriptToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.breakScriptToolStripMenuItem.Text = "Break script";
            this.breakScriptToolStripMenuItem.Click += new System.EventHandler(this.BreakScriptToolStripMenuItemClick);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.customizeToolStripMenuItem,
                                    this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.customizeToolStripMenuItem.Text = "&Customize";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.contentsToolStripMenuItem,
                                    this.indexToolStripMenuItem,
                                    this.searchToolStripMenuItem,
                                    this.toolStripSeparator7,
                                    this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(119, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // SpyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 337);
            this.Controls.Add(this.tabOuter);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "SpyForm";
            this.Text = "UIAutomationSpy";
            this.Deactivate += new System.EventHandler(this.SpyFormDeactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SpyFormFormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SpyFormFormClosed);
            this.Load += new System.EventHandler(this.SpyFormLoad);
            this.Leave += new System.EventHandler(this.SpyFormLeave);
            this.Resize += new System.EventHandler(this.SpyFormResize);
            this.tabOuter.ResumeLayout(false);
            this.tabCode.ResumeLayout(false);
            this.tabInner.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabControl.PerformLayout();
            this.tabHierarchy.ResumeLayout(false);
            this.tabProperties.ResumeLayout(false);
            this.tabScript.ResumeLayout(false);
            this.splitContScript.Panel1.ResumeLayout(false);
            this.splitContScript.Panel2.ResumeLayout(false);
            this.splitContScript.Panel2.PerformLayout();
            this.splitContScript.ResumeLayout(false);
            this.tabResults.ResumeLayout(false);
            this.tabTree.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seleniumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uIAutomationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notImplementedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem scriptResultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem breakScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ancestryTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem codeGenerationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopRecorgingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startRecordingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem automationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.CheckBox chkTestCode;
        private System.Windows.Forms.TextBox txtFullCode;
        private System.Windows.Forms.TreeView tvwHierarhy;
        private System.Windows.Forms.RichTextBox richResults;
        private System.Windows.Forms.TextBox txtScript;
        private System.Windows.Forms.TabPage tabResults;
        private System.Windows.Forms.Button btnBreakPS;
        private System.Windows.Forms.Button btnRunAll;
        private System.Windows.Forms.Button btnRunSel;
        private System.Windows.Forms.SplitContainer splitContScript;
        private System.Windows.Forms.PropertyGrid pGridElement;
        private System.Windows.Forms.TabPage tabProperties;
        private System.Windows.Forms.TreeView tvUIAHierarchy;
        private System.Windows.Forms.TabPage tabScript;
        private System.Windows.Forms.RichTextBox richPatterns;
        private System.Windows.Forms.TabPage tabTree;
        private System.Windows.Forms.TabPage tabHierarchy;
        private System.Windows.Forms.TabPage tabControl;
        private System.Windows.Forms.TabControl tabInner;
        private System.Windows.Forms.TabPage tabCode;
        private System.Windows.Forms.TabControl tabOuter;
        private System.Windows.Forms.CheckBox chkClipboard;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.RichTextBox richControlCode;
        private System.Windows.Forms.Button btnStart;
        
    }
    
}
