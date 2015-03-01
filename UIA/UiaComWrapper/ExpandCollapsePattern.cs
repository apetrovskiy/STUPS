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
    public class ExpandCollapsePattern : BasePattern
    {
        
        private UIAutomationClient.IUIAutomationExpandCollapsePattern _pattern;
        public static readonly AutomationProperty ExpandCollapseStateProperty = ExpandCollapsePatternIdentifiers.ExpandCollapseStateProperty;
        public static readonly AutomationPattern Pattern = ExpandCollapsePatternIdentifiers.Pattern;

        
        private ExpandCollapsePattern(AutomationElement el, UIAutomationClient.IUIAutomationExpandCollapsePattern pattern, bool cached)
            : base(el, cached)
        {
            Debug.Assert(pattern != null);
            this._pattern = pattern;
        }

        internal static object Wrap(AutomationElement el, object pattern, bool cached)
        {
            return (pattern == null) ? null : new ExpandCollapsePattern(el, (UIAutomationClient.IUIAutomationExpandCollapsePattern)pattern, cached);
        }

        public void Collapse()
        {
                        try
            {
this._pattern.Collapse();            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        public void Expand()
        {
                        try
            {
this._pattern.Expand();            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        
        public ExpandCollapsePatternInformation Cached
        {
            get
            {
                Utility.ValidateCached(this._cached);
                return new ExpandCollapsePatternInformation(this._el, true);
            }
        }

        public ExpandCollapsePatternInformation Current
        {
            get
            {
                return new ExpandCollapsePatternInformation(this._el, false);
            }
        }

        
        [StructLayout(LayoutKind.Sequential)]
        public struct ExpandCollapsePatternInformation
        {
            private AutomationElement _el;
            private bool _isCached;
            internal ExpandCollapsePatternInformation(AutomationElement element, bool isCached)
            {
                this._el = element;
                this._isCached = isCached;
            }

            public ExpandCollapseState ExpandCollapseState
            {
                get
                {
                    return (ExpandCollapseState)this._el.GetPropertyValue(ExpandCollapsePattern.ExpandCollapseStateProperty, _isCached);
                }
            }
        }
    }
}