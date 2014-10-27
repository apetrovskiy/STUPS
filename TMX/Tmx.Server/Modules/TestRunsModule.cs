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
			Post[UrnList.TestRunsControlPoint_relPath] = _ => createNewTestRun(this.Bind<TestRun>());
			Post[UrnList.TestRuns_ByName_relPath] = parameters => createNewTestRun(parameters.name);
			Delete[UrnList.TestRuns_One_relPath] = parameters => deleteTestRun(parameters.id);
		}
		
		Negotiator createNewTestRun(ITestRun testRun)
		{
            return null == testRun ? Negotiate.WithStatusCode(HttpStatusCode.NotFound) : setTestRun(testRun);
		}
		
		Negotiator createNewTestRun(string testRunName)
		{
            return string.IsNullOrEmpty(testRunName) ? Negotiate.WithStatusCode(HttpStatusCode.NotFound) : setTestRun(new TestRun());
		}
		
        Negotiator setTestRun(ITestRun testRun)
        {
            (testRun as TestRun).SetWorkflow(WorkflowCollection.Workflows.First(wfl => wfl.Name == testRun.Name));
            if (0 == testRun.WorkflowId)
                return Negotiate.WithStatusCode(HttpStatusCode.NotFound);
            if (TestRunStartTypes.Immediately == testRun.StartType)
                testRun.StartTime = DateTime.Now;
            TestRunQueue.TestRuns.Add(testRun);
            // int workflowId = WorkflowCollection.Workflows.First(w => w.Name == testRun.Name).Id;
            // TaskPool.TasksForClients.AddRange(TaskPool.Tasks.Where(task => task.WorkflowId == workflowId));
            // later, on registering a client
            // TaskPool.TasksForClients.AddRange(TaskPool.Tasks.Where(task => task.WorkflowId == testRun.Workflow.Id));
            return Negotiate.WithStatusCode(HttpStatusCode.Created);
        }
        
		Negotiator deleteTestRun(int testRunId)
		{
			TestRunQueue.TestRuns.RemoveAll(tr => tr.Id == testRunId);
			return Negotiate.WithStatusCode(HttpStatusCode.OK);
		}
	}
}
