/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08.12.2011
 * Time: 11:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Pattern
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;

    /// <summary>
    /// Description of InvokeUiaTogglePatternCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Invoke-UiaTogglePatternCommand test")]
    public class InvokeUiaTogglePatternCommandTestFixture
    {
        public InvokeUiaTogglePatternCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[void]([UIAutomation.Preferences]::Timeout = 10000);");
        }
        
        
    // Button
    
    // CheckBox
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        public void Invoke_CheckBox_Toggle1()
        {
            string expectedResult = "Checked";
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsFull, 
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaCheckBox -AutomationId checkBox1 | Invoke-UiaCheckBoxtoggle;" + 
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaList -AutomationId listBox1 | " + 
                "Get-UiaListItem -Name " + 
                expectedResult +
                " | Read-UiaControlName;",
                expectedResult);
        }
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        public void Invoke_CheckBox_Toggle2()
        {
            string expectedResult = "Unchecked";
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsFull, 
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaCheckBox -AutomationId checkBox1 | Invoke-UiaCheckBoxtoggle | Invoke-UiaCheckBoxtoggle;" + 
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaList -AutomationId listBox1 | " + 
                "Get-UiaListItem -Name " + 
                expectedResult +
                " | Read-UiaControlName;",
                expectedResult);
        }
    
    // Custom
    // DataItem
    
    
    // ListItem
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        public void Invoke_ListItem_Toggle1()
        {
            string expectedResult = "SelectedIndexChanged";
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsFull, 
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UiaList -AutomationId checkedListBox1 " + 
                @" | Get-UiaListItem -Name a1 | Invoke-UiaListItemToggle;" +
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UiaList -AutomationId listBox1 | " + 
                @"Get-UiaListItem -Name " + 
                expectedResult +
                " | Read-UiaControlName;",
                expectedResult);
        }
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        public void Invoke_ListItem_Toggle2()
        {
            string expectedResult = "SelectedIndexChanged";
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsFull, 
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UiaList -AutomationId checkedListBox1 " + 
                @" | Get-UiaListItem -Name a1 | Invoke-UiaListItemToggle | Invoke-UiaListItemToggle;" +
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UiaList -AutomationId listBox1 | " + 
                @"Get-UiaListItem -Name " + 
                expectedResult +
                " | Read-UiaControlName;",
                expectedResult);
        }
    
    // MenuItem
    // RadioButton
        
        
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
