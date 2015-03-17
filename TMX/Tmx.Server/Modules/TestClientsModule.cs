/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/17/2014
 * Time: 8:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Modules
{
    using System;
    using System.Linq;
    using Nancy;
    using Nancy.ModelBinding;
    using Nancy.Responses.Negotiation;
    using Nancy.TinyIoc;
    using Tmx.Core;
    using Tmx.Core.Types.Remoting;
    using Tmx.Interfaces.Server;
    using Tmx.Interfaces.Remoting;
    using Tmx.Server.Interfaces;
    
    /// <summary>
    /// Description of TestClientsModule.
    /// </summary>
    public class TestClientsModule : NancyModule
    {
        public TestClientsModule() : base(UrlList.TestClients_Root)
        {
            Post[UrlList.TestClientRegistrationPoint_relPath] = _ => CreateNewClient(this.Bind<TestClient>());
            
            Delete[UrlList.TestClientDeregistrationPoint_relPath] = parameters => DeleteClientById(parameters.id);
            
            Put[UrlList.TestClient_Status_relPath] = parameters => {
                var detailedStatus = this.Bind<DetailedStatus>();
                return UpdateStatus(parameters.id, detailedStatus);
            };
            
            Get[UrlList.TestClientRegistrationPoint_relPath] = _ => ReturnAllClients();
            
            Get[UrlList.TestClientQueryPoint_relPath] = parameters => ReturnClientById(parameters.id);
        }
        
        Negotiator CreateNewClient(TestClient testClient)
        {
            if (!TestRunQueue.TestRuns.HasActiveTestRuns())
                return Negotiate.WithStatusCode(HttpStatusCode.ExpectationFailed);
            testClient.TestRunId = TestRunQueue.TestRuns.ActiveTestRunIds().First();
            ClientsCollection.Clients.Add(testClient);
            
            var taskSelector = TinyIoCContainer.Current.Resolve<TaskSelector>();
            
//try {
//    var taskSel = TinyIoCContainer.Current.Resolve<ITaskSelector>();
//    if (null == taskSel)
//        Console.WriteLine("null == taskSel");
//    else
//        Console.WriteLine("type is {0}", taskSel.GetType().Name);
//}
//catch (Exception ee) {
//    Console.WriteLine(ee.Message);
//}
            
            var tasksForClient = taskSelector.SelectTasksForClient(testClient.Id, TaskPool.Tasks);
            tasksForClient.ForEach(task => task.TestRunId = testClient.TestRunId);
            TaskPool.TasksForClients.AddRange(tasksForClient);
            return Negotiate.WithModel(testClient).WithStatusCode(HttpStatusCode.Created);
        }
        
        HttpStatusCode DeleteClientById(Guid clientId)
        {
            var testRunId = ClientsCollection.Clients.First(client => client.Id == clientId).TestRunId;
            ClientsCollection.Clients.RemoveAll(client => client.Id == clientId);
            TaskPool.TasksForClients.Where(task => task.ClientId == clientId && task.TestRunId == testRunId && task.TaskStatus == TestTaskStatuses.New)
                .ToList()
                .ForEach(task => task.TaskStatus = TestTaskStatuses.Canceled);
            return HttpStatusCode.NoContent;
        }

        HttpStatusCode UpdateStatus(Guid clientId, DetailedStatus detailedStatus)
        {
            if (ClientsCollection.Clients.All(client => client.Id != clientId))
                return HttpStatusCode.NotFound;
            ClientsCollection.Clients.First(client => client.Id == clientId).DetailedStatus = detailedStatus.Status;
            return HttpStatusCode.OK;
        }
        
        Negotiator ReturnAllClients()
        {
            return 0 == ClientsCollection.Clients.Count ? Negotiate.WithStatusCode(HttpStatusCode.NotFound) : Negotiate.WithModel(ClientsCollection.Clients).WithStatusCode(HttpStatusCode.OK);
        }
        
        Negotiator ReturnClientById(Guid clientId)
        {
            // TODO: refactor this
            return ClientsCollection.Clients.Any(client => client.Id == clientId) ? Negotiate.WithModel(ClientsCollection.Clients.First(client => client.Id == clientId)).WithStatusCode(HttpStatusCode.OK) : Negotiate.WithStatusCode(HttpStatusCode.NotFound);
        }
    }
}
