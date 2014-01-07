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
    using System;
    using MbUnit.Framework;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ISupportsSelectionItemPatternTestFixture.
    /// </summary>
    [TestFixture]
    public class ISupportsSelectionItemPatternTestFixture
    {
        [SetUp]
        public void SetUp()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [TearDown]
        public void TearDown()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
        // TreeItem
        [Test]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        public void TreeItem_IsSelected_False()
        {
            string expectedResult = "False";
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsFull, 
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UiaTreeItem -Name Node0).IsSelected;",
                expectedResult);
        }
        
        [Test]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        public void TreeItem_IsSelected_True()
        {
            string expectedResult = "True";
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsFull, 
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = (Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UiaTreeItem -Name Node0).Select();" +
                @"(Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UiaTreeItem -Name Node0).IsSelected;",
                expectedResult);
        }
        
        [Test]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        public void TreeItem_AddToSelection()
        {
            string expectedResult = "True";
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsFull, 
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = (Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UiaTreeItem -Name Node0).AddToSelection();" +
                @"(Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UiaTreeItem -Name Node0).IsSelected;",
                expectedResult);
        }
        
        [Test]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        public void TreeItem_RemoveFromSelection()
        {
            string expectedResult = "False";
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsFull, 
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = (Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UiaTreeItem -Name Node0).Select();" +
                @"$null = (Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UiaTreeItem -Name Node0).RemoveFromSelection();" + 
                @"(Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UiaTreeItem -Name Node0).IsSelected;",
                expectedResult);
        }
        
//        
//        [Test]
//        public void SelectionItem_AddToSelection()
//        {
//            // Arrange
//            bool expectedResult = true;
//            bool result = false;
//            ISupportsSelectionItemPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetSelectionItemPattern(new PatternsData()) }) as ISupportsSelectionItemPattern;
//            
//            // Act
//            element.AddToSelection();
//            try {
//                (element as IUiElement).GetCurrentPattern<ISelectionItemPattern>(SelectionItemPattern.Pattern).Received(1).AddToSelection();
//                result = true;
//            }
//            catch {}
//            
//            // Assert
//            Assert.AreEqual(expectedResult, result);
//        }
//        
//        [Test]
//        public void SelectionItem_RemoveFromSelection()
//        {
//            // Arrange
//            bool expectedResult = true;
//            bool result = false;
//            ISupportsSelectionItemPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetSelectionItemPattern(new PatternsData()) }) as ISupportsSelectionItemPattern;
//            
//            // Act
//            element.RemoveFromSelection();
//            try {
//                (element as IUiElement).GetCurrentPattern<ISelectionItemPattern>(SelectionItemPattern.Pattern).Received(1).RemoveFromSelection();
//                result = true;
//            }
//            catch {}
//            
//            // Assert
//            Assert.AreEqual(expectedResult, result);
//        }
//        
//        [Test]
//        public void SelectionItem_Select()
//        {
//            // Arrange
//            bool expectedResult = true;
//            bool result = false;
//            ISupportsSelectionItemPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetSelectionItemPattern(new PatternsData()) }) as ISupportsSelectionItemPattern;
//            
//            // Act
//            element.Select();
//            try {
//                (element as IUiElement).GetCurrentPattern<ISelectionItemPattern>(SelectionItemPattern.Pattern).Received(1).Select();
//                result = true;
//            }
//            catch {}
//            
//            // Assert
//            Assert.AreEqual(expectedResult, result);
//        }
//        
//        [Test]
//        public void SelectionItem_IsSelected()
//        {
//            // Arrange
//            bool expectedValue = true;
//            ISupportsSelectionItemPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetSelectionItemPattern(new PatternsData() { SelectionItemPattern_IsSelected = expectedValue }) }) as ISupportsSelectionItemPattern;
//            
//            // Act
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.IsSelected);
//        }
//        
//        [Test]
//        public void SelectionItem_SelectionContainer()
//        {
//            // Arrange
//            IUiElement expectedValue = new UiElement();
//            ISupportsSelectionItemPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetSelectionItemPattern(new PatternsData() { SelectionItemPattern_SelectionContainer = expectedValue }) }) as ISupportsSelectionItemPattern;
//            
//            // Act
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.SelectionContainer);
//        }
    }
}
