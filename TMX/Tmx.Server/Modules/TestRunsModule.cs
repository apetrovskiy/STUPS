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
        
//		ITestRun setTestRunDetails(TestRunCommand testRunCommand)
//		{
//			if (string.IsNullOrEmpty(testRunCommand.Name))
//				testRunCommand.Name = testRunCommand.WorkflowName + " " + DateTime.Now;
//            var testRun = new TestRun { Name = testRunCommand.Name, Status = testRunCommand.Status };
//            setWorkflow(testRunCommand, testRun);
//            setStartUpParameters(testRun);
//            setCommonData(testRun);
//            setCreatedTime(testRun);
//            return testRun;
//		}
//		
//        void setWorkflow(TestRunCommand testRunCommand, TestRun testRun)
//        {
//            (testRun as TestRun).SetWorkflow(WorkflowCollection.Workflows.First(wfl => wfl.Name == testRunCommand.WorkflowName));
//        }
//        
//        void setStartUpParameters(ITestRun testRun)
//        {
//            if (TestRunStartTypes.Immediately == testRun.StartType)
//                testRun.Status = TestRunQueue.TestRuns.Any(tr => tr.TestLabId == testRun.TestLabId && tr.IsQueued()) ? TestRunStatuses.Pending : TestRunStatuses.Running;
//            if (testRun.IsActive())
//                testRun.SetStartTime();
//        }
//        
//        void setCommonData(ITestRun testRun)
//        {
//            if (null == Request.Form || 0 >= Request.Form.Count)
//                return;
//            foreach (var key in Request.Form)
//                testRun.Data.AddOrUpdateDataItem(new CommonDataItem {
//                    Key = key,
//                    Value = Request.Form[key]
//                });
//        }
//        
//        void setCreatedTime(ITestRun testRun)
//        {
//            testRun.CreatedTime = DateTime.Now;
//        }
        
		Negotiator deleteTestRun(Guid testRunId)
		{
			TestRunQueue.TestRuns.RemoveAll(tr => tr.Id == testRunId);
			return Negotiate.WithStatusCode(HttpStatusCode.OK);
		}

//        Negotiator changeTestRun(Guid testRunId)
//        {
//            throw new NotImplementedException ();
//        }
	}
}
