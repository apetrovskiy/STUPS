/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/25/2013
 * Time: 8:21 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTestForms
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Description of WinFormsTripled.
    /// </summary>
    public partial class WinFormsTripled : WinFormsForm //Form
    {
//        public WinFormsTripled()
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
        
        private ControlToForm[] neededControls = null;
        
        public WinFormsTripled(
            System.Windows.Automation.ControlType controlType,
            int controlDelay) : base ("WinFormsTripled", "WinFormsTripled", controlType, controlDelay)
        {
            base.ChildForm = this;
        }
        
        public WinFormsTripled(
            System.Windows.Automation.ControlType controlType,
            string controlName,
            string controlAutomationId,
            int controlDelay) : base ("WinFormsTripled", "WinFormsTripled", controlType, controlName, controlAutomationId, controlDelay)
        {
            base.ChildForm = this;
        }
        
        public WinFormsTripled(
            ControlToForm[] controls) : base ("WinFormsTripled", "WinFormsTripled", controls)
        {
            base.ChildForm = this;
            
            this.neededControls = controls;
        }
        
        
        
//        void WinFormsTripledLoad(object sender, EventArgs e)
//        {
//            WinFormsSecond secondForm =
//                new WinFormsSecond(this.neededControls);
//            secondForm.Show();
//        }
        
//        void WinFormsTripledShown(object sender, System.EventArgs e)
//        {
//            WinFormsSecond secondForm =
//                new WinFormsSecond(this.neededControls);
//            secondForm.Show();
//        }
        
//        void WinFormsTripledControlAdded(object sender, System.Windows.Forms.ControlEventArgs e)
//        {
//            WinFormsSecond secondForm =
//                new WinFormsSecond(this.neededControls);
//            secondForm.Show();
//        }
        
        void btnSecondFormClick(object sender, System.EventArgs e)
        {
            WinFormsSecond secondForm =
                new WinFormsSecond(this.neededControls);
            secondForm.Show();
        }
    }
}
