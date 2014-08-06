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
	using System.Net;
	using RestSharp;
	using TMX.Interfaces.Exceptions;
	using TMX.Interfaces.Server;
	using Tmx.Interfaces.Remoting;
	using Tmx.Interfaces.Types.Remoting;
	
	/// <summary>
	/// Description of TaskUpdater.
	/// </summary>
	public class TaskUpdater
	{
	    // readonly RestRequestCreator _restRequestCreator = new RestRequestCreator();
	    readonly RestRequestCreator _restRequestCreator;
	    
	    public TaskUpdater(RestRequestCreator requestCreator)
	    {
	    	_restRequestCreator = requestCreator;
	    }
	    
		public bool UpdateTask(ITestTask task)
		{
			var request = _restRequestCreator.GetRestRequest(UrnList.TestTasks_Root + "/" + task.Id, Method.PUT);
			request.AddObject(task);
			var updatingTaskResponse = _restRequestCreator.RestClient.Execute<TestTask>(request);
			if (HttpStatusCode.OK != updatingTaskResponse.StatusCode)
				throw new UpdateTaskException("Failed to update task '" + task.Name + "'. " + updatingTaskResponse.StatusCode);
			return true;
		}
		
		public bool SendTaskResult(ITestTask task, int clientId)
		{
			var request = _restRequestCreator.GetRestRequest(UrnList.TestTasks_Root + UrnList.TestTasks_CurrentTask + "/" + clientId, Method.PUT);
			request.AddObject(task);
			var sendingResultResponse = _restRequestCreator.RestClient.Execute<TestTask>(request);
			if (HttpStatusCode.OK != sendingResultResponse.StatusCode)
				throw new UpdateTaskException("Failed to send results to task. " + sendingResultResponse.StatusCode);
			return true;
		}
	}
}
