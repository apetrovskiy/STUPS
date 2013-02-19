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
    /// Description of InvokeUIACollapsePatternCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Invoke-UIACollapsePatternCommand test")]
    public class InvokeUIACollapsePatternCommandTestFixture
    {
        public InvokeUIACollapsePatternCommandTestFixture()
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
        
        // ComboBox
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        public void Invoke_ComboBox_Collapse()
        {
            string expectedResult = "b02";
//            string expectedResult1 = "CmdletInvocationException";
//            //string expectedResult2 = "Get-UIAListItem: timeout expired for class: ' + , control type: ListItem, title: b2";
//            string expectedResult2 = "The target element corresponds to UI that is no longer available (for example, the parent";
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsFull, 
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAComboBox -AutomationId comboBox4 | Invoke-UIAComboBoxExpand " + 
                " | Get-UIAListItem -Name b02 | Read-UIAControlName;",
                expectedResult);
//            CmdletUnitTest.TestRunspace.RunAndGetTheException(
//                @"$null = Get-UIAWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                " | Get-UIAListItem -Name b2;",
//                expectedResult1,
//                expectedResult2);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UIAComboBox -AutomationId comboBox4 | Invoke-UIAComboBoxCollapse; " + 
                @"try {" +
                " Get-UIAListItem -Name b02 | Read-UIAControlIsOffscreen; } catch { \"1\"; };",
                "True");
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
        public void Invoke_TreeItem_Collapse()
        {
            string expectedResult = "Invoked";
            string expectedResult1 = "CmdletInvocationException";
            // 20130219
            //string expectedResult2 = "Get-UIATreeItem: timeout expired for class: ' + , control type: TreeItem, title: Node1";
            string expectedResult2 = @"Get-UIATreeItem: timeout expired for control with class: + '', control type: 'TreeItem', title: 'Node1', automationId: '', value: ''";
            //string expectedResult2 = "GetUIATreeItem: timeout expired for class: ' + , control type: TreeItem, title: Node1";
            //string expectedResult2 = "A generic error occurred in GDI+.";
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
                "Get-UIAListItem -Name Invoked | Read-UIAControlName;",
                expectedResult);
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"$null = Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIATreeItem -Name Node0 | Invoke-UIATreeItemCollapse;" +
                @"$null = Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIATreeItem -Name Node1;",
                expectedResult1,
                expectedResult2);
        }
        
//UIAutomationTest.Commands.Pattern.InvokeUIACollapsePatternCommandTestFixture.Invoke_TreeItem_Collapse:
//  Expected string length 86 but was 85. Strings differ at index 3.
//  Expected: "Get-UIATreeItem: timeout expired for class: ' + , control typ..."
//  But was:  "GetUIATreeItem: timeout expired for class: ' + , control type..."
//  --------------^

//UIAutomationTest.Commands.Pattern.InvokeUIACollapsePatternCommandTestFixture.Invoke_TreeItem_Collapse:
//  Expected string length 85 but was 33. Strings differ at index 0.
//  Expected: "GetUIATreeItem: timeout expired for class: ' + , control type..."
//  But was:  "A generic error occurred in GDI+."
//  -----------^

//UIAutomationTest.Commands.Pattern.InvokeUIACollapsePatternCommandTestFixture.Invoke_TreeItem_Collapse:
//  Expected string length 33 but was 85. Strings differ at index 0.
//  Expected: "A generic error occurred in GDI+."
//  But was:  "GetUIATreeItem: timeout expired for class: ' + , control type..."
//  -----------^

        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
