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
    using System.Windows.Automation;

    /// <summary>
    /// Description of OutUiaControlNameCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="Read-UiaControlNameCommand test")]
    public class ReadUiaControlNameCommandTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="InputObject ProcessRecord test Null via pipeline")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("NoForms")]
        public void ReadUiaControlName_TestPipelineInput()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"if ( ($null | Read-UiaControlName) ) { 1; } else { 0; }",
                "0");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="ProcessRecord test Null via parameter")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("NoForms")]
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
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="ProcessRecord test Is Not AutomationElement")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("NoForms")]
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
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="ProcessRecord test Is AutomationElement")]
        //[MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("NUnit")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
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
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="ProcessRecord test Is Name")]
        //[MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("NUnit")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("Control")]
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
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
    }
}
