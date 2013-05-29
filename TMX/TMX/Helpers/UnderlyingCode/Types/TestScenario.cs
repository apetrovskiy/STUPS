/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/19/2012
 * Time: 2:52 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of TestScenario.
    /// </summary>
    public class TestScenario : ITestScenario
    {
        public TestScenario()
        {
            this.TestResults = new List<ITestResult> ();
            this.Statistics = new TestStat();
            this.enStatus = TestScenarioStatuses.NotTested;
            try{
                if (TestData.CurrentTestResult.Details.Count > 0) {
                    TMX.TestData.AddTestResult(
                        "autoclosed", 
                        TestData.GetTestResultId(), 
                        null, 
                        false, // isKnownIssue
                        false, // generateNextResult
                        null, // MyInvocation
                        null, // Error
                        string.Empty,
                        // 20130322
                        //true);
                        true,
                        false);
                } else {
                    TestData.CurrentTestResult = null;
                }
            }
            catch {}
            
            // 20130529
            this.PlatformIds =
                new List<string>();
            this.Tags =
                new List<string>();
            
            // 20130301
            this.SetNow();
            
            this.TestResults.Add(
                new TestResult(
                    TestData.TestSuites[TestData.TestSuites.Count - 1].TestScenarios[TestData.TestSuites[TestData.TestSuites.Count - 1].TestScenarios.Count - 1].Id, // "???",
                    TestData.TestSuites[TestData.TestSuites.Count - 1].Id)); // "???"));
            TestData.CurrentTestResult = 
                this.TestResults[TestResults.Count - 1];
        }
        
        public TestScenario(
            string testScenarioName, 
            string testScenarioId,
            string testSuiteId)
        {
            this.TestResults = new List<ITestResult> ();
            this.Statistics = new TestStat();
            this.enStatus = TestScenarioStatuses.NotTested;
            this.Name = testScenarioName;
            if (testScenarioId != string.Empty && testScenarioId != null) {
                this.Id = testScenarioId;
            } else {
                this.Id = 
                    TestData.GetTestScenarioId();
            }
            
            // suiteId
            this.SuiteId = testSuiteId;
            
            try{
TestData.dumpTestStructure("TestScenario #1");
                if (TestData.CurrentTestResult.Details.Count > 0) {
                    TMX.TestData.AddTestResult(
                        "autoclosed", 
                        TestData.GetTestResultId(), 
                        null, 
                        false, // isKnownIssue
                        false, // generateNextResult
                        null, // MyInvocation
                        null, // Error
                        string.Empty,
                        // 20130322
                        //true);
                        true,
                        false);
TestData.dumpTestStructure("TestScenario #2");
                } else {
TestData.dumpTestStructure("TestScenario #3");
                    TestData.CurrentTestResult = null;
                }
            }
            catch {}
            
            // 20130529
            this.PlatformIds =
                new List<string>();
            this.Tags =
                new List<string>();
            
            // 20130301
            this.SetNow();
TestData.dumpTestStructure("TestScenario #4");
            this.TestResults.Add(
                new TestResult(
                   this.Id,
                   this.SuiteId));
TestData.dumpTestStructure("TestScenario #5");
            
            // 20130407
            try {
TestData.dumpTestStructure("TestScenario #5.1");
                if ((null != TestData.CurrentTestResult.Name ||
                    null != TestData.CurrentTestResult.Id) &&
                    null != TestData.CurrentTestResult.Details &&
                    0 < TestData.CurrentTestResult.Details.Count) {
TestData.dumpTestStructure("TestScenario #5.3");
                    TestData.CurrentTestScenario.TestResults.Add(TestData.CurrentTestResult);
TestData.dumpTestStructure("TestScenario #5.5");
                }
            }
            catch (Exception eeeee) {
                //Console.WriteLine(eeeee.Message);
            }
TestData.dumpTestStructure("TestScenario #5.9");
            TestData.CurrentTestResult = 
                TestResults[TestResults.Count - 1];
TestData.dumpTestStructure("TestScenario #6");
        }
        
        //public virtual int DbId { get; protected set; }
        public virtual int DbId { get; set; }
        public string Name { get; internal set; }
        public string Id { get; internal set; }
        public System.Collections.Generic.List<ITestResult> TestResults {get; internal set; }
        public string Description { get; set; }

        private string status;
        public string Status { get { return this.status; } }
        private TestScenarioStatuses _enStatus;
        internal TestScenarioStatuses enStatus
        { 
            get { return this._enStatus; }
            set{
                this._enStatus = value;

                switch (value) {
                    case TestScenarioStatuses.Passed:
                        this.status = TMX.TestData.TestStatePassed;
                        break;
                    case TestScenarioStatuses.Failed:
                        this.status = TMX.TestData.TestStateFailed;
                        break;
                    case TestScenarioStatuses.NotTested:
                        this.status = TMX.TestData.TestStateNotTested;
                        break;
                    case TestScenarioStatuses.KnownIssue:
                        this.status = TMX.TestData.TestStateKnownIssue;
                        break;
                    default:
                        // 20130428
                        //throw new Exception("Invalid value for TestScenarioStatuses");
                        this.status = TMX.TestData.TestStateNotTested;
                        break;
                }
            }
        }
        
        public TestStat Statistics { get; set; }
        
        public string SuiteId { get; internal set; }
        
        // 20130301
        public System.DateTime Timestamp { get; internal set; }
        public void SetNow()
        {
            this.Timestamp = System.DateTime.Now;
        }
        public double TimeSpent { get; internal set; }
        public void SetTimeSpent(double timeSpent)
        {
            this.TimeSpent = timeSpent;
        }
        
        public List<string> Tags { get; set; }
        
        public List<string> PlatformIds { get; set; }
    }
}
