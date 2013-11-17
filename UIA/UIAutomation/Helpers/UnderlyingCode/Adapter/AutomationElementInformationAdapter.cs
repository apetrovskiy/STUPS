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
	using Ninject;
    
    public struct MySuperWrapperInformation : IMySuperWrapperInformation
    //public class MySuperWrapperInformation : IMySuperWrapperInformation
    {
    	//private AutomationElement _el;
    	//private bool _useCache;
    	
    	private AutomationElement.AutomationElementInformation infoHolder;
    	//
    	[Inject]
    	public MySuperWrapperInformation(AutomationElement.AutomationElementInformation information)
    	{
    	    this.infoHolder = information;
    	}
    	//
    	
    	public ControlType ControlType
    	{
    	   get { return this.infoHolder.ControlType; }
    	}
    	public string LocalizedControlType
    	{
    	    get { return this.infoHolder.LocalizedControlType; }
    	}
    	public string Name
    	{
    	    get { return this.infoHolder.Name; }
    	}
    	public string AcceleratorKey
    	{
    	    get { return this.infoHolder.AcceleratorKey; }
    	}
    	public string AccessKey
    	{
    	    get { return this.infoHolder.AccessKey; }
    	}
    	public bool HasKeyboardFocus
    	{
    	    get { return this.infoHolder.HasKeyboardFocus; }
    	}
    	public bool IsKeyboardFocusable
    	{
    	    get { return this.infoHolder.IsKeyboardFocusable; }
    	}
    	public bool IsEnabled
    	{
    	    get { return this.infoHolder.IsEnabled; }
    	}
    	public Rect BoundingRectangle
    	{
    	    get { return this.infoHolder.BoundingRectangle; }
    	}
    	public string HelpText
    	{
    	    get { return this.infoHolder.HelpText; }
    	}
    	public bool IsControlElement
    	{
    	    get { return this.infoHolder.IsControlElement; }
    	}
    	public bool IsContentElement
    	{
    	    get { return this.infoHolder.IsContentElement; }
    	}
    	public AutomationElement LabeledBy
    	{
    	    get { return this.infoHolder.LabeledBy; }
    	}
    	public string AutomationId
    	{
    	    get { return this.infoHolder.AutomationId; }
    	}
    	public string ItemType
    	{
    	    get { return this.infoHolder.ItemType; }
    	}
    	public bool IsPassword
    	{
    	    get { return this.infoHolder.IsPassword; }
    	}
    	public string ClassName
    	{
    	    get { return this.infoHolder.ClassName; }
    	}
    	public int NativeWindowHandle
    	{
    	    get { return this.infoHolder.NativeWindowHandle; }
    	}
    	public int ProcessId
    	{
    	    get { return this.infoHolder.ProcessId; }
    	}
    	public bool IsOffscreen
    	{
    	    get { return this.infoHolder.IsOffscreen; }
    	}
    	public OrientationType Orientation
    	{
    	    get { return this.infoHolder.Orientation; }
    	}
    	public string FrameworkId
    	{
    	    get { return this.infoHolder.FrameworkId; }
    	}
    	public bool IsRequiredForForm
    	{
    	    get { return this.infoHolder.IsRequiredForForm; }
    	}
    	public string ItemStatus
    	{
    	    get { return this.infoHolder.ItemStatus; }
    	}
    	
    	public AutomationElement.AutomationElementInformation SourceInformation
    	{
    	    get { return this.infoHolder; }
    	    set { this.infoHolder = value; }
    	}
    }
}