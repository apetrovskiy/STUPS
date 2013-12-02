/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08.12.2011
 * Time: 8:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using UIAutomation.Commands;

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    using System.Runtime.InteropServices;
    
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

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
        [Parameter(Mandatory = false, 
            ValueFromPipeline = true,
            HelpMessage = "This is usually the output from Get-UiaControl" )] 
        //public System.Windows.Automation.AutomationElement[] InputObject { get; set; }
        //public ICollection InputObject { get; set; }
        public IMySuperWrapper[] InputObject { get; set; }
        /*
        public MySuperWrapper[] InputObject { get; set; }
        */
        [Parameter(Mandatory = false)]
        public virtual SwitchParameter PassThru { get; set; }
        
        [Parameter(Mandatory = false)]
        public ScriptBlock[] EventAction { get; set; }
        #endregion Parameters
        
        
        protected override void StopProcessing()
        {
            WriteVerbose(this, "User interrupted");
        }
        
        #region Properties
        protected AutomationEvent AutomationEventType { get; set; }
        protected AutomationProperty AutomationProperty { get; set; }
        protected internal AutomationEventHandler AutomationEventHandler { get; set; }
        protected internal AutomationPropertyChangedEventHandler AutomationPropertyChangedEventHandler { get; set; }
        protected internal StructureChangedEventHandler StructureChangedEventHandler { get; set; }
        protected RegisterUiaStructureChangedEventCommand Child { get; set; }
        #endregion Properties
        
        protected bool GetColorProbe(HasControlInputCmdletBase cmdlet,
                                     // 20131109
                                     //AutomationElement element)
                                     IMySuperWrapper element)
        {
            bool result = false;
            
            //NativeMethods.getpi
            
            
            
            return result;
        }
        
        protected bool ClickControl(HasControlInputCmdletBase cmdlet,
                                    // 20131109
                                    //AutomationElement element,
                                    IMySuperWrapper element,
                                    bool RightClick,
                                    bool MidClick,
                                    bool Alt,
                                    bool Shift,
                                    bool Ctrl,
                                    bool inSequence,
                                    bool DoubleClick,
                                    // 20131125
                                    int DoubleClickInterval,
                                    int RelativeX,
                                    int RelativeY)
        {
            bool result = false;
            
            if (-1000000 == RelativeX) {
                RelativeX = Preferences.ClickOnControlByCoordX;
            }
            if (-1000000 == RelativeY) {
                RelativeY = Preferences.ClickOnControlByCoordY;
            }
            
            // 20131109
            //AutomationElement whereToClick = 
            //    element;
            IMySuperWrapper whereToClick = 
                element;
            WriteVerbose(cmdlet, 
                         "where the click will be performed: " +
                         element.Current.Name);
            // 20131109
            //AutomationElement whereTheHandle = 
            //    whereToClick;
            IMySuperWrapper whereTheHandle = 
                whereToClick;
            
            if (whereToClick.Current.NativeWindowHandle == 0) {
            
                WriteVerbose(cmdlet, "The handle of this control equals to zero");
                WriteVerbose(cmdlet, "trying to use one of its ancestors");
                
                whereTheHandle = 
                    UiaHelper.GetAncestorWithHandle(whereToClick);
                if (whereTheHandle.Current.NativeWindowHandle == 0) {
                    ErrorRecord err = 
                        new ErrorRecord(new Exception("The handle of this control equals to zero"),
                                        "ZeroHandle",
                                        ErrorCategory.InvalidArgument,
                                        whereTheHandle);
                    err.ErrorDetails = 
                        new ErrorDetails("This control does not have a handle");
                    WriteError(cmdlet, err, true);

                    // TODO: WriteError(...)
                } else {
                    WriteVerbose(cmdlet, 
                                 "the control with a handle is " + 
                                 whereTheHandle.Current.Name);
                    WriteVerbose(cmdlet, 
                                 "its handle is " + 
                                 whereTheHandle.Current.NativeWindowHandle.ToString());
                    WriteVerbose(cmdlet, 
                                 "its rectangle is " + 
                                 whereTheHandle.Current.BoundingRectangle.ToString());
                }
            }
            
            WriteVerbose(cmdlet, 
                         "the element the click will be performed on has rectangle: " + 
                         whereToClick.Current.BoundingRectangle.ToString());
            
            
            int x = 0;
            int y = 0;
            // these x and y are window-related coordinates
            if (RelativeX != 0 && RelativeY != 0) {
                x = RelativeX + (int)whereToClick.Current.BoundingRectangle.X;
                y = RelativeY + (int)whereToClick.Current.BoundingRectangle.Y;
            } else {
                // these x and y are for the SetCursorPos call
                // they are screen coordinates
                x = (int)whereToClick.Current.BoundingRectangle.X + 
                    ((int)whereToClick.Current.BoundingRectangle.Width / 2); // + 3;
                y = (int)whereToClick.Current.BoundingRectangle.Y + 
                    ((int)whereToClick.Current.BoundingRectangle.Height / 2); // + 3;
            }
            // if the -X and -Y paramters are supplied (only for SetCursorPos)
            
            // PostMessage's (click) second parameter
            uint uDown = 0;
            uint uUp = 0;
            
            // these relative coordinates for SendMessage/PostMessage
            int relativeX = x - (int)whereTheHandle.Current.BoundingRectangle.X;
            int relativeY = y - (int)whereTheHandle.Current.BoundingRectangle.Y;
            
            WriteVerbose(cmdlet, "relative X (the base is the control with the handle) = " + relativeX.ToString());            
            WriteVerbose(cmdlet, "relative Y (the base is the control with the handle) = " + relativeY.ToString());
            
            // PostMessage's (click) third and fourth paramters (the third'll be reasigned later)
            IntPtr wParamDown = IntPtr.Zero;
            IntPtr wParamUp = IntPtr.Zero;
            IntPtr lParam = 
                new IntPtr(((new IntPtr(relativeX)).ToInt32() & 0xFFFF) +
                           (((new IntPtr(relativeY)).ToInt32() & 0xFFFF) << 16));
            
            // PostMessage's (keydown/keyup) fourth parameter
            const uint uCtrlDown = 0x401D;
            const uint uCtrlUp = 0xC01D;
            const uint uShiftDown = 0x402A;
            const uint uShiftUp = 0xC02A;
            IntPtr lParamKeyDown = IntPtr.Zero;
            IntPtr lParamKeyUp = IntPtr.Zero;
            
            if (Ctrl) {
                lParamKeyDown = 
                    new IntPtr(((new IntPtr(0x0001)).ToInt32() & 0xFFFF) +
                               (((new IntPtr(uCtrlDown)).ToInt32() & 0xFFFF) << 16));
                lParamKeyUp = 
                    new IntPtr(((new IntPtr(0x0001)).ToInt32() & 0xFFFF) +
                               (((new IntPtr(uCtrlUp)).ToInt32() & 0xFFFF) << 16));
                WriteVerbose(this, "control parameters for KeyDown/KeyUp have been prepared");
            }
            if (Shift) {
                lParamKeyDown = 
                    new IntPtr(((new IntPtr(0x0001)).ToInt32() & 0xFFFF) +
                               (((new IntPtr(uShiftDown)).ToInt32() & 0xFFFF) << 16));
                lParamKeyUp = 
                    new IntPtr(((new IntPtr(0x0001)).ToInt32() & 0xFFFF) +
                               (((new IntPtr(uShiftUp)).ToInt32() & 0xFFFF) << 16));
                WriteVerbose(this, "shift parameters for KeyDown/KeyUp have been prepared");
            }
            // PostMessage's (activate) third parameter
            uint ulAct = 0;
            uint uhAct = 0;
            
            uint mask = 0;
            if (Ctrl) {
                mask |= NativeMethods.MK_CONTROL;
                WriteVerbose(this, "control parameters for ButtonDown/ButtonUp have been prepared");
            }
            if (Shift) {
                mask |= NativeMethods.MK_SHIFT;
                WriteVerbose(this, "shift parameters for ButtonDown/ButtonUp have been prepared");
            }
            
            if (RightClick && !DoubleClick) {
                WriteVerbose(cmdlet, "right click");
                uhAct = uDown = NativeMethods.WM_RBUTTONDOWN;
                uUp = NativeMethods.WM_RBUTTONUP;
                wParamDown = new IntPtr(NativeMethods.MK_RBUTTON | mask);
                wParamUp = new IntPtr(mask);
                ulAct = NativeMethods.MK_RBUTTON;
            } else if (RightClick && DoubleClick) {
                WriteVerbose(cmdlet, "right double click");
                uhAct = uDown = NativeMethods.WM_RBUTTONDBLCLK;
                uUp = NativeMethods.WM_RBUTTONUP;
                wParamDown = new IntPtr(NativeMethods.MK_RBUTTON | mask);
                wParamUp = new IntPtr(mask);
                ulAct = NativeMethods.MK_RBUTTON;
            } else if (MidClick && !DoubleClick) {
                WriteVerbose(cmdlet, "middle button click");
                uhAct = uDown = NativeMethods.WM_MBUTTONDOWN;
                uUp = NativeMethods.WM_MBUTTONUP;
                wParamDown = new IntPtr(NativeMethods.MK_MBUTTON | mask);
                wParamUp = new IntPtr(mask);
                ulAct = NativeMethods.MK_MBUTTON;
            } else if (MidClick && DoubleClick) {
                WriteVerbose(cmdlet, "middle button double click");
                uhAct = uDown = NativeMethods.WM_MBUTTONDBLCLK;
                uUp = NativeMethods.WM_MBUTTONUP;
                wParamDown = new IntPtr(NativeMethods.MK_MBUTTON | mask);
                wParamUp = new IntPtr(mask);
                ulAct = NativeMethods.MK_MBUTTON;
            } else if (DoubleClick) {
                WriteVerbose(cmdlet, "left double click");
                uhAct = uDown = NativeMethods.WM_LBUTTONDBLCLK;
                uUp = NativeMethods.WM_LBUTTONUP;
                wParamDown = new IntPtr(NativeMethods.MK_LBUTTON | mask);
                wParamUp = new IntPtr(mask);
                ulAct = NativeMethods.MK_LBUTTON;
            } else {
                WriteVerbose(cmdlet, "left click");
                uhAct = uDown = NativeMethods.WM_LBUTTONDOWN;
                uUp = NativeMethods.WM_LBUTTONUP;
                wParamDown = new IntPtr(NativeMethods.MK_LBUTTON | mask);
                wParamUp = new IntPtr(mask);
                ulAct = NativeMethods.MK_LBUTTON;
            }
            
            IntPtr handle =
                    new IntPtr(whereTheHandle.Current.NativeWindowHandle);
            WriteVerbose(cmdlet, 
                         "the handle of the element the click will be performed on is " + 
                         handle.ToString());
            
            WriteVerbose(cmdlet, "X = " + x.ToString());
            WriteVerbose(cmdlet, "Y = " + y.ToString());
            
            try {
                whereTheHandle.SetFocus();
            } 
            catch { }
            
            bool setCursorPosResult = 
                NativeMethods.SetCursorPos(x, y);
            WriteVerbose(cmdlet, "SetCursorPos result = " + setCursorPosResult.ToString());
            
            Thread.Sleep(Preferences.OnClickDelay);
            
            // trying to heal context menu clicks
            Process windowProcess = 
                Process.GetProcessById(
                    whereTheHandle.Current.ProcessId);
            if (windowProcess != null) {
                IntPtr mainWindow = 
                    windowProcess.MainWindowHandle;
                if (mainWindow != IntPtr.Zero) {
                    
                    IntPtr lParam2 = 
                        new IntPtr(((new IntPtr(ulAct)).ToInt32() & 0xFFFF) +
                                   (((new IntPtr(uhAct)).ToInt32() & 0xFFFF) << 16));
                    bool res0 = 
                        NativeMethods.PostMessage1(handle, NativeMethods.WM_MOUSEACTIVATE, 
                                     mainWindow, lParam2);
                    WriteVerbose(this, "WM_MOUSEACTIVATE is sent");
                }
            }
            
            if (Ctrl) {
                // press the control key
                NativeMethods.keybd_event((byte)NativeMethods.VK_LCONTROL, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | 0, 0);
                WriteVerbose(this, " the control button has been pressed");
            }
            if (Shift) {
                // press the shift key
                NativeMethods.keybd_event((byte)NativeMethods.VK_LSHIFT, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | 0, 0);
                WriteVerbose(this, " the shift button has been pressed");
            }
            
            // // 20120620 for Home Tab
            bool res1 = NativeMethods.PostMessage1(handle, uDown, wParamDown, lParam);
            
            int interval = DoubleClickInterval / 2;
            if (DoubleClick) {
                Thread.Sleep(interval);
            }
            
            // MouseMove
            if (RightClick || DoubleClick) {
                bool resMM = NativeMethods.PostMessage1(handle, NativeMethods.WM_MOUSEMOVE, wParamDown, lParam);
            }
            
            // 20131125
            if (DoubleClick) {
                Thread.Sleep(interval);
            }
            
            // // 20120620 for Home Tab
            bool res2 = NativeMethods.PostMessage1(handle, uUp, wParamUp, lParam);
            
            if (!inSequence) {
                if (Ctrl) {
                    // release the control key
                    NativeMethods.keybd_event((byte)NativeMethods.VK_LCONTROL, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP, 0);
                    WriteVerbose(this, " the control button has been released");
                }
                if (Shift) {
                    // release the shift key
                    NativeMethods.keybd_event((byte)NativeMethods.VK_LSHIFT, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP, 0);
                    WriteVerbose(this, " the shift button has been released");
                }
            }
            
            WriteVerbose(cmdlet,
                         // // 20120620 for Home Tab
                         // 20130312
                         "PostMessage " + uDown.ToString() + 
                         //"SendMessage " + uDown.ToString() + 
                         " result = " + res1.ToString());
            WriteVerbose(cmdlet, 
                         // // 20120620 for Home Tab
                         // 20130312
                         "PostMessage " + uUp.ToString() +
                         //"SendMessage " + uUp.ToString() + 
                         " result = " + res2.ToString());
            // if (!res1 && !res2) {
            if (res1 && res2) {
                result = true;
            } else {
                result = false;
            }
            
            return result;
        }
        
        // 20131109
        //internal bool CheckControl(HasControlInputCmdletBase cmdlet)
        internal bool CheckAndPrepareInput(HasControlInputCmdletBase cmdlet)
        {
            bool result = false;
            
            // 20131109
            //ICollection newInputCollection =
            //    new MySuperCollection
            
            if (null == cmdlet.InputObject) {
                
                WriteVerbose(cmdlet, "[checking the input] Control(s) are null");
                
                cmdlet.WriteError(
                    cmdlet,
                    "The pipeline input is null",
                    "InputIsNull",
                    ErrorCategory.InvalidArgument,
                    true);
                
            }
            
            // 20131109
            //foreach (AutomationElement inputObject in cmdlet.InputObject) {
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
                    
                    // 20131109
                    // experimental
//                    cmdlet.WriteError(
//                        cmdlet,
//                        "The pipeline input is null",
//                        "InputIsNull",
//                        ErrorCategory.InvalidArgument,
//                        true);
                    cmdlet.WriteError(
                        cmdlet,
                        "A part of the pipeline input is null",
                        "PartOfInputIsNull",
                        ErrorCategory.InvalidArgument,
                        false);
                    
                }
                
                // 20131109
                //System.Windows.Automation.AutomationElement _control = null;
                //IMySuperWrapper _controlAdapter = null;
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
                    //if (inputObject is IMySuperWrapper) {
                    if (null != (inputObject as IMySuperWrapper))
                    {
                    /*
                    if (inputObject is IMySuperWrapper) {
                    */

                        cmdlet.CurrentWindow = (IMySuperWrapper)_controlAdapter;
                    }
//                    if (inputObject is AutomationElement) {
//                        cmdlet.currentWindow = new MySuperWrapper((AutomationElement)inputObject);
//                    }
                    
                    result = true;
                    
                    // there's no need to output the True value
                    // since the output will be what we want 
                    // (some part of AutomationElement, as an example)
                } catch (Exception eControlTypeException) {
                    
                    WriteDebug(cmdlet, "[checking the input] Control is not an AutomationElement");
                    WriteDebug(cmdlet, "[checking the input] " + eControlTypeException.Message);
                    
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
                                                  // 20131109
                                                  //AutomationElement inputObject,
                                                  IMySuperWrapper inputObject,
                                                  AutomationEvent eventType,
                                                  AutomationProperty prop)
        {
            if (null == CurrentData.Events) {
                CurrentData.InitializeEventCollection();
            }
            
            try {

                CacheRequest cacheRequest = new CacheRequest
                {
                    AutomationElementMode = AutomationElementMode.Full,
                    TreeFilter = Automation.RawViewCondition
                };
                cacheRequest.Add(AutomationElement.NameProperty);
                cacheRequest.Add(AutomationElement.AutomationIdProperty);
                cacheRequest.Add(AutomationElement.ClassNameProperty);
                cacheRequest.Add(AutomationElement.ControlTypeProperty);
                //cacheRequest.Add(AutomationElement.ProcessIdProperty);
                // cache patterns?
                
                // cacheRequest.Activate();
                cacheRequest.Push();

                AutomationEventHandler uiaEventHandler;
                switch (eventType.ProgrammaticName) {
                    case "InvokePatternIdentifiers.InvokedEvent":
                        WriteVerbose(cmdlet, "subscribing to the InvokedEvent handler");
                        Automation.AddAutomationEventHandler(
                            InvokePattern.InvokedEvent,
                            // 20131118
                            // property to method
                            //inputObject.SourceElement, 
                            inputObject.GetSourceElement(),
                            TreeScope.Element, // TreeScope.Subtree, // TreeScope.Element,
                            uiaEventHandler = new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        UiaHelper.WriteEventToCollection(cmdlet, uiaEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    case "TextPatternIdentifiers.TextChangedEvent":
                        WriteVerbose(cmdlet, "subscribing to the TextChangedEvent handler");
                        Automation.AddAutomationEventHandler(
                            TextPattern.TextChangedEvent,
                            // 20131118
                            // property to method
                            //inputObject.SourceElement, 
                            inputObject.GetSourceElement(),
                            TreeScope.Element,
                            uiaEventHandler = new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        UiaHelper.WriteEventToCollection(cmdlet, uiaEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    case "TextPatternIdentifiers.TextSelectionChangedEvent":
                        WriteVerbose(cmdlet, "subscribing to the TextSelectionChangedEvent handler");
                        Automation.AddAutomationEventHandler(
                            TextPattern.TextSelectionChangedEvent,
                            // 20131118
                            // property to method
                            //inputObject.SourceElement, 
                            inputObject.GetSourceElement(),
                            TreeScope.Element,
                            uiaEventHandler = new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        UiaHelper.WriteEventToCollection(cmdlet, uiaEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    case "WindowPatternIdentifiers.WindowOpenedProperty":
                        WriteVerbose(cmdlet, "subscribing to the WindowOpenedEvent handler");
                        Automation.AddAutomationEventHandler(
                            WindowPattern.WindowOpenedEvent,
                            // 20131118
                            // property to method
                            //inputObject.SourceElement, 
                            inputObject.GetSourceElement(),
                            TreeScope.Subtree,
                            uiaEventHandler = new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        UiaHelper.WriteEventToCollection(cmdlet, uiaEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    case "AutomationElementIdentifiers.AutomationPropertyChangedEvent":
                        if (prop != null) {
                            WriteVerbose(cmdlet, "subscribing to the AutomationPropertyChangedEvent handler");
                            AutomationPropertyChangedEventHandler uiaPropertyChangedEventHandler;
                            Automation.AddAutomationPropertyChangedEventHandler(
                                // 20131118
                                // property to method
                                //inputObject.SourceElement, 
                                inputObject.GetSourceElement(),
                                TreeScope.Subtree,
                                uiaPropertyChangedEventHandler = 
                                    new AutomationPropertyChangedEventHandler(cmdlet.AutomationPropertyChangedEventHandler),
                                prop);
                            UiaHelper.WriteEventToCollection(cmdlet, uiaPropertyChangedEventHandler);
                            if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaPropertyChangedEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        }
                        break;
                    case "AutomationElementIdentifiers.StructureChangedEvent":
                        WriteVerbose(cmdlet, "subscribing to the StructureChangedEvent handler");
                        StructureChangedEventHandler uiaStructureChangedEventHandler;
                        Automation.AddStructureChangedEventHandler(
                            // 20131118
                            // property to method
                            //inputObject.SourceElement,
                            inputObject.GetSourceElement(),
                            TreeScope.Subtree,
                            uiaStructureChangedEventHandler = 
                            new StructureChangedEventHandler(cmdlet.StructureChangedEventHandler));
                        UiaHelper.WriteEventToCollection(cmdlet, uiaStructureChangedEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaStructureChangedEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    case "WindowPatternIdentifiers.WindowClosedProperty":
                        WriteVerbose(cmdlet, "subscribing to the WindowClosedEvent handler");
                        Automation.AddAutomationEventHandler(
                            WindowPattern.WindowClosedEvent,
                            // 20131118
                            // property to method
                            //inputObject.SourceElement, 
                            inputObject.GetSourceElement(),
                            TreeScope.Subtree,
                            uiaEventHandler = new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        UiaHelper.WriteEventToCollection(cmdlet, uiaEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    case "AutomationElementIdentifiers.MenuClosedEvent":
                        WriteVerbose(cmdlet, "subscribing to the MenuClosedEvent handler");
                        Automation.AddAutomationEventHandler(
                            AutomationElement.MenuClosedEvent,
                            // 20131118
                            // property to method
                            //inputObject.SourceElement, 
                            inputObject.GetSourceElement(),
                            TreeScope.Subtree,
                            uiaEventHandler = new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        UiaHelper.WriteEventToCollection(cmdlet, uiaEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    case "AutomationElementIdentifiers.MenuOpenedEvent":
                        WriteVerbose(cmdlet, "subscribing to the MenuOpenedEvent handler");
                        Automation.AddAutomationEventHandler(
                            AutomationElement.MenuOpenedEvent,
                            // 20131118
                            // property to method
                            //inputObject.SourceElement, 
                            inputObject.GetSourceElement(),
                            TreeScope.Subtree,
                            uiaEventHandler = new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        UiaHelper.WriteEventToCollection(cmdlet, uiaEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    case "AutomationElementIdentifiers.ToolTipClosedEvent":
                        WriteVerbose(cmdlet, "subscribing to the ToolTipClosedEvent handler");
                        Automation.AddAutomationEventHandler(
                            AutomationElement.ToolTipClosedEvent,
                            // 20131118
                            // property to method
                            //inputObject.SourceElement, 
                            inputObject.GetSourceElement(),
                            TreeScope.Subtree,
                            uiaEventHandler = new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        UiaHelper.WriteEventToCollection(cmdlet, uiaEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    case "AutomationElementIdentifiers.ToolTipOpenedEvent":
                        WriteVerbose(cmdlet, "subscribing to the ToolTipOpenedEvent handler");
                        Automation.AddAutomationEventHandler(
                            AutomationElement.ToolTipOpenedEvent,
                            // 20131118
                            // property to method
                            //inputObject.SourceElement, 
                            inputObject.GetSourceElement(),
                            TreeScope.Subtree,
                            uiaEventHandler = new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        UiaHelper.WriteEventToCollection(cmdlet, uiaEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    case "AutomationElementIdentifiers.AutomationFocusChangedEvent":
                        WriteVerbose(cmdlet, "subscribing to the AutomationFocusChangedEvent handler");
                        AutomationFocusChangedEventHandler uiaFocusChangedEventHandler;
                        Automation.AddAutomationFocusChangedEventHandler(
                            uiaFocusChangedEventHandler = new AutomationFocusChangedEventHandler(cmdlet.AutomationEventHandler));
                        UiaHelper.WriteEventToCollection(cmdlet, uiaFocusChangedEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaFocusChangedEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    default:
                        WriteVerbose(cmdlet, 
                                     "the following event has not been subscribed to: " + 
                                     eventType.ProgrammaticName);
                        break;
                }
                WriteVerbose(cmdlet, "on the object " + inputObject.Current.Name);
                cacheRequest.Pop();
                
            } 
            catch (Exception e) {
                
                WriteVerbose(cmdlet,
                              "Unable to register event handler " +
                              eventType.ProgrammaticName +
                              " for " +
                              inputObject.Current.Name);
                 WriteVerbose(cmdlet,
                              e.Message);
            }
        }
        #endregion subscribe to events
    
        #region OnUIAutomationEvent
        protected void OnUIAutomationEvent(object src, AutomationEventArgs e)
        {
            if (!checkNotNull(src, e)) return;
            RunEventScriptBlocks(this);
            try {
                WriteVerbose(this, e.EventId + " on " + (src as AutomationElement) + " fired");
            } catch { }
        }
        #endregion OnUIAutomationEvent
        
        #region OnUIAutomationPropertyChangedEvent
        protected void OnUIAutomationPropertyChangedEvent(object src, AutomationPropertyChangedEventArgs e)
        {
            if (!checkNotNull(src, e)) return;
            if (AutomationProperty == e.Property) {
                
                
try {
    WriteVerbose(this, "RunEventScriptBlocks(this) ran");
} catch { }
                
                
                RunEventScriptBlocks(this);
            }
            try {
                WriteVerbose(this, e.EventId + "on " + (src as AutomationElement) + " fired");
            } catch { }
        }
        #endregion OnUIAutomationPropertyChangedEvent
        
        #region OnUIStructureChangedEvent
        protected void OnUIStructureChangedEvent(object src, StructureChangedEventArgs e)
        {
            if (!checkNotNull(src, e)) return;

            // StructureChangeType
            if ((e.StructureChangeType == StructureChangeType.ChildAdded && Child.ChildAdded) ||
                (e.StructureChangeType == StructureChangeType.ChildRemoved && Child.ChildRemoved) ||
                (e.StructureChangeType == StructureChangeType.ChildrenBulkAdded && Child.ChildrenBulkAdded) ||
                (e.StructureChangeType == StructureChangeType.ChildrenBulkRemoved && Child.ChildrenBulkRemoved) ||
                (e.StructureChangeType == StructureChangeType.ChildrenInvalidated && Child.ChildrenInvalidated) ||
                (e.StructureChangeType == StructureChangeType.ChildrenReordered && Child.ChildrenReordered)) {
                RunEventScriptBlocks(this);
            }
            try {
                WriteVerbose(this, e.EventId + " on " + (src as AutomationElement) + " fired");
            } catch { }
        }
        #endregion OnUIStructureChangedEvent
        
        #region OnUIWindowClosedEvent
        protected void OnUIWindowClosedEvent(object src, WindowClosedEventArgs e)
        {
            if (!checkNotNull(src, e)) return;
            RunEventScriptBlocks(this);
            try {
                WriteVerbose(this, e.EventId + "on " + (src as AutomationElement) + " fired");
            } catch { }
        }
        #endregion OnUIWindowClosedEvent
        
        #region Event handling for recording
        protected internal void OnUIRecordingAutomationEvent(
            object src,
            AutomationEventArgs e)
        {
            try { // experimental
            
            // 20131109
            //AutomationElement sourceElement;
            IMySuperWrapper sourceElement;
            string elementTitle = String.Empty;
            string elementType = String.Empty;
            AutomationEvent eventId = null;
            
            try {
                // 20131109
                //sourceElement = src as AutomationElement;
                sourceElement = src as IMySuperWrapper;
                try { elementTitle = sourceElement.Cached.Name; } catch { }
                try {
                    elementType =
                        sourceElement.Cached.ControlType.ProgrammaticName;
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
            } catch (ElementNotAvailableException) {
                return;
            }
            // try {
                string whatToWrite = String.Empty;
                string specificToEvent = String.Empty;
                // 
                try {
                    if (eventId == AutomationElement.AsyncContentLoadedEvent) {
                        specificToEvent = "#AsyncContentLoadedEvent triggered\r\n#source title: " + 
                            elementTitle + " of the type " + elementType;
                    }
                    if (eventId == SelectionItemPattern.ElementAddedToSelectionEvent) {
                        specificToEvent =
                            "SelectItem -AddToSelection:$true -ItemName " + 
                            elementTitle;
                    }
                    if (eventId == SelectionItemPattern.ElementRemovedFromSelectionEvent) {
                        specificToEvent =
                            "SelectItem -RemoveFromSelection:$true -ItemName " + 
                            elementTitle;
                    }
                    if (eventId == SelectionItemPattern.ElementSelectedEvent) {
                        specificToEvent =
                            "SelectItem -ItemName " + 
                            elementTitle;
                    }
                    if (eventId == SelectionPattern.InvalidatedEvent) {
                        specificToEvent = "#InvalidatedEvent triggered\r\n#source title: " + 
                            elementTitle + " of the type " + elementType;
                    }
                    if (eventId == InvokePattern.InvokedEvent) {
                        specificToEvent = "Click";
                    }
                    if (eventId == AutomationElement.LayoutInvalidatedEvent) {
                        specificToEvent = "#LayoutInvalidatedEvent triggered\r\n#source title: " + 
                            elementTitle + " of the type " + elementType;
                    }
                    if (eventId == AutomationElement.MenuClosedEvent) {
                        specificToEvent = "#MenuClosedEvent triggered\r\n#source title: " + 
                            elementTitle + " of the type " + elementType;
                    }
                    if (eventId == AutomationElement.MenuOpenedEvent) {
                        specificToEvent = "#MenuOpenedEvent triggered\r\n#source title: " + 
                            elementTitle + " of the type " + elementType;
                    }
                    if (eventId == TextPattern.TextChangedEvent) {
                        specificToEvent = "#TextChangedEvent triggered\r\n#source title: " + 
                            elementTitle + " of the type " + elementType;
                    }
                    if (eventId == TextPattern.TextSelectionChangedEvent) {
                        specificToEvent = "#TextSelectionChangedEvent triggered\r\n#source title: " + 
                            elementTitle + " of the type " + elementType;
                    }
                    if (eventId == AutomationElement.ToolTipClosedEvent) {
                        specificToEvent = "#ToolTipClosedEvent triggered\r\n#source title: " + 
                            elementTitle + " of the type " + elementType;
                    }
                    if (eventId == AutomationElement.ToolTipOpenedEvent) {
                        specificToEvent = "#ToolTipOpenedEvent triggered\r\n#source title: " + 
                            elementTitle + " of the type " + elementType;
                    }
                    if (eventId == WindowPattern.WindowOpenedEvent) {
                        specificToEvent = "#WindowOpenedEvent triggered\r\n#source title: " + 
                            elementTitle + " of the type " + elementType;
                    }
                    if (eventId == AutomationElement.AutomationFocusChangedEvent) {
                        specificToEvent = "#AutomationFocusChangedEvent triggered\r\n#source title: " + 
                            elementTitle + " of the type " + elementType;
                    }
                    if (eventId == AutomationElement.AutomationPropertyChangedEvent) {
                        specificToEvent = "#AutomationPropertyChangedEvent triggered\r\n#source title: " + 
                            elementTitle + " of the type " + elementType;
                        // specificToEvent += "old value: ";
                        // specificToEvent += eventId.
                    }
                    if (eventId == AutomationElement.StructureChangedEvent) {
                        specificToEvent = "#StructureChangedEvent triggered\r\n#source title: " + 
                            elementTitle + " of the type " + elementType;
                    }
                    if (eventId == WindowPattern.WindowClosedEvent) {
                        specificToEvent = "#WindowClosedEvent triggered\r\n#source title: " + 
                            elementTitle + " of the type " + elementType;
                    }
                } catch (Exception e1) {
                    WriteVerbose(this,
                                 "Event handling for element: " + 
                                 sourceElement.Current.Name + 
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
                        whatToWrite += "Invoke-UIA";
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
                WriteVerbose(this, e.EventId + "on " + (src as AutomationElement) + " fired");
                WriteVerbose(this, e.EventId + "on " + (src as IMySuperWrapper) + " fired");
            } catch { }
        }
        #endregion Event handling for recording
        
        #region checker event handler inputs
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "check")]
        protected bool checkNotNull(object objectToTest, AutomationEventArgs e)
        {
            // 20131109
            //AutomationElement sourceElement;
            // 20131118
            //IMySuperWrapper sourceElement;
            /*
            AutomationElement sourceElement;
            */
            try {
                // 20131109
                //sourceElement = objectToTest as AutomationElement;
                // 20131118
                //sourceElement = objectToTest as IMySuperWrapper;
                AutomationElement sourceElement = objectToTest as AutomationElement;
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
            // 20130315
            // 20131109
            //AutomationElement[] inputElements,
            //ICollection inputElements,
            IMySuperWrapper[] inputElements,
            IEnumerable<Hashtable> SearchCriteria,
            //System.Collections.Hashtable[] SearchCriteria,
            int timeout)
        {
            
            bool result = false;
            foreach (Hashtable ht in SearchCriteria)
            {
                Dictionary<string, object> dict =
                    ConvertHashtableToDictionary(ht);
                
                GetControlCmdletBase cmdlet = 
                    new GetControlCmdletBase();
                
                try{ cmdlet.Class = dict["CLASS"].ToString(); } catch {}
                try{ cmdlet.AutomationId = dict["AUTOMATIONID"].ToString(); } catch {}
                // 20131128
                // try{ cmdlet.ControlType = dict["CONTROLTYPE"].ToString(); } catch {}
                try{ cmdlet.Name = dict["NAME"].ToString(); } catch {}
                try{ cmdlet.Value = dict["VALUE"].ToString(); } catch {}
                
                cmdlet.Timeout = timeout;
                
                //if (null != inputElements && null != (inputElements as AutomationElement[]) && 0 < inputElements.Length) {
                // 20131109
                //if (null != inputElements && null != (inputElements as AutomationElement[]) && 0 < inputElements.Count) {
                if (null != inputElements && null != (inputElements as IMySuperWrapper[]) && inputElements.Any()) {

                /*
                if (null != inputElements && null != (inputElements as IMySuperWrapper[]) && 0 < inputElements.Count()) {
                */

                    // 20131109
                    //cmdlet.InputObject = inputElements;
                    cmdlet.InputObject = inputElements; //.ConvertCmdletInputToCollectionAdapter();
                } else {
                    if (CurrentData.CurrentWindow == null) {
                        return result;
                    }
                    
                    // 20131109
                    //cmdlet.InputObject = new AutomationElement[]{ UIAutomation.CurrentData.CurrentWindow };
                    cmdlet.InputObject = new MySuperWrapper[]{ (MySuperWrapper)CurrentData.CurrentWindow };
                }
                
                WriteVerbose(this, "getting the control");
                
                // 20131202
                // ArrayList elementsToWorkWith = GetControl(cmdlet);
                List<IMySuperWrapper> elementsToWorkWith = GetControl(cmdlet);
                
                if (null == elementsToWorkWith) {

                    WriteVerbose(this, "couldn't get the control(s)");
                    return result;
                } else {
                    
                    // 20131109
                    //foreach (AutomationElement elementToWorkWith in elementsToWorkWith) {
                    foreach (IMySuperWrapper elementToWorkWith in elementsToWorkWith) {
                        
                        WriteVerbose(this, "found the control:");
                        try {WriteVerbose(this, "Name = " + elementToWorkWith.Current.Name); }catch {}
                        try {WriteVerbose(this, "AutomationId = " + elementToWorkWith.Current.AutomationId); }catch {}
                        try {WriteVerbose(this, "ClassName = " + elementToWorkWith.Current.ClassName); }catch {}
                        try {WriteVerbose(this, "ControlType = " + elementToWorkWith.Current.ControlType.ProgrammaticName); }catch {}
                        
                        bool oneControlResult = 
                            TestControlByPropertiesFromDictionary(
                                dict,
                                elementToWorkWith);
                        
                        if (oneControlResult) {
                            
                            if (Preferences.HighlightCheckedControl) {
                                UiaHelper.HighlightCheckedControl(elementToWorkWith);
                            }
                            
                        } else { // 20130710
                            return result;
                        }
                    
                    } // 20120824
                }
            }

            /*
            for (int i = 0; i < SearchCriteria.Length; i++) {
                
                System.Collections.Generic.Dictionary<string, object> dict =
                    this.ConvertHashtableToDictionary(SearchCriteria[i]);
                
                GetControlCmdletBase cmdlet = 
                    new GetControlCmdletBase();
                
                try{ cmdlet.Class = dict["CLASS"].ToString(); } catch {}
                try{ cmdlet.AutomationId = dict["AUTOMATIONID"].ToString(); } catch {}
                try{ cmdlet.ControlType = dict["CONTROLTYPE"].ToString(); } catch {}
                try{ cmdlet.Name = dict["NAME"].ToString(); } catch {}
                try{ cmdlet.Value = dict["VALUE"].ToString(); } catch {}
                
                cmdlet.Timeout = timeout;
                
                if (null != inputElements && null != (inputElements as AutomationElement[]) && 0 < inputElements.Length) {
                    cmdlet.InputObject = inputElements;
                } else {
                    if (UIAutomation.CurrentData.CurrentWindow == null) {
                        return result;
                    }
                    cmdlet.InputObject = new AutomationElement[]{ UIAutomation.CurrentData.CurrentWindow };
                }
                
                WriteVerbose(this, "getting the control");
                
                ArrayList elementsToWorkWith = GetControl(cmdlet);
                
                if (null == elementsToWorkWith) {

                    WriteVerbose(this, "couldn't get the control(s)");
                    return result;
                } else {

                    foreach (AutomationElement elementToWorkWith in elementsToWorkWith) {
                        
                        WriteVerbose(this, "found the control:");
                        try {WriteVerbose(this, "Name = " + elementToWorkWith.Current.Name); }catch {}
                        try {WriteVerbose(this, "AutomationId = " + elementToWorkWith.Current.AutomationId); }catch {}
                        try {WriteVerbose(this, "ClassName = " + elementToWorkWith.Current.ClassName); }catch {}
                        try {WriteVerbose(this, "ControlType = " + elementToWorkWith.Current.ControlType.ProgrammaticName); }catch {}
                        
                        bool oneControlResult = 
                            testControlByPropertiesFromDictionary(
                                dict,
                                elementToWorkWith);
                        
                        if (oneControlResult) {
                            
                            if (Preferences.HighlightCheckedControl) {
                                UiaHelper.HighlightCheckedControl(elementToWorkWith);
                            }
                            
                        } else { // 20130710
                            return result;
                        }
                    
                    } // 20120824
                }
            }
            */

            result = true;
            
            return result;
        }
    }
}