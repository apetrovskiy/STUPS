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
    // using Xunit;

    // using UIAutomationTest;
    
    /// <summary>
    /// Description of ISupportsTableItemPatternTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class ISupportsTableItemPatternTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            // MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void TearDown()
        {
            // MiddleLevelCode.DisposeRunspace();
        }
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void TableItem_ImplementsCommonPattern()
//        {
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            MbUnit.Framework.Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
//            
//            ISupportsHighlighter highlightableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData()) }) as ISupportsHighlighter;
//            
//            MbUnit.Framework.Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
//            
//            ISupportsNavigation navigatableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData()) }) as ISupportsNavigation;
//            
//            MbUnit.Framework.Assert.IsNotNull(navigatableElement as ISupportsNavigation);
//            
//            ISupportsConversion conversibleElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData()) }) as ISupportsConversion;
//            
//            MbUnit.Framework.Assert.IsNotNull(conversibleElement as ISupportsConversion);
//            
//            ISupportsRefresh refreshableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData()) }) as ISupportsRefresh;
//            
//            MbUnit.Framework.Assert.IsNotNull(refreshableElement as ISupportsRefresh);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void TableItem_ImplementsPatternInQuestion()
//        {
//            ISupportsTableItemPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData()) }) as ISupportsTableItemPattern;
//            
//            MbUnit.Framework.Assert.IsNotNull(element as ISupportsTableItemPattern);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void TableItem_DoesNotImplementOtherPatterns()
//        {
//            ISupportsValuePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData()) }) as ISupportsValuePattern;
//            
//            MbUnit.Framework.Assert.IsNull(element as ISupportsValuePattern);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
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
//            MbUnit.Framework.Assert.AreEqual(expectedResult, result);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
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
//            MbUnit.Framework.Assert.AreEqual(expectedResult, result);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
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
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.TableColumn);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
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
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.TableColumnSpan);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
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
//            MbUnit.Framework.Assert.AreEqual(expectedValue.Current.Name, element.TableContainingGrid.Current.Name);
//            MbUnit.Framework.Assert.AreEqual(expectedValue.Current.AutomationId, element.TableContainingGrid.Current.AutomationId);
//            MbUnit.Framework.Assert.AreEqual(expectedValue.Current.ClassName, element.TableContainingGrid.Current.ClassName);
//            MbUnit.Framework.Assert.AreEqual(expectedValue.Current.ControlType, element.TableContainingGrid.Current.ControlType);
//            MbUnit.Framework.Assert.AreEqual(expectedValue.Current.BoundingRectangle, element.TableContainingGrid.Current.BoundingRectangle);
//            MbUnit.Framework.Assert.AreEqual(expectedValue.Current.NativeWindowHandle, element.TableContainingGrid.Current.NativeWindowHandle);
//            MbUnit.Framework.Assert.AreEqual(expectedValue.Current.ProcessId, element.TableContainingGrid.Current.ProcessId);
//            MbUnit.Framework.Assert.AreEqual(expectedValue.Current.IsEnabled, element.TableContainingGrid.Current.IsEnabled);
//            MbUnit.Framework.Assert.AreEqual(expectedValue.Current.IsOffscreen, element.TableContainingGrid.Current.IsOffscreen);
//            MbUnit.Framework.Assert.AreEqual(expectedValue.Current.AcceleratorKey, element.TableContainingGrid.Current.AcceleratorKey);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
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
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.TableRow);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
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
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.TableRowSpan);
//        }
    }
}
