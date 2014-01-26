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
    /// Description of ISupportsTablePatternTestFixture.
    /// </summary>
    // [Ignore]
    [MbUnit.Framework.TestFixture]
    public class ISupportsTablePatternTestFixture
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
//        public void Table_ImplementsCommonPattern()
//        {
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            MbUnit.Framework.Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
//            
//            ISupportsHighlighter highlightableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData()) }) as ISupportsHighlighter;
//            
//            MbUnit.Framework.Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
//            
//            ISupportsNavigation navigatableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData()) }) as ISupportsNavigation;
//            
//            MbUnit.Framework.Assert.IsNotNull(navigatableElement as ISupportsNavigation);
//            
//            ISupportsConversion conversibleElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData()) }) as ISupportsConversion;
//            
//            MbUnit.Framework.Assert.IsNotNull(conversibleElement as ISupportsConversion);
//            
//            ISupportsRefresh refreshableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData()) }) as ISupportsRefresh;
//            
//            MbUnit.Framework.Assert.IsNotNull(refreshableElement as ISupportsRefresh);
//        }
//        
//        [Test]// [Fact]
//        public void Table_ImplementsExportPattern()
//        {
//            ISupportsExport exportableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsExport;
//            
//            MbUnit.Framework.Assert.IsNotNull(exportableElement as ISupportsExport);
//        }
//        
//        [Test]// [Fact]
//        public void Table_ImplementsPatternInQuestion()
//        {
//            ISupportsTablePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData()) }) as ISupportsTablePattern;
//            
//            MbUnit.Framework.Assert.IsNotNull(element as ISupportsTablePattern);
//        }
//        
//        [Test]// [Fact]
//        public void Table_DoesNotImplementOtherPatterns()
//        {
//            ISupportsValuePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData()) }) as ISupportsValuePattern;
//            
//            MbUnit.Framework.Assert.IsNull(element as ISupportsValuePattern);
//        }
//        
//        [Test]// [Fact]
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
//            MbUnit.Framework.Assert.AreEqual(expectedResult, result);
//        }
//        
//        [Test]// [Fact]
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
//            MbUnit.Framework.Assert.AreEqual(expectedResult, result);
//        }
//        
//        [Test]// [Fact]
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
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.TableColumnCount);
//        }
//        
//        [Test]// [Fact]
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
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.TableRowCount);
//        }
//        
//        [Test]// [Fact]
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
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.RowOrColumnMajor);
//        }
//        
//        [Test]// [Fact]
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
