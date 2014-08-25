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
        volatile RestTemplate _restTemplate;
	    
	    public Registration(RestRequestCreator requestCreator)
	    {
	    	_restTemplate = requestCreator.GetRestTemplate(string.Empty);
	    }
        
        public int SendRegistrationInfoAndGetClientId(string customClientString)
		{
			var registrationResponse = _restTemplate.PostForMessage<TestClient>(UrnList.TestClientRegistrationPoint, getNewTestClient(customClientString));
			if (HttpStatusCode.Created == registrationResponse.StatusCode)
				return registrationResponse.Body.Id;
			throw new Exception("Failed to register a client. "+ registrationResponse.StatusCode); // TODO: new type!
		}
        
        public void UnregisterClient()
        {
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
