/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/11/2014
 * Time: 10:40 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Helpers.Commands
{
    using UIAutomation.Commands;
    
    /// <summary>
    /// Description of InvokeControlClickCommand.
    /// </summary>
    public class InvokeControlClickCommand : UiaCommand
    {
        public InvokeControlClickCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            var cmdlet =
                (InvokeUiaControlClickCommand)Cmdlet;
            
            foreach (IUiElement inputObject in cmdlet.InputObject) {
            
                cmdlet.ClickControl(
                    cmdlet,
                    inputObject,
                    new ClickSettings {
                        RightClick = cmdlet.RightClick,
                        MidClick = cmdlet.MidClick,
                        Alt = cmdlet.Alt,
                        Shift = cmdlet.Shift,
                        Ctrl = cmdlet.Ctrl,
                        // inSequence = cmdlet.ins
                        DoubleClick = cmdlet.DoubleClick,
                        DoubleClickInterval = cmdlet.DoubleClickInterval,
                        RelativeX = cmdlet.X,
                        RelativeY = cmdlet.Y
                    });
                
                if (cmdlet.PassThru) {

                    cmdlet.WriteObject(cmdlet, inputObject);
                } else {
                    cmdlet.WriteObject(cmdlet, true);
                }
                
            }
        }
    }
}
