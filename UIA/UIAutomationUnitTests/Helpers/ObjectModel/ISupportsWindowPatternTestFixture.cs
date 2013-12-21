/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 12/22/2013
 * Time: 2:50 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.ObjectModel
{
    using System.Windows.Automation;
    using UIAutomation;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of ISupportsWindowPatternTestFixture.
    /// </summary>
    [Ignore]
    public class ISupportsWindowPatternTestFixture
    {
        [SetUp]
        public void SetUp()
        {
            FakeFactory.Init();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
        [Test]
        public void Window_ImplementsCommonPattern()
        {
            ISupportsInvokePattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetWindowPattern(new PatternsData()) }) as ISupportsInvokePattern;
            
            Assert.IsNotNull(element as ISupportsInvokePattern);
        }
        
        [Test]
        public void Window_ImplementsPattern()
        {
            ISupportsWindowPattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetWindowPattern(new PatternsData()) }) as ISupportsWindowPattern;
            
            Assert.IsNotNull(element as ISupportsWindowPattern);
        }
        
        [Test]
        public void Window_DoesNotImplementOtherPatterns()
        {
            ISupportsValuePattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetWindowPattern(new PatternsData()) }) as ISupportsValuePattern;
            
            Assert.IsNull(element as ISupportsValuePattern);
        }
        
        [Test]
        public void Window_Close()
        {
            // Arrange
            ISupportsWindowPattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetWindowPattern(new PatternsData()) }) as ISupportsWindowPattern;
            
            // Act
            // Assert
            element.Close();
        }
        
        [Test]
        public void Window_SetWindowVisualState()
        {
            // Arrange
            ISupportsWindowPattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetWindowPattern(new PatternsData()) }) as ISupportsWindowPattern;
            
            // Act
            // Assert
            element.SetWindowVisualState(WindowVisualState.Maximized);
        }
        
        [Test]
        public void Window_WaitForInputIdle()
        {
            // Arrange
            ISupportsWindowPattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetWindowPattern(new PatternsData()) }) as ISupportsWindowPattern;
            
            // Act
            // Assert
            element.WaitForInputIdle(1);
        }
    }
}
