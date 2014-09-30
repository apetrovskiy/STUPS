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
	using Tmx.Core;
	using Tmx.Interfaces.Server;
	using Tmx.Interfaces.Remoting;
	
	/// <summary>
	/// Description of TestClientsModule.
	/// </summary>
	public class TestClientsModule : NancyModule
	{
		public TestClientsModule() : base(UrnList.TestClients_Root)
		{
			Post[UrnList.TestClients_Clients] = _ => createNewClient(this.Bind<TestClient>());
			
			Delete[UrnList.TestClientDeregistrationPoint] = parameters => deleteClientById(parameters.id);
		    
		    Get[UrnList.TestClients_Clients] = _ => returnAllClients();
		    
		    Get[UrnList.TestClientQueryPoint] = parameters => returnClientById(parameters.id);
		}
		
		Negotiator createNewClient(TestClient testClient)
		{
			int maxId = 0;
			if (0 < ClientsCollection.Clients.Count)
				maxId = ClientsCollection.Clients.Max(client => client.Id);
			testClient.Id = ++maxId;
			ClientsCollection.Clients.Add(testClient);
			// TODO: DI
			var taskSorter = new TaskSelector();
			TaskPool.TasksForClients.AddRange(taskSorter.SelectTasksForClient(testClient.Id, TaskPool.Tasks));
			// setting status
			// if (TaskPool.TasksForClients.Any(task => task.ClientId == testClient.Id && task.TaskFinished == false))
			//     testClient.Status = TestClientStatuses.WorkflowInProgress;
			// return Response.AsJson(testClient).WithStatusCode(HttpStatusCode.Created);
			return Negotiate.WithModel(testClient).WithStatusCode(HttpStatusCode.Created);
		}
		
		HttpStatusCode deleteClientById(int clientId)
		{
			ClientsCollection.Clients.RemoveAll(client => client.Id == clientId);
			return HttpStatusCode.NoContent;
		}
		
		Negotiator returnAllClients()
		{
			// return 0 == ClientsCollection.Clients.Count ? HttpStatusCode.NotFound : Response.AsJson(ClientsCollection.Clients).WithStatusCode(HttpStatusCode.OK);
			return 0 == ClientsCollection.Clients.Count ? Negotiate.WithStatusCode(HttpStatusCode.NotFound) : Negotiate.WithModel(ClientsCollection.Clients).WithStatusCode(HttpStatusCode.OK);
		}
		
		Negotiator returnClientById(int clientId)
		{
			// TODO: refactor this
		    // return ClientsCollection.Clients.Any(client => client.Id == clientId) ? Response.AsJson(ClientsCollection.Clients.Any(client => client.Id == clientId)) : HttpStatusCode.NotFound;
		    return ClientsCollection.Clients.Any(client => client.Id == clientId) ? Negotiate.WithModel(ClientsCollection.Clients.Any(client => client.Id == clientId)) : Negotiate.WithStatusCode(HttpStatusCode.NotFound);
		}
	}
}
