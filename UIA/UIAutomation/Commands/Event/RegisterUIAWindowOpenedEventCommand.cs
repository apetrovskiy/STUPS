/*    
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 20/01/2012
 * Time: 09:51 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    extern alias UIANET;
    using System.Management.Automation;
    using System.Windows.Automation;
    using UIAutomation.Helpers.Commands;

    /// <summary>
    /// Description of RegisterUiaWindowOpenedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UiaWindowOpenedEvent")]
    public class RegisterUiaWindowOpenedEventCommand : EventCmdletBase
    {
        public RegisterUiaWindowOpenedEventCommand()
        {
            base.AutomationEventType = 
                WindowPattern.WindowOpenedEvent;
            base.AutomationEventHandler = OnUIAutomationEvent;
        }
    }
}
