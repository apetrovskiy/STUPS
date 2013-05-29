/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/19/2012
 * Time: 2:46 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of TestSuite.
    /// </summary>
    public class TestSuite : ITestSuite
    {
        public TestSuite()
        {
            TestScenarios = new List<ITestScenario>();
            this.Statistics = new TestStat();
            this.enStatus = TestSuiteStatuses.NotTested;
            
            // 20130301
            this.SetNow();
            
            // 20130529
            this.PlatformIds =
                new List<string>();
            this.Tags =
                new List<string>();
        }
        
        public TestSuite(string testSuiteName, string testSuiteId)
        {
            TestScenarios = new List<ITestScenario> ();
            this.Statistics = new TestStat();
            this.enStatus = TestSuiteStatuses.NotTested;
            this.Name = testSuiteName;
            if (testSuiteId != string.Empty) {
                this.Id = testSuiteId;
            } else {
                this.Id = 
                    TestData.GetTestSuiteId();
            }
            
            // 20130301
            this.SetNow();
        }
        
        //public virtual int DbId { get; protected set; }
        public virtual int DbId { get; set; }
        public string Name { get; internal set; }
        public string Id { get; internal set; }
        public System.Collections.Generic.List<ITestScenario> TestScenarios { get; internal set; }
        public string Description { get; set; }

        private string status;
        public string Status { get { return this.status; } }
        private TestSuiteStatuses _enStatus;
        internal TestSuiteStatuses enStatus 
        { 
            get { return this._enStatus; }
            set{
                this._enStatus = value;

                switch (value) {
                    case TestSuiteStatuses.Passed:
                        this.status = TMX.TestData.TestStatePassed;
                        break;
                    case TestSuiteStatuses.Failed:
                        this.status = TMX.TestData.TestStateFailed;
                        break;
                    case TestSuiteStatuses.NotTested:
                        this.status = TMX.TestData.TestStateNotTested;
                        break;
                    case TestSuiteStatuses.KnownIssue:
                        this.status = TMX.TestData.TestStateKnownIssue;
                        break;
                    default:
                        throw new Exception("Invalid value for TestSuiteStatuses");
                }
            }
        }
        
        public TestStat Statistics { get; set; }
        
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
