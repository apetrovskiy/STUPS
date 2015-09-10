/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/22/2014
 * Time: 3:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Tests.Modules
{
    using System;
    using System.Linq;
    using Nancy;
    using Nancy.Testing;
    using Interfaces.Server;
    using Client;
    using Core;
    using Core.Types.Remoting;
    using Interfaces.Remoting;
    using Interfaces.TestStructure;
    using Logic.ObjectModel.Objects;
    using Xunit;
    using UnitTestingHelpers;
    using Xunit.Extensions;
    
    /// <summary>
    /// Description of TestTasksModuleTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class TestTasksModuleTestFixture
    {
        const string TestClientHostnameExpected = "testhost";
        const string TestClientUsernameExpected = "aaa";
        const string TestClientHostnameAlternateExpected = "client02";
        ITestWorkflow _workflow;
        ITestRun _testRun;
        BrowserResponse _response;
        Browser _browser;
        DateTime _startTime;
        
        public TestTasksModuleTestFixture()
        {
            TestSettings.PrepareModuleTests();
            _browser = TestFactory.GetBrowserForTestTasksModule();
            TestFactory.GetTestRunWithStatus(TestRunStatuses.Running);
            _workflow = WorkflowCollection.Workflows.First();
            _testRun = TestRunQueue.TestRuns.First();
            TestFactory.GetAnotherTestRunWithStatus(TestRunStatuses.Pending, _workflow);
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            TestSettings.PrepareModuleTests();
            _browser = TestFactory.GetBrowserForTestTasksModule();
            TestFactory.GetTestRunWithStatus(TestRunStatuses.Running);
            _workflow = WorkflowCollection.Workflows.First();
            _testRun = TestRunQueue.TestRuns.First();
            TestFactory.GetAnotherTestRunWithStatus(TestRunStatuses.Pending, _workflow);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldProvideATaskToTestClientIfTheClientMatchesTheRule()
        {
            var expectedTask = GivenLoadedTestTask(5, "task name", false, TestTaskStatuses.New, true, TestClientHostnameExpected, 0);
            var testClient = GivenRegisteredTestClientAsJson(TestClientHostnameExpected, TestClientUsernameExpected);
            
            var actualTask = WhenGettingTaskAsJson(testClient.Id);
            
            ThenHttpResponseIsOk();
            ThenTestTaskPropertiesEqualTo(expectedTask, actualTask, TestTaskStatuses.Running);
            ThenTestClientIsBusy(ClientsCollection.Clients.First(client => client.Id == testClient.Id));
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        // public void Should_provide_no_task_to_test_client_if_the_client_does_not_match_the_rule()
        public void ShouldNotRegisterTestClientIfTheClientDoesNotMatchTheRule()
        {
            // TODO: rewrite as Given-When-Then
            GivenLoadedTestTask(5, "task name", false, TestTaskStatuses.New, true, "no matches", 0);
            var testClient = GivenRegisteredTestClientAsJson(TestClientHostnameExpected, TestClientUsernameExpected);
            
            ThenTestClientIsNotRegistered(testClient);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldProvideTheSecondTaskIfTheClientMatchesTheRule()
        {
            GivenLoadedTestTask(1, "task name", false, TestTaskStatuses.New, true, ".*h.*", 0);
            var givenTask02 = GivenLoadedTestTask(2, "task name 02", false, TestTaskStatuses.New, true, "u", 0);
            var registeredClient = GivenRegisteredTestClientAsJson("h", "u");
            
            var actualTask = WhenGettingTaskAsJson(registeredClient.Id);
            WhenFinishingTaskAsJson(actualTask);
            actualTask = WhenGettingTaskAsJson(registeredClient.Id);
            
            ThenHttpResponseIsOk();
            ThenTestTaskPropertiesEqualTo(givenTask02, actualTask, TestTaskStatuses.Running);
            ThenTestClientIsBusy(ClientsCollection.Clients.First(client => client.Id == registeredClient.Id));
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldNotProvideTheSecondTaskIfTheClientDoesNotMatchTheRule()
        {
            GivenLoadedTestTask(1, "task name", false, TestTaskStatuses.New, true, ".*h.*", 0);
            GivenLoadedTestTask(2, "task name 02", false, TestTaskStatuses.New, true, "aaa", 0);
            var registeredClient = GivenRegisteredTestClientAsJson("h", "u");
            
            var actualTask = WhenGettingTaskAsJson(registeredClient.Id);
            WhenFinishingTaskAsJson(actualTask);
            WhenGettingTaskAsJson(registeredClient.Id);
            
            ThenHttpResponseIsNotFound();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldProvideTheSecondTaskIfTheClientMatchesTheRuleAndThereAreSeveralTasks()
        {
            GivenLoadedTestTask(1, "task name", false, TestTaskStatuses.New, true, ".*h.*", 0);
            GivenLoadedTestTask(2, "task name", false, TestTaskStatuses.New, true, ".*aaa.*", 0);
            var givenTask03 = GivenLoadedTestTask(3, "task name 02", false, TestTaskStatuses.New, true, "u", 0);
            GivenLoadedTestTask(4, "task name", false, TestTaskStatuses.New, true, ".*aaa.*", 0);
            var registeredClient = GivenRegisteredTestClientAsJson("h", "u");
            
            var actualTask = WhenGettingTaskAsJson(registeredClient.Id);
            WhenFinishingTaskAsJson(actualTask);
            actualTask = WhenGettingTaskAsJson(registeredClient.Id);
            
            ThenHttpResponseIsOk();
            ThenTestTaskPropertiesEqualTo(givenTask03, actualTask, TestTaskStatuses.Running);
            Assert.Equal(givenTask03.Id, TaskPool.TasksForClients.OrderBy(t => t.Id).Skip(1).First().Id);
            ThenTestClientIsBusy(ClientsCollection.Clients.First(client => client.Id == registeredClient.Id));
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldNotProvideTheSecondTaskIfTheClientDoesNotMatchTheRuleAndThereAreSeveral()
        {
            GivenLoadedTestTask(1, "task name", false, TestTaskStatuses.New, true, ".*h.*", 0);
            GivenLoadedTestTask(2, "task name", false, TestTaskStatuses.New, true, ".*aaa.*", 0);
            GivenLoadedTestTask(3, "task name 02", false, TestTaskStatuses.New, true, "aaa", 0);
            GivenLoadedTestTask(4, "task name 02", false, TestTaskStatuses.New, true, "aaa", 0);
            var registeredClient = GivenRegisteredTestClientAsJson("h", "u");
            
            var task = WhenGettingTaskAsJson(registeredClient.Id);
            WhenFinishingTaskAsJson(task);
            WhenGettingTaskAsJson(registeredClient.Id);
            
            ThenHttpResponseIsNotFound();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldCancelAllFurtherTasksAndUnregisterClientsOnFail()
        {
            GivenLoadedTestTask(1, "task name", false, TestTaskStatuses.New, true, ".*h.*", 0);
            GivenLoadedTestTask(2, "task name", false, TestTaskStatuses.New, true, ".*aaa.*", 0);
            var givenTask03 = GivenLoadedTestTask(3, "task name 02", false, TestTaskStatuses.New, true, "u", 0);
            GivenLoadedTestTask(4, "task name", false, TestTaskStatuses.New, true, ".*aaa.*", 0);
            GivenLoadedTestTask(5, "task name", false, TestTaskStatuses.New, true, "h", 0);
            var registeredClient = GivenRegisteredTestClientAsJson("h", "u");
            
            var actualTask = WhenGettingTaskAsJson(registeredClient.Id);
            var taskId01 = actualTask.Id;
            WhenFailingTaskAsJson(actualTask);
            actualTask = WhenGettingTaskAsJson(registeredClient.Id);
            // var taskId02 = actualTask.Id;
            
            // 20150807
            // ThenHttpResponseIsNotFound();
            // 20150909
            // ThenHttpResponseIsExpectationFailed();
            ThenHttpResponseIsNotFound(); // as there's no more client
            Assert.Equal(null, actualTask);
            Assert.Equal(0, TaskPool.TasksForClients.Count(task => !task.IsFailed() && !task.IsCanceled()));
            Assert.Equal(givenTask03.Id, TaskPool.TasksForClients.OrderBy(t => t.Id).Skip(1).First().Id);
            ThenTestRunIsCompleted();
            // ThenTestRunClientsUnregistered(actualTask.Id);
            ThenTestRunClientsUnregistered(taskId01);
        }
        
        // 20150907
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldCancelAllFurtherTasksAndUnregisterClientsOnTestResultsFailed()
        {
            GivenLoadedTestTask(1, "task name", false, TestTaskStatuses.New, true, ".*h.*", 0);
            // givenTask01.IsCritical = true;
            TaskPool.Tasks[0].IsCritical = true;
            GivenLoadedTestTask(2, "task name", false, TestTaskStatuses.New, true, ".*aaa.*", 0);
            var givenTask03 = GivenLoadedTestTask(3, "task name 02", false, TestTaskStatuses.New, true, "u", 0);
            GivenLoadedTestTask(4, "task name", false, TestTaskStatuses.New, true, ".*aaa.*", 0);
            GivenLoadedTestTask(5, "task name", false, TestTaskStatuses.New, true, "h", 0);
            var registeredClient = GivenRegisteredTestClientAsJson("h", "u");
            
            var actualTask = WhenGettingTaskAsJson(registeredClient.Id);
            var taskId01 = actualTask.Id;
            
            // 20150908
            actualTask.IsCritical = true;
            
            WhenFailingTestResultsForTaskAsJson(actualTask);
            actualTask = WhenGettingTaskAsJson(registeredClient.Id);
            // var taskId02 = actualTask.Id;
            
            // 20150807
            // ThenHttpResponseIsNotFound();
            // 20150909
            // ThenHttpResponseIsExpectationFailed();
            ThenHttpResponseIsNotFound(); // as there's no more client
            Assert.Equal(null, actualTask);
            Assert.Equal(0, TaskPool.TasksForClients.Count(task => !task.IsFailed() && !task.IsCanceled()));
            Assert.Equal(givenTask03.Id, TaskPool.TasksForClients.OrderBy(t => t.Id).Skip(1).First().Id);
            ThenTestRunIsCompleted();
            // ThenTestRunClientsUnregistered(actualTask.Id);
            ThenTestRunClientsUnregistered(taskId01);
        }
        
//[NUnit.Framework.Test, TestCaseSource("DivideCases")]
//public void DivideTest(int n, int d, int q)
//{
//    NUnit.Framework.Assert.AreEqual( q, n / d );
//}
//
//static object[] DivideCases =
//{
//    new object[] { 12, 3, 4 },
//    new object[] { 12, 5, 6 },
//    new object[] { 12, 2, 6 },
//    new object[] { 12, 4, 3 } 
//};
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] // [Fact]
        [Theory]
        [InlineData("testHost001", "user001")]
        [InlineData("testHost002", "user002")]
        [InlineData("testHost003", "user003")]
//        [TestCase("testHost001", "user000")]
//        [TestCase("testHost002", "user002")]
//        [TestCase("testHost003", "user003")]
        // public void ShouldNotProvideATaskBeforeTaskThisDependsOnIsCompleted() //string hostname, string username)
        public void ShouldNotProvideATaskBeforeTaskThisDependsOnIsCompleted<T1, T2>(T1 hostname, T2 username)
        {
            var testClientHostnameExpected = hostname.ToString();
            var testClientUsernameExpected = username.ToString();
//            if ("user003" == username.ToString())
//                // Xunit.Assert.Equal(1, 2);
//                NUnit.Framework.Assert.AreEqual(1, 2);
//            else
//                NUnit.Framework.Assert.AreEqual(2, 3);
            
            GivenLoadedTestTask(4, "task name", false, TestTaskStatuses.New, true, "another rule", 0);
            GivenLoadedTestTask(5, "task name", false, TestTaskStatuses.New, true, testClientHostnameExpected, 4);
            var registeredClient = GivenRegisteredTestClientAsJson(testClientHostnameExpected, testClientUsernameExpected);
            
            var actualTask = WhenGettingTaskAsJson(registeredClient.Id);
            
            ThenTestTaskIsNull(actualTask);
            ThenTestClientIsFree(registeredClient);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldNotProvideATaskBeforeTaskThisDependsOnIsAllocated()
        {
            GivenLoadedTestTask(5, "task name", false, TestTaskStatuses.New, true, TestClientHostnameExpected, 4);
            var registeredClient = GivenRegisteredTestClientAsJson(TestClientHostnameExpected, TestClientUsernameExpected);
            
            var actualTask = WhenGettingTaskAsJson(registeredClient.Id);
            
            ThenTestTaskIsNull(actualTask);
            ThenTestClientIsFree(registeredClient);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldProvideATaskOnlyAfterTaskThisDependsOnIsCompleted()
        {
            GivenAllocatedTestTask(4, "task name", true, TestTaskStatuses.CompletedSuccessfully, true, "another rule", 0);
            var givenTask02 = GivenLoadedTestTask(5, "task name", false, TestTaskStatuses.New, true, TestClientHostnameExpected, 4);
            var registeredClient = GivenRegisteredTestClientAsJson(TestClientHostnameExpected, TestClientUsernameExpected);
            
            var actualTask = WhenGettingTaskAsJson(registeredClient.Id);
            
            ThenHttpResponseIsOk();
            ThenTestTaskPropertiesEqualTo(givenTask02, actualTask, TestTaskStatuses.Running);
            ThenTestClientIsBusy(ClientsCollection.Clients.First(client => client.Id == registeredClient.Id));
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldProvideNoTaskToUnregisteredTestClient()
        {
            GivenLoadedTestTask(5, "task name", false, TestTaskStatuses.New, true, TestClientHostnameExpected, 0);
            var registeredClient = GivenRegisteredTestClientAsJson(TestClientHostnameExpected, TestClientUsernameExpected);
            
            WhenSendingDeregistrationAsJson(registeredClient);
            WhenGettingTaskAsJson(Guid.Empty);
            
            ThenHttpResponseIsExpectationFailed();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldProvideNoTaskToTestClientThatLostItsRegistration()
        {
            var givenTask01 = GivenLoadedTestTask(5, "task name", false, TestTaskStatuses.New, true, TestClientHostnameExpected, 0);
            var registeredClient = GivenRegisteredTestClientAsJson(TestClientHostnameExpected, TestClientUsernameExpected);
            
            WhenRemovingRegisteredClientOnServer(registeredClient);
            WhenGettingTaskAsJson(registeredClient.Id);
            if (HttpStatusCode.ExpectationFailed == _response.StatusCode)
                registeredClient = GivenRegisteredTestClientAsJson(TestClientHostnameExpected, TestClientUsernameExpected);
            var actualTask = WhenGettingTaskAsJson(registeredClient.Id);
            
            ThenHttpResponseIsOk();
            ThenTestTaskPropertiesEqualTo(givenTask01, actualTask, TestTaskStatuses.Running);
            Assert.Equal(givenTask01.Id, TaskPool.TasksForClients.OrderBy(t => t.Id).Skip(1).First().Id);
            ThenTestClientIsBusy(ClientsCollection.Clients.First(client => client.Id == registeredClient.Id));
        }
        
        [MbUnit.Framework.Ignore][NUnit.Framework.Ignore]
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        public void ShouldCompleteTheCurrentTaskOnClientUnregistration()
        {
            // TODO: do it!
//            // Given
//            var testClient = new TestClient { Hostname = testClientHostnameExpected, Username = testClientUsernameExpected };
//            var task = new TestTask {
//                Id = 5,
//                Name = "task name",
//                TaskFinished = false,
//                IsActive = true,
//                TaskStatus = TestTaskStatuses.New,
//                Rule = "no matches"
//            };
//            TaskPool.Tasks.Add(task);
//            
//            // When
//            var response = browser.Post(UrnList.TestClientRegistrationPoint, with => with.JsonBody<ITestClient>(testClient));
//            testClient = response.Body.DeserializeJson<TestClient>();
//            WHEN_SendingDeregistration(testClient);
//            response = browser.Get(UrnList.TestTasks_Root + "/" + 0);
//            
//            // Then
//            ThenHttpResponseIsNotFound(response);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldProvideTaskByTaskOnLoadingNewTasks()
        {
            GivenLoadedTestTask(5, "task name", false, TestTaskStatuses.New, true, TestClientHostnameExpected, 0);
            var registeredClient = GivenRegisteredTestClientAsJson(TestClientHostnameExpected, TestClientUsernameExpected);
            
            // the first task
            var actualTask = WhenGettingTaskAsJson(registeredClient.Id);
            actualTask.TaskResult.Add("result01", "res01");
            actualTask.TaskResult.Add("result02", "res02");
            WhenFinishingTaskAsJson(actualTask);
            
            // the second task
            var givenTask02 = GivenLoadedTestTask(10, "task name", false, TestTaskStatuses.New, true, TestClientHostnameExpected, 0);
            givenTask02.ClientId = registeredClient.Id;
            TaskPool.TasksForClients.Add(givenTask02);
            actualTask = WhenGettingTaskAsJson(registeredClient.Id);
            actualTask.TaskResult.Add("result01", "res01");
            actualTask.TaskResult.Add("result02", "res02");
            WhenFinishingTaskAsJson(actualTask);
            
            ThenHttpResponseIsOk();
            ThenTestTaskPropertiesEqualTo(givenTask02, actualTask);
            Assert.Equal(givenTask02.Id, TaskPool.TasksForClients.OrderBy(t => t.Id).Skip(1).First().Id);
            ThenTestClientIsBusy(ClientsCollection.Clients.First(client => client.Id == registeredClient.Id));
        }
        
        // ======================================== Lack of pending test runs ========================================================
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldProvideATaskToTestClientIfTheClientMatchesTheRuleAndThereAreNoTestRuns()
        {
            TestRunQueue.TestRuns.Skip(1).First().Status = TestRunStatuses.Running;
            var expectedTask = GivenLoadedTestTask(5, "task name", false, TestTaskStatuses.New, true, TestClientHostnameExpected, 0);
            var testClient = GivenRegisteredTestClientAsJson(TestClientHostnameExpected, TestClientUsernameExpected);
            
            var actualTask = WhenGettingTaskAsJson(testClient.Id);
            
            ThenHttpResponseIsOk();
            ThenTestTaskPropertiesEqualTo(expectedTask, actualTask, TestTaskStatuses.Running);
            ThenTestClientIsBusy(ClientsCollection.Clients.First(client => client.Id == testClient.Id));
        }
        // ============================================================================================================================
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldProvideATaskToTwoTestClientsIfTheyMatchTheRule()
        {
            var expectedTask = GivenLoadedTestTask(5, "task name", false, TestTaskStatuses.New, true, TestClientHostnameExpected + "|" + TestClientHostnameAlternateExpected, 0);
            var testClient01 = GivenRegisteredTestClientAsJson(TestClientHostnameExpected, TestClientUsernameExpected);
            var testClient02 = GivenRegisteredTestClientAsJson(TestClientHostnameAlternateExpected, TestClientUsernameExpected);
            
            var actualTask01 = WhenGettingTaskAsJson(testClient01.Id);
            
            ThenHttpResponseIsOk();
            ThenTestTaskPropertiesEqualTo(expectedTask, actualTask01, TestTaskStatuses.Running);
            ThenTestClientIsBusy(ClientsCollection.Clients.First(client => client.Id == testClient01.Id));
            
            // TODO: refactor this
            var actualTask02 = WhenGettingTaskAsJson(testClient02.Id);
            
            ThenHttpResponseIsOk();
            ThenTestTaskPropertiesEqualTo(expectedTask, actualTask02, TestTaskStatuses.Running);
            ThenTestClientIsBusy(ClientsCollection.Clients.First(client => client.Id == testClient02.Id));
        }
        // ============================================================================================================================
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldProvideTasksToTwoTestClientsBasedOnHowTheyMatchRules()
        {
            var expectedTask01 = GivenLoadedTestTask(5, "task name 01", false, TestTaskStatuses.New, true, TestClientHostnameExpected, 0);
            var expectedTask02 = GivenLoadedTestTask(6, "task name 02", false, TestTaskStatuses.New, true, TestClientHostnameExpected + "|" + TestClientHostnameAlternateExpected, 0);
            var testClient01 = GivenRegisteredTestClientAsJson(TestClientHostnameExpected, TestClientUsernameExpected);
            var testClient02 = GivenRegisteredTestClientAsJson(TestClientHostnameAlternateExpected, TestClientUsernameExpected);
            
            var actualTask01 = WhenGettingTaskAsJson(testClient01.Id);
            
            ThenHttpResponseIsOk();
            ThenTestTaskPropertiesEqualTo(expectedTask01, actualTask01, TestTaskStatuses.Running);
            ThenTestClientIsBusy(ClientsCollection.Clients.First(client => client.Id == testClient01.Id));
            
            // TODO: refactor this
            var actualTask02 = WhenGettingTaskAsJson(testClient02.Id);
            
            ThenHttpResponseIsOk();
            ThenTestTaskPropertiesEqualTo(expectedTask02, actualTask02, TestTaskStatuses.Running);
            ThenTestClientIsBusy(ClientsCollection.Clients.First(client => client.Id == testClient02.Id));
        }
        // ============================================================================================================================
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldNotFailTestRunOnATaskFailedByTestResults()
        {
            var expectedTask01 = GivenLoadedTestTask(5, "task name 01", false, TestTaskStatuses.New, true, TestClientHostnameExpected, 0, TestStatuses.Failed);
            TaskPool.Tasks[1].IsCritical = false;
            var expectedTask02 = GivenLoadedTestTask(6, "task name 02", false, TestTaskStatuses.New, true, TestClientHostnameExpected + "|" + TestClientHostnameAlternateExpected, 0);
            var testClient01 = GivenRegisteredTestClientAsJson(TestClientHostnameExpected, TestClientUsernameExpected);
            var testClient02 = GivenRegisteredTestClientAsJson(TestClientHostnameAlternateExpected, TestClientUsernameExpected);
            
            var actualTask01 = WhenGettingTaskAsJson(testClient01.Id);
            // actualTask01.IsCritical = false;
            WhenFailingTestResultsForTaskAsJson(actualTask01);
            
            ThenHttpResponseIsOk();
            ThenTestTaskPropertiesEqualTo(expectedTask01, actualTask01, TestTaskStatuses.FailedByTestResults);
            ThenTestClientIsBusy(ClientsCollection.Clients.First(client => client.Id == testClient01.Id));
            
            // TODO: refactor this
            var actualTask02 = WhenGettingTaskAsJson(testClient02.Id);
            
            ThenHttpResponseIsOk();
            ThenTestTaskPropertiesEqualTo(expectedTask02, actualTask02, TestTaskStatuses.Running);
            ThenTestClientIsBusy(ClientsCollection.Clients.First(client => client.Id == testClient02.Id));
        }
        
        [MbUnit.Framework.Test]
        [NUnit.Framework.Test]
        [Fact]
        public void ShouldFailTestRunOnACriticalTaskFailedByTestResults()
        {
            var expectedTask01 = GivenLoadedTestTask(5, "task name 01", false, TestTaskStatuses.New, true, TestClientHostnameExpected, 0, TestStatuses.Failed);
            TaskPool.Tasks[1].IsCritical = true;
            GivenLoadedTestTask(6, "task name 02", false, TestTaskStatuses.New, true, TestClientHostnameExpected + "|" + TestClientHostnameAlternateExpected, 0);
            var testClient01 = GivenRegisteredTestClientAsJson(TestClientHostnameExpected, TestClientUsernameExpected);
            var testClient02 = GivenRegisteredTestClientAsJson(TestClientHostnameAlternateExpected, TestClientUsernameExpected);
            
            var actualTask01 = WhenGettingTaskAsJson(testClient01.Id);
            // actualTask01.IsCritical = true;
            expectedTask01.TaskStatus = TestTaskStatuses.FailedByTestResults;
            WhenFailingTestResultsForTaskAsJson(actualTask01);
            
            ThenHttpResponseIsOk();
            ThenTestTaskPropertiesEqualTo(expectedTask01, actualTask01, TestTaskStatuses.FailedByTestResults);
            // ThenTestClientIsBusy(ClientsCollection.Clients.First(client => client.Id == testClient01.Id));
            
            // TODO: refactor this
            WhenGettingTaskAsJson(testClient02.Id);
            
            // ThenHttpResponseIsOk();
            // 20150909
            // ThenHttpResponseIsExpectationFailed();
            ThenHttpResponseIsNotFound(); // as there's no more client
            // ThenTestTaskPropertiesEqualTo(expectedTask02, actualTask02, TestTaskStatuses.Running);
            //ThenTestTaskPropertiesEqualTo(expectedTask02, actualTask02, TestTaskStatuses.Canceled);
            //ThenTestClientIsBusy(ClientsCollection.Clients.First(client => client.Id == testClient02.Id));
        }
        // ============================================================================================================================
        ITestClient GivenRegisteredTestClientAsJson(string hostname, string username)
        {
            var testClient = new TestClient { Hostname = hostname, Username = username };
            //_response = _browser.Post(UrlList.TestClientRegistrationPoint_absPath, with => {
            //                                with.JsonBody<ITestClient>(testClient);
            //                                with.Accept("application/json");
            //                            });
            var client = testClient;
            _response = _browser.Post(UrlList.TestClientRegistrationPoint_absPath, with =>
            {
                with.JsonBody<ITestClient>(client);
                with.Accept("application/json");
            });
            testClient = _response.Body.DeserializeJson<TestClient>();
            
            if (null == testClient)
                return null;
            
            var clientSettings = ClientSettings.Instance;
            clientSettings.ServerUrl = @"http://localhost:12340";
            clientSettings.StopImmediately = false;
            
            clientSettings.ClientId = testClient.Id;
            // clientSettings.StopImmediately = false;
            
            
            
            return testClient;
        }
        
        ITestTask GivenLoadedTestTask(int id, string taskName, bool finished, TestTaskStatuses status, bool isActive, string rule, int afterTask, TestStatuses testStatus = TestStatuses.NotRun)
        {
            // 20150904
            var task = new TestTask {
            // var task = new TestTask (TestTaskRuntimeTypes.Powershell) {
                Id = id,
                Name = taskName,
                TaskFinished = finished,
                IsActive = isActive,
                TaskStatus = status,
                Rule = rule,
                AfterTask = afterTask,
                WorkflowId = _workflow.Id,
                TestRunId = _testRun.Id
                // 20150908
                ,
                TestStatus = testStatus
            };
            TaskPool.Tasks.Add(task);
            return task;
        }
        
        ITestTask GivenAllocatedTestTask(int id, string taskName, bool finished, TestTaskStatuses status, bool isActive, string rule, int afterTask, TestStatuses testStatus = TestStatuses.NotRun)
        {
            // 20150904
            var task = new TestTask {
            // var task = new TestTask (TestTaskRuntimeTypes.Powershell) {
                Id = id,
                Name = taskName,
                TaskFinished = finished,
                IsActive = isActive,
                TaskStatus = status,
                Rule = rule,
                AfterTask = afterTask,
                WorkflowId = _workflow.Id,
                TestRunId = _testRun.Id
                    // 20150908
                    ,
                TestStatus = testStatus
            };
            TaskPool.TasksForClients.Add(task);
            return task;
        }
        
        // TODO: duplicated
        void WhenSendingDeregistrationAsJson(ITestClient testClient)
        {
            _browser.Delete(UrlList.TestClients_Root + "/" + testClient.Id, with => with.Accept("application/json"));
        }
        
        void WhenSendingDeregistrationAsXml(TestClient testClient)
        {
            _browser.Delete(UrlList.TestClients_Root + "/" + testClient.Id, with => with.Accept("application/xml"));
        }
        
        // 20141020 squeezing a task to its proxy
        TestTask WhenGettingTaskAsJson(Guid clientId)
        // TestTaskProxy WhenGettingTaskAsJson(int clientId)
        {
            _response = _browser.Get(UrlList.TestTasks_Root + "/" + clientId, with => with.Accept("application/json"));
            // 20141020 squeezing a task to its proxy
            var actualTask = _response.Body.DeserializeJson<TestTask>();
            // var actualTask = response.Body.DeserializeJson<TestTaskProxy>();
            // var actualTask = response.Body.DeserializeJson<TestTaskCodeProxy>();
            if (null == actualTask) return null;
            actualTask.TaskStatus = TestTaskStatuses.Running;
            // emulates actualTask.StartTimer();
            _startTime = DateTime.Now;
            actualTask.StartTime = _startTime;
            _browser.Put(UrlList.TestTasks_Root + "/" + actualTask.Id, with => {
                                    // 20141020 squeezing a task to its proxy
                                       with.JsonBody<ITestTask>(actualTask);
                                       // with.JsonBody<ITestTaskProxy>(actualTask);
                                       // with.JsonBody<ITestTaskStatusProxy>((actualTask as ITestTask).SqueezeTaskToTaskStatusProxy());
                                       with.Accept("application/json");
                                   });
            return actualTask;
        }
        
        void WhenRemovingRegisteredClientOnServer(ITestClient registeredClient)
        {
            ClientsCollection.Clients.RemoveAll(client => client.Id == registeredClient.Id);
        }
        
        // 20141020 squeezing a task to its proxy
        void WhenFinishingTaskAsJson(TestTask actualTask)
        // void WhenFinishingTaskAsJson(TestTaskProxy actualTask)
        {
            actualTask.TaskStatus = TestTaskStatuses.CompletedSuccessfully;
            actualTask.TaskFinished = true;
            _browser.Put(UrlList.TestTasks_Root + "/" + actualTask.Id, with => {
                with.Accept("application/json");
                // 20141020 squeezing a task to its proxy
                with.JsonBody<ITestTask>(actualTask);
                // with.JsonBody<ITestTaskProxy>(actualTask);
            });
        }
        
        // 20141020 squeezing a task to its proxy
        void WhenFailingTaskAsJson(TestTask actualTask)
        // void WHEN_Failing_Task(TestTaskProxy actualTask)
        {
            actualTask.TaskStatus = TestTaskStatuses.ExecutionFailed;
            actualTask.TaskFinished = true;
            // 20141020 squeezing a task to its proxy
            _browser.Put(UrlList.TestTasks_Root + "/" + actualTask.Id, with => {
                             with.Accept("application/json");
                             with.JsonBody<ITestTask>(actualTask);
                         });
            // _browser.Put(UrnList.TestTasks_Root + "/" + actualTask.Id, with => with.JsonBody<ITestTaskProxy>(actualTask));
        }

        // 20150907
        // 20141020 squeezing a task to its proxy
        void WhenFailingTestResultsForTaskAsJson(TestTask actualTask)
        // void WHEN_Failing_Task(TestTaskProxy actualTask)
        {
            actualTask.TaskStatus = TestTaskStatuses.FailedByTestResults;
            
            // 20150908
            actualTask.TestStatus = TestStatuses.Failed;
            
            actualTask.TaskFinished = true;
            
            // 20141020 squeezing a task to its proxy
            _browser.Put(UrlList.TestTasks_Root + "/" + actualTask.Id, with =>
            {
                with.Accept("application/json");
                with.JsonBody<ITestTask>(actualTask);
            });
            // _browser.Put(UrnList.TestTasks_Root + "/" + actualTask.Id, with => with.JsonBody<ITestTaskProxy>(actualTask));
        }
        
        void ThenHttpResponseIsOk()
        {
            Assert.Equal(HttpStatusCode.OK, _response.StatusCode);
        }
        
        void ThenHttpResponseIsNotFound()
        {
            Assert.Equal(HttpStatusCode.NotFound, _response.StatusCode);
        }
        
        void ThenHttpResponseIsExpectationFailed()
        {
            Assert.Equal(HttpStatusCode.ExpectationFailed, _response.StatusCode);
        }
        
        // 20141020 squeezing a task to its proxy
        void ThenTestTaskPropertiesEqualTo(ITestTask expectedTask, ITestTask actualTask)
        // void ThenTestTaskPropertiesEqualTo(ITestTask expectedTask, ITestTaskProxy actualTask)
        {
            Assert.Equal(expectedTask.Id, actualTask.Id);
            Assert.Equal(expectedTask.Name, actualTask.Name);
            Assert.Equal(expectedTask.TaskStatus, actualTask.TaskStatus);
            // 20150112
            // Xunit.Assert.Equal(expectedTask.TaskFinished, actualTask.TaskFinished);
            // 20141020 squeezing a task to its proxy
            Assert.Equal(expectedTask.IsActive, actualTask.IsActive);
            // Xunit.Assert.Equal(_startTime, actualTask.StartTime);

            // 20150908
            Assert.Equal(expectedTask.TestStatus, actualTask.TestStatus);
        }
        
        // 20141020 squeezing a task to its proxy
        void ThenTestTaskPropertiesEqualTo(ITestTask expectedTask, ITestTask actualTask, TestTaskStatuses status)
        // void ThenTestTaskPropertiesEqualTo(ITestTask expectedTask, ITestTaskProxy actualTask, TestTaskStatuses status)
        {
            expectedTask.TaskStatus = status;
            ThenTestTaskPropertiesEqualTo(expectedTask, actualTask);
        }
        
        // 20141020 squeezing a task to its proxy
        void ThenTestTaskIsNull(ITestTask task)
        // void ThenTestTaskIsNull(ITestTaskProxy task)
        {
            Assert.Equal(null, task);
        }
        
        void ThenTestClientIsBusy(ITestClient testClient)
        {
            Assert.Equal(TestClientStatuses.Running, testClient.Status);
        }
        
        void ThenTestClientIsFree(ITestClient testClient)
        {
            Assert.Equal(TestClientStatuses.NoTasks, testClient.Status);
        }
        
        void ThenTestRunIsCompleted()
        {
            Assert.Equal(true, _testRun.IsCompleted());
        }

        void ThenTestRunClientsUnregistered(int taskId)
        {
            // Xunit.Assert.True(ClientsCollection.Clients.All(client => client.TestRunId != _testRun.Id));
            // var clientIdOfClientThatRanThisTask = ClientsCollection.Clients.First(client => client.TaskId == taskId).Id;
            // Xunit.Assert.True(ClientsCollection.Clients.All(client => client.Id != clientIdOfClientThatRanThisTask));
            // not good, not bad
            Assert.True(ClientsCollection.Clients.All(client => client.TaskId != taskId));
        }

        void ThenTestClientIsNotRegistered(ITestClient testClient)
        {
            Assert.Null(testClient);
        }
    }
}
