/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 5/28/2013
 * Time: 3:13 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System;
    using System.Management.Automation;
	using Tmx;
    
    /// <summary>
    /// Description of UpdateTmxTestStatisticsCommand.
    /// </summary>
    [Cmdlet(VerbsData.Update, "TmxTestStatistics")]
    public class UpdateTmxTestStatisticsCommand : CommonCmdletBase
    {
        protected override void BeginProcessing()
        {
            
            if (null != TestData.TestSuites && 0 < TestData.TestSuites.Count) {
                
                foreach (var testSuite in TestData.TestSuites) {
                    
                    TestData.RefreshSuiteStatistics(testSuite, false);
                }
                
            }
            
        }
    }
}
