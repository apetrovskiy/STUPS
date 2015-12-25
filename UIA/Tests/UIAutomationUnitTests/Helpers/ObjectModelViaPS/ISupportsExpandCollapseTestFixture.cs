/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/8/2014
 * Time: 2:22 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.ObjectModelViaPS
{
    // using Xunit;

    // using UIAutomationTest;
    
    /// <summary>
    /// Description of ISupportsExpandCollapseTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class ISupportsExpandCollapseTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            // MiddleLevelCode.PrepareRunspace();
//            CmdletUnitTest.TestRunspace.RunPSCode(
//                @"[void]([UIAutomation.CurrentData]::ResetData());");
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void TearDown()
        {
            // MiddleLevelCode.DisposeRunspace();
        }
        
        /*
        $rootNode = Get-UiaWindow -n *win*full* | Get-UiaTree | Get-UiaTreeItem
        $rootNode | Get-UiaTreeItemCheckedState ### ?
        
        $rootNode.ExpandCollapseState
        $rootNode.Expand()
        $rootNode.Collapse()
        */
        
        // ComboBox
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [Category("Slow")]
//        [Category("WinForms")]
//        [Category("Control")]
//        public void Invoke_ComboBox_Expand()
//        {
//            string expectedResult = "b2";
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsFull, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"(Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UiaComboBox -AutomationId comboBox1).Expand() " + 
//                @" | Get-UiaListItem -Name b2 | Read-UiaControlName;",
//                expectedResult);
//        }
        
        // TreeItem
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [Category("Slow")]
//        [Category("WinForms")]
//        [Category("Control")]
//        public void Invoke_TreeItem_Expand()
//        {
//            string expectedResult = "Invoked";
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsFull, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = (Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UiaTreeItem -Name Node0).Expand();" + 
//                @"Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UiaList -AutomationId listBox1 | " + 
//                @"Get-UiaListItem -Name " + 
//                expectedResult +
//                @" | Read-UiaControlName;",
//                expectedResult);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [Category("Slow")]
//        [Category("ISupportsExpandCollapse")]
//        public void TreeItem_ExpandCollapseState_Expanded()
//        {
//            string expectedResult = "Expanded";
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsFull, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = (Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UiaTreeItem -Name Node0).Expand(); " + 
//                @"(Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UiaTreeItem -Name Node0).ExpandCollapseState; ",
//                expectedResult);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [Category("Slow")]
//        [Category("ISupportsExpandCollapse")]
//        public void TreeItem_ExpandCollapseState_Collapsed()
//        {
//            string expectedResult = "Collapsed";
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsFull, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = (Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UiaTreeItem -Name Node0).Collapse(); " + 
//                @"(Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UiaTreeItem -Name Node0).ExpandCollapseState; ",
//                expectedResult);
//        }
        
        
        
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void ExpandCollapseState_Expanded()
//        {
//            // Arrange
//            ExpandCollapseState expectedValue = ExpandCollapseState.Expanded;
//            ISupportsExpandCollapsePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData() { ExpandCollapsePattern_ExpandCollapseState = expectedValue }) }) as ISupportsExpandCollapsePattern;
//            
//            // Act
//            // Assert
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                // @"$input.ExpandCollapseState;",
//                @"param($inputData) " +
//                @"$inputData.ExpandCollapseState;",
//                new IUiElement[] { element as IUiElement },
//                expectedValue.ToString());
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void ExpandCollapseState_Collapsed()
//        {
//            // Arrange
//            ExpandCollapseState expectedValue = ExpandCollapseState.Collapsed;
//            ISupportsExpandCollapsePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData() { ExpandCollapsePattern_ExpandCollapseState = expectedValue }) }) as ISupportsExpandCollapsePattern;
//            
//            // Act
//            // Assert
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                // @"$input.ExpandCollapseState;",
//                @"param($inputData) " +
//                @"$inputData.ExpandCollapseState;",
//                new IUiElement[] { (element as IUiElement) },
//                expectedValue.ToString());
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void ExpandCollapseState_LeafNode()
//        {
//            // Arrange
//            ExpandCollapseState expectedValue = ExpandCollapseState.LeafNode;
//            ISupportsExpandCollapsePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData() { ExpandCollapsePattern_ExpandCollapseState = expectedValue }) }) as ISupportsExpandCollapsePattern;
//            
//            // Act
//            // Assert
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                // @"$input.ExpandCollapseState;",
//                @"param($inputData) " +
//                @"$inputData.ExpandCollapseState;",
//                new IUiElement[] { element as IUiElement },
//                expectedValue.ToString());
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void ExpandCollapseState_PartiallyExpanded()
//        {
//            // Arrange
//            ExpandCollapseState expectedValue = ExpandCollapseState.PartiallyExpanded;
//            ISupportsExpandCollapsePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData() { ExpandCollapsePattern_ExpandCollapseState = expectedValue }) }) as ISupportsExpandCollapsePattern;
//            
//            // Act
//            // Assert
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                // @"$input.ExpandCollapseState;",
//                @"param($inputData) " +
//                @"$inputData.ExpandCollapseState;",
//                new IUiElement[] { element as IUiElement },
//                expectedValue.ToString());
//        }
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void ExpandCollapse_Collapse()
//        {
//            // Arrange
//            ExpandCollapseState expectedValue = ExpandCollapseState.Collapsed;
//            ISupportsExpandCollapsePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData()) }) as ISupportsExpandCollapsePattern;
//            
//            // Act
//            element.Collapse();
//            try {
//                (element as IUiElement).GetCurrentPattern<IExpandCollapsePattern>(ExpandCollapsePattern.Pattern).Received().Collapse();
//                element.ExpandCollapseState.Returns(expectedValue);
//            }
//            catch {}
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.ExpandCollapseState);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void ExpandCollapse_Expand()
//        {
//            // Arrange
//            ExpandCollapseState expectedValue = ExpandCollapseState.Expanded;
//            ISupportsExpandCollapsePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData()) }) as ISupportsExpandCollapsePattern;
//            
//            // Act
//            element.Expand();
//            try {
//                (element as IUiElement).GetCurrentPattern<IExpandCollapsePattern>(ExpandCollapsePattern.Pattern).Received().Expand();
//                element.ExpandCollapseState.Returns(expectedValue);
//            }
//            catch {}
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.ExpandCollapseState);
//        }
    }
}
