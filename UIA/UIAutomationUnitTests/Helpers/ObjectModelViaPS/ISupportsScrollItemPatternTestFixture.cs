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
    /// Description of ISupportsScrollItemPatternTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture]
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
        
//        [Test]// [Fact]
//        public void ScrollItem_ImplementsCommonPattern()
//        {
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollItemPattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            MbUnit.Framework.Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
//            
//            ISupportsHighlighter highlightableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollItemPattern(new PatternsData()) }) as ISupportsHighlighter;
//            
//            MbUnit.Framework.Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
//            
//            ISupportsNavigation navigatableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollItemPattern(new PatternsData()) }) as ISupportsNavigation;
//            
//            MbUnit.Framework.Assert.IsNotNull(navigatableElement as ISupportsNavigation);
//            
//            ISupportsConversion conversibleElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollItemPattern(new PatternsData()) }) as ISupportsConversion;
//            
//            MbUnit.Framework.Assert.IsNotNull(conversibleElement as ISupportsConversion);
//            
//            ISupportsRefresh refreshableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollItemPattern(new PatternsData()) }) as ISupportsRefresh;
//            
//            MbUnit.Framework.Assert.IsNotNull(refreshableElement as ISupportsRefresh);
//        }
//        
//        [Test]// [Fact]
//        public void ScrollItem_ImplementsPatternInQuestion()
//        {
//            ISupportsScrollItemPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollItemPattern(new PatternsData()) }) as ISupportsScrollItemPattern;
//            
//            MbUnit.Framework.Assert.IsNotNull(element as ISupportsScrollItemPattern);
//        }
//        
//        [Test]// [Fact]
//        public void ScrollItem_DoesNotImplementOtherPatterns()
//        {
//            ISupportsValuePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetScrollItemPattern(new PatternsData()) }) as ISupportsValuePattern;
//            
//            MbUnit.Framework.Assert.IsNull(element as ISupportsValuePattern);
//        }
//        
//        [Test]// [Fact]
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
//            MbUnit.Framework.Assert.AreEqual(expectedResult, result);
//        }
    }
}
