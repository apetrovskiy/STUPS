/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/4/2013
 * Time: 10:05 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.CheckCmdletParameters
{ // using Xunit;
    
    /// <summary>
    /// Description of InvokeUiaButtonClickCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    // [Ignore("20140128")]
    public class InvokeUiaButtonClickCommandTestFixture
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
        [MbUnit.Framework.Description("Invoke-UiaButtonClick")]
        public void Invoke_UiaButtonClick_NoParameters()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Invoke-UiaButtonClick;");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        [MbUnit.Framework.Description("Invoke-UiaButtonClick -PassThru")]
        public void Invoke_UiaButtonClick_PassThru()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Invoke-UiaButtonClick -PassThru;");
        }
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
//        [MbUnit.Framework.Category("Fast")]
//        [MbUnit.Framework.Description("Invoke-UiaButtonClick 'text'")]
//        public void Invoke_UiaButtonClick_ContainsText_Position0()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Invoke-UiaButtonClick 'text';");
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
//        [MbUnit.Framework.Category("Fast")]
//        [MbUnit.Framework.Description("Invoke-UiaButtonClick -ContainsText 'text'")]
//        public void Invoke_UiaButtonClick_ContainsText()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Invoke-UiaButtonClick -ContainsText 'text';");
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
//        [MbUnit.Framework.Category("Fast")]
//        [MbUnit.Framework.Description("Invoke-UiaButtonClick -ContainsText 'text' -PassThru")]
//        public void Invoke_UiaButtonClick_ContainsText_PassThru()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Invoke-UiaButtonClick -ContainsText 'text' -PassThru;");
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
//        [MbUnit.Framework.Category("Fast")]
//        [MbUnit.Framework.Description("Invoke-UiaButtonClick -Name 'text'")]
//        public void Invoke_UiaButtonClick_Name()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Invoke-UiaButtonClick -Name 'text';");
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
//        [MbUnit.Framework.Category("Fast")]
//        [MbUnit.Framework.Description("Invoke-UiaButtonClick -Name 'text' -Win32")]
//        public void Invoke_UiaButtonClick_Name_Win32()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Invoke-UiaButtonClick -Name 'text' -Win32;");
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
//        [MbUnit.Framework.Category("Fast")]
//        [MbUnit.Framework.Description("Invoke-UiaButtonClick -AutomationId 'text'")]
//        public void Invoke_UiaButtonClick_AutomationId()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Invoke-UiaButtonClick -AutomationId 'text';");
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
//        [MbUnit.Framework.Category("Fast")]
//        [MbUnit.Framework.Description("Invoke-UiaButtonClick -Class 'text'")]
//        public void Invoke_UiaButtonClick_Class()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Invoke-UiaButtonClick -Class 'text';");
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
//        [MbUnit.Framework.Category("Fast")]
//        [MbUnit.Framework.Description("Invoke-UiaButtonClick -Value 'text'")]
//        public void Invoke_UiaButtonClick_Value()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Invoke-UiaButtonClick -Value 'text';");
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
//        [MbUnit.Framework.Category("Fast")]
//        [MbUnit.Framework.Description("Invoke-UiaButtonClick -Name 'text' -AutomationId 'text2' -Class 'text3' -Value 'text4' -PassThru")]
//        public void Invoke_UiaButtonClick_Name_AutomationId_Class_Value_PassThru()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Invoke-UiaButtonClick -Name 'text' -AutomationId 'text2' -Class 'text3' -Value 'text4' -PassThru;");
//        }
    }
}
