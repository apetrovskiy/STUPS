/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/25/2013
 * Time: 1:34 PM
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
    /// Description of WaitUIAWindowCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAWindow", DefaultParameterSetName = "UIA")]
    public class WaitUIAWindowCommand : GetUIAWindowCommand
    {
        public WaitUIAWindowCommand()
        {
            this.TestMode = true;
        }
    }
}
