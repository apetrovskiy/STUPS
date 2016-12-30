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
    using Xunit;
    using NSubstitute;
    
    /// <summary>
    /// Description of ISupportsTableItemPatternTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class ISupportsTableItemPatternTestFixture
    {
        public ISupportsTableItemPatternTestFixture()
        {
            FakeFactory.Init();
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            FakeFactory.Init();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void TearDown()
        {
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void TableItem_ImplementsCommonPattern()
        {
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            MbUnit.Framework.Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
            
            var highlightableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData()) }) as ISupportsHighlighter;
            
            MbUnit.Framework.Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
            Assert.NotNull(highlightableElement as ISupportsHighlighter);
            
            var navigatableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData()) }) as ISupportsNavigation;
            
            MbUnit.Framework.Assert.IsNotNull(navigatableElement as ISupportsNavigation);
            Assert.NotNull(navigatableElement as ISupportsNavigation);
            
            var conversibleElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData()) }) as ISupportsConversion;
            
            MbUnit.Framework.Assert.IsNotNull(conversibleElement as ISupportsConversion);
            Assert.NotNull(conversibleElement as ISupportsConversion);
            
            var refreshableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData()) }) as ISupportsRefresh;
            
            MbUnit.Framework.Assert.IsNotNull(refreshableElement as ISupportsRefresh);
            Assert.NotNull(refreshableElement as ISupportsRefresh);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void TableItem_ImplementsPatternInQuestion()
        {
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData()) }) as ISupportsTableItemPattern;
            
            MbUnit.Framework.Assert.IsNotNull(element as ISupportsTableItemPattern);
            Assert.NotNull(element as ISupportsTableItemPattern);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void TableItem_DoesNotImplementOtherPatterns()
        {
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData()) }) as ISupportsValuePattern;
            
            MbUnit.Framework.Assert.IsNull(element as ISupportsValuePattern);
            Assert.Null(element as ISupportsValuePattern);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void TableItem_GetColumnHeaderItems()
        {
            // Arrange
            const bool expectedResult = true;
            bool result = false;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData()) }) as ISupportsTableItemPattern;
            
            // Act
            element.GetColumnHeaderItems();
            try {
                (element as IUiElement).GetCurrentPattern<ITableItemPattern>(TableItemPattern.Pattern).Current.Received(1).GetColumnHeaderItems();
                result = true;
            }
            catch {}
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedResult, result);
            Assert.Equal(expectedResult, result);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void TableItem_GetRowHeaderItems()
        {
            // Arrange
            const bool expectedResult = true;
            bool result = false;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData()) }) as ISupportsTableItemPattern;
            
            // Act
            element.GetRowHeaderItems();
            try {
                var resultData = (element as IUiElement).GetCurrentPattern<ITableItemPattern>(TableItemPattern.Pattern).Current.Received(1).GetRowHeaderItems();
                result = true;
            }
            catch {}
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedResult, result);
            Assert.Equal(expectedResult, result);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void TableItem_TableColumn()
        {
            // Arrange
            const int expectedValue = 3;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData() { TableItemPattern_Column = expectedValue }) }) as ISupportsTableItemPattern;
            
            // Act
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.TableColumn);
            Assert.Equal(expectedValue, element.TableColumn);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void TableItem_TableColumnSpan()
        {
            // Arrange
            const int expectedValue = 4;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData() { TableItemPattern_ColumnSpan = expectedValue }) }) as ISupportsTableItemPattern;
            
            // Act
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.TableColumnSpan);
            Assert.Equal(expectedValue, element.TableColumnSpan);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        // [Ignore]
        [MbUnit.Framework.Ignore]
        [NUnit.Framework.Ignore("")]
        public void TableItem_TableContainingGrid()
        {
            // Arrange
            var expectedValue = new UiElement();
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData() { TableItemPattern_ContainingGrid = expectedValue }) }) as ISupportsTableItemPattern;
            
            // Act
            
            // Assert
            // Assert.AreEqual(expectedValue as IUiElement, element.TableContainingGrid as IUiElement);
            // 20140312
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
//            
//            Xunit.Assert.Equal(expectedValue.Current.Name, element.TableContainingGrid.Current.Name);
//            Xunit.Assert.Equal(expectedValue.Current.AutomationId, element.TableContainingGrid.Current.AutomationId);
//            Xunit.Assert.Equal(expectedValue.Current.ClassName, element.TableContainingGrid.Current.ClassName);
//            Xunit.Assert.Equal(expectedValue.Current.ControlType, element.TableContainingGrid.Current.ControlType);
//            Xunit.Assert.Equal(expectedValue.Current.BoundingRectangle, element.TableContainingGrid.Current.BoundingRectangle);
//            Xunit.Assert.Equal(expectedValue.Current.NativeWindowHandle, element.TableContainingGrid.Current.NativeWindowHandle);
//            Xunit.Assert.Equal(expectedValue.Current.ProcessId, element.TableContainingGrid.Current.ProcessId);
//            Xunit.Assert.Equal(expectedValue.Current.IsEnabled, element.TableContainingGrid.Current.IsEnabled);
//            Xunit.Assert.Equal(expectedValue.Current.IsOffscreen, element.TableContainingGrid.Current.IsOffscreen);
//            Xunit.Assert.Equal(expectedValue.Current.AcceleratorKey, element.TableContainingGrid.Current.AcceleratorKey);
            MbUnit.Framework.Assert.AreEqual(expectedValue.GetCurrent().Name, element.TableContainingGrid.GetCurrent().Name);
            MbUnit.Framework.Assert.AreEqual(expectedValue.GetCurrent().AutomationId, element.TableContainingGrid.GetCurrent().AutomationId);
            MbUnit.Framework.Assert.AreEqual(expectedValue.GetCurrent().ClassName, element.TableContainingGrid.GetCurrent().ClassName);
            MbUnit.Framework.Assert.AreEqual(expectedValue.GetCurrent().ControlType, element.TableContainingGrid.GetCurrent().ControlType);
            MbUnit.Framework.Assert.AreEqual(expectedValue.GetCurrent().BoundingRectangle, element.TableContainingGrid.GetCurrent().BoundingRectangle);
            MbUnit.Framework.Assert.AreEqual(expectedValue.GetCurrent().NativeWindowHandle, element.TableContainingGrid.GetCurrent().NativeWindowHandle);
            MbUnit.Framework.Assert.AreEqual(expectedValue.GetCurrent().ProcessId, element.TableContainingGrid.GetCurrent().ProcessId);
            MbUnit.Framework.Assert.AreEqual(expectedValue.GetCurrent().IsEnabled, element.TableContainingGrid.GetCurrent().IsEnabled);
            MbUnit.Framework.Assert.AreEqual(expectedValue.GetCurrent().IsOffscreen, element.TableContainingGrid.GetCurrent().IsOffscreen);
            MbUnit.Framework.Assert.AreEqual(expectedValue.GetCurrent().AcceleratorKey, element.TableContainingGrid.GetCurrent().AcceleratorKey);
            
            Assert.Equal(expectedValue.GetCurrent().Name, element.TableContainingGrid.GetCurrent().Name);
            Assert.Equal(expectedValue.GetCurrent().AutomationId, element.TableContainingGrid.GetCurrent().AutomationId);
            Assert.Equal(expectedValue.GetCurrent().ClassName, element.TableContainingGrid.GetCurrent().ClassName);
            Assert.Equal(expectedValue.GetCurrent().ControlType, element.TableContainingGrid.GetCurrent().ControlType);
            Assert.Equal(expectedValue.GetCurrent().BoundingRectangle, element.TableContainingGrid.GetCurrent().BoundingRectangle);
            Assert.Equal(expectedValue.GetCurrent().NativeWindowHandle, element.TableContainingGrid.GetCurrent().NativeWindowHandle);
            Assert.Equal(expectedValue.GetCurrent().ProcessId, element.TableContainingGrid.GetCurrent().ProcessId);
            Assert.Equal(expectedValue.GetCurrent().IsEnabled, element.TableContainingGrid.GetCurrent().IsEnabled);
            Assert.Equal(expectedValue.GetCurrent().IsOffscreen, element.TableContainingGrid.GetCurrent().IsOffscreen);
            Assert.Equal(expectedValue.GetCurrent().AcceleratorKey, element.TableContainingGrid.GetCurrent().AcceleratorKey);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void TableItem_TableRow()
        {
            // Arrange
            const int expectedValue = 5;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData() { TableItemPattern_Row = expectedValue }) }) as ISupportsTableItemPattern;
            
            // Act
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.TableRow);
            Assert.Equal(expectedValue, element.TableRow);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void TableItem_TableRowSpan()
        {
            // Arrange
            const int expectedValue = 6;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData() { TableItemPattern_RowSpan = expectedValue }) }) as ISupportsTableItemPattern;
            
            // Act
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.TableRowSpan);
            Assert.Equal(expectedValue, element.TableRowSpan);
        }
    }
}
