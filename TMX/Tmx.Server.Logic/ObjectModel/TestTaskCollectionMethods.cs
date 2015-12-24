namespace Tmx.Server.Logic.ObjectModel
{
    using System;
    using System.Linq;
    using Core;
    using ExtensionMethods;
    using Internal;
    using Objects;
    using Tmx.Interfaces;
    using Tmx.Interfaces.Exceptions;
    using Tmx.Interfaces.Remoting;

    public class TestTaskCollectionMethods
    {
        public virtual void UpdateTestClientWithActiveTask(ITestClient testClient, ITestTask actualTask)
        {
            testClient.Status = TestClientStatuses.Running;
            testClient.TaskId = actualTask.Id;
            testClient.TaskName = actualTask.Name;
            testClient.TestRunId = actualTask.TestRunId;
        }

        public virtual ITestTask UpdateTask(ITestTask loadedTask, int taskId)
        {
            if (null == loadedTask)
                // throw new UpdateTaskException("Failed to update task with id = " + taskId);
                // throw new UpdateTaskException(string.Format("Failed to update task with id = {0}", taskId));
                throw new UpdateTaskException(string.Format(Messages.UpdateTaskException, taskId));
            var storedTask = TaskPool.TasksForClients.First(task => task.Id == taskId && task.ClientId == loadedTask.ClientId);
            storedTask.TaskStatus = loadedTask.TaskStatus;
            storedTask.TaskResult = loadedTask.TaskResult;
            storedTask.StartTime = loadedTask.StartTime;
            // 20150908
            storedTask.TestStatus = loadedTask.TestStatus;

            var taskSelector = ServerObjectFactory.Resolve<TaskSelector>();

            if (storedTask.IsFailed())
                taskSelector.CancelFurtherTasksOfTestClient(storedTask.ClientId);
            // 20150908
            if (storedTask.IsFailed() && storedTask.IsCritical)
                taskSelector.CancelFurtherTasksOfTestRun(storedTask.TestRunId);

            if (storedTask.IsFinished())
                CleanUpClientDetailedStatus(storedTask.ClientId);

            // 20150908
            if (storedTask.IsLastTaskInTestRun())
            // 20150909
            // comment it back
            // if (storedTask.IsLastTaskInTestRun() && storedTask.TaskStatus != TestTaskStatuses.Running) // ??
                CompleteTestRun(storedTask);

            if (storedTask.IsFinished())
                storedTask.SetFinishTime();

            if (storedTask.IsCompletedSuccessfully())
                UpdateNextTask(storedTask);

            return storedTask;
        }
        
        void CompleteTestRun(ITestTask task)
        {
            var currentTestRun = TestRunQueue.TestRuns.First(testRun => testRun.Id == task.TestRunId);
            // 20150907
            // currentTestRun.Status = TaskPool.TasksForClients.Any(tsk => tsk.TestRunId == currentTestRun.Id && tsk.TaskStatus == TestTaskStatuses.ExecutionFailed) ? TestRunStatuses.InterruptedOnTaskFailure : TestRunStatuses.Finished;
            // currentTestRun.Status = TaskPool.TasksForClients.Any(tsk => tsk.TestRunId == currentTestRun.Id && (tsk.TaskStatus == TestTaskStatuses.ExecutionFailed || tsk.TaskStatus == TestTaskStatuses.FailedByTestResults)) ? TestRunStatuses.InterruptedOnTaskFailure : TestRunStatuses.Finished;
            // 20150908
            //currentTestRun.Status =
            //    TaskPool.TasksForClients.Any(
            //        tsk => tsk.TestRunId == currentTestRun.Id && tsk.TaskStatus == TestTaskStatuses.ExecutionFailed)
            //        ? TestRunStatuses.InterruptedOnTaskFailure
            //        : TaskPool.TasksForClients.Any(
            //            tsk =>
            //                tsk.TestRunId == currentTestRun.Id && tsk.TaskStatus == TestTaskStatuses.FailedByTestResults)
            //            ? TestRunStatuses.InterruptedOnCriticalTask
            //            : TestRunStatuses.Finished;

            var tasksForTestRun = TaskPool.TasksForClients.Where(tsk => tsk.TestRunId == currentTestRun.Id);
            var tasksForTestRunAsArray = tasksForTestRun as ITestTask[] ?? tasksForTestRun.ToArray();
            //currentTestRun.Status = tasksForTestRunAsArray.Any(tsk => tsk.TaskStatus == TestTaskStatuses.ExecutionFailed)
            //    ? TestRunStatuses.InterruptedOnTaskFailure
            //    : tasksForTestRunAsArray.Any(tsk => tsk.TaskStatus == TestTaskStatuses.FailedByTestResults)
            //        ? TestRunStatuses.InterruptedOnCriticalTask
            //        : TestRunStatuses.Finished;
            currentTestRun.Status =
                tasksForTestRunAsArray.Any(tsk => tsk.TaskStatus == TestTaskStatuses.FailedByTestResults)
                    ? TestRunStatuses.InterruptedOnCriticalTask
                    : tasksForTestRunAsArray.Any(tsk => tsk.TaskStatus == TestTaskStatuses.ExecutionFailed)
                        ? TestRunStatuses.InterruptedOnTaskFailure
                        : tasksForTestRunAsArray.Any(tsk => tsk.TaskStatus == TestTaskStatuses.InterruptedByUser || tsk.TaskStatus == TestTaskStatuses.Canceled)
                            ? TestRunStatuses.Canceled
                            : TestRunStatuses.Finished;

            // 20150807
            // 20150908
            // if (TestRunStatuses.InterruptedOnTaskFailure == currentTestRun.Status)
            // 20150909
            /*
            if (TestRunStatuses.InterruptedOnTaskFailure == currentTestRun.Status || TestRunStatuses.InterruptedOnCriticalTask == currentTestRun.Status)
                currentTestRun.UnregisterClients();
            */

            currentTestRun.SetTimeTaken();
            
            if (!TestRunQueue.TestRuns.Any(testRun => testRun.TestLabId == currentTestRun.TestLabId && testRun.Id != currentTestRun.Id))
                TestLabCollection.TestLabs.First(testLab => testLab.Id == currentTestRun.TestLabId).Status = TestLabStatuses.Free;
            
            ActivateNextInRowTestRun();
        }
        
        void CleanUpClientDetailedStatus(Guid clientId)
        {
            ClientsCollection.Clients.First(client => client.Id == clientId).DetailedStatus = string.Empty;
        }

        void ActivateNextInRowTestRun()
        {
            ServerObjectFactory.Resolve<TestRunSelector>().RunNextInRowTestRun();
        }

        public virtual bool UpdateNextTask(ITestTask storedTask)
        {
            ITestTask nextTask;
            var taskSorter = ServerObjectFactory.Resolve<TaskSelector>();
            try
            {
                nextTask = taskSorter.GetNextLegitimateTask(storedTask.ClientId, storedTask.Id);
            }
            catch (Exception eFailedToGetNextTask)
            {
                // TODO: AOP
                // Trace.TraceError("updateNextTaskAndReturnOk(TaskSelector taskSorter, ITestTask storedTask)");
                // Trace.TraceError(eFailedToGetNextTask.Message);
                throw new FailedToGetNextTaskException(eFailedToGetNextTask.Message);
            }
            if (null == nextTask)
                return true;
            nextTask.PreviousTaskResult = storedTask.TaskResult;
            nextTask.PreviousTaskId = storedTask.Id;
            return true;
        }
    }
}