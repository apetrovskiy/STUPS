/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/8/2014
 * Time: 2:22 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Helpers.ObjectModelWithMocks
{
    using System;
    using System.Windows.Automation;
    using MbUnit.Framework;
    using System.Management.Automation;
    using UIAutomation;
    using UIAutomationUnitTests;
    
    /// <summary>
    /// Description of ISupportsExpandCollapseTestFixture.
    /// </summary>
    [TestFixture]
    public class ISupportsExpandCollapseTestFixture
    {
        [SetUp]
        public void SetUp()
        {
            // the current 3
            // CurrentData.ResetData();
            
            // FakeFactory.InitForPowerShell();
            // MiddleLevelCode.PrepareRunspace();
            
            // the current 4
            // the current 6
            // FakeFactory.InitForPowerShell();
            MiddleLevelCode.PrepareRunspace();
            
            // the current 2
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[void]([UIAutomation.CurrentData]::ResetData());");
            
            // the current 4
//            FakeFactory.InitForPowerShell();
//            MiddleLevelCode.PrepareRunspace();
            
            // the current 6
            FakeFactory.InitForPowerShell();
        }
        
        [TearDown]
        public void TearDown()
        {
            MiddleLevelCode.DisposeRunspace();
            
            // CurrentData.ResetData();
            // the current
            // FakeFactory.Reset();
            
            // the current 5 (exp)
            // CurrentData.ResetData();
            
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
//        [Test]
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
//        [Test]
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
//        [Test]
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
//        [Test]
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
        
        
        
        
        [Test]
        [Ignore]
        public void ExpandCollapseState_Expanded()
        {
            // Arrange
            ExpandCollapseState expectedValue = ExpandCollapseState.Expanded;
            ISupportsExpandCollapsePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData() { ExpandCollapsePattern_ExpandCollapseState = expectedValue }) }) as ISupportsExpandCollapsePattern;
            
//if (null == element) {
//    Console.WriteLine("null == element");
//} else {
//    Console.WriteLine("null != element");
//    try {
//        Console.WriteLine(element.ExpandCollapseState.ToString());
//    } catch (Exception e) {
//        Console.WriteLine(e.Message);
//        // throw;
//    }
//}
//var pattern = FakeFactory.GetExpandCollapsePattern(new PatternsData() { ExpandCollapsePattern_ExpandCollapseState = expectedValue });
//if (null == pattern) {
//    Console.WriteLine("null == pattern");
//} else {
//    Console.WriteLine("null != pattern");
//    try {
//        Console.WriteLine(pattern.Current.ExpandCollapseState.ToString());
//    } catch (Exception e2) {
//        Console.WriteLine(e2.Message);
//        // throw;
//    }
//}
            
            // Act
            // Assert
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$input | %{ $_.ExpandCollapseState; }",
                new [] { element },
                expectedValue.ToString());
        }
        
        [Test]
        [Ignore]
        public void ExpandCollapseState_Collapsed()
        {
            // Arrange
            ExpandCollapseState expectedValue = ExpandCollapseState.Collapsed;
            ISupportsExpandCollapsePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData() { ExpandCollapsePattern_ExpandCollapseState = expectedValue }) }) as ISupportsExpandCollapsePattern;
            
//if (null == element) {
//    Console.WriteLine("null == element");
//} else {
//    Console.WriteLine("null != element");
//    try {
//        Console.WriteLine(element.ExpandCollapseState.ToString());
//    } catch (Exception e) {
//        Console.WriteLine(e.Message);
//        // throw;
//    }
//}
//var pattern = FakeFactory.GetExpandCollapsePattern(new PatternsData() { ExpandCollapsePattern_ExpandCollapseState = expectedValue });
//if (null == pattern) {
//    Console.WriteLine("null == pattern");
//} else {
//    Console.WriteLine("null != pattern");
//    try {
//        Console.WriteLine(pattern.Current.ExpandCollapseState.ToString());
//    } catch (Exception e2) {
//        Console.WriteLine(e2.Message);
//        // throw;
//    }
//}
            
            // Act
            // Assert
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$input | %{ $_.ExpandCollapseState; }",
                new [] { element },
                expectedValue.ToString());
        }
        
        [Test]
        [Ignore]
        public void ExpandCollapseState_LeafNode()
        {
            // Arrange
            ExpandCollapseState expectedValue = ExpandCollapseState.LeafNode;
            ISupportsExpandCollapsePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData() { ExpandCollapsePattern_ExpandCollapseState = expectedValue }) }) as ISupportsExpandCollapsePattern;
            
//if (null == element) {
//    Console.WriteLine("null == element");
//} else {
//    Console.WriteLine("null != element");
//    try {
//        Console.WriteLine(element.ExpandCollapseState.ToString());
//    } catch (Exception e) {
//        Console.WriteLine(e.Message);
//        // throw;
//    }
//}
//var pattern = FakeFactory.GetExpandCollapsePattern(new PatternsData() { ExpandCollapsePattern_ExpandCollapseState = expectedValue });
//if (null == pattern) {
//    Console.WriteLine("null == pattern");
//} else {
//    Console.WriteLine("null != pattern");
//    try {
//        Console.WriteLine(pattern.Current.ExpandCollapseState.ToString());
//    } catch (Exception e2) {
//        Console.WriteLine(e2.Message);
//        // throw;
//    }
//}
            
            // Act
            // Assert
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$input | %{ $_.ExpandCollapseState; }",
                new [] { element },
                expectedValue.ToString());
        }
        
        [Test]
        [Ignore]
        public void ExpandCollapseState_PartiallyExpanded()
        {
            // Arrange
            ExpandCollapseState expectedValue = ExpandCollapseState.PartiallyExpanded;
            ISupportsExpandCollapsePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData() { ExpandCollapsePattern_ExpandCollapseState = expectedValue }) }) as ISupportsExpandCollapsePattern;
            
//if (null == element) {
//    Console.WriteLine("null == element");
//} else {
//    Console.WriteLine("null != element");
//    try {
//        Console.WriteLine(element.ExpandCollapseState.ToString());
//    } catch (Exception e) {
//        Console.WriteLine(e.Message);
//        // throw;
//    }
//}
//var pattern = FakeFactory.GetExpandCollapsePattern(new PatternsData() { ExpandCollapsePattern_ExpandCollapseState = expectedValue });
//if (null == pattern) {
//    Console.WriteLine("null == pattern");
//} else {
//    Console.WriteLine("null != pattern");
//    try {
//        Console.WriteLine(pattern.Current.ExpandCollapseState.ToString());
//    } catch (Exception e2) {
//        Console.WriteLine(e2.Message);
//        // throw;
//    }
//}
            
            // Act
            // Assert
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$input | %{ $_.ExpandCollapseState; }",
                new [] { element },
                expectedValue.ToString());
        }
        
//        [Test]
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
//            Assert.AreEqual(expectedValue, element.ExpandCollapseState);
//        }
//        
//        [Test]
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
//            Assert.AreEqual(expectedValue, element.ExpandCollapseState);
//        }
    }
}
