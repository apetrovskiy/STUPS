/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 12/22/2013
 * Time: 2:49 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.ObjectModel
{
    using System.Windows.Automation;
    using UIAutomation;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of ISupportsGridPatternTestFixture.
    /// </summary>
    // [Ignore]
    [TestFixture]
    public class ISupportsGridPatternTestFixture
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
        public void Grid_ImplementsCommonPattern()
        {
            ISupportsInvokePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsInvokePattern;
            
            Assert.IsNotNull(element as ISupportsInvokePattern);
        }
        
        [Test]
        public void Grid_ImplementsPattern()
        {
            ISupportsGridPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsGridPattern;
            
            Assert.IsNotNull(element as ISupportsGridPattern);
        }
        
        [Test]
        public void Grid_DoesNotImplementOtherPatterns()
        {
            ISupportsValuePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsValuePattern;
            
            Assert.IsNull(element as ISupportsValuePattern);
        }
        
        [Test]
        public void Grid_GetItem()
        {
            // Arrange
            ISupportsGridPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsGridPattern;
            
            // Act
            
            // Assert
            element.GetItem(1, 1);
        }
        
        [Test]
        public void Grid_ColumnCount()
        {
            // Arrange
            int expectedValue = 3;
            ISupportsGridPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData() { GridPattern_ColumnCount = expectedValue }) }) as ISupportsGridPattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.GridColumnCount);
        }
        
        [Test]
        public void Grid_RowCount()
        {
            // Arrange
            int expectedValue = 4;
            ISupportsGridPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData() { GridPattern_RowCount = expectedValue }) }) as ISupportsGridPattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.GridRowCount);
        }
    }
}
