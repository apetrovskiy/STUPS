/*    
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 20/01/2012
 * Time: 09:51 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of RegisterUIAWindowOpenedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UIAWindowOpenedEvent")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class RegisterUIAWindowOpenedEventCommand : EventCmdletBase
    {
        #region Constructor
        public RegisterUIAWindowOpenedEventCommand()
        {
            base.AutomationEventType = 
                WindowPattern.WindowOpenedEvent;
            base.AutomationEventHandler = OnUIAutomationEvent;
        }
        #endregion Constructor
    }
}
