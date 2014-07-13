/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/18/2012
 * Time: 7:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TmxNewTestSuiteCommand.
    /// </summary>
    internal class TmxNewTestSuiteCommand : TmxCommand
    {
        internal TmxNewTestSuiteCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (NewSuiteCmdletBase)this.Cmdlet;
            
            bool result = 
                TmxHelper.NewTestSuite(
                    cmdlet.Name,
                    cmdlet.Id,
                    cmdlet.TestPlatformId,
                    cmdlet.Description,
                    cmdlet.BeforeScenario,
                    cmdlet.AfterScenario);
            if (result) {
                
                cmdlet.WriteObject(cmdlet, TestData.CurrentTestSuite);
            } else {
                
                cmdlet.WriteError(
                    cmdlet,
                    "Couldn't create a test suite",
                    "CreatingTestSuite",
                    ErrorCategory.InvalidArgument,
                    true);
            }
        }
    }
}
