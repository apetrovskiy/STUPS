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
	using TMX.Interfaces.Server;
	using Tmx.Core;
	
	/// <summary>
	/// Description of TestClientsModule.
	/// </summary>
	public class TestClientsModule : NancyModule
	{
		public TestClientsModule() : base(UrnList.TestClients_Root)
		{
			Post[UrnList.TestClients_Clients] = _ => {
                var testClient = this.Bind<TestClient>();
                
                int maxId = 0;
                if (0 < ClientsCollection.Clients.Count)
                	maxId = ClientsCollection.Clients.Max(client => client.Id);
				
				testClient.Id = ++maxId;
				ClientsCollection.Clients.Add(testClient);
				
				// TODO: DI
				var taskSorter = new TaskSelector();
				TaskPool.TasksForClients.AddRange(taskSorter.SelectTasksForClient(testClient.Id, TaskPool.Tasks));
				return Response.AsJson(testClient).WithStatusCode(HttpStatusCode.Created);
			};
			
			Delete[UrnList.TestClientDeregistrationPoint] = parameters => {
				try {
					var clientsToDelete = ClientsCollection.Clients.RemoveAll(client => client.Id == parameters.id);
					// TODO: clean up the list of tasks for the client if ever existed
					return HttpStatusCode.NoContent;
				}
				catch {
					return HttpStatusCode.InternalServerError;
				}
			};
		    
		    Get[UrnList.TestClients_Clients] = _ => 0 == ClientsCollection.Clients.Count ? HttpStatusCode.NotFound : Response.AsJson(ClientsCollection.Clients).WithStatusCode(HttpStatusCode.OK);
		    
		    // TODO: refactor this
		    Get[UrnList.TestClientQueryPoint] = parameters => ClientsCollection.Clients.Any(client => client.Id == parameters.id) ? Response.AsJson(ClientsCollection.Clients.Any(client => client.Id == parameters.id)) : HttpStatusCode.NotFound;
		}
	}
}
