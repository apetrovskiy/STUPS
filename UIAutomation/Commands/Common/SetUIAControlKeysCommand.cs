/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/26/2012
 * Time: 12:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    
    // 20120823
    using System.Windows.Automation;
    
    
    /// <summary>
    /// Description of SetUIAControlKeysCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAControlKeys")]
    public class SetUIAControlKeysCommand : HasControlInputCmdletBase
    {
        public SetUIAControlKeysCommand()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   Position = 0)]
        [AllowEmptyString]
        public string Text { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter RightClick { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter MidClick { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter Alt { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter Shift { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter Ctrl { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter DoubleClick { get; set; }
//        [Parameter(Mandatory = false)]
//        public int X { get; set; }
//        [Parameter(Mandatory = false)]
//        public int Y { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter Wait { get; set; }
        #endregion Parameters
        
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!this.CheckControl(this)) { return; }
            
            // 20120823
            foreach (AutomationElement inputObject in this.InputObject) {

            try {
                System.Windows.Forms.SendKeys.SendWait(this.Text);
                this.WriteObject(this, true);
            }
            catch (Exception eKeys) {
                ErrorRecord err = 
                    new ErrorRecord(
                        new Exception("Failed to send keys to a control"),
                        "SendKeysFailed",
                        ErrorCategory.InvalidResult,
                        null);
                string controlName = string.Empty;
                try {
                    // 20120823
                    //controlName = this.InputObject.Current.Name;
                    controlName = inputObject.Current.Name;
                }
                catch {}
                err.ErrorDetails = 
                    new ErrorDetails(
                        "Failed to send keys to " + 
                        controlName + 
                        "\r\n" + 
                        eKeys.Message);
                this.WriteError(this, err, true);
            }

            } // 20120823

        }
    }
}
