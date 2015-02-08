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
    using System.Net;
    using System.Net.Sockets;
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
        // const string _testRunCookieName = "test_run_name";
        
        public ViewsTestRunsModule() : base(UrlList.ViewTestRuns_Root)
        {
            Get[UrlList.ViewTestRuns_NewTestRunPage] = _ => {
                var data = CreateNewTestRunModel(UrlList.ViewTestWorkflowParameters_Root + "/" + UrlList.ViewTestWorkflowParameters_DefaultPage, string.Empty);
                data.Selected = string.Empty;
                // data.TestRunName = string.Empty;
                try {
                    data.Selected = getCookieValue(_workflowCookieName);
                    // data.TestRunName = getCookieValue(_testRunCookieName);
                }
                catch {}
                return View[UrlList.ViewTestRuns_NewTestRunPageName, data];
            };
            
            Post[UrlList.ViewTestRuns_NewTestRunPage] = _ => {
                string workflowName = Request.Form.workflow_name;
                var data = CreateNewTestRunModel("/workflows/" + WorkflowCollection.Workflows.FirstOrDefault(wfl => wfl.Name == workflowName).ParametersPageName, workflowName);
                data.Selected = workflowName;
                // string testRunName = Request.Form.test_run_name;
                // data.TestRunName = testRunName;
                return Negotiate
                    .WithCookie(new NancyCookie(_workflowCookieName, workflowName))
                    .WithView(UrlList.ViewTestRuns_NewTestRunPageName)
                    .WithModel((ExpandoObject)data);
                    // .WithCookie(new NancyCookie(_testRunCookieName, testRunName))
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
                data.Clients = (ClientsCollection.Clients.Where(client => client.TestRunId == parameters.id).ToList() ?? new List<ITestClient>());
                return View[UrlList.ViewTestRuns_ClientsPageName, data];
            };
            
            Get [UrlList.ViewTestRuns_TasksPage] = parameters => {
                dynamic data = new ExpandoObject();
                data.TasksForClients = (TaskPool.TasksForClients.Where(task => task.TestRunId == parameters.id).ToList() ?? new List<ITestTask>());
                return View[UrlList.ViewTestRuns_TasksPageName, data];
            };
            
            Get[UrlList.ViewTestRuns_ResultsPage] = parameters => {
                var data = CreateTestRunReportsModel(parameters.id);
                return View[UrlList.ViewTestRuns_ResultsPageName, data];
            };
        }

        public virtual dynamic CreateNewTestRunModel(string path, string workflowName)
        {
            dynamic data = new ExpandoObject();
            data.Workflows = (WorkflowCollection.Workflows ?? new List<ITestWorkflow>());
            data.TestLabs = (TestLabCollection.TestLabs ?? new List<ITestLab>());
            data.Path = path;
            data.WorkflowName = workflowName;
            return data;
        }
        
        public virtual dynamic CreateTestRunListModel()
        {
            dynamic data = new ExpandoObject();
            data.TestRuns = (TestRunQueue.TestRuns ?? new List<ITestRun>());
            data.TestLabs = (TestLabCollection.TestLabs ?? new List<ITestLab>());
            return data;
        }
        
        public virtual dynamic CreateTestRunReportsModel(Guid testRunId)
        {
            ITestRun currentTestRun = getCurrentTestRun(testRunId);
            var testStatistics = TinyIoCContainer.Current.Resolve<TestStatistics>();
            testStatistics.RefreshAllStatistics(currentTestRun.TestSuites, true);
            var serverUrl = getServerUrl();
            var testRunUrl = getTestRunUrl(testRunId);
            return new { TestRun = currentTestRun, Suites = currentTestRun.TestSuites.OrderBy(suite => suite.Id), ServerUrl = serverUrl, TestRunUrl = testRunUrl };
        }
        
        ITestRun getCurrentTestRun(Guid testRunId)
        {
            return TestRunQueue.TestRuns.First(testRun => testRun.Id == testRunId);
        }
        
        string getCookieValue(string cookieName)
        {
            var cookieValue = Context.Request.Cookies[cookieName];
            cookieValue = cookieValue.Replace("+", " ");
            return cookieValue;
        }
        
        string getServerUrl()
        {
            var ipAddress = Dns.GetHostAddresses(Dns.GetHostName()).First(address => address.AddressFamily == AddressFamily.InterNetwork && address.ToString().Substring(0, 7) != "169.254");
            return "http://" + ipAddress + ":" + ServerControl.Port;
        }
        
        string getTestRunUrl(Guid testRunId)
        {
            return getServerUrl() + "/testRuns/" + testRunId + "/testResults";
        }
    }
}
