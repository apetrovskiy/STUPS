/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/27/2014
 * Time: 3:24 AM
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
    using Nancy.Responses.Negotiation;
    using Tmx.Core;
    using Tmx.Core.Types.Remoting;
    using Tmx.Interfaces.Remoting;
    using Tmx.Interfaces.Server;
    
    /// <summary>
    /// Description of TestRunsModule.
    /// </summary>
    public class TestRunsModule : NancyModule
    {
        public TestRunsModule() : base(UrlList.TestRuns_Root)
        {
            Post[UrlList.TestRunsControlPoint_relPath] = _ => createNewTestRun(this.Bind<TestRunCommand>());
            Delete[UrlList.TestRuns_One_relPath] = parameters => deleteTestRun(parameters.id);
            // Put[UrnList.TestRuns_One_relPath] = parameters => changeTestRun(parameters.id);
            
            // http://blog.nancyfx.org/x-http-method-override-with-nancyfx/
            Put[UrlList.TestRuns_One_Cancel] = parameters => cancelTestRun(parameters.id);
        }
        
        // Negotiator createNewTestRun()
        Negotiator createNewTestRun(ITestRunCommand testRunCommand)
        {
            if (null == testRunCommand)
                testRunCommand = new TestRunCommand { WorkflowName = Request.Form.workflow_name };
            if (string.IsNullOrEmpty(testRunCommand.WorkflowName))
                testRunCommand.WorkflowName = Request.Form.workflow_name;
            return null == testRunCommand ? Negotiate.WithStatusCode(HttpStatusCode.NotFound) : setTestRun(testRunCommand);
        }
        
        Negotiator setTestRun(ITestRunCommand testRunCommand)
        {
            if (string.IsNullOrEmpty(testRunCommand.WorkflowName))
                return Negotiate.WithStatusCode(HttpStatusCode.NotFound);
            var testRunInitializer = new TestRunInitializer();
            var testRun = testRunInitializer.CreateTestRun(testRunCommand, Request.Form);
            if (Guid.Empty == testRun.WorkflowId) // ??
                return Negotiate.WithStatusCode(HttpStatusCode.NotFound);
            TestRunQueue.TestRuns.Add(testRun);
            // there are no test clients on the new test run
            // var taskSelector = new TaskSelector();
            // taskSelector.AddTasksForEveryClient(TaskPool.Tasks.Where(task => WorkflowCollection.Workflows.ActiveWorkflowIds().Contains(task.WorkflowId)), testRun.Id);
            
            // TODO: trySet InProgress
            // 20141128
            // return Negotiate.WithStatusCode(HttpStatusCode.Created);
            // TODO: fix code duplication
//            dynamic data = new ExpandoObject();
//            data.TestRuns = TestRunQueue.TestRuns ?? new List<ITestRun>();
//            data.TestLabs = TestLabCollection.TestLabs ?? new List<ITestLab>();
            var data = createTestRunExpandoObject();
            
            // return Negotiate.WithStatusCode(HttpStatusCode.OK).WithView(UrnList.ViewTestStatus_Root + "/" + UrnList.ViewTestStatus_TestRunsPage).WithModel((ExpandoObject)data);
            return Negotiate.WithStatusCode(HttpStatusCode.OK).WithView(UrlList.ViewTestRuns_TestRunsPageName).WithModel((ExpandoObject)data);
        }
        
		Negotiator deleteTestRun(Guid testRunId)
		{
			TestRunQueue.TestRuns.RemoveAll(tr => tr.Id == testRunId);
			return Negotiate.WithStatusCode(HttpStatusCode.OK);
		}

//        Negotiator changeTestRun(Guid testRunId)
//        {
//            throw new NotImplementedException ();
//        }
        
        Negotiator cancelTestRun(Guid testRunId)
        {
            var testRun = TestRunQueue.TestRuns.First(tr => tr.Id == testRunId);
            var data = createTestRunExpandoObject();
            if (null == testRun)
                return Negotiate.WithStatusCode(HttpStatusCode.ExpectationFailed).WithView(UrlList.ViewTestRuns_TestRunsPageName).WithModel((ExpandoObject)data); // ??
            if (testRun.IsCompleted())
                return Negotiate.WithStatusCode(HttpStatusCode.ExpectationFailed).WithView(UrlList.ViewTestRuns_TestRunsPageName).WithModel((ExpandoObject)data); // ??
            var testRunSelector = new TestRunSelector();
            testRunSelector.CancelTestRun(testRun);
            
            // TODO: fix code duplication
//            dynamic data = new ExpandoObject();
//            data.TestRuns = TestRunQueue.TestRuns ?? new List<ITestRun>();
//            data.TestLabs = TestLabCollection.TestLabs ?? new List<ITestLab>();
            // var data = createTestRunExpandoObject();
            
            // return Negotiate.WithStatusCode(HttpStatusCode.OK).WithView(UrnList.ViewTestStatus_Root + "/" + UrnList.ViewTestStatus_TestRunsPage).WithModel((ExpandoObject)data);
            return Negotiate.WithStatusCode(HttpStatusCode.OK).WithView(UrlList.ViewTestRuns_TestRunsPageName).WithModel((ExpandoObject)data);
        }

        dynamic createTestRunExpandoObject()
        {
            dynamic data = new ExpandoObject();
            data.TestRuns = TestRunQueue.TestRuns ?? new List<ITestRun>();
            data.TestLabs = TestLabCollection.TestLabs ?? new List<ITestLab>();
            return data;
        }
	}
}
