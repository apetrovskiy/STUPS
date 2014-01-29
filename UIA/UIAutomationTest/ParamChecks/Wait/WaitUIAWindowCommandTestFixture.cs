/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/25/2013
 * Time: 1:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.CheckCmdletParameters
{
    using MbUnit.Framework;// using Xunit;
    
    /// <summary>
    /// Description of WaitUiaWindowCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture]
    // [Ignore("20140128")]
    public class WaitUiaWindowCommandTestFixture
    {
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode2.PrepareRunspaceForParamChecks();
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            // MiddleLevelCode.DisposeRunspace();
        }
        
        
        
//        [Test]// [Fact]
//        [Category("Fast")]
//        public void Get_UiaWindow_NoParameters()
//        {
//            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParameterMissing(
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParameterMissing(
//        		"Get-UiaWindow;");
//        }
//        
//        [Test]// [Fact]
//        [Category("Fast")]
//        public void Get_UiaWindow_ProcessName()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_FailureOutput(
//        		"Get-UiaWindow -ProcessName processName;");
//        }
    }
}
