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
//            var taskRunner = new TaskRunner();
//            var taskUpdater = new TaskUpdater(new RestRequestCreator());
            var task = cmdlet.InputObject;
            if (TestTaskStatuses.Accepted != task.TaskStatus)
                cmdlet.WriteError(cmdlet, "Task '" + task.Name + "' has been already processed", "AlreadyProcessed", ErrorCategory.InvalidData, true);
            
//            var taskRunner = new TaskRunner();
//			var runResult = taskRunner.Run(task);
//			task.TaskFinished = true;
//			task.TaskStatus = runResult ? TestTaskStatuses.CompletedSuccessfully : TestTaskStatuses.Failed;
            runTask(task);
Console.WriteLine("task has been run");
//			var taskUpdater = new TaskUpdater(new RestRequestCreator());
//			taskUpdater.UpdateTask(task);
			updateTask(task);
Console.WriteLine("task has been updated");
			sendTestResults();
Console.WriteLine("test results gave been sent");
        }
        
		void runTask(ITestTask task)
		{
Console.WriteLine("running task 0001");
			var taskRunner = new TaskRunner();
Console.WriteLine("running task 0002");
			var runResult = taskRunner.Run(task);
Console.WriteLine("running task 0003");
			task.TaskFinished = true;
Console.WriteLine("running task 0004");
			task.TaskStatus = runResult ? TestTaskStatuses.CompletedSuccessfully : TestTaskStatuses.Failed;
Console.WriteLine("running task 0005");
		}
		
		void updateTask(ITestTask task)
		{
Console.WriteLine("updating task 0001");
			var taskUpdater = new TaskUpdater(new RestRequestCreator());
Console.WriteLine("updating task 0002");
			taskUpdater.UpdateTask(task);
Console.WriteLine("updating task 0003");
		}
		
		void sendTestResults()
		{
Console.WriteLine("sending test results 0001");
            var testResultsSender = new TestResultsSender(new RestRequestCreator());
Console.WriteLine("sending test results 0002");
            var result = testResultsSender.SendTestResults();
Console.WriteLine("sending test results 0003");
            if (result)
                TestData.ResetData();
Console.WriteLine("sending test results 0004");
		}
    }
}
