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
    using System.Collections;

    /// <summary>
    /// Description of AddUIAWizardStepCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "UIAWizardStep")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class AddUIAWizardStepCommand : WizardConstructionCmdletBase
    //internal class AddUIAWizardStepCommand : WizardCmdletBase
    {
        public AddUIAWizardStepCommand()
        {
        }
        
        #region Parameters
// [Parameter(Mandatory = true,
// ValueFromPipeline = true)]
// public Wizard InputObject { get; set; }
        [Parameter(Mandatory = false)]
        //public System.Collections.Hashtable[] SearchCriteria { get; set; }
        public Hashtable[] SearchCriteria { get; set; }
        [Parameter(Mandatory = false)]
        public ScriptBlock[] StepForwardAction { get; set; }
        [Parameter(Mandatory = false)]
        public ScriptBlock[] StepBackwardAction { get; set; }
        [Parameter(Mandatory = false)]
        public int Order { get; set; }
        #endregion Parameters
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            UIAAddWizardStepCommand command =
                new UIAAddWizardStepCommand(this);
            command.Execute();
            
            
//            if (InputObject != null && InputObject is Wizard) {
//                WizardStep step = new WizardStep(Name, Order);
//                if (SearchCriteria != null && SearchCriteria.Length > 0) {
//                    WriteVerbose(this, "adding search criteria");
//                    step.SearchCriteria = SearchCriteria;
//                }
//                if (StepForwardAction != null && StepForwardAction.Length > 0) {
//                    WriteVerbose(this, "adding step forward actions");
//                    step.StepForwardAction = StepForwardAction;
//                }
//                if (StepBackwardAction != null && StepBackwardAction.Length > 0) {
//                    WriteVerbose(this, "adding step backward actions");
//                    step.StepBackwardAction = StepBackwardAction;
//                }
//                WriteVerbose(this, "adding the step");
//                InputObject.Steps.Add(step);
//                if (PassThru) {
//                    WriteObject(this, InputObject);
//                } else {
//                    WriteObject(this, true);
//                }
//            } else {
////                ErrorRecord err = 
////                    new ErrorRecord(
////                        new Exception("The wizard object you provided is not valid"),
////                        "WrongWizardObject",
////                        ErrorCategory.InvalidArgument,
////                        InputObject);
////                err.ErrorDetails = 
////                    new ErrorDetails(
////                        "The wizard object you provided is not valid");
////                WriteError(this, err, true);
//                
//                this.WriteError(
//                    this,
//                    "The wizard object you provided is not valid",
//                    "WrongWizardObject",
//                    ErrorCategory.InvalidArgument,
//                    true);
//            }
        }
        
    }
}
