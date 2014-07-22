/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/11/2013
 * Time: 2:35 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Data;
	using Tmx.Interfaces;
//    using System.Data.SQLite;
    using FluentNHibernate;
    using FluentNHibernate.Mapping;
    using NHibernate;
    using NHibernate.Mapping;
    
    /// <summary>
    /// Description of TestResultMap.
    /// </summary>
    public class TestResultMap : ClassMap<TestResult>
    {
        public TestResultMap()
        {
            Id(x => x.DbId);
            Map(x => x.Name);
            Map(x => x.Id);
            //Map(x => x.Error);
            //HasMany(x => x.Details);
            
            Map(x => x.ScriptName);
            Map(x => x.LineNumber);
            Map(x => x.Position);
            Map(x => x.Error);
            Map(x => x.Code);
            //HasMany(x => x.Parameters);
            
            Map(x => x.Status);
            Map(x => x.enStatus);
            
            Map(x => x.TimeSpent);
            Map(x => x.Timestamp);
            Map(x => x.SuiteId);
            Map(x => x.ScenarioId);
            Map(x => x.Generated);
            Map(x => x.Screenshot);
            Map(x => x.Origin);
            
            Map(x => x.PlatformId);
        }
        
#region bunch01
//        public string Name { get; set; }
//        public string Id { get; set; }
//        public string Description { get; set; }
//        public List<ITestResultDetail> Details { get; internal set; }
#endregion bunch01
#region bunch02
//        public string ScriptName { get; internal set; }
//        public void SetScriptName(string scriptName)
//        {
//            this.ScriptName = scriptName;
//        }
//        public int LineNumber { get; internal set; }
//        public void SetLineNumber(int lineNumber)
//        {
//            this.LineNumber = lineNumber;
//        }
//        public int Position { get; internal set; }
//        public void SetPosition(int position)
//        {
//            this.Position = position;
//        }
//        public ErrorRecord Error { get; internal set; }
//        public void SetError(ErrorRecord error)
//        {
//            this.Error = error;
//        }
//        public string Code { get; set; }
//        
//        public List<object> Parameters { get; internal set; }
#endregion bunch02
#region bunch03
//        private string status;
//        public string Status { get { return this.status; } }
//        private TestResultStatuses _enStatus;
//        public TestResultStatuses enStatus
//        { 
//            get { return this._enStatus; }
//            set{
//                this._enStatus = value;
//
//                switch (value) {
//                    case TestResultStatuses.Passed:
//                        this.status = TestData.TestStatePassed;
//                        break;
//                    case TestResultStatuses.Failed:
//                        this.status = TestData.TestStateFailed;
//                        break;
//                    case TestResultStatuses.NotTested:
//                        this.status = TestData.TestStateNotTested;
//                        break;
//                    case TestResultStatuses.KnownIssue:
//                        this.status = TestData.TestStateKnownIssue;
//                        break;
//                    default:
//                        throw new Exception("Invalid value for TestResultStatuses");
//                }
//            }
//        }
#endregion bunch03
#region bunch04
//        public double TimeSpent { get; internal set; }
//        public void SetTimeSpent(double timeSpent)
//        {
//            this.TimeSpent = timeSpent;
//        }
//        
//        public System.DateTime Timestamp { get; internal set; }
//        public void SetNow()
//        {
//            this.Timestamp = System.DateTime.Now;
//        }
//        
//        public string SuiteId { get; internal set; }
//        public string ScenarioId { get; internal set; }
//        
//        public bool Generated { get; internal set; }
//        public void SetGenerated()
//        {
//            this.Generated = true;
//        }
//        
//        public string Screenshot { get; internal set; }
//        public void SetScreenshot(string path)
//        {
//            this.Screenshot = path;
//        }
//        
//        public TestResultOrigins Origin { get; internal set; }
//        public void SetOrigin(TestResultOrigins origin)
//        {
//            if (TestResultOrigins.Logical == this.Origin) {
//                
//                // don't change the origin - it already was logical
//            } else {
//                
//                this.Origin = origin;
//            }
//        }
#endregion bunch04
#region bunch05
//        public object[] ListDetailNames(TestResultStatusCmdletBase cmdlet)
//        {
//            //ArrayList detailsList =
//            //    new ArrayList();
//            
//            // 20130402
//            ITestResultDetail[] detailsList = null;
//            
//            cmdlet.WriteVerbose(cmdlet, "trying to enumerate details");
//            
//            if (null != this.Details && 0 < this.Details.Count) {
//                
//                // 20130402
//                //if (null == cmdlet.TestResultStatus) {
//                if (TestResultStatuses.NotTested == cmdlet.TestResultStatus) {
//                    
//                    var testResultDetailsNonFiltered = 
//                        from detail in this.Details
//                        select detail;
//                    
//                    try {
//                        detailsList = testResultDetailsNonFiltered.ToArray();
//                    }
//                    catch {}
//                    
//                } else {
//                    
//                    var testResultDetailFiltered =
//                        from detail in this.Details
//                        where detail.DetailStatus == TestResultStatuses.Failed || detail.DetailStatus == TestResultStatuses.KnownIssue
//                        select detail;
//                    
//                    try {
//                        detailsList = testResultDetailFiltered.ToArray();
//                    }
//                    catch {}
//                    
//                }
//                
////                foreach (TestResultDetail detail in this.Details) {
////                    
////                    detailsList.Add(detail.Name);
////                }
//                
//            }
//            
//            // 20130402
//            //return detailsList.ToArray();
//            return detailsList;
//        }
//        
//        public List<string> PlatformIds { get; set; }
#endregion bunch05
    }
}
