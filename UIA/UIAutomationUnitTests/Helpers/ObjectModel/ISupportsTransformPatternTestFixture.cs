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
    /// Description of ISupportsTransformPatternTestFixture.
    /// </summary>
    // [Ignore]
    [TestFixture]
    public class ISupportsTransformPatternTestFixture
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
        public void Transform_ImplementsCommonPattern()
        {
            ISupportsInvokePattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsInvokePattern;
            
            Assert.IsNotNull(element as ISupportsInvokePattern);
        }
        
        [Test]
        public void Transform_ImplementsPattern()
        {
            ISupportsTransformPattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsTransformPattern;
            
            Assert.IsNotNull(element as ISupportsTransformPattern);
        }
        
        [Test]
        public void Transform_DoesNotImplementOtherPatterns()
        {
            ISupportsValuePattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsValuePattern;
            
            Assert.IsNull(element as ISupportsValuePattern);
        }
        
        [Test]
        public void Transform_Move()
        {
            // Arrange
            ISupportsTransformPattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsTransformPattern;
            
            // Act
            // Assert
            element.Move(1, 1);
        }
        
        [Test]
        public void Transform_Resize()
        {
            // Arrange
            ISupportsTransformPattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsTransformPattern;
            
            // Act
            // Assert
            element.Resize(1, 1);
        }
        
        [Test]
        public void Transform_Rotate()
        {
            // Arrange
            ISupportsTransformPattern element =
                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsTransformPattern;
            
            // Act
            // Assert
            element.Rotate(1);
        }
    }
}
