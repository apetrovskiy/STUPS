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
		public ITestTask GetCurrentTask()
		{
			var client = new RestClient(ClientSettings.ServerUrl);
			var request = new RestRequest(UrnList.TestTasks_Root + "/" + ClientSettings.ClientId, Method.GET);
			var gettingTaskResponse = client.Execute<TestTask>(request);
			
			if (HttpStatusCode.OK != gettingTaskResponse.StatusCode)
				throw new LoadTaskException("Failed to load task");
			
			var task = gettingTaskResponse.Data;
			task.Status = TestTaskStatuses.Accepted;
			request = new RestRequest(UrnList.TestTasks_Root + "/" + task.Id, Method.PUT);
			request.AddObject(task);
			var acceptingTaskResponse = client.Execute(request);
			
			if (HttpStatusCode.OK == acceptingTaskResponse.StatusCode)
				return task;
			throw new AcceptTaskException("Failed to accept task");
		}
	}
}
