/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/4/2013
 * Time: 9:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.CheckCmdletParameters
{ // using Xunit;
    
    /// <summary>
    /// Description of InvokeUiaInvokePatternCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    // [Ignore("20140128")]
    public class InvokeUiaInvokePatternCommandTestFixture
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
        [MbUnit.Framework.Description("Invoke-UiaInvokePattern")]
        public void Invoke_UiaInvokePattern_NoParameters()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Invoke-UiaInvokePattern;");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        [MbUnit.Framework.Description("Invoke-UiaInvokePattern -PassThru")]
        public void Invoke_UiaInvokePattern_PassThru()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Invoke-UiaInvokePattern -PassThru;");
        }
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
//        [MbUnit.Framework.Category("Fast")]
//        [MbUnit.Framework.Description("Invoke-UiaInvokePattern 'text'")]
//        public void Invoke_UiaInvokePattern_ContainsText_Position0()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Invoke-UiaInvokePattern 'text';");
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
//        [MbUnit.Framework.Category("Fast")]
//        [MbUnit.Framework.Description("Invoke-UiaInvokePattern -ContainsText 'text'")]
//        public void Invoke_UiaInvokePattern_ContainsText()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Invoke-UiaInvokePattern -ContainsText 'text';");
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
//        [MbUnit.Framework.Category("Fast")]
//        [MbUnit.Framework.Description("Invoke-UiaInvokePattern -ContainsText 'text' -PassThru")]
//        public void Invoke_UiaInvokePattern_ContainsText_PassThru()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Invoke-UiaInvokePattern -ContainsText 'text' -PassThru;");
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
//        [MbUnit.Framework.Category("Fast")]
//        [MbUnit.Framework.Description("Invoke-UiaInvokePattern -Name 'text'")]
//        public void Invoke_UiaInvokePattern_Name()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Invoke-UiaInvokePattern -Name 'text';");
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
//        [MbUnit.Framework.Category("Fast")]
//        [MbUnit.Framework.Description("Invoke-UiaInvokePattern -Name 'text' -Win32")]
//        public void Invoke_UiaInvokePattern_Name_Win32()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Invoke-UiaInvokePattern -Name 'text' -Win32;");
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
//        [MbUnit.Framework.Category("Fast")]
//        [MbUnit.Framework.Description("Invoke-UiaInvokePattern -AutomationId 'text'")]
//        public void Invoke_UiaInvokePattern_AutomationId()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Invoke-UiaInvokePattern -AutomationId 'text';");
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
//        [MbUnit.Framework.Category("Fast")]
//        [MbUnit.Framework.Description("Invoke-UiaInvokePattern -Class 'text'")]
//        public void Invoke_UiaInvokePattern_Class()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Invoke-UiaInvokePattern -Class 'text';");
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
//        [MbUnit.Framework.Category("Fast")]
//        [MbUnit.Framework.Description("Invoke-UiaInvokePattern -Value 'text'")]
//        public void Invoke_UiaInvokePattern_Value()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Invoke-UiaInvokePattern -Value 'text';");
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
//        [MbUnit.Framework.Category("Fast")]
//        [MbUnit.Framework.Description("Invoke-UiaInvokePattern -Name 'text' -AutomationId 'text2' -Class 'text3' -Value 'text4' -PassThru")]
//        public void Invoke_UiaInvokePattern_Name_AutomationId_Class_Value_PassThru()
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Invoke-UiaInvokePattern -Name 'text' -AutomationId 'text2' -Class 'text3' -Value 'text4' -PassThru;");
//        }
    }
}
