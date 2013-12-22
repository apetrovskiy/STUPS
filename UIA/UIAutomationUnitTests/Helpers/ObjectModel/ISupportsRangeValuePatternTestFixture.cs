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
    /// Description of ISupportsRangeValuePatternTestFixture.
    /// </summary>
    // [Ignore]
    [TestFixture]
    public class ISupportsRangeValuePatternTestFixture
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
        public void RangeValue_ImplementsCommonPattern()
        {
            ISupportsInvokePattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetRangeValuePattern(new PatternsData()) }) as ISupportsInvokePattern;
            
            Assert.IsNotNull(element as ISupportsInvokePattern);
        }
        
        [Test]
        public void RangeValue_ImplementsPattern()
        {
            ISupportsRangeValuePattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetRangeValuePattern(new PatternsData()) }) as ISupportsRangeValuePattern;
            
            Assert.IsNotNull(element as ISupportsRangeValuePattern);
        }
        
        [Test]
        public void RangeValue_DoesNotImplementOtherPatterns()
        {
            ISupportsValuePattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetRangeValuePattern(new PatternsData()) }) as ISupportsValuePattern;
            
            Assert.IsNull(element as ISupportsValuePattern);
        }
        
//        [Test]
//        public void RangeValue_RangeValue()
//        {
//            // Arrange
//            ISupportsRangeValuePattern element =
//                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetRangeValuePattern(new PatternsData()) }) as ISupportsRangeValuePattern;
//            
//            // Act
//            // Assert
//            element.RangeValue();
//        }
    }
}
