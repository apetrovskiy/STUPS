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
                        true);
                } else {
                    TestData.CurrentTestResult = null;
                }
            }
            catch {}
            
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
                        true);
                } else {
                    TestData.CurrentTestResult = null;
                }
            }
            catch {}
            
            this.TestResults.Add(
                new TestResult(
                   this.Id,
                   this.SuiteId));
            TestData.CurrentTestResult = 
                TestResults[TestResults.Count - 1];
        }
        
        public string Name { get; internal set; }
        public string Id { get; internal set; }
        public System.Collections.Generic.List<ITestResult> TestResults {get; internal set; }
        public string Description { get; set; }
        public string Status { get; internal set; }
        private TestScenarioStatuses _enStatus;
        internal TestScenarioStatuses enStatus
        { 
            get { return this._enStatus; }
            set{
                this._enStatus = value;
                if (value == TestScenarioStatuses.Failed) {
                    this.Status = TMX.TestData.TestStateFailed;
                }
                if (value == TestScenarioStatuses.Passed) {
                    this.Status = TMX.TestData.TestStatePassed;
                }
                if (value == TestScenarioStatuses.NotTested) {
                    this.Status = TMX.TestData.TestStateNotTested;
                }
            }
        }
        
        public TestStat Statistics { get; set; }
        
        public string SuiteId { get; internal set; }
    }
}
