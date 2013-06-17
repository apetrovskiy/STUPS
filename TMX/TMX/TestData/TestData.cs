/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17/02/2012
 * Time: 07:48 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.ComponentModel;
    using System.Linq;
	
    public delegate void TMXStructureChangedEventHandler(object sender, EventArgs e);
    public delegate void TMXDatabaseOperationCompletedEventHandler(object sender, EventArgs e);
    
    /// <summary>
    /// Description of TestSuitesCollection.
    /// </summary>
    public static class TestData
    {
        // ----------------- Variables ---------------------------
        
        public const string TestStateNotTested = "NOT TESTED";
        public const string TestStatePassed = "PASSED";
        public const string TestStateFailed = "FAILED";
        public const string TestStateKnownIssue = "KNOWN ISSUE";
        
        static TestData()
        {
            TestSuites = 
                new List<TestSuite>();
            
            // 20130531
            TestPlatforms =
                new List<TestPlatform>();
        }
        
        
        // ----------------- Properties --------------------------
        
        public static List<TestSuite> TestSuites {get; internal set; }

        public static TestSuite CurrentTestSuite { get; set; }
        public static TestScenario CurrentTestScenario { get; set; }
        public static ITestResult CurrentTestResult { get; set; } // ?? rewrite as the last item of the collection ??
        // 20130617
        public static ITestCase CurrentTestCase { get; set; }
        // 20130531
        public static List<TestPlatform> TestPlatforms {get; internal set; }
        public static ITestPlatform CurrentTestPlatform { get; set; }
        public static ITestResult LastTestResult // ?? rewrite as setting the previous on creating the current ??
        {
            get {
                ITestResult testResult = null;
                if (null != TestSuites && 0 < TestSuites.Count) {
                    
                    int suiteNumber = TestSuites.Count - 1;
                    
                    if (null != TestSuites[suiteNumber].TestScenarios &&
                        0 < TestSuites[suiteNumber].TestScenarios.Count) {
                        
                        int scenarioNumber = TestSuites[TestSuites.Count -1].TestScenarios.Count - 1;
                        
                        if (null != TestSuites[suiteNumber].TestScenarios[scenarioNumber].TestResults &&
                            0 < TestSuites[suiteNumber].TestScenarios[scenarioNumber].TestResults.Count) {
                            
                        testResult = TestSuites[suiteNumber].TestScenarios[scenarioNumber].TestResults[
                                TestSuites[suiteNumber].TestScenarios[scenarioNumber].TestResults.Count - 1];
                        }
                    }
                }
                
                return testResult;
            }
        }
        
        
        public static IDatabase CurrentStructureDB { get; set; }
        public static IDatabase CurrentRepositoryDB { get; set; }
        public static IDatabase CurrentResultsDB { get; set; }

        
        // ------------------ Events -----------------------------
        public static event TMXStructureChangedEventHandler TMXNewTestSuiteCreated;
        public static event TMXStructureChangedEventHandler TMXTestSuiteOpened;
        public static event TMXStructureChangedEventHandler TMXNewTestScenarioAdded;
        public static event TMXStructureChangedEventHandler TMXTestScenarioOpened;
        public static event TMXStructureChangedEventHandler TMXNewTestResultClosed;
        public static event TMXStructureChangedEventHandler TMXNewTestResultDetailAdded;
        // 20130531
        public static event TMXStructureChangedEventHandler TMXNewTestPlatformCreated;
        
        public static event TMXDatabaseOperationCompletedEventHandler TMXBackUpTestResultsCompleted;
        public static event TMXDatabaseOperationCompletedEventHandler TMXRestoreTestResultsCompleted;
        
        public static event TMXDatabaseOperationCompletedEventHandler TMXTestBucketAdded;
        public static event TMXDatabaseOperationCompletedEventHandler TMXTestBucketRemoved;
        public static event TMXDatabaseOperationCompletedEventHandler TMXTestBucketChanged;
        
        public static event TMXDatabaseOperationCompletedEventHandler TMXTestConstantAdded;
        public static event TMXDatabaseOperationCompletedEventHandler TMXTestConstantRemoved;
        public static event TMXDatabaseOperationCompletedEventHandler TMXTestConstantChanged;
        
        public static event TMXDatabaseOperationCompletedEventHandler TMXTestCaseAdded;
        public static event TMXDatabaseOperationCompletedEventHandler TMXTestCaseRemoved;
        public static event TMXDatabaseOperationCompletedEventHandler TMXTestCaseChanged;
        
        internal static void OnTMXNewTestSuiteCreated(object sender, EventArgs e) 
        {
            if (TMXNewTestSuiteCreated != null) {
                TMXNewTestSuiteCreated(sender, e);
            }
        }
        
        internal static void OnTMXTestSuiteOpened(object sender, EventArgs e) 
        {
            if (TMXTestSuiteOpened != null) {
                TMXTestSuiteOpened(sender, e);
            }
        }
        
        internal static void OnTMXNewTestScenarioAdded(object sender, EventArgs e) 
        {
            if (TMXNewTestScenarioAdded != null) {
                TMXNewTestScenarioAdded(sender, e);
            }
        }
        
        internal static void OnTMXTestScenarioOpened(object sender, EventArgs e) 
        {
            if (TMXTestScenarioOpened != null) {
                TMXTestScenarioOpened(sender, e);
            }
        }
        
        internal static void OnTMXNewTestResultClosed(object sender, EventArgs e) 
        {
            if (TMXNewTestResultClosed != null) {
                TMXNewTestResultClosed(sender, e);
            }
        }
        
        internal static void OnTMXNewTestResultDetailAdded(object sender, EventArgs e) 
        {
            if (TMXNewTestResultDetailAdded != null) {
                TMXNewTestResultDetailAdded(sender, e);
            }
        }
        
        internal static void OnTMXBackUpTestResultsCompleted(object sender, EventArgs e) 
        {
            if (TMXBackUpTestResultsCompleted != null) {
                TMXBackUpTestResultsCompleted(sender, e);
            }
        }
        
        internal static void OnTMXRestoreTestResultsCompleted(object sender, EventArgs e) 
        {
            if (TMXRestoreTestResultsCompleted != null) {
                TMXRestoreTestResultsCompleted(sender, e);
            }
        }
        
        // 20130531
        internal static void OnTMXNewTestPlatformCreated(object sender, EventArgs e) 
        {
            if (TMXNewTestPlatformCreated != null) {
                TMXNewTestPlatformCreated(sender, e);
            }
        }
        
        internal static void OnTMXTestBucketAdded(object sender, EventArgs e) 
        {
            if (TMXTestBucketAdded != null) {
                TMXTestBucketAdded(sender, e);
            }
        }
        
        internal static void OnTMXTestBucketRemoved(object sender, EventArgs e) 
        {
            if (TMXTestBucketRemoved != null) {
                TMXTestBucketRemoved(sender, e);
            }
        }
        
        internal static void OnTMXTestBucketChanged(object sender, EventArgs e) 
        {
            if (TMXTestBucketChanged != null) {
                TMXTestBucketChanged(sender, e);
            }
        }
        
        internal static void OnTMXTestConstantAdded(object sender, EventArgs e) 
        {
            if (TMXTestConstantAdded != null) {
                TMXTestConstantAdded(sender, e);
            }
        }
        
        internal static void OnTMXTestConstantRemoved(object sender, EventArgs e) 
        {
            if (TMXTestConstantRemoved != null) {
                TMXTestConstantRemoved(sender, e);
            }
        }
        
        internal static void OnTMXTestConstantChanged(object sender, EventArgs e) 
        {
            if (TMXTestConstantChanged != null) {
                TMXTestConstantChanged(sender, e);
            }
        }
        
        internal static void OnTMXTestCaseAdded(object sender, EventArgs e) 
        {
            if (TMXTestCaseAdded != null) {
                TMXTestCaseAdded(sender, e);
            }
        }
        
        internal static void OnTMXTestCaseRemoved(object sender, EventArgs e) 
        {
            if (TMXTestCaseRemoved != null) {
                TMXTestCaseRemoved(sender, e);
            }
        }
        
        internal static void OnTMXTestCaseChanged(object sender, EventArgs e) 
        {
            if (TMXTestCaseChanged != null) {
                TMXTestCaseChanged(sender, e);
            }
        }
        
        // ------------------ Methods ----------------------------
        public static void ResetData()
        {
            TestSuites.Clear();
            CurrentTestResult = null;
            CurrentTestScenario = null;
            CurrentTestSuite = null;
        }
        
        public static void CleanData()
        {
            foreach (TestSuite suite in TestSuites) {
                foreach (TestScenario scenario in suite.TestScenarios) {
                    scenario.TestResults.Clear();
                    scenario.enStatus = TestScenarioStatuses.NotTested;
                }
                suite.enStatus = TestSuiteStatuses.NotTested;
            }
            CurrentTestResult = null;
            CurrentTestScenario = null;
            CurrentTestSuite = null;
        }
        
        internal static void AddTestResult(string closingTestResultName, // previousTestResultName
                                           string closingTestResultId, // previousTestResultId
                                           bool? passed,
                                           bool isKnownIssue,
                                           bool generateNextResult,
                                           InvocationInfo myInvocation,
                                           ErrorRecord error,
                                           string testResultDescription,
                                           // 20130322
                                           //bool generated)
                                           bool generated,
                                           bool skipAutomatic)
        {
            //TestData.InitCurrentTestScenario();
            
            // 20130429
            TMX.Logger.TMXLogger.Info("Test result: '" + closingTestResultName + "'\tPassed:" + passed.ToString() + "\tKnown issue:" + isKnownIssue.ToString());

            ITestResult currentTestResult;
            if (null != TestData.CurrentTestResult) {
                
dumpTestStructure("AddTestResult #1");
                currentTestResult = TestData.CurrentTestResult;
dumpTestStructure("AddTestResult #1b");
            } else {
                
dumpTestStructure("AddTestResult #2");
                currentTestResult =
                    new TestResult(
                        TestData.CurrentTestScenario.Id,
                        TestData.CurrentTestSuite.Id);
dumpTestStructure("AddTestResult #2b");
            }

            // 20130325
            if (null == currentTestResult.Name ||
                string.Empty == currentTestResult.Name ||
                0 == currentTestResult.Name.Length) {
                
dumpTestStructure("AddTestResult #3");
                // 20130610
//                if (closingTestResultName != null &&
//                    closingTestResultName != string.Empty &&
//                    closingTestResultName.Length > 0 &&
//                    TMX.TestData.CurrentTestResult != null && 
//                     closingTestResultName != TMX.TestData.CurrentTestResult.Name) {

                if (closingTestResultName != null &&
                    closingTestResultName != string.Empty &&
                    closingTestResultName.Length > 0 &&
                    ((TMX.TestData.CurrentTestResult != null && 
                      closingTestResultName != TMX.TestData.CurrentTestResult.Name) ||
                      null == TMX.TestData.CurrentTestResult)) {
                    
dumpTestStructure("AddTestResult #3b");
                    currentTestResult.Name = closingTestResultName;

                } else {
                    
dumpTestStructure("AddTestResult #4");
                    currentTestResult.Name = "generated test result name";
                }
                
            // 20130326
            } else {
                
dumpTestStructure("AddTestResult #5");
                // the current test result is a result that was preset
                // nothing to do
            }

            // 20130322
            // setting test result's origin
            if (generated) {
                
dumpTestStructure("AddTestResult #6");
                currentTestResult.SetOrigin(TestResultOrigins.Automatic);

            } else {
                
dumpTestStructure("AddTestResult #7");
                currentTestResult.SetOrigin(TestResultOrigins.Logical);

            }

            // 20130325
            if (null == currentTestResult.Id ||
                string.Empty == currentTestResult.Id ||
                0 == currentTestResult.Id.Length) {
                
dumpTestStructure("AddTestResult #8");
                // 20130610
//                if (closingTestResultId != null &&
//                    closingTestResultId != string.Empty &&
//                    closingTestResultId.Length > 0 &&
//                    null != TMX.TestData.CurrentTestResult &&
//                    closingTestResultId != TMX.TestData.CurrentTestResult.Id) {

                if (closingTestResultId != null &&
                    closingTestResultId != string.Empty &&
                    closingTestResultId.Length > 0 &&
                    ((null != TMX.TestData.CurrentTestResult &&
                      closingTestResultId != TMX.TestData.CurrentTestResult.Id) ||
                      null == TMX.TestData.CurrentTestResult)) {
                    
dumpTestStructure("AddTestResult #9");
                    currentTestResult.Id = closingTestResultId;

                } else {
                    

dumpTestStructure("AddTestResult #10");
                    currentTestResult.Id = GetTestResultId();

                }
            // 20130326
            } else {
dumpTestStructure("AddTestResult #11");
                // there already was the Id
                // nothing to do
            }

            if (passed != null) {
dumpTestStructure("AddTestResult #14");
                if ((bool)passed) {

                    currentTestResult.enStatus = TestResultStatuses.Passed;
                } else {

                    currentTestResult.enStatus = TestResultStatuses.Failed;
                }

                if (isKnownIssue) {

                    currentTestResult.enStatus = TestResultStatuses.KnownIssue;
                }
            } else {
dumpTestStructure("AddTestResult #15");

                // 20130407
                //currentTestResult.enStatus = TestResultStatuses.NotTested;
                
                // 20130330
                // if there were no errors during the test case execution
                // it is marked as passed
                bool noErrors = true;
                if (null == currentTestResult.Error &&
                    TestResultStatuses.Failed != currentTestResult.enStatus &&
                    TestResultStatuses.KnownIssue != currentTestResult.enStatus) {
dumpTestStructure("AddTestResult #16");
                    //foreach (ITestResultDetail detail in currentTestResult.Details) {
                    foreach (ITestResultDetail detail in currentTestResult.Details) {
dumpTestStructure("AddTestResult #17");
                        if (null == ((TestResultDetail)detail).ErrorDetail) {
dumpTestStructure("AddTestResult #18");
                            noErrors = false;
                            break;
                        }
                    }
                }
                // 20130407
                //if (noErrors) {
                if (noErrors && null != passed) {
dumpTestStructure("AddTestResult #19");
                    currentTestResult.enStatus = TestResultStatuses.Passed;
                }

            }
dumpTestStructure("AddTestResult #20");
            if (testResultDescription != null &&
                testResultDescription != string.Empty &&
                testResultDescription.Length > 0){
dumpTestStructure("AddTestResult #21");
                currentTestResult.Description = testResultDescription;

            }

            if (generated) {
dumpTestStructure("AddTestResult #23");
                currentTestResult.SetGenerated();

            }

            if (TMXHelper.TestCaseStarted == System.DateTime.MinValue) {
dumpTestStructure("AddTestResult #25");
                TMXHelper.TestCaseStarted = System.DateTime.Now;
            }

            currentTestResult.SetNow();
dumpTestStructure("AddTestResult #27");
            currentTestResult.SetTimeSpent(
                (currentTestResult.Timestamp - TMXHelper.TestCaseStarted).TotalSeconds);
dumpTestStructure("AddTestResult #29");
            
            TestData.CurrentTestResult = currentTestResult;
            
            // 20130531
            try {
                TestData.CurrentTestResult.PlatformId =
                    // 20130612
                    //TestData.CurrentTestPlatform.Id;
                    TestData.CurrentTestScenario.PlatformId;
            }
            catch {}
            
            // 20130326
            if (null != TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1] &&
                TestResultOrigins.Logical == TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1].Origin &&
                TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1] != TestData.CurrentTestResult &&
                null != TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1].Name &&
                0 < TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1].Name.Length) {
dumpTestStructure("AddTestResult #30");
                
                TMXHelper.TestCaseStarted =
                    System.DateTime.Now;
                TestData.CurrentTestScenario.TestResults.Add(new TestResult(TestData.CurrentTestScenario.Id, TestData.CurrentTestSuite.Id));
               
            }
            
            TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1] = 
                TestData.CurrentTestResult;
            
            #region Test Result's PowerShell data
            if (myInvocation != null) {
                
                TestData.CurrentTestResult.SetScriptName(TMXHelper.GetScriptName(myInvocation));

                TestData.CurrentTestResult.SetLineNumber(TMXHelper.GetScriptLineNumber(myInvocation));

                TestData.CurrentTestResult.SetPosition(TMXHelper.GetPipelinePosition(myInvocation));

                // 20130329
                try {
                    
                    if (((bool)passed && Preferences.LogScriptName_Passed) || (!(bool)passed && Preferences.LogScriptName_Failed)) {
    
                        TestData.CurrentTestResult.Code += 
                            "script name: " + 
                            TestData.CurrentTestResult.ScriptName;
    
                    }
                }
                catch {}
                try {
                    
                    if (((bool)passed && Preferences.LogLineNumber_Passed) || (!(bool)passed && Preferences.LogLineNumber_Failed)) {
    
                        TestData.CurrentTestResult.Code +=
                            "\r\nline number: " +
                            TestData.CurrentTestResult.LineNumber.ToString();
    
                    }
                }
                catch {}
                try {
                    
                    if (((bool)passed && Preferences.LogCode_Passed) || (!(bool)passed && Preferences.LogCode_Failed)) {
    
                        TestData.CurrentTestResult.Code +=
                            "\r\ncode:\r\n" +
                            myInvocation.Line;
    
                    }
                }
                catch {}
            }
            
            if (error != null) {

                TestData.CurrentTestResult.SetError(error);

            }
            #endregion Test Result's PowerShell data
            
            var sourceTestResult = TestData.CurrentTestResult;
            
            // 20130322
            //SetScenarioStatus();
            SetScenarioStatus(skipAutomatic);
            
            // 20130322
            //SetSuiteStatus();
            SetSuiteStatus(skipAutomatic);
            
            if (generateNextResult) {
dumpTestStructure("AddTestResult #40");
                // write current time
                TMXHelper.TestCaseStarted =
                    System.DateTime.Now;
                TestData.CurrentTestScenario.TestResults.Add(
                    new TestResult(
                       TestData.CurrentTestScenario.Id,
                       TestData.CurrentTestScenario.SuiteId));
                TestData.CurrentTestResult = 
                    TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1];
dumpTestStructure("AddTestResult #45");
            } else {
dumpTestStructure("AddTestResult #46");
                // write zero time
                TMXHelper.TestCaseStarted =
                    System.DateTime.MinValue;
                TestData.CurrentTestResult = null;
            }
            
            if (TMX.Preferences.Storage) {
                // 20130527
    			using (var session = StorageHelper.SessionFactory.OpenSession())
                {
                    session.Save(TestData.CurrentTestResult);
    			}
            }

            OnTMXNewTestResultClosed(sourceTestResult, null);
        }
        

        
        internal static void InitTestData()
        {
            TMXHelper.TestCaseStarted =
                System.DateTime.Now;
            
            if (null == TestData.TestSuites) {
                TestData.TestSuites = new List<TestSuite>();
            }
            
            // 20130605
            if (null == TestData.TestPlatforms) {
                TestData.TestPlatforms = new List<TestPlatform>();
            }
            
            // 20130531
            // check that at least one platform exists
            if (0 == TestData.TestPlatforms.Count) {
                TMXHelper.NewTestPlatform(
                    "autogenerated",
                    GetTestPlatformId(),
                    "This platform has been created automatically",
                    System.Environment.OSVersion.Platform.ToString(),
                    System.Environment.OSVersion.VersionString,
                    System.Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE"),
                    "");
            }
            
            // check that at least one suite exists
            if (TestData.TestSuites.Count == 0) {
                TMXHelper.NewTestSuite(
                    "autogenerated",
                    GetTestSuiteId(),
                    TestData.CurrentTestPlatform.Id,
                    "This suite has been created automatically",
                    null,
                    null);
            }
            
            // check that at least one scenario exists
            if (TestData.CurrentTestSuite.TestScenarios.Count == 0) {
                TMX.Commands.AddTMXTestScenarioCommand cmdlet = 
                    new TMX.Commands.AddTMXTestScenarioCommand();
                cmdlet.Name = "autogenerated";
                cmdlet.Id = GetTestScenarioId();
                cmdlet.Description = 
                    "This scenario has been created automatically";
                cmdlet.TestSuiteName = 
                    TestData.CurrentTestSuite.Name;
                cmdlet.TestSuiteId =
                    TestData.CurrentTestSuite.Id;
                TMXHelper.AddTestScenario(cmdlet);
            }
        }
        
        internal static void InitCurrentTestSuite()
        {
            if (null == TestData.CurrentTestSuite) {
                
                if (null == TestData.TestSuites) {
                    
                    TestData.InitTestData();
                } else {
                    
                    if (0 == TestData.TestSuites.Count) {
                        
//Console.WriteLine("current test platform???????????????????");
//Console.WriteLine(TestData.CurrentTestPlatform.Id);
                        
                        TestData.AddTestSuite(
                            "autogenerated",
                            TestData.GetTestSuiteId(),
                            TestData.CurrentTestPlatform.Id,
                            string.Empty,
                            null,
                            null);
                    }
                }
                
                TestData.CurrentTestSuite =
                    TestData.TestSuites[TestData.TestSuites.Count - 1];
            }
        }
        
        internal static void InitCurrentTestScenario()
        {
            if (null == TestData.CurrentTestSuite) {
                TestData.InitCurrentTestSuite();
            }
            
            if (null == TestData.CurrentTestScenario) {
                
                if (null == TestData.CurrentTestSuite.TestScenarios) {
                    
                    // that's impossible...
                    TestData.CurrentTestSuite.TestScenarios =
                        new List<ITestScenario>();
                    
                } 
                
                if (0 == TestData.CurrentTestSuite.TestScenarios.Count) {
                    
                    TestData.AddTestScenario(
                        TestData.CurrentTestSuite,
                        "autogenerated",
                        TestData.GetTestScenarioId(),
                        string.Empty,
                        string.Empty,
                        string.Empty,
                        TestData.CurrentTestPlatform.Id,
                        null,
                        null);
                }
                
                TestData.CurrentTestScenario =
                    (TestScenario)TestData.CurrentTestSuite.TestScenarios[
                        TestData.CurrentTestSuite.TestScenarios.Count - 1];
            }
        }
        
        // 20130322
        //internal static TestStat RefreshScenarioStatistics(TestScenario scenario)
        internal static TestStat RefreshScenarioStatistics(TestScenario scenario, bool skipAutomatic)
        {
            TestStat ts = new TestStat();

            if (null != scenario.TestResults && 0 < scenario.TestResults.Count) {
                
                ts.All = scenario.TestResults.Count;
                foreach (TestResult tr in scenario.TestResults) {
                    
                    // 20130322
                    if (skipAutomatic) {
                        if (TestResultOrigins.Automatic == tr.Origin) {
                            continue;
                        }
                    }
                    
                    if (tr.enStatus == TestResultStatuses.Passed ||
                        tr.enStatus == TestResultStatuses.KnownIssue) {
                        ts.Passed++;
                        if (tr.enStatus == TestResultStatuses.KnownIssue){
                            ts.PassedButWithBadSmell++;
                        }
                    }
                    if (tr.enStatus == TestResultStatuses.Failed) {
                        ts.Failed++;
                    }
                    ts.TimeSpent += tr.TimeSpent;
                }
            }
            ts.NotTested = 
                ts.All - 
                ts.Passed -
                ts.Failed;
            scenario.Statistics = ts;
            return ts;
        }
        
        internal static TestStat RefreshSuiteStatistics(TestSuite suite, bool skipAutomatic)
        {
            TestStat ts = new TestStat();
            foreach (TestScenario tsc in suite.TestScenarios) {
                
                // 20130322
                //RefreshScenarioStatistics(tsc);
                RefreshScenarioStatistics(tsc, skipAutomatic);
                ts.All += tsc.Statistics.All;
                ts.Passed += tsc.Statistics.Passed;
                ts.Failed += tsc.Statistics.Failed;
                ts.NotTested += tsc.Statistics.NotTested;
                ts.TimeSpent += tsc.Statistics.TimeSpent;
                ts.PassedButWithBadSmell += tsc.Statistics.PassedButWithBadSmell;
            }
            suite.Statistics = ts;
            return ts;
        }
        
        internal static void SetScenarioStatus(bool skipAutomatic)
        {
            if (null == TestData.CurrentTestScenario) {
                TestData.InitCurrentTestScenario();
            }

            int counterPassedResults = 0;
            int counterKnownIssueResults = 0;
            
            if (null != TestData.CurrentTestScenario &&
                null != TestData.CurrentTestScenario.TestResults &&
                0 < TestData.CurrentTestScenario.TestResults.Count) {
                foreach (TestResult testResult in TestData.CurrentTestScenario.TestResults) {

                    switch (testResult.enStatus) {
                        case TestResultStatuses.Passed:
                            counterPassedResults++;
                            TestData.CurrentTestScenario.enStatus = TestScenarioStatuses.Passed;
                            break;
                        case TestResultStatuses.Failed:
                            TestData.CurrentTestScenario.enStatus = TestScenarioStatuses.Failed;
                            return;
                            //break;
                        case TestResultStatuses.NotTested:
                            
                            break;
                        case TestResultStatuses.KnownIssue:
                            counterKnownIssueResults++;
                            TestData.CurrentTestScenario.enStatus = TestScenarioStatuses.Passed;
                            break;
                        default:
                            throw new Exception("Invalid value for TestResultStatuses");
                    }
                }
                if (0 == counterPassedResults && 0 < counterKnownIssueResults) {
                    TestData.CurrentTestScenario.enStatus = TestScenarioStatuses.KnownIssue;
                }
            
                // set statistics
                // 20130322
                //RefreshScenarioStatistics(TestData.CurrentTestScenario);
                RefreshScenarioStatistics(TestData.CurrentTestScenario, skipAutomatic);
            }
        }
        
        internal static void SetSuiteStatus(bool skipAutomatic)
        {
            if (null == TestData.CurrentTestSuite) {
                TestData.InitCurrentTestScenario();
            }

            // 20130322
            //TestData.SetScenarioStatus();
            TestData.SetScenarioStatus(skipAutomatic);

            int counterPassedResults = 0;
            int counterKnownIssueResults = 0;
            
            if (TestData.CurrentTestSuite != null && 
                0 < TestData.CurrentTestSuite.TestScenarios.Count) {

                foreach (TestScenario scenario in TestData.CurrentTestSuite.TestScenarios) {

                    switch (scenario.enStatus) {
                        case TestScenarioStatuses.Passed:
                            counterPassedResults++;
                            TestData.CurrentTestSuite.enStatus = TestSuiteStatuses.Passed;
                            break;
                        case TestScenarioStatuses.Failed:
                            TestData.CurrentTestSuite.enStatus = TestSuiteStatuses.Failed;
                            return;
                            //break;
                        case TestScenarioStatuses.NotTested:

                            break;
                        case TestScenarioStatuses.KnownIssue:
                            counterKnownIssueResults++;
                            TestData.CurrentTestSuite.enStatus = TestSuiteStatuses.Passed;
                            break;
                        default:
                            // 20130428
                            //throw new Exception("Invalid value for TestScenarioStatuses");
                            // as Not Tested
                            break;
                    }
                }

                if (0 == counterPassedResults && 0 < counterKnownIssueResults) {

                    TestData.CurrentTestSuite.enStatus = TestSuiteStatuses.KnownIssue;
                }

                // set statistics
                // 20130322
                //RefreshSuiteStatistics(TestData.CurrentTestSuite);
                RefreshSuiteStatistics(TestData.CurrentTestSuite, skipAutomatic);

            }
        }
        
        internal static string GetTestPlatformId()
        {
            string result = string.Empty;            
            
            // read the last id used and generate a new one
            int testNumber = 
                TestData.TestPlatforms.Count; // + 1;
            bool noValidId = true;
            do {
                foreach (TestPlatform Platform in TestData.TestPlatforms) {
                    if (Platform.Id == testNumber.ToString()) {
                        testNumber++;
                    }
                }
                noValidId = false;
                result = testNumber.ToString();
            } while (noValidId);
            
            return result;
        }
        
        internal static string GetTestSuiteId()
        {
            string result = string.Empty;            
            
            // read the last id used and generate a new one
            int testNumber = 
                TestData.TestSuites.Count; // + 1;
            bool noValidId = true;
            do {
                foreach (TestSuite suite in TestData.TestSuites) {
                    if (suite.Id == testNumber.ToString()) {
                        testNumber++;
                    }
                }
                noValidId = false;
                result = testNumber.ToString();
            } while (noValidId);
            
            return result;
        }
        
        internal static string GetTestScenarioId()
        {
            string result = string.Empty;            

            // 20121220
            // 20130329
            //int scNumber = 0;
            int scNumber = 1;
            if (null != TestData.TestSuites && 0 < TestData.TestSuites.Count) {

                if (null != TestData.CurrentTestSuite.TestScenarios) {

                    // read the last used id and generate a new one
                    scNumber = 
                        TestData.CurrentTestSuite.TestScenarios.Count; // + 1;
                    bool noValidId = true;

                    do {

                        foreach (TestScenario scenario in TestData.CurrentTestSuite.TestScenarios) {

                            if (scenario.Id == scNumber.ToString()) {

                                scNumber++;
                            }
                        }
                        noValidId = false;

                        // 20130329
                        if (0 == scNumber) {
                            scNumber++;
                        }
                        
                        result = scNumber.ToString();
                    } while (noValidId);
                    
                    
                    
                } else {

                    result = scNumber.ToString();
                }
                
                
            } else {

                result = scNumber.ToString();
            }
            
            return result;
        }
        
        internal static string GetTestResultId()
        {
            string result = string.Empty;
            
            // 20121220
            int testNumber = 0;
            if (null != TestData.TestSuites && 0 < TestData.TestSuites.Count) {
                
                if (null != TestData.CurrentTestScenario) {
                    
                    if (null != TestData.CurrentTestScenario.TestResults) {
                        
                        // read the last used id and generate a new one
                        testNumber = 
                            TestData.CurrentTestScenario.TestResults.Count; // + 1;
                        bool noValidId = true;
                        do {
                            foreach (TestResult testResult in TestData.CurrentTestScenario.TestResults) {
                                if (testResult.Id == testNumber.ToString()) {
                                    testNumber++;
                                }
                            }
                            noValidId = false;
                            result = testNumber.ToString();
                        } while (noValidId);
                        
                    } else {
                        
                        result = testNumber.ToString();
                        
                    }
                    
                } else {
                    
                    result = testNumber.ToString();
                    
                }
            } else {
                
                result = testNumber.ToString();
                
            }
            
            return result;
        }
        
        internal static bool AttachTestResultCode()
        {
            bool result = false;
            
            
            
            return result;
        }
        
        // 20130331
        //internal static void AddTestResultTextDetail(object detail)
        internal static void AddTestResultTextDetail(TestResultDetailCmdletBase cmdlet, object detail)
        {
            ITestResultDetail testResultDetail = 
                new TestResultDetail();
            
//            if (TestData.TestSuites.Count == 0) {
//                InitTestData();
//            }
            
            testResultDetail.AddTestResultDetail(
                TestResultDetailTypes.Comment,
                detail.ToString());
            CurrentTestResult.Details.Add(testResultDetail);
            
            // 20130402
            testResultDetail.DetailStatus = cmdlet.TestResultStatus;
            
            // 20130331
            switch (cmdlet.TestResultStatus) {
                case TestResultStatuses.Failed:
                    cmdlet.WriteVerbose(cmdlet, "TestResultStatus = Failed");
                    // 20130402
                    //CurrentTestResult.enStatus = TestResultStatuses.Failed;
                    if (TestResultStatuses.KnownIssue != CurrentTestResult.enStatus) {
                        
                        CurrentTestResult.enStatus = TestResultStatuses.Failed;
                    }
                    break;
                case TestResultStatuses.Passed:
                    cmdlet.WriteVerbose(cmdlet, "TestResultStatus = Passed");
                    // 20130402
                    //CurrentTestResult.enStatus = TestResultStatuses.Passed;
                    if (TestResultStatuses.KnownIssue != CurrentTestResult.enStatus &&
                        TestResultStatuses.Failed != CurrentTestResult.enStatus) {
                        
                        CurrentTestResult.enStatus = TestResultStatuses.Passed;
                    }
                    break;
                case TestResultStatuses.NotTested:
                    cmdlet.WriteVerbose(cmdlet, "TestResultStatus = NotTested");
                    // nothing to do
                    break;
                case TestResultStatuses.KnownIssue:
                    cmdlet.WriteVerbose(cmdlet, "TestResultStatus = KnownIssue");
                    CurrentTestResult.enStatus = TestResultStatuses.KnownIssue;
                    break;
                default:
                    cmdlet.WriteVerbose(cmdlet, "TestResultStatus = ????");
                    cmdlet.WriteVerbose(cmdlet, cmdlet.TestResultStatus.ToString());
                	break;
            }
            
            OnTMXNewTestResultDetailAdded(testResultDetail, null);
            
            // 20130402
            if (cmdlet.Finished) {
                
                TMXHelper.TestCaseStarted =
                    System.DateTime.Now;
                    
                TestData.CurrentTestScenario.TestResults.Add(new TestResult(TestData.CurrentTestScenario.Id, TestData.CurrentTestSuite.Id));
                TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1] =
                    TestData.CurrentTestResult;
                
            }
        }
        
        internal static void AddTestResultErrorDetail(ErrorRecord detail)
        {
            ITestResultDetail testResultDetail = 
                new TestResultDetail();
            
//            if (TestData.TestSuites.Count == 0) {
//                InitTestData();
//            }
            
            testResultDetail.AddTestResultDetail(
                TestResultDetailTypes.ErrorRecord,
                detail);
            CurrentTestResult.Details.Add(testResultDetail);
        }
        
        internal static void AddTestResultScreenshotDetail(object detail)
        {
            ITestResultDetail testResultDetail = 
                new TestResultDetail();
            
//            if (TestData.TestSuites.Count == 0) {
//                InitTestData();
//            }
            
            testResultDetail.AddTestResultDetail(
                TestResultDetailTypes.Screenshot,
                detail.ToString());
            CurrentTestResult.Details.Add(testResultDetail);
            CurrentTestResult.SetScreenshot(detail.ToString());
        }
        
        internal static bool AddTestPlatform(
            string testPlatformName,
            string testPlatformId,
            string testPlatformDesctiption,
            string testPlatformOS,
            string testPlatformVersion,
            string testPlatformArchitecture,
            string testPlatformLanguage)
        {
            bool result = false;
            
            // 20130429
            TMX.Logger.TMXLogger.Info("Test platform: '" + testPlatformName + "'");
            
            if (testPlatformId == null || testPlatformId == string.Empty) {
                testPlatformId = 
                    GetTestPlatformId();
            }
            
            // 20121219
            if (null != GetTestPlatform(testPlatformName, testPlatformId)) {
                // the suite requested won't be duplicated, exit
                return false;
            }
            
            TestPlatforms.Add(new TestPlatform(testPlatformName, testPlatformId));
            if (testPlatformDesctiption != null && testPlatformDesctiption != string.Empty) {
                TestData.TestPlatforms[TestPlatforms.Count - 1].Description = 
                    testPlatformDesctiption;
            }
            
            TestData.TestPlatforms[TestPlatforms.Count - 1].OperatingSystem = testPlatformOS;
            TestData.TestPlatforms[TestPlatforms.Count - 1].Version = testPlatformVersion;
            TestData.TestPlatforms[TestPlatforms.Count - 1].Architecture = testPlatformArchitecture;
            TestData.TestPlatforms[TestPlatforms.Count - 1].Language = testPlatformLanguage;
            
            TestData.CurrentTestPlatform = 
                TestData.TestPlatforms[TestPlatforms.Count - 1];
            
            if (TestData.CurrentTestPlatform != null) {

                OnTMXNewTestPlatformCreated(TestData.CurrentTestPlatform, new EventArgs()); //null);
            } else {
                //
            }
            
            if (TMX.Preferences.Storage) {
                // 20130527
    			using (var session = StorageHelper.SessionFactory.OpenSession())
                {
                    session.Save(TestData.CurrentTestPlatform);
    			}
            }
            
            result = true;
            return result;
        }
        
        internal static bool AddTestSuite(string testSuiteName, 
                                          string testSuiteId,
                                          string testPlatformId,
                                          string testSuiteDesctiption,
                                          ScriptBlock[] testSuiteBeforeScenario,
                                          ScriptBlock[] testSuiteAfterScenario)
        {
            bool result = false;
            
            // 20130429
            TMX.Logger.TMXLogger.Info("Test suite: '" + testSuiteName + "'");
            
            if (testSuiteId == null || testSuiteId == string.Empty) {
                testSuiteId = 
                    GetTestSuiteId();
            }
            
            // 20121219
            if (null != GetTestSuite(testSuiteName, testSuiteId, testPlatformId)) {
                // the suite requested won't be duplicated, exit
                return false;
            }
            
            // 20130612
            // removing the first (autogenerated) suite
            try {
                if (1 == TMX.TestData.TestSuites.Count && "autogenerated" == TMX.TestData.TestSuites[0].Name &&
                    1 == TMX.TestData.TestSuites[0].TestScenarios.Count && "autogenerated" == TMX.TestData.TestSuites[0].TestScenarios[0].Name &&
                    1 == TMX.TestData.TestSuites[0].TestScenarios[0].TestResults.Count && TestResultOrigins.Automatic == TMX.TestData.TestSuites[0].TestScenarios[0].TestResults[0].Origin) {
                    
                    TMX.TestData.TestSuites.RemoveAt(0);
                }
            }
            catch {}
            
            // 20130301
            // set time spent on the previous suite
            if (null != TMX.TestData.CurrentTestSuite) {
                
                if (System.DateTime.MinValue != TMX.TestData.CurrentTestSuite.Timestamp) {

                    TMX.TestData.CurrentTestSuite.SetTimeSpent(
                        TMX.TestData.CurrentTestSuite.TimeSpent +=
                        (System.DateTime.Now - TMX.TestData.CurrentTestSuite.Timestamp).TotalSeconds);
                    TMX.TestData.CurrentTestSuite.Timestamp = System.DateTime.MinValue;
                }
                
//                // 20130407 (added)
//                try {
//                    if (TMX.TestData.CurrentTestSuite.Name == TMX.TestData.TestSuites[TMX.TestData.TestSuites.Count - 1].Name &&
//                        TMX.TestData.CurrentTestSuite.Id == TMX.TestData.TestSuites[TMX.TestData.TestSuites.Count - 1].Id) {
//Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! here !!!!!!!!!!!!!!!!!!!!!!!!!!!!!>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
//                        TMX.TestData.TestSuites[TMX.TestData.TestSuites.Count - 1] = TMX.TestData.CurrentTestSuite;
//                    }
//                }
//                catch {}
            }
            
            TestSuites.Add(new TestSuite(testSuiteName, testSuiteId));
            if (testSuiteDesctiption != null && testSuiteDesctiption != string.Empty) {
                TestData.TestSuites[TestSuites.Count - 1].Description = 
                    testSuiteDesctiption;
            }
            
            TestData.CurrentTestSuite = 
                TestData.TestSuites[TestSuites.Count - 1];
            
            if (TestData.CurrentTestSuite != null) {
                
//                // 20130531
//                try {
//                    TestData.CurrentTestSuite.PlatformId =
//                        TestData.CurrentTestPlatform.Id;
//                }
//                catch {}
                
                // 20131612
                if (null != testPlatformId && string.Empty != testPlatformId) {
                    TestData.CurrentTestSuite.PlatformId = testPlatformId;
                } else {
                    TestData.CurrentTestSuite.PlatformId =
                        TestData.CurrentTestPlatform.Id;
                }
                
                // 20130615
                TMX.TestData.CurrentTestSuite.BeforeScenario = testSuiteBeforeScenario;
                TMX.TestData.CurrentTestSuite.AfterScenario = testSuiteAfterScenario;
                
                // 20130301
                // set the initial time for this suite's session
                TestData.CurrentTestSuite.SetNow();

                OnTMXNewTestSuiteCreated(TestData.CurrentTestSuite, new EventArgs()); //null);
            } else {
                //
            }
            
            if (TMX.Preferences.Storage) {
                // 20130527
    			using (var session = StorageHelper.SessionFactory.OpenSession())
                {
                    session.Save(TestData.CurrentTestSuite);
    			}
            }
            
            result = true;
            return result;
        }
        
        internal static TestPlatform GetTestPlatform(string testPlatformName, string testPlatformId)
        {
            TestPlatform result = null;

            // 20121219
            if (null != testPlatformName && string.Empty != testPlatformName) {
                foreach (TestPlatform testPlatform in TestPlatforms) {
                    if (testPlatform.Name == testPlatformName) {
                        
                        // id does not match
                        if (testPlatformId != string.Empty && 
                            testPlatformId != null &&
                            testPlatformId != testPlatform.Id) {

                            // 201212119
                            continue;
                        }
                        if (testPlatformId != string.Empty && 
                            testPlatformId != null &&
                            testPlatformId == testPlatform.Id) {

                            result = testPlatform;
                        }
                        if (testPlatformId == string.Empty || testPlatformId == null) {

                            result = testPlatform;
                        }
                        if (result != null) {

                            return result;
                        }
                    }
                }
            }
            
            // 20121219
            if (null != testPlatformId && string.Empty != testPlatformId) {
                foreach (TestPlatform testPlatform in TestPlatforms) {
                    if (testPlatform.Id == testPlatformId) {

                        result = testPlatform;
                        return result;
                    }
                }
            }
            return result;
        }
        
        internal static TestSuite GetTestSuite(string testSuiteName, string testSuiteId, string testPlatformId)
        {
            TestSuite result = null;
            
            // 20121219
            if (null != testSuiteName && string.Empty != testSuiteName) {
                foreach (TestSuite testSuite in TestSuites) {
                    if (testSuite.Name == testSuiteName) {
                        
                        // id does not match
                        if (testSuiteId != string.Empty && 
                            testSuiteId != null &&
                            testSuiteId != testSuite.Id) {
                            
                            // 201212119
                            continue;
                        }
                        if (testSuiteId != string.Empty && 
                            testSuiteId != null &&
                            testSuiteId == testSuite.Id) {
                            
                            if (testPlatformId != testSuite.PlatformId) {
                                continue;
                            } else {
                                result = testSuite;
                            }
                        }
                        if (testSuiteId == string.Empty || testSuiteId == null) {
                            
                            // does this code ever work?
                            if (testPlatformId != testSuite.PlatformId) {
                                
                                continue;
                            } else {
                                
                                result = testSuite;
                            }
                        }
                        if (result != null) {
                            
                            return result;
                        }
                    }
                }
            }
            
            // 20121219
            if (null != testSuiteId && string.Empty != testSuiteId) {
                foreach (TestSuite testSuite in TestSuites) {
                    if (testSuite.Id == testSuiteId) {
                        
                        if (testPlatformId != testSuite.PlatformId) {
                            
                            continue;
                        } else {
                            
                            result = testSuite;
                            return result;
                        }
                    }
                }
            }
            return result;
        }
        
internal static void dumpTestStructure(string strNumber)
{
//    try {
//        int tsCounter = TestData.TestSuites.Count;
//        int tscCounter = TestData.TestSuites[tsCounter - 1].TestScenarios.Count;
//        int trCounter = TestData.TestSuites[tsCounter - 1].TestScenarios[tscCounter - 1].TestResults.Count;
//        try { Console.WriteLine(strNumber + " TestData.TestSuites[tsCounter - 1].TestScenarios[tscCounter - 1].TestResults[trCounter - 1].Status = " + TestData.TestSuites[tsCounter - 1].TestScenarios[tscCounter - 1].TestResults[trCounter - 1].Status); } catch {}
//        try { Console.WriteLine(strNumber + " TestData.TestSuites[tsCounter - 1].TestScenarios[tscCounter - 2].TestResults[trCounter - 1].Status = " + TestData.TestSuites[tsCounter - 1].TestScenarios[tscCounter - 2].TestResults[trCounter - 1].Status); } catch {}
//        try { Console.WriteLine(strNumber + " TestData.CurrentTestSuite.TestScenarios[tscCounter44 - 1].TestResults[trCounter44 - 1].Status = " + TestData.CurrentTestSuite.TestScenarios[tscCounter - 1].TestResults[trCounter - 1].Status); } catch {}
//        try { Console.WriteLine(strNumber + " TestData.CurrentTestScenario.TestResults[trCounter44 - 1].Status = " + TestData.CurrentTestScenario.TestResults[trCounter - 1].Status); } catch {}
//        try { Console.WriteLine(strNumber + " TestData.CurrentTestResult.Status = " + TestData.CurrentTestResult.Status); } catch {}
//    } catch {}
}
        
        internal static bool AddTestCase(
            //TestScenario testScenario,
            string testCaseName,
            string testCaseId,
            string testCaseDescription,
            string testSuiteName,
            string testSuiteId,
            string testScenarioName,
            string testScenarioId,
            string testPlatformId,
            ScriptBlock[] testCode)
        {
            bool result = false;
            
            TestSuite testSuite =
                TestData.GetTestSuite(
                    testSuiteName,
                    testSuiteId,
                    testPlatformId);
            
            if (null == testSuite) { // ?? mistaken behavior ??
                
                testSuite = TestData.CurrentTestSuite;
            }
            
Console.WriteLine("test suite: " + testSuite.Name + "\t" + testSuite.Id);
            
            TestScenario testScenario =
                TestData.GetTestScenario(
                    testSuite,
                    testScenarioName,
                    testScenarioId,
                    testSuiteName,
                    testSuiteId,
                    testPlatformId);
            
            if (null == testScenario) { // ?? mistaken behavior ??
                
                testScenario = TestData.CurrentTestScenario;
            }
            
Console.WriteLine("test scenario: " + testScenario.Name + "\t" + testScenario.Id);
            
            TestCase testCase =
                new TestCase(
                    testCaseName,
                    testCaseId);
            
            testCase.Description = testCaseDescription;
            testCase.TestCode = testCode;
            // 20130617
            TMX.TestData.CurrentTestCase = testCase;
            
            try {
                
                testScenario.TestCases.Add(testCase);
                result = true;
            }
            catch (Exception eFailedToAdd) {
                throw eFailedToAdd;
                //result = false;
            }
            
            return result;
        }
        
        internal static bool AddTestScenario(TestSuite testSuite,
                                             string testScenarioName,
                                             string testScenarioId,
                                             string testScenarioDescription,
                                             string testSuiteName,
                                             string testSuiteId,
                                             string testPlatformId,
                                             ScriptBlock[] testScenarioBeforeTest,
                                             ScriptBlock[] testScenarioAfterTest)
        {
            bool result = false;
            
            // clean up the last empty test result
            // in the previous scenario
            if (TestData.CurrentTestScenario != null) {
                
                if (TestData.CurrentTestScenario.TestResults.Count > 0) {
                    
                    if (TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1].Details.Count == 0 &&
                        TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1].Status == TestStateNotTested) {

                        TestData.CurrentTestScenario.TestResults.RemoveAt(TestData.CurrentTestScenario.TestResults.Count - 1);
                    }
                }
                
//                // 20130405
//                if ((null != TestData.CurrentTestResult.Name &&
//                     string.Empty != TestData.CurrentTestResult.Name) ||
//                    (0 < TestData.CurrentTestResult.Details.Count)) {
//                    //TMXHelper.TestCaseStarted =
//                    //    System.DateTime.Now;
//                    TestData.CurrentTestScenario.TestResults.Add(new TestResult(TestData.CurrentTestScenario.Id, TestData.CurrentTestSuite.Id));
//                    TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1] =
//                        TestData.CurrentTestResult;
//                }
            }
            
            // 20130301
            // set time spent on the previous scenario
            if (null != TMX.TestData.CurrentTestScenario) {
            	
                if (System.DateTime.MinValue != TMX.TestData.CurrentTestScenario.Timestamp) {
                    
                    TMX.TestData.CurrentTestScenario.SetTimeSpent(
                        TMX.TestData.CurrentTestScenario.TimeSpent +=
                        (System.DateTime.Now - TMX.TestData.CurrentTestScenario.Timestamp).TotalSeconds);
                    TMX.TestData.CurrentTestScenario.Timestamp = System.DateTime.MinValue;
                }
            }
dumpTestStructure("2");
            
            if (testSuite != null) {
                
                TestData.CurrentTestSuite = testSuite;
            } else if (testSuite == null && 
                       testSuiteName != string.Empty &&
                       testSuiteName != null) {
                
                TestSuite testSuite2 = 
                    GetTestSuite(testSuiteName, testSuiteId, testPlatformId);
                if (testSuite2 != null) {
                    
                    TestData.CurrentTestSuite = testSuite2;
                }
            } else if (testSuite == null && 
                       testSuiteId != string.Empty &&
                       testSuiteId != null) {
                
                TestSuite testSuite3 = 
                    GetTestSuite(testSuiteName, testSuiteId, testPlatformId);
                if (testSuite3 != null) {
                    
                    TestData.CurrentTestSuite = testSuite3;
                }
            }
            
            if (TestData.CurrentTestSuite == null) {
                
                return result;
            }
            
            if (testScenarioId == null || testScenarioId == string.Empty) {
                
                testScenarioId = 
                    GetTestScenarioId();
            }
            
dumpTestStructure("4");
            
//            // 20130405
//            if (null != TestData.TestSuites && 0 < TestData.TestSuites.Count) {
//                int lastTestSuiteNumber = TestData.TestSuites.Count - 1;
//
//                if (null != TestData.TestSuites[lastTestSuiteNumber].TestScenarios && 0 < TestData.TestSuites[lastTestSuiteNumber].TestScenarios.Count) {
//                    int lastTestScenarioNumber = TestData.TestSuites[lastTestSuiteNumber].TestScenarios.Count - 1;
//
//                    if (TestData.CurrentTestScenario.Name == TestData.TestSuites[lastTestSuiteNumber].TestScenarios[lastTestScenarioNumber].Name &&
//                        TestData.CurrentTestScenario.Id == TestData.TestSuites[lastTestSuiteNumber].TestScenarios[lastTestScenarioNumber].Id) {
//                        
//                        TestData.TestSuites[lastTestSuiteNumber].TestScenarios[lastTestScenarioNumber] = TestData.CurrentTestScenario;
//                    }
//                }
//            }

dumpTestStructure("4.4");
            
            TestData.CurrentTestSuite.TestScenarios.Add(
                new TestScenario(testScenarioName, testScenarioId, TestData.CurrentTestSuite.Id)); //testSuiteId));
            
dumpTestStructure("4.5");
            // description
            if (testScenarioDescription != null && testScenarioDescription != string.Empty) {
                
                TestData.CurrentTestSuite.TestScenarios[CurrentTestSuite.TestScenarios.Count - 1].Description = 
                    testScenarioDescription;
            }
            
dumpTestStructure("4.6");
            TestData.CurrentTestScenario = 
                (TestScenario)TestData.CurrentTestSuite.TestScenarios[CurrentTestSuite.TestScenarios.Count - 1];
            
            // 20130615
            // 20130616
            TMX.TestData.CurrentTestScenario.BeforeTest = testScenarioBeforeTest;
            TMX.TestData.CurrentTestScenario.AfterTest = testScenarioAfterTest;
            
//            // 20130531
//            try {
//                
//                TestData.CurrentTestScenario.PlatformId =
//                    TestData.CurrentTestPlatform.Id;
//            }
//            catch {
//                
//            }
            
            // 20130612
            if (null != testPlatformId && string.Empty != testPlatformId) {
                TestData.CurrentTestScenario.PlatformId = testPlatformId;
            } else {
                TestData.CurrentTestScenario.PlatformId =
                    //TestData.CurrentTestPlatform.Id;
                    TestData.CurrentTestSuite.PlatformId;
            }
            
            // 20130301
            // set the initial time for this scenario's session
            CurrentTestScenario.SetNow();
            
            OnTMXNewTestScenarioAdded(TestData.CurrentTestScenario, null);
            
            if (TMX.Preferences.Storage) {
                
                // 20130527
    			using (var session = StorageHelper.SessionFactory.OpenSession())
                {
    			    
                    session.Save(TestData.CurrentTestScenario);
    			}
            }
            
            result = true;

dumpTestStructure("7");
            
            return result;
        }
        
        internal static TestCase GetTestCase(
            TestSuite testSuite,
            string testCaseName,
            string testCaseId,
            string testScenarioName,
            string testScenarioId,
            string testSuiteName,
            string testSuiteId,
            string testPlatformId)
        {
            TestCase result = null;
            
            if (null == testSuite) {
                
                testSuite =
                    TMX.TestData.GetTestSuite(
                        testSuiteName,
                        testSuiteId,
                        testPlatformId);
                
            }
            
            TestScenario testScenario = null;
            
            if (null != testSuite) {
                
                testScenario =
                    TMX.TestData.GetTestScenario(
                        testSuite,
                        testScenarioName,
                        testScenarioId,
                        testSuiteName,
                        testSuiteId,
                        testPlatformId);
            }
            
            if (null != testScenario && 0 < testScenario.TestCases.Count) {
                
                foreach (TestCase testCase in testScenario.TestCases) {
                    
                    if ((testCaseName == testCase.TestCaseName &&
                        testCaseId == testCase.TestCaseId) ||
                        (null == testCaseName && testCaseId == testCase.TestCaseId) ||
                        (null == testCaseId && testCaseName == testCase.TestCaseName)){
                        
                        result = testCase;
                        break;
                    }
                }
            }
            
            return result;
        }
        
        internal static TestScenario GetTestScenario(
            TestSuite testSuite,
            string testScenarioName,
            string testScenarioId,
            string testSuiteName,
            string testSuiteId,
            string testPlatformId)
        {
            TestScenario result = null;

            if (testSuite != null) {
                TestData.CurrentTestSuite = testSuite;
            } else if (testSuite == null && 
                       testSuiteName != string.Empty &&
                       testSuiteName != null) {
                TestSuite testSuite2 = 
                    GetTestSuite(testSuiteName, testSuiteId, testPlatformId);
                if (testSuite2 != null) {
                    TestData.CurrentTestSuite = testSuite2;
                }
            } else if (testSuite == null && 
                       testSuiteId != string.Empty &&
                       testSuiteId != null) {
                TestSuite testSuite3 = 
                    GetTestSuite(testSuiteName, testSuiteId, testPlatformId);
                if (testSuite3 != null) {
                    TestData.CurrentTestSuite = testSuite3;
                }
            }
            
            if (TestData.CurrentTestSuite == null) {
                return result;
            }
            
            if (testScenarioName != null && testScenarioName != string.Empty) {
                foreach (TestScenario testScenario in TestData.CurrentTestSuite.TestScenarios) {
                    if (testScenario.Name == testScenarioName) {
                        TestData.CurrentTestScenario = testScenario;
                        return testScenario;
                    }
                }
            }
            
            if (testScenarioId != null && testScenarioId != string.Empty) {
                foreach (TestScenario testScenario in TestData.CurrentTestSuite.TestScenarios) {
                    if (testScenario.Id == testScenarioId) {
                        TestData.CurrentTestScenario = testScenario;
                        return testScenario;
                    }
                }
            }

            return result;
        }
        
        internal static System.Linq.IOrderedEnumerable<TMX.TestSuite> SearchTestSuite(
            Func<TestSuite, bool> query,
            Func<TestSuite, object> ordering,
            bool desc)
        {
            IOrderedEnumerable<TestSuite> result = null;
            
            if (desc) {
                result =
                    from suite in TestData.TestSuites
                    where query(suite)
                    orderby ordering(suite) descending
                    select suite;
            } else {
                result =
                    from suite in TestData.TestSuites
                    where query(suite)
                    orderby ordering(suite) ascending
                    select suite;
            }
            return result;
        }
        
        private static System.Collections.Generic.List<TestScenario> getAllScenarios()
        {
            List<TestScenario> result = new List<TestScenario>();
            foreach (TestSuite suite in TestData.TestSuites) {
                foreach (TestScenario scenario in suite.TestScenarios) {
                    result.Add(scenario);
                }
            }
            return result;
        }
        
        internal static System.Linq.IOrderedEnumerable<TMX.TestScenario> SearchTestScenario(
            Func<TestScenario, bool> query,
            Func<TestScenario, object> ordering,
            bool desc)
        {
            IOrderedEnumerable<TestScenario> result = null;
            
            if (desc) {
                result =
                    from scenario in getAllScenarios()
                    where query(scenario)
                    orderby ordering(scenario) descending
                    select scenario;
            } else {
                result =
                    from scenario in getAllScenarios()
                    where query(scenario)
                    orderby ordering(scenario) ascending
                    select scenario;
            }
            
            return result;
        }
        
        private static System.Collections.Generic.List<TestResult> getAllTestResults()
        {
            List<TestResult> result = new List<TestResult>();
            foreach (TestSuite suite in TestData.TestSuites) {
                foreach (TestScenario scenario in suite.TestScenarios) {
                    foreach (TestResult testResult in scenario.TestResults) {
                        result.Add(testResult);
                    }
                }
            }
            return result;
        }
        
        internal static System.Linq.IOrderedEnumerable<TMX.TestResult> SearchTestResult(
            Func<TestResult, bool> query,
            Func<TestResult, object> ordering,
            bool desc)
        {
            IOrderedEnumerable<TestResult> result = null;
            
            if (desc) {
                result =
                    from testResult in getAllTestResults()
                    where query(testResult)
                    orderby ordering(testResult) descending
                    select testResult;
            } else {
                result =
                    from testResult in getAllTestResults()
                    where query(testResult)
                    orderby ordering(testResult) ascending
                    select testResult;
            }
            return result;
        }
    }
}
