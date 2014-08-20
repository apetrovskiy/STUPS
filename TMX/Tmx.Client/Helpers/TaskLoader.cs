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
	// using RestSharp;
	using Spring.Rest.Client;
	using Tmx;
	using TMX.Interfaces.Exceptions;
	using TMX.Interfaces.Server;
	using Tmx.Interfaces.Remoting;
	using Tmx.Interfaces.Types.Remoting;
	
	/// <summary>
	/// Description of TaskLoader.
	/// </summary>
	public class TaskLoader
	{
        // 20140820
        // move from RestSharp to RestTemplate
	    // volatile RestRequestCreator _restRequestCreator;
	    volatile RestTemplate _restTemplate;
	    
	    public TaskLoader(RestRequestCreator requestCreator)
	    {
	    	// _restRequestCreator = requestCreator;
	    	_restTemplate = requestCreator.GetRestTemplate(string.Empty);
	    }
	    
		public ITestTask GetCurrentTask()
		{
            // 20140820
            // move from RestSharp to RestTemplate
//// Console.WriteLine("trying to load a new task: " + UrnList.TestTasks_Root + "/" + ClientSettings.ClientId);
//			// var request = _restRequestCreator.GetRestRequest(UrnList.TestTasks_Root + "/" + ClientSettings.ClientId, Method.GET);
//			var clientSettings = ClientSettings.Instance;
//			var request = _restRequestCreator.GetRestRequest(UrnList.TestTasks_Root + "/" + clientSettings.ClientId, Method.GET);
//			
//			var gettingTaskResponse = _restRequestCreator.RestClient.Execute<TestTask>(request);
//			var task = gettingTaskResponse.Data;
//            if (HttpStatusCode.NotFound == gettingTaskResponse.StatusCode) return null; // a waiting task?
////Console.WriteLine("trying to accept the task");
////if (null == task)
////    Console.WriteLine("null == task");
////else
////    Console.WriteLine("null != task");
//			if (HttpStatusCode.OK == gettingTaskResponse.StatusCode) return acceptCurrentTask(task);
//			throw new LoadTaskException("Failed to load task. " + gettingTaskResponse.StatusCode);
			
			var gettingTaskResponse = _restTemplate.GetForMessage<TestTask>(UrnList.TestTasks_Root + "/" + ClientSettings.Instance.ClientId);
			
			var task = gettingTaskResponse.Body;
            if (HttpStatusCode.NotFound == gettingTaskResponse.StatusCode) return null; // a waiting task?
			if (HttpStatusCode.OK == gettingTaskResponse.StatusCode) return acceptCurrentTask(task);
			throw new LoadTaskException("Failed to load task. " + gettingTaskResponse.StatusCode);
		}

		ITestTask acceptCurrentTask(ITestTask task)
		{
            // 20140820
            // move from RestSharp to RestTemplate
//		    if (null == task)
//		        throw new AcceptTaskException("Failed to accept task.");
//			task.TaskStatus = TestTaskStatuses.Accepted;
//			task.StartTimer();
//			var request = new RestRequest(UrnList.TestTasks_Root + "/" + task.Id, Method.PUT);
//			request.AddObject(task);
//			var acceptingTaskResponse = _restRequestCreator.RestClient.Execute(request);
//			if (HttpStatusCode.OK == acceptingTaskResponse.StatusCode)
//				return task;
//			throw new AcceptTaskException("Failed to accept task '" + task.Name + "'. " + acceptingTaskResponse.StatusCode);
		    
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
