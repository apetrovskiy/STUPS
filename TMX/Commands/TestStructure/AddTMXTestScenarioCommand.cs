/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of AddTMXTestScenarioCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "TMXTestScenario")]
    public class AddTMXTestScenarioCommand : AddScenarioCmdletBase
    {
        public AddTMXTestScenarioCommand()
        {
//            if (TestData.CurrentTestSuite != null) {
//                this.InputObject = TestData.CurrentTestSuite; // ?????????????
//            }
            // 20120926
            //if (TestData.TestSuites.Count == 0) {
            if (null == TestData.TestSuites || 0 == TestData.TestSuites.Count) {
                TestData.InitTestData();
            }
        }
        
        #region Parameters
        #endregion Parameters
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            bool result = 
                TMX.TMXHelper.AddTestScenario(this);
            if (result) {
                WriteObject(TestData.CurrentTestScenario);
            } else {
                ErrorRecord err = 
                    new ErrorRecord(new Exception("Couldn't add a test scenario"),
                                    "AddingTestScenario",
                                    ErrorCategory.InvalidData,
                                    this.Name);
                err.ErrorDetails =
                    new ErrorDetails(
                        "Failed to add a test scenario");
                ThrowTerminatingError(err);
            }
        }
    }
}
