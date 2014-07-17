/*
 * Created by SharpDevelop.
 * User: alexa_000
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
	using TMX.Interfaces;
	using Tmx.Server.Helpers.Objects;
	
	/// <summary>
	/// Description of TestClientsModule.
	/// </summary>
	public class TestClientsModule : NancyModule
	{
		public TestClientsModule() : base("/Clients")
		{
			Post["/"] = parameters => {
                var testClient = this.Bind<TestClientInformation>();
                
                int maxId = 1;
                if (0 < ClientsCollection.Clients.Count)
                	maxId = ClientsCollection.Clients.Max(client => client.Id);
                
				ClientsCollection.Clients.Add(
					new TestClientInformation {
                		Id = ++maxId,
						Hostname = testClient.Hostname,
						Fqdn = testClient.Fqdn,
						IpAddresses = testClient.IpAddresses,
						MacAddresses = testClient.MacAddresses,
						UserDomainName = testClient.UserDomainName,
						Username = testClient.Username,
						IsInteractive = testClient.IsInteractive,
						IsAdmin = testClient.IsAdmin,
						OsVersion = testClient.OsVersion,
						EnvironmentVersion = testClient.EnvironmentVersion,
						UptimeSeconds = testClient.UptimeSeconds,
						CustomString = testClient.CustomString
					});
                
                return HttpStatusCode.Created;
			};
			
			Delete["/{id}"] = parameters => {
				try {
					var clientsToDelete = ClientsCollection.Clients.RemoveAll(client => client.Id == parameters.id);
						return HttpStatusCode.OK;
				}
				catch {
					return HttpStatusCode.InternalServerError;
				}
			};
		}
	}
}
