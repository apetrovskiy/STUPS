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
    using System.Collections.Generic;
    using System.Linq;
    using Nancy;
    using Nancy.Testing;
    using MbUnit.Framework;
    using NUnit.Framework;
    using Core.Types.Remoting;
    using Interfaces.Internal;
    using Interfaces.Server;
    using Interfaces.Remoting;
    using Logic.ObjectModel.Objects;
    using Xunit;
    using UnitTestingHelpers;

    /// <summary>
    /// Description of TestClientsModuleTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class TestClientsModuleTestFixture
    {
        const string _testClientHostnameExpected01 = "testhost_01";
        const string _testClientUsernameExpected01 = "aaa_01";
        const string _testClientHostnameExpected02 = "testhost_002";
        const string _testClientUsernameExpected02 = "aaa_002";
        const string _testClientHostnameExpected03 = "testhost_03";
        const string _testClientUsernameExpected03 = "aaa_03";
        const string _theCurrentDetailedStatus = "the current status";
        const string _theLastDetailedStatus = "the latest status";
        BrowserResponse _response;
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
            var testRun = GIVEN_Active_TestRun();
            var testClient = GIVEN_TestClient(_testClientHostnameExpected01, _testClientUsernameExpected01);
            
            WHEN_SendingRegistration_as_Json(testClient);
            
            THEN_Http_Response_Is_Created();
            THEN_Test_Client_Properties_Were_Applied(testClient);
            THEN_Id_Of_The_First_Client_Equals(_response.Body.DeserializeJson<TestClient>().Id);
            THEN_test_client_is_free(testClient);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_register_the_first_test_client_as_xml()
        {
            var testRun = GIVEN_Active_TestRun();
            var testClient = GIVEN_TestClient(_testClientHostnameExpected01, _testClientUsernameExpected01);
            
            WHEN_SendingRegistration_as_Xml(testClient as TestClient);
            
            THEN_Http_Response_Is_Created();
            THEN_Test_Client_Properties_Were_Applied(testClient);
            THEN_Id_Of_The_First_Client_Equals(_response.Body.DeserializeXml<TestClient>().Id);
            THEN_test_client_is_free(testClient);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_register_the_second_test_client_as_json()
        {
            var testRun = GIVEN_Active_TestRun();
            GIVEN_SendingRegistration_as_Json(GIVEN_TestClient(_testClientHostnameExpected01, _testClientUsernameExpected01));
            var testClient02 = GIVEN_TestClient(_testClientHostnameExpected02, _testClientUsernameExpected02);
            
            WHEN_SendingRegistration_as_Json(testClient02);
            
            THEN_Http_Response_Is_Created();
            THEN_Test_Client_Properties_Were_Applied(testClient02);
            THEN_Id_Of_The_First_Client_Equals(_response.Body.DeserializeJson<TestClient>().Id);
            THEN_test_client_is_free(testClient02);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_register_the_second_test_client_as_xml()
        {
            var testRun = GIVEN_Active_TestRun();
            GIVEN_SendingRegistration_as_Xml(GIVEN_TestClient(_testClientHostnameExpected01, _testClientUsernameExpected01) as TestClient);
            var testClient02 = GIVEN_TestClient(_testClientHostnameExpected02, _testClientUsernameExpected02) as TestClient;
            
            WHEN_SendingRegistration_as_Xml(testClient02);
            
            THEN_Http_Response_Is_Created();
            THEN_Test_Client_Properties_Were_Applied(testClient02);
            THEN_Id_Of_The_First_Client_Equals(_response.Body.DeserializeXml<TestClient>().Id);
            THEN_test_client_is_free(testClient02);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_be_no_clients_after_unregistering_the_only_test_client_as_json()
        {
            var testRun = GIVEN_Active_TestRun();
            var testClient = GIVEN_SendingRegistration_as_Json(GIVEN_TestClient(_testClientHostnameExpected02, _testClientUsernameExpected02));
            
            WHEN_SendingDeregistration_as_json(testClient);
            
            THEN_There_Is_The_Number_Of_Registered_Clients(0);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_be_no_clients_after_unregistering_the_only_test_client_as_xml()
        {
            var testRun = GIVEN_Active_TestRun();
            var testClient = GIVEN_SendingRegistration_as_Xml(GIVEN_TestClient(_testClientHostnameExpected02, _testClientUsernameExpected02) as TestClient);
            
            WHEN_SendingDeregistration_as_json(testClient);
            
            THEN_There_Is_The_Number_Of_Registered_Clients(0);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_be_only_one_client_after_unregistering_one_of_two_test_clients_as_json()
        {
            var testRun = GIVEN_Active_TestRun();
            var testClient01 = GIVEN_SendingRegistration_as_Json(GIVEN_TestClient(_testClientHostnameExpected01, _testClientUsernameExpected01));
            var testClient02 = GIVEN_SendingRegistration_as_Json(GIVEN_TestClient(_testClientHostnameExpected02, _testClientUsernameExpected02));
            
            WHEN_SendingDeregistration_as_json(testClient01);
            
            THEN_There_Is_The_Number_Of_Registered_Clients(1);
            THEN_Id_Of_The_First_Client_Equals(testClient02.Id);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_be_only_one_client_after_unregistering_one_of_two_test_clients_as_xml()
        {
            var testRun = GIVEN_Active_TestRun();
            var testClient01 = GIVEN_SendingRegistration_as_Xml(GIVEN_TestClient(_testClientHostnameExpected01, _testClientUsernameExpected01) as TestClient);
            var testClient02 = GIVEN_SendingRegistration_as_Xml(GIVEN_TestClient(_testClientHostnameExpected02, _testClientUsernameExpected02) as TestClient);
            
            WHEN_SendingDeregistration_as_xml(testClient01);
            
            THEN_There_Is_The_Number_Of_Registered_Clients(1);
            THEN_Id_Of_The_First_Client_Equals(testClient02.Id);
        }
        
        // ============================================= Detailed status ==============================================================
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_set_test_client_first_status_as_json()
        {
            var testRun = GIVEN_Active_TestRun();
            var testClient01 = GIVEN_SendingRegistration_as_Json(GIVEN_TestClient(_testClientHostnameExpected01, _testClientUsernameExpected01));
            
            WHEN_SendingStatus_as_json(testClient01.Id, new DetailedStatus(_theCurrentDetailedStatus));
            
            THEN_There_Is_The_Number_Of_Registered_Clients(1); // ??
            Xunit.Assert.Equal(_theCurrentDetailedStatus, ClientsCollection.Clients.First(client => client.Id == testClient01.Id).DetailedStatus);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_set_test_client_first_status_as_xml()
        {
            var testRun = GIVEN_Active_TestRun();
            var testClient01 = GIVEN_SendingRegistration_as_Xml(GIVEN_TestClient(_testClientHostnameExpected01, _testClientUsernameExpected01) as TestClient);
            
            WHEN_SendingStatus_as_xml(testClient01.Id, new DetailedStatus(_theCurrentDetailedStatus));
            
            THEN_There_Is_The_Number_Of_Registered_Clients(1); // ??
            Xunit.Assert.Equal(_theCurrentDetailedStatus, ClientsCollection.Clients.First(client => client.Id == testClient01.Id).DetailedStatus);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_set_test_client_second_status_as_json()
        {
            var testRun = GIVEN_Active_TestRun();
            var testClient01 = GIVEN_SendingRegistration_as_Json(GIVEN_TestClient(_testClientHostnameExpected01, _testClientUsernameExpected01));
            
            WHEN_SendingStatus_as_json(testClient01.Id, new DetailedStatus(_theCurrentDetailedStatus));
            WHEN_SendingStatus_as_json(testClient01.Id, new DetailedStatus(_theLastDetailedStatus));
            
            THEN_There_Is_The_Number_Of_Registered_Clients(1); // ??
            Xunit.Assert.Equal(_theLastDetailedStatus, ClientsCollection.Clients.First(client => client.Id == testClient01.Id).DetailedStatus);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_set_test_client_second_status_as_xml()
        {
            var testRun = GIVEN_Active_TestRun();
            var testClient01 = GIVEN_SendingRegistration_as_Xml(GIVEN_TestClient(_testClientHostnameExpected01, _testClientUsernameExpected01) as TestClient);
            
            WHEN_SendingStatus_as_xml(testClient01.Id, new DetailedStatus(_theCurrentDetailedStatus));
            WHEN_SendingStatus_as_xml(testClient01.Id, new DetailedStatus(_theLastDetailedStatus));
            
            THEN_There_Is_The_Number_Of_Registered_Clients(1); // ??
            Xunit.Assert.Equal(_theLastDetailedStatus, ClientsCollection.Clients.First(client => client.Id == testClient01.Id).DetailedStatus);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_set_test_client_empty_status_as_json()
        {
            var testRun = GIVEN_Active_TestRun();
            var testClient01 = GIVEN_SendingRegistration_as_Json(GIVEN_TestClient(_testClientHostnameExpected01, _testClientUsernameExpected01));
            
            WHEN_SendingStatus_as_json(testClient01.Id, new DetailedStatus(_theCurrentDetailedStatus));
            WHEN_SendingStatus_as_json(testClient01.Id, new DetailedStatus(string.Empty));
            
            THEN_There_Is_The_Number_Of_Registered_Clients(1); // ??
            Xunit.Assert.Equal(string.Empty, ClientsCollection.Clients.First(client => client.Id == testClient01.Id).DetailedStatus);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_set_test_client_empty_status_as_xml()
        {
            var testRun = GIVEN_Active_TestRun();
            var testClient01 = GIVEN_SendingRegistration_as_Xml(GIVEN_TestClient(_testClientHostnameExpected01, _testClientUsernameExpected01) as TestClient);
            
            WHEN_SendingStatus_as_xml(testClient01.Id, new DetailedStatus(_theCurrentDetailedStatus));
            WHEN_SendingStatus_as_xml(testClient01.Id, new DetailedStatus(string.Empty));
            
            THEN_There_Is_The_Number_Of_Registered_Clients(1); // ??
            Xunit.Assert.Equal(string.Empty, ClientsCollection.Clients.First(client => client.Id == testClient01.Id).DetailedStatus);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_not_set_test_client_status_from_wrong_clientId_as_json()
        {
            var testRun = GIVEN_Active_TestRun();
            var testClient01 = GIVEN_SendingRegistration_as_Json(GIVEN_TestClient(_testClientHostnameExpected01, _testClientUsernameExpected01));
            
            WHEN_SendingStatus_as_json(testClient01.Id, new DetailedStatus(_theCurrentDetailedStatus));
            WHEN_SendingStatus_as_json(new Guid(), new DetailedStatus(_theLastDetailedStatus));
            
            THEN_There_Is_The_Number_Of_Registered_Clients(1); // ??
            THEN_Http_Response_Is_NotFound();
            Xunit.Assert.Equal(_theCurrentDetailedStatus, ClientsCollection.Clients.First(client => client.Id == testClient01.Id).DetailedStatus);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_not_set_test_client_status_from_wrong_clientId_as_xml()
        {
            var testRun = GIVEN_Active_TestRun();
            var testClient01 = GIVEN_SendingRegistration_as_Xml(GIVEN_TestClient(_testClientHostnameExpected01, _testClientUsernameExpected01) as TestClient);
            
            WHEN_SendingStatus_as_xml(testClient01.Id, new DetailedStatus(_theCurrentDetailedStatus));
            WHEN_SendingStatus_as_xml(new Guid(), new DetailedStatus(_theLastDetailedStatus));
            
            THEN_There_Is_The_Number_Of_Registered_Clients(1); // ??
            THEN_Http_Response_Is_NotFound();
            Xunit.Assert.Equal(_theCurrentDetailedStatus, ClientsCollection.Clients.First(client => client.Id == testClient01.Id).DetailedStatus);
        }
        
        // cleaning up detailed status on finishing a task
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_set_test_client_second_status_as_json()
//        {
//            const string detailedStatus01 = "the current status";
//            const string detailedStatus02 = "the latest status";
//            var testClient01 = GIVEN_SendingRegistration_as_Json(GIVEN_TestClient("testhost_03", "aaa_03"));
//            
//            WHEN_SendingStatus_as_json(testClient01.Id, new DetailedStatus(detailedStatus01));
//            WHEN_SendingStatus_as_json(testClient01.Id, new DetailedStatus(detailedStatus02));
//            
//            THEN_There_Is_The_Number_Of_Registered_Clients(testClient01.Id);
//            Xunit.Assert.Equal(detailedStatus02, ClientsCollection.Clients.First(client => client.Id == testClient01.Id).DetailedStatus);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_set_test_client_second_status_as_xml()
//        {
//            const string detailedStatus01 = "the current status";
//            const string detailedStatus02 = "the latest status";
//            var testClient01 = GIVEN_SendingRegistration_as_Xml(GIVEN_TestClient("testhost_03", "aaa_03") as TestClient);
//            
//            WHEN_SendingStatus_as_xml(testClient01.Id, new DetailedStatus(detailedStatus01));
//            WHEN_SendingStatus_as_xml(testClient01.Id, new DetailedStatus(detailedStatus02));
//            
//            THEN_There_Is_The_Number_Of_Registered_Clients(testClient01.Id);
//            Xunit.Assert.Equal(detailedStatus02, ClientsCollection.Clients.First(client => client.Id == testClient01.Id).DetailedStatus);
//        }
        
        
        
        
        // ============================================= Multi-workflow =============================================================
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_register_test_client_only_in_the_first_workflow_if_there_is_no_active_workflow()
//        {
//            var workflow01 = GIVEN_LoadedWorkflow(1, "w1");
//            GIVEN_LoadedWorkflow(2, "w2");
//            var testClient = GIVEN_TestClient("h", "u");
//            WorkflowCollection.ActiveWorkflow = null;
//            
//            WHEN_SendingRegistration_as_Json(testClient);
//            
//            Xunit.Assert.Equal(workflow01.Id, ClientsCollection.Clients.First(client => client.Id == testClient.Id).WorkflowId);
//        }
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_register_test_client_only_in_the_active_workflow_if_there_is_any()
//        {
//            GIVEN_LoadedWorkflow(1, "w1");
//            var workflow02 = GIVEN_LoadedWorkflow(2, "w2");
//            WorkflowCollection.ActiveWorkflow = workflow02;
//            var testClient = GIVEN_TestClient("h", "u");
//            
//            WHEN_SendingRegistration_as_Json(testClient);
//            
//            Xunit.Assert.Equal(workflow02.Id, ClientsCollection.Clients.First(client => client.Id == testClient.Id).WorkflowId);
//        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_register_new_client_only_in_one_testRun_as_json()
        {
            var testRun = GIVEN_Active_TestRun();
            // the second active test run
            TestFactory.GetTestRunWithStatus(TestRunStatuses.Running);
            var testClient = GIVEN_TestClient(_testClientHostnameExpected01, _testClientUsernameExpected01);
            
            testClient = WHEN_SendingRegistration_as_Json(testClient);
            
            THEN_Http_Response_Is_Created();
            Xunit.Assert.Equal(1, ClientsCollection.Clients.Count);
            Xunit.Assert.Equal(testRun.Id, testClient.TestRunId);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_register_new_client_only_in_one_testRun_as_xml()
        {
            var testRun = GIVEN_Active_TestRun();
            // the second active test run
            TestFactory.GetTestRunWithStatus(TestRunStatuses.Running);
            var testClient = GIVEN_TestClient(_testClientHostnameExpected01, _testClientUsernameExpected01);
            
            testClient = WHEN_SendingRegistration_as_Xml(testClient as TestClient);
            
            THEN_Http_Response_Is_Created();
            Xunit.Assert.Equal(1, ClientsCollection.Clients.Count);
            Xunit.Assert.Equal(testRun.Id, testClient.TestRunId);
        }
        
        [MbUnit.Framework.Ignore][NUnit.Framework.Ignore]
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        public void Should_register_two_clients_in_separate_testRuns_as_json()
        {
            var testRun01 = GIVEN_Active_TestRun();
            var testRun02 = GIVEN_Active_TestRun();
            var testClient01 = GIVEN_TestClient(_testClientHostnameExpected01, _testClientUsernameExpected01);
            var testClient02 = GIVEN_TestClient("testhost_02", "aaa_02");
            
            testClient01 = WHEN_SendingRegistration_as_Json(testClient01);
            testClient02 = WHEN_SendingRegistration_as_Json(testClient02);
            
            THEN_Http_Response_Is_Created();
            Xunit.Assert.Equal(2, ClientsCollection.Clients.Count);
            Xunit.Assert.Equal(testRun01.Id, testClient01.TestRunId);
            Xunit.Assert.Equal(testRun02.Id, testClient02.TestRunId);
        }
        
        // ============================================= No active test runs =============================================================
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_not_register_a_test_client_if_there_are_no_active_testRuns_only_pending_as_json()
        {
            var testRun = GIVEN_Pending_TestRun();
            var testClient = GIVEN_TestClient(_testClientHostnameExpected01, _testClientUsernameExpected01);
            
            WHEN_SendingRegistration_as_Json(testClient);
            
            THEN_Http_Response_Is_ExpectationFailed();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_not_register_a_test_client_if_there_are_no_active_testRuns_only_scheduled_as_json()
        {
            var testRun = GIVEN_Scheduled_TestRun();
            var testClient = GIVEN_TestClient(_testClientHostnameExpected01, _testClientUsernameExpected01);
            
            WHEN_SendingRegistration_as_Json(testClient);
            
            THEN_Http_Response_Is_ExpectationFailed();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_not_register_a_test_client_if_there_are_no_active_testRuns_only_completed_as_json()
        {
            var testRun = GIVEN_Completed_TestRun();
            var testClient = GIVEN_TestClient(_testClientHostnameExpected01, _testClientUsernameExpected01);
            
            WHEN_SendingRegistration_as_Json(testClient);
            
            THEN_Http_Response_Is_ExpectationFailed();
        }
        
        // ============================================= Querying clients =============================================================
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_return_all_registered_clients_as_json()
        {
            var testRun = GIVEN_Active_TestRun();
            var testClient01 = GIVEN_SendingRegistration_as_Json(GIVEN_TestClient(_testClientHostnameExpected01, _testClientUsernameExpected01));
            var testClient02 = GIVEN_SendingRegistration_as_Json(GIVEN_TestClient(_testClientHostnameExpected02, _testClientUsernameExpected02));
            var testClient03 = GIVEN_SendingRegistration_as_Json(GIVEN_TestClient("testhost_03", "aaa_03"));
            
            var testClientCollection = WHEN_Getting_all_registered_clients_as_json();
            
            THEN_Http_Response_Is_Ok();
            Xunit.Assert.Equal(3, testClientCollection.Count);
        }
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_return_all_registered_clients_as_xml()
//        {
//            var testClient01 = GIVEN_SendingRegistration_as_Json(GIVEN_TestClient("testhost_01", "aaa_01"));
//            var testClient02 = GIVEN_SendingRegistration_as_Json(GIVEN_TestClient("testhost_02", "aaa_02"));
//            var testClient03 = GIVEN_SendingRegistration_as_Json(GIVEN_TestClient("testhost_03", "aaa_03"));
//            
//            var testClientCollection = WHEN_Getting_all_registered_clients_as_xml();
//            
//            THEN_Http_Response_Is_Ok();
//            Xunit.Assert.Equal(3, testClientCollection.Count);
//        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_return_NotFound_if_no_clients_registered_as_json()
        {
            ClientsCollection.Clients.Clear();
            
            var testClientCollection = WHEN_Getting_all_registered_clients_as_json();
            
            THEN_Http_Response_Is_NotFound();
            Xunit.Assert.Equal(null, testClientCollection);
        }
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_return_NotFound_if_no_clients_registered_as_xml()
//        {
//            ClientsCollection.Clients.Clear();
//            
//            var testClientCollection = WHEN_Getting_all_registered_clients_as_xml();
//            
//            THEN_Http_Response_Is_NotFound();
//            Xunit.Assert.Equal(null, testClientCollection);
//        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_return_registered_client_by_Id_as_json()
        {
            var testRun = GIVEN_Active_TestRun();
            var testClient01 = GIVEN_SendingRegistration_as_Json(GIVEN_TestClient(_testClientHostnameExpected01, _testClientUsernameExpected01));
            var testClient02 = GIVEN_SendingRegistration_as_Json(GIVEN_TestClient(_testClientHostnameExpected02, _testClientUsernameExpected02));
            var testClient03 = GIVEN_SendingRegistration_as_Json(GIVEN_TestClient(_testClientHostnameExpected03, _testClientUsernameExpected03));
            
            var testClientActual = WHEN_Getting_registered_client_by_Id_as_json(testClient02.Id);
            
            THEN_Http_Response_Is_Ok();
            THEN_Test_Client_Properties_Were_Applied(testClientActual, 1);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_return_registered_client_by_Id_as_xml()
        {
            var testRun = GIVEN_Active_TestRun();
            var testClient01 = GIVEN_SendingRegistration_as_Json(GIVEN_TestClient(_testClientHostnameExpected01, _testClientUsernameExpected01));
            var testClient02 = GIVEN_SendingRegistration_as_Json(GIVEN_TestClient(_testClientHostnameExpected02, _testClientUsernameExpected02));
            var testClient03 = GIVEN_SendingRegistration_as_Json(GIVEN_TestClient(_testClientHostnameExpected03, _testClientUsernameExpected03));
            
            var testClientActual = WHEN_Getting_registered_client_by_Id_as_xml(testClient02.Id);
            
            THEN_Http_Response_Is_Ok();
            THEN_Test_Client_Properties_Were_Applied(testClientActual, 1);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_return_NotFound_if_no_clients_registered_and_by_Id_as_json()
        {
            ClientsCollection.Clients.Clear();
            
            var testClientCollection = WHEN_Getting_registered_client_by_Id_as_json(Guid.NewGuid());
            
            THEN_Http_Response_Is_NotFound();
            Xunit.Assert.Equal(null, testClientCollection);
        }
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_return_NotFound_if_no_clients_registered_and_by_Id_as_xml()
//        {
//            ClientsCollection.Clients.Clear();
//            
//            var testClientCollection = WHEN_Getting_registered_client_by_Id_as_xml(2);
//            
//            THEN_Http_Response_Is_NotFound();
//            Xunit.Assert.Equal(null, testClientCollection);
//        }
        // ============================================================================================================================
        ITestClient GIVEN_TestClient(string hostname, string username) // , int testRunId)
        {
            return TestFactory.GivenTestClient(hostname, username); // , testRunId);
        }
        
        ITestRun GIVEN_Active_TestRun()
        {
            return getTestRunWithStatus(TestRunStatuses.Running);
        }
        
        ITestRun GIVEN_Pending_TestRun()
        {
            return getTestRunWithStatus(TestRunStatuses.Pending);
        }
        
        ITestRun GIVEN_Scheduled_TestRun()
        {
            return getTestRunWithStatus(TestRunStatuses.Scheduled);
        }
        
        ITestRun GIVEN_Completed_TestRun()
        {
            return getTestRunWithStatus(TestRunStatuses.CompletedSuccessfully);
        }

        ITestRun getTestRunWithStatus(TestRunStatuses status)
        {
            return TestFactory.GetTestRunWithStatus(status);
        }
        
        ITestClient GIVEN_SendingRegistration_as_Json(ITestClient testClient)
        {
            WHEN_SendingRegistration_as_Json(testClient);
            return _response.Body.DeserializeJson<TestClient>();
        }
        
        ITestClient GIVEN_SendingRegistration_as_Xml(TestClient testClient)
        {
            WHEN_SendingRegistration_as_Xml(testClient);
            return _response.Body.DeserializeXml<TestClient>();
        }
        
        IWorkflow GIVEN_LoadedWorkflow(int id, string name)
        {
            var workflow = new TestWorkflow(TestLabCollection.TestLabs.First()) { Name = name };
            WorkflowCollection.AddWorkflow(workflow);
            return workflow;
        }
        
        ITestClient WHEN_SendingRegistration_as_Json(ITestClient testClient)
        {
            _response = _browser.Post(UrlList.TestClientRegistrationPoint_absPath, with => {
                with.JsonBody<ITestClient>(testClient);
                with.Accept("application/json");
            });
            return _response.Body.DeserializeJson<TestClient>();
        }
        
        ITestClient WHEN_SendingRegistration_as_Xml(TestClient testClient)
        {
            _response = _browser.Post(UrlList.TestClientRegistrationPoint_absPath, with => {
                with.XMLBody<TestClient>(testClient);
                with.Accept("application/xml");
            });
            return _response.Body.DeserializeXml<TestClient>();
        }
        
        void WHEN_SendingDeregistration_as_json(ITestClient testClient)
        {
            _browser.Delete(UrlList.TestClients_Root + "/" + testClient.Id, with => with.Accept("application/json"));
        }
        
        void WHEN_SendingDeregistration_as_xml(ITestClient testClient)
        {
            _browser.Delete(UrlList.TestClients_Root + "/" + testClient.Id, with => with.Accept("application/xml"));
        }
        
        void WHEN_SendingStatus_as_json(Guid clientId, DetailedStatus detailedStatus)
        {
            _response = _browser.Put(UrlList.TestClients_Root + "/" + clientId + "/status", with => {
                with.JsonBody<DetailedStatus>(detailedStatus);
                with.Accept("application/json");
            });
        }
        
        void WHEN_SendingStatus_as_xml(Guid clientId, DetailedStatus detailedStatus)
        {
            _response = _browser.Put(UrlList.TestClients_Root + "/" + clientId + "/status", with => {
                with.JsonBody<DetailedStatus>(detailedStatus);
                with.Accept("application/xml");
            });
        }
        
        List<TestClient> WHEN_Getting_all_registered_clients_as_json()
        {
            _response = _browser.Get(UrlList.TestClients_Root + UrlList.TestClientRegistrationPoint_relPath, with => with.Accept("application/json"));
            return _response.Body.DeserializeJson<List<TestClient>>();
        }
        
        List<TestClient> WHEN_Getting_all_registered_clients_as_xml()
        {
            _response = _browser.Get(UrlList.TestClients_Root + UrlList.TestClientRegistrationPoint_relPath, with => with.Accept("application/xml"));
            return _response.Body.DeserializeJson<List<TestClient>>();
        }
        
        TestClient WHEN_Getting_registered_client_by_Id_as_json(Guid clientId)
        {
            _response = _browser.Get(UrlList.TestClients_Root + "/" + clientId, with => with.Accept("application/json"));
            return _response.Body.DeserializeJson<TestClient>();
        }
        
        TestClient WHEN_Getting_registered_client_by_Id_as_xml(Guid clientId)
        {
            _response = _browser.Get(UrlList.TestClients_Root + "/" + clientId, with => with.Accept("application/xml"));
            return _response.Body.DeserializeXml<TestClient>();
        }
        
        void THEN_There_Is_The_Number_Of_Registered_Clients(int number)
        {
            Xunit.Assert.Equal(number, ClientsCollection.Clients.Count);
        }
        
        void THEN_Id_Of_The_First_Client_Equals(Guid clientId)
        {
            int testClientCounter = ClientsCollection.Clients.Count - 1;
            Xunit.Assert.Equal(clientId, ClientsCollection.Clients[testClientCounter].Id);
        }
        
        void THEN_Http_Response_Is_Ok()
        {
            Xunit.Assert.Equal(HttpStatusCode.OK, _response.StatusCode);
        }
        
        void THEN_Http_Response_Is_Created()
        {
            Xunit.Assert.Equal(HttpStatusCode.Created, _response.StatusCode);
        }
        
        void THEN_Http_Response_Is_NotFound()
        {
            Xunit.Assert.Equal(HttpStatusCode.NotFound, _response.StatusCode);
        }
        
        void THEN_Http_Response_Is_ExpectationFailed()
        {
            Xunit.Assert.Equal(HttpStatusCode.ExpectationFailed, _response.StatusCode);
        }
        
        void THEN_Test_Client_Properties_Were_Applied(ISystemInfo testClient)
        {
            int testClientNumber = ClientsCollection.Clients.Count - 1;
            THEN_Test_Client_Properties_Were_Applied(testClient, testClientNumber);
        }
        
        void THEN_Test_Client_Properties_Were_Applied(ISystemInfo testClient, int testClientNumber)
        {
            Xunit.Assert.Equal(testClient.CustomString, ClientsCollection.Clients[testClientNumber].CustomString);
            Xunit.Assert.Equal(testClient.EnvironmentVersion, ClientsCollection.Clients[testClientNumber].EnvironmentVersion);
            Xunit.Assert.Equal(testClient.Fqdn, ClientsCollection.Clients[testClientNumber].Fqdn);
            Xunit.Assert.Equal(testClient.Hostname, ClientsCollection.Clients[testClientNumber].Hostname);
            Xunit.Assert.Equal(testClient.IsAdmin, ClientsCollection.Clients[testClientNumber].IsAdmin);
            Xunit.Assert.Equal(testClient.IsInteractive, ClientsCollection.Clients[testClientNumber].IsInteractive);
            Xunit.Assert.Equal(testClient.Language, ClientsCollection.Clients[testClientNumber].Language);
            // Xunit.Assert.Equal(testClient.OsEdition, ClientsCollection.Clients[testClientCounter].OsEdition);
            // Xunit.Assert.Equal(testClient.OsName, ClientsCollection.Clients[testClientCounter].OsName);
            Xunit.Assert.Equal(testClient.OsVersion, ClientsCollection.Clients[testClientNumber].OsVersion);
            Xunit.Assert.Equal(testClient.UptimeSeconds, ClientsCollection.Clients[testClientNumber].UptimeSeconds);
            Xunit.Assert.Equal(testClient.UserDomainName, ClientsCollection.Clients[testClientNumber].UserDomainName);
            Xunit.Assert.Equal(testClient.Username, ClientsCollection.Clients[testClientNumber].Username);
        }
        
        // TODO: duplicated
        void THEN_test_client_is_busy(ITestClient testClient)
        {
            Xunit.Assert.Equal(TestClientStatuses.Running, testClient.Status);
        }
        
        void THEN_test_client_is_free(ITestClient testClient)
        {
            Xunit.Assert.Equal(TestClientStatuses.NoTasks, testClient.Status);
        }
    }
}
