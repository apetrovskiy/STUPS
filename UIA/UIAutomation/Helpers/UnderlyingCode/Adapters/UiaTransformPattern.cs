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
    /// Description of TransformPatternAdapterNet.
    /// </summary>
    public class UiaTransformPattern : ITransformPattern
    {
        private classic.TransformPattern _transformPattern;
        private IUiElement _element;

        public UiaTransformPattern(IUiElement element, classic.TransformPattern transformPattern)
        {
            _transformPattern = transformPattern;
            _element = element;
            //this._useCache = useCache;
        }

        public UiaTransformPattern(IUiElement element)
        {
            _element = element;
        }

        public struct TransformPatternInformation : ITransformPatternInformation
        {
            // private AutomationElement _el;
            // private bool _useCache;
            
            private readonly bool _useCache;
            private readonly ITransformPattern _transformPattern;

            public TransformPatternInformation(ITransformPattern transformPattern, bool useCache)
            {
                _transformPattern = transformPattern;
                _useCache = useCache;
            }
            
            public bool CanMove {
                // get { return (bool)this._el.GetPatternPropertyValue(TransformPattern.CanMoveProperty, this._useCache); }
                get { return (bool)_transformPattern.GetParentElement().GetPatternPropertyValue(classic.TransformPattern.CanMoveProperty, _useCache); }
            }
            public bool CanResize {
                // get { return (bool)this._el.GetPatternPropertyValue(TransformPattern.CanResizeProperty, this._useCache); }
                get { return (bool)_transformPattern.GetParentElement().GetPatternPropertyValue(classic.TransformPattern.CanResizeProperty, _useCache); }
            }
            public bool CanRotate {
                // get { return (bool)this._el.GetPatternPropertyValue(TransformPattern.CanRotateProperty, this._useCache); }
                get { return (bool)_transformPattern.GetParentElement().GetPatternPropertyValue(classic.TransformPattern.CanRotateProperty, _useCache); }
            }
//            internal TransformPatternInformation(AutomationElement el, bool useCache)
//            {
//                this._el = el;
//                this._useCache = useCache;
//            }
        }
        public static readonly classic.AutomationPattern Pattern = classic.TransformPatternIdentifiers.Pattern;
        public static readonly classic.AutomationProperty CanMoveProperty = classic.TransformPatternIdentifiers.CanMoveProperty;
        public static readonly classic.AutomationProperty CanResizeProperty = classic.TransformPatternIdentifiers.CanResizeProperty;
        public static readonly classic.AutomationProperty CanRotateProperty = classic.TransformPatternIdentifiers.CanRotateProperty;
        // private SafePatternHandle _hPattern;
        // private bool _cached;
        
        public virtual ITransformPatternInformation Cached {
            get {
                // Misc.ValidateCached(this._cached);
                // return new TransformPattern.TransformPatternInformation(this._el, true);
                return new TransformPatternInformation(this, true);
            }
        }
        
        public virtual ITransformPatternInformation Current {
            get {
                // Misc.ValidateCurrent(this._hPattern);
                // return new TransformPattern.TransformPatternInformation(this._el, false);
                return new TransformPatternInformation(this, false);
            }
        }
//        private UiaTransformPattern(AutomationElement el, SafePatternHandle hPattern, bool cached) : base(el, hPattern)
//        {
//            this._hPattern = hPattern;
//            this._cached = cached;
//        }
        public virtual void Move(double x, double y)
        {
            // UiaCoreApi.TransformPattern_Move(this._hPattern, x, y);
            _transformPattern.Move(x, y);
        }
        public virtual void Resize(double width, double height)
        {
            // UiaCoreApi.TransformPattern_Resize(this._hPattern, width, height);
            _transformPattern.Resize(width, height);
        }
        public virtual void Rotate(double degrees)
        {
            // UiaCoreApi.TransformPattern_Rotate(this._hPattern, degrees);
            _transformPattern.Rotate(degrees);
        }
//        static internal object Wrap(AutomationElement el, SafePatternHandle hPattern, bool cached)
//        {
//            return new TransformPattern(el, hPattern, cached);
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
            _transformPattern = pattern as classic.TransformPattern;
        }
        
        public object GetSourcePattern()
        {
            return _transformPattern;
        }
    }
}

