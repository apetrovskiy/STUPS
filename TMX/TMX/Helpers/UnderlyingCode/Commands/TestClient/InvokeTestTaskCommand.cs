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
	using Tmx.Core;
	using Tmx.Interfaces.Remoting;
	using Tmx.Commands;
	
    /// <summary>
    /// Description of InvokeTestTaskCommand.
    /// </summary>
    // TODO: fix it 20141030
    class InvokeTestTaskCommand : TmxCommand
    {
        internal InvokeTestTaskCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (InvokeTmxTestTaskCommand)Cmdlet;
            var task = cmdlet.InputObject;
            // 20141022
            // if (TestTaskStatuses.Accepted != task.TaskStatus)
            if (task.IsFinished())
                cmdlet.WriteError(cmdlet, "Task '" + task.Name + "' has been already processed", "AlreadyProcessed", ErrorCategory.InvalidData, true);
            
            loadCommonData();
            runTask(task);
			updateTask(task);
			sendTestResults();
			ClientSettings.Instance.CurrentTask = null;
        }
        
		void loadCommonData()
		{
		    var commonDataLoader = new CommonDataLoader(new RestRequestCreator());
		    // 20141030
		    // CommonData.Data = commonDataLoader.Load();
		    ClientSettings.Instance.CommonData.Data = commonDataLoader.Load();
		}
		
		void runTask(ITestTask task)
		{
			var taskRunner = new TaskRunner();
			var runResult = taskRunner.Run(task);
			task.TaskFinished = true;
			task.TaskStatus = runResult ? TestTaskStatuses.CompletedSuccessfully : TestTaskStatuses.Interrupted;
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
