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
	using TMX.Interfaces.Server;
	using Tmx.Interfaces.Remoting;
	using Tmx.Interfaces.Types.Remoting;
    
    /// <summary>
    /// Description of TestTasksModule.
    /// </summary>
    public class TestTasksModule : NancyModule
    {
        public TestTasksModule() : base(UrnList.TestTasks_Root)
        {
            Get[UrnList.TestTasks_CurrentClient] = parameters => {
                var taskSorter = new TaskSorter();
                // 20140731
                // List<ITestTask> taskList = taskSorter.GetTasksForClient(parameters.id);
                // ITestTask actualTask = taskList.First(task => task.IsActive && !task.Completed && task.Id == taskList.Where(tsk => !tsk.Completed && tsk.IsActive).Min(t => t.Id));
                // actualTask.ClientId = parameters.id;
//                var actualTask =
//                	TaskPool.Tasks.First(task => 
//                	                     task.ClientId == parameters.id && 
//                	                     task.IsActive && 
//                	                     !task.Completed && 
//                	                     task.Id == TaskPool.Tasks.Where(tsk => 
//                	                                                     tsk.ClientId == parameters.id && 
//                	                                                     !tsk.Completed && 
//                	                                                     tsk.IsActive).Min(t => t.Id));
                
                ITestTask actualTask = taskSorter.GetFirstLegibleTask(parameters.id);
                
                
                // return Response.AsJson(actualTask).WithStatusCode(HttpStatusCode.OK);
                return null != actualTask ? Response.AsJson(actualTask).WithStatusCode(HttpStatusCode.OK) : HttpStatusCode.NotFound;
            };
            
            Put[UrnList.TestTasks_Task] = parameters => {
                var loadedTask = this.Bind<TestTask>();
                var storedTask = TaskPool.Tasks.First(task => task.Id == loadedTask.Id);
                storedTask.Completed = loadedTask.Completed;
                storedTask.Status = loadedTask.Status;
                storedTask.TaskResult = loadedTask.TaskResult;
                var taskSorter = new TaskSorter();
                List<ITestTask> taskList = taskSorter.SelectTasksForClient(loadedTask.ClientId);
                var nextTask = taskList.First(task => task.IsActive && !task.Completed && task.Id == taskList.Where(tsk => !tsk.Completed && tsk.IsActive && tsk.Id > loadedTask.Id).Min(t => t.Id));
                nextTask.PreviousTaskResult = storedTask.TaskResult ?? new string[] {};
                nextTask.PreviousTaskId = loadedTask.Id;
                return HttpStatusCode.OK;
            };
        }
    }
}
