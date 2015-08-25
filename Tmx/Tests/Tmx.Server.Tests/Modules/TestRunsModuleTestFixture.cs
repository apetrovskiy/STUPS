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
    using System.ComponentModel;
    using System.Dynamic;
    using System.IO;
    using System.Linq;
    using Logic.ObjectModel;
    using Core;
    using Core.Types.Remoting;
    using CsQuery.ExtensionMethods;
    using Interfaces.Remoting;
    using Interfaces.Server;
    using Logic.ObjectModel.Objects;
    using MbUnit.Framework;
    using Nancy;
    using Nancy.ModelBinding;
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
        
        [Test][NUnit.Framework.Test][Fact]
        public void Should_create_first_testRun_of_default_workflow_Running_as_json()
        {
            GIVEN_first_testWorkflow(TestConstants.Workflow03);
            WorkflowCollection.Workflows[0].IsDefault = true;
            Defaults.Workflow = WorkflowCollection.Workflows[0].Name;
            
            WHEN_sending_testRun_as_json("def", TestRunStatuses.Running, UrlList.TestRunsControlPoint_absPath_for_newDefaultTestRun + "paramValue", null);
            
            THEN_there_should_be_the_following_number_of_testRun_objects(1);
            THEN_testRun_is_running(TestRunQueue.TestRuns[0]);
            
            var w1 = WorkflowCollection.Workflows[0];
            var t1 = TestRunQueue.TestRuns[0];
        }
        
        [Test][NUnit.Framework.Test][Fact]
        public void Should_create_second_testRun_of_default_workflow_object_to_another_workflow_and_another_testLab_Running_as_json()
        {
            GIVEN_first_testWorkflow(TestConstants.Workflow03);
            WorkflowCollection.Workflows[0].IsDefault = true;
            Defaults.Workflow = WorkflowCollection.Workflows[0].Name;
            GIVEN_second_testWorkflow();
            var secondTestWorkflow = WorkflowCollection.Workflows.Skip(1).First();
            var secondTestLab = new TestLab();
            TestLabCollection.TestLabs.Add(secondTestLab);
            secondTestWorkflow.SetTestLab(secondTestLab);
            
            WHEN_sending_testRun_as_json("def", TestRunStatuses.Running);
            WHEN_sending_testRun_as_json("NAC", TestRunStatuses.Running);
            
            THEN_there_should_be_the_following_number_of_testRun_objects(2);
            THEN_testRun_is_running(TestRunQueue.TestRuns[0]);
            THEN_testRun_is_running(TestRunQueue.TestRuns[1]);
        }
        
        [Test][NUnit.Framework.Test][Fact]
        public void Should_create_first_testRun_Running_as_json()
        {
            GIVEN_first_testWorkflow();
            
            WHEN_sending_testRun_as_json("CRsuite", TestRunStatuses.Running);
            
            THEN_there_should_be_the_following_number_of_testRun_objects(1);
            THEN_testRun_is_running(TestRunQueue.TestRuns[0]);
        }

        [Test][NUnit.Framework.Test][Fact]
        public void Should_create_first_testRun_and_returns_its_id()
        {
            GIVEN_first_testWorkflow();

            // WHEN_sending_testRun_as_json("CRsuite", TestRunStatuses.Running);
            WHEN_sending_testRun_as_json("CRsuite", TestRunStatuses.Running);

            THEN_there_should_be_the_following_number_of_testRun_objects(1);
            THEN_testRun_is_running(TestRunQueue.TestRuns[0]);
            // THEN_testRun_id_is(testRunCommandResponse.NewTestRunId, TestRunQueue.TestRuns[0].Id);
            THEN_testRun_id_is(TestRunQueue.TestRuns[0].Id);
        }
        
        [Test][NUnit.Framework.Test][Fact]
        public void Should_create_second_testRun_object_to_another_workflow_and_another_testLab_Running_as_json()
        {
            GIVEN_first_testWorkflow();
            GIVEN_second_testWorkflow();
            var secondTestWorkflow = WorkflowCollection.Workflows.Skip(1).First();
            var secondTestLab = new TestLab();
            TestLabCollection.TestLabs.Add(secondTestLab);
            secondTestWorkflow.SetTestLab(secondTestLab);
            
            WHEN_sending_testRun_as_json("CRsuite", TestRunStatuses.Running);
            WHEN_sending_testRun_as_json("NAC", TestRunStatuses.Running);
            
            THEN_there_should_be_the_following_number_of_testRun_objects(2);
            THEN_testRun_is_running(TestRunQueue.TestRuns[0]);
            THEN_testRun_is_running(TestRunQueue.TestRuns[1]);
        }
        
        [Test][NUnit.Framework.Test][Fact]
        public void Should_create_second_testRun_object_to_the_same_testLab_and_another_workflow_Pending_as_json()
        {
            GIVEN_first_testWorkflow();
            GIVEN_second_testWorkflow();
            
            WHEN_sending_testRun_as_json("CRsuite", TestRunStatuses.Running);
            WHEN_sending_testRun_as_json("NAC", TestRunStatuses.Running);
            
            THEN_there_should_be_the_following_number_of_testRun_objects(2);
            THEN_testRun_is_running(TestRunQueue.TestRuns[0]);
            THEN_testRun_is_pending(TestRunQueue.TestRuns[1]);
        }
        
        [Test][NUnit.Framework.Test][Fact]
        public void Should_create_second_testRun_object_to_the_same_testLab_and_the_same_workflow_Pending_as_json()
        {
            GIVEN_first_testWorkflow();
            
            WHEN_sending_testRun_as_json("CRsuite", TestRunStatuses.Running);
            WHEN_sending_testRun_as_json("CRsuite", TestRunStatuses.Running);
            
            THEN_there_should_be_the_following_number_of_testRun_objects(2);
            THEN_testRun_is_running(TestRunQueue.TestRuns[0]);
            THEN_testRun_is_pending(TestRunQueue.TestRuns[1]);
        }
        
        [Test][NUnit.Framework.Test][Fact]
        public void Should_create_second_testRun_object_to_the_same_testLab_and_the_same_workflow_as_completed_Running_as_json()
        {
            GIVEN_first_testWorkflow();
            
            WHEN_sending_testRun_as_json("CRsuite", TestRunStatuses.Running);
            TaskPool.TasksForClients.ForEach(task => task.TaskStatus = TestTaskStatuses.CompletedSuccessfully);
            TestRunQueue.TestRuns.ForEach(testRun => testRun.Status = TestRunStatuses.CompletedSuccessfully);
            WHEN_sending_testRun_as_json("CRsuite", TestRunStatuses.Running);
            
            THEN_there_should_be_the_following_number_of_testRun_objects(2);
            THEN_testRun_is_completed(TestRunQueue.TestRuns[0]);
            THEN_testRun_is_running(TestRunQueue.TestRuns[1]);
        }
        
        [Test][NUnit.Framework.Test][Fact]
        public void Should_run_only_one_testRun_after_completion_of_the_previous_one_as_json()
        {
            GIVEN_first_testWorkflow();
            
            WHEN_sending_testRun_as_json("CRsuite", TestRunStatuses.Running);
            TaskPool.TasksForClients.ForEach(task => task.TaskStatus = TestTaskStatuses.CompletedSuccessfully);
            TestRunQueue.TestRuns.ForEach(testRun => testRun.Status = TestRunStatuses.CompletedSuccessfully);
            WHEN_sending_testRun_as_json("CRsuite", TestRunStatuses.Running);
            WHEN_sending_testRun_as_json("CRsuite", TestRunStatuses.Running);
            WHEN_sending_testRun_as_json("CRsuite", TestRunStatuses.Running);
            WHEN_sending_testRun_as_json("CRsuite", TestRunStatuses.Running);
            
            THEN_there_should_be_the_following_number_of_testRun_objects(5);
            THEN_testRun_is_completed(TestRunQueue.TestRuns[0]);
            THEN_testRun_is_running(TestRunQueue.TestRuns[1]);
            THEN_testRun_is_pending(TestRunQueue.TestRuns[2]);
            THEN_testRun_is_pending(TestRunQueue.TestRuns[3]);
            THEN_testRun_is_pending(TestRunQueue.TestRuns[4]);
        }
        
        [Test][NUnit.Framework.Test][Fact]
        public void Should_run_only_one_testRun_after_interruption_of_the_previous_one_as_json()
        {
            GIVEN_first_testWorkflow();
            
            WHEN_sending_testRun_as_json("CRsuite", TestRunStatuses.Running);
            TaskPool.TasksForClients.ForEach(task => task.TaskStatus = TestTaskStatuses.ExecutionFailed);
            TestRunQueue.TestRuns.ForEach(testRun => testRun.Status = TestRunStatuses.CompletedSuccessfully);
            WHEN_sending_testRun_as_json("CRsuite", TestRunStatuses.Running);
            WHEN_sending_testRun_as_json("CRsuite", TestRunStatuses.Running);
            WHEN_sending_testRun_as_json("CRsuite", TestRunStatuses.Running);
            WHEN_sending_testRun_as_json("CRsuite", TestRunStatuses.Running);
            
            THEN_there_should_be_the_following_number_of_testRun_objects(5);
            THEN_testRun_is_completed(TestRunQueue.TestRuns[0]);
            THEN_testRun_is_running(TestRunQueue.TestRuns[1]);
            THEN_testRun_is_pending(TestRunQueue.TestRuns[2]);
            THEN_testRun_is_pending(TestRunQueue.TestRuns[3]);
            THEN_testRun_is_pending(TestRunQueue.TestRuns[4]);
        }
        
        [Test][NUnit.Framework.Test][Fact]
        public void Should_run_only_one_testRun_after_cancellation_of_the_previous_one_as_json()
        {
            GIVEN_first_testWorkflow();
            
            WHEN_sending_testRun_as_json("CRsuite", TestRunStatuses.Running);
            TaskPool.TasksForClients.ForEach(task => task.TaskStatus = TestTaskStatuses.Canceled);
            TestRunQueue.TestRuns.ForEach(testRun => testRun.Status = TestRunStatuses.CompletedSuccessfully);
            WHEN_sending_testRun_as_json("CRsuite", TestRunStatuses.Running);
            WHEN_sending_testRun_as_json("CRsuite", TestRunStatuses.Running);
            WHEN_sending_testRun_as_json("CRsuite", TestRunStatuses.Running);
            WHEN_sending_testRun_as_json("CRsuite", TestRunStatuses.Running);
            
            THEN_there_should_be_the_following_number_of_testRun_objects(5);
            THEN_testRun_is_completed(TestRunQueue.TestRuns[0]);
            THEN_testRun_is_running(TestRunQueue.TestRuns[1]);
            THEN_testRun_is_pending(TestRunQueue.TestRuns[2]);
            THEN_testRun_is_pending(TestRunQueue.TestRuns[3]);
            THEN_testRun_is_pending(TestRunQueue.TestRuns[4]);
        }
        
        [Test][NUnit.Framework.Test]// [Fact]
        [MbUnit.Framework.Ignore][NUnit.Framework.Ignore]
        public void Should_return_testRun_as_json()
        {
            GIVEN_first_testWorkflow();
            
            WHEN_sending_testRun_as_json("CRsuite", TestRunStatuses.Running);
            TaskPool.TasksForClients.ForEach(task => task.TaskStatus = TestTaskStatuses.Canceled);
            TestRunQueue.TestRuns.ForEach(testRun => testRun.Status = TestRunStatuses.CompletedSuccessfully);
            WHEN_getting_testRun(0);
            
            THEN_response_has_testRun_id(0);
        }

        [Test][NUnit.Framework.Test]// [Fact]
        [MbUnit.Framework.Ignore][NUnit.Framework.Ignore]
        public void Should_return_all_testRuns_as_json()
        {
            //GIVEN_first_testWorkflow();

            //WHEN_sending_testRun_as_json("CRsuite", TestRunStatuses.Running);
            //TaskPool.TasksForClients.ForEach(task => task.TaskStatus = TestTaskStatuses.Canceled);
            //TestRunQueue.TestRuns.ForEach(testRun => testRun.Status = TestRunStatuses.CompletedSuccessfully);
            //WHEN_getting_testRun(0);

            //THEN_response_has_testRun_id(0);
        }
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_add_one_task_to_the_common_pool_on_imporing_one_task()
//        {
//            Xunit.Assert.Equal(0, 1);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_add_all_tasks_to_the_common_pool_on_importing_several_tasks()
//        {
//            Xunit.Assert.Equal(0, 1);
//        }
//        
//        // ==========================================================================================
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_add_one_task_to_one_client_pool()
//        {
//            Xunit.Assert.Equal(0, 1);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_add_all_tasks_to_one_client_pool()
//        {
//            Xunit.Assert.Equal(0, 1);
//        }
//        
//        // ==========================================================================================
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_add_one_task_to_all_client_pools()
//        {
//            Xunit.Assert.Equal(0, 1);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_add_all_tasks_to_all_client_pools()
//        {
//            Xunit.Assert.Equal(0, 1);
//        }
//        
//        // ==========================================================================================
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_add_no_tasks_to_not_matching_client_pools()
//        {
//            Xunit.Assert.Equal(0, 1);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_add_one_task_to_matching_client_pools()
//        {
//            Xunit.Assert.Equal(0, 1);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_add_all_tasks_to_matching_client_pools()
//        {
//            Xunit.Assert.Equal(0, 1);
//        }
        
        void GIVEN_first_testWorkflow()
        {
            GIVEN_first_testWorkflow(TestConstants.Workflow01);
        }
        
        void GIVEN_first_testWorkflow(string alternativeName)
        {
            var serverCommand = new ServerCommand {
                Command = ServerControlCommands.LoadConfiguraiton,
                Data = alternativeName
            };
            _browser.Put(UrlList.ServerControlPoint_absPath, with => {
                with.JsonBody<ServerCommand>(serverCommand);
                with.Accept("application/json");
            });
        }
        
        void GIVEN_second_testWorkflow()
        {
            var serverCommand = new ServerCommand {
                Command = ServerControlCommands.LoadConfiguraiton,
                Data = TestConstants.Workflow02
            };
            _browser.Put(UrlList.ServerControlPoint_absPath, with => {
                with.JsonBody<ServerCommand>(serverCommand);
                with.Accept("application/json");
            });
        }
        
        // TestRunCommand WHEN_sending_testRun_as_json(string testWorkflowName, TestRunStatuses status)
        void WHEN_sending_testRun_as_json(string testWorkflowName, TestRunStatuses status)
        {
            var testRunCommand = new TestRunCommand { WorkflowName = testWorkflowName, Status = status };
            // 20150825
            // return WHEN_sending_testRun_as_json(testWorkflowName, status, UrlList.TestRunsControlPoint_absPath, testRunCommand);
            WHEN_sending_testRun_as_json(testWorkflowName, status, UrlList.TestRunsControlPoint_absPath, testRunCommand);
        }
        
        // TestRunCommand WHEN_sending_testRun_as_json(string testWorkflowName, TestRunStatuses status, string alternativeUrl, ITestRunCommand testRunCommand)
        void WHEN_sending_testRun_as_json(string testWorkflowName, TestRunStatuses status, string alternativeUrl, ITestRunCommand testRunCommand)
        {
            var testRun = new TestRun();
            (testRun as TestRun).SetWorkflow(WorkflowCollection.Workflows.First(wfl => wfl.Name == testWorkflowName));
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
            // return _response.Body.DeserializeJson<TestRunCommand>();
        }
        
        void WHEN_getting_testRun(int numberOfTheTestRun)
        {
            _response = _browser.Get(UrlList.TestRunsControlPoint_absPath + TestRunQueue.TestRuns[numberOfTheTestRun].Id, with => with.Accept("application/json"));
        }
        
        void THEN_there_should_be_the_following_number_of_testRun_objects(int number)
        {
            Assert.Equal(number, TestRunQueue.TestRuns.Count);
        }
        
        void THEN_testRun_is_running(ITestRun testRun)
        {
            Assert.Equal(true, testRun.IsActive());
        }
        
        void THEN_testRun_is_pending(ITestRun testRun)
        {
            Assert.Equal(true, testRun.IsPending());
        }
        
        void THEN_testRun_is_completed(ITestRun testRun)
        {
            Assert.Equal(true, testRun.IsCompleted());
        }
        
        void THEN_testRun_id_is(Guid actualTestRunId)
        {
            Assert.Equal(_response.Headers[Tmx_Core_Resources.NewTestRun_lastTestRunId], actualTestRunId.ToString());
        }
        
        void THEN_response_has_testRun_id(int numberOfTestRunInTheQueue)
        {
            var testRun = _response.Body.DeserializeJson<TestRun>();
            // var testRun = _response.Body.Deserialize<TestRun>(new TestRunDeserializer());
            Assert.Equal(TestRunQueue.TestRuns[0].Id, testRun.Id);
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
