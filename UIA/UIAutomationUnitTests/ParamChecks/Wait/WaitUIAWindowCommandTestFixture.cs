/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/25/2013
 * Time: 1:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.CheckCmdletParameters
{
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of WaitUiaWindowCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class WaitUiaWindowCommandTestFixture
    {
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspaceForParamChecks();
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
        
        
//        [Test]
//        [Category("Fast")]
//        public void Get_UiaWindow_NoParameters()
//        {
//            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParameterMissing(
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParameterMissing(
//        		"Get-UiaWindow;");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        public void Get_UiaWindow_ProcessName()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_FailureOutput(
//        		"Get-UiaWindow -ProcessName processName;");
//        }
    }
}
