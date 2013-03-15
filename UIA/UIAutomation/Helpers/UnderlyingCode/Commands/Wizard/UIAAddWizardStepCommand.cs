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
            
            //WizardCollection.Wizards[
            
//            //if (!ValidateWizardName(Name)) {
//            if (!cmdlet.ValidateWizardName(cmdlet.Name)) {
//                
//                cmdlet.WriteError(
//                    cmdlet,
//                    "The wizard name you selected is already in use",
//                    "NameInUse",
//                    ErrorCategory.InvalidArgument,
//                    true);
//                
//                // for unit tests
//                return;
//            }
//            //this.WriteVerbose(this, "wizard name validated");
//            cmdlet.WriteVerbose(cmdlet, "wizard name validated");
//            Wizard wzd = new Wizard(cmdlet.Name);
//            //this.WriteVerbose(this, "wizard object created");
//            cmdlet.WriteVerbose(cmdlet, "wizard object created");
//            if (cmdlet.StartAction != null && cmdlet.StartAction.Length > 0) {
//                wzd.StartAction = cmdlet.StartAction;
//            }
//            //this.WriteObject(this, wzd);
//            cmdlet.WriteObject(cmdlet, wzd);
        }
    }
}
