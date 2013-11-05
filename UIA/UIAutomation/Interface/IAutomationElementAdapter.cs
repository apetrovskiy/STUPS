/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 11/5/2013
 * Time: 1:22 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Automation;

	public interface IAutomationElementAdapter
	{
		bool Equals(object obj);
		int GetHashCode();
		int[] GetRuntimeId();
		object GetCurrentPropertyValue(AutomationProperty property);
		object GetCurrentPropertyValue(AutomationProperty property, bool ignoreDefaultValue);
		object GetCurrentPattern(AutomationPattern pattern);
		bool TryGetCurrentPattern(AutomationPattern pattern, out object patternObject);
		object GetCachedPropertyValue(AutomationProperty property);
		object GetCachedPropertyValue(AutomationProperty property, bool ignoreDefaultValue);
		object GetCachedPattern(AutomationPattern pattern);
		bool TryGetCachedPattern(AutomationPattern pattern, out object patternObject);
		AutomationElement GetUpdatedCache(CacheRequest request);
		//AutomationElement FindFirst(TreeScope scope, Condition condition);
		IAutomationElementAdapter FindFirst(TreeScope scope, Condition condition);
		//AutomationElementCollection FindAll(TreeScope scope, Condition condition);
		IAutomationElementCollection FindAll(TreeScope scope, Condition condition);
		AutomationProperty[] GetSupportedProperties();
		AutomationPattern[] GetSupportedPatterns();
		void SetFocus();
		//bool TryGetClickablePoint(out Point pt);
		bool TryGetClickablePoint(out System.Windows.Point pt);
		//Point GetClickablePoint();
		System.Windows.Point GetClickablePoint();
		AutomationElement.AutomationElementInformation Cached { get; }
		AutomationElement.AutomationElementInformation Current { get; }
		AutomationElement CachedParent { get; }
		AutomationElementCollection CachedChildren { get; }
		
		AutomationElement SourceElement { get; }
	    
//		bool Equals(object obj);
//		int GetHashCode();
//		int[] GetRuntimeId();
//		object GetCurrentPropertyValue(AutomationProperty property);
//		object GetCurrentPropertyValue(AutomationProperty property, bool ignoreDefaultValue);
//		object GetCurrentPattern(AutomationPattern pattern);
//		bool TryGetCurrentPattern(AutomationPattern pattern, out object patternObject);
//		object GetCachedPropertyValue(AutomationProperty property);
//		object GetCachedPropertyValue(AutomationProperty property, bool ignoreDefaultValue);
//		object GetCachedPattern(AutomationPattern pattern);
//		bool TryGetCachedPattern(AutomationPattern pattern, out object patternObject);
//		AutomationElement GetUpdatedCache(CacheRequest request);
//		//AutomationElement FindFirst(TreeScope scope, Condition condition);
//		IAutomationElementAdapter FindFirst(TreeScope scope, System.Windows.Automation.Condition condition);
//		//AutomationElementCollection FindAll(TreeScope scope, Condition condition);
//		AutomationElementCollection FindAll(TreeScope scope, System.Windows.Automation.Condition condition);
//		AutomationProperty[] GetSupportedProperties();
//		AutomationPattern[] GetSupportedPatterns();
//		void SetFocus();
//		//bool TryGetClickablePoint(out Point pt);
//		bool TryGetClickablePoint(out System.Windows.Point pt);
//		//Point GetClickablePoint();
//		System.Windows.Point GetClickablePoint();
//		AutomationElement.AutomationElementInformation Cached { get; }
//		AutomationElement.AutomationElementInformation Current { get; }
//		AutomationElement CachedParent { get; }
//		AutomationElementCollection CachedChildren { get; }
//		
//		AutomationElement SourceElement { get; }
	}
}
