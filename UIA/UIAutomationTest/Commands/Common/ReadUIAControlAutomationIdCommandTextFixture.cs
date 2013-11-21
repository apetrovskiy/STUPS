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
    using System;
    using System.Windows.Automation;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;

    /// <summary>
    /// Description of ReadUiaControlAutomationIdCommandTextFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Read-UiaControlAutomationIdCommand test")]
    public class ReadUiaControlAutomationIdCommandTestFixture
    {
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="InputObject ProcessRecord test Null via pipeline")]
        [Category("Slow")]
        [Category("NoForms")]
        public void ReadUiaControlAutomationId_TestPipelineInput()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsTrue(
                @"if ( ($null | Read-UiaControlAutomationId) ) { 1; } else { 0; }",
                "0");
        }
        
        [Test] //[Test(Description="ProcessRecord test Null via parameter")]
        [Category("Slow")]
        [Category("NoForms")]
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
        
        [Test] //[Test(Description="ProcessRecord test Is Not AutomationElement")]
        [Category("Slow")]
        [Category("NoForms")]
        public void ReadUiaControlAutomationId_TestParameterInputOtherType()
        {
//            CmdletUnitTest.TestRunspace.RunAndEvaluateIsNull(
//                @"if ((Read-UiaControlAutomationId -InputObject (New-Object System.Windows.forms.Label))) { 1; }else{ 0; }");
            
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Read-UiaControlAutomationId -InputObject (New-Object System.Windows.forms.Label))) { 1; } else { 0; }",
                "ParameterBindingException",
                //@"Cannot bind parameter 'InputObject'. Cannot convert the ""System.Windows.Forms.Label, Text: "" value of type ""System.Windows.Forms.Label"" to type ""System.Windows.Automation.AutomationElement"".");
                @"Cannot bind parameter 'InputObject'. Cannot convert the ""System.Windows.Forms.Label, Text: "" value of type ""System.Windows.Forms.Label"" to type ""UIAutomation.IMySuperWrapper"".");
            
//            UIAutomationTest.Commands.Common.ReadUiaControlAutomationIdCommandTestFixture.TestParameterInputOtherType:
//System.Management.Automation.ParameterBindingException : Cannot bind parameter 'InputObject'. Cannot convert the "System.Windows.Forms.Label, Text: " value of type "System.Windows.Forms.Label" to type "System.Windows.Automation.AutomationElement".
//  ----> System.Management.Automation.PSInvalidCastException : Cannot convert the "System.Windows.Forms.Label, Text: " value of type "System.Windows.Forms.Label" to type "System.Windows.Automation.AutomationElement".
        }
        
        [Test] //[Test(Description="ProcessRecord test Is AutomationElement")]
        //[Category("Slow")][Category("NUnit")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
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

        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
    }
}
