/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 12/22/2013
 * Time: 2:49 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.ObjectModel
{
    using System.Windows.Automation;
    using UIAutomation;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of ISupportsTableItemPatternTestFixture.
    /// </summary>
    // [Ignore]
    [TestFixture]
    public class ISupportsTableItemPatternTestFixture
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
        public void TableItem_ImplementsCommonPattern()
        {
            ISupportsInvokePattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData()) }) as ISupportsInvokePattern;
            
            Assert.IsNotNull(element as ISupportsInvokePattern);
        }
        
        [Test]
        public void TableItem_ImplementsPattern()
        {
            ISupportsTableItemPattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData()) }) as ISupportsTableItemPattern;
            
            Assert.IsNotNull(element as ISupportsTableItemPattern);
        }
        
        [Test]
        public void TableItem_DoesNotImplementOtherPatterns()
        {
            ISupportsValuePattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData()) }) as ISupportsValuePattern;
            
            Assert.IsNull(element as ISupportsValuePattern);
        }
        
        [Test]
        [Ignore]
        public void TableItem_GetColumnHeaderItems()
        {
            // Arrange
            ISupportsTableItemPattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData()) }) as ISupportsTableItemPattern;
            
            // Act
            // Assert
            element.GetColumnHeaderItems();
        }
        
        [Test]
        [Ignore]
        public void TableItem_GetRowHeaderItems()
        {
            // Arrange
            ISupportsTableItemPattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTableItemPattern(new PatternsData()) }) as ISupportsTableItemPattern;
            
            // Act
            // Assert
            element.GetRowHeaderItems();
        }
    }
}
