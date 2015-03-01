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
    public class DropTargetPattern : BasePattern
    {

        private UIAutomationClient.IUIAutomationDropTargetPattern _pattern;
        public static readonly AutomationProperty DropTargetEffectProperty = DropTargetPatternIdentifiers.DropTargetEffectProperty;
        public static readonly AutomationProperty DropTargetEffectsProperty = DropTargetPatternIdentifiers.DropTargetEffectsProperty;
        public static readonly AutomationEvent DropTargetEnterEvent = DropTargetPatternIdentifiers.DragEnterEvent;
        public static readonly AutomationEvent DropTargetLeaveEvent = DropTargetPatternIdentifiers.DragLeaveEvent;
        public static readonly AutomationEvent DroppedEvent = DropTargetPatternIdentifiers.DroppedEvent;
        public static readonly AutomationPattern Pattern = DropTargetPatternIdentifiers.Pattern;


        private DropTargetPattern(AutomationElement el, UIAutomationClient.IUIAutomationDropTargetPattern pattern, bool cached)
            : base(el, cached)
        {
            Debug.Assert(pattern != null);
            this._pattern = pattern;
        }

        internal static object Wrap(AutomationElement el, object pattern, bool cached)
        {
            return (pattern == null) ? null : new DropTargetPattern(el, (UIAutomationClient.IUIAutomationDropTargetPattern)pattern, cached);
        }


        public DropTargetPatternInformation Cached
        {
            get
            {
                Utility.ValidateCached(this._cached);
                return new DropTargetPatternInformation(this._el, true);
            }
        }

        public DropTargetPatternInformation Current
        {
            get
            {
                return new DropTargetPatternInformation(this._el, false);
            }
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct DropTargetPatternInformation
        {
            private AutomationElement _el;
            private bool _isCached;
            internal DropTargetPatternInformation(AutomationElement element, bool isCached)
            {
                this._el = element;
                this._isCached = isCached;
            }

            public string DropTargetEffect
            {
                get
                {
                    return (string)this._el.GetPropertyValue(DropTargetPattern.DropTargetEffectProperty, _isCached);
                }
            }

            public string[] DropTargetEffects
            {
                get
                {
                    return (string[])this._el.GetPropertyValue(DropTargetPattern.DropTargetEffectsProperty, _isCached);
                }
            }
        }
    }
}
