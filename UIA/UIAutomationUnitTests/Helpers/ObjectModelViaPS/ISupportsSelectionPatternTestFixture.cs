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
    using MbUnit.Framework;
    using System.Management.Automation;
    using NSubstitute;
    using UIAutomation;
    // using UIAutomationTest;
    
    /// <summary>
    /// Description of ISupportsSelectionPatternTestFixture.
    /// </summary>
    [TestFixture]
    public class ISupportsSelectionPatternTestFixture
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
        
//        [Test]
//        public void Selection_ImplementsCommonPattern()
//        {
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetSelectionPattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
//            
//            ISupportsHighlighter highlightableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetSelectionPattern(new PatternsData()) }) as ISupportsHighlighter;
//            
//            Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
//            
//            ISupportsNavigation navigatableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetSelectionPattern(new PatternsData()) }) as ISupportsNavigation;
//            
//            Assert.IsNotNull(navigatableElement as ISupportsNavigation);
//            
//            ISupportsConversion conversibleElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetSelectionPattern(new PatternsData()) }) as ISupportsConversion;
//            
//            Assert.IsNotNull(conversibleElement as ISupportsConversion);
//            
//            ISupportsRefresh refreshableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetSelectionPattern(new PatternsData()) }) as ISupportsRefresh;
//            
//            Assert.IsNotNull(refreshableElement as ISupportsRefresh);
//        }
//        
//        [Test]
//        public void Selection_ImplementsPatternInQuestion()
//        {
//            ISupportsSelectionPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetSelectionPattern(new PatternsData()) }) as ISupportsSelectionPattern;
//            
//            Assert.IsNotNull(element as ISupportsSelectionPattern);
//        }
//        
//        [Test]
//        public void Selection_DoesNotImplementOtherPatterns()
//        {
//            ISupportsValuePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetSelectionPattern(new PatternsData()) }) as ISupportsValuePattern;
//            
//            Assert.IsNull(element as ISupportsValuePattern);
//        }
//        
//        [Test]
//        public void Selection_GetSelection()
//        {
//            // Arrange
//            bool expectedResult = true;
//            bool result = false;
//            ISupportsSelectionPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetSelectionPattern(new PatternsData()) }) as ISupportsSelectionPattern;
//            
//            // Act
//            element.GetSelection();
//            try {
//                var resultData = (element as IUiElement).GetCurrentPattern<ISelectionPattern>(SelectionPattern.Pattern).Current.Received(1).GetSelection();
//                result = true;
//            }
//            catch {}
//            
//            // Assert
//            Assert.AreEqual(expectedResult, result);
//        }
//        
//        [Test]
//        public void Selection_CanSelectMultiple()
//        {
//            // Arrange
//            bool expectedValue = true;
//            ISupportsSelectionPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetSelectionPattern(new PatternsData() { SelectionPattern_CanSelectMultiple = expectedValue }) }) as ISupportsSelectionPattern;
//            
//            // Act
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.CanSelectMultiple);
//        }
//        
//        [Test]
//        public void Selection_IsSelectionRequired()
//        {
//            // Arrange
//            bool expectedValue = false;
//            ISupportsSelectionPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetSelectionPattern(new PatternsData() { SelectionPattern_IsSelectionRequired = expectedValue }) }) as ISupportsSelectionPattern;
//            
//            // Act
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.IsSelectionRequired);
//        }
    }
}
