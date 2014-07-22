/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/11/2013
 * Time: 2:30 AM
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
    
    /// <summary>
    /// Description of TestScenarioMap.
    /// </summary>
    public class TestScenarioMap : ClassMap<TestScenario>
    {
        public TestScenarioMap()
        {
            Id(x => x.DbId);
            Map(x => x.Name);
            Map(x => x.Id);
            Map(x => x.Status);
            Map(x => x.Description);
            HasMany(x => x.TestResults);
            
            //Map(x => x.Status);
            
            //Map(x => x.Statistics);
            Map(x => x.SuiteId);
            Map(x => x.Timestamp);
            Map(x => x.TimeSpent);
            Map(x => x.Tags);
            Map(x => x.PlatformId);
        }
        
#region bunch01
//        public string Name { get; internal set; }
//        public string Id { get; internal set; }
//        public System.Collections.Generic.List<ITestResult> TestResults {get; internal set; }
//        public string Description { get; set; }
#endregion bunch01
#region bunch02
//        private string status;
//        public string Status { get { return this.status; } }
//        private TestScenarioStatuses _enStatus;
//        internal TestScenarioStatuses enStatus
//        { 
//            get { return this._enStatus; }
//            set{
//                this._enStatus = value;
//
//                switch (value) {
//                    case TestScenarioStatuses.Passed:
//                        this.status = TestData.TestStatePassed;
//                        break;
//                    case TestScenarioStatuses.Failed:
//                        this.status = TestData.TestStateFailed;
//                        break;
//                    case TestScenarioStatuses.NotTested:
//                        this.status = TestData.TestStateNotTested;
//                        break;
//                    case TestScenarioStatuses.KnownIssue:
//                        this.status = TestData.TestStateKnownIssue;
//                        break;
//                    default:
//                        // 20130428
//                        //throw new Exception("Invalid value for TestScenarioStatuses");
//                        this.status = TestData.TestStateNotTested;
//                        break;
//                }
//            }
//        }
#endregion bunch02
#region bunch03
//        public TestStat Statistics { get; set; }
//        
//        public string SuiteId { get; internal set; }
//        
//        // 20130301
//        public System.DateTime Timestamp { get; internal set; }
//        public void SetNow()
//        {
//            this.Timestamp = System.DateTime.Now;
//        }
//        public double TimeSpent { get; internal set; }
//        public void SetTimeSpent(double timeSpent)
//        {
//            this.TimeSpent = timeSpent;
//        }
//        
//        public List<string> Tags { get; set; }
//        
//        public List<string> PlatformIds { get; set; }
#endregion bunch03
    }
}
