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
	using System.Security.Principal;
    // using RestSharp;
	using Spring.Http;
	using Spring.Rest.Client;
	using TMX.Interfaces.Exceptions;
	using TMX.Interfaces.Server;
	using Tmx.Interfaces;
	using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of Registration.
    /// </summary>
    public class Registration
    {
        // readonly RestRequestCreator _restRequestCreator = new RestRequestCreator();
        // 20140820
        // move from RestSharp to RestTemplate
//        volatile RestRequestCreator _restRequestCreator;
        volatile RestTemplate _restTemplate;
	    
	    public Registration(RestRequestCreator requestCreator)
	    {
	        // 20140820
            // move from RestSharp to RestTemplate
	    	// _restRequestCreator = requestCreator;
	    	_restTemplate = requestCreator.GetRestTemplate(string.Empty);
	    }
        
        public int SendRegistrationInfoAndGetClientId(string customClientString)
		{
            // 20140820
            // move from RestSharp to RestTemplate
//			var request = _restRequestCreator.GetRestRequest(UrnList.TestClients_Root + UrnList.TestClients_Clients, Method.POST);
//			request.AddBody(getNewTestClient(customClientString));
//			var registrationResponse = _restRequestCreator.RestClient.Execute<TestClient>(request);
//			if (HttpStatusCode.Created == registrationResponse.StatusCode)
//				return registrationResponse.Data.Id;
//			throw new Exception("Failed to register a client. "+ registrationResponse.StatusCode); // TODO: new type!
			
//Console.WriteLine("sending registration... 001");
			var registrationResponse = _restTemplate.PostForMessage<TestClient>(UrnList.TestClients_Root + UrnList.TestClients_Clients, getNewTestClient(customClientString));
//			var newTestClient = getNewTestClient(customClientString);
//Console.WriteLine("sending registration... 001.1");
//			var registrationResponse = _restTemplate.PostForMessage<TestClient>(UrnList.TestClients_Root + UrnList.TestClients_Clients, newTestClient);
//Console.WriteLine("sending registration... 002");
			if (HttpStatusCode.Created == registrationResponse.StatusCode)
				return registrationResponse.Body.Id;
//Console.WriteLine("sending registration... 003");
			throw new Exception("Failed to register a client. "+ registrationResponse.StatusCode); // TODO: new type!
		}
        
        public void UnregisterClient()
        {
            // 20140820
            // move from RestSharp to RestTemplate
//			// var request = _restRequestCreator.GetRestRequest(UrnList.TestClients_Root + "/" + ClientSettings.ClientId, Method.DELETE);
//			var clientSettings = ClientSettings.Instance;
//			var request = _restRequestCreator.GetRestRequest(UrnList.TestClients_Root + "/" + clientSettings.ClientId, Method.DELETE);
//			var unregistrationResponse = _restRequestCreator.RestClient.Execute(request);
//			if (HttpStatusCode.OK != unregistrationResponse.StatusCode)
//                throw new ClientDeregistrationException("Failed to unregister the client. " + unregistrationResponse.StatusCode);
//			// ClientSettings.ResetData();
//			clientSettings.ResetData();
			
			try {
			    _restTemplate.Delete(UrnList.TestClients_Root + "/" + ClientSettings.Instance.ClientId);
                ClientSettings.Instance.ResetData();
			}
			catch {
			    throw new ClientDeregistrationException("Failed to unregister the client");
			}
        }
        
        ITestClient getNewTestClient(string customClientString)
        {
            return new TestClient {
                CustomString = customClientString,
                Hostname = Environment.MachineName,
                Username = Environment.UserName,
                UserDomainName = Environment.UserDomainName,
                IsInteractive = Environment.UserInteractive,
                IsAdmin = isAdministrator(),
                // EnvironmentVersion = Environment.Version.Major + "." + Environment.Version.MajorRevision + "." + Environment.Version.Minor + "." + Environment.Version.MinorRevision + "." + Environment.Version.Build,
                Fqdn = Dns.GetHostName() + "." + IPGlobalProperties.GetIPGlobalProperties().DomainName,
                OsVersion = Environment.OSVersion.VersionString,
                UptimeSeconds = Environment.TickCount / 1000
            };
        }
        
        bool isAdministrator()
        {
            var principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
