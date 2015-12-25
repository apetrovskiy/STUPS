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
    using System.Management.Automation;
    using Client;
    using Client.Library.ObjectModel;
    using Commands;
    using Core;
    using Core.Proxy;
    using Interfaces.Remoting;

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
            
            LoadCommonData();
            RunTask(task);

            //// 20150907
            //if (task.IsCritical && TestStatuses.Failed == TestData.TestSuites.GetOveralStatus())
            //    task.TaskStatus = TestTaskStatuses.FailedByTestResults;
            // 20150910
            task.CheckTestStatus();

            UpdateTask(task);
            SendTestResults();
            ClientSettings.Instance.CurrentTask = null;
        }
        
        void LoadCommonData()
        {
            // 20150918
            // var commonDataLoader = new CommonDataLoader(new RestRequestCreator());
            // var commonDataLoader = new CommonDataLoader();
            var commonDataLoader = ProxyFactory.Get<CommonDataLoader>();
            ClientSettings.Instance.CommonData.Data = commonDataLoader.Load();
        }
        
        void RunTask(ITestTask task)
        {
            // var taskRunner = new TaskRunner();
            var taskRunner = ProxyFactory.Get<TaskRunner>();
            var runResult = taskRunner.Run(task);
            // 20150112
            // task.TaskFinished = true
            task.TaskStatus = runResult ? TestTaskStatuses.CompletedSuccessfully : TestTaskStatuses.ExecutionFailed;
            //// 20150908
            //if (TestStatuses.Failed == TestData.TestSuites.GetOveralStatus())
            //    task.TaskStatus = TestTaskStatuses.FailedByTestResults;
            // 20150910
            //if (task.IsCritical && TestStatuses.Failed == TestData.TestSuites.GetOveralStatus())
            //    task.TaskStatus = TestTaskStatuses.FailedByTestResults;
            task.CheckTestStatus();
        }
        
        void UpdateTask(ITestTask task)
        {
            // 20150918
            // var taskUpdater = new TaskUpdater(new RestRequestCreator());
            // var taskUpdater = new TaskUpdater();
            var taskUpdater = ProxyFactory.Get<TaskUpdater>();
            taskUpdater.UpdateTask(task);
        }
        
        void SendTestResults()
        {
            // 20150918
            // var testResultsSender = new TestResultsSender(new RestRequestCreator());
            // var testResultsSender = new TestResultsSender();
            var testResultsSender = ProxyFactory.Get<TestResultsSender>();
            var result = testResultsSender.SendTestResults();
            if (result)
                TestData.ResetData();
        }
    }
}
