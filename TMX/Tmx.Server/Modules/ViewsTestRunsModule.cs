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
    using Nancy.Cookies;
    using Nancy.ModelBinding;
    using Nancy.Responses.Negotiation;
    using Nancy.Extensions;
    using Nancy.TinyIoc;
    using Tmx.Core;
    using Tmx.Interfaces.Server;
    using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of ViewsTestRunsModule.
    /// </summary>
    public class ViewsTestRunsModule : NancyModule
    {
        const string _workflowCookieName = "workflow_name";
        
        public ViewsTestRunsModule() : base(UrlList.ViewTestRuns_Root)
        {
            Get[UrlList.ViewTestRuns_NewTestRunPage] = _ => {
                var data = CreateNewTestRunModel(UrlList.ViewTestWorkflowParameters_Root + "/" + UrlList.ViewTestWorkflowParameters_DefaultPage, string.Empty);
                data.Selected = string.Empty;
                try {
                    var cookieValue = Context.Request.Cookies[_workflowCookieName];
                    cookieValue = cookieValue.Replace("+", " ");
                    data.Selected = cookieValue;
                }
                catch {}
                return View[UrlList.ViewTestRuns_NewTestRunPageName, data];
            };
            
            Post[UrlList.ViewTestRuns_NewTestRunPage] = _ => {
                string workflowName = Request.Form.workflow_name;
                var data = CreateNewTestRunModel("/workflows/" + WorkflowCollection.Workflows.FirstOrDefault(wfl => wfl.Name == workflowName).ParametersPageName, workflowName);
                data.Selected = workflowName;
                return Negotiate.WithCookie(new NancyCookie(_workflowCookieName, workflowName)).WithView(UrlList.ViewTestRuns_NewTestRunPageName).WithModel((ExpandoObject)data);
            };
            
            Get[UrlList.ViewTestRuns_TestRunsPage] = parameters => {
                var data = CreateTestRunListModel();
                return View[UrlList.ViewTestRuns_TestRunsPageName, data];
            };
            
            Get [UrlList.ViewTestRuns_ParametersPage] = parameters => {
                dynamic data = new ExpandoObject();
                data.TestRun = getCurrentTestRun(parameters.id);
                return View[UrlList.ViewTestRuns_ParametersPageName, data];
            };
            
            Get [UrlList.ViewTestRuns_ClientsPage] = parameters => {
                dynamic data = new ExpandoObject();
                // 20141130
                // data.Clients = ClientsCollection.Clients.Where(client => client.TestRunId == parameters.id).ToList() ?? new List<ITestClient>();
                // 20141218
                // data.Clients = (ClientsCollection.Clients.Where(client => client.TestRunId == parameters.id).ToList() ?? new List<ITestClient>()).ToArray();
                data.Clients = (ClientsCollection.Clients.Where(client => client.TestRunId == parameters.id).ToList() ?? new List<ITestClient>());
                return View[UrlList.ViewTestRuns_ClientsPageName, data];
            };
            
            Get [UrlList.ViewTestRuns_TasksPage] = parameters => {
                dynamic data = new ExpandoObject();
                // 20141130
                // data.TasksForClients = TaskPool.TasksForClients.Where(task => task.TestRunId == parameters.id).ToList() ?? new List<ITestTask>();
                // 20141218
                // data.TasksForClients = (TaskPool.TasksForClients.Where(task => task.TestRunId == parameters.id).ToList() ?? new List<ITestTask>()).ToArray();
                data.TasksForClients = (TaskPool.TasksForClients.Where(task => task.TestRunId == parameters.id).ToList() ?? new List<ITestTask>());
                return View[UrlList.ViewTestRuns_TasksPageName, data];
            };
            
            Get[UrlList.ViewTestRuns_ResultsPage] = parameters => {
//                dynamic data = new ExpandoObject();
//                ITestRun currentTestRun = getCurrentTestRun(parameters.id);
//                var testStatistics = TinyIoCContainer.Current.Resolve<TestStatistics>();
//                testStatistics.RefreshAllStatistics(currentTestRun.TestSuites, true);
//                data.TestRun = currentTestRun;
//                data.Suites = currentTestRun.TestSuites.ToArray();
                
                var data = CreateTestRunReportsModel(parameters.id);
                
                return View[UrlList.ViewTestRuns_ResultsPageName, data];
            };
        }

        public virtual dynamic CreateNewTestRunModel(string path, string workflowName)
        {
            dynamic data = new ExpandoObject();
            // 20141130
//            data.Workflows = WorkflowCollection.Workflows ?? new List<ITestWorkflow>();
//            data.TestLabs = TestLabCollection.TestLabs ?? new List<ITestLab>();
            // 20141218
            // data.Workflows = (WorkflowCollection.Workflows ?? new List<ITestWorkflow>()).ToArray();
            // data.TestLabs = (TestLabCollection.TestLabs ?? new List<ITestLab>()).ToArray();
            data.Workflows = (WorkflowCollection.Workflows ?? new List<ITestWorkflow>());
            data.TestLabs = (TestLabCollection.TestLabs ?? new List<ITestLab>());
            data.Path = path;
            data.WorkflowName = workflowName;
            return data;
        }
        
        public virtual dynamic CreateTestRunListModel()
        {
            dynamic data = new ExpandoObject();
            // 20141130
//            data.TestRuns = TestRunQueue.TestRuns ?? new List<ITestRun>();
//            data.TestLabs = TestLabCollection.TestLabs ?? new List<ITestLab>();
            data.TestRuns = (TestRunQueue.TestRuns ?? new List<ITestRun>()).ToArray();
            data.TestLabs = (TestLabCollection.TestLabs ?? new List<ITestLab>()).ToArray();
            return data;
        }
        
        public virtual dynamic CreateTestRunReportsModel(Guid testRunId)
        {
            // dynamic data = new ExpandoObject();
            ITestRun currentTestRun = getCurrentTestRun(testRunId);
            
Console.WriteLine("is testRun null? {0}", null == currentTestRun);
Console.WriteLine("testRun Id = {0}", currentTestRun.Id);
Console.WriteLine("is testRun.Suites null? {0}", null == currentTestRun.TestSuites);
Console.WriteLine("there are {0} suites", currentTestRun.TestSuites.Count);
            
            var testStatistics = TinyIoCContainer.Current.Resolve<TestStatistics>();
            testStatistics.RefreshAllStatistics(currentTestRun.TestSuites, true);
            // data.TestRun = currentTestRun;
            // // 20141218
            // // data.Suites = currentTestRun.TestSuites.ToArray();
            // data.Suites = currentTestRun.TestSuites;
            
//Console.WriteLine("are Suites null? {0}", null == data.Suites);
            
            // return data;
            // return new { @Model = new { TestRun = currentTestRun, Suites = currentTestRun.TestSuites } };
            return new { TestRun = currentTestRun, Suites = currentTestRun.TestSuites };
        }
        
        ITestRun getCurrentTestRun(Guid testRunId)
        {
            return TestRunQueue.TestRuns.First(testRun => testRun.Id == testRunId);
        }
    }
}
