/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/28/2013
 * Time: 12:51 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of AddUIABannerTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "UIABannerText")]
    public class AddUIABannerTextCommand : CommonCmdletBase
    {
        public AddUIABannerTextCommand()
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
            UIAHelper.AppendBanner(this.Message);
        }
    }
}
