/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/11/2014
 * Time: 3:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Helpers.Commands
{
    using UIAutomation.Commands;
    
    /// <summary>
    /// Description of GetRegisteredEventCommand.
    /// </summary>
    public class GetRegisteredEventCommand : UiaCommand
    {
        public GetRegisteredEventCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
            
        }
        
        public override void Execute()
        {
            var cmdlet =
                (GetUiaRegisteredEventCommand)Cmdlet;
            
            
        }
    }
}
