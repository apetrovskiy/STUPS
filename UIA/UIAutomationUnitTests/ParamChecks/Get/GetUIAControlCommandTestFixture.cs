/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/27/2013
 * Time: 12:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.CheckCmdletParameters
{
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of GetUiaControlCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class GetUiaControlCommandTestFixture
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
        
        [Test]
        [Category("Fast")]
        public void Get_UiaControl_NoParameters()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UiaControl;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UiaControl_ControlType()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UiaControl -ControlType Button;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UiaControl_Name()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UiaControl -Name 'aaa';");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UiaControl_ControlType_Name()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UiaControl -ControlType Button -Name 'aaa';");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UiaControl_AutomationId()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UiaControl -AutomationId '111';");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UiaControl_ControlType_AutomationId()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UiaControl -ControlType Button -AutomationId '111';");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UiaControl_ClassName()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UiaControl -Class 'class';");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UiaControl_ControlType_ClassName()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UiaControl -ControlType Button -Class 'class';");
        }
    }
}
