/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/27/2014
 * Time: 3:20 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Tests.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Logic.ObjectModel;
    using Core;
    using Core.Types.Remoting;
    using Interfaces.Remoting;
    using Interfaces.Server;
    using Logic.ObjectModel.Objects;
    using MbUnit.Framework;
    using Nancy.Testing;
    using UnitTestingHelpers;
    using Xunit;
    using Assert = Xunit.Assert;

    /// <summary>
    /// Description of TestRunsModuleTestFixture.
    /// </summary>
    [TestFixture][NUnit.Framework.TestFixture]
    public class TestRunsModuleTestFixture
    {
        BrowserResponse _response;
        Browser _browser;
        const string TestClientHostnameExpected01 = "testhost_01";
        const string TestClientUsernameExpected01 = "aaa_01";
        
        public TestRunsModuleTestFixture()
        {
            TestSettings.PrepareModuleTests();
            _browser = TestFactory.GetBrowserForTestRunsModule();
        }
        
        [SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            TestSettings.PrepareModuleTests();
            _browser = TestFactory.GetBrowserForTestRunsModule();
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldCreateFirstTestRunOfDefaultWorkflowRunningAsJson()
        {
            GivenFirstTestWorkflow(TestConstants.Workflow03);
            WorkflowCollection.Workflows[0].IsDefault = true;
            Defaults.Workflow = WorkflowCollection.Workflows[0].Name;
            
            WhenSendingTestRunAsJson(TestConstants.Workflow03Name, UrlList.TestRunsControlPoint_absPath_for_newDefaultTestRun + "paramValue", null);

            ThenThereShouldBeTheFollowingNumberOfTestRunObjects(1);
            ThenTestRunIsRunning(TestRunQueue.TestRuns[0]);
            
            var w1 = WorkflowCollection.Workflows[0];
            var t1 = TestRunQueue.TestRuns[0];
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldCreateSecondTestRunOfDefaultWorkflowObjectToAnotherWorkflowAndAnotherTestLabRunningAsJson()
        {
            GivenFirstTestWorkflow(TestConstants.Workflow03);
            WorkflowCollection.Workflows[0].IsDefault = true;
            Defaults.Workflow = WorkflowCollection.Workflows[0].Name;
            GivenSecondTestWorkflow();
            var secondTestWorkflow = WorkflowCollection.Workflows.Skip(1).First();
            var secondTestLab = new TestLab();
            TestLabCollection.TestLabs.Add(secondTestLab);
            secondTestWorkflow.SetTestLab(secondTestLab);
            
            WhenSendingTestRunAsJson(TestConstants.Workflow03Name, TestRunStatuses.Running);
            WhenSendingTestRunAsJson(TestConstants.Workflow02Name, TestRunStatuses.Running);
            
            ThenThereShouldBeTheFollowingNumberOfTestRunObjects(2);
            ThenTestRunIsRunning(TestRunQueue.TestRuns[0]);
            ThenTestRunIsRunning(TestRunQueue.TestRuns[1]);
            ThenTestRunIdIs(1, Guid.Parse(_response.Headers[Resources.NewTestRun_lastTestRunId]));
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldCreateFirstTestRunRunningAsJson()
        {
            GivenFirstTestWorkflow();
            
            WhenSendingTestRunAsJson(TestConstants.Workflow01Name, TestRunStatuses.Running);
            
            ThenThereShouldBeTheFollowingNumberOfTestRunObjects(1);
            ThenTestRunIsRunning(TestRunQueue.TestRuns[0]);
            ThenTestRunIdIs(0, Guid.Parse(_response.Headers[Resources.NewTestRun_lastTestRunId]));
        }

        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldCreateFirstTestRunAndReturnItsId()
        {
            GivenFirstTestWorkflow();

            WhenSendingTestRunAsJson(TestConstants.Workflow01Name, TestRunStatuses.Running);

            ThenThereShouldBeTheFollowingNumberOfTestRunObjects(1);
            ThenTestRunIsRunning(TestRunQueue.TestRuns[0]);
            ThenTestRunIdIs(0, Guid.Parse(_response.Headers[Resources.NewTestRun_lastTestRunId]));
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldCreateSecondTestRunObjectToAnotherWorkflowAndAnotherTestLabRunningAsJson()
        {
            GivenFirstTestWorkflow();
            GivenSecondTestWorkflow();
            var secondTestWorkflow = WorkflowCollection.Workflows.Skip(1).First();
            var secondTestLab = new TestLab();
            TestLabCollection.TestLabs.Add(secondTestLab);
            secondTestWorkflow.SetTestLab(secondTestLab);
            
            WhenSendingTestRunAsJson(TestConstants.Workflow01Name, TestRunStatuses.Running);
            WhenSendingTestRunAsJson(TestConstants.Workflow02Name, TestRunStatuses.Running);
            
            ThenThereShouldBeTheFollowingNumberOfTestRunObjects(2);
            ThenTestRunIsRunning(TestRunQueue.TestRuns[0]);
            ThenTestRunIsRunning(TestRunQueue.TestRuns[1]);
            ThenTestRunIdIs(1, Guid.Parse(_response.Headers[Resources.NewTestRun_lastTestRunId]));
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldCreateSecondTestRunObjectToTheSameTestLabAndAnotherWorkflowPendingAsJson()
        {
            GivenFirstTestWorkflow();
            GivenSecondTestWorkflow();
            
            WhenSendingTestRunAsJson(TestConstants.Workflow01Name, TestRunStatuses.Running);
            WhenSendingTestRunAsJson(TestConstants.Workflow02Name, TestRunStatuses.Running);
            
            ThenThereShouldBeTheFollowingNumberOfTestRunObjects(2);
            ThenTestRunIsRunning(TestRunQueue.TestRuns[0]);
            ThenTestRunIsPending(TestRunQueue.TestRuns[1]);
            ThenTestRunIdIs(1, Guid.Parse(_response.Headers[Resources.NewTestRun_lastTestRunId]));
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldCreateSecondTestRunObjectToTheSameTestLabAndTheSameWorkflowPendingAsJson()
        {
            GivenFirstTestWorkflow();
            
            WhenSendingTestRunAsJson(TestConstants.Workflow01Name, TestRunStatuses.Running);
            WhenSendingTestRunAsJson(TestConstants.Workflow01Name, TestRunStatuses.Running);
            
            ThenThereShouldBeTheFollowingNumberOfTestRunObjects(2);
            ThenTestRunIsRunning(TestRunQueue.TestRuns[0]);
            ThenTestRunIsPending(TestRunQueue.TestRuns[1]);
            ThenTestRunIdIs(1, Guid.Parse(_response.Headers[Resources.NewTestRun_lastTestRunId]));
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldCreateSecondTestRunObjectToTheSameTestLabAndTheSameWorkflowAsCompletedRunningAsJson()
        {
            GivenFirstTestWorkflow();
            
            WhenSendingTestRunAsJson(TestConstants.Workflow01Name, TestRunStatuses.Running);
            TaskPool.TasksForClients.ForEach(task => task.TaskStatus = TestTaskStatuses.CompletedSuccessfully);
            TestRunQueue.TestRuns.ForEach(testRun => testRun.Status = TestRunStatuses.Finished);
            WhenSendingTestRunAsJson(TestConstants.Workflow01Name, TestRunStatuses.Running);
            
            ThenThereShouldBeTheFollowingNumberOfTestRunObjects(2);
            ThenTestRunIsCompleted(TestRunQueue.TestRuns[0]);
            ThenTestRunIsRunning(TestRunQueue.TestRuns[1]);
            ThenTestRunIdIs(1, Guid.Parse(_response.Headers[Resources.NewTestRun_lastTestRunId]));
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldRunOnlyOneTestRunAfterCompletionOfThePreviousOneAsJson()
        {
            GivenFirstTestWorkflow();
            
            WhenSendingTestRunAsJson(TestConstants.Workflow01Name, TestRunStatuses.Running);
            TaskPool.TasksForClients.ForEach(task => task.TaskStatus = TestTaskStatuses.CompletedSuccessfully);
            TestRunQueue.TestRuns.ForEach(testRun => testRun.Status = TestRunStatuses.Finished);
            WhenSendingTestRunAsJson(TestConstants.Workflow01Name, TestRunStatuses.Running);
            WhenSendingTestRunAsJson(TestConstants.Workflow01Name, TestRunStatuses.Running);
            WhenSendingTestRunAsJson(TestConstants.Workflow01Name, TestRunStatuses.Running);
            WhenSendingTestRunAsJson(TestConstants.Workflow01Name, TestRunStatuses.Running);
            
            ThenThereShouldBeTheFollowingNumberOfTestRunObjects(5);
            ThenTestRunIsCompleted(TestRunQueue.TestRuns[0]);
            ThenTestRunIsRunning(TestRunQueue.TestRuns[1]);
            ThenTestRunIsPending(TestRunQueue.TestRuns[2]);
            ThenTestRunIsPending(TestRunQueue.TestRuns[3]);
            ThenTestRunIsPending(TestRunQueue.TestRuns[4]);
            ThenTestRunIdIs(4, Guid.Parse(_response.Headers[Resources.NewTestRun_lastTestRunId]));
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldRunOnlyOneTestRunAfterInterruptionOfThePreviousOneAsJson()
        {
            GivenFirstTestWorkflow();
            
            WhenSendingTestRunAsJson(TestConstants.Workflow01Name, TestRunStatuses.Running);
            TaskPool.TasksForClients.ForEach(task => task.TaskStatus = TestTaskStatuses.ExecutionFailed);
            TestRunQueue.TestRuns.ForEach(testRun => testRun.Status = TestRunStatuses.Finished);
            WhenSendingTestRunAsJson(TestConstants.Workflow01Name, TestRunStatuses.Running);
            WhenSendingTestRunAsJson(TestConstants.Workflow01Name, TestRunStatuses.Running);
            WhenSendingTestRunAsJson(TestConstants.Workflow01Name, TestRunStatuses.Running);
            WhenSendingTestRunAsJson(TestConstants.Workflow01Name, TestRunStatuses.Running);
            
            ThenThereShouldBeTheFollowingNumberOfTestRunObjects(5);
            ThenTestRunIsCompleted(TestRunQueue.TestRuns[0]);
            ThenTestRunIsRunning(TestRunQueue.TestRuns[1]);
            ThenTestRunIsPending(TestRunQueue.TestRuns[2]);
            ThenTestRunIsPending(TestRunQueue.TestRuns[3]);
            ThenTestRunIsPending(TestRunQueue.TestRuns[4]);
            ThenTestRunIdIs(4, Guid.Parse(_response.Headers[Resources.NewTestRun_lastTestRunId]));
        }

        // 20150907
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldRunOnlyOneTestRunAfterInterruptionOfThePreviousOneByTestResultsAsJson()
        {
            GivenFirstTestWorkflow();

            WhenSendingTestRunAsJson(TestConstants.Workflow01Name, TestRunStatuses.Running);
            TaskPool.TasksForClients.ForEach(task => task.TaskStatus = TestTaskStatuses.FailedByTestResults);
            TestRunQueue.TestRuns.ForEach(testRun => testRun.Status = TestRunStatuses.Finished);
            WhenSendingTestRunAsJson(TestConstants.Workflow01Name, TestRunStatuses.Running);
            WhenSendingTestRunAsJson(TestConstants.Workflow01Name, TestRunStatuses.Running);
            WhenSendingTestRunAsJson(TestConstants.Workflow01Name, TestRunStatuses.Running);
            WhenSendingTestRunAsJson(TestConstants.Workflow01Name, TestRunStatuses.Running);

            ThenThereShouldBeTheFollowingNumberOfTestRunObjects(5);
            ThenTestRunIsCompleted(TestRunQueue.TestRuns[0]);
            ThenTestRunIsRunning(TestRunQueue.TestRuns[1]);
            ThenTestRunIsPending(TestRunQueue.TestRuns[2]);
            ThenTestRunIsPending(TestRunQueue.TestRuns[3]);
            ThenTestRunIsPending(TestRunQueue.TestRuns[4]);
            ThenTestRunIdIs(4, Guid.Parse(_response.Headers[Resources.NewTestRun_lastTestRunId]));
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldRunOnlyOneTestRunAfterCancellationOfThePreviousOneAsJson()
        {
            GivenFirstTestWorkflow();
            
            WhenSendingTestRunAsJson(TestConstants.Workflow01Name, TestRunStatuses.Running);
            TaskPool.TasksForClients.ForEach(task => task.TaskStatus = TestTaskStatuses.Canceled);
            TestRunQueue.TestRuns.ForEach(testRun => testRun.Status = TestRunStatuses.Finished);
            WhenSendingTestRunAsJson(TestConstants.Workflow01Name, TestRunStatuses.Running);
            WhenSendingTestRunAsJson(TestConstants.Workflow01Name, TestRunStatuses.Running);
            WhenSendingTestRunAsJson(TestConstants.Workflow01Name, TestRunStatuses.Running);
            WhenSendingTestRunAsJson(TestConstants.Workflow01Name, TestRunStatuses.Running);
            
            ThenThereShouldBeTheFollowingNumberOfTestRunObjects(5);
            ThenTestRunIsCompleted(TestRunQueue.TestRuns[0]);
            ThenTestRunIsRunning(TestRunQueue.TestRuns[1]);
            ThenTestRunIsPending(TestRunQueue.TestRuns[2]);
            ThenTestRunIsPending(TestRunQueue.TestRuns[3]);
            ThenTestRunIsPending(TestRunQueue.TestRuns[4]);
            ThenTestRunIdIs(4, Guid.Parse(_response.Headers[Resources.NewTestRun_lastTestRunId]));
        }
        
        [Test][NUnit.Framework.Test]// [Fact]
        [Ignore][NUnit.Framework.Ignore("")]
        public void ShouldReturnTestRunAsJson()
        {
            GivenFirstTestWorkflow();
            
            WhenSendingTestRunAsJson(TestConstants.Workflow01Name, TestRunStatuses.Running);
            TaskPool.TasksForClients.ForEach(task => task.TaskStatus = TestTaskStatuses.Canceled);
            TestRunQueue.TestRuns.ForEach(testRun => testRun.Status = TestRunStatuses.Finished);
            WhenGettingTestRun(0);
            
            ThenResponseHasTestRunId(0);
            ThenTestRunIdIs(0, Guid.Parse(_response.Headers[Resources.NewTestRun_lastTestRunId]));
        }
        
        [Test][NUnit.Framework.Test]// [Fact]
        [Ignore][NUnit.Framework.Ignore("")]
        public void ShouldReturnAllTestRunsAsJson()
        {
            //GivenFirstTestWorkflow();
            
            //WhenSendingTestRunAsJson(TestConstants.Workflow01Name, TestRunStatuses.Running);
            //TaskPool.TasksForClients.ForEach(task => task.TaskStatus = TestTaskStatuses.Canceled);
            //TestRunQueue.TestRuns.ForEach(testRun => testRun.Status = TestRunStatuses.Finished);
            //WhenGettingTestRun(0);
            
            //ThenResponseHasTestRunId(0);
            
            GivenFirstTestWorkflow();
            GivenSecondTestWorkflow();
            GivenTestRunRunning(TestConstants.Workflow01Name);
            // GivenTestRunPending(TestConstants.Workflow02Name);
            // GivenTestRunPending(TestConstants.Workflow01Name);
            
            var allTestRuns = WhenSendingRequestToGetAllTestRuns();
            
            // UrlList.TestRunsControlPoint_relPath
            // ThenTestRunEqualsTo(TestRunQueue.TestRuns[0], )
            Assert.Equal(TestRunQueue.TestRuns[0], allTestRuns[0]);
            // Assert.Equal(TestRunQueue.TestRuns[1], allTestRuns[1]);
            // Assert.Equal(TestRunQueue.TestRuns[2], allTestRuns[2]);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldSetTestRunStatusCanceledOnCancelingOfPendingTestRun()
        {
            GivenFirstTestWorkflow();
            GivenSecondTestWorkflow();
            GivenTestRunRunning(TestConstants.Workflow01Name);
            GivenTestRunPending(TestConstants.Workflow02Name);
            
            WhenCancelingTestRun(TestRunQueue.TestRuns[1]);
            
            ThenTestRunStatusIsCanceled(TestRunQueue.TestRuns[1]);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldSetTestRunStatusCancelingOnCancelingOfRunningTestRun()
        {
            GivenFirstTestWorkflow();
            GivenSecondTestWorkflow();
            GivenTestRunRunning(TestConstants.Workflow01Name);
            GivenTestRunPending(TestConstants.Workflow02Name);
            
            WhenCancelingTestRun(TestRunQueue.TestRuns[0]);
            
            ThenTestRunStatusIsCanceled(TestRunQueue.TestRuns[0]);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldSetTestRunStatusCancelingOnCancelingOfRunningTestRunWithRegisteredClients()
        {
            var testRun = TestFactory.GetTestRunWithStatus(TestRunStatuses.Running, TestClientHostnameExpected01);
            GivenTasksForRule(testRun, TestClientHostnameExpected01);
            GivenRegisteredClient(TestClientHostnameExpected01, TestClientUsernameExpected01);
            TestFactory.GetTestRunWithStatus(TestRunStatuses.Pending, TestClientHostnameExpected01);
            
            WhenCancelingTestRun(TestRunQueue.TestRuns[0]);
            
            ThenTestRunStatusIsCanceling(TestRunQueue.TestRuns[0]);
            // 20150918
            // temporarily
            // linked lines of code 20150918-001
            // ThenTestTaskStatusIs(TaskPool.TasksForClients[0], TestTaskStatuses.InterruptedByUser);
            ThenTestTaskStatusIs(TaskPool.TasksForClients[0], TestTaskStatuses.Running);

            ThenTestTaskStatusIs(TaskPool.TasksForClients[1], TestTaskStatuses.New); // emulates the situation when a cancel task has been ready to be sent to a client
            ThenTestTaskStatusIs(TaskPool.TasksForClients[2], TestTaskStatuses.Canceled);
        }
        
        
        
//        ITestClient GivenTestClient(string hostname, string username) // , int testRunId)
//        {
//            return TestFactory.GivenTestClient(hostname, username); // , testRunId);
//        }
        
        ITestClient GivenRegisteredClient(string hostname, string username)
        {
            var testClient = new TestClient { Hostname = hostname, Username = username };
            _response = _browser.Post(UrlList.TestClientRegistrationPoint_absPath, with => {
                with.JsonBody(testClient);
                with.Accept("application/json");
            });
            return _response.Body.DeserializeJson<TestClient>();
        }
        
        
        
//        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_add_one_task_to_the_common_pool_on_imporing_one_task()
//        {
//            Xunit.Assert.Equal(0, 1);
//        }
//        
//        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_add_all_tasks_to_the_common_pool_on_importing_several_tasks()
//        {
//            Xunit.Assert.Equal(0, 1);
//        }
//        
//        // ==========================================================================================
//        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_add_one_task_to_one_client_pool()
//        {
//            Xunit.Assert.Equal(0, 1);
//        }
//        
//        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_add_all_tasks_to_one_client_pool()
//        {
//            Xunit.Assert.Equal(0, 1);
//        }
//        
//        // ==========================================================================================
//        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_add_one_task_to_all_client_pools()
//        {
//            Xunit.Assert.Equal(0, 1);
//        }
//        
//        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_add_all_tasks_to_all_client_pools()
//        {
//            Xunit.Assert.Equal(0, 1);
//        }
//        
//        // ==========================================================================================
//        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_add_no_tasks_to_not_matching_client_pools()
//        {
//            Xunit.Assert.Equal(0, 1);
//        }
//        
//        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_add_one_task_to_matching_client_pools()
//        {
//            Xunit.Assert.Equal(0, 1);
//        }
//        
//        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_add_all_tasks_to_matching_client_pools()
//        {
//            Xunit.Assert.Equal(0, 1);
//        }

        void GivenTasksForRule(ITestRun testRun, string rule)
        {
            TaskPool.TasksForClients.AddRange(
                new[] {
                    new TestTask {
                        Id = 1,
                        TaskStatus = TestTaskStatuses.Running,
                        Rule = rule,
                        TestRunId = testRun.Id,
                        WorkflowId = testRun.WorkflowId
                    },
                    new TestTask {
                        Id = 2,
                        TaskStatus = TestTaskStatuses.New,
                        IsCancel = true,
                        Rule = rule,
                        TestRunId = testRun.Id,
                        WorkflowId = testRun.WorkflowId
                    },
                    new TestTask {
                        Id = 2,
                        TaskStatus = TestTaskStatuses.New,
                        Rule = rule,
                        TestRunId = testRun.Id,
                        WorkflowId = testRun.WorkflowId
                    }
                }
               );
        }
        
        void GivenFirstTestWorkflow()
        {
            GivenFirstTestWorkflow(TestConstants.Workflow01);
        }
        
        void GivenFirstTestWorkflow(string alternativeName)
        {
            var serverCommand = new ServerCommand {
                Command = ServerControlCommands.LoadConfiguraiton,
                Data = alternativeName
            };
            _browser.Put(UrlList.ServerControlPoint_absPath, with => {
                with.JsonBody(serverCommand);
                with.Accept("application/json");
            });
        }
        
        void GivenSecondTestWorkflow()
        {
            var serverCommand = new ServerCommand {
                Command = ServerControlCommands.LoadConfiguraiton,
                Data = TestConstants.Workflow02
            };
            _browser.Put(UrlList.ServerControlPoint_absPath, with => {
                with.JsonBody(serverCommand);
                with.Accept("application/json");
            });
        }
        
        void GivenTestRunRunning(string testWorkflowName)
        {
            var testRunCommand = new TestRunCommand { WorkflowName = testWorkflowName, Status = TestRunStatuses.Running };
            WhenSendingTestRunAsJson(testWorkflowName, UrlList.TestRunsControlPoint_absPath, testRunCommand);
        }
        
        void GivenTestRunPending(string testWorkflowName)
        {
            var testRunCommand = new TestRunCommand { WorkflowName = testWorkflowName, Status = TestRunStatuses.Running }; // will be pending
            WhenSendingTestRunAsJson(testWorkflowName, UrlList.TestRunsControlPoint_absPath, testRunCommand);
        }
        
        void WhenSendingTestRunAsJson(string testWorkflowName, TestRunStatuses status)
        {
            var testRunCommand = new TestRunCommand { WorkflowName = testWorkflowName, Status = status };
            WhenSendingTestRunAsJson(testWorkflowName, UrlList.TestRunsControlPoint_absPath, testRunCommand);
        }
        
        void WhenSendingTestRunAsJson(string testWorkflowName, string alternativeUrl, ITestRunCommand testRunCommand)
        {
            var testRun = new TestRun();
            ((TestRun) testRun).SetWorkflow(WorkflowCollection.Workflows.First(wfl => wfl.Name == testWorkflowName));
            if (null == testRunCommand)
                _response = _browser.Post(alternativeUrl, with => {
                    // with.JsonBody(testRunCommand);
                    with.Accept("application/json");
                });
            else
                _response = _browser.Post(alternativeUrl, with => {
                    with.JsonBody(testRunCommand);
                    with.Accept("application/json");
                });
        }
        
        void WhenGettingTestRun(int numberOfTheTestRun)
        {
            _response = _browser.Get(UrlList.TestRunsControlPoint_absPath + TestRunQueue.TestRuns[numberOfTheTestRun].Id, with => with.Accept("application/json"));
        }
        
        void WhenCancelingTestRun(ITestRun testRun)
        {
            _response = _browser.Put(UrlList.TestRuns_Root + "/" + testRun.Id + "/cancelTestRun", with => {
                                         with.Accept("application/json");
                                     });
        }
        
        List<ITestRun> WhenSendingRequestToGetAllTestRuns()
        // List<TestRun> WhenSendingRequestToGetAllTestRuns()
        {
            _response = _browser.Get(UrlList.TestRuns_Root + UrlList.TestRunsControlPoint_relPath, with =>
            {
                with.Accept("application/json");
            });
            // return _response.Body.DeserializeJson<List<ITestRun>>();
            //try {
            //    // var testRuns = _response.Body.DeserializeJson<List<TestRun>>();
            //    // var testRuns = _response.Body.DeserializeJson<List<ITestRun>>();
            //    // var testRuns = _response.Body.DeserializeJson<IEnumerable<ITestRun>>();
            //    var testRuns = _response.Body.DeserializeJson();
            //}
            //catch (Exception ee) {
            //    Console.WriteLine(ee.Message);
            //}
            // return _response.Body.DeserializeJson<List<TestRun>>();
            return _response.Body.DeserializeJson<List<ITestRun>>();
        }
        
        void ThenThereShouldBeTheFollowingNumberOfTestRunObjects(int number)
        {
            Assert.Equal(number, TestRunQueue.TestRuns.Count);
        }
        
        void ThenTestRunIsRunning(ITestRun testRun)
        {
            Assert.Equal(true, testRun.IsActive());
        }
        
        void ThenTestRunIsPending(ITestRun testRun)
        {
            Assert.Equal(true, testRun.IsPending());
        }
        
        void ThenTestRunIsCompleted(ITestRun testRun)
        {
            Assert.Equal(true, testRun.IsCompleted());
        }
        
        // void ThenTestRunIdIs(Guid actualTestRunId)
        void ThenTestRunIdIs(int testRunNumber, Guid actualTestRunId)
        {
            // Assert.Equal(_response.Headers[Resources.NewTestRun_lastTestRunId], actualTestRunId.ToString());
            // Assert.Equal(TestRunQueue.TestRuns[0].Id, actualTestRunId.ToString());
            // Assert.Equal(TestRunQueue.TestRuns[0].Id, actualTestRunId);
            Assert.Equal(TestRunQueue.TestRuns[testRunNumber].Id, actualTestRunId);
        }
        
        void ThenResponseHasTestRunId(int numberOfTestRunInTheQueue)
        {
            var testRun = _response.Body.DeserializeJson<TestRun>();
            // var testRun = _response.Body.Deserialize<TestRun>(new TestRunDeserializer());
            Assert.Equal(TestRunQueue.TestRuns[0].Id, testRun.Id);
        }
        
        void ThenTestRunStatusIsCanceling(ITestRun testRun)
        {
            Assert.Equal(TestRunStatuses.Canceling, testRun.Status);
        }
        
        void ThenTestRunStatusIsCanceled(ITestRun testRun)
        {
            Assert.Equal(TestRunStatuses.Canceled, testRun.Status);
        }

        void ThenTestTaskStatusIs(ITestTask testTask, TestTaskStatuses status)
        {
            Assert.Equal(status, testTask.TaskStatus);
        }
    }
    
    //public class TestRunDeserializer : IBodyDeserializer
    //{
    //    public bool CanDeserialize(string contentType, BindingContext context)
    //    {
    //        return true;
    //    }

    //    public object Deserialize(string contentType, Stream bodyStream, BindingContext context)
    //    {
    //        return new TestRun();
    //    }
    //}
}
