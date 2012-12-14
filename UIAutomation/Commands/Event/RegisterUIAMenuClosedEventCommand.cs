/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/16/2012
 * Time: 12:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of RegisterUIAMenuClosedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UIAMenuClosedEvent")]
    public class RegisterUIAMenuClosedEventCommand : EventCmdletBase
    {
        public RegisterUIAMenuClosedEventCommand()
        {
            this.AutomationEventType = AutomationElement.MenuClosedEvent;
            this.AutomationEventHandler = OnUIAutomationEvent;
        }
    }
}
