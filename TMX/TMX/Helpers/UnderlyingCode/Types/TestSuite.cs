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
    using System.Management.Automation;
	using TMX.Interfaces;
	using TMX.Interfaces.TestStructure;
    
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
        }
        
        public TestSuite(string testSuiteName, string testSuiteId)
        {
            TestScenarios = new List<ITestScenario> ();
            this.Statistics = new TestStat();
            this.enStatus = TestSuiteStatuses.NotTested;
            this.Name = testSuiteName;
            this.Id = testSuiteId != string.Empty ? testSuiteId : TestData.GetTestSuiteId();

            /*
            if (testSuiteId != string.Empty) {
                this.Id = testSuiteId;
            } else {
                this.Id = 
                    TestData.GetTestSuiteId();
            }
            */

            // 20130301
            this.SetNow();
        }
        
        //public virtual int DbId { get; protected set; }
        public virtual int DbId { get; set; }
        public virtual string Name { get; protected internal set; }
        public virtual string Id { get; protected internal set; }
        public virtual System.Collections.Generic.List<ITestScenario> TestScenarios { get; protected internal set; }
        public virtual string Description { get; set; }

        private string status;
        public virtual string Status { get { return this.status; } }
        private TestSuiteStatuses _enStatus;
        protected internal virtual TestSuiteStatuses enStatus 
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
        
        public virtual TestStat Statistics { get; set; }
        
        // 20130301
        public virtual System.DateTime Timestamp { get; protected internal set; }
        public virtual void SetNow()
        {
            this.Timestamp = System.DateTime.Now;
        }
        public virtual double TimeSpent { get; protected internal set; }
        public virtual void SetTimeSpent(double timeSpent)
        {
            this.TimeSpent = timeSpent;
        }
        
        public virtual string Tags { get; set; }
        public virtual string PlatformId { get; set; }
        
        // 20130615
        public virtual ScriptBlock[] BeforeScenario { get; set; }
        public virtual ScriptBlock[] AfterScenario { get; set; }
        public virtual object[] BeforeScenarioParameters { get; set; }
        public virtual object[] AfterScenarioParameters { get; set; }
    }
}
