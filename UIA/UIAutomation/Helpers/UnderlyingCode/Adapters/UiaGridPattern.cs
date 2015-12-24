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
    /// Description of GridPatternAdapterNet.
    /// </summary>
    public class UiaGridPattern : IGridPattern
    {
        private classic.GridPattern _gridPattern;
        private IUiElement _element;

        public UiaGridPattern(IUiElement element, classic.GridPattern gridPattern)
        {
            _gridPattern = gridPattern;
            _element = element;
            //this._useCache = useCache;
        }

        public UiaGridPattern(IUiElement element)
        {
            _element = element;
        }

        public struct GridPatternInformation : IGridPatternInformation
        {
            // private AutomationElement _el;
            // private bool _useCache;
            
            private readonly bool _useCache;
            private readonly IGridPattern _gridPattern;

            public GridPatternInformation(IGridPattern gridPattern, bool useCache)
            {
                _gridPattern = gridPattern;
                _useCache = useCache;
            }
            
            public int RowCount {
                // get { return (int)this._el.GetPatternPropertyValue(GridPattern.RowCountProperty, this._useCache); }
                get { return (int)_gridPattern.GetParentElement().GetPatternPropertyValue(classic.GridPattern.RowCountProperty, _useCache); }
            }
            public int ColumnCount {
                // get { return (int)this._el.GetPatternPropertyValue(GridPattern.ColumnCountProperty, this._useCache); }
                get { return (int)_gridPattern.GetParentElement().GetPatternPropertyValue(classic.GridPattern.ColumnCountProperty, _useCache); }
            }
//            internal GridPatternInformation(AutomationElement el, bool useCache)
//            {
//                this._el = el;
//                this._useCache = useCache;
//            }
        }
        public static readonly classic.AutomationPattern Pattern = classic.GridPatternIdentifiers.Pattern;
        public static readonly classic.AutomationProperty RowCountProperty = classic.GridPatternIdentifiers.RowCountProperty;
        public static readonly classic.AutomationProperty ColumnCountProperty = classic.GridPatternIdentifiers.ColumnCountProperty;
        // internal SafePatternHandle _hPattern;
        // internal bool _cached;
        
        public virtual IGridPatternInformation Cached {
            get {
                // Misc.ValidateCached(this._cached);
                // return new GridPattern.GridPatternInformation(this._el, true);
                return new GridPatternInformation(this, true);
            }
        }
        
        public virtual IGridPatternInformation Current {
            get {
                // Misc.ValidateCurrent(this._hPattern);
                // return new GridPattern.GridPatternInformation(this._el, false);
                return new GridPatternInformation(this, false);
            }
        }
//        internal UiaGridPattern(AutomationElement el, SafePatternHandle hPattern, bool cached) : base(el, hPattern)
//        {
//            this._hPattern = hPattern;
//            this._cached = cached;
//        }
        
        public virtual IUiElement GetItem(int row, int column)
        {
            // SafeNodeHandle hnode = UiaCoreApi.GridPattern_GetItem(this._hPattern, row, column);
            // return AutomationElement.Wrap(hnode);
            return AutomationFactory.GetUiElement(_gridPattern.GetItem(row, column));
        }
//        static internal object Wrap(AutomationElement el, SafePatternHandle hPattern, bool cached)
//        {
//            return new GridPattern(el, hPattern, cached);
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
            _gridPattern = pattern as classic.GridPattern;
        }
        
        public object GetSourcePattern()
        {
            return _gridPattern;
        }
    }
}

