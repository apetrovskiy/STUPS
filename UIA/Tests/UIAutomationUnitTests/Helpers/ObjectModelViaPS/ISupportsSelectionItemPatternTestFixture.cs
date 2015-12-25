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
    /// Description of ISupportsSelectionItemPatternTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class ISupportsSelectionItemPatternTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            // MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void TearDown()
        {
            // MiddleLevelCode.DisposeRunspace();
        }
        
//        // ListItem
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [Category("Slow")]
//        [Category("WinForms")]
//        [Category("Control")]
//        public void ListItem_Select()
//        {
//            string expectedResult = "True";
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = (Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UiaListItem a001).Select(); " +
//                @"(Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UiaListItem a001).IsSelected;",
//                expectedResult);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [Category("Slow")]
//        [Category("WinForms")]
//        [Category("Control")]
//        public void ListItem_AddToSelection()
//        {
//            string expectedResult = "True";
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = (Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UiaListItem b002).Select(); " +
//                @"$null = (Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UiaListItem a001).AddToSelection();" +
//                @"(Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UiaListItem a001).IsSelected;",
//                expectedResult);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [Category("Slow")]
//        [Category("WinForms")]
//        [Category("Control")]
//        public void ListItem_RemoveFromSelection()
//        {
//            string expectedResult = "False";
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = (Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UiaListItem a001).Select(); " +
//                @"$null = (Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UiaListItem b002).AddToSelection();" +
//                @"$null = (Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UiaListItem a001).RemoveFromSelection(); " + 
//                @"(Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UiaListItem a001).IsSelected;",
//                expectedResult);
//        }
//        
//        // TreeItem
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [Category("Slow")]
//        [Category("WinForms")]
//        [Category("Control")]
//        public void TreeItem_IsSelected_False()
//        {
//            string expectedResult = "False";
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"(Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UiaTreeItem -Name Node0).IsSelected;",
//                expectedResult);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [Category("Slow")]
//        [Category("WinForms")]
//        [Category("Control")]
//        public void TreeItem_IsSelected_True()
//        {
//            string expectedResult = "True";
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = (Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UiaTreeItem -Name Node0).Select(); " +
//                @"(Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UiaTreeItem -Name Node0).IsSelected;",
//                expectedResult);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [Category("Slow")]
//        [Category("WinForms")]
//        [Category("Control")]
//        public void TreeItem_AddToSelection()
//        {
//            string expectedResult = "True";
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = (Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UiaTreeItem -Name Node0).AddToSelection(); " +
//                @"(Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UiaTreeItem -Name Node0).IsSelected;",
//                expectedResult);
//        }
        
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
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
//            MbUnit.Framework.Assert.AreEqual(expectedResult, result);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
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
//            MbUnit.Framework.Assert.AreEqual(expectedResult, result);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
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
//            MbUnit.Framework.Assert.AreEqual(expectedResult, result);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
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
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.IsSelected);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
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
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.SelectionContainer);
//        }
    }
}
