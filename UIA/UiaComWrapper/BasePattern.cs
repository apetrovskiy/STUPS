// (c) Copyright Microsoft, 2012.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.



using System;
using System.Diagnostics;

namespace System.Windows.Automation
{
    public class BasePattern
    {
        
        internal AutomationElement _el;
        internal bool _cached;

        
        internal BasePattern(AutomationElement el, bool cached)
        {
            Debug.Assert(el != null);
            this._el = el;
            this._cached = cached;
        }
    }
}
