/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/11/2014
 * Time: 3:32 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Helpers.Commands
{
    using UIAutomation.Commands;
    
    /// <summary>
    /// Description of ShowBannerCommand.
    /// </summary>
    public class ShowBannerCommand : UiaCommand
    {
        public ShowBannerCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            var cmdlet =
                (ShowUiaBannerCommand)Cmdlet;
            
            UiaHelper.ShowBanner(cmdlet.Message);
        }
    }
}
