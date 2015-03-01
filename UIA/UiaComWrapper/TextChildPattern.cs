// (c) Copyright Microsoft, 2012.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.


using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Automation.Text;
using UIAComWrapperInternal;

namespace System.Windows.Automation
{
    public class TextChildPattern : BasePattern
    {
        private UIAutomationClient.IUIAutomationTextChildPattern _pattern;
        public static readonly AutomationPattern Pattern = TextChildPatternIdentifiers.Pattern;

        private TextChildPattern(AutomationElement el, UIAutomationClient.IUIAutomationTextChildPattern pattern, bool cached)
            : base(el, cached)
        {
            Debug.Assert(pattern != null);
            this._pattern = pattern;
        }

        public AutomationElement TextContainer
        {
            get
            {
                try
                {
                    return AutomationElement.Wrap(this._pattern.TextContainer);
                }
                catch (System.Runtime.InteropServices.COMException e)
                {
                    Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
                }
            }
        }

        public TextPatternRange TextRange
        {
            get
            {
                try
                {
                    AutomationElement textContainer = this.TextContainer;
                    TextPattern textPattern = (TextPattern)textContainer.GetCurrentPattern(TextPattern.Pattern);
                    return TextPatternRange.Wrap(this._pattern.TextRange, textPattern);
                }
                catch (System.Runtime.InteropServices.COMException e)
                {
                    Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
                }
            }
        }

        internal static object Wrap(AutomationElement el, object pattern, bool cached)
        {
            return (pattern == null) ? null : new TextChildPattern(el, (UIAutomationClient.IUIAutomationTextChildPattern)pattern, cached);
        }
    }
}
