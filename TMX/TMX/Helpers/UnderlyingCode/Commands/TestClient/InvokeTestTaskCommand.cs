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
            var task = cmdlet.InputObject;
            if (TestTaskStatuses.Accepted != task.TaskStatus)
                cmdlet.WriteError(cmdlet, "Task '" + task.Name + "' has been already processed", "AlreadyProcessed", ErrorCategory.InvalidData, true);
            
            runTask(task);
			updateTask(task);
			sendTestResults();
        }
        
		void runTask(ITestTask task)
		{
			var taskRunner = new TaskRunner();
			var runResult = taskRunner.Run(task);
			task.TaskFinished = true;
			task.TaskStatus = runResult ? TestTaskStatuses.CompletedSuccessfully : TestTaskStatuses.Failed;
		}
		
		void updateTask(ITestTask task)
		{
			var taskUpdater = new TaskUpdater(new RestRequestCreator());
			taskUpdater.UpdateTask(task);
		}
		
		void sendTestResults()
		{
            var testResultsSender = new TestResultsSender(new RestRequestCreator());
            var result = testResultsSender.SendTestResults();
            if (result)
                TestData.ResetData();
		}
    }
}
