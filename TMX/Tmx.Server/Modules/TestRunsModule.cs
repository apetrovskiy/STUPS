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
			Post[UrnList.TestRunsControlPoint_relPath] = _ => createNewTestRun(this.Bind<TestRunCommand>());
			Post[UrnList.TestRuns_ByName_relPath] = parameters => createNewTestRun(parameters.name);
			Delete[UrnList.TestRuns_One_relPath] = parameters => deleteTestRun(parameters.id);
		}
		
		Negotiator createNewTestRun(TestRunCommand testRunCommand)
		{
            return null == testRunCommand ? Negotiate.WithStatusCode(HttpStatusCode.NotFound) : setTestRun(testRunCommand);
		}
		
//		Negotiator createNewTestRun(string testRunName)
//		{
//            return string.IsNullOrEmpty(testRunName) ? Negotiate.WithStatusCode(HttpStatusCode.NotFound) : setTestRun(new TestRun());
//		}
        
        Negotiator setTestRun(TestRunCommand testRunCommand)
        {
            var testRun = new TestRun { Name = testRunCommand.Name, Status = testRunCommand.Status };
            (testRun as TestRun).SetWorkflow(WorkflowCollection.Workflows.First(wfl => wfl.Name == testRunCommand.WorkflowName));
            if (0 == testRun.WorkflowId)
                return Negotiate.WithStatusCode(HttpStatusCode.NotFound);
            if (TestRunStartTypes.Immediately == testRun.StartType) {
                testRun.StartTime = DateTime.Now;
                testRun.Status = TestRunStatuses.Running;
            }
			int maxId = 0;
			if (0 < TestRunQueue.TestRuns.Count)
			   maxId = TestRunQueue.TestRuns.Max(tr => tr.Id);
			testRun.Id = ++maxId;
            TestRunQueue.TestRuns.Add(testRun);
            addTasksForEveryClient(TaskPool.Tasks.Where(task => WorkflowCollection.Workflows.ActiveWorkflowIds().Contains(task.WorkflowId)));
            // TODO: trySet InProgress
            return Negotiate.WithStatusCode(HttpStatusCode.Created);
        }
        
		Negotiator deleteTestRun(int testRunId)
		{
			TestRunQueue.TestRuns.RemoveAll(tr => tr.Id == testRunId);
			return Negotiate.WithStatusCode(HttpStatusCode.OK);
		}
		
		internal virtual void addTasksForEveryClient(IEnumerable<ITestTask> activeWorkflowsTasks)
		{
		    if (0 == ClientsCollection.Clients.Count) return;
			var taskSorter = new TaskSelector();
			foreach (var clientId in ClientsCollection.Clients.Where(client => client.IsInActiveTestRun()).Select(client => client.Id)) {
			    TaskPool.TasksForClients.AddRange(taskSorter.SelectTasksForClient(clientId, activeWorkflowsTasks.ToList()));
			}
		}
	}
}
