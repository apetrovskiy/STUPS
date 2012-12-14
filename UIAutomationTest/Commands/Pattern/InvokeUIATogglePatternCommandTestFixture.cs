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
    /// Description of InvokeUIATogglePatternCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Invoke-UIATogglePatternCommand test")]
    public class InvokeUIATogglePatternCommandTestFixture
    {
        public InvokeUIATogglePatternCommandTestFixture()
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
                @"$null = Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIACheckBox -AutomationId checkBox1 | Invoke-UIACheckBoxtoggle;" + 
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAList -AutomationId listBox1 | " + 
                "Get-UIAListItem -Name " + 
                expectedResult +
                " | Read-UIAControlName;",
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
                @"$null = Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIACheckBox -AutomationId checkBox1 | Invoke-UIACheckBoxtoggle | Invoke-UIACheckBoxtoggle;" + 
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAList -AutomationId listBox1 | " + 
                "Get-UIAListItem -Name " + 
                expectedResult +
                " | Read-UIAControlName;",
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
                @"$null = Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UIAList -AutomationId checkedListBox1 " + 
                @" | Get-UIAListItem -Name a1 | Invoke-UIAListItemToggle;" +
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UIAList -AutomationId listBox1 | " + 
                @"Get-UIAListItem -Name " + 
                expectedResult +
                " | Read-UIAControlName;",
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
                @"$null = Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UIAList -AutomationId checkedListBox1 " + 
                @" | Get-UIAListItem -Name a1 | Invoke-UIAListItemToggle | Invoke-UIAListItemToggle;" +
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UIAList -AutomationId listBox1 | " + 
                @"Get-UIAListItem -Name " + 
                expectedResult +
                " | Read-UIAControlName;",
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
