/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/28/2014
 * Time: 5:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests
{
    using System.Windows.Automation;
    using System.Windows;

    /// <summary>
    /// Description of ElementData.
    /// </summary>
    public struct ElementData
    {
        public ControlType Current_ControlType { get; set; }
        public string Current_LocalizedControlType { get; set; }
        public string Current_Name { get; set; }
        public string Current_AcceleratorKey { get; set; }
        public string Current_AccessKey { get; set; }
        public bool Current_HasKeyboardFocus { get; set; }
        public bool Current_IsKeyboardFocusable { get; set; }
        public bool Current_IsEnabled { get; set; }
        public Rect Current_BoundingRectangle { get; set; }
        public string Current_HelpText { get; set; }
        public bool Current_IsControlElement { get; set; }
        public bool Current_IsContentElement { get; set; }
        public AutomationElement Current_LabeledBy { get; set; }
        public string Current_AutomationId { get; set; }
        public string Current_ItemType { get; set; }
        public bool Current_IsPassword { get; set; }
        public string Current_ClassName { get; set; }
        public int Current_NativeWindowHandle { get; set; }
        public int Current_ProcessId { get; set; }
        public bool Current_IsOffscreen { get; set; }
        public OrientationType Current_Orientation { get; set; }
        public string Current_FrameworkId { get; set; }
        public bool Current_IsRequiredForForm { get; set; }
        public string Current_ItemStatus { get; set; }
        
        public string Current_Value { get; set; }
        
        public ControlType Cached_ControlType { get; set; }
        public string Cached_LocalizedControlType { get; set; }
        public string Cached_Name { get; set; }
        public string Cached_AcceleratorKey { get; set; }
        public string Cached_AccessKey { get; set; }
        public bool Cached_HasKeyboardFocus { get; set; }
        public bool Cached_IsKeyboardFocusable { get; set; }
        public bool Cached_IsEnabled { get; set; }
        public Rect Cached_BoundingRectangle { get; set; }
        public string Cached_HelpText { get; set; }
        public bool Cached_IsControlElement { get; set; }
        public bool Cached_IsContentElement { get; set; }
        public AutomationElement Cached_LabeledBy { get; set; }
        public string Cached_AutomationId { get; set; }
        public string Cached_ItemType { get; set; }
        public bool Cached_IsPassword { get; set; }
        public string Cached_ClassName { get; set; }
        public int Cached_NativeWindowHandle { get; set; }
        public int Cached_ProcessId { get; set; }
        public bool Cached_IsOffscreen { get; set; }
        public OrientationType Cached_Orientation { get; set; }
        public string Cached_FrameworkId { get; set; }
        public bool Cached_IsRequiredForForm { get; set; }
        public string Cached_ItemStatus { get; set; }
        
        public string Cached_Value { get; set; }
    }
}
