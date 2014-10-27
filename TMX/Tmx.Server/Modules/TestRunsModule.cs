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
	using System.Linq;
	using Nancy;
	using Nancy.ModelBinding;
	using Nancy.Responses.Negotiation;
	using Tmx.Core.Types.Remoting;
	using Tmx.Interfaces.Remoting;
	using Tmx.Interfaces.Server;
	using Tmx.Server.Helpers.Objects;
	
	/// <summary>
	/// Description of TestRunsModule.
	/// </summary>
	public class TestRunsModule : NancyModule
	{
		public TestRunsModule() : base(UrnList.TestRuns_Root)
		{
			Post[UrnList.TestRunsControlPoint_relPath] = _ => createNewTestRun(this.Bind<TestRun>());
			Delete[UrnList.TestRuns_One_relPath] = parameters => deleteTestRun(parameters.id);
		}
		
		Negotiator createNewTestRun(ITestRun testRun)
		{
			if (null == testRun)
				return Negotiate.WithStatusCode(HttpStatusCode.ExpectationFailed);
			TestRunQueue.TestRuns.Add(testRun);
			int workflowId = WorkflowCollection.Workflows.First(w => w.Name == testRun.Name).Id;
			TaskPool.TasksForClients.AddRange(TaskPool.Tasks.Where(task => task.WorkflowId == workflowId));
			return Negotiate.WithStatusCode(HttpStatusCode.Created);
		}
		
		Negotiator deleteTestRun(int testRunId)
		{
			TestRunQueue.TestRuns.RemoveAll(tr => tr.Id == testRunId);
			return Negotiate.WithStatusCode(HttpStatusCode.OK);
		}
	}
}
