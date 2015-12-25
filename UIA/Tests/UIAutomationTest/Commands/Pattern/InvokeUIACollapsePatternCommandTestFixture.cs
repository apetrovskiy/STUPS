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
    /// <summary>
    /// Description of InvokeUiaCollapsePatternCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="Invoke-UiaCollapsePatternCommand test")]
    public class InvokeUiaCollapsePatternCommandTestFixture
    {
        public InvokeUiaCollapsePatternCommandTestFixture()
        {
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[void]([UIAutomation.Preferences]::Timeout = 10000);");
        }
        
        // Button
        
        // ComboBox
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Control")]
        public void Invoke_ComboBox_Collapse()
        {
            string expectedResult = "b02";
//            string expectedResult1 = "CmdletInvocationException";
//            //string expectedResult2 = "Get-UiaListItem: timeout expired for class: ' + , control type: ListItem, title: b2";
//            string expectedResult2 = "The target element corresponds to UI that is no longer available (for example, the parent";
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsFull, 
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaComboBox -AutomationId comboBox4 | Invoke-UiaComboBoxExpand " + 
                " | Get-UiaListItem -Name b02 | Read-UiaControlName;",
                expectedResult);
//            CmdletUnitTest.TestRunspace.RunAndGetTheException(
//                @"$null = Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                " | Get-UiaListItem -Name b2;",
//                expectedResult1,
//                expectedResult2);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UiaComboBox -AutomationId comboBox4 | Invoke-UiaComboBoxCollapse; " + 
                @"try {" +
                " Get-UiaListItem -Name b02 | Read-UiaControlIsOffscreen; } catch { \"1\"; };",
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
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        public void Invoke_TreeItem_Collapse()
        {
            string expectedResult = "Invoked";
            string expectedResult1 = "CmdletInvocationException";
            // 20130219
            //string expectedResult2 = "Get-UiaTreeItem: timeout expired for class: ' + , control type: TreeItem, title: Node1";
            // 20131129
            // string expectedResult2 = @"Get-UiaTreeItem: timeout expired for control with class: + '', control type: 'TreeItem', title: 'Node1', automationId: '', value: ''";
            // 20140110
            // string expectedResult2 = @"Get-UiaTreeItem: timeout expired for control with class: + '', control type: 'System.String[]', title: 'Node1', automationId: '', value: ''";
            // 20140111
            // string expectedResult2 = @"Get-UiaTreeItem: failed to get control in 10000 milliseconds by: title: 'Node1', automationId: '', className: '', value: ''.";
            string expectedResult2 = @"failed to get control in 10000 milliseconds by: title: 'Node1', automationId: '', className: '', value: ''.";
            //string expectedResult2 = "GetUiaTreeItem: timeout expired for class: ' + , control type: TreeItem, title: Node1";
            //string expectedResult2 = "A generic error occurred in GDI+.";
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
                "Get-UiaListItem -Name Invoked | Read-UiaControlName;",
                expectedResult);
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"$null = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaTreeItem -Name Node0 | Invoke-UiaTreeItemCollapse;" +
                @"$null = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaTreeItem -Name Node1;",
                expectedResult1,
                expectedResult2);
        }
        
//UIAutomationTest.Commands.Pattern.InvokeUiaCollapsePatternCommandTestFixture.Invoke_TreeItem_Collapse:
//  Expected string length 86 but was 85. Strings differ at index 3.
//  Expected: "Get-UiaTreeItem: timeout expired for class: ' + , control typ..."
//  But was:  "GetUiaTreeItem: timeout expired for class: ' + , control type..."
//  --------------^

//UIAutomationTest.Commands.Pattern.InvokeUiaCollapsePatternCommandTestFixture.Invoke_TreeItem_Collapse:
//  Expected string length 85 but was 33. Strings differ at index 0.
//  Expected: "GetUiaTreeItem: timeout expired for class: ' + , control type..."
//  But was:  "A generic error occurred in GDI+."
//  -----------^

//UIAutomationTest.Commands.Pattern.InvokeUiaCollapsePatternCommandTestFixture.Invoke_TreeItem_Collapse:
//  Expected string length 33 but was 85. Strings differ at index 0.
//  Expected: "A generic error occurred in GDI+."
//  But was:  "GetUiaTreeItem: timeout expired for class: ' + , control type..."
//  -----------^

        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
