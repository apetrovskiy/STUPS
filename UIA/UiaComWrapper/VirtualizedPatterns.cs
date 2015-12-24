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
    public class ItemContainerPattern : BasePattern
    {
        private UIAutomationClient.IUIAutomationItemContainerPattern _pattern;
        public static readonly AutomationPattern Pattern = ItemContainerPatternIdentifiers.Pattern;

        private ItemContainerPattern(AutomationElement el, UIAutomationClient.IUIAutomationItemContainerPattern pattern, bool cached)
            : base(el, cached)
        {
            Debug.Assert(pattern != null);
            this._pattern = pattern;
        }

        public AutomationElement FindItemByProperty(AutomationElement startAfter, AutomationProperty property, object value)
        {
            try
            {
                return AutomationElement.Wrap(
                    this._pattern.FindItemByProperty(
                        (startAfter == null) ? null : startAfter.NativeElement,
                        (property == null) ? 0 : property.Id,
                        Utility.UnwrapObject(value)));
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        internal static object Wrap(AutomationElement el, object pattern, bool cached)
        {
            return (pattern == null) ? null : new ItemContainerPattern(el, (UIAutomationClient.IUIAutomationItemContainerPattern)pattern, cached);
        }
    }

    public class VirtualizedItemPattern : BasePattern
    {
        private UIAutomationClient.IUIAutomationVirtualizedItemPattern _pattern;
        public static readonly AutomationPattern Pattern = VirtualizedItemPatternIdentifiers.Pattern;

        private VirtualizedItemPattern(AutomationElement el, UIAutomationClient.IUIAutomationVirtualizedItemPattern pattern, bool cached)
            : base(el, cached)
        {
            Debug.Assert(pattern != null);
            this._pattern = pattern;
        }

        public void Realize()
        {
            try
            {
                this._pattern.Realize();
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        internal static object Wrap(AutomationElement el, object pattern, bool cached)
        {
            return (pattern == null) ? null : new VirtualizedItemPattern(el, (UIAutomationClient.IUIAutomationVirtualizedItemPattern)pattern, cached);
        }
    }
}
