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
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Description of WinFormsWithMenus.
    /// </summary>
    public partial class WinFormsWithMenus : Form // WinFormsForm
    {
        public WinFormsWithMenus()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }
        
//        public WinFormsWithMenus(
//            System.Windows.Automation.ControlType controlType,
//            int controlDelay) : base ("WinFormsWithMenus", "WinFormsWithMenus", controlType, controlDelay)
//        {
//            base.ChildForm = this;
//        }
//        
//        public WinFormsWithMenus(
//            System.Windows.Automation.ControlType controlType,
//            string controlName,
//            string controlAutomationId,
//            int controlDelay) : base ("WinFormsWithMenus", "WinFormsWithMenus", controlType, controlName, controlAutomationId, controlDelay)
//        {
//            base.ChildForm = this;
//        }
//        
//        public WinFormsWithMenus(
//            ControlToForm[] controls) : base ("WinFormsWithMenus", "WinFormsWithMenus", controls)
//        {
//            base.ChildForm = this;
//        }
        
        void MenuLevel12ToolStripMenuItemClick(object sender, EventArgs e)
        {
            listBox1.Items.Add("WindowMenuLevel1-2");
        }
        
        void ListBox1SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        
        void MenuLevel21ToolStripMenuItemClick(object sender, EventArgs e)
        {
            listBox1.Items.Add("WindowMenuLevel2-1");
        }
        
        void MenuLevel22ToolStripMenuItemClick(object sender, EventArgs e)
        {
            listBox1.Items.Add("WindowMenuLevel2-2");
        }
        
        void ControlMenuLevel12ToolStripMenuItemClick(object sender, EventArgs e)
        {
            listBox1.Items.Add("ControlMenuLevel1-2");
        }
        
        void ControlMenuLevel21ToolStripMenuItemClick(object sender, EventArgs e)
        {
            listBox1.Items.Add("ControlMenuLevel2-1");
        }
        
        void ControlMenuLevel22ToolStripMenuItemClick(object sender, EventArgs e)
        {
            listBox1.Items.Add("ControlMenuLevel2-2");
        }
    }
}
