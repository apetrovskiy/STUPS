/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/8/2013
 * Time: 10:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;

    /// <summary>
    /// Description of DockPatternAdapterNet.
    /// </summary>
    public class UiaDockPattern : IDockPattern
    {
        // private System.Windows.Automation.DockPattern _dockPattern;
        private classic.DockPattern _dockPattern;
        private IUiElement _element;

        public UiaDockPattern(IUiElement element, classic.DockPattern dockPattern)
        {
            _dockPattern = dockPattern;
            _element = element;
            //this._useCache = useCache;
        }

        public UiaDockPattern(IUiElement element)
        {
            _element = element;
        }
        
        public UiaDockPattern(classic.DockPattern DockPattern)
        {
            _dockPattern = DockPattern;
        }

        public struct DockPatternInformation : IDockPatternInformation
        {
            // private AutomationElement _el;
            // private bool _useCache;
            
            private readonly bool _useCache;
            private readonly IDockPattern _dockPattern;

            public DockPatternInformation(IDockPattern dockPattern, bool useCache)
            {
                _dockPattern = dockPattern;
                _useCache = useCache;
            }
            
            public classic.DockPosition DockPosition {
                // get { return (DockPosition)this._el.GetPatternPropertyValue(DockPattern.DockPositionProperty, this._useCache); }
                get { return (classic.DockPosition)_dockPattern.GetParentElement().GetPatternPropertyValue(classic.DockPattern.DockPositionProperty, _useCache); }
            }
//            internal DockPatternInformation(AutomationElement el, bool useCache)
//            {
//                this._el = el;
//                this._useCache = useCache;
//            }
        }
        public static readonly classic.AutomationPattern Pattern = classic.DockPatternIdentifiers.Pattern;
        public static readonly classic.AutomationProperty DockPositionProperty = classic.DockPatternIdentifiers.DockPositionProperty;
        // private SafePatternHandle _hPattern;
        // private bool _cached;
        
        public virtual IDockPatternInformation Cached {
            get {
                // Misc.ValidateCached(this._cached);
                // return new DockPattern.DockPatternInformation(this._el, true);
                return new DockPatternInformation(this, true);
            }
        }
        
        public virtual IDockPatternInformation Current {
            get {
                // Misc.ValidateCurrent(this._hPattern);
                // return new DockPattern.DockPatternInformation(this._el, false);
                return new DockPatternInformation(this, false);
            }
        }
//        private UiaDockPattern(AutomationElement el, SafePatternHandle hPattern, bool cached) : base(el, hPattern)
//        {
//            this._hPattern = hPattern;
//            this._cached = cached;
//        }
        public virtual void SetDockPosition(classic.DockPosition dockPosition)
        {
            // UiaCoreApi.DockPattern_SetDockPosition(this._hPattern, dockPosition);
            _dockPattern.SetDockPosition(dockPosition);
        }
//        static internal object Wrap(AutomationElement el, SafePatternHandle hPattern, bool cached)
//        {
//            return new DockPattern(el, hPattern, cached);
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
            _dockPattern = pattern as classic.DockPattern;
        }
        
        public object GetSourcePattern()
        {
            return _dockPattern;
        }
    }
}

