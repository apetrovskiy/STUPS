/*
 * Created by SharpDevelop.
 * User: alexa_000
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
	using Tmx.Interfaces.Remoting;
	using Tmx.Interfaces.Types.Remoting;
	using Tmx.Server;
	
	/// <summary>
	/// Description of TaskUpdater.
	/// </summary>
	public class TaskUpdater
	{
//		public bool UpdateTask(ITestTask testTask)
//		{
//			ClientSettings.CurrentTask.Completed = testTask.Completed;
//			ClientSettings.CurrentTask.Status = testTask.Status;
//			ClientSettings.CurrentTask.TaskResult = testTask.TaskResult;
//			return UpdateTask();
//		}
//		
		public bool UpdateTask()
		{
			var client = new RestClient(ClientSettings.ServerUrl);
			var request = new RestRequest(UrnList.TestTasks_Root + "/" + ClientSettings.CurrentTask.Id, Method.PUT);
			request.AddObject(ClientSettings.CurrentTask);
			var updatingTaskResponse = client.Execute<TestTask>(request);
			if (HttpStatusCode.OK != updatingTaskResponse.StatusCode)
				throw new UpdateTaskException("Failed to update task");
			return true;
		}
	}
}
