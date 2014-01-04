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
	extern alias UIANET;
	using System;
	// using UIANET::System.Windows.Automation;
	using System.Windows.Automation;
	using Ninject;
	using System.Windows;
	using System.Linq;

	// using TMX.Commands;

	/// <summary>
	/// Description of UiElement.
	/// </summary>
	public class UiElement : IUiElement
	{
		private AutomationElement _elementHolderNet;
		// //private AutomationElement _elementHolderCom;
		// private readonly IUiElement _elementHolderAdapter;
		private IUiElement _elementHolderAdapter;
		private static InnerElementTypes _innerElementType = InnerElementTypes.AutomationElementNet;
		// internal static InnerElementTypes InnerElementType
//		internal static InnerElementTypes InnerElementType
//		{
//		    get { return _innerElementType; }
//		    set { _innerElementType = value; }
//		}

		[Inject()]
		public UiElement(AutomationElement element)
		{
			_elementHolderNet = element;
			_innerElementType = InnerElementTypes.AutomationElementNet;
		}

		//[Inject]
		//public UiElement(::AutomationElement element)
		//{
		//	this._elementHolderCom = element;
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
			_elementHolderNet = AutomationElement.RootElement;
			//
			_innerElementType = InnerElementTypes.Empty;
			// _innerElementType = InnerElementTypes.AutomationElementNet;
		}

		public override bool Equals(object obj)
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return _elementHolderNet.Equals(obj);
//			    case InnerElementTypes.AutomationElementCom:
//			        //
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
//			    case InnerElementTypes.AutomationElementCom:
//			        //
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
//			    case InnerElementTypes.AutomationElementCom:
//			        //
				case InnerElementTypes.UiElement:
					return _elementHolderAdapter.GetRuntimeId();
				default:
					return _elementHolderNet.GetRuntimeId();
			}
		}

		public virtual object GetCurrentPropertyValue(AutomationProperty property)
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return Preferences.FromCache ? _elementHolderNet.GetCachedPropertyValue(property) : _elementHolderNet.GetCurrentPropertyValue(property);
				//			    case InnerElementTypes.AutomationElementCom:
//			        //
				case InnerElementTypes.UiElement:
					return Preferences.FromCache ? _elementHolderAdapter.GetCachedPropertyValue(property) : _elementHolderAdapter.GetCurrentPropertyValue(property);
				default:
					return Preferences.FromCache ? _elementHolderNet.GetCachedPropertyValue(property) : _elementHolderNet.GetCurrentPropertyValue(property);
			}
		}

		public virtual object GetCurrentPropertyValue(AutomationProperty property, bool ignoreDefaultValue)
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return Preferences.FromCache ? _elementHolderNet.GetCachedPropertyValue(property, ignoreDefaultValue) : _elementHolderNet.GetCurrentPropertyValue(property, ignoreDefaultValue);
				//			    case InnerElementTypes.AutomationElementCom:
//			        //
				case InnerElementTypes.UiElement:
					return Preferences.FromCache ? _elementHolderAdapter.GetCachedPropertyValue(property, ignoreDefaultValue) : _elementHolderAdapter.GetCurrentPropertyValue(property, ignoreDefaultValue);
				default:
					return Preferences.FromCache ? _elementHolderNet.GetCachedPropertyValue(property, ignoreDefaultValue) : _elementHolderNet.GetCurrentPropertyValue(property, ignoreDefaultValue);
			}
		}

		public virtual TPatternInterface GetCurrentPattern<TPatternInterface>(AutomationPattern pattern) where TPatternInterface : IBasePattern
		{

			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					if (Preferences.FromCache) {
						return (TPatternInterface)AutomationFactory.GetPatternAdapter<TPatternInterface>(this, _elementHolderNet.GetCachedPattern(pattern));
					} else {
						return (TPatternInterface)AutomationFactory.GetPatternAdapter<TPatternInterface>(this, _elementHolderNet.GetCurrentPattern(pattern));
					}
				// default:
//			    case InnerElementTypes.AutomationElementCom:
//			        //
					// 20131208
                case InnerElementTypes.UiElement:
                    // return Preferences.FromCache ? _elementHolderAdapter.GetCachedPattern(pattern) : _elementHolderAdapter.GetCurrentPattern(pattern);
                    return Preferences.FromCache ? default(TPatternInterface) : _elementHolderAdapter.GetCurrentPattern<TPatternInterface>(pattern);
					// default:
					///    return Preferences.FromCache ? _elementHolderNet.GetCachedPattern(pattern) : _elementHolderNet.GetCurrentPattern(pattern);
                default:
					if (Preferences.FromCache) {
						return (TPatternInterface)AutomationFactory.GetPatternAdapter<TPatternInterface>(this, _elementHolderNet.GetCachedPattern(pattern));
					} else {
						return (TPatternInterface)AutomationFactory.GetPatternAdapter<TPatternInterface>(this, _elementHolderNet.GetCurrentPattern(pattern));
					}
			}

			// return default(N);
		}

		public virtual object GetCurrentPattern(AutomationPattern pattern)
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return _elementHolderNet.GetCurrentPattern(pattern);
				default:
//			    case InnerElementTypes.AutomationElementCom:
//			        //
					// case InnerElementTypes.UiElement:
					//     return _elementHolderAdapter.GetCurrentPattern(pattern);
					return _elementHolderNet.GetCurrentPattern(pattern);
			}
		}

		public virtual bool TryGetCurrentPattern(AutomationPattern pattern, out object patternObject)
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return Preferences.FromCache ? _elementHolderNet.TryGetCachedPattern(pattern, out patternObject) : _elementHolderNet.TryGetCurrentPattern(pattern, out patternObject);
				//			    case InnerElementTypes.AutomationElementCom:
//			        //
				case InnerElementTypes.UiElement:
					return Preferences.FromCache ? _elementHolderAdapter.TryGetCachedPattern(pattern, out patternObject) : _elementHolderAdapter.TryGetCurrentPattern(pattern, out patternObject);
				default:
					return Preferences.FromCache ? _elementHolderNet.TryGetCachedPattern(pattern, out patternObject) : _elementHolderNet.TryGetCurrentPattern(pattern, out patternObject);
			}
		}

		public virtual object GetCachedPropertyValue(AutomationProperty property)
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return _elementHolderNet.GetCachedPropertyValue(property);
//			    case InnerElementTypes.AutomationElementCom:
//			        //
				case InnerElementTypes.UiElement:
					return _elementHolderAdapter.GetCachedPropertyValue(property);
				default:
					return _elementHolderNet.GetCachedPropertyValue(property);
			}
		}

		public virtual object GetCachedPropertyValue(AutomationProperty property, bool ignoreDefaultValue)
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return _elementHolderNet.GetCachedPropertyValue(property, ignoreDefaultValue);
//			    case InnerElementTypes.AutomationElementCom:
//			        //
				case InnerElementTypes.UiElement:
					return _elementHolderAdapter.GetCachedPropertyValue(property, ignoreDefaultValue);
				default:
					return _elementHolderNet.GetCachedPropertyValue(property, ignoreDefaultValue);
			}
		}

		public virtual object GetCachedPattern(AutomationPattern pattern)
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return _elementHolderNet.GetCachedPattern(pattern);
//			    case InnerElementTypes.AutomationElementCom:
//			        //
				case InnerElementTypes.UiElement:
					return _elementHolderAdapter.GetCachedPattern(pattern);
				default:
					return _elementHolderNet.GetCachedPattern(pattern);
			}
		}

		public virtual bool TryGetCachedPattern(AutomationPattern pattern, out object patternObject)
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return _elementHolderNet.TryGetCachedPattern(pattern, out patternObject);
//			    case InnerElementTypes.AutomationElementCom:
//			        //
				case InnerElementTypes.UiElement:
					return _elementHolderAdapter.TryGetCachedPattern(pattern, out patternObject);
				default:
					return _elementHolderNet.TryGetCachedPattern(pattern, out patternObject);
			}
		}

		public virtual AutomationElement GetUpdatedCache(CacheRequest request)
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return _elementHolderNet.GetUpdatedCache(request);
//			    case InnerElementTypes.AutomationElementCom:
//			        //
				case InnerElementTypes.UiElement:
					return _elementHolderAdapter.GetUpdatedCache(request);
				default:
					return _elementHolderNet.GetUpdatedCache(request);
			}
		}

		public virtual IUiElement FindFirst(TreeScope scope, UIANET.System.Windows.Automation.Condition condition)
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return AutomationFactory.GetUiElement(_elementHolderNet.FindFirst(scope, condition));
//			    case InnerElementTypes.AutomationElementCom:
//			        //
				case InnerElementTypes.UiElement:
					return _elementHolderAdapter.FindFirst(scope, condition);
				default:
					return AutomationFactory.GetUiElement(_elementHolderNet.FindFirst(scope, condition));
			}
		}

		public virtual IUiEltCollection FindAll(TreeScope scope, UIANET.System.Windows.Automation.Condition condition)
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return AutomationFactory.GetUiEltCollection(_elementHolderNet.FindAll(scope, condition));
//			    case InnerElementTypes.AutomationElementCom:
//			        //
				case InnerElementTypes.UiElement:
					return _elementHolderAdapter.FindAll(scope, condition);
				default:
//			    case InnerElementTypes.Empty:
//			        return AutomationFactory.GetUiEltCollection(_elementHolderNet.FindAll(scope, condition));
					return AutomationFactory.GetUiEltCollection(_elementHolderNet.FindAll(scope, condition));
			}
		}

		public virtual AutomationProperty[] GetSupportedProperties()
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return _elementHolderNet.GetSupportedProperties();
//			    case InnerElementTypes.AutomationElementCom:
//			        //
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
//			    case InnerElementTypes.AutomationElementCom:
//			        //
				case InnerElementTypes.UiElement:
					return _elementHolderAdapter.GetSupportedPatterns();
				default:
					return _elementHolderNet.GetSupportedPatterns().ConvertAutomationPatternToBasePattern(this);
			}
		}

		public virtual void SetFocus()
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					_elementHolderNet.SetFocus();
					break;
//			    case InnerElementTypes.AutomationElementCom:
//			        //
				case InnerElementTypes.UiElement:
					_elementHolderAdapter.SetFocus();
					break;
				default:
					_elementHolderNet.SetFocus();
					break;
			}
		}

		public virtual bool TryGetClickablePoint(out Point pt)
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return _elementHolderNet.TryGetClickablePoint(out pt);
//			    case InnerElementTypes.AutomationElementCom:
//			        //
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
//			    case InnerElementTypes.AutomationElementCom:
//			        //
				case InnerElementTypes.UiElement:
					return _elementHolderAdapter.GetClickablePoint();
				default:
					return _elementHolderNet.GetClickablePoint();
			}
		}

		public virtual IUiElementInformation Cached {
			get {
				switch (_innerElementType) {
					case InnerElementTypes.AutomationElementNet:
						return AutomationFactory.GetUiElementInformation(_elementHolderNet.Cached);
//			        case /InnerElementTypes.AutomationElementCom:
//			            //
					case InnerElementTypes.UiElement:
						return _elementHolderAdapter.Cached;
					default:
						return AutomationFactory.GetUiElementInformation(_elementHolderNet.Cached);
				}
			}
		}

		public virtual IUiElementInformation Current {
			get {
				switch (_innerElementType) {
					case InnerElementTypes.AutomationElementNet:
		                
		                
//System.Windows.Forms.MessageBox.Show("current:\r\n" + _elementHolderNet.Current.Name + "\r\n" + _elementHolderNet.Current.AutomationId + "\r\n" + _elementHolderNet.Current.ClassName + "\r\n" + _elementHolderNet.Current.ProcessId.ToString());
		                
						return AutomationFactory.GetUiElementInformation(Preferences.FromCache ? _elementHolderNet.Cached : _elementHolderNet.Current);
//		            case InnerElementTypes.AutomationElementCom:
//		                //
					case InnerElementTypes.UiElement:
						return Preferences.FromCache ? _elementHolderAdapter.Cached : _elementHolderAdapter.Current;
					default:
						return AutomationFactory.GetUiElementInformation(Preferences.FromCache ? _elementHolderNet.Cached : _elementHolderNet.Current);
				}
			}
		}

		public virtual IUiElement CachedParent {
			get {
				switch (_innerElementType) {
					case InnerElementTypes.AutomationElementNet:
						return AutomationFactory.GetUiElement(_elementHolderNet.CachedParent);
//			        case InnerElementTypes.AutomationElementCom:
//			            //
					case InnerElementTypes.UiElement:
						return _elementHolderAdapter.CachedParent;
					default:
						return AutomationFactory.GetUiElement(_elementHolderNet.CachedParent);
				}
			}
		}

		public virtual IUiEltCollection CachedChildren {
			get {
				switch (_innerElementType) {
					case InnerElementTypes.AutomationElementNet:
						return AutomationFactory.GetUiEltCollection(_elementHolderNet.CachedChildren);
//			        case /InnerElementTypes.AutomationElementCom:
//			            //
					case InnerElementTypes.UiElement:
						return _elementHolderAdapter.CachedChildren;
					default:
						return AutomationFactory.GetUiEltCollection(_elementHolderNet.CachedChildren);
				}
			}
		}

		// static methods and properties
		public static readonly object NotSupported = AutomationElementIdentifiers.NotSupported;
		public static readonly AutomationProperty IsControlElementProperty = AutomationElementIdentifiers.IsControlElementProperty;
		public static readonly AutomationProperty ControlTypeProperty = AutomationElementIdentifiers.ControlTypeProperty;
		public static readonly AutomationProperty IsContentElementProperty = AutomationElementIdentifiers.IsContentElementProperty;
		public static readonly AutomationProperty LabeledByProperty = AutomationElementIdentifiers.LabeledByProperty;
		public static readonly AutomationProperty NativeWindowHandleProperty = AutomationElementIdentifiers.NativeWindowHandleProperty;
		public static readonly AutomationProperty AutomationIdProperty = AutomationElementIdentifiers.AutomationIdProperty;
		public static readonly AutomationProperty ItemTypeProperty = AutomationElementIdentifiers.ItemTypeProperty;
		public static readonly AutomationProperty IsPasswordProperty = AutomationElementIdentifiers.IsPasswordProperty;
		public static readonly AutomationProperty LocalizedControlTypeProperty = AutomationElementIdentifiers.LocalizedControlTypeProperty;
		public static readonly AutomationProperty NameProperty = AutomationElementIdentifiers.NameProperty;
		public static readonly AutomationProperty AcceleratorKeyProperty = AutomationElementIdentifiers.AcceleratorKeyProperty;
		public static readonly AutomationProperty AccessKeyProperty = AutomationElementIdentifiers.AccessKeyProperty;
		public static readonly AutomationProperty HasKeyboardFocusProperty = AutomationElementIdentifiers.HasKeyboardFocusProperty;
		public static readonly AutomationProperty IsKeyboardFocusableProperty = AutomationElementIdentifiers.IsKeyboardFocusableProperty;
		public static readonly AutomationProperty IsEnabledProperty = AutomationElementIdentifiers.IsEnabledProperty;
		public static readonly AutomationProperty BoundingRectangleProperty = AutomationElementIdentifiers.BoundingRectangleProperty;
		public static readonly AutomationProperty ProcessIdProperty = AutomationElementIdentifiers.ProcessIdProperty;
		public static readonly AutomationProperty RuntimeIdProperty = AutomationElementIdentifiers.RuntimeIdProperty;
		public static readonly AutomationProperty ClassNameProperty = AutomationElementIdentifiers.ClassNameProperty;
		public static readonly AutomationProperty HelpTextProperty = AutomationElementIdentifiers.HelpTextProperty;
		public static readonly AutomationProperty ClickablePointProperty = AutomationElementIdentifiers.ClickablePointProperty;
		public static readonly AutomationProperty CultureProperty = AutomationElementIdentifiers.CultureProperty;
		public static readonly AutomationProperty IsOffscreenProperty = AutomationElementIdentifiers.IsOffscreenProperty;
		public static readonly AutomationProperty OrientationProperty = AutomationElementIdentifiers.OrientationProperty;
		public static readonly AutomationProperty FrameworkIdProperty = AutomationElementIdentifiers.FrameworkIdProperty;
		public static readonly AutomationProperty IsRequiredForFormProperty = AutomationElementIdentifiers.IsRequiredForFormProperty;
		public static readonly AutomationProperty ItemStatusProperty = AutomationElementIdentifiers.ItemStatusProperty;
		public static readonly AutomationProperty IsDockPatternAvailableProperty = AutomationElementIdentifiers.IsDockPatternAvailableProperty;
		public static readonly AutomationProperty IsExpandCollapsePatternAvailableProperty = AutomationElementIdentifiers.IsExpandCollapsePatternAvailableProperty;
		public static readonly AutomationProperty IsGridItemPatternAvailableProperty = AutomationElementIdentifiers.IsGridItemPatternAvailableProperty;
		public static readonly AutomationProperty IsGridPatternAvailableProperty = AutomationElementIdentifiers.IsGridPatternAvailableProperty;
		public static readonly AutomationProperty IsInvokePatternAvailableProperty = AutomationElementIdentifiers.IsInvokePatternAvailableProperty;
		public static readonly AutomationProperty IsMultipleViewPatternAvailableProperty = AutomationElementIdentifiers.IsMultipleViewPatternAvailableProperty;
		public static readonly AutomationProperty IsRangeValuePatternAvailableProperty = AutomationElementIdentifiers.IsRangeValuePatternAvailableProperty;
		public static readonly AutomationProperty IsSelectionItemPatternAvailableProperty = AutomationElementIdentifiers.IsSelectionItemPatternAvailableProperty;
		public static readonly AutomationProperty IsSelectionPatternAvailableProperty = AutomationElementIdentifiers.IsSelectionPatternAvailableProperty;
		public static readonly AutomationProperty IsScrollPatternAvailableProperty = AutomationElementIdentifiers.IsScrollPatternAvailableProperty;
		public static readonly AutomationProperty IsScrollItemPatternAvailableProperty = AutomationElementIdentifiers.IsScrollItemPatternAvailableProperty;
		public static readonly AutomationProperty IsTablePatternAvailableProperty = AutomationElementIdentifiers.IsTablePatternAvailableProperty;
		public static readonly AutomationProperty IsTableItemPatternAvailableProperty = AutomationElementIdentifiers.IsTableItemPatternAvailableProperty;
		public static readonly AutomationProperty IsTextPatternAvailableProperty = AutomationElementIdentifiers.IsTextPatternAvailableProperty;
		public static readonly AutomationProperty IsTogglePatternAvailableProperty = AutomationElementIdentifiers.IsTogglePatternAvailableProperty;
		public static readonly AutomationProperty IsTransformPatternAvailableProperty = AutomationElementIdentifiers.IsTransformPatternAvailableProperty;
		public static readonly AutomationProperty IsValuePatternAvailableProperty = AutomationElementIdentifiers.IsValuePatternAvailableProperty;
		public static readonly AutomationProperty IsWindowPatternAvailableProperty = AutomationElementIdentifiers.IsWindowPatternAvailableProperty;
		public static readonly AutomationEvent ToolTipOpenedEvent = AutomationElementIdentifiers.ToolTipOpenedEvent;
		public static readonly AutomationEvent ToolTipClosedEvent = AutomationElementIdentifiers.ToolTipClosedEvent;
		public static readonly AutomationEvent StructureChangedEvent = AutomationElementIdentifiers.StructureChangedEvent;
		public static readonly AutomationEvent MenuOpenedEvent = AutomationElementIdentifiers.MenuOpenedEvent;
		public static readonly AutomationEvent AutomationPropertyChangedEvent = AutomationElementIdentifiers.AutomationPropertyChangedEvent;
		public static readonly AutomationEvent AutomationFocusChangedEvent = AutomationElementIdentifiers.AutomationFocusChangedEvent;
		public static readonly AutomationEvent AsyncContentLoadedEvent = AutomationElementIdentifiers.AsyncContentLoadedEvent;
		public static readonly AutomationEvent MenuClosedEvent = AutomationElementIdentifiers.MenuClosedEvent;
		public static readonly AutomationEvent LayoutInvalidatedEvent = AutomationElementIdentifiers.LayoutInvalidatedEvent;

		public static IUiElement RootElement {
			get {
				switch (_innerElementType) {
					case InnerElementTypes.AutomationElementNet:
						return AutomationFactory.GetUiElement(AutomationElement.RootElement);
//			        case InnerElementTypes.AutomationElementCom:
//			            //
					case InnerElementTypes.UiElement:
						return RootElement;
					default:
						return AutomationFactory.GetUiElement(AutomationElement.RootElement);
				}
			}
		}

		public static IUiElement FocusedElement {
			get {
				switch (_innerElementType) {
					case InnerElementTypes.AutomationElementNet:
						return AutomationFactory.GetUiElement(AutomationElement.FocusedElement);
//		            case InnerElementTypes.AutomationElementCom:
//		                //
					case InnerElementTypes.UiElement:
						return FocusedElement;
					default:
						return AutomationFactory.GetUiElement(AutomationElement.FocusedElement);
				}
			}
		}

		public static IUiElement FromPoint(Point pt)
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return AutomationFactory.GetUiElement(AutomationElement.FromPoint(pt));
//		        case InnerElementTypes.AutomationElementCom:
//		            //
				case InnerElementTypes.UiElement:
					return FromPoint(pt);
				default:
					return AutomationFactory.GetUiElement(AutomationElement.FromPoint(pt));
			}
		}

		public static IUiElement FromHandle(IntPtr controlHandle)
		{
			switch (_innerElementType) {
				case InnerElementTypes.AutomationElementNet:
					return AutomationFactory.GetUiElement(AutomationElement.FromHandle(controlHandle));
//		        case InnerElementTypes.AutomationElementCom:
//		            //
				case InnerElementTypes.UiElement:
					return FromHandle(controlHandle);
				default:
					return AutomationFactory.GetUiElement(AutomationElement.FromHandle(controlHandle));
			}
		}

//		public virtual AutomationElement GetSourceElement()
//		{
//			return _elementHolderNet;
//		}
		
//		public virtual T GetSourceElement<T>()
//		{
//		    if (T is AutomationElement) {
//		        return _elementHolderNet;
//		    }
//		    if (T is IUiElement) {
//		        return _elementHolderAdapter;
//		    }
//		}
		
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
			if (element is AutomationElement) {
				_elementHolderNet = element as AutomationElement;
				_innerElementType = InnerElementTypes.AutomationElementNet;
			}
			// if com
			if (element is IUiElement) {
				_elementHolderAdapter = (IUiElement)element;
				_innerElementType = InnerElementTypes.UiElement;
			}
		}

		public virtual string Tag { get; set; }

		public virtual void Dispose()
		{
			GC.SuppressFinalize(this);
		}

		// internal methods
		public virtual object GetPatternPropertyValue(AutomationProperty property, bool useCache)
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
