/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/18/2014
 * Time: 11:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client
{
    using System;
	using System.Net;
	using System.Net.NetworkInformation;
    using RestSharp;
	using TMX.Interfaces.Exceptions;
	using TMX.Interfaces.Server;
	using Tmx.Interfaces;
	using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of Registration.
    /// </summary>
    public class Registration
    {
        readonly RestRequestCreator _restRequestCreator = new RestRequestCreator();
        
        public int SendRegistrationInfoAndGetClientId(string customClientString)
		{
			var request = _restRequestCreator.GetRestRequest(UrnList.TestClients_Root + UrnList.TestClients_Clients, Method.POST);
			request.AddBody(getNewTestClient(customClientString));
			var registrationResponse = _restRequestCreator.RestClient.Execute<TestClient>(request);
			if (HttpStatusCode.Created == registrationResponse.StatusCode)
				return registrationResponse.Data.Id;
			throw new Exception("Failed to register a client"); // TODO: new type!
		}
        
        public void UnregisterClient()
        {
			var request = _restRequestCreator.GetRestRequest(UrnList.TestClients_Root + "/" + ClientSettings.ClientId, Method.DELETE);
			var unregistrationResponse = _restRequestCreator.RestClient.Execute(request);
			if (HttpStatusCode.OK != unregistrationResponse.StatusCode)
                throw new ClientDeregistrationException("Failed to unregister the client");
			cleanUpClientData();
        }
        
        ITestClient getNewTestClient(string customClientString)
        {
            return new TestClient {
                CustomString = customClientString,
                Hostname = Environment.MachineName,
                Username = Environment.UserName,
                UserDomainName = Environment.UserDomainName,
                IsInteractive = Environment.UserInteractive,
                // IsAdmin = 
                // EnvironmentVersion = Environment.Version.Major + "." + Environment.Version.MajorRevision + "." + Environment.Version.Minor + "." + Environment.Version.MinorRevision + "." + Environment.Version.Build,
                Fqdn = Dns.GetHostName() + "." + IPGlobalProperties.GetIPGlobalProperties().DomainName,
                OsVersion = Environment.OSVersion.VersionString,
                UptimeSeconds = Environment.TickCount / 1000
            };
        }
        
		void cleanUpClientData()
		{
			ClientSettings.ClientId = 0;
			ClientSettings.CurrentTask = null;
			ClientSettings.ServerUrl = string.Empty;
		}
    }
}
