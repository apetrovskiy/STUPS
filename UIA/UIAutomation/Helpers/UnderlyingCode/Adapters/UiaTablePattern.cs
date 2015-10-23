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
    using System.Linq;

    /// <summary>
    /// Description of TablePatternAdapterNet.
    /// </summary>
    public class UiaTablePattern : ITablePattern
    {
        private classic.TablePattern _tablePattern;
        private IUiElement _element;

        public UiaTablePattern(IUiElement element, classic.TablePattern tablePattern)
        {
            _tablePattern = tablePattern;
            _element = element;
            //this._useCache = useCache;
        }

        public UiaTablePattern(IUiElement element)
        {
            _element = element;
        }

        public struct TablePatternInformation : ITablePatternInformation
        {
            // private AutomationElement _el;
            // private bool _useCache;
            
            private readonly bool _useCache;
            private readonly ITablePattern _tablePattern;

            public TablePatternInformation(ITablePattern tablePattern, bool useCache)
            {
                _tablePattern = tablePattern;
                _useCache = useCache;
            }
            
            public int RowCount {
                // get { return (int)this._el.GetPatternPropertyValue(GridPattern.RowCountProperty, this._useCache); }
                get { return (int)_tablePattern.GetParentElement().GetPatternPropertyValue(classic.GridPattern.RowCountProperty, _useCache); }
            }
            public int ColumnCount {
                // get { return (int)this._el.GetPatternPropertyValue(GridPattern.ColumnCountProperty, this._useCache); }
                get { return (int)_tablePattern.GetParentElement().GetPatternPropertyValue(classic.GridPattern.ColumnCountProperty, _useCache); }
            }
            public classic.RowOrColumnMajor RowOrColumnMajor {
                // get { return (RowOrColumnMajor)this._el.GetPatternPropertyValue(TablePattern.RowOrColumnMajorProperty, this._useCache); }
                get { return (classic.RowOrColumnMajor)_tablePattern.GetParentElement().GetPatternPropertyValue(classic.TablePattern.RowOrColumnMajorProperty, _useCache); }
            }
//            internal TablePatternInformation(AutomationElement el, bool useCache)
//            {
//                this._el = el;
//                this._useCache = useCache;
//            }
            
            public IUiElement[] GetRowHeaders()
            {
                // return (AutomationElement[])this._el.GetPatternPropertyValue(TablePattern.RowHeadersProperty, this._useCache);
                // 20140302
                // AutomationElement[] nativeElements = (AutomationElement[])this._tablePattern.GetParentElement().GetPatternPropertyValue(TablePattern.RowHeadersProperty, this._useCache);
                var nativeElements = (classic.AutomationElement[])_tablePattern.GetParentElement().GetPatternPropertyValue(classic.TablePattern.RowHeadersProperty, _useCache);
                IUiEltCollection tempCollection = AutomationFactory.GetUiEltCollection(nativeElements);
                if (null == tempCollection || 0 == tempCollection.Count) {
                    return new UiElement[] {};
                } else {
                    return tempCollection.Cast<IUiElement>().ToArray<IUiElement>();
                }
            }
            
            public IUiElement[] GetColumnHeaders()
            {
                // return (AutomationElement[])this._el.GetPatternPropertyValue(TablePattern.ColumnHeadersProperty, this._useCache);
                // 20140302
                // AutomationElement[] nativeElements = (AutomationElement[])this._tablePattern.GetParentElement().GetPatternPropertyValue(TablePattern.ColumnHeadersProperty, this._useCache);
                var nativeElements = (classic.AutomationElement[])_tablePattern.GetParentElement().GetPatternPropertyValue(classic.TablePattern.ColumnHeadersProperty, _useCache);
                IUiEltCollection tempCollection = AutomationFactory.GetUiEltCollection(nativeElements);
                if (null == tempCollection || 0 == tempCollection.Count) {
                    return new UiElement[] {};
                } else {
                    return tempCollection.Cast<IUiElement>().ToArray<IUiElement>();
                }
            }
        }
        public static readonly classic.AutomationPattern Pattern = classic.TablePatternIdentifiers.Pattern;
        /*
        public static new readonly AutomationPattern Pattern = TablePatternIdentifiers.Pattern;
        */
        public static readonly classic.AutomationProperty RowHeadersProperty = classic.TablePatternIdentifiers.RowHeadersProperty;
        public static readonly classic.AutomationProperty ColumnHeadersProperty = classic.TablePatternIdentifiers.ColumnHeadersProperty;
        public static readonly classic.AutomationProperty RowOrColumnMajorProperty = classic.TablePatternIdentifiers.RowOrColumnMajorProperty;
        
        public virtual ITablePatternInformation Cached {
            get {
                // Misc.ValidateCached(this._cached);
                // return new TablePattern.TablePatternInformation(this._el, true);
                return new TablePatternInformation(this, true);
            }
        }
        
        public virtual ITablePatternInformation Current {
            get {
                // Misc.ValidateCurrent(this._hPattern);
                // return new TablePattern.TablePatternInformation(this._el, false);
                return new TablePatternInformation(this, false);
            }
        }
//        private UiaTablePattern(AutomationElement el, SafePatternHandle hPattern, bool cached) : base(el, hPattern, cached)
//        {
//        }
//        static internal new object Wrap(AutomationElement el, SafePatternHandle hPattern, bool cached)
//        {
//            return new TablePattern(el, hPattern, cached);
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
            _tablePattern = pattern as classic.TablePattern;
        }
        
        public object GetSourcePattern()
        {
            return _tablePattern;
        }
    }
}

