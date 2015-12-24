/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/30/2014
 * Time: 5:20 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    
    /// <summary>
    /// Description of UiaAutomation.
    /// </summary>
    // public static class Automation
    [UiaSpecialBinding]
    public class UiaAutomation : IAutomation
    {
        public classic.Condition RawViewCondition
        {
            get { return classic.Automation.RawViewCondition; }
        }
        
        public classic.Condition ControlViewCondition
        {
            get { return classic.Automation.ControlViewCondition; }
        }
        
        public classic.Condition ContentViewCondition
        {
            get { return classic.Automation.ContentViewCondition; }
        }
        
        public bool Compare(IUiElement el1, IUiElement el2)
        {
            return classic.Automation.Compare(el1.GetSourceElement() as classic.AutomationElement, el2.GetSourceElement() as classic.AutomationElement);
        }
        
        public bool Compare(int[] runtimeId1, int[] runtimeId2)
        {
            return classic.Automation.Compare(runtimeId1, runtimeId2);
        }
        
        public string PropertyName(classic.AutomationProperty property)
        {
            return classic.Automation.PropertyName(property);
        }
        
        public string PatternName(IBasePattern pattern)
        {
            return classic.Automation.PatternName(pattern.GetSourcePattern() as classic.AutomationPattern);
        }
        
        public void AddAutomationEventHandler(classic.AutomationEvent eventId, IUiElement element, classic.TreeScope scope, classic.AutomationEventHandler eventHandler)
        {
            classic.Automation.AddAutomationEventHandler(
                eventId,
                element.GetSourceElement() as classic.AutomationElement,
                scope,
                eventHandler);
        }
        
        public void RemoveAutomationEventHandler(classic.AutomationEvent eventId, IUiElement element, classic.AutomationEventHandler eventHandler)
        {
            classic.Automation.RemoveAutomationEventHandler(
                eventId,
                element.GetSourceElement() as classic.AutomationElement,
                eventHandler);
        }
        
        public void AddAutomationPropertyChangedEventHandler(IUiElement element, classic.TreeScope scope, classic.AutomationPropertyChangedEventHandler eventHandler, params classic.AutomationProperty[] properties)
        {
            classic.Automation.AddAutomationPropertyChangedEventHandler(
                element.GetSourceElement() as classic.AutomationElement,
                scope,
                eventHandler,
                properties);
        }
        
        public void RemoveAutomationPropertyChangedEventHandler(IUiElement element, classic.AutomationPropertyChangedEventHandler eventHandler)
        {
            classic.Automation.RemoveAutomationPropertyChangedEventHandler(
                element.GetSourceElement() as classic.AutomationElement,
                eventHandler);
        }
        
        public void AddStructureChangedEventHandler(IUiElement element, classic.TreeScope scope, classic.StructureChangedEventHandler eventHandler)
        {
            classic.Automation.AddStructureChangedEventHandler(
                element.GetSourceElement() as classic.AutomationElement,
                scope,
                eventHandler);
        }
        
        public void RemoveStructureChangedEventHandler(IUiElement element, classic.StructureChangedEventHandler eventHandler)
        {
            classic.Automation.RemoveStructureChangedEventHandler(
                element.GetSourceElement() as classic.AutomationElement,
                eventHandler);
        }
        
        public void AddAutomationFocusChangedEventHandler(classic.AutomationFocusChangedEventHandler eventHandler)
        {
            classic.Automation.AddAutomationFocusChangedEventHandler(
                eventHandler);
        }
        
        public void RemoveAutomationFocusChangedEventHandler(classic.AutomationFocusChangedEventHandler eventHandler)
        {
            classic.Automation.RemoveAutomationFocusChangedEventHandler(
                eventHandler);
        }
        
        public void RemoveAllEventHandlers()
        {
            classic.Automation.RemoveAllEventHandlers();
        }
    }
}
