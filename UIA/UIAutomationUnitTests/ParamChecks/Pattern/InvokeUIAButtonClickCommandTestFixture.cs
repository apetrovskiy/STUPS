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
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of InvokeUiaButtonClickCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class InvokeUiaButtonClickCommandTestFixture
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
        [Description("Invoke-UiaButtonClick")]
        public void Invoke_UiaButtonClick_NoParameters()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Invoke-UiaButtonClick;");
        }
        
        [Test]
        [Category("Fast")]
        [Description("Invoke-UiaButtonClick -PassThru")]
        public void Invoke_UiaButtonClick_PassThru()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Invoke-UiaButtonClick -PassThru;");
        }
        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UiaButtonClick 'text'")]
//        public void Invoke_UiaButtonClick_ContainsText_Position0()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UiaButtonClick 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UiaButtonClick -ContainsText 'text'")]
//        public void Invoke_UiaButtonClick_ContainsText()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UiaButtonClick -ContainsText 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UiaButtonClick -ContainsText 'text' -PassThru")]
//        public void Invoke_UiaButtonClick_ContainsText_PassThru()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UiaButtonClick -ContainsText 'text' -PassThru;");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UiaButtonClick -Name 'text'")]
//        public void Invoke_UiaButtonClick_Name()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UiaButtonClick -Name 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UiaButtonClick -Name 'text' -Win32")]
//        public void Invoke_UiaButtonClick_Name_Win32()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UiaButtonClick -Name 'text' -Win32;");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UiaButtonClick -AutomationId 'text'")]
//        public void Invoke_UiaButtonClick_AutomationId()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UiaButtonClick -AutomationId 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UiaButtonClick -Class 'text'")]
//        public void Invoke_UiaButtonClick_Class()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UiaButtonClick -Class 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UiaButtonClick -Value 'text'")]
//        public void Invoke_UiaButtonClick_Value()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UiaButtonClick -Value 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UiaButtonClick -Name 'text' -AutomationId 'text2' -Class 'text3' -Value 'text4' -PassThru")]
//        public void Invoke_UiaButtonClick_Name_AutomationId_Class_Value_PassThru()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UiaButtonClick -Name 'text' -AutomationId 'text2' -Class 'text3' -Value 'text4' -PassThru;");
//        }
    }
}
