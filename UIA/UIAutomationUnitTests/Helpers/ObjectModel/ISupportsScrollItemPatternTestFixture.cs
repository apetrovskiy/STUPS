/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
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
    /// Description of ISupportsScrollItemPatternTestFixture.
    /// </summary>
    // [Ignore]
    [TestFixture]
    public class ISupportsScrollItemPatternTestFixture
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
        public void ScrollItem_ImplementsCommonPattern()
        {
            ISupportsInvokePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetScrollItemPattern(new PatternsData()) }) as ISupportsInvokePattern;
            
            Assert.IsNotNull(element as ISupportsInvokePattern);
        }
        
        [Test]
        public void ScrollItem_ImplementsPattern()
        {
            ISupportsScrollItemPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetScrollItemPattern(new PatternsData()) }) as ISupportsScrollItemPattern;
            
            Assert.IsNotNull(element as ISupportsScrollItemPattern);
        }
        
        [Test]
        public void ScrollItem_DoesNotImplementOtherPatterns()
        {
            ISupportsValuePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetScrollItemPattern(new PatternsData()) }) as ISupportsValuePattern;
            
            Assert.IsNull(element as ISupportsValuePattern);
        }
        
        [Test]
        public void ScrollItem_ScrollIntoView()
        {
            // Arrange
            ISupportsScrollItemPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetScrollItemPattern(new PatternsData()) }) as ISupportsScrollItemPattern;
            
            // Act
            // Assert
            element.ScrollIntoView();
        }
    }
}
