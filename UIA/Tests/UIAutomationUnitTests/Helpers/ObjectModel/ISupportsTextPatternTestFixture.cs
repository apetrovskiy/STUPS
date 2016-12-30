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
    using System.Windows.Automation.Text;
    using UIAutomation;
    using Xunit;
    using NSubstitute;
    
    /// <summary>
    /// Description of ISupportsTextPatternTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class ISupportsTextPatternTestFixture
    {
        public ISupportsTextPatternTestFixture()
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
        public void Text_ImplementsCommonPattern()
        {
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            MbUnit.Framework.Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
            
            var highlightableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsHighlighter;
            
            MbUnit.Framework.Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
            Assert.NotNull(highlightableElement as ISupportsHighlighter);
            
            var navigatableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsNavigation;
            
            MbUnit.Framework.Assert.IsNotNull(navigatableElement as ISupportsNavigation);
            Assert.NotNull(navigatableElement as ISupportsNavigation);
            
            var conversibleElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsConversion;
            
            MbUnit.Framework.Assert.IsNotNull(conversibleElement as ISupportsConversion);
            Assert.NotNull(conversibleElement as ISupportsConversion);
            
            var refreshableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsRefresh;
            
            MbUnit.Framework.Assert.IsNotNull(refreshableElement as ISupportsRefresh);
            Assert.NotNull(refreshableElement as ISupportsRefresh);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Text_ImplementsPatternInQuestion()
        {
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsTextPattern;
            
            MbUnit.Framework.Assert.IsNotNull(element as ISupportsTextPattern);
            Assert.NotNull(element as ISupportsTextPattern);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Text_DoesNotImplementOtherPatterns()
        {
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsValuePattern;
            
            MbUnit.Framework.Assert.IsNull(element as ISupportsValuePattern);
            Assert.Null(element as ISupportsValuePattern);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Text_GetTextSelection()
        {
            // Arrange
            const bool expectedResult = true;
            bool result = false;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsTextPattern;
            
            // Act
            element.GetTextSelection();
            try {
                var resultData = (element as IUiElement).GetCurrentPattern<ITextPattern>(TextPattern.Pattern).Received(1).GetSelection();
                result = true;
            }
            catch {}
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedResult, result);
            Assert.Equal(expectedResult, result);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Text_GetVisibleRanges()
        {
            // Arrange
            const bool expectedResult = true;
            bool result = false;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsTextPattern;
            
            // Act
            element.GetVisibleRanges();
            try {
                var resultData = (element as IUiElement).GetCurrentPattern<ITextPattern>(TextPattern.Pattern).Received(1).GetVisibleRanges();
                result = true;
            }
            catch {}
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedResult, result);
            Assert.Equal(expectedResult, result);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        // [Ignore]
        [MbUnit.Framework.Ignore]
        [NUnit.Framework.Ignore("")]
        public void Text_RangeFromChild()
        {
            // Arrange
            const bool expectedResult = true;
            bool result = false;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsTextPattern;
            
            // Act
            element.RangeFromChild(new UiElement());
            try {
                var resultData = (element as IUiElement).GetCurrentPattern<ITextPattern>(TextPattern.Pattern).Received(1).RangeFromChild(new UiElement());
                result = true;
            }
            catch {}
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedResult, result);
            Assert.Equal(expectedResult, result);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        // [Ignore]
        [MbUnit.Framework.Ignore]
        [NUnit.Framework.Ignore("")]
        public void Text_RangeFromPoint()
        {
            // Arrange
            const bool expectedResult = true;
            bool result = false;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsTextPattern;
            
            // Act
            element.RangeFromPoint(new System.Windows.Point());
            try {
                var resultData = (element as IUiElement).GetCurrentPattern<ITextPattern>(TextPattern.Pattern).Received(1).RangeFromPoint(new System.Windows.Point());
                result = true;
            }
            catch {}
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedResult, result);
            Assert.Equal(expectedResult, result);
        }
        
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        // [Ignore]
        [MbUnit.Framework.Ignore]
        [NUnit.Framework.Ignore("")]
        public void Text_DocumentRange()
        {
            // Arrange
            var expectedValue = new object() as TextPatternRange;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData() { TextPattern_DocumentRange = expectedValue }) }) as ISupportsTextPattern;
            
            // Act
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.DocumentRange);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Text_SupportedTextSelection()
        {
            // Arrange
            var expectedValue = SupportedTextSelection.Single;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData() { TextPattern_SupportedTextSelection = expectedValue }) }) as ISupportsTextPattern;
            
            // Act
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.SupportedTextSelection);
        }
    }
}
