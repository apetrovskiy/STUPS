/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/28/2014
 * Time: 8:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
	using System;
	using TMX.Interfaces.Exceptions;
	using Tmx;
	using Tmx.Client;
	using Tmx.Interfaces.Remoting;
	using Tmx.Commands;
	
    /// <summary>
    /// Description of InvokeTestTaskCommand.
    /// </summary>
    class InvokeTestTaskCommand : TmxCommand
    {
        internal InvokeTestTaskCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (InvokeTmxTestTaskCommand)Cmdlet;
            var taskRunner = new TaskRunner();
            var taskUpdater = new TaskUpdater();
            foreach (var task in cmdlet.InputObject) {
				taskRunner.Run(task);
				task.Completed = true;
				task.Status = TestTaskStatuses.CompletedSuccessfully; // TODO: use honest status!
				ClientSettings.CurrentTask = task;
				taskUpdater.UpdateTask();
            }
        }
    }
}
