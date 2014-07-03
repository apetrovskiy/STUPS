/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/15/2013
 * Time: 10:04 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
	using TMX.Interfaces;
    
    /// <summary>
    /// Description of TmxInvokeTestCaseCommand.
    /// </summary>
    internal class TmxInvokeTestCaseCommand : TmxCommand
    {
        internal TmxInvokeTestCaseCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet =
                (TestCaseExecCmdletBase)this.Cmdlet;
            
            ITestCase testCase =
            	TestData.GetTestCase(
            		TMX.TestData.CurrentTestSuite,
            		cmdlet.Name,
            		cmdlet.Id,
            		// 20130912
            		//TMX.TestData.CurrentTestSuite.Name,
            		//TMX.TestData.CurrentTestSuite.Id,
            		//TMX.TestData.CurrentTestScenario.Name,
            		//TMX.TestData.CurrentTestScenario.Id,
            		TMX.TestData.CurrentTestScenario.Name,
            		TMX.TestData.CurrentTestScenario.Id,
            		TMX.TestData.CurrentTestSuite.Name,
            		TMX.TestData.CurrentTestSuite.Id,
            		cmdlet.TestPlatformId);
            
            // 20130912
            if (null == testCase) {
                
                cmdlet.WriteError(
                    cmdlet,
                    "failed to find test case with Name = '" +
                    cmdlet.Name +
                    "', Id = '" +
                    cmdlet.Id +
                    "'",
                    "FailedToFindTestCase",
                    ErrorCategory.InvalidArgument,
                    true);
            }
            
            testCase.TestCodeParameters =
                cmdlet.TestCodeParameters;
            
            if (!cmdlet.OnlySetParameters) {
                cmdlet.RunTestCase(
                	cmdlet,
                	TMX.TestData.CurrentTestSuite, // temporary, add selection from cmdlet's parameters
                	TMX.TestData.CurrentTestScenario);
            }
        }
    }
}
