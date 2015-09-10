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
        const string TestClientHostnameExpected01 = "testhost_01";
        const string TestClientUsernameExpected01 = "aaa_01";
        const string TestClientHostnameExpected02 = "testhost_002";
        const string TestClientUsernameExpected02 = "aaa_002";
        const string TestClientHostnameExpected03 = "testhost_03";
        const string TestClientUsernameExpected03 = "aaa_03";
        const string TheCurrentDetailedStatus = "the current status";
        const string TheLastDetailedStatus = "the latest status";
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
        public void ShouldRegisterTheFirstTestClientAsJson()
        {
            GivenActiveTestRun();
            var testClient = GivenTestClient(TestClientHostnameExpected01, TestClientUsernameExpected01);
            
            WhenSendingRegistrationAsJson(testClient);
            
            ThenHttpResponseIsCreated();
            ThenTestClientPropertiesWereApplied(testClient);
            ThenIdOfTheFirstClientEquals(_response.Body.DeserializeJson<TestClient>().Id);
            ThenTestClientIsFree(testClient);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldRegisterTheFirstTestClientAsXml()
        {
            GivenActiveTestRun();
            var testClient = GivenTestClient(TestClientHostnameExpected01, TestClientUsernameExpected01);
            
            WhenSendingRegistrationAsXml(testClient as TestClient);
            
            ThenHttpResponseIsCreated();
            ThenTestClientPropertiesWereApplied(testClient);
            ThenIdOfTheFirstClientEquals(_response.Body.DeserializeXml<TestClient>().Id);
            ThenTestClientIsFree(testClient);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldRegisterTheSecondTestClientAsJson()
        {
            GivenActiveTestRun(TestClientHostnameExpected01, TestClientHostnameExpected02);
            GivenSendingRegistrationAsJson(GivenTestClient(TestClientHostnameExpected01, TestClientUsernameExpected01));
            var testClient02 = GivenTestClient(TestClientHostnameExpected02, TestClientUsernameExpected02);
            
            WhenSendingRegistrationAsJson(testClient02);
            
            ThenHttpResponseIsCreated();
            ThenTestClientPropertiesWereApplied(testClient02);
            ThenIdOfTheFirstClientEquals(_response.Body.DeserializeJson<TestClient>().Id);
            ThenTestClientIsFree(testClient02);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldRegisterTheSecondTestClientAsXml()
        {
            GivenActiveTestRun(TestClientHostnameExpected01, TestClientHostnameExpected02);
            GivenSendingRegistrationAsXml(GivenTestClient(TestClientHostnameExpected01, TestClientUsernameExpected01) as TestClient);
            var testClient02 = GivenTestClient(TestClientHostnameExpected02, TestClientUsernameExpected02) as TestClient;
            
            WhenSendingRegistrationAsXml(testClient02);
            
            ThenHttpResponseIsCreated();
            ThenTestClientPropertiesWereApplied(testClient02);
            ThenIdOfTheFirstClientEquals(_response.Body.DeserializeXml<TestClient>().Id);
            ThenTestClientIsFree(testClient02);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldBeNoClientsAfterUnregisteringTheOnlyTestClientAsJson()
        {
            GivenActiveTestRun(TestClientHostnameExpected02);
            var testClient = GivenSendingRegistrationAsJson(GivenTestClient(TestClientHostnameExpected02, TestClientUsernameExpected02));
            
            WhenSendingDeregistrationAsJson(testClient);
            
            ThenThereIsTheNumberOfRegisteredClients(0);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldBeNoClientsAfterUnregisteringTheOnlyTestClientAsXml()
        {
            GivenActiveTestRun(TestClientHostnameExpected02);
            var testClient = GivenSendingRegistrationAsXml(GivenTestClient(TestClientHostnameExpected02, TestClientUsernameExpected02) as TestClient);
            
            WhenSendingDeregistrationAsJson(testClient);
            
            ThenThereIsTheNumberOfRegisteredClients(0);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldBeOnlyOneClientAfterUnregisteringOneOfTwoTestClientsAsJson()
        {
            GivenActiveTestRun(TestClientHostnameExpected01, TestClientHostnameExpected02);
            var testClient01 = GivenSendingRegistrationAsJson(GivenTestClient(TestClientHostnameExpected01, TestClientUsernameExpected01));
            var testClient02 = GivenSendingRegistrationAsJson(GivenTestClient(TestClientHostnameExpected02, TestClientUsernameExpected02));
            
            WhenSendingDeregistrationAsJson(testClient01);
            
            ThenThereIsTheNumberOfRegisteredClients(1);
            ThenIdOfTheFirstClientEquals(testClient02.Id);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldBeOnlyOneClientAfterUnregisteringOneOfTwoTestClientsAsXml()
        {
            GivenActiveTestRun(TestClientHostnameExpected01, TestClientHostnameExpected02);
            var testClient01 = GivenSendingRegistrationAsXml(GivenTestClient(TestClientHostnameExpected01, TestClientUsernameExpected01) as TestClient);
            var testClient02 = GivenSendingRegistrationAsXml(GivenTestClient(TestClientHostnameExpected02, TestClientUsernameExpected02) as TestClient);
            
            WhenSendingDeregistrationAsXml(testClient01);
            
            ThenThereIsTheNumberOfRegisteredClients(1);
            ThenIdOfTheFirstClientEquals(testClient02.Id);
        }
        
        // ============================================= Detailed status ==============================================================
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldSetTestClientFirstStatusAsJson()
        {
            GivenActiveTestRun(TestClientHostnameExpected01);
            var testClient01 = GivenSendingRegistrationAsJson(GivenTestClient(TestClientHostnameExpected01, TestClientUsernameExpected01));
            
            WhenSendingStatusAsJson(testClient01.Id, new DetailedStatus(TheCurrentDetailedStatus));
            
            ThenThereIsTheNumberOfRegisteredClients(1); // ??
            Assert.Equal(TheCurrentDetailedStatus, ClientsCollection.Clients.First(client => client.Id == testClient01.Id).DetailedStatus);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldSetTestClientFirstStatusAsXml()
        {
            GivenActiveTestRun();
            var testClient01 = GivenSendingRegistrationAsXml(GivenTestClient(TestClientHostnameExpected01, TestClientUsernameExpected01) as TestClient);
            
            WhenSendingStatusAsXml(testClient01.Id, new DetailedStatus(TheCurrentDetailedStatus));
            
            ThenThereIsTheNumberOfRegisteredClients(1); // ??
            Assert.Equal(TheCurrentDetailedStatus, ClientsCollection.Clients.First(client => client.Id == testClient01.Id).DetailedStatus);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldSetTestClientSecondStatusAsJson()
        {
            GivenActiveTestRun();
            var testClient01 = GivenSendingRegistrationAsJson(GivenTestClient(TestClientHostnameExpected01, TestClientUsernameExpected01));
            
            WhenSendingStatusAsJson(testClient01.Id, new DetailedStatus(TheCurrentDetailedStatus));
            WhenSendingStatusAsJson(testClient01.Id, new DetailedStatus(TheLastDetailedStatus));
            
            ThenThereIsTheNumberOfRegisteredClients(1); // ??
            Assert.Equal(TheLastDetailedStatus, ClientsCollection.Clients.First(client => client.Id == testClient01.Id).DetailedStatus);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldSetTestClientSecondStatusAsXml()
        {
            GivenActiveTestRun();
            var testClient01 = GivenSendingRegistrationAsXml(GivenTestClient(TestClientHostnameExpected01, TestClientUsernameExpected01) as TestClient);
            
            WhenSendingStatusAsXml(testClient01.Id, new DetailedStatus(TheCurrentDetailedStatus));
            WhenSendingStatusAsXml(testClient01.Id, new DetailedStatus(TheLastDetailedStatus));
            
            ThenThereIsTheNumberOfRegisteredClients(1); // ??
            Assert.Equal(TheLastDetailedStatus, ClientsCollection.Clients.First(client => client.Id == testClient01.Id).DetailedStatus);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldSetTestClientEmptyStatusAsJson()
        {
            GivenActiveTestRun();
            var testClient01 = GivenSendingRegistrationAsJson(GivenTestClient(TestClientHostnameExpected01, TestClientUsernameExpected01));
            
            WhenSendingStatusAsJson(testClient01.Id, new DetailedStatus(TheCurrentDetailedStatus));
            WhenSendingStatusAsJson(testClient01.Id, new DetailedStatus(string.Empty));
            
            ThenThereIsTheNumberOfRegisteredClients(1); // ??
            Assert.Equal(string.Empty, ClientsCollection.Clients.First(client => client.Id == testClient01.Id).DetailedStatus);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldSetTestClientEmptyStatusAsXml()
        {
            GivenActiveTestRun();
            var testClient01 = GivenSendingRegistrationAsXml(GivenTestClient(TestClientHostnameExpected01, TestClientUsernameExpected01) as TestClient);
            
            WhenSendingStatusAsXml(testClient01.Id, new DetailedStatus(TheCurrentDetailedStatus));
            WhenSendingStatusAsXml(testClient01.Id, new DetailedStatus(string.Empty));
            
            ThenThereIsTheNumberOfRegisteredClients(1); // ??
            Assert.Equal(string.Empty, ClientsCollection.Clients.First(client => client.Id == testClient01.Id).DetailedStatus);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldNotSetTestClientStatusFromWrongClientIdAsJson()
        {
            GivenActiveTestRun();
            var testClient01 = GivenSendingRegistrationAsJson(GivenTestClient(TestClientHostnameExpected01, TestClientUsernameExpected01));
            
            WhenSendingStatusAsJson(testClient01.Id, new DetailedStatus(TheCurrentDetailedStatus));
            WhenSendingStatusAsJson(new Guid(), new DetailedStatus(TheLastDetailedStatus));
            
            ThenThereIsTheNumberOfRegisteredClients(1); // ??
            ThenHttpResponseIsNotFound();
            Assert.Equal(TheCurrentDetailedStatus, ClientsCollection.Clients.First(client => client.Id == testClient01.Id).DetailedStatus);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldNotSetTestClientStatusFromWrongClientIdAsXml()
        {
            GivenActiveTestRun();
            var testClient01 = GivenSendingRegistrationAsXml(GivenTestClient(TestClientHostnameExpected01, TestClientUsernameExpected01) as TestClient);
            
            WhenSendingStatusAsXml(testClient01.Id, new DetailedStatus(TheCurrentDetailedStatus));
            WhenSendingStatusAsXml(new Guid(), new DetailedStatus(TheLastDetailedStatus));
            
            ThenThereIsTheNumberOfRegisteredClients(1); // ??
            ThenHttpResponseIsNotFound();
            Assert.Equal(TheCurrentDetailedStatus, ClientsCollection.Clients.First(client => client.Id == testClient01.Id).DetailedStatus);
        }
        
        // cleaning up detailed status on finishing a task
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void ShouldSetTestClientSecondStatusAsJson()
//        {
//            const string detailedStatus01 = "the current status";
//            const string detailedStatus02 = "the latest status";
//            var testClient01 = GivenSendingRegistrationAsJson(GivenTestClient("testhost_03", "aaa_03"));
//            
//            WhenSendingStatusAsJson(testClient01.Id, new DetailedStatus(detailedStatus01));
//            WhenSendingStatusAsJson(testClient01.Id, new DetailedStatus(detailedStatus02));
//            
//            ThenThereIsTheNumberOfRegisteredClients(testClient01.Id);
//            Xunit.Assert.Equal(detailedStatus02, ClientsCollection.Clients.First(client => client.Id == testClient01.Id).DetailedStatus);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void ShouldSetTestClientSecondStatusAsXml()
//        {
//            const string detailedStatus01 = "the current status";
//            const string detailedStatus02 = "the latest status";
//            var testClient01 = GivenSendingRegistrationAsXml(GivenTestClient("testhost_03", "aaa_03") as TestClient);
//            
//            WhenSendingStatusAsXml(testClient01.Id, new DetailedStatus(detailedStatus01));
//            WhenSendingStatusAsXml(testClient01.Id, new DetailedStatus(detailedStatus02));
//            
//            ThenThereIsTheNumberOfRegisteredClients(testClient01.Id);
//            Xunit.Assert.Equal(detailedStatus02, ClientsCollection.Clients.First(client => client.Id == testClient01.Id).DetailedStatus);
//        }
        
        
        
        
        // ============================================= Multi-workflow =============================================================
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_register_test_client_only_in_the_first_workflow_if_there_is_no_active_workflow()
//        {
//            var workflow01 = GivenLoadedWorkflow(1, "w1");
//            GivenLoadedWorkflow(2, "w2");
//            var testClient = GivenTestClient("h", "u");
//            WorkflowCollection.ActiveWorkflow = null;
//            
//            WhenSendingRegistrationAsJson(testClient);
//            
//            Xunit.Assert.Equal(workflow01.Id, ClientsCollection.Clients.First(client => client.Id == testClient.Id).WorkflowId);
//        }
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_register_test_client_only_in_the_active_workflow_if_there_is_any()
//        {
//            GivenLoadedWorkflow(1, "w1");
//            var workflow02 = GivenLoadedWorkflow(2, "w2");
//            WorkflowCollection.ActiveWorkflow = workflow02;
//            var testClient = GivenTestClient("h", "u");
//            
//            WhenSendingRegistrationAsJson(testClient);
//            
//            Xunit.Assert.Equal(workflow02.Id, ClientsCollection.Clients.First(client => client.Id == testClient.Id).WorkflowId);
//        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldRegisterNewClientOnlyInOneTestRunAsJson()
        {
            var testRun = GivenActiveTestRun();
            // the second active test run
            TestFactory.GetTestRunWithStatus(TestRunStatuses.Running);
            var testClient = GivenTestClient(TestClientHostnameExpected01, TestClientUsernameExpected01);
            
            testClient = WhenSendingRegistrationAsJson(testClient);
            
            ThenHttpResponseIsCreated();
            Assert.Equal(1, ClientsCollection.Clients.Count);
            Assert.Equal(testRun.Id, testClient.TestRunId);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldRegisterNewClientOnlyInOneTestRunAsXml()
        {
            var testRun = GivenActiveTestRun();
            // the second active test run
            TestFactory.GetTestRunWithStatus(TestRunStatuses.Running);
            var testClient = GivenTestClient(TestClientHostnameExpected01, TestClientUsernameExpected01);
            
            testClient = WhenSendingRegistrationAsXml(testClient as TestClient);
            
            ThenHttpResponseIsCreated();
            Assert.Equal(1, ClientsCollection.Clients.Count);
            Assert.Equal(testRun.Id, testClient.TestRunId);
        }
        
        [MbUnit.Framework.Ignore][NUnit.Framework.Ignore]
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        public void ShouldRegisterTwoClientsInSeparateTestRunsAsJson()
        {
            var testRun01 = GivenActiveTestRun();
            var testRun02 = GivenActiveTestRun();
            var testClient01 = GivenTestClient(TestClientHostnameExpected01, TestClientUsernameExpected01);
            var testClient02 = GivenTestClient("testhost_02", "aaa_02");
            
            testClient01 = WhenSendingRegistrationAsJson(testClient01);
            testClient02 = WhenSendingRegistrationAsJson(testClient02);
            
            ThenHttpResponseIsCreated();
            Assert.Equal(2, ClientsCollection.Clients.Count);
            Assert.Equal(testRun01.Id, testClient01.TestRunId);
            Assert.Equal(testRun02.Id, testClient02.TestRunId);
        }
        
        // ============================================= No active test runs =============================================================
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldNotRegisterATestClientIfThereAreNoActiveTestRunsOnlyPendingAsJson()
        {
            GivenPendingTestRun();
            var testClient = GivenTestClient(TestClientHostnameExpected01, TestClientUsernameExpected01);
            
            WhenSendingRegistrationAsJson(testClient);
            
            ThenHttpResponseIsExpectationFailed();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldNotRegisterATestClientIfThereAreNoActiveTestRunsOnlyScheduledAsJson()
        {
            GivenScheduledTestRun();
            var testClient = GivenTestClient(TestClientHostnameExpected01, TestClientUsernameExpected01);
            
            WhenSendingRegistrationAsJson(testClient);
            
            ThenHttpResponseIsExpectationFailed();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldNotRegisterATestClientIfThereAreNoActiveTestRunsOnlyCompletedAsJson()
        {
            GivenCompletedTestRun();
            var testClient = GivenTestClient(TestClientHostnameExpected01, TestClientUsernameExpected01);
            
            WhenSendingRegistrationAsJson(testClient);
            
            ThenHttpResponseIsExpectationFailed();
        }
        
        // ============================================= Querying clients =============================================================
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldReturnAllRegisteredClientsAsJson()
        {
            GivenActiveTestRun(TestClientHostnameExpected01, TestClientHostnameExpected02, TestClientHostnameExpected03);
            GivenSendingRegistrationAsJson(GivenTestClient(TestClientHostnameExpected01, TestClientUsernameExpected01));
            GivenSendingRegistrationAsJson(GivenTestClient(TestClientHostnameExpected02, TestClientUsernameExpected02));
            GivenSendingRegistrationAsJson(GivenTestClient(TestClientHostnameExpected03, TestClientUsernameExpected03));
            
            var testClientCollection = WhenGettingAllRegisteredClientsAsJson();
            
            ThenHttpResponseIsOk();
            Assert.Equal(3, testClientCollection.Count);
        }
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_return_all_registered_clients_as_xml()
//        {
//            var testClient01 = GivenSendingRegistrationAsJson(GivenTestClient("testhost_01", "aaa_01"));
//            var testClient02 = GivenSendingRegistrationAsJson(GivenTestClient("testhost_02", "aaa_02"));
//            var testClient03 = GivenSendingRegistrationAsJson(GivenTestClient("testhost_03", "aaa_03"));
//            
//            var testClientCollection = WhenGettingAllRegisteredClientsAsXml();
//            
//            ThenHttpResponseIsOk();
//            Xunit.Assert.Equal(3, testClientCollection.Count);
//        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldReturnNotFoundIfNoClientsRegisteredAsJson()
        {
            ClientsCollection.Clients.Clear();
            
            var testClientCollection = WhenGettingAllRegisteredClientsAsJson();
            
            ThenHttpResponseIsNotFound();
            Assert.Equal(null, testClientCollection);
        }
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_return_NotFound_if_no_clients_registered_as_xml()
//        {
//            ClientsCollection.Clients.Clear();
//            
//            var testClientCollection = WhenGettingAllRegisteredClientsAsXml();
//            
//            ThenHttpResponseIsNotFound();
//            Xunit.Assert.Equal(null, testClientCollection);
//        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldReturnRegisteredClientByIdAsJson()
        {
            GivenActiveTestRun(TestClientHostnameExpected01,TestClientHostnameExpected02, TestClientHostnameExpected03);
            GivenSendingRegistrationAsJson(GivenTestClient(TestClientHostnameExpected01, TestClientUsernameExpected01));
            var testClient02 = GivenSendingRegistrationAsJson(GivenTestClient(TestClientHostnameExpected02, TestClientUsernameExpected02));
            GivenSendingRegistrationAsJson(GivenTestClient(TestClientHostnameExpected03, TestClientUsernameExpected03));
            
            var testClientActual = WhenGettingRegisteredClientByIdAsJson(testClient02.Id);
            
            ThenHttpResponseIsOk();
            ThenTestClientPropertiesWereApplied(testClientActual, 1);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldReturnRegisteredClientByIdAsXml()
        {
            GivenActiveTestRun(TestClientHostnameExpected01, TestClientHostnameExpected02, TestClientHostnameExpected03);
            GivenSendingRegistrationAsJson(GivenTestClient(TestClientHostnameExpected01, TestClientUsernameExpected01));
            var testClient02 = GivenSendingRegistrationAsJson(GivenTestClient(TestClientHostnameExpected02, TestClientUsernameExpected02));
            GivenSendingRegistrationAsJson(GivenTestClient(TestClientHostnameExpected03, TestClientUsernameExpected03));
            
            var testClientActual = WhenGettingRegisteredClientByIdAsXml(testClient02.Id);
            
            ThenHttpResponseIsOk();
            ThenTestClientPropertiesWereApplied(testClientActual, 1);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldReturnNotFoundIfNoClientsRegisteredAndByIdAsJson()
        {
            ClientsCollection.Clients.Clear();
            
            var testClientCollection = WhenGettingRegisteredClientByIdAsJson(Guid.NewGuid());
            
            ThenHttpResponseIsNotFound();
            Assert.Equal(null, testClientCollection);
        }
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_return_NotFound_if_no_clients_registered_and_by_Id_as_xml()
//        {
//            ClientsCollection.Clients.Clear();
//            
//            var testClientCollection = WhenGettingRegisteredClientByIdAsXml(2);
//            
//            ThenHttpResponseIsNotFound();
//            Xunit.Assert.Equal(null, testClientCollection);
//        }
        // ============================================================================================================================
        ITestClient GivenTestClient(string hostname, string username) // , int testRunId)
        {
            return TestFactory.GivenTestClient(hostname, username); // , testRunId);
        }
        
        ITestRun GivenActiveTestRun()
        {
            return GivenActiveTestRun("aaa_01");
        }
        
        ITestRun GivenActiveTestRun(params string[] rules)
        {
            return getTestRunWithStatus(TestRunStatuses.Running, rules);
        }
        
        ITestRun GivenPendingTestRun()
        {
            return getTestRunWithStatus(TestRunStatuses.Pending);
        }
        
        ITestRun GivenScheduledTestRun()
        {
            return getTestRunWithStatus(TestRunStatuses.Scheduled);
        }
        
        ITestRun GivenCompletedTestRun()
        {
            return getTestRunWithStatus(TestRunStatuses.Finished);
        }
        
        ITestRun getTestRunWithStatus(TestRunStatuses status)
        {
            return getTestRunWithStatus(status, "aaa_01");
        }
        
        ITestRun getTestRunWithStatus(TestRunStatuses status, params string[] rules)
        {
            return TestFactory.GetTestRunWithStatus(status, rules);
        }
        
        ITestClient GivenSendingRegistrationAsJson(ITestClient testClient)
        {
            WhenSendingRegistrationAsJson(testClient);
            return _response.Body.DeserializeJson<TestClient>();
        }
        
        ITestClient GivenSendingRegistrationAsXml(TestClient testClient)
        {
            WhenSendingRegistrationAsXml(testClient);
            return _response.Body.DeserializeXml<TestClient>();
        }
        
        IWorkflow GivenLoadedWorkflow(int id, string name)
        {
            var workflow = new TestWorkflow(TestLabCollection.TestLabs.First()) { Name = name };
            WorkflowCollection.AddWorkflow(workflow);
            return workflow;
        }
        
        ITestClient WhenSendingRegistrationAsJson(ITestClient testClient)
        {
            _response = _browser.Post(UrlList.TestClientRegistrationPoint_absPath, with => {
                with.JsonBody(testClient);
                with.Accept("application/json");
            });
            return _response.Body.DeserializeJson<TestClient>();
        }
        
        ITestClient WhenSendingRegistrationAsXml(TestClient testClient)
        {
            _response = _browser.Post(UrlList.TestClientRegistrationPoint_absPath, with => {
                with.XMLBody(testClient);
                with.Accept("application/xml");
            });
            return _response.Body.DeserializeXml<TestClient>();
        }
        
        void WhenSendingDeregistrationAsJson(ITestClient testClient)
        {
            _browser.Delete(UrlList.TestClients_Root + "/" + testClient.Id, with => with.Accept("application/json"));
        }
        
        void WhenSendingDeregistrationAsXml(ITestClient testClient)
        {
            _browser.Delete(UrlList.TestClients_Root + "/" + testClient.Id, with => with.Accept("application/xml"));
        }
        
        void WhenSendingStatusAsJson(Guid clientId, DetailedStatus detailedStatus)
        {
            _response = _browser.Put(UrlList.TestClients_Root + "/" + clientId + "/status", with => {
                with.JsonBody(detailedStatus);
                with.Accept("application/json");
            });
        }
        
        void WhenSendingStatusAsXml(Guid clientId, DetailedStatus detailedStatus)
        {
            _response = _browser.Put(UrlList.TestClients_Root + "/" + clientId + "/status", with => {
                with.JsonBody(detailedStatus);
                with.Accept("application/xml");
            });
        }
        
        List<TestClient> WhenGettingAllRegisteredClientsAsJson()
        {
            _response = _browser.Get(UrlList.TestClients_Root + UrlList.TestClientRegistrationPoint_relPath, with => with.Accept("application/json"));
            return _response.Body.DeserializeJson<List<TestClient>>();
        }
        
        List<TestClient> WhenGettingAllRegisteredClientsAsXml()
        {
            _response = _browser.Get(UrlList.TestClients_Root + UrlList.TestClientRegistrationPoint_relPath, with => with.Accept("application/xml"));
            return _response.Body.DeserializeJson<List<TestClient>>();
        }
        
        TestClient WhenGettingRegisteredClientByIdAsJson(Guid clientId)
        {
            _response = _browser.Get(UrlList.TestClients_Root + "/" + clientId, with => with.Accept("application/json"));
            return _response.Body.DeserializeJson<TestClient>();
        }
        
        TestClient WhenGettingRegisteredClientByIdAsXml(Guid clientId)
        {
            _response = _browser.Get(UrlList.TestClients_Root + "/" + clientId, with => with.Accept("application/xml"));
            return _response.Body.DeserializeXml<TestClient>();
        }
        
        void ThenThereIsTheNumberOfRegisteredClients(int number)
        {
            Assert.Equal(number, ClientsCollection.Clients.Count);
        }
        
        void ThenIdOfTheFirstClientEquals(Guid clientId)
        {
            int testClientCounter = ClientsCollection.Clients.Count - 1;
            Assert.Equal(clientId, ClientsCollection.Clients[testClientCounter].Id);
        }
        
        void ThenHttpResponseIsOk()
        {
            Assert.Equal(HttpStatusCode.OK, _response.StatusCode);
        }
        
        void ThenHttpResponseIsCreated()
        {
            Assert.Equal(HttpStatusCode.Created, _response.StatusCode);
        }
        
        void ThenHttpResponseIsNotFound()
        {
            Assert.Equal(HttpStatusCode.NotFound, _response.StatusCode);
        }
        
        void ThenHttpResponseIsExpectationFailed()
        {
            Assert.Equal(HttpStatusCode.ExpectationFailed, _response.StatusCode);
        }
        
        void ThenTestClientPropertiesWereApplied(ISystemInfo testClient)
        {
            int testClientNumber = ClientsCollection.Clients.Count - 1;
            ThenTestClientPropertiesWereApplied(testClient, testClientNumber);
        }
        
        void ThenTestClientPropertiesWereApplied(ISystemInfo testClient, int testClientNumber)
        {
            Assert.Equal(testClient.CustomString, ClientsCollection.Clients[testClientNumber].CustomString);
            Assert.Equal(testClient.EnvironmentVersion, ClientsCollection.Clients[testClientNumber].EnvironmentVersion);
            Assert.Equal(testClient.Fqdn, ClientsCollection.Clients[testClientNumber].Fqdn);
            Assert.Equal(testClient.Hostname, ClientsCollection.Clients[testClientNumber].Hostname);
            Assert.Equal(testClient.IsAdmin, ClientsCollection.Clients[testClientNumber].IsAdmin);
            Assert.Equal(testClient.IsInteractive, ClientsCollection.Clients[testClientNumber].IsInteractive);
            Assert.Equal(testClient.Language, ClientsCollection.Clients[testClientNumber].Language);
            // Xunit.Assert.Equal(testClient.OsEdition, ClientsCollection.Clients[testClientCounter].OsEdition);
            // Xunit.Assert.Equal(testClient.OsName, ClientsCollection.Clients[testClientCounter].OsName);
            Assert.Equal(testClient.OsVersion, ClientsCollection.Clients[testClientNumber].OsVersion);
            Assert.Equal(testClient.UptimeSeconds, ClientsCollection.Clients[testClientNumber].UptimeSeconds);
            Assert.Equal(testClient.UserDomainName, ClientsCollection.Clients[testClientNumber].UserDomainName);
            Assert.Equal(testClient.Username, ClientsCollection.Clients[testClientNumber].Username);
        }
        
        // TODO: duplicated
        void ThenTestClientIsBusy(ITestClient testClient)
        {
            Assert.Equal(TestClientStatuses.Running, testClient.Status);
        }
        
        void ThenTestClientIsFree(ITestClient testClient)
        {
            Assert.Equal(TestClientStatuses.NoTasks, testClient.Status);
        }
    }
}
