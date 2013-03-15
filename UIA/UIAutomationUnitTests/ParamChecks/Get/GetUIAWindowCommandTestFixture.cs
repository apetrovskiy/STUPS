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
    using System;
    using System.Windows.Automation;
    using PSTestLib;
    using UIAutomation;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of GetUIAWindowCommandTestFixture.
    /// </summary>
    public class GetUIAWindowCommandTestFixture
    {
        public GetUIAWindowCommandTestFixture()
        {
        }
        
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
        public void Get_UIAWindow_NoParameters()
        {
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParameterMissing(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParameterMissing(
        		"Get-UIAWindow;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UIAWindow_ProcessName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UIAWindow -ProcessName processName;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UIAWindow_ProcessId()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UIAWindow -ProcessId 123;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UIAWindow_Process()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UIAWindow -InputObject $null;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UIAWindow_ProcessName_Name_AuId_Class()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UIAWindow -ProcessName processName -Name aaa -AutomationId bbb -Class ccc;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UIAWindow_ProcessId_Name_AuId_Class()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UIAWindow -ProcessId 123 -Name aaa -AutomationId bbb -Class ccc;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UIAWindow_Process_Name_AuId_Class()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UIAWindow -InputObject $null -Name aaa -AutomationId bbb -Class ccc;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UIAWindow_ProcessName_First()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UIAWindow -ProcessName processName -First;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UIAWindow_ProcessId_First()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UIAWindow -ProcessId 123 -First;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UIAWindow_Process_First()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UIAWindow -InputObject $null -First;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UIAWindow_ProcessName_Recurse()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UIAWindow -ProcessName processName -Recurse;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UIAWindow_ProcessId_Recurse()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UIAWindow -ProcessId 123 -Recurse;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UIAWindow_Process_Recurse()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UIAWindow -InputObject $null -Recurse;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UIAWindow_Name()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
        		"Get-UIAWindow -Name name;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UIAWindow_Name_Array()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
        		"Get-UIAWindow -Name name1,name2,name3;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UIAWindow_Name_AuId()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
        		"Get-UIAWindow -Name name -AutomationId aaa;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UIAWindow_Name_Class()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
        		"Get-UIAWindow -Name name -Class ccc;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UIAWindow_Name_AuId_Class()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
        		"Get-UIAWindow -Name name -AutomationId aaa -Class ccc;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_UIAWindow_Name_First()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
        		"Get-UIAWindow -Name name -First;");
        }
    }
}
