/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/11/2013
 * Time: 2:08 AM
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
    /// Description of TestSuiteMapping.
    /// </summary>
    public class TestSuiteMap : ClassMap<TestSuite>
    {
        public TestSuiteMap()
        {
            Id(x => x.DbId);
            Map(x => x.Name);
            Map(x => x.Id);
            Map(x => x.Status);
            Map(x => x.Description);
            HasMany(x => x.TestScenarios);
            
            //Map(x => x.Status);
            //Map(x => x.Statistics);
            Map(x => x.Timestamp);
            Map(x => x.TimeSpent);
            Map(x => x.Tags);
            Map(x => x.PlatformId);
        }
        
#region bunch01
//        public string Name { get; internal set; }
//        public string Id { get; internal set; }
//        public System.Collections.Generic.List<ITestScenario> TestScenarios { get; internal set; }
//        public string Description { get; set; }
#endregion bunch01
#region bunch02
//        private string status;
//        public string Status { get { return this.status; } }
//        private TestSuiteStatuses _enStatus;
//        internal TestSuiteStatuses enStatus 
//        { 
//            get { return this._enStatus; }
//            set{
//                this._enStatus = value;
//
//                switch (value) {
//                    case TestSuiteStatuses.Passed:
//                        this.status = TestData.TestStatePassed;
//                        break;
//                    case TestSuiteStatuses.Failed:
//                        this.status = TestData.TestStateFailed;
//                        break;
//                    case TestSuiteStatuses.NotTested:
//                        this.status = TestData.TestStateNotTested;
//                        break;
//                    case TestSuiteStatuses.KnownIssue:
//                        this.status = TestData.TestStateKnownIssue;
//                        break;
//                    default:
//                        throw new Exception("Invalid value for TestSuiteStatuses");
//                }
//            }
//        }
#endregion bunch02
#region bunch03
//        public TestStat Statistics { get; set; }
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
