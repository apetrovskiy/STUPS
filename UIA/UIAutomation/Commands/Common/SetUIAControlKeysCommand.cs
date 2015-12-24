/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/26/2012
 * Time: 12:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Windows.Forms;

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of SetUiaControlKeysCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaControlKeys")]
    public class SetUiaControlKeysCommand : HasControlInputCmdletBase
    {
        #region Parameters
        [UiaParameter][Parameter(Mandatory = true,
                   Position = 0)]
        [AllowEmptyString]
        public string Text { get; set; }
//        [UiaParameterNotUsed][Parameter(Mandatory = false)]
//        public SwitchParameter RightClick { get; set; }
//        [UiaParameterNotUsed][Parameter(Mandatory = false)]
//        public SwitchParameter MidClick { get; set; }
//        [UiaParameterNotUsed][Parameter(Mandatory = false)]
//        public SwitchParameter Alt { get; set; }
//        [UiaParameterNotUsed][Parameter(Mandatory = false)]
//        public SwitchParameter Shift { get; set; }
//        [UiaParameterNotUsed][Parameter(Mandatory = false)]
//        public SwitchParameter Ctrl { get; set; }
//        [UiaParameterNotUsed][Parameter(Mandatory = false)]
//        public SwitchParameter DoubleClick { get; set; }
//        [UiaParameterNotUsed][Parameter(Mandatory = false)]
//        public int X { get; set; }
//        [UiaParameterNotUsed][Parameter(Mandatory = false)]
//        public int Y { get; set; }
//        [UiaParameterNotUsed][Parameter(Mandatory = false)]
//        public SwitchParameter Wait { get; set; }
        #endregion Parameters
        
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!CheckAndPrepareInput(this)) { return; }
            
            foreach (IUiElement inputObject in InputObject) {
                
                try {
                    SendKeys.SendWait(Text);
                    WriteObject(this, true);
                }
                catch (Exception) {
                    // 20131216 
    //                ErrorRecord err = 
    //                    new ErrorRecord(
    //                        new Exception("Failed to send keys to a control"),
    //                        "SendKeysFailed",
    //                        ErrorCategory.InvalidResult,
    //                        null);
    //                string controlName = string.Empty;
    //                try {
    //                    controlName = inputObject.Current.Name;
    //                }
    //                catch {}
    //                err.ErrorDetails = 
    //                    new ErrorDetails(
    //                        "Failed to send keys to " + 
    //                        controlName + 
    //                        "\r\n" + 
    //                        eKeys.Message);
    //                WriteError(this, err, true);
                    
                    WriteError(
                        this,
                        "Failed to send keys to a control",
                        "SendKeysFailed",
                        ErrorCategory.InvalidResult,
                        true);
                }
                
            } // 20120823

        }
    }
}
