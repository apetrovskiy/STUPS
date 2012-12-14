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
    /// Description of InvokeUIAExpandPatternCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Invoke-UIAExpandPatternCommand test")]
    public class InvokeUIAExpandPatternCommandTestFixture
    {
        public InvokeUIAExpandPatternCommandTestFixture()
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
        // Unsupported pattern
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Control")]
//        public void Invoke_Button_Expand()
//        {
//            string expectedResult = "Invoked";
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsFull, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = Get-UIAWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                " | Get-UIAButton -Name button1 | Invoke-UIAButtonClick;" + 
//                @"(Get-UIAWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                " | Get-UIAList -AutomationId listBox1 | " + 
//                "Get-UIAListItem -Name " + 
//                expectedResult +
//                ").Current.Name;",
//                expectedResult);
//        }
        
        // ComboBox
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        public void Invoke_ComboBox_Expand()
        {
            string expectedResult = "b2";
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsFull, 
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAComboBox -AutomationId comboBox1 | Invoke-UIAComboBoxExpand " + 
                " | Get-UIAListItem -Name b2 | Read-UIAControlName;",
                expectedResult);
        }
        
        // Custom
        // DataItem
        // Group
        // ListItem
        // MenuBar
        // MenuItem
        // SplitButton
        // ToolBar
        
        // TreeItem
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        public void Invoke_TreeItem_Expand()
        {
            string expectedResult = "Invoked";
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsFull, 
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIATreeItem -Name Node0 | Invoke-UIATreeItemExpand;" + 
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAList -AutomationId listBox1 | " + 
                "Get-UIAListItem -Name " + 
                expectedResult +
                " | Read-UIAControlName;",
                expectedResult);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
