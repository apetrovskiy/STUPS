/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of OpenTMXTestSuiteCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Open, "TMXTestSuite")]
    public class OpenTMXTestSuiteCommand : OpenSuiteCmdletBase
    {
        public OpenTMXTestSuiteCommand()
        {
        }
        
        #region Parameters
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            this.CheckParameters();
            
            bool result = 
                TMX.TMXHelper.OpenTestSuite(this.Name, this.Id);
            if (result) {
                WriteObject(TestData.CurrentTestSuite);
            } else {
                ErrorRecord err = 
                    new ErrorRecord(new Exception("Couldn't get a test suite"),
                                    "GettingTestSuite",
                                    ErrorCategory.InvalidOperation,
                                    this.Name);
                err.ErrorDetails = 
                    new ErrorDetails(
                        "Failed to get a test suite");
                ThrowTerminatingError(err);
            }
        }
    }
}
