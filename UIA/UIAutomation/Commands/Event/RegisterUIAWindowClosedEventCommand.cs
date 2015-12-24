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
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System.Management.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;

    /// <summary>
    /// Description of RegisterUiaWindowClosedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UiaWindowClosedEvent")]
    public class RegisterUiaWindowClosedEventCommand : EventCmdletBase
    {
        public RegisterUiaWindowClosedEventCommand()
        {
            AutomationEventType = 
                classic.WindowPattern.WindowClosedEvent;
            AutomationEventHandler = OnUIAutomationEvent;
        }
    }
}
