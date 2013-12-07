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
    using Commands;
    
    /// <summary>
    /// Description of UiaRemoveWizardStepCommand.
    /// </summary>
    internal class UiaRemoveWizardStepCommand : UiaCommand
    {
        internal UiaRemoveWizardStepCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            RemoveUiaWizardStepCommand cmdlet =
                (RemoveUiaWizardStepCommand)Cmdlet;
            
            WizardHelper.RemoveWizardStep(cmdlet);
        }
    }
}
