/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/27/2014
 * Time: 8:46 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using Nancy;
    using Nancy.ModelBinding;
    using Tmx.Interfaces.Server;
    using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of ViewsTestRunsModule.
    /// </summary>
    public class ViewsTestRunsModule : NancyModule
    {
        public ViewsTestRunsModule() : base(UrnList.ViewTestRuns_Root)
        {
            Get[UrnList.ViewTestRuns_NewTestRunPage] = _ => {
                dynamic data = new ExpandoObject();
                data.Workflows = WorkflowCollection.Workflows ?? new List<ITestWorkflow>();
                data.TestLabs = TestLabCollection.TestLabs ?? new List<ITestLab>();
                return View[UrnList.ViewTestRuns_NewTestRunPageName, data];
            };
            
            Get[UrnList.ViewTestRuns_TestRun_CancelPage] = parameters => {
                dynamic data = new ExpandoObject();
                data.TestRun = TestRunQueue.TestRuns.FirstOrDefault(testRun => testRun.Id == parameters.id);
                return View[UrnList.ViewTestRuns_TestRun_CancelPageName, data];
            };
            
            Post[UrnList.ViewTestRuns_TestRun_CancelPage] = parameters => {
                var testRunSelector = new TestRunSelector();
                testRunSelector.CancelTestRun(TestRunQueue.TestRuns.FirstOrDefault(testRun => testRun.Id == parameters.id));
                return View[UrnList.ViewTestRuns_TestRun_CancelPageName];
            };
            
            Get [UrnList.ViewTestRuns_ParametersPage] = parameters => {
                dynamic data = new ExpandoObject();
                data.TestRun = TestRunQueue.TestRuns.First(testRun => testRun.Id == parameters.id);
                return View[UrnList.ViewTestRuns_ParametersPageName, data];
            };
            
            Get [UrnList.ViewTestRuns_ClientsPage] = parameters => {
                dynamic data = new ExpandoObject();
                data.Clients = ClientsCollection.Clients.Where(client => client.TestRunId == parameters.id).ToList() ?? new List<ITestClient>();
                return View[UrnList.ViewTestRuns_ClientsPageName, data];
            };
            
            Get [UrnList.ViewTestRuns_TasksPage] = parameters => {
                dynamic data = new ExpandoObject();
                data.TasksForClients = TaskPool.TasksForClients.Where(task => task.TestRunId == parameters.id).ToList() ?? new List<ITestTask>();
                return View[UrnList.ViewTestRuns_TasksPageName, data];
            };
            
            Get[UrnList.ViewTestRuns_ResultsPage] = parameters => {
                dynamic data = new ExpandoObject();
                data.TestRun = TestRunQueue.TestRuns.First(testRun => testRun.Id == parameters.id);
                return View[UrnList.ViewTestRuns_ResultsPageName, data];
            };
        }
    }
}
