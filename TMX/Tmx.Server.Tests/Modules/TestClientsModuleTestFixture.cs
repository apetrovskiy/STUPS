/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/18/2014
 * Time: 9:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Tests.Modules
{
    using System;
    using System.Management.Automation;
    using Nancy;
    using Nancy.Testing;
    using MbUnit.Framework;
    using NUnit.Framework;
	using TMX.Interfaces.Internal;
	using TMX.Interfaces.Server;
	using Tmx.Core;
	using Tmx.Interfaces;
	using Tmx.Interfaces.Remoting;
	using Tmx.Interfaces.TestStructure;
	using Tmx.Server.Modules;
    using Xunit;
    using PSTestLib;
    
    /// <summary>
    /// Description of TestClientsModuleTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class TestClientsModuleTestFixture
    {
        public TestClientsModuleTestFixture()
        {
            TestSettings.PrepareModuleTests();
        }
        
    	[MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
    	public void SetUp()
    	{
    	    TestSettings.PrepareModuleTests();
    	}
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_register_the_first_test_client()
        {
            var testClient = givenTestClient("testhost_01", "aaa_01");
            
            var response = whenSendingRegistration(testClient);
            
            thenHttpResponseIsCreated(response);
            thenTestClientPropertiesWereApplied(testClient);
            thenIdOfTheFirstClientEquals(response.Body.DeserializeJson<TestClient>().Id);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_register_the_second_test_client()
        {
            givenSendingRegistration(givenTestClient("testhost_001", "aaa_001"));
            var testClient02 = givenTestClient("testhost_002", "aaa_002");
            
            var response = whenSendingRegistration(testClient02);
            
            thenHttpResponseIsCreated(response);
            thenTestClientPropertiesWereApplied(testClient02);
            thenIdOfTheFirstClientEquals(response.Body.DeserializeJson<TestClient>().Id);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_be_no_clients_after_unregistering_the_only_test_client()
        {
            var testClient = givenSendingRegistration(givenTestClient("testhost_02", "aaa_02"));
            
            whenSendingDeregistration(testClient);
            
            thenThereIsTheNumberOfRegisteredClients(0);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_be_only_one_client_after_unregistering_one_of_two_test_clients()
        {
            var testClient01 = givenSendingRegistration(givenTestClient("testhost_03", "aaa_03"));
            var testClient02 = givenSendingRegistration(givenTestClient("testhost_04", "aaa_04"));
            
            whenSendingDeregistration(testClient01);
            
            thenThereIsTheNumberOfRegisteredClients(testClient01.Id);
            thenIdOfTheFirstClientEquals(testClient02.Id);
        }
        
        ITestClient givenTestClient(string hostname, string username)
        {
            return TestFactory.GivenTestClient(hostname, username);
        }
        
        ITestClient givenSendingRegistration(ITestClient testClient)
        {
            var response = whenSendingRegistration(testClient);
            return response.Body.DeserializeJson<TestClient>();
        }
        
        BrowserResponse whenSendingRegistration(ITestClient testClient)
        {
            var browser = TestFactory.GetBrowserForTestClientsModule();
            return browser.Post(UrnList.TestClientRegistrationPoint, with => with.JsonBody<ITestClient>(testClient));
        }
        
        void whenSendingDeregistration(ITestClient testClient)
        {
            var browser = TestFactory.GetBrowserForTestClientsModule();
            browser.Delete(UrnList.TestClients_Root + "/" + testClient.Id);
        }
        
        void thenThereIsTheNumberOfRegisteredClients(int number)
        {
            Xunit.Assert.Equal(number, ClientsCollection.Clients.Count);
        }
        
        void thenIdOfTheFirstClientEquals(int clientId)
        {
            int testClientCounter = ClientsCollection.Clients.Count - 1;
            Xunit.Assert.Equal(clientId, ClientsCollection.Clients[testClientCounter].Id);
        }
        
        void thenHttpResponseIsCreated(BrowserResponse response)
        {
            Xunit.Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
        
        void thenTestClientPropertiesWereApplied(ISystemInfo testClient)
        {
            int testClientCounter = ClientsCollection.Clients.Count - 1;
            Xunit.Assert.Equal(testClient.CustomString, ClientsCollection.Clients[testClientCounter].CustomString);
            Xunit.Assert.Equal(testClient.EnvironmentVersion, ClientsCollection.Clients[testClientCounter].EnvironmentVersion);
            Xunit.Assert.Equal(testClient.Fqdn, ClientsCollection.Clients[testClientCounter].Fqdn);
            Xunit.Assert.Equal(testClient.Hostname, ClientsCollection.Clients[testClientCounter].Hostname);
            Xunit.Assert.Equal(testClient.IsAdmin, ClientsCollection.Clients[testClientCounter].IsAdmin);
            Xunit.Assert.Equal(testClient.IsInteractive, ClientsCollection.Clients[testClientCounter].IsInteractive);
            Xunit.Assert.Equal(testClient.Language, ClientsCollection.Clients[testClientCounter].Language);
            // Xunit.Assert.Equal(testClient.OsEdition, ClientsCollection.Clients[testClientCounter].OsEdition);
            // Xunit.Assert.Equal(testClient.OsName, ClientsCollection.Clients[testClientCounter].OsName);
            Xunit.Assert.Equal(testClient.OsVersion, ClientsCollection.Clients[testClientCounter].OsVersion);
            Xunit.Assert.Equal(testClient.UptimeSeconds, ClientsCollection.Clients[testClientCounter].UptimeSeconds);
            Xunit.Assert.Equal(testClient.UserDomainName, ClientsCollection.Clients[testClientCounter].UserDomainName);
            Xunit.Assert.Equal(testClient.Username, ClientsCollection.Clients[testClientCounter].Username);
        }
    }
}
