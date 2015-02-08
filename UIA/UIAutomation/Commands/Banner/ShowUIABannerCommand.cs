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
    using System.Management.Automation;
    using Helpers.Commands;
    
    /// <summary>
    /// Description of ShowUiaBannerCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Show, "UiaBanner")]
    public class ShowUiaBannerCommand : CommonCmdletBase
    {
        #region Parameters
        [UiaParameter]
        [Parameter(Mandatory = true,
                   Position = 0)]
        [ValidateNotNullOrEmpty]
        public string Message { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            // UiaHelper.ShowBanner(Message);
            
            var command =
                AutomationFactory.GetCommand<ShowBannerCommand>(this);
            command.Execute();
        }
    }
}
