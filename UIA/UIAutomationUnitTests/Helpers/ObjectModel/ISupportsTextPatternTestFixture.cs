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
    using MbUnit.Framework;
    using NSubstitute;
    
    /// <summary>
    /// Description of ISupportsTextPatternTestFixture.
    /// </summary>
    // [Ignore]
    [TestFixture]
    public class ISupportsTextPatternTestFixture
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
        public void Text_ImplementsCommonPattern()
        {
            ISupportsInvokePattern invokableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsInvokePattern;
            
            Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
            
            ISupportsHighlighter highlightableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsHighlighter;
            
            Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
            
            ISupportsNavigation navigatableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsNavigation;
            
            Assert.IsNotNull(navigatableElement as ISupportsNavigation);
            
            ISupportsConversion conversibleElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsConversion;
            
            Assert.IsNotNull(conversibleElement as ISupportsConversion);
            
            ISupportsRefresh refreshableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsRefresh;
            
            Assert.IsNotNull(refreshableElement as ISupportsRefresh);
        }
        
        [Test]
        public void Text_ImplementsPatternInQuestion()
        {
            ISupportsTextPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsTextPattern;
            
            Assert.IsNotNull(element as ISupportsTextPattern);
        }
        
        [Test]
        public void Text_DoesNotImplementOtherPatterns()
        {
            ISupportsValuePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsValuePattern;
            
            Assert.IsNull(element as ISupportsValuePattern);
        }
        
        [Test]
        public void Text_GetTextSelection()
        {
            // Arrange
            bool expectedResult = true;
            bool result = false;
            ISupportsTextPattern element =
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
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test]
        public void Text_GetVisibleRanges()
        {
            // Arrange
            bool expectedResult = true;
            bool result = false;
            ISupportsTextPattern element =
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
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test]
        [Ignore]
        public void Text_RangeFromChild()
        {
            // Arrange
            bool expectedResult = true;
            bool result = false;
            ISupportsTextPattern element =
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
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test]
        [Ignore]
        public void Text_RangeFromPoint()
        {
            // Arrange
            bool expectedResult = true;
            bool result = false;
            ISupportsTextPattern element =
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
            Assert.AreEqual(expectedResult, result);
        }
        
        
        [Test]
        [Ignore]
        public void Text_DocumentRange()
        {
            // Arrange
            TextPatternRange expectedValue = new object() as TextPatternRange;
            ISupportsTextPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData() { TextPattern_DocumentRange = expectedValue }) }) as ISupportsTextPattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.DocumentRange);
        }
        
        [Test]
        public void Text_SupportedTextSelection()
        {
            // Arrange
            SupportedTextSelection expectedValue = SupportedTextSelection.Single;
            ISupportsTextPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData() { TextPattern_SupportedTextSelection = expectedValue }) }) as ISupportsTextPattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.SupportedTextSelection);
        }
    }
}
