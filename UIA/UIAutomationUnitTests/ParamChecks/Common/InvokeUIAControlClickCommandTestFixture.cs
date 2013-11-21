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
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of InvokeUiaControlClickCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class InvokeUiaControlClickCommandTestFixture
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
        [Description("Invoke-UiaControlClick")]
        public void Invoke_UiaControlClick_NoParameters()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Invoke-UiaControlClick;");
        }
        
        [Test]
        [Category("Fast")]
        [Description("Invoke-UiaControlClick -PassThru")]
        public void Invoke_UiaControlClick_PassThru()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Invoke-UiaControlClick -PassThru;");
        }
        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UiaControlClick 'text'")]
//        public void Invoke_UiaControlClick_ContainsText_Position0()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UiaControlClick 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UiaControlClick -ContainsText 'text'")]
//        public void Invoke_UiaControlClick_ContainsText()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UiaControlClick -ContainsText 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UiaControlClick -ContainsText 'text' -PassThru")]
//        public void Invoke_UiaControlClick_ContainsText_PassThru()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UiaControlClick -ContainsText 'text' -PassThru;");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UiaControlClick -Name 'text'")]
//        public void Invoke_UiaControlClick_Name()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UiaControlClick -Name 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UiaControlClick -Name 'text' -Win32")]
//        public void Invoke_UiaControlClick_Name_Win32()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UiaControlClick -Name 'text' -Win32;");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UiaControlClick -AutomationId 'text'")]
//        public void Invoke_UiaControlClick_AutomationId()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UiaControlClick -AutomationId 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UiaControlClick -Class 'text'")]
//        public void Invoke_UiaControlClick_Class()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UiaControlClick -Class 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UiaControlClick -Value 'text'")]
//        public void Invoke_UiaControlClick_Value()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UiaControlClick -Value 'text';");
//        }
//        
//        [Test]
//        [Category("Fast")]
//        [Description("Invoke-UiaControlClick -Name 'text' -AutomationId 'text2' -Class 'text3' -Value 'text4' -PassThru")]
//        public void Invoke_UiaControlClick_Name_AutomationId_Class_Value_PassThru()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//        		"Invoke-UiaControlClick -Name 'text' -AutomationId 'text2' -Class 'text3' -Value 'text4' -PassThru;");
//        }
    }
}
