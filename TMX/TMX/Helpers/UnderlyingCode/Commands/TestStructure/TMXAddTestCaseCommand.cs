/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/20/2012
 * Time: 1:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TMXAddTestCaseCommand.
    /// </summary>
    internal class TMXAddTestCaseCommand : TMXCommand
    {
        internal TMXAddTestCaseCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            AddTestCaseCmdletBase cmdlet =
                (AddTestCaseCmdletBase)this.Cmdlet;
            
            bool result = 
                TMX.TMXHelper.AddTestCase(cmdlet);
            
            // 20130616
            TMX.Logger.TMXLogger.Info("Test case: '" + cmdlet.Name + "'");
            
            if (result) {
                
                cmdlet.WriteObject(
                    cmdlet,
                    TestData.CurrentTestScenario);
            } else {
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
