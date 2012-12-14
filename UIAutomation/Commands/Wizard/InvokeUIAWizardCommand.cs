/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/23/2012
 * Time: 3:16 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of InvokeUIAWizardCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAWizard")]
    public class InvokeUIAWizardCommand : WizardRunCmdletBase
    {
        public InvokeUIAWizardCommand()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        internal new Wizard InputObject { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            Wizard wzd = GetWizard(Name);
            if (wzd == null) {
                ErrorRecord err = 
                    new ErrorRecord(
                        new Exception("Couldn't get the wizard you asked for"),
                        "NoSuchWizard",
                        ErrorCategory.InvalidArgument,
                        Name);
                err.ErrorDetails = 
                    new ErrorDetails(
                        "Failed to get the wizard you asked for");
                //ThrowTerminatingError(err);
                this.WriteError(this, err, true);
            } else {
                this.WriteVerbose(this, "running script blocks");
                RunWizardScriptBlocks(this, wzd);
                //if (PassThru) {
                this.WriteObject(this, wzd);
                //} else {
                // WriteObject(this, true);
                //}
            }
        }
    }
}
