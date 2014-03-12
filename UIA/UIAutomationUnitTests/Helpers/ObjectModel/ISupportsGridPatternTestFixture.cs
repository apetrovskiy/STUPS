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
    using MbUnit.Framework;using Xunit;
    using NSubstitute;
    
    /// <summary>
    /// Description of ISupportsGridPatternTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture]
    public class ISupportsGridPatternTestFixture
    {
        public ISupportsGridPatternTestFixture()
        {
            FakeFactory.Init();
        }
        
        [SetUp]
        public void SetUp()
        {
            FakeFactory.Init();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
        [Test][Fact]
        public void Grid_ImplementsCommonPattern()
        {
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            MbUnit.Framework.Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
            
            ISupportsHighlighter highlightableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsHighlighter;
            
            MbUnit.Framework.Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
            Xunit.Assert.NotNull(highlightableElement as ISupportsHighlighter);
            
            ISupportsNavigation navigatableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsNavigation;
            
            MbUnit.Framework.Assert.IsNotNull(navigatableElement as ISupportsNavigation);
            Xunit.Assert.NotNull(navigatableElement as ISupportsNavigation);
            
            ISupportsConversion conversibleElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsConversion;
            
            MbUnit.Framework.Assert.IsNotNull(conversibleElement as ISupportsConversion);
            Xunit.Assert.NotNull(conversibleElement as ISupportsConversion);
            
            ISupportsRefresh refreshableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsRefresh;
            
            MbUnit.Framework.Assert.IsNotNull(refreshableElement as ISupportsRefresh);
            Xunit.Assert.NotNull(refreshableElement as ISupportsRefresh);
        }
        
        [Test][Fact]
        public void Grid_ImplementsExportPattern()
        {
            ISupportsExport exportableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsExport;
            
            MbUnit.Framework.Assert.IsNotNull(exportableElement as ISupportsExport);
            Xunit.Assert.NotNull(exportableElement as ISupportsExport);
        }
        
        [Test][Fact]
        public void Grid_ImplementsPatternInQuestion()
        {
            ISupportsGridPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsGridPattern;
            
            MbUnit.Framework.Assert.IsNotNull(element as ISupportsGridPattern);
            Xunit.Assert.NotNull(element as ISupportsGridPattern);
        }
        
        [Test][Fact]
        public void Grid_DoesNotImplementOtherPatterns()
        {
            ISupportsValuePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsValuePattern;
            
            MbUnit.Framework.Assert.IsNull(element as ISupportsValuePattern);
            Xunit.Assert.Null(element as ISupportsValuePattern);
        }
        
//        [Test][Fact]
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
        
        [Test][Fact]
        public void Grid_ColumnCount()
        {
            // Arrange
            const int expectedValue = 3;
            ISupportsGridPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData() { GridPattern_ColumnCount = expectedValue }) }) as ISupportsGridPattern;
            
            // Act
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.GridColumnCount);
            Xunit.Assert.Equal(expectedValue, element.GridColumnCount);
        }
        
        [Test][Fact]
        public void Grid_RowCount()
        {
            // Arrange
            const int expectedValue = 4;
            ISupportsGridPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData() { GridPattern_RowCount = expectedValue }) }) as ISupportsGridPattern;
            
            // Act
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.GridRowCount);
            Xunit.Assert.Equal(expectedValue, element.GridRowCount);
        }
        
        [Test][Fact]
        public void Grid_GetItem()
        {
            // Arrange
            ControlType expectedControlType = ControlType.Document;
            const string expectedName = "control name";
            const string expectedAutomationId = "au Id";
            const string expectedClassName = "control name";
            ISupportsGridPattern element =
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
        
        [Test]// [Fact]
        [Ignore("not yet ready")]
        public void Grid_ExportToCsv()
        {
            // Arrange
            ISupportsExport element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsExport;
            
            // Act
            
            // Assert
            element.ExportToCsv();
        }
    }
}
