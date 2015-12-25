/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/14/2014
 * Time: 9:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System.Management.Automation;

    /// <summary>
    /// Description of ExitUiaWizardCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Exit, "UiaWizard")]
    public class ExitUiaWizardCommand : WizardContainerCmdletBase
    {
        protected override void BeginProcessing()
        {
            ExitWizardCommand command =
                new ExitWizardCommand(this);
            command.Execute();
        }
    }
}
