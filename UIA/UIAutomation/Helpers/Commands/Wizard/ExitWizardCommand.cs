/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/14/2014
 * Time: 9:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using Commands;
    
    /// <summary>
    /// Description of ExitWizardCommand.
    /// </summary>
    public class ExitWizardCommand : UiaCommand
    {
        public ExitWizardCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            ExitUiaWizardCommand cmdlet =
                (ExitUiaWizardCommand)Cmdlet;

            cmdlet.GetWizard(cmdlet.Name).StopImmediately = true;
            
            cmdlet.WriteObject(cmdlet, true);
        }
    }
}
