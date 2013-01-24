/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/19/2012
 * Time: 11:46 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TMXAddTestScenarioCommand.
    /// </summary>
    internal class TMXAddTestScenarioCommand : TMXCommand
    {
        internal TMXAddTestScenarioCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            AddScenarioCmdletBase cmdlet =
                (AddScenarioCmdletBase)this.Cmdlet;
            
            bool result = 
                //TMX.TMXHelper.AddTestScenario(this);
                TMX.TMXHelper.AddTestScenario(cmdlet);
            if (result) {
                
                //WriteObject(TestData.CurrentTestScenario);
                cmdlet.WriteObject(
                    cmdlet,
                    TestData.CurrentTestScenario);
            } else {
//                ErrorRecord err = 
//                    new ErrorRecord(new Exception("Couldn't add a test scenario"),
//                                    "AddingTestScenario",
//                                    ErrorCategory.InvalidData,
//                                    this.Name);
//                err.ErrorDetails =
//                    new ErrorDetails(
//                        "Failed to add a test scenario");
//                ThrowTerminatingError(err);
                
                cmdlet.WriteError(
                    cmdlet,
                    "Couldn't add a test scenario",
                    "AddingTestScenario",
                    ErrorCategory.InvalidArgument,
                    true);
            }
        }
    }
}
