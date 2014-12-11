/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/31/2014
 * Time: 1:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server
{
    using System;
    using System.Linq;
    using Tmx.Core;
    using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of TestRunSelector.
    /// </summary>
    public class TestRunSelector
    {
        public ITestRun GetNextInRowTestRun()
        {
            // var testRunsThatPending = TestRunQueue.TestRuns.Where(testRun => TestRunStatuses.Pending == testRun.Status);
            var testRunsThatPending = TestRunQueue.TestRuns.Where(testRun => testRun.IsPending());
            return !testRunsThatPending.Any() ? null : testRunsThatPending.OrderBy(testRun => testRun.CreatedTime).First();
        }
        
        public void CancelTestRun(ITestRun testRun)
        {
            TaskPool.TasksForClients.Where(task => task.TestRunId == testRun.Id && !task.IsFinished() && !task.IsActive()).ToList().ForEach(task => task.TaskStatus = TestTaskStatuses.Canceled);
            testRun.Status = TestRunStatuses.Cancelled;
            if (TaskPool.TasksForClients.Any(task => task.TestRunId == testRun.Id && task.IsActive())) {
                TaskPool.TasksForClients.Where(task => task.TestRunId == testRun.Id && task.IsActive()).ToList().ForEach(task => task.TaskStatus = TestTaskStatuses.Interrupted);
                testRun.Status = TestRunStatuses.Cancelling;
            }
            // 20141211
            // disconnecting clients
            ClientsCollection.Clients.RemoveAll(client => client.TestRunId == testRun.Id);
            testRun.SetTimeTaken();
        }
    }
}
