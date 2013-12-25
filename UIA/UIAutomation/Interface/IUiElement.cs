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
	extern alias UIANET;
	using System;
	using System.Collections;
	using System.ComponentModel;
	using System.Windows.Automation;
	using System.Windows;

	public interface IUiElement : IDisposable
	{
		bool Equals(object obj);
		int GetHashCode();
		int[] GetRuntimeId();
		object GetCurrentPropertyValue(AutomationProperty property);
		object GetCurrentPropertyValue(AutomationProperty property, bool ignoreDefaultValue);
		TN GetCurrentPattern<TN>(AutomationPattern pattern) where TN : IBasePattern;
		object GetCurrentPattern(AutomationPattern pattern);
		bool TryGetCurrentPattern(AutomationPattern pattern, out object patternObject);
		object GetCachedPropertyValue(AutomationProperty property);
		object GetCachedPropertyValue(AutomationProperty property, bool ignoreDefaultValue);
		object GetCachedPattern(AutomationPattern pattern);
		bool TryGetCachedPattern(AutomationPattern pattern, out object patternObject);
		AutomationElement GetUpdatedCache(CacheRequest request);
		IUiElement FindFirst(TreeScope scope, System.Windows.Automation.Condition condition);
		IUiEltCollection FindAll(TreeScope scope, System.Windows.Automation.Condition condition);
		AutomationProperty[] GetSupportedProperties();
		IBasePattern[] GetSupportedPatterns();
		void SetFocus();
		bool TryGetClickablePoint(out Point pt);
		Point GetClickablePoint();
		IUiElementInformation Cached { get; }
		IUiElementInformation Current { get; }
		IUiElement CachedParent { get; }
		IUiEltCollection CachedChildren { get; }
        
		AutomationElement GetSourceElement();
		void SetSourceElement<T>(T element);
		string Tag { get; set; }

		// internal methods
		object GetPatternPropertyValue(AutomationProperty property, bool useCache);

		// InnerElementTypes InnerElementType { get; set; }
	}
}
