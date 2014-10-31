/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/8/2014
 * Time: 9:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Tests
{
    using System;
    using System.Linq;
    using Nancy;
    using Nancy.Testing;
	using Tmx.Core;
    using Tmx.Core.Types.Remoting;
	using Tmx.Interfaces.Remoting;
	using Tmx.Server.Modules;
    
    /// <summary>
    /// Description of TestFactory.
    /// </summary>
    public class TestFactory
    {
        public static Browser GetBrowserForTestClientsModule()
        {
            return new Browser(with => with.Module(new TestClientsModule()));
        }
        
        public static Browser GetBrowserForTestTasksModule()
        {
            return new Browser(with => with.Modules(typeof(TestClientsModule), typeof(TestTasksModule)));
        }
        
        public static Browser GetBrowserForServerControlModule()
        {
            return new Browser(with => with.Modules(typeof(ServerControlModule)));
        }
        
        public static Browser GetBrowserForTestRunsModule()
        {
        	return new Browser(with => with.Modules(typeof(TestRunsModule), typeof(ServerControlModule)));
        }
        
        public static Browser GetBrowserForTestResultsModule()
        {
            return new Browser(with => with.Modules(typeof(TestRunsModule), typeof(TestResultsModule)));
        }
        
        public static Browser GetBrowserForTestDataModule()
        {
            return new Browser(with => with.Module(new TestDataModule()));
        }
        
        public static ITestClient GivenTestClient(string hostname, string username)
        {
            return new TestClient { Hostname = hostname, Username = username };
        }
        
        public static ITestRun GetTestRunWithStatus(TestRunStatuses status)
        {
            var workflow = new TestWorkflow(TestLabCollection.TestLabs.First()) { Name = "workflow 01" };
            workflow.SetTestLab(TestLabCollection.TestLabs.First());
            WorkflowCollection.Workflows.Add(workflow);
            var testRun = new TestRun { Name = "test run 03", Status = status };
            testRun.SetWorkflow(workflow);
            TestRunQueue.TestRuns.Add(testRun);
            return testRun;
        }
        
        public static void GetAnotherTestRunWithStatus(TestRunStatuses status, ITestWorkflow workflow)
        {
            var testRun = new TestRun {
                Name = "test run the second",
                Status = status
            };
            testRun.SetWorkflow(workflow);
            TestRunQueue.TestRuns.Add(testRun);
        }
    }
}
