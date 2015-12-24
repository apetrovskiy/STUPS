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
                    
                    switch (testResult.enStatus) {
                        case TestStatuses.Passed:
                            testScenarioStatistics.Passed++;
                            break;
                        case TestStatuses.Failed:
                            testScenarioStatistics.Failed++;
                            break;
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
            testScenarioStatistics.NotTested = testScenarioStatistics.All - testScenarioStatistics.Passed - testScenarioStatistics.Failed -testScenarioStatistics.PassedButWithBadSmell;
            scenario.Statistics = testScenarioStatistics;
            setTestScenarioStatus(scenario);
            return testScenarioStatistics;
        }
        
        void setTestSuiteStatus(ITestSuite suite)
        {
            suite.enStatus = suite.Statistics.PassedButWithBadSmell > 0 ? TestStatuses.KnownIssue :
                suite.Statistics.Failed > 0 ? TestStatuses.Failed :
                suite.Statistics.Passed > 0 ? TestStatuses.Passed : TestStatuses.NotRun;
        }
        
        void setTestScenarioStatus(ITestScenario scenario)
        {
            scenario.enStatus = scenario.Statistics.PassedButWithBadSmell > 0 ? TestStatuses.KnownIssue :
                scenario.Statistics.Failed > 0 ? TestStatuses.Failed :
                scenario.Statistics.Passed > 0 ? TestStatuses.Passed : TestStatuses.NotRun;
        }
    }
}
