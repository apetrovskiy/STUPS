/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/8/2014
 * Time: 9:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Tests.UnitTestingHelpers
{
    using System.Linq;
    using Core.Types.Remoting;
    using Interfaces.Remoting;
    using Library.Modules;
    using Logic.ObjectModel.Objects;
    using Nancy.Testing;

    /// <summary>
    /// Description of TestFactory.
    /// </summary>
    public class TestFactory
    {
        public static Browser GetBrowserForTestClientsModule()
        {
            // 20160119
            // http://stackoverflow.com/questions/24776929/nancy-testing-seems-slow-is-there-anything-im-should-be-doing-to-improve-perfo/25745960#25745960
            return new Browser(with => with.Modules(typeof(TestClientsModule), typeof(ServerControlModule), typeof(TestRunsModule)));
            // return new Browser(with => with.Modules(typeof(TestClientsModule), typeof(ServerControlModule), typeof(TestRunsModule)).DisableAutoRegistrations());
        }
        
        public static Browser GetBrowserForTestTasksModule()
        {
            // 20160119
            return new Browser(with => with.Modules(typeof(TestTasksModule), typeof(TestClientsModule))); // , typeof(ServerControlModule), typeof(TestRunsModule)));
            // return new Browser(with => with.Modules(typeof(TestTasksModule), typeof(TestClientsModule)).DisableAutoRegistrations());
        }
        
        public static Browser GetBrowserForServerControlModule()
        {
            // 20160119
            return new Browser(with => with.Modules(typeof(ServerControlModule)));
            // return new Browser(with => with.Modules(typeof(ServerControlModule)).DisableAutoRegistrations());
        }
        
        public static Browser GetBrowserForTestRunsModule()
        {
            // 20160119
            return new Browser(with => with.Modules(typeof(TestRunsModule), typeof(ServerControlModule)));
            // return new Browser(with => with.Modules(typeof(TestRunsModule), typeof(ServerControlModule)).DisableAutoRegistrations());
        }
        
        public static Browser GetBrowserForTestResultsModule()
        {
            // 20160119
            return new Browser(with => with.Modules(typeof(TestResultsModule)));
            // return new Browser(with => with.Modules(typeof(TestResultsModule)).DisableAutoRegistrations());
        }
        
        public static Browser GetBrowserForTestDataModule()
        {
            // 20160119
            return new Browser(with => with.Modules(typeof(TestDataModule)));
            // return new Browser(with => with.Modules(typeof(TestDataModule)).DisableAutoRegistrations());
        }
        
        public static ITestClient GivenTestClient(string hostname, string username)
        {
            return new TestClient { Hostname = hostname, Username = username };
        }
        
        public static ITestRun GetTestRunWithStatus(TestRunStatuses status)
        {
            return GetTestRunWithStatus(status, "aaa_01");
        }
        
        public static ITestRun GetTestRunWithStatus(TestRunStatuses status, params string[] rules)
        {
            var workflow = new TestWorkflow(TestLabCollection.TestLabs.First()) { Name = "workflow 01" };
            workflow.SetTestLab(TestLabCollection.TestLabs.First());
            WorkflowCollection.Workflows.Add(workflow);
            var testRun = new TestRun { Name = "test run 03", Status = status };
            testRun.SetWorkflow(workflow);
            TestRunQueue.TestRuns.Add(testRun);
            var taskId = 0;
            if (null != rules)
                // 20150904
                rules.ToList().ForEach(rule => TaskPool.Tasks.Add(new TestTask { Id = ++taskId, Rule = rule, WorkflowId = workflow.Id, TestRunId = testRun.Id }));
                // rules.ToList().ForEach(rule => TaskPool.Tasks.Add(new TestTask (TestTaskRuntimeTypes.Powershell) { Id = ++taskId, Rule = rule, WorkflowId = workflow.Id, TestRunId = testRun.Id }));
            
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
