/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/7/2014
 * Time: 5:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Helpers.ObjectModel
{
    /// <summary>
    /// Description of ISupportsValuePatternTestFixture.
    /// </summary>
    // [MbUnit.Framework.Ignore][NUnit.Framework.Ignore]
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class ISupportsValuePatternTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void TearDown()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Value_ImplementsCommonPattern()
//        {
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetValuePattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
//            
//            ISupportsHighlighter highlightableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetValuePattern(new PatternsData()) }) as ISupportsHighlighter;
//            
//            Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
//            
//            ISupportsNavigation navigatableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetValuePattern(new PatternsData()) }) as ISupportsNavigation;
//            
//            Assert.IsNotNull(navigatableElement as ISupportsNavigation);
//            
//            ISupportsConversion conversibleElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetValuePattern(new PatternsData()) }) as ISupportsConversion;
//            
//            Assert.IsNotNull(conversibleElement as ISupportsConversion);
//            
//            ISupportsRefresh refreshableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetValuePattern(new PatternsData()) }) as ISupportsRefresh;
//            
//            Assert.IsNotNull(refreshableElement as ISupportsRefresh);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Value_ImplementsPatternInQuestion()
//        {
//            ISupportsValuePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetValuePattern(new PatternsData()) }) as ISupportsValuePattern;
//            
//            Assert.IsNotNull(element as ISupportsValuePattern);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Value_DoesNotImplementOtherPatterns()
//        {
//            ISupportsDockPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetValuePattern(new PatternsData()) }) as ISupportsDockPattern;
//            
//            Assert.IsNull(element as ISupportsValuePattern);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Value_Value_Get()
//        {
//            // Arrange
//            const string expectedValue = "abc";
//            ISupportsValuePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetValuePattern(new PatternsData() { ValuePattern_Value = expectedValue }) }) as ISupportsValuePattern;
//            
//            // Act
//            // Assert
//            Assert.AreEqual(expectedValue, element.Value);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [MbUnit.Framework.Ignore][NUnit.Framework.Ignore]
//        public void Value_Value_Set()
//        {
//            // Arrange
//            string expectedValue = "abc";
//            ISupportsValuePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetValuePattern(new PatternsData()) }) as ISupportsValuePattern;
//            
//            // Act
//            element.Value = expectedValue;
//            try {
//                (element as IUiElement).GetCurrentPattern<IValuePattern>(ValuePattern.Pattern).Received(1).SetValue(expectedValue);
//                element.Value.Returns(expectedValue);
//                
//            }
//            catch {}
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.Value);
//        }
    }
}
