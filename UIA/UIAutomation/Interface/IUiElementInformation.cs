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
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System.Windows;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    
    public interface IUiElementInformation
    {
        classic.ControlType ControlType { get; }
        string LocalizedControlType { get; }
        string Name { get; }
        string AcceleratorKey { get; }
        string AccessKey { get; }
        bool HasKeyboardFocus { get; }
        bool IsKeyboardFocusable { get; }
        bool IsEnabled { get; }
        Rect BoundingRectangle { get; }
        string HelpText { get; }
        bool IsControlElement { get; }
        bool IsContentElement { get; }
        classic.AutomationElement LabeledBy { get; }
        string AutomationId { get; }
        string ItemType { get; }
        bool IsPassword { get; }
        string ClassName { get; }
        int NativeWindowHandle { get; }
        int ProcessId { get; }
        bool IsOffscreen { get; }
        classic.OrientationType Orientation { get; }
        string FrameworkId { get; }
        bool IsRequiredForForm { get; }
        string ItemStatus { get; }
    }
}
