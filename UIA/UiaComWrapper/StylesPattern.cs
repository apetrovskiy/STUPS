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
    public class StylesPattern : BasePattern
    {

        private UIAutomationClient.IUIAutomationStylesPattern _pattern;
        public static readonly AutomationProperty StyleIdProperty = StylesPatternIdentifiers.StyleIdProperty;
        public static readonly AutomationProperty StyleNameProperty = StylesPatternIdentifiers.StyleNameProperty;
        public static readonly AutomationProperty FillColorProperty = StylesPatternIdentifiers.FillColorProperty;
        public static readonly AutomationProperty FillPatternStyleProperty = StylesPatternIdentifiers.FillPatternStyleProperty;
        public static readonly AutomationProperty ShapeProperty = StylesPatternIdentifiers.ShapeProperty;
        public static readonly AutomationProperty FillPatternColorProperty = StylesPatternIdentifiers.FillPatternColorProperty;
        public static readonly AutomationProperty ExtendedPropertiesProperty = StylesPatternIdentifiers.ExtendedPropertiesProperty;
        public static readonly AutomationPattern Pattern = StylesPatternIdentifiers.Pattern;


        private StylesPattern(AutomationElement el, UIAutomationClient.IUIAutomationStylesPattern pattern, bool cached)
            : base(el, cached)
        {
            Debug.Assert(pattern != null);
            this._pattern = pattern;
        }

        internal static object Wrap(AutomationElement el, object pattern, bool cached)
        {
            return (pattern == null) ? null : new StylesPattern(el, (UIAutomationClient.IUIAutomationStylesPattern)pattern, cached);
        }


        public StylesPatternInformation Cached
        {
            get
            {
                Utility.ValidateCached(this._cached);
                return new StylesPatternInformation(this._el, true);
            }
        }

        public StylesPatternInformation Current
        {
            get
            {
                return new StylesPatternInformation(this._el, false);
            }
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct StylesPatternInformation
        {
            private AutomationElement _el;
            private bool _isCached;
            internal StylesPatternInformation(AutomationElement element, bool isCached)
            {
                this._el = element;
                this._isCached = isCached;
            }

            public StyleId StyleId
            {
                get
                {
                    return (StyleId)(int)this._el.GetPropertyValue(StylesPattern.StyleIdProperty, _isCached);
                }
            }

            public string StyleName
            {
                get
                {
                    return (string)this._el.GetPropertyValue(StylesPattern.StyleNameProperty, _isCached);
                }
            }

            public int FillColor
            {
                get
                {
                    return (int)this._el.GetPropertyValue(StylesPattern.FillColorProperty, _isCached);
                }
            }

            public string FillPatternStyle
            {
                get
                {
                    return (string)this._el.GetPropertyValue(StylesPattern.FillPatternStyleProperty, _isCached);
                }
            }

            public string Shape
            {
                get
                {
                    return (string)this._el.GetPropertyValue(StylesPattern.ShapeProperty, _isCached);
                }
            }

            public int FillPatternColor
            {
                get
                {
                    return (int)this._el.GetPropertyValue(StylesPattern.FillPatternColorProperty, _isCached);
                }
            }

            public string ExtendedProperties
            {
                get
                {
                    return (string)this._el.GetPropertyValue(StylesPattern.ExtendedPropertiesProperty, _isCached);
                }
            }


        }
    }
}
