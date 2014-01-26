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
    using MbUnit.Framework;// using Xunit;
    using System.Management.Automation;
    using NSubstitute;
    using UIAutomation;
    // using UIAutomationTest;
    
    /// <summary>
    /// Description of ISupportsDockPatternTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture]
    public class ISupportsDockPatternTestFixture
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
        
//        [Test]// [Fact]
//        public void Dock_ImplementsCommonPattern()
//        {
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            MbUnit.Framework.Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
//            
//            ISupportsHighlighter highlightableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsHighlighter;
//            
//            MbUnit.Framework.Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
//            
//            ISupportsNavigation navigatableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsNavigation;
//            
//            MbUnit.Framework.Assert.IsNotNull(navigatableElement as ISupportsNavigation);
//            
//            ISupportsConversion conversibleElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsConversion;
//            
//            MbUnit.Framework.Assert.IsNotNull(conversibleElement as ISupportsConversion);
//            
//            ISupportsRefresh refreshableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsRefresh;
//            
//            MbUnit.Framework.Assert.IsNotNull(refreshableElement as ISupportsRefresh);
//        }
//        
//        [Test]// [Fact]
//        public void Dock_ImplementsPatternInQuestion()
//        {
//            ISupportsDockPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsDockPattern;
//            
//            MbUnit.Framework.Assert.IsNotNull(element as ISupportsDockPattern);
//        }
//        
//        [Test]// [Fact]
//        public void Dock_DoesNotImplementOtherPatterns()
//        {
//            ISupportsValuePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsValuePattern;
//            
//            MbUnit.Framework.Assert.IsNull(element as ISupportsValuePattern);
//        }
//        
//        [Test]// [Fact]
//        public void Dock_DockPosition()
//        {
//            // Arrange
//            DockPosition expectedValue = DockPosition.Bottom;
//            ISupportsDockPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData() { DockPattern_DockPosition = expectedValue }) }) as ISupportsDockPattern;
//            
//            // Act
//            element.SetDockPosition(expectedValue);
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.DockPosition);
//        }
//        
//        [Test]// [Fact]
//        public void Dock_SetDockPosition()
//        {
//            // Arrange
//            DockPosition expectedValue = DockPosition.Left;
//            ISupportsDockPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsDockPattern;
//            
//            // Act
//            element.SetDockPosition(expectedValue);
//            try {
//                (element as IUiElement).GetCurrentPattern<IDockPattern>(DockPattern.Pattern).Received(1).SetDockPosition(expectedValue);
//                element.DockPosition.Returns(expectedValue);
//                
//            }
//            catch {}
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(expectedValue, element.DockPosition);
//        }
    }
}
