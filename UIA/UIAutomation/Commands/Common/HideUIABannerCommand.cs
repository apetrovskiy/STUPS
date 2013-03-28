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
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of HideUIABannerCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Hide, "UIABanner")]
    public class HideUIABannerCommand : CommonCmdletBase
    {
        public HideUIABannerCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            UIAHelper.HideBanner();
        }
    }
}
