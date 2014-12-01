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
    using Tmx.Core;
    using Tmx.Interfaces.Server;
    using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of ViewsTestRunsModule.
    /// </summary>
    public class ViewsTestRunsModule : NancyModule
    {
        public ViewsTestRunsModule() : base(UrlList.ViewTestRuns_Root)
        {
            Get[UrlList.ViewTestRuns_NewTestRunPage] = _ => {
                var data = createNewTestRunExpandoObject(UrlList.ViewTestWorkflowParameters_Root + "/" + UrlList.ViewTestWorkflowParameters_DefaultPage, string.Empty);
                return View[UrlList.ViewTestRuns_NewTestRunPageName, data];
            };
            
            Post[UrlList.ViewTestRuns_NewTestRunPage] = _ => {
                string workflowName = Request.Form.workflow_name;
                var data = createNewTestRunExpandoObject("/workflows/" + WorkflowCollection.Workflows.FirstOrDefault(wfl => wfl.Name == workflowName).ParametersPageName, workflowName);
                return View[UrlList.ViewTestRuns_NewTestRunPageName, data];
            };
            
            Get[UrlList.ViewTestRuns_TestRunsPage] = parameters => {
                var data = createTestRunExpandoObject();
                return View[UrlList.ViewTestRuns_TestRunsPageName, data];
            };
            
            Get [UrlList.ViewTestRuns_ParametersPage] = parameters => {
                dynamic data = new ExpandoObject();
                // 20141130
                // data.TestRun = TestRunQueue.TestRuns.First(testRun => testRun.Id == parameters.id);
                data.TestRun = getCurrentTestRun(parameters.id);
                return View[UrlList.ViewTestRuns_ParametersPageName, data];
            };
            
            Get [UrlList.ViewTestRuns_ClientsPage] = parameters => {
                dynamic data = new ExpandoObject();
                // 20141130
                // data.Clients = ClientsCollection.Clients.Where(client => client.TestRunId == parameters.id).ToList() ?? new List<ITestClient>();
                data.Clients = (ClientsCollection.Clients.Where(client => client.TestRunId == parameters.id).ToList() ?? new List<ITestClient>()).ToArray();
                return View[UrlList.ViewTestRuns_ClientsPageName, data];
            };
            
            Get [UrlList.ViewTestRuns_TasksPage] = parameters => {
                dynamic data = new ExpandoObject();
                // 20141130
                // data.TasksForClients = TaskPool.TasksForClients.Where(task => task.TestRunId == parameters.id).ToList() ?? new List<ITestTask>();
                data.TasksForClients = (TaskPool.TasksForClients.Where(task => task.TestRunId == parameters.id).ToList() ?? new List<ITestTask>()).ToArray();
                return View[UrlList.ViewTestRuns_TasksPageName, data];
            };
            
            Get[UrlList.ViewTestRuns_ResultsPage] = parameters => {
                dynamic data = new ExpandoObject();
                
                // 20141130
                // var currentTestRun = TestRunQueue.TestRuns.First(testRun => testRun.Id == parameters.id);
                ITestRun currentTestRun = getCurrentTestRun(parameters.id);
                var testStatistics = new TestStatistics();
                testStatistics.RefreshAllStatistics(currentTestRun.TestSuites, true);
                // data.TestRun = TestRunQueue.TestRuns.First(testRun => testRun.Id == parameters.id);
                data.TestRun = currentTestRun;
                // data.Suites = data.TestRun.TestSuites.ToArray();
                data.Suites = currentTestRun.TestSuites.ToArray();
                
                return View[UrlList.ViewTestRuns_ResultsPageName, data];
            };
        }

        dynamic createNewTestRunExpandoObject(string path, string workflowName)
        {
            dynamic data = new ExpandoObject();
            // 20141130
//            data.Workflows = WorkflowCollection.Workflows ?? new List<ITestWorkflow>();
//            data.TestLabs = TestLabCollection.TestLabs ?? new List<ITestLab>();
            data.Workflows = (WorkflowCollection.Workflows ?? new List<ITestWorkflow>()).ToArray();
            data.TestLabs = (TestLabCollection.TestLabs ?? new List<ITestLab>()).ToArray();
            data.Path = path;
            data.WorkflowName = workflowName;
            return data;
        }
        
        dynamic createTestRunExpandoObject()
        {
            dynamic data = new ExpandoObject();
            // 20141130
//            data.TestRuns = TestRunQueue.TestRuns ?? new List<ITestRun>();
//            data.TestLabs = TestLabCollection.TestLabs ?? new List<ITestLab>();
            data.TestRuns = (TestRunQueue.TestRuns ?? new List<ITestRun>()).ToArray();
            data.TestLabs = (TestLabCollection.TestLabs ?? new List<ITestLab>()).ToArray();
            return data;
        }
        
        ITestRun getCurrentTestRun(Guid testRunId)
        {
            return TestRunQueue.TestRuns.First(testRun => testRun.Id == testRunId);
        }
    }
}
