/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/11/2014
 * Time: 10:27 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Helpers.Commands
{
    using UIAutomation.Commands;
    
    /// <summary>
    /// Description of GetDesktopCommand.
    /// </summary>
    public class GetDesktopCommand : UiaCommand
    {
        public GetDesktopCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            var cmdlet =
                (GetUiaDesktopCommand)Cmdlet;
            
            CurrentData.CurrentWindow =
                UiElement.RootElement;
            
            cmdlet.WriteObject(cmdlet, UiElement.RootElement);
        }
    }
}
