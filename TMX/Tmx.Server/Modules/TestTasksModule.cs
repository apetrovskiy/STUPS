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
	using Tmx.Core.Types.Remoting;
	using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of TestTasksModule.
    /// </summary>
    public class TestTasksModule : NancyModule
    {
        public TestTasksModule() : base(UrnList.TestTasks_Root)
        {
            Get[UrnList.TestTasks_CurrentTaskForClientById] = parameters => returnTaskByClientId(parameters.id);
        	
            Put[UrnList.TestTasks_Task] = parameters => {
            	ITestTask loadedTask = this.Bind<TestTask>();
                return updateTask(loadedTask, parameters.id);
            };
        	
        	Get[UrnList.TestTasks_AllDesignated] = _ => returnAllDesignatedTasks();
            
            Get[UrnList.TestTasks_AllLoaded + "/"] = _ => returnAllLoadedTasks();
            
            Delete[UrnList.TestTasks_Task] = parameters => deleteAllocatedTaskById(parameters.id);
            
			Delete[UrnList.TestTasks_AllLoaded + UrnList.TestTasks_Task] = parameters => deleteLoadedTaskById(parameters).id;
        }
        
		Negotiator returnTaskByClientId(int clientId)
		{
            if (ClientsCollection.Clients.All(client => client.Id != clientId))
                return Negotiate.WithStatusCode(HttpStatusCode.ExpectationFailed);
			var taskSorter = new TaskSelector();
			ITestTask actualTask = taskSorter.GetFirstLegibleTask(clientId);
			// setting status
			// TODO: refactor
			if (null == actualTask)
                ClientsCollection.Clients.First(client => client.Id == clientId).Status = TestClientStatuses.NoTasks;
			ClientsCollection.Clients.First(client => client.Id == clientId).Status = TestClientStatuses.WorkflowInProgress;
			return null != actualTask ? Negotiate.WithModel(actualTask).WithStatusCode(HttpStatusCode.OK) : Negotiate.WithStatusCode(HttpStatusCode.NotFound);
		}

		HttpStatusCode updateTask(ITestTask loadedTask, int taskId)
		{
			if (null == loadedTask)
				throw new UpdateTaskException("Failed to update task with id = " + taskId);
			var storedTask = TaskPool.TasksForClients.First(task => task.Id == taskId && task.ClientId == loadedTask.ClientId);
			storedTask.TaskFinished = loadedTask.TaskFinished;
			storedTask.TaskStatus = loadedTask.TaskStatus;
			storedTask.TaskResult = loadedTask.TaskResult;
			var taskSorter = new TaskSelector();
			
			if (TestTaskStatuses.Failed == storedTask.TaskStatus)
				taskSorter.CancelFurtherTasks(storedTask.ClientId);
			
			if (storedTask.TaskFinished) {
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
			}
			return HttpStatusCode.OK;
		}
		
        Negotiator returnAllDesignatedTasks()
        {
        	return 0 == TaskPool.TasksForClients.Count ? Negotiate.WithStatusCode(HttpStatusCode.NotFound) : Negotiate.WithModel(TaskPool.TasksForClients).WithStatusCode(HttpStatusCode.OK);
        }
        
        Negotiator returnAllLoadedTasks()
        {
        	return 0 == TaskPool.Tasks.Count ? Negotiate.WithStatusCode(HttpStatusCode.NotFound) : Negotiate.WithModel(TaskPool.Tasks).WithStatusCode(HttpStatusCode.OK);
        }

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
