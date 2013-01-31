/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 01/12/2011
 * Time: 12:36 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    using System.Runtime.InteropServices;
    
    // 20120823
    using System.Windows.Automation;
    
    /// <summary>
    /// Description of SetUIAFocusCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAFocus")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIAFocusCommand : HasControlInputCmdletBase
    {
        #region Constructor
        public SetUIAFocusCommand()
        {
        }
        #endregion Constructor
        
        #region Parameters
        #endregion Parameters
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            // if (!this.CheckControl(this)) { return; }
            if (!this.CheckControl(this)) { return; }
            
            // 20120823
            foreach (AutomationElement inputObject in this.InputObject) {

                try {
                    inputObject.SetFocus();
                }
                catch (Exception eSetFocus) {
                    this.WriteError(
                        this,
                        "Could not set focus. " +
                        eSetFocus.Message,
                        "FailedToSetFocus",
                        ErrorCategory.InvalidOperation,
                        true);
                }
                if (this.PassThru) {
                    // 20130105
                    //this.WriteObject(this, this.InputObject);
                    this.WriteObject(this, inputObject);
                } else {
                    this.WriteObject(this, true);
                }
            
            } // 20120823

        }
    }
}
