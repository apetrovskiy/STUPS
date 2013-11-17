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
		private AutomationElement elementHolder;
        
		[Inject]
		public MySuperWrapper(AutomationElement element)
		{
			this.elementHolder = element;
		}

		public override bool Equals(object obj)
		{
			return this.elementHolder.Equals(obj);
		}

		public override int GetHashCode()
		{
			return this.elementHolder.GetHashCode();
		}

		public int[] GetRuntimeId()
		{
			return this.elementHolder.GetRuntimeId();
		}

		public object GetCurrentPropertyValue(AutomationProperty property)
		{
			return this.elementHolder.GetCurrentPropertyValue(property);
		}

		public object GetCurrentPropertyValue(AutomationProperty property, bool ignoreDefaultValue)
		{
			return this.elementHolder.GetCurrentPropertyValue(property, ignoreDefaultValue);
		}

		public object GetCurrentPattern(AutomationPattern pattern)
		{
			return this.elementHolder.GetCurrentPattern(pattern);
		}

		public bool TryGetCurrentPattern(AutomationPattern pattern, out object patternObject)
		{
			return this.elementHolder.TryGetCurrentPattern(pattern, out patternObject);
		}

		public object GetCachedPropertyValue(AutomationProperty property)
		{
			return this.elementHolder.GetCachedPropertyValue(property);
		}

		public object GetCachedPropertyValue(AutomationProperty property, bool ignoreDefaultValue)
		{
			return this.elementHolder.GetCachedPropertyValue(property, ignoreDefaultValue);
		}

		public object GetCachedPattern(AutomationPattern pattern)
		{
			return this.elementHolder.GetCachedPattern(pattern);
		}

		public bool TryGetCachedPattern(AutomationPattern pattern, out object patternObject)
		{
			return this.elementHolder.TryGetCachedPattern(pattern, out patternObject);
		}

		public AutomationElement GetUpdatedCache(CacheRequest request)
		{
			return this.elementHolder.GetUpdatedCache(request);
		}

		public IMySuperWrapper FindFirst(TreeScope scope, Condition condition)
		{
			return ObjectsFactory.GetMySuperWrapper(this.elementHolder.FindFirst(scope, condition));
		}

		public IMySuperCollection FindAll(TreeScope scope, Condition condition)
		{
			return ObjectsFactory.GetMySuperCollection(this.elementHolder.FindAll(scope, condition));
		}

		public AutomationProperty[] GetSupportedProperties()
		{
			return this.elementHolder.GetSupportedProperties();
		}

		public AutomationPattern[] GetSupportedPatterns()
		{
			return this.elementHolder.GetSupportedPatterns();
		}

		public void SetFocus()
		{
			this.elementHolder.SetFocus();
		}

		//public bool TryGetClickablePoint(out Point pt)
		public bool TryGetClickablePoint(out System.Windows.Point pt)
		{
			return this.elementHolder.TryGetClickablePoint(out pt);
		}

		//public Point GetClickablePoint()
		public System.Windows.Point GetClickablePoint()
		{
			return this.elementHolder.GetClickablePoint();
		}

		// 20131114
		//public AutomationElement.AutomationElementInformation Cached {
		public IMySuperWrapperInformation Cached {
		    // 20131114
			//get { return this.elementHolder.Cached; }
			get { return ObjectsFactory.GetMySuperWrapperInformation(this.elementHolder.Cached); }
		}

		// 20131114
		//public AutomationElement.AutomationElementInformation Current {
		public IMySuperWrapperInformation Current {
			// 20131114
		    //get { return this.elementHolder.Current; }
		    get { return ObjectsFactory.GetMySuperWrapperInformation(this.elementHolder.Current); }
		}

		// 20131114
		//public AutomationElement CachedParent {
		public IMySuperWrapper CachedParent {
		    // 20131114
			//get { return this.elementHolder.CachedParent; }
			get { return ObjectsFactory.GetMySuperWrapper(this.elementHolder.CachedParent); }
		}

		// 20131114
		//public AutomationElementCollection CachedChildren {
		public IMySuperCollection CachedChildren {
		    // 20131114
			//get { return this.elementHolder.CachedChildren; }
			get { return ObjectsFactory.GetMySuperCollection(this.elementHolder.CachedChildren); }
		}

		// static methods and properties
		public static IMySuperWrapper RootElement {
		    // 20131112
			//get { return new MySuperWrapper(AutomationElement.RootElement); }
			get { return ObjectsFactory.GetMySuperWrapper(AutomationElement.RootElement); }
		}
		
		public static IMySuperWrapper FocusedElement {
		    // 20131112
		    //get { return new MySuperWrapper(AutomationElement.FocusedElement); }
		    get { return ObjectsFactory.GetMySuperWrapper(AutomationElement.FocusedElement); }
		}
		
		public static IMySuperWrapper FromPoint(System.Windows.Point pt)
		{
		    // 20131112
		    //return new MySuperWrapper(AutomationElement.FromPoint(pt));
		    return ObjectsFactory.GetMySuperWrapper(AutomationElement.FromPoint(pt));
		}
		
		public static IMySuperWrapper FromHandle(IntPtr controlHandle)
		{
		    // 20131112
		    //return new MySuperWrapper(AutomationElement.FromHandle(controlHandle));
		    return ObjectsFactory.GetMySuperWrapper(AutomationElement.FromHandle(controlHandle));
		}

		public AutomationElement SourceElement {
			get { return this.elementHolder; }
			set { this.elementHolder = value; }
		}
	}
}
