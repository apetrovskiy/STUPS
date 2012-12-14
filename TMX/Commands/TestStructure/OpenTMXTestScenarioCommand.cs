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
    /// Description of OpenTMXTestScenarioCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Open, "TMXTestScenario")]
    public class OpenTMXTestScenarioCommand : OpenScenarioCmdletBase
    {
        public OpenTMXTestScenarioCommand()
        {
//            if (TestData.CurrentTestSuite != null) {
//                this.InputObject = TestData.CurrentTestSuite; // ?????????????
//            }
        }
        
        #region Parameters
        #endregion Parameters
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            bool result = 
                TMX.TMXHelper.OpenTestScenario(this);
            if (result) {
                WriteObject(TestData.CurrentTestScenario);
            } else {
                ErrorRecord err = 
                    new ErrorRecord(new Exception("Couldn't open a test scenario"),
                                    "GettingTestScenario",
                                    ErrorCategory.InvalidOperation,
                                    this.Name);
                err.ErrorDetails = 
                    new ErrorDetails(
                        "Failed to open a test scenario");
                ThrowTerminatingError(err);
            }
        }
    }
}
