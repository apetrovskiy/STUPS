/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/27/2013
 * Time: 12:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.CheckCmdletParameters
{ // using Xunit;
    
    /// <summary>
    /// Description of GetUiaControlCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    // [Ignore("20140128")]
    public class GetUiaControlCommandTestFixture
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
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        public void Get_UiaControl_NoParameters()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-UiaControl;");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        public void Get_UiaControl_ControlType()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-UiaControl -ControlType Button;");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        public void Get_UiaControl_Name()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-UiaControl -Name 'aaa';");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        public void Get_UiaControl_ControlType_Name()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-UiaControl -ControlType Button -Name 'aaa';");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        public void Get_UiaControl_AutomationId()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-UiaControl -AutomationId '111';");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        public void Get_UiaControl_ControlType_AutomationId()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-UiaControl -ControlType Button -AutomationId '111';");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        public void Get_UiaControl_ClassName()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-UiaControl -Class 'class';");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        public void Get_UiaControl_ControlType_ClassName()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-UiaControl -ControlType Button -Class 'class';");
        }
    }
}
