/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 07/12/2011
 * Time: 07:51 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace UIAutomation.UnitTests
{
    /// <summary>
    /// Description of AutomationElement.
    /// </summary>
    public class AutomationElement
    {
        public AutomationElement()
        {
        }
        
        public System.Windows.Automation.AutomationElement.AutomationElementInformation Cached
        { get; set; }
        
// public System.Windows.Automation.AutomationElementCollection CachedChildren
// {
// get { return ((System.Windows.Automation.AutomationElementCollection)(new UIAutomation.UnitTests.AutomationElementCollection())); }
// set { }
// }
        
        public System.Windows.Automation.AutomationElement CachedParent
        { get; set; }
        
        public System.Windows.Automation.AutomationElement.AutomationElementInformation Current
        {
            get { return (new System.Windows.Automation.AutomationElement.AutomationElementInformation()); }
            set { }
        }
        
    }
    
    public class AutomationElementCollection
    {
        public AutomationElementCollection()
        {
            // return ((System.Windows.Automation.AutomationElementCollection)this);
        }
        public int Count { get; set; }
        public bool IsSynchronized { get; set; }
        public object SyncRoot { get; set; }
        // public int Count { get; set; }
        // public int Count { get; set; }
    }
    
    public class AutomationElementInformation
    {
        public string AcceleratorKey { get; set; }
        public string AccessKey { get; set; }
        public string AutomationId { get; set; }
        public System.Windows.Rect BoundingRectangle { get; set; }
        public string ClassName { get; set; }
        public System.Windows.Automation.ControlType ControlType { get; set; }
        public string FrameworkId { get; set; }
        public bool HasKeyboardFocus { get; set; }
        public string HelpText { get; set; }
        public bool IsContentElement { get; set; }
        public bool IsControlElement { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsKeyboardFocusable { get; set; }
        public bool IsOffscreen { get; set; }
        public bool IsPassword { get; set; }
        public bool IsRequiredForForm { get; set; }
        public string ItemStatus { get; set; }
        public string ItemType { get; set; }
        public System.Windows.Automation.AutomationElement LabeledBy { get; set; }
        public string LocalizedControlType { get; set; }        
        public string Name { get; set; }
        public int NativeWindowHandle { get; set; }
        public System.Windows.Automation.OrientationType Orientation { get; set; }
        public int ProcessId { get; set; }
        
        // 20120206 System.Windows.Automation.AutomationElement elt;
        // elt.CachedChildren.IsSynchronized bool
        // elt.CachedChildren.SyncRoot
        // elt.CachedChildren.
        // System.Drawing.Rectangle
        // System.Windows.Rect
        // elt.Cached elementinfo
        // elt.CachedChildren coll
        // elt.CachedParent elt
        // elt.Current info
        // System.Windows.Automation.AutomationElement.AutomationElementInformation info = 
        // new System.Windows.Automation.AutomationElement.AutomationElementInformation();
        // info.AcceleratorKey string
        // info.AccessKey string
        // info.AutomationId
        // info.BoundingRectangle Rect
        // info.ClassName strig
        // info.ControlType
        // info.FrameworkId string
        // info.HasKeyboardFocus bool
        // info.HelpText string
        
        // info.IsContentElement
        // info.IsControlElement
        // info.IsEnabled
        // info.IsKeyboardFocusable
        // info.IsOffscreen
        // info.IsPassword
        // info.IsRequiredForForm
        
        // info.ItemStatus string
        // info.ItemType string
        // info.LabeledBy ae
        // info.LocalizedControlType string
        // info.Name
        // info.NativeWindowHandle int
        // info.Orientation OrientationType
        // info.ProcessId int
    }
}
