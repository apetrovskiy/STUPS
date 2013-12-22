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
    /// Description of ISupportsTablePatternTestFixture.
    /// </summary>
    // [Ignore]
    [TestFixture]
    public class ISupportsTablePatternTestFixture
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
        public void Table_ImplementsCommonPattern()
        {
            ISupportsInvokePattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData()) }) as ISupportsInvokePattern;
            
            Assert.IsNotNull(element as ISupportsInvokePattern);
        }
        
        [Test]
        public void Table_ImplementsPattern()
        {
            ISupportsTablePattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData()) }) as ISupportsTablePattern;
            
            Assert.IsNotNull(element as ISupportsTablePattern);
        }
        
        [Test]
        public void Table_DoesNotImplementOtherPatterns()
        {
            ISupportsValuePattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData()) }) as ISupportsValuePattern;
            
            Assert.IsNull(element as ISupportsValuePattern);
        }
        
        [Test]
        [Ignore]
        public void Table_GetColumnHeaders()
        {
            // Arrange
            ISupportsTablePattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData()) }) as ISupportsTablePattern;
            
            // Act
            // Assert
            element.GetColumnHeaders();
        }
        
        [Test]
        [Ignore]
        public void Table_GetRowHeaders()
        {
            // Arrange
            ISupportsTablePattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTablePattern(new PatternsData()) }) as ISupportsTablePattern;
            
            // Act
            // Assert
            element.GetRowHeaders();
        }
    }
}
