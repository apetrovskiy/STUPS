/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/20/2012
 * Time: 7:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTestForms.FormsCollection.WinForms
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Description of WinFormsFull.
    /// </summary>
    public partial class WinFormsFull : Form
    {
        public WinFormsFull()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }
        
        void ToolStrip2ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }
        
        void Button1Click(object sender, EventArgs e)
        {
            // 20120830
            //this.listBox1.Items.Clear();
            this.listBox1.Items.Add("Invoked");
        }
        
        void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.listBox1.Items.Clear();
            this.listBox1.Items.Add("Invoked");
            this.listBox1.Items.Add("LinkClicked");
        }
        
        void TabPage2Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            this.listBox1.Items.Add("Invoked");
        }
        
        void ListBox1SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.listBox1.Items.Clear();
        }
        
        void ToolStripSplitButton2ButtonClick(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            this.listBox1.Items.Add("Invoked");
        }
        
        void LinkLabel1Click(object sender, EventArgs e)
        {
            //this.listBox1.Items.Clear();
            this.listBox1.Items.Add("Invoked");
            this.listBox1.Items.Add("Click");
        }
        
        void TabControl1Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            this.listBox1.Items.Add("Invoked");
            this.listBox1.Items.Add("Click");
        }
        
        void TreeView1AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.listBox1.Items.Clear();
            this.listBox1.Items.Add("Invoked");
            this.listBox1.Items.Add("AfterSelect");
        }
        
        void TreeView1Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            this.listBox1.Items.Add("Invoked");
            this.listBox1.Items.Add("Click");
        }
        
        void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.listBox1.Items.Clear();
        }
        
        void CheckBox1CheckedChanged(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            if (this.checkBox1.Checked) {
                this.listBox1.Items.Add("Checked");
            } else {
                this.listBox1.Items.Add("Unchecked");
            }
        }
        
        void CheckBox1Click(object sender, EventArgs e)
        {
            //this.listBox1.Items.Clear();
            if (this.checkBox1.Checked) {
                this.listBox1.Items.Add("Clicked");
            } else {
                this.listBox1.Items.Add("Unclicked");
            }
        }
        
        void CheckedListBox1SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            //this.listBox1.Items.Add((object)sender.ToString());
            this.listBox1.Items.Add("SelectedIndexChanged");
        }
        
        void CheckedListBox1Click(object sender, EventArgs e)
        {
            //this.listBox1.Items.Clear();
            this.listBox1.Items.Add("Clicked");
            
            
            
            this.listBox1.Items.Add(sender.ToString().Substring(21));
            this.Text = sender.ToString().Substring(21);
        }
        
        void CheckedListBox1ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //this.listBox1.Items.Clear();
            this.listBox1.Items.Add("Checked");
            //this.listBox1.Items.Add(sender.ToString().Substring(21));
            this.label1.Text = sender.ToString().Substring(21);
            //this.Text = sender.ToString().Substring(21);
            //this.listBox1.Items.Add(sender.GetType().Name.Substring(21));
        }
        
        void Button2Click(object sender, EventArgs e)
        {
            int label2Left = this.label2.Left;
            this.label2.Left = -10000;
            int radio2Left = this.radioButton2.Left;
            this.radioButton2.Left = -10000;
            int domain2Left = this.domainUpDown2.Left;
            this.domainUpDown2.Left = -10000;
            System.Threading.Thread.Sleep(2000);
            this.label2.Left = label2Left;
            this.radioButton2.Left = radio2Left;
            this.domainUpDown2.Left = domain2Left;
            this.label2.Enabled = true;
            this.radioButton2.Enabled = true;
            this.domainUpDown2.Enabled = true;
            
            // for testing double Invoke
            //this.listBox1.Items.Clear();
            this.listBox1.Items.Add("Invoked2");
        }
    }
}
