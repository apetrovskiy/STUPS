/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 6/15/2013
 * Time: 7:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
	/// <summary>
	/// Description of TMXInvokeTestScenarioCommand.
	/// </summary>
    internal class TMXInvokeTestScenarioCommand : TMXCommand
    {
        internal TMXInvokeTestScenarioCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            TestScenarioExecCmdletBase cmdlet =
                (TestScenarioExecCmdletBase)this.Cmdlet;
            
            ITestScenario testScenario =
            	TestData.GetTestScenario(
            		TMX.TestData.CurrentTestSuite,
            		cmdlet.Name,
            		cmdlet.Id,
            		TMX.TestData.CurrentTestSuite.Name,
            		TMX.TestData.CurrentTestSuite.Id,
            		cmdlet.TestPlatformId);
            
            cmdlet.RunTestScenario(
            	cmdlet,
            	TMX.TestData.CurrentTestSuite, // temporary, add selection from cmdlet's parameters
            	testScenario);
            
//            bool result = 
//                TMX.TMXHelper.NewTestSuite(
//                    cmdlet.Name,
//                    cmdlet.Id,
//                    cmdlet.TestPlatformId,
//                    cmdlet.Description,
//                    cmdlet.BeforeScenario,
//                    cmdlet.AfterScenario);
//            if (result) {
//                
//                //TestData.CurrentTestSuite.
//                
//                cmdlet.WriteObject(cmdlet, TestData.CurrentTestSuite);
//            } else {
//                
//                cmdlet.WriteError(
//                    cmdlet,
//                    "Couldn't create a test suite",
//                    "CreatingTestSuite",
//                    ErrorCategory.InvalidArgument,
//                    true);
//            }
        }
    }
}
