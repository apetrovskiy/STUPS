/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 5/29/2013
 * Time: 12:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    
    using System.Windows.Automation;
    using System.Collections;
    
    /// <summary>
    /// Description of WaitUIANoWindowCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIANoWindow", DefaultParameterSetName = "UIA")]
    public class WaitUIANoWindowCommand : GetUIAWindowCommand
    {
        public WaitUIANoWindowCommand()
        {
            this.TestMode = true;
            this.WaitNoWindow = true;
        }
    }
}
