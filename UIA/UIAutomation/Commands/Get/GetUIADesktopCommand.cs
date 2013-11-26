/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/1/2012
 * Time: 9:46 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System.Management.Automation;
    using System.Windows.Automation;
    
    /// <summary>
    /// Description of GetUiaDesktopCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaDesktop")]
    [OutputType(typeof(object))]
    public class GetUiaDesktopCommand : GetCmdletBase
    {
        protected override void BeginProcessing()
        {
            // 20131109
            //UIAutomation.CurrentData.CurrentWindow = 
            //    AutomationElement.RootElement;
            CurrentData.CurrentWindow =
                MySuperWrapper.RootElement;
            // 20131109
            //this.WriteObject(this, AutomationElement.RootElement);
            WriteObject(this, MySuperWrapper.RootElement);
        }
    }
}
