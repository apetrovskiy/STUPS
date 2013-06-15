/*
 * Created by SharpDevelop.
 * User: Alexander
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
            
            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            
//            ITestCase testCase =
//            	TestData.GetTestCase(
//            		cmdlet.Name,
//            		cmdlet.Id,
//            		cmdlet.TestPlatformId);
//            
//            cmdlet.RunTestCase(
//            	cmdlet,
//            	testSuite);
            
        }
    }
}
