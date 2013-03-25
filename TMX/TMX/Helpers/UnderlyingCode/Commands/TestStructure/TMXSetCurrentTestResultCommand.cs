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
                
            TestData.InitCurrentTestScenario();
            
            if (null != TestData.CurrentTestResult) {
             
                TestData.CurrentTestScenario.TestResults.Add(TestData.CurrentTestResult);                
            }
                
            TestData.CurrentTestResult =
                new TestResult(
                    TestData.CurrentTestScenario.Id,
                    TestData.CurrentTestSuite.Id);
            
            TMXHelper.SetCurrentTestResult(cmdlet);
            
        }
    }
}
