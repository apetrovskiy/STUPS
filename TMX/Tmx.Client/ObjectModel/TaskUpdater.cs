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
    using System.Diagnostics;
    using Spring.Rest.Client;
    using Tmx.Interfaces.Exceptions;
    using Tmx.Interfaces.Server;
    using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of TaskUpdater.
    /// </summary>
    public class TaskUpdater
    {
        // volatile RestTemplate _restTemplate;
        readonly IRestOperations _restTemplate;
        
        public TaskUpdater(RestRequestCreator requestCreator)
        {
            _restTemplate = requestCreator.GetRestTemplate();
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
                
                _restTemplate.Put(UrlList.TestTasks_Root + "/" + task.Id, task);
                
                Trace.TraceInformation("UpdateTask(ITestTask task).2");
                
                return true;
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
                
                _restTemplate.Put(UrlList.CurrentTaskForClientById + "/" + clientId, task);
                
                Trace.TraceInformation("SendTaskResult(ITestTask task, Guid clientId).2");
                
                return true;
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
