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
    extern alias UIANET;
    using System;
    using System.Management.Automation;
    
    using System.Windows.Automation;
    using System.Collections;
    using UIAutomation.Helpers.Commands;
    
    /// <summary>
    /// Description of WaitUiaWindowCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaWindow", DefaultParameterSetName = "UIA")]
    public class WaitUiaWindowCommand : GetUiaWindowCommand
    {
        public WaitUiaWindowCommand()
        {
            TestMode = true;
        }
    }
}
