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
    
    public interface IAutomation
    {
        bool Compare(IUiElement el1, IUiElement el2);
        bool Compare(int[] runtimeId1, int[] runtimeId2);
        string PropertyName(classic.AutomationProperty property);
        string PatternName(IBasePattern pattern);
        void AddAutomationEventHandler(classic.AutomationEvent eventId, IUiElement element, classic.TreeScope scope, classic.AutomationEventHandler eventHandler);
        void RemoveAutomationEventHandler(classic.AutomationEvent eventId, IUiElement element, classic.AutomationEventHandler eventHandler);
        void AddAutomationPropertyChangedEventHandler(IUiElement element, classic.TreeScope scope, classic.AutomationPropertyChangedEventHandler eventHandler, params classic.AutomationProperty[] properties);
        void RemoveAutomationPropertyChangedEventHandler(IUiElement element, classic.AutomationPropertyChangedEventHandler eventHandler);
        void AddStructureChangedEventHandler(IUiElement element, classic.TreeScope scope, classic.StructureChangedEventHandler eventHandler);
        void RemoveStructureChangedEventHandler(IUiElement element, classic.StructureChangedEventHandler eventHandler);
        void AddAutomationFocusChangedEventHandler(classic.AutomationFocusChangedEventHandler eventHandler);
        void RemoveAutomationFocusChangedEventHandler(classic.AutomationFocusChangedEventHandler eventHandler);
        void RemoveAllEventHandlers();
        
        classic.Condition RawViewCondition { get; }
        classic.Condition ControlViewCondition { get; }
        classic.Condition ContentViewCondition { get; }
    }
}
