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
    public class TogglePattern : BasePattern
    {
        
        private UIAutomationClient.IUIAutomationTogglePattern _pattern;
        public static readonly AutomationPattern Pattern = TogglePatternIdentifiers.Pattern;
        public static readonly AutomationProperty ToggleStateProperty = TogglePatternIdentifiers.ToggleStateProperty;

        
        private TogglePattern(AutomationElement el, UIAutomationClient.IUIAutomationTogglePattern pattern, bool cached)
            : base(el, cached)
        {
            Debug.Assert(pattern != null);
            this._pattern = pattern;
        }

        internal static object Wrap(AutomationElement el, object pattern, bool cached)
        {
            return (pattern == null) ? null : new TogglePattern(el, (UIAutomationClient.IUIAutomationTogglePattern)pattern, cached);
        }

        public void Toggle()
        {
            try
            {
                this._pattern.Toggle();
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        
        public TogglePatternInformation Cached
        {
            get
            {
                Utility.ValidateCached(this._cached);
                return new TogglePatternInformation(this._el, true);
            }
        }

        public TogglePatternInformation Current
        {
            get
            {
                return new TogglePatternInformation(this._el, false);
            }
        }


        
        [StructLayout(LayoutKind.Sequential)]
        public struct TogglePatternInformation
        {
            private AutomationElement _el;
            private bool _isCached;
            internal TogglePatternInformation(AutomationElement element, bool isCached)
            {
                this._el = element;
                this._isCached = isCached;
            }

            public ToggleState ToggleState
            {
                get
                {
                    return (ToggleState)this._el.GetPropertyValue(TogglePattern.ToggleStateProperty, _isCached);
                }
            }
        }
    }
}