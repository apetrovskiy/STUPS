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
    using Tmx.Core;
    using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of ServerWatcher.
    /// </summary>
    public class ServerWatcher
    {
        public virtual bool IsWorkflowCompleted(string name)
        {
			const int sleepInterval = 3000;
            
            // TODO: to a template method
            while (waitForWorkflow(name)) {
                System.Threading.Thread.Sleep(sleepInterval);
            }
            // 20140921
            temp_dumpTestTasks();
            return true;
        }

        internal virtual bool waitForWorkflow(string name)
        {
            // int workflowId = 0;
            var workflowId = Guid.Empty;
            if (!string.IsNullOrEmpty(name))
                // workflowId = WorkflowCollection.Workflows.First(wfl => wfl.Name == name).Id;
                workflowId = WorkflowCollection.Workflows.First(wfl => wfl.Name == name).Id;
            return thereHaveNotBeenTasksAllocated(workflowId) || allTasksAreComplete(workflowId);
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
            catch (Exception) {
// Console.WriteLine(ee.Message);
            }
        }
        
//        bool thereHaveBeenClientsAlready()
//        {
//            return !TaskPool.TasksForClients.Any() && !ClientsCollection.Clients.Any();
//        }
        
        // bool thereHaveNotBeenTasksAllocated(int workflowId)
        bool thereHaveNotBeenTasksAllocated(Guid workflowId)
        {
            // return !TaskPool.TasksForClients.Any();
            // return 0 == workflowId ? !TaskPool.TasksForClients.Any() : TaskPool.TasksForClients.All(task => task.WorkflowId != workflowId);
            return Guid.Empty == workflowId ? !TaskPool.TasksForClients.Any() : TaskPool.TasksForClients.All(task => task.WorkflowId != workflowId);
        }
        
        // bool allTasksAreComplete(int workflowId)
        bool allTasksAreComplete(Guid workflowId)
        {
//            return TaskPool.TasksForClients.Any(task => task.TaskStatus == TestTaskStatuses.New || 
//                                                task.TaskStatus == TestTaskStatuses.Accepted);
            // 20141022
//            return 0 == workflowId ?
//                TaskPool.TasksForClients.Any(task => task.TaskStatus == TestTaskStatuses.New || 
//                                             task.TaskStatus == TestTaskStatuses.Accepted) :
//                TaskPool.TasksForClients.Any(task => task.WorkflowId == workflowId && (task.TaskStatus == TestTaskStatuses.New || 
//                                                                                       task.TaskStatus == TestTaskStatuses.Accepted));
            
            // return 0 == workflowId ?
            return Guid.Empty == workflowId ?
                TaskPool.TasksForClients.Any(task => !task.IsFinished()) :
                TaskPool.TasksForClients.Any(task => task.WorkflowId == workflowId && !task.IsFinished());
        }
    }
}
