/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/19/2012
 * Time: 2:53 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TestResult.
    /// </summary>
    public class TestResult : ITestResult
    {
        public TestResult(
           string testScenarioId,
           string testSuiteId)
        {
            this.Details = 
                new List<ITestResultDetail > ();
            this.enStatus = TestResultStatuses.NotTested;
            
            // scenarioId and suiteId
            this.ScenarioId = testScenarioId;
            this.SuiteId = testSuiteId;
        }
        
        public string Name { get; set; }
        public string Id { get; set; }
        public string Description { get; set; }
        public List<ITestResultDetail> Details { get; internal set; }
        
        public string ScriptName { get; internal set; }
        public void SetScriptName(string scriptName)
        {
            this.ScriptName = scriptName;
        }
        public int LineNumber { get; internal set; }
        public void SetLineNumber(int lineNumber)
        {
            this.LineNumber = lineNumber;
        }
        public int Position { get; internal set; }
        public void SetPosition(int position)
        {
            this.Position = position;
        }
        public ErrorRecord Error { get; internal set; }
        public void SetError(ErrorRecord error)
        {
            this.Error = error;
        }
        public string Code { get; set; }
        
        public List<object> Parameters { get; internal set; }

        private string status;
        public string Status { get { return this.status; } }
        private TestResultStatuses _enStatus;
        public TestResultStatuses enStatus
        { 
            get { return this._enStatus; }
            set{
                this._enStatus = value;

                switch (value) {
                    case TestResultStatuses.Passed:
                        this.status = TMX.TestData.TestStatePassed;
                        break;
                    case TestResultStatuses.Failed:
                        this.status = TMX.TestData.TestStateFailed;
                        break;
                    case TestResultStatuses.NotTested:
                        this.status = TMX.TestData.TestStateNotTested;
                        break;
                    case TestResultStatuses.KnownIssue:
                        this.status = TMX.TestData.TestStateKnownIssue;
                        break;
                    default:
                        throw new Exception("Invalid value for TestResultStatuses");
                }
            }
        }
        
        public double TimeSpent { get; internal set; }
        public void SetTimeSpent(double timeSpent)
        {
            this.TimeSpent = timeSpent;
        }
        
        public System.DateTime Timestamp { get; internal set; }
        public void SetNow()
        {
            this.Timestamp = System.DateTime.Now;
        }
        
        public string SuiteId { get; internal set; }
        public string ScenarioId { get; internal set; }
        
        public bool Generated { get; internal set; }
        public void SetGenerated()
        {
            this.Generated = true;
        }
        
        public string Screenshot { get; internal set; }
        public void SetScreenshot(string path)
        {
            this.Screenshot = path;
        }
        
        public TestResultOrigins Origin { get; internal set; }
        public void SetOrigin(TestResultOrigins origin)
        {
            if (TestResultOrigins.Logical == this.Origin) {
                
                // don't change the origin - it already was logical
            } else {
                
                this.Origin = origin;
            }
        }
    }
}
