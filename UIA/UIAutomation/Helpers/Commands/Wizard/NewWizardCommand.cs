/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/15/2013
 * Time: 12:09 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using Commands;
    
    /// <summary>
    /// Description of UiaNewWizardCommand.
    /// </summary>
    public class NewWizardCommand : UiaCommand
    {
        public NewWizardCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            NewUiaWizardCommand cmdlet =
                (NewUiaWizardCommand)Cmdlet;
            
            WizardHelper.CreateWizard(cmdlet);
        }
    }
}
