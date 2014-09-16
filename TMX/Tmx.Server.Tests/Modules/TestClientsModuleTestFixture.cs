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
            var testClient = GIVEN_TestClient("testhost_01", "aaa_01");
            
            var response = WHEN_SendingRegistration(testClient);
            
            THEN_Http_Response_Is_Created(response);
            THEN_Test_Client_Properties_Were_Applied(testClient);
            THEN_Id_Of_The_First_Client_Equals(response.Body.DeserializeJson<TestClient>().Id);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_register_the_second_test_client()
        {
            GIVEN_SendingRegistration(GIVEN_TestClient("testhost_001", "aaa_001"));
            var testClient02 = GIVEN_TestClient("testhost_002", "aaa_002");
            
            var response = WHEN_SendingRegistration(testClient02);
            
            THEN_Http_Response_Is_Created(response);
            THEN_Test_Client_Properties_Were_Applied(testClient02);
            THEN_Id_Of_The_First_Client_Equals(response.Body.DeserializeJson<TestClient>().Id);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_be_no_clients_after_unregistering_the_only_test_client()
        {
            var testClient = GIVEN_SendingRegistration(GIVEN_TestClient("testhost_02", "aaa_02"));
            
            WHEN_SendingDeregistration(testClient);
            
            THEN_There_Is_The_Number_Of_Registered_Clients(0);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_be_only_one_client_after_unregistering_one_of_two_test_clients()
        {
            var testClient01 = GIVEN_SendingRegistration(GIVEN_TestClient("testhost_03", "aaa_03"));
            var testClient02 = GIVEN_SendingRegistration(GIVEN_TestClient("testhost_04", "aaa_04"));
            
            WHEN_SendingDeregistration(testClient01);
            
            THEN_There_Is_The_Number_Of_Registered_Clients(testClient01.Id);
            THEN_Id_Of_The_First_Client_Equals(testClient02.Id);
        }
        
        // ============================================================================================================================
        ITestClient GIVEN_TestClient(string hostname, string username)
        {
            return TestFactory.GivenTestClient(hostname, username);
        }
        
        ITestClient GIVEN_SendingRegistration(ITestClient testClient)
        {
            var response = WHEN_SendingRegistration(testClient);
            return response.Body.DeserializeJson<TestClient>();
        }
        
        BrowserResponse WHEN_SendingRegistration(ITestClient testClient)
        {
            var browser = TestFactory.GetBrowserForTestClientsModule();
            return browser.Post(UrnList.TestClientRegistrationPoint, with => with.JsonBody<ITestClient>(testClient));
        }
        
        void WHEN_SendingDeregistration(ITestClient testClient)
        {
            var browser = TestFactory.GetBrowserForTestClientsModule();
            browser.Delete(UrnList.TestClients_Root + "/" + testClient.Id);
        }
        
        void THEN_There_Is_The_Number_Of_Registered_Clients(int number)
        {
            Xunit.Assert.Equal(number, ClientsCollection.Clients.Count);
        }
        
        void THEN_Id_Of_The_First_Client_Equals(int clientId)
        {
            int testClientCounter = ClientsCollection.Clients.Count - 1;
            Xunit.Assert.Equal(clientId, ClientsCollection.Clients[testClientCounter].Id);
        }
        
        void THEN_Http_Response_Is_Created(BrowserResponse response)
        {
            Xunit.Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
        
        void THEN_Test_Client_Properties_Were_Applied(ISystemInfo testClient)
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
