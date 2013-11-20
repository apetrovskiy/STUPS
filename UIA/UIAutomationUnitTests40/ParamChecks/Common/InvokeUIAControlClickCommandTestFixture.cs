/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/4/2013
 * Time: 10:18 PM
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
    /// Description of InvokeUIAControlClickCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class InvokeUIAControlClickCommandTestFixture
    {
        public InvokeUIAControlClickCommandTestFixture()
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
        [Description("Invoke-UIAControlClick")]
        public void Invoke_UIAControlClick_NoParameters()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Invoke-UIAControlClick;");
        }
        
        [Test]
        [Category("Fast")]
        [Description("Invoke-UIAControlClick -PassThru")]
        public void Invoke_UIAControlClick_PassThru()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Invoke-UIAControlClick -PassThru;");
        }
        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UIAControlClick 'text'")]
//        public void Invoke_UIAControlClick_ContainsText_Position0()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UIAControlClick 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UIAControlClick -ContainsText 'text'")]
//        public void Invoke_UIAControlClick_ContainsText()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UIAControlClick -ContainsText 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UIAControlClick -ContainsText 'text' -PassThru")]
//        public void Invoke_UIAControlClick_ContainsText_PassThru()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UIAControlClick -ContainsText 'text' -PassThru;");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UIAControlClick -Name 'text'")]
//        public void Invoke_UIAControlClick_Name()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UIAControlClick -Name 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UIAControlClick -Name 'text' -Win32")]
//        public void Invoke_UIAControlClick_Name_Win32()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UIAControlClick -Name 'text' -Win32;");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UIAControlClick -AutomationId 'text'")]
//        public void Invoke_UIAControlClick_AutomationId()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UIAControlClick -AutomationId 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UIAControlClick -Class 'text'")]
//        public void Invoke_UIAControlClick_Class()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UIAControlClick -Class 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UIAControlClick -Value 'text'")]
//        public void Invoke_UIAControlClick_Value()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UIAControlClick -Value 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UIAControlClick -Name 'text' -AutomationId 'text2' -Class 'text3' -Value 'text4' -PassThru")]
//        public void Invoke_UIAControlClick_Name_AutomationId_Class_Value_PassThru()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UIAControlClick -Name 'text' -AutomationId 'text2' -Class 'text3' -Value 'text4' -PassThru;");
//        }
    }
}
