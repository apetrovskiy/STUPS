/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 07/12/2011
 * Time: 11:44 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Common
{
    using System.Windows.Automation;

    /// <summary>
    /// Description of ReadUiaControlAutomationIdCommandTextFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="Read-UiaControlAutomationIdCommand test")]
    public class ReadUiaControlAutomationIdCommandTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="InputObject ProcessRecord test Null via pipeline")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("NoForms")]
        public void ReadUiaControlAutomationId_TestPipelineInput()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsTrue(
                @"if ( ($null | Read-UiaControlAutomationId) ) { 1; } else { 0; }",
                "0");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="ProcessRecord test Null via parameter")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("NoForms")]
        public void ReadUiaControlAutomationId_TestParameterInputNull()
        {
//            CmdletUnitTest.TestRunspace.RunAndEvaluateIsNull(
//                @"if ((Read-UiaControlAutomationId -InputObject $null)) { 1; } else { 0; }");
            
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Read-UiaControlAutomationId -InputObject $null)) { 1; } else { 0; }",
                "ParameterBindingValidationException",
                "Cannot validate argument on parameter 'InputObject'. The argument is null or empty. Supply an argument that is not null or empty and then try the command again.");
            
//            UIAutomationTest.Commands.Common.ReadUiaControlAutomationIdCommandTestFixture.TestParameterInputNull:
//System.Management.Automation.ParameterBindingValidationException : Cannot validate argument on parameter 'InputObject'. The argument is null or empty. Supply an argument that is not null or empty and then try the command again.
//  ----> System.Management.Automation.ValidationMetadataException : The argument is null or empty. Supply an argument that is not null or empty and then try the command again.
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="ProcessRecord test Is Not AutomationElement")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("NoForms")]
        public void ReadUiaControlAutomationId_TestParameterInputOtherType()
        {
//            CmdletUnitTest.TestRunspace.RunAndEvaluateIsNull(
//                @"if ((Read-UiaControlAutomationId -InputObject (New-Object System.Windows.forms.Label))) { 1; }else{ 0; }");
            
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Read-UiaControlAutomationId -InputObject (New-Object System.Windows.forms.Label))) { 1; } else { 0; }",
                "ParameterBindingException",
                //@"Cannot bind parameter 'InputObject'. Cannot convert the ""System.Windows.Forms.Label, Text: "" value of type ""System.Windows.Forms.Label"" to type ""System.Windows.Automation.AutomationElement"".");
                @"Cannot bind parameter 'InputObject'. Cannot convert the ""System.Windows.Forms.Label, Text: "" value of type ""System.Windows.Forms.Label"" to type ""UIAutomation.IUiElement"".");
            
//            UIAutomationTest.Commands.Common.ReadUiaControlAutomationIdCommandTestFixture.TestParameterInputOtherType:
//System.Management.Automation.ParameterBindingException : Cannot bind parameter 'InputObject'. Cannot convert the "System.Windows.Forms.Label, Text: " value of type "System.Windows.Forms.Label" to type "System.Windows.Automation.AutomationElement".
//  ----> System.Management.Automation.PSInvalidCastException : Cannot convert the "System.Windows.Forms.Label, Text: " value of type "System.Windows.Forms.Label" to type "System.Windows.Automation.AutomationElement".
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="ProcessRecord test Is AutomationElement")]
        //[MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("NUnit")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        public void ReadUiaControlAutomationId_TestParameterInputControlWithAutomationId()
        {
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"Get-UiaWindow -Name '" + 
//                CmdletUnitTest.TestRunspace.NUnitTitle + 
//                "' | Get-UiaPane -AutomationId '" + 
//                CmdletUnitTest.TestRunspace.NUnitTreeSplitterAutomationId + 
//                "' | Read-UiaControlAutomationId",
//                CmdletUnitTest.TestRunspace.NUnitTreeSplitterAutomationId);
            string automationId = "btnAuId";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                ControlType.Button,
                "btnName",
                automationId,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"if ((Get-UiaWindow -n " +
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UiaButton -name btnName | Read-UiaControlAutomationId)) { '" + 
                automationId + 
                "'; } else { ''; }",
                automationId);
        }

        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
    }
}
