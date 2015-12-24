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
    public class LegacyIAccessiblePattern : BasePattern
    {
        public static readonly AutomationProperty ChildIdProperty = LegacyIAccessiblePatternIdentifiers.ChildIdProperty;
        public static readonly AutomationProperty NameProperty = LegacyIAccessiblePatternIdentifiers.NameProperty;
        public static readonly AutomationProperty ValueProperty = LegacyIAccessiblePatternIdentifiers.ValueProperty;
        public static readonly AutomationProperty DescriptionProperty = LegacyIAccessiblePatternIdentifiers.DescriptionProperty;
        public static readonly AutomationProperty RoleProperty = LegacyIAccessiblePatternIdentifiers.RoleProperty;
        public static readonly AutomationProperty StateProperty = LegacyIAccessiblePatternIdentifiers.StateProperty;
        public static readonly AutomationProperty HelpProperty = LegacyIAccessiblePatternIdentifiers.HelpProperty;
        public static readonly AutomationProperty KeyboardShortcutProperty = LegacyIAccessiblePatternIdentifiers.KeyboardShortcutProperty;
        public static readonly AutomationProperty SelectionProperty = LegacyIAccessiblePatternIdentifiers.SelectionProperty;
        public static readonly AutomationProperty DefaultActionProperty = LegacyIAccessiblePatternIdentifiers.DefaultActionProperty;
        public static readonly AutomationPattern Pattern = LegacyIAccessiblePatternIdentifiers.Pattern;

        private UIAutomationClient.IUIAutomationLegacyIAccessiblePattern _pattern;

        private LegacyIAccessiblePattern(AutomationElement el, UIAutomationClient.IUIAutomationLegacyIAccessiblePattern pattern, bool cached)
            : base(el, cached)
        {
            Debug.Assert(pattern != null);
            this._pattern = pattern;
        }

        public void Select(int flagsSelect)
        {
            try
            {
                this._pattern.Select(flagsSelect);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        public void DoDefaultAction()
        {
            try
            {
                this._pattern.DoDefaultAction();
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
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

        public Accessibility.IAccessible GetIAccessible()
        {
            try
            {
                return (Accessibility.IAccessible)this._pattern.GetIAccessible();
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        internal static object Wrap(AutomationElement el, object pattern, bool cached)
        {
            return (pattern == null) ? null : new LegacyIAccessiblePattern(el, (UIAutomationClient.IUIAutomationLegacyIAccessiblePattern)pattern, cached);
        }


        public LegacyIAccessiblePatternInformation Cached
        {
            get
            {
                Utility.ValidateCached(this._cached);
                return new LegacyIAccessiblePatternInformation(this._el, true);
            }
        }

        public LegacyIAccessiblePatternInformation Current
        {
            get
            {
                return new LegacyIAccessiblePatternInformation(this._el, false);
            }
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct LegacyIAccessiblePatternInformation
        {
            private AutomationElement _el;
            private bool _isCached;
            internal LegacyIAccessiblePatternInformation(AutomationElement element, bool isCached)
            {
                this._el = element;
                this._isCached = isCached;
            }
            
            public AutomationElement[] GetSelection()
            {
                return (AutomationElement[])this._el.GetPropertyValue(LegacyIAccessiblePattern.SelectionProperty, _isCached);
            }

            public int ChildId
            {
                get
                {
                    return (int)this._el.GetPropertyValue(LegacyIAccessiblePattern.ChildIdProperty, _isCached);
                }
            }

            public string DefaultAction
            {
                get
                {
                    return (string)this._el.GetPropertyValue(LegacyIAccessiblePattern.DefaultActionProperty, _isCached);
                }
            }

            public string Description
            {
                get
                {
                    return (string)this._el.GetPropertyValue(LegacyIAccessiblePattern.DescriptionProperty, _isCached);
                }
            }

            public string Help
            {
                get
                {
                    return (string)this._el.GetPropertyValue(LegacyIAccessiblePattern.HelpProperty, _isCached);
                }
            }

            public string KeyboardShortcut
            {
                get
                {
                    return (string)this._el.GetPropertyValue(LegacyIAccessiblePattern.KeyboardShortcutProperty, _isCached);
                }
            }

            public string Name
            {
                get
                {
                    return (string)this._el.GetPropertyValue(LegacyIAccessiblePattern.NameProperty, _isCached);
                }
            }

            public uint Role
            {
                get
                {
                    return Convert.ToUInt32(this._el.GetPropertyValue(LegacyIAccessiblePattern.RoleProperty, _isCached));
                }
            }

            public uint State
            {
                get
                {
                    return Convert.ToUInt32(this._el.GetPropertyValue(LegacyIAccessiblePattern.StateProperty, _isCached));
                }
            }

            public string Value
            {
                get
                {
                    return (string)this._el.GetPropertyValue(LegacyIAccessiblePattern.ValueProperty, _isCached);
                }
            }
        }
    }
}
