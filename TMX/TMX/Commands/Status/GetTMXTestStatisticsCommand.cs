/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/3/2013
 * Time: 10:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System;
    using System.Management.Automation;
    using Tmx;
    using Tmx.Core;
    using Tmx.Interfaces;
    
    /// <summary>
    /// Description of GetTmxTestStatisticsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TmxTestStatistics")]
    public class GetTmxTestStatisticsCommand : CommonCmdletBase
    {
        protected override void BeginProcessing()
        {
//            var stat = new TestStat();
//            
//            if (null != TestData.TestSuites && 0 < TestData.TestSuites.Count) {
//                
//                // 20141107
//                var testStatistics = new TestStatistics();
//                
//                foreach (var testSuite in TestData.TestSuites) {
//                    
//                    // 20141107
//                    // TestData.RefreshSuiteStatistics(testSuite, false);
//                    testStatistics.RefreshSuiteStatistics(testSuite, false);
//                    stat.Passed += testSuite.Statistics.Passed;
//                    stat.Failed += testSuite.Statistics.Failed;
//                    stat.PassedButWithBadSmell += testSuite.Statistics.PassedButWithBadSmell;
//                    stat.NotTested += testSuite.Statistics.NotTested;
//                    stat.All += testSuite.Statistics.All;
//                }
//                
//            }
            var testStatistics = new TestStatistics();
            var stat = testStatistics.RefreshAllStatistics(TestData.TestSuites, false);
            WriteObject(this, stat);
        }
    }
}
