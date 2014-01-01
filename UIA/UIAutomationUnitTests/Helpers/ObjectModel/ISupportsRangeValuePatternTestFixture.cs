/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/22/2013
 * Time: 2:50 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.ObjectModel
{
    using System.Windows.Automation;
    using UIAutomation;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of ISupportsRangeValuePatternTestFixture.
    /// </summary>
    // [Ignore]
    [TestFixture]
    public class ISupportsRangeValuePatternTestFixture
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
        public void RangeValue_ImplementsCommonPattern()
        {
            ISupportsInvokePattern invokableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetRangeValuePattern(new PatternsData()) }) as ISupportsInvokePattern;
            
            Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
            
            ISupportsHighlighter highlightableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetRangeValuePattern(new PatternsData()) }) as ISupportsHighlighter;
            
            Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
            
            ISupportsNavigation navigatableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetRangeValuePattern(new PatternsData()) }) as ISupportsNavigation;
            
            Assert.IsNotNull(navigatableElement as ISupportsNavigation);
            
            ISupportsConversion navigatableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsConversion;
            
            Assert.IsNotNull(conversibleeElement as ISupportsConversion);
        }
        
        [Test]
        public void RangeValue_ImplementsPattern()
        {
            ISupportsRangeValuePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetRangeValuePattern(new PatternsData()) }) as ISupportsRangeValuePattern;
            
            Assert.IsNotNull(element as ISupportsRangeValuePattern);
        }
        
        [Test]
        public void RangeValue_DoesNotImplementOtherPatterns()
        {
            ISupportsValuePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetRangeValuePattern(new PatternsData()) }) as ISupportsValuePattern;
            
            Assert.IsNull(element as ISupportsValuePattern);
        }
        
        [Test]
        public void RangeValue_IsRangeReadOnly()
        {
            // Arrange
            bool expectedValue = true;
            ISupportsRangeValuePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetRangeValuePattern(new PatternsData() { RangeValuePattern_IsReadOnly = expectedValue }) }) as ISupportsRangeValuePattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.IsRangeReadOnly);
        }
        
        [Test]
        public void RangeValue_LargeChange()
        {
            // Arrange
            double expectedValue = 101.1;
            ISupportsRangeValuePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetRangeValuePattern(new PatternsData() { RangeValuePattern_LargeChange = expectedValue }) }) as ISupportsRangeValuePattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.LargeChange);
        }
        
        [Test]
        public void RangeValue_Maximum()
        {
            // Arrange
            double expectedValue = 1001.2;
            ISupportsRangeValuePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetRangeValuePattern(new PatternsData() { RangeValuePattern_Maximum = expectedValue }) }) as ISupportsRangeValuePattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.Maximum);
        }
        
        [Test]
        public void RangeValue_Minimum()
        {
            // Arrange
            double expectedValue = 15.3;
            ISupportsRangeValuePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetRangeValuePattern(new PatternsData() { RangeValuePattern_Minimum = expectedValue }) }) as ISupportsRangeValuePattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.Minimum);
        }
        
        [Test]
        public void RangeValue_SmallChange()
        {
            // Arrange
            double expectedValue = 5.4;
            ISupportsRangeValuePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetRangeValuePattern(new PatternsData() { RangeValuePattern_SmallChange = expectedValue }) }) as ISupportsRangeValuePattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.SmallChange);
        }
        
        [Test]
        public void RangeValue_RangeValue()
        {
            // Arrange
            double expectedValue = 3.5;
            ISupportsRangeValuePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetRangeValuePattern(new PatternsData() { RangeValuePattern_Value = expectedValue }) }) as ISupportsRangeValuePattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.RangeValue);
        }
    }
}
