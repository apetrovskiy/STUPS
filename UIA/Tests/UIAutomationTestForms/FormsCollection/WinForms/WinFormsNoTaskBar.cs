/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08.12.2011
 * Time: 9:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTestForms
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Description of WinFormsNoTaskBar.
    /// </summary>
    public partial class WinFormsNoTaskBar : WinFormsForm // Form
    {
//        public WinFormsNoTaskBar(
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

        public WinFormsNoTaskBar(
            System.Windows.Automation.ControlType controlType,
            int controlDelay) : base ("WinFormsNoTaskBar", "WinFormsNoTaskBar", controlType, controlDelay)
        {
            base.ChildForm = this;
        }
        
        public WinFormsNoTaskBar(
            System.Windows.Automation.ControlType controlType,
            string controlName,
            string controlAutomationId,
            int controlDelay) : base ("WinFormsNoTaskBar", "WinFormsNoTaskBar", controlType, controlName, controlAutomationId, controlDelay)
        {
            base.ChildForm = this;
        }
        
        public WinFormsNoTaskBar(
            ControlToForm[] controls) : base ("WinFormsNoTaskBar", "WinFormsNoTaskBar", controls)
        {
            base.ChildForm = this;
        }
    }
}
