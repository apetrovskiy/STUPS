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
	using Tmx.Interfaces;
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
                List<ITestTask> taskList = taskSorter.GetTasksForClient(parameters.id);
                ITestTask actualTask = taskList.First(task => task.On && !task.Completed && task.Id == taskList.Min(t => t.Id));
                return Response.AsJson(actualTask).WithStatusCode(HttpStatusCode.OK);
            };
            
            Put[UrnList.TestTasks_Task] = parameters => {
                var loadedTask = this.Bind<TestTask>();
                var storedTask = TaskPool.Tasks.First(task => task.Id == loadedTask.Id);
                storedTask.Completed = loadedTask.Completed;
                storedTask.Status = loadedTask.Status;
                storedTask.TaskResult = loadedTask.TaskResult;
                return HttpStatusCode.OK;
            };
        }
    }
}
