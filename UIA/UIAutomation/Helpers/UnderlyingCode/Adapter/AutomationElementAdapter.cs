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
	
	// using TMX.Commands;

	/// <summary>
	/// Description of UiElement.
	/// </summary>
	public class UiElement : IUiElement //, IInitializable
	{
		private AutomationElement _elementHolderNet;
		// //private AutomationElement _elementHolderCom;
		private readonly IUiElement _elementHolderAdapter;
		// 20131206
		// private static InnerElementTypes _innerElementType = InnerElementTypes.Empty;
		private static InnerElementTypes _innerElementType = InnerElementTypes.AutomationElementNet;
        
		[Inject]
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
		
		[Inject]
		public UiElement(IUiElement element)
		{
			_elementHolderAdapter = element;
			_innerElementType = InnerElementTypes.UiElement;
		}
		
		[Inject]
		public UiElement()
		{
			_innerElementType = InnerElementTypes.Empty;
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

		public int[] GetRuntimeId()
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

		public object GetCurrentPropertyValue(AutomationProperty property)
		{
			switch (_innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return Preferences.FromCache ? _elementHolderNet.GetCachedPropertyValue(property) : _elementHolderNet.GetCurrentPropertyValue(property);
                    /*
                    if (Preferences.FromCache) {
                        return _elementHolderNet.GetCachedPropertyValue(property);
                    } else {
                        return _elementHolderNet.GetCurrentPropertyValue(property);
                    }
                    */
                //			    case InnerElementTypes.AutomationElementCom:
//			        //
			    case InnerElementTypes.UiElement:
			        return Preferences.FromCache ? _elementHolderAdapter.GetCachedPropertyValue(property) : _elementHolderAdapter.GetCurrentPropertyValue(property);
                    /*
                    if (Preferences.FromCache) {
                        return _elementHolderAdapter.GetCachedPropertyValue(property);
                    } else {
                        return _elementHolderAdapter.GetCurrentPropertyValue(property);
                    }
                    */
                default:
			        return Preferences.FromCache ? _elementHolderNet.GetCachedPropertyValue(property) : _elementHolderNet.GetCurrentPropertyValue(property);
                    /*
                    if (Preferences.FromCache) {
                        return _elementHolderNet.GetCachedPropertyValue(property);
                    } else {
                        return _elementHolderNet.GetCurrentPropertyValue(property);
                    }
                    */
            }
		}

		public object GetCurrentPropertyValue(AutomationProperty property, bool ignoreDefaultValue)
		{
			switch (_innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return Preferences.FromCache ? _elementHolderNet.GetCachedPropertyValue(property, ignoreDefaultValue) : _elementHolderNet.GetCurrentPropertyValue(property, ignoreDefaultValue);
                    /*
                    if (Preferences.FromCache) {
                        return _elementHolderNet.GetCachedPropertyValue(property, ignoreDefaultValue);
                    } else {
                        return _elementHolderNet.GetCurrentPropertyValue(property, ignoreDefaultValue);
                    }
                    */
                //			    case InnerElementTypes.AutomationElementCom:
//			        //
			    case InnerElementTypes.UiElement:
			        return Preferences.FromCache ? _elementHolderAdapter.GetCachedPropertyValue(property, ignoreDefaultValue) : _elementHolderAdapter.GetCurrentPropertyValue(property, ignoreDefaultValue);

                    /*
                    if (Preferences.FromCache) {
                        return _elementHolderAdapter.GetCachedPropertyValue(property, ignoreDefaultValue);
                    } else {
                        return _elementHolderAdapter.GetCurrentPropertyValue(property, ignoreDefaultValue);
                    }
                    */
                default:
			        return Preferences.FromCache ? _elementHolderNet.GetCachedPropertyValue(property, ignoreDefaultValue) : _elementHolderNet.GetCurrentPropertyValue(property, ignoreDefaultValue);
                    /*
                    if (Preferences.FromCache) {
                        return _elementHolderNet.GetCachedPropertyValue(property, ignoreDefaultValue);
                    } else {
                        return _elementHolderNet.GetCurrentPropertyValue(property, ignoreDefaultValue);
                    }
                    */
            }
		}

		public object GetCurrentPattern(AutomationPattern pattern)
		{
		    //int patternId = pattern.Id;
			switch (_innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        if (Preferences.FromCache) {
                        // 20131122
                        // ValuePattern -> IMySuperValuePattern
                        // 20131205
			            // if (pattern.Id != ValuePattern.Pattern.Id) return _elementHolderNet.GetCachedPattern(pattern);
//			            switch (pattern.ProgrammaticName) {
//			                case System.Windows.Automation.ValuePattern.Pattern.ProgrammaticName:
//        			            IMySuperValuePattern valuePattern =
//        			                AutomationFactory.GetMySuperValuePattern(
//        			                    this,
//        			                    _elementHolderNet.GetCachedPattern(pattern) as ValuePattern);//,
//        			            return valuePattern;
//			                    //break;
//			                case InvokePattern.Pattern.ProgrammaticName:
//			                    IMySuperInvokePattern invokePattern =
//			                        AutomationFactory.GetMySuperInvokePattern(
//			                            this,
//			                            _elementHolderNet.GetCachedPattern(pattern) as InvokePattern);
//			                    return invokePattern;
//			                default:
//			                    return _elementHolderNet.GetCachedPattern(pattern);
//			                	//break;
//			            }
                        if (pattern.Id == ExpandCollapsePattern.Pattern.Id) {
                            IMySuperExpandCollapsePattern expandCollapsePattern =
                                AutomationFactory.GetMySuperExpandCollapsePattern(
                                    this,
                                    _elementHolderNet.GetCachedPattern(pattern) as ExpandCollapsePattern);
                            return expandCollapsePattern;
                        } else if (pattern.Id == InvokePattern.Pattern.Id) {
			                IMySuperInvokePattern invokePattern =
		                        AutomationFactory.GetMySuperInvokePattern(
		                            this,
		                            _elementHolderNet.GetCachedPattern(pattern) as InvokePattern);
		                    return invokePattern;
                        } else if (pattern.Id == TogglePattern.Pattern.Id) {
                            IMySuperTogglePattern togglePattern =
                                AutomationFactory.GetMySuperTogglePattern(
                                    this,
                                    _elementHolderNet.GetCachedPattern(pattern) as TogglePattern);
                            return togglePattern;
                        } else if (pattern.Id == ValuePattern.Pattern.Id) {
			                IMySuperValuePattern valuePattern =
    			                AutomationFactory.GetMySuperValuePattern(
    			                    this,
    			                    _elementHolderNet.GetCachedPattern(pattern) as ValuePattern);//,
    			            return valuePattern;
			            } else {
			                return _elementHolderNet.GetCachedPattern(pattern);
			            }
			            // if (pattern.Id != ValuePattern.Pattern.Id && pattern.Id != InvokePattern.Pattern.Id) return _elementHolderNet.GetCachedPattern(pattern);
			            //switch (pattern.Id) {
			            //    case (ValuePattern.Pattern.Id):
			            //ValuePattern valuePattern =
//			            IMySuperValuePattern valuePattern =
//			                AutomationFactory.GetMySuperValuePattern(
//			                    this,
//			                    _elementHolderNet.GetCachedPattern(pattern) as ValuePattern);//,
//			            //Preferences.FromCache);
//			            return valuePattern;
			            //    default:
			            //        
			            //    	break;
			            /*
                        if (pattern.Id == ValuePattern.Pattern.Id) {
                        //switch (pattern.Id) {
                        //    case (ValuePattern.Pattern.Id):
                                //ValuePattern valuePattern =
                                IMySuperValuePattern valuePattern =
                                    ObjectsFactory.GetMySuperValuePattern(
                                        this,
                                        _elementHolderNet.GetCachedPattern(pattern) as ValuePattern);//,
                                        //Preferences.FromCache);
                                return valuePattern;
                        //    default:
                        //        
                        //    	break;
                        }
                        */
			        } else {
                        // 20131122
                        // ValuePattern -> IMySuperValuePattern
                        // 20131205
			            // if (pattern.Id != ValuePattern.Pattern.Id) return _elementHolderNet.GetCurrentPattern(pattern);
//			            switch (patternId) {
//			                case (int)ValuePattern.Pattern.Id:
//			                    IMySuperValuePattern valuePattern =
//			                        AutomationFactory.GetMySuperValuePattern(
//			                            this,
//			                            _elementHolderNet.GetCurrentPattern(pattern) as ValuePattern);
//			                    return valuePattern;
//			                case (int)InvokePattern.Pattern.Id:
//			                    IMySuperInvokePattern invokePattern =
//			                        AutomationFactory.GetMySuperInvokePattern(
//			                            this,
//			                            _elementHolderNet.GetCurrentPattern(pattern) as InvokePattern);
//			                    return invokePattern;
//			                default:
//			                    
//			                	break;
//			            }
			            if (pattern.Id == ExpandCollapsePattern.Pattern.Id) {
			                IMySuperExpandCollapsePattern expandCollapsePattern =
			                    AutomationFactory.GetMySuperExpandCollapsePattern(
			                        this,
			                        _elementHolderNet.GetCurrentPattern(pattern) as ExpandCollapsePattern);
			                return expandCollapsePattern;
			            } else if (pattern.Id == InvokePattern.Pattern.Id) {
			                IMySuperInvokePattern invokePattern =
		                        AutomationFactory.GetMySuperInvokePattern(
		                            this,
		                            _elementHolderNet.GetCurrentPattern(pattern) as InvokePattern);
		                    return invokePattern;
			            } else if (pattern.Id == TogglePattern.Pattern.Id) {
			                IMySuperTogglePattern togglePattern =
			                    AutomationFactory.GetMySuperTogglePattern(
			                        this,
			                        _elementHolderNet.GetCurrentPattern(pattern) as TogglePattern);
			                return togglePattern;
			            } else if (pattern.Id == ValuePattern.Pattern.Id) {
			                IMySuperValuePattern valuePattern =
		                        AutomationFactory.GetMySuperValuePattern(
		                            this,
		                            _elementHolderNet.GetCurrentPattern(pattern) as ValuePattern);
		                    return valuePattern;
			            }  else {
			                return this._elementHolderNet.GetCurrentPattern(pattern);
			            }
			            //switch (pattern.Id) {
			            //    case ValuePattern.Pattern.Id:
			            //ValuePattern valuePattern =
//			            IMySuperValuePattern valuePattern =
//			                AutomationFactory.GetMySuperValuePattern(
//			                    this,
//			                    _elementHolderNet.GetCurrentPattern(pattern) as ValuePattern);//,
//			            //Preferences.FromCache);
//			            return valuePattern;
			            //    default:
			            //        
			            //    	break;
			            /*
                        if (pattern.Id == ValuePattern.Pattern.Id) {
                        //switch (pattern.Id) {
                        //    case ValuePattern.Pattern.Id:
                                //ValuePattern valuePattern =
                                IMySuperValuePattern valuePattern =
                                    ObjectsFactory.GetMySuperValuePattern(
                                        this,
                                        _elementHolderNet.GetCurrentPattern(pattern) as ValuePattern);//,
                                        //Preferences.FromCache);
                                return valuePattern;
                        //    default:
                        //        
                        //    	break;
                        }
                        */
			        }
//			    case InnerElementTypes.AutomationElementCom:
//			        //
			    case InnerElementTypes.UiElement:
			        return Preferences.FromCache ? _elementHolderAdapter.GetCachedPattern(pattern) : _elementHolderAdapter.GetCurrentPattern(pattern);
                    /*
                    if (Preferences.FromCache) {
                        return _elementHolderAdapter.GetCachedPattern(pattern);
                    } else {
                        return _elementHolderAdapter.GetCurrentPattern(pattern);
                    }
                    */
                default:
			        return Preferences.FromCache ? _elementHolderNet.GetCachedPattern(pattern) : _elementHolderNet.GetCurrentPattern(pattern);
                    /*
                    if (Preferences.FromCache) {
                        return _elementHolderNet.GetCachedPattern(pattern);
                    } else {
                        return _elementHolderNet.GetCurrentPattern(pattern);
                    }
                    */
            }
		}

		public bool TryGetCurrentPattern(AutomationPattern pattern, out object patternObject)
		{
			switch (_innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return Preferences.FromCache ? _elementHolderNet.TryGetCachedPattern(pattern, out patternObject) : _elementHolderNet.TryGetCurrentPattern(pattern, out patternObject);
                    /*
                    if (Preferences.FromCache) {
                        return _elementHolderNet.TryGetCachedPattern(pattern, out patternObject);
                    } else {
                        return _elementHolderNet.TryGetCurrentPattern(pattern, out patternObject);
                    }
                    */
                //			    case InnerElementTypes.AutomationElementCom:
//			        //
			    case InnerElementTypes.UiElement:
			        return Preferences.FromCache ? _elementHolderAdapter.TryGetCachedPattern(pattern, out patternObject) : _elementHolderAdapter.TryGetCurrentPattern(pattern, out patternObject);
                    /*
                    if (Preferences.FromCache) {
                        return _elementHolderAdapter.TryGetCachedPattern(pattern, out patternObject);
                    } else {
                        return _elementHolderAdapter.TryGetCurrentPattern(pattern, out patternObject);
                    }
                    */
                default:
			        return Preferences.FromCache ? _elementHolderNet.TryGetCachedPattern(pattern, out patternObject) : _elementHolderNet.TryGetCurrentPattern(pattern, out patternObject);
                    /*
                    if (Preferences.FromCache) {
                        return _elementHolderNet.TryGetCachedPattern(pattern, out patternObject);
                    } else {
                        return _elementHolderNet.TryGetCurrentPattern(pattern, out patternObject);
                    }
                    */
            }
		}

		public object GetCachedPropertyValue(AutomationProperty property)
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

		public object GetCachedPropertyValue(AutomationProperty property, bool ignoreDefaultValue)
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

		public object GetCachedPattern(AutomationPattern pattern)
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

		public bool TryGetCachedPattern(AutomationPattern pattern, out object patternObject)
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

		public AutomationElement GetUpdatedCache(CacheRequest request)
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
        
		// 20131205
		// UIANET
		// public IUiElement FindFirst(TreeScope scope, Condition condition)
		public IUiElement FindFirst(TreeScope scope, UIANET::System.Windows.Automation.Condition condition)
		// public IUiElement FindFirst(TreeScope scope, UIANET::Condition condition)
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
        
		// 20131205
		// UIANET
		// public IUiEltCollection FindAll(TreeScope scope, Condition condition)
		public IUiEltCollection FindAll(TreeScope scope, UIANET::System.Windows.Automation.Condition condition)
		{
			switch (_innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return AutomationFactory.GetUiEltCollection(_elementHolderNet.FindAll(scope, condition));
//			    case InnerElementTypes.AutomationElementCom:
//			        //
			    case InnerElementTypes.UiElement:
			        return _elementHolderAdapter.FindAll(scope, condition);
			    default:
			        return AutomationFactory.GetUiEltCollection(_elementHolderNet.FindAll(scope, condition));
			}
		}

		public AutomationProperty[] GetSupportedProperties()
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

		public AutomationPattern[] GetSupportedPatterns()
		{
			switch (_innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return _elementHolderNet.GetSupportedPatterns();
//			    case InnerElementTypes.AutomationElementCom:
//			        //
			    case InnerElementTypes.UiElement:
			        return _elementHolderAdapter.GetSupportedPatterns();
			    default:
			        return _elementHolderNet.GetSupportedPatterns();
			}
		}

		public void SetFocus()
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

		public bool TryGetClickablePoint(out Point pt)
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

		public Point GetClickablePoint()
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

		public IUiElementInformation Cached {
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

		public IUiElementInformation Current {
		    get {
		        switch (_innerElementType) {
		            case InnerElementTypes.AutomationElementNet:
		                return AutomationFactory.GetUiElementInformation(Preferences.FromCache ? _elementHolderNet.Cached : _elementHolderNet.Current);
		                /*
                        if (Preferences.FromCache) {
                            return ObjectsFactory.GetUiElementInformation(_elementHolderNet.Cached);
                        } else {
                            return ObjectsFactory.GetUiElementInformation(_elementHolderNet.Current);
                        }
                        */
                    //		            case InnerElementTypes.AutomationElementCom:
//		                //
		            case InnerElementTypes.UiElement:
		                return Preferences.FromCache ? _elementHolderAdapter.Cached : _elementHolderAdapter.Current;
                        /*
                        if (Preferences.FromCache) {
                            return _elementHolderAdapter.Cached;
                        } else {
                            return _elementHolderAdapter.Current;
                        }
                        */
                    default:
		                return AutomationFactory.GetUiElementInformation(Preferences.FromCache ? _elementHolderNet.Cached : _elementHolderNet.Current);
		                /*
                        if (Preferences.FromCache) {
                            return ObjectsFactory.GetUiElementInformation(_elementHolderNet.Cached);
                        } else {
                            return ObjectsFactory.GetUiElementInformation(_elementHolderNet.Current);
                        }
                        */
                }
		    }
		}

		public IUiElement CachedParent {
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

		public IUiEltCollection CachedChildren {
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
		
		public AutomationElement GetSourceElement()
		{
		    return _elementHolderNet;
		}
		public void SetSourceElement(AutomationElement element)
		{
		    _elementHolderNet = element;
		}
		
//		public AutomationElement GetSourceElement()
//		{
//		    return this.elementHolderNet;
//		}
//		public void SetSourceElement(AutomationElement element)
//		{
//		    this.elementHolderNet = element;
//		}
		
//		public IUiElement GetSourceElement()
//		{
//		    return this.elementHolderAdapter;
//		}
//		public void SetSourceElement(IUiElement element)
//		{
//		    this.elementHolderAdapter = element;
//		}
		
		public string Tag { get; set; }
		
		public void Dispose()
		{
//		    if (InnerElementTypes.AutomationElementNet == innerElementType) { // &&
//		        //null != this.elementHolderNet) {
//		        this.elementHolderNet = null;
//		    }
//		    // this.elementHolderCom = null;
//		    if (InnerElementTypes.UiElement == innerElementType) { //&&
//		        //null != this.elementHolderAdapter) {
//		        this.elementHolderAdapter = null;
//		    }
//		    this.Cached = null;
//		    this.CachedChildren = null;
//		    this.CachedParent = null;
//		    this.Current = null;
		    
		    // 20131120
		    GC.SuppressFinalize(this);
		}
		
		// internal methods
        public object GetPatternPropertyValue(AutomationProperty property, bool useCache)
        {
        	if (useCache)
        	{
        		//return this.GetCachedPropertyValue(property);
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
        	//return this.GetCurrentPropertyValue(property);
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
        
//        public static UiElement GetParent()
//        {
//            return GetParent();
//        }
//        
//        public static IUiElement GetFirstChild()
//        {
//            return GetFirstChild();
//        }
//        
//        public static IUiElement GetLastChild()
//        {
//            return GetLastChild();
//        }
//        
//        public static UiElement GetNextSibling()
//        {
//            return GetNextSibling();
//        }
//        
//        public static IUiElement GetPreviousSibling()
//        {
//            return GetPreviousSibling();
//        }

        #region NavigateTo
        public IUiElement NavigateToParent()
        {
            IUiElement result = null;
            
            TreeWalker walker =
                new TreeWalker(
                    System.Windows.Automation.Condition.TrueCondition);
            
            try {
                result = AutomationFactory.GetUiElement(walker.GetParent(this.GetSourceElement()));
            }
            catch {}
            
            return result;
        }
        
        public IUiElement NavigateToFirstChild()
        {
            IUiElement result = null;
            
            TreeWalker walker =
                new TreeWalker(
                    System.Windows.Automation.Condition.TrueCondition);
            
            try {
                result = AutomationFactory.GetUiElement(walker.GetFirstChild(this.GetSourceElement()));
            }
            catch {}
            
            return result;
        }
        
        public IUiElement NavigateToLastChild()
        {
            IUiElement result = null;
            
            TreeWalker walker =
                new TreeWalker(
                    System.Windows.Automation.Condition.TrueCondition);
            
            try {
                result = AutomationFactory.GetUiElement(walker.GetLastChild(this.GetSourceElement()));
            }
            catch {}
            
            return result;
        }
        
        public IUiElement NavigateToNextSibling()
        {
            IUiElement result = null;
            
            TreeWalker walker =
                new TreeWalker(
                    System.Windows.Automation.Condition.TrueCondition);
            
            try {
                result = AutomationFactory.GetUiElement(walker.GetNextSibling(this.GetSourceElement()));
            }
            catch {}
            
            return result;
        }
        
        public IUiElement NavigateToPreviousSibling()
        {
            IUiElement result = null;
            
            TreeWalker walker =
                new TreeWalker(
                    System.Windows.Automation.Condition.TrueCondition);
            
            try {
                result = AutomationFactory.GetUiElement(walker.GetPreviousSibling(this.GetSourceElement()));
            }
            catch {}
            
            return result;
        }
        #endregion NavigateTo
        
        #region Patterns
        public IUiElement Click()
        {
            // IMySuperInvokePattern invokePattern =
            //    this.GetInvokePattern().Invoke();
            
//            try {
//                invokePattern.Invoke();
//            }
//            catch {}
            this.GetInvokePattern().Invoke();
            return this;
        }
        
        public IUiElement DoubleClick()
        {
            HasControlInputCmdletBase cmdlet =
                new HasControlInputCmdletBase();
            cmdlet.ClickControl(
                cmdlet,
                this,
                false,
                false,
                false,
                false,
                false,
                false,
                true,
                50,
                Preferences.ClickOnControlByCoordX,
                Preferences.ClickOnControlByCoordY);
            
            return this;
        }
        
        public IUiElement Select()
        {
            this.GetSelectionItemPattern().Select();
            return this;
        }
        
        public IUiElement AddToSelection()
        {
            this.GetSelectionItemPattern().AddToSelection();
            return this;
        }
        
        public IUiElement RemoveFromSelection()
        {
            this.GetSelectionItemPattern().RemoveFromSelection();
            return this;
        }
        
        public bool IsSelected
        {
            get { return this.GetSelectionItemPattern().Current.IsSelected; }
        }
        
        public IUiElement SelectionContainer
        {
            get { return this.GetSelectionItemPattern().Current.SelectionContainer; }
        }
        
        public IUiElement[] GetSelection()
        {
            return this.GetSelectionPattern().Current.GetSelection();
        }
        
        public bool CanSelectMultiple
        {
            get { return this.GetSelectionPattern().Current.CanSelectMultiple; }
        }
        
        public bool IsSelectionRequired
        {
            get { return this.GetSelectionPattern().Current.IsSelectionRequired; }
        }
        
        public IUiElement Toggle()
        {
            // IMySuperTogglePattern togglePattern =
            //     this.GetTogglePattern().Toggle();
            
//            try {
//                togglePattern.Toggle();
//            }
//            catch {}
            this.GetTogglePattern().Toggle();
            return this;
        }
        
//        public bool? ToggleState
//        {
//            get {
//                using (ToggleState t = ToggleState) {
//                    
//                } 
//                switch (this.GetTogglePattern().Current.ToggleState) {
//                     case ToggleState.Off:
//                         return false;
//                     case ToggleState.On:
//                         return true;
//                     case ToggleState.Indeterminate:
//                         return null;
////                     default:
////                         throw new Exception("Invalid value for ToggleState");
//                 }
//            }
//            set { 
//                switch (value) {
//                    case true:
//                        this.GetTogglePattern().Current.ToggleState = ToggleState.On;
//                        break;
//                    case false:
//                        this.GetTogglePattern().Current.ToggleState = ToggleState.Off;
//                    case null:
//                        this.GetTogglePattern().Current.ToggleState = ToggleState.Indeterminate;
////                    default:
////                        
////                    	break;
//                }
//            }
//        }
        
        public string Value
        {
            get { return this.GetValuePattern().Current.Value; }
            set { this.GetValuePattern().SetValue(value); }
        }
        
        
        #endregion Patterns
        
        #region Highlighter
        public IUiElement Highlight()
        {
            UiaHelper.Highlight(this);
            return this;
        }
        #endregion Highlighter
	}
}
