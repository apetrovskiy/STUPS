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
    using System.Collections.Generic;
    using System.Linq;
	using Nancy;
	using Nancy.ModelBinding;
    using Nancy.Responses.Negotiation;
	using Tmx.Interfaces.Exceptions;
	using Tmx.Interfaces.Server;
	using Tmx.Core;
	using Tmx.Core.Types.Remoting;
	using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of TestTasksModule.
    /// </summary>
    public class TestTasksModule : NancyModule
    {
        public TestTasksModule() : base(UrnList.TestTasks_Root)
        {
            Get[UrnList.TestTasks_CurrentTaskForClientById_relPath] = parameters => returnTaskByClientId(parameters.id);
        	
            Put[UrnList.TestTasks_Task] = parameters => {
                // 20141020
            	ITestTask loadedTask = this.Bind<TestTask>();
            	// ITestTaskProxy loadedTask = this.Bind<TestTaskProxy>();
            	// ITestTaskResultProxy loadedTask = this.Bind<TestTaskResultProxy>();
                return updateTask(loadedTask, parameters.id);
                // return updateTask(loadedTask, parameters.id);
            };
        	
            // 20141003
            // temporarily hidden
//        	Get[UrnList.TestTasks_AllDesignated] = _ => returnAllDesignatedTasks();
//            
//            Get[UrnList.TestTasks_AllLoaded + "/"] = _ => returnAllLoadedTasks();
            
            Delete[UrnList.TestTasks_Task] = parameters => deleteAllocatedTaskById(parameters.id);
            
			Delete[UrnList.TestTasks_AllLoaded_relPath + UrnList.TestTasks_Task] = parameters => deleteLoadedTaskById(parameters).id;
        }
        
		Negotiator returnTaskByClientId(int clientId)
        {
            if (ClientsCollection.Clients.All(client => client.Id != clientId))
                return Negotiate.WithStatusCode(HttpStatusCode.ExpectationFailed);
            var taskSorter = new TaskSelector();
            ITestTask actualTask = taskSorter.GetFirstLegibleTask(clientId);
            var clientInQuestion = ClientsCollection.Clients.First(client => client.Id == clientId);
            return null == actualTask ? returnStatusTaskNotFound(clientInQuestion) : returnTaskToClientAndOk(clientInQuestion, actualTask);
        }
		
        Negotiator returnStatusTaskNotFound(ITestClient testClient)
        {
            testClient.Status = TestClientStatuses.NoTasks;
            return Negotiate.WithStatusCode(HttpStatusCode.NotFound);
        }
        
        Negotiator returnTaskToClientAndOk(ITestClient testClient, ITestTask actualTask)
        {
            testClient.Status = TestClientStatuses.WorkflowInProgress;
            testClient.TaskId = actualTask.Id;
            testClient.TaskName = actualTask.Name;
            testClient.WorkflowId = actualTask.WorkflowId;
            // 20141020
            return Negotiate.WithModel(actualTask).WithStatusCode(HttpStatusCode.OK);
            // return Negotiate.WithModel(actualTask.SqueezeTaskToTaskResultProxy()).WithStatusCode(HttpStatusCode.OK);
        }
        
        // 20141020
		HttpStatusCode updateTask(ITestTask loadedTask, int taskId)
		// HttpStatusCode updateTask(ITestTaskResultProxy loadedTask, int taskId)
		{
			if (null == loadedTask)
				throw new UpdateTaskException("Failed to update task with id = " + taskId);
			var storedTask = TaskPool.TasksForClients.First(task => task.Id == taskId && task.ClientId == loadedTask.ClientId);
			storedTask.TaskFinished = loadedTask.TaskFinished;
			storedTask.TaskStatus = loadedTask.TaskStatus;
			storedTask.TaskResult = loadedTask.TaskResult;
			storedTask.StartTime = loadedTask.StartTime;
			
			var taskSorter = new TaskSelector();
			// 20141022
			// if (TestTaskStatuses.Failed == storedTask.TaskStatus)
			if (storedTask.IsFailed())
				taskSorter.CancelFurtherTasks(storedTask.ClientId);
			// 20141022
			// if (TestTaskStatuses.Accepted == storedTask.TaskStatus)
			if (storedTask.IsFinished())
			    cleanUpClientdetailedStatus(storedTask.ClientId);
			
			updateWorklowStatus(storedTask.WorkflowId);
			
            return storedTask.TaskFinished ? updateNextTaskAndReturnOk(taskSorter, storedTask) : HttpStatusCode.OK;
		}
		
        HttpStatusCode updateNextTaskAndReturnOk(TaskSelector taskSorter, ITestTask storedTask)
        {
            ITestTask nextTask = null;
            try {
                nextTask = taskSorter.GetNextLegibleTask(storedTask.ClientId, storedTask.Id);
            } catch (Exception eFailedToGetNextTask) {
                throw new FailedToGetNextTaskException(eFailedToGetNextTask.Message);
            }
            if (null == nextTask)
                return HttpStatusCode.OK;
            nextTask.PreviousTaskResult = storedTask.TaskResult;
            nextTask.PreviousTaskId = storedTask.Id;
            return HttpStatusCode.OK;
        }
        
        void cleanUpClientdetailedStatus(int clientId)
        {
            ClientsCollection.Clients.First(client => client.Id == clientId).DetailedStatus = string.Empty;
        }
        
        void updateWorklowStatus(int workflowId)
        {
            // 20141022
            // if (TaskPool.TasksForClients.All(task => task.WorkflowId == workflowId && task.TaskStatus != TestTaskStatuses.Accepted && task.TaskStatus != TestTaskStatuses.New))
            if (TaskPool.TasksForClients.All(task => task.WorkflowId == workflowId && task.IsFinished()))
                WorkflowCollection.Workflows.Where(wfl => wfl.Id == workflowId).AsEnumerable().ToList().ForEach(wfl => wfl.WorkflowStatus = WorkflowStatuses.NoTasks);
        }
        
		// 20141003
		// temporarily hidden
//        Negotiator returnAllDesignatedTasks()
//        {
//        	return 0 == TaskPool.TasksForClients.Count ? Negotiate.WithStatusCode(HttpStatusCode.NotFound) : Negotiate.WithModel(TaskPool.TasksForClients).WithStatusCode(HttpStatusCode.OK);
//        }
//        
//        Negotiator returnAllLoadedTasks()
//        {
//        	return 0 == TaskPool.Tasks.Count ? Negotiate.WithStatusCode(HttpStatusCode.NotFound) : Negotiate.WithModel(TaskPool.Tasks).WithStatusCode(HttpStatusCode.OK);
//        }

		HttpStatusCode deleteAllocatedTaskById(int taskId)
		{
			TaskPool.TasksForClients.RemoveAll(task => task.Id == taskId);
			return HttpStatusCode.NoContent;
		}
		HttpStatusCode deleteLoadedTaskById(int taskId)
		{
			TaskPool.Tasks.RemoveAll(task => task.Id == taskId);
			return HttpStatusCode.NoContent;
		}
    }
}
