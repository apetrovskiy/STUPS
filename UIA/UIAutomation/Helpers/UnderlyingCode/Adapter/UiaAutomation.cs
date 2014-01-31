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
		public Condition RawViewCondition
		{
		    get { return Condition.TrueCondition; }
		}
		
		public Condition ControlViewCondition
		{
		    get { return new NotCondition(new PropertyCondition(AutomationElement.IsControlElementProperty, false)); }
		}
		
		public Condition ContentViewCondition
		{
		    get { return new NotCondition(
		              new OrCondition(
		                  new Condition[] {
		                      new PropertyCondition(AutomationElement.IsControlElementProperty, false),
		                      new PropertyCondition(AutomationElement.IsContentElementProperty, false)
		                                  }
		                              )
		              ); }
		}
		
		public bool Compare(IUiElement el1, IUiElement el2)
		{
			return Automation.Compare(el1.GetSourceElement() as AutomationElement, el2.GetSourceElement() as AutomationElement);
		}
		
		public bool Compare(int[] runtimeId1, int[] runtimeId2)
		{
			return Automation.Compare(runtimeId1, runtimeId2);
		}
		
		public string PropertyName(AutomationProperty property)
		{
			return Automation.PropertyName(property);
		}
		
		public string PatternName(IBasePattern pattern)
		{
		    return Automation.PatternName(pattern.GetSourcePattern() as AutomationPattern);
		}
		
		public void AddAutomationEventHandler(AutomationEvent eventId, IUiElement element, TreeScope scope, AutomationEventHandler eventHandler)
		{
			Automation.AddAutomationEventHandler(
			    eventId,
			    element.GetSourceElement() as AutomationElement,
			    scope,
			    eventHandler);
		}
		
		public void RemoveAutomationEventHandler(AutomationEvent eventId, IUiElement element, AutomationEventHandler eventHandler)
		{
			Automation.RemoveAutomationEventHandler(
			    eventId,
			    element.GetSourceElement() as AutomationElement,
			    eventHandler);
		}
		
		public void AddAutomationPropertyChangedEventHandler(IUiElement element, TreeScope scope, AutomationPropertyChangedEventHandler eventHandler, params AutomationProperty[] properties)
		{
			Automation.AddAutomationPropertyChangedEventHandler(
		        element.GetSourceElement() as AutomationElement,
			    scope,
			    eventHandler,
			    properties);
		}
		
		public void RemoveAutomationPropertyChangedEventHandler(IUiElement element, AutomationPropertyChangedEventHandler eventHandler)
		{
			Automation.RemoveAutomationPropertyChangedEventHandler(
		        element.GetSourceElement() as AutomationElement,
			    eventHandler);
		}
		
		public void AddStructureChangedEventHandler(IUiElement element, TreeScope scope, StructureChangedEventHandler eventHandler)
		{
			Automation.AddStructureChangedEventHandler(
		        element.GetSourceElement() as AutomationElement,
			    scope,
			    eventHandler);
		}
		
		public void RemoveStructureChangedEventHandler(IUiElement element, StructureChangedEventHandler eventHandler)
		{
			Automation.RemoveStructureChangedEventHandler(
		        element.GetSourceElement() as AutomationElement,
			    eventHandler);
		}
		
		public void AddAutomationFocusChangedEventHandler(AutomationFocusChangedEventHandler eventHandler)
		{
			Automation.AddAutomationFocusChangedEventHandler(
			    eventHandler);
		}
		
		public void RemoveAutomationFocusChangedEventHandler(AutomationFocusChangedEventHandler eventHandler)
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
