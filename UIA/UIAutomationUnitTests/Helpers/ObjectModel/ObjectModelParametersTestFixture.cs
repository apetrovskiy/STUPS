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
    using MbUnit.Framework;using Xunit;
    using NSubstitute;
    
    /// <summary>
    /// Description of ObjectModelParametersTestFixture.
    /// </summary>
    public class ObjectModelParametersTestFixture
    {
        public ObjectModelParametersTestFixture()
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
        [Description("Checks that there is no elements' object model available when the  parameter if $false")]
        public void DoenNotImplementCommonPatterns()
        {
            // Arrange
            UIAutomation.Preferences.UseElementsPatternObjectModel = false;
            
            ISupportsInvokePattern invokableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsInvokePattern;
            
            MbUnit.Framework.Assert.IsNull(invokableElement as ISupportsInvokePattern);
            Xunit.Assert.Null(invokableElement as ISupportsInvokePattern);
            
            ISupportsHighlighter highlightableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsHighlighter;
            
            MbUnit.Framework.Assert.IsNull(highlightableElement as ISupportsHighlighter);
            Xunit.Assert.Null(highlightableElement as ISupportsHighlighter);
            
            ISupportsNavigation navigatableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsNavigation;
            
            MbUnit.Framework.Assert.IsNull(navigatableElement as ISupportsNavigation);
            Xunit.Assert.Null(navigatableElement as ISupportsNavigation);
            
            ISupportsConversion conversibleElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsConversion;
            
            MbUnit.Framework.Assert.IsNull(conversibleElement as ISupportsConversion);
            Xunit.Assert.Null(conversibleElement as ISupportsConversion);
            
            ISupportsRefresh refreshableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsRefresh;
            
            MbUnit.Framework.Assert.IsNull(refreshableElement as ISupportsRefresh);
            Xunit.Assert.Null(refreshableElement as ISupportsRefresh);
        }
        
        [Test][Fact]
        [Description("Checks that the extended elements' object model is off when the UseElementsSearchObjectModel parameter is $false")]
        public void NoExtension()
        {
            // Arrange
            UIAutomation.Preferences.UseElementsSearchObjectModel = false;
            
            // Act
            IUiElement[] elements = new IUiElement[] {};
            IUiElement element =
                FakeFactory.GetElement_ForFindAll(
                    elements,
                    new PropertyCondition(
                        AutomationElement.ControlTypeProperty,
                        ControlType.Button));
            
            // Assert
            MbUnit.Framework.Assert.IsNull(element as ISupportsExtendedModel);
            Xunit.Assert.Null(element as ISupportsExtendedModel);
        }
        
        [Test][Fact]
        [Description("Checks that the basic elements' object model works, while the extended elements' object model is off")]
        public void Toggle_Toggle_Off_ExtendedObjectModel_Off()
        {
            // Arrange
            UIAutomation.Preferences.UseElementsSearchObjectModel = false;
            
            ToggleState expectedValue = ToggleState.Off;
            ISupportsTogglePattern element =
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
            Xunit.Assert.Equal(expectedValue, element.ToggleState);
        }
        
        [Test][Fact]
        [Description("Checks that the basic elements' object model works, while the extended elements' object model is also on")]
        public void Toggle_Toggle_Off_ExtendedObjectModel_On()
        {
            // Arrange
            UIAutomation.Preferences.UseElementsSearchObjectModel = true;
            
            ToggleState expectedValue = ToggleState.Off;
            ISupportsTogglePattern element =
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
            Xunit.Assert.Equal(expectedValue, element.ToggleState);
        }
    }
}
