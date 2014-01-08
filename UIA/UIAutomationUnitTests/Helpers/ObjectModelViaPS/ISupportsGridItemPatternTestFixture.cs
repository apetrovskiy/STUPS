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
    using MbUnit.Framework;
    using System.Management.Automation;
    using NSubstitute;
    using UIAutomation;
    // using UIAutomationTest;
    
    /// <summary>
    /// Description of ISupportsGridItemPatternTestFixture.
    /// </summary>
    // [Ignore]
    [TestFixture]
    public class ISupportsGridItemPatternTestFixture
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
        
//        [Test]
//        public void GridItem_ImplementsCommonPattern()
//        {
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
//            
//            ISupportsHighlighter highlightableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData()) }) as ISupportsHighlighter;
//            
//            Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
//            
//            ISupportsNavigation navigatableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData()) }) as ISupportsNavigation;
//            
//            Assert.IsNotNull(navigatableElement as ISupportsNavigation);
//            
//            ISupportsConversion conversibleElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData()) }) as ISupportsConversion;
//            
//            Assert.IsNotNull(conversibleElement as ISupportsConversion);
//            
//            ISupportsRefresh refreshableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData()) }) as ISupportsRefresh;
//            
//            Assert.IsNotNull(refreshableElement as ISupportsRefresh);
//        }
//        
//        [Test]
//        public void GridItem_ImplementsPatternInQuestion()
//        {
//            ISupportsGridItemPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData()) }) as ISupportsGridItemPattern;
//            
//            Assert.IsNotNull(element as ISupportsGridItemPattern);
//        }
//        
//        [Test]
//        public void GridItem_DoesNotImplementOtherPatterns()
//        {
//            ISupportsValuePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData()) }) as ISupportsValuePattern;
//            
//            Assert.IsNull(element as ISupportsValuePattern);
//        }
//        
//        [Test]
//        public void GridItem_GridColumn()
//        {
//            // Arrange
//            int expectedValue = 3;
//            ISupportsGridItemPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData() { GridItemPattern_Column = expectedValue }) }) as ISupportsGridItemPattern;
//            
//            // Act
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.GridColumn);
//        }
//        
//        [Test]
//        public void GridItem_ColumnSpan()
//        {
//            // Arrange
//            int expectedValue = 4;
//            ISupportsGridItemPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData() { GridItemPattern_ColumnSpan = expectedValue }) }) as ISupportsGridItemPattern;
//            
//            // Act
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.GridColumnSpan);
//        }
//        
//        [Test]
//        [Ignore]
//        public void GridItem_ContainingGrid()
//        {
//            // Arrange
//            IUiElement expectedValue = new UiElement();
//            ISupportsGridItemPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData() { GridItemPattern_ContainingGrid = expectedValue }) }) as ISupportsGridItemPattern;
//            
//            // Act
//            
//            // Assert
//            // Assert.AreEqual(expectedValue as IUiElement, element.GridContainingGrid as IUiElement);
//            Assert.AreEqual(expectedValue.Current.Name, element.GridContainingGrid.Current.Name);
//            Assert.AreEqual(expectedValue.Current.AutomationId, element.GridContainingGrid.Current.AutomationId);
//            Assert.AreEqual(expectedValue.Current.ClassName, element.GridContainingGrid.Current.ClassName);
//            Assert.AreEqual(expectedValue.Current.ControlType, element.GridContainingGrid.Current.ControlType);
//            Assert.AreEqual(expectedValue.Current.BoundingRectangle, element.GridContainingGrid.Current.BoundingRectangle);
//            Assert.AreEqual(expectedValue.Current.NativeWindowHandle, element.GridContainingGrid.Current.NativeWindowHandle);
//            Assert.AreEqual(expectedValue.Current.ProcessId, element.GridContainingGrid.Current.ProcessId);
//            Assert.AreEqual(expectedValue.Current.IsEnabled, element.GridContainingGrid.Current.IsEnabled);
//            Assert.AreEqual(expectedValue.Current.IsOffscreen, element.GridContainingGrid.Current.IsOffscreen);
//            Assert.AreEqual(expectedValue.Current.AcceleratorKey, element.GridContainingGrid.Current.AcceleratorKey);
//        }
//        
//        [Test]
//        public void GridItem_Row()
//        {
//            // Arrange
//            int expectedValue = 5;
//            ISupportsGridItemPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData() { GridItemPattern_Row = expectedValue }) }) as ISupportsGridItemPattern;
//            
//            // Act
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.GridRow);
//        }
//        
//        [Test]
//        public void GridItem_RowSpan()
//        {
//            // Arrange
//            int expectedValue = 6;
//            ISupportsGridItemPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridItemPattern(new PatternsData() { GridItemPattern_RowSpan = expectedValue }) }) as ISupportsGridItemPattern;
//            
//            // Act
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.GridRowSpan);
//        }
    }
}
