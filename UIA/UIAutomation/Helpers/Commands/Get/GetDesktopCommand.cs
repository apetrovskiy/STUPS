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
    /// Description of GetDesktopCommand.
    /// </summary>
    public class GetDesktopCommand : AbstractCommand	// : UiaCommand
    {
        public GetDesktopCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        // public GetDesktopCommand(PSCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
//System.Console.WriteLine("desktop command 0001");
            var cmdlet =
                (GetUiaDesktopCommand)Cmdlet;
            
//if (null == cmdlet) {
//    Console.WriteLine("null == cmdlet");
//} else {
//    Console.WriteLine("null != cmdlet");
//}
//System.Console.WriteLine("desktop command 0002");
            CurrentData.CurrentWindow =
                UiElement.RootElement;
            
//System.Console.WriteLine("desktop command 0003");
            cmdlet.WriteObject(cmdlet, UiElement.RootElement);
        }
    }
}
