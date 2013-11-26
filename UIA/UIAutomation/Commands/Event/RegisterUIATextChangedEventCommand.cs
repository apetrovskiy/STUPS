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
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of RegisterUiaTextChangedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UiaTextChangedEvent")]
    
    public class RegisterUiaTextChangedEventCommand : EventCmdletBase
    {
        #region Constructor
        public RegisterUiaTextChangedEventCommand()
        {
            // base.AutomationEventType = 
            AutomationEventType = 
                TextPattern.TextChangedEvent;
            // base.AutomationEventHandler = OnUIAutomationEvent;
            AutomationEventHandler = OnUIAutomationEvent;
        }
        #endregion Constructor
    }
}
