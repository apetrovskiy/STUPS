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
    /// Description of SaveScreenshotCommand.
    /// </summary>
    public class SaveScreenshotCommand : AbstractCommand	// : UiaCommand
    {
        public SaveScreenshotCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            var cmdlet =
                (SaveUiaScreenshotCommand)Cmdlet;
            
            
        }
    }
}
