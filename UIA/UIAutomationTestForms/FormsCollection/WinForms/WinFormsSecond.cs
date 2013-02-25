/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/25/2013
 * Time: 10:22 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTestForms
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Description of WinFormsSecond.
    /// </summary>
    public partial class WinFormsSecond : WinFormsForm
    {
//        public WinFormsSecond()
//        {
//            //
//            // The InitializeComponent() call is required for Windows Forms designer support.
//            //
//            InitializeComponent();
//            
//            //
//            // TODO: Add constructor code after the InitializeComponent() call.
//            //
//        }
        
        public WinFormsSecond(
            System.Windows.Automation.ControlType controlType,
            int controlDelay) : base ("WinFormsSecond", "WinFormsSecond", controlType, controlDelay)
        {
            base.ChildForm = this;
        }
        
        public WinFormsSecond(
            System.Windows.Automation.ControlType controlType,
            string controlName,
            string controlAutomationId,
            int controlDelay) : base ("WinFormsSecond", "WinFormsSecond", controlType, controlName, controlAutomationId, controlDelay)
        {
            base.ChildForm = this;
        }
        
        public WinFormsSecond(
            ControlToForm[] controls) : base ("WinFormsSecond", "WinFormsSecond", controls)
        {
            base.ChildForm = this;
        }
    }
}
