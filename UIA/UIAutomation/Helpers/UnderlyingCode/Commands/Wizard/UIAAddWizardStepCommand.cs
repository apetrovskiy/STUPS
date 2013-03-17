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
            

            WizardHelper.AddWizardStep(cmdlet);
        }



        //if (null != cmdlet.SearchCriteria && 0 < cmdlet.SearchCriteria.Length) {
//
        //    cmdlet.WriteVerbose(cmdlet, "adding search criteria");
        //}

        //if (null != cmdlet.StepForwardAction && 0 < cmdlet.StepForwardAction.Length) {
//
        //    cmdlet.WriteVerbose(cmdlet, "adding step forward actions");
        //}

        //if (null != cmdlet.StepBackwardAction && 0 < cmdlet.StepBackwardAction.Length) {
//
        //    cmdlet.WriteVerbose(cmdlet, "adding step backward actions");
        //}


//        void AddWizardStep(AddUIAWizardStepCommand cmdlet)
//        {
//            if (null != cmdlet.InputObject && cmdlet.InputObject is Wizard) {
//                WizardStep step = new WizardStep(cmdlet.Name, cmdlet.Order);
//                step.SearchCriteria = cmdlet.SearchCriteria;
//                step.StepForwardAction = cmdlet.StepForwardAction;
//                step.StepBackwardAction = cmdlet.StepBackwardAction;
//                step.StepCancelAction = cmdlet.StepCancelAction;
//                step.StepGetWindowAction = cmdlet.StepGetWindowAction;
//                cmdlet.WriteVerbose(cmdlet, "adding the step");
//                // 20130317
//                step.Parent = cmdlet.InputObject;
//
//                cmdlet.InputObject.Steps.Add(step);
//
//                if (cmdlet.PassThru) {
//
//                    cmdlet.WriteObject(cmdlet, cmdlet.InputObject);
//                } else {
//
//                    cmdlet.WriteObject(cmdlet, true);
//                }
//            } else {
//
//                cmdlet.WriteError(cmdlet, "The wizard object you provided is not valid", "WrongWizardObject", ErrorCategory.InvalidArgument, true);
//            }
//        }
    }
}
