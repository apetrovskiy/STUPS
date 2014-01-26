/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/22/2013
 * Time: 2:48 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.ObjectModel
{
    using System.Windows.Automation;
    using UIAutomation;
    using MbUnit.Framework;using Xunit;
    
    /// <summary>
    /// Description of ISupportsInvokePatternTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture]
    public class ISupportsInvokePatternTestFixture
    {
        public ISupportsInvokePatternTestFixture()
        {
            FakeFactory.Init();
        }
        
        [SetUp]
        public void SetUp()
        {
            FakeFactory.Init();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
        [Test][Fact]
        public void Invoke_ImplementsCommonPattern()
        {
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetInvokePattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            MbUnit.Framework.Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
            
            ISupportsHighlighter highlightableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetInvokePattern(new PatternsData()) }) as ISupportsHighlighter;
            
            MbUnit.Framework.Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
            Xunit.Assert.NotNull(highlightableElement as ISupportsHighlighter);
            
            ISupportsNavigation navigatableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetInvokePattern(new PatternsData()) }) as ISupportsNavigation;
            
            MbUnit.Framework.Assert.IsNotNull(navigatableElement as ISupportsNavigation);
            Xunit.Assert.NotNull(navigatableElement as ISupportsNavigation);
            
            ISupportsConversion conversibleElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetInvokePattern(new PatternsData()) }) as ISupportsConversion;
            
            MbUnit.Framework.Assert.IsNotNull(conversibleElement as ISupportsConversion);
            Xunit.Assert.NotNull(conversibleElement as ISupportsConversion);
            
            ISupportsRefresh refreshableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetInvokePattern(new PatternsData()) }) as ISupportsRefresh;
            
            MbUnit.Framework.Assert.IsNotNull(refreshableElement as ISupportsRefresh);
            Xunit.Assert.NotNull(refreshableElement as ISupportsRefresh);
        }
        
        [Test][Fact]
        public void Invoke_Invoke()
        {
            // Arrange
            ISupportsInvokePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetInvokePattern(new PatternsData()) }) as ISupportsInvokePattern;
            
            // Act
            // Assert
            element.Invoke();
        }
        
//        [Test][Fact]
//        public void Invoke_ImplementsPatternInQuestion()
//        {
//            ISupportsInvokePattern element =
//                FakeFactory.GetAutomaitonElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetInvokePattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            MbUnit.Framework.Assert.IsNotNull(element as ISupportsInvokePattern);
//        }
        
        [Test][Fact]
        public void Invoke_DoesNotImplementOtherPatterns()
        {
            ISupportsValuePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetInvokePattern(new PatternsData()) }) as ISupportsValuePattern;
            
            MbUnit.Framework.Assert.IsNull(element as ISupportsValuePattern);
            Xunit.Assert.Null(element as ISupportsValuePattern);
        }
        
//        [Test][Fact]
//        public void Invoke_Click()
//        {
//            // Arrange
//            ISupportsInvokePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetInvokePattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            // Act
//            // Assert
//            element.Click();
//        }
//        
//        [Test][Fact]
//        public void Invoke_DoubleClick()
//        {
//            // Arrange
//            ISupportsInvokePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetInvokePattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            // Act
//            
//            // Assert
//            element.DoubleClick();
//        }
    }
}
