/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/23/2012
 * Time: 12:32 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of GetUIAWizardCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAWizard")]
    public class GetUIAWizardCommand : WizardContainerCmdletBase
    {
        public GetUIAWizardCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            UIAGetWizardCommand command =
                new UIAGetWizardCommand(this);
            command.Execute();
            
//            Wizard wzd = GetWizard(Name);
//            if (wzd != null) {
//
//                WriteObject(this, wzd);
//
//            } else {
//                ErrorRecord err = 
//                    new ErrorRecord(
//                        new Exception("Can't get the wizard you asked for"),
//                        "NoWizard",
//                        ErrorCategory.InvalidArgument,
//                        Name);
//                err.ErrorDetails = 
//                    new ErrorDetails(
//                        "Failed to get the wizard you asked for");
//
//                //ThrowTerminatingError(err);
//                this.WriteError(this, err, true);
//
//            }

        }
    }
}
