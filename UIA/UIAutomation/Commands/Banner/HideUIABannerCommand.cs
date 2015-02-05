/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/22/2013
 * Time: 7:32 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System.Management.Automation;
    using Helpers.Commands;
    
    /// <summary>
    /// Description of HideUiaBannerCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Hide, "UiaBanner")]
    public class HideUiaBannerCommand : CommonCmdletBase
    {
        protected override void BeginProcessing()
        {
            // UiaHelper.HideBanner();
            
            var command =
                AutomationFactory.GetCommand<HideBannerCommand>(this);
            command.Execute();
        }
    }
}
