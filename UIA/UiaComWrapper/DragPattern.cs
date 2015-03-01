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
    public class DragPattern : BasePattern
    {

        private UIAutomationClient.IUIAutomationDragPattern _pattern;
        public static readonly AutomationProperty IsGrabbedProperty = DragPatternIdentifiers.IsGrabbedProperty;
        public static readonly AutomationProperty GrabbedItemsProperty = DragPatternIdentifiers.GrabbedItemsProperty;
        public static readonly AutomationProperty DropEffectProperty = DragPatternIdentifiers.DropEffectProperty;
        public static readonly AutomationProperty DropEffectsProperty = DragPatternIdentifiers.DropEffectsProperty;
        public static readonly AutomationEvent DragStartEvent = DragPatternIdentifiers.DragStartEvent;
        public static readonly AutomationEvent DragCancelEvent = DragPatternIdentifiers.DragCancelEvent;
        public static readonly AutomationEvent DragCompleteEvent = DragPatternIdentifiers.DragCompleteEvent;
        public static readonly AutomationPattern Pattern = DragPatternIdentifiers.Pattern;


        private DragPattern(AutomationElement el, UIAutomationClient.IUIAutomationDragPattern pattern, bool cached)
            : base(el, cached)
        {
            Debug.Assert(pattern != null);
            this._pattern = pattern;
        }

        internal static object Wrap(AutomationElement el, object pattern, bool cached)
        {
            return (pattern == null) ? null : new DragPattern(el, (UIAutomationClient.IUIAutomationDragPattern)pattern, cached);
        }


        public DragPatternInformation Cached
        {
            get
            {
                Utility.ValidateCached(this._cached);
                return new DragPatternInformation(this._el, true);
            }
        }

        public DragPatternInformation Current
        {
            get
            {
                return new DragPatternInformation(this._el, false);
            }
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct DragPatternInformation
        {
            private AutomationElement _el;
            private bool _isCached;
            internal DragPatternInformation(AutomationElement element, bool isCached)
            {
                this._el = element;
                this._isCached = isCached;
            }

            public bool IsGrabbed
            {
                get
                {
                    return (bool)this._el.GetPropertyValue(DragPattern.IsGrabbedProperty, _isCached);
                }
            }

            public AutomationElement[] GrabbedItems
            {
                get
                {
                    return (AutomationElement[])this._el.GetPropertyValue(DragPattern.GrabbedItemsProperty, _isCached);
                }
            }

            public string DropEffect
            {
                get
                {
                    return (string)this._el.GetPropertyValue(DragPattern.DropEffectProperty, _isCached);
                }
            }

            public string[] DropEffects
            {
                get
                {
                    return (string[])this._el.GetPropertyValue(DragPattern.DropEffectsProperty, _isCached);
                }
            }
        }
    }
}
