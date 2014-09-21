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
            return !ClientsCollection.Clients.Any() || !TaskPool.TasksForClients.Any() || TaskPool.TasksForClients.Any(task => task.TaskStatus == TestTaskStatuses.New || task.TaskStatus == TestTaskStatuses.Accepted);
        }
        
        void temp_dumpTestTasks()
        {
//            var list = new List<Class1>();
//            list.Add(new Class1 { Id = 1, Name = "aaa" });
//            list.Add(new Class1 { Id = 100, Name = "sadfr asf awsfd" });
//            list.Add(new Class1 { Id = 1000000, Name = " safd sadf as " });
//            var rootNode = new XElement("objects",
//                                        from item in list
//                                        select new XElement("object", new XAttribute("id", item.Id), new XAttribute("name", item.Name)));
//            var xDoc = new XDocument(rootNode);
//            xDoc.Save(@"e:\aaaabbbbcccc.xml");
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
                
// Console.WriteLine(dateTimeString);
                
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
    }
}
