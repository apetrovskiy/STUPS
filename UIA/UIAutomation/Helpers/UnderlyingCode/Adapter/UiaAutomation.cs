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
    using System;
    
    using System.Windows.Automation;
    
	/// <summary>
	/// Description of UiaAutomation.
	/// </summary>
	// public static class Automation
	public class UiaAutomation : IAutomation
	{
//	    public UIAutomation(Automation automation)
//	    {
//	        SourceObject = automation;
//	    }
	    
		// public static readonly Condition RawViewCondition = Condition.TrueCondition;
		public readonly Condition RawViewCondition = Condition.TrueCondition;
		// public static readonly Condition ControlViewCondition = new NotCondition(new PropertyCondition(AutomationElement.IsControlElementProperty, false));
		public readonly Condition ControlViewCondition = new NotCondition(new PropertyCondition(AutomationElement.IsControlElementProperty, false));
		// public static readonly Condition ContentViewCondition = new NotCondition(new OrCondition(new Condition[]
		public readonly Condition ContentViewCondition = new NotCondition(new OrCondition(new Condition[] {
			new PropertyCondition(AutomationElement.IsControlElementProperty, false),
			new PropertyCondition(AutomationElement.IsContentElementProperty, false)
		}));
		// public static bool Compare(AutomationElement el1, AutomationElement el2)
		public bool Compare(IUiElement el1, IUiElement el2)
		{
			// return Misc.Compare(el1, el2);
			return Automation.Compare(el1, el2);
		}
		// public static bool Compare(int[] runtimeId1, int[] runtimeId2)
		public bool Compare(int[] runtimeId1, int[] runtimeId2)
		{
			// return Misc.Compare(runtimeId1, runtimeId2);
			return Automation.Compare(runtimeId1, runtimeId2);
		}
		// public static string PropertyName(AutomationProperty property)
		public string PropertyName(AutomationProperty property)
		{
//			Misc.ValidateArgumentNonNull(property, "property");
//			string text = property.ProgrammaticName.Split(new char[] { '.' })[1];
//			return text.Substring(0, text.Length - 8);
			return Automation.PropertyName(property);
		}
		// public static string PatternName(AutomationPattern pattern)
		public string PatternName(IBasePattern pattern)
		{
//			Misc.ValidateArgumentNonNull(pattern, "pattern");
//			string programmaticName = pattern.ProgrammaticName;
//			return programmaticName.Substring(0, programmaticName.Length - 26);
			return Automation.PatternName(pattern);
		}
		// public static void AddAutomationEventHandler(AutomationEvent eventId, AutomationElement element, TreeScope scope, AutomationEventHandler eventHandler)
		public void AddAutomationEventHandler(AutomationEvent eventId, IUiElement element, TreeScope scope, AutomationEventHandler eventHandler)
		{
//			Misc.ValidateArgumentNonNull(element, "element");
//			Misc.ValidateArgumentNonNull(eventHandler, "eventHandler");
//			Misc.ValidateArgument(eventId != AutomationElement.AutomationFocusChangedEvent, "EventIdMustNotBeAutomationFocusChanged");
//			Misc.ValidateArgument(eventId != AutomationElement.StructureChangedEvent, "EventIdMustNotBeStructureChanged");
//			Misc.ValidateArgument(eventId != AutomationElement.AutomationPropertyChangedEvent, "EventIdMustNotBeAutomationPropertyChanged");
//			if (eventId == WindowPattern.WindowClosedEvent) {
//				bool flag = false;
//				if (Misc.Compare(element, AutomationElement.RootElement)) {
//					if ((scope & TreeScope.Descendants) == TreeScope.Descendants) {
//						flag = true;
//					}
//				} else {
//					if ((scope & (TreeScope.Element | TreeScope.Descendants | TreeScope.Ancestors)) == (TreeScope.Element | TreeScope.Descendants | TreeScope.Ancestors)) {
//						flag = true;
//					} else {
//						if ((scope & TreeScope.Element) == TreeScope.Element) {
//							object currentPropertyValue = element.GetCurrentPropertyValue(AutomationElement.NativeWindowHandleProperty);
//							if (currentPropertyValue != null && currentPropertyValue is int && (int)currentPropertyValue != 0 && HwndProxyElementProvider.IsWindowPatternWindow(NativeMethods.HWND.Cast(new IntPtr((int)currentPropertyValue)))) {
//								flag = true;
//							}
//						}
//					}
//				}
//				if (!flag) {
//					throw new ArgumentException(SR.Get("ParamsNotApplicableToWindowClosedEvent"));
//				}
//			}
//			EventListener l = new EventListener(eventId, scope, null, CacheRequest.CurrentUiaCacheRequest);
//			ClientEventManager.AddListener(element, eventHandler, l);
			
			Automation.AddAutomationEventHandler(
			    eventId,
			    element.GetSourceElement(),
			    scope,
			    eventHandler);
		}
		// public static void RemoveAutomationEventHandler(AutomationEvent eventId, AutomationElement element, AutomationEventHandler eventHandler)
		public void RemoveAutomationEventHandler(AutomationEvent eventId, IUiElement element, AutomationEventHandler eventHandler)
		{
//			Misc.ValidateArgumentNonNull(element, "element");
//			Misc.ValidateArgumentNonNull(eventHandler, "eventHandler");
//			Misc.ValidateArgument(eventId != AutomationElement.AutomationFocusChangedEvent, "EventIdMustNotBeAutomationFocusChanged");
//			Misc.ValidateArgument(eventId != AutomationElement.StructureChangedEvent, "EventIdMustNotBeStructureChanged");
//			Misc.ValidateArgument(eventId != AutomationElement.AutomationPropertyChangedEvent, "EventIdMustNotBeAutomationPropertyChanged");
//			ClientEventManager.RemoveListener(eventId, element, eventHandler);
			
			Automation.RemoveAutomationEventHandler(
			    eventId,
			    element.GetSourceElement(),
			    eventHandler);
		}
		// public static void AddAutomationPropertyChangedEventHandler(AutomationElement element, TreeScope scope, AutomationPropertyChangedEventHandler eventHandler, params AutomationProperty[] properties)
		public void AddAutomationPropertyChangedEventHandler(IUiElement element, TreeScope scope, AutomationPropertyChangedEventHandler eventHandler, params AutomationProperty[] properties)
		{
//			Misc.ValidateArgumentNonNull(element, "element");
//			Misc.ValidateArgumentNonNull(eventHandler, "eventHandler");
//			Misc.ValidateArgumentNonNull(properties, "properties");
//			if (properties.Length == 0) {
//				throw new ArgumentException(SR.Get("AtLeastOnePropertyMustBeSpecified"));
//			}
//			for (int i = 0; i < properties.Length; i++) {
//				AutomationProperty obj = properties[i];
//				Misc.ValidateArgumentNonNull(obj, "properties");
//			}
//			EventListener l = new EventListener(AutomationElement.AutomationPropertyChangedEvent, scope, properties, CacheRequest.CurrentUiaCacheRequest);
//			ClientEventManager.AddListener(element, eventHandler, l);
			
			Automation.AddAutomationPropertyChangedEventHandler(
		        element.GetSourceElement(),
			    scope,
			    eventHandler,
			    properties);
		}
		// public static void RemoveAutomationPropertyChangedEventHandler(AutomationElement element, AutomationPropertyChangedEventHandler eventHandler)
		public void RemoveAutomationPropertyChangedEventHandler(IUiElement element, AutomationPropertyChangedEventHandler eventHandler)
		{
//			Misc.ValidateArgumentNonNull(element, "element");
//			Misc.ValidateArgumentNonNull(eventHandler, "eventHandler");
//			ClientEventManager.RemoveListener(AutomationElement.AutomationPropertyChangedEvent, element, eventHandler);
			
			Automation.RemoveAutomationPropertyChangedEventHandler(
		        element.GetSourceElement(),
			    eventHandler);
		}
		// public static void AddStructureChangedEventHandler(AutomationElement element, TreeScope scope, StructureChangedEventHandler eventHandler)
		public void AddStructureChangedEventHandler(IUiElement element, TreeScope scope, StructureChangedEventHandler eventHandler)
		{
//			Misc.ValidateArgumentNonNull(element, "element");
//			Misc.ValidateArgumentNonNull(eventHandler, "eventHandler");
//			EventListener l = new EventListener(AutomationElement.StructureChangedEvent, scope, null, CacheRequest.CurrentUiaCacheRequest);
//			ClientEventManager.AddListener(element, eventHandler, l);
			
			Automation.AddStructureChangedEventHandler(
		        element.GetSourceElement(),
			    scope,
			    eventHandler);
		}
		// public static void RemoveStructureChangedEventHandler(AutomationElement element, StructureChangedEventHandler eventHandler)
		public void RemoveStructureChangedEventHandler(IUiElement element, StructureChangedEventHandler eventHandler)
		{
//			Misc.ValidateArgumentNonNull(element, "element");
//			Misc.ValidateArgumentNonNull(eventHandler, "eventHandler");
//			ClientEventManager.RemoveListener(AutomationElement.StructureChangedEvent, element, eventHandler);
			
			Automation.RemoveStructureChangedEventHandler(
		        element.GetSourceElement(),
			    eventHandler);
		}
		// public static void AddAutomationFocusChangedEventHandler(AutomationFocusChangedEventHandler eventHandler)
		public void AddAutomationFocusChangedEventHandler(AutomationFocusChangedEventHandler eventHandler)
		{
//			Misc.ValidateArgumentNonNull(eventHandler, "eventHandler");
//			EventListener l = new EventListener(AutomationElement.AutomationFocusChangedEvent, TreeScope.Element | TreeScope.Children | TreeScope.Descendants | TreeScope.Ancestors, null, CacheRequest.CurrentUiaCacheRequest);
//			ClientEventManager.AddFocusListener(eventHandler, l);
			
			Automation.AddAutomationFocusChangedEventHandler(
			    eventHandler);
		}
		// public static void RemoveAutomationFocusChangedEventHandler(AutomationFocusChangedEventHandler eventHandler)
		public void RemoveAutomationFocusChangedEventHandler(AutomationFocusChangedEventHandler eventHandler)
		{
//			Misc.ValidateArgumentNonNull(eventHandler, "eventHandler");
//			ClientEventManager.RemoveFocusListener(eventHandler);
			
			Automation.RemoveAutomationFocusChangedEventHandler(
			    eventHandler);
		}
		// public static void RemoveAllEventHandlers()
		public void RemoveAllEventHandlers()
		{
//			ClientEventManager.RemoveAllListeners();
			
			Automation.RemoveAllEventHandlers();
		}
		
//		internal static Automation SourceObject { get; set; }
	}
}
