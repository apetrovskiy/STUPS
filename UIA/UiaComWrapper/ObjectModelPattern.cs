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
    public class ObjectModelPattern : BasePattern
    {
        private UIAutomationClient.IUIAutomationObjectModelPattern _pattern;
        public static readonly AutomationPattern Pattern = ObjectModelPatternIdentifiers.Pattern;

        private ObjectModelPattern(AutomationElement el, UIAutomationClient.IUIAutomationObjectModelPattern pattern, bool cached)
            : base(el, cached)
        {
            Debug.Assert(pattern != null);
            this._pattern = pattern;
        }

        public object GetUnderlyingObjectModel()
        {
            try
            {
                return this._pattern.GetUnderlyingObjectModel();
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        internal static object Wrap(AutomationElement el, object pattern, bool cached)
        {
            return (pattern == null) ? null : new ObjectModelPattern(el, (UIAutomationClient.IUIAutomationObjectModelPattern)pattern, cached);
        }
    }
}
