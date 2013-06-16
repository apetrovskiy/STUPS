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
    
    /// <summary>
    /// Description of TMXInvokeTestCaseCommand.
    /// </summary>
    internal class TMXInvokeTestCaseCommand : TMXCommand
    {
        internal TMXInvokeTestCaseCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            TestCaseExecCmdletBase cmdlet =
                (TestCaseExecCmdletBase)this.Cmdlet;
            
            ITestCase testCase =
            	TestData.GetTestCase(
            		TMX.TestData.CurrentTestSuite,
            		cmdlet.Name,
            		cmdlet.Id,
            		TMX.TestData.CurrentTestSuite.Name,
            		TMX.TestData.CurrentTestSuite.Id,
            		TMX.TestData.CurrentTestScenario.Name,
            		TMX.TestData.CurrentTestScenario.Id,
            		cmdlet.TestPlatformId);
            
Console.WriteLine("000002");
            
            testCase.TestCodeParameters =
                cmdlet.TestCodeParameters;
            
Console.WriteLine("000003");
            
            if (!cmdlet.OnlySetParameters) {
                cmdlet.RunTestCase(
                	cmdlet,
                	TMX.TestData.CurrentTestSuite, // temporary, add selection from cmdlet's parameters
                	TMX.TestData.CurrentTestScenario);
            }
            
Console.WriteLine("000004");
        }
    }
}
