/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/8/2013
 * Time: 10:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;

    /// <summary>
    /// Description of RangeValuePatternAdapterNet.
    /// </summary>
    public class UiaRangeValuePattern : IRangeValuePattern
    {
        private classic.RangeValuePattern _rangeValuePattern;
        private IUiElement _element;

        public UiaRangeValuePattern(IUiElement element, classic.RangeValuePattern rangeValuePattern)
        {
            _rangeValuePattern = rangeValuePattern;
            _element = element;
            //this._useCache = useCache;
        }

        public UiaRangeValuePattern(IUiElement element)
        {
            _element = element;
        }

        public struct RangeValuePatternInformation : IRangeValuePatternInformation
        {
            // private AutomationElement _el;
            // private bool _useCache;
            
            private readonly bool _useCache;
            private readonly IRangeValuePattern _rangeValuePattern;

            public RangeValuePatternInformation(IRangeValuePattern rangeValuePattern, bool useCache)
            {
                _rangeValuePattern = rangeValuePattern;
                _useCache = useCache;
            }
            
            public double Value {
//                get {
//                    object patternPropertyValue = this._el.GetPatternPropertyValue(RangeValuePattern.ValueProperty, this._useCache);
//                    if (patternPropertyValue is int) {
//                        return (double)((int)patternPropertyValue);
//                    }
//                    if (patternPropertyValue is int) {
//                        return (double)((int)patternPropertyValue);
//                    }
//                    if (patternPropertyValue is byte) {
//                        return (double)((byte)patternPropertyValue);
//                    }
//                    if (patternPropertyValue is DateTime) {
//                        return (double)((DateTime)patternPropertyValue).Year;
//                    }
//                    return (double)patternPropertyValue;
//                }
                get { return (double)_rangeValuePattern.GetParentElement().GetPatternPropertyValue(classic.RangeValuePattern.ValueProperty, _useCache); }
            }
            public bool IsReadOnly {
                // get { return (bool)this._el.GetPatternPropertyValue(RangeValuePattern.IsReadOnlyProperty, this._useCache); }
                get { return (bool)_rangeValuePattern.GetParentElement().GetPatternPropertyValue(classic.RangeValuePattern.IsReadOnlyProperty, _useCache); }
            }
            public double Maximum {
//                get {
//                    object patternPropertyValue = this._el.GetPatternPropertyValue(RangeValuePattern.MaximumProperty, this._useCache);
//                    if (patternPropertyValue is int) {
//                        return (double)((int)patternPropertyValue);
//                    }
//                    if (patternPropertyValue is int) {
//                        return (double)((int)patternPropertyValue);
//                    }
//                    if (patternPropertyValue is byte) {
//                        return (double)((byte)patternPropertyValue);
//                    }
//                    if (patternPropertyValue is DateTime) {
//                        return (double)((DateTime)patternPropertyValue).Year;
//                    }
//                    return (double)patternPropertyValue;
//                }
                get { return (double)_rangeValuePattern.GetParentElement().GetPatternPropertyValue(classic.RangeValuePattern.MaximumProperty, _useCache); }
            }
            public double Minimum {
//                get {
//                    object patternPropertyValue = this._el.GetPatternPropertyValue(RangeValuePattern.MinimumProperty, this._useCache);
//                    if (patternPropertyValue is int) {
//                        return (double)((int)patternPropertyValue);
//                    }
//                    if (patternPropertyValue is int) {
//                        return (double)((int)patternPropertyValue);
//                    }
//                    if (patternPropertyValue is byte) {
//                        return (double)((byte)patternPropertyValue);
//                    }
//                    if (patternPropertyValue is DateTime) {
//                        return (double)((DateTime)patternPropertyValue).Year;
//                    }
//                    return (double)patternPropertyValue;
//                }
                get { return (double)_rangeValuePattern.GetParentElement().GetPatternPropertyValue(classic.RangeValuePattern.MinimumProperty, _useCache); }
            }
            public double LargeChange {
//                get {
//                    object patternPropertyValue = this._el.GetPatternPropertyValue(RangeValuePattern.LargeChangeProperty, this._useCache);
//                    if (patternPropertyValue is int) {
//                        return (double)((int)patternPropertyValue);
//                    }
//                    if (patternPropertyValue is int) {
//                        return (double)((int)patternPropertyValue);
//                    }
//                    if (patternPropertyValue is byte) {
//                        return (double)((byte)patternPropertyValue);
//                    }
//                    if (patternPropertyValue is DateTime) {
//                        return (double)((DateTime)patternPropertyValue).Year;
//                    }
//                    return (double)patternPropertyValue;
//                }
                get { return (double)_rangeValuePattern.GetParentElement().GetPatternPropertyValue(classic.RangeValuePattern.LargeChangeProperty, _useCache); }
            }
            public double SmallChange {
//                get {
//                    object patternPropertyValue = this._el.GetPatternPropertyValue(RangeValuePattern.SmallChangeProperty, this._useCache);
//                    if (patternPropertyValue is int) {
//                        return (double)((int)patternPropertyValue);
//                    }
//                    if (patternPropertyValue is int) {
//                        return (double)((int)patternPropertyValue);
//                    }
//                    if (patternPropertyValue is byte) {
//                        return (double)((byte)patternPropertyValue);
//                    }
//                    if (patternPropertyValue is DateTime) {
//                        return (double)((DateTime)patternPropertyValue).Year;
//                    }
//                    return (double)patternPropertyValue;
//                }
                get { return (double)_rangeValuePattern.GetParentElement().GetPatternPropertyValue(classic.RangeValuePattern.SmallChangeProperty, _useCache); }
            }
//            internal RangeValuePatternInformation(AutomationElement el, bool useCache)
//            {
//                this._el = el;
//                this._useCache = useCache;
//            }
        }
        public static readonly classic.AutomationPattern Pattern = classic.RangeValuePatternIdentifiers.Pattern;
        public static readonly classic.AutomationProperty ValueProperty = classic.RangeValuePatternIdentifiers.ValueProperty;
        public static readonly classic.AutomationProperty IsReadOnlyProperty = classic.RangeValuePatternIdentifiers.IsReadOnlyProperty;
        public static readonly classic.AutomationProperty MinimumProperty = classic.RangeValuePatternIdentifiers.MinimumProperty;
        public static readonly classic.AutomationProperty MaximumProperty = classic.RangeValuePatternIdentifiers.MaximumProperty;
        public static readonly classic.AutomationProperty LargeChangeProperty = classic.RangeValuePatternIdentifiers.LargeChangeProperty;
        public static readonly classic.AutomationProperty SmallChangeProperty = classic.RangeValuePatternIdentifiers.SmallChangeProperty;
        // private SafePatternHandle _hPattern;
        // private bool _cached;
        
        public virtual IRangeValuePatternInformation Cached {
            get {
                // Misc.ValidateCached(this._cached);
                // return new RangeValuePattern.RangeValuePatternInformation(this._el, true);
                return new RangeValuePatternInformation(this, true);
            }
        }
        
        public virtual IRangeValuePatternInformation Current {
            get {
                // Misc.ValidateCurrent(this._hPattern);
                // return new RangeValuePattern.RangeValuePatternInformation(this._el, false);
                return new RangeValuePatternInformation(this, false);
            }
        }
//        private UiaRangeValuePattern(AutomationElement el, SafePatternHandle hPattern, bool cached) : base(el, hPattern)
//        {
//            this._hPattern = hPattern;
//            this._cached = cached;
//        }
        public virtual void SetValue(double value)
        {
//            object currentPropertyValue = this._el.GetCurrentPropertyValue(AutomationElementIdentifiers.IsEnabledProperty);
//            if (currentPropertyValue is bool && !(bool)currentPropertyValue) {
//                throw new ElementNotEnabledException();
//            }
//            object currentPropertyValue2 = this._el.GetCurrentPropertyValue(RangeValuePattern.IsReadOnlyProperty);
//            if (currentPropertyValue2 is bool && (bool)currentPropertyValue2) {
//                throw new InvalidOperationException(SR.Get("ValueReadonly"));
//            }
//            UiaCoreApi.RangeValuePattern_SetValue(this._hPattern, value);
            _rangeValuePattern.SetValue(value);
        }
//        static internal object Wrap(AutomationElement el, SafePatternHandle hPattern, bool cached)
//        {
//            return new RangeValuePattern(el, hPattern, cached);
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
            _rangeValuePattern = pattern as classic.RangeValuePattern;
        }
        
        public object GetSourcePattern()
        {
            return _rangeValuePattern;
        }
    }
}

