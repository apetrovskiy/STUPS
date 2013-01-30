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
    /// Description of ReadUIAControlClassCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Read-UIAControlClassCommand test")]
    public class ReadUIAControlClassCommandTestFixture
    {
        public ReadUIAControlClassCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="InputObject ProcessRecord test Null via pipeline")]
        [Category("Slow")]
        [Category("NoForms")]
        public void TestPipelineInput()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsTrue(
                @"if ( ($null | Read-UIAControlClass) ) { 1; } else { 0; }",
                "0");
        }
        
        [Test] //[Test(Description="ProcessRecord test Null via parameter")]
        [Category("Slow")]
        [Category("NoForms")]
        public void TestParameterInputNull()
        {
//            CmdletUnitTest.TestRunspace.RunAndEvaluateIsNull(
//                @"if ((Read-UIAControlClass -InputObject $null)) { 1; }else{ 0; }");
            
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Read-UIAControlClass -InputObject $null)) { 1; } else { 0; }",
                "ParameterBindingValidationException",
                @"Cannot validate argument on parameter 'InputObject'. The argument is null or empty. Supply an argument that is not null or empty and then try the command again.");
            
//            UIAutomationTest.Commands.Common.ReadUIAControlClassCommandTestFixture.TestParameterInputNull:
//System.Management.Automation.ParameterBindingValidationException : Cannot validate argument on parameter 'InputObject'. The argument is null or empty. Supply an argument that is not null or empty and then try the command again.
//  ----> System.Management.Automation.ValidationMetadataException : The argument is null or empty. Supply an argument that is not null or empty and then try the command again.
        }
        
        [Test] //[Test(Description="ProcessRecord test Is Not AutomationElement")]
        [Category("Slow")]
        [Category("NoForms")]
        public void TestParameterInputOtherType()
        {
//            CmdletUnitTest.TestRunspace.RunAndEvaluateIsNull(
//                @"if ((Read-UIAControlClass -InputObject (New-Object System.Windows.forms.Label))) { 1; }else{ 0; }");
            
                CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Read-UIAControlClass -InputObject (New-Object System.Windows.forms.Label))) { 1; } else { 0; }",
                "ParameterBindingException",
                @"Cannot bind parameter 'InputObject'. Cannot convert the ""System.Windows.Forms.Label, Text: "" value of type ""System.Windows.Forms.Label"" to type ""System.Windows.Automation.AutomationElement"".");
            
//            UIAutomationTest.Commands.Common.ReadUIAControlClassCommandTestFixture.TestParameterInputOtherType:
//System.Management.Automation.ParameterBindingException : Cannot bind parameter 'InputObject'. Cannot convert the "System.Windows.Forms.Label, Text: " value of type "System.Windows.Forms.Label" to type "System.Windows.Automation.AutomationElement".
//  ----> System.Management.Automation.PSInvalidCastException : Cannot convert the "System.Windows.Forms.Label, Text: " value of type "System.Windows.Forms.Label" to type "System.Windows.Automation.AutomationElement".
        }
        
// [Test] //[Test(Description="ProcessRecord test Is AutomationElement")]
// [Category("Slow")][Category("NUnit")]
// [Ignore("Unstable being run on various operationg systems")]
// public void TestParameterInputFormWithClass()
// {
// string codeSnippet = 
// @"Get-UIAWindow -Name '" + 
// CmdletUnitTest.TestRunspace.NUnitTitle + 
// "' | Read-UIAControlClass";
// System.Collections.ObjectModel.Collection<PSObject >  coll =
// CmdletUnitTest.TestRunspace.RunPSCode(codeSnippet);
// Assert.AreEqual(CmdletUnitTest.TestRunspace.NUnitClass, coll[0].ToString());
// }

        [Test] //[Test(Description="ProcessRecord test Is Class")]
        //[Category("Slow")][Category("NUnit")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        public void TestParameterInputControlWithAutomationId()
        {
            string className = "Button";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                ControlType.Button,
                "btnName",
                "auid",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"if ((Get-UIAWindow -n " +
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UIAButton -name btnName | Read-UIAControlClass)) { '" + 
                className + 
                "'; } else { ''; }",
                className);
        }

        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
    }
}
