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
	using TMX.Interfaces.Server;
	using Tmx.Interfaces;
	using Tmx.Interfaces.Remoting;
	using Tmx.Interfaces.TestStructure;
	using Tmx.Interfaces.Types.Remoting;
    using Xunit;
    using PSTestLib;
    
    /// <summary>
    /// Description of TestClientsModuleTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class TestClientsModuleTestFixture
    {
        public TestClientsModuleTestFixture()
        {
            TestSettings.PrepareModuleTests();
        }
        
    	[MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
    	public void SetUp()
    	{
    	    TestSettings.PrepareModuleTests();
    	}
    	
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_send_response_on_registering_a_new_test_client()
        {
        	// Given
            var browser = new Browser(new DefaultNancyBootstrapper());
            var clientInformation = new TestClientInformation {
                Hostname = "h",
                OsVersion = "w",
                Username = "u"
            };
            
            // When
            var response = browser.Post(UrnList.TestClients_Root + UrnList.TestClients_Clients, (with) => {
                with.JsonBody<IClientInformation>(clientInformation);
            });
            
            // Then
            Xunit.Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_register_the_first_test_client_and_set_id()
        {
        	// Given
            var browser = new Browser(new DefaultNancyBootstrapper());
            var testClientHostnameExpected = "testhost";
            var testClientUsernameExpected = "aaa";
            var testClientIdExpected = 1;
            var clientInformation = new TestClientInformation { Hostname = testClientHostnameExpected, Username = testClientUsernameExpected };
            
            // When
            var response = browser.Post(UrnList.TestClients_Root + UrnList.TestClients_Clients, (with) => {
                with.JsonBody<IClientInformation>(clientInformation);
            });
            
            // Then
            Xunit.Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Xunit.Assert.Equal(testClientHostnameExpected, ClientsCollection.Clients[0].Hostname);
            Xunit.Assert.Equal(testClientUsernameExpected, ClientsCollection.Clients[0].Username);
            Xunit.Assert.Equal(testClientIdExpected, ClientsCollection.Clients[0].Id);
            Xunit.Assert.Equal(testClientIdExpected, response.Body.DeserializeJson<TestClientInformation>().Id);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_provide_a_task_to_test_client()
        {
        	// Given
            var browser = new Browser(new DefaultNancyBootstrapper());
            var testClientHostnameExpected = "testhost";
            var testClientUsernameExpected = "aaa";
            var clientInformation = new TestClientInformation { Hostname = testClientHostnameExpected, Username = testClientUsernameExpected };
            var task = new TestTask {
            	Id = 5,
            	Name = "task name",
            	Completed = false,
            	IsActive = true,
            	Status = TestTaskStatuses.New
            };
			TaskPool.Tasks.Add(task);
            
            // When
            var response = browser.Post(UrnList.TestClients_Root + UrnList.TestClients_Clients, (with) => {
                with.JsonBody<IClientInformation>(clientInformation);
            });
            var testClient = response.Body.DeserializeJson<TestClientInformation>();
            response = browser.Get(UrnList.TestTasks_Root + "/" + testClient.Id);
            var loadedTask = response.Body.DeserializeJson<TestTask>();
            
            // Then
            Xunit.Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Xunit.Assert.Equal(task.Id, loadedTask.Id);
            Xunit.Assert.Equal(task.Name, loadedTask.Name);
            Xunit.Assert.Equal(task.Status, loadedTask.Status);
            Xunit.Assert.Equal(task.Completed, loadedTask.Completed);
            Xunit.Assert.Equal(task.IsActive, loadedTask.IsActive);
        }
    }
}
