/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/8/2014
 * Time: 2:22 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Helpers.ObjectModelWithMocks
{
    using System;
    using System.Windows.Automation;
    using MbUnit.Framework;
    using System.Management.Automation;
    using UIAutomation;
    using UIAutomationUnitTests;
    
    /// <summary>
    /// Description of CommonPatternsTestFixture.
    /// </summary>
    [TestFixture]
    public class CommonPatternsTestFixture
    {
        [SetUp]
        public void SetUp()
        {
            FakeFactory.InitForPowerShell();
            MiddleLevelCode.PrepareRunspace();
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[void]([UIAutomation.CurrentData]::ResetData());");
        }
        
        [TearDown]
        public void TearDown()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
//        [Test]
//        public void InvokePattern()
//        {
//            // Arrange
//            // DockPosition expectedValue = DockPosition.Bottom;
//            ISupportsInvokePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            // Act
//            // element.SetDockPosition(expectedValue);
//            element.Click();
//            element.Click(1, 1);
//            element.DoubleClick();
//            element.DoubleClick(1, 1);
//            element.RightClick();
//            element.AltClick();
//            element.CtrlClick();
//            element.ShiftClick();
//            element.InvokeContextMenu();
//            
//            // Assert
//            // Assert.AreEqual(expectedValue, element.DockPosition);
//        }
//        
//        [Test]
//        public void Highlighter()
//        {
//            // Arrange
//            // DockPosition expectedValue = DockPosition.Bottom;
//            ISupportsHighlighter element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsHighlighter;
//            
//            // Act
//            // element.SetDockPosition(expectedValue);
//            element.Highlight();
//            
//            // Assert
//            // Assert.AreEqual(expectedValue, element.DockPosition);
//        }
//        
//        [Test]
//        public void Navigation()
//        {
//            // Arrange
//            // DockPosition expectedValue = DockPosition.Bottom;
//            ISupportsNavigation element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsNavigation;
//            
//            // Act
//            // element.SetDockPosition(expectedValue);
//            element.NavigateToFirstChild();
//            element.NavigateToLastChild();
//            element.NavigateToPreviousSibling();
//            element.NavigateToNextSibling();
//            element.NavigateToParent();
//            
//            // Assert
//            // Assert.AreEqual(expectedValue, element.DockPosition);
//        }
//        
//        [Test]
//        public void Conversion()
//        {
//            // Arrange
//            // DockPosition expectedValue = DockPosition.Bottom;
//            ISupportsConversion element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsConversion;
//            
//            // Act
//            // element.SetDockPosition(expectedValue);
//            element.ConvertToSearchCriteria();
//            
//            // Assert
//            // Assert.AreEqual(expectedValue, element.DockPosition);
//        }
//        
//        [Test]
//        public void Refresh()
//        {
//            // Arrange
//            // DockPosition expectedValue = DockPosition.Bottom;
//            ISupportsRefresh element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsRefresh;
//            
//            // Act
//            // element.SetDockPosition(expectedValue);
//            element.Refresh();
//            
//            // Assert
//            // Assert.AreEqual(expectedValue, element.DockPosition);
//        }
    }
}
