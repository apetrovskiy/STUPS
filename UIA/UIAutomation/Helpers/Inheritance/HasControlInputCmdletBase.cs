/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08.12.2011
 * Time: 8:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;
    using System.Management.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    using System.Runtime.InteropServices;
    
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using Commands;
    using PSTestLib;

    #region declarations
        [StructLayout(LayoutKind.Sequential)]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "MOUSEINPUT")]
        internal struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "KEYBDINPUT")]
        internal struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "HARDWAREINPUT")]
        internal struct HARDWAREINPUT
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }

        
        [StructLayout(LayoutKind.Explicit)]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "MOUSEKEYBDHARDWAREINPUT")]
        internal struct MOUSEKEYBDHARDWAREINPUT
        {
            [FieldOffset(0)]
            public MOUSEINPUT Mouse;

            [FieldOffset(0)]
            public KEYBDINPUT Keyboard;

            [FieldOffset(0)]
            public HARDWAREINPUT Hardware;
        }

        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "INPUT")]
        internal struct INPUT
        {
            public UInt32 Type;
            public MOUSEKEYBDHARDWAREINPUT Data;
        }
    #endregion declarations
    
    /// <summary>
    /// Description of HasControlInputCmdletBase.
    /// </summary>
    public class HasControlInputCmdletBase : HasScriptBlockCmdletBase
    {
        #region Constructor
        public HasControlInputCmdletBase()
        {
            InputObject = null;
            PassThru = true;
        }
        #endregion Constructor
        
        #region Parameters
        [ValidateNotNullOrEmpty()]
        [UiaParameter][Parameter(Mandatory = false, 
            ValueFromPipeline = true,
            HelpMessage = "This is usually the output from Get-UiaControl" )] 
        //public System.Windows.Automation.AutomationElement[] InputObject { get; set; }
        //public ICollection InputObject { get; set; }
        // 20131213
        // 20140130
        public IUiElement[] InputObject { get; set; }
        // public virtual IUiElement[] InputObject { get; set; }
        // public Castle.DynamicProxy.
        /*
        public UiElement[] InputObject { get; set; }
        */
        [UiaParameter][Parameter(Mandatory = false)]
        public virtual SwitchParameter PassThru { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false)]
        public ScriptBlock[] EventAction { get; set; }
        #endregion Parameters
        
        protected override void StopProcessing()
        {
            WriteVerbose(this, "User interrupted");
        }
        
        #region Properties
        protected internal classic.AutomationEvent AutomationEventType { get; set; }
        // 20140217
        // protected internal AutomationProperty AutomationProperty { get; set; }
        protected internal classic.AutomationProperty[] AutomationProperty { get; set; }
        protected internal classic.AutomationEventHandler AutomationEventHandler { get; set; }
        protected internal classic.AutomationPropertyChangedEventHandler AutomationPropertyChangedEventHandler { get; set; }
        protected internal classic.StructureChangedEventHandler StructureChangedEventHandler { get; set; }
        protected RegisterUiaStructureChangedEventCommand Child { get; set; }
        #endregion Properties
        
        protected bool GetColorProbe(HasControlInputCmdletBase cmdlet,
                                     IUiElement element)
        {
            bool result = false;
            
            //NativeMethods.getpi
            
            
            
            return result;
        }
        
        protected internal bool ClickControl(HasControlInputCmdletBase cmdlet,
                                    IUiElement element,
                                    ClickSettings settings)
        {
            bool result = false;
            
            if (-1000000 == settings.RelativeX) {
                settings.RelativeX = Preferences.ClickOnControlByCoordX;
            }
            if (-1000000 == settings.RelativeY) {
                settings.RelativeY = Preferences.ClickOnControlByCoordY;
            }
            
            IUiElement whereToClick = 
                element;
            IUiElement whereTheHandle = 
                whereToClick;
            
            // 20140312
            // if (whereToClick.Current.NativeWindowHandle == 0) {
            if (whereToClick.GetCurrent().NativeWindowHandle == 0) {
                
                whereTheHandle =
                    whereToClick.GetAncestorWithHandle();
                // 20140312
                // if (whereTheHandle.Current.NativeWindowHandle == 0) {
                if (whereTheHandle.GetCurrent().NativeWindowHandle == 0) {
                    
                    WriteError(
                        this,
                        "The handle of this control equals to zero",
                        "ZeroHandle",
                        ErrorCategory.InvalidArgument,
                        true);

                    // TODO: WriteError(...)
                } else {
//                    WriteVerbose(cmdlet, 
//                                 "the control with a handle is " + 
//                                 whereTheHandle.Current.Name);
//                    WriteVerbose(cmdlet, 
//                                 "its handle is " + 
//                                 whereTheHandle.Current.NativeWindowHandle.ToString());
//                    WriteVerbose(cmdlet, 
//                                 "its rectangle is " + 
//                                 whereTheHandle.Current.BoundingRectangle.ToString());
                }
            }
            
            int x = 0;
            int y = 0;
            // these x and y are window-related coordinates
            if (settings.RelativeX != 0 && settings.RelativeY != 0) {
                // 20140312
//                x = settings.RelativeX + (int)whereToClick.Current.BoundingRectangle.X;
//                y = settings.RelativeY + (int)whereToClick.Current.BoundingRectangle.Y;
                x = settings.RelativeX + (int)whereToClick.GetCurrent().BoundingRectangle.X;
                y = settings.RelativeY + (int)whereToClick.GetCurrent().BoundingRectangle.Y;
            } else {
                // these x and y are for the SetCursorPos call
                // they are screen coordinates
                // 20140312
//                x = (int)whereToClick.Current.BoundingRectangle.X + 
//                    ((int)whereToClick.Current.BoundingRectangle.Width / 2); // + 3;
//                y = (int)whereToClick.Current.BoundingRectangle.Y + 
//                    ((int)whereToClick.Current.BoundingRectangle.Height / 2); // + 3;
                x = (int)whereToClick.GetCurrent().BoundingRectangle.X + 
                    ((int)whereToClick.GetCurrent().BoundingRectangle.Width / 2); // + 3;
                y = (int)whereToClick.GetCurrent().BoundingRectangle.Y + 
                    ((int)whereToClick.GetCurrent().BoundingRectangle.Height / 2); // + 3;
            }
            // if the -X and -Y paramters are supplied (only for SetCursorPos)
            
            // PostMessage's (click) second parameter
            uint uDown = 0;
            uint uUp = 0;
            
            // these relative coordinates for SendMessage/PostMessage
            // 20140312
//            settings.RelativeX = x - (int)whereTheHandle.Current.BoundingRectangle.X;
//            settings.RelativeY = y - (int)whereTheHandle.Current.BoundingRectangle.Y;
            settings.RelativeX = x - (int)whereTheHandle.GetCurrent().BoundingRectangle.X;
            settings.RelativeY = y - (int)whereTheHandle.GetCurrent().BoundingRectangle.Y;
            
            // PostMessage's (click) third and fourth paramters (the third'll be reasigned later)
            IntPtr wParamDown = IntPtr.Zero;
            IntPtr wParamUp = IntPtr.Zero;
            var lParam =
                new IntPtr(((new IntPtr(settings.RelativeX)).ToInt32() & 0xFFFF) +
                           (((new IntPtr(settings.RelativeY)).ToInt32() & 0xFFFF) << 16));
            
            /*
            IntPtr lParam = 
                new IntPtr(((new IntPtr(settings.RelativeX)).ToInt32() & 0xFFFF) +
                           (((new IntPtr(settings.RelativeY)).ToInt32() & 0xFFFF) << 16));
            */
            
            // PostMessage's (keydown/keyup) fourth parameter
            const uint uCtrlDown = 0x401D;
            const uint uCtrlUp = 0xC01D;
            const uint uShiftDown = 0x402A;
            const uint uShiftUp = 0xC02A;
            IntPtr lParamKeyDown = IntPtr.Zero;
            IntPtr lParamKeyUp = IntPtr.Zero;
            
            if (settings.Ctrl) {
                lParamKeyDown = 
                    new IntPtr(((new IntPtr(0x0001)).ToInt32() & 0xFFFF) +
                               (((new IntPtr(uCtrlDown)).ToInt32() & 0xFFFF) << 16));
                lParamKeyUp = 
                    new IntPtr(((new IntPtr(0x0001)).ToInt32() & 0xFFFF) +
                               (((new IntPtr(uCtrlUp)).ToInt32() & 0xFFFF) << 16));
            }
            if (settings.Shift) {
                lParamKeyDown = 
                    new IntPtr(((new IntPtr(0x0001)).ToInt32() & 0xFFFF) +
                               (((new IntPtr(uShiftDown)).ToInt32() & 0xFFFF) << 16));
                lParamKeyUp = 
                    new IntPtr(((new IntPtr(0x0001)).ToInt32() & 0xFFFF) +
                               (((new IntPtr(uShiftUp)).ToInt32() & 0xFFFF) << 16));
            }
            // PostMessage's (activate) third parameter
            uint ulAct = 0;
            uint uhAct = 0;
            
            uint mask = 0;
            if (settings.Ctrl) {
                mask |= NativeMethods.MK_CONTROL;
            }
            if (settings.Shift) {
                mask |= NativeMethods.MK_SHIFT;
            }
            
            if (settings.RightClick && !settings.DoubleClick) {
                uhAct = uDown = NativeMethods.WM_RBUTTONDOWN;
                uUp = NativeMethods.WM_RBUTTONUP;
                wParamDown = new IntPtr(NativeMethods.MK_RBUTTON | mask);
                wParamUp = new IntPtr(mask);
                ulAct = NativeMethods.MK_RBUTTON;
            } else if (settings.RightClick && settings.DoubleClick) {
                uhAct = uDown = NativeMethods.WM_RBUTTONDBLCLK;
                uUp = NativeMethods.WM_RBUTTONUP;
                wParamDown = new IntPtr(NativeMethods.MK_RBUTTON | mask);
                wParamUp = new IntPtr(mask);
                ulAct = NativeMethods.MK_RBUTTON;
            } else if (settings.MidClick && !settings.DoubleClick) {
                uhAct = uDown = NativeMethods.WM_MBUTTONDOWN;
                uUp = NativeMethods.WM_MBUTTONUP;
                wParamDown = new IntPtr(NativeMethods.MK_MBUTTON | mask);
                wParamUp = new IntPtr(mask);
                ulAct = NativeMethods.MK_MBUTTON;
            } else if (settings.MidClick && settings.DoubleClick) {
                uhAct = uDown = NativeMethods.WM_MBUTTONDBLCLK;
                uUp = NativeMethods.WM_MBUTTONUP;
                wParamDown = new IntPtr(NativeMethods.MK_MBUTTON | mask);
                wParamUp = new IntPtr(mask);
                ulAct = NativeMethods.MK_MBUTTON;
            } else if (settings.DoubleClick) {
                uhAct = uDown = NativeMethods.WM_LBUTTONDBLCLK;
                uUp = NativeMethods.WM_LBUTTONUP;
                wParamDown = new IntPtr(NativeMethods.MK_LBUTTON | mask);
                wParamUp = new IntPtr(mask);
                ulAct = NativeMethods.MK_LBUTTON;
            } else {
                uhAct = uDown = NativeMethods.WM_LBUTTONDOWN;
                uUp = NativeMethods.WM_LBUTTONUP;
                wParamDown = new IntPtr(NativeMethods.MK_LBUTTON | mask);
                wParamUp = new IntPtr(mask);
                ulAct = NativeMethods.MK_LBUTTON;
            }
            
            // 20140312
            // var handle = new IntPtr(whereTheHandle.Current.NativeWindowHandle);
            var handle = new IntPtr(whereTheHandle.GetCurrent().NativeWindowHandle);
            /*
            IntPtr handle =
                    new IntPtr(whereTheHandle.Current.NativeWindowHandle);
            */
            
            try {
                whereTheHandle.SetFocus();
            } 
            catch { }
            
            bool setCursorPosResult = 
                NativeMethods.SetCursorPos(x, y);
//            WriteVerbose(cmdlet, "SetCursorPos result = " + setCursorPosResult.ToString());
            
            Thread.Sleep(Preferences.OnClickDelay);
            
            // trying to heal context menu clicks
            Process windowProcess = 
                Process.GetProcessById(
                    // 20140312
                    // whereTheHandle.Current.ProcessId);
                    whereTheHandle.GetCurrent().ProcessId);
            if (windowProcess != null) {
                IntPtr mainWindow = 
                    windowProcess.MainWindowHandle;
                if (mainWindow != IntPtr.Zero) {
                    
                    var lParam2 = 
                        new IntPtr(((new IntPtr(ulAct)).ToInt32() & 0xFFFF) +
                                   (((new IntPtr(uhAct)).ToInt32() & 0xFFFF) << 16));
                    /*
                    IntPtr lParam2 = 
                        new IntPtr(((new IntPtr(ulAct)).ToInt32() & 0xFFFF) +
                                   (((new IntPtr(uhAct)).ToInt32() & 0xFFFF) << 16));
                    */
                    bool res0 = 
                        NativeMethods.PostMessage1(handle, NativeMethods.WM_MOUSEACTIVATE, 
                                     mainWindow, lParam2);
//                    WriteVerbose(this, "WM_MOUSEACTIVATE is sent");
                }
            }
            
            if (settings.Ctrl) {
                // press the control key
                NativeMethods.keybd_event((byte)NativeMethods.VK_LCONTROL, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | 0, 0);
//                WriteVerbose(this, " the Control button has been pressed");
            }
            if (settings.Shift) {
                // press the settings.Shift key
                NativeMethods.keybd_event((byte)NativeMethods.VK_LSHIFT, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | 0, 0);
//                WriteVerbose(this, " the Shift button has been pressed");
            }
            
            // // 20120620 for Home Tab
            bool res1 = NativeMethods.PostMessage1(handle, uDown, wParamDown, lParam);
            
            int interval = settings.DoubleClickInterval / 2;
            if (settings.DoubleClick) {
                Thread.Sleep(interval);
            }
            
            // MouseMove
            if (settings.RightClick || settings.DoubleClick) {
                bool resMM = NativeMethods.PostMessage1(handle, NativeMethods.WM_MOUSEMOVE, wParamDown, lParam);
            }
            
            // 20131125
            if (settings.DoubleClick) {
                Thread.Sleep(interval);
            }
            
            // // 20120620 for Home Tab
            bool res2 = NativeMethods.PostMessage1(handle, uUp, wParamUp, lParam);
            
            if (!settings.inSequence) {
                if (settings.Ctrl) {
                    // release the control key
                    NativeMethods.keybd_event((byte)NativeMethods.VK_LCONTROL, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP, 0);
//                    WriteVerbose(this, " the Control button has been released");
                }
                if (settings.Shift) {
                    // release the settings.Shift key
                    NativeMethods.keybd_event((byte)NativeMethods.VK_LSHIFT, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP, 0);
//                    WriteVerbose(this, " the Shift button has been released");
                }
            }
            
//            WriteVerbose(cmdlet,
//                         // // 20120620 for Home Tab
//                         // 20130312
//                         "PostMessage " + uDown.ToString() + 
//                         //"SendMessage " + uDown.ToString() + 
//                         " result = " + res1.ToString());
//            WriteVerbose(cmdlet, 
//                         // // 20120620 for Home Tab
//                         // 20130312
//                         "PostMessage " + uUp.ToString() +
//                         //"SendMessage " + uUp.ToString() + 
//                         " result = " + res2.ToString());
            // if (!res1 && !res2) {
            if (res1 && res2) {
                result = true;
            } else {
                result = false;
            }
            
            return result;
        }
        
        internal bool CheckAndPrepareInput(HasControlInputCmdletBase cmdlet)
        {
            bool result = false;
            
            if (null == cmdlet.InputObject) {
                
                WriteVerbose(cmdlet, "[checking the input] Control(s) are null");
                
                cmdlet.WriteError(
                    cmdlet,
                    "The pipeline input is null",
                    "InputIsNull",
                    ErrorCategory.InvalidArgument,
                    true);
                
            }
            
            foreach (var inputObject in cmdlet.InputObject) {
                
                if (null == inputObject) {
                    
                    WriteVerbose(cmdlet, "[checking the input] Control is null");
                    if (PassThru) {
                        
                        WriteObject(this, inputObject);
                    } else {
                        
                        result = false;
                        WriteObject(this, result);
                    }
                    
                    result = false;
                    
                    cmdlet.WriteError(
                        cmdlet,
                        "A part of the pipeline input is null",
                        "PartOfInputIsNull",
                        ErrorCategory.InvalidArgument,
                        false);
                    
                }
                
                // 20131109
                //System.Windows.Automation.AutomationElement _control = null;
                //IUiElement _controlAdapter = null;
                var _controlAdapter = inputObject;
                
                try {
                    
                    // 20131109
                    //_control = 
                    //    (AutomationElement)inputObject;
                    
                    // 20131109
//                    this.WriteVerbose(
//                        cmdlet,
//                        "[checking the input] the input control is of the " +
//                        inputObject.Current.ControlType.ProgrammaticName +
//                        " type");
                    
                    // 20131109
                    //cmdlet.currentWindow = _control;
                    //if (inputObject is IUiElement) {
                    if (null != (inputObject as IUiElement))
                    {
                    /*
                    if (inputObject is IUiElement) {
                    */
                        cmdlet.CurrentInputElement = (IUiElement)_controlAdapter;
                    }
//                    if (inputObject is AutomationElement) {
//                        cmdlet.currentWindow = new UiElement((AutomationElement)inputObject);
//                    }
                    
                    result = true;
                    
                    // there's no need to output the True value
                    // since the output will be what we want 
                    // (some part of AutomationElement, as an example)
                } catch (Exception) {
                    
                    if (PassThru) {
                        
                        // 20131109
                        //WriteObject(this, _control);
                        WriteObject(this, _controlAdapter);
                        
                    } else {
                        
                        result = false;
                        WriteObject(this, result);
                        
                    }
                    result = false;
                    return result;
                }
            
            } // 20120823
            
            return result;
        }
        
        #region subscribe to events
        protected internal void SubscribeToEvents(HasControlInputCmdletBase cmdlet,
                                                  IUiElement inputObject,
                                                  classic.AutomationEvent eventType,
                                                  classic.AutomationProperty[] properties)
        {
            if (null == CurrentData.Events) {
                CurrentData.InitializeEventCollection();
            }
            
            try {
                var cacheRequest = new classic.CacheRequest
                // CacheRequest cacheRequest = new CacheRequest
                {
                    AutomationElementMode = classic.AutomationElementMode.Full,
                    // 20140130
                    // TreeFilter = Automation.RawViewCondition
                    TreeFilter = UiaAutomation.RawViewCondition
                };
                cacheRequest.Add(classic.AutomationElement.NameProperty);
                cacheRequest.Add(classic.AutomationElement.AutomationIdProperty);
                cacheRequest.Add(classic.AutomationElement.ClassNameProperty);
                cacheRequest.Add(classic.AutomationElement.ControlTypeProperty);
                //cacheRequest.Add(AutomationElement.ProcessIdProperty);
                // cache patterns?
                
                // cacheRequest.Activate();
                cacheRequest.Push();
                
                classic.AutomationEventHandler uiaEventHandler;
                switch (eventType.ProgrammaticName) {
                    case "InvokePatternIdentifiers.InvokedEvent":
                        UiaAutomation.AddAutomationEventHandler(
                            classic.InvokePattern.InvokedEvent,
                            inputObject,
                            classic.TreeScope.Element,
                            uiaEventHandler = new classic.AutomationEventHandler(cmdlet.AutomationEventHandler));
                        UiaHelper.WriteEventToCollection(cmdlet, uiaEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    case "TextPatternIdentifiers.TextChangedEvent":
                        UiaAutomation.AddAutomationEventHandler(
                            classic.TextPattern.TextChangedEvent,
                            inputObject,
                            classic.TreeScope.Element,
                            uiaEventHandler = new classic.AutomationEventHandler(cmdlet.AutomationEventHandler));
                        UiaHelper.WriteEventToCollection(cmdlet, uiaEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    case "TextPatternIdentifiers.TextSelectionChangedEvent":
                        UiaAutomation.AddAutomationEventHandler(
                            classic.TextPattern.TextSelectionChangedEvent,
                            inputObject,
                            classic.TreeScope.Element,
                            uiaEventHandler = new classic.AutomationEventHandler(cmdlet.AutomationEventHandler));
                        UiaHelper.WriteEventToCollection(cmdlet, uiaEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    case "WindowPatternIdentifiers.WindowOpenedProperty":
                        UiaAutomation.AddAutomationEventHandler(
                            classic.WindowPattern.WindowOpenedEvent,
                            inputObject,
                            classic.TreeScope.Subtree,
                            uiaEventHandler = new classic.AutomationEventHandler(cmdlet.AutomationEventHandler));
                        UiaHelper.WriteEventToCollection(cmdlet, uiaEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    case "AutomationElementIdentifiers.AutomationPropertyChangedEvent":
                        if (properties != null) {
                            classic.AutomationPropertyChangedEventHandler uiaPropertyChangedEventHandler;
                            UiaAutomation.AddAutomationPropertyChangedEventHandler(
                                inputObject,
                                classic.TreeScope.Subtree,
                                uiaPropertyChangedEventHandler = 
                                    new classic.AutomationPropertyChangedEventHandler(cmdlet.AutomationPropertyChangedEventHandler),
                                properties);
                            UiaHelper.WriteEventToCollection(cmdlet, uiaPropertyChangedEventHandler);
                            if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaPropertyChangedEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        }
                        break;
                    case "AutomationElementIdentifiers.StructureChangedEvent":
                        classic.StructureChangedEventHandler uiaStructureChangedEventHandler;
                        UiaAutomation.AddStructureChangedEventHandler(
                            inputObject,
                            classic.TreeScope.Subtree,
                            uiaStructureChangedEventHandler = 
                            new classic.StructureChangedEventHandler(cmdlet.StructureChangedEventHandler));
                        UiaHelper.WriteEventToCollection(cmdlet, uiaStructureChangedEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaStructureChangedEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    case "WindowPatternIdentifiers.WindowClosedProperty":
                        UiaAutomation.AddAutomationEventHandler(
                            classic.WindowPattern.WindowClosedEvent,
                            inputObject,
                            classic.TreeScope.Subtree,
                            uiaEventHandler = new classic.AutomationEventHandler(cmdlet.AutomationEventHandler));
                        UiaHelper.WriteEventToCollection(cmdlet, uiaEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    case "AutomationElementIdentifiers.MenuClosedEvent":
                        UiaAutomation.AddAutomationEventHandler(
                            classic.AutomationElement.MenuClosedEvent,
                            inputObject,
                            classic.TreeScope.Subtree,
                            uiaEventHandler = new classic.AutomationEventHandler(cmdlet.AutomationEventHandler));
                        UiaHelper.WriteEventToCollection(cmdlet, uiaEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    case "AutomationElementIdentifiers.MenuOpenedEvent":
                        UiaAutomation.AddAutomationEventHandler(
                            classic.AutomationElement.MenuOpenedEvent,
                            inputObject,
                            classic.TreeScope.Subtree,
                            uiaEventHandler = new classic.AutomationEventHandler(cmdlet.AutomationEventHandler));
                        UiaHelper.WriteEventToCollection(cmdlet, uiaEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    case "AutomationElementIdentifiers.ToolTipClosedEvent":
                        UiaAutomation.AddAutomationEventHandler(
                            classic.AutomationElement.ToolTipClosedEvent,
                            inputObject,
                            classic.TreeScope.Subtree,
                            uiaEventHandler = new classic.AutomationEventHandler(cmdlet.AutomationEventHandler));
                        UiaHelper.WriteEventToCollection(cmdlet, uiaEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    case "AutomationElementIdentifiers.ToolTipOpenedEvent":
                        UiaAutomation.AddAutomationEventHandler(
                            classic.AutomationElement.ToolTipOpenedEvent,
                            inputObject,
                            classic.TreeScope.Subtree,
                            uiaEventHandler = new classic.AutomationEventHandler(cmdlet.AutomationEventHandler));
                        UiaHelper.WriteEventToCollection(cmdlet, uiaEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    case "AutomationElementIdentifiers.AutomationFocusChangedEvent":
                        classic.AutomationFocusChangedEventHandler uiaFocusChangedEventHandler;
                        UiaAutomation.AddAutomationFocusChangedEventHandler(
                            uiaFocusChangedEventHandler = new classic.AutomationFocusChangedEventHandler(cmdlet.AutomationEventHandler));
                        UiaHelper.WriteEventToCollection(cmdlet, uiaFocusChangedEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaFocusChangedEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    default:
                        WriteVerbose(cmdlet, 
                                     "the following event has not been subscribed to: " + 
                                     eventType.ProgrammaticName);
                        break;
                }
                cacheRequest.Pop();
                
            } 
            catch (Exception e) {
                
                WriteVerbose(cmdlet,
                              "Unable to register event handler " +
                              eventType.ProgrammaticName +
                              " for " +
                    // 20140312
                              // inputObject.Current.Name);
                    inputObject.GetCurrent().Name);
                 WriteVerbose(cmdlet,
                              e.Message);
            }
        }
        #endregion subscribe to events
    
        #region OnUIAutomationEvent
        protected void OnUIAutomationEvent(object src, classic.AutomationEventArgs e)
        {
            if (!checkNotNull(src, e)) return;
            RunEventScriptBlocks(this);
            try {
                WriteVerbose(this, e.EventId + " on " + (src as classic.AutomationElement) + " fired");
            } catch { }
        }
        #endregion OnUIAutomationEvent
        
        #region OnUIAutomationPropertyChangedEvent
        protected void OnUIAutomationPropertyChangedEvent(object src, classic.AutomationPropertyChangedEventArgs e)
        {
            if (!checkNotNull(src, e)) return;
            // 20140217
            // if (AutomationProperty == e.Property) {
            if (AutomationProperty.Contains(e.Property)) {
                
                
try {
    WriteVerbose(this, "RunEventScriptBlocks(this) ran");
} catch { }
                
                
                RunEventScriptBlocks(this);
            }
            try {
                WriteVerbose(this, e.EventId + "on " + (src as classic.AutomationElement) + " fired");
            } catch { }
        }
        #endregion OnUIAutomationPropertyChangedEvent
        
        #region OnUIStructureChangedEvent
        protected void OnUIStructureChangedEvent(object src, classic.StructureChangedEventArgs e)
        {
            if (!checkNotNull(src, e)) return;

            // StructureChangeType
            if ((e.StructureChangeType == classic.StructureChangeType.ChildAdded && Child.ChildAdded) ||
                (e.StructureChangeType == classic.StructureChangeType.ChildRemoved && Child.ChildRemoved) ||
                (e.StructureChangeType == classic.StructureChangeType.ChildrenBulkAdded && Child.ChildrenBulkAdded) ||
                (e.StructureChangeType == classic.StructureChangeType.ChildrenBulkRemoved && Child.ChildrenBulkRemoved) ||
                (e.StructureChangeType == classic.StructureChangeType.ChildrenInvalidated && Child.ChildrenInvalidated) ||
                (e.StructureChangeType == classic.StructureChangeType.ChildrenReordered && Child.ChildrenReordered)) {
                RunEventScriptBlocks(this);
            }
            try {
                WriteVerbose(this, e.EventId + " on " + (src as classic.AutomationElement) + " fired");
            } catch { }
        }
        #endregion OnUIStructureChangedEvent
        
        #region OnUIWindowClosedEvent
        protected void OnUIWindowClosedEvent(object src, classic.WindowClosedEventArgs e)
        {
            if (!checkNotNull(src, e)) return;
            RunEventScriptBlocks(this);
            try {
                WriteVerbose(this, e.EventId + "on " + (src as classic.AutomationElement) + " fired");
            } catch { }
        }
        #endregion OnUIWindowClosedEvent
        
        #region Event handling for recording
        protected internal void OnUIRecordingAutomationEvent(
            object src,
            classic.AutomationEventArgs e)
        {
            try { // experimental
                
                IUiElement sourceElement;
                string elementTitle = String.Empty;
                string elementType = String.Empty;
                classic.AutomationEvent eventId = null;
                
                try {
                    
                    sourceElement = src as IUiElement;
                    // 20140312
                    // try { elementTitle = sourceElement.Cached.Name; } catch { }
                    // try { elementTitle = (sourceElement as ISupportsCached).Cached.Name; } catch { }
                    try { elementTitle = sourceElement.GetCached().Name; } catch { }
                    try {
                        // 20140312
                        elementType =
                            // sourceElement.Cached.ControlType.ProgrammaticName;
                            // (sourceElement as ISupportsCached).Cached.ControlType.ProgrammaticName;
                            sourceElement.GetCached().ControlType.ProgrammaticName;
                    } catch { }
    
                    try {
                        elementType = 
                            elementType.Substring(
                            elementType.IndexOf('.') + 1);
                        if (elementType.Length == 0) {
                            return;
                        }
                    } catch { }
                    
                    try {
                        eventId = e.EventId;
                        if (sourceElement == null ||
                            elementType.Length == 0 ||
                            eventId == null) {
                            return;
                        }
                    } catch { }
                } catch (classic.ElementNotAvailableException) {
                    return;
                }
                // try {
                string whatToWrite = String.Empty;
                string specificToEvent = String.Empty;
                // 
                try {
                    if (eventId == classic.AutomationElement.AsyncContentLoadedEvent) {
                        specificToEvent = "#AsyncContentLoadedEvent triggered\r\n#source title: " + 
                            elementTitle + " of the type " + elementType;
                    }
                    if (eventId == classic.SelectionItemPattern.ElementAddedToSelectionEvent) {
                        specificToEvent =
                            "SelectItem -AddToSelection:$true -ItemName " + 
                            elementTitle;
                    }
                    if (eventId == classic.SelectionItemPattern.ElementRemovedFromSelectionEvent) {
                        specificToEvent =
                            "SelectItem -RemoveFromSelection:$true -ItemName " + 
                            elementTitle;
                    }
                    if (eventId == classic.SelectionItemPattern.ElementSelectedEvent) {
                        specificToEvent =
                            "SelectItem -ItemName " + 
                            elementTitle;
                    }
                    if (eventId == classic.SelectionPattern.InvalidatedEvent) {
                        specificToEvent = "#InvalidatedEvent triggered\r\n#source title: " + 
                            elementTitle + " of the type " + elementType;
                    }
                    if (eventId == classic.InvokePattern.InvokedEvent) {
                        specificToEvent = "Click";
                    }
                    if (eventId == classic.AutomationElement.LayoutInvalidatedEvent) {
                        specificToEvent = "#LayoutInvalidatedEvent triggered\r\n#source title: " + 
                            elementTitle + " of the type " + elementType;
                    }
                    if (eventId == classic.AutomationElement.MenuClosedEvent) {
                        specificToEvent = "#MenuClosedEvent triggered\r\n#source title: " + 
                            elementTitle + " of the type " + elementType;
                    }
                    if (eventId == classic.AutomationElement.MenuOpenedEvent) {
                        specificToEvent = "#MenuOpenedEvent triggered\r\n#source title: " + 
                            elementTitle + " of the type " + elementType;
                    }
                    if (eventId == classic.TextPattern.TextChangedEvent) {
                        specificToEvent = "#TextChangedEvent triggered\r\n#source title: " + 
                            elementTitle + " of the type " + elementType;
                    }
                    if (eventId == classic.TextPattern.TextSelectionChangedEvent) {
                        specificToEvent = "#TextSelectionChangedEvent triggered\r\n#source title: " + 
                            elementTitle + " of the type " + elementType;
                    }
                    if (eventId == classic.AutomationElement.ToolTipClosedEvent) {
                        specificToEvent = "#ToolTipClosedEvent triggered\r\n#source title: " + 
                            elementTitle + " of the type " + elementType;
                    }
                    if (eventId == classic.AutomationElement.ToolTipOpenedEvent) {
                        specificToEvent = "#ToolTipOpenedEvent triggered\r\n#source title: " + 
                            elementTitle + " of the type " + elementType;
                    }
                    if (eventId == classic.WindowPattern.WindowOpenedEvent) {
                        specificToEvent = "#WindowOpenedEvent triggered\r\n#source title: " + 
                            elementTitle + " of the type " + elementType;
                    }
                    if (eventId == classic.AutomationElement.AutomationFocusChangedEvent) {
                        specificToEvent = "#AutomationFocusChangedEvent triggered\r\n#source title: " + 
                            elementTitle + " of the type " + elementType;
                    }
                    if (eventId == classic.AutomationElement.AutomationPropertyChangedEvent) {
                        specificToEvent = "#AutomationPropertyChangedEvent triggered\r\n#source title: " + 
                            elementTitle + " of the type " + elementType;
                        // specificToEvent += "old value: ";
                        // specificToEvent += eventId.
                    }
                    if (eventId == classic.AutomationElement.StructureChangedEvent) {
                        specificToEvent = "#StructureChangedEvent triggered\r\n#source title: " + 
                            elementTitle + " of the type " + elementType;
                    }
                    if (eventId == classic.WindowPattern.WindowClosedEvent) {
                        specificToEvent = "#WindowClosedEvent triggered\r\n#source title: " + 
                            elementTitle + " of the type " + elementType;
                    }
                } catch (Exception e1) {
                    WriteVerbose(this,
                                 "Event handling for element: " +
                        // 20140312
                                 // sourceElement.Current.Name +
                        sourceElement.GetCurrent().Name + 
                                 " eventId: " +
                                 eventId + 
                                 " failed");
                    WriteVerbose(this,
                                 e1.Message);
                }
// } else {
//  // handle any other events
// }
                if (specificToEvent.Length > 0) {
                    if (specificToEvent.Substring(0, 1) != "#") {
                        // 20131227
                        // whatToWrite += "Invoke-UIA";
                        whatToWrite += "Invoke-Uia";
                        whatToWrite += elementType;
                        whatToWrite += specificToEvent;
                    } else {
                        whatToWrite = specificToEvent;
                    }
                    if (whatToWrite != 
                        // ((ArrayList)Recording[Recording.Count - 1])[0].ToString()) {
                        // ((ArrayList)Recording[Recording.Count - 1]).Insert(0, whatToWrite);
                        (Recording[Recording.Count - 1])[0].ToString()) {
                        (Recording[Recording.Count - 1]).Insert(0, whatToWrite);
                    }
                }
            //} catch { return; }
            
            
            } catch (Exception eUnknown) {
                // WriteVerbose("!!!OnUIRecording " + eUnknown.Message);
                WriteDebug(this, eUnknown.Message);
            } // experimental
            try {
                // 20131109
                WriteVerbose(this, e.EventId + "on " + (src as classic.AutomationElement) + " fired");
                WriteVerbose(this, e.EventId + "on " + (src as IUiElement) + " fired");
            } catch { }
        }
        #endregion Event handling for recording
        
        #region checker event handler inputs
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "check")]
        protected bool checkNotNull(object objectToTest, classic.AutomationEventArgs e)
        {
            // 20131109
            //AutomationElement sourceElement;
            // 20131118
            //IUiElement sourceElement;
            /*
            AutomationElement sourceElement;
            */
            try {
                // 20131109
                //sourceElement = objectToTest as AutomationElement;
                // 20131118
                //sourceElement = objectToTest as IUiElement;
                classic.AutomationElement sourceElement = objectToTest as classic.AutomationElement;
                // 20131109
                //this.EventSource = sourceElement;
                // 20131118
                // property to method
                //this.EventSource = sourceElement.SourceElement;
                // 20131118
                //this.EventSource = sourceElement.GetSourceElement();
                EventSource = sourceElement;
                EventArgs = e;
            } 
            catch { //(ElementNotAvailableException eNotAvailable) {
                return false;
            }
            return true;
        }
        #endregion checker event handler inputs

        protected internal bool TestControlByPropertiesFromHashtable(
            IUiElement[] inputElements,
            IEnumerable<Hashtable> searchCriteria,
            int timeout)
        {
            bool result = false;
            
            if (null == searchCriteria || 0 == searchCriteria.Count()) return result;
            if (null == inputElements || 0 == inputElements.Length) return result;
            
            foreach (Hashtable ht in searchCriteria)
            {
                Dictionary<string, object> dict =
                    ht.ConvertHashtableToDictionary();
                
                var cmdlet = new GetControlCmdletBase();
                
                try { cmdlet.Class = dict["CLASS"].ToString(); } catch {}
                try { cmdlet.AutomationId = dict["AUTOMATIONID"].ToString(); } catch {}
                // 20131128
                // try{ cmdlet.ControlType = dict["CONTROLTYPE"].ToString(); } catch {}
                // 20131203
                try { cmdlet.ControlType = new string[] { dict["CONTROLTYPE"].ToString() }; } catch {}
                try { cmdlet.Name = dict["NAME"].ToString(); } catch {}
                try { cmdlet.Value = dict["VALUE"].ToString(); } catch {}
                
                cmdlet.Timeout = timeout;
                
                if (null != inputElements && null != (inputElements as IUiElement[]) && inputElements.Any()) {
                    cmdlet.InputObject = inputElements;
                } else {
                    if (CurrentData.CurrentWindow == null) {
                        return result;
                    }
                    cmdlet.InputObject = new[]{ CurrentData.CurrentWindow };
                }
                
                var controlSearcher =
                    AutomationFactory.GetSearcherImpl<ControlSearcher>() as ControlSearcher;
                
                List<IUiElement> elementsToWorkWith =
                    controlSearcher.GetElements(
                        controlSearcher.ConvertCmdletToControlSearcherData(cmdlet),
                        cmdlet.Timeout);
                
                // 20140212
                // if (null == elementsToWorkWith) {
                if (null == elementsToWorkWith || 0 == elementsToWorkWith.Count) {
//                    WriteVerbose(this, "couldn't get the control(s)");
                    return result;
                } else {
                    
                    // 20140212
                    bool theCurrentHashtableMatchesAtLeastOneElement = false;
                    
                    foreach (IUiElement elementToWorkWith in elementsToWorkWith) {
                        
                        bool oneControlResult = 
                            elementToWorkWith.TestControlByPropertiesFromDictionary(dict);
                        
                        if (oneControlResult) {
                            
                            if (Preferences.HighlightCheckedControl) {
                                UiaHelper.HighlightCheckedControl(elementToWorkWith);
                            }
                            
                            theCurrentHashtableMatchesAtLeastOneElement = true;
                            // result = true;
                            break;
                        } else { // 20130710
                            // 20140211
                            // return result;
                            // nothing to do
                        }
                    
                    } // 20120824
                    
                    if (!theCurrentHashtableMatchesAtLeastOneElement) return result;
                }
            }
            
            // 20140211
            // 20140211
            result = true;
            
            return result;
        }
    }
}