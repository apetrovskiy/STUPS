/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08.12.2011
 * Time: 11:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Convert
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;

    /// <summary>
    /// Description of ConvertFromUiaDataGridCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="ConvertFrom-UiaDataGridCommand test")]
    public class ConvertFromUiaDataGridCommandTestFixture
    {
        [SetUp]
        public void PrepareRunspace()
        {
// CmdletUnitTest.TestRunspace.IitializeRunspace();
// string codeSnippet = 
// @"$ErrorPreference = [System.Management.Automation.ActionPreference]::SilentlyContinue;";
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="InputObject ProcessRecord test Null via pipeline")]
        [Category("Slow")]
        [Category("NoForms")]
        public void ConvertFromUiaDataGrid_TestPipelineInput()
        {
            string codeSnippet = 
                @"if ( ($null | ConvertFrom-UiaDataGrid) ) { 1; }else{ 0; }";
            System.Collections.ObjectModel.Collection<PSObject> coll = 
                CmdletUnitTest.TestRunspace.RunPSCode(codeSnippet);
            Assert.IsTrue(coll[0].ToString() == "0");
        }
        
        [Test] //[Test(Description="ProcessRecord test Null via parameter")]
        [Category("Slow")]
        [Category("NoForms")]
        public void ConvertFromUiaDataGrid_TestParameterInputNull()
        {
//            CmdletUnitTest.TestRunspace.RunAndEvaluateIsNull(
//                @"if ((ConvertFrom-UiaDataGrid -InputObject $null)) { 1; }else{ 0; }");
            
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((ConvertFrom-UiaDataGrid -InputObject $null)) { 1; }else{ 0; }",
                "ParameterBindingValidationException",
                @"Cannot validate argument on parameter 'InputObject'. The argument is null or empty. Supply an argument that is not null or empty and then try the command again.");
            
//            UIAutomationTest.Commands.Convert.ConvertFromUiaDataGridCommandTestFixture.TestParameterInputNull:
//System.Management.Automation.ParameterBindingValidationException : Cannot validate argument on parameter 'InputObject'. The argument is null or empty. Supply an argument that is not null or empty and then try the command again.
//  ----> System.Management.Automation.ValidationMetadataException : The argument is null or empty. Supply an argument that is not null or empty and then try the command again.
        }
        
        [Test] //[Test(Description="ProcessRecord test Is Not AutomationElement")]
        [Category("Slow")]
        [Category("NoForms")]
        public void ConvertFromUiaDataGrid_TestParameterInputOtherType()
        {
//            CmdletUnitTest.TestRunspace.RunAndEvaluateIsNull(
//                @"if ((ConvertFrom-UiaDataGrid -InputObject (New-Object System.Windows.forms.Label))) { 1; }else{ 0; }");
            
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((ConvertFrom-UiaDataGrid -InputObject (New-Object System.Windows.forms.Label))) { 1; }else{ 0; }",
                "ParameterBindingException",
                //@"Cannot bind parameter 'InputObject'. Cannot convert the ""System.Windows.Forms.Label, Text: "" value of type ""System.Windows.Forms.Label"" to type ""System.Windows.Automation.AutomationElement"".");
                @"Cannot bind parameter 'InputObject'. Cannot convert the ""System.Windows.Forms.Label, Text: "" value of type ""System.Windows.Forms.Label"" to type ""UIAutomation.IUiElement"".");
            
//            UIAutomationTest.Commands.Convert.ConvertFromUiaDataGridCommandTestFixture.TestParameterInputOtherType:
//System.Management.Automation.ParameterBindingException : Cannot bind parameter 'InputObject'. Cannot convert the "System.Windows.Forms.Label, Text: " value of type "System.Windows.Forms.Label" to type "System.Windows.Automation.AutomationElement".
//  ----> System.Management.Automation.PSInvalidCastException : Cannot convert the "System.Windows.Forms.Label, Text: " value of type "System.Windows.Forms.Label" to type "System.Windows.Automation.AutomationElement".
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
    }
    
    

}