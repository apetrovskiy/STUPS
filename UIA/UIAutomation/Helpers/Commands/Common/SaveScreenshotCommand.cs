/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/11/2014
 * Time: 10:41 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Helpers.Commands
{
    using UIAutomation.Commands;
    
    /// <summary>
    /// Description of SaveScreenshotCommand.
    /// </summary>
    public class SaveScreenshotCommand : UiaCommand
    {
        public SaveScreenshotCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            var cmdlet =
                (SaveUiaScreenshotCommand)Cmdlet;
            
            
        }
    }
}
