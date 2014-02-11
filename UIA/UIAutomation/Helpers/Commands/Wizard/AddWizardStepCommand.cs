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
    using Commands;
    
    /// <summary>
    /// Description of UiaAddWizardStepCommand.
    /// </summary>
    public class AddWizardStepCommand : UiaCommand
    {
        public AddWizardStepCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            AddUiaWizardStepCommand cmdlet =
                (AddUiaWizardStepCommand)Cmdlet;

            WizardHelper.AddWizardStep(cmdlet);
        }
    }
}
