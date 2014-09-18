/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/23/2014
 * Time: 5:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client
{
	using System;
	using System.Net;
	using Spring.Rest.Client;
	using TMX.Interfaces.Exceptions;
	using TMX.Interfaces.Server;
	using Tmx.Core.Types.Remoting;
	using Tmx.Interfaces.Remoting;
	
	/// <summary>
	/// Description of TaskLoader.
	/// </summary>
	public class TaskLoader
	{
	    // volatile RestTemplate _restTemplate;
	    readonly RestTemplate _restTemplate;
	    
	    public TaskLoader(RestRequestCreator requestCreator)
	    {
	    	_restTemplate = requestCreator.GetRestTemplate();
	    }
	    
		public virtual ITestTask GetCurrentTask()
		{
			var gettingTaskResponse = _restTemplate.GetForMessage<TestTask>(UrnList.TestTasks_Root + "/" + ClientSettings.Instance.ClientId);
			
			var task = gettingTaskResponse.Body;
            if (HttpStatusCode.NotFound == gettingTaskResponse.StatusCode) return null; // a waiting task?
			if (HttpStatusCode.OK == gettingTaskResponse.StatusCode) return acceptCurrentTask(task);
			throw new LoadTaskException("Failed to load task. " + gettingTaskResponse.StatusCode);
		}

		ITestTask acceptCurrentTask(ITestTask task)
		{
		    if (null == task)
		        throw new AcceptTaskException("Failed to accept task.");
			task.TaskStatus = TestTaskStatuses.Accepted;
			task.StartTimer();
			try {
                _restTemplate.Put(UrnList.TestTasks_Root + "/" + task.Id, task);
				return task;
			}
			catch {
                throw new AcceptTaskException("Failed to accept task '" + task.Name + "'");
			}
		}
	}
}
