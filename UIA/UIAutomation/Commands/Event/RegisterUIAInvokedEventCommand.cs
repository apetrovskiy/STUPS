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
    extern alias UIANET;
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of RegisterUiaInvokedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UiaInvokedEvent")]
    
    public class RegisterUiaInvokedEventCommand : EventCmdletBase
    {
        #region Constructor
        public RegisterUiaInvokedEventCommand()
        {
            AutomationEventType = InvokePattern.InvokedEvent;
            AutomationEventHandler = OnUIAutomationEvent;
        }
        #endregion Constructor
    }
}
