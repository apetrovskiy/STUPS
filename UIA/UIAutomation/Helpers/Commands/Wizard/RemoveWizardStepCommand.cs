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
    using Commands;
    
    /// <summary>
    /// Description of UiaRemoveWizardStepCommand.
    /// </summary>
    public class RemoveWizardStepCommand : UiaCommand
    {
        public RemoveWizardStepCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            RemoveUiaWizardStepCommand cmdlet =
                (RemoveUiaWizardStepCommand)Cmdlet;
            
            WizardHelper.RemoveWizardStep(cmdlet);
        }
    }
}
