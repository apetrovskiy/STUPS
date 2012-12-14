/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08.12.2011
 * Time: 9:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTestForms
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Description of WinFormsRich.
    /// </summary>
    public partial class WinFormsRich : Form // : WinFormsForm // Form
    {
//        public WinFormsRich(
//            System.Windows.Automation.ControlType controlType,
//            int controlDelay)
//        {
//            this.ControlType = controlType;
//            this.ControlDelay = controlDelay;
//            //  // The InitializeComponent() call is required for Windows Forms designer support.
//            // 
//            InitializeComponent();
//            
//            //  // TODO: Add constructor code after the InitializeComponent() call.
//            // 
//        }

        public WinFormsRich()
        {
            InitializeComponent();
        }

//        public WinFormsRich(
//            System.Windows.Automation.ControlType controlType,
//            int controlDelay) : base ("WinFormsRich", "WinFormsRich", controlType, controlDelay)
//        {
//            base.ChildForm = this;
//        }
//        
//        public WinFormsRich(
//            System.Windows.Automation.ControlType controlType,
//            string controlName,
//            string controlAutomationId,
//            int controlDelay) : base ("WinFormsRich", "WinFormsRich", controlType, controlName, controlAutomationId, controlDelay)
//        {
//            base.ChildForm = this;
//        }
//        
//        public WinFormsRich(
//            ControlToForm[] controls) : base ("WinFormsRich", "WinFormsRich", controls)
//        {
//            base.ChildForm = this;
//        }  
        
        void CheckBox2CheckedChanged(object sender, EventArgs e)
        {
            
        }
        
        void RadioButton3CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
