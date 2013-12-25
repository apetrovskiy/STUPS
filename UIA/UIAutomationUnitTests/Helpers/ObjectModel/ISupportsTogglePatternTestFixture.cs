/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 12/21/2013
 * Time: 1:23 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.ObjectModel
{
    using System.Windows.Automation;
    using UIAutomation;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of ISupportsTogglePatternTestFixture.
    /// </summary>
    [TestFixture]
    // [Ignore("not yet ready")]
    public class ISupportsTogglePatternTestFixture
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
        public void Toggle_ImplementsCommonPattern()
        {
            ISupportsInvokePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTogglePattern(new PatternsData()) }) as ISupportsInvokePattern;
            
            Assert.IsNotNull(element as ISupportsInvokePattern);
        }
        
        [Test]
        public void Toggle_ImplementsPattern()
        {
            ISupportsTogglePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTogglePattern(new PatternsData()) }) as ISupportsTogglePattern;
            
            Assert.IsNotNull(element as ISupportsTogglePattern);
        }
        
        [Test]
        public void Toggle_DoesNotImplementOtherPatterns()
        {
            ISupportsValuePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTogglePattern(new PatternsData()) }) as ISupportsValuePattern;
            
            Assert.IsNull(element as ISupportsValuePattern);
        }
        
        [Test]
        public void Toggle_Toggle()
        {
            // Arrange
            ISupportsTogglePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTogglePattern(new PatternsData()) }) as ISupportsTogglePattern;
            
            // Act
            // Assert
            element.Toggle();
        }
        
        [Test]
        public void Toggle_ToggleState_Indeterminate()
        {
            // Arrange
            ToggleState expectedValue = ToggleState.Indeterminate;
            ISupportsTogglePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTogglePattern(new PatternsData() { TogglePattern_ToggleState = expectedValue }) }) as ISupportsTogglePattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.ToggleState);
        }
        
        [Test]
        public void Toggle_ToggleState_Off()
        {
            // Arrange
            ToggleState expectedValue = ToggleState.Off;
            ISupportsTogglePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTogglePattern(new PatternsData() { TogglePattern_ToggleState = expectedValue }) }) as ISupportsTogglePattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.ToggleState);
        }
        
        [Test]
        public void Toggle_ToggleState_On()
        {
            // Arrange
            ToggleState expectedValue = ToggleState.On;
            ISupportsTogglePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTogglePattern(new PatternsData() { TogglePattern_ToggleState = expectedValue }) }) as ISupportsTogglePattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.ToggleState);
        }
    }
}
