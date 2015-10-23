/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/11/2014
 * Time: 3:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Helpers.Commands
{
    /// <summary>
    /// Description of HideBannerCommand.
    /// </summary>
    public class HideBannerCommand : UiaCommand
    {
        public HideBannerCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
//            var cmdlet =
//                (AddUiaBannerTextCommand)Cmdlet;
            
            UiaHelper.HideBanner();
        }
    }
}
