/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 07/12/2011
 * Time: 11:45 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Common
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of OutUiaControlNameCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Read-UiaControlNameCommand test")]
    public class ReadUiaControlNameCommandTestFixture
    {
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="InputObject ProcessRecord test Null via pipeline")]
        [Category("Slow")]
        [Category("NoForms")]
        public void ReadUiaControlName_TestPipelineInput()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"if ( ($null | Read-UiaControlName) ) { 1; } else { 0; }",
                "0");
        }
        
        [Test] //[Test(Description="ProcessRecord test Null via parameter")]
        [Category("Slow")]
        [Category("NoForms")]
        public void ReadUiaControlName_TestParameterInputNull()
        {
//            CmdletUnitTest.TestRunspace.RunAndEvaluateIsNull(
//                @"if ((Read-UiaControlName -InputObject $null)) { 1; } else { 0; }");
            
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Read-UiaControlName -InputObject $null)) { 1; } else { 0; }",
                "ParameterBindingValidationException",
                @"Cannot validate argument on parameter 'InputObject'. The argument is null or empty. Supply an argument that is not null or empty and then try the command again.");
            
//            UIAutomationTest.Commands.Common.ReadUiaControlNameCommandTestFixture.TestParameterInputNull:
//System.Management.Automation.ParameterBindingValidationException : Cannot validate argument on parameter 'InputObject'. The argument is null or empty. Supply an argument that is not null or empty and then try the command again.
//  ----> System.Management.Automation.ValidationMetadataException : The argument is null or empty. Supply an argument that is not null or empty and then try the command again.
        }
        
        [Test] //[Test(Description="ProcessRecord test Is Not AutomationElement")]
        [Category("Slow")]
        [Category("NoForms")]
        public void ReadUiaControlName_TestParameterInputOtherType()
        {
//            CmdletUnitTest.TestRunspace.RunAndEvaluateIsNull(
//                @"if ((Read-UiaControlName -InputObject (New-Object System.Windows.forms.Label))) { 1; } else { 0; }");
            
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Read-UiaControlName -InputObject (New-Object System.Windows.forms.Label))) { 1; } else { 0; }",
                "ParameterBindingException",
                //@"Cannot bind parameter 'InputObject'. Cannot convert the ""System.Windows.Forms.Label, Text: "" value of type ""System.Windows.Forms.Label"" to type ""System.Windows.Automation.AutomationElement"".");
                @"Cannot bind parameter 'InputObject'. Cannot convert the ""System.Windows.Forms.Label, Text: "" value of type ""System.Windows.Forms.Label"" to type ""UIAutomation.IUiElement"".");
            
//            UIAutomationTest.Commands.Common.ReadUiaControlNameCommandTestFixture.TestParameterInputOtherType:
//System.Management.Automation.ParameterBindingException : Cannot bind parameter 'InputObject'. Cannot convert the "System.Windows.Forms.Label, Text: " value of type "System.Windows.Forms.Label" to type "System.Windows.Automation.AutomationElement".
//  ----> System.Management.Automation.PSInvalidCastException : Cannot convert the "System.Windows.Forms.Label, Text: " value of type "System.Windows.Forms.Label" to type "System.Windows.Automation.AutomationElement".
        }
        
        [Test] //[Test(Description="ProcessRecord test Is AutomationElement")]
        //[Category("Slow")][Category("NUnit")]
        [Category("Slow")]
        [Category("WinForms")]
        public void ReadUiaControlName_TestParameterInputFormWithTitle()
        {
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"Get-UiaWindow -Name '" + 
//                CmdletUnitTest.TestRunspace.NUnitTitle + 
//                "' | Read-UiaControlName",
//                CmdletUnitTest.TestRunspace.NUnitTitle);
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UiaWindow -n " + 
                           MiddleLevelCode.TestFormNameEmpty +
                           " | Read-UiaControlName)) { 1; } else { 0; }");
        }
        
        [Test] //[Test(Description="ProcessRecord test Is Name")]
        //[Category("Slow")][Category("NUnit")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Slow")]
        [Category("Control")]
        public void TestParameterInputControlWithAutomationId()
        {
            string name = "btnName";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                ControlType.Button,
                name,
                "autoid",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"if ((Get-UiaWindow -n " +
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UiaButton -name btnName | Read-UiaControlName)) { '" + 
                name + 
                "'; } else { ''; }",
                name);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
    }
}
