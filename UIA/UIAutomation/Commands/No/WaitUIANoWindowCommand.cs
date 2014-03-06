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
    extern alias UIANET;// using System.Windows.Automation;
    using System;
    using System.Management.Automation;
    
    using classic = UIANET::System.Windows.Automation; // using System.Windows.Automation;
    using System.Collections;
    
    /// <summary>
    /// Description of WaitUiaNoWindowCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaNoWindow", DefaultParameterSetName = "UIA")]
    public class WaitUiaNoWindowCommand : GetUiaWindowCommand
    {
        public WaitUiaNoWindowCommand()
        {
            TestMode = true;
            WaitNoWindow = true;
        }
    }
}
