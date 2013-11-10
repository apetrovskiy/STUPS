/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 07/12/2011
 * Time: 07:48 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Common
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;

    /// <summary>
    /// Description of MoveUIACursorCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Move-UIACursorCommand test")]
    public class MoveUIACursorCommandTestFixture
    {
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="InputObject ProcessRecord test Null via pipeline")]
        [Category("Slow")]
        [Category("NoForms")]
        public void MoveUIACursor_TestPipelineInput()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsTrue(
                @"if ( ($null | Move-UIACursor -X 1 -Y 1) ) { 1; } else { 0; }",
                "0");
        }
        
        [Test] //[Test(Description="ProcessRecord test Null via parameter")]
        [Category("Slow")]
        [Category("NoForms")]
        public void MoveUIACursor_TestParameterInputNull()
        {
//            CmdletUnitTest.TestRunspace.RunAndEvaluateIsNull(
//                @"if ((Move-UIACursor -InputObject $null -X 1 -Y 1)) { 1; } else { 0; }");
            
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Move-UIACursor -InputObject $null -X 1 -Y 1)) { 1; } else { 0; }",
                "ParameterBindingValidationException",
                "Cannot validate argument on parameter 'InputObject'. The argument is null or empty. Supply an argument that is not null or empty and then try the command again.");
            
            
//            UIAutomationTest.Commands.Common.MoveUIACursorCommandTestFixture.TestParameterInputNull:
//  Expected string length 27 but was 35. Strings differ at index 0.
//  Expected: "ValidationMetadataException"
//  But was:  "ParameterBindingValidationException"
//  -----------^

            
//            UIAutomationTest.Commands.Common.MoveUIACursorCommandTestFixture.TestParameterInputNull:
//System.Management.Automation.ParameterBindingValidationException : Cannot validate argument on parameter 'InputObject'. The argument is null or empty. Supply an argument that is not null or empty and then try the command again.
//  ----> System.Management.Automation.ValidationMetadataException : The argument is null or empty. Supply an argument that is not null or empty and then try the command again.
        }
        
        [Test] //[Test(Description="ProcessRecord test Is Not AutomationElement")]
        [Category("Slow")]
        [Category("NoForms")]
        public void MoveUIACursor_TestParameterInputOtherType()
        {
//            CmdletUnitTest.TestRunspace.RunAndEvaluateIsNull(
//                @"if ((Move-UIACursor -InputObject (New-Object System.Windows.forms.Label) -X 1 -Y 1)) { 1; }else{ 0; }");
            
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Move-UIACursor -InputObject (New-Object System.Windows.forms.Label) -X 1 -Y 1)) { 1; } else { 0; }",
                @"ParameterBindingException",
                //@"Cannot bind parameter 'InputObject'. Cannot convert the ""System.Windows.Forms.Label, Text: "" value of type ""System.Windows.Forms.Label"" to type ""System.Windows.Automation.AutomationElement"".");
                @"Cannot bind parameter 'InputObject'. Cannot convert the ""System.Windows.Forms.Label, Text: "" value of type ""System.Windows.Forms.Label"" to type ""UIAutomation.IMySuperWrapper"".");
            
//            UIAutomationTest.Commands.Common.MoveUIACursorCommandTestFixture.TestParameterInputOtherType:
//System.Management.Automation.ParameterBindingException : Cannot bind parameter 'InputObject'. Cannot convert the "System.Windows.Forms.Label, Text: " value of type "System.Windows.Forms.Label" to type "System.Windows.Automation.AutomationElement".
//  ----> System.Management.Automation.PSInvalidCastException : Cannot convert the "System.Windows.Forms.Label, Text: " value of type "System.Windows.Forms.Label" to type "System.Windows.Automation.AutomationElement".
        }
        
        [Test] //[Test(Description="ProcessRecord test Is AutomationElement")]
        [Category("Slow")]
        [Category("WinForms")]
        public void MoveUIACursor_TestParameterInputAutomationElement()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
                           MiddleLevelCode.TestFormProcess +
                           " | Move-UIACursor -X 1 -Y 1)) { 1; } else { 0; }");
        }
        
        //[System.Windows.Forms.Cursor]::Position.X
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
    }
    
    

}
