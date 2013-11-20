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
		//private T elementHolder;
		//private InnerElementTypes innerElementType = InnerElementTypes.AutomationElementNet;
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
			//return this.elementHolder.Equals(obj);
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return this.elementHolderNet.Equals(obj);
			        //break;
//			    case InnerElementTypes.AutomationElementCom:
//			        //
//			        //break;
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.Equals(obj);
			        //break;
			    default:
			        //throw new Exception("Invalid value for InnerElementTypes");
			        return this.elementHolderNet.Equals(obj);
			}
		}

		public override int GetHashCode()
		{
			//return this.elementHolderNet.GetHashCode();
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return this.elementHolderNet.GetHashCode();
			        //break;
//			    case InnerElementTypes.AutomationElementCom:
//			        //
//			        //break;
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.GetHashCode();
			        //break;
			    default:
			        //throw new Exception("Invalid value for InnerElementTypes");
			        return this.elementHolderNet.GetHashCode();
			}
		}

		public int[] GetRuntimeId()
		{
			//return this.elementHolderNet.GetRuntimeId();
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return this.elementHolderNet.GetRuntimeId();
			        //break;
//			    case InnerElementTypes.AutomationElementCom:
//			        //
//			        /break;
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.GetRuntimeId();
			        //break;
			    default:
			        //throw new Exception("Invalid value for InnerElementTypes");
			        return this.elementHolderNet.GetRuntimeId();
			}
		}

		public object GetCurrentPropertyValue(AutomationProperty property)
		{
			//return this.elementHolderNet.GetCurrentPropertyValue(property);
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return this.elementHolderNet.GetCurrentPropertyValue(property);
			        //break;
//			    case InnerElementTypes.AutomationElementCom:
//			        //
//			        //break;
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.GetCurrentPropertyValue(property);
			        //break;
			    default:
			        //throw new Exception("Invalid value for InnerElementTypes");
			        return this.elementHolderNet.GetCurrentPropertyValue(property);
			}
		}

		public object GetCurrentPropertyValue(AutomationProperty property, bool ignoreDefaultValue)
		{
			//return this.elementHolderNet.GetCurrentPropertyValue(property, ignoreDefaultValue);
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return this.elementHolderNet.GetCurrentPropertyValue(property, ignoreDefaultValue);
			        //break;
//			    case InnerElementTypes.AutomationElementCom:
//			        //
//			        //break;
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.GetCurrentPropertyValue(property, ignoreDefaultValue);
			        //break;
			    default:
			        //throw new Exception("Invalid value for InnerElementTypes");
			        return this.elementHolderNet.GetCurrentPropertyValue(property, ignoreDefaultValue);
			}
		}

		public object GetCurrentPattern(AutomationPattern pattern)
		{
			//return this.elementHolderNet.GetCurrentPattern(pattern);
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return this.elementHolderNet.GetCurrentPattern(pattern);
			        //break;
//			    case InnerElementTypes.AutomationElementCom:
//			        //
//			        //break;
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.GetCurrentPattern(pattern);
			        //break;
			    default:
			        //throw new Exception("Invalid value for InnerElementTypes");
			        return this.elementHolderNet.GetCurrentPattern(pattern);
			}
		}

		public bool TryGetCurrentPattern(AutomationPattern pattern, out object patternObject)
		{
			//return this.elementHolderNet.TryGetCurrentPattern(pattern, out patternObject);
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return this.elementHolderNet.TryGetCurrentPattern(pattern, out patternObject);
			        //break;
//			    case InnerElementTypes.AutomationElementCom:
//			        //
//			        //break;
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.TryGetCurrentPattern(pattern, out patternObject);
			        //break;
			    default:
			        //throw new Exception("Invalid value for InnerElementTypes");
			        return this.elementHolderNet.TryGetCurrentPattern(pattern, out patternObject);
			}
		}

		public object GetCachedPropertyValue(AutomationProperty property)
		{
			//return this.elementHolderNet.GetCachedPropertyValue(property);
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return this.elementHolderNet.GetCachedPropertyValue(property);
			        //break;
//			    case InnerElementTypes.AutomationElementCom:
//			        //
//			        //break;
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.GetCachedPropertyValue(property);
			        //break;
			    default:
			        //throw new Exception("Invalid value for InnerElementTypes");
			        return this.elementHolderNet.GetCachedPropertyValue(property);
			}
		}

		public object GetCachedPropertyValue(AutomationProperty property, bool ignoreDefaultValue)
		{
			//return this.elementHolderNet.GetCachedPropertyValue(property, ignoreDefaultValue);
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return this.elementHolderNet.GetCachedPropertyValue(property, ignoreDefaultValue);
			        //break;
//			    case InnerElementTypes.AutomationElementCom:
//			        //
//			        //break;
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.GetCachedPropertyValue(property, ignoreDefaultValue);
			        //break;
			    default:
			        //throw new Exception("Invalid value for InnerElementTypes");
			        return this.elementHolderNet.GetCachedPropertyValue(property, ignoreDefaultValue);
			}
		}

		public object GetCachedPattern(AutomationPattern pattern)
		{
			//return this.elementHolderNet.GetCachedPattern(pattern);
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return this.elementHolderNet.GetCachedPattern(pattern);
			        //break;
//			    case InnerElementTypes.AutomationElementCom:
//			        //
//			        //break;
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.GetCachedPattern(pattern);
			        //break;
			    default:
			        //throw new Exception("Invalid value for InnerElementTypes");
			        return this.elementHolderNet.GetCachedPattern(pattern);
			}
		}

		public bool TryGetCachedPattern(AutomationPattern pattern, out object patternObject)
		{
			//return this.elementHolderNet.TryGetCachedPattern(pattern, out patternObject);
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return this.elementHolderNet.TryGetCachedPattern(pattern, out patternObject);
			        //break;
//			    case InnerElementTypes.AutomationElementCom:
//			        //
//			        //break;
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.TryGetCachedPattern(pattern, out patternObject);
			        //break;
			    default:
			        //throw new Exception("Invalid value for InnerElementTypes");
			        return this.elementHolderNet.TryGetCachedPattern(pattern, out patternObject);
			}
		}

		public AutomationElement GetUpdatedCache(CacheRequest request)
		{
			//return this.elementHolderNet.GetUpdatedCache(request);
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return this.elementHolderNet.GetUpdatedCache(request);
			        //break;
//			    case InnerElementTypes.AutomationElementCom:
//			        //
//			        //break;
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.GetUpdatedCache(request);
			        //break;
			    default:
			        //throw new Exception("Invalid value for InnerElementTypes");
			        return this.elementHolderNet.GetUpdatedCache(request);
			}
		}

		public IMySuperWrapper FindFirst(TreeScope scope, Condition condition)
		{
			//return ObjectsFactory.GetMySuperWrapper(this.elementHolderNet.FindFirst(scope, condition));
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return ObjectsFactory.GetMySuperWrapper(this.elementHolderNet.FindFirst(scope, condition));
			        //break;
//			    case InnerElementTypes.AutomationElementCom:
//			        //
//			        //break;
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.FindFirst(scope, condition);
			        //break;
			    default:
			        //throw new Exception("Invalid value for InnerElementTypes");
			        return ObjectsFactory.GetMySuperWrapper(this.elementHolderNet.FindFirst(scope, condition));
			}
		}

		public IMySuperCollection FindAll(TreeScope scope, Condition condition)
		{
			//return ObjectsFactory.GetMySuperCollection(this.elementHolderNet.FindAll(scope, condition));
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return ObjectsFactory.GetMySuperCollection(this.elementHolderNet.FindAll(scope, condition));
			        //break;
//			    case InnerElementTypes.AutomationElementCom:
//			        //
//			        //break;
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.FindAll(scope, condition);
			        //break;
			    default:
			        //throw new Exception("Invalid value for InnerElementTypes");
			        return ObjectsFactory.GetMySuperCollection(this.elementHolderNet.FindAll(scope, condition));
			}
		}

		public AutomationProperty[] GetSupportedProperties()
		{
			//return this.elementHolderNet.GetSupportedProperties();
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return this.elementHolderNet.GetSupportedProperties();
			        //break;
//			    case InnerElementTypes.AutomationElementCom:
//			        //
//			        //break;
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.GetSupportedProperties();
			        //break;
			    default:
			        //throw new Exception("Invalid value for InnerElementTypes");
			        return this.elementHolderNet.GetSupportedProperties();
			}
		}

		public AutomationPattern[] GetSupportedPatterns()
		{
			//return this.elementHolderNet.GetSupportedPatterns();
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return this.elementHolderNet.GetSupportedPatterns();
			        //break;
//			    case InnerElementTypes.AutomationElementCom:
//			        //
//			        //break;
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.GetSupportedPatterns();
			        //break;
			    default:
			        //throw new Exception("Invalid value for InnerElementTypes");
			        return this.elementHolderNet.GetSupportedPatterns();
			}
		}

		public void SetFocus()
		{
			//this.elementHolderNet.SetFocus();
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        this.elementHolderNet.SetFocus();
			        break;
//			    case InnerElementTypes.AutomationElementCom:
//			        //
//			        break;
			    case InnerElementTypes.MySuperWrapper:
			        this.elementHolderAdapter.SetFocus();
			        break;
			    default:
			        //throw new Exception("Invalid value for InnerElementTypes");
			        this.elementHolderNet.SetFocus();
			        break;
			}
		}

		//public bool TryGetClickablePoint(out Point pt)
		public bool TryGetClickablePoint(out System.Windows.Point pt)
		{
			//return this.elementHolderNet.TryGetClickablePoint(out pt);
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return this.elementHolderNet.TryGetClickablePoint(out pt);
			        //break;
//			    case InnerElementTypes.AutomationElementCom:
//			        //
//			        //break;
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.TryGetClickablePoint(out pt);
			        //break;
			    default:
			        //throw new Exception("Invalid value for InnerElementTypes");
			        return this.elementHolderNet.TryGetClickablePoint(out pt);
			}
		}

		//public Point GetClickablePoint()
		public System.Windows.Point GetClickablePoint()
		{
			//return this.elementHolderNet.GetClickablePoint();
			switch (innerElementType) {
			    case InnerElementTypes.AutomationElementNet:
			        return this.elementHolderNet.GetClickablePoint();
			        //break;
//			    case InnerElementTypes.AutomationElementCom:
//			        //
//			        //break;
			    case InnerElementTypes.MySuperWrapper:
			        return this.elementHolderAdapter.GetClickablePoint();
			        //break;
			    default:
			        //throw new Exception("Invalid value for InnerElementTypes");
			        return this.elementHolderNet.GetClickablePoint();
			}
		}

		// 20131114
		//public AutomationElement.AutomationElementInformation Cached {
		public IMySuperWrapperInformation Cached {
		    // 20131114
			//get { return this.elementHolder.Cached; }
			get {
			    //return ObjectsFactory.GetMySuperWrapperInformation(this.elementHolderNet.Cached);
			    switch (innerElementType) {
			        case InnerElementTypes.AutomationElementNet:
			            return ObjectsFactory.GetMySuperWrapperInformation(this.elementHolderNet.Cached);
			            //break;
//			        case /InnerElementTypes.AutomationElementCom:
//			            //
//			            //break;
			        case InnerElementTypes.MySuperWrapper:
			            return this.elementHolderAdapter.Cached;
			            //break;
			        default:
			            //throw new Exception("Invalid value for InnerElementTypes");
			            return ObjectsFactory.GetMySuperWrapperInformation(this.elementHolderNet.Cached);
			    }
			}
		}

		// 20131114
		//public AutomationElement.AutomationElementInformation Current {
		public IMySuperWrapperInformation Current {
			// 20131114
		    //get { return this.elementHolder.Current; }
		    get {
		        //return ObjectsFactory.GetMySuperWrapperInformation(this.elementHolderNet.Current);
		        switch (innerElementType) {
		            case InnerElementTypes.AutomationElementNet:
		                return ObjectsFactory.GetMySuperWrapperInformation(this.elementHolderNet.Current);
		                //break;
//		            case InnerElementTypes.AutomationElementCom:
//		                //
//		                //break;
		            case InnerElementTypes.MySuperWrapper:
		                return this.elementHolderAdapter.Current;
		                //break;
		            default:
		                //throw new Exception("Invalid value for InnerElementTypes");
		                return ObjectsFactory.GetMySuperWrapperInformation(this.elementHolderNet.Current);
		        }
		    }
		}

		// 20131114
		//public AutomationElement CachedParent {
		public IMySuperWrapper CachedParent {
		    // 20131114
			//get { return this.elementHolder.CachedParent; }
			get {
			    //return ObjectsFactory.GetMySuperWrapper(this.elementHolderNet.CachedParent);
			    switch (innerElementType) {
			        case InnerElementTypes.AutomationElementNet:
			            return ObjectsFactory.GetMySuperWrapper(this.elementHolderNet.CachedParent);
			            //break;
//			        case InnerElementTypes.AutomationElementCom:
//			            //
//			            //break;
			        case InnerElementTypes.MySuperWrapper:
			            return this.elementHolderAdapter.CachedParent;
			            //break;
			        default:
			            //throw new Exception("Invalid value for InnerElementTypes");
			            return ObjectsFactory.GetMySuperWrapper(this.elementHolderNet.CachedParent);
			    }
			}
		}

		// 20131114
		//public AutomationElementCollection CachedChildren {
		public IMySuperCollection CachedChildren {
		    // 20131114
			//get { return this.elementHolder.CachedChildren; }
			get {
			    //return ObjectsFactory.GetMySuperCollection(this.elementHolderNet.CachedChildren);
			    switch (innerElementType) {
			        case InnerElementTypes.AutomationElementNet:
			            return ObjectsFactory.GetMySuperCollection(this.elementHolderNet.CachedChildren);
			            //break;
//			        case /InnerElementTypes.AutomationElementCom:
//			            //
//			            //break;
			        case InnerElementTypes.MySuperWrapper:
			            return this.elementHolderAdapter.CachedChildren;
			            //break;
			        default:
			            //throw new Exception("Invalid value for InnerElementTypes");
			            return ObjectsFactory.GetMySuperCollection(this.elementHolderNet.CachedChildren);
			    }
			}
		}

		// static methods and properties
		public static IMySuperWrapper RootElement {
		    // 20131112
			//get { return new MySuperWrapper(AutomationElement.RootElement); }
			get {
			    //return ObjectsFactory.GetMySuperWrapper(AutomationElement.RootElement);
			    switch (innerElementType) {
			        case InnerElementTypes.AutomationElementNet:
			            return ObjectsFactory.GetMySuperWrapper(AutomationElement.RootElement);
			            //break;
//			        case InnerElementTypes.AutomationElementCom:
//			            //
//			            //break;
			        case InnerElementTypes.MySuperWrapper:
			            return MySuperWrapper.RootElement;
			            //break;
			        default:
			            //throw new Exception("Invalid value for InnerElementTypes");
			            return ObjectsFactory.GetMySuperWrapper(AutomationElement.RootElement);
			    }
			}
		}
		
		public static IMySuperWrapper FocusedElement {
		    // 20131112
		    //get { return new MySuperWrapper(AutomationElement.FocusedElement); }
		    get {
		        //return ObjectsFactory.GetMySuperWrapper(AutomationElement.FocusedElement);
		        switch (innerElementType) {
		            case InnerElementTypes.AutomationElementNet:
		                return ObjectsFactory.GetMySuperWrapper(AutomationElement.FocusedElement);
		                //break;
//		            case InnerElementTypes.AutomationElementCom:
//		                //
//		                //break;
		            case InnerElementTypes.MySuperWrapper:
		                return MySuperWrapper.FocusedElement;
		                //break;
		            default:
		                //throw new Exception("Invalid value for InnerElementTypes");
		                return ObjectsFactory.GetMySuperWrapper(AutomationElement.FocusedElement);
		        }
		    }
		}
		
		public static IMySuperWrapper FromPoint(System.Windows.Point pt)
		{
		    // 20131112
		    //return new MySuperWrapper(AutomationElement.FromPoint(pt));
		    //return ObjectsFactory.GetMySuperWrapper(AutomationElement.FromPoint(pt));
		    switch (innerElementType) {
		        case InnerElementTypes.AutomationElementNet:
		            return ObjectsFactory.GetMySuperWrapper(AutomationElement.FromPoint(pt));
		            //break;
//		        case InnerElementTypes.AutomationElementCom:
//		            //
//		            //break;
		        case InnerElementTypes.MySuperWrapper:
		            return MySuperWrapper.FromPoint(pt);
		            //break;
		        default:
		            //throw new Exception("Invalid value for InnerElementTypes");
		            return ObjectsFactory.GetMySuperWrapper(AutomationElement.FromPoint(pt));
		    }
		}
		
		public static IMySuperWrapper FromHandle(IntPtr controlHandle)
		{
		    // 20131112
		    //return new MySuperWrapper(AutomationElement.FromHandle(controlHandle));
		    //return ObjectsFactory.GetMySuperWrapper(AutomationElement.FromHandle(controlHandle));
		    switch (innerElementType) {
		        case InnerElementTypes.AutomationElementNet:
		            return ObjectsFactory.GetMySuperWrapper(AutomationElement.FromHandle(controlHandle));
		            //break;
//		        case InnerElementTypes.AutomationElementCom:
//		            //
//		            //break;
		        case InnerElementTypes.MySuperWrapper:
		            return MySuperWrapper.FromHandle(controlHandle);
		            //break;
		        default:
		            //throw new Exception("Invalid value for InnerElementTypes");
		            return ObjectsFactory.GetMySuperWrapper(AutomationElement.FromHandle(controlHandle));
		    }
		}

//		public AutomationElement SourceElement {
//			get {
//		        //return this.elementHolderNet;
//		        switch (innerElementType) {
//		            case InnerElementTypes.AutomationElementNet:
//		                return this.elementHolderNet;
//		                break;
//		            case InnerElementTypes.AutomationElementCom:
//		                //
//		                break;
//		            case InnerElementTypes.MySuperWrapper:
//		                return this.elementHolderAdapter;
//		                break;
//		            default:
//		                //throw new Exception("Invalid value for InnerElementTypes");
//		                return this.elementHolderNet;
//		        }
//		    }
//			set {
//		        //this.elementHolderNet = value;
//		        switch (innerElementType) {
//		            case InnerElementTypes.AutomationElementNet:
//		                this.elementHolderNet = value;
//		                break;
//		            case InnerElementTypes.AutomationElementCom:
//		                //
//		                break;
//		            case InnerElementTypes.MySuperWrapper:
//		                this.elementHolderAdapter = value;
//		                break;
//		            default:
//		                //throw new Exception("Invalid value for InnerElementTypes");
//		                this.elementHolderNet = value;
//		        }
//		    }
//		}
		
//		public T GetSourceElement<T>()
//		{
//		    //return this.elementHolderNet;
//		    switch (innerElementType) {
//		        case InnerElementTypes.AutomationElementNet:
//		            return this.elementHolderNet;
//		            break;
//		        case InnerElementTypes.AutomationElementCom:
//		            //
//		            break;
//		        case InnerElementTypes.MySuperWrapper:
//		            
//		            break;
//		        default:
//		            //throw new Exception("Invalid value for InnerElementTypes");
//		            return this.elementHolderNet;
//		    }
//		}
//		public void SetSourceElement<T>(T element)
//		{
//			//this.elementHolderNet = element;
//			switch (innerElementType) {
//			    case InnerElementTypes.AutomationElementNet:
//			        this.elementHolderNet = element;
//			        break;
//			    case InnerElementTypes.AutomationElementCom:
//			        //
//			        break;
//			    case InnerElementTypes.MySuperWrapper:
//			        this.elementHolderAdapter = element;
//			        break;
//			    default:
//			        //throw new Exception("Invalid value for InnerElementTypes");
//			        this.elementHolderNet = element;
//			}
//		}
		
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
		    this.elementHolderNet = null;
		    // this.elementHolderCom = null;
		    this.elementHolderAdapter = null;
//		    this.Cached = null;
//		    this.CachedChildren = null;
//		    this.CachedParent = null;
//		    this.Current = null;
		    
		    // 20131120
		    GC.SuppressFinalize(this);
		}
	}
}
