/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/4/2014
 * Time: 2:19 PM
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
    /// Description of ObjectModelParametersTestFixture.
    /// </summary>
    // [Ignore("20130313")]
    public class ObjectModelParametersTestFixture
    {
        public ObjectModelParametersTestFixture()
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
//        [Description("Checks that there is no elements' object model available when the  parameter if $false")]
        public void DoenNotImplementCommonPatterns()
        {
            // Arrange
            Preferences.UseElementsPatternObjectModel = false;
            Preferences.UseElementsCached = false;
            Preferences.UseElementsCurrent = false;
            
            var invokableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsInvokePattern;
            
            MbUnit.Framework.Assert.IsNull(invokableElement as ISupportsInvokePattern);
            Assert.Null(invokableElement as ISupportsInvokePattern);
            
            var highlightableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsHighlighter;
            
            MbUnit.Framework.Assert.IsNull(highlightableElement as ISupportsHighlighter);
            Assert.Null(highlightableElement as ISupportsHighlighter);
            
            var navigatableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsNavigation;
            
            MbUnit.Framework.Assert.IsNull(navigatableElement as ISupportsNavigation);
            Assert.Null(navigatableElement as ISupportsNavigation);
            
            var conversibleElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsConversion;
            
            MbUnit.Framework.Assert.IsNull(conversibleElement as ISupportsConversion);
            Assert.Null(conversibleElement as ISupportsConversion);
            
            var refreshableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsRefresh;
            
            MbUnit.Framework.Assert.IsNull(refreshableElement as ISupportsRefresh);
            Assert.Null(refreshableElement as ISupportsRefresh);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        [Description("Checks that the extended elements' object model is off when the UseElementsSearchObjectModel parameter is $false")]
        public void NoExtension()
        {
            // Arrange
            Preferences.UseElementsSearchObjectModel = false;
            
            // Act
            var elements = new IUiElement[] {};
            var element =
                FakeFactory.GetElement_ForFindAll(
                    elements,
                    new PropertyCondition(
                        AutomationElement.ControlTypeProperty,
                        ControlType.Button));
            
            // Assert
            MbUnit.Framework.Assert.IsNull(element as ISupportsExtendedModel);
            Assert.Null(element as ISupportsExtendedModel);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        [Description("Checks that the basic elements' object model works, while the extended elements' object model is off")]
        public void Toggle_Toggle_Off_ExtendedObjectModel_Off()
        {
            // Arrange
            Preferences.UseElementsSearchObjectModel = false;
            
            var expectedValue = ToggleState.Off;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTogglePattern(new PatternsData()) }) as ISupportsTogglePattern;
            
            // Act
            element.ToggleState.Returns(ToggleState.On);
            element.Toggle();
            try {
                (element as IUiElement).GetCurrentPattern<ITogglePattern>(TogglePattern.Pattern).Received().Toggle();
                if (ToggleState.On == element.ToggleState) {
                    element.ToggleState.Returns(ToggleState.Off);
                }
            }
            catch {}
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.ToggleState);
            Assert.Equal(expectedValue, element.ToggleState);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        [Description("Checks that the basic elements' object model works, while the extended elements' object model is also on")]
        public void Toggle_Toggle_Off_ExtendedObjectModel_On()
        {
            // Arrange
            Preferences.UseElementsSearchObjectModel = true;
            
            var expectedValue = ToggleState.Off;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTogglePattern(new PatternsData()) }) as ISupportsTogglePattern;
            
            // Act
            element.ToggleState.Returns(ToggleState.On);
            element.Toggle();
            try {
                (element as IUiElement).GetCurrentPattern<ITogglePattern>(TogglePattern.Pattern).Received().Toggle();
                if (ToggleState.On == element.ToggleState) {
                    element.ToggleState.Returns(ToggleState.Off);
                }
            }
            catch {}
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.ToggleState);
            Assert.Equal(expectedValue, element.ToggleState);
        }
    }
}
