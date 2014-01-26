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
    /// Description of ISupportsTextPatternTestFixture.
    /// </summary>
    // [Ignore]
    [MbUnit.Framework.TestFixture]
    public class ISupportsTextPatternTestFixture
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
//        public void Text_ImplementsCommonPattern()
//        {
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            MbUnit.Framework.Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
//            
//            ISupportsHighlighter highlightableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsHighlighter;
//            
//            MbUnit.Framework.Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
//            
//            ISupportsNavigation navigatableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsNavigation;
//            
//            MbUnit.Framework.Assert.IsNotNull(navigatableElement as ISupportsNavigation);
//            
//            ISupportsConversion conversibleElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsConversion;
//            
//            MbUnit.Framework.Assert.IsNotNull(conversibleElement as ISupportsConversion);
//            
//            ISupportsRefresh refreshableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsRefresh;
//            
//            MbUnit.Framework.Assert.IsNotNull(refreshableElement as ISupportsRefresh);
//        }
//        
//        [Test]// [Fact]
//        public void Text_ImplementsPatternInQuestion()
//        {
//            ISupportsTextPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsTextPattern;
//            
//            MbUnit.Framework.Assert.IsNotNull(element as ISupportsTextPattern);
//        }
//        
//        [Test]// [Fact]
//        public void Text_DoesNotImplementOtherPatterns()
//        {
//            ISupportsValuePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsValuePattern;
//            
//            MbUnit.Framework.Assert.IsNull(element as ISupportsValuePattern);
//        }
//        
//        [Test]// [Fact]
//        public void Text_GetTextSelection()
//        {
//            // Arrange
//            bool expectedResult = true;
//            bool result = false;
//            ISupportsTextPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsTextPattern;
//            
//            // Act
//            element.GetTextSelection();
//            try {
//                var resultData = (element as IUiElement).GetCurrentPattern<ITextPattern>(TextPattern.Pattern).Received(1).GetSelection();
//                result = true;
//            }
//            catch {}
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(expectedResult, result);
//        }
//        
//        [Test]// [Fact]
//        public void Text_GetVisibleRanges()
//        {
//            // Arrange
//            bool expectedResult = true;
//            bool result = false;
//            ISupportsTextPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsTextPattern;
//            
//            // Act
//            element.GetVisibleRanges();
//            try {
//                var resultData = (element as IUiElement).GetCurrentPattern<ITextPattern>(TextPattern.Pattern).Received(1).GetVisibleRanges();
//                result = true;
//            }
//            catch {}
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(expectedResult, result);
//        }
//        
//        [Test]// [Fact]
//        [Ignore]
//        public void Text_RangeFromChild()
//        {
//            // Arrange
//            bool expectedResult = true;
//            bool result = false;
//            ISupportsTextPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsTextPattern;
//            
//            // Act
//            element.RangeFromChild(new UiElement());
//            try {
//                var resultData = (element as IUiElement).GetCurrentPattern<ITextPattern>(TextPattern.Pattern).Received(1).RangeFromChild(new UiElement());
//                result = true;
//            }
//            catch {}
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(expectedResult, result);
//        }
//        
//        [Test]// [Fact]
//        [Ignore]
//        public void Text_RangeFromPoint()
//        {
//            // Arrange
//            bool expectedResult = true;
//            bool result = false;
//            ISupportsTextPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsTextPattern;
//            
//            // Act
//            element.RangeFromPoint(new System.Windows.Point());
//            try {
//                var resultData = (element as IUiElement).GetCurrentPattern<ITextPattern>(TextPattern.Pattern).Received(1).RangeFromPoint(new System.Windows.Point());
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
//        [Ignore]
//        public void Text_DocumentRange()
//        {
//            // Arrange
//            TextPatternRange expectedValue = new object() as TextPatternRange;
//            ISupportsTextPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData() { TextPattern_DocumentRange = expectedValue }) }) as ISupportsTextPattern;
//            
//            // Act
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.DocumentRange);
//        }
//        
//        [Test]// [Fact]
//        public void Text_SupportedTextSelection()
//        {
//            // Arrange
//            SupportedTextSelection expectedValue = SupportedTextSelection.Single;
//            ISupportsTextPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData() { TextPattern_SupportedTextSelection = expectedValue }) }) as ISupportsTextPattern;
//            
//            // Act
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.SupportedTextSelection);
//        }
    }
}
