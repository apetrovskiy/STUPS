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
    // test it
    //using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    
    /// <summary>
    /// Description of GetUIADesktopCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIADesktop")]
    [OutputType(typeof(object))]
    public class GetUIADesktopCommand : GetCmdletBase
    {
        protected override void BeginProcessing()
        {
            // 20131109
            //UIAutomation.CurrentData.CurrentWindow = 
            //    AutomationElement.RootElement;
            UIAutomation.CurrentData.CurrentWindow =
                MySuperWrapper.RootElement;
            // 20131109
            //this.WriteObject(this, AutomationElement.RootElement);
            this.WriteObject(this, MySuperWrapper.RootElement);
        }
    }
}
