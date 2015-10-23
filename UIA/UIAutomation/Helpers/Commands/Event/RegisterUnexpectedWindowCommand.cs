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
    /// Description of RegisterUnexpectedWindowCommand.
    /// </summary>
    public class RegisterUnexpectedWindowCommand : UiaCommand
    {
        public RegisterUnexpectedWindowCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            var cmdlet =
                (RegisterUiaUnexpectedWindowCommand)Cmdlet;
            
            
        }
    }
}
