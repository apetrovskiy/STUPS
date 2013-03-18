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
    /// Description of UIAStepWizardCommand.
    /// </summary>
    internal class UIAStepWizardCommand : UIACommand
    {
        internal UIAStepWizardCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            StepUIAWizardCommand cmdlet =
                (StepUIAWizardCommand)this.Cmdlet;
            
            WizardHelper.StepWizardStep(cmdlet);
        }
    }
}
