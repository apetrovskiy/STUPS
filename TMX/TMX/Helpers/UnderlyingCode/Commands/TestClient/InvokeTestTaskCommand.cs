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
	using System.Linq;
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
            var taskUpdater = new TaskUpdater(new RestRequestCreator());
            var task = cmdlet.InputObject;
            if (TestTaskStatuses.Accepted != task.TaskStatus)
                cmdlet.WriteError(cmdlet, "Task '" + task.Name + "' has been already processed", "AlreadyProcessed", ErrorCategory.InvalidData, true);
            
            // task.TaskResult = new string[] {};
            ClientSettings.TaskResult = new string[] {};
            
			var runResult = taskRunner.Run(task);
			task.TaskFinished = true;
			task.TaskStatus = runResult ? TestTaskStatuses.CompletedSuccessfully : TestTaskStatuses.Failed;
			//
if (null == ClientSettings.TaskResult)
    Console.WriteLine("invoke: null == ClientSettings.TaskResult");
else {
    Console.WriteLine("invoke: null != ClientSettings.TaskResult");
    foreach (var element in ClientSettings.TaskResult) {
        Console.WriteLine(element);
    }
}
			if (null != ClientSettings.TaskResult)
                task.TaskResult = ClientSettings.TaskResult.ToArray();
			//
			taskUpdater.UpdateTask(task);
        }
    }
}
