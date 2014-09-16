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
	        resultTaskScope =
	        	tasks.Where(task => // 0 == task.ClientId && 
	        	                     (Regex.IsMatch(client.CustomString ?? string.Empty, task.Rule)  ||
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
	                                ).Select(t => { var newTask = t.CloneTaskForNewTestClient(); newTask.ClientId = clientId; return newTask; }).ToList<ITestTask>();
            return resultTaskScope;
	    }
	    
		public virtual ITestTask GetFirstLegibleTask(int clientId)
		{
			var taskListForClient = getOnlyNewTestTasksForClient(clientId);
			if (null == taskListForClient || !taskListForClient.Any()) return null;
			var taskCandidate = taskListForClient.First(task => task.Id == taskListForClient.Min(tsk => tsk.Id));
			return isItTimeToPublishTask(taskCandidate) ? taskCandidate : null;
		}
		
		public virtual ITestTask GetNextLegibleTask(int clientId, int currentTaskId)
		{
			var taskListForClient = getOnlyNewTestTasksForClient(clientId);
			if (null == taskListForClient || !taskListForClient.Any()) return null;
			return taskListForClient.First(task => task.Id == taskListForClient.Where(t => t.Id > currentTaskId).Min(tsk => tsk.Id));
		}
		
		internal virtual IEnumerable<ITestTask> getOnlyNewTestTasksForClient(int clientId)
		{
		    return TaskPool.TasksForClients.Where(task => task.ClientId == clientId && task.IsActive && !task.TaskFinished);
		}
		
		internal virtual bool isItTimeToPublishTask(ITestTask task)
		{
		    var numberOfMustDoneBeforeTask = task.AfterTask;
//		    if (0 == tasksThatShouldBeCompletedBefore) return true;
//			return !TaskPool.TasksForClients.Any(t => t.Id == tasksThatShouldBeCompletedBefore && t.TaskStatus != TestTaskStatuses.CompletedSuccessfully);
		    // 20140914
			// return 0 == numberOfMustDoneBeforeTask || !TaskPool.TasksForClients.Any(t => t.Id == numberOfMustDoneBeforeTask && t.TaskStatus != TestTaskStatuses.CompletedSuccessfully);
            return 
                0 == numberOfMustDoneBeforeTask ||
                !TaskPool.TasksForClients.Any(t => t.Id == numberOfMustDoneBeforeTask && t.TaskStatus != TestTaskStatuses.CompletedSuccessfully) ||
                !TaskPool.TasksForClients.All(t => t.Id != numberOfMustDoneBeforeTask);
        }
	}
}
