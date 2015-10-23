/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/16/2014
 * Time: 12:58 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Helpers.Commands
{
    /// <summary>
    /// Description of EventCommand.
    /// </summary>
    public class EventCommand : UiaCommand
    {
        public EventCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
            
        }
        
        public override void Execute()
        {
            var cmdlet = (EventCmdletBase)Cmdlet;
            
            foreach (IUiElement inputObject in cmdlet.InputObject) {
                
                cmdlet.SubscribeToEvents(
                    cmdlet,
                    inputObject,
                    cmdlet.AutomationEventType,
                    cmdlet.AutomationProperty);
            }
        }
    }
}
