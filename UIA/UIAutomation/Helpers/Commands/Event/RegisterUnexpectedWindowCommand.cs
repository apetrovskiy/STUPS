/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/11/2014
 * Time: 3:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Helpers.Commands
{
    using System;
    using System.Management.Automation;
    using System.Collections;
    using System.Collections.Generic;
    using UIAutomation.Commands;
    using PSTestLib;
    
    /// <summary>
    /// Description of RegisterUnexpectedWindowCommand.
    /// </summary>
    public class RegisterUnexpectedWindowCommand : AbstractCommand	// : UiaCommand
    {
        public RegisterUnexpectedWindowCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            var cmdlet =
                (RegisterUiaUnexpectedWindowCommand)Cmdlet;
            
            
        }
    }
}
