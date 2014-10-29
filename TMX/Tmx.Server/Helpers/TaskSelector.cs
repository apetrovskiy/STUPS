/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/22/2014
 * Time: 8:40 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Security.Cryptography;
	using System.Text.RegularExpressions;
	using Tmx.Core;
	using Tmx.Interfaces.Remoting;
	
	/// <summary>
	/// Description of TaskSelector.
	/// </summary>
	public class TaskSelector
	{
	    public virtual List<ITestTask> SelectTasksForClient(int clientId, List<ITestTask> tasks)
	    {
	        var resultTaskScope = new List<ITestTask>();
	        
	        var client = ClientsCollection.Clients.First(c => c.Id == clientId);
	        // TODO: use IDisposable or DI
	        // using (var client = ClientsCollection.Clients.First(c => c.Id == clientId)) {
	        
	        if (null == client) return resultTaskScope;
	        
	        // TODO: add IsAdmin and IsInteractive to the checking
//	        resultTaskScope =
//	        	tasks.Where(task => // 0 == task.ClientId && 
//	        	                     (Regex.IsMatch(client.CustomString ?? string.Empty, task.Rule)  ||
//	        	                      Regex.IsMatch(client.EnvironmentVersion ?? string.Empty, task.Rule) ||
//	        	                      Regex.IsMatch(client.Fqdn ?? string.Empty, task.Rule) ||
//	        	                      Regex.IsMatch(client.Hostname ?? string.Empty, task.Rule) ||
//	        	                      // task.Rule == client.IsAdmin.ToString() ||
//	        	                      // task.Rule == client.IsInteractive.ToString() ||
//	        	                      // Regex.IsMatch(client.OsEdition ?? string.Empty, task.Rule) ||
//	        	                      // Regex.IsMatch(client.OsName ?? string.Empty, task.Rule) ||
//	        	                      Regex.IsMatch(client.OsVersion ?? string.Empty, task.Rule) ||
//	        	                      Regex.IsMatch(client.UserDomainName ?? string.Empty, task.Rule) ||
//	        	                      Regex.IsMatch(client.Username ?? string.Empty, task.Rule))
//	                        // 20141023
//	                                // ).Select(t => { var newTask = t.CloneTaskForNewTestClient(); newTask.ClientId = clientId; return newTask; }).ToList<ITestTask>();
//	                               // ).Select(t => { var newTask = t.CloneTaskForNewTestClient(); newTask.ClientId = clientId; newTask.WorkflowId = WorkflowCollection.ActiveWorkflow.Id; return newTask; }).ToList<ITestTask>();
//	                               ).Select(t => { var newTask = t.CloneTaskForNewTestClient(); newTask.ClientId = clientId; return newTask; }).ToList<ITestTask>();
	        
	        // var workflowSelectionIds = WorkflowCollection.Workflows.Select(wfl => wfl.Id).Intersect(TestRunQueue.TestRuns.Where(tr => tr.Status == TestRunStatuses.Running).Select(tr => tr.WorkflowId));
//	        var workflowSelectionIds = WorkflowCollection.Workflows.ActiveWorkflowIds();
	        
	        
            var workflowId = TestRunQueue.TestRuns.First(testRun => testRun.Id == client.TestRunId).WorkflowId;
	        
            resultTaskScope =
	            // tasks.Where(task => workflowSelectionIds.Contains(task.WorkflowId))
                tasks.Where(task => task.WorkflowId == workflowId)
	            .Where(task => // 0 == task.ClientId && 
	        	                        (Regex.IsMatch(client.CustomString ?? string.Empty, task.Rule) ||
                                        Regex.IsMatch(client.EnvironmentVersion ?? string.Empty, task.Rule) ||
                                        Regex.IsMatch(client.Fqdn ?? string.Empty, task.Rule) ||
                                        Regex.IsMatch(client.Hostname ?? string.Empty, task.Rule) ||
                                        // task.Rule == client.IsAdmin.ToString() ||
                                        // task.Rule == client.IsInteractive.ToString() ||
                                        // Regex.IsMatch(client.OsEdition ?? string.Empty, task.Rule) ||
                                        // Regex.IsMatch(client.OsName ?? string.Empty, task.Rule) ||
                                        Regex.IsMatch(client.OsVersion ?? string.Empty, task.Rule) ||
                                        Regex.IsMatch(client.UserDomainName ?? string.Empty, task.Rule) ||
                                        Regex.IsMatch(client.Username ?? string.Empty, task.Rule))
	                        // 20141023
	                                // ).Select(t => { var newTask = t.CloneTaskForNewTestClient(); newTask.ClientId = clientId; return newTask; }).ToList<ITestTask>();
	                               // ).Select(t => { var newTask = t.CloneTaskForNewTestClient(); newTask.ClientId = clientId; newTask.WorkflowId = WorkflowCollection.ActiveWorkflow.Id; return newTask; }).ToList<ITestTask>();
            ).Select(t => {
                var newTask = t.CloneTaskForNewTestClient();
                newTask.ClientId = clientId;
                return newTask;
            }).ToList<ITestTask>();
            
            return resultTaskScope;
	    }
	    
		public virtual ITestTask GetFirstLegibleTask(int clientId)
		{
			var taskListForClient = getOnlyNewTestTasksForClient(clientId);
			if (null == taskListForClient || !taskListForClient.Any()) return null;
			// 20141023
			// var taskCandidate = taskListForClient.First(task => task.Id == taskListForClient.Min(tsk => tsk.Id));
			// var taskCandidate = taskListForClient.Where(task => task.WorkflowId == ClientsCollection.Clients.First(client => client.Id == clientId).TestRunId).First(task => task.Id == taskListForClient.Min(tsk => tsk.Id));
			
//			var taskCands = taskListForClient.Where(task => task.TestRunId == ClientsCollection.Clients.First(client => client.Id == clientId).TestRunId);
//			if (null == taskCands)
//			    Console.WriteLine("");
//			else
//			    foreach (var t in taskCands) {
//                    Console.WriteLine("task id = {0}, name = {1}", t.Id, t.Name);
//			    }
//			var taskCand = taskCands.First(task => task.Id == taskListForClient.Min(tsk => tsk.Id));
			
			
			// var taskCandidate = taskListForClient.Where(task => task.TestRunId == ClientsCollection.Clients.First(client => client.Id == clientId).TestRunId).First(task => task.Id == taskListForClient.Min(tsk => tsk.Id));
			var taskCandidate = taskListForClient.First(task => task.Id == taskListForClient.Min(tsk => tsk.Id));
			return isItTimeToPublishTask(taskCandidate) ? taskCandidate : null;
		}
		
		public virtual ITestTask GetNextLegibleTask(int clientId, int currentTaskId)
		{
			var taskListForClient = getOnlyNewTestTasksForClient(clientId);
			if (null == taskListForClient || !taskListForClient.Any()) return null;
			var tasksToBeNextOne = taskListForClient.Where(t => t.Id > currentTaskId);
			if (null == tasksToBeNextOne || !tasksToBeNextOne.Any()) return null;
			
			return taskListForClient.First(task => task.Id == tasksToBeNextOne.Min(tsk => tsk.Id));
		}
		
        public virtual void CancelFurtherTasks(int clientId)
        {
//             TaskPool.TasksForClients
//                 // 20141022
//                 // .Where(task => task.ClientId == clientId && task.TaskStatus != TestTaskStatuses.Failed && task.TaskStatus != TestTaskStatuses.CompletedSuccessfully)
//                 // .Where(task => task.ClientId == clientId && !task.IsFinished() && !task.IsCancelled()) // ??
//                 // 20141023
//                 // .Where(task => task.ClientId == clientId && !task.IsFinished())
//                 .Where(task => task.ClientId == clientId && !task.IsFinished() && task.WorkflowId == WorkflowCollection.ActiveWorkflow.Id)
//                 .ToList()
//                 .ForEach(task => task.TaskStatus = TestTaskStatuses.Canceled);
            TaskPool.TasksForClients
                .Where(task => task.ClientId == clientId && !task.IsFinished())
                .ToList()
                .ForEach(task => task.TaskStatus = TestTaskStatuses.Canceled);
        }
        
		internal virtual IEnumerable<ITestTask> getOnlyNewTestTasksForClient(int clientId)
		{
		    return TaskPool.TasksForClients.Where(task => task.ClientId == clientId && task.IsActive && task.TaskStatus == TestTaskStatuses.New);
		    // return TaskPool.TasksForClients.Where(task => task.ClientId == clientId && task.TestRunId == ClientsCollection.Clients.First(client => client.Id == clientId).TestRunId && task.TaskStatus == TestTaskStatuses.New);
		    // .Where(task => task.TestRunId == ClientsCollection.Clients.First(client => client.Id == clientId).TestRunId);
		}
		
		internal virtual bool isItTimeToPublishTask(ITestTask task)
		{
		    var numberOfMustDoneBeforeTask = task.AfterTask;
            if (0 == numberOfMustDoneBeforeTask) return true;
			return TaskPool.TasksForClients.Any(t => t.Id == numberOfMustDoneBeforeTask) && !TaskPool.TasksForClients.Any(t => t.Id == numberOfMustDoneBeforeTask && !t.TaskFinished);
        }
	}
}
