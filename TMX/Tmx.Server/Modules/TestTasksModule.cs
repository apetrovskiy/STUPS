/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/21/2014
 * Time: 10:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Modules
{
    using System;
    //using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Internal;
    using Nancy;
    using Nancy.ModelBinding;
    using Nancy.Responses.Negotiation;
    //using Nancy.TinyIoc;
    using Tmx.Interfaces.Exceptions;
    using Tmx.Interfaces.Server;
    using Core;
    using Core.Types.Remoting;
    using Tmx.Interfaces.Remoting;
    using Interfaces;
    
    /// <summary>
    /// Description of TestTasksModule.
    /// </summary>
    public class TestTasksModule : NancyModule
    {
        public TestTasksModule() : base(UrlList.TestTasks_Root)
        {
            Get[UrlList.TestTasks_CurrentTaskForClientById_relPath] = parameters => ReturnTaskByClientId(parameters.id);
            
            Put[UrlList.TestTasks_Task] = parameters => {
                // 20141020 squeezing a task to its proxy
                ITestTask loadedTask = this.Bind<TestTask>();
                // ITestTaskProxy loadedTask = this.Bind<TestTaskProxy>();
                // ITestTaskResultProxy loadedTask = this.Bind<TestTaskResultProxy>();
                return UpdateTask(loadedTask, parameters.id);
            };
            
            Delete[UrlList.TestTasks_Task] = parameters => DeleteAllocatedTaskById(parameters.id);
            
            Delete[UrlList.TestTasks_AllLoaded_relPath + UrlList.TestTasks_Task] = parameters => DeleteLoadedTaskById(parameters).id;
        }
        
        Negotiator ReturnTaskByClientId(Guid clientId)
        {
            Trace.TraceInformation("returnTaskByClientId(Guid clientId).1");
            
            if (ClientsCollection.Clients.All(client => client.Id != clientId))
                return Negotiate.WithStatusCode(HttpStatusCode.ExpectationFailed);
            
            Trace.TraceInformation("returnTaskByClientId(Guid clientId).2");

            var taskSelector = ServerObjectFactory.Resolve<TaskSelector>();
            
//try {
//    var taskSel = TinyIoCContainer.Current.Resolve<ITaskSelector>();
//    if (null == taskSel)
//        Console.WriteLine("null == taskSel");
//    else
//        Console.WriteLine("type is {0}", taskSel.GetType().Name);
//}
//catch (Exception ee) {
//    Console.WriteLine(ee.Message);
//}
            
            Trace.TraceInformation("returnTaskByClientId(Guid clientId).3");
            
            ITestTask actualTask = taskSelector.GetFirstLegitimateTask(clientId);
            
            Trace.TraceInformation("returnTaskByClientId(Guid clientId).4 actualTask is null? {0}", null == actualTask);
            
            var clientInQuestion = ClientsCollection.Clients.First(client => client.Id == clientId);
            
            Trace.TraceInformation("returnTaskByClientId(Guid clientId).5 clientInQuestion is null? {0}", null == clientInQuestion);
            Trace.TraceInformation("returnTaskByClientId(Guid clientId).6 clientInQuestion.Id = {0}, hostname = {1}", clientInQuestion.Id, clientInQuestion.Hostname);
            
            return null == actualTask ? returnNoTask_StatusNotFound(clientInQuestion) : returnTaskToClient_StatusOk(clientInQuestion, actualTask);
        }
        
        Negotiator returnNoTask_StatusNotFound(ITestClient testClient)
        {
            Trace.TraceInformation("returnNoTask_StatusNotFound(ITestClient testClient).1");
            
            testClient.SetNoTasksStatus();
            
            Trace.TraceInformation("returnNoTask_StatusNotFound(ITestClient testClient).2");
            
            return Negotiate.WithStatusCode(HttpStatusCode.NotFound);
        }
        
        Negotiator returnTaskToClient_StatusOk(ITestClient testClient, ITestTask actualTask)
        {
            testClient.Status = TestClientStatuses.Running;
            testClient.TaskId = actualTask.Id;
            testClient.TaskName = actualTask.Name;
            testClient.TestRunId = actualTask.TestRunId;
            // 20141020 squeezing a task to its proxy
            return Negotiate.WithModel(actualTask).WithStatusCode(HttpStatusCode.OK);
            // return Negotiate.WithModel(actualTask.SqueezeTaskToTaskResultProxy()).WithStatusCode(HttpStatusCode.OK);
            // return Negotiate.WithModel(actualTask.SqueezeTaskToTaskCodeProxy()).WithStatusCode(HttpStatusCode.OK);
        }
        
        // 20141020 squeezing a task to its proxy
        HttpStatusCode UpdateTask(ITestTask loadedTask, int taskId)
        // HttpStatusCode updateTask(ITestTaskResultProxy loadedTask, int taskId)
        {
            if (null == loadedTask)
                throw new UpdateTaskException("Failed to update task with id = " + taskId);
            var storedTask = TaskPool.TasksForClients.First(task => task.Id == taskId && task.ClientId == loadedTask.ClientId);
            // 20150112
            // storedTask.TaskFinished = loadedTask.TaskFinished;
            storedTask.TaskStatus = loadedTask.TaskStatus;
            storedTask.TaskResult = loadedTask.TaskResult;
            storedTask.StartTime = loadedTask.StartTime;

            // 20150317
            // var taskSelector = TinyIoCContainer.Current.Resolve<TaskSelector>();
            var taskSelector = ServerObjectFactory.Resolve<TaskSelector>();
            
//try {
//    var taskSel = TinyIoCContainer.Current.Resolve<ITaskSelector>();
//    if (null == taskSel)
//        Console.WriteLine("null == taskSel");
//    else
//        Console.WriteLine("type is {0}", taskSel.GetType().Name);
//}
//catch (Exception ee) {
//    Console.WriteLine(ee.Message);
//}
            
            if (storedTask.IsFailed())
                taskSelector.CancelFurtherTasksOfTestClient(storedTask.ClientId);
            if (storedTask.IsFinished())
                CleanUpClientDetailedStatus(storedTask.ClientId);
            
            if (storedTask.IsLastTaskInTestRun())
                CompleteTestRun(storedTask);
            
            if (storedTask.IsFinished())
                storedTask.SetTimeTaken();
            
            // 20150112
            // return storedTask.TaskFinished ? updateNextTaskAndReturnOk(taskSelector, storedTask) : HttpStatusCode.OK;
            return storedTask.IsCompletedSuccessfully() ? UpdateNextTaskAndReturnOk(taskSelector, storedTask) : HttpStatusCode.OK;
        }

        void CompleteTestRun(ITestTask task)
        {
            var currentTestRun = TestRunQueue.TestRuns.First(testRun => testRun.Id == task.TestRunId);
            currentTestRun.Status = TaskPool.TasksForClients.Any (tsk => tsk.TestRunId == currentTestRun.Id && tsk.TaskStatus == TestTaskStatuses.Interrupted) ? TestRunStatuses.Interrupted : TestRunStatuses.CompletedSuccessfully;
            currentTestRun.SetTimeTaken();
            
            if (!TestRunQueue.TestRuns.Any(testRun => testRun.TestLabId == currentTestRun.TestLabId && testRun.Id != currentTestRun.Id))
                TestLabCollection.TestLabs.First(testLab => testLab.Id == currentTestRun.TestLabId).Status = TestLabStatuses.Free;
            
            ActivateNextInRowTestRun();
        }
        
        void ActivateNextInRowTestRun()
        {
            var testRunSelector = ServerObjectFactory.Resolve<TestRunSelector>();
            var testRun = testRunSelector.GetNextInRowTestRun();
            if (null == testRun) return;
            if (TestRunQueue.TestRuns.Any(tr => tr.IsActive() && tr.TestLabId == testRun.TestLabId)) return;
            testRun.SetStartTime();
            testRun.Status = TestRunStatuses.Running;
        }
        
        HttpStatusCode UpdateNextTaskAndReturnOk(ITaskSelector taskSorter, ITestTask storedTask)
        {
            ITestTask nextTask = null;
            try {
                nextTask = taskSorter.GetNextLegitimateTask(storedTask.ClientId, storedTask.Id);
            } catch (Exception eFailedToGetNextTask) {
                // TODO: AOP
                Trace.TraceError("updateNextTaskAndReturnOk(TaskSelector taskSorter, ITestTask storedTask)");
                Trace.TraceError(eFailedToGetNextTask.Message);
                throw new FailedToGetNextTaskException(eFailedToGetNextTask.Message);
            }
            if (null == nextTask)
                return HttpStatusCode.OK;
            nextTask.PreviousTaskResult = storedTask.TaskResult;
            nextTask.PreviousTaskId = storedTask.Id;
            return HttpStatusCode.OK;
        }
        
        void CleanUpClientDetailedStatus(Guid clientId)
        {
            ClientsCollection.Clients.First(client => client.Id == clientId).DetailedStatus = string.Empty;
        }
        
        HttpStatusCode DeleteAllocatedTaskById(int taskId)
        {
            TaskPool.TasksForClients.RemoveAll(task => task.Id == taskId);
            return HttpStatusCode.NoContent;
        }

        HttpStatusCode DeleteLoadedTaskById(int taskId)
        {
            TaskPool.Tasks.RemoveAll(task => task.Id == taskId);
            return HttpStatusCode.NoContent;
        }
    }
}
