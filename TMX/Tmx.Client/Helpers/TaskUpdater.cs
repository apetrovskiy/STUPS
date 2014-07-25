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
	using Tmx.Interfaces.Remoting;
	using Tmx.Interfaces.Types.Remoting;
	using Tmx.Server;
	
	/// <summary>
	/// Description of TaskUpdater.
	/// </summary>
	public class TaskUpdater
	{
	    readonly RestRequestCreator _restRequestCreator = new RestRequestCreator();
	    
		public bool UpdateTask()
		{
			var request = _restRequestCreator.GetRestRequest(UrnList.TestTasks_Root + "/" + ClientSettings.CurrentTask.Id, Method.PUT);
			request.AddObject(ClientSettings.CurrentTask);
			var updatingTaskResponse = _restRequestCreator.RestClient.Execute<TestTask>(request);
			if (HttpStatusCode.OK != updatingTaskResponse.StatusCode)
				throw new UpdateTaskException("Failed to update task");
			return true;
		}
	}
}
