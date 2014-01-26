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
    using MbUnit.Framework;using Xunit;
    using NSubstitute;
    
    /// <summary>
    /// Description of ISupportsSelectionPatternTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture]
    public class ISupportsSelectionPatternTestFixture
    {
        public ISupportsSelectionPatternTestFixture()
        {
            FakeFactory.Init();
        }
        
        [SetUp]
        public void SetUp()
        {
            FakeFactory.Init();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
        [Test][Fact]
        public void Selection_ImplementsCommonPattern()
        {
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetSelectionPattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            MbUnit.Framework.Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
            
            ISupportsHighlighter highlightableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetSelectionPattern(new PatternsData()) }) as ISupportsHighlighter;
            
            MbUnit.Framework.Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
            Xunit.Assert.NotNull(highlightableElement as ISupportsHighlighter);
            
            ISupportsNavigation navigatableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetSelectionPattern(new PatternsData()) }) as ISupportsNavigation;
            
            MbUnit.Framework.Assert.IsNotNull(navigatableElement as ISupportsNavigation);
            Xunit.Assert.NotNull(navigatableElement as ISupportsNavigation);
            
            ISupportsConversion conversibleElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetSelectionPattern(new PatternsData()) }) as ISupportsConversion;
            
            MbUnit.Framework.Assert.IsNotNull(conversibleElement as ISupportsConversion);
            Xunit.Assert.NotNull(conversibleElement as ISupportsConversion);
            
            ISupportsRefresh refreshableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetSelectionPattern(new PatternsData()) }) as ISupportsRefresh;
            
            MbUnit.Framework.Assert.IsNotNull(refreshableElement as ISupportsRefresh);
            Xunit.Assert.NotNull(refreshableElement as ISupportsRefresh);
        }
        
        [Test][Fact]
        public void Selection_ImplementsPatternInQuestion()
        {
            ISupportsSelectionPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetSelectionPattern(new PatternsData()) }) as ISupportsSelectionPattern;
            
            MbUnit.Framework.Assert.IsNotNull(element as ISupportsSelectionPattern);
            Xunit.Assert.NotNull(element as ISupportsSelectionPattern);
        }
        
        [Test][Fact]
        public void Selection_DoesNotImplementOtherPatterns()
        {
            ISupportsValuePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetSelectionPattern(new PatternsData()) }) as ISupportsValuePattern;
            
            MbUnit.Framework.Assert.IsNull(element as ISupportsValuePattern);
            Xunit.Assert.Null(element as ISupportsValuePattern);
        }
        
        [Test][Fact]
        public void Selection_GetSelection()
        {
            // Arrange
            bool expectedResult = true;
            bool result = false;
            ISupportsSelectionPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetSelectionPattern(new PatternsData()) }) as ISupportsSelectionPattern;
            
            // Act
            element.GetSelection();
            try {
                var resultData = (element as IUiElement).GetCurrentPattern<ISelectionPattern>(SelectionPattern.Pattern).Current.Received(1).GetSelection();
                result = true;
            }
            catch {}
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedResult, result);
            Xunit.Assert.Equal(expectedResult, result);
        }
        
        [Test][Fact]
        public void Selection_CanSelectMultiple()
        {
            // Arrange
            bool expectedValue = true;
            ISupportsSelectionPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetSelectionPattern(new PatternsData() { SelectionPattern_CanSelectMultiple = expectedValue }) }) as ISupportsSelectionPattern;
            
            // Act
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.CanSelectMultiple);
            Xunit.Assert.Equal(expectedValue, element.CanSelectMultiple);
        }
        
        [Test][Fact]
        public void Selection_IsSelectionRequired()
        {
            // Arrange
            bool expectedValue = false;
            ISupportsSelectionPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetSelectionPattern(new PatternsData() { SelectionPattern_IsSelectionRequired = expectedValue }) }) as ISupportsSelectionPattern;
            
            // Act
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.IsSelectionRequired);
            Xunit.Assert.Equal(expectedValue, element.IsSelectionRequired);
        }
    }
}
