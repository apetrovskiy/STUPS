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
	using System.Linq;
	using Nancy.Testing;
	using Tmx.Core;
	using Tmx.Core.Types.Remoting;
	using Tmx.Interfaces.Remoting;
	using Tmx.Interfaces.Server;
	using Xunit;
	
	/// <summary>
	/// Description of TestRunsModuleTestFixture.
	/// </summary>
	[MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
	public class TestRunsModuleTestFixture
	{
	    BrowserResponse _response;
	    Browser _browser;
		
		public TestRunsModuleTestFixture()
		{
			TestSettings.PrepareModuleTests();
            _browser = TestFactory.GetBrowserForTestRunsModule();
		}
		
		[MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
		public void SetUp()
		{
			TestSettings.PrepareModuleTests();
            _browser = TestFactory.GetBrowserForTestRunsModule();
		}
		
		[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
		public void Should_create_first_testRun_Running_as_json()
		{
			GIVEN_first_testWorkflow();
			
			WHEN_sending_testRun_as_json("CRsuite", TestRunStatuses.Running);
			
			THEN_there_should_be_the_following_number_of_testRun_objects(1);
			THEN_testRun_is_running(TestRunQueue.TestRuns[0]);
		}
		
		[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
		public void Should_create_second_testRun_object_to_another_workflow_and_another_testLab_Running_as_json()
		{
			GIVEN_first_testWorkflow();
			GIVEN_second_testWorkflow();
			var secondTestWorkflow = WorkflowCollection.Workflows.Skip(1).First();
			secondTestWorkflow.SetTestLab(new TestLab());
			
			WHEN_sending_testRun_as_json("CRsuite", TestRunStatuses.Running);
			WHEN_sending_testRun_as_json("NAC", TestRunStatuses.Running);
			
			THEN_there_should_be_the_following_number_of_testRun_objects(2);
			THEN_testRun_is_running(TestRunQueue.TestRuns[0]);
			THEN_testRun_is_running(TestRunQueue.TestRuns[1]);
		}
		
		[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
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
		
		[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
		public void Should_create_second_testRun_object_to_the_same_testLab_and_the_same_workflow_Pending_as_json()
		{
		    GIVEN_first_testWorkflow();
			
			WHEN_sending_testRun_as_json("CRsuite", TestRunStatuses.Running);
			WHEN_sending_testRun_as_json("CRsuite", TestRunStatuses.Running);
			
			THEN_there_should_be_the_following_number_of_testRun_objects(2);
			THEN_testRun_is_running(TestRunQueue.TestRuns[0]);
			THEN_testRun_is_pending(TestRunQueue.TestRuns[1]);
		}
		
		[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
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
		
		[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
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
		
		[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
		public void Should_run_only_one_testRun_after_interruption_of_the_previous_one_as_json()
		{
		    GIVEN_first_testWorkflow();
			
			WHEN_sending_testRun_as_json("CRsuite", TestRunStatuses.Running);
			TaskPool.TasksForClients.ForEach(task => task.TaskStatus = TestTaskStatuses.Interrupted);
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
		
		[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
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
		
//    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//    	public void Should_add_one_task_to_the_common_pool_on_imporing_one_task()
//    	{
//    	    Xunit.Assert.Equal(0, 1);
//    	}
//    	
//    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//    	public void Should_add_all_tasks_to_the_common_pool_on_importing_several_tasks()
//    	{
//    	    Xunit.Assert.Equal(0, 1);
//    	}
//    	
//    	// ==========================================================================================
//    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//    	public void Should_add_one_task_to_one_client_pool()
//    	{
//    	    Xunit.Assert.Equal(0, 1);
//    	}
//    	
//    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//    	public void Should_add_all_tasks_to_one_client_pool()
//    	{
//    	    Xunit.Assert.Equal(0, 1);
//    	}
//    	
//    	// ==========================================================================================
//    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//    	public void Should_add_one_task_to_all_client_pools()
//    	{
//    	    Xunit.Assert.Equal(0, 1);
//    	}
//    	
//    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//    	public void Should_add_all_tasks_to_all_client_pools()
//    	{
//    	    Xunit.Assert.Equal(0, 1);
//    	}
//    	
//    	// ==========================================================================================
//    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//    	public void Should_add_no_tasks_to_not_matching_client_pools()
//    	{
//    	    Xunit.Assert.Equal(0, 1);
//    	}
//    	
//    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//    	public void Should_add_one_task_to_matching_client_pools()
//    	{
//    	    Xunit.Assert.Equal(0, 1);
//    	}
//    	
//    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//    	public void Should_add_all_tasks_to_matching_client_pools()
//    	{
//    	    Xunit.Assert.Equal(0, 1);
//    	}
		
		void GIVEN_first_testWorkflow()
		{
			var serverCommand = new ServerCommand {
				Command = ServerControlCommands.LoadConfiguraiton,
				Data = @"../../Modules/Workflow1.xml"
			};
			_browser.Put(UrnList.ServerControlPoint_absPath, with => {
				with.JsonBody<ServerCommand>(serverCommand);
				with.Accept("application/json");
			});
		}
		
		void GIVEN_second_testWorkflow()
		{
			var serverCommand = new ServerCommand {
				Command = ServerControlCommands.LoadConfiguraiton,
				Data = @"../../Modules/Workflow2.xml"
			};
			_browser.Put(UrnList.ServerControlPoint_absPath, with => {
				with.JsonBody<ServerCommand>(serverCommand);
				with.Accept("application/json");
			});
		}
		
		TestRunCommand WHEN_sending_testRun_as_json(string testWorkflowName, TestRunStatuses status)
		{
		    var testRun = new TestRun();
			var testRunCommand = new TestRunCommand { WorkflowName = testWorkflowName, Status = status };
			(testRun as TestRun).SetWorkflow(WorkflowCollection.Workflows.First(wfl => wfl.Name == testWorkflowName));
			_response = _browser.Post(UrnList.TestRunsControlPoint_absPath, with => {
				with.JsonBody(testRunCommand);
				with.Accept("application/json");
			});
			return _response.Body.DeserializeJson<TestRunCommand>();
		}
		
		void THEN_there_should_be_the_following_number_of_testRun_objects(int number)
		{
			Xunit.Assert.Equal(number, TestRunQueue.TestRuns.Count);
		}
		
        void THEN_testRun_is_running(ITestRun testRun)
        {
            Xunit.Assert.Equal(true, testRun.IsActive());
        }
        
        void THEN_testRun_is_pending(ITestRun testRun)
        {
            Xunit.Assert.Equal(true, testRun.IsPending());
        }
        
        void THEN_testRun_is_completed(ITestRun testRun)
        {
        	Xunit.Assert.Equal(true, testRun.IsCompleted());
        }
	}
}
