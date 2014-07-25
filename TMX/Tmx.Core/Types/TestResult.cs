/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/19/2012
 * Time: 2:53 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Collections;
    using System.Linq;
	using Tmx.Interfaces.TestStructure;
	// using Tmx.Core;
    
    /// <summary>
    /// Description of TestResult.
    /// </summary>
    public class TestResult : ITestResult
    {
        public TestResult() {}
        
        public TestResult(
           string testScenarioId,
           string testSuiteId)
        {
            this.Details = new List<ITestResultDetail>();
            this.enStatus = TestResultStatuses.NotTested;
            
            // scenarioId and suiteId
            this.ScenarioId = testScenarioId;
            this.SuiteId = testSuiteId;
            
            this.SetNow();
        }
        
        public virtual int DbId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Id { get; set; }
        public virtual string Description { get; set; }
        public virtual List<ITestResultDetail> Details { get; protected internal set; }
        
        public virtual string ScriptName { get; protected internal set; }
        public virtual void SetScriptName(string scriptName)
        {
			ScriptName = scriptName;
        }
        public virtual int LineNumber { get; protected internal set; }
        public virtual void SetLineNumber(int lineNumber)
        {
			LineNumber = lineNumber;
        }
        public virtual int Position { get; protected internal set; }
        public virtual void SetPosition(int position)
        {
			Position = position;
        }
        public virtual ErrorRecord Error { get; protected internal set; }
        public virtual void SetError(ErrorRecord error)
        {
			Error = error;
        }
        public virtual string Code { get; set; }
        
        public virtual List<object> Parameters { get; protected internal set; }

        string status;
        public virtual string Status { get { return this.status; } }
        TestResultStatuses _enStatus;
        public virtual TestResultStatuses enStatus
        { 
            get { return _enStatus; }
            set{
				_enStatus = value;

                switch (value) {
                    case TestResultStatuses.Passed:
						status = TestData.TestStatePassed;
                        break;
                    case TestResultStatuses.Failed:
						status = TestData.TestStateFailed;
                        break;
                    case TestResultStatuses.NotTested:
						status = TestData.TestStateNotTested;
                        break;
                    case TestResultStatuses.KnownIssue:
						status = TestData.TestStateKnownIssue;
                        break;
                    default:
                        throw new Exception("Invalid value for TestResultStatuses");
                }
            }
        }
        
        public virtual double TimeSpent { get; protected internal set; }
        public virtual void SetTimeSpent(double timeSpent)
        {
			TimeSpent = timeSpent;
        }
        
        public virtual DateTime Timestamp { get; protected internal set; }
        public virtual void SetNow()
        {
			Timestamp = DateTime.Now;
        }
        
        public virtual string SuiteId { get; protected internal set; }
        public virtual string ScenarioId { get; protected internal set; }
        
        public virtual bool Generated { get; protected internal set; }
        public virtual void SetGenerated()
        {
			Generated = true;
        }
        
        public virtual string Screenshot { get; protected internal set; }
        public virtual void SetScreenshot(string path)
        {
			Screenshot = path;
        }
        
        public virtual TestResultOrigins Origin { get; protected internal set; }
        public virtual void SetOrigin(TestResultOrigins origin)
        {
            if (TestResultOrigins.Logical == this.Origin) {
                
                // don't change the origin - it already was logical
            } else {
                
				Origin = origin;
            }
        }
        
        // 20140703
        // refactoring
//        public virtual object[] ListDetailNames(TestResultStatusCmdletBase cmdlet)
//        {
//            //ArrayList detailsList =
//            //    new ArrayList();
//            
//            // 20130402
//            ITestResultDetail[] detailsList = null;
//            
//            cmdlet.WriteVerbose(cmdlet, "trying to enumerate details");
//            
//            // 20140208
//            // if (null == this.Details || 0 >= this.Details.Count) return detailsList;
//            if (null == this.Details || 0 == this.Details.Count) return detailsList;
//            // if (null != this.Details && 0 < this.Details.Count) {
//
//            // 20130402
//            //if (null == cmdlet.TestResultStatus) {
//            if (TestResultStatuses.NotTested == cmdlet.TestResultStatus) {
//                    
//                var testResultDetailsNonFiltered = 
//                    from detail in this.Details
//                    select detail;
//                    
//                try {
//                    detailsList = testResultDetailsNonFiltered.ToArray();
//                }
//                catch {}
//                    
//            } else {
//                    
//                var testResultDetailFiltered =
//                    from detail in this.Details
//                    where detail.DetailStatus == TestResultStatuses.Failed || detail.DetailStatus == TestResultStatuses.KnownIssue
//                    select detail;
//                    
//                try {
//                    detailsList = testResultDetailFiltered.ToArray();
//                }
//                catch {}
//                    
//            }
//                
////                foreach (TestResultDetail detail in this.Details) {
////                    
////                    detailsList.Add(detail.Name);
////                }
//            
//            return detailsList;
//        }
        
        public virtual object[] ListDetailNames(TestResultStatuses status)
        {
            //ArrayList detailsList =
            //    new ArrayList();
            
            // 20130402
            ITestResultDetail[] detailsList = null;
            
            // 20140208
            // if (null == this.Details || 0 >= this.Details.Count) return detailsList;
            if (null == this.Details || 0 == this.Details.Count) return detailsList;
            // if (null != this.Details && 0 < this.Details.Count) {

            // 20130402
            //if (null == cmdlet.TestResultStatus) {
            if (TestResultStatuses.NotTested == status) {
                    
                var testResultDetailsNonFiltered = 
                    from detail in this.Details
                    select detail;
                    
                try {
                    detailsList = testResultDetailsNonFiltered.ToArray();
                }
                catch {}
                    
            } else {
                    
                var testResultDetailFiltered =
                    from detail in this.Details
                    where detail.DetailStatus == TestResultStatuses.Failed || detail.DetailStatus == TestResultStatuses.KnownIssue
                    select detail;
                    
                try {
                    detailsList = testResultDetailFiltered.ToArray();
                }
                catch {}
                    
            }
                
//                foreach (TestResultDetail detail in this.Details) {
//                    
//                    detailsList.Add(detail.Name);
//                }
            
            return detailsList;
        }
        
        public virtual string PlatformId { get; set; }
    }
}
