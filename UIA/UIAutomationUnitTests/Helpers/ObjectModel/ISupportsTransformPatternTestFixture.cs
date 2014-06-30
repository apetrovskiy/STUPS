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
    using MbUnit.Framework;using Xunit;using NUnit.Framework;
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
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Transform_ImplementsCommonPattern()
        {
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            MbUnit.Framework.Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
            
            ISupportsHighlighter highlightableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsHighlighter;
            
            MbUnit.Framework.Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
            Xunit.Assert.NotNull(highlightableElement as ISupportsHighlighter);
            
            ISupportsNavigation navigatableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsNavigation;
            
            MbUnit.Framework.Assert.IsNotNull(navigatableElement as ISupportsNavigation);
            Xunit.Assert.NotNull(navigatableElement as ISupportsNavigation);
            
            ISupportsConversion conversibleElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsConversion;
            
            MbUnit.Framework.Assert.IsNotNull(conversibleElement as ISupportsConversion);
            Xunit.Assert.NotNull(conversibleElement as ISupportsConversion);
            
            ISupportsRefresh refreshableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsRefresh;
            
            MbUnit.Framework.Assert.IsNotNull(refreshableElement as ISupportsRefresh);
            Xunit.Assert.NotNull(refreshableElement as ISupportsRefresh);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Transform_ImplementsPatternInQuestion()
        {
            ISupportsTransformPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsTransformPattern;
            
            MbUnit.Framework.Assert.IsNotNull(element as ISupportsTransformPattern);
            Xunit.Assert.NotNull(element as ISupportsTransformPattern);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Transform_DoesNotImplementOtherPatterns()
        {
            ISupportsValuePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData()) }) as ISupportsValuePattern;
            
            MbUnit.Framework.Assert.IsNull(element as ISupportsValuePattern);
            Xunit.Assert.Null(element as ISupportsValuePattern);
        }
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
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
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
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
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
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
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Transform_CanMove()
        {
            // Arrange
            bool expectedValue = true;
            ISupportsTransformPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData() { TransformPattern_CanMove = expectedValue }) }) as ISupportsTransformPattern;
            
            // Act
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.CanMove);
            Xunit.Assert.Equal(expectedValue, element.CanMove);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Transform_CanResize()
        {
            // Arrange
            bool expectedValue = false;
            ISupportsTransformPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData() { TransformPattern_CanResize = expectedValue }) }) as ISupportsTransformPattern;
            
            // Act
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.CanResize);
            Xunit.Assert.Equal(expectedValue, element.CanResize);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Transform_CanRotate()
        {
            // Arrange
            bool expectedValue = true;
            ISupportsTransformPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTransformPattern(new PatternsData() { TransformPattern_CanRotate = expectedValue }) }) as ISupportsTransformPattern;
            
            // Act
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.CanRotate);
            Xunit.Assert.Equal(expectedValue, element.CanRotate);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
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
            MbUnit.Framework.Assert.AreEqual(expectedResult, result);
            Xunit.Assert.Equal(expectedResult, result);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
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
            MbUnit.Framework.Assert.AreEqual(expectedResult, result);
            Xunit.Assert.Equal(expectedResult, result);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
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
            MbUnit.Framework.Assert.AreEqual(expectedResult, result);
            Xunit.Assert.Equal(expectedResult, result);
        }
    }
}
