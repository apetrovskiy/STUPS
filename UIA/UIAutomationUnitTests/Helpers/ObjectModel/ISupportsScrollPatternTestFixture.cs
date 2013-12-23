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
    /// Description of ISupportsScrollPatternTestFixture.
    /// </summary>
    // [Ignore]
    [TestFixture]
    public class ISupportsScrollPatternTestFixture
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
        public void Scroll_ImplementsCommonPattern()
        {
            ISupportsInvokePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData()) }) as ISupportsInvokePattern;
            
            Assert.IsNotNull(element as ISupportsInvokePattern);
        }
        
        [Test]
        public void Scroll_ImplementsPattern()
        {
            ISupportsScrollPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData()) }) as ISupportsScrollPattern;
            
            Assert.IsNotNull(element as ISupportsScrollPattern);
        }
        
        [Test]
        public void Scroll_DoesNotImplementOtherPatterns()
        {
            ISupportsValuePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData()) }) as ISupportsValuePattern;
            
            Assert.IsNull(element as ISupportsValuePattern);
        }
        
        [Test]
        public void Scroll_Scroll()
        {
            // Arrange
            ISupportsScrollPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData()) }) as ISupportsScrollPattern;
            
            // Act
            // Assert
            element.Scroll(ScrollAmount.LargeIncrement, ScrollAmount.LargeIncrement);
        }
        
        [Test]
        public void Scroll_ScrollHorizontal()
        {
            // Arrange
            ISupportsScrollPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData()) }) as ISupportsScrollPattern;
            
            // Act
            // Assert
            element.ScrollHorizontal(ScrollAmount.LargeIncrement);
        }
        
        [Test]
        public void Scroll_ScrollVertical()
        {
            // Arrange
            ISupportsScrollPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData()) }) as ISupportsScrollPattern;
            
            // Act
            // Assert
            element.ScrollVertical(ScrollAmount.LargeIncrement);
        }
        
        [Test]
        public void Scroll_SetScrollPercent()
        {
            // Arrange
            ISupportsScrollPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetScrollPattern(new PatternsData()) }) as ISupportsScrollPattern;
            
            // Act
            // Assert
            element.SetScrollPercent(1, 1);
        }
    }
}
