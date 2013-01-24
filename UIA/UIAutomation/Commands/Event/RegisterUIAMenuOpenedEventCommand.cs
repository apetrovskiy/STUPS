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
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of RegisterUIAMenuOpenedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UIAMenuOpenedEvent")]
    public class RegisterUIAMenuOpenedEventCommand : EventCmdletBase
    {
        public RegisterUIAMenuOpenedEventCommand()
        {
            this.AutomationEventType = AutomationElement.MenuOpenedEvent;
            this.AutomationEventHandler = OnUIAutomationEvent;
        }
    }
}
