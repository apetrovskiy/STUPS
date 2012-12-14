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
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of RegisterUIATextChangedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UIATextChangedEvent")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class RegisterUIATextChangedEventCommand : EventCmdletBase
    {
        #region Constructor
        public RegisterUIATextChangedEventCommand()
        {
            // base.AutomationEventType = 
            this.AutomationEventType = 
                TextPattern.TextChangedEvent;
            // base.AutomationEventHandler = OnUIAutomationEvent;
            this.AutomationEventHandler = OnUIAutomationEvent;
        }
        #endregion Constructor
    }
}
