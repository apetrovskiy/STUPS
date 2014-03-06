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
    extern alias UIANET;using System.Windows.Automation;
    using System;
    
    using classic = UIANET::System.Windows.Automation; // using System.Windows.Automation;
    
	/// <summary>
	/// Description of UiaAutomation.
	/// </summary>
	// public static class Automation
	[UiaSpecialBinding]
	public class UiaAutomation : IAutomation
	{
		public classic.Condition RawViewCondition
		{
		    get { return Automation.RawViewCondition; }
		}
		
		public classic.Condition ControlViewCondition
		{
		    // get { return new NotCondition(new PropertyCondition(AutomationElement.IsControlElementProperty, false)); }
		    get { return Automation.ControlViewCondition; }
		}
		
		public classic.Condition ContentViewCondition
		{
//		    get { return new NotCondition(
//		              new OrCondition(
//		                  new Condition[] {
//		                      new PropertyCondition(AutomationElement.IsControlElementProperty, false),
//		                      new PropertyCondition(AutomationElement.IsContentElementProperty, false)
//		                                  }
//		                              )
//		              ); }
		    get { return Automation.ContentViewCondition; }
		}
		
		public bool Compare(IUiElement el1, IUiElement el2)
		{
			return Automation.Compare(el1.GetSourceElement() as AutomationElement, el2.GetSourceElement() as AutomationElement);
		}
		
		public bool Compare(int[] runtimeId1, int[] runtimeId2)
		{
			return Automation.Compare(runtimeId1, runtimeId2);
		}
		
		public string PropertyName(classic.AutomationProperty property)
		{
			return Automation.PropertyName(property);
		}
		
		public string PatternName(IBasePattern pattern)
		{
		    return Automation.PatternName(pattern.GetSourcePattern() as AutomationPattern);
		}
		
		public void AddAutomationEventHandler(classic.AutomationEvent eventId, IUiElement element, classic.TreeScope scope, classic.AutomationEventHandler eventHandler)
		{
			Automation.AddAutomationEventHandler(
			    eventId,
			    element.GetSourceElement() as AutomationElement,
			    scope,
			    eventHandler);
		}
		
		public void RemoveAutomationEventHandler(classic.AutomationEvent eventId, IUiElement element, classic.AutomationEventHandler eventHandler)
		{
			Automation.RemoveAutomationEventHandler(
			    eventId,
			    element.GetSourceElement() as AutomationElement,
			    eventHandler);
		}
		
		public void AddAutomationPropertyChangedEventHandler(IUiElement element, classic.TreeScope scope, classic.AutomationPropertyChangedEventHandler eventHandler, params classic.AutomationProperty[] properties)
		{
			Automation.AddAutomationPropertyChangedEventHandler(
		        element.GetSourceElement() as AutomationElement,
			    scope,
			    eventHandler,
			    properties);
		}
		
		public void RemoveAutomationPropertyChangedEventHandler(IUiElement element, classic.AutomationPropertyChangedEventHandler eventHandler)
		{
			Automation.RemoveAutomationPropertyChangedEventHandler(
		        element.GetSourceElement() as AutomationElement,
			    eventHandler);
		}
		
		public void AddStructureChangedEventHandler(IUiElement element, classic.TreeScope scope, classic.StructureChangedEventHandler eventHandler)
		{
			Automation.AddStructureChangedEventHandler(
		        element.GetSourceElement() as AutomationElement,
			    scope,
			    eventHandler);
		}
		
		public void RemoveStructureChangedEventHandler(IUiElement element, classic.StructureChangedEventHandler eventHandler)
		{
			Automation.RemoveStructureChangedEventHandler(
		        element.GetSourceElement() as AutomationElement,
			    eventHandler);
		}
		
		public void AddAutomationFocusChangedEventHandler(classic.AutomationFocusChangedEventHandler eventHandler)
		{
			Automation.AddAutomationFocusChangedEventHandler(
			    eventHandler);
		}
		
		public void RemoveAutomationFocusChangedEventHandler(classic.AutomationFocusChangedEventHandler eventHandler)
		{
			Automation.RemoveAutomationFocusChangedEventHandler(
			    eventHandler);
		}
		
		public void RemoveAllEventHandlers()
		{
			Automation.RemoveAllEventHandlers();
		}
	}
}
