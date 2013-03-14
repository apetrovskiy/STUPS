/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08/02/2012
 * Time: 02:29 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of NewUIAWizardCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "UIAWizard")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class NewUIAWizardCommand : WizardContainerCmdletBase
    //internal class NewUIAWizardCommand : WizardCmdletBase
    {
        public NewUIAWizardCommand()
        {
        }
        
        
        #region Parameters
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ScriptBlock[] StartAction { get; set; }
        [Parameter(Mandatory = false)]
        internal int Order { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            UIANewWizardCommand command =
                new UIANewWizardCommand(this);
            command.Execute();
            
//            if (!ValidateWizardName(Name)) {
//                ErrorRecord err = 
//                    new ErrorRecord(
//                        new Exception("The wizard name you selected is already in use"),
//                        "NameInUse",
//                        ErrorCategory.InvalidArgument,
//                        this.Name);
//                err.ErrorDetails = 
//                    new ErrorDetails(
//                        "The wizard name you selected is already in use");
//                //ThrowTerminatingError(err);
//                this.WriteError(this, err, true);
//            }
//            this.WriteVerbose(this, "wizard name validated");
//            Wizard wzd = new Wizard(Name);
//            this.WriteVerbose(this, "wizard object created");
//            if (StartAction != null && StartAction.Length > 0) {
//                wzd.StartAction = StartAction;
//            }
//            this.WriteObject(this, wzd);
        }
        
    }
}
