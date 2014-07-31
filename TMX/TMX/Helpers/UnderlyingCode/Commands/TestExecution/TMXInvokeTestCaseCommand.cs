/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/15/2013
 * Time: 10:04 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
	// using Tmx.Core;
	using Tmx;
	// using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of TmxInvokeTestCaseCommand.
    /// </summary>
    class TmxInvokeTestCaseCommand : TmxCommand
    {
        internal TmxInvokeTestCaseCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (TestCaseExecCmdletBase)Cmdlet;
            
            var testCase =
            	TestData.GetTestCase(
            		TestData.CurrentTestSuite,
            		cmdlet.Name,
            		cmdlet.Id,
            		TestData.CurrentTestScenario.Name,
            		TestData.CurrentTestScenario.Id,
            		TestData.CurrentTestSuite.Name,
            		TestData.CurrentTestSuite.Id,
            		cmdlet.TestPlatformId);
            
            if (null == testCase)
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
            
            testCase.TestCodeParameters = cmdlet.TestCodeParameters;
            
            if (!cmdlet.OnlySetParameters)
                cmdlet.RunTestCase(
                	cmdlet,
                	TestData.CurrentTestSuite, // temporary, add selection from cmdlet's parameters
                	TestData.CurrentTestScenario);
        }
    }
}
