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
    /// Description of GetUIAFocusCommand.
    /// </summary>
    public class GetFocusCommand : UiaCommand
    {
        public GetFocusCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            var cmdlet =
                (GetUiaFocusCommand)Cmdlet;
            
            
        }
    }
}
