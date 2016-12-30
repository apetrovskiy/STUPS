/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/22/2013
 * Time: 2:50 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.ObjectModel
{
    using System.Windows.Automation;
    using UIAutomation;
    using Xunit;
    using NSubstitute;
    
    /// <summary>
    /// Description of ISupportsRangeValuePatternTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class ISupportsRangeValuePatternTestFixture
    {
        public ISupportsRangeValuePatternTestFixture()
        {
            FakeFactory.Init();
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            FakeFactory.Init();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void TearDown()
        {
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void RangeValue_ImplementsCommonPattern()
        {
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetRangeValuePattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            MbUnit.Framework.Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
            
            var highlightableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetRangeValuePattern(new PatternsData()) }) as ISupportsHighlighter;
            
            MbUnit.Framework.Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
            Assert.NotNull(highlightableElement as ISupportsHighlighter);
            
            var navigatableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetRangeValuePattern(new PatternsData()) }) as ISupportsNavigation;
            
            MbUnit.Framework.Assert.IsNotNull(navigatableElement as ISupportsNavigation);
            Assert.NotNull(navigatableElement as ISupportsNavigation);
            
            var conversibleElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetRangeValuePattern(new PatternsData()) }) as ISupportsConversion;
            
            MbUnit.Framework.Assert.IsNotNull(conversibleElement as ISupportsConversion);
            Assert.NotNull(conversibleElement as ISupportsConversion);
            
            var refreshableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetRangeValuePattern(new PatternsData()) }) as ISupportsRefresh;
            
            MbUnit.Framework.Assert.IsNotNull(refreshableElement as ISupportsRefresh);
            Assert.NotNull(refreshableElement as ISupportsRefresh);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void RangeValue_ImplementsPatternInQuestion()
        {
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetRangeValuePattern(new PatternsData()) }) as ISupportsRangeValuePattern;
            
            MbUnit.Framework.Assert.IsNotNull(element as ISupportsRangeValuePattern);
            Assert.NotNull(element as ISupportsRangeValuePattern);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void RangeValue_DoesNotImplementOtherPatterns()
        {
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetRangeValuePattern(new PatternsData()) }) as ISupportsValuePattern;
            
            MbUnit.Framework.Assert.IsNull(element as ISupportsValuePattern);
            Assert.Null(element as ISupportsValuePattern);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void RangeValue_IsRangeReadOnly()
        {
            // Arrange
            const bool expectedValue = true;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetRangeValuePattern(new PatternsData() { RangeValuePattern_IsReadOnly = expectedValue }) }) as ISupportsRangeValuePattern;
            
            // Act
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.IsRangeReadOnly);
            Assert.Equal(expectedValue, element.IsRangeReadOnly);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void RangeValue_LargeChange()
        {
            // Arrange
            const double expectedValue = 101.1;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetRangeValuePattern(new PatternsData() { RangeValuePattern_LargeChange = expectedValue }) }) as ISupportsRangeValuePattern;
            
            // Act
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.LargeChange);
            Assert.Equal(expectedValue, element.LargeChange);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void RangeValue_Maximum()
        {
            // Arrange
            const double expectedValue = 1001.2;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetRangeValuePattern(new PatternsData() { RangeValuePattern_Maximum = expectedValue }) }) as ISupportsRangeValuePattern;
            
            // Act
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.Maximum);
            Assert.Equal(expectedValue, element.Maximum);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void RangeValue_Minimum()
        {
            // Arrange
            const double expectedValue = 15.3;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetRangeValuePattern(new PatternsData() { RangeValuePattern_Minimum = expectedValue }) }) as ISupportsRangeValuePattern;
            
            // Act
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.Minimum);
            Assert.Equal(expectedValue, element.Minimum);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void RangeValue_SmallChange()
        {
            // Arrange
            const double expectedValue = 5.4;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetRangeValuePattern(new PatternsData() { RangeValuePattern_SmallChange = expectedValue }) }) as ISupportsRangeValuePattern;
            
            // Act
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.SmallChange);
            Assert.Equal(expectedValue, element.SmallChange);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void RangeValue_RangeValue_Get()
        {
            // Arrange
            const double expectedValue = 3.5;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetRangeValuePattern(new PatternsData() { RangeValuePattern_Value = expectedValue }) }) as ISupportsRangeValuePattern;
            
            // Act
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.RangeValue);
            Assert.Equal(expectedValue, element.RangeValue);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void RangeValue_RangeValue_Set()
        {
            // Arrange
            const double expectedValue = 4.7;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetRangeValuePattern(new PatternsData()) }) as ISupportsRangeValuePattern;
            
            // Act
            element.RangeValue = expectedValue;
            try {
                (element as IUiElement).GetCurrentPattern<IRangeValuePattern>(RangeValuePattern.Pattern).Received(1).SetValue(expectedValue);
                element.RangeValue.Returns(expectedValue);
                
            }
            catch {}
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.RangeValue);
            Assert.Equal(expectedValue, element.RangeValue);
        }
    }
}
