/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/5/2014
 * Time: 1:06 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace UIAutomationTestForms
{
    partial class WinFormsWithMenus
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuLevel11ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLevel21ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLevel22ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLevel12ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.controlMenuLevel11ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlMenuLevel21ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlMenuLevel22ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlMenuLevel12ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.menuLevel11ToolStripMenuItem,
                                    this.menuLevel12ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(194, 48);
            // 
            // menuLevel11ToolStripMenuItem
            // 
            this.menuLevel11ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.menuLevel21ToolStripMenuItem,
                                    this.menuLevel22ToolStripMenuItem});
            this.menuLevel11ToolStripMenuItem.Name = "menuLevel11ToolStripMenuItem";
            this.menuLevel11ToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.menuLevel11ToolStripMenuItem.Text = "WindowMenuLevel1-1";
            // 
            // menuLevel21ToolStripMenuItem
            // 
            this.menuLevel21ToolStripMenuItem.Name = "menuLevel21ToolStripMenuItem";
            this.menuLevel21ToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.menuLevel21ToolStripMenuItem.Text = "WindowMenuLevel2-1";
            this.menuLevel21ToolStripMenuItem.Click += new System.EventHandler(this.MenuLevel21ToolStripMenuItemClick);
            // 
            // menuLevel22ToolStripMenuItem
            // 
            this.menuLevel22ToolStripMenuItem.Name = "menuLevel22ToolStripMenuItem";
            this.menuLevel22ToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.menuLevel22ToolStripMenuItem.Text = "WindowMenuLevel2-2";
            this.menuLevel22ToolStripMenuItem.Click += new System.EventHandler(this.MenuLevel22ToolStripMenuItemClick);
            // 
            // menuLevel12ToolStripMenuItem
            // 
            this.menuLevel12ToolStripMenuItem.Name = "menuLevel12ToolStripMenuItem";
            this.menuLevel12ToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.menuLevel12ToolStripMenuItem.Text = "WindowMenuLevel1-2";
            this.menuLevel12ToolStripMenuItem.Click += new System.EventHandler(this.MenuLevel12ToolStripMenuItemClick);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(245, 447);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(184, 121);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.ContextMenuStrip = this.contextMenuStrip2;
            this.panel1.Location = new System.Drawing.Point(337, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(361, 610);
            this.panel1.TabIndex = 2;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.controlMenuLevel11ToolStripMenuItem,
                                    this.controlMenuLevel12ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(190, 48);
            // 
            // controlMenuLevel11ToolStripMenuItem
            // 
            this.controlMenuLevel11ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.controlMenuLevel21ToolStripMenuItem,
                                    this.controlMenuLevel22ToolStripMenuItem});
            this.controlMenuLevel11ToolStripMenuItem.Name = "controlMenuLevel11ToolStripMenuItem";
            this.controlMenuLevel11ToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.controlMenuLevel11ToolStripMenuItem.Text = "ControlMenuLevel1-1";
            // 
            // controlMenuLevel21ToolStripMenuItem
            // 
            this.controlMenuLevel21ToolStripMenuItem.Name = "controlMenuLevel21ToolStripMenuItem";
            this.controlMenuLevel21ToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.controlMenuLevel21ToolStripMenuItem.Text = "ControlMenuLevel2-1";
            this.controlMenuLevel21ToolStripMenuItem.Click += new System.EventHandler(this.ControlMenuLevel21ToolStripMenuItemClick);
            // 
            // controlMenuLevel22ToolStripMenuItem
            // 
            this.controlMenuLevel22ToolStripMenuItem.Name = "controlMenuLevel22ToolStripMenuItem";
            this.controlMenuLevel22ToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.controlMenuLevel22ToolStripMenuItem.Text = "ControlMenuLevel2-2";
            this.controlMenuLevel22ToolStripMenuItem.Click += new System.EventHandler(this.ControlMenuLevel22ToolStripMenuItemClick);
            // 
            // controlMenuLevel12ToolStripMenuItem
            // 
            this.controlMenuLevel12ToolStripMenuItem.Name = "controlMenuLevel12ToolStripMenuItem";
            this.controlMenuLevel12ToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.controlMenuLevel12ToolStripMenuItem.Text = "ControlMenuLevel1-2";
            this.controlMenuLevel12ToolStripMenuItem.Click += new System.EventHandler(this.ControlMenuLevel12ToolStripMenuItemClick);
            // 
            // WinFormsWithMenus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 609);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.panel1);
            this.Name = "WinFormsWithMenus";
            this.Text = "WinFormsWithMenus";
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.ToolStripMenuItem controlMenuLevel12ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlMenuLevel22ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlMenuLevel21ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlMenuLevel11ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripMenuItem menuLevel12ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuLevel22ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuLevel21ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuLevel11ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}
