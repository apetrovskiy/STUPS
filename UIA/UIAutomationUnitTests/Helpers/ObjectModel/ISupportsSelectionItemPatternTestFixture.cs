/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/22/2013
 * Time: 2:51 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.ObjectModel
{
    using System.Windows.Automation;
    using UIAutomation;
    using MbUnit.Framework;
    using NSubstitute;
    
    /// <summary>
    /// Description of ISupportsSelectionItemPatternTestFixture.
    /// </summary>
    [TestFixture]
    public class ISupportsSelectionItemPatternTestFixture
    {
        [SetUp]
        public void SetUp()
        {
            FakeFactory.Init();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
        [Test]
        public void SelectionItem_ImplementsCommonPattern()
        {
            ISupportsInvokePattern invokableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetSelectionItemPattern(new PatternsData()) }) as ISupportsInvokePattern;
            
            Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
            
            ISupportsHighlighter highlightableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetSelectionItemPattern(new PatternsData()) }) as ISupportsHighlighter;
            
            Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
            
            ISupportsNavigation navigatableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetSelectionItemPattern(new PatternsData()) }) as ISupportsNavigation;
            
            Assert.IsNotNull(navigatableElement as ISupportsNavigation);
            
            ISupportsConversion conversibleElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsConversion;
            
            Assert.IsNotNull(conversibleElement as ISupportsConversion);
        }
        
        [Test]
        public void SelectionItem_ImplementsPatternInQuestion()
        {
            ISupportsSelectionItemPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetSelectionItemPattern(new PatternsData()) }) as ISupportsSelectionItemPattern;
            
            Assert.IsNotNull(element as ISupportsSelectionItemPattern);
        }
        
        [Test]
        public void SelectionItem_DoesNotImplementOtherPatterns()
        {
            ISupportsValuePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetSelectionItemPattern(new PatternsData()) }) as ISupportsValuePattern;
            
            Assert.IsNull(element as ISupportsValuePattern);
        }
        
        [Test]
        public void SelectionItem_AddToSelection()
        {
            // Arrange
            bool expectedResult = true;
            bool result = false;
            ISupportsSelectionItemPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetSelectionItemPattern(new PatternsData()) }) as ISupportsSelectionItemPattern;
            
            // Act
            element.AddToSelection();
            try {
                (element as IUiElement).GetCurrentPattern<ISelectionItemPattern>(SelectionItemPattern.Pattern).Received(1).AddToSelection();
                result = true;
            }
            catch {}
            
            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test]
        public void SelectionItem_RemoveFromSelection()
        {
            // Arrange
            bool expectedResult = true;
            bool result = false;
            ISupportsSelectionItemPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetSelectionItemPattern(new PatternsData()) }) as ISupportsSelectionItemPattern;
            
            // Act
            element.RemoveFromSelection();
            try {
                (element as IUiElement).GetCurrentPattern<ISelectionItemPattern>(SelectionItemPattern.Pattern).Received(1).RemoveFromSelection();
                result = true;
            }
            catch {}
            
            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test]
        public void SelectionItem_Select()
        {
            // Arrange
            bool expectedResult = true;
            bool result = false;
            ISupportsSelectionItemPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetSelectionItemPattern(new PatternsData()) }) as ISupportsSelectionItemPattern;
            
            // Act
            element.Select();
            try {
                (element as IUiElement).GetCurrentPattern<ISelectionItemPattern>(SelectionItemPattern.Pattern).Received(1).Select();
                result = true;
            }
            catch {}
            
            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test]
        public void SelectionItem_IsSelected()
        {
            // Arrange
            bool expectedValue = true;
            ISupportsSelectionItemPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetSelectionItemPattern(new PatternsData() { SelectionItemPattern_IsSelected = expectedValue }) }) as ISupportsSelectionItemPattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.IsSelected);
        }
        
        [Test]
        public void SelectionItem_SelectionContainer()
        {
            // Arrange
            IUiElement expectedValue = new UiElement();
            ISupportsSelectionItemPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetSelectionItemPattern(new PatternsData() { SelectionItemPattern_SelectionContainer = expectedValue }) }) as ISupportsSelectionItemPattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.SelectionContainer);
        }
    }
}
