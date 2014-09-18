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
	using TMX.Interfaces.Exceptions;
	using TMX.Interfaces.Server;
	using Tmx.Core.Types.Remoting;
	using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of TestTasksModule.
    /// </summary>
    public class TestTasksModule : NancyModule
    {
        public TestTasksModule() : base(UrnList.TestTasks_Root)
        {
            Get[UrnList.TestTasks_CurrentClient] = parameters => {
				var taskSorter = new TaskSelector();
				ITestTask actualTask = taskSorter.GetFirstLegibleTask(parameters.id);
				return null != actualTask ? Response.AsJson(actualTask).WithStatusCode(HttpStatusCode.OK) : HttpStatusCode.NotFound;
			};
            
            Get[UrnList.TestTasks_AllDesignated] = _ => Response.AsJson(TaskPool.TasksForClients).WithStatusCode(HttpStatusCode.OK);
            
            Put[UrnList.TestTasks_Task] = parameters => {
                ITestTask loadedTask = this.Bind<TestTask>();
                if (null == loadedTask) throw new UpdateTaskException("Failed to update task with id = " + parameters.id);
                var storedTask = TaskPool.TasksForClients.First(task => task.Id == parameters.id && task.ClientId == loadedTask.ClientId);
                storedTask.TaskFinished = loadedTask.TaskFinished;
                storedTask.TaskStatus = loadedTask.TaskStatus;
                
                var taskSorter = new TaskSelector();
                if (TestTaskStatuses.Failed == storedTask.TaskStatus)
                    taskSorter.CancelFurtherTasks(storedTask.ClientId);
                
                if (storedTask.TaskFinished) {
                    ITestTask nextTask = null;
                    try {
                        nextTask = taskSorter.GetNextLegibleTask(storedTask.ClientId, storedTask.Id);
                    }
                    catch (Exception eFailedToGetNextTask) {
                        throw new FailedToGetNextTaskException(eFailedToGetNextTask.Message);
                    }
                    
                    if (null == nextTask) return HttpStatusCode.OK;
                    nextTask.PreviousTaskResult = storedTask.TaskResult;
                    nextTask.PreviousTaskId = storedTask.Id;
                }
                return HttpStatusCode.OK;
            };
        	
        	Put[UrnList.CurrentTaskOfCurrentClient] = parameters => {
                ITestTask loadedTask = this.Bind<TestTask>();
                if (null == loadedTask) throw new UpdateTaskException("Failed to send results to task, client id = " + parameters.id);
                
                var taskSorter = new TaskSelector();
                var actualTask = taskSorter.GetFirstLegibleTask(parameters.id) as TestTask;
				var currentTaskResult = actualTask.TaskResult ?? new Dictionary<string, string>();
				// TODO: improve
				// actualTask.TaskResult = currentTaskResult.Concat(loadedTask.TaskResult).ToList<object>();
				// actualTask.TaskResult = currentTaskResult..Concat(loadedTask.TaskResult);
                foreach (var pair in loadedTask.TaskResult) {
                    currentTaskResult.Add(pair.Key, pair.Value);
                }
                actualTask.TaskResult = currentTaskResult;
                return HttpStatusCode.OK;        		
        	};
        }
    }
}
