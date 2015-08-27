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
    using System.Collections.Generic;
    using Interfaces;
    using Interfaces.TestStructure;

    /// <summary>
    /// Description of TestStatistics.
    /// </summary>
    public class TestStatistics
    {
        public virtual TestStat RefreshAllStatistics(List<ITestSuite> suites, bool skipAutomatic)
        {
            var testAllStatistics = new TestStat();
            foreach (var testSuite in suites) {
                RefreshSuiteStatistics(testSuite, skipAutomatic);
                testAllStatistics.All += testSuite.Statistics.All;
                testAllStatistics.Passed += testSuite.Statistics.Passed;
                testAllStatistics.Failed += testSuite.Statistics.Failed;
                testAllStatistics.NotTested += testSuite.Statistics.NotTested;
                testAllStatistics.TimeSpent += testSuite.Statistics.TimeSpent;
                testAllStatistics.PassedButWithBadSmell += testSuite.Statistics.PassedButWithBadSmell;
            }
            return testAllStatistics;
        }
        
        public virtual TestStat RefreshSuiteStatistics(ITestSuite suite, bool skipAutomatic)
        {
            var testSuiteStatistics = new TestStat();
            foreach (var testScenario in suite.TestScenarios) {
                RefreshScenarioStatistics(testScenario, skipAutomatic);
                testSuiteStatistics.All += testScenario.Statistics.All;
                testSuiteStatistics.Passed += testScenario.Statistics.Passed;
                testSuiteStatistics.Failed += testScenario.Statistics.Failed;
                testSuiteStatistics.NotTested += testScenario.Statistics.NotTested;
                testSuiteStatistics.TimeSpent += testScenario.Statistics.TimeSpent;
                testSuiteStatistics.PassedButWithBadSmell += testScenario.Statistics.PassedButWithBadSmell;
            }
            suite.Statistics = testSuiteStatistics;
            setTestSuiteStatus(suite);
            return testSuiteStatistics;
        }
        
        public virtual TestStat RefreshScenarioStatistics(ITestScenario scenario, bool skipAutomatic)
        {
            var testScenarioStatistics = new TestStat();
            
            if (null != scenario.TestResults && 0 < scenario.TestResults.Count) {
                
                testScenarioStatistics.All = scenario.TestResults.Count;
                foreach (var testResult in scenario.TestResults) {
//                    if (skipAutomatic)
//                        if (TestResultOrigins.Automatic == testResult.Origin)
//                            continue;
                    if (skipAutomatic && TestResultOrigins.Automatic == testResult.Origin)
                        continue;
                    
//                    if (testResult.enStatus == TestResultStatuses.Passed || testResult.enStatus == TestResultStatuses.KnownIssue) {
//                        testScenarioStatistics.Passed++;
//                        if (testResult.enStatus == TestResultStatuses.KnownIssue)
//                            testScenarioStatistics.PassedButWithBadSmell++;
//                    }
//                    switch (testResult.enStatus) {
//                        case TestResultStatuses.Passed:
//                        case TestResultStatuses.KnownIssue:
//                            testScenarioStatistics.Passed++;
//                            if (testResult.enStatus == TestResultStatuses.KnownIssue)
//                                testScenarioStatistics.PassedButWithBadSmell++;
//                            break;
//                    }
//                    if (testResult.enStatus == TestResultStatuses.Failed)
//                        testScenarioStatistics.Failed++;
                    
                    // 20150219
                    switch (testResult.enStatus) {
                        // 20150805
                        // case TestResultStatuses.Passed:
                        case TestStatuses.Passed:
                            testScenarioStatistics.Passed++;
                            break;
                        // 20150805
                        // case TestResultStatuses.Failed:
                        case TestStatuses.Failed:
                            testScenarioStatistics.Failed++;
                            break;
                        // 20150805
                        // case TestResultStatuses.KnownIssue:
                        case TestStatuses.KnownIssue:
                            testScenarioStatistics.PassedButWithBadSmell++;
                            break;
//                        case TestResultStatuses.NotTested:
//                            testScenarioStatistics.NotTested++;
//                            break;
                    }
                    
                    testScenarioStatistics.TimeSpent += testResult.TimeSpent;
                }
            }
            // 20150219
            // testScenarioStatistics.NotTested = testScenarioStatistics.All - testScenarioStatistics.Passed - testScenarioStatistics.Failed;
            testScenarioStatistics.NotTested = testScenarioStatistics.All - testScenarioStatistics.Passed - testScenarioStatistics.Failed -testScenarioStatistics.PassedButWithBadSmell;
            scenario.Statistics = testScenarioStatistics;
            setTestScenarioStatus(scenario);
            return testScenarioStatistics;
        }
        
        void setTestSuiteStatus(ITestSuite suite)
        {
            // 20150805
            // suite.enStatus = suite.Statistics.PassedButWithBadSmell > 0 ? TestSuiteStatuses.KnownIssue :
            suite.enStatus = suite.Statistics.PassedButWithBadSmell > 0 ? TestStatuses.KnownIssue :
                // 20150805
                // suite.Statistics.Failed > 0 ? TestSuiteStatuses.Failed :
                suite.Statistics.Failed > 0 ? TestStatuses.Failed :
                // 20150805
                // suite.Statistics.Passed > 0 ? TestSuiteStatuses.Passed : TestSuiteStatuses.NotTested;
                suite.Statistics.Passed > 0 ? TestStatuses.Passed : TestStatuses.NotRun;
        }
        
        void setTestScenarioStatus(ITestScenario scenario)
        {
            // 20150805
            // scenario.enStatus = scenario.Statistics.PassedButWithBadSmell > 0 ? TestScenarioStatuses.KnownIssue :
            scenario.enStatus = scenario.Statistics.PassedButWithBadSmell > 0 ? TestStatuses.KnownIssue :
                // 20150805
                // scenario.Statistics.Failed > 0 ? TestScenarioStatuses.Failed :
                scenario.Statistics.Failed > 0 ? TestStatuses.Failed :
                // 20150805
                // scenario.Statistics.Passed > 0 ? TestScenarioStatuses.Passed : TestScenarioStatuses.NotTested;
                scenario.Statistics.Passed > 0 ? TestStatuses.Passed : TestStatuses.NotRun;
        }
    }
}
