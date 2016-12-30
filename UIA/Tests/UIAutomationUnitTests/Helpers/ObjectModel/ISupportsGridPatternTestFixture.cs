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
    using MbUnit.Framework;using Xunit;using NUnit.Framework;

    /// <summary>
    /// Description of ISupportsGridPatternTestFixture.
    /// </summary>
    [MbUnit.Framework.Parallelizable(TestScope.All)]
    [NUnit.Framework.Parallelizable(ParallelScope.Fixtures)]
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class ISupportsGridPatternTestFixture
    {
        public ISupportsGridPatternTestFixture()
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
        public void Grid_ImplementsCommonPattern()
        {
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            MbUnit.Framework.Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
            
            var highlightableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsHighlighter;
            
            MbUnit.Framework.Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
            Xunit.Assert.NotNull(highlightableElement as ISupportsHighlighter);
            
            var navigatableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsNavigation;
            
            MbUnit.Framework.Assert.IsNotNull(navigatableElement as ISupportsNavigation);
            Xunit.Assert.NotNull(navigatableElement as ISupportsNavigation);
            
            var conversibleElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsConversion;
            
            MbUnit.Framework.Assert.IsNotNull(conversibleElement as ISupportsConversion);
            Xunit.Assert.NotNull(conversibleElement as ISupportsConversion);
            
            var refreshableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsRefresh;
            
            MbUnit.Framework.Assert.IsNotNull(refreshableElement as ISupportsRefresh);
            Xunit.Assert.NotNull(refreshableElement as ISupportsRefresh);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Grid_ImplementsExportPattern()
        {
            var exportableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsExport;
            
            MbUnit.Framework.Assert.IsNotNull(exportableElement as ISupportsExport);
            Xunit.Assert.NotNull(exportableElement as ISupportsExport);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Grid_ImplementsPatternInQuestion()
        {
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsGridPattern;
            
            MbUnit.Framework.Assert.IsNotNull(element as ISupportsGridPattern);
            Xunit.Assert.NotNull(element as ISupportsGridPattern);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Grid_DoesNotImplementOtherPatterns()
        {
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsValuePattern;
            
            MbUnit.Framework.Assert.IsNull(element as ISupportsValuePattern);
            Xunit.Assert.Null(element as ISupportsValuePattern);
        }
        
//        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Grid_GetItem()
//        {
//            // Arrange
//            ISupportsGridPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsGridPattern;
//            
//            // Act
//            
//            // Assert
//            element.GetItem(1, 1);
//        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Grid_ColumnCount()
        {
            // Arrange
            const int expectedValue = 3;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData() { GridPattern_ColumnCount = expectedValue }) }) as ISupportsGridPattern;
            
            // Act
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.GridColumnCount);
            Xunit.Assert.Equal(expectedValue, element.GridColumnCount);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Grid_RowCount()
        {
            // Arrange
            const int expectedValue = 4;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData() { GridPattern_RowCount = expectedValue }) }) as ISupportsGridPattern;
            
            // Act
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.GridRowCount);
            Xunit.Assert.Equal(expectedValue, element.GridRowCount);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Grid_GetItem()
        {
            // Arrange
            ControlType expectedControlType = ControlType.Document;
            const string expectedName = "control name";
            const string expectedAutomationId = "au Id";
            const string expectedClassName = "control name";
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridPattern(
                        new PatternsData() {
                            GridPattern_GetItem_Name = expectedName,
                            GridPattern_GetItem_AutomationId = expectedAutomationId,
                            GridPattern_GetItem_Class = expectedClassName,
                            GridPattern_GetItem_ControlType = expectedControlType
                        }) }) as ISupportsGridPattern;
            
            // Act
            IUiElement gottenElement = element.GetItem(1, 1);
            
            // Assert
            // 20140312
//            MbUnit.Framework.Assert.AreEqual(expectedControlType, gottenElement.Current.ControlType);
//            MbUnit.Framework.Assert.AreEqual(expectedName, gottenElement.Current.Name);
//            MbUnit.Framework.Assert.AreEqual(expectedAutomationId, gottenElement.Current.AutomationId);
//            MbUnit.Framework.Assert.AreEqual(expectedClassName, gottenElement.Current.ClassName);
//            
//            Xunit.Assert.Equal(expectedControlType, gottenElement.Current.ControlType);
//            Xunit.Assert.Equal(expectedName, gottenElement.Current.Name);
//            Xunit.Assert.Equal(expectedAutomationId, gottenElement.Current.AutomationId);
//            Xunit.Assert.Equal(expectedClassName, gottenElement.Current.ClassName);
            MbUnit.Framework.Assert.AreEqual(expectedControlType, gottenElement.GetCurrent().ControlType);
            MbUnit.Framework.Assert.AreEqual(expectedName, gottenElement.GetCurrent().Name);
            MbUnit.Framework.Assert.AreEqual(expectedAutomationId, gottenElement.GetCurrent().AutomationId);
            MbUnit.Framework.Assert.AreEqual(expectedClassName, gottenElement.GetCurrent().ClassName);
            
            Xunit.Assert.Equal(expectedControlType, gottenElement.GetCurrent().ControlType);
            Xunit.Assert.Equal(expectedName, gottenElement.GetCurrent().Name);
            Xunit.Assert.Equal(expectedAutomationId, gottenElement.GetCurrent().AutomationId);
            Xunit.Assert.Equal(expectedClassName, gottenElement.GetCurrent().ClassName);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        // [Ignore("not yet ready")]
        [MbUnit.Framework.Ignore("not yet ready")]
        [NUnit.Framework.Ignore("not yet ready")]
        public void Grid_ExportToCsv()
        {
            // Arrange
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsExport;
            
            // Act
            
            // Assert
            element.ExportToCsv();
        }
    }
}
