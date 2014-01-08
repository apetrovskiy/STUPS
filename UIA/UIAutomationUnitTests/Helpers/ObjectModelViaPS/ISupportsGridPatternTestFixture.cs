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
    /// Description of ISupportsGridPatternTestFixture.
    /// </summary>
    // [Ignore]
    [TestFixture]
    public class ISupportsGridPatternTestFixture
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
//        public void Grid_ImplementsCommonPattern()
//        {
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
//            
//            ISupportsHighlighter highlightableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsHighlighter;
//            
//            Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
//            
//            ISupportsNavigation navigatableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsNavigation;
//            
//            Assert.IsNotNull(navigatableElement as ISupportsNavigation);
//            
//            ISupportsConversion conversibleElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsConversion;
//            
//            Assert.IsNotNull(conversibleElement as ISupportsConversion);
//            
//            ISupportsRefresh refreshableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsRefresh;
//            
//            Assert.IsNotNull(refreshableElement as ISupportsRefresh);
//        }
//        
//        [Test]
//        public void Grid_ImplementsExportPattern()
//        {
//            ISupportsExport exportableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsExport;
//            
//            Assert.IsNotNull(exportableElement as ISupportsExport);
//        }
//        
//        [Test]
//        public void Grid_ImplementsPatternInQuestion()
//        {
//            ISupportsGridPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsGridPattern;
//            
//            Assert.IsNotNull(element as ISupportsGridPattern);
//        }
//        
//        [Test]
//        public void Grid_DoesNotImplementOtherPatterns()
//        {
//            ISupportsValuePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsValuePattern;
//            
//            Assert.IsNull(element as ISupportsValuePattern);
//        }
//        
////        [Test]
////        public void Grid_GetItem()
////        {
////            // Arrange
////            ISupportsGridPattern element =
////                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
////                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData()) }) as ISupportsGridPattern;
////            
////            // Act
////            
////            // Assert
////            element.GetItem(1, 1);
////        }
//        
//        [Test]
//        public void Grid_ColumnCount()
//        {
//            // Arrange
//            int expectedValue = 3;
//            ISupportsGridPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData() { GridPattern_ColumnCount = expectedValue }) }) as ISupportsGridPattern;
//            
//            // Act
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.GridColumnCount);
//        }
//        
//        [Test]
//        public void Grid_RowCount()
//        {
//            // Arrange
//            int expectedValue = 4;
//            ISupportsGridPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridPattern(new PatternsData() { GridPattern_RowCount = expectedValue }) }) as ISupportsGridPattern;
//            
//            // Act
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.GridRowCount);
//        }
//        
//        [Test]
//        public void Grid_GetItem()
//        {
//            // Arrange
//            ControlType expectedControlType = ControlType.Document;
//            string expectedName = "control name";
//            string expectedAutomationId = "au Id";
//            string expectedClassName = "control name";
//            ISupportsGridPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetGridPattern(
//                        new PatternsData() {
//                            GridPattern_GetItem_Name = expectedName,
//                            GridPattern_GetItem_AutomationId = expectedAutomationId,
//                            GridPattern_GetItem_Class = expectedClassName,
//                            GridPattern_GetItem_ControlType = expectedControlType
//                        }) }) as ISupportsGridPattern;
//            
//            // Act
//            IUiElement gottenElement = element.GetItem(1, 1);
//            
//            // Assert
//            Assert.AreEqual(expectedControlType, gottenElement.Current.ControlType);
//            Assert.AreEqual(expectedName, gottenElement.Current.Name);
//            Assert.AreEqual(expectedAutomationId, gottenElement.Current.AutomationId);
//            Assert.AreEqual(expectedClassName, gottenElement.Current.ClassName);
//        }
//        
//        [Test]
//        [Ignore("not yet ready")]
//        public void Grid_ExportToCsv()
//        {
//            // Arrange
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
