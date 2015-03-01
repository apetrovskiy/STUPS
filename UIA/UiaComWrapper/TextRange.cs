// (c) Copyright Microsoft, 2012.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.



using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using UIAComWrapperInternal;

namespace System.Windows.Automation.Text
{
    public class TextPatternRange
    {
        
        private UIAutomationClient.IUIAutomationTextRange _range;
        private TextPattern _pattern;

        
        internal TextPatternRange(UIAutomationClient.IUIAutomationTextRange range, TextPattern pattern)
        {
            Debug.Assert(range != null);
            Debug.Assert(pattern != null);
            this._range = range;
            this._pattern = pattern;
        }

        internal static TextPatternRange Wrap(UIAutomationClient.IUIAutomationTextRange range, TextPattern pattern)
        {
            Debug.Assert(pattern != null);
            if (range == null)
            {
                return null;
            }
            else
            {
                return new TextPatternRange(range, pattern);
            }
        }

        public void AddToSelection()
        {
            try
            {
                _range.AddToSelection();
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        public TextPatternRange Clone()
        {
            try
            {
                return TextPatternRange.Wrap(_range.Clone(), this._pattern);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        public bool Compare(TextPatternRange range)
        {
            try
            {
                return 0 != this._range.Compare(range.NativeRange);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        public int CompareEndpoints(TextPatternRangeEndpoint endpoint, TextPatternRange targetRange, TextPatternRangeEndpoint targetEndpoint)
        {
            try
            {
                return this._range.CompareEndpoints(
                    (UIAutomationClient.TextPatternRangeEndpoint)endpoint,
                    targetRange.NativeRange,
                    (UIAutomationClient.TextPatternRangeEndpoint)targetEndpoint);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        public void ExpandToEnclosingUnit(TextUnit unit)
        {
            try
            {
                this._range.ExpandToEnclosingUnit((UIAutomationClient.TextUnit)unit);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        public TextPatternRange FindAttribute(AutomationTextAttribute attribute, object value, bool backward)
        {
            Utility.ValidateArgumentNonNull(attribute, "attribute");
            Utility.ValidateArgumentNonNull(value, "value");
            if ((attribute == TextPattern.CultureAttribute) && (value is CultureInfo))
            {
                value = ((CultureInfo)value).LCID;
            }
            try
            {
                return TextPatternRange.Wrap(
                    this._range.FindAttribute(attribute.Id, value, Utility.ConvertToInt(backward)), this._pattern);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        public TextPatternRange FindText(string text, bool backward, bool ignoreCase)
        {
            try
            {
                return TextPatternRange.Wrap(
                    this._range.FindText(text, Utility.ConvertToInt(backward), Utility.ConvertToInt(ignoreCase)), this._pattern);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        public object GetAttributeValue(AutomationTextAttribute attribute)
        {
            Utility.ValidateArgumentNonNull(attribute, "attribute");
            try
            {
                PropertyTypeInfo info;
                if (!Schema.GetPropertyTypeInfo(attribute, out info))
                {
                    throw new ArgumentException("Unsupported Attribute");
                }
                object valueAsObject = this._range.GetAttributeValue(attribute.Id);
                if (info.Type.IsEnum && (valueAsObject is int))
                {
                    return Enum.ToObject(info.Type, (int)valueAsObject);
                }
                if ((valueAsObject != AutomationElement.NotSupported) && (info.ObjectConverter != null))
                {
                    valueAsObject = info.ObjectConverter(valueAsObject);
                }
                return valueAsObject;
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        public Rect[] GetBoundingRectangles()
        {
            try
            {
                double[] unrolledRects = (double[])this._range.GetBoundingRectangles();
                Rect[] result = null;
                if (unrolledRects != null)
                {
                    Debug.Assert(unrolledRects.Length % 4 == 0);
                    // If unrolledRects is somehow not a multiple of 4, we still will not 
                    // overrun it, since (x / 4) * 4 <= x for C# integer math.
                    result = new Rect[unrolledRects.Length / 4];
                    for (int i = 0; i < result.Length; i++)
                    {
                        int j = i * 4; ;
                        result[i] = new Rect(unrolledRects[j], unrolledRects[j + 1], unrolledRects[j + 2], unrolledRects[j + 3]);
                    }
                }
                return result;
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        public AutomationElement[] GetChildren()
        {
            try
            {
                return Utility.ConvertToElementArray(this._range.GetChildren());
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        public AutomationElement GetEnclosingElement()
        {
            try
            {
                return AutomationElement.Wrap(this._range.GetEnclosingElement());
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        public string GetText(int maxLength)
        {
            try
            {
                return this._range.GetText(maxLength);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        public int Move(TextUnit unit, int count)
        {
            try
            {
                return this._range.Move((UIAutomationClient.TextUnit)unit, count);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        public void MoveEndpointByRange(TextPatternRangeEndpoint endpoint, TextPatternRange targetRange, TextPatternRangeEndpoint targetEndpoint)
        {
            try
            {
                this._range.MoveEndpointByRange(
                    (UIAutomationClient.TextPatternRangeEndpoint)endpoint,
                    targetRange.NativeRange,
                    (UIAutomationClient.TextPatternRangeEndpoint)targetEndpoint);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        public int MoveEndpointByUnit(TextPatternRangeEndpoint endpoint, TextUnit unit, int count)
        {
            try
            {
                return this._range.MoveEndpointByUnit(
                    (UIAutomationClient.TextPatternRangeEndpoint)endpoint,
                    (UIAutomationClient.TextUnit)unit,
                    count);
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
                this._range.RemoveFromSelection();
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        public void ScrollIntoView(bool alignToTop)
        {
            try
            {
                this._range.ScrollIntoView(Utility.ConvertToInt(alignToTop));
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
                this._range.Select();
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        internal static TextPatternRange[] Wrap(UIAutomationClient.IUIAutomationTextRangeArray ranges, TextPattern pattern)
        {
            if (ranges == null)
            {
                return null;
            }
            TextPatternRange[] rangeArray = new TextPatternRange[ranges.Length];
            for (int i = 0; i < ranges.Length; i++)
            {
                rangeArray[i] = new TextPatternRange(ranges.GetElement(i), pattern);
            }
            return rangeArray;
        }

        
        internal UIAutomationClient.IUIAutomationTextRange NativeRange
        {
            get
            {
                return this._range;
            }
        }

        public TextPattern TextPattern
        {
            get
            {
                return this._pattern;
            }
        }
    }
}
