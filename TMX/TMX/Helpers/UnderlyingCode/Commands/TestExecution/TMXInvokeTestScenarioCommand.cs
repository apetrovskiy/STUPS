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
	using TMX.Interfaces.TestStructure;
    
	/// <summary>
	/// Description of TmxInvokeTestScenarioCommand.
	/// </summary>
    class TmxInvokeTestScenarioCommand : TmxCommand
    {
        internal TmxInvokeTestScenarioCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (TestScenarioExecCmdletBase)Cmdlet;
            
            var testScenario =
            	TestData.GetTestScenario(
            		TestData.CurrentTestSuite,
            		cmdlet.Name,
            		cmdlet.Id,
            		TestData.CurrentTestSuite.Name,
            		TestData.CurrentTestSuite.Id,
            		cmdlet.TestPlatformId);
            
            if (null == testScenario)
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
            
            testScenario.BeforeTestParameters = cmdlet.BeforeTestParameters;
            testScenario.AfterTestParameters = cmdlet.AfterTestParameters;
            
            if (!cmdlet.OnlySetParameters)
                cmdlet.RunTestScenario(
                	cmdlet,
					TestData.CurrentTestSuite, // temporary, add selection from cmdlet's parameters
                	testScenario);
        }
    }
}
