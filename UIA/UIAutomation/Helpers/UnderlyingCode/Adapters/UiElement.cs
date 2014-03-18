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
//	using System.Windows.Automation;
	using Ninject;
	using System.Windows;
	using System.Linq;
	
//	using Ninject.Extensions.ChildKernel;
    
	/// <summary>
	/// Description of UiElement.
	/// </summary>
	public class UiElement : IUiElement
	{
		private classic.AutomationElement _elementHolderNet;
		// //private AutomationElement _elementHolderCom;
        // 20140316
        private viacom.AutomationElement _elementHolderCom;
        
		// private viacom. _elementHolderCom;
		// private readonly IUiElement _elementHolderAdapter;
		private IUiElement _elementHolderAdapter;
		//private static InnerElementTypes _innerElementType = InnerElementTypes.AutomationElementNet;
        
        // temporary!
        // public static InnerElementTypes _innerElementType = InnerElementTypes.AutomationElementNet;
        public InnerElementTypes _innerElementType = InnerElementTypes.AutomationElementNet;
        
		// internal static InnerElementTypes InnerElementType
//		internal static InnerElementTypes InnerElementType
//		{
//		    get { return _innerElementType; }
//		    set { _innerElementType = value; }
//		}
		
//		internal IChildKernel ChildKernel { get; set; }
        
		// 20140315
//		[Inject()]
//		public UiElement(classic.AutomationElement element)
//		{
//			_elementHolderNet = element;
//			_innerElementType = InnerElementTypes.AutomationElementNet;
//		}
//
//		//[Inject]
//		//public UiElement(viacom.AutomationElement element)
//		//{
//		//	this._elementHolderCom = element;
//		//}
//
//		[Inject()]
//		public UiElement(IUiElement element)
//		{
//			_elementHolderAdapter = element;
//			_innerElementType = InnerElementTypes.UiElement;
//		}
        // 20140318
        
		[Inject()]
		public UiElement()
		{
			// temporary
			// later use here an empty proxy
            // 20140316
			// _elementHolderNet = classic.AutomationElement.RootElement;
			//
			// _innerElementType = InnerElementTypes.Empty;
			_innerElementType = InnerElementTypes.AutomationElementNet;
		}
        
        // 20140318
        /*
        [Inject]
        public UiElement(object element)
        {
            // 20140316
			// if (element is classic.AutomationElement) {
            if (null != element as classic.AutomationElement) {
// Console.WriteLine("SetSourceElement: 001.1");
				_elementHolderNet = element as classic.AutomationElement;
// Console.WriteLine("SetSourceElement: 001.2");
				_innerElementType = InnerElementTypes.AutomationElementNet;
                
                // 20140316
                return;
			}
			// if com
            // 20140316
            if (null != element as viacom.AutomationElement) {
                
                _elementHolderCom = element as viacom.AutomationElement;
                _innerElementType = InnerElementTypes.AutomationElementCom;
                return;
            }
            
            // 20140316
			// if (element is IUiElement) {
            if (null != element as IUiElement) {
//Console.WriteLine("SetSourceElement: 002.1");
				_elementHolderAdapter = (IUiElement)element;
//Console.WriteLine("SetSourceElement: 002.2");
				_innerElementType = InnerElementTypes.UiElement;
                // 20140316
                return;
			}
        }
        */

		public override bool Equals(object obj)
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return _elementHolderNet.Equals(obj);
			    case InnerElementTypes.AutomationElementCom:
			        return _elementHolderCom.Equals(obj);
				case InnerElementTypes.UiElement:
					return _elementHolderAdapter.Equals(obj);
                // 20140316
				default:
					// return _elementHolderNet.Equals(obj);
                    return false;
			}
		}

		public override int GetHashCode()
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return _elementHolderNet.GetHashCode();
			    case InnerElementTypes.AutomationElementCom:
			        return _elementHolderCom.GetHashCode();
				case InnerElementTypes.UiElement:
					return _elementHolderAdapter.GetHashCode();
                // 20140316
				default:
					// return _elementHolderNet.GetHashCode();
                    return 0;
			}
		}

		public virtual int[] GetRuntimeId()
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return _elementHolderNet.GetRuntimeId();
			    case InnerElementTypes.AutomationElementCom:
			        return _elementHolderCom.GetRuntimeId();
				case InnerElementTypes.UiElement:
					return _elementHolderAdapter.GetRuntimeId();
                // 20140316
				default:
					// return _elementHolderNet.GetRuntimeId();
                    return new int[] {};
			}
		}

		public virtual object GetCurrentPropertyValue(classic.AutomationProperty property)
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return Preferences.FromCache ? _elementHolderNet.GetCachedPropertyValue(property) : _elementHolderNet.GetCurrentPropertyValue(property);
				case InnerElementTypes.AutomationElementCom:
			        return Preferences.FromCache ? _elementHolderCom.GetCachedPropertyValue(property) : _elementHolderCom.GetCurrentPropertyValue(property);
				case InnerElementTypes.UiElement:
					return Preferences.FromCache ? _elementHolderAdapter.GetCachedPropertyValue(property) : _elementHolderAdapter.GetCurrentPropertyValue(property);
                // 20140316
				default:
					// return Preferences.FromCache ? _elementHolderNet.GetCachedPropertyValue(property) : _elementHolderNet.GetCurrentPropertyValue(property);
                    return null;
			}
		}

		public virtual object GetCurrentPropertyValue(classic.AutomationProperty property, bool ignoreDefaultValue)
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return Preferences.FromCache ? _elementHolderNet.GetCachedPropertyValue(property, ignoreDefaultValue) : _elementHolderNet.GetCurrentPropertyValue(property, ignoreDefaultValue);
				case InnerElementTypes.AutomationElementCom:
			        return Preferences.FromCache ? _elementHolderCom.GetCachedPropertyValue(property, ignoreDefaultValue) : _elementHolderCom.GetCurrentPropertyValue(property, ignoreDefaultValue);
				case InnerElementTypes.UiElement:
					return Preferences.FromCache ? _elementHolderAdapter.GetCachedPropertyValue(property, ignoreDefaultValue) : _elementHolderAdapter.GetCurrentPropertyValue(property, ignoreDefaultValue);
                // 20140316
				default:
					// return Preferences.FromCache ? _elementHolderNet.GetCachedPropertyValue(property, ignoreDefaultValue) : _elementHolderNet.GetCurrentPropertyValue(property, ignoreDefaultValue);
                    return null;
			}
		}

		public virtual TPatternInterface GetCurrentPattern<TPatternInterface>(classic.AutomationPattern pattern) where TPatternInterface : IBasePattern
		{

			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
Console.WriteLine("pattern 01.1");
Console.WriteLine(typeof(TPatternInterface).Name);
					if (Preferences.FromCache) {
						return (TPatternInterface)AutomationFactory.GetPatternAdapter<TPatternInterface>(this, _elementHolderNet.GetCachedPattern(pattern));
					} else {
Console.WriteLine("pattern 01.1.2");
Console.WriteLine(this.Current.Name);
Console.WriteLine(this.Current.AutomationId);
Console.WriteLine(this.Current.ClassName);
Console.WriteLine(this.Current.ProcessId);
						return (TPatternInterface)AutomationFactory.GetPatternAdapter<TPatternInterface>(this, _elementHolderNet.GetCurrentPattern(pattern));
					}
				// default:
//			    case InnerElementTypes.AutomationElementCom:
//			        if (Preferences.FromCache) {
//						return (TPatternInterface)AutomationFactory.GetPatternAdapter<TPatternInterface>(this, _elementHolderCom.GetCachedPattern(pattern));
//					} else {
//						return (TPatternInterface)AutomationFactory.GetPatternAdapter<TPatternInterface>(this, _elementHolderCom.GetCurrentPattern(pattern));
//					}
					// 20131208
                case InnerElementTypes.UiElement:
Console.WriteLine("pattern 01.2");
                    // return Preferences.FromCache ? _elementHolderAdapter.GetCachedPattern(pattern) : _elementHolderAdapter.GetCurrentPattern(pattern);
                    return Preferences.FromCache ? default(TPatternInterface) : _elementHolderAdapter.GetCurrentPattern<TPatternInterface>(pattern);
					// default:
					//    return Preferences.FromCache ? _elementHolderNet.GetCachedPattern(pattern) : _elementHolderNet.GetCurrentPattern(pattern);
                // 20140316
                default:
//					if (Preferences.FromCache) {
//						return (TPatternInterface)AutomationFactory.GetPatternAdapter<TPatternInterface>(this, _elementHolderNet.GetCachedPattern(pattern));
//					} else {
//						return (TPatternInterface)AutomationFactory.GetPatternAdapter<TPatternInterface>(this, _elementHolderNet.GetCurrentPattern(pattern));
//					}
Console.WriteLine("pattern 01.3");
                    return default(TPatternInterface);
			}

			// return default(N);
		}

		public virtual object GetCurrentPattern(classic.AutomationPattern pattern)
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
Console.WriteLine("pattern 02.1");
		            // 20140208
					// return _elementHolderNet.GetCurrentPattern(pattern);
					return Preferences.FromCache ? _elementHolderNet.GetCachedPattern(pattern) : _elementHolderNet.GetCurrentPattern(pattern);
//                case InnerElementTypes.AutomationElementCom:
//                    return Preferences.FromCache ? _elementHolderCom.GetCachedPattern(pattern) : _elementHolderCom.GetCurrentPattern(pattern);
                // 20140316
				default:
////			    case InnerElementTypes.AutomationElementCom:
////			        //
//					// case InnerElementTypes.UiElement:
//					//     return _elementHolderAdapter.GetCurrentPattern(pattern);
//					return _elementHolderNet.GetCurrentPattern(pattern);
Console.WriteLine("pattern 02.3");
                    return null;
			}
		}

		public virtual bool TryGetCurrentPattern(classic.AutomationPattern pattern, out object patternObject)
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return Preferences.FromCache ? _elementHolderNet.TryGetCachedPattern(pattern, out patternObject) : _elementHolderNet.TryGetCurrentPattern(pattern, out patternObject);
				case InnerElementTypes.AutomationElementCom:
			        return Preferences.FromCache ? _elementHolderCom.TryGetCachedPattern(pattern, out patternObject) : _elementHolderCom.TryGetCurrentPattern(pattern, out patternObject);
				case InnerElementTypes.UiElement:
                    return Preferences.FromCache ? _elementHolderAdapter.TryGetCachedPattern(pattern, out patternObject) : _elementHolderAdapter.TryGetCurrentPattern(pattern, out patternObject);
                // 20140316
				default:
//					return Preferences.FromCache ? _elementHolderNet.TryGetCachedPattern(pattern, out patternObject) : _elementHolderNet.TryGetCurrentPattern(pattern, out patternObject);
                    patternObject = null;
                    return false;
			}
		}

		public virtual object GetCachedPropertyValue(classic.AutomationProperty property)
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return _elementHolderNet.GetCachedPropertyValue(property);
			    case InnerElementTypes.AutomationElementCom:
			        return _elementHolderCom.GetCachedPropertyValue(property);
				case InnerElementTypes.UiElement:
					return _elementHolderAdapter.GetCachedPropertyValue(property);
                // 20140316
				default:
//					return _elementHolderNet.GetCachedPropertyValue(property);
                    return false;
			}
		}

		public virtual object GetCachedPropertyValue(classic.AutomationProperty property, bool ignoreDefaultValue)
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return _elementHolderNet.GetCachedPropertyValue(property, ignoreDefaultValue);
			    case InnerElementTypes.AutomationElementCom:
			        return _elementHolderCom.GetCachedPropertyValue(property, ignoreDefaultValue);
				case InnerElementTypes.UiElement:
					return _elementHolderAdapter.GetCachedPropertyValue(property, ignoreDefaultValue);
                // 20140316
				default:
//					return _elementHolderNet.GetCachedPropertyValue(property, ignoreDefaultValue);
                    return null;
			}
		}

		public virtual object GetCachedPattern(classic.AutomationPattern pattern)
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return _elementHolderNet.GetCachedPattern(pattern);
			    case InnerElementTypes.AutomationElementCom:
			        return _elementHolderCom.GetCachedPattern(pattern);
				case InnerElementTypes.UiElement:
					return _elementHolderAdapter.GetCachedPattern(pattern);
                // 20140316
				default:
//					return _elementHolderNet.GetCachedPattern(pattern);
                    return null;
			}
		}

		public virtual bool TryGetCachedPattern(classic.AutomationPattern pattern, out object patternObject)
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return _elementHolderNet.TryGetCachedPattern(pattern, out patternObject);
			    case InnerElementTypes.AutomationElementCom:
			        return _elementHolderCom.TryGetCachedPattern(pattern, out patternObject);
				case InnerElementTypes.UiElement:
					return _elementHolderAdapter.TryGetCachedPattern(pattern, out patternObject);
                // 20140316
				default:
//					return _elementHolderNet.TryGetCachedPattern(pattern, out patternObject);
                    patternObject = null;
                    return false;
			}
		}

		public virtual classic.AutomationElement GetUpdatedCache(classic.CacheRequest request)
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return _elementHolderNet.GetUpdatedCache(request);
			    case InnerElementTypes.AutomationElementCom:
			        return _elementHolderCom.GetUpdatedCache(request);
				case InnerElementTypes.UiElement:
					return _elementHolderAdapter.GetUpdatedCache(request);
                // 20140316
				default:
//					return _elementHolderNet.GetUpdatedCache(request);
                    return null;
			}
		}

		public virtual IUiElement FindFirst(classic.TreeScope scope, UIANET.System.Windows.Automation.Condition condition)
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return AutomationFactory.GetUiElement(_elementHolderNet.FindFirst(scope, condition));
                    // return AutomationFactory.GetUiElement(_elementHolderNet.FindFirst(scope, condition), "findfirst");
			    case InnerElementTypes.AutomationElementCom:
			        return AutomationFactory.GetUiElement(_elementHolderCom.FindFirst(scope, condition));
				case InnerElementTypes.UiElement:
					return _elementHolderAdapter.FindFirst(scope, condition);
                // 20140316
				default:
//					return AutomationFactory.GetUiElement(_elementHolderNet.FindFirst(scope, condition));
                    return null;
			}
		}

		public virtual IUiEltCollection FindAll(classic.TreeScope scope, UIANET.System.Windows.Automation.Condition condition)
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return AutomationFactory.GetUiEltCollection(_elementHolderNet.FindAll(scope, condition));
			    case InnerElementTypes.AutomationElementCom:
			        return AutomationFactory.GetUiEltCollection(_elementHolderCom.FindAll(scope, condition));
				case InnerElementTypes.UiElement:
					return _elementHolderAdapter.FindAll(scope, condition);
                // 20140316
				default:
////			    case InnerElementTypes.Empty:
////			        return AutomationFactory.GetUiEltCollection(_elementHolderNet.FindAll(scope, condition));
//					return AutomationFactory.GetUiEltCollection(_elementHolderNet.FindAll(scope, condition));
                    return null;
			}
		}
		
//		public virtual IUiEltCollection FindAll(TreeScope scope, UIANET.System.Windows.Automation.Condition condition, IEnumerable<IUiElement> excludeElements)
//		{
//			switch (_innerElementType) {
//				case InnerElementTypes.AutomationElementNet:
//					// return AutomationFactory.GetUiEltCollection(_elementHolderNet.FindAll(scope, condition));
//					return _elementHolderNet.FindAll(scope, condition).GetOnlyNewElements(excludeElements);
////			    case InnerElementTypes.AutomationElementCom:
////			        //
//				case InnerElementTypes.UiElement:
//					return _elementHolderAdapter.FindAll(scope, condition);
//				default:
////			    case InnerElementTypes.Empty:
////			        return AutomationFactory.GetUiEltCollection(_elementHolderNet.FindAll(scope, condition));
//					// return AutomationFactory.GetUiEltCollection(_elementHolderNet.FindAll(scope, condition));
//					return _elementHolderNet.FindAll(scope, condition).GetOnlyNewElements(excludeElements);
//			}
//		}

		public virtual classic.AutomationProperty[] GetSupportedProperties()
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return _elementHolderNet.GetSupportedProperties();
			    case InnerElementTypes.AutomationElementCom:
			        return _elementHolderCom.GetSupportedProperties();
				case InnerElementTypes.UiElement:
					return _elementHolderAdapter.GetSupportedProperties();
                // 20140316
				default:
//					return _elementHolderNet.GetSupportedProperties();
                    return null;
			}
		}

		public virtual IBasePattern[] GetSupportedPatterns()
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return _elementHolderNet.GetSupportedPatterns().ConvertAutomationPatternToBasePattern(this);
			    case InnerElementTypes.AutomationElementCom:
			        return _elementHolderCom.GetSupportedPatterns().ConvertAutomationPatternToBasePattern(this);
				case InnerElementTypes.UiElement:
					return _elementHolderAdapter.GetSupportedPatterns();
                // 20140316
				default:
//					return _elementHolderNet.GetSupportedPatterns().ConvertAutomationPatternToBasePattern(this);
                    return null;
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
    			    case InnerElementTypes.AutomationElementCom:
    			        _elementHolderCom.SetFocus();
                        break;
    				case InnerElementTypes.UiElement:
    					_elementHolderAdapter.SetFocus();
    					break;
                    // 20140316
    				default:
//    					_elementHolderNet.SetFocus();
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
			    case InnerElementTypes.AutomationElementCom:
			        return _elementHolderCom.TryGetClickablePoint(out pt);
				case InnerElementTypes.UiElement:
                    return _elementHolderAdapter.TryGetClickablePoint(out pt);
                // 20140316
				default:
//					return _elementHolderNet.TryGetClickablePoint(out pt);
                    pt = new Point(0, 0);
                    return false;
			}
		}

		public virtual Point GetClickablePoint()
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return _elementHolderNet.GetClickablePoint();
			    case InnerElementTypes.AutomationElementCom:
			        return _elementHolderCom.GetClickablePoint();
				case InnerElementTypes.UiElement:
					return _elementHolderAdapter.GetClickablePoint();
                // 20140316
				default:
//					return _elementHolderNet.GetClickablePoint();
                    return new Point(0, 0);
			}
		}
        
		internal virtual IUiElementInformation Cached {
			get {
				switch (_innerElementType) {
					case InnerElementTypes.AutomationElementNet:
						return AutomationFactory.GetUiElementInformation(_elementHolderNet.Cached);
			        case InnerElementTypes.AutomationElementCom:
			            return AutomationFactory.GetUiElementInformation(_elementHolderCom.Cached);
					case InnerElementTypes.UiElement:
                        // 20140312
						// return _elementHolderAdapter.Cached;
                        // return (_elementHolderAdapter as ISupportsCached).Cached;
                        return _elementHolderAdapter.GetCached();
                    // 20140316
					default:
//						return AutomationFactory.GetUiElementInformation(_elementHolderNet.Cached);
                        return null;
				}
			}
		}
        
        internal virtual IUiElementInformation Current {
			get {
				switch (_innerElementType) {
					case InnerElementTypes.AutomationElementNet:
						return AutomationFactory.GetUiElementInformation(Preferences.FromCache ? _elementHolderNet.Cached : _elementHolderNet.Current);
		            case InnerElementTypes.AutomationElementCom:
		                return AutomationFactory.GetUiElementInformation(Preferences.FromCache ? _elementHolderCom.Cached : _elementHolderCom.Current);
					case InnerElementTypes.UiElement:
                        // 20140312
						// return Preferences.FromCache ? _elementHolderAdapter.Cached : _elementHolderAdapter.Current;
                        // return Preferences.FromCache ? (_elementHolderAdapter as ISupportsCached).Cached : (_elementHolderAdapter as ISupportsCurrent).Current;
                        return Preferences.FromCache ? _elementHolderAdapter.GetCached() : _elementHolderAdapter.GetCurrent();
                    // 20140316
					default:
//						return AutomationFactory.GetUiElementInformation(Preferences.FromCache ? _elementHolderNet.Cached : _elementHolderNet.Current);
                        return null;
				}
			}
		}
        
		internal virtual IUiElement CachedParent {
			get {
				switch (_innerElementType) {
					case InnerElementTypes.AutomationElementNet:
						return AutomationFactory.GetUiElement(_elementHolderNet.CachedParent);
                        // return AutomationFactory.GetUiElement(_elementHolderNet.CachedParent, "cachedparent");
			        case InnerElementTypes.AutomationElementCom:
			            return AutomationFactory.GetUiElement(_elementHolderCom.CachedParent);
					case InnerElementTypes.UiElement:
                        // 20140312
						// return _elementHolderAdapter.CachedParent;
                        // return (_elementHolderAdapter as ISupportsCached).CachedParent;
                        return _elementHolderAdapter.GetCachedParent();
                    // 20140316
					default:
//						return AutomationFactory.GetUiElement(_elementHolderNet.CachedParent);
                        return null;
				}
			}
		}
        
		internal virtual IUiEltCollection CachedChildren {
			get {
				switch (_innerElementType) {
					case InnerElementTypes.AutomationElementNet:
						return AutomationFactory.GetUiEltCollection(_elementHolderNet.CachedChildren);
			        case InnerElementTypes.AutomationElementCom:
			            return AutomationFactory.GetUiEltCollection(_elementHolderCom.CachedChildren);
					case InnerElementTypes.UiElement:
                        // 20140312
						// return _elementHolderAdapter.CachedChildren;
                        // return (_elementHolderAdapter as ISupportsCached).CachedChildren;
                        return _elementHolderAdapter.GetCachedChildren();
                    // 20140316
					default:
//						return AutomationFactory.GetUiEltCollection(_elementHolderNet.CachedChildren);
                        return null;
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
//				switch (_innerElementType) {
//					case InnerElementTypes.AutomationElementNet:
//						return AutomationFactory.GetUiElement(classic.AutomationElement.RootElement);
//			        case InnerElementTypes.AutomationElementCom:
//			            return AutomationFactory.GetUiElement(viacom.AutomationElement.RootElement);
//					case InnerElementTypes.UiElement:
//						return RootElement;
//					default:
//						return AutomationFactory.GetUiElement(classic.AutomationElement.RootElement);
//				}
                return AutomationFactory.GetUiElement(classic.AutomationElement.RootElement);
                //
//                Console.WriteLine(AutomationFactory.GetUiElement(classic.AutomationElement.RootElement, "rootElement").GetCurrent().Name);
//                Console.WriteLine(AutomationFactory.GetUiElement(classic.AutomationElement.RootElement, "rootElement").GetCurrent().AutomationId);
//                Console.WriteLine(AutomationFactory.GetUiElement(classic.AutomationElement.RootElement, "rootElement").GetCurrent().ClassName);
//                Console.WriteLine(AutomationFactory.GetUiElement(classic.AutomationElement.RootElement, "rootElement").GetCurrent().ProcessId);
                //
                // return AutomationFactory.GetUiElement(classic.AutomationElement.RootElement, "rootElement");
			}
		}

		public static IUiElement FocusedElement {
			get {
//				switch (_innerElementType) {
//					case InnerElementTypes.AutomationElementNet:
//						return AutomationFactory.GetUiElement(classic.AutomationElement.FocusedElement);
//		            case InnerElementTypes.AutomationElementCom:
//		                return AutomationFactory.GetUiElement(viacom.AutomationElement.FocusedElement);
//					case InnerElementTypes.UiElement:
//						return FocusedElement;
//					default:
//						return AutomationFactory.GetUiElement(classic.AutomationElement.FocusedElement);
//				}
                return AutomationFactory.GetUiElement(classic.AutomationElement.FocusedElement);
                // return AutomationFactory.GetUiElement(classic.AutomationElement.FocusedElement, "focusedElement");
			}
		}

		public static IUiElement FromPoint(Point pt)
		{
//			switch (_innerElementType) {
//				case InnerElementTypes.AutomationElementNet:
//					return AutomationFactory.GetUiElement(classic.AutomationElement.FromPoint(pt));
//		        case InnerElementTypes.AutomationElementCom:
//		            return AutomationFactory.GetUiElement(viacom.AutomationElement.FromPoint(pt));    
//				case InnerElementTypes.UiElement:
//					return FromPoint(pt);
//				default:
//					return AutomationFactory.GetUiElement(classic.AutomationElement.FromPoint(pt));
//			}
            return AutomationFactory.GetUiElement(classic.AutomationElement.FromPoint(pt));
            // return AutomationFactory.GetUiElement(classic.AutomationElement.FromPoint(pt), "fromPoint");
		}

		public static IUiElement FromHandle(IntPtr controlHandle)
		{
//			switch (_innerElementType) {
//				case InnerElementTypes.AutomationElementNet:
//					return AutomationFactory.GetUiElement(classic.AutomationElement.FromHandle(controlHandle));
//		        case InnerElementTypes.AutomationElementCom:
//		            return AutomationFactory.GetUiElement(viacom.AutomationElement.FromHandle(controlHandle));
//				case InnerElementTypes.UiElement:
//					return FromHandle(controlHandle);
//				default:
//					return AutomationFactory.GetUiElement(classic.AutomationElement.FromHandle(controlHandle));
//			}
            return AutomationFactory.GetUiElement(classic.AutomationElement.FromHandle(controlHandle));
            // return AutomationFactory.GetUiElement(classic.AutomationElement.FromHandle(controlHandle), "fromHandle");
		}
        
		public virtual object GetSourceElement()
		{
		    if (null != _elementHolderNet) {
		        return _elementHolderNet;
		    } else if (null != _elementHolderAdapter) {
		        return _elementHolderAdapter;
            // 20140316
            } else if (null != _elementHolderCom) {
                return _elementHolderCom;
		    } else {
		        return null;
		    }
		}
        
		public virtual void SetSourceElement<T>(T element)
		{
            // 20140316
			// if (element is classic.AutomationElement) {
            // 20140318
            // if (null != element as classic.AutomationElement) {
            if (typeof(T) == typeof(classic.AutomationElement)) {
// Console.WriteLine("SetSourceElement: 001.1");
				_elementHolderNet = element as classic.AutomationElement;
// Console.WriteLine("SetSourceElement: 001.2");
				_innerElementType = InnerElementTypes.AutomationElementNet;
                
                // 20140316
                return;
			}
			// if com
            // 20140316
            if (null != element as viacom.AutomationElement) {
                
                _elementHolderCom = element as viacom.AutomationElement;
                _innerElementType = InnerElementTypes.AutomationElementCom;
                return;
            }
            
            // 20140316
			// if (element is IUiElement) {
            if (null != element as IUiElement) {
//Console.WriteLine("SetSourceElement: 002.1");
				_elementHolderAdapter = (IUiElement)element;
//Console.WriteLine("SetSourceElement: 002.2");
				_innerElementType = InnerElementTypes.UiElement;
                // 20140316
                return;
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
		    
//		    this.ChildKernel.Dispose();
		    
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
