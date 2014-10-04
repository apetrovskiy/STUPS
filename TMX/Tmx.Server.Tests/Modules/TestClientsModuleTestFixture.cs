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
	using Tmx.Interfaces.Internal;
	using Tmx.Interfaces.Server;
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
	    const string _testClientHostnameExpected = "testhost";
	    const string _testClientUsernameExpected = "aaa";
	    BrowserResponse response;
	    Browser _browser;
        
        public TestClientsModuleTestFixture()
        {
            TestSettings.PrepareModuleTests();
            _browser = TestFactory.GetBrowserForTestTasksModule();
        }
        
    	[MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
    	public void SetUp()
    	{
    	    TestSettings.PrepareModuleTests();
    	    _browser = TestFactory.GetBrowserForTestTasksModule();
    	}
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_register_the_first_test_client_as_json()
        {
            var testClient = GIVEN_TestClient("testhost_01", "aaa_01");
            
            WHEN_SendingRegistration_as_Json(testClient);
            
            THEN_Http_Response_Is_Created();
            THEN_Test_Client_Properties_Were_Applied(testClient);
            THEN_Id_Of_The_First_Client_Equals(response.Body.DeserializeJson<TestClient>().Id);
            THEN_test_client_is_free(testClient);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_register_the_first_test_client_as_xml()
        {
            var testClient = GIVEN_TestClient("testhost_01", "aaa_01");
            
            WHEN_SendingRegistration_as_Xml(testClient as TestClient);
            
            THEN_Http_Response_Is_Created();
            THEN_Test_Client_Properties_Were_Applied(testClient);
            THEN_Id_Of_The_First_Client_Equals(response.Body.DeserializeXml<TestClient>().Id);
            THEN_test_client_is_free(testClient);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_register_the_second_test_client_as_json()
        {
            GIVEN_SendingRegistration_as_Json(GIVEN_TestClient("testhost_001", "aaa_001"));
            var testClient02 = GIVEN_TestClient("testhost_002", "aaa_002");
            
            WHEN_SendingRegistration_as_Json(testClient02);
            
            THEN_Http_Response_Is_Created();
            THEN_Test_Client_Properties_Were_Applied(testClient02);
            THEN_Id_Of_The_First_Client_Equals(response.Body.DeserializeJson<TestClient>().Id);
            THEN_test_client_is_free(testClient02);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_register_the_second_test_client_as_xml()
        {
            GIVEN_SendingRegistration_as_Xml(GIVEN_TestClient("testhost_001", "aaa_001") as TestClient);
            var testClient02 = GIVEN_TestClient("testhost_002", "aaa_002") as TestClient;
            
            WHEN_SendingRegistration_as_Xml(testClient02);
            
            THEN_Http_Response_Is_Created();
            THEN_Test_Client_Properties_Were_Applied(testClient02);
            THEN_Id_Of_The_First_Client_Equals(response.Body.DeserializeXml<TestClient>().Id);
            THEN_test_client_is_free(testClient02);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_be_no_clients_after_unregistering_the_only_test_client_as_json()
        {
            var testClient = GIVEN_SendingRegistration_as_Json(GIVEN_TestClient("testhost_02", "aaa_02"));
            
            WHEN_SendingDeregistrationas_as_json(testClient);
            
            THEN_There_Is_The_Number_Of_Registered_Clients(0);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_be_no_clients_after_unregistering_the_only_test_client_as_xml()
        {
            var testClient = GIVEN_SendingRegistration_as_Xml(GIVEN_TestClient("testhost_02", "aaa_02") as TestClient);
            
            WHEN_SendingDeregistrationas_as_json(testClient);
            
            THEN_There_Is_The_Number_Of_Registered_Clients(0);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_be_only_one_client_after_unregistering_one_of_two_test_clients_as_json()
        {
            var testClient01 = GIVEN_SendingRegistration_as_Json(GIVEN_TestClient("testhost_03", "aaa_03"));
            var testClient02 = GIVEN_SendingRegistration_as_Json(GIVEN_TestClient("testhost_04", "aaa_04"));
            
            WHEN_SendingDeregistrationas_as_json(testClient01);
            
            THEN_There_Is_The_Number_Of_Registered_Clients(testClient01.Id);
            THEN_Id_Of_The_First_Client_Equals(testClient02.Id);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_be_only_one_client_after_unregistering_one_of_two_test_clients_as_xml()
        {
            var testClient01 = GIVEN_SendingRegistration_as_Xml(GIVEN_TestClient("testhost_03", "aaa_03") as TestClient);
            var testClient02 = GIVEN_SendingRegistration_as_Xml(GIVEN_TestClient("testhost_04", "aaa_04") as TestClient);
            
            WHEN_SendingDeregistrationas_as_xml(testClient01);
            
            THEN_There_Is_The_Number_Of_Registered_Clients(testClient01.Id);
            THEN_Id_Of_The_First_Client_Equals(testClient02.Id);
        }
        
        // ============================================================================================================================
        ITestClient GIVEN_TestClient(string hostname, string username)
        {
            return TestFactory.GivenTestClient(hostname, username);
        }
        
        ITestClient GIVEN_SendingRegistration_as_Json(ITestClient testClient)
        {
            WHEN_SendingRegistration_as_Json(testClient);
            return response.Body.DeserializeJson<TestClient>();
        }
        
        ITestClient GIVEN_SendingRegistration_as_Xml(TestClient testClient)
        {
            WHEN_SendingRegistration_as_Xml(testClient);
            return response.Body.DeserializeXml<TestClient>();
        }
        
        void WHEN_SendingRegistration_as_Json(ITestClient testClient)
        {
            response = _browser.Post(UrnList.TestClientRegistrationPoint, with => {
                with.JsonBody<ITestClient>(testClient);
                with.Accept("application/json");
            });
        }
        
        void WHEN_SendingRegistration_as_Xml(TestClient testClient)
        {
            response = _browser.Post(UrnList.TestClientRegistrationPoint, with => {
                with.XMLBody<TestClient>(testClient);
                with.Accept("application/xml");
            });
        }
        
        void WHEN_SendingDeregistrationas_as_json(ITestClient testClient)
        {
            _browser.Delete(UrnList.TestClients_Root + "/" + testClient.Id, with => with.Accept("application/json"));
        }
        
        void WHEN_SendingDeregistrationas_as_xml(ITestClient testClient)
        {
            _browser.Delete(UrnList.TestClients_Root + "/" + testClient.Id, with => with.Accept("application/xml"));
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
        
        void THEN_Http_Response_Is_Created()
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
        
        // TODO: duplicated
        void THEN_test_client_is_busy(ITestClient testClient)
        {
            Xunit.Assert.Equal(TestClientStatuses.WorkflowInProgress, testClient.Status);
        }
        
        void THEN_test_client_is_free(ITestClient testClient)
        {
            Xunit.Assert.Equal(TestClientStatuses.NoTasks, testClient.Status);
        }
    }
}
