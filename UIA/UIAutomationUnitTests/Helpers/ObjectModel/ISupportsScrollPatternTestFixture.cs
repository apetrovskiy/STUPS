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
    
    /// <summary>
    /// Description of ISupportsScrollPatternTestFixture.
    /// </summary>
    // [Ignore]
    [TestFixture]
    public class ISupportsScrollPatternTestFixture
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
        public void Scroll_ImplementsCommonPattern()
        {
            ISupportsInvokePattern invokableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData()) }) as ISupportsInvokePattern;
            
            Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
            
            
            ISupportsHighlighter highlightableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData()) }) as ISupportsHighlighter;
            
            Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
            
            ISupportsNavigation navigatableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData()) }) as ISupportsNavigation;
            
            Assert.IsNotNull(navigatableElement as ISupportsNavigation);
        }
        
        [Test]
        public void Scroll_ImplementsPattern()
        {
            ISupportsScrollPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData()) }) as ISupportsScrollPattern;
            
            Assert.IsNotNull(element as ISupportsScrollPattern);
        }
        
        [Test]
        public void Scroll_DoesNotImplementOtherPatterns()
        {
            ISupportsValuePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData()) }) as ISupportsValuePattern;
            
            Assert.IsNull(element as ISupportsValuePattern);
        }
        
        [Test]
        public void Scroll_Scroll()
        {
            // Arrange
            ISupportsScrollPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData()) }) as ISupportsScrollPattern;
            
            // Act
            // Assert
            element.Scroll(ScrollAmount.LargeIncrement, ScrollAmount.LargeIncrement);
        }
        
        [Test]
        public void Scroll_ScrollHorizontal()
        {
            // Arrange
            ISupportsScrollPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData()) }) as ISupportsScrollPattern;
            
            // Act
            // Assert
            element.ScrollHorizontal(ScrollAmount.LargeIncrement);
        }
        
        [Test]
        public void Scroll_ScrollVertical()
        {
            // Arrange
            ISupportsScrollPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData()) }) as ISupportsScrollPattern;
            
            // Act
            // Assert
            element.ScrollVertical(ScrollAmount.LargeIncrement);
        }
        
        [Test]
        public void Scroll_SetScrollPercent()
        {
            // Arrange
            ISupportsScrollPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData()) }) as ISupportsScrollPattern;
            
            // Act
            // Assert
            element.SetScrollPercent(1, 1);
        }
        
                
        [Test]
        public void Scroll_HorizontallyScrollable()
        {
            // Arrange
            bool expectedValue = true;
            ISupportsScrollPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData() { ScrollPattern_HorizontallyScrollable = expectedValue }) }) as ISupportsScrollPattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.HorizontallyScrollable);
        }
        
        [Test]
        public void Scroll_HorizontalScrollPercent()
        {
            // Arrange
            double expectedValue = 12.1;
            ISupportsScrollPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData() { ScrollPattern_HorizontalScrollPercent = expectedValue }) }) as ISupportsScrollPattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.HorizontalScrollPercent);
        }
        
        [Test]
        public void Scroll_HorizontalViewSize()
        {
            // Arrange
            double expectedValue = 14.2;
            ISupportsScrollPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData() { ScrollPattern_HorizontalViewSize = expectedValue }) }) as ISupportsScrollPattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.HorizontalViewSize);
        }
        
        [Test]
        public void Scroll_VerticallyScrollable()
        {
            // Arrange
            bool expectedValue = false;
            ISupportsScrollPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData() { ScrollPattern_VerticallyScrollable = expectedValue }) }) as ISupportsScrollPattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.VerticallyScrollable);
        }
        
        
        
        [Test]
        public void Scroll_VerticalScrollPercent()
        {
            // Arrange
            double expectedValue = 16.3;
            ISupportsScrollPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData() { ScrollPattern_VerticalScrollPercent = expectedValue }) }) as ISupportsScrollPattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.VerticalScrollPercent);
        }
        
        [Test]
        public void Scroll_VerticalViewSize()
        {
            // Arrange
            double expectedValue = 18.4;
            ISupportsScrollPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData() { ScrollPattern_VerticalViewSize = expectedValue }) }) as ISupportsScrollPattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.VerticalViewSize);
        }
    }
}
