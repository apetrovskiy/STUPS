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
                _restTemplate.Put(UrlList.TestTasks_Root + "/" + task.Id, task);
                return true;
            }
            catch {
                throw new UpdateTaskException("Failed to update task '" + task.Name + "'");
            }
        }
        
        public virtual bool SendTaskResult(ITestTask task, Guid clientId)
        {
            try {
                _restTemplate.Put(UrlList.CurrentTaskForClientById + "/" + clientId, task);
                return true;
            }
            catch {
                throw new UpdateTaskException("Failed to send results to task");
            }
        }
    }
}
