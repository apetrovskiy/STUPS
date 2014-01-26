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
    /// Description of ISupportsValuePatternTestFixture.
    /// </summary>
    // [Ignore]
    [MbUnit.Framework.TestFixture]
    public class ISupportsValuePatternTestFixture
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
//        public void Value_ImplementsCommonPattern()
//        {
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetValuePattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            MbUnit.Framework.Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
//            
//            ISupportsHighlighter highlightableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetValuePattern(new PatternsData()) }) as ISupportsHighlighter;
//            
//            MbUnit.Framework.Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
//            
//            ISupportsNavigation navigatableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetValuePattern(new PatternsData()) }) as ISupportsNavigation;
//            
//            MbUnit.Framework.Assert.IsNotNull(navigatableElement as ISupportsNavigation);
//            
//            ISupportsConversion conversibleElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetValuePattern(new PatternsData()) }) as ISupportsConversion;
//            
//            MbUnit.Framework.Assert.IsNotNull(conversibleElement as ISupportsConversion);
//            
//            ISupportsRefresh refreshableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetValuePattern(new PatternsData()) }) as ISupportsRefresh;
//            
//            MbUnit.Framework.Assert.IsNotNull(refreshableElement as ISupportsRefresh);
//        }
//        
//        [Test]// [Fact]
//        public void Value_ImplementsPatternInQuestion()
//        {
//            ISupportsValuePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetValuePattern(new PatternsData()) }) as ISupportsValuePattern;
//            
//            MbUnit.Framework.Assert.IsNotNull(element as ISupportsValuePattern);
//        }
//        
//        [Test]// [Fact]
//        public void Value_DoesNotImplementOtherPatterns()
//        {
//            ISupportsDockPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetValuePattern(new PatternsData()) }) as ISupportsDockPattern;
//            
//            MbUnit.Framework.Assert.IsNull(element as ISupportsValuePattern);
//        }
//        
//        [Test]// [Fact]
//        public void Value_Value_Get()
//        {
//            // Arrange
//            const string expectedValue = "abc";
//            ISupportsValuePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetValuePattern(new PatternsData() { ValuePattern_Value = expectedValue }) }) as ISupportsValuePattern;
//            
//            // Act
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.Value);
//        }
//        
//        [Test]// [Fact]
//        [Ignore]
//        public void Value_Value_Set()
//        {
//            // Arrange
//            string expectedValue = "abc";
//            ISupportsValuePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetValuePattern(new PatternsData()) }) as ISupportsValuePattern;
//            
//            // Act
//            element.Value = expectedValue;
//            try {
//                (element as IUiElement).GetCurrentPattern<IValuePattern>(ValuePattern.Pattern).Received(1).SetValue(expectedValue);
//                element.Value.Returns(expectedValue);
//                
//            }
//            catch {}
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.Value);
//        }
    }
}
