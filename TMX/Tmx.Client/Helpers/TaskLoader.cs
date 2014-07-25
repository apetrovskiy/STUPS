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
	using RestSharp;
	using TMX.Interfaces.Exceptions;
	using Tmx.Interfaces.Remoting;
	using Tmx.Interfaces.Types.Remoting;
	using Tmx.Server;
	
	/// <summary>
	/// Description of TaskLoader.
	/// </summary>
	public class TaskLoader
	{
	    readonly RestRequestCreator _restRequestCreator = new RestRequestCreator();
	    
		public ITestTask GetCurrentTask()
		{
			var request = _restRequestCreator.GetRestRequest(UrnList.TestTasks_Root + "/" + ClientSettings.ClientId, Method.GET);
			var gettingTaskResponse = _restRequestCreator.RestClient.Execute<TestTask>(request);
			
			if (HttpStatusCode.OK != gettingTaskResponse.StatusCode)
				throw new LoadTaskException("Failed to load task");
			
			return acceptCurrentTask(gettingTaskResponse.Data);
		}

		ITestTask acceptCurrentTask(ITestTask task)
		{
			task.Status = TestTaskStatuses.Accepted;
			var request = new RestRequest(UrnList.TestTasks_Root + "/" + task.Id, Method.PUT);
			request.AddObject(task);
			var acceptingTaskResponse = _restRequestCreator.RestClient.Execute(request);
			if (HttpStatusCode.OK == acceptingTaskResponse.StatusCode)
				return task;
			throw new AcceptTaskException("Failed to accept task");
		}
	}
}
