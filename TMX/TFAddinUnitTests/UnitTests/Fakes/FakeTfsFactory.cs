/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/28/2013
 * Time: 3:12 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TFAddinUnitTests
{
//    using System;
//    using System.Net;
//    using MbUnit.Framework;
//    using PSTestLib;
//    using Moq;
//    //using m
////    using Moq;
////    using Autofac;
////    using Autofac.Builder;
//    using TMX;
//    using Microsoft.TeamFoundation.Client;
//    //using Microsoft.TeamFoundation.Client.Internal;
//    //using Microsoft.TeamFoundation.Client.ProjectSettings;
//    using Microsoft.TeamFoundation.TestManagement.Client;
//    using Microsoft.TeamFoundation.WorkItemTracking.Client;
    
    
    using System;
    //using System.Management.Automation;
    using System.Net;
    //using System.Collections.Specialized;
    using System.Globalization;
    //using Microsoft.TeamFoundation
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.TestManagement.Client;
    using Microsoft.TeamFoundation.WorkItemTracking.Client;
    using Microsoft.TeamFoundation.Client.Channels;
    using Microsoft.TeamFoundation.Framework.Client;
    using MbUnit.Framework;
    using PSTestLib;
    using Moq;
    //using m
//    using Moq;
//    using Autofac;
//    using Autofac.Builder;
    using TMX;
    
    /// <summary>
    /// Description of FakeTfsFactory.
    /// </summary>
    public static class FakeTfsFactory
    {
        static FakeTfsFactory()
        {
        }
        
        //internal static string TestLinkApiKeyRight = "56238b86d143acaef5b2175ce840e132"; //"aaa"; // "56238b86d143acaef5b2175ce840e132";
        //internal static string TestLinkApiKeyWrong = "wrong api key";
        internal static string TfsUrlRight = "http://1.2.3.4:8080/tfs";
        internal static string TfsUrlWrong = "wrong url";
        internal static ICredentials Credentials = new NetworkCredential();
        
        [ThreadStatic]
        private static System.Random generator = new System.Random();
        
        private static Mock<TfsConnection> _getTfsMock(string url, ICredentials credentials)
        {
            Uri uri =
                    new Uri(url);
            
            var tfsMock = new Mock<TfsConfigurationServer>(uri, credentials).As<TfsConnection>();
            
            //tfsMock.Setup(t => t.Initialize(
            //tfsMock.Setup(t => t.
            
//            // checking the api key via TestLink.checkDevKey(string)
//            tfsMock.Setup(t => t.checkDevKey(TestLinkApiKeyRight)).Returns(true);
//            tfsMock.Setup(t => t.checkDevKey(TestLinkApiKeyWrong))
//                .Throws(new TestLinkException("2000:(checkDevKey) - Can not authenticate client: invalid developer key"));
//            tfsMock.Setup(t => t.checkDevKey(string.Empty))
//                .Throws(new TestLinkException("Devkey is empty. You must supply a development key"));
//            
//            // checking the url via TestLink.SayHello()
//            if (TestLinkUrlRight == url) {
//                tfsMock.Setup(t => t.SayHello()).Returns(() => string.Empty);
//            } else if (TestLinkUrlWrong == url) {
//                tfsMock.Setup(t => t.SayHello())
//                    .Throws(new UriFormatException("Invalid URI: The format of the URI could not be determined."));
//            } else if (string.Empty == url) {
//                tfsMock.Setup(t => t.SayHello())
//                    .Throws(new XmlRpcMissingUrl("Proxy XmlRpcUrl attribute or Url property not set."));
//            }

            return tfsMock;
        }
        
        private static Mock<TfsConnection> _getTfsMock()
        {
            var tfsMock =
                _getTfsMock(
                    TfsUrlRight,
                    Credentials);
            
            return tfsMock;
        }
        
        public static TfsConnection GetTfsConfigurationServer(string uri, ICredentials credentials)
        {
            // constructor
            var tfsMock = _getTfsMock(uri, credentials);
            
            return tfsMock.Object;
        }
        
        private static Mock<TfsConnection> _getTfskMockProjectCollection(string name)
        {
            //var tfsMock = _getTfskMock();
           
            //var tfsMock.Setup(t => t //..GetProjects()).Returns(listOfProjects);
            //testLinkMock.Setup(t => t.GetProject(It.IsAny<string>())).Returns((string s) => listOfProjects.Find(item => item.name == s));
            
            var tfsMock = new Mock<TfsTeamProjectCollection>().As<TfsConnection>();
            //tfsMock.SetupProperty(
            
            //projectCollection.Authenticate()
            //tfsMock.Setup(t => t.Authenticate()).
            
            //TeamFoundationIdentity projectCollection.AuthorizedIdentity
            //tfsMock.SetupProperty(v => v.AuthorizedIdentity, new TeamFoundationIdentity
            
            //Guid projectCollection.CachedInstanceId
            //CatalogNode projectCollection.CatalogNode
            //ITfsRequestChannelFactory projectCollection.ChannelFactory
            //string projectCollection.ClientCacheDirectoryForInstance
            //TfsClientCredentials projectCollection.ClientCredentials
            //TfsConfigurationServer projectCollection.ConfigurationServer
            //projectCollection.Connect(connectOptions)
            //bool projectCollection.ConnectivityFailureOnLastWebServiceCall
            //ConnectivityFailureStatusChangedEventHandler projectCollection.ConnectivityFailureStatusChanged
            //ICredentials projectCollection.Credentials
            //CredentialsChangedEventHandler projectCollection.CredentialsChanged
            //CultureInfo projectCollection.Culture
            //projectCollection.Disconnect()
            //projectCollection.Dispose()
            //projectCollection.EnsureAuthenticated()
            //projectCollection.Equals(object object)
            //projectCollection.FlushServices()
            //projectCollection.GetAuthenticatedIdentity(out TeamFoundationIdentity identity)
            //int projectCollection.GetHashCode()
            //projectCollection.GetService<T>()
            //projectCollection.GetService(Type serviceType)
            //projectCollection.GetType()
            //bool projectCollection.HasAuthenticated
            //IdentityDescriptor projectCollection.IdentityToImpersonate
            //Guid projectCollection.InstanceId
            //bool projectCollection.IsHostedServer
            //string projectCollection.Name
            //TFProxyServer projectCollection.ProxyServer
            //ServerCapabilities projectCollection.ServerCapabilities
            //IServerDataProvider projectCollection.ServerDataProvider
            //Guid projectCollection.SessionId
            //TeamFoundationServer projectCollection.TeamFoundationServer
            //TimeZone projectCollection.TimeZone
            //projectCollection.ToString()
            //CultureInfo projectCollection.UICulture
            //Uri projectCollection.Uri
            
            
            return tfsMock;
        }
        
        public static TfsConnection GetTfsProjectCollection(string name)
        {
            var tfsMock = _getTfskMockProjectCollection(name);
            
            return tfsMock.Object;
        }
    }
}
