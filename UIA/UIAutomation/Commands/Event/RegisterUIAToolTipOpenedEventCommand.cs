/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/16/2012
 * Time: 12:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of RegisterUIAToolTipOpenedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UIAToolTipOpenedEvent")]
    public class RegisterUIAToolTipOpenedEventCommand : EventCmdletBase
    {
        public RegisterUIAToolTipOpenedEventCommand()
        {
            this.AutomationEventType = AutomationElement.ToolTipOpenedEvent;
            this.AutomationEventHandler = OnUIAutomationEvent;
        }
    }
}
