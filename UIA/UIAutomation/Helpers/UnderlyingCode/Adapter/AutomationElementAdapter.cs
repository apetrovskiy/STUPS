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
	using System;
	using System.Windows.Automation;
	using Ninject;

	/// <summary>
	/// Description of MySuperWrapper.
	/// </summary>
	public class MySuperWrapper : IMySuperWrapper
	{
		private AutomationElement elementHolderNet;
		// //private AutomationElement elementHolderCom;
		private IMySuperWrapper elementHolderAdapter;
		private static InnerElementTypes innerElementType = InnerElementTypes.Empty;
        
		[Inject]
		public MySuperWrapper(AutomationElement element)
		{
			this.elementHolderNet = element;
			innerElementType = InnerElementTypes.AutomationElementNet;
		}
		
		//[Inject]
		//public MySuperWrapper(::AutomationElement element)
		//{
		//	this.elementHolderCom = element;
		//}
		
		[Inject]
		public MySuperWrapper(IMySuperWrapper element)
		{
			this.elementHolderAdapter = element;
			innerElementType = InnerElementTypes.MySuperWrapper;
		}
		
		[Inject]
		public MySuperWrapper()
		{
			innerElementType = InnerElementTypes.Empty;
		}

		public override bool Equals(object obj)
		{
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return this.elementHolderNet.Equals(obj);
//			    case InnerElementTypes.AutomationElementCom:
//			        //
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.Equals(obj);
			    default:
			        return this.elementHolderNet.Equals(obj);
			}
		}

		public override int GetHashCode()
		{
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return this.elementHolderNet.GetHashCode();
//			    case InnerElementTypes.AutomationElementCom:
//			        //
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.GetHashCode();
			    default:
			        return this.elementHolderNet.GetHashCode();
			}
		}

		public int[] GetRuntimeId()
		{
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return this.elementHolderNet.GetRuntimeId();
//			    case InnerElementTypes.AutomationElementCom:
//			        //
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.GetRuntimeId();
			    default:
			        return this.elementHolderNet.GetRuntimeId();
			}
		}

		public object GetCurrentPropertyValue(AutomationProperty property)
		{
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        if (Preferences.FromCache) {
			            return this.elementHolderNet.GetCachedPropertyValue(property);
			        } else {
                        return this.elementHolderNet.GetCurrentPropertyValue(property);
			        }
//			    case InnerElementTypes.AutomationElementCom:
//			        //
			    case InnerElementTypes.MySuperWrapper:
			        if (Preferences.FromCache) {
			            return this.elementHolderAdapter.GetCachedPropertyValue(property);
			        } else {
                        return this.elementHolderAdapter.GetCurrentPropertyValue(property);
			        }
			    default:
			        if (Preferences.FromCache) {
			            return this.elementHolderNet.GetCachedPropertyValue(property);
			        } else {
                        return this.elementHolderNet.GetCurrentPropertyValue(property);
			        }
			}
		}

		public object GetCurrentPropertyValue(AutomationProperty property, bool ignoreDefaultValue)
		{
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        if (Preferences.FromCache) {
			            return this.elementHolderNet.GetCachedPropertyValue(property, ignoreDefaultValue);
			        } else {
                        return this.elementHolderNet.GetCurrentPropertyValue(property, ignoreDefaultValue);
			        }
//			    case InnerElementTypes.AutomationElementCom:
//			        //
			    case InnerElementTypes.MySuperWrapper:
			        if (Preferences.FromCache) {
			            return this.elementHolderAdapter.GetCachedPropertyValue(property, ignoreDefaultValue);
			        } else {
                        return this.elementHolderAdapter.GetCurrentPropertyValue(property, ignoreDefaultValue);
			        }
			    default:
			        if (Preferences.FromCache) {
			            return this.elementHolderNet.GetCachedPropertyValue(property, ignoreDefaultValue);
			        } else {
                        return this.elementHolderNet.GetCurrentPropertyValue(property, ignoreDefaultValue);
			        }
			}
		}

		public object GetCurrentPattern(AutomationPattern pattern)
		{
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        if (Preferences.FromCache) {
			            return this.elementHolderNet.GetCachedPattern(pattern);
			        } else {
                        return this.elementHolderNet.GetCurrentPattern(pattern);
			        }
//			    case InnerElementTypes.AutomationElementCom:
//			        //
			    case InnerElementTypes.MySuperWrapper:
			        if (Preferences.FromCache) {
			            return this.elementHolderAdapter.GetCachedPattern(pattern);
			        } else {
                        return this.elementHolderAdapter.GetCurrentPattern(pattern);
			        }
			    default:
			        if (Preferences.FromCache) {
			            return this.elementHolderNet.GetCachedPattern(pattern);
			        } else {
                        return this.elementHolderNet.GetCurrentPattern(pattern);
			        }
			}
		}

		public bool TryGetCurrentPattern(AutomationPattern pattern, out object patternObject)
		{
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        if (Preferences.FromCache) {
			            return this.elementHolderNet.TryGetCachedPattern(pattern, out patternObject);
			        } else {
                        return this.elementHolderNet.TryGetCurrentPattern(pattern, out patternObject);
			        }
//			    case InnerElementTypes.AutomationElementCom:
//			        //
			    case InnerElementTypes.MySuperWrapper:
			        if (Preferences.FromCache) {
			            return this.elementHolderAdapter.TryGetCachedPattern(pattern, out patternObject);
			        } else {
                        return this.elementHolderAdapter.TryGetCurrentPattern(pattern, out patternObject);
			        }
			    default:
			        if (Preferences.FromCache) {
			            return this.elementHolderNet.TryGetCachedPattern(pattern, out patternObject);
			        } else {
                        return this.elementHolderNet.TryGetCurrentPattern(pattern, out patternObject);
			        }
			}
		}

		public object GetCachedPropertyValue(AutomationProperty property)
		{
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return this.elementHolderNet.GetCachedPropertyValue(property);
//			    case InnerElementTypes.AutomationElementCom:
//			        //
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.GetCachedPropertyValue(property);
			    default:
			        return this.elementHolderNet.GetCachedPropertyValue(property);
			}
		}

		public object GetCachedPropertyValue(AutomationProperty property, bool ignoreDefaultValue)
		{
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return this.elementHolderNet.GetCachedPropertyValue(property, ignoreDefaultValue);
//			    case InnerElementTypes.AutomationElementCom:
//			        //
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.GetCachedPropertyValue(property, ignoreDefaultValue);
			    default:
			        return this.elementHolderNet.GetCachedPropertyValue(property, ignoreDefaultValue);
			}
		}

		public object GetCachedPattern(AutomationPattern pattern)
		{
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return this.elementHolderNet.GetCachedPattern(pattern);
//			    case InnerElementTypes.AutomationElementCom:
//			        //
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.GetCachedPattern(pattern);
			    default:
			        return this.elementHolderNet.GetCachedPattern(pattern);
			}
		}

		public bool TryGetCachedPattern(AutomationPattern pattern, out object patternObject)
		{
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return this.elementHolderNet.TryGetCachedPattern(pattern, out patternObject);
//			    case InnerElementTypes.AutomationElementCom:
//			        //
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.TryGetCachedPattern(pattern, out patternObject);
			    default:
			        return this.elementHolderNet.TryGetCachedPattern(pattern, out patternObject);
			}
		}

		public AutomationElement GetUpdatedCache(CacheRequest request)
		{
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return this.elementHolderNet.GetUpdatedCache(request);
//			    case InnerElementTypes.AutomationElementCom:
//			        //
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.GetUpdatedCache(request);
			    default:
			        return this.elementHolderNet.GetUpdatedCache(request);
			}
		}

		public IMySuperWrapper FindFirst(TreeScope scope, Condition condition)
		{
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return ObjectsFactory.GetMySuperWrapper(this.elementHolderNet.FindFirst(scope, condition));
//			    case InnerElementTypes.AutomationElementCom:
//			        //
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.FindFirst(scope, condition);
			    default:
			        return ObjectsFactory.GetMySuperWrapper(this.elementHolderNet.FindFirst(scope, condition));
			}
		}

		public IMySuperCollection FindAll(TreeScope scope, Condition condition)
		{
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return ObjectsFactory.GetMySuperCollection(this.elementHolderNet.FindAll(scope, condition));
//			    case InnerElementTypes.AutomationElementCom:
//			        //
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.FindAll(scope, condition);
			    default:
			        return ObjectsFactory.GetMySuperCollection(this.elementHolderNet.FindAll(scope, condition));
			}
		}

		public AutomationProperty[] GetSupportedProperties()
		{
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return this.elementHolderNet.GetSupportedProperties();
//			    case InnerElementTypes.AutomationElementCom:
//			        //
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.GetSupportedProperties();
			    default:
			        return this.elementHolderNet.GetSupportedProperties();
			}
		}

		public AutomationPattern[] GetSupportedPatterns()
		{
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return this.elementHolderNet.GetSupportedPatterns();
//			    case InnerElementTypes.AutomationElementCom:
//			        //
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.GetSupportedPatterns();
			    default:
			        return this.elementHolderNet.GetSupportedPatterns();
			}
		}

		public void SetFocus()
		{
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        this.elementHolderNet.SetFocus();
			        break;
//			    case InnerElementTypes.AutomationElementCom:
//			        //
			    case InnerElementTypes.MySuperWrapper:
			        this.elementHolderAdapter.SetFocus();
			        break;
			    default:
			        this.elementHolderNet.SetFocus();
			        break;
			}
		}

		public bool TryGetClickablePoint(out System.Windows.Point pt)
		{
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return this.elementHolderNet.TryGetClickablePoint(out pt);
//			    case InnerElementTypes.AutomationElementCom:
//			        //
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.TryGetClickablePoint(out pt);
			    default:
			        return this.elementHolderNet.TryGetClickablePoint(out pt);
			}
		}

		public System.Windows.Point GetClickablePoint()
		{
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return this.elementHolderNet.GetClickablePoint();
//			    case InnerElementTypes.AutomationElementCom:
//			        //
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.GetClickablePoint();
			    default:
			        return this.elementHolderNet.GetClickablePoint();
			}
		}

		public IMySuperWrapperInformation Cached {
			get {
			    switch (innerElementType) {
			        case InnerElementTypes.AutomationElementNet:
			            return ObjectsFactory.GetMySuperWrapperInformation(this.elementHolderNet.Cached);
//			        case /InnerElementTypes.AutomationElementCom:
//			            //
			        case InnerElementTypes.MySuperWrapper:
			            return this.elementHolderAdapter.Cached;
			        default:
			            return ObjectsFactory.GetMySuperWrapperInformation(this.elementHolderNet.Cached);
			    }
			}
		}

		public IMySuperWrapperInformation Current {
		    get {
		        switch (innerElementType) {
		            case InnerElementTypes.AutomationElementNet:
		                if (Preferences.FromCache) {
                            return ObjectsFactory.GetMySuperWrapperInformation(this.elementHolderNet.Cached);
    			        } else {
    		                return ObjectsFactory.GetMySuperWrapperInformation(this.elementHolderNet.Current);
                        }
//		            case InnerElementTypes.AutomationElementCom:
//		                //
		            case InnerElementTypes.MySuperWrapper:
		                if (Preferences.FromCache) {
    			            return this.elementHolderAdapter.Cached;
    			        } else {
                            return this.elementHolderAdapter.Current;
		                }
		            default:
		                if (Preferences.FromCache) {
    			            return ObjectsFactory.GetMySuperWrapperInformation(this.elementHolderNet.Cached);
    			        } else {
                            return ObjectsFactory.GetMySuperWrapperInformation(this.elementHolderNet.Current);
		                }
		        }
		    }
		}

		public IMySuperWrapper CachedParent {
			get {
			    switch (innerElementType) {
			        case InnerElementTypes.AutomationElementNet:
			            return ObjectsFactory.GetMySuperWrapper(this.elementHolderNet.CachedParent);
//			        case InnerElementTypes.AutomationElementCom:
//			            //
			        case InnerElementTypes.MySuperWrapper:
			            return this.elementHolderAdapter.CachedParent;
			        default:
			            return ObjectsFactory.GetMySuperWrapper(this.elementHolderNet.CachedParent);
			    }
			}
		}

		public IMySuperCollection CachedChildren {
			get {
			    switch (innerElementType) {
			        case InnerElementTypes.AutomationElementNet:
			            return ObjectsFactory.GetMySuperCollection(this.elementHolderNet.CachedChildren);
//			        case /InnerElementTypes.AutomationElementCom:
//			            //
			        case InnerElementTypes.MySuperWrapper:
			            return this.elementHolderAdapter.CachedChildren;
			        default:
			            return ObjectsFactory.GetMySuperCollection(this.elementHolderNet.CachedChildren);
			    }
			}
		}

		// static methods and properties
		public static IMySuperWrapper RootElement {
			get {
			    switch (innerElementType) {
			        case InnerElementTypes.AutomationElementNet:
			            return ObjectsFactory.GetMySuperWrapper(AutomationElement.RootElement);
//			        case InnerElementTypes.AutomationElementCom:
//			            //
			        case InnerElementTypes.MySuperWrapper:
			            return MySuperWrapper.RootElement;
			        default:
			            return ObjectsFactory.GetMySuperWrapper(AutomationElement.RootElement);
			    }
			}
		}
		
		public static IMySuperWrapper FocusedElement {
		    get {
		        switch (innerElementType) {
		            case InnerElementTypes.AutomationElementNet:
		                return ObjectsFactory.GetMySuperWrapper(AutomationElement.FocusedElement);
//		            case InnerElementTypes.AutomationElementCom:
//		                //
		            case InnerElementTypes.MySuperWrapper:
		                return MySuperWrapper.FocusedElement;
		            default:
		                return ObjectsFactory.GetMySuperWrapper(AutomationElement.FocusedElement);
		        }
		    }
		}
		
		public static IMySuperWrapper FromPoint(System.Windows.Point pt)
		{
		    switch (innerElementType) {
		        case InnerElementTypes.AutomationElementNet:
		            return ObjectsFactory.GetMySuperWrapper(AutomationElement.FromPoint(pt));
//		        case InnerElementTypes.AutomationElementCom:
//		            //
		        case InnerElementTypes.MySuperWrapper:
		            return MySuperWrapper.FromPoint(pt);
		        default:
		            return ObjectsFactory.GetMySuperWrapper(AutomationElement.FromPoint(pt));
		    }
		}
		
		public static IMySuperWrapper FromHandle(IntPtr controlHandle)
		{
		    switch (innerElementType) {
		        case InnerElementTypes.AutomationElementNet:
		            return ObjectsFactory.GetMySuperWrapper(AutomationElement.FromHandle(controlHandle));
//		        case InnerElementTypes.AutomationElementCom:
//		            //
		        case InnerElementTypes.MySuperWrapper:
		            return MySuperWrapper.FromHandle(controlHandle);
		        default:
		            return ObjectsFactory.GetMySuperWrapper(AutomationElement.FromHandle(controlHandle));
		    }
		}
		
		public AutomationElement GetSourceElement()
		{
		    return this.elementHolderNet;
		}
		public void SetSourceElement(AutomationElement element)
		{
		    this.elementHolderNet = element;
		}
		
//		public AutomationElement GetSourceElement()
//		{
//		    return this.elementHolderNet;
//		}
//		public void SetSourceElement(AutomationElement element)
//		{
//		    this.elementHolderNet = element;
//		}
		
//		public IMySuperWrapper GetSourceElement()
//		{
//		    return this.elementHolderAdapter;
//		}
//		public void SetSourceElement(IMySuperWrapper element)
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
//		    if (InnerElementTypes.MySuperWrapper == innerElementType) { //&&
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
	}
}
