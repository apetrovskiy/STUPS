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
    using Xunit;
    using NSubstitute;
    
    /// <summary>
    /// Description of ISupportsTransformPatternTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class ISupportsTransformPatternTestFixture
    {
        public ISupportsTransformPatternTestFixture()
        {
            FakeFactory.Init();
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            FakeFactory.Init();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void TearDown()
        {
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Transform_ImplementsCommonPattern()
        {
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            MbUnit.Framework.Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
            
            var highlightableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsHighlighter;
            
            MbUnit.Framework.Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
            Assert.NotNull(highlightableElement as ISupportsHighlighter);
            
            var navigatableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsNavigation;
            
            MbUnit.Framework.Assert.IsNotNull(navigatableElement as ISupportsNavigation);
            Assert.NotNull(navigatableElement as ISupportsNavigation);
            
            var conversibleElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsConversion;
            
            MbUnit.Framework.Assert.IsNotNull(conversibleElement as ISupportsConversion);
            Assert.NotNull(conversibleElement as ISupportsConversion);
            
            var refreshableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsRefresh;
            
            MbUnit.Framework.Assert.IsNotNull(refreshableElement as ISupportsRefresh);
            Assert.NotNull(refreshableElement as ISupportsRefresh);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Transform_ImplementsPatternInQuestion()
        {
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsTransformPattern;
            
            MbUnit.Framework.Assert.IsNotNull(element as ISupportsTransformPattern);
            Assert.NotNull(element as ISupportsTransformPattern);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Transform_DoesNotImplementOtherPatterns()
        {
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsValuePattern;
            
            MbUnit.Framework.Assert.IsNull(element as ISupportsValuePattern);
            Assert.Null(element as ISupportsValuePattern);
        }
        
//        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
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
//        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
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
//        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
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
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Transform_CanMove()
        {
            // Arrange
            const bool expectedValue = true;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData() { TransformPattern_CanMove = expectedValue }) }) as ISupportsTransformPattern;
            
            // Act
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.CanMove);
            Assert.Equal(expectedValue, element.CanMove);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Transform_CanResize()
        {
            // Arrange
            const bool expectedValue = false;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData() { TransformPattern_CanResize = expectedValue }) }) as ISupportsTransformPattern;
            
            // Act
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.CanResize);
            Assert.Equal(expectedValue, element.CanResize);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Transform_CanRotate()
        {
            // Arrange
            const bool expectedValue = true;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData() { TransformPattern_CanRotate = expectedValue }) }) as ISupportsTransformPattern;
            
            // Act
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.CanRotate);
            Assert.Equal(expectedValue, element.CanRotate);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Transform_Move()
        {
            // Arrange
            const bool expectedResult = true;
            bool result = false;
            var element =
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
            MbUnit.Framework.Assert.AreEqual(expectedResult, result);
            Assert.Equal(expectedResult, result);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Transform_Resize()
        {
            // Arrange
            const bool expectedResult = true;
            bool result = false;
            var element =
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
            MbUnit.Framework.Assert.AreEqual(expectedResult, result);
            Assert.Equal(expectedResult, result);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Transform_Rotate()
        {
            // Arrange
            const bool expectedResult = true;
            bool result = false;
            var element =
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
            MbUnit.Framework.Assert.AreEqual(expectedResult, result);
            Assert.Equal(expectedResult, result);
        }
    }
}
