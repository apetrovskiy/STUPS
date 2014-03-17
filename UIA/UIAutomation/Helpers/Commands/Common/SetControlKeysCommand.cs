/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/11/2014
 * Time: 10:41 AM
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
    /// Description of SetControlKeysCommand.
    /// </summary>
    public class SetControlKeysCommand : AbstractCommand	// : UiaCommand
    {
        public SetControlKeysCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            var cmdlet =
                (SetUiaControlKeysCommand)Cmdlet;
            
            
        }
    }
}
