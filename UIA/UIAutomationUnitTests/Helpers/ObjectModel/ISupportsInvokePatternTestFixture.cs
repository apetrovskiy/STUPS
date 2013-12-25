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
    using System.Windows.Automation;
    using UIAutomation;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of ISupportsInvokePatternTestFixture.
    /// </summary>
    // [Ignore]
    [TestFixture]
    public class ISupportsInvokePatternTestFixture
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
        public void Invoke_ImplementsCommonPattern()
        {
            ISupportsInvokePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetInvokePattern(new PatternsData()) }) as ISupportsInvokePattern;
            
            Assert.IsNotNull(element as ISupportsInvokePattern);
        }
        
//        [Test]
//        public void Invoke_ImplementsPattern()
//        {
//            ISupportsInvokePattern element =
//                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetInvokePattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            Assert.IsNotNull(element as ISupportsInvokePattern);
//        }
        
        [Test]
        public void Invoke_DoesNotImplementOtherPatterns()
        {
            ISupportsValuePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetInvokePattern(new PatternsData()) }) as ISupportsValuePattern;
            
            Assert.IsNull(element as ISupportsValuePattern);
        }
        
        [Test]
        public void Invoke_Click()
        {
            // Arrange
            ISupportsInvokePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetInvokePattern(new PatternsData()) }) as ISupportsInvokePattern;
            
            // Act
            // Assert
            element.Click();
        }
        
        [Test]
        public void Invoke_DoubleClick()
        {
            // Arrange
            ISupportsInvokePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetInvokePattern(new PatternsData()) }) as ISupportsInvokePattern;
            
            // Act
            
            // Assert
            element.DoubleClick();
        }
    }
}
