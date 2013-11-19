/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
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

    public interface IMySuperWrapper : IDisposable
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
		IMySuperWrapper FindFirst(TreeScope scope, Condition condition);
		//AutomationElementCollection FindAll(TreeScope scope, Condition condition);
		IMySuperCollection FindAll(TreeScope scope, Condition condition);
		AutomationProperty[] GetSupportedProperties();
		AutomationPattern[] GetSupportedPatterns();
		void SetFocus();
		//bool TryGetClickablePoint(out Point pt);
		bool TryGetClickablePoint(out System.Windows.Point pt);
		//Point GetClickablePoint();
		System.Windows.Point GetClickablePoint();
		// 20131114
		//AutomationElement.AutomationElementInformation Cached { get; }
		IMySuperWrapperInformation Cached { get; }
		// 20131114
		//AutomationElement.AutomationElementInformation Current { get; }
		IMySuperWrapperInformation Current { get; }
		// 20131114
		//AutomationElement CachedParent { get; }
		IMySuperWrapper CachedParent { get; }
		// 20131114
		//AutomationElementCollection CachedChildren { get; }
		IMySuperCollection CachedChildren { get; }
		
		//AutomationElement SourceElement { get; }
		//AutomationElement SourceElement { get; set; }
		//T GetSourceElement<T>();
		//void SetSourceElement<T>(T element);
		AutomationElement GetSourceElement();
		void SetSourceElement(AutomationElement element);
		//IMySuperWrapper GetSourceElement();
		//void SetSourceElement(IMySuperWrapper element);
	    
		//void Dispose();
		
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
//		IMySuperWrapper FindFirst(TreeScope scope, System.Windows.Automation.Condition condition);
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
