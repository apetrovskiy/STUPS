/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/3/2013
 * Time: 10:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetTmxTestStatisticsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TmxTestStatistics")]
    public class GetTmxTestStatisticsCommand : CommonCmdletBase
    {
        public GetTmxTestStatisticsCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            TestStat stat = new TestStat();
            
            if (null != TMX.TestData.TestSuites && 0 < TMX.TestData.TestSuites.Count) {
                
                foreach (TestSuite testSuite in TMX.TestData.TestSuites) {
                    
                    TMX.TestData.RefreshSuiteStatistics(testSuite, false);
                    stat.Passed += testSuite.Statistics.Passed;
                    stat.Failed += testSuite.Statistics.Failed;
                    stat.PassedButWithBadSmell += testSuite.Statistics.PassedButWithBadSmell;
                    stat.NotTested += testSuite.Statistics.NotTested;
                    stat.All += testSuite.Statistics.All;
                }
                
            }
            
            this.WriteObject(this, stat);
        }
    }
}
