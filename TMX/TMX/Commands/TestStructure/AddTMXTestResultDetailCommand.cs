/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of AddTmxTestResultDetailCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "TmxTestResultDetail")]
    public class AddTmxTestResultDetailCommand : TestResultDetailCmdletBase
    {
        protected override void BeginProcessing()
        {
            CheckCmdletParameters();
            
            WriteVerbose(this, TestResultDetail);
            // 20140317
            // turning off the logger
            // TMX.Logger.TmxLogger.Info(this.TestResultDetail);
            if (Echo) {

                WriteObject(TestResultDetail);
            }
            // 20130331
            //TMX.TestData.AddTestResultTextDetail(this.TestResultDetail);
            TestData.AddTestResultTextDetail(this, TestResultDetail);
        }
    }
}
