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
    using System.Management.Automation;
    using UIAutomation.Commands;
    
    /// <summary>
    /// Description of InvokeControlContextMenuCommand.
    /// </summary>
    public class InvokeControlContextMenuCommand : UiaCommand
    {
        public InvokeControlContextMenuCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            var cmdlet =
                (InvokeUiaControlContextMenuCommand)Cmdlet;
            
            foreach (IUiElement inputObject in cmdlet.InputObject) {
                
                try {
                    var resultElement = inputObject.InvokeContextMenu(cmdlet, cmdlet.X, cmdlet.Y);
                    // return the context menu window
                    cmdlet.WriteObject(cmdlet, resultElement);
                } catch {
                    cmdlet.WriteError(
                        cmdlet,
                        "Failed to invoke context menu on this element",
                        "couldNotClick",
                        ErrorCategory.InvalidResult,
                        true);
                }
                
            }
        }
    }
}
