/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/22/2013
 * Time: 2:48 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.ObjectModel
{
    using UIAutomation;
    using MbUnit.Framework;using Xunit;using NUnit.Framework;
    
    /// <summary>
    /// Description of ISupportsGridItemPatternTestFixture.
    /// </summary>
    [MbUnit.Framework.Parallelizable(TestScope.All)]
    [NUnit.Framework.Parallelizable(ParallelScope.Fixtures)]
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class ISupportsGridItemPatternTestFixture
    {
        public ISupportsGridItemPatternTestFixture()
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
        public void GridItem_ImplementsCommonPattern()
        {
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            MbUnit.Framework.Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
            
            var highlightableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData()) }) as ISupportsHighlighter;
            
            MbUnit.Framework.Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
            Xunit.Assert.NotNull(highlightableElement as ISupportsHighlighter);
            
            var navigatableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData()) }) as ISupportsNavigation;
            
            MbUnit.Framework.Assert.IsNotNull(navigatableElement as ISupportsNavigation);
            Xunit.Assert.NotNull(navigatableElement as ISupportsNavigation);
            
            var conversibleElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData()) }) as ISupportsConversion;
            
            MbUnit.Framework.Assert.IsNotNull(conversibleElement as ISupportsConversion);
            Xunit.Assert.NotNull(conversibleElement as ISupportsConversion);
            
            var refreshableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData()) }) as ISupportsRefresh;
            
            MbUnit.Framework.Assert.IsNotNull(refreshableElement as ISupportsRefresh);
            Xunit.Assert.NotNull(refreshableElement as ISupportsRefresh);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void GridItem_ImplementsPatternInQuestion()
        {
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData()) }) as ISupportsGridItemPattern;
            
            MbUnit.Framework.Assert.IsNotNull(element as ISupportsGridItemPattern);
            Xunit.Assert.NotNull(element as ISupportsGridItemPattern);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void GridItem_DoesNotImplementOtherPatterns()
        {
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData()) }) as ISupportsValuePattern;
            
            MbUnit.Framework.Assert.IsNull(element as ISupportsValuePattern);
            Xunit.Assert.Null(element as ISupportsValuePattern);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void GridItem_GridColumn()
        {
            // Arrange
            const int expectedValue = 3;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData() { GridItemPattern_Column = expectedValue }) }) as ISupportsGridItemPattern;
            
            // Act
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.GridColumn);
            Xunit.Assert.Equal(expectedValue, element.GridColumn);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void GridItem_ColumnSpan()
        {
            // Arrange
            const int expectedValue = 4;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData() { GridItemPattern_ColumnSpan = expectedValue }) }) as ISupportsGridItemPattern;
            
            // Act
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.GridColumnSpan);
            Xunit.Assert.Equal(expectedValue, element.GridColumnSpan);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        // [Ignore]
        [MbUnit.Framework.Ignore]
        [NUnit.Framework.Ignore("")]
        public void GridItem_ContainingGrid()
        {
            // Arrange
            IUiElement expectedValue = new UiElement();
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData() { GridItemPattern_ContainingGrid = expectedValue }) }) as ISupportsGridItemPattern;
            
            // Act
            
            // Assert
            // Assert.AreEqual(expectedValue as IUiElement, element.GridContainingGrid as IUiElement);
            // 20140312
//            MbUnit.Framework.Assert.AreEqual(expectedValue.Current.Name, element.GridContainingGrid.Current.Name);
//            MbUnit.Framework.Assert.AreEqual(expectedValue.Current.AutomationId, element.GridContainingGrid.Current.AutomationId);
//            MbUnit.Framework.Assert.AreEqual(expectedValue.Current.ClassName, element.GridContainingGrid.Current.ClassName);
//            MbUnit.Framework.Assert.AreEqual(expectedValue.Current.ControlType, element.GridContainingGrid.Current.ControlType);
//            MbUnit.Framework.Assert.AreEqual(expectedValue.Current.BoundingRectangle, element.GridContainingGrid.Current.BoundingRectangle);
//            MbUnit.Framework.Assert.AreEqual(expectedValue.Current.NativeWindowHandle, element.GridContainingGrid.Current.NativeWindowHandle);
//            MbUnit.Framework.Assert.AreEqual(expectedValue.Current.ProcessId, element.GridContainingGrid.Current.ProcessId);
//            MbUnit.Framework.Assert.AreEqual(expectedValue.Current.IsEnabled, element.GridContainingGrid.Current.IsEnabled);
//            MbUnit.Framework.Assert.AreEqual(expectedValue.Current.IsOffscreen, element.GridContainingGrid.Current.IsOffscreen);
//            MbUnit.Framework.Assert.AreEqual(expectedValue.Current.AcceleratorKey, element.GridContainingGrid.Current.AcceleratorKey);
//            
//            Xunit.Assert.Equal(expectedValue.Current.Name, element.GridContainingGrid.Current.Name);
//            Xunit.Assert.Equal(expectedValue.Current.AutomationId, element.GridContainingGrid.Current.AutomationId);
//            Xunit.Assert.Equal(expectedValue.Current.ClassName, element.GridContainingGrid.Current.ClassName);
//            Xunit.Assert.Equal(expectedValue.Current.ControlType, element.GridContainingGrid.Current.ControlType);
//            Xunit.Assert.Equal(expectedValue.Current.BoundingRectangle, element.GridContainingGrid.Current.BoundingRectangle);
//            Xunit.Assert.Equal(expectedValue.Current.NativeWindowHandle, element.GridContainingGrid.Current.NativeWindowHandle);
//            Xunit.Assert.Equal(expectedValue.Current.ProcessId, element.GridContainingGrid.Current.ProcessId);
//            Xunit.Assert.Equal(expectedValue.Current.IsEnabled, element.GridContainingGrid.Current.IsEnabled);
//            Xunit.Assert.Equal(expectedValue.Current.IsOffscreen, element.GridContainingGrid.Current.IsOffscreen);
//            Xunit.Assert.Equal(expectedValue.Current.AcceleratorKey, element.GridContainingGrid.Current.AcceleratorKey);
            MbUnit.Framework.Assert.AreEqual(expectedValue.GetCurrent().Name, element.GridContainingGrid.GetCurrent().Name);
            MbUnit.Framework.Assert.AreEqual(expectedValue.GetCurrent().AutomationId, element.GridContainingGrid.GetCurrent().AutomationId);
            MbUnit.Framework.Assert.AreEqual(expectedValue.GetCurrent().ClassName, element.GridContainingGrid.GetCurrent().ClassName);
            MbUnit.Framework.Assert.AreEqual(expectedValue.GetCurrent().ControlType, element.GridContainingGrid.GetCurrent().ControlType);
            MbUnit.Framework.Assert.AreEqual(expectedValue.GetCurrent().BoundingRectangle, element.GridContainingGrid.GetCurrent().BoundingRectangle);
            MbUnit.Framework.Assert.AreEqual(expectedValue.GetCurrent().NativeWindowHandle, element.GridContainingGrid.GetCurrent().NativeWindowHandle);
            MbUnit.Framework.Assert.AreEqual(expectedValue.GetCurrent().ProcessId, element.GridContainingGrid.GetCurrent().ProcessId);
            MbUnit.Framework.Assert.AreEqual(expectedValue.GetCurrent().IsEnabled, element.GridContainingGrid.GetCurrent().IsEnabled);
            MbUnit.Framework.Assert.AreEqual(expectedValue.GetCurrent().IsOffscreen, element.GridContainingGrid.GetCurrent().IsOffscreen);
            MbUnit.Framework.Assert.AreEqual(expectedValue.GetCurrent().AcceleratorKey, element.GridContainingGrid.GetCurrent().AcceleratorKey);
            
            Xunit.Assert.Equal(expectedValue.GetCurrent().Name, element.GridContainingGrid.GetCurrent().Name);
            Xunit.Assert.Equal(expectedValue.GetCurrent().AutomationId, element.GridContainingGrid.GetCurrent().AutomationId);
            Xunit.Assert.Equal(expectedValue.GetCurrent().ClassName, element.GridContainingGrid.GetCurrent().ClassName);
            Xunit.Assert.Equal(expectedValue.GetCurrent().ControlType, element.GridContainingGrid.GetCurrent().ControlType);
            Xunit.Assert.Equal(expectedValue.GetCurrent().BoundingRectangle, element.GridContainingGrid.GetCurrent().BoundingRectangle);
            Xunit.Assert.Equal(expectedValue.GetCurrent().NativeWindowHandle, element.GridContainingGrid.GetCurrent().NativeWindowHandle);
            Xunit.Assert.Equal(expectedValue.GetCurrent().ProcessId, element.GridContainingGrid.GetCurrent().ProcessId);
            Xunit.Assert.Equal(expectedValue.GetCurrent().IsEnabled, element.GridContainingGrid.GetCurrent().IsEnabled);
            Xunit.Assert.Equal(expectedValue.GetCurrent().IsOffscreen, element.GridContainingGrid.GetCurrent().IsOffscreen);
            Xunit.Assert.Equal(expectedValue.GetCurrent().AcceleratorKey, element.GridContainingGrid.GetCurrent().AcceleratorKey);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void GridItem_Row()
        {
            // Arrange
            const int expectedValue = 5;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData() { GridItemPattern_Row = expectedValue }) }) as ISupportsGridItemPattern;
            
            // Act
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.GridRow);
            Xunit.Assert.Equal(expectedValue, element.GridRow);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void GridItem_RowSpan()
        {
            // Arrange
            const int expectedValue = 6;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData() { GridItemPattern_RowSpan = expectedValue }) }) as ISupportsGridItemPattern;
            
            // Act
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.GridRowSpan);
            Xunit.Assert.Equal(expectedValue, element.GridRowSpan);
        }
    }
}
