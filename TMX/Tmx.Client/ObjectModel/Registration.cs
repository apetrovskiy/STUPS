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
    using System.Diagnostics;
	using System.Net;
    using PSTestLib.Helpers;
	using Spring.Http;
	using Spring.Rest.Client;
    using Tmx.Core.Types.Remoting;
	using Tmx.Interfaces.Exceptions;
	using Tmx.Interfaces.Server;
	using Tmx.Core;
	using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of Registration.
    /// </summary>
    public class Registration
    {
        // volatile RestTemplate _restTemplate;
        RestTemplate _restTemplate;
        
        public Registration(RestRequestCreator requestCreator)
        {
            _restTemplate = requestCreator.GetRestTemplate();
            
//            // 20141211
//            // temporary
//            // TODO: think about where to move it
//            var tracingControl = new TracingControl("TmxClient_");
        }
        
        public virtual Guid SendRegistrationInfoAndGetClientId(string customClientString)
        {
            Trace.TraceInformation("SendRegistrationInfoAndGetClientId(string customClientString).1");
            
            var registrationResponse = _restTemplate.PostForMessage<TestClient>(UrlList.TestClientRegistrationPoint_absPath, getNewTestClient(customClientString));
            
            Trace.TraceInformation("registrationResponse is null {0}", null == registrationResponse);
            Trace.TraceInformation("registrationResponse.Body is null {0}", null == registrationResponse.Body);
            
            if (HttpStatusCode.Created == registrationResponse.StatusCode)
                ClientSettings.Instance.CurrentClient = registrationResponse.Body;
            
            Trace.TraceInformation("ClientSettings.Instance.CurrentClient = registrationResponse.Body");
            
            if (HttpStatusCode.Created == registrationResponse.StatusCode)
                return registrationResponse.Body.Id;
            
            Trace.TraceInformation("registrationResponse.Body.Id = {0}", registrationResponse.Body.Id);
            
            // TODO: AOP
            Trace.TraceWarning("SendRegistrationInfoAndGetClientId(string customClientString).2");
            Trace.TraceWarning("Failed to register a client. "+ registrationResponse.StatusCode);
            throw new Exception("Failed to register a client. "+ registrationResponse.StatusCode); // TODO: new type!
        }
        
        public virtual void UnregisterClient()
        {
            closeCurrentTaskIfAny();
            try {
                
                // 20141211
                // TODO: AOP
                Trace.TraceInformation("UnregisterClient().1: client id = {0}, url = {1}", ClientSettings.Instance.ClientId, UrlList.TestClients_Root + "/" + ClientSettings.Instance.ClientId);
                
                // 20141216
                // _restTemplate.Delete(UrlList.TestClients_Root + "/" + ClientSettings.Instance.ClientId);
                var unregisteringClientResponse = _restTemplate.Exchange(UrlList.TestClients_Root + "/" + ClientSettings.Instance.ClientId, HttpMethod.DELETE, null);
                if (HttpStatusCode.NoContent != unregisteringClientResponse.StatusCode)
                    throw new ClientDeregistrationException("Failed to unregister the client");
                ClientSettings.Instance.ResetData();
                
                Trace.TraceInformation("UnregisterClient().2");
            }
            catch (RestClientException eUnregisteringClient) {
                // TODO: AOP
                Trace.TraceError("UnregisterClient()");
                Trace.TraceError(eUnregisteringClient.Message);
                throw new ClientDeregistrationException("Failed to unregister the client. " + eUnregisteringClient.Message);
            }
        }
        
        ITestClient getNewTestClient(string customClientString)
        {
            return new TestClient { CustomString = customClientString };
        }
        
        void closeCurrentTaskIfAny()
        {
            
            Trace.TraceInformation("closeCurrentTaskIfAny().1");
            
            var task = ClientSettings.Instance.CurrentTask;
            
            Trace.TraceInformation("closeCurrentTaskIfAny().2");
            
            if (null == task) return;
            
            Trace.TraceInformation("closeCurrentTaskIfAny().3");
            
            var taskUpdater = new TaskUpdater(new RestRequestCreator());
            
            Trace.TraceInformation("closeCurrentTaskIfAny().4");
            
            task.TaskFinished = true;
            
            Trace.TraceInformation("closeCurrentTaskIfAny().5");
            
            task.TaskStatus = TestTaskStatuses.CompletedSuccessfully;
            
            Trace.TraceInformation("closeCurrentTaskIfAny().6");
            
            taskUpdater.UpdateTask(task);
            
            Trace.TraceInformation("closeCurrentTaskIfAny().7");
        }
    }
}
