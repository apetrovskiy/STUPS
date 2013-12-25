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
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsInvokePattern;
            
            Assert.IsNotNull(element as ISupportsInvokePattern);
        }
        
        [Test]
        public void Transform_ImplementsPattern()
        {
            ISupportsTransformPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsTransformPattern;
            
            Assert.IsNotNull(element as ISupportsTransformPattern);
        }
        
        [Test]
        public void Transform_DoesNotImplementOtherPatterns()
        {
            ISupportsValuePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsValuePattern;
            
            Assert.IsNull(element as ISupportsValuePattern);
        }
        
        [Test]
        public void Transform_Move()
        {
            // Arrange
            ISupportsTransformPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
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
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
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
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsTransformPattern;
            
            // Act
            // Assert
            element.Rotate(1);
        }
        
        [Test]
        public void Transform_CanMove()
        {
            // Arrange
            bool expectedValue = true;
            ISupportsTransformPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData() { TransformPattern_CanMove = expectedValue }) }) as ISupportsTransformPattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.CanMove);
        }
        
        [Test]
        public void Transform_CanResize()
        {
            // Arrange
            bool expectedValue = false;
            ISupportsTransformPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData() { TransformPattern_CanResize = expectedValue }) }) as ISupportsTransformPattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.CanResize);
        }
        
        [Test]
        public void Transform_CanRotate()
        {
            // Arrange
            bool expectedValue = true;
            ISupportsTransformPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData() { TransformPattern_CanRotate = expectedValue }) }) as ISupportsTransformPattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.CanRotate);
        }
    }
}
