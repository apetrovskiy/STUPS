/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/7/2014
 * Time: 5:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Helpers.ObjectModel
{
    /// <summary>
    /// Description of ISupportsExpandCollapseTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class ISupportsExpandCollapseTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void TearDown()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
        /*
        $rootNode = Get-UiaWindow -n *win*full* | Get-UiaTree | Get-UiaTreeItem
        $rootNode | Get-UiaTreeItemCheckedState ### ?
        
        $rootNode.ExpandCollapseState
        $rootNode.Expand()
        $rootNode.Collapse()
        */
        
        // ComboBox
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        public void Invoke_ComboBox_Expand()
        {
            string expectedResult = "b2";
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsFull, 
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UiaComboBox -AutomationId comboBox1).Expand() " + 
                @" | Get-UiaListItem -Name b2 | Read-UiaControlName;",
                expectedResult);
        }
        
        // TreeItem
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        public void Invoke_TreeItem_Expand()
        {
            string expectedResult = "Invoked";
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsFull, 
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = (Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UiaTreeItem -Name Node0).Expand();" + 
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UiaList -AutomationId listBox1 | " + 
                @"Get-UiaListItem -Name " + 
                expectedResult +
                @" | Read-UiaControlName;",
                expectedResult);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ISupportsExpandCollapse")]
        public void TreeItem_ExpandCollapseState_Expanded()
        {
            string expectedResult = "Expanded";
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsFull, 
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = (Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UiaTreeItem -Name Node0).Expand(); " + 
                @"(Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UiaTreeItem -Name Node0).ExpandCollapseState; ",
                expectedResult);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ISupportsExpandCollapse")]
        public void TreeItem_ExpandCollapseState_Collapsed()
        {
            string expectedResult = "Collapsed";
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsFull, 
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = (Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UiaTreeItem -Name Node0).Collapse(); " + 
                @"(Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UiaTreeItem -Name Node0).ExpandCollapseState; ",
                expectedResult);
        }
    }
}
