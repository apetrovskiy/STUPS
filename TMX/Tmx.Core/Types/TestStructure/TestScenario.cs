/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/19/2012
 * Time: 2:52 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces
{
    using System;
    using System.Collections.Generic;
    // using System.Management.Automation;
    using System.Xml.Serialization;
    using Tmx.Interfaces;
    using Tmx.Interfaces.TestStructure;
    // using Tmx.Core;
    
    /// <summary>
    /// Description of TestScenario.
    /// </summary>
    public class TestScenario : ITestScenario
    {
        public TestScenario()
        {
            UniqueId = Guid.NewGuid();
            this.TestResults = new List<ITestResult>();
            this.TestCases = new List<ITestCase>();
            this.Statistics = new TestStat();
            this.enStatus = TestScenarioStatuses.NotTested;
        }
        
        // 20141102
//            try{
//                if (TestData.CurrentTestResult.Details.Count > 0) {
//                    
//                    TestData.AddTestResult(
//                        "autoclosed", 
//                        TestData.GetTestResultId(), 
//                        null, 
//                        false, // isKnownIssue
//                        false, // generateNextResult
//                        null, // MyInvocation
//                        null, // Error
//                        string.Empty,
//                        TestResultOrigins.Automatic,
//                        false);
//                } else {
//                    TestData.CurrentTestResult = null;
//                }
//            }
//            catch {}
//            
//            this.SetNow();
//            
//            // in detail 20140713
//            var testSuite1 = TestData.TestSuites[TestData.TestSuites.Count - 1];
//            var testScenario1 = testSuite1.TestScenarios[testSuite1.TestScenarios.Count - 1]; // HERE!!
//            string testScenarioId1 = testScenario1.Id;
//            // string testScenarioId1 = TestData.TestSuites[TestData.TestSuites.Count - 1].TestScenarios[TestData.TestSuites[TestData.TestSuites.Count - 1].TestScenarios.Count - 1].Id;
//            string testSuiteId1 = TestData.TestSuites[TestData.TestSuites.Count - 1].Id;
//            // 20140723
//            // var testResult1 = new TestResult(testScenarioId1, testSuiteId1);
//            // this.TestResults.Add(testResult1);
//            this.TestResults.Add(new TestResult(testScenarioId1, testSuiteId1)); // ??
////            this.TestResults.Add(
////                new TestResult(
////                    TestData.TestSuites[TestData.TestSuites.Count - 1].TestScenarios[TestData.TestSuites[TestData.TestSuites.Count - 1].TestScenarios.Count - 1].Id, // "???",
////                    TestData.TestSuites[TestData.TestSuites.Count - 1].Id)); // "???"));
//            TestData.CurrentTestResult = this.TestResults[TestResults.Count - 1];
//        }
        
        public TestScenario(
            string testScenarioName, 
            string testScenarioId,
            string testSuiteId)
        {
            UniqueId = Guid.NewGuid();
            this.TestResults = new List<ITestResult>();
            this.TestCases = new List<ITestCase>();
            this.Statistics = new TestStat();
            this.enStatus = TestScenarioStatuses.NotTested;
            this.Name = testScenarioName;
            this.Id = !string.IsNullOrEmpty(testScenarioId) ? testScenarioId : TestData.GetTestScenarioId();
            this.SuiteId = testSuiteId;
            
            try{
                if (TestData.CurrentTestResult.Details.Count > 0) {
                    TestData.AddTestResult(
                        "autoclosed", 
                        TestData.GetTestResultId(), 
                        null, 
                        false, // isKnownIssue
                        false, // generateNextResult
                        // 20160116
                        // null, // MyInvocation
                        null, // Error
                        string.Empty,
                        TestResultOrigins.Automatic,
                        false);
                } else {
                    TestData.CurrentTestResult = null;
                }
            }
            catch {}
            
            this.SetNow();
            this.TestResults.Add(
                new TestResult(
                   this.Id,
                   this.SuiteId));
            
            try {
                if ((null != TestData.CurrentTestResult.Name ||
                    null != TestData.CurrentTestResult.Id) &&
                    null != TestData.CurrentTestResult.Details &&
                    0 < TestData.CurrentTestResult.Details.Count) {
                    
                    TestData.CurrentTestScenario.TestResults.Add(TestData.CurrentTestResult);
                }
            }
            catch (Exception) {
                //Console.WriteLine(eeeee.Message);
            }
            TestData.CurrentTestResult = 
                TestResults[TestResults.Count - 1];
        }
        
        [XmlAttribute]
        public virtual Guid UniqueId { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Id { get; set; }
        [XmlElement("TestResults", typeof(ITestResult))]
        public List<ITestResult> TestResults {get; protected internal set; }
        [XmlAttribute]
        public virtual string Description { get; set; }

        string _status;
        [XmlAttribute]
        public virtual string Status { get { return this._status; } }
        TestScenarioStatuses _enStatus;
        [XmlAttribute]
        public TestScenarioStatuses enStatus
        { 
            get { return _enStatus; }
            set{
                _enStatus = value;

                switch (value) {
                    case TestScenarioStatuses.Passed:
                        _status = TestData.TestStatePassed;
                        break;
                    case TestScenarioStatuses.Failed:
                        _status = TestData.TestStateFailed;
                        break;
                    case TestScenarioStatuses.NotTested:
                        _status = TestData.TestStateNotTested;
                        break;
                    case TestScenarioStatuses.KnownIssue:
                        _status = TestData.TestStateKnownIssue;
                        break;
                    default:
                        // 20130428
                        //throw new Exception("Invalid value for TestScenarioStatuses");
                        _status = TestData.TestStateNotTested;
                        break;
                }
            }
        }
        
        [XmlIgnore]
        public TestStat Statistics { get; set; }
        
        [XmlIgnore]
        public string SuiteId { get; set; }
        [XmlIgnore]
        public Guid SuiteUniqueId { get; set; }
        
        [XmlAttribute]
        public virtual DateTime Timestamp { get; set; }
        public void SetNow()
        {
            Timestamp = DateTime.Now;
        }
        
        [XmlAttribute]
        public virtual double TimeSpent { get; set; }
        public virtual void SetTimeSpent(double timeSpent)
        {
            TimeSpent = timeSpent;
        }
        
        [XmlIgnore]
        public virtual string Tags { get; set; }
        [XmlAttribute]
        public virtual string PlatformId { get; set; }
        [XmlAttribute]
        public virtual Guid PlatformUniqueId { get; set; }
        
        [XmlIgnore]
        // 20141211
        // public virtual ScriptBlock[] BeforeTest { get; set; }
        public virtual ICodeBlock[] BeforeTest { get; set; }
        [XmlIgnore]
        // 20141211
        // public virtual ScriptBlock[] AfterTest { get; set; }
        public virtual ICodeBlock[] AfterTest { get; set; }
        [XmlIgnore]
        public virtual object[] BeforeTestParameters { get; set; }
        [XmlIgnore]
        public virtual object[] AfterTestParameters { get; set; }
        [XmlIgnore]
        public List<ITestCase> TestCases { get; set; }
        
        public virtual int GetAll()
        {
            return Statistics.All;
        }
        
        public virtual int GetPassed()
        {
            return Statistics.Passed;
        }
        
        public virtual int GetFailed()
        {
            return Statistics.Failed;
        }
        
        public virtual int GetPassedButWithBadSmell()
        {
            return Statistics.PassedButWithBadSmell;
        }
        
        public virtual int GetNotTested()
        {
            return Statistics.NotTested;
        }
    }
}
