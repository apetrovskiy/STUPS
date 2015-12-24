/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/5/2013
 * Time: 1:31 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;
    // using UIANET::System.Windows.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    using Ninject;
    using System.Windows;

//    using Ninject.Extensions.ChildKernel;
    
    /// <summary>
    /// Description of UiElement.
    /// </summary>
    public class UiElement : IUiElement
    {
        private classic.AutomationElement _elementHolderNet;
        // //private AutomationElement _elementHolderCom;
        // private viacom. _elementHolderCom;
        // private readonly IUiElement _elementHolderAdapter;
        private IUiElement _elementHolderAdapter;
        private static InnerElementTypes _innerElementType = InnerElementTypes.AutomationElementNet;
        // internal static InnerElementTypes InnerElementType
//        internal static InnerElementTypes InnerElementType
//        {
//            get { return _innerElementType; }
//            set { _innerElementType = value; }
//        }
        
//        internal IChildKernel ChildKernel { get; set; }

        [Inject()]
        public UiElement(classic.AutomationElement element)
        {
            _elementHolderNet = element;
            _innerElementType = InnerElementTypes.AutomationElementNet;
        }

        //[Inject]
        //public UiElement(viacom.AutomationElement element)
        //{
        //    this._elementHolderCom = element;
        //}

        [Inject()]
        public UiElement(IUiElement element)
        {
            _elementHolderAdapter = element;
            _innerElementType = InnerElementTypes.UiElement;
        }

        [Inject()]
        public UiElement()
        {
            // temporary
            // later use here an empty proxy
            _elementHolderNet = classic.AutomationElement.RootElement;
            //
            _innerElementType = InnerElementTypes.Empty;
            // _innerElementType = InnerElementTypes.AutomationElementNet;
        }

        public override bool Equals(object obj)
        {
            switch (_innerElementType) {
                case InnerElementTypes.AutomationElementNet:
                    return _elementHolderNet.Equals(obj);
//                case InnerElementTypes.AutomationElementCom:
//                    //
                case InnerElementTypes.UiElement:
                    return _elementHolderAdapter.Equals(obj);
                default:
                    return _elementHolderNet.Equals(obj);
            }
        }

        public override int GetHashCode()
        {
            switch (_innerElementType) {
                case InnerElementTypes.AutomationElementNet:
                    return _elementHolderNet.GetHashCode();
//                case InnerElementTypes.AutomationElementCom:
//                    //
                case InnerElementTypes.UiElement:
                    return _elementHolderAdapter.GetHashCode();
                default:
                    return _elementHolderNet.GetHashCode();
            }
        }

        public virtual int[] GetRuntimeId()
        {
            switch (_innerElementType) {
                case InnerElementTypes.AutomationElementNet:
                    return _elementHolderNet.GetRuntimeId();
//                case InnerElementTypes.AutomationElementCom:
//                    //
                case InnerElementTypes.UiElement:
                    return _elementHolderAdapter.GetRuntimeId();
                default:
                    return _elementHolderNet.GetRuntimeId();
            }
        }

        public virtual object GetCurrentPropertyValue(classic.AutomationProperty property)
        {
            switch (_innerElementType) {
                case InnerElementTypes.AutomationElementNet:
                    return Preferences.FromCache ? _elementHolderNet.GetCachedPropertyValue(property) : _elementHolderNet.GetCurrentPropertyValue(property);
                //                case InnerElementTypes.AutomationElementCom:
//                    //
                case InnerElementTypes.UiElement:
                    return Preferences.FromCache ? _elementHolderAdapter.GetCachedPropertyValue(property) : _elementHolderAdapter.GetCurrentPropertyValue(property);
                default:
                    return Preferences.FromCache ? _elementHolderNet.GetCachedPropertyValue(property) : _elementHolderNet.GetCurrentPropertyValue(property);
            }
        }

        public virtual object GetCurrentPropertyValue(classic.AutomationProperty property, bool ignoreDefaultValue)
        {
            switch (_innerElementType) {
                case InnerElementTypes.AutomationElementNet:
                    return Preferences.FromCache ? _elementHolderNet.GetCachedPropertyValue(property, ignoreDefaultValue) : _elementHolderNet.GetCurrentPropertyValue(property, ignoreDefaultValue);
                //                case InnerElementTypes.AutomationElementCom:
//                    //
                case InnerElementTypes.UiElement:
                    return Preferences.FromCache ? _elementHolderAdapter.GetCachedPropertyValue(property, ignoreDefaultValue) : _elementHolderAdapter.GetCurrentPropertyValue(property, ignoreDefaultValue);
                default:
                    return Preferences.FromCache ? _elementHolderNet.GetCachedPropertyValue(property, ignoreDefaultValue) : _elementHolderNet.GetCurrentPropertyValue(property, ignoreDefaultValue);
            }
        }

        public virtual TPatternInterface GetCurrentPattern<TPatternInterface>(classic.AutomationPattern pattern) where TPatternInterface : IBasePattern
        {

            switch (_innerElementType) {
                case InnerElementTypes.AutomationElementNet:
                    if (Preferences.FromCache) {
                        return (TPatternInterface)AutomationFactory.GetPatternAdapter<TPatternInterface>(this, _elementHolderNet.GetCachedPattern(pattern));
                    } else {
                        return (TPatternInterface)AutomationFactory.GetPatternAdapter<TPatternInterface>(this, _elementHolderNet.GetCurrentPattern(pattern));
                    }
                // default:
//                case InnerElementTypes.AutomationElementCom:
//                    //
                    // 20131208
                case InnerElementTypes.UiElement:
                    // return Preferences.FromCache ? _elementHolderAdapter.GetCachedPattern(pattern) : _elementHolderAdapter.GetCurrentPattern(pattern);
                    return Preferences.FromCache ? default(TPatternInterface) : _elementHolderAdapter.GetCurrentPattern<TPatternInterface>(pattern);
                    // default:
                    //    return Preferences.FromCache ? _elementHolderNet.GetCachedPattern(pattern) : _elementHolderNet.GetCurrentPattern(pattern);
                default:
                    if (Preferences.FromCache) {
                        return (TPatternInterface)AutomationFactory.GetPatternAdapter<TPatternInterface>(this, _elementHolderNet.GetCachedPattern(pattern));
                    } else {
                        return (TPatternInterface)AutomationFactory.GetPatternAdapter<TPatternInterface>(this, _elementHolderNet.GetCurrentPattern(pattern));
                    }
            }

            // return default(N);
        }

        public virtual object GetCurrentPattern(classic.AutomationPattern pattern)
        {
            switch (_innerElementType) {
                case InnerElementTypes.AutomationElementNet:
                    // 20140208
                    // return _elementHolderNet.GetCurrentPattern(pattern);
                    return Preferences.FromCache ? _elementHolderNet.GetCachedPattern(pattern) : _elementHolderNet.GetCurrentPattern(pattern);
                default:
//                case InnerElementTypes.AutomationElementCom:
//                    //
                    // case InnerElementTypes.UiElement:
                    //     return _elementHolderAdapter.GetCurrentPattern(pattern);
                    return _elementHolderNet.GetCurrentPattern(pattern);
            }
        }

        public virtual bool TryGetCurrentPattern(classic.AutomationPattern pattern, out object patternObject)
        {
            switch (_innerElementType) {
                case InnerElementTypes.AutomationElementNet:
                    return Preferences.FromCache ? _elementHolderNet.TryGetCachedPattern(pattern, out patternObject) : _elementHolderNet.TryGetCurrentPattern(pattern, out patternObject);
                //                case InnerElementTypes.AutomationElementCom:
//                    //
                case InnerElementTypes.UiElement:
                    return Preferences.FromCache ? _elementHolderAdapter.TryGetCachedPattern(pattern, out patternObject) : _elementHolderAdapter.TryGetCurrentPattern(pattern, out patternObject);
                default:
                    return Preferences.FromCache ? _elementHolderNet.TryGetCachedPattern(pattern, out patternObject) : _elementHolderNet.TryGetCurrentPattern(pattern, out patternObject);
            }
        }

        public virtual object GetCachedPropertyValue(classic.AutomationProperty property)
        {
            switch (_innerElementType) {
                case InnerElementTypes.AutomationElementNet:
                    return _elementHolderNet.GetCachedPropertyValue(property);
//                case InnerElementTypes.AutomationElementCom:
//                    //
                case InnerElementTypes.UiElement:
                    return _elementHolderAdapter.GetCachedPropertyValue(property);
                default:
                    return _elementHolderNet.GetCachedPropertyValue(property);
            }
        }

        public virtual object GetCachedPropertyValue(classic.AutomationProperty property, bool ignoreDefaultValue)
        {
            switch (_innerElementType) {
                case InnerElementTypes.AutomationElementNet:
                    return _elementHolderNet.GetCachedPropertyValue(property, ignoreDefaultValue);
//                case InnerElementTypes.AutomationElementCom:
//                    //
                case InnerElementTypes.UiElement:
                    return _elementHolderAdapter.GetCachedPropertyValue(property, ignoreDefaultValue);
                default:
                    return _elementHolderNet.GetCachedPropertyValue(property, ignoreDefaultValue);
            }
        }

        public virtual object GetCachedPattern(classic.AutomationPattern pattern)
        {
            switch (_innerElementType) {
                case InnerElementTypes.AutomationElementNet:
                    return _elementHolderNet.GetCachedPattern(pattern);
//                case InnerElementTypes.AutomationElementCom:
//                    //
                case InnerElementTypes.UiElement:
                    return _elementHolderAdapter.GetCachedPattern(pattern);
                default:
                    return _elementHolderNet.GetCachedPattern(pattern);
            }
        }

        public virtual bool TryGetCachedPattern(classic.AutomationPattern pattern, out object patternObject)
        {
            switch (_innerElementType) {
                case InnerElementTypes.AutomationElementNet:
                    return _elementHolderNet.TryGetCachedPattern(pattern, out patternObject);
//                case InnerElementTypes.AutomationElementCom:
//                    //
                case InnerElementTypes.UiElement:
                    return _elementHolderAdapter.TryGetCachedPattern(pattern, out patternObject);
                default:
                    return _elementHolderNet.TryGetCachedPattern(pattern, out patternObject);
            }
        }

        public virtual classic.AutomationElement GetUpdatedCache(classic.CacheRequest request)
        {
            switch (_innerElementType) {
                case InnerElementTypes.AutomationElementNet:
                    return _elementHolderNet.GetUpdatedCache(request);
//                case InnerElementTypes.AutomationElementCom:
//                    //
                case InnerElementTypes.UiElement:
                    return _elementHolderAdapter.GetUpdatedCache(request);
                default:
                    return _elementHolderNet.GetUpdatedCache(request);
            }
        }

        public virtual IUiElement FindFirst(classic.TreeScope scope, UIANET.System.Windows.Automation.Condition condition)
        {
            switch (_innerElementType) {
                case InnerElementTypes.AutomationElementNet:
                    return AutomationFactory.GetUiElement(_elementHolderNet.FindFirst(scope, condition));
//                case InnerElementTypes.AutomationElementCom:
//                    //
                case InnerElementTypes.UiElement:
                    return _elementHolderAdapter.FindFirst(scope, condition);
                default:
                    return AutomationFactory.GetUiElement(_elementHolderNet.FindFirst(scope, condition));
            }
        }

        public virtual IUiEltCollection FindAll(classic.TreeScope scope, UIANET.System.Windows.Automation.Condition condition)
        {
            switch (_innerElementType) {
                case InnerElementTypes.AutomationElementNet:
                    return AutomationFactory.GetUiEltCollection(_elementHolderNet.FindAll(scope, condition));
//                case InnerElementTypes.AutomationElementCom:
//                    //
                case InnerElementTypes.UiElement:
                    return _elementHolderAdapter.FindAll(scope, condition);
                default:
//                case InnerElementTypes.Empty:
//                    return AutomationFactory.GetUiEltCollection(_elementHolderNet.FindAll(scope, condition));
                    return AutomationFactory.GetUiEltCollection(_elementHolderNet.FindAll(scope, condition));
            }
        }
        
//        public virtual IUiEltCollection FindAll(TreeScope scope, UIANET.System.Windows.Automation.Condition condition, IEnumerable<IUiElement> excludeElements)
//        {
//            switch (_innerElementType) {
//                case InnerElementTypes.AutomationElementNet:
//                    // return AutomationFactory.GetUiEltCollection(_elementHolderNet.FindAll(scope, condition));
//                    return _elementHolderNet.FindAll(scope, condition).GetOnlyNewElements(excludeElements);
////                case InnerElementTypes.AutomationElementCom:
////                    //
//                case InnerElementTypes.UiElement:
//                    return _elementHolderAdapter.FindAll(scope, condition);
//                default:
////                case InnerElementTypes.Empty:
////                    return AutomationFactory.GetUiEltCollection(_elementHolderNet.FindAll(scope, condition));
//                    // return AutomationFactory.GetUiEltCollection(_elementHolderNet.FindAll(scope, condition));
//                    return _elementHolderNet.FindAll(scope, condition).GetOnlyNewElements(excludeElements);
//            }
//        }

        public virtual classic.AutomationProperty[] GetSupportedProperties()
        {
            switch (_innerElementType) {
                case InnerElementTypes.AutomationElementNet:
                    return _elementHolderNet.GetSupportedProperties();
//                case InnerElementTypes.AutomationElementCom:
//                    //
                case InnerElementTypes.UiElement:
                    return _elementHolderAdapter.GetSupportedProperties();
                default:
                    return _elementHolderNet.GetSupportedProperties();
            }
        }

        public virtual IBasePattern[] GetSupportedPatterns()
        {
            switch (_innerElementType) {
                case InnerElementTypes.AutomationElementNet:
                    return _elementHolderNet.GetSupportedPatterns().ConvertAutomationPatternToBasePattern(this);
//                case InnerElementTypes.AutomationElementCom:
//                    //
                case InnerElementTypes.UiElement:
                    return _elementHolderAdapter.GetSupportedPatterns();
                default:
                    return _elementHolderNet.GetSupportedPatterns().ConvertAutomationPatternToBasePattern(this);
            }
        }

        public virtual void SetFocus()
        {
            //
            try {
                switch (_innerElementType) {
                    case InnerElementTypes.AutomationElementNet:
                        _elementHolderNet.SetFocus();
                        break;
    //                case InnerElementTypes.AutomationElementCom:
    //                    //
                    case InnerElementTypes.UiElement:
                        _elementHolderAdapter.SetFocus();
                        break;
                    default:
                        _elementHolderNet.SetFocus();
                        break;
                }
            }
            catch {}
            //
        }

        public virtual bool TryGetClickablePoint(out Point pt)
        {
            switch (_innerElementType) {
                case InnerElementTypes.AutomationElementNet:
                    return _elementHolderNet.TryGetClickablePoint(out pt);
//                case InnerElementTypes.AutomationElementCom:
//                    //
                case InnerElementTypes.UiElement:
                    return _elementHolderAdapter.TryGetClickablePoint(out pt);
                default:
                    return _elementHolderNet.TryGetClickablePoint(out pt);
            }
        }

        public virtual Point GetClickablePoint()
        {
            switch (_innerElementType) {
                case InnerElementTypes.AutomationElementNet:
                    return _elementHolderNet.GetClickablePoint();
//                case InnerElementTypes.AutomationElementCom:
//                    //
                case InnerElementTypes.UiElement:
                    return _elementHolderAdapter.GetClickablePoint();
                default:
                    return _elementHolderNet.GetClickablePoint();
            }
        }
        
        internal virtual IUiElementInformation Cached {
            get {
                switch (_innerElementType) {
                    case InnerElementTypes.AutomationElementNet:
                        return AutomationFactory.GetUiElementInformation(_elementHolderNet.Cached);
//                    case /InnerElementTypes.AutomationElementCom:
//                        //
                    case InnerElementTypes.UiElement:
                        // 20140312
                        // return _elementHolderAdapter.Cached;
                        // return (_elementHolderAdapter as ISupportsCached).Cached;
                        return _elementHolderAdapter.GetCached();
                    default:
                        return AutomationFactory.GetUiElementInformation(_elementHolderNet.Cached);
                }
            }
        }
        
        internal virtual IUiElementInformation Current {
            get {
                switch (_innerElementType) {
                    case InnerElementTypes.AutomationElementNet:
                        return AutomationFactory.GetUiElementInformation(Preferences.FromCache ? _elementHolderNet.Cached : _elementHolderNet.Current);
//                    case InnerElementTypes.AutomationElementCom:
//                        //
                    case InnerElementTypes.UiElement:
                        // 20140312
                        // return Preferences.FromCache ? _elementHolderAdapter.Cached : _elementHolderAdapter.Current;
                        // return Preferences.FromCache ? (_elementHolderAdapter as ISupportsCached).Cached : (_elementHolderAdapter as ISupportsCurrent).Current;
                        return Preferences.FromCache ? _elementHolderAdapter.GetCached() : _elementHolderAdapter.GetCurrent();
                    default:
                        return AutomationFactory.GetUiElementInformation(Preferences.FromCache ? _elementHolderNet.Cached : _elementHolderNet.Current);
                }
            }
        }
        
        internal virtual IUiElement CachedParent {
            get {
                switch (_innerElementType) {
                    case InnerElementTypes.AutomationElementNet:
                        return AutomationFactory.GetUiElement(_elementHolderNet.CachedParent);
//                    case InnerElementTypes.AutomationElementCom:
//                        //
                    case InnerElementTypes.UiElement:
                        // 20140312
                        // return _elementHolderAdapter.CachedParent;
                        // return (_elementHolderAdapter as ISupportsCached).CachedParent;
                        return _elementHolderAdapter.GetCachedParent();
                    default:
                        return AutomationFactory.GetUiElement(_elementHolderNet.CachedParent);
                }
            }
        }
        
        internal virtual IUiEltCollection CachedChildren {
            get {
                switch (_innerElementType) {
                    case InnerElementTypes.AutomationElementNet:
                        return AutomationFactory.GetUiEltCollection(_elementHolderNet.CachedChildren);
//                    case /InnerElementTypes.AutomationElementCom:
//                        //
                    case InnerElementTypes.UiElement:
                        // 20140312
                        // return _elementHolderAdapter.CachedChildren;
                        // return (_elementHolderAdapter as ISupportsCached).CachedChildren;
                        return _elementHolderAdapter.GetCachedChildren();
                    default:
                        return AutomationFactory.GetUiEltCollection(_elementHolderNet.CachedChildren);
                }
            }
        }
        
        #region Cached
        public virtual IUiElementInformation GetCached()
        {
            try {
                return Cached;
            } catch (Exception) {
                return null;
                // throw;
            }
        }
        
        public virtual IUiElement GetCachedParent()
        {
            try {
                return CachedParent;
            } catch (Exception) {
                return null;
                // throw;
            }
        }
        
        public virtual IUiEltCollection GetCachedChildren()
        {
            try {
                return CachedChildren;
            } catch (Exception) {
                return null;
                // throw;
            }
        }
        #endregion Cached
        #region Current
        public virtual IUiElementInformation GetCurrent()
        {
            try {
                return Current;
            } catch (Exception) {
                return null;
                // throw;
            }
        }
        #endregion Current
        
        // static methods and properties
        public static readonly object NotSupported = classic.AutomationElementIdentifiers.NotSupported;
        public static readonly classic.AutomationProperty IsControlElementProperty = classic.AutomationElementIdentifiers.IsControlElementProperty;
        public static readonly classic.AutomationProperty ControlTypeProperty = classic.AutomationElementIdentifiers.ControlTypeProperty;
        public static readonly classic.AutomationProperty IsContentElementProperty = classic.AutomationElementIdentifiers.IsContentElementProperty;
        public static readonly classic.AutomationProperty LabeledByProperty = classic.AutomationElementIdentifiers.LabeledByProperty;
        public static readonly classic.AutomationProperty NativeWindowHandleProperty = classic.AutomationElementIdentifiers.NativeWindowHandleProperty;
        public static readonly classic.AutomationProperty AutomationIdProperty = classic.AutomationElementIdentifiers.AutomationIdProperty;
        public static readonly classic.AutomationProperty ItemTypeProperty = classic.AutomationElementIdentifiers.ItemTypeProperty;
        public static readonly classic.AutomationProperty IsPasswordProperty = classic.AutomationElementIdentifiers.IsPasswordProperty;
        public static readonly classic.AutomationProperty LocalizedControlTypeProperty = classic.AutomationElementIdentifiers.LocalizedControlTypeProperty;
        public static readonly classic.AutomationProperty NameProperty = classic.AutomationElementIdentifiers.NameProperty;
        public static readonly classic.AutomationProperty AcceleratorKeyProperty = classic.AutomationElementIdentifiers.AcceleratorKeyProperty;
        public static readonly classic.AutomationProperty AccessKeyProperty = classic.AutomationElementIdentifiers.AccessKeyProperty;
        public static readonly classic.AutomationProperty HasKeyboardFocusProperty = classic.AutomationElementIdentifiers.HasKeyboardFocusProperty;
        public static readonly classic.AutomationProperty IsKeyboardFocusableProperty = classic.AutomationElementIdentifiers.IsKeyboardFocusableProperty;
        public static readonly classic.AutomationProperty IsEnabledProperty = classic.AutomationElementIdentifiers.IsEnabledProperty;
        public static readonly classic.AutomationProperty BoundingRectangleProperty = classic.AutomationElementIdentifiers.BoundingRectangleProperty;
        public static readonly classic.AutomationProperty ProcessIdProperty = classic.AutomationElementIdentifiers.ProcessIdProperty;
        public static readonly classic.AutomationProperty RuntimeIdProperty = classic.AutomationElementIdentifiers.RuntimeIdProperty;
        public static readonly classic.AutomationProperty ClassNameProperty = classic.AutomationElementIdentifiers.ClassNameProperty;
        public static readonly classic.AutomationProperty HelpTextProperty = classic.AutomationElementIdentifiers.HelpTextProperty;
        public static readonly classic.AutomationProperty ClickablePointProperty = classic.AutomationElementIdentifiers.ClickablePointProperty;
        public static readonly classic.AutomationProperty CultureProperty = classic.AutomationElementIdentifiers.CultureProperty;
        public static readonly classic.AutomationProperty IsOffscreenProperty = classic.AutomationElementIdentifiers.IsOffscreenProperty;
        public static readonly classic.AutomationProperty OrientationProperty = classic.AutomationElementIdentifiers.OrientationProperty;
        public static readonly classic.AutomationProperty FrameworkIdProperty = classic.AutomationElementIdentifiers.FrameworkIdProperty;
        public static readonly classic.AutomationProperty IsRequiredForFormProperty = classic.AutomationElementIdentifiers.IsRequiredForFormProperty;
        public static readonly classic.AutomationProperty ItemStatusProperty = classic.AutomationElementIdentifiers.ItemStatusProperty;
        public static readonly classic.AutomationProperty IsDockPatternAvailableProperty = classic.AutomationElementIdentifiers.IsDockPatternAvailableProperty;
        public static readonly classic.AutomationProperty IsExpandCollapsePatternAvailableProperty = classic.AutomationElementIdentifiers.IsExpandCollapsePatternAvailableProperty;
        public static readonly classic.AutomationProperty IsGridItemPatternAvailableProperty = classic.AutomationElementIdentifiers.IsGridItemPatternAvailableProperty;
        public static readonly classic.AutomationProperty IsGridPatternAvailableProperty = classic.AutomationElementIdentifiers.IsGridPatternAvailableProperty;
        public static readonly classic.AutomationProperty IsInvokePatternAvailableProperty = classic.AutomationElementIdentifiers.IsInvokePatternAvailableProperty;
        public static readonly classic.AutomationProperty IsMultipleViewPatternAvailableProperty = classic.AutomationElementIdentifiers.IsMultipleViewPatternAvailableProperty;
        public static readonly classic.AutomationProperty IsRangeValuePatternAvailableProperty = classic.AutomationElementIdentifiers.IsRangeValuePatternAvailableProperty;
        public static readonly classic.AutomationProperty IsSelectionItemPatternAvailableProperty = classic.AutomationElementIdentifiers.IsSelectionItemPatternAvailableProperty;
        public static readonly classic.AutomationProperty IsSelectionPatternAvailableProperty = classic.AutomationElementIdentifiers.IsSelectionPatternAvailableProperty;
        public static readonly classic.AutomationProperty IsScrollPatternAvailableProperty = classic.AutomationElementIdentifiers.IsScrollPatternAvailableProperty;
        public static readonly classic.AutomationProperty IsScrollItemPatternAvailableProperty = classic.AutomationElementIdentifiers.IsScrollItemPatternAvailableProperty;
        public static readonly classic.AutomationProperty IsTablePatternAvailableProperty = classic.AutomationElementIdentifiers.IsTablePatternAvailableProperty;
        public static readonly classic.AutomationProperty IsTableItemPatternAvailableProperty = classic.AutomationElementIdentifiers.IsTableItemPatternAvailableProperty;
        public static readonly classic.AutomationProperty IsTextPatternAvailableProperty = classic.AutomationElementIdentifiers.IsTextPatternAvailableProperty;
        public static readonly classic.AutomationProperty IsTogglePatternAvailableProperty = classic.AutomationElementIdentifiers.IsTogglePatternAvailableProperty;
        public static readonly classic.AutomationProperty IsTransformPatternAvailableProperty = classic.AutomationElementIdentifiers.IsTransformPatternAvailableProperty;
        public static readonly classic.AutomationProperty IsValuePatternAvailableProperty = classic.AutomationElementIdentifiers.IsValuePatternAvailableProperty;
        public static readonly classic.AutomationProperty IsWindowPatternAvailableProperty = classic.AutomationElementIdentifiers.IsWindowPatternAvailableProperty;
        public static readonly classic.AutomationEvent ToolTipOpenedEvent = classic.AutomationElementIdentifiers.ToolTipOpenedEvent;
        public static readonly classic.AutomationEvent ToolTipClosedEvent = classic.AutomationElementIdentifiers.ToolTipClosedEvent;
        public static readonly classic.AutomationEvent StructureChangedEvent = classic.AutomationElementIdentifiers.StructureChangedEvent;
        public static readonly classic.AutomationEvent MenuOpenedEvent = classic.AutomationElementIdentifiers.MenuOpenedEvent;
        public static readonly classic.AutomationEvent AutomationPropertyChangedEvent = classic.AutomationElementIdentifiers.AutomationPropertyChangedEvent;
        public static readonly classic.AutomationEvent AutomationFocusChangedEvent = classic.AutomationElementIdentifiers.AutomationFocusChangedEvent;
        public static readonly classic.AutomationEvent AsyncContentLoadedEvent = classic.AutomationElementIdentifiers.AsyncContentLoadedEvent;
        public static readonly classic.AutomationEvent MenuClosedEvent = classic.AutomationElementIdentifiers.MenuClosedEvent;
        public static readonly classic.AutomationEvent LayoutInvalidatedEvent = classic.AutomationElementIdentifiers.LayoutInvalidatedEvent;

        public static IUiElement RootElement {
            get {
                switch (_innerElementType) {
                    case InnerElementTypes.AutomationElementNet:
                        return AutomationFactory.GetUiElement(classic.AutomationElement.RootElement);
//                    case InnerElementTypes.AutomationElementCom:
//                        //
                    case InnerElementTypes.UiElement:
                        return RootElement;
                    default:
                        return AutomationFactory.GetUiElement(classic.AutomationElement.RootElement);
                }
            }
        }

        public static IUiElement FocusedElement {
            get {
                switch (_innerElementType) {
                    case InnerElementTypes.AutomationElementNet:
                        return AutomationFactory.GetUiElement(classic.AutomationElement.FocusedElement);
//                    case InnerElementTypes.AutomationElementCom:
//                        //
                    case InnerElementTypes.UiElement:
                        return FocusedElement;
                    default:
                        return AutomationFactory.GetUiElement(classic.AutomationElement.FocusedElement);
                }
            }
        }

        public static IUiElement FromPoint(Point pt)
        {
            switch (_innerElementType) {
                case InnerElementTypes.AutomationElementNet:
                    return AutomationFactory.GetUiElement(classic.AutomationElement.FromPoint(pt));
//                case InnerElementTypes.AutomationElementCom:
//                    //
                case InnerElementTypes.UiElement:
                    return FromPoint(pt);
                default:
                    return AutomationFactory.GetUiElement(classic.AutomationElement.FromPoint(pt));
            }
        }

        public static IUiElement FromHandle(IntPtr controlHandle)
        {
            switch (_innerElementType) {
                case InnerElementTypes.AutomationElementNet:
                    return AutomationFactory.GetUiElement(classic.AutomationElement.FromHandle(controlHandle));
//                case InnerElementTypes.AutomationElementCom:
//                    //
                case InnerElementTypes.UiElement:
                    return FromHandle(controlHandle);
                default:
                    return AutomationFactory.GetUiElement(classic.AutomationElement.FromHandle(controlHandle));
            }
        }
        
        public virtual object GetSourceElement()
        {
            if (null != _elementHolderNet) {
                return _elementHolderNet;
            } else if (null != _elementHolderAdapter) {
                return _elementHolderAdapter;
            } else {
                return null;
            }
        }

        public virtual void SetSourceElement<T>(T element)
        {
            if (element is classic.AutomationElement) {
                _elementHolderNet = element as classic.AutomationElement;
                _innerElementType = InnerElementTypes.AutomationElementNet;
            }
            // if com
            if (element is IUiElement) {
                _elementHolderAdapter = (IUiElement)element;
                _innerElementType = InnerElementTypes.UiElement;
            }
            
            if (null == element) {
                _elementHolderNet = null;
                // com
                _elementHolderAdapter = null;
            }
        }
        
        internal virtual string Tag { get; set; }
        public virtual string GetTag()
        {
            return Tag;
        }
        
        public virtual void SetTag(string tag)
        {
            Tag = tag;
        }
        
        // 20140110
        public bool IsValid()
        {
            return this.GetIsValid();
        }
        
        public virtual void Dispose()
        // public void Dispose()
        {
            // ? if (null != this._elementHolderNet) this._elementHolderNet = null;
            // ? if (null != this._elementHolderAdapter) {
            // ?     this._elementHolderAdapter.Dispose();
            // ?     this._elementHolderAdapter = null;
            // ? }
            
//            this.ChildKernel.Dispose();
            
            // 20140131
            // 20140205
            // if (null != this._elementHolderNet) this._elementHolderNet = null;
            // if (null != this._elementHolderAdapter) this._elementHolderAdapter = null;
            // 20140205
            // if (null != this._elementHolderAdapter) this._elementHolderAdapter.Dispose();
            
            GC.SuppressFinalize(this);
        }

        // internal methods
        public virtual object GetPatternPropertyValue(classic.AutomationProperty property, bool useCache)
        {
            if (useCache) {
                switch (_innerElementType) {
                    case InnerElementTypes.AutomationElementNet:
                        return _elementHolderNet.GetCachedPropertyValue(property);
                    //case InnerElementTypes.AutomationElementCom:
                    //    
                    case InnerElementTypes.UiElement:
                        return _elementHolderAdapter.GetCachedPropertyValue(property);
                    default:
                        return _elementHolderNet.GetCachedPropertyValue(property);
                }
            }

            switch (_innerElementType) {
                case InnerElementTypes.AutomationElementNet:
                    return _elementHolderNet.GetCurrentPropertyValue(property);
                //case InnerElementTypes.AutomationElementCom:
                //    
                case InnerElementTypes.UiElement:
                    return _elementHolderAdapter.GetCurrentPropertyValue(property);
                default:
                    return _elementHolderNet.GetCurrentPropertyValue(property);
            }
        }
    }
}
