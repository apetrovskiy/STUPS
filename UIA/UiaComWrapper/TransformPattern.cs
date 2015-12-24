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
    public class TransformPattern : BasePattern
    {
        
        private UIAutomationClient.IUIAutomationTransformPattern _pattern;
        public static readonly AutomationPattern Pattern = TransformPatternIdentifiers.Pattern;
        public static readonly AutomationProperty CanMoveProperty = TransformPatternIdentifiers.CanMoveProperty;
        public static readonly AutomationProperty CanResizeProperty = TransformPatternIdentifiers.CanResizeProperty;
        public static readonly AutomationProperty CanRotateProperty = TransformPatternIdentifiers.CanRotateProperty;

        
        protected TransformPattern(AutomationElement el, UIAutomationClient.IUIAutomationTransformPattern pattern, bool cached)
            : base(el, cached)
        {
            Debug.Assert(pattern != null);
            this._pattern = pattern;
        }

        internal static object Wrap(AutomationElement el, object pattern, bool cached)
        {
            return (pattern == null) ? null : new TransformPattern(el, (UIAutomationClient.IUIAutomationTransformPattern)pattern, cached);
        }

        public void Move(double x, double y)
        {
            try
            {
                this._pattern.Move(x, y);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        public void Resize(double width, double height)
        {
            try
            {
                this._pattern.Resize(width, height);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        public void Rotate(double degrees)
        {
            try
            {
                this._pattern.Rotate(degrees);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        
        public TransformPatternInformation Cached
        {
            get
            {
                Utility.ValidateCached(this._cached);
                return new TransformPatternInformation(this._el, true);
            }
        }

        public TransformPatternInformation Current
        {
            get
            {
                return new TransformPatternInformation(this._el, false);
            }
        }


        
        [StructLayout(LayoutKind.Sequential)]
        public struct TransformPatternInformation
        {
            private AutomationElement _el;
            private bool _isCached;
            internal TransformPatternInformation(AutomationElement element, bool isCached)
            {
                this._el = element;
                this._isCached = isCached;
            }

            public bool CanMove
            {
                get
                {
                    return (bool)this._el.GetPropertyValue(TransformPattern.CanMoveProperty, _isCached);
                }
            }
            public bool CanResize
            {
                get
                {
                    return (bool)this._el.GetPropertyValue(TransformPattern.CanResizeProperty, _isCached);
                }
            }
            public bool CanRotate
            {
                get
                {
                    return (bool)this._el.GetPropertyValue(TransformPattern.CanRotateProperty, _isCached);
                }
            }
        }
    }

    public class TransformPattern2 : TransformPattern
    {

        private UIAutomationClient.IUIAutomationTransformPattern2 _pattern;
        public static readonly AutomationProperty CanZoomProperty = TransformPattern2Identifiers.CanZoomProperty;
        public static readonly AutomationProperty ZoomLevelProperty = TransformPattern2Identifiers.ZoomLevelProperty;
        public static readonly AutomationProperty ZoomMinimumProperty = TransformPattern2Identifiers.ZoomMinimumProperty;
        public static readonly AutomationProperty ZoomMaximumProperty = TransformPattern2Identifiers.ZoomMaximumProperty;
        public new static readonly AutomationPattern Pattern = TransformPattern2Identifiers.Pattern;

        private TransformPattern2(AutomationElement el, UIAutomationClient.IUIAutomationTransformPattern2 pattern2, UIAutomationClient.IUIAutomationTransformPattern pattern, bool cached)
            : base(el, pattern, cached)
        {
            Debug.Assert(pattern2 != null);
            this._pattern = pattern2;
        }

        internal new static object Wrap(AutomationElement el, object pattern, bool cached)
        {
            TransformPattern2 result = null;
            if (pattern != null)
            {
                UIAutomationClient.IUIAutomationTransformPattern basePattern =
                    (UIAutomationClient.IUIAutomationTransformPattern)el.GetRawPattern(TransformPattern.Pattern, cached);
                if (basePattern != null)
                {
                    result = new TransformPattern2(el, (UIAutomationClient.IUIAutomationTransformPattern2)pattern,
                        basePattern, cached);
                }
            }
            return result;
        }

        public void Zoom(double zoom)
        {
            try
            {
                this._pattern.Zoom(zoom);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        public void ZoomByUnit(ZoomUnit zoomUnit)
        {
            try
            {
                this._pattern.ZoomByUnit((UIAutomationClient.ZoomUnit)zoomUnit);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }

        public new TransformPattern2Information Cached
        {
            get
            {
                Utility.ValidateCached(this._cached);
                return new TransformPattern2Information(this._el, true);
            }
        }

        public new TransformPattern2Information Current
        {
            get
            {
                return new TransformPattern2Information(this._el, false);
            }
        }



        [StructLayout(LayoutKind.Sequential)]
        public struct TransformPattern2Information
        {
            private AutomationElement _el;
            private bool _isCached;
            internal TransformPattern2Information(AutomationElement element, bool isCached)
            {
                this._el = element;
                this._isCached = isCached;
            }

            public bool CanZoom
            {
                get
                {
                    return (bool)this._el.GetPropertyValue(TransformPattern2.CanZoomProperty, _isCached);
                }
            }

            public double ZoomLevel
            {
                get
                {
                    return (double)this._el.GetPropertyValue(TransformPattern2.ZoomLevelProperty, _isCached);
                }
            }

            public double ZoomMinimum
            {
                get
                {
                    return (double)this._el.GetPropertyValue(TransformPattern2.ZoomMinimumProperty, _isCached);
                }
            }

            public double ZoomMaximum
            {
                get
                {
                    return (double)this._el.GetPropertyValue(TransformPattern2.ZoomMaximumProperty, _isCached);
                }
            }
        }
    }

}