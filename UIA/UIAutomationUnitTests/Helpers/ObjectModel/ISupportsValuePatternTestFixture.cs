/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/21/2013
 * Time: 1:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.ObjectModel
{
    using System.Windows.Automation;
    using UIAutomation;
    using MbUnit.Framework;
    using NSubstitute;
    
    /// <summary>
    /// Description of ISupportsValuePatternTestFixture.
    /// </summary>
    // [Ignore]
    [TestFixture]
    public class ISupportsValuePatternTestFixture
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
        public void Value_ImplementsCommonPattern()
        {
            ISupportsInvokePattern invokableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetValuePattern(new PatternsData()) }) as ISupportsInvokePattern;
            
            Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
            
            ISupportsHighlighter highlightableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetValuePattern(new PatternsData()) }) as ISupportsHighlighter;
            
            Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
            
            ISupportsNavigation navigatableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetValuePattern(new PatternsData()) }) as ISupportsNavigation;
            
            Assert.IsNotNull(navigatableElement as ISupportsNavigation);
            
            ISupportsConversion conversibleElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetValuePattern(new PatternsData()) }) as ISupportsConversion;
            
            Assert.IsNotNull(conversibleElement as ISupportsConversion);
            
            ISupportsRefresh refreshableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetValuePattern(new PatternsData()) }) as ISupportsRefresh;
            
            Assert.IsNotNull(refreshableElement as ISupportsRefresh);
        }
        
        [Test]
        public void Value_ImplementsPatternInQuestion()
        {
            ISupportsValuePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetValuePattern(new PatternsData()) }) as ISupportsValuePattern;
            
            Assert.IsNotNull(element as ISupportsValuePattern);
        }
        
        [Test]
        public void Value_DoesNotImplementOtherPatterns()
        {
            ISupportsDockPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetValuePattern(new PatternsData()) }) as ISupportsDockPattern;
            
            Assert.IsNull(element as ISupportsValuePattern);
        }
        
        [Test]
        public void Value_Value_Get()
        {
            // Arrange
            const string expectedValue = "abc";
            ISupportsValuePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetValuePattern(new PatternsData() { ValuePattern_Value = expectedValue }) }) as ISupportsValuePattern;
            
            // Act
            // Assert
            Assert.AreEqual(expectedValue, element.Value);
        }
        
        [Test]
        [Ignore]
        public void Value_Value_Set()
        {
            // Arrange
            string expectedValue = "abc";
            ISupportsValuePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetValuePattern(new PatternsData()) }) as ISupportsValuePattern;
            
            // Act
            element.Value = expectedValue;
            try {
                (element as IUiElement).GetCurrentPattern<IValuePattern>(ValuePattern.Pattern).Received(1).SetValue(expectedValue);
                element.Value.Returns(expectedValue);
                
            }
            catch {}
            
            // Assert
            Assert.AreEqual(expectedValue, element.Value);
        }
    }
}
