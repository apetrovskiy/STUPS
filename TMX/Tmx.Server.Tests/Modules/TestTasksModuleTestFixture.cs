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
        public void Should_react_on_registering_a_new_test_client()
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
                On = true,
                Completed = false,
                Name = "task name" 
            };
            TaskPool.Tasks.Add(testTask);
            
            // When
            var response = browser.Post(UrnList.TestClients_Root + UrnList.TestClients_Clients, (with) => {
                with.JsonBody<IClientInformation>(clientInformation);
            });
            var clientId = response.Body.DeserializeJson<IClientInformation>().Id;
            response = browser.Get(UrnList.TestTasks_Root + "/" + clientId);
            
            // Then
            Xunit.Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Xunit.Assert.Equal(testTask.Id, response.Body.DeserializeJson<ITestTask>().Id);
            Xunit.Assert.Equal(testTask.On, response.Body.DeserializeJson<ITestTask>().On);
            Xunit.Assert.Equal(testTask.Completed, response.Body.DeserializeJson<ITestTask>().Completed);
            Xunit.Assert.Equal(testTask.Name, response.Body.DeserializeJson<ITestTask>().Name);
        }
	}
}
