/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/24/2014
 * Time: 3:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client.Library.ObjectModel
{
    using System;
    using System.Diagnostics;
    using System.Net;
    using Abstract;
    using Interfaces.Exceptions;
    using Interfaces.Remoting;
    using Interfaces.Server;
    using Helpers;
    using Spring.Http;
    using Spring.Rest.Client;

    /// <summary>
    /// Description of TaskUpdater.
    /// </summary>
    public class TaskUpdater
    {
        // volatile RestTemplate _restTemplate;
        readonly IRestOperations _restTemplate;
        
        //public TaskUpdater(IRestRequestCreator requestCreator)
        //{
        //    _restTemplate = requestCreator.GetRestTemplate();
        //}

        public TaskUpdater()
        {
            _restTemplate = RestRequestFactory.GetRestRequestCreator().GetRestTemplate();
        }
        
        // 20141020 squeezing a task to its proxy
        public virtual bool UpdateTask(ITestTask task)
        // public virtual bool UpdateTask(ITestTaskStatusProxy task)
        {
            // TODO: try several times
            try {
                
                // 20141211
                // TODO: AOP
                Trace.TraceInformation("UpdateTask(ITestTask task).1: task id = {0}, task name = {1}, url = {2}", task.Id, task.Name, UrlList.TestTasks_Root + "/" + task.Id);
                
                // 20141215
                // _restTemplate.Put(UrlList.TestTasks_Root + "/" + task.Id, task);
                var updatingTaskResponse = _restTemplate.Exchange(UrlList.TestTasks_Root + "/" + task.Id, HttpMethod.PUT, new HttpEntity(task));
                
                Trace.TraceInformation("UpdateTask(ITestTask task).2");
                
                if (HttpStatusCode.OK == updatingTaskResponse.StatusCode)
                    return true;
                throw new UpdateTaskException("Failed to update task '" + task.Name + "'");
                // 20141215
                // return true;
            }
            catch (Exception eOnUpdatingTask) {
                // TODO: AOP
                Trace.TraceError("UpdateTask(ITestTask task)");
                Trace.TraceError(eOnUpdatingTask.Message);
                throw new UpdateTaskException("Failed to update task '" + task.Name + "'");
            }
        }
        
        public virtual bool SendTaskResult(ITestTask task, Guid clientId)
        {
            try {
                
                // 20141211
                // TODO: AOP
                Trace.TraceInformation("SendTaskResult(ITestTask task, Guid clientId).1: client id = {0}, task id = {1}, task name = {2}, url = {3}", clientId, task.Id, task.Name, UrlList.CurrentTaskForClientById + "/" + clientId);
                
                // 20141215
                // _restTemplate.Put(UrlList.CurrentTaskForClientById + "/" + clientId, task);
                var sendingTaskResultResponse = _restTemplate.Exchange(UrlList.CurrentTaskForClientById + "/" + clientId, HttpMethod.PUT, new HttpEntity(task));
                
                Trace.TraceInformation("SendTaskResult(ITestTask task, Guid clientId).2");
                
                if (HttpStatusCode.OK == sendingTaskResultResponse.StatusCode)
                    return true;
                throw new UpdateTaskException("Failed to send results to task");
                
                // 20141215
                // return true;
            }
            catch (Exception eOnSendingTaskResults) {
                // TODO: AOP
                Trace.TraceError("SendTaskResult(ITestTask task, Guid clientId)");
                Trace.TraceError(eOnSendingTaskResults.Message);
                throw new UpdateTaskException("Failed to send results to task");
            }
        }
    }
}
