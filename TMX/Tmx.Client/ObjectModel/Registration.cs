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
	using Spring.Http;
	using Spring.Rest.Client;
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
	    }
        
        public virtual Guid SendRegistrationInfoAndGetClientId(string customClientString)
		{
			var registrationResponse = _restTemplate.PostForMessage<TestClient>(UrnList.TestClientRegistrationPoint_absPath, getNewTestClient(customClientString));
			
			if (HttpStatusCode.Created == registrationResponse.StatusCode)
			    ClientSettings.Instance.CurrentClient = registrationResponse.Body;
			
			if (HttpStatusCode.Created == registrationResponse.StatusCode)
				return registrationResponse.Body.Id;
			throw new Exception("Failed to register a client. "+ registrationResponse.StatusCode); // TODO: new type!
		}
        
        public virtual void UnregisterClient()
        {
            closeCurrentTaskIfAny();
			try {
			    _restTemplate.Delete(UrnList.TestClients_Root + "/" + ClientSettings.Instance.ClientId);
                ClientSettings.Instance.ResetData();
			}
            catch (RestClientException eUnregisteringClient) {
			    throw new ClientDeregistrationException("Failed to unregister the client. " + eUnregisteringClient.Message);
			}
        }
        
        ITestClient getNewTestClient(string customClientString)
        {
            return new TestClient { CustomString = customClientString };
        }
        
        void closeCurrentTaskIfAny()
        {
            var task = ClientSettings.Instance.CurrentTask;
            if (null == task) return;
            var taskUpdater = new TaskUpdater(new RestRequestCreator());
            task.TaskFinished = true;
            task.TaskStatus = TestTaskStatuses.CompletedSuccessfully;
            taskUpdater.UpdateTask(task);
        }
    }
}
