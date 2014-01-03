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
    /// Description of InvokeUiaExpandPatternCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Invoke-UiaExpandPatternCommand test")]
    public class InvokeUiaExpandPatternCommandTestFixture
    {
        public InvokeUiaExpandPatternCommandTestFixture()
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
//                @"$null = Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                " | Get-UiaButton -Name button1 | Invoke-UiaButtonClick;" + 
//                @"(Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                " | Get-UiaList -AutomationId listBox1 | " + 
//                "Get-UiaListItem -Name " + 
//                expectedResult +
//                ").Current.Name;",
//                expectedResult);
//        }
        
        // ComboBox
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        public void Invoke_ComboBox_Expand()
        {
            string expectedResult = "b2";
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsFull, 
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaComboBox -AutomationId comboBox1 | Invoke-UiaComboBoxExpand " + 
                " | Get-UiaListItem -Name b2 | Read-UiaControlName;",
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
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        public void Invoke_TreeItem_Expand()
        {
            string expectedResult = "Invoked";
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsFull, 
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaTreeItem -Name Node0 | Invoke-UiaTreeItemExpand;" + 
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaList -AutomationId listBox1 | " + 
                "Get-UiaListItem -Name " + 
                expectedResult +
                " | Read-UiaControlName;",
                expectedResult);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
