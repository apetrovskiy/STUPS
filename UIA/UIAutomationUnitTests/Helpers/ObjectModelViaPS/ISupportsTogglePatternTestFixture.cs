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
    /// Description of ISupportsTogglePatternTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture]
    public class ISupportsTogglePatternTestFixture
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
//        public void Toggle_ImplementsCommonPattern()
//        {
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTogglePattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            MbUnit.Framework.Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
//            
//            ISupportsHighlighter highlightableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTogglePattern(new PatternsData()) }) as ISupportsHighlighter;
//            
//            MbUnit.Framework.Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
//            
//            ISupportsNavigation navigatableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTogglePattern(new PatternsData()) }) as ISupportsNavigation;
//            
//            MbUnit.Framework.Assert.IsNotNull(navigatableElement as ISupportsNavigation);
//            
//            ISupportsConversion conversibleElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTogglePattern(new PatternsData()) }) as ISupportsConversion;
//            
//            MbUnit.Framework.Assert.IsNotNull(conversibleElement as ISupportsConversion);
//            
//            ISupportsRefresh refreshableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTogglePattern(new PatternsData()) }) as ISupportsRefresh;
//            
//            MbUnit.Framework.Assert.IsNotNull(refreshableElement as ISupportsRefresh);
//        }
//        
//        [Test]// [Fact]
//        public void Toggle_ImplementsPatternInQuestion()
//        {
//            ISupportsTogglePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTogglePattern(new PatternsData()) }) as ISupportsTogglePattern;
//            
//            MbUnit.Framework.Assert.IsNotNull(element as ISupportsTogglePattern);
//        }
//        
//        [Test]// [Fact]
//        public void Toggle_DoesNotImplementOtherPatterns()
//        {
//            ISupportsValuePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTogglePattern(new PatternsData()) }) as ISupportsValuePattern;
//            
//            MbUnit.Framework.Assert.IsNull(element as ISupportsValuePattern);
//        }
//        
////        [Test]// [Fact]
////        public void Toggle_Toggle()
////        {
////            // Arrange
////            ISupportsTogglePattern element =
////                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
////                    new IBasePattern[] { FakeFactory.GetTogglePattern(new PatternsData()) }) as ISupportsTogglePattern;
////            
////            // Act
////            // Assert
////            element.Toggle();
////        }
//        
//        [Test]// [Fact]
//        public void Toggle_ToggleState_Indeterminate()
//        {
//            // Arrange
//            ToggleState expectedValue = ToggleState.Indeterminate;
//            ISupportsTogglePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTogglePattern(new PatternsData() { TogglePattern_ToggleState = expectedValue }) }) as ISupportsTogglePattern;
//            
//            // Act
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.ToggleState);
//        }
//        
//        [Test]// [Fact]
//        public void Toggle_ToggleState_Off()
//        {
//            // Arrange
//            ToggleState expectedValue = ToggleState.Off;
//            ISupportsTogglePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTogglePattern(new PatternsData() { TogglePattern_ToggleState = expectedValue }) }) as ISupportsTogglePattern;
//            
//            // Act
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.ToggleState);
//        }
//        
//        [Test]// [Fact]
//        public void Toggle_ToggleState_On()
//        {
//            // Arrange
//            ToggleState expectedValue = ToggleState.On;
//            ISupportsTogglePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTogglePattern(new PatternsData() { TogglePattern_ToggleState = expectedValue }) }) as ISupportsTogglePattern;
//            
//            // Act
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.ToggleState);
//        }
//        
//        [Test]// [Fact]
//        public void Toggle_Toggle_On()
//        {
//            // Arrange
//            ToggleState expectedValue = ToggleState.On;
//            ISupportsTogglePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTogglePattern(new PatternsData()) }) as ISupportsTogglePattern;
//            
//            // Act
//            element.ToggleState.Returns(ToggleState.Off);
//            element.Toggle();
//            try {
//                (element as IUiElement).GetCurrentPattern<ITogglePattern>(TogglePattern.Pattern).Received().Toggle();
//                if (ToggleState.Off == element.ToggleState) {
//                    element.ToggleState.Returns(ToggleState.On);
//                }
//            }
//            catch {}
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.ToggleState);
//        }
//        
//        [Test]// [Fact]
//        public void Toggle_Toggle_Off()
//        {
//            // Arrange
//            ToggleState expectedValue = ToggleState.Off;
//            ISupportsTogglePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTogglePattern(new PatternsData()) }) as ISupportsTogglePattern;
//            
//            // Act
//            element.ToggleState.Returns(ToggleState.On);
//            element.Toggle();
//            try {
//                (element as IUiElement).GetCurrentPattern<ITogglePattern>(TogglePattern.Pattern).Received().Toggle();
//                if (ToggleState.On == element.ToggleState) {
//                    element.ToggleState.Returns(ToggleState.Off);
//                }
//            }
//            catch {}
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.ToggleState);
//        }
    }
}
