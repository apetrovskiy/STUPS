/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/17/2014
 * Time: 8:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Library.Modules
{
    using System;
    using Core.Types.Remoting;
    using Logic.Internal;
    using Logic.ObjectModel;
    using Nancy;
    using Nancy.ModelBinding;
    using Nancy.Responses.Negotiation;
    using Interfaces.Server;
    
    /// <summary>
    /// Description of TestClientsModule.
    /// </summary>
    public class TestClientsModule : NancyModule
    {
        public TestClientsModule() : base(UrlList.TestClients_Root)
        {
            Post[UrlList.TestClientRegistrationPoint_relPath] = _ => CreateNewClient(this.Bind<TestClient>());
            
            Delete[UrlList.TestClientDeregistrationPoint_relPath] = parameters => DeleteClientById(parameters.id);
            
            Put[UrlList.TestClient_Status_relPath] = parameters => {
                var detailedStatus = this.Bind<DetailedStatus>();
                return UpdateStatus(parameters.id, detailedStatus);
            };
            
            Get[UrlList.TestClientRegistrationPoint_relPath] = _ => ReturnAllClients();
            
            Get[UrlList.TestClientQueryPoint_relPath] = parameters => ReturnClientById(parameters.id);
        }
        
        Negotiator CreateNewClient(TestClient testClient)
        {
            return ServerObjectFactory.Resolve<TestClientCollectionMethods>().CreateNewClient(testClient)
                ? Negotiate.WithModel(testClient).WithStatusCode(HttpStatusCode.Created)
                // : Negotiate.WithStatusCode(HttpStatusCode.ExpectationFailed);
                : Negotiate.WithStatusCode(HttpStatusCode.ExpectationFailed).WithReasonPhrase(ServerLibrary.ReasonPhrase_TestClientsModule_FailedToCreateNewTestClient); // TODO: check that the phrase fits
        }
        
        HttpStatusCode DeleteClientById(Guid clientId)
        {
            ServerObjectFactory.Resolve<TestClientCollectionMethods>().DeleteClientById(clientId);
            return HttpStatusCode.NoContent;
        }

        HttpStatusCode UpdateStatus(Guid clientId, DetailedStatus detailedStatus)
        {
            return ServerObjectFactory.Resolve<TestClientCollectionMethods>().UpdateStatus(clientId, detailedStatus)
                ? HttpStatusCode.OK
                : HttpStatusCode.NotFound;
        }
        
        Negotiator ReturnAllClients()
        {
            var clientCollection = ServerObjectFactory.Resolve<TestClientCollectionMethods>().ReturnAllClients();
            return 0 == clientCollection.Count ? Negotiate.WithStatusCode(HttpStatusCode.NotFound) : Negotiate.WithModel(clientCollection).WithStatusCode(HttpStatusCode.OK);
        }
        
        Negotiator ReturnClientById(Guid clientId)
        {
            var testClient = ServerObjectFactory.Resolve<TestClientCollectionMethods>().ReturnClientById(clientId);
            return null != testClient ? Negotiate.WithModel(testClient).WithStatusCode(HttpStatusCode.OK) : Negotiate.WithStatusCode(HttpStatusCode.NotFound);
        }
    }
}
