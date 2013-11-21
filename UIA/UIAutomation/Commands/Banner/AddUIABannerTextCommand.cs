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
    using System.Management.Automation;
    
    /// <summary>
    /// Description of AddUiaBannerTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "UiaBannerText")]
    public class AddUiaBannerTextCommand : CommonCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = true,
                   Position = 0)]
        [ValidateNotNullOrEmpty]
        public string Message { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            UiaHelper.AppendBanner(this.Message);
        }
    }
}
