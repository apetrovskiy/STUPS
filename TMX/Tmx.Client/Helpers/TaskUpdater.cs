/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/24/2014
 * Time: 3:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client
{
	using System;
	// using System.Net;
	using Spring.Rest.Client;
	using TMX.Interfaces.Exceptions;
	using TMX.Interfaces.Server;
	using Tmx.Interfaces.Remoting;
	// using Tmx.Interfaces.Types.Remoting;
	
	/// <summary>
	/// Description of TaskUpdater.
	/// </summary>
	public class TaskUpdater
	{
	    volatile RestTemplate _restTemplate;
	    
	    public TaskUpdater(RestRequestCreator requestCreator)
	    {
	    	_restTemplate = requestCreator.GetRestTemplate(string.Empty);
	    }
	    
		public bool UpdateTask(ITestTask task)
		{
			try {
			    _restTemplate.Put(UrnList.TestTasks_Root + "/" + task.Id, task);
			    return true;
			}
			catch {
			    throw new UpdateTaskException("Failed to update task '" + task.Name + "'");
			}
		}
		
		public bool SendTaskResult(ITestTask task, int clientId)
		{
			try {
			    _restTemplate.Put(UrnList.TestTasks_Root + UrnList.TestTasks_CurrentTask + "/" + clientId, task);
			    return true;
			}
			catch {
			    throw new UpdateTaskException("Failed to send results to task");
			}
		}
	}
}
