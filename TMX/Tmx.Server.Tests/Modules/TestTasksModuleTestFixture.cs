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
    using System.Management.Automation;
    using System.Threading.Tasks;
	using Gallio.Model.Filters;
    using Nancy;
    using Nancy.Testing;
    using MbUnit.Framework;
    using NUnit.Framework;
	using Tmx.Interfaces.Server;
	using Tmx.Client;
	using Tmx.Core;
	using Tmx.Core.Types.Remoting;
	using Tmx.Interfaces;
	using Tmx.Interfaces.Remoting;
	using Tmx.Interfaces.TestStructure;
	using Tmx.Server.Modules;
    using Xunit;
    using PSTestLib;
    using Xunit.Extensions;
    
	/// <summary>
	/// Description of TestTasksModuleTestFixture.
	/// </summary>
	[MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
	public class TestTasksModuleTestFixture
	{
		public TestTasksModuleTestFixture()
		{
		    TestSettings.PrepareModuleTests();
		}
        
    	[MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
    	public void SetUp()
    	{
    	    TestSettings.PrepareModuleTests();
    	}
    	
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_provide_a_task_to_test_client_if_the_client_matches_the_rule()
        {
            // Given
            var browser = TestFactory.GetBrowserForTestTasksModule();
			const string testClientHostnameExpected = "testhost";
			const string testClientUsernameExpected = "aaa";
			var expectedTask = GIVEN_Loaded_TestTask(5, "task name", false, TestTaskStatuses.New, true, testClientHostnameExpected, 0);
			var testClient = GIVEN_Registered_TestClient(testClientHostnameExpected, testClientUsernameExpected);
			
			// When
            var response = browser.Get(UrnList.TestTasks_Root + "/" + testClient.Id, with => with.Accept("application/json"));
            var actualTask = response.Body.DeserializeJson<TestTask>();
            
            // Then
            THEN_HttpResponse_Is_Ok(response);
            THEN_TestTask_Properties_Equal_To(expectedTask, actualTask);
            THEN_test_client_is_busy(ClientsCollection.Clients.First(client => client.Id == testClient.Id));
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_provide_no_task_to_test_client_if_the_client_does_not_match_the_rule()
        {
        	// Given
            var browser = TestFactory.GetBrowserForTestTasksModule();
			const string testClientHostnameExpected = "testhost";
			const string testClientUsernameExpected = "aaa";
			var givenTask = GIVEN_Loaded_TestTask(5, "task name", false, TestTaskStatuses.New, true, "no matches", 0);
			var testClient = GIVEN_Registered_TestClient(testClientHostnameExpected, testClientUsernameExpected);
            
            // When
            var response = browser.Get(UrnList.TestTasks_Root + "/" + testClient.Id, with => with.Accept("application/json"));
            
            // Then
            THEN_HttpResponse_Is_NotFound(response);
            THEN_test_client_is_free(testClient);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_provide_the_second_task_if_the_client_matches_the_rule()
        {
        	// Given
            var browser = TestFactory.GetBrowserForTestTasksModule();
            var givenTask01 = GIVEN_Loaded_TestTask(1, "task name", false, TestTaskStatuses.New, true, ".*h.*", 0);
            var givenTask02 = GIVEN_Loaded_TestTask(2, "task name 02", false, TestTaskStatuses.New, true, "u", 0);
            var registeredClient = GIVEN_Registered_TestClient("h", "u");
            
            // When
            var clientSettings = ClientSettings.Instance;
            clientSettings.ServerUrl = @"http://localhost:12340";
            clientSettings.StopImmediately = false;
            
            clientSettings.ClientId = registeredClient.Id;
            clientSettings.StopImmediately = false;
            
            var taskLoader = new TaskLoader(new RestRequestCreator());
            
            var response = browser.Get(UrnList.TestTasks_Root + "/" + registeredClient.Id, with => with.Accept("application/json"));
            var actualTask = response.Body.DeserializeJson<TestTask>();
            actualTask.TaskStatus = TestTaskStatuses.Accepted;
            response = browser.Put(UrnList.TestTasks_Root + "/" + actualTask.Id, with => with.JsonBody<ITestTask>(actualTask));
            var taskUpdater = new TaskUpdater(new RestRequestCreator());
            response = browser.Put(UrnList.TestTasks_Root + "/" + actualTask.Id, with => with.JsonBody<ITestTask>(actualTask));
            
            actualTask.TaskStatus = TestTaskStatuses.CompletedSuccessfully;
            actualTask.TaskFinished = true;
            response = browser.Put(UrnList.TestTasks_Root + "/" + actualTask.Id, with => with.JsonBody<ITestTask>(actualTask));
            response = browser.Get(UrnList.TestTasks_Root + "/" + registeredClient.Id, with => {
                with.Accept("application/json");
                with.JsonBody<ITestTask>(actualTask);
            });
            actualTask = response.Body.DeserializeJson<TestTask>();
            
            // Then
            THEN_HttpResponse_Is_Ok(response);
            THEN_TestTask_Properties_Equal_To(givenTask02, actualTask);
            THEN_test_client_is_busy(ClientsCollection.Clients.First(client => client.Id == registeredClient.Id));
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_not_provide_the_second_task_if_the_client_does_not_match_the_rule()
        {
        	// Given
            var browser = TestFactory.GetBrowserForTestTasksModule();
            var givenTask01 = GIVEN_Loaded_TestTask(1, "task name", false, TestTaskStatuses.New, true, ".*h.*", 0);
            var givenTask02 = GIVEN_Loaded_TestTask(2, "task name 02", false, TestTaskStatuses.New, true, "aaa", 0);
            var registeredClient = GIVEN_Registered_TestClient("h", "u");
            
            // When
            var response = browser.Get(UrnList.TestTasks_Root + "/" + registeredClient.Id, with => with.Accept("application/json"));
            var actualTask = response.Body.DeserializeJson<TestTask>();
            actualTask.TaskStatus = TestTaskStatuses.Accepted;
            response = browser.Put(UrnList.TestTasks_Root + "/" + actualTask.Id, with => {
                                   	with.JsonBody<ITestTask>(actualTask);
                                   	with.Accept("application/json");
                                   });
            actualTask.TaskStatus = TestTaskStatuses.CompletedSuccessfully;
            actualTask.TaskFinished = true;
            response = browser.Put(UrnList.TestTasks_Root + "/" + actualTask.Id, with => with.JsonBody<ITestTask>(actualTask));
            response = browser.Get(UrnList.TestTasks_Root + "/" + registeredClient.Id, with => with.Accept("application/json"));
            
            // Then
            THEN_HttpResponse_Is_NotFound(response);
        }
        
    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_provide_the_second_task_if_the_client_matches_the_rule_and_there_are_several()
        {
        	// Given
            var browser = TestFactory.GetBrowserForTestTasksModule();
            var givenTask01 = GIVEN_Loaded_TestTask(1, "task name", false, TestTaskStatuses.New, true, ".*h.*", 0);
            var givenTask02 = GIVEN_Loaded_TestTask(2, "task name", false, TestTaskStatuses.New, true, ".*aaa.*", 0);
            var givenTask03 = GIVEN_Loaded_TestTask(3, "task name 02", false, TestTaskStatuses.New, true, "u", 0);
            var givenTask04 = GIVEN_Loaded_TestTask(4, "task name", false, TestTaskStatuses.New, true, ".*aaa.*", 0);
            var registeredClient = GIVEN_Registered_TestClient("h", "u");
            
            // When
            var response = browser.Get(UrnList.TestTasks_Root + "/" + registeredClient.Id, with => with.Accept("application/json"));
            var actualTask = response.Body.DeserializeJson<TestTask>();
            actualTask.TaskStatus = TestTaskStatuses.Accepted;
            response = browser.Put(UrnList.TestTasks_Root + "/" + actualTask.Id, with => {
                                   	with.JsonBody<ITestTask>(actualTask);
                                   	with.Accept("application/json");
                                   });
            actualTask.TaskStatus = TestTaskStatuses.CompletedSuccessfully;
            actualTask.TaskFinished = true;
            response = browser.Put(UrnList.TestTasks_Root + "/" + actualTask.Id, with => {
                                   	with.JsonBody<ITestTask>(actualTask);
                                   	with.Accept("application/json");
                                   });
            response = browser.Get(UrnList.TestTasks_Root + "/" + registeredClient.Id, with => with.Accept("application/json"));
            actualTask = response.Body.DeserializeJson<TestTask>();
            
            // Then
            THEN_HttpResponse_Is_Ok(response);
            THEN_TestTask_Properties_Equal_To(givenTask03, actualTask);
            Xunit.Assert.Equal(givenTask03.Id, TaskPool.TasksForClients.OrderBy(t => t.Id).Skip(1).First().Id);
            THEN_test_client_is_busy(ClientsCollection.Clients.First(client => client.Id == registeredClient.Id));
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_not_provide_the_second_task_if_the_client_does_not_match_the_rule_and_there_are_several()
        {
        	// Given
            var browser = TestFactory.GetBrowserForTestTasksModule();
            var givenTask01 = GIVEN_Loaded_TestTask(1, "task name", false, TestTaskStatuses.New, true, ".*h.*", 0);
            var givenTask02 = GIVEN_Loaded_TestTask(2, "task name", false, TestTaskStatuses.New, true, ".*aaa.*", 0);
            var givenTask03 = GIVEN_Loaded_TestTask(3, "task name 02", false, TestTaskStatuses.New, true, "aaa", 0);
            var givenTask04 = GIVEN_Loaded_TestTask(4, "task name 02", false, TestTaskStatuses.New, true, "aaa", 0);
            var registeredClient = GIVEN_Registered_TestClient("h", "u");
            
            // When
            var response = browser.Get(UrnList.TestTasks_Root + "/" + registeredClient.Id, with => with.Accept("application/json"));
            var task = response.Body.DeserializeJson<TestTask>();
            task.TaskStatus = TestTaskStatuses.Accepted;
            response = browser.Put(UrnList.TestTasks_Root + "/" + task.Id, with => {
                                   	with.JsonBody<ITestTask>(task);
                                   	with.Accept("application/json");
                                   });
            task.TaskStatus = TestTaskStatuses.CompletedSuccessfully;
            task.TaskFinished = true;
            response = browser.Put(UrnList.TestTasks_Root + "/" + task.Id, with => {
                                   	with.JsonBody<ITestTask>(task);
                                   	with.Accept("application/json");
                                   });
            response = browser.Get(UrnList.TestTasks_Root + "/" + registeredClient.Id, with => with.Accept("application/json"));
            
            // Then
            THEN_HttpResponse_Is_NotFound(response);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_cancel_all_further_tasks_on_fail()
        {
            
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
        [Xunit.Extensions.Theory]
        [InlineData("testHost001", "user001")]
        [InlineData("testHost002", "user002")]
        [InlineData("testHost003", "user003")]
//        [TestCase("testHost001", "user000")]
//        [TestCase("testHost002", "user002")]
//        [TestCase("testHost003", "user003")]
        // public void Should_not_provide_a_task_before_task_this_depends_on_is_completed() //string hostname, string username)
        public void Should_not_provide_a_task_before_task_this_depends_on_is_completed<T1, T2>(T1 hostname, T2 username)
        {
        	// Given
            var browser = TestFactory.GetBrowserForTestTasksModule();
//            const string testClientHostnameExpected = "testhost";
//            const string testClientUsernameExpected = "aaa";
            string testClientHostnameExpected = hostname.ToString();
            string testClientUsernameExpected = username.ToString();
//            if ("user003" == username.ToString())
//                // Xunit.Assert.Equal(1, 2);
//                NUnit.Framework.Assert.AreEqual(1, 2);
//            else
//                NUnit.Framework.Assert.AreEqual(2, 3);
            
			var givenTask01 = GIVEN_Loaded_TestTask(4, "task name", false, TestTaskStatuses.New, true, "another rule", 0);
            var givenTask02 = GIVEN_Loaded_TestTask(5, "task name", false, TestTaskStatuses.New, true, testClientHostnameExpected, 4);
            var registeredClient = GIVEN_Registered_TestClient(testClientHostnameExpected, testClientUsernameExpected);
			
            // When
            var response = browser.Get(UrnList.TestTasks_Root + "/" + registeredClient.Id, with => with.Accept("application/json"));
            var actualTask = response.Body.DeserializeJson<TestTask>();
            
            // Then
            THEN_TestTask_Is_Null(actualTask);
            THEN_test_client_is_free(registeredClient);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_not_provide_a_task_before_task_this_depends_on_is_allocated()
        {
        	// Given
            var browser = TestFactory.GetBrowserForTestTasksModule();
			const string testClientHostnameExpected = "testhost";
			const string testClientUsernameExpected = "aaa";
            
            var givenTask = GIVEN_Loaded_TestTask(5, "task name", false, TestTaskStatuses.New, true, testClientHostnameExpected, 4);
            var registeredClient = GIVEN_Registered_TestClient(testClientHostnameExpected, testClientUsernameExpected);
			
            // When
            var response = browser.Get(UrnList.TestTasks_Root + "/" + registeredClient.Id, with => with.Accept("application/json"));
            var loadedTask = response.Body.DeserializeJson<TestTask>();
            
            // Then
            THEN_TestTask_Is_Null(loadedTask);
            THEN_test_client_is_free(registeredClient);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_provide_a_task_only_after_task_this_depends_on_is_completed()
        {
        	// Given
            var browser = TestFactory.GetBrowserForTestTasksModule();
			const string testClientHostnameExpected = "testhost";
			const string testClientUsernameExpected = "aaa";
            var givenTask01 = GIVEN_Allocated_TestTask(4, "task name", true, TestTaskStatuses.CompletedSuccessfully, true, "another rule", 0);
            var givenTask02 = GIVEN_Loaded_TestTask(5, "task name", false, TestTaskStatuses.New, true, testClientHostnameExpected, 4);
            var registeredClient = GIVEN_Registered_TestClient(testClientHostnameExpected, testClientUsernameExpected);
			
            // When
            var response = browser.Get(UrnList.TestTasks_Root + "/" + registeredClient.Id, with => with.Accept("application/json"));
            var actualTask = response.Body.DeserializeJson<TestTask>();
            
            // Then
            THEN_HttpResponse_Is_Ok(response);
            THEN_TestTask_Properties_Equal_To(givenTask02, actualTask);
            THEN_test_client_is_busy(ClientsCollection.Clients.First(client => client.Id == registeredClient.Id));
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_provide_no_task_to_unregistered_test_client()
        {
        	// Given
            var browser = TestFactory.GetBrowserForTestTasksModule();
			const string testClientHostnameExpected = "testhost";
			const string testClientUsernameExpected = "aaa";
            var givenTask01 = GIVEN_Loaded_TestTask(5, "task name", false, TestTaskStatuses.New, true, "no matches", 0);
            var registeredClient = GIVEN_Registered_TestClient(testClientHostnameExpected, testClientUsernameExpected);
			
            // When
            WHEN_SendingDeregistration_as_json(registeredClient);
            var response = browser.Get(UrnList.TestTasks_Root + "/" + 0, with => with.Accept("application/json"));
            
            // Then
            // THEN_HttpResponse_Is_NotFound(response);
            THEN_HttpResponse_Is_ExpectationFailed(response);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_complete_the_current_task_on_client_unregistration()
        {
            // TODO: do it!
//        	// Given
//            var browser = TestFactory.GetBrowserForTestTasksModule();
//			const string testClientHostnameExpected = "testhost";
//			const string testClientUsernameExpected = "aaa";
//            var testClient = new TestClient { Hostname = testClientHostnameExpected, Username = testClientUsernameExpected };
//            var task = new TestTask {
//            	Id = 5,
//            	Name = "task name",
//            	TaskFinished = false,
//            	IsActive = true,
//            	TaskStatus = TestTaskStatuses.New,
//            	Rule = "no matches"
//            };
//			TaskPool.Tasks.Add(task);
//            
//            // When
//            var response = browser.Post(UrnList.TestClientRegistrationPoint, with => with.JsonBody<ITestClient>(testClient));
//            testClient = response.Body.DeserializeJson<TestClient>();
//            WHEN_SendingDeregistration(testClient);
//            response = browser.Get(UrnList.TestTasks_Root + "/" + 0);
//            
//            // Then
//            THEN_HttpResponse_Is_NotFound(response);
        }
        
        // ============================================================================================================================
        ITestClient GIVEN_Registered_TestClient(string hostname, string username)
        {
            var browser = TestFactory.GetBrowserForTestTasksModule();
            var testClient = new TestClient { Hostname = hostname, Username = username };
            var response = browser.Post(UrnList.TestClientRegistrationPoint, with => {
                                        	with.JsonBody<ITestClient>(testClient);
                                        	with.Accept("application/json");
                                        });
            return response.Body.DeserializeJson<TestClient>();
        }
        
        ITestTask GIVEN_Loaded_TestTask(int id, string taskName, bool finished, TestTaskStatuses status, bool isActive, string rule, int afterTask)
        {
            var task = new TestTask {
            	Id = id,
            	Name = taskName,
            	TaskFinished = finished,
            	IsActive = isActive,
            	TaskStatus = status,
            	Rule = rule,
            	AfterTask = afterTask
            };
			TaskPool.Tasks.Add(task);
			return task;
        }
        
        ITestTask GIVEN_Allocated_TestTask(int id, string taskName, bool finished, TestTaskStatuses status, bool isActive, string rule, int afterTask)
        {
            var task = new TestTask {
            	Id = id,
            	Name = taskName,
            	TaskFinished = finished,
            	IsActive = isActive,
            	TaskStatus = status,
            	Rule = rule,
            	AfterTask = afterTask
            };
			TaskPool.TasksForClients.Add(task);
			return task;
        }
        
        // TODO: duplicated
        void WHEN_SendingDeregistration_as_json(ITestClient testClient)
        {
            var browser = TestFactory.GetBrowserForTestTasksModule();
            browser.Delete(UrnList.TestClients_Root + "/" + testClient.Id, with => with.Accept("application/json"));
        }
        
        void WHEN_SendingDeregistration_as_xml(TestClient testClient)
        {
            var browser = TestFactory.GetBrowserForTestTasksModule();
            browser.Delete(UrnList.TestClients_Root + "/" + testClient.Id, with => with.Accept("application/xml"));
        }
        
        void THEN_HttpResponse_Is_Ok(BrowserResponse response)
        {
            Xunit.Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        
        void THEN_HttpResponse_Is_NotFound(BrowserResponse response)
        {
            Xunit.Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        
        void THEN_HttpResponse_Is_ExpectationFailed(BrowserResponse response)
        {
            Xunit.Assert.Equal(HttpStatusCode.ExpectationFailed, response.StatusCode);
        }
        
        void THEN_TestTask_Properties_Equal_To(ITestTask expectedTask, ITestTask actualTask)
        {
            Xunit.Assert.Equal(expectedTask.Id, actualTask.Id);
            Xunit.Assert.Equal(expectedTask.Name, actualTask.Name);
            Xunit.Assert.Equal(expectedTask.TaskStatus, actualTask.TaskStatus);
            Xunit.Assert.Equal(expectedTask.TaskFinished, actualTask.TaskFinished);
            Xunit.Assert.Equal(expectedTask.IsActive, actualTask.IsActive);
        }
        
        void THEN_TestTask_Is_Null(ITestTask task)
        {
            Xunit.Assert.Equal(null, task);
        }
        
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
