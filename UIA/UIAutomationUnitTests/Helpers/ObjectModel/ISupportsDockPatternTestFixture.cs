/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 12/22/2013
 * Time: 2:48 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.ObjectModel
{
    using System;
    
    
    using System.Windows.Automation;
    using UIAutomation;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of ISupportsDockPatternTestFixture.
    /// </summary>
    [TestFixture]
    public class ISupportsDockPatternTestFixture
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
        public void Dock_ImplementsCommonPattern()
        {
Console.WriteLine("Dock_ImplementsCommonPattern: 0001");
            
            ISupportsInvokePattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsInvokePattern;
            
Console.WriteLine("Dock_ImplementsCommonPattern: 0002");
            
            Assert.IsNotNull(element as ISupportsInvokePattern);
        }
        
        [Test]
        public void Dock_ImplementsPattern()
        {
            ISupportsDockPattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsDockPattern;
            
            Assert.IsNotNull(element as ISupportsDockPattern);
        }
        
        [Test]
        public void Dock_DoesNotImplementOtherPatterns()
        {
            ISupportsValuePattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsValuePattern;
            
            Assert.IsNull(element as ISupportsValuePattern);
        }
        
        [Test]
        public void Dock_SetDockPosition()
        {
            // Arrange
            ISupportsDockPattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsDockPattern;
            
            // Act
            // Assert
            element.SetDockPosition(DockPosition.Bottom);
        }
    }
}
