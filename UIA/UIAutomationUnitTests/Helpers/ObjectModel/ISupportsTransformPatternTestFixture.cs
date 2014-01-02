/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
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
    using NSubstitute;
    
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
            ISupportsInvokePattern invokableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsInvokePattern;
            
            Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
            
            ISupportsHighlighter highlightableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsHighlighter;
            
            Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
            
            ISupportsNavigation navigatableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsNavigation;
            
            Assert.IsNotNull(navigatableElement as ISupportsNavigation);
            
            ISupportsConversion conversibleElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsConversion;
            
            Assert.IsNotNull(conversibleElement as ISupportsConversion);
        }
        
        [Test]
        public void Transform_ImplementsPatternInQuestion()
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
        
//        [Test]
//        public void Transform_Move()
//        {
//            // Arrange
//            ISupportsTransformPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsTransformPattern;
//            
//            // Act
//            // Assert
//            element.Move(1, 1);
//        }
//        
//        [Test]
//        public void Transform_Resize()
//        {
//            // Arrange
//            ISupportsTransformPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsTransformPattern;
//            
//            // Act
//            // Assert
//            element.Resize(1, 1);
//        }
//        
//        [Test]
//        public void Transform_Rotate()
//        {
//            // Arrange
//            ISupportsTransformPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsTransformPattern;
//            
//            // Act
//            // Assert
//            element.Rotate(1);
//        }
        
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
        
        [Test]
        public void Transform_Move()
        {
            // Arrange
            bool expectedResult = true;
            bool result = false;
            ISupportsTransformPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsTransformPattern;
            
            // Act
            element.Move(1, 1);
            try {
                (element as IUiElement).GetCurrentPattern<ITransformPattern>(TransformPattern.Pattern).Received(1).Move(1, 1);
                result = true;
            }
            catch {}
            
            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test]
        public void Transform_Resize()
        {
            // Arrange
            bool expectedResult = true;
            bool result = false;
            ISupportsTransformPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsTransformPattern;
            
            // Act
            element.Resize(1, 1);
            try {
                (element as IUiElement).GetCurrentPattern<ITransformPattern>(TransformPattern.Pattern).Received(1).Resize(1, 1);
                result = true;
            }
            catch {}
            
            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test]
        public void Transform_Rotate()
        {
            // Arrange
            bool expectedResult = true;
            bool result = false;
            ISupportsTransformPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsTransformPattern;
            
            // Act
            element.Rotate(1);
            try {
                (element as IUiElement).GetCurrentPattern<ITransformPattern>(TransformPattern.Pattern).Received(1).Rotate(1);
                result = true;
            }
            catch {}
            
            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
