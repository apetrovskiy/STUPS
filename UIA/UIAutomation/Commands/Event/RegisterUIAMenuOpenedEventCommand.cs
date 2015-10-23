/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/16/2012
 * Time: 11:56 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System.Management.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;

    /// <summary>
    /// Description of RegisterUiaMenuOpenedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UiaMenuOpenedEvent")]
    public class RegisterUiaMenuOpenedEventCommand : EventCmdletBase
    {
        public RegisterUiaMenuOpenedEventCommand()
        {
            AutomationEventType = classic.AutomationElement.MenuOpenedEvent;
            AutomationEventHandler = OnUIAutomationEvent;
        }
    }
}
