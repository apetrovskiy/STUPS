/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/25/2013
 * Time: 1:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.CheckCmdletParameters
{ // using Xunit;
    
    /// <summary>
    /// Description of WaitUiaWindowCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    // [Ignore("20140128")]
    public class WaitUiaWindowCommandTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode2.PrepareRunspaceForParamChecks();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            // MiddleLevelCode.DisposeRunspace();
        }
        
        
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
//        [MbUnit.Framework.Category("Fast")]
//        public void Get_UiaWindow_NoParameters()
//        {
//            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParameterMissing(
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParameterMissing(
//                "Get-UiaWindow;");
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
//        [MbUnit.Framework.Category("Fast")]
//        public void Get_UiaWindow_ProcessName()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_FailureOutput(
//                "Get-UiaWindow -ProcessName processName;");
//        }
    }
}
