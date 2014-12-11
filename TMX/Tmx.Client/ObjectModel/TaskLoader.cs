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
    using System.Diagnostics;
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
        
        // 20141020 squeezing a task to its proxy
        public virtual ITestTask GetCurrentTask()
        // public virtual ITestTaskCodeProxy GetCurrentTask()
        {
            if (Guid.Empty == ClientSettings.Instance.ClientId)
                throw new ClientNotRegisteredException("Client is not registered. Run the Register-TmxSystemUnderTest cmdlet first");
            // 20141020 squeezing a task to its proxy
            HttpResponseMessage<TestTask> gettingTaskResponse = null;
            // HttpResponseMessage<TestTaskCodeProxy> gettingTaskResponse = null;
            try {
                // 20141020 squeezing a task to its proxy
                gettingTaskResponse = _restTemplate.GetForMessage<TestTask>(UrlList.TestTasks_Root + "/" + ClientSettings.Instance.ClientId);
                // gettingTaskResponse = _restTemplate.GetForMessage<TestTaskCodeProxy>(UrnList.TestTasks_Root + "/" + ClientSettings.Instance.ClientId);
            }
            catch (RestClientException eHttpClientErrorException) {
                Trace.TraceError(eHttpClientErrorException.Message);
                if (string.Empty != eHttpClientErrorException.Message)
                    if (Regex.IsMatch(eHttpClientErrorException.Message, "resulted in 417"))
                        // GET request for 'http://172.28.8.105:12340/Tasks/1' resulted in 417 - ExpectationFailed (Expectation Failed).
                        throw new ClientNotRegisteredException("Client is not registered. Run the Register-TmxSystemUnderTest cmdlet first");
            }
            
            if (null == gettingTaskResponse)
                throw new LoadTaskException("Failed to load task. " + gettingTaskResponse.StatusCode);
            var task = gettingTaskResponse.Body;
            if (HttpStatusCode.NotFound == gettingTaskResponse.StatusCode) return null; // a waiting task?
            if (HttpStatusCode.ExpectationFailed == gettingTaskResponse.StatusCode)
                throw new ClientNotRegisteredException("Client is not registered. Run the Register-TmxSystemUnderTest cmdlet first");
            if (HttpStatusCode.OK == gettingTaskResponse.StatusCode) return acceptCurrentTask(task);
            throw new LoadTaskException("Failed to load task. " + gettingTaskResponse.StatusCode);
        }
        
        // 20141020 squeezing a task to its proxy
        ITestTask acceptCurrentTask(ITestTask task)
        // ITestTaskProxy acceptCurrentTask(ITestTaskCodeProxy task)
        {
            if (null == task)
                throw new AcceptTaskException("Failed to accept task.");
            task.TaskStatus = TestTaskStatuses.Running;
            task.StartTimer();
            try {
                _restTemplate.Put(UrlList.TestTasks_Root + "/" + task.Id, task);
            	return task;
            }
            catch (RestClientException eAcceptingTask) {
                Trace.TraceError(eAcceptingTask.Message);
                throw new AcceptTaskException("Failed to accept task '" + task.Name + "'. " + eAcceptingTask.Message);
            }
        }
    }
}
