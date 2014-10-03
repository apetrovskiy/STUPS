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
			
			Put[UrnList.TestClient_Status] = parameters => {
            	var status = this.Bind<string>();
                return updateStatus(parameters.id, status);
			};
		    
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
			return Negotiate.WithModel(testClient).WithStatusCode(HttpStatusCode.Created);
		}
		
		HttpStatusCode deleteClientById(int clientId)
		{
			ClientsCollection.Clients.RemoveAll(client => client.Id == clientId);
			return HttpStatusCode.NoContent;
		}
		
        HttpStatusCode updateStatus(int clientId, string status)
        {
            if (ClientsCollection.Clients.All(client => client.Id != clientId))
                return HttpStatusCode.NotFound;
            ClientsCollection.Clients.First(client => client.Id == clientId).DetailedStatus = status;
            return HttpStatusCode.OK;
        }
        
		Negotiator returnAllClients()
		{
			return 0 == ClientsCollection.Clients.Count ? Negotiate.WithStatusCode(HttpStatusCode.NotFound) : Negotiate.WithModel(ClientsCollection.Clients).WithStatusCode(HttpStatusCode.OK);
		}
		
		Negotiator returnClientById(int clientId)
		{
			// TODO: refactor this
		    return ClientsCollection.Clients.Any(client => client.Id == clientId) ? Negotiate.WithModel(ClientsCollection.Clients.Any(client => client.Id == clientId)).WithStatusCode(HttpStatusCode.OK) : Negotiate.WithStatusCode(HttpStatusCode.NotFound);
		}
	}
}
