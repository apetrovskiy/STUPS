/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/27/2014
 * Time: 2:26 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Tests.Modules
{
	using System;
	using Nancy.Testing;
	using Tmx.Core.Types.Remoting;
	using Tmx.Interfaces.Server;
	using Tmx.Interfaces.Remoting;
	using Xunit;
	
	/// <summary>
	/// Description of ServerControlModuleTestFixture.
	/// </summary>
	[MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
	public class ServerControlModuleTestFixture
	{
	    // BrowserResponse _response;
	    Browser _browser;
		
		public ServerControlModuleTestFixture()
		{
			TestSettings.PrepareModuleTests();
            _browser = TestFactory.GetBrowserForServerControlModule();
		}
		
		[MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
		public void SetUp()
		{
			TestSettings.PrepareModuleTests();
            _browser = TestFactory.GetBrowserForServerControlModule();
		}
		
		[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
		public void Should_create_first_workflow_object_as_json()
		{
			var serverCommand = GIVEN_server_command(ServerControlCommands.LoadConfiguraiton, @"../../Modules/Workflow1.xml");
			
			WHEN_sending_server_command_as_json(serverCommand);
			
			THEN_there_should_be_the_following_number_of_workflow_objects(1);
		}
		
		[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
		public void Should_create_first_workflow_object_as_xml()
		{
			var serverCommand = GIVEN_server_command(ServerControlCommands.LoadConfiguraiton, @"../../Modules/Workflow1.xml");
			
			WHEN_sending_server_command_as_xml(serverCommand);
			
			THEN_there_should_be_the_following_number_of_workflow_objects(1);
		}
		
		[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
		public void Should_create_second_workflow_object_as_json()
		{
			var serverCommand01 = GIVEN_server_command(ServerControlCommands.LoadConfiguraiton, @"../../Modules/Workflow1.xml");
			GIVEN_sending_server_command(serverCommand01);
			var serverCommand02 = GIVEN_server_command(ServerControlCommands.LoadConfiguraiton, @"../../Modules/Workflow2.xml");
			
			WHEN_sending_server_command_as_json(serverCommand02);
			
			THEN_there_should_be_the_following_number_of_workflow_objects(2);
		}
		
		[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
		public void Should_create_second_workflow_object_as_xml()
		{
			var serverCommand01 = GIVEN_server_command(ServerControlCommands.LoadConfiguraiton, @"../../Modules/Workflow1.xml");
			GIVEN_sending_server_command(serverCommand01);
			var serverCommand02 = GIVEN_server_command(ServerControlCommands.LoadConfiguraiton, @"../../Modules/Workflow2.xml");
			
			WHEN_sending_server_command_as_xml(serverCommand02);
			
			THEN_there_should_be_the_following_number_of_workflow_objects(2);
		}
		
		ServerCommand GIVEN_server_command(ServerControlCommands commandType, string data)
		{
			return new ServerCommand {
				Command = commandType,
				Data = data
			};
		}
		
		void GIVEN_sending_server_command(ServerCommand serverCommand)
		{
			WHEN_sending_server_command_as_xml(serverCommand);
		}
		
		void WHEN_sending_server_command_as_json(ServerCommand serverCommand)
		{
			_browser.Put(UrlList.ServerControlPoint_absPath, with => {
				with.JsonBody<ServerCommand>(serverCommand);
				with.Accept("application/json");
			});
		}
		
		void WHEN_sending_server_command_as_xml(ServerCommand serverCommand)
		{
			_browser.Put(UrlList.ServerControlPoint_absPath, with => {
				with.JsonBody<ServerCommand>(serverCommand);
				with.Accept("application/xml");
			});
		}
		
		void THEN_there_should_be_the_following_number_of_workflow_objects(int number)
		{
			Xunit.Assert.Equal(number, WorkflowCollection.Workflows.Count);
		}
	}
}
