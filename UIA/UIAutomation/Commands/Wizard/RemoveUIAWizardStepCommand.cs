/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08/02/2012
 * Time: 02:30 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of RemoveUIAWizardStepCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "UIAWizardStep")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class RemoveUIAWizardStepCommand : WizardStepCmdletBase //WizardConstructionCmdletBase
    //internal class RemoveUIAWizardStepCommand : WizardCmdletBase
    {
        public RemoveUIAWizardStepCommand()
        {
        }
        
        
        #region Parameters
// [Parameter]
// public string Name { get; set; }
        #endregion Parameters
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            UIARemoveWizardStepCommand command =
                new UIARemoveWizardStepCommand(this);
            command.Execute();
            
//            if (InputObject != null && InputObject is Wizard) {
//                WizardStep stepToRemove = null;
//                foreach (WizardStep step in InputObject.Steps) {
//                    if (step.Name == Name) {
//                        stepToRemove = step;
//                    }
//                }
//                InputObject.Steps.Remove(stepToRemove);
//                if (PassThru) {
//                    WriteObject(this, InputObject);
//                } else {
//                    WriteObject(this, true);
//                }
//            } else {
//                ErrorRecord err = 
//                    new ErrorRecord(
//                        new Exception("The wizard object you provided is not valid"),
//                        "WrongWizardObject",
//                        ErrorCategory.InvalidArgument,
//                        InputObject);
//                err.ErrorDetails = 
//                    new ErrorDetails(
//                        "The wizard object you provided is not valid");
//                WriteError(this, err, true);
//            }
//        // WizardStep step = new WizardStep(Name, Order);
//        // if (SearchCriteria != null && SearchCriteria.Length > 0) {
        }
    }
}
