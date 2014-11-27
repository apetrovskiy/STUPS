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
		public TestRunsModule() : base(UrnList.TestRuns_Root)
		{
			Post[UrnList.TestRunsControlPoint_relPath] = _ => createNewTestRun(this.Bind<TestRunCommand>());
			// Post[UrnList.TestRuns_ByName_relPath] = parameters => createNewTestRun(parameters.name);
			Delete[UrnList.TestRuns_One_relPath] = parameters => deleteTestRun(parameters.id);
            // Put[UrnList.TestRuns_One_relPath] = parameters => changeTestRun(parameters.id);
            
            // http://blog.nancyfx.org/x-http-method-override-with-nancyfx/
            Put[UrnList.TestRuns_One_Cancel] = parameters => cancelTestRun(parameters.id);
		}
		
		Negotiator createNewTestRun(TestRunCommand testRunCommand)
		{
            return null == testRunCommand ? Negotiate.WithStatusCode(HttpStatusCode.NotFound) : setTestRun(testRunCommand);
		}
        
        Negotiator setTestRun(TestRunCommand testRunCommand)
        {
            if (string.IsNullOrEmpty(testRunCommand.WorkflowName))
                return Negotiate.WithStatusCode(HttpStatusCode.NotFound);
            var testRunInitializer = new TestRunInitializer();
            var testRun = testRunInitializer.CreateTestRun(testRunCommand, Request.Form);
            // var testRun = setTestRunDetails(testRunCommand);
            if (Guid.Empty == testRun.WorkflowId) // ??
                return Negotiate.WithStatusCode(HttpStatusCode.NotFound);
            TestRunQueue.TestRuns.Add(testRun);
            // there are no test clients on the new test run
            // var taskSelector = new TaskSelector();
            // taskSelector.AddTasksForEveryClient(TaskPool.Tasks.Where(task => WorkflowCollection.Workflows.ActiveWorkflowIds().Contains(task.WorkflowId)), testRun.Id);
            
            // TODO: trySet InProgress
            return Negotiate.WithStatusCode(HttpStatusCode.Created);
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
            if (null == testRun)
                return Negotiate.WithStatusCode(HttpStatusCode.ExpectationFailed); // ??
            if (testRun.IsCompleted())
                return Negotiate.WithStatusCode(HttpStatusCode.ExpectationFailed); // ??
            var testRunSelector = new TestRunSelector();
            testRunSelector.CancelTestRun(testRun);
            return Negotiate.WithStatusCode(HttpStatusCode.OK);
        }
	}
}
