/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
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
	/// Description of TmxInvokeTestScenarioCommand.
	/// </summary>
    internal class TmxInvokeTestScenarioCommand : TmxCommand
    {
        internal TmxInvokeTestScenarioCommand(CommonCmdletBase cmdlet) : base (cmdlet)
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
            
            if (null == testScenario) {
                
                cmdlet.WriteError(
                    cmdlet,
                    "failed to find test scenario with Name = '" +
                    cmdlet.Name +
                    "', Id = '" +
                    cmdlet.Id +
                    "'",
                    "FailedToFindTestScenario",
                    ErrorCategory.InvalidArgument,
                    true);
            }
            
            testScenario.BeforeTestParameters =
                cmdlet.BeforeTestParameters;
            testScenario.AfterTestParameters =
                cmdlet.AfterTestParameters;
            
            if (!cmdlet.OnlySetParameters) {
                cmdlet.RunTestScenario(
                	cmdlet,
                	TMX.TestData.CurrentTestSuite, // temporary, add selection from cmdlet's parameters
                	testScenario);
            }
        }
    }
}
