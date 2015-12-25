/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/24/2013
 * Time: 1:01 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.CheckCmdletParameters
{ // using Xunit;
    
    /// <summary>
    /// Description of GetUiaWindowCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    // [Ignore("20140128")]
    public class GetUiaWindowCommandTestFixture
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
        public void Get_UiaWindow_NoParameters()
        {
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParameterMissing(
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParameterMissing(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-UiaWindow;");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        public void Get_UiaWindow_ProcessName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-UiaWindow -ProcessName processName;");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        public void Get_UiaWindow_ProcessId()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-UiaWindow -ProcessId 123;");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        public void Get_UiaWindow_Process()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsBinding_ValidationException(
                "Get-UiaWindow -InputObject $null;");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        public void Get_UiaWindow_ProcessName_Name_AuId_Class()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-UiaWindow -ProcessName processName -Name aaa -AutomationId bbb -Class ccc;");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        public void Get_UiaWindow_ProcessId_Name_AuId_Class()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-UiaWindow -ProcessId 123 -Name aaa -AutomationId bbb -Class ccc;");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        public void Get_UiaWindow_Process_Name_AuId_Class()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsBinding_ValidationException(
                "Get-UiaWindow -InputObject $null -Name aaa -AutomationId bbb -Class ccc;");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        public void Get_UiaWindow_ProcessName_First()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-UiaWindow -ProcessName processName -First;");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        public void Get_UiaWindow_ProcessId_First()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-UiaWindow -ProcessId 123 -First;");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        public void Get_UiaWindow_Process_First()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsBinding_ValidationException(
                "Get-UiaWindow -InputObject $null -First;");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        public void Get_UiaWindow_ProcessName_Recurse()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-UiaWindow -ProcessName processName -Recurse;");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        public void Get_UiaWindow_ProcessId_Recurse()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-UiaWindow -ProcessId 123 -Recurse;");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        public void Get_UiaWindow_Process_Recurse()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsBinding_ValidationException(
                "Get-UiaWindow -InputObject $null -Recurse;");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        public void Get_UiaWindow_Name()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-UiaWindow -Name name;");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        public void Get_UiaWindow_Name_Array()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-UiaWindow -Name name1,name2,name3;");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        public void Get_UiaWindow_Name_AuId()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-UiaWindow -Name name -AutomationId aaa;");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        public void Get_UiaWindow_Name_Class()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-UiaWindow -Name name -Class ccc;");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        public void Get_UiaWindow_Name_AuId_Class()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-UiaWindow -Name name -AutomationId aaa -Class ccc;");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        public void Get_UiaWindow_Name_First()
        {
            // 20130918
            //CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-UiaWindow -Name name -First;");
        }
    }
}
