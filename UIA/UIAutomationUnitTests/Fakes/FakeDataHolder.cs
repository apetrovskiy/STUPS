/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/11/2013
 * Time: 12:22 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests
{
    using System;
    using System.Windows.Automation;
    //using PSTestLib;
    using UIAutomation;
    //using MbUnit.Framework;
    
    /// <summary>
    /// Description of FakeDataHolder.
    /// </summary>
    public class FakeDataHolder : IMySuperWrapper
    {
        IMySuperWrapperInformation elementHolder;
        
		public FakeDataHolder()
		{
		}
		
		//public FakeDataHolder(IElementInformation currentData)
		public FakeDataHolder(IMySuperWrapperInformation currentData)
		{
		    this.elementHolder = currentData;
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
			//return this.elementHolder.GetRuntimeId();
			return new int[] { 1, 2, 3 };
		}

		public object GetCurrentPropertyValue(AutomationProperty property)
		{
			//return this.elementHolder.GetCurrentPropertyValue(property);
			return null;
		}

		public object GetCurrentPropertyValue(AutomationProperty property, bool ignoreDefaultValue)
		{
			//return this.elementHolder.GetCurrentPropertyValue(property, ignoreDefaultValue);
			return null;
		}

		public object GetCurrentPattern(AutomationPattern pattern)
		{
			//return this.elementHolder.GetCurrentPattern(pattern);
			return null;
		}

		public bool TryGetCurrentPattern(AutomationPattern pattern, out object patternObject)
		{
			//return this.elementHolder.TryGetCurrentPattern(pattern, out patternObject);
			patternObject = null;
			return false;
		}

		public object GetCachedPropertyValue(AutomationProperty property)
		{
			//return this.elementHolder.GetCachedPropertyValue(property);
			return null;
		}

		public object GetCachedPropertyValue(AutomationProperty property, bool ignoreDefaultValue)
		{
			//return this.elementHolder.GetCachedPropertyValue(property, ignoreDefaultValue);
			return null;
		}

		public object GetCachedPattern(AutomationPattern pattern)
		{
			//return this.elementHolder.GetCachedPattern(pattern);
			return null;
		}

		public bool TryGetCachedPattern(AutomationPattern pattern, out object patternObject)
		{
			//return this.elementHolder.TryGetCachedPattern(pattern, out patternObject);
			patternObject = null;
			return false;
		}

		public AutomationElement GetUpdatedCache(CacheRequest request)
		{
			//return this.elementHolder.GetUpdatedCache(request);
			return null;
		}

		//public AutomationElement FindFirst(TreeScope scope, Condition condition)
		public IMySuperWrapper FindFirst(TreeScope scope, Condition condition)
		{
			IMySuperWrapper adapterElement = null; // = new MySuperWrapper(this.elementHolder.FindFirst(scope, condition));
			return adapterElement;
		}

		//public AutomationElementCollection FindAll(TreeScope scope, Condition condition)
		public IMySuperCollection FindAll(TreeScope scope, Condition condition)
		{
			//return this.elementHolder.FindAll(scope, condition);
			IMySuperCollection adapterCollection = null; // = new MySuperCollection(this.elementHolder.FindAll(scope, condition));
			return adapterCollection;
		}

		public AutomationProperty[] GetSupportedProperties()
		{
			//return this.elementHolder.GetSupportedProperties();
			return null;
		}

		public AutomationPattern[] GetSupportedPatterns()
		{
			//return this.elementHolder.GetSupportedPatterns();
			return null;
		}

		public void SetFocus()
		{
			//this.elementHolder.SetFocus();
		}

		//public bool TryGetClickablePoint(out Point pt)
		public bool TryGetClickablePoint(out System.Windows.Point pt)
		{
			//return this.elementHolder.TryGetClickablePoint(out pt);
			pt = new System.Windows.Point();
			return false;
		}

		//public Point GetClickablePoint()
		public System.Windows.Point GetClickablePoint()
		{
			//return this.elementHolder.GetClickablePoint();
			return new System.Windows.Point();
		}

		public AutomationElement.AutomationElementInformation Cached {
			//get { return this.elementHolder.Cached; }
			get { return new AutomationElement.AutomationElementInformation(); }
		}

		public AutomationElement.AutomationElementInformation Current {
			//get { return this.elementHolder.Current; }
			get { return new AutomationElement.AutomationElementInformation(); }
		}

		public AutomationElement CachedParent {
			//get { return this.elementHolder.CachedParent; }
			get { return null; }
		}

		public AutomationElementCollection CachedChildren {
			//get { return this.elementHolder.CachedChildren; }
			get { return null; }
		}

		// static methods and properties
		public static IMySuperWrapper RootElement {
			get { return new MySuperWrapper(AutomationElement.RootElement); }
		}
		
		public static IMySuperWrapper FromPoint(System.Windows.Point pt)
		{
		    return new MySuperWrapper(AutomationElement.FromPoint(pt));
		}
		
		public static IMySuperWrapper FromHandle(IntPtr controlHandle)
		{
		    return new MySuperWrapper(AutomationElement.FromHandle(controlHandle));
		}

//		public AutomationElement SourceElement {
//			get { return this.elementHolder; }
//			set { this.elementHolder = value; }
//		}
		
		public AutomationElement SourceElement { get; set; }
    }
}
