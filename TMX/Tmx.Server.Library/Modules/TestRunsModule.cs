/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/27/2014
 * Time: 3:24 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Library.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Dynamic;
    using System.Linq;
    using Core;
    using Core.Types.Remoting;
    using Internal;
    using Nancy;
    using Nancy.ModelBinding;
    using Nancy.Responses.Negotiation;
    using ObjectModel;
    using ObjectModel.Objects;
    using Tmx.Interfaces.Remoting;
    using Tmx.Interfaces.Server;

    /// <summary>
    /// Description of TestRunsModule.
    /// </summary>
    public class TestRunsModule : NancyModule
    {
        public TestRunsModule() : base(UrlList.TestRuns_Root)
        {
            Post[UrlList.TestRunsControlPoint_relPath] = _ => CreateNewTestRun(this.Bind<TestRunCommand>());
            Delete[UrlList.TestRuns_One_relPath] = parameters => DeleteTestRun(parameters.id);
            
            // http://blog.nancyfx.org/x-http-method-override-with-nancyfx/
            Put[UrlList.TestRuns_One_Cancel] = parameters => CancelTestRun(parameters.id);
        }
        
        Negotiator CreateNewTestRun(ITestRunCommand testRunCommand)
        {
            Trace.TraceInformation("dissecting testRunCommand");
            Trace.TraceInformation("is testRunCommand null? {0}", null == testRunCommand);
            if (null != testRunCommand) {
                Trace.TraceInformation("workflow name = {0}, test run name = {1}", testRunCommand.WorkflowName, testRunCommand.TestRunName);
            }
            
            if (null == testRunCommand)
                // 20141219
                // testRunCommand = new TestRunCommand { TestRunName = Request.Form.test_run_name, WorkflowName = Request.Form.workflow_name };
                testRunCommand = new TestRunCommand { TestRunName = Request.Form.test_run_name ?? string.Empty, WorkflowName = Request.Form.workflow_name ?? string.Empty };
            if (string.IsNullOrEmpty(testRunCommand.WorkflowName))
                // 20141219
                // testRunCommand.WorkflowName = Request.Form.workflow_name;
                testRunCommand.WorkflowName = Request.Form.workflow_name ?? string.Empty;
            
            if (string.IsNullOrEmpty(testRunCommand.TestRunName))
                // 20141219
                // testRunCommand.TestRunName = Request.Form.test_run_name;
                testRunCommand.TestRunName = Request.Form.test_run_name ?? string.Empty;
            
            Trace.TraceInformation("workflow name = {0}, test run name = {1}", testRunCommand.WorkflowName, testRunCommand.TestRunName);
            
            return null == testRunCommand ? Negotiate.WithStatusCode(HttpStatusCode.NotFound) : SetTestRun(testRunCommand);
        }
        
        Negotiator SetTestRun(ITestRunCommand testRunCommand)
        {
            if (string.IsNullOrEmpty(testRunCommand.WorkflowName))
                return Negotiate.WithStatusCode(HttpStatusCode.NotFound);
            var testRunInitializer = ServerObjectFactory.Resolve<TestRunInitializer>();
            var testRun = testRunInitializer.CreateTestRun(testRunCommand, Request.Form);
            if (Guid.Empty == testRun.WorkflowId) // ??
                return Negotiate.WithStatusCode(HttpStatusCode.NotFound);
            TestRunQueue.TestRuns.Add(testRun);
            
            foreach (var testRunAction in testRun.BeforeActions) {
                testRunAction.Run();
            }
            
            var data = CreateTestRunExpandoObject();
            
            return Negotiate.WithStatusCode(HttpStatusCode.OK).WithView(UrlList.ViewTestRuns_TestRunsPageName).WithModel((ExpandoObject)data);
        }
        
        Negotiator DeleteTestRun(Guid testRunId)
        {
            TestRunQueue.TestRuns.RemoveAll(tr => tr.Id == testRunId);
            return Negotiate.WithStatusCode(HttpStatusCode.OK);
        }
        
        Negotiator CancelTestRun(Guid testRunId)
        {
            var testRun = TestRunQueue.TestRuns.First(tr => tr.Id == testRunId);
            var data = CreateTestRunExpandoObject();
            if (null == testRun)
                return Negotiate.WithStatusCode(HttpStatusCode.ExpectationFailed).WithView(UrlList.ViewTestRuns_TestRunsPageName).WithModel((ExpandoObject)data); // ??
            if (testRun.IsCompleted())
                return Negotiate.WithStatusCode(HttpStatusCode.ExpectationFailed).WithView(UrlList.ViewTestRuns_TestRunsPageName).WithModel((ExpandoObject)data); // ??
            var testRunSelector = ServerObjectFactory.Resolve<TestRunSelector>();
            testRunSelector.CancelTestRun(testRun);
            return Negotiate.WithStatusCode(HttpStatusCode.OK).WithView(UrlList.ViewTestRuns_TestRunsPageName).WithModel((ExpandoObject)data);
        }

        dynamic CreateTestRunExpandoObject()
        {
            dynamic data = new ExpandoObject();
            data.TestRuns = TestRunQueue.TestRuns ?? new List<ITestRun>();
            data.TestLabs = TestLabCollection.TestLabs ?? new List<ITestLab>();
            return data;
        }
    }
}
