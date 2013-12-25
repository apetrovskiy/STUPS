/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 12/22/2013
 * Time: 2:51 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.ObjectModel
{
    using System.Windows.Automation;
    using UIAutomation;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of ISupportsSelectionPatternTestFixture.
    /// </summary>
    // [Ignore]
    [TestFixture]
    public class ISupportsSelectionPatternTestFixture
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
        public void Selection_ImplementsCommonPattern()
        {
            ISupportsInvokePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetSelectionPattern(new PatternsData()) }) as ISupportsInvokePattern;
            
            Assert.IsNotNull(element as ISupportsInvokePattern);
        }
        
        [Test]
        public void Selection_ImplementsPattern()
        {
            ISupportsSelectionPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetSelectionPattern(new PatternsData()) }) as ISupportsSelectionPattern;
            
            Assert.IsNotNull(element as ISupportsSelectionPattern);
        }
        
        [Test]
        public void Selection_DoesNotImplementOtherPatterns()
        {
            ISupportsValuePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetSelectionPattern(new PatternsData()) }) as ISupportsValuePattern;
            
            Assert.IsNull(element as ISupportsValuePattern);
        }
        
        [Test]
        public void Selection_GetSelection()
        {
            // Arrange
            ISupportsSelectionPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetSelectionPattern(new PatternsData()) }) as ISupportsSelectionPattern;
            
            // Act
            // Assert
            element.GetSelection();
        }
        
        [Test]
        public void Selection_CanSelectMultiple()
        {
            // Arrange
            bool expectedValue = true;
            ISupportsSelectionPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetSelectionPattern(new PatternsData() { SelectionPattern_CanSelectMultiple = expectedValue }) }) as ISupportsSelectionPattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.CanSelectMultiple);
        }
        
        [Test]
        public void Selection_IsSelectionRequired()
        {
            // Arrange
            bool expectedValue = false;
            ISupportsSelectionPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetSelectionPattern(new PatternsData() { SelectionPattern_IsSelectionRequired = expectedValue }) }) as ISupportsSelectionPattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.IsSelectionRequired);
        }
    }
}
