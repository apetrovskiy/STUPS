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
    public class TablePattern : GridPattern
    {
        
        private UIAutomationClient.IUIAutomationTablePattern _pattern;
        public new static readonly AutomationPattern Pattern = TablePatternIdentifiers.Pattern;
        public static readonly AutomationProperty ColumnHeadersProperty = TablePatternIdentifiers.ColumnHeadersProperty;
        public static readonly AutomationProperty RowHeadersProperty = TablePatternIdentifiers.RowHeadersProperty;
        public static readonly AutomationProperty RowOrColumnMajorProperty = TablePatternIdentifiers.RowOrColumnMajorProperty;


        
        private TablePattern(AutomationElement el, UIAutomationClient.IUIAutomationTablePattern tablePattern, UIAutomationClient.IUIAutomationGridPattern gridPattern, bool cached)
            : base(el, gridPattern, cached)
        {
            Debug.Assert(tablePattern != null);
            this._pattern = tablePattern;
        }

        internal new static object Wrap(AutomationElement el, object pattern, bool cached)
        {
            TablePattern result = null;
            if (pattern != null)
            {
                UIAutomationClient.IUIAutomationGridPattern gridPattern =
                    (UIAutomationClient.IUIAutomationGridPattern)el.GetRawPattern(GridPattern.Pattern, cached);
                if (gridPattern != null)
                {
                    result = new TablePattern(el, (UIAutomationClient.IUIAutomationTablePattern)pattern,
                        gridPattern, cached);
                }
            }
            return result;
        }

        
        public new TablePatternInformation Cached
        {
            get
            {
                Utility.ValidateCached(this._cached);
                return new TablePatternInformation(this._el, true);
            }
        }

        public new TablePatternInformation Current
        {
            get
            {
                return new TablePatternInformation(this._el, false);
            }
        }


        
        [StructLayout(LayoutKind.Sequential)]
        public struct TablePatternInformation
        {
            private AutomationElement _el;
            private bool _isCached;
            internal TablePatternInformation(AutomationElement element, bool isCached)
            {
                this._el = element;
                this._isCached = isCached;
            }

            public AutomationElement[] GetRowHeaders()
            {
                return (AutomationElement[])this._el.GetPropertyValue(TablePattern.RowHeadersProperty, _isCached);
            }

            public AutomationElement[] GetColumnHeaders()
            {
                return (AutomationElement[])this._el.GetPropertyValue(TablePattern.ColumnHeadersProperty, _isCached);
            }

            public int RowCount
            {
                get
                {
                    return (int)this._el.GetPropertyValue(TablePattern.RowCountProperty, _isCached);
                }
            }
            public int ColumnCount
            {
                get
                {
                    return (int)this._el.GetPropertyValue(TablePattern.ColumnCountProperty, _isCached);
                }
            }
            public RowOrColumnMajor RowOrColumnMajor
            {
                get
                {
                    return (RowOrColumnMajor)this._el.GetPropertyValue(TablePattern.RowOrColumnMajorProperty, _isCached);
                }
            }
        }
    }

    public class TableItemPattern : GridItemPattern
    {
        
        private UIAutomationClient.IUIAutomationTableItemPattern _pattern;
        public new static readonly AutomationPattern Pattern = TableItemPatternIdentifiers.Pattern;
        public static readonly AutomationProperty ColumnHeaderItemsProperty = TableItemPatternIdentifiers.ColumnHeaderItemsProperty;
        public static readonly AutomationProperty RowHeaderItemsProperty = TableItemPatternIdentifiers.RowHeaderItemsProperty;

        
        private TableItemPattern(AutomationElement el, UIAutomationClient.IUIAutomationTableItemPattern tablePattern, UIAutomationClient.IUIAutomationGridItemPattern gridPattern, bool cached)
            : base(el, gridPattern, cached)
        {
            Debug.Assert(tablePattern != null);
            this._pattern = tablePattern;
        }

        internal new static object Wrap(AutomationElement el, object pattern, bool cached)
        {
            TableItemPattern result = null;
            if (pattern != null)
            {
                UIAutomationClient.IUIAutomationGridItemPattern gridPattern =
                    (UIAutomationClient.IUIAutomationGridItemPattern)el.GetRawPattern(GridItemPattern.Pattern, cached);
                if (gridPattern != null)
                {
                    result = new TableItemPattern(el, (UIAutomationClient.IUIAutomationTableItemPattern)pattern,
                        gridPattern, cached);
                }
            }
            return result;
        }

        
        public new TableItemPatternInformation Cached
        {
            get
            {
                Utility.ValidateCached(this._cached);
                return new TableItemPatternInformation(this._el, true);
            }
        }

        public new TableItemPatternInformation Current
        {
            get
            {
                return new TableItemPatternInformation(this._el, false);
            }
        }


        
        [StructLayout(LayoutKind.Sequential)]
        public struct TableItemPatternInformation
        {
            private AutomationElement _el;
            private bool _isCached;
            internal TableItemPatternInformation(AutomationElement element, bool isCached)
            {
                this._el = element;
                this._isCached = isCached;
            }
            
            public int Row
            {
                get
                {
                    return (int)this._el.GetPropertyValue(TableItemPattern.RowProperty, _isCached);
                }
            }
            public int Column
            {
                get
                {
                    return (int)this._el.GetPropertyValue(TableItemPattern.ColumnProperty, _isCached);
                }
            }
            public int RowSpan
            {
                get
                {
                    return (int)this._el.GetPropertyValue(TableItemPattern.RowSpanProperty, _isCached);
                }
            }
            public int ColumnSpan
            {
                get
                {
                    return (int)this._el.GetPropertyValue(TableItemPattern.ColumnSpanProperty, _isCached);
                }
            }
            public AutomationElement ContainingGrid
            {
                get
                {
                    return (AutomationElement)this._el.GetPropertyValue(TableItemPattern.ContainingGridProperty, _isCached);
                }
            }

            public AutomationElement[] GetRowHeaderItems()
            {
                return (AutomationElement[])this._el.GetPropertyValue(TableItemPattern.RowHeaderItemsProperty, _isCached);
            }

            public AutomationElement[] GetColumnHeaderItems()
            {
                return (AutomationElement[])this._el.GetPropertyValue(TableItemPattern.ColumnHeaderItemsProperty, _isCached);
            }
        }
    }
}