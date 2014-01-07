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
    using System;
    using MbUnit.Framework;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ISupportsTableItemPatternTestFixture.
    /// </summary>
    // [Ignore]
    [TestFixture]
    public class ISupportsTableItemPatternTestFixture
    {
        [SetUp]
        public void SetUp()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [TearDown]
        public void TearDown()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
//        [Test]
//        public void TableItem_ImplementsCommonPattern()
//        {
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
//            
//            ISupportsHighlighter highlightableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData()) }) as ISupportsHighlighter;
//            
//            Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
//            
//            ISupportsNavigation navigatableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData()) }) as ISupportsNavigation;
//            
//            Assert.IsNotNull(navigatableElement as ISupportsNavigation);
//            
//            ISupportsConversion conversibleElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData()) }) as ISupportsConversion;
//            
//            Assert.IsNotNull(conversibleElement as ISupportsConversion);
//            
//            ISupportsRefresh refreshableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData()) }) as ISupportsRefresh;
//            
//            Assert.IsNotNull(refreshableElement as ISupportsRefresh);
//        }
//        
//        [Test]
//        public void TableItem_ImplementsPatternInQuestion()
//        {
//            ISupportsTableItemPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData()) }) as ISupportsTableItemPattern;
//            
//            Assert.IsNotNull(element as ISupportsTableItemPattern);
//        }
//        
//        [Test]
//        public void TableItem_DoesNotImplementOtherPatterns()
//        {
//            ISupportsValuePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData()) }) as ISupportsValuePattern;
//            
//            Assert.IsNull(element as ISupportsValuePattern);
//        }
//        
//        [Test]
//        public void TableItem_GetColumnHeaderItems()
//        {
//            // Arrange
//            bool expectedResult = true;
//            bool result = false;
//            ISupportsTableItemPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData()) }) as ISupportsTableItemPattern;
//            
//            // Act
//            element.GetColumnHeaderItems();
//            try {
//                (element as IUiElement).GetCurrentPattern<ITableItemPattern>(TableItemPattern.Pattern).Current.Received(1).GetColumnHeaderItems();
//                result = true;
//            }
//            catch {}
//            
//            // Assert
//            Assert.AreEqual(expectedResult, result);
//        }
//        
//        [Test]
//        public void TableItem_GetRowHeaderItems()
//        {
//            // Arrange
//            bool expectedResult = true;
//            bool result = false;
//            ISupportsTableItemPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData()) }) as ISupportsTableItemPattern;
//            
//            // Act
//            element.GetRowHeaderItems();
//            try {
//                var resultData = (element as IUiElement).GetCurrentPattern<ITableItemPattern>(TableItemPattern.Pattern).Current.Received(1).GetRowHeaderItems();
//                result = true;
//            }
//            catch {}
//            
//            // Assert
//            Assert.AreEqual(expectedResult, result);
//        }
//        
//        [Test]
//        public void TableItem_TableColumn()
//        {
//            // Arrange
//            int expectedValue = 3;
//            ISupportsTableItemPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData() { TableItemPattern_Column = expectedValue }) }) as ISupportsTableItemPattern;
//            
//            // Act
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.TableColumn);
//        }
//        
//        [Test]
//        public void TableItem_TableColumnSpan()
//        {
//            // Arrange
//            int expectedValue = 4;
//            ISupportsTableItemPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData() { TableItemPattern_ColumnSpan = expectedValue }) }) as ISupportsTableItemPattern;
//            
//            // Act
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.TableColumnSpan);
//        }
//        
//        [Test]
//        [Ignore]
//        public void TableItem_TableContainingGrid()
//        {
//            // Arrange
//            IUiElement expectedValue = new UiElement();
//            ISupportsTableItemPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData() { TableItemPattern_ContainingGrid = expectedValue }) }) as ISupportsTableItemPattern;
//            
//            // Act
//            
//            // Assert
//            // Assert.AreEqual(expectedValue as IUiElement, element.TableContainingGrid as IUiElement);
//            Assert.AreEqual(expectedValue.Current.Name, element.TableContainingGrid.Current.Name);
//            Assert.AreEqual(expectedValue.Current.AutomationId, element.TableContainingGrid.Current.AutomationId);
//            Assert.AreEqual(expectedValue.Current.ClassName, element.TableContainingGrid.Current.ClassName);
//            Assert.AreEqual(expectedValue.Current.ControlType, element.TableContainingGrid.Current.ControlType);
//            Assert.AreEqual(expectedValue.Current.BoundingRectangle, element.TableContainingGrid.Current.BoundingRectangle);
//            Assert.AreEqual(expectedValue.Current.NativeWindowHandle, element.TableContainingGrid.Current.NativeWindowHandle);
//            Assert.AreEqual(expectedValue.Current.ProcessId, element.TableContainingGrid.Current.ProcessId);
//            Assert.AreEqual(expectedValue.Current.IsEnabled, element.TableContainingGrid.Current.IsEnabled);
//            Assert.AreEqual(expectedValue.Current.IsOffscreen, element.TableContainingGrid.Current.IsOffscreen);
//            Assert.AreEqual(expectedValue.Current.AcceleratorKey, element.TableContainingGrid.Current.AcceleratorKey);
//        }
//        
//        [Test]
//        public void TableItem_TableRow()
//        {
//            // Arrange
//            int expectedValue = 5;
//            ISupportsTableItemPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData() { TableItemPattern_Row = expectedValue }) }) as ISupportsTableItemPattern;
//            
//            // Act
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.TableRow);
//        }
//        
//        [Test]
//        public void TableItem_TableRowSpan()
//        {
//            // Arrange
//            int expectedValue = 6;
//            ISupportsTableItemPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData() { TableItemPattern_RowSpan = expectedValue }) }) as ISupportsTableItemPattern;
//            
//            // Act
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.TableRowSpan);
//        }
    }
}
