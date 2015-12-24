/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/11/2014
 * Time: 10:39 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Helpers.Commands
{
    using UIAutomation.Commands;
    
    /// <summary>
    /// Description of ClearControlTextCommand.
    /// </summary>
    public class ClearControlTextCommand : UiaCommand
    {
        public ClearControlTextCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            var cmdlet =
                (ClearUiaControlTextCommand)Cmdlet;
            
            
        }
    }
}
