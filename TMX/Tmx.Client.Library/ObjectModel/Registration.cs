/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/18/2014
 * Time: 11:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client.Library.ObjectModel
{
    using System;
    using System.Diagnostics;
    using System.Net;
    using Core;
    using Core.Types.Remoting;
    using Interfaces.Exceptions;
    using Interfaces.Remoting;
    using Interfaces.Server;
    using Helpers;
    using Spring.Http;
    using Spring.Rest.Client;
//using PSTestLib.Helpers;
    //using Tmx.Core;

    /// <summary>
    /// Description of Registration.
    /// </summary>
    public class Registration
    {
        // volatile RestTemplate _restTemplate;
        readonly RestTemplate _restTemplate;
        
//        public Registration(IRestRequestCreator requestCreator)
//        {
//            _restTemplate = requestCreator.GetRestTemplate();
            
////            // 20141211
////            // temporary
////            // TODO: think about where to move it
////            var tracingControl = new TracingControl("TmxClient_");
//        }

        public Registration()
        {
            _restTemplate = RestRequestFactory.GetRestRequestCreator().GetRestTemplate();
        }
        
        public virtual Guid SendRegistrationInfoAndGetClientId(string customClientString)
        {
            Trace.TraceInformation("SendRegistrationInfoAndGetClientId(string customClientString).1");
            
            var registrationResponse = _restTemplate.PostForMessage<TestClient>(UrlList.TestClientRegistrationPoint_absPath, GetNewTestClient(customClientString));
            
            Trace.TraceInformation("registrationResponse is null {0}", null == registrationResponse);

            // 20150316
            if (null == registrationResponse)
                throw new Exception("Failed to register a client.");

            Trace.TraceInformation("registrationResponse.Body is null {0}", null == registrationResponse.Body);

            // 20150316
            if (null == registrationResponse.Body)
                throw new Exception("Failed to register a client.");
            
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
            CloseCurrentTaskIfAny();
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
        
        ITestClient GetNewTestClient(string customClientString)
        {
            return new TestClient { CustomString = customClientString };
        }
        
        void CloseCurrentTaskIfAny()
        {
            
            Trace.TraceInformation("closeCurrentTaskIfAny().1");
            
            var task = ClientSettings.Instance.CurrentTask;
            
            Trace.TraceInformation("closeCurrentTaskIfAny().2");
            
            if (null == task) return;
            
            Trace.TraceInformation("closeCurrentTaskIfAny().3");
            
            // 20150918
            // var taskUpdater = new TaskUpdater(new RestRequestCreator());
            var taskUpdater = new TaskUpdater();
            
            Trace.TraceInformation("closeCurrentTaskIfAny().4");
            
            // 20150112
            // task.TaskFinished = true;
            
            Trace.TraceInformation("closeCurrentTaskIfAny().5");
            
            task.TaskStatus = TestTaskStatuses.CompletedSuccessfully;

            //// 20150908
            //task.TestStatus = TestData.TestSuites.GetOveralStatus();
            //if (TestStatuses.Failed == task.TestStatus)
            //    task.TaskStatus = TestTaskStatuses.FailedByTestResults;
            //// 20150910
            //task.TestStatus = TestData.TestSuites.GetOveralStatus();
            //if (task.IsCritical && TestStatuses.Failed == task.TestStatus)
            //    task.TaskStatus = TestTaskStatuses.FailedByTestResults;
            // 20150910
            task.CheckTestStatus();

            Trace.TraceInformation("closeCurrentTaskIfAny().6");
            
            taskUpdater.UpdateTask(task);
            
            Trace.TraceInformation("closeCurrentTaskIfAny().7");
        }
    }
}
