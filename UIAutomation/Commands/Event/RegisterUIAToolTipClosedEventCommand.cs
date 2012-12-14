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
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of RegisterUIAToolTipClosedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UIAToolTipClosedEvent")]
    public class RegisterUIAToolTipClosedEventCommand : EventCmdletBase
    {
        public RegisterUIAToolTipClosedEventCommand()
        {
            this.AutomationEventType = AutomationElement.ToolTipClosedEvent;
            this.AutomationEventHandler = OnUIAutomationEvent;
        }
    }
}
