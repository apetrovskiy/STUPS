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
    using System.Management.Automation;
    using Nancy;
    using Nancy.Testing;
    using MbUnit.Framework;
    using NUnit.Framework;
	using Tmx;
	using Tmx.Interfaces;
	using Tmx.Interfaces.Remoting;
	using Tmx.Interfaces.TestStructure;
	using Tmx.Interfaces.Types.Remoting;
    using Xunit;
    using Tmx;
    using PSTestLib;
    
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
        public void Should_provide_a_task_to_a_test_client()
        {
        	// Given
            var browser = new Browser(new DefaultNancyBootstrapper());
            var clientInformation = new TestClientInformation {
                Hostname = "h",
                OsVersion = "w",
                Username = "u"
            };
            var testTask = new TestTask {
                Id = 1,
                IsActive = true,
                Completed = false,
                Name = "task name" 
            };
            TaskPool.Tasks.Add(testTask);
            
            // When
            var response = browser.Post(UrnList.TestClients_Root + UrnList.TestClients_Clients, (with) => {
                with.JsonBody<IClientInformation>(clientInformation);
            });
            var registeredClient = response.Body.DeserializeJson<TestClientInformation>();
            response = browser.Get(UrnList.TestTasks_Root + "/" + registeredClient.Id);
            var task = response.Body.DeserializeJson<TestTask>();
            
            // Then
            Xunit.Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Xunit.Assert.Equal(testTask.Id, task.Id);
            Xunit.Assert.Equal(testTask.IsActive, task.IsActive);
            Xunit.Assert.Equal(testTask.Completed, task.Completed);
            Xunit.Assert.Equal(testTask.Name, task.Name);
            // Xunit.Assert.Equal(testTask.Name, clientsetting
        }
	}
}
