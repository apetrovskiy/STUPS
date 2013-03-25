/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 3/25/2013
 * Time: 1:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TMXSetCurrentTestResultCommand.
    /// </summary>
    internal class TMXSetCurrentTestResultCommand : TMXCommand
    {
        internal TMXSetCurrentTestResultCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            TestResultCmdletBase cmdlet =
                (TestResultCmdletBase)this.Cmdlet;
                
            cmdlet.WriteVerbose(
                cmdlet,
                "Checking the current test structure, creating the first test suite and scenario if needed");
            TestData.InitCurrentTestScenario();
            
            cmdlet.WriteVerbose(
                cmdlet,
                "Checking whether the current test result is fulfilled and must be added to the current test scenairo' results");
            if (null != TestData.CurrentTestResult) {
                
                cmdlet.WriteVerbose(
                    cmdlet,
                    "The current test result is not null");

                if ((null != TestData.CurrentTestResult.Name &&
                    string.Empty != TestData.CurrentTestResult.Name &&
                    null != TestData.CurrentTestResult.Id &&
                    string.Empty != TestData.CurrentTestResult.Id) ||
                    (0 < TestData.CurrentTestResult.Details.Count)) {
                    
                    cmdlet.WriteVerbose(
                        cmdlet,
                        "Adding the current test result to the current test scenario' results");
                    
                    TestData.CurrentTestScenario.TestResults.Add(TestData.CurrentTestResult);                
                }
                
            }
            
            cmdlet.WriteVerbose(
                cmdlet,
                "Creating the current test result for putting new data into it");
            
            TestData.CurrentTestResult =
                new TestResult(
                    TestData.CurrentTestScenario.Id,
                    TestData.CurrentTestSuite.Id);
            
            cmdlet.WriteVerbose(
                cmdlet,
                "Writing data to the current test result");
            
            TMXHelper.SetCurrentTestResult(cmdlet);
            
        }
    }
}
