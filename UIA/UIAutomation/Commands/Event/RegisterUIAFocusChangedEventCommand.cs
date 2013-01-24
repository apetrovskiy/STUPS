/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/16/2012
 * Time: 12:04 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of RegisterUIAFocusChangedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UIAFocusChangedEvent")]
    public class RegisterUIAFocusChangedEventCommand : EventCmdletBase
    {
        public RegisterUIAFocusChangedEventCommand()
        {
            this.AutomationEventType = AutomationElement.AutomationFocusChangedEvent;
            this.AutomationEventHandler = OnUIAutomationEvent;
        }
    }
}
