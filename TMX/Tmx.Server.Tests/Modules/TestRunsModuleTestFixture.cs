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
	using Tmx.Core.Types.Remoting;
	using Tmx.Interfaces.Remoting;
	using Tmx.Interfaces.Server;
	using Tmx.Server.Helpers.Objects;
	using Xunit;
	
	/// <summary>
	/// Description of TestRunsModuleTestFixture.
	/// </summary>
	[MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
	public class TestRunsModuleTestFixture
	{
	    // BrowserResponse _response;
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
		public void Should_create_first_testRun_object_as_json()
		{
			GIVEN_testWorkflow();
			
			WHEN_sending_testRun_as_json("CRsuite");
			
			THEN_there_should_be_the_following_number_of_testRun_objects(1);
		}
		
		void GIVEN_testWorkflow()
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
		
		void WHEN_sending_testRun_as_json(string testWorkflowName)
		{
			var testRun = new TestRun(WorkflowCollection.Workflows.First(wfl => wfl.Name == testWorkflowName));
			_browser.Post(UrnList.TestRunsControlPoint_absPath, with => {
				with.JsonBody(testRun);
				with.Accept("application/json");
			});
		}
		
		void THEN_there_should_be_the_following_number_of_testRun_objects(int number)
		{
			Xunit.Assert.Equal(number, TestRunQueue.TestRuns.Count);
		}
	}
}
