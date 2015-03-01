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
    public class RangeValuePattern : BasePattern
    {
        
        private UIAutomationClient.IUIAutomationRangeValuePattern _pattern;
        public static readonly AutomationPattern Pattern = RangeValuePatternIdentifiers.Pattern;
        public static readonly AutomationProperty IsReadOnlyProperty = RangeValuePatternIdentifiers.IsReadOnlyProperty;
        public static readonly AutomationProperty LargeChangeProperty = RangeValuePatternIdentifiers.LargeChangeProperty;
        public static readonly AutomationProperty MaximumProperty = RangeValuePatternIdentifiers.MaximumProperty;
        public static readonly AutomationProperty MinimumProperty = RangeValuePatternIdentifiers.MinimumProperty;
        public static readonly AutomationProperty SmallChangeProperty = RangeValuePatternIdentifiers.SmallChangeProperty;
        public static readonly AutomationProperty ValueProperty = RangeValuePatternIdentifiers.ValueProperty;

        
        private RangeValuePattern(AutomationElement el, UIAutomationClient.IUIAutomationRangeValuePattern pattern, bool cached)
            : base(el, cached)
        {
            Debug.Assert(pattern != null);
            this._pattern = pattern;
        }

        internal static object Wrap(AutomationElement el, object pattern, bool cached)
        {
            return (pattern == null) ? null : new RangeValuePattern(el, (UIAutomationClient.IUIAutomationRangeValuePattern)pattern, cached);
        }

        public void SetValue(double value)
        {
            try
            {
                this._pattern.SetValue(value);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        
        public RangeValuePatternInformation Cached
        {
            get
            {
                Utility.ValidateCached(this._cached);
                return new RangeValuePatternInformation(this._el, true);
            }
        }

        public RangeValuePatternInformation Current
        {
            get
            {
                return new RangeValuePatternInformation(this._el, false);
            }
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public struct RangeValuePatternInformation
        {
            private AutomationElement _el;
            private bool _isCached;
            internal RangeValuePatternInformation(AutomationElement element, bool isCached)
            {
                this._el = element;
                this._isCached = isCached;
            }

            public double Value
            {
                get
                {
                    return (double)this._el.GetPropertyValue(RangeValuePattern.ValueProperty, _isCached);
                }
            }
            public bool IsReadOnly
            {
                get
                {
                    return (bool)this._el.GetPropertyValue(RangeValuePattern.IsReadOnlyProperty, _isCached);
                }
            }
            public double Maximum
            {
                get
                {
                    return (double)this._el.GetPropertyValue(RangeValuePattern.MaximumProperty, _isCached);
                }
            }
            public double Minimum
            {
                get
                {
                    return (double)this._el.GetPropertyValue(RangeValuePattern.MinimumProperty, _isCached);
                }
            }
            public double LargeChange
            {
                get
                {
                    return (double)this._el.GetPropertyValue(RangeValuePattern.LargeChangeProperty, _isCached);
                }
            }
            public double SmallChange
            {
                get
                {
                    return (double)this._el.GetPropertyValue(RangeValuePattern.SmallChangeProperty, _isCached);
                }
            }
        }
    }

    public class ValuePattern : BasePattern
    {
        
        private UIAutomationClient.IUIAutomationValuePattern _pattern;
        public static readonly AutomationPattern Pattern = ValuePatternIdentifiers.Pattern;
        public static readonly AutomationProperty IsReadOnlyProperty = ValuePatternIdentifiers.IsReadOnlyProperty;
        public static readonly AutomationProperty ValueProperty = ValuePatternIdentifiers.ValueProperty;


        
        private ValuePattern(AutomationElement el, UIAutomationClient.IUIAutomationValuePattern pattern, bool cached)
            : base(el, cached)
        {
            Debug.Assert(pattern != null);
            this._pattern = pattern;
        }

        internal static object Wrap(AutomationElement el, object pattern, bool cached)
        {
            return (pattern == null) ? null : new ValuePattern(el, (UIAutomationClient.IUIAutomationValuePattern)pattern, cached);
        }

        public void SetValue(string value)
        {
            try
            {
                this._pattern.SetValue(value);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        
        public ValuePatternInformation Cached
        {
            get
            {
                Utility.ValidateCached(this._cached);
                return new ValuePatternInformation(this._el, true);
            }
        }

        public ValuePatternInformation Current
        {
            get
            {
                return new ValuePatternInformation(this._el, false);
            }
        }


        
        [StructLayout(LayoutKind.Sequential)]
        public struct ValuePatternInformation
        {
            private AutomationElement _el;
            private bool _isCached;
            internal ValuePatternInformation(AutomationElement element, bool isCached)
            {
                this._el = element;
                this._isCached = isCached;
            }

            public string Value
            {
                get
                {
                    return (string)this._el.GetPropertyValue(ValuePattern.ValueProperty, _isCached);
                }
            }

            public bool IsReadOnly
            {
                get
                {
                    return (bool)this._el.GetPropertyValue(ValuePattern.IsReadOnlyProperty, _isCached);
                }
            }
        }
    }
}
