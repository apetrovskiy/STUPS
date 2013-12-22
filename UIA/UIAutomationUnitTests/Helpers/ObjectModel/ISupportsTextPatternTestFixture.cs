/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 12/22/2013
 * Time: 2:51 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.ObjectModel
{
    using System.Windows.Automation;
    using UIAutomation;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of ISupportsTextPatternTestFixture.
    /// </summary>
    // [Ignore]
    [TestFixture]
    public class ISupportsTextPatternTestFixture
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
        public void Text_ImplementsCommonPattern()
        {
            ISupportsInvokePattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsInvokePattern;
            
            Assert.IsNotNull(element as ISupportsInvokePattern);
        }
        
        [Test]
        public void Text_ImplementsPattern()
        {
            ISupportsTextPattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsTextPattern;
            
            Assert.IsNotNull(element as ISupportsTextPattern);
        }
        
        [Test]
        public void Text_DoesNotImplementOtherPatterns()
        {
            ISupportsValuePattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsValuePattern;
            
            Assert.IsNull(element as ISupportsValuePattern);
        }
        
        [Test]
        public void Text_GetTextSelection()
        {
            // Arrange
            ISupportsTextPattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsTextPattern;
            
            // Act
            // Assert
            element.GetTextSelection();
        }
        
        [Test]
        public void Text_GetVisibleRanges()
        {
            // Arrange
            ISupportsTextPattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsTextPattern;
            
            // Act
            // Assert
            element.GetVisibleRanges();
        }
        
        [Test]
        public void Text_RangeFromChild()
        {
            // Arrange
            ISupportsTextPattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsTextPattern;
            
            // Act
            // Assert
            element.RangeFromChild(new UiElement());
        }
        
        [Test]
        public void Text_RangeFromPoint()
        {
            // Arrange
            ISupportsTextPattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsTextPattern;
            
            // Act
            // Assert
            element.RangeFromPoint(new System.Windows.Point());
        }
    }
}
