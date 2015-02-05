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
    using Helpers.Commands;
    
    /// <summary>
    /// Description of AddUiaBannerTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "UiaBannerText")]
    public class AddUiaBannerTextCommand : CommonCmdletBase
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
//            UiaHelper.AppendBanner(Message);
            
            var command =
                AutomationFactory.GetCommand<AddBannerTextCommand>(this);
            command.Execute();
        }
    }
}
