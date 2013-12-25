/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
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
    /// Description of ISupportsTablePatternTestFixture.
    /// </summary>
    // [Ignore]
    [TestFixture]
    public class ISupportsTablePatternTestFixture
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
        public void Table_ImplementsCommonPattern()
        {
            ISupportsInvokePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData()) }) as ISupportsInvokePattern;
            
            Assert.IsNotNull(element as ISupportsInvokePattern);
        }
        
        [Test]
        public void Table_ImplementsPattern()
        {
            ISupportsTablePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData()) }) as ISupportsTablePattern;
            
            Assert.IsNotNull(element as ISupportsTablePattern);
        }
        
        [Test]
        public void Table_DoesNotImplementOtherPatterns()
        {
            ISupportsValuePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData()) }) as ISupportsValuePattern;
            
            Assert.IsNull(element as ISupportsValuePattern);
        }
        
        [Test]
        public void Table_GetColumnHeaders()
        {
            // Arrange
            ISupportsTablePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData()) }) as ISupportsTablePattern;
            
            // Act
            // Assert
            element.GetColumnHeaders();
        }
        
        [Test]
        public void Table_GetRowHeaders()
        {
            // Arrange
            ISupportsTablePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData()) }) as ISupportsTablePattern;
            
            // Act
            // Assert
            element.GetRowHeaders();
        }
        
        [Test]
        public void Table_TableColumnCount()
        {
            // Arrange
            int expectedValue = 7;
            ISupportsTablePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData() { TablePattern_ColumnCount = expectedValue }) }) as ISupportsTablePattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.TableColumnCount);
        }
        
        [Test]
        public void Table_TableRowCount()
        {
            // Arrange
            int expectedValue = 8;
            ISupportsTablePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData() { TablePattern_RowCount = expectedValue }) }) as ISupportsTablePattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.TableRowCount);
        }
        
        [Test]
        public void Table_RowOrColumnMajor()
        {
            // Arrange
            RowOrColumnMajor expectedValue = RowOrColumnMajor.ColumnMajor;
            ISupportsTablePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData() { TablePattern_RowOrColumnMajor = expectedValue }) }) as ISupportsTablePattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.RowOrColumnMajor);
        }
    }
}
