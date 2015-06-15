namespace Tmx.Server.Logic.ObjectModel
{
    using System;
    using System.Linq;
    using Core;
    using ExtensionMethods;
    using Internal;
    using Objects;
    using Tmx.Interfaces.Exceptions;
    using Tmx.Interfaces.Remoting;

    public class TestTaskCollectionMethods
    {
        public void UpdateTestClientWithActiveTask(ITestClient testClient, ITestTask actualTask)
        {
            testClient.Status = TestClientStatuses.Running;
            testClient.TaskId = actualTask.Id;
            testClient.TaskName = actualTask.Name;
            testClient.TestRunId = actualTask.TestRunId;
        }

        public ITestTask UpdateTask(ITestTask loadedTask, int taskId)
        {
            if (null == loadedTask)
                throw new UpdateTaskException("Failed to update task with id = " + taskId);
            var storedTask = TaskPool.TasksForClients.First(task => task.Id == taskId && task.ClientId == loadedTask.ClientId);
            storedTask.TaskStatus = loadedTask.TaskStatus;
            storedTask.TaskResult = loadedTask.TaskResult;
            storedTask.StartTime = loadedTask.StartTime;

            var taskSelector = ServerObjectFactory.Resolve<TaskSelector>();

            if (storedTask.IsFailed())
                taskSelector.CancelFurtherTasksOfTestClient(storedTask.ClientId);
            if (storedTask.IsFinished())
                CleanUpClientDetailedStatus(storedTask.ClientId);

            if (storedTask.IsLastTaskInTestRun())
                CompleteTestRun(storedTask);

            if (storedTask.IsFinished())
                storedTask.SetTimeTaken();

            if (storedTask.IsCompletedSuccessfully())
                UpdateNextTask(storedTask);

            return storedTask;
        }

        void CompleteTestRun(ITestTask task)
        {
            var currentTestRun = TestRunQueue.TestRuns.First(testRun => testRun.Id == task.TestRunId);
            currentTestRun.Status = TaskPool.TasksForClients.Any(tsk => tsk.TestRunId == currentTestRun.Id && tsk.TaskStatus == TestTaskStatuses.Interrupted) ? TestRunStatuses.Interrupted : TestRunStatuses.CompletedSuccessfully;
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

        public bool UpdateNextTask(ITestTask storedTask)
        {
            // ITestTask nextTask = null;
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