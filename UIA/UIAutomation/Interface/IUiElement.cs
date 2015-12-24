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
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;

//    using System.Collections.Generic;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    using System.Windows;

    public interface IUiElement : IDisposable
    {
        bool Equals(object obj);
        int GetHashCode();
        int[] GetRuntimeId();
        object GetCurrentPropertyValue(classic.AutomationProperty property);
        object GetCurrentPropertyValue(classic.AutomationProperty property, bool ignoreDefaultValue);
        TN GetCurrentPattern<TN>(classic.AutomationPattern pattern) where TN : IBasePattern;
        object GetCurrentPattern(classic.AutomationPattern pattern);
        bool TryGetCurrentPattern(classic.AutomationPattern pattern, out object patternObject);
        object GetCachedPropertyValue(classic.AutomationProperty property);
        object GetCachedPropertyValue(classic.AutomationProperty property, bool ignoreDefaultValue);
        object GetCachedPattern(classic.AutomationPattern pattern);
        bool TryGetCachedPattern(classic.AutomationPattern pattern, out object patternObject);
        classic.AutomationElement GetUpdatedCache(classic.CacheRequest request);
        IUiElement FindFirst(classic.TreeScope scope, classic.Condition condition);
        IUiEltCollection FindAll(classic.TreeScope scope, classic.Condition condition);
        // 20140203
//        IUiEltCollection FindAll(TreeScope scope, System.Windows.Automation.Condition condition, IEnumerable<IUiElement> excludeElements);
        classic.AutomationProperty[] GetSupportedProperties();
        IBasePattern[] GetSupportedPatterns();
        void SetFocus();
        bool TryGetClickablePoint(out Point pt);
        Point GetClickablePoint();
        // 20140312
        // moved
//        IUiElementInformation Cached { get; }
//        IUiElementInformation Current { get; }
//        IUiElement CachedParent { get; }
//        IUiEltCollection CachedChildren { get; }
        
        IUiElementInformation GetCached();
        IUiElement GetCachedParent();
        IUiEltCollection GetCachedChildren();
        IUiElementInformation GetCurrent();
        
        object GetSourceElement();
        void SetSourceElement<T>(T element);
        string GetTag();
        void SetTag(string tag);
        bool IsValid();
        
        // internal methods
        object GetPatternPropertyValue(classic.AutomationProperty property, bool useCache);
    }
}
