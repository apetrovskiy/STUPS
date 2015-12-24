/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 20/01/2012
 * Time: 09:50 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System.Management.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;

    /// <summary>
    /// Description of RegisterUiaTextSelectionChangedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UiaTextSelectionChangedEvent")]
    public class RegisterUiaTextSelectionChangedEventCommand : EventCmdletBase
    {
        public RegisterUiaTextSelectionChangedEventCommand()
        {
            AutomationEventType = 
                classic.TextPattern.TextSelectionChangedEvent;
            AutomationEventHandler = OnUIAutomationEvent;
        }
    }
}
