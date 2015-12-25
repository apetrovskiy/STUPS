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
    /// <summary>
    /// Description of CommonPatternsTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class CommonPatternsTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void TearDown()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
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
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
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
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
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
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
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
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
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
