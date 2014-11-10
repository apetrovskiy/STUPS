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
    }
}
