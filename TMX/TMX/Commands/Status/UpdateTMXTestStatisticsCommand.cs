/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 5/28/2013
 * Time: 3:13 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of UpdateTMXTestStatisticsCommand.
    /// </summary>
    [Cmdlet(VerbsData.Update, "TMXTestStatistics")]
    public class UpdateTMXTestStatisticsCommand : CommonCmdletBase
    {
        public UpdateTMXTestStatisticsCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            
            if (null != TMX.TestData.TestSuites && 0 < TMX.TestData.TestSuites.Count) {
                
                foreach (TestSuite testSuite in TMX.TestData.TestSuites) {
                    
                    TMX.TestData.RefreshSuiteStatistics(testSuite, false);
                }
                
            }
            
        }
    }
}
