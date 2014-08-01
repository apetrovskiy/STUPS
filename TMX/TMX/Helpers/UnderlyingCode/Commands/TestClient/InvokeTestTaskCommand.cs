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
	using System.Management.Automation;
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
            // var taskUpdater = new TaskUpdater();
            var taskUpdater = new TaskUpdater(new RestRequestCreator());
//            foreach (var task in cmdlet.InputObject) {
//                if (TestTaskStatuses.Accepted != task.Status) {
//                    cmdlet.WriteError(cmdlet, "Task '" + task.Name + "' has been already processed", "AlreadyProcessed", ErrorCategory.InvalidData, false);
//                    continue;
//                }
//				var runResult = taskRunner.Run(task);
//				task.Completed = true;
//				task.Status = runResult ? TestTaskStatuses.CompletedSuccessfully : TestTaskStatuses.Failed;
//				// ClientSettings.CurrentTask = task;
//// ClientSettings.CurrentTask = task;
//				taskUpdater.UpdateTask(task);
//				// ClientSettings.CurrentTask = null;
//            }
            var task = cmdlet.InputObject;
            if (TestTaskStatuses.Accepted != task.TaskStatus)
                cmdlet.WriteError(cmdlet, "Task '" + task.Name + "' has been already processed", "AlreadyProcessed", ErrorCategory.InvalidData, true);
            ClientSettings.CurrentTask = task;
			var runResult = taskRunner.Run(task);
			task = ClientSettings.CurrentTask;
			ClientSettings.CurrentTask = null;
			task.TaskFinished = true;
			task.TaskStatus = runResult ? TestTaskStatuses.CompletedSuccessfully : TestTaskStatuses.Failed;
Console.WriteLine("invoking " + task.Id + " " + task.TaskStatus + " " + task.TaskFinished);
			// ClientSettings.CurrentTask = task;
// ClientSettings.CurrentTask = task;
			taskUpdater.UpdateTask(task);
        }
    }
}
