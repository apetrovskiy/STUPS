/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/3/2014
 * Time: 4:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Logic.ObjectModel.ExtensionMethods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core;
    using Objects;
    using Tmx.Interfaces.Remoting;

    /// <summary>
    /// Description of ExtensionMethods.
    /// </summary>
    public static class ExtensionMethods
    {
        public static IEnumerable<Guid> ActiveTestRunIds(this List<ITestRun> list)
        {
            return TestRunQueue.TestRuns.Where(tr => tr.IsActive()).Select(tr => tr.Id);
        }
        
        public static bool HasActiveTestRuns(this List<ITestRun> list)
        {
            return TestRunQueue.TestRuns.Any(tr => tr.IsActive());
            // return TestRunQueue.TestRuns.Any(IsActive);
        }

        public static IEnumerable<ITestWorkflow> ActiveWorkflows(this List<ITestWorkflow> list)
        {
            return WorkflowCollection.Workflows.Where(wfl => TestRunQueue.TestRuns.Where(tr => tr.Status == TestRunStatuses.Running).Select(tr => tr.WorkflowId).Contains(wfl.Id));
        }
        
        public static bool IsInActiveTestRun(this ITestClient testClient)
        {
            return ActiveTestRunIds(TestRunQueue.TestRuns).Contains(testClient.TestRunId);
        }
        
        public static bool IsLastTaskInTestRun(this ITestTask task)
        {
            return !TaskPool.TasksForClients.Any(tsk => tsk.TestRunId == task.TestRunId && tsk.Id != task.Id && !tsk.IsFinished());
        }
        
        public static string GetTestLabName(this ITestRun testRun)
        {
            return TestLabCollection.TestLabs.FirstOrDefault(testLab => testLab.Id == testRun.TestLabId).Name;
        }
        
        public static void UnregisterClients(this ITestRun testRun)
        {
            ClientsCollection.Clients.RemoveAll(client => client.TestRunId == testRun.Id);
        }
    }
}
