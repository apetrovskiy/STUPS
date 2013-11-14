// /*
// * Created by SharpDevelop.
// * User: Alexander Petrovskiy
// * Date: 11/5/2013
// * Time: 1:56 AM
// * 
// * To change this template use Tools | Options | Coding | Edit Standard Headers.
// */
//
//namespace UIAutomationUnitTests
//{
//    using System;
//    using System.Windows.Automation;
//    //using PSTestLib;
//    using UIAutomation;
//    //using MbUnit.Framework;
//    
//    /// <summary>
//    /// Description of FakeMySuperWrapper.
//    /// </summary>
//    public class FakeMySuperWrapper : IMySuperWrapper
//    {
//        private IMySuperWrapper elementHolder;
//
//		public FakeMySuperWrapper()
//		{
//		}
////
////		public MySuperWrapper(AutomationElement element)
////		{
////			this.elementHolder = element;
////		}
//		
//		//
//		public FakeMySuperWrapper(IMySuperWrapper dataHolder)
//		{
//		    this.elementHolder = dataHolder;
//		}
//		//
//
//		public override bool Equals(object obj)
//		{
//			return this.elementHolder.Equals(obj);
//		}
//
//		public override int GetHashCode()
//		{
//			return this.elementHolder.GetHashCode();
//		}
//
//		public int[] GetRuntimeId()
//		{
//			return this.elementHolder.GetRuntimeId();
//		}
//
//		public object GetCurrentPropertyValue(AutomationProperty property)
//		{
//			return this.elementHolder.GetCurrentPropertyValue(property);
//		}
//
//		public object GetCurrentPropertyValue(AutomationProperty property, bool ignoreDefaultValue)
//		{
//			return this.elementHolder.GetCurrentPropertyValue(property, ignoreDefaultValue);
//		}
//
//		public object GetCurrentPattern(AutomationPattern pattern)
//		{
//			return this.elementHolder.GetCurrentPattern(pattern);
//		}
//
//		public bool TryGetCurrentPattern(AutomationPattern pattern, out object patternObject)
//		{
//			return this.elementHolder.TryGetCurrentPattern(pattern, out patternObject);
//		}
//
//		public object GetCachedPropertyValue(AutomationProperty property)
//		{
//			return this.elementHolder.GetCachedPropertyValue(property);
//		}
//
//		public object GetCachedPropertyValue(AutomationProperty property, bool ignoreDefaultValue)
//		{
//			return this.elementHolder.GetCachedPropertyValue(property, ignoreDefaultValue);
//		}
//
//		public object GetCachedPattern(AutomationPattern pattern)
//		{
//			return this.elementHolder.GetCachedPattern(pattern);
//		}
//
//		public bool TryGetCachedPattern(AutomationPattern pattern, out object patternObject)
//		{
//			return this.elementHolder.TryGetCachedPattern(pattern, out patternObject);
//		}
//
//		public AutomationElement GetUpdatedCache(CacheRequest request)
//		{
//			return this.elementHolder.GetUpdatedCache(request);
//		}
//
//		//public AutomationElement FindFirst(TreeScope scope, Condition condition)
//		public IMySuperWrapper FindFirst(TreeScope scope, Condition condition)
//		{
//			IMySuperWrapper adapterElement = null; // = new MySuperWrapper(this.elementHolder.FindFirst(scope, condition));
//			return adapterElement;
//		}
//
//		//public AutomationElementCollection FindAll(TreeScope scope, Condition condition)
//		public IMySuperCollection FindAll(TreeScope scope, Condition condition)
//		{
//			//return this.elementHolder.FindAll(scope, condition);
//			IMySuperCollection adapterCollection = new MySuperCollection(this.elementHolder.FindAll(scope, condition));
//			return adapterCollection;
//		}
//
//		public AutomationProperty[] GetSupportedProperties()
//		{
//			return this.elementHolder.GetSupportedProperties();
//		}
//
//		public AutomationPattern[] GetSupportedPatterns()
//		{
//			return this.elementHolder.GetSupportedPatterns();
//		}
//
//		public void SetFocus()
//		{
//			this.elementHolder.SetFocus();
//		}
//
//		//public bool TryGetClickablePoint(out Point pt)
//		public bool TryGetClickablePoint(out System.Windows.Point pt)
//		{
//			return this.elementHolder.TryGetClickablePoint(out pt);
//		}
//
//		//public Point GetClickablePoint()
//		public System.Windows.Point GetClickablePoint()
//		{
//			return this.elementHolder.GetClickablePoint();
//		}
//
//		public IMySuperWrapperInformation Cached {
//			get { return this.elementHolder.Cached; }
//		}
//
//		public IMySuperWrapperInformation Current {
//			get { return this.elementHolder.Current; }
//		}
//
//		public IMySuperWrapper CachedParent {
//			get { return this.elementHolder.CachedParent; }
//		}
//
//		public IMySuperCollection CachedChildren {
//			get { return this.elementHolder.CachedChildren; }
//		}
//
//		// static methods and properties
//		public static IMySuperWrapper RootElement {
//			get { return new MySuperWrapper(AutomationElement.RootElement); }
//		}
//		
//		public static IMySuperWrapper FromPoint(System.Windows.Point pt)
//		{
//		    return new MySuperWrapper(AutomationElement.FromPoint(pt));
//		}
//		
//		public static IMySuperWrapper FromHandle(IntPtr controlHandle)
//		{
//		    return new MySuperWrapper(AutomationElement.FromHandle(controlHandle));
//		}
//
////		public AutomationElement SourceElement {
////			get { return this.elementHolder; }
////			set { this.elementHolder = value; }
////		}
//		
//		public AutomationElement SourceElement { get; set; }
//    }
//}
