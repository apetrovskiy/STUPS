/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/4/2013
 * Time: 9:35 PM
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
    /// Description of InvokeUIAInvokePatternCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class InvokeUIAInvokePatternCommandTestFixture
    {
        public InvokeUIAInvokePatternCommandTestFixture()
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
        [Description("Invoke-UIAInvokePattern")]
        public void Invoke_UIAInvokePattern_NoParameters()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Invoke-UIAInvokePattern;");
        }
        
        [Test]
        [Category("Fast")]
        [Description("Invoke-UIAInvokePattern -PassThru")]
        public void Invoke_UIAInvokePattern_PassThru()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Invoke-UIAInvokePattern -PassThru;");
        }
        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UIAInvokePattern 'text'")]
//        public void Invoke_UIAInvokePattern_ContainsText_Position0()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UIAInvokePattern 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UIAInvokePattern -ContainsText 'text'")]
//        public void Invoke_UIAInvokePattern_ContainsText()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UIAInvokePattern -ContainsText 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UIAInvokePattern -ContainsText 'text' -PassThru")]
//        public void Invoke_UIAInvokePattern_ContainsText_PassThru()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UIAInvokePattern -ContainsText 'text' -PassThru;");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UIAInvokePattern -Name 'text'")]
//        public void Invoke_UIAInvokePattern_Name()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UIAInvokePattern -Name 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UIAInvokePattern -Name 'text' -Win32")]
//        public void Invoke_UIAInvokePattern_Name_Win32()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UIAInvokePattern -Name 'text' -Win32;");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UIAInvokePattern -AutomationId 'text'")]
//        public void Invoke_UIAInvokePattern_AutomationId()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UIAInvokePattern -AutomationId 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UIAInvokePattern -Class 'text'")]
//        public void Invoke_UIAInvokePattern_Class()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UIAInvokePattern -Class 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UIAInvokePattern -Value 'text'")]
//        public void Invoke_UIAInvokePattern_Value()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UIAInvokePattern -Value 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UIAInvokePattern -Name 'text' -AutomationId 'text2' -Class 'text3' -Value 'text4' -PassThru")]
//        public void Invoke_UIAInvokePattern_Name_AutomationId_Class_Value_PassThru()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UIAInvokePattern -Name 'text' -AutomationId 'text2' -Class 'text3' -Value 'text4' -PassThru;");
//        }
    }
}
