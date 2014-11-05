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
    using System.Text.RegularExpressions;
    using Spring.Http;
	using Spring.Rest.Client;
	using Tmx.Interfaces.Exceptions;
	using Tmx.Interfaces.Server;
	using Tmx.Core.Types.Remoting;
	using Tmx.Interfaces.Remoting;
	
	/// <summary>
	/// Description of TaskLoader.
	/// </summary>
	public class TaskLoader
	{
	    // volatile RestTemplate _restTemplate;
	    readonly IRestOperations _restTemplate;
	    
	    public TaskLoader(RestRequestCreator requestCreator)
	    {
	    	_restTemplate = requestCreator.GetRestTemplate();
	    }
	    
	    // 20141020 sqeezing a task to its proxy
		public virtual ITestTask GetCurrentTask()
		// public virtual ITestTaskCodeProxy GetCurrentTask()
		{
Console.WriteLine("GetCurrentTask 000001");
            if (Guid.Empty == ClientSettings.Instance.ClientId)
                throw new ClientNotRegisteredException("Client is not registered. Run the Register-TmxSystemUnderTest cmdlet first");
            // 20141020 sqeezing a task to its proxy
Console.WriteLine("GetCurrentTask 000002");
            HttpResponseMessage<TestTask> gettingTaskResponse = null;
            // HttpResponseMessage<TestTaskCodeProxy> gettingTaskResponse = null;
			try {
Console.WriteLine("GetCurrentTask 000003");
                // 20141020 sqeezing a task to its proxy
			    gettingTaskResponse = _restTemplate.GetForMessage<TestTask>(UrnList.TestTasks_Root + "/" + ClientSettings.Instance.ClientId);
Console.WriteLine("GetCurrentTask 000004");
			    // gettingTaskResponse = _restTemplate.GetForMessage<TestTaskCodeProxy>(UrnList.TestTasks_Root + "/" + ClientSettings.Instance.ClientId);
			}
			catch (Exception eHttpClientErrorException) {
Console.WriteLine("GetCurrentTask 000005");
			    if (string.Empty != eHttpClientErrorException.Message)
			        if (Regex.IsMatch(eHttpClientErrorException.Message, "resulted in 417"))
			            // GET request for 'http://172.28.8.105:12340/Tasks/1' resulted in 417 - ExpectationFailed (Expectation Failed).
			            throw new ClientNotRegisteredException("Client is not registered. Run the Register-TmxSystemUnderTest cmdlet first");
			}
            
Console.WriteLine("GetCurrentTask 000006");
            if (null == gettingTaskResponse)
                throw new LoadTaskException("Failed to load task. " + gettingTaskResponse.StatusCode);
Console.WriteLine("GetCurrentTask 000007");
			var task = gettingTaskResponse.Body;
Console.WriteLine("GetCurrentTask 000008");
            if (HttpStatusCode.NotFound == gettingTaskResponse.StatusCode) return null; // a waiting task?
Console.WriteLine("GetCurrentTask 000009");
            if (HttpStatusCode.ExpectationFailed == gettingTaskResponse.StatusCode)
                throw new ClientNotRegisteredException("Client is not registered. Run the Register-TmxSystemUnderTest cmdlet first");
Console.WriteLine("GetCurrentTask 000010");
			if (HttpStatusCode.OK == gettingTaskResponse.StatusCode) return acceptCurrentTask(task);
Console.WriteLine("GetCurrentTask 000011");
			throw new LoadTaskException("Failed to load task. " + gettingTaskResponse.StatusCode);
		}
		
		// 20141020 sqeezing a task to its proxy
		ITestTask acceptCurrentTask(ITestTask task)
		// ITestTaskProxy acceptCurrentTask(ITestTaskCodeProxy task)
		{
		    if (null == task)
		        throw new AcceptTaskException("Failed to accept task.");
			task.TaskStatus = TestTaskStatuses.Running;
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
