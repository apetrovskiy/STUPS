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
    /// Description of ISupportsScrollItemPatternTestFixture.
    /// </summary>
    [TestFixture]
    public class ISupportsScrollItemPatternTestFixture
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
//        public void ScrollItem_ImplementsCommonPattern()
//        {
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollItemPattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
//            
//            ISupportsHighlighter highlightableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollItemPattern(new PatternsData()) }) as ISupportsHighlighter;
//            
//            Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
//            
//            ISupportsNavigation navigatableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollItemPattern(new PatternsData()) }) as ISupportsNavigation;
//            
//            Assert.IsNotNull(navigatableElement as ISupportsNavigation);
//            
//            ISupportsConversion conversibleElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollItemPattern(new PatternsData()) }) as ISupportsConversion;
//            
//            Assert.IsNotNull(conversibleElement as ISupportsConversion);
//            
//            ISupportsRefresh refreshableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollItemPattern(new PatternsData()) }) as ISupportsRefresh;
//            
//            Assert.IsNotNull(refreshableElement as ISupportsRefresh);
//        }
//        
//        [Test]
//        public void ScrollItem_ImplementsPatternInQuestion()
//        {
//            ISupportsScrollItemPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollItemPattern(new PatternsData()) }) as ISupportsScrollItemPattern;
//            
//            Assert.IsNotNull(element as ISupportsScrollItemPattern);
//        }
//        
//        [Test]
//        public void ScrollItem_DoesNotImplementOtherPatterns()
//        {
//            ISupportsValuePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollItemPattern(new PatternsData()) }) as ISupportsValuePattern;
//            
//            Assert.IsNull(element as ISupportsValuePattern);
//        }
//        
//        [Test]
//        public void ScrollItem_ScrollIntoView()
//        {
//            // Arrange
//            bool expectedResult = true;
//            bool result = false;
//            ISupportsScrollItemPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollItemPattern(new PatternsData()) }) as ISupportsScrollItemPattern;
//            
//            // Act
//            element.ScrollIntoView();
//            try {
//                (element as IUiElement).GetCurrentPattern<IScrollItemPattern>(ScrollItemPattern.Pattern).Received(1).ScrollIntoView();
//                result = true;
//            }
//            catch {}
//            
//            // Assert
//            Assert.AreEqual(expectedResult, result);
//        }
    }
}
