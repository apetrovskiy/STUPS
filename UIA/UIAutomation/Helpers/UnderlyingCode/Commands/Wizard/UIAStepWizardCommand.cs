/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/18/2013
 * Time: 2:15 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    using UIAutomation.Commands;
    
    /// <summary>
    /// Description of UiaStepWizardCommand.
    /// </summary>
    internal class UiaStepWizardCommand : UiaCommand
    {
        internal UiaStepWizardCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            StepUiaWizardCommand cmdlet =
                (StepUiaWizardCommand)this.Cmdlet;
            
            WizardHelper.StepWizardStep(cmdlet);
        }
    }
}
