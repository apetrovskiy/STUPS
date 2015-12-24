/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/8/2013
 * Time: 3:29 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;

    /// <summary>
    /// Description of ScrollPatternAdapter.
    /// </summary>
    public class UiaScrollPattern : IScrollPattern
    {
        private classic.ScrollPattern _scrollPattern;
        private IUiElement _element;

        public UiaScrollPattern(IUiElement element, classic.ScrollPattern scrollPattern)
        {
            _scrollPattern = scrollPattern;
            _element = element;
            //this._useCache = useCache;
        }

        public UiaScrollPattern(IUiElement element)
        {
            _element = element;
        }

        // public struct ScrollPatternInformation
        public struct ScrollPatternInformation : IScrollPatternInformation
        {
            // private AutomationElement _el;
            private bool _useCache;
            
            private IScrollPattern _scrollPattern;
            
            public ScrollPatternInformation(IScrollPattern scrollPattern, bool useCache)
            {
                _scrollPattern = scrollPattern;
                _useCache = useCache;
            }
            
            public double HorizontalScrollPercent {
                // get { return (double)this._el.GetPatternPropertyValue(ScrollPattern.HorizontalScrollPercentProperty, this._useCache); }
                get { return (double)_scrollPattern.GetParentElement().GetPatternPropertyValue(classic.ScrollPattern.HorizontalScrollPercentProperty, _useCache); }
            }
            public double VerticalScrollPercent {
                // get { return (double)this._el.GetPatternPropertyValue(ScrollPattern.VerticalScrollPercentProperty, this._useCache); }
                get { return (double)_scrollPattern.GetParentElement().GetPatternPropertyValue(classic.ScrollPattern.VerticalScrollPercentProperty, _useCache); }
            }
            public double HorizontalViewSize {
                // get { return (double)this._el.GetPatternPropertyValue(ScrollPattern.HorizontalViewSizeProperty, this._useCache); }
                get { return (double)_scrollPattern.GetParentElement().GetPatternPropertyValue(classic.ScrollPattern.HorizontalViewSizeProperty, _useCache); }
            }
            public double VerticalViewSize {
                // get { return (double)this._el.GetPatternPropertyValue(ScrollPattern.VerticalViewSizeProperty, this._useCache); }
                get { return (double)_scrollPattern.GetParentElement().GetPatternPropertyValue(classic.ScrollPattern.VerticalViewSizeProperty, _useCache); }
            }
            public bool HorizontallyScrollable {
                // get { return (bool)this._el.GetPatternPropertyValue(ScrollPattern.HorizontallyScrollableProperty, this._useCache); }
                get { return (bool)_scrollPattern.GetParentElement().GetPatternPropertyValue(classic.ScrollPattern.HorizontallyScrollableProperty, _useCache); }
            }
            public bool VerticallyScrollable {
                // get { return (bool)this._el.GetPatternPropertyValue(ScrollPattern.VerticallyScrollableProperty, this._useCache); }
                get { return (bool)_scrollPattern.GetParentElement().GetPatternPropertyValue(classic.ScrollPattern.VerticallyScrollableProperty, _useCache); }
            }
//            internal ScrollPatternInformation(AutomationElement el, bool useCache)
//            {
//                this._el = el;
//                this._useCache = useCache;
//            }
        }
        public const double NoScroll = -1.0;
        public static readonly classic.AutomationPattern Pattern = classic.ScrollPatternIdentifiers.Pattern;
        public static readonly classic.AutomationProperty HorizontalScrollPercentProperty = classic.ScrollPatternIdentifiers.HorizontalScrollPercentProperty;
        public static readonly classic.AutomationProperty HorizontalViewSizeProperty = classic.ScrollPatternIdentifiers.HorizontalViewSizeProperty;
        public static readonly classic.AutomationProperty VerticalScrollPercentProperty = classic.ScrollPatternIdentifiers.VerticalScrollPercentProperty;
        public static readonly classic.AutomationProperty VerticalViewSizeProperty = classic.ScrollPatternIdentifiers.VerticalViewSizeProperty;
        public static readonly classic.AutomationProperty HorizontallyScrollableProperty = classic.ScrollPatternIdentifiers.HorizontallyScrollableProperty;
        public static readonly classic.AutomationProperty VerticallyScrollableProperty = classic.ScrollPatternIdentifiers.VerticallyScrollableProperty;
        // private SafePatternHandle _hPattern;
        // private bool _cached;
        
        public virtual IScrollPatternInformation Cached {
            get {
                // Misc.ValidateCached(this._cached);
                // return new ScrollPattern.ScrollPatternInformation(this._el, true);
                return new ScrollPatternInformation(this, true);
            }
        }
        
        public virtual IScrollPatternInformation Current {
            get {
                // Misc.ValidateCurrent(this._hPattern);
                // return new ScrollPattern.ScrollPatternInformation(this._el, false);
                return new ScrollPatternInformation(this, false);
            }
        }
//        private UiaScrollPattern(AutomationElement el, SafePatternHandle hPattern, bool cached) : base(el, hPattern)
//        {
//            this._hPattern = hPattern;
//            this._cached = cached;
//        }
        public virtual void SetScrollPercent(double horizontalPercent, double verticalPercent)
        {
            // UiaCoreApi.ScrollPattern_SetScrollPercent(this._hPattern, horizontalPercent, verticalPercent);
            _scrollPattern.SetScrollPercent(horizontalPercent, verticalPercent);
        }
        public virtual void Scroll(classic.ScrollAmount horizontalAmount, classic.ScrollAmount verticalAmount)
        {
            // UiaCoreApi.ScrollPattern_Scroll(this._hPattern, horizontalAmount, verticalAmount);
            _scrollPattern.Scroll(horizontalAmount, verticalAmount);
        }
        public virtual void ScrollHorizontal(classic.ScrollAmount amount)
        {
            // UiaCoreApi.ScrollPattern_Scroll(this._hPattern, amount, ScrollAmount.NoAmount);
            _scrollPattern.ScrollHorizontal(amount);
        }
        public virtual void ScrollVertical(classic.ScrollAmount amount)
        {
            // UiaCoreApi.ScrollPattern_Scroll(this._hPattern, ScrollAmount.NoAmount, amount);
            _scrollPattern.ScrollVertical(amount);
        }
//        static internal object Wrap(AutomationElement el, SafePatternHandle hPattern, bool cached)
//        {
//            return new ScrollPattern(el, hPattern, cached);
//        }
        
        public void SetParentElement(IUiElement element)
        {
            _element = element;
        }
        
        public IUiElement GetParentElement()
        {
            return _element;
        }
        
        public void SetSourcePattern(object pattern)
        {
            _scrollPattern = pattern as classic.ScrollPattern;
        }
        
        public object GetSourcePattern()
        {
            return _scrollPattern;
        }
    }
}
