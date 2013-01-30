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
            TestScenarios = new List<ITestScenario > ();
            this.Statistics = new TestStat();
            this.enStatus = TestSuiteStatuses.NotTested;
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
        }
        
        public string Name { get; internal set; }
        public string Id { get; internal set; }
        public System.Collections.Generic.List<ITestScenario> TestScenarios { get; internal set; }
        public string Description { get; set; }
        public string Status { get; internal set; }
        private TestSuiteStatuses _enStatus;
        internal TestSuiteStatuses enStatus 
        { 
            get { return this._enStatus; }
            set{
                this._enStatus = value;
                if (value == TestSuiteStatuses.Failed) {
                    this.Status = TMX.TestData.TestStateFailed;
                }
                if (value == TestSuiteStatuses.Passed) {
                    this.Status = TMX.TestData.TestStatePassed;
                }
                if (value == TestSuiteStatuses.NotTested) {
                    this.Status = TMX.TestData.TestStateNotTested;
                }
            }
        }
        
        public TestStat Statistics { get; set; }
    }
}
