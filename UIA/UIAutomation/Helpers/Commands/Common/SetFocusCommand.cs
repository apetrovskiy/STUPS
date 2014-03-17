/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/11/2014
 * Time: 10:42 AM
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
    /// Description of SetFocusCommand.
    /// </summary>
    public class SetFocusCommand : AbstractCommand	// : UiaCommand
    {
        public SetFocusCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            var cmdlet =
                (SetUiaFocusCommand)Cmdlet;
            
            
        }
    }
}
