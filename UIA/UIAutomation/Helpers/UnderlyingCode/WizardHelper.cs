/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 3/17/2013
 * Time: 7:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    
    /// <summary>
    /// Description of WizardHelper.
    /// </summary>
    public static class WizardHelper
    {
        static WizardHelper()
        {
        }
        
        public static void CreateWizard(WizardContainerCmdletBase cmdlet)
        {
            if (!cmdlet.ValidateWizardName(cmdlet.Name)) {
                cmdlet.WriteError(cmdlet, "The wizard name you selected is already in use", "NameInUse", ErrorCategory.InvalidArgument, true);
                // return;
            }
            
            cmdlet.WriteVerbose(cmdlet, "wizard name validated");
            Wizard wzd = new Wizard(cmdlet.Name);
            cmdlet.WriteVerbose(cmdlet, "wizard object created");
            wzd.StartAction = cmdlet.StartAction;
            wzd.StopAction = cmdlet.StopAction;
            wzd.DefaultStepForwardAction = cmdlet.DefaultStepForwardAction;
            wzd.DefaultStepBackwardAction = cmdlet.DefaultStepBackwardAction;
            wzd.DefaultStepCancelAction = cmdlet.DefaultStepCancelAction;
            wzd.DefaultStepGetWindowAction = cmdlet.DefaultStepGetWindowAction;

            cmdlet.WriteObject(cmdlet, wzd);
        }
        
        public static void AddWizardStep(WizardConstructionCmdletBase cmdlet)
        {
            if (null != cmdlet.InputObject && cmdlet.InputObject is Wizard) {
                WizardStep step = new WizardStep(cmdlet.Name, cmdlet.Order);
                step.SearchCriteria = cmdlet.SearchCriteria;
                step.StepForwardAction = cmdlet.StepForwardAction;
                step.StepBackwardAction = cmdlet.StepBackwardAction;
                step.StepCancelAction = cmdlet.StepCancelAction;
                step.StepGetWindowAction = cmdlet.StepGetWindowAction;
                cmdlet.WriteVerbose(cmdlet, "adding the step");
                // 20130317
                step.Parent = cmdlet.InputObject;

                cmdlet.InputObject.Steps.Add(step);

                if (cmdlet.PassThru) {

                    cmdlet.WriteObject(cmdlet, cmdlet.InputObject);
                } else {

                    cmdlet.WriteObject(cmdlet, true);
                }
            } else {

                cmdlet.WriteError(cmdlet, "The wizard object you provided is not valid", "WrongWizardObject", ErrorCategory.InvalidArgument, true);
            }
        }
        
        public static void InvokeWizard(WizardRunCmdletBase cmdlet)
        {
Console.WriteLine("InvokeWizard 000001");
            Wizard wzd = cmdlet.GetWizard(cmdlet.Name);
Console.WriteLine("InvokeWizard 000002");
            if (null == wzd) {
Console.WriteLine("InvokeWizard 000003");
                cmdlet.WriteError(cmdlet, "Couldn't get the wizard you asked for", "NoSuchWizard", ErrorCategory.InvalidArgument, true);
            } else {
Console.WriteLine("InvokeWizard 000004");
                wzd.Automatic = cmdlet.Automatic;
                wzd.ForwardDirection = cmdlet.ForwardDirection;
Console.WriteLine("InvokeWizard 000005");
                //this.WriteVerbose(this, "running script blocks");
                cmdlet.WriteVerbose(cmdlet, "running script blocks");
                //RunWizardScriptBlocks(this, wzd);
                cmdlet.RunWizardStartScriptBlocks(cmdlet, wzd);
Console.WriteLine("InvokeWizard 000006");

                // 20130317
                cmdlet.RunWizardInAutomaticMode(cmdlet, wzd);
Console.WriteLine("InvokeWizard 000007");
                //if (PassThru) {
                //this.WriteObject(this, wzd);
                cmdlet.WriteObject(cmdlet, wzd);
                //} else {
                // WriteObject(this, true);
            }
        }
    }
}
