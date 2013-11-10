/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/11/2013
 * Time: 12:28 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
	using System;
	using System.Windows;
	using System.Windows.Automation;

#region commented
	/// <summary>
	/// Description of MySuperWrapperInformation.
	/// </summary>
//	public struct MySuperWrapperInformation : IEquatable<MySuperWrapperInformation>
//	{
//		int member;
//		// this is just an example member, replace it with your own struct members!
//		#region Equals and GetHashCode implementation
//		// The code in this region is useful if you want to use this structure in collections.
//		// If you don't need it, you can just remove the region and the ": IEquatable<MySuperWrapperInformation>" declaration.
//
//		public override bool Equals(object obj)
//		{
//			if (obj is MySuperWrapperInformation)
//				return Equals((MySuperWrapperInformation)obj);
//			else
//				// use Equals method below
//				return false;
//		}
//
//		public bool Equals(MySuperWrapperInformation other)
//		{
//			// add comparisions for all members here
//			return this.member == other.member;
//		}
//
//		public override int GetHashCode()
//		{
//			// combine the hash codes of all members here (e.g. with XOR operator ^)
//			return member.GetHashCode();
//		}
//
//		public static bool operator ==(MySuperWrapperInformation left, MySuperWrapperInformation right)
//		{
//			return left.Equals(right);
//		}
//
//		public static bool operator !=(MySuperWrapperInformation left, MySuperWrapperInformation right)
//		{
//			return !left.Equals(right);
//		}
//		#endregion
//	}
#endregion commented

    public struct AutomationElementInformation : IMySuperWrapperInformation
    {
    	//private AutomationElement _el;
    	//private bool _useCache;
    	public ControlType ControlType { get; set; }
    	//	get { return (ControlType)this._el.GetPatternPropertyValue(AutomationElement.ControlTypeProperty, this._useCache); }
    	//}
    	public string LocalizedControlType { get; set; }
    	//	get { return (string)this._el.GetPatternPropertyValue(AutomationElement.LocalizedControlTypeProperty, this._useCache); }
    	//}
    	public string Name { get; set; }
    	//	get { return (string)this._el.GetPatternPropertyValue(AutomationElement.NameProperty, this._useCache); }
    	//}
    	public string AcceleratorKey { get; set; }
    	//	get { return (string)this._el.GetPatternPropertyValue(AutomationElement.AcceleratorKeyProperty, this._useCache); }
    	//}
    	public string AccessKey { get; set; }
    	//	get { return (string)this._el.GetPatternPropertyValue(AutomationElement.AccessKeyProperty, this._useCache); }
    	//}
    	public bool HasKeyboardFocus { get; set; }
    	//	get { return (bool)this._el.GetPatternPropertyValue(AutomationElement.HasKeyboardFocusProperty, this._useCache); }
    	//}
    	public bool IsKeyboardFocusable { get; set; }
    	//	get { return (bool)this._el.GetPatternPropertyValue(AutomationElement.IsKeyboardFocusableProperty, this._useCache); }
    	//}
    	public bool IsEnabled { get; set; }
    	//	get { return (bool)this._el.GetPatternPropertyValue(AutomationElement.IsEnabledProperty, this._useCache); }
    	//}
    	public Rect BoundingRectangle { get; set; }
    	//	get { return (Rect)this._el.GetPatternPropertyValue(AutomationElement.BoundingRectangleProperty, this._useCache); }
    	//}
    	public string HelpText { get; set; }
    	//	get { return (string)this._el.GetPatternPropertyValue(AutomationElement.HelpTextProperty, this._useCache); }
    	//}
    	public bool IsControlElement { get; set; }
    	//	get { return (bool)this._el.GetPatternPropertyValue(AutomationElement.IsControlElementProperty, this._useCache); }
    	//}
    	public bool IsContentElement { get; set; }
    	//	get { return (bool)this._el.GetPatternPropertyValue(AutomationElement.IsContentElementProperty, this._useCache); }
    	//}
    	public AutomationElement LabeledBy { get; set; }
    	//	get { return (AutomationElement)this._el.GetPatternPropertyValue(AutomationElement.LabeledByProperty, this._useCache); }
    	//}
    	public string AutomationId { get; set; }
    	//	get { return (string)this._el.GetPatternPropertyValue(AutomationElement.AutomationIdProperty, this._useCache); }
    	//}
    	public string ItemType { get; set; }
    	//	get { return (string)this._el.GetPatternPropertyValue(AutomationElement.ItemTypeProperty, this._useCache); }
    	//}
    	public bool IsPassword { get; set; }
    	//	get { return (bool)this._el.GetPatternPropertyValue(AutomationElement.IsPasswordProperty, this._useCache); }
    	//}
    	public string ClassName { get; set; }
    	//	get { return (string)this._el.GetPatternPropertyValue(AutomationElement.ClassNameProperty, this._useCache); }
    	//}
    	public int NativeWindowHandle { get; set; }
    	//	get { return (int)this._el.GetPatternPropertyValue(AutomationElement.NativeWindowHandleProperty, this._useCache); }
    	//}
    	public int ProcessId { get; set; }
    	//	get { return (int)this._el.GetPatternPropertyValue(AutomationElement.ProcessIdProperty, this._useCache); }
    	//}
    	public bool IsOffscreen { get; set; }
    	//	get { return (bool)this._el.GetPatternPropertyValue(AutomationElement.IsOffscreenProperty, this._useCache); }
    	//}
    	public OrientationType Orientation { get; set; }
    	//	get { return (OrientationType)this._el.GetPatternPropertyValue(AutomationElement.OrientationProperty, this._useCache); }
    	//}
    	public string FrameworkId { get; set; }
    	//	get { return (string)this._el.GetPatternPropertyValue(AutomationElement.FrameworkIdProperty, this._useCache); }
    	//}
    	public bool IsRequiredForForm { get; set; }
    	//	get { return (bool)this._el.GetPatternPropertyValue(AutomationElement.IsRequiredForFormProperty, this._useCache); }
    	//}
    	public string ItemStatus { get; set; }
    	//	get { return (string)this._el.GetPatternPropertyValue(AutomationElement.ItemStatusProperty, this._useCache); }
    	//}
    	//internal AutomationElementInformation(AutomationElement el, bool useCache)
    	//{
    	//	this._el = el;
    	//	this._useCache = useCache;
    	//}
    }
}