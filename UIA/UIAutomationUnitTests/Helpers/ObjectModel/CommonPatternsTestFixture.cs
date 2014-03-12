/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/5/2014
 * Time: 5:39 PM
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
    /// Description of CommonPatternsTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture]
    public class CommonPatternsTestFixture
    {
        public CommonPatternsTestFixture()
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
            // 20140312
            Preferences.UseElementsCached = false;
            Preferences.UseElementsCurrent = false;
        }
        
//        [Test][Fact]
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
        
        [Test][Fact]
        public void Highlighter()
        {
            // Arrange
            // DockPosition expectedValue = DockPosition.Bottom;
            // 20140312
            // ISupportsHighlighter element =
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsHighlighter;
            
            // Act
            // element.SetDockPosition(expectedValue);
            element.Highlight();
            
            // Assert
            // Assert.AreEqual(expectedValue, element.DockPosition);
        }
        
        [Test][Fact]
        public void Navigation()
        {
            // Arrange
            // DockPosition expectedValue = DockPosition.Bottom;
            // 20140312
            // ISupportsNavigation element =
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsNavigation;
            
            // Act
            // element.SetDockPosition(expectedValue);
            element.NavigateToFirstChild();
            element.NavigateToLastChild();
            element.NavigateToPreviousSibling();
            element.NavigateToNextSibling();
            element.NavigateToParent();
            
            // Assert
            // Assert.AreEqual(expectedValue, element.DockPosition);
        }
        
        [Test][Fact]
        public void Conversion()
        {
            // Arrange
            // DockPosition expectedValue = DockPosition.Bottom;
            // 20140312
            // ISupportsConversion element =
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsConversion;
            
            // Act
            // element.SetDockPosition(expectedValue);
            element.ConvertToSearchCriteria();
            
            // Assert
            // Assert.AreEqual(expectedValue, element.DockPosition);
        }
        
        [Test][Fact]
        public void Refresh()
        {
            // Arrange
            // DockPosition expectedValue = DockPosition.Bottom;
            // 20140312
            // ISupportsRefresh element =
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsRefresh;
            
            // Act
            // element.SetDockPosition(expectedValue);
            element.Refresh();
            
            // Assert
            // Assert.AreEqual(expectedValue, element.DockPosition);
        }
        
        [Test][Fact]
        public void Cached_On()
        {
            Preferences.UseElementsCached = true;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsCached;
            var testCached = element.Cached;
            var testCachedChildren = element.CachedChildren;
            var testCachedParent = element.CachedParent;
        }
        
        [Test][Fact]
        public void Cached_Off()
        {
            Preferences.UseElementsCached = false;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsCached;
            MbUnit.Framework.Assert.IsNull(element);
            Xunit.Assert.Null(element);
        }
        
        [Test][Fact]
        public void Current_On()
        {
            Preferences.UseElementsCurrent = true;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsCurrent;
            var testCurrent = element.Current;
        }
        
        [Test][Fact]
        public void Current_Off()
        {
            Preferences.UseElementsCurrent = false;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsCurrent;
            MbUnit.Framework.Assert.IsNull(element);
            Xunit.Assert.Null(element);
        }
    }
}
