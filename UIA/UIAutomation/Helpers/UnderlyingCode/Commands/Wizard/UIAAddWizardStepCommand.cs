/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
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
    }
}
