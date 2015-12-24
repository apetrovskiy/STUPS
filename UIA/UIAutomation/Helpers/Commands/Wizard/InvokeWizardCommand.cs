/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/17/2013
 * Time: 2:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Helpers.Commands
{
    /// <summary>
    /// Description of UiaInvokeWizardCommand.
    /// </summary>
    public class InvokeWizardCommand : UiaCommand
    {
        public InvokeWizardCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            WizardRunCmdletBase cmdlet =
                (WizardRunCmdletBase)Cmdlet;
            
            WizardHelper.InvokeWizard(cmdlet);
        }
    }
}
