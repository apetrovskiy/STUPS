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
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    
    /// <summary>
    /// Description of GetUIADesktopCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIADesktop")]
    [OutputType(typeof(object))]
    public class GetUIADesktopCommand : GetCmdletBase
    {
        public GetUIADesktopCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            UIAutomation.CurrentData.CurrentWindow = 
                AutomationElement.RootElement;
            this.WriteObject(this, AutomationElement.RootElement);
        }
    }
}
