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
    using Ninject;
    
    public struct UiElementInformation : IUiElementInformation
    {
        //private AutomationElement _el;
        //private bool _useCache;
        private classic.AutomationElement.AutomationElementInformation _infoHolder;
        //
        [Inject]
        public UiElementInformation(classic.AutomationElement.AutomationElementInformation information)
        {
            _infoHolder = information;
        }
        //
        
        public classic.ControlType ControlType
        {
           get { return _infoHolder.ControlType; }
        }
        public string LocalizedControlType
        {
            get { return _infoHolder.LocalizedControlType; }
        }
        public string Name
        {
            get { return _infoHolder.Name; }
        }
        public string AcceleratorKey
        {
            get { return _infoHolder.AcceleratorKey; }
        }
        public string AccessKey
        {
            get { return _infoHolder.AccessKey; }
        }
        public bool HasKeyboardFocus
        {
            get { return _infoHolder.HasKeyboardFocus; }
        }
        public bool IsKeyboardFocusable
        {
            get { return _infoHolder.IsKeyboardFocusable; }
        }
        public bool IsEnabled
        {
            get { return _infoHolder.IsEnabled; }
        }
        public Rect BoundingRectangle
        {
            get { return _infoHolder.BoundingRectangle; }
        }
        public string HelpText
        {
            get { return _infoHolder.HelpText; }
        }
        public bool IsControlElement
        {
            get { return _infoHolder.IsControlElement; }
        }
        public bool IsContentElement
        {
            get { return _infoHolder.IsContentElement; }
        }
        public classic.AutomationElement LabeledBy
        {
            get { return _infoHolder.LabeledBy; }
        }
        public string AutomationId
        {
            get { return _infoHolder.AutomationId; }
        }
        public string ItemType
        {
            get { return _infoHolder.ItemType; }
        }
        public bool IsPassword
        {
            get { return _infoHolder.IsPassword; }
        }
        public string ClassName
        {
            get { return _infoHolder.ClassName; }
        }
        public int NativeWindowHandle
        {
            get { return _infoHolder.NativeWindowHandle; }
        }
        public int ProcessId
        {
            get { return _infoHolder.ProcessId; }
        }
        public bool IsOffscreen
        {
            get { return _infoHolder.IsOffscreen; }
        }
        public classic.OrientationType Orientation
        {
            get { return _infoHolder.Orientation; }
        }
        public string FrameworkId
        {
            get { return _infoHolder.FrameworkId; }
        }
        public bool IsRequiredForForm
        {
            get { return _infoHolder.IsRequiredForForm; }
        }
        public string ItemStatus
        {
            get { return _infoHolder.ItemStatus; }
        }
        
        public classic.AutomationElement.AutomationElementInformation SourceInformation
        {
            get { return _infoHolder; }
            set { _infoHolder = value; }
        }
    }
}