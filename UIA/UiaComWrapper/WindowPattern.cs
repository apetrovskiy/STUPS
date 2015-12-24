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
    public class WindowPattern : BasePattern
    {
        
        private UIAutomationClient.IUIAutomationWindowPattern _pattern;
        public static readonly AutomationPattern Pattern = WindowPatternIdentifiers.Pattern;
        public static readonly AutomationProperty CanMaximizeProperty = WindowPatternIdentifiers.CanMaximizeProperty;
        public static readonly AutomationProperty CanMinimizeProperty = WindowPatternIdentifiers.CanMinimizeProperty;
        public static readonly AutomationProperty IsModalProperty = WindowPatternIdentifiers.IsModalProperty;
        public static readonly AutomationProperty IsTopmostProperty = WindowPatternIdentifiers.IsTopmostProperty;
        public static readonly AutomationEvent WindowClosedEvent = WindowPatternIdentifiers.WindowClosedEvent;
        public static readonly AutomationProperty WindowInteractionStateProperty = WindowPatternIdentifiers.WindowInteractionStateProperty;
        public static readonly AutomationEvent WindowOpenedEvent = WindowPatternIdentifiers.WindowOpenedEvent;
        public static readonly AutomationProperty WindowVisualStateProperty = WindowPatternIdentifiers.WindowVisualStateProperty;

        
        private WindowPattern(AutomationElement el, UIAutomationClient.IUIAutomationWindowPattern pattern, bool cached)
            : base(el, cached)
        {
            Debug.Assert(pattern != null);
            this._pattern = pattern;
        }

        internal static object Wrap(AutomationElement el, object pattern, bool cached)
        {
            return (pattern == null) ? null : new WindowPattern(el, (UIAutomationClient.IUIAutomationWindowPattern)pattern, cached);
        }

        public void Close()
        {
            try
            {
                this._pattern.Close();
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        public void SetWindowVisualState(WindowVisualState state)
        {
            try
            {
                this._pattern.SetWindowVisualState((UIAutomationClient.WindowVisualState)state);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        public bool WaitForInputIdle(int milliseconds)
        {
            try
            {
                return (0 != this._pattern.WaitForInputIdle(milliseconds));
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        
        public WindowPatternInformation Cached
        {
            get
            {
                Utility.ValidateCached(this._cached);
                return new WindowPatternInformation(this._el, true);
            }
        }

        public WindowPatternInformation Current
        {
            get
            {
                return new WindowPatternInformation(this._el, false);
            }
        }


        
        [StructLayout(LayoutKind.Sequential)]
        public struct WindowPatternInformation
        {
            private AutomationElement _el;
            private bool _isCached;
            internal WindowPatternInformation(AutomationElement element, bool isCached)
            {
                this._el = element;
                this._isCached = isCached;
            }

            public bool CanMaximize
            {
                get
                {
                    return (bool)this._el.GetPropertyValue(WindowPattern.CanMaximizeProperty, _isCached);
                }
            }

            public bool CanMinimize
            {
                get
                {
                    return (bool)this._el.GetPropertyValue(WindowPattern.CanMinimizeProperty, _isCached);
                }
            }

            public bool IsModal
            {
                get
                {
                    return (bool)this._el.GetPropertyValue(WindowPattern.IsModalProperty, _isCached);
                }
            }

            public WindowVisualState WindowVisualState
            {
                get
                {
                    return (WindowVisualState)this._el.GetPropertyValue(WindowPattern.WindowVisualStateProperty, _isCached);
                }
            }

            public WindowInteractionState WindowInteractionState
            {
                get
                {
                    return (WindowInteractionState)this._el.GetPropertyValue(WindowPattern.WindowInteractionStateProperty, _isCached);
                }
            }

            public bool IsTopmost
            {
                get
                {
                    return (bool)this._el.GetPropertyValue(WindowPattern.IsTopmostProperty, _isCached);
                }
            }
        }
    }
}