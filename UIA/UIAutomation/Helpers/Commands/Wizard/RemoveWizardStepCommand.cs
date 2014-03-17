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
    using PSTestLib;
    
    /// <summary>
    /// Description of UiaRemoveWizardStepCommand.
    /// </summary>
    public class RemoveWizardStepCommand : AbstractCommand	// : UiaCommand
    {
        public RemoveWizardStepCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            var cmdlet =
                (RemoveUiaWizardStepCommand)Cmdlet;
            
            WizardHelper.RemoveWizardStep(cmdlet);
        }
    }
}
