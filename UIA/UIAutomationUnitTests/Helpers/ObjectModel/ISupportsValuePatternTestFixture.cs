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
            ISupportsInvokePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetValuePattern(new PatternsData()) }) as ISupportsInvokePattern;
            
            Assert.IsNotNull(element as ISupportsInvokePattern);
        }
        
        [Test]
        public void Value_ImplementsPattern()
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
            const string expectedValue = "abc";
            ISupportsValuePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    // new IBasePattern[] { FakeFactory.GetValuePattern(new PatternsData() { ValuePattern_Value = expectedValue }) }) as ISupportsValuePattern;
                    new IBasePattern[] { FakeFactory.GetValuePattern(new PatternsData()) }) as ISupportsValuePattern;
            
            // Act
            element.Value = expectedValue;
            
            // Assert
            Assert.AreEqual(expectedValue, element.Value);
        }
    }
}
