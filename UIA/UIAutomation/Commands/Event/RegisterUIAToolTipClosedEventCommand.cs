/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/16/2012
 * Time: 12:32 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of RegisterUiaToolTipClosedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UiaToolTipClosedEvent")]
    public class RegisterUiaToolTipClosedEventCommand : EventCmdletBase
    {
        public RegisterUiaToolTipClosedEventCommand()
        {
            AutomationEventType = AutomationElement.ToolTipClosedEvent;
            AutomationEventHandler = OnUIAutomationEvent;
        }
    }
}
