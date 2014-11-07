/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/7/2014
 * Time: 9:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Core
{
    using System;
    using Tmx.Interfaces;
    using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of TestStatistics.
    /// </summary>
    public class TestStatistics
    {
        public virtual TestStat RefreshScenarioStatistics(ITestScenario scenario, bool skipAutomatic)
        {
            var ts = new TestStat();

            if (null != scenario.TestResults && 0 < scenario.TestResults.Count) {
                
                ts.All = scenario.TestResults.Count;
                foreach (var testResult in scenario.TestResults) {
                    
                    if (skipAutomatic)
                        if (TestResultOrigins.Automatic == testResult.Origin)
                            continue;
                    
                    if (testResult.enStatus == TestResultStatuses.Passed || testResult.enStatus == TestResultStatuses.KnownIssue) {
                        ts.Passed++;
                        if (testResult.enStatus == TestResultStatuses.KnownIssue)
                            ts.PassedButWithBadSmell++;
                    }
                    if (testResult.enStatus == TestResultStatuses.Failed)
                        ts.Failed++;
                    ts.TimeSpent += testResult.TimeSpent;
                }
            }
            ts.NotTested = ts.All - ts.Passed - ts.Failed;
            scenario.Statistics = ts;
            return ts;
        }
        
        public virtual TestStat RefreshSuiteStatistics(ITestSuite suite, bool skipAutomatic)
        {
            var ts = new TestStat();
            foreach (var testScenario in suite.TestScenarios) {
                
                //RefreshScenarioStatistics(tsc);
                RefreshScenarioStatistics(testScenario, skipAutomatic);
                ts.All += testScenario.Statistics.All;
                ts.Passed += testScenario.Statistics.Passed;
                ts.Failed += testScenario.Statistics.Failed;
                ts.NotTested += testScenario.Statistics.NotTested;
                ts.TimeSpent += testScenario.Statistics.TimeSpent;
                ts.PassedButWithBadSmell += testScenario.Statistics.PassedButWithBadSmell;
            }
            suite.Statistics = ts;
            return ts;
        }
    }
}
