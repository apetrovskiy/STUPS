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
    /// Description of ISupportsWindowPatternTestFixture.
    /// </summary>
    // [MbUnit.Framework.Ignore][NUnit.Framework.Ignore]
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class ISupportsWindowPatternTestFixture
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
//        public void Window_ImplementsCommonPattern()
//        {
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetWindowPattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
//            
//            ISupportsHighlighter highlightableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetWindowPattern(new PatternsData()) }) as ISupportsHighlighter;
//            
//            Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
//            
//            ISupportsNavigation navigatableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetWindowPattern(new PatternsData()) }) as ISupportsNavigation;
//            
//            Assert.IsNotNull(navigatableElement as ISupportsNavigation);
//            
//            ISupportsConversion conversibleElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetWindowPattern(new PatternsData()) }) as ISupportsConversion;
//            
//            Assert.IsNotNull(conversibleElement as ISupportsConversion);
//            
//            ISupportsRefresh refreshableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetWindowPattern(new PatternsData()) }) as ISupportsRefresh;
//            
//            Assert.IsNotNull(refreshableElement as ISupportsRefresh);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Window_ImplementsPatternInQuestion()
//        {
//            ISupportsWindowPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetWindowPattern(new PatternsData()) }) as ISupportsWindowPattern;
//            
//            Assert.IsNotNull(element as ISupportsWindowPattern);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Window_DoesNotImplementOtherPatterns()
//        {
//            ISupportsValuePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetWindowPattern(new PatternsData()) }) as ISupportsValuePattern;
//            
//            Assert.IsNull(element as ISupportsValuePattern);
//        }
//        
////        [MbUnit.Framework.Test][NUnit.Framework.Test]
////        public void Window_Close()
////        {
////            // Arrange
////            ISupportsWindowPattern element =
////                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
////                    new IBasePattern[] { FakeFactory.GetWindowPattern(new PatternsData()) }) as ISupportsWindowPattern;
////            
////            // Act
////            // Assert
////            element.Close();
////        }
//        
////        [MbUnit.Framework.Test][NUnit.Framework.Test]
////        public void Window_SetWindowVisualState()
////        {
////            // Arrange
////            ISupportsWindowPattern element =
////                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
////                    new IBasePattern[] { FakeFactory.GetWindowPattern(new PatternsData()) }) as ISupportsWindowPattern;
////            
////            // Act
////            // Assert
////            element.SetWindowVisualState(WindowVisualState.Maximized);
////        }
////        
////        [MbUnit.Framework.Test][NUnit.Framework.Test]
////        public void Window_WaitForInputIdle()
////        {
////            // Arrange
////            ISupportsWindowPattern element =
////                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
////                    new IBasePattern[] { FakeFactory.GetWindowPattern(new PatternsData()) }) as ISupportsWindowPattern;
////            
////            // Act
////            // Assert
////            element.WaitForInputIdle(1);
////        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Window_CanMaximize()
//        {
//            // Arrange
//            bool expectedValue = true;
//            ISupportsWindowPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetWindowPattern(new PatternsData() { WindowPattern_CanMaximize = expectedValue }) }) as ISupportsWindowPattern;
//            
//            // Act
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.CanMaximize);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Window_CanMinimize()
//        {
//            // Arrange
//            bool expectedValue = false;
//            ISupportsWindowPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetWindowPattern(new PatternsData() { WindowPattern_CanMinimize = expectedValue }) }) as ISupportsWindowPattern;
//            
//            // Act
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.CanMinimize);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Window_IsModal()
//        {
//            // Arrange
//            bool expectedValue = true;
//            ISupportsWindowPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetWindowPattern(new PatternsData() { WindowPattern_IsModal = expectedValue }) }) as ISupportsWindowPattern;
//            
//            // Act
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.IsModal);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Window_IsTopmost()
//        {
//            // Arrange
//            bool expectedValue = false;
//            ISupportsWindowPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetWindowPattern(new PatternsData() { WindowPattern_IsTopmost = expectedValue }) }) as ISupportsWindowPattern;
//            
//            // Act
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.IsTopmost);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Window_WindowInteractionState()
//        {
//            // Arrange
//            WindowInteractionState expectedValue = WindowInteractionState.ReadyForUserInteraction;
//            ISupportsWindowPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetWindowPattern(new PatternsData() { WindowPattern_WindowInteractionState = expectedValue }) }) as ISupportsWindowPattern;
//            
//            // Act
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.WindowInteractionState);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Window_WindowVisualState()
//        {
//            // Arrange
//            WindowVisualState expectedValue = WindowVisualState.Normal;
//            ISupportsWindowPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetWindowPattern(new PatternsData() { WindowPattern_WindowVisualState = expectedValue }) }) as ISupportsWindowPattern;
//            
//            // Act
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.WindowVisualState);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Window_Close()
//        {
//            // Arrange
//            bool expectedResult = true;
//            bool result = false;
//            ISupportsWindowPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetWindowPattern(new PatternsData()) }) as ISupportsWindowPattern;
//            
//            // Act
//            element.Close();
//            try {
//                (element as IUiElement).GetCurrentPattern<IWindowPattern>(WindowPattern.Pattern).Received(1).Close();
//                result = true;
//            }
//            catch {}
//            
//            // Assert
//            Assert.AreEqual(expectedResult, result);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Window_SetWindowVisualState()
//        {
//            // Arrange
//            WindowVisualState expectedValue = WindowVisualState.Minimized;
//            ISupportsWindowPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetWindowPattern(new PatternsData()) }) as ISupportsWindowPattern;
//            
//            // Act
//            element.SetWindowVisualState(expectedValue);
//            try {
//                (element as IUiElement).GetCurrentPattern<IWindowPattern>(WindowPattern.Pattern).Received(1).SetWindowVisualState(expectedValue);
//                element.WindowVisualState.Returns(expectedValue);
//                
//            }
//            catch {}
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.WindowVisualState);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Window_WaitForInputIdle()
//        {
//            // Arrange
//            bool expectedResult = true;
//            bool result = false;
//            ISupportsWindowPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetWindowPattern(new PatternsData()) }) as ISupportsWindowPattern;
//            
//            // Act
//            element.WaitForInputIdle(1);
//            try {
//                (element as IUiElement).GetCurrentPattern<IWindowPattern>(WindowPattern.Pattern).Received(1).WaitForInputIdle(1);
//                result = true;
//            }
//            catch {}
//            
//            // Assert
//            Assert.AreEqual(expectedResult, result);
//        }
    }
}
