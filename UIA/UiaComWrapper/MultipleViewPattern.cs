// (c) Copyright Microsoft, 2012.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.



using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UIAComWrapperInternal;

namespace System.Windows.Automation
{
    public class MultipleViewPattern : BasePattern
    {
        
        private UIAutomationClient.IUIAutomationMultipleViewPattern _pattern;
        public static readonly AutomationPattern Pattern = MultipleViewPatternIdentifiers.Pattern;
        public static readonly AutomationProperty CurrentViewProperty = MultipleViewPatternIdentifiers.CurrentViewProperty;
        public static readonly AutomationProperty SupportedViewsProperty = MultipleViewPatternIdentifiers.SupportedViewsProperty;

        
        private MultipleViewPattern(AutomationElement el, UIAutomationClient.IUIAutomationMultipleViewPattern pattern, bool cached)
            : base(el, cached)
        {
            Debug.Assert(pattern != null);
            this._pattern = pattern;
        }

        internal static object Wrap(AutomationElement el, object pattern, bool cached)
        {
            return (pattern == null) ? null : new MultipleViewPattern(el, (UIAutomationClient.IUIAutomationMultipleViewPattern)pattern, cached);
        }

        public string GetViewName(int viewId)
        {
            try
            {
                return this._pattern.GetViewName(viewId);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        public void SetCurrentView(int viewId)
        {
            try
            {
                this._pattern.SetCurrentView(viewId);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        
        public MultipleViewPatternInformation Cached
        {
            get
            {
                Utility.ValidateCached(this._cached);
                return new MultipleViewPatternInformation(this._el, true);
            }
        }

        public MultipleViewPatternInformation Current
        {
            get
            {
                return new MultipleViewPatternInformation(this._el, false);
            }
        }

        
        [StructLayout(LayoutKind.Sequential)]
        public struct MultipleViewPatternInformation
        {
            private AutomationElement _el;
            private bool _isCached;
            internal MultipleViewPatternInformation(AutomationElement element, bool isCached)
            {
                this._el = element;
                this._isCached = isCached;
            }

            public int CurrentView
            {
                get
                {
                    return (int)this._el.GetPropertyValue(MultipleViewPattern.CurrentViewProperty, _isCached);
                }
            }
            public int[] GetSupportedViews()
            {
                    return (int[])this._el.GetPropertyValue(MultipleViewPattern.SupportedViewsProperty, _isCached);
            }
        }
    }
}
