/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/15/2013
 * Time: 7:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
	/// <summary>
	/// Description of TMXInvokeTestSuiteCommand.
	/// </summary>
    internal class TMXInvokeTestSuiteCommand : TMXCommand
    {
        internal TMXInvokeTestSuiteCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            TestSuiteExecCmdletBase cmdlet =
                (TestSuiteExecCmdletBase)this.Cmdlet;
            
            ITestSuite testSuite =
            	TestData.GetTestSuite(
            		cmdlet.Name,
            		cmdlet.Id,
            		cmdlet.TestPlatformId);
            
            testSuite.BeforeScenarioParameters =
                cmdlet.BeforeScenarioParameters;
            testSuite.AfterScenarioParameters =
                cmdlet.AfterScenarioParameters;
            
            if (!cmdlet.OnlySetParameters) {
                cmdlet.RunTestSuite(
                	cmdlet,
                	testSuite);
            }
        }
    }
}
