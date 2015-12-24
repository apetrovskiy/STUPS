/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 5/15/2013
 * Time: 3:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System.Management.Automation;

    /// <summary>
    /// Description of RegisterUiaUnexpectedWindowCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UiaUnexpectedWindow")]
    public class RegisterUiaUnexpectedWindowCommand : RegisterUiaWindowOpenedEventCommand
    {
        public RegisterUiaUnexpectedWindowCommand()
        {
        }
    }
}
