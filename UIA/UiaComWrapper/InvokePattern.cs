// (c) Copyright Microsoft, 2012.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.



using System;
using System.Diagnostics;
using UIAComWrapperInternal;

namespace System.Windows.Automation
{
    public class InvokePattern : BasePattern
    {
        
        private UIAutomationClient.IUIAutomationInvokePattern _pattern;
        public static readonly AutomationEvent InvokedEvent = InvokePatternIdentifiers.InvokedEvent;
        public static readonly AutomationPattern Pattern = InvokePatternIdentifiers.Pattern;

        
        private InvokePattern(AutomationElement el, UIAutomationClient.IUIAutomationInvokePattern pattern, bool cached)
            : base(el, cached)
        {
            Debug.Assert(pattern != null);
            this._pattern = pattern;
        }

        public void Invoke()
        {
            try
            {
                this._pattern.Invoke();
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        internal static object Wrap(AutomationElement el, object pattern, bool cached)
        {
            return (pattern == null) ? null : new InvokePattern(el, (UIAutomationClient.IUIAutomationInvokePattern)pattern, cached);
        }
    }
}
