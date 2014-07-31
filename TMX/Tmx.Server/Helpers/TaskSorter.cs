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
	using System.Text.RegularExpressions;
	using Tmx.Interfaces;
	using Tmx.Interfaces.Remoting;
	using Tmx.Interfaces.Types.Remoting;
	
	/// <summary>
	/// Description of TaskSorter.
	/// </summary>
	public class TaskSorter
	{
	    public List<ITestTask> SelectTasksForClient(int clientId)
	    {
	        var resultTaskScope = new List<ITestTask>();
	        
	        var client = ClientsCollection.Clients.First(c => c.Id == clientId);
	        // TODO: use IDisposable or DI
	        // using (var client = ClientsCollection.Clients.First(c => c.Id == clientId)) {
	        
	        if (null == client) return resultTaskScope;
	        
	        // TODO: add IsAdmin and IsInteractive to the checking
	        resultTaskScope =
	        	TaskPool.Tasks.Where(task => // 0 == task.ClientId && 
	        	                     (Regex.IsMatch(client.CustomString ?? string.Empty, task.Rule)  ||
	        	                      Regex.IsMatch(client.EnvironmentVersion ?? string.Empty, task.Rule) ||
	        	                      Regex.IsMatch(client.Fqdn ?? string.Empty, task.Rule) ||
	        	                      Regex.IsMatch(client.Hostname ?? string.Empty, task.Rule) ||
	        	                      // task.Rule == client.IsAdmin.ToString() ||
	        	                      // task.Rule == client.IsInteractive.ToString() ||
	        	                      Regex.IsMatch(client.OsVersion ?? string.Empty, task.Rule) ||
	        	                      Regex.IsMatch(client.UserDomainName ?? string.Empty, task.Rule) ||
	        	                      Regex.IsMatch(client.Username ?? string.Empty, task.Rule))
	                                ).Select(t => { var newTask = t.CloneTask(); newTask.ClientId = clientId; return newTask; }).ToList<ITestTask>();
            return resultTaskScope;
	    }
	    
		public ITestTask GetFirstLegibleTask(int clientId)
		{
			var taskListForClient = getOnlyNewTestTasksForClient(clientId);
			if (null == taskListForClient || !taskListForClient.Any()) return null;
			return taskListForClient.First(task => task.Id == taskListForClient.Min(tsk => tsk.Id));
		}
		
		public ITestTask GetNextLegibleTask(int clientId, int currentTaskId)
		{
			var taskListForClient = getOnlyNewTestTasksForClient(clientId);
			if (null == taskListForClient || !taskListForClient.Any()) return null;
			// return taskListForClient.First(task => task.Id > taskListForClient.Min(tsk => tsk.Id));
			return taskListForClient.First(task => task.Id == taskListForClient.OrderBy(t => t.Id).Skip(1).First().Id);
		}
		
		IEnumerable<ITestTask> getOnlyNewTestTasksForClient(int clientId)
		{
		    // return TaskPool.TasksForClients.Where(task => task.ClientId == clientId && task.IsActive && task.Status == TestTaskStatuses.New); // && !task.Completed);
		    return TaskPool.TasksForClients.Where(task => task.ClientId == clientId && task.IsActive && !task.Completed);
		}
	}
}
