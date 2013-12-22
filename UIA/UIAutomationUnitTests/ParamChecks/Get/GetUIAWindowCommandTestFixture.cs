/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/24/2013
 * Time: 1:01 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.CheckCmdletParameters
{
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of GetUiaWindowCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class GetUiaWindowCommandTestFixture
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
        public void Get_UiaWindow_NoParameters()
        {
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParameterMissing(
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParameterMissing(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UiaWindow;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UiaWindow_ProcessName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UiaWindow -ProcessName processName;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UiaWindow_ProcessId()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UiaWindow -ProcessId 123;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UiaWindow_Process()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsBinding_ValidationException(
        		"Get-UiaWindow -InputObject $null;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UiaWindow_ProcessName_Name_AuId_Class()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UiaWindow -ProcessName processName -Name aaa -AutomationId bbb -Class ccc;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UiaWindow_ProcessId_Name_AuId_Class()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UiaWindow -ProcessId 123 -Name aaa -AutomationId bbb -Class ccc;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UiaWindow_Process_Name_AuId_Class()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsBinding_ValidationException(
        		"Get-UiaWindow -InputObject $null -Name aaa -AutomationId bbb -Class ccc;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UiaWindow_ProcessName_First()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UiaWindow -ProcessName processName -First;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UiaWindow_ProcessId_First()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UiaWindow -ProcessId 123 -First;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UiaWindow_Process_First()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsBinding_ValidationException(
        		"Get-UiaWindow -InputObject $null -First;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UiaWindow_ProcessName_Recurse()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UiaWindow -ProcessName processName -Recurse;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UiaWindow_ProcessId_Recurse()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UiaWindow -ProcessId 123 -Recurse;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UiaWindow_Process_Recurse()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsBinding_ValidationException(
        		"Get-UiaWindow -InputObject $null -Recurse;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UiaWindow_Name()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UiaWindow -Name name;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UiaWindow_Name_Array()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UiaWindow -Name name1,name2,name3;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UiaWindow_Name_AuId()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UiaWindow -Name name -AutomationId aaa;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UiaWindow_Name_Class()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UiaWindow -Name name -Class ccc;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UiaWindow_Name_AuId_Class()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UiaWindow -Name name -AutomationId aaa -Class ccc;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UiaWindow_Name_First()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UiaWindow -Name name -First;");
        }
    }
}
