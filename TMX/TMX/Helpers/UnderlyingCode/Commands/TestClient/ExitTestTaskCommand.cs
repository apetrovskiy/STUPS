/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/25/2014
 * Time: 8:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
	using System;
	using Tmx;
	using Tmx.Client;
	using Tmx.Commands;
	
    /// <summary>
    /// Description of ExitTestTaskCommand.
    /// </summary>
    class ExitTestTaskCommand : TmxCommand
    {
        internal ExitTestTaskCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (ExitTmxTestTaskCommand)Cmdlet;
//            var taskLoader = new TaskLoader();
//            ClientSettings.CurrentTask = taskLoader.GetCurrentTask();
        }
    }
}
