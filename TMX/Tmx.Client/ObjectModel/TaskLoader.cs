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
            Trace.TraceInformation("GetCurrentTask().1");
            
            if (Guid.Empty == ClientSettings.Instance.ClientId)
                throw new ClientNotRegisteredException("Client is not registered. Run the Register-TmxSystemUnderTest cmdlet first");
            // 20141020 squeezing a task to its proxy
            HttpResponseMessage<TestTask> gettingTaskResponse = null;
            // HttpResponseMessage<TestTaskCodeProxy> gettingTaskResponse = null;
            try {
                
                // 20141211
                // TODO: AOP
                Trace.TraceInformation("GetCurrentTask().2: client id = {0}, url = {1}", ClientSettings.Instance.ClientId, UrlList.TestTasks_Root + "/" + ClientSettings.Instance.ClientId);
                
                // 20141020 squeezing a task to its proxy
                gettingTaskResponse = _restTemplate.GetForMessage<TestTask>(UrlList.TestTasks_Root + "/" + ClientSettings.Instance.ClientId);
                // gettingTaskResponse = _restTemplate.GetForMessage<TestTaskCodeProxy>(UrnList.TestTasks_Root + "/" + ClientSettings.Instance.ClientId);
                
                Trace.TraceInformation("GetCurrentTask().3 gettingTaskResponse is null? {0}", null == gettingTaskResponse);
            }
            catch (RestClientException eHttpClientErrorException) {
                // TODO: AOP
                Trace.TraceError("GetCurrentTask()");
                Trace.TraceError(eHttpClientErrorException.Message);
                if (string.Empty != eHttpClientErrorException.Message)
                    if (Regex.IsMatch(eHttpClientErrorException.Message, "resulted in 417"))
                        // GET request for 'http://172.28.8.105:12340/Tasks/1' resulted in 417 - ExpectationFailed (Expectation Failed).
                        throw new ClientNotRegisteredException("Client is not registered. Run the Register-TmxSystemUnderTest cmdlet first");
            }
            
            Trace.TraceInformation("GetCurrentTask().4");
            
            if (null == gettingTaskResponse)
                throw new LoadTaskException("Failed to load task. " + gettingTaskResponse.StatusCode);
            
            Trace.TraceInformation("GetCurrentTask().5");
            
            var task = gettingTaskResponse.Body;
            
            Trace.TraceInformation("GetCurrentTask().6 task is null? {0}", null == task);
            
            if (HttpStatusCode.NotFound == gettingTaskResponse.StatusCode) return null; // a waiting task?
            
            Trace.TraceInformation("GetCurrentTask().7");
            
            if (HttpStatusCode.ExpectationFailed == gettingTaskResponse.StatusCode)
                throw new ClientNotRegisteredException("Client is not registered. Run the Register-TmxSystemUnderTest cmdlet first");
            
            Trace.TraceInformation("GetCurrentTask().8 client is registered");
            
            if (HttpStatusCode.OK == gettingTaskResponse.StatusCode) return acceptCurrentTask(task);
            
            Trace.TraceInformation("GetCurrentTask().9");
            
            // TODO: AOP
            Trace.TraceError("GetCurrentTask().10");
            throw new LoadTaskException("Failed to load task. " + gettingTaskResponse.StatusCode);
        }
        
        // 20141020 squeezing a task to its proxy
        ITestTask acceptCurrentTask(ITestTask task)
        // ITestTaskProxy acceptCurrentTask(ITestTaskCodeProxy task)
        {
            Trace.TraceInformation("acceptCurrentTask(ITestTask task).1");
            
            if (null == task)
                throw new AcceptTaskException("Failed to accept task.");
            
            // 20141211
            // TODO: AOP
            Trace.TraceInformation("acceptCurrentTask(ITestTask task).2: task id = {0}", task.Id);
            
            task.TaskStatus = TestTaskStatuses.Running;
            task.StartTimer();
            try {
                
                // 20141211
                // TODO: AOP
                Trace.TraceInformation("acceptCurrentTask(ITestTask task).3: task id = {0}, url = {1}", task.Id, UrlList.TestTasks_Root + "/" + task.Id);
                
                _restTemplate.Put(UrlList.TestTasks_Root + "/" + task.Id, task);
                
                Trace.TraceInformation("acceptCurrentTask(ITestTask task).4");
                
                return task;
            }
            catch (RestClientException eAcceptingTask) {
                // TODO: AOP
                Trace.TraceError("acceptCurrentTask(ITestTask task)");
                Trace.TraceError(eAcceptingTask.Message);
                throw new AcceptTaskException("Failed to accept task '" + task.Name + "'. " + eAcceptingTask.Message);
            }
        }
    }
}
