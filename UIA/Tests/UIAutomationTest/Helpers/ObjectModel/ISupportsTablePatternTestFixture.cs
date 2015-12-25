/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/7/2014
 * Time: 5:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Helpers.ObjectModel
{
    /// <summary>
    /// Description of ISupportsTablePatternTestFixture.
    /// </summary>
    // [MbUnit.Framework.Ignore][NUnit.Framework.Ignore]
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class ISupportsTablePatternTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void TearDown()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Table_ImplementsCommonPattern()
//        {
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
//            
//            ISupportsHighlighter highlightableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData()) }) as ISupportsHighlighter;
//            
//            Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
//            
//            ISupportsNavigation navigatableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData()) }) as ISupportsNavigation;
//            
//            Assert.IsNotNull(navigatableElement as ISupportsNavigation);
//            
//            ISupportsConversion conversibleElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData()) }) as ISupportsConversion;
//            
//            Assert.IsNotNull(conversibleElement as ISupportsConversion);
//            
//            ISupportsRefresh refreshableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData()) }) as ISupportsRefresh;
//            
//            Assert.IsNotNull(refreshableElement as ISupportsRefresh);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Table_ImplementsExportPattern()
//        {
//            ISupportsExport exportableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsExport;
//            
//            Assert.IsNotNull(exportableElement as ISupportsExport);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Table_ImplementsPatternInQuestion()
//        {
//            ISupportsTablePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData()) }) as ISupportsTablePattern;
//            
//            Assert.IsNotNull(element as ISupportsTablePattern);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Table_DoesNotImplementOtherPatterns()
//        {
//            ISupportsValuePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData()) }) as ISupportsValuePattern;
//            
//            Assert.IsNull(element as ISupportsValuePattern);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Table_GetColumnHeaders()
//        {
//            // Arrange
//            bool expectedResult = true;
//            bool result = false;
//            ISupportsTablePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData()) }) as ISupportsTablePattern;
//            
//            // Act
//            element.GetColumnHeaders();
//            try {
//                (element as IUiElement).GetCurrentPattern<ITablePattern>(TablePattern.Pattern).Current.Received(1).GetColumnHeaders();
//                result = true;
//            }
//            catch {}
//            
//            // Assert
//            Assert.AreEqual(expectedResult, result);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Table_GetRowHeaders()
//        {
//            // Arrange
//            bool expectedResult = true;
//            bool result = false;
//            ISupportsTablePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData()) }) as ISupportsTablePattern;
//            
//            // Act
//            element.GetRowHeaders();
//            try {
//                (element as IUiElement).GetCurrentPattern<ITablePattern>(TablePattern.Pattern).Current.Received(1).GetRowHeaders();
//                result = true;
//            }
//            catch {}
//            
//            // Assert
//            Assert.AreEqual(expectedResult, result);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Table_TableColumnCount()
//        {
//            // Arrange
//            int expectedValue = 7;
//            ISupportsTablePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData() { TablePattern_ColumnCount = expectedValue }) }) as ISupportsTablePattern;
//            
//            // Act
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.TableColumnCount);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Table_TableRowCount()
//        {
//            // Arrange
//            int expectedValue = 8;
//            ISupportsTablePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData() { TablePattern_RowCount = expectedValue }) }) as ISupportsTablePattern;
//            
//            // Act
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.TableRowCount);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Table_RowOrColumnMajor()
//        {
//            // Arrange
//            RowOrColumnMajor expectedValue = RowOrColumnMajor.ColumnMajor;
//            ISupportsTablePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData() { TablePattern_RowOrColumnMajor = expectedValue }) }) as ISupportsTablePattern;
//            
//            // Act
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.RowOrColumnMajor);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [Ignore("not yet ready")]
//        public void Table_ExportToCsv()
//        {
//            // Arrange
//            // int expectedValue = 4;
//            ISupportsExport element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsExport;
//            
//            // Act
//            
//            // Assert
//            element.ExportToCsv();
//        }
    }
}
