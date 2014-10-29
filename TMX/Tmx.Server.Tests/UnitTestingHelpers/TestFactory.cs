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
            return new Browser(with => with.Module(new TestResultsModule()));
        }
        
        public static Browser GetBrowserForTestDataModule()
        {
            return new Browser(with => with.Module(new TestDataModule()));
        }
        
        public static ITestClient GivenTestClient(string hostname, string username) //, int testRunId)
        {
            // return new TestClient { Hostname = hostname, Username = username, TestRunId = testRunId };
            return new TestClient { Hostname = hostname, Username = username };
        }
        
        public static ITestRun GetTestRunWithStatus(TestRunStatuses status)
        {
            int maxWorkflowId = 0 < WorkflowCollection.Workflows.Count ? WorkflowCollection.Workflows.Max(w => w.Id) : 0;
            var workflow = new TestWorkflow {
                Id = ++maxWorkflowId,
                Name = "workflow 01",
                TestLabId = TestLabCollection.TestLabs.First().Id
            };
            WorkflowCollection.Workflows.Add(workflow);
            int maxTestRunId = 0 < TestRunQueue.TestRuns.Count ? TestRunQueue.TestRuns.Max(tr => tr.Id) : 0;
            var testRun = new TestRun {
                Id = ++maxTestRunId,
                Name = "test run 03",
                TestLabId = TestLabCollection.TestLabs.First().Id
            };
            testRun.Status = status;
            testRun.SetWorkflow(workflow);
            TestRunQueue.TestRuns.Add(testRun);
            return testRun;
        }
    }
}
