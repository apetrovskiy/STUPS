/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/10/2014
 * Time: 6:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Helpers
{
    using System;
    using System.Linq;
    using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of ServerWatcher.
    /// </summary>
    public class ServerWatcher
    {
        public virtual bool IsWorkflowCompleted()
        {
			const int sleepInterval = 3000;
            
            // TODO: to a template method
            while (wait()) {
                System.Threading.Thread.Sleep(sleepInterval);
            }
            return true;
        }

        internal virtual bool wait()
        {
            return !ClientsCollection.Clients.Any() || !TaskPool.TasksForClients.Any() || TaskPool.TasksForClients.Any(task => task.TaskStatus == TestTaskStatuses.New || task.TaskStatus == TestTaskStatuses.Accepted);
        }
    }
}
