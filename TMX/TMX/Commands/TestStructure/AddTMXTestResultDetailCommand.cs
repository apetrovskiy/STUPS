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
            this.CheckCmdletParameters();
            
            this.WriteVerbose(this, this.TestResultDetail);
            // 20140317
            // turning off the logger
            // TMX.Logger.TmxLogger.Info(this.TestResultDetail);
            if (this.Echo) {

                WriteObject(this.TestResultDetail);
            }
            // 20130331
            //TMX.TestData.AddTestResultTextDetail(this.TestResultDetail);
            TMX.TestData.AddTestResultTextDetail(this, this.TestResultDetail);
        }
    }
}
