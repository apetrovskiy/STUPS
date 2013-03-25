/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/22/2013
 * Time: 7:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ShowUIABannerCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Show, "UIABanner")]
    public class ShowUIABannerCommand : CommonCmdletBase
    {
        public ShowUIABannerCommand()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   Position = 0)]
        [ValidateNotNullOrEmpty()]
        public string Message { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            UIAHelper.ShowBanner(this.Message);
        }
    }
}
