/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08.12.2011
 * Time: 9:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTestForms
{
    /// <summary>
    /// Description of WinFormsMaximized.
    /// </summary>
    public partial class WinFormsMaximized : WinFormsForm // Form
    {
//        public WinFormsMaximized(
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

        public WinFormsMaximized(
            System.Windows.Automation.ControlType controlType,
            int controlDelay) : base ("WinFormsMaximized", "WinFormsMaximized", controlType, controlDelay)
        {
            ChildForm = this;
        }
        
        public WinFormsMaximized(
            System.Windows.Automation.ControlType controlType,
            string controlName,
            string controlAutomationId,
            int controlDelay) : base ("WinFormsMaximized", "WinFormsMaximized", controlType, controlName, controlAutomationId, controlDelay)
        {
            ChildForm = this;
        }
        
        public WinFormsMaximized(
            ControlToForm[] controls) : base ("WinFormsMaximized", "WinFormsMaximized", controls)
        {
            ChildForm = this;
        }        
    }
}
