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
    using System;
    using System.Windows.Automation;
    using MbUnit.Framework;// using Xunit;
    using System.Management.Automation;
    using NSubstitute;
    using UIAutomation;
    // using UIAutomationTest;
    
    /// <summary>
    /// Description of ISupportsScrollPatternTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture]
    public class ISupportsScrollPatternTestFixture
    {
        [SetUp]
        public void SetUp()
        {
            // MiddleLevelCode.PrepareRunspace();
        }
        
        [TearDown]
        public void TearDown()
        {
            // MiddleLevelCode.DisposeRunspace();
        }
        
//        [Test]// [Fact]
//        public void Scroll_ImplementsCommonPattern()
//        {
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            MbUnit.Framework.Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
//            
//            
//            ISupportsHighlighter highlightableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData()) }) as ISupportsHighlighter;
//            
//            MbUnit.Framework.Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
//            
//            ISupportsNavigation navigatableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData()) }) as ISupportsNavigation;
//            
//            MbUnit.Framework.Assert.IsNotNull(navigatableElement as ISupportsNavigation);
//            
//            ISupportsConversion conversibleElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData()) }) as ISupportsConversion;
//            
//            MbUnit.Framework.Assert.IsNotNull(conversibleElement as ISupportsConversion);
//            
//            ISupportsRefresh refreshableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData()) }) as ISupportsRefresh;
//            
//            MbUnit.Framework.Assert.IsNotNull(refreshableElement as ISupportsRefresh);
//        }
//        
//        [Test]// [Fact]
//        public void Scroll_ImplementsPatternInQuestion()
//        {
//            ISupportsScrollPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData()) }) as ISupportsScrollPattern;
//            
//            MbUnit.Framework.Assert.IsNotNull(element as ISupportsScrollPattern);
//        }
//        
//        [Test]// [Fact]
//        public void Scroll_DoesNotImplementOtherPatterns()
//        {
//            ISupportsValuePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData()) }) as ISupportsValuePattern;
//            
//            MbUnit.Framework.Assert.IsNull(element as ISupportsValuePattern);
//        }
//        
//        [Test]// [Fact]
//        public void Scroll_Scroll()
//        {
//            // Arrange
//            bool expectedResult = true;
//            bool result = false;
//            ISupportsScrollPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData()) }) as ISupportsScrollPattern;
//            
//            // Act
//            element.Scroll(ScrollAmount.LargeIncrement, ScrollAmount.LargeIncrement);
//            try {
//                (element as IUiElement).GetCurrentPattern<IScrollPattern>(ScrollPattern.Pattern).Received(1).Scroll(ScrollAmount.LargeIncrement, ScrollAmount.LargeIncrement);
//                result = true;
//            }
//            catch {}
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(expectedResult, result);
//        }
//        
//        [Test]// [Fact]
//        public void Scroll_ScrollHorizontal()
//        {
//            // Arrange
//            bool expectedResult = true;
//            bool result = false;
//            ISupportsScrollPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData()) }) as ISupportsScrollPattern;
//            
//            // Act
//            element.ScrollHorizontal(ScrollAmount.LargeIncrement);
//            try {
//                (element as IUiElement).GetCurrentPattern<IScrollPattern>(ScrollPattern.Pattern).Received(1).ScrollHorizontal(ScrollAmount.LargeIncrement);
//                result = true;
//            }
//            catch {}
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(expectedResult, result);
//        }
//        
//        [Test]// [Fact]
//        public void Scroll_ScrollVertical()
//        {
//            // Arrange
//            bool expectedResult = true;
//            bool result = false;
//            ISupportsScrollPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData()) }) as ISupportsScrollPattern;
//            
//            // Act
//            element.ScrollVertical(ScrollAmount.LargeIncrement);
//            try {
//                (element as IUiElement).GetCurrentPattern<IScrollPattern>(ScrollPattern.Pattern).Received(1).ScrollVertical(ScrollAmount.LargeIncrement);
//                result = true;
//            }
//            catch {}
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(expectedResult, result);
//        }
//        
//        [Test]// [Fact]
//        public void Scroll_SetScrollPercent()
//        {
//            // Arrange
//            bool expectedResult = true;
//            bool result = false;
//            ISupportsScrollPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData()) }) as ISupportsScrollPattern;
//            
//            // Act
//            element.SetScrollPercent(1, 1);
//            try {
//                (element as IUiElement).GetCurrentPattern<IScrollPattern>(ScrollPattern.Pattern).Received(1).SetScrollPercent(1, 1);
//                result = true;
//            }
//            catch {}
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(expectedResult, result);
//        }
//        
//                
//        [Test]// [Fact]
//        public void Scroll_HorizontallyScrollable()
//        {
//            // Arrange
//            bool expectedValue = true;
//            ISupportsScrollPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData() { ScrollPattern_HorizontallyScrollable = expectedValue }) }) as ISupportsScrollPattern;
//            
//            // Act
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.HorizontallyScrollable);
//        }
//        
//        [Test]// [Fact]
//        public void Scroll_HorizontalScrollPercent()
//        {
//            // Arrange
//            double expectedValue = 12.1;
//            ISupportsScrollPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData() { ScrollPattern_HorizontalScrollPercent = expectedValue }) }) as ISupportsScrollPattern;
//            
//            // Act
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.HorizontalScrollPercent);
//        }
//        
//        [Test]// [Fact]
//        public void Scroll_HorizontalViewSize()
//        {
//            // Arrange
//            double expectedValue = 14.2;
//            ISupportsScrollPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData() { ScrollPattern_HorizontalViewSize = expectedValue }) }) as ISupportsScrollPattern;
//            
//            // Act
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.HorizontalViewSize);
//        }
//        
//        [Test]// [Fact]
//        public void Scroll_VerticallyScrollable()
//        {
//            // Arrange
//            bool expectedValue = false;
//            ISupportsScrollPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData() { ScrollPattern_VerticallyScrollable = expectedValue }) }) as ISupportsScrollPattern;
//            
//            // Act
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.VerticallyScrollable);
//        }
//        
//        [Test]// [Fact]
//        public void Scroll_VerticalScrollPercent()
//        {
//            // Arrange
//            double expectedValue = 16.3;
//            ISupportsScrollPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData() { ScrollPattern_VerticalScrollPercent = expectedValue }) }) as ISupportsScrollPattern;
//            
//            // Act
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.VerticalScrollPercent);
//        }
//        
//        [Test]// [Fact]
//        public void Scroll_VerticalViewSize()
//        {
//            // Arrange
//            double expectedValue = 18.4;
//            ISupportsScrollPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData() { ScrollPattern_VerticalViewSize = expectedValue }) }) as ISupportsScrollPattern;
//            
//            // Act
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.VerticalViewSize);
//        }
    }
}
