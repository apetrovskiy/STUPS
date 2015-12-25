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
    /// Description of ObjectModelParametersTestFixture.
    /// </summary>
    public class ObjectModelParametersTestFixture
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
//        [MbUnit.Framework.Description("Checks that there is no elements' object model available when the  parameter if $false")]
//        public void DoenNotImplementCommonPatterns()
//        {
//            // Arrange
//            UIAutomation.Preferences.UseElementsPatternObjectModel = false;
//            
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            Assert.IsNull(invokableElement as ISupportsInvokePattern);
//            
//            ISupportsHighlighter highlightableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsHighlighter;
//            
//            Assert.IsNull(highlightableElement as ISupportsHighlighter);
//            
//            ISupportsNavigation navigatableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsNavigation;
//            
//            Assert.IsNull(navigatableElement as ISupportsNavigation);
//            
//            ISupportsConversion conversibleElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsConversion;
//            
//            Assert.IsNull(conversibleElement as ISupportsConversion);
//            
//            ISupportsRefresh refreshableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsRefresh;
//            
//            Assert.IsNull(refreshableElement as ISupportsRefresh);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [MbUnit.Framework.Description("Checks that the extended elements' object model is off when the UseElementsSearchObjectModel parameter is $false")]
//        public void NoExtension()
//        {
//            // Arrange
//            UIAutomation.Preferences.UseElementsSearchObjectModel = false;
//            
//            // Act
//            IUiElement[] elements = new IUiElement[] {};
//            IUiElement element =
//                FakeFactory.GetElement_ForFindAll(
//                    elements,
//                    new PropertyCondition(
//                        AutomationElement.ControlTypeProperty,
//                        ControlType.Button));
//            
//            // Assert
//            Assert.IsNull(element as ISupportsExtendedModel);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [MbUnit.Framework.Description("Checks that the basic elements' object model works, while the extended elements' object model is off")]
//        public void Toggle_Toggle_Off_ExtendedObjectModel_Off()
//        {
//            // Arrange
//            UIAutomation.Preferences.UseElementsSearchObjectModel = false;
//            
//            ToggleState expectedValue = ToggleState.Off;
//            ISupportsTogglePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTogglePattern(new PatternsData()) }) as ISupportsTogglePattern;
//            
//            // Act
//            element.ToggleState.Returns(ToggleState.On);
//            element.Toggle();
//            try {
//                (element as IUiElement).GetCurrentPattern<ITogglePattern>(TogglePattern.Pattern).Received().Toggle();
//                if (ToggleState.On == element.ToggleState) {
//                    element.ToggleState.Returns(ToggleState.Off);
//                }
//            }
//            catch {}
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.ToggleState);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [MbUnit.Framework.Description("Checks that the basic elements' object model works, while the extended elements' object model is also on")]
//        public void Toggle_Toggle_Off_ExtendedObjectModel_On()
//        {
//            // Arrange
//            UIAutomation.Preferences.UseElementsSearchObjectModel = true;
//            
//            ToggleState expectedValue = ToggleState.Off;
//            ISupportsTogglePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetTogglePattern(new PatternsData()) }) as ISupportsTogglePattern;
//            
//            // Act
//            element.ToggleState.Returns(ToggleState.On);
//            element.Toggle();
//            try {
//                (element as IUiElement).GetCurrentPattern<ITogglePattern>(TogglePattern.Pattern).Received().Toggle();
//                if (ToggleState.On == element.ToggleState) {
//                    element.ToggleState.Returns(ToggleState.Off);
//                }
//            }
//            catch {}
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.ToggleState);
//        }
    }
}
