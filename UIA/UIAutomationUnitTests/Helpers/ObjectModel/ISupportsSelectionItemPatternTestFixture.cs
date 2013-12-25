/*
 * Created by SharpDevelop.
 * User: Alexander
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
    
    /// <summary>
    /// Description of ISupportsSelectionItemPatternTestFixture.
    /// </summary>
    // [Ignore]
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
            ISupportsInvokePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetSelectionItemPattern(new PatternsData()) }) as ISupportsInvokePattern;
            
            Assert.IsNotNull(element as ISupportsInvokePattern);
        }
        
        [Test]
        public void SelectionItem_ImplementsPattern()
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
            ISupportsSelectionItemPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetSelectionItemPattern(new PatternsData()) }) as ISupportsSelectionItemPattern;
            
            // Act
            // Assert
            element.AddToSelection();
        }
        
        [Test]
        public void SelectionItem_RemoveFromSelection()
        {
            // Arrange
            ISupportsSelectionItemPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetSelectionItemPattern(new PatternsData()) }) as ISupportsSelectionItemPattern;
            
            // Act
            // Assert
            element.RemoveFromSelection();
        }
        
        [Test]
        public void SelectionItem_Select()
        {
            // Arrange
            ISupportsSelectionItemPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetSelectionItemPattern(new PatternsData()) }) as ISupportsSelectionItemPattern;
            
            // Act
            // Assert
            element.Select();
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
