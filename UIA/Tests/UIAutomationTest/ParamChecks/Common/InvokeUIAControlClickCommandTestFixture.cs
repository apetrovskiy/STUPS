/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/4/2013
 * Time: 10:18 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.CheckCmdletParameters
{ // using Xunit;
    
    /// <summary>
    /// Description of InvokeUiaControlClickCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    // [Ignore("20140128")]
    public class InvokeUiaControlClickCommandTestFixture
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
        [MbUnit.Framework.Description("Invoke-UiaControlClick")]
        public void Invoke_UiaControlClick_NoParameters()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Invoke-UiaControlClick;");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        [MbUnit.Framework.Description("Invoke-UiaControlClick -PassThru")]
        public void Invoke_UiaControlClick_PassThru()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Invoke-UiaControlClick -PassThru;");
        }
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
//        [MbUnit.Framework.Category("Fast")]
//        [MbUnit.Framework.Description("Invoke-UiaControlClick 'text'")]
//        public void Invoke_UiaControlClick_ContainsText_Position0()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Invoke-UiaControlClick 'text';");
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
//        [MbUnit.Framework.Category("Fast")]
//        [MbUnit.Framework.Description("Invoke-UiaControlClick -ContainsText 'text'")]
//        public void Invoke_UiaControlClick_ContainsText()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Invoke-UiaControlClick -ContainsText 'text';");
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
//        [MbUnit.Framework.Category("Fast")]
//        [MbUnit.Framework.Description("Invoke-UiaControlClick -ContainsText 'text' -PassThru")]
//        public void Invoke_UiaControlClick_ContainsText_PassThru()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Invoke-UiaControlClick -ContainsText 'text' -PassThru;");
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
//        [MbUnit.Framework.Category("Fast")]
//        [MbUnit.Framework.Description("Invoke-UiaControlClick -Name 'text'")]
//        public void Invoke_UiaControlClick_Name()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Invoke-UiaControlClick -Name 'text';");
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
//        [MbUnit.Framework.Category("Fast")]
//        [MbUnit.Framework.Description("Invoke-UiaControlClick -Name 'text' -Win32")]
//        public void Invoke_UiaControlClick_Name_Win32()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Invoke-UiaControlClick -Name 'text' -Win32;");
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
//        [MbUnit.Framework.Category("Fast")]
//        [MbUnit.Framework.Description("Invoke-UiaControlClick -AutomationId 'text'")]
//        public void Invoke_UiaControlClick_AutomationId()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Invoke-UiaControlClick -AutomationId 'text';");
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
//        [MbUnit.Framework.Category("Fast")]
//        [MbUnit.Framework.Description("Invoke-UiaControlClick -Class 'text'")]
//        public void Invoke_UiaControlClick_Class()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Invoke-UiaControlClick -Class 'text';");
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
//        [MbUnit.Framework.Category("Fast")]
//        [MbUnit.Framework.Description("Invoke-UiaControlClick -Value 'text'")]
//        public void Invoke_UiaControlClick_Value()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Invoke-UiaControlClick -Value 'text';");
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
//        [MbUnit.Framework.Category("Fast")]
//        [MbUnit.Framework.Description("Invoke-UiaControlClick -Name 'text' -AutomationId 'text2' -Class 'text3' -Value 'text4' -PassThru")]
//        public void Invoke_UiaControlClick_Name_AutomationId_Class_Value_PassThru()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Invoke-UiaControlClick -Name 'text' -AutomationId 'text2' -Class 'text3' -Value 'text4' -PassThru;");
//        }
    }
}
