/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/4/2013
 * Time: 10:05 PM
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
    /// Description of InvokeUIAButtonClickCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class InvokeUIAButtonClickCommandTestFixture
    {
        public InvokeUIAButtonClickCommandTestFixture()
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
        [Description("Invoke-UIAButtonClick")]
        public void Invoke_UIAButtonClick_NoParameters()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Invoke-UIAButtonClick;");
        }
        
        [Test]
        [Category("Fast")]
        [Description("Invoke-UIAButtonClick -PassThru")]
        public void Invoke_UIAButtonClick_PassThru()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Invoke-UIAButtonClick -PassThru;");
        }
        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UIAButtonClick 'text'")]
//        public void Invoke_UIAButtonClick_ContainsText_Position0()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UIAButtonClick 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UIAButtonClick -ContainsText 'text'")]
//        public void Invoke_UIAButtonClick_ContainsText()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UIAButtonClick -ContainsText 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UIAButtonClick -ContainsText 'text' -PassThru")]
//        public void Invoke_UIAButtonClick_ContainsText_PassThru()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UIAButtonClick -ContainsText 'text' -PassThru;");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UIAButtonClick -Name 'text'")]
//        public void Invoke_UIAButtonClick_Name()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UIAButtonClick -Name 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UIAButtonClick -Name 'text' -Win32")]
//        public void Invoke_UIAButtonClick_Name_Win32()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UIAButtonClick -Name 'text' -Win32;");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UIAButtonClick -AutomationId 'text'")]
//        public void Invoke_UIAButtonClick_AutomationId()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UIAButtonClick -AutomationId 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UIAButtonClick -Class 'text'")]
//        public void Invoke_UIAButtonClick_Class()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UIAButtonClick -Class 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UIAButtonClick -Value 'text'")]
//        public void Invoke_UIAButtonClick_Value()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UIAButtonClick -Value 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UIAButtonClick -Name 'text' -AutomationId 'text2' -Class 'text3' -Value 'text4' -PassThru")]
//        public void Invoke_UIAButtonClick_Name_AutomationId_Class_Value_PassThru()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UIAButtonClick -Name 'text' -AutomationId 'text2' -Class 'text3' -Value 'text4' -PassThru;");
//        }
    }
}
