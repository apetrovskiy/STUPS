/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/11/2014
 * Time: 10:27 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Helpers.Commands
{
    using System;
    using System.Management.Automation;
//    using System.Collections;
//    using System.Collections.Generic;
    using UIAutomation.Commands;
    using PSTestLib;
    
    /// <summary>
    /// Description of TestControlStateCommand.
    /// </summary>
    public class TestControlStateCommand : AbstractCommand	// : UiaCommand
    {
        public TestControlStateCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            var cmdlet =
                (TestUiaControlStateCommand)Cmdlet;
            
            bool result = 
                cmdlet.TestControlByPropertiesFromHashtable(
                    cmdlet.InputObject,
                    cmdlet.SearchCriteria,
                    0);
            
            cmdlet.WriteObject(cmdlet, result);
        }
    }
}
