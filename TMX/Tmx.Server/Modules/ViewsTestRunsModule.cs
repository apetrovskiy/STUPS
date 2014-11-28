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
        public ViewsTestRunsModule() : base(UrlList.ViewTestRuns_Root)
        {
            Get[UrlList.ViewTestRuns_NewTestRunPage] = _ => {
                dynamic data = new ExpandoObject();
                data.Workflows = WorkflowCollection.Workflows ?? new List<ITestWorkflow>();
                data.TestLabs = TestLabCollection.TestLabs ?? new List<ITestLab>();
                data.Path = UrlList.ViewTestWorkflowParameters_Root + "/" + UrlList.ViewTestWorkflowParameters_DefaultPageName;
                data.WorkflowName = string.Empty;
                return View[UrlList.ViewTestRuns_NewTestRunPageName, data];
            };
            
            Post[UrlList.ViewTestRuns_NewTestRunPage] = _ => {
                dynamic data = new ExpandoObject();
                data.Workflows = WorkflowCollection.Workflows ?? new List<ITestWorkflow>();
                data.TestLabs = TestLabCollection.TestLabs ?? new List<ITestLab>();
                string workflowName = Request.Form.workflow_name;
                data.Path = "/workflows/" + WorkflowCollection.Workflows.FirstOrDefault(wfl => wfl.Name == workflowName).ParametersPageName;
                data.WorkflowName = workflowName;
                return View[UrlList.ViewTestRuns_NewTestRunPageName, data];
            };
            
            Get[UrlList.ViewTestRuns_TestRunsPage] = parameters => {
                dynamic data = new ExpandoObject();
                data.TestRuns = TestRunQueue.TestRuns ?? new List<ITestRun>();
                data.TestLabs = TestLabCollection.TestLabs ?? new List<ITestLab>();
                return View[UrlList.ViewTestRuns_TestRunsPageName, data];
            };
            
            Get [UrlList.ViewTestRuns_ParametersPage] = parameters => {
                dynamic data = new ExpandoObject();
                data.TestRun = TestRunQueue.TestRuns.First(testRun => testRun.Id == parameters.id);
                return View[UrlList.ViewTestRuns_ParametersPageName, data];
            };
            
            Get [UrlList.ViewTestRuns_ClientsPage] = parameters => {
                dynamic data = new ExpandoObject();
                data.Clients = ClientsCollection.Clients.Where(client => client.TestRunId == parameters.id).ToList() ?? new List<ITestClient>();
                return View[UrlList.ViewTestRuns_ClientsPageName, data];
            };
            
            Get [UrlList.ViewTestRuns_TasksPage] = parameters => {
                dynamic data = new ExpandoObject();
                data.TasksForClients = TaskPool.TasksForClients.Where(task => task.TestRunId == parameters.id).ToList() ?? new List<ITestTask>();
                return View[UrlList.ViewTestRuns_TasksPageName, data];
            };
            
            Get[UrlList.ViewTestRuns_ResultsPage] = parameters => {
                dynamic data = new ExpandoObject();
                data.TestRun = TestRunQueue.TestRuns.First(testRun => testRun.Id == parameters.id);
                return View[UrlList.ViewTestRuns_ResultsPageName, data];
            };
        }
    }
}
