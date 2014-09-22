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
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
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
            // 20140921
            temp_dumpTestTasks();
            return true;
        }

        internal virtual bool wait()
        {
            // 20140922
            // return !ClientsCollection.Clients.Any() || !TaskPool.TasksForClients.Any() || TaskPool.TasksForClients.Any(task => task.TaskStatus == TestTaskStatuses.New || task.TaskStatus == TestTaskStatuses.Accepted);
//            return // !ClientsCollection.Clients.Any() ||
//                // there have been clients
//                (TaskPool.TasksForClients.Any() && !ClientsCollection.Clients.Any()) ||
//                // there have not ever been tasks
//                !TaskPool.TasksForClients.Any() || 
//                // all tasks are complete
//                TaskPool.TasksForClients.Any(task => task.TaskStatus == TestTaskStatuses.New || 
//                                             task.TaskStatus == TestTaskStatuses.Accepted);
            
            // return thereHaveBeenClientsAlready() || thereHaveNotBeenTasksAllocated() || allTasksAreComplete();
            return thereHaveNotBeenTasksAllocated() || allTasksAreComplete();
        }
        
        void temp_dumpTestTasks()
        {
            try {
                var dateTimeString =
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                    @"\testTasks_" +
                    DateTime.Now.Year +
                    DateTime.Now.Month + 
                    DateTime.Now.Day +
                    DateTime.Now.Hour +
                    DateTime.Now.Minute + 
                    DateTime.Now.Second + 
                    ".xml";
                
                var rootNode = new XElement(
                    "testTasks",
                    from testTask in TaskPool.TasksForClients
                    select new XElement(
                        "testTask",
                        new XAttribute("id", testTask.Id),
                        new XAttribute("name", testTask.Name),
                        new XAttribute("status", testTask.TaskStatus),
                        new XAttribute("finished", testTask.TaskFinished),
                        new XAttribute("clientId", testTask.ClientId))); // ,
                        // new XAttribute("taskResult", testTask.TaskResult ?? new Dictionary<string, string>()),
                        // new XAttribute("previousTaskResult", testTask.PreviousTaskResult ?? new Dictionary<string, string>())));
                var xDoc = new XDocument(rootNode);
                xDoc.Save(dateTimeString);
            }
            catch (Exception ee) {
// Console.WriteLine(ee.Message);
            }
        }
        
//        bool thereHaveBeenClientsAlready()
//        {
//            return !TaskPool.TasksForClients.Any() && !ClientsCollection.Clients.Any();
//        }
        
        bool thereHaveNotBeenTasksAllocated()
        {
            return !TaskPool.TasksForClients.Any();
        }
        
        bool allTasksAreComplete()
        {
            return TaskPool.TasksForClients.Any(task => task.TaskStatus == TestTaskStatuses.New || 
                                                task.TaskStatus == TestTaskStatuses.Accepted);
        }
    }
}
