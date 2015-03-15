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
    /// Description of WinFormsAnonymous.
    /// </summary>
    public partial class WinFormsAnonymous : WinFormsForm // Form
    {
//        public WinFormsAnonymous(
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

        public WinFormsAnonymous(
            System.Windows.Automation.ControlType controlType,
            int controlDelay) : base ("WinFormsAnonymous", "", controlType, controlDelay)
        {
            base.ChildForm = this;
        }
        
        public WinFormsAnonymous(
            System.Windows.Automation.ControlType controlType,
            string controlName,
            string controlAutomationId,
            int controlDelay) : base ("WinFormsAnonymous", "", controlType, controlName, controlAutomationId, controlDelay)
        {
            base.ChildForm = this;
        }
        
        public WinFormsAnonymous(
            ControlToForm[] controls) : base ("WinFormsAnonymous", "WinFormsAnonymous", controls)
        {
            base.ChildForm = this;
        }
    }
}
