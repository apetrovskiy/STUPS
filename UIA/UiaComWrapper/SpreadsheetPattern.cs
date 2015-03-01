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
    public class SpreadsheetPattern : BasePattern
    {

        private UIAutomationClient.IUIAutomationSpreadsheetPattern _pattern;
        public static readonly AutomationPattern Pattern = SpreadsheetPatternIdentifiers.Pattern;

        private SpreadsheetPattern(AutomationElement el, UIAutomationClient.IUIAutomationSpreadsheetPattern pattern, bool cached)
            : base(el, cached)
                                                                    {
            Debug.Assert(pattern != null);
            this._pattern = pattern;
        }

        internal static object Wrap(AutomationElement el, object pattern, bool cached)
        {
            return (pattern == null) ? null : new SpreadsheetPattern(el, (UIAutomationClient.IUIAutomationSpreadsheetPattern)pattern, cached);
        }

        public AutomationElement GetItemByName(string name)
        {
            try
            {
                return AutomationElement.Wrap(
                    this._pattern.GetItemByName(name));
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }
    }

    public class SpreadsheetItemPattern : BasePattern
    {

        private UIAutomationClient.IUIAutomationSpreadsheetItemPattern _pattern;
        public static readonly AutomationPattern Pattern = SpreadsheetItemPatternIdentifiers.Pattern;
        public static readonly AutomationProperty FormulaProperty = SpreadsheetItemPatternIdentifiers.FormulaProperty;
        public static readonly AutomationProperty AnnotationObjectsProperty = SpreadsheetItemPatternIdentifiers.AnnotationObjectsProperty;
        public static readonly AutomationProperty AnnotationTypesProperty = SpreadsheetItemPatternIdentifiers.AnnotationTypesProperty;

        private SpreadsheetItemPattern(AutomationElement el, UIAutomationClient.IUIAutomationSpreadsheetItemPattern pattern, bool cached)
            : base(el, cached)
        {
            Debug.Assert(pattern != null);
            this._pattern = pattern;
        }

        internal static object Wrap(AutomationElement el, object pattern, bool cached)
        {
            return (pattern == null) ? null : new SpreadsheetItemPattern(el, (UIAutomationClient.IUIAutomationSpreadsheetItemPattern)pattern, cached);
        }

        public SpreadsheetItemPatternInformation Cached
        {
            get
            {
                Utility.ValidateCached(this._cached);
                return new SpreadsheetItemPatternInformation(this._el, true);
            }
        }

        public SpreadsheetItemPatternInformation Current
        {
            get
            {
                return new SpreadsheetItemPatternInformation(this._el, false);
            }
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct SpreadsheetItemPatternInformation
        {
            private AutomationElement _el;
            private bool _isCached;
            internal SpreadsheetItemPatternInformation(AutomationElement element, bool isCached)
            {
                this._el = element;
                this._isCached = isCached;
            }

            public string Formula
            {
                get
                {
                    return (string)this._el.GetPropertyValue(SpreadsheetItemPattern.FormulaProperty, _isCached);
                }
            }

            public AutomationElement[] GetAnnotationObjects()
            {
                return (AutomationElement[])this._el.GetPropertyValue(SpreadsheetItemPattern.AnnotationObjectsProperty, _isCached);
            }

            public AnnotationType[] GetAnnotationTypes()
            {
                return (AnnotationType[])this._el.GetPropertyValue(SpreadsheetItemPattern.AnnotationTypesProperty, _isCached);
            }
        }
    }
}