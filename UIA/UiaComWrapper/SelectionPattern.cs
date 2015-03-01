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
    public class SelectionPattern : BasePattern
    {
        
        private UIAutomationClient.IUIAutomationSelectionPattern _pattern;
        public static readonly AutomationPattern Pattern = SelectionPatternIdentifiers.Pattern;
        public static readonly AutomationProperty CanSelectMultipleProperty = SelectionPatternIdentifiers.CanSelectMultipleProperty;
        public static readonly AutomationEvent InvalidatedEvent = SelectionPatternIdentifiers.InvalidatedEvent;
        public static readonly AutomationProperty IsSelectionRequiredProperty = SelectionPatternIdentifiers.IsSelectionRequiredProperty;
        public static readonly AutomationProperty SelectionProperty = SelectionPatternIdentifiers.SelectionProperty;

        
        private SelectionPattern(AutomationElement el, UIAutomationClient.IUIAutomationSelectionPattern pattern, bool cached)
            : base(el, cached)
        {
            Debug.Assert(pattern != null);
            this._pattern = pattern;
        }

        internal static object Wrap(AutomationElement el, object pattern, bool cached)
        {
            return (pattern == null) ? null : new SelectionPattern(el, (UIAutomationClient.IUIAutomationSelectionPattern)pattern, cached);
        }

        
        public SelectionPatternInformation Cached
        {
            get
            {
                Utility.ValidateCached(this._cached);
                return new SelectionPatternInformation(this._el, true);
            }
        }

        public SelectionPatternInformation Current
        {
            get
            {
                return new SelectionPatternInformation(this._el, false);
            }
        }

        
        [StructLayout(LayoutKind.Sequential)]
        public struct SelectionPatternInformation
        {
            private AutomationElement _el;
            private bool _isCached;
            internal SelectionPatternInformation(AutomationElement element, bool isCached)
            {
                this._el = element;
                this._isCached = isCached;
            }

            public AutomationElement[] GetSelection()
            {
                return (AutomationElement[])this._el.GetPropertyValue(SelectionPattern.SelectionProperty, _isCached);
            }

            public bool CanSelectMultiple
            {
                get
                {
                    return (bool)this._el.GetPropertyValue(SelectionPattern.CanSelectMultipleProperty, _isCached);
                }
            }
            public bool IsSelectionRequired
            {
                get
                {
                    return (bool)this._el.GetPropertyValue(SelectionPattern.IsSelectionRequiredProperty, _isCached);
                }
            }
        }
    }

    public class SelectionItemPattern : BasePattern
    {
        
        private UIAutomationClient.IUIAutomationSelectionItemPattern _pattern;
        public static readonly AutomationPattern Pattern = SelectionItemPatternIdentifiers.Pattern;
        public static readonly AutomationEvent ElementAddedToSelectionEvent = SelectionItemPatternIdentifiers.ElementAddedToSelectionEvent;
        public static readonly AutomationEvent ElementRemovedFromSelectionEvent = SelectionItemPatternIdentifiers.ElementRemovedFromSelectionEvent;
        public static readonly AutomationEvent ElementSelectedEvent = SelectionItemPatternIdentifiers.ElementSelectedEvent;
        public static readonly AutomationProperty IsSelectedProperty = SelectionItemPatternIdentifiers.IsSelectedProperty;
        public static readonly AutomationProperty SelectionContainerProperty = SelectionItemPatternIdentifiers.SelectionContainerProperty;


        
        private SelectionItemPattern(AutomationElement el, UIAutomationClient.IUIAutomationSelectionItemPattern pattern, bool cached)
            : base(el, cached)
        {
            Debug.Assert(pattern != null);
            this._pattern = pattern;
        }

        internal static object Wrap(AutomationElement el, object pattern, bool cached)
        {
            return (pattern == null) ? null : new SelectionItemPattern(el, (UIAutomationClient.IUIAutomationSelectionItemPattern)pattern, cached);
        }

        public void AddToSelection()
        {
            try
            {
                this._pattern.AddToSelection();
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        public void RemoveFromSelection()
        {
            try
            {
                this._pattern.RemoveFromSelection();
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        public void Select()
        {
            try
            {
                this._pattern.Select();
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        
        public SelectionItemPatternInformation Cached
        {
            get
            {
                Utility.ValidateCached(this._cached);
                return new SelectionItemPatternInformation(this._el, true);
            }
        }

        public SelectionItemPatternInformation Current
        {
            get
            {
                return new SelectionItemPatternInformation(this._el, false);
            }
        }

        
        [StructLayout(LayoutKind.Sequential)]
        public struct SelectionItemPatternInformation
        {
            private AutomationElement _el;
            private bool _isCached;
            internal SelectionItemPatternInformation(AutomationElement element, bool isCached)
            {
                this._el = element;
                this._isCached = isCached;
            }

            public bool IsSelected
            {
                get
                {
                    return (bool)this._el.GetPropertyValue(SelectionItemPattern.IsSelectedProperty, _isCached);
                }
            }

            public AutomationElement SelectionContainer
            {
                get
                {
                    return (AutomationElement)this._el.GetPropertyValue(SelectionItemPattern.SelectionContainerProperty, _isCached);
                }
            }
        }
    }
}