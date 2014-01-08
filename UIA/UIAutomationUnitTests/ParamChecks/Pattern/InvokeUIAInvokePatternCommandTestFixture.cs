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
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of InvokeUiaInvokePatternCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class InvokeUiaInvokePatternCommandTestFixture
    {
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspaceForParamChecks();
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            // MiddleLevelCode.DisposeRunspace();
        }
        
        [Test]
        [Category("Fast")]
        [Description("Invoke-UiaInvokePattern")]
        public void Invoke_UiaInvokePattern_NoParameters()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Invoke-UiaInvokePattern;");
        }
        
        [Test]
        [Category("Fast")]
        [Description("Invoke-UiaInvokePattern -PassThru")]
        public void Invoke_UiaInvokePattern_PassThru()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Invoke-UiaInvokePattern -PassThru;");
        }
        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UiaInvokePattern 'text'")]
//        public void Invoke_UiaInvokePattern_ContainsText_Position0()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UiaInvokePattern 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UiaInvokePattern -ContainsText 'text'")]
//        public void Invoke_UiaInvokePattern_ContainsText()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UiaInvokePattern -ContainsText 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UiaInvokePattern -ContainsText 'text' -PassThru")]
//        public void Invoke_UiaInvokePattern_ContainsText_PassThru()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UiaInvokePattern -ContainsText 'text' -PassThru;");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UiaInvokePattern -Name 'text'")]
//        public void Invoke_UiaInvokePattern_Name()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UiaInvokePattern -Name 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UiaInvokePattern -Name 'text' -Win32")]
//        public void Invoke_UiaInvokePattern_Name_Win32()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UiaInvokePattern -Name 'text' -Win32;");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UiaInvokePattern -AutomationId 'text'")]
//        public void Invoke_UiaInvokePattern_AutomationId()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UiaInvokePattern -AutomationId 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UiaInvokePattern -Class 'text'")]
//        public void Invoke_UiaInvokePattern_Class()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UiaInvokePattern -Class 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UiaInvokePattern -Value 'text'")]
//        public void Invoke_UiaInvokePattern_Value()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UiaInvokePattern -Value 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UiaInvokePattern -Name 'text' -AutomationId 'text2' -Class 'text3' -Value 'text4' -PassThru")]
//        public void Invoke_UiaInvokePattern_Name_AutomationId_Class_Value_PassThru()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UiaInvokePattern -Name 'text' -AutomationId 'text2' -Class 'text3' -Value 'text4' -PassThru;");
//        }
    }
}
