/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 3/15/2013
 * Time: 11:56 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    using UIAutomation.Commands;
    
    /// <summary>
    /// Description of UIAAddWizardStepCommand.
    /// </summary>
    internal class UIAAddWizardStepCommand : UIACommand
    {
        internal UIAAddWizardStepCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            AddUIAWizardStepCommand cmdlet =
                (AddUIAWizardStepCommand)this.Cmdlet;
            
            //if (InputObject != null && InputObject is Wizard) {
            if (null != cmdlet.InputObject && cmdlet.InputObject is Wizard) {
                //WizardStep step = new WizardStep(Name, Order);
                WizardStep step = new WizardStep(cmdlet.Name, cmdlet.Order);
                //if (SearchCriteria != null && SearchCriteria.Length > 0) {
                if (null != cmdlet.SearchCriteria && 0 < cmdlet.SearchCriteria.Length) {
                    //WriteVerbose(this, "adding search criteria");
                    cmdlet.WriteVerbose(cmdlet, "adding search criteria");
                    //step.SearchCriteria = SearchCriteria;
                    step.SearchCriteria = cmdlet.SearchCriteria;
                }
                //if (StepForwardAction != null && StepForwardAction.Length > 0) {
                if (null != cmdlet.StepForwardAction && 0 < cmdlet.StepForwardAction.Length) {
                    //WriteVerbose(this, "adding step forward actions");
                    cmdlet.WriteVerbose(cmdlet, "adding step forward actions");
                    //step.StepForwardAction = StepForwardAction;
                    step.StepForwardAction = cmdlet.StepForwardAction;
                }
                //if (StepBackwardAction != null && StepBackwardAction.Length > 0) {
                if (null != cmdlet.StepBackwardAction && 0 < cmdlet.StepBackwardAction.Length) {
                    //WriteVerbose(this, "adding step backward actions");
                    cmdlet.WriteVerbose(cmdlet, "adding step backward actions");
                    //step.StepBackwardAction = StepBackwardAction;
                    step.StepBackwardAction = cmdlet.StepBackwardAction;
                }
                //WriteVerbose(this, "adding the step");
                cmdlet.WriteVerbose(cmdlet, "adding the step");
                //InputObject.Steps.Add(step);
                cmdlet.InputObject.Steps.Add(step);
                //if (PassThru) {
                if (cmdlet.PassThru) {
                    //WriteObject(this, InputObject);
                    cmdlet.WriteObject(cmdlet, cmdlet.InputObject);
                } else {
                    //WriteObject(this, true);
                    cmdlet.WriteObject(cmdlet, true);
                }
            } else {
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
                
                //this.WriteError(
                cmdlet.WriteError(
                    //this,
                    cmdlet,
                    "The wizard object you provided is not valid",
                    "WrongWizardObject",
                    ErrorCategory.InvalidArgument,
                    true);
            }
        }
    }
}
