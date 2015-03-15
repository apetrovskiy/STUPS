/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08.12.2011
 * Time: 9:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTestForms
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Description of WinFormsEmpty.
    /// </summary>
    public partial class WinFormsEmpty : WinFormsForm // Form
    {
//        public WinFormsEmpty(
//            System.Windows.Automation.ControlType controlType,
//            int controlDelay)
//        {
//            this.ControlType = controlType;
//            this.ControlDelay = controlDelay;
//            base.ChildForm = this;
//            //  // The InitializeComponent() call is required for Windows Forms designer support.
//            // 
//            InitializeComponent();
//            
//            //  // TODO: Add constructor code after the InitializeComponent() call.
//            // 
//        }

        public WinFormsEmpty(
            System.Windows.Automation.ControlType controlType,
            int controlDelay) : base ("WinFormsEmpty", "WinFormsEmpty", controlType, controlDelay)
        {
            base.ChildForm = this;
        }
        
        public WinFormsEmpty(
            System.Windows.Automation.ControlType controlType,
            string controlName,
            string controlAutomationId,
            int controlDelay) : base ("WinFormsEmpty", "WinFormsEmpty", controlType, controlName, controlAutomationId, controlDelay)
        {
            base.ChildForm = this;
        }
        
        public WinFormsEmpty(
            ControlToForm[] controls) : base ("WinFormsEmpty", "WinFormsEmpty", controls)
        {
            base.ChildForm = this;
        }
    }
}
