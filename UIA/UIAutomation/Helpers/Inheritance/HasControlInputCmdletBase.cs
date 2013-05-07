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
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    using System.Runtime.InteropServices;
    
    using System.Collections;

    #region declarations
        [StructLayout(LayoutKind.Sequential)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "MOUSEINPUT")]
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "KEYBDINPUT")]
        internal struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "HARDWAREINPUT")]
        internal struct HARDWAREINPUT
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }

        
        [StructLayout(LayoutKind.Explicit)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "MOUSEKEYBDHARDWAREINPUT")]
        internal struct MOUSEKEYBDHARDWAREINPUT
        {
            [FieldOffset(0)]
            public MOUSEINPUT Mouse;

            [FieldOffset(0)]
            public KEYBDINPUT Keyboard;

            [FieldOffset(0)]
            public HARDWAREINPUT Hardware;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "INPUT")]
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
            HelpMessage = "This is usually the output from Get-UIAControl" )] 
        public virtual System.Windows.Automation.AutomationElement[] InputObject { get; set; }
        [Parameter(Mandatory = false)]
        public virtual SwitchParameter PassThru { get; set; }
        
        [Parameter(Mandatory = false)]
        public ScriptBlock[] EventAction { get; set; }
        #endregion Parameters
        
        
        protected override void StopProcessing()
        {
            WriteVerbose(this, "User interrupted");
        }
        
//        #region declarations
//        // http://msdn.microsoft.com/en-us/library/windows/desktop/ms646244(v=vs.85).aspx
//        protected uint WM_MOUSEACTIVATE             = 0x0021;
//        protected uint WM_LBUTTONDOWN               = 0x0201;
//        protected uint WM_LBUTTONUP                 = 0x0202;
//        protected uint WM_LBUTTONDBLCLK             = 0x0203;
//        protected uint WM_RBUTTONDOWN               = 0x0204;
//        protected uint WM_RBUTTONUP                 = 0x0205;
//        protected uint WM_RBUTTONDBLCLK             = 0x0206;
//        protected uint WM_MBUTTONDOWN               = 0x0207;
//        protected uint WM_MBUTTONUP                 = 0x0208;
//        protected uint WM_MBUTTONDBLCLK             = 0x0209;
//        
//        protected uint MK_CONTROL                    = 0x0008;    // The CTRL key is down.
//        protected uint MK_LBUTTON                    = 0x0001;    // The left mouse button is down.
//        protected uint MK_MBUTTON                    = 0x0010;    // The middle mouse button is down.
//        protected uint MK_RBUTTON                    = 0x0002;    // The right mouse button is down.
//        protected uint MK_SHIFT                        = 0x0004;    // The SHIFT key is down.
//        // 20120206 protected uint MK_XBUTTON1                    = 0x0020;    // The first X button is down.
//        // 20120206 protected uint MK_XBUTTON2                    = 0x0040;    // The second X button is down.
//        
//        protected uint WM_KEYDOWN                   = 0x0100;
//        protected uint WM_KEYUP                     = 0x0101;
//        protected uint WM_SYSKEYDOWN                = 0x0104;
//        protected uint WM_SYSKEYUP                  = 0x0105;
//        
//        // http://msdn.microsoft.com/en-us/library/ms927178.aspx
//        protected uint VK_SHIFT                        = 0x0010;    // SHIFT key
//        protected uint VK_CONTROL                    = 0x0011;    // CTRL key
//        
//        protected uint VK_LSHIFT                    = 0xA0;    // Left SHIFT
//        protected uint VK_RSHIFT                    = 0xA1;    // Right SHIFT
//        protected uint VK_LCONTROL                    = 0xA2;    // Left CTRL
//        protected uint VK_RCONTROL                    = 0xA3;    // Right CTRL
//            
//        [DllImport("user32.dll", EntryPoint = "PostMessage", CharSet = CharSet.Auto)]
//        [return: MarshalAs(UnmanagedType.Bool)]
//        protected static extern bool PostMessage1(IntPtr hWnd, uint Msg,
//                                                IntPtr wParam, IntPtr lParam);
//        
//        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
//        [return: MarshalAs(UnmanagedType.Bool)]
//        protected static extern bool SendMessage1(IntPtr hWnd, uint Msg,
//                                                IntPtr wParam, IntPtr lParam);
//        
//        [DllImport("user32.dll")]
//        [return: MarshalAs(UnmanagedType.Bool)]
//        protected static extern bool SetCursorPos(int X, int Y);
//        
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "INPUT")]
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "MOUSE")]
//        protected const int INPUT_MOUSE = 0;
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "INPUT")]
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "KEYBOARD")]
//        protected const int INPUT_KEYBOARD = 1;
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "INPUT")]
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "HARDWARE")]
//        protected const int INPUT_HARDWARE = 2;
//        
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "KEYEVENTF")]
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "EXTENDEDKEY")]
//        protected const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "KEYEVENTF")]
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "KEYUP")]
//        protected const uint KEYEVENTF_KEYUP = 0x0002;
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "KEYEVENTF")]
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UNICODE")]
//        protected const uint KEYEVENTF_UNICODE = 0x0004;
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "KEYEVENTF")]
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "SCANCODE")]
//        protected const uint KEYEVENTF_SCANCODE = 0x0008;
//        
//
//        
//        [DllImport("user32.dll", SetLastError = true)]
//        // protected static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);
//        //internal static extern uint SendInput(uint nInputs, INPUT pInputs, int cbSize);
//        private static extern uint SendInput(uint nInputs, INPUT pInputs, int cbSize);
//        
//// [DllImport("user32.dll")]
//// protected static extern void keybd_event(byte bVk, byte bScan, uint dwFlags,
//// UIntPtr dwExtraInfo);
//        
//        [DllImport("user32.dll")]
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "keybd")]
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "event")]
//        protected static extern void keybd_event(byte bVk, byte bScan, uint dwFlags,
//           int dwExtraInfo);
//        
//        
//        [DllImport("user32.dll")]
//        protected static extern short GetKeyState(uint vkCode);
//        
//        #endregion declarations
        
        #region Properties
        protected AutomationEvent AutomationEventType { get; set; }
        protected AutomationProperty AutomationProperty { get; set; }
        protected internal AutomationEventHandler AutomationEventHandler { get; set; }
        protected internal AutomationPropertyChangedEventHandler AutomationPropertyChangedEventHandler { get; set; }
        protected internal StructureChangedEventHandler StructureChangedEventHandler { get; set; }
        protected Commands.RegisterUIAStructureChangedEventCommand Child { get; set; }
        #endregion Properties
        
//        protected override void BeginProcessing()
//        {
//            WriteVerbose(this, "BeginProcessing()");
//        }
        
        protected bool GetColorProbe(HasControlInputCmdletBase cmdlet,
                                     AutomationElement element)
        {
            bool result = false;
            
            //NativeMethods.getpi
            
            
            
            return result;
        }
        
        protected bool ClickControl(HasControlInputCmdletBase cmdlet,
                                    AutomationElement element,
                                    bool RightClick,
                                    bool MidClick,
                                    bool Alt,
                                    bool Shift,
                                    bool Ctrl,
                                    bool inSequence,
                                    bool DoubleClick,
                                    int RelativeX,
                                    int RelativeY)
        {
            bool result = false;
            
            // 20121012
            if (-1000000 == RelativeX) {
                RelativeX = Preferences.ClickOnControlByCoordX;
            }
            if (-1000000 == RelativeY) {
                RelativeY = Preferences.ClickOnControlByCoordY;
            }
            
            // 20120823
            //foreach (AutomationElement element in elements){
            
            AutomationElement whereToClick = 
                element;
            WriteVerbose(cmdlet, 
                         "where the click will be performed: " +
                         element.Current.Name);
            AutomationElement whereTheHandle = 
                whereToClick;
            
            if (whereToClick.Current.NativeWindowHandle == 0) {
            
                WriteVerbose(cmdlet, "The handle of this control equals to zero");
                WriteVerbose(cmdlet, "trying to use one of its ancestors");
                
                whereTheHandle = 
                    UIAHelper.GetAncestorWithHandle(whereToClick);
                if (whereTheHandle.Current.NativeWindowHandle == 0) {
                    ErrorRecord err = 
                        new ErrorRecord(new Exception("The handle of this control equals to zero"),
                                        "ZeroHandle",
                                        ErrorCategory.InvalidArgument,
                                        whereTheHandle);
                    err.ErrorDetails = 
                        new ErrorDetails("This control does not have a handle");
                    WriteError(cmdlet, err, true);
                    // return;
                    // 20120209 result = false;
                    // 20120209 return result;
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
                //int relativeX = x - (int)whereTheHandle.Current.BoundingRectangle.X;
                x = RelativeX + (int)whereToClick.Current.BoundingRectangle.X;
                //int relativeY = y - (int)whereTheHandle.Current.BoundingRectangle.Y;
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
// if (RelativeX != 0 && RelativeY != 0) {
// x = RelativeX;
// y = RelativeY;
// WriteVerbose(cmdlet, "coordinates are taken from the input parameters");
// }
// WriteVerbose(cmdlet, "X = " + x.ToString());            
// WriteVerbose(cmdlet, "Y = " + y.ToString());
            
            // PostMessage's (click) second parameter
            uint uDown = 0;
            uint uUp = 0;
            
            // these relative coordinates for SendMessage/PostMessage
            int relativeX = x - (int)whereTheHandle.Current.BoundingRectangle.X;
            int relativeY = y - (int)whereTheHandle.Current.BoundingRectangle.Y;
            
//  // these x and y are window-related coordinates
// if (RelativeX != 0 && RelativeY != 0) {
//  //int relativeX = x - (int)whereTheHandle.Current.BoundingRectangle.X;
// x = RelativeX + (int)whereToClick.Current.BoundingRectangle.X;
//  //int relativeY = y - (int)whereTheHandle.Current.BoundingRectangle.Y;
// y = RelativeY + (int)whereToClick.Current.BoundingRectangle.Y;
// }
            WriteVerbose(cmdlet, "relative X (the base is the control with the handle) = " + relativeX.ToString());            
            WriteVerbose(cmdlet, "relative Y (the base is the control with the handle) = " + relativeY.ToString());
            
            // PostMessage's (click) third and fourth paramters (the third'll be reasigned later)
            System.IntPtr wParamDown = IntPtr.Zero;
            System.IntPtr wParamUp = IntPtr.Zero;
            System.IntPtr lParam = 
                new IntPtr(((new IntPtr(relativeX)).ToInt32() & 0xFFFF) +
                           (((new IntPtr(relativeY)).ToInt32() & 0xFFFF) << 16));
            
            // PostMessage's (keydown/keyup) fourth parameter
            uint uCtrlDown = 0x401D;
            uint uCtrlUp = 0xC01D;
            uint uShiftDown = 0x402A;
            uint uShiftUp = 0xC02A;
            System.IntPtr lParamKeyDown = IntPtr.Zero;
            System.IntPtr lParamKeyUp = IntPtr.Zero;
            
// if (Ctrl) {
// unsafe{
// KEYBDINPUT kb;//={ 0 };
// INPUT Input = new INPUT(); //={ 0 };
//  // if (bExtended)
//  // kb.dwFlags = KEYEVENT_EXTENDEDKEY;
// kb.wVk = (ushort)VK_CONTROL;
// Input.Type = INPUT_KEYBOARD;
// 
//  // Input.Data = kb;
// SendInput(1, Input, sizeof(INPUT));
// }
// }
            
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
            
            System.IntPtr handle =
                    new System.IntPtr(whereTheHandle.Current.NativeWindowHandle);
            WriteVerbose(cmdlet, 
                         "the handle of the element the click will be performed on is " + 
                         handle.ToString());
            
// SetCursorPos((int)whereToClick.Current.BoundingRectangle.X,
// (int)whereToClick.Current.BoundingRectangle.Y);
            WriteVerbose(cmdlet, "X = " + x.ToString());
            WriteVerbose(cmdlet, "Y = " + y.ToString());
            
//  // IntPtr hDesk = OpenInputDesktop(0, true, 0);
//  // IntPtr hDesk = OpenInputDesktop(DF_ALLOWOTHERACCOUNTHOOK, true, GENERIC_ALL);
//  // IntPtr hDesk = OpenInputDesktop(0, true, 0x0000037f);
// 
// IntPtr hOrigThread = GetThreadDesktop(GetCurrentThreadId());
// IntPtr hOrigDesktop = OpenInputDesktop(0, false, DESKTOP_SWITCHDESKTOP);
// WriteVerbose(this, 
// "the handle to the input desktop is " + 
// hOrigDesktop.ToString());
//  // MessageBox.Show(x.ToString());
// bool Success = SetThreadDesktop(hOrigDesktop);
// WriteVerbose(this, 
// "the input desktop has been set (SetThreadDesktop): " + 
// Success.ToString());
// Success = SwitchDesktop(hOrigDesktop);
//  // MessageBox.Show(Success.ToString());
// WriteVerbose(this, 
// "the input desktop has been set (SwitchDesktop): " + 
// Success.ToString());
            
            
//  // Save original desktop
// hOriginalThread = GetThreadDesktop(GetCurrentThreadId());
// hOriginalInput = OpenInputDesktop(0, FALSE, DESKTOP_SWITCHDESKTOP);
//
//  // Create a new Desktop and switch to it
// hNewDesktop = CreateDesktop("NewDesktopName", NULL, NULL, 0, GENERIC_ALL, NULL);
// SetThreadDesktop(hNewDesktop);
// SwitchDesktop(hNewDesktop);
//
//  // Execute thread/process in the new desktop
// StartThread();
// StartProcess();
//
//  // Restore original desktop
// SwitchDesktop(hOriginalInput);
// SetThreadDesktop(hOriginalThread);
//
//  // Close the Desktop
// CloseDesktop(hNewDesktop);
            
            try {
                whereTheHandle.SetFocus();
            } 
            catch { }
            
            bool setCursorPosResult = 
                NativeMethods.SetCursorPos(x, y);
            WriteVerbose(cmdlet, "SetCursorPos result = " + setCursorPosResult.ToString());
            
            System.Threading.Thread.Sleep(Preferences.OnClickDelay);
            
            
            // trying to heal context menu clicks
            System.Diagnostics.Process windowProcess = 
                System.Diagnostics.Process.GetProcessById(
                    whereTheHandle.Current.ProcessId);
            if (windowProcess != null) {
                IntPtr mainWindow = 
                    windowProcess.MainWindowHandle;
                if (mainWindow != IntPtr.Zero) {
// System.IntPtr lParam2 = 
// new IntPtr(((new IntPtr(0x0001)).ToInt32() & 0xFFFF) +
// (((new IntPtr(0x0201)).ToInt32() & 0xFFFF) << 16));
                    System.IntPtr lParam2 = 
                        new IntPtr(((new IntPtr(ulAct)).ToInt32() & 0xFFFF) +
                                   (((new IntPtr(uhAct)).ToInt32() & 0xFFFF) << 16));
                    bool res0 = 
                        // 20130118
                        //NativeMethods.SendMessage1(handle, NativeMethods.WM_MOUSEACTIVATE, 
                        // 20130312
                        NativeMethods.PostMessage1(handle, NativeMethods.WM_MOUSEACTIVATE, 
                                     mainWindow, lParam2);
                    WriteVerbose(this, "WM_MOUSEACTIVATE is sent");
                }
            }
            
// if (Ctrl) {
// PostMessage1(handle, WM_KEYDOWN, new IntPtr(VK_CONTROL), lParamKeyDown);
// }
// if (Shift) {
// PostMessage1(handle, WM_KEYDOWN, new IntPtr(VK_SHIFT), lParamKeyDown);
// }
            
            if (Ctrl) {
// PostMessage1(handle, WM_SYSKEYDOWN, new IntPtr(VK_CONTROL), lParamKeyDown);
// PostMessage1(handle, WM_SYSKEYDOWN, new IntPtr(VK_CONTROL), lParamKeyDown);
// WriteVerbose(this, "WM_SYSKEYDOWN VK_CONTROL");
                // press the control key
                // keybd_event((byte)VK_LCONTROL, 0x45, 0, 0);
                NativeMethods.keybd_event((byte)NativeMethods.VK_LCONTROL, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | 0, 0);
                WriteVerbose(this, " the control button has been pressed");
            }
            if (Shift) {
// PostMessage1(handle, WM_SYSKEYDOWN, new IntPtr(VK_SHIFT), lParamKeyDown);
// PostMessage1(handle, WM_SYSKEYDOWN, new IntPtr(VK_SHIFT), lParamKeyDown);
// WriteVerbose(this, "WM_SYSKEYDOWN VK_SHIFT");
                // press the shift key
                // keybd_event((byte)VK_LSHIFT, 0x45, 0, 0);
                NativeMethods.keybd_event((byte)NativeMethods.VK_LSHIFT, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | 0, 0);
                WriteVerbose(this, " the shift button has been pressed");
            }
            
            // // 20120620 for Home Tab
            bool res1 = NativeMethods.PostMessage1(handle, uDown, wParamDown, lParam);
            // 20130312
            //bool res1 = NativeMethods.SendMessage1(handle, uDown, wParamDown, lParam);
            
            
            // 20130312
            // MouseMove
            if (RightClick || DoubleClick) {
                bool resMM = NativeMethods.PostMessage1(handle, NativeMethods.WM_MOUSEMOVE, wParamDown, lParam);
            }
            
// if (Ctrl) {
//// PostMessage1(handle, WM_SYSKEYDOWN, new IntPtr(VK_CONTROL), lParamKeyDown);
//// PostMessage1(handle, WM_SYSKEYDOWN, new IntPtr(VK_CONTROL), lParamKeyDown);
//// WriteVerbose(this, "WM_SYSKEYDOWN VK_CONTROL");
//  // press the control key
// keybd_event((byte)VK_CONTROL, 0x45, 0, 0);
// }
// if (Shift) {
//// PostMessage1(handle, WM_SYSKEYDOWN, new IntPtr(VK_SHIFT), lParamKeyDown);
//// PostMessage1(handle, WM_SYSKEYDOWN, new IntPtr(VK_SHIFT), lParamKeyDown);
//// WriteVerbose(this, "WM_SYSKEYDOWN VK_SHIFT");
//  // press the shift key
// keybd_event((byte)VK_SHIFT, 0x45, 0, 0);
// }
            
            // bool res2 = PostMessage1(handle, uUp, IntPtr.Zero, lParam);
            // bool res2 = PostMessage1(handle, uUp, wParam, lParam);
            // System.Threading.Thread.Sleep(50);
            
            // // 20120620 for Home Tab
            bool res2 = NativeMethods.PostMessage1(handle, uUp, wParamUp, lParam);
            // 20130312
            //bool res2 = NativeMethods.SendMessage1(handle, uUp, wParamUp, lParam);
            
// if (Ctrl) {
//// PostMessage1(handle, WM_SYSKEYDOWN, new IntPtr(VK_CONTROL), lParamKeyDown);
//// PostMessage1(handle, WM_SYSKEYDOWN, new IntPtr(VK_CONTROL), lParamKeyDown);
//// WriteVerbose(this, "WM_SYSKEYDOWN VK_CONTROL");
// }
// if (Shift) {
//// PostMessage1(handle, WM_SYSKEYDOWN, new IntPtr(VK_SHIFT), lParamKeyDown);
//// PostMessage1(handle, WM_SYSKEYDOWN, new IntPtr(VK_SHIFT), lParamKeyDown);
//// WriteVerbose(this, "WM_SYSKEYDOWN VK_SHIFT");
// }
            
            if (!inSequence) {
                if (Ctrl) {
// PostMessage1(handle, WM_SYSKEYUP, new IntPtr(VK_CONTROL), lParamKeyUp);
// WriteVerbose(this, "WM_SYSKEYUP VK_CONTROL");
                    // ::ZeroMemory
                    // release the control key
                    // keybd_event((byte)VK_LCONTROL, 0x45, KEYEVENTF_KEYUP, 0);
                    NativeMethods.keybd_event((byte)NativeMethods.VK_LCONTROL, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP, 0);
                    WriteVerbose(this, " the control button has been released");
                }
                if (Shift) {
// PostMessage1(handle, WM_SYSKEYUP, new IntPtr(VK_SHIFT), lParamKeyUp);
// WriteVerbose(this, "WM_SYSKEYUP VK_SHIFT");
                    // release the shift key
                    // keybd_event((byte)VK_LSHIFT, 0x45, KEYEVENTF_KEYUP, 0);
                    NativeMethods.keybd_event((byte)NativeMethods.VK_LSHIFT, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP, 0);
                    WriteVerbose(this, " the shift button has been released");
                }
            }
// bool res1 = SendMessage1(handle, uDown, wParam, lParam);
// bool res2 = SendMessage1(handle, uUp, IntPtr.Zero, lParam);

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
            
            //} // 20120823
            
            return result;
        }
        
        internal bool CheckControl(HasControlInputCmdletBase cmdlet)
        {
            bool result = false;
            // string cmdletName = cmdlet.GetType().Name.Replace("UIA", "-UIA");
            // 20120228 string cmdletName = CmdletName(cmdlet);
            
            // 20120823
            foreach (AutomationElement inputObject in cmdlet.InputObject) {
                
            // 20120823
            //if (cmdlet.InputObject == null)
            if (null == inputObject) {
                
            // 20120823
            //{
                //WriteVerbose(cmdletName + ": Control is null");
                this.WriteVerbose(cmdlet, "[checking the control] Control is null");
                if (this.PassThru) {
                    //WriteObject(this, null);
                    // 20120823
                    //WriteObject(this, this.InputObject);
                    this.WriteObject(this, inputObject);
                } else {
                    result = false;
                    this.WriteObject(this, result);
                }
                // 20120830
                //return false;
                result = false;
                return result;
            }
            System.Windows.Automation.AutomationElement _control = null;
            try {
                
                _control = 
                    // 20120823
                    //(System.Windows.Automation.AutomationElement)(cmdlet.InputObject);
                    (AutomationElement)inputObject;
                
                this.WriteVerbose(cmdlet,
                             //"[checking the control] the given control is of the " + 
                             // 20130108
                             "[checking the control] the input control is of the " + 
                             // 20120823
                             //cmdlet.InputObject.Current.ControlType.ProgrammaticName + 
                             inputObject.Current.ControlType.ProgrammaticName +
                             " type");
                
                //WriteVerbose(cmdlet,
                //             "[checking the control] the given control is of the " + 
                //             _control.Current.ControlType.ProgrammaticName + 
                //             " type");
                cmdlet._window = _control;
                
                result = true;
                // WriteObject(result); 
                // there's no need to output the True value
                // since the output will be what we want 
                // (some part of AutomationElement, as an example)
            } catch (Exception eControlTypeException) {
                
                this.WriteDebug(cmdlet, "[checking the control] Control is not an AutomationElement");
                this.WriteDebug(cmdlet, "[checking the control] " + eControlTypeException.Message);
                if (this.PassThru) {
                    
                    // result = null;
                    //WriteObject(this, null);
                    WriteObject(this, _control);
                } else {
                    
                    result = false;
                    this.WriteObject(this, result);
                }
                // result = false;
                // WriteObject(result);
                // return result;
                // 20120830
                //return false;
                result = false;
                return result;
            }
            
            } // 20120823
            
            return result;
        }
        
        #region subscribe to events
        protected internal void SubscribeToEvents(HasControlInputCmdletBase cmdlet,
                                                  AutomationElement inputObject,
                                                  AutomationEvent eventType,
                                                  AutomationProperty prop)
        {
            AutomationEventHandler uiaEventHandler;
            AutomationPropertyChangedEventHandler uiaPropertyChangedEventHandler;
            StructureChangedEventHandler uiaStructureChangedEventHandler;
            AutomationFocusChangedEventHandler uiaFocusChangedEventHandler;
            
            // 20130109
            if (null == CurrentData.Events) {
                CurrentData.InitializeEventCollection();
            }
            
            try {

                CacheRequest cacheRequest = new CacheRequest();
                cacheRequest.AutomationElementMode = AutomationElementMode.Full; //.None;
                cacheRequest.TreeFilter = Automation.RawViewCondition;
                cacheRequest.Add(AutomationElement.NameProperty);
                cacheRequest.Add(AutomationElement.AutomationIdProperty);
                cacheRequest.Add(AutomationElement.ClassNameProperty);
                cacheRequest.Add(AutomationElement.ControlTypeProperty);
                //cacheRequest.Add(AutomationElement.ProcessIdProperty);
                // cache patterns?
                
                // cacheRequest.Activate();
                cacheRequest.Push();
                
                switch (eventType.ProgrammaticName) {
                    case "InvokePatternIdentifiers.InvokedEvent":
                        this.WriteVerbose(cmdlet, "subscribing to the InvokedEvent handler");
                        Automation.AddAutomationEventHandler(
                            InvokePattern.InvokedEvent,
                            inputObject, 
                            TreeScope.Element, // TreeScope.Subtree, // TreeScope.Element,
                            // uiaEventHandler = new AutomationEventHandler(OnUIAutomationEvent));
                            //uiaEventHandler = new AutomationEventHandler(handler));
                            //uiaEventHandler = new AutomationEventHandler(((EventCmdletBase)cmdlet).AutomationEventHandler));
                            uiaEventHandler = new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        UIAHelper.WriteEventToCollection(cmdlet, uiaEventHandler);
                        // 20130327
                        //this.WriteObject(cmdlet, uiaEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    case "TextPatternIdentifiers.TextChangedEvent":
                        this.WriteVerbose(cmdlet, "subscribing to the TextChangedEvent handler");
                        Automation.AddAutomationEventHandler(
                            TextPattern.TextChangedEvent,
                            inputObject, 
                            TreeScope.Element,
                            // uiaEventHandler = new AutomationEventHandler(OnUIAutomationEvent));
                            //uiaEventHandler = new AutomationEventHandler(handler));
                            //uiaEventHandler = new AutomationEventHandler(((EventCmdletBase)cmdlet).AutomationEventHandler));
                            uiaEventHandler = new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        UIAHelper.WriteEventToCollection(cmdlet, uiaEventHandler);
                        // 20130327
                        //this.WriteObject(cmdlet, uiaEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    case "TextPatternIdentifiers.TextSelectionChangedEvent":
                        this.WriteVerbose(cmdlet, "subscribing to the TextSelectionChangedEvent handler");
                        Automation.AddAutomationEventHandler(
                            TextPattern.TextSelectionChangedEvent,
                            inputObject, 
                            TreeScope.Element,
                            // uiaEventHandler = new AutomationEventHandler(OnUIAutomationEvent));
                            //uiaEventHandler = new AutomationEventHandler(handler));
                            //uiaEventHandler = new AutomationEventHandler(((EventCmdletBase)cmdlet).AutomationEventHandler));
                            uiaEventHandler = new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        UIAHelper.WriteEventToCollection(cmdlet, uiaEventHandler);
                        // 20130327
                        //this.WriteObject(cmdlet, uiaEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    case "WindowPatternIdentifiers.WindowOpenedProperty":
                        this.WriteVerbose(cmdlet, "subscribing to the WindowOpenedEvent handler");
                        Automation.AddAutomationEventHandler(
                            WindowPattern.WindowOpenedEvent,
                            inputObject, 
                            TreeScope.Subtree,
                            // uiaEventHandler = new AutomationEventHandler(OnUIAutomationEvent));
                            //uiaEventHandler = new AutomationEventHandler(handler));
                            //uiaEventHandler = new AutomationEventHandler(((EventCmdletBase)cmdlet).AutomationEventHandler));
                            uiaEventHandler = new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        UIAHelper.WriteEventToCollection(cmdlet, uiaEventHandler);
                        // 20130327
                        //this.WriteObject(cmdlet, uiaEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    case "AutomationElementIdentifiers.AutomationPropertyChangedEvent":
                        if (prop != null) {
                            this.WriteVerbose(cmdlet, "subscribing to the AutomationPropertyChangedEvent handler");
                            Automation.AddAutomationPropertyChangedEventHandler(
                                inputObject, 
                                TreeScope.Subtree,
                                uiaPropertyChangedEventHandler = 
                                    // new AutomationPropertyChangedEventHandler(OnUIAutomationPropertyChangedEvent),
                                    //new AutomationPropertyChangedEventHandler(handler),
                                    //new AutomationPropertyChangedEventHandler(((EventCmdletBase)cmdlet).AutomationPropertyChangedEventHandler),
                                    new AutomationPropertyChangedEventHandler(cmdlet.AutomationPropertyChangedEventHandler),
                                prop);
                            UIAHelper.WriteEventToCollection(cmdlet, uiaPropertyChangedEventHandler);
                            // 20130327
                            //this.WriteObject(cmdlet, uiaPropertyChangedEventHandler);
                            if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaPropertyChangedEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        }
                        break;
                    case "AutomationElementIdentifiers.StructureChangedEvent":
                        this.WriteVerbose(cmdlet, "subscribing to the StructureChangedEvent handler");
                        Automation.AddStructureChangedEventHandler(
                            inputObject,
                            TreeScope.Subtree,
                            uiaStructureChangedEventHandler = 
                            // new StructureChangedEventHandler(OnUIStructureChangedEvent));
                            //new StructureChangedEventHandler(handler));
                            //new StructureChangedEventHandler(((EventCmdletBase)cmdlet).StructureChangedEventHandler));
                            new StructureChangedEventHandler(cmdlet.StructureChangedEventHandler));
                        UIAHelper.WriteEventToCollection(cmdlet, uiaStructureChangedEventHandler);
                        // 20130327
                        //this.WriteObject(cmdlet, uiaStructureChangedEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaStructureChangedEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    case "WindowPatternIdentifiers.WindowClosedProperty":
                        this.WriteVerbose(cmdlet, "subscribing to the WindowClosedEvent handler");
                        Automation.AddAutomationEventHandler(
                            WindowPattern.WindowClosedEvent,
                            inputObject, 
                            TreeScope.Subtree,
                            // uiaEventHandler = new AutomationEventHandler(OnUIAutomationEvent));
                            //uiaEventHandler = new AutomationEventHandler(handler));
                            //uiaEventHandler = new AutomationEventHandler(((EventCmdletBase)cmdlet).AutomationEventHandler));
                            uiaEventHandler = new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        UIAHelper.WriteEventToCollection(cmdlet, uiaEventHandler);
                        // 20130327
                        //this.WriteObject(cmdlet, uiaEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    case "AutomationElementIdentifiers.MenuClosedEvent":
                        this.WriteVerbose(cmdlet, "subscribing to the MenuClosedEvent handler");
                        Automation.AddAutomationEventHandler(
                            AutomationElement.MenuClosedEvent,
                            inputObject, 
                            TreeScope.Subtree,
                            uiaEventHandler = new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        UIAHelper.WriteEventToCollection(cmdlet, uiaEventHandler);
                        // 20130327
                        //this.WriteObject(cmdlet, uiaEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    case "AutomationElementIdentifiers.MenuOpenedEvent":
                        this.WriteVerbose(cmdlet, "subscribing to the MenuOpenedEvent handler");
                        Automation.AddAutomationEventHandler(
                            AutomationElement.MenuOpenedEvent,
                            inputObject, 
                            TreeScope.Subtree,
                            uiaEventHandler = new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        UIAHelper.WriteEventToCollection(cmdlet, uiaEventHandler);
                        // 20130327
                        //this.WriteObject(cmdlet, uiaEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    case "AutomationElementIdentifiers.ToolTipClosedEvent":
                        this.WriteVerbose(cmdlet, "subscribing to the ToolTipClosedEvent handler");
                        Automation.AddAutomationEventHandler(
                            AutomationElement.ToolTipClosedEvent,
                            inputObject, 
                            TreeScope.Subtree,
                            uiaEventHandler = new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        UIAHelper.WriteEventToCollection(cmdlet, uiaEventHandler);
                        // 20130327
                        //this.WriteObject(cmdlet, uiaEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    case "AutomationElementIdentifiers.ToolTipOpenedEvent":
                        this.WriteVerbose(cmdlet, "subscribing to the ToolTipOpenedEvent handler");
                        Automation.AddAutomationEventHandler(
                            AutomationElement.ToolTipOpenedEvent,
                            inputObject, 
                            TreeScope.Subtree,
                            uiaEventHandler = new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        UIAHelper.WriteEventToCollection(cmdlet, uiaEventHandler);
                        // 20130327
                        //this.WriteObject(cmdlet, uiaEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    case "AutomationElementIdentifiers.AutomationFocusChangedEvent":
                        WriteVerbose(cmdlet, "subscribing to the AutomationFocusChangedEvent handler");
                        Automation.AddAutomationFocusChangedEventHandler(
                            //AutomationElement.AutomationFocusChangedEvent,
                            //inputObject, 
                            //System.Windows.Automation.AutomationElement.RootElement,
                            //TreeScope.Subtree,
                            uiaFocusChangedEventHandler = new AutomationFocusChangedEventHandler(cmdlet.AutomationEventHandler));
                        UIAHelper.WriteEventToCollection(cmdlet, uiaFocusChangedEventHandler);
                        // 20130327
                        //this.WriteObject(cmdlet, uiaFocusChangedEventHandler);
                        if (cmdlet.PassThru) { cmdlet.WriteObject(cmdlet, uiaFocusChangedEventHandler); } else { cmdlet.WriteObject(cmdlet, true); }
                        break;
                    default:
                        this.WriteVerbose(cmdlet, 
                                     "the following event has not been subscribed to: " + 
                                     eventType.ProgrammaticName);
                        break;
                }
                this.WriteVerbose(cmdlet, "on the object " + inputObject.Current.Name);
                cacheRequest.Pop();
                
            } 
            catch (Exception e) {
// try {
// ErrorRecord err = new ErrorRecord(
// e,
// "RegisteringEvent",
// ErrorCategory.OperationStopped,
// inputObject);
// err.ErrorDetails = 
// new ErrorDetails("Unable to register event handler " +
//  // handler.ToString());
// eventType.ProgrammaticName + 
// " for " + 
// inputObject.Current.Name);
//  // this.OnSuccessAction.ToString());
// WriteError(this, err, false);
// }
// catch {
// ErrorRecord err = new ErrorRecord(
// e,
// "RegisteringEvent",
// ErrorCategory.OperationStopped,
// inputObject);
// err.ErrorDetails = 
// new ErrorDetails("Unable to register event handler " +
// eventType.ProgrammaticName);;
// WriteError(this, err, false);
// }
                
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
            if (this.AutomationProperty == e.Property) {
                
                
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
            if ((e.StructureChangeType == StructureChangeType.ChildAdded && this.Child.ChildAdded) ||
                (e.StructureChangeType == StructureChangeType.ChildRemoved && this.Child.ChildRemoved) ||
                (e.StructureChangeType == StructureChangeType.ChildrenBulkAdded && this.Child.ChildrenBulkAdded) ||
                (e.StructureChangeType == StructureChangeType.ChildrenBulkRemoved && this.Child.ChildrenBulkRemoved) ||
                (e.StructureChangeType == StructureChangeType.ChildrenInvalidated && this.Child.ChildrenInvalidated) ||
                (e.StructureChangeType == StructureChangeType.ChildrenReordered && this.Child.ChildrenReordered)) {
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
        protected internal void OnUIRecordingAutomationEvent(object src, 
                                                             AutomationEventArgs e)
        {
            try { // experimental
        
            AutomationElement sourceElement;
            string elementTitle = String.Empty;
            string elementType = String.Empty;
            AutomationEvent eventId = null;
            
            try {
                sourceElement = src as AutomationElement;
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
                // string elementType = 
                //  // getControlTypeNameOfAutomationElement(sourceElement, sourceElement);
                // sourceElement.Current.ControlType.ProgrammaticName.Substring(
                // sourceElement.Current.ControlType.ProgrammaticName.IndexOf('.') + 1);
                // if (elementType.Length == 0) {
                // return;
                //}
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
                        ((System.Collections.ArrayList)this.Recording[this.Recording.Count - 1])[0].ToString()) {
                        ((System.Collections.ArrayList)this.Recording[this.Recording.Count - 1]).Insert(0, whatToWrite);
                    }
                }
            //} catch { return; }
            
            
            } catch (Exception eUnknown) {
                // WriteVerbose("!!!OnUIRecording " + eUnknown.Message);
                WriteDebug(this, eUnknown.Message);
            } // experimental
            try {
                WriteVerbose(this, e.EventId + "on " + (src as AutomationElement) + " fired");
            } catch { }
        }
        #endregion Event handling for recording
        
        #region checker event handler inputs
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "check")]
        protected bool checkNotNull(object objectToTest, AutomationEventArgs e)
        {
            AutomationElement sourceElement;
            try {
                sourceElement = objectToTest as AutomationElement;
                this.EventSource = sourceElement;
                this.EventArgs = e;
            } 
            catch { //(ElementNotAvailableException eNotAvailable) {
                return false;
            }
            return true;
        }
        #endregion checker event handler inputs

        protected internal bool TestControlByPropertiesFromHashtable(
            // 20130315
            AutomationElement[] inputElements,
            System.Collections.Hashtable[] SearchCriteria,
            int timeout)
        {
            
            bool result = false;
            for (int i = 0; i < SearchCriteria.Length; i++) {
                
                // 20120917
//                string className = string.Empty;
//                string controlType = string.Empty;
//                string name = string.Empty;
//                string automationId = string.Empty;
                
                // 20120917
                // 20130318
                //System.Collections.Generic.Dictionary<string, string> dict = 
                //    this.ConvertHashtableToDictionary(SearchCriteria[i]);
                System.Collections.Generic.Dictionary<string, object> dict =
                    this.ConvertHashtableToDictionary(SearchCriteria[i]);
                
                
                
//                foreach(System.Collections.Generic.KeyValuePair<string, string> entry in dict) {
//                    this.WriteVerbose(this, entry.Key);
//                    this.WriteVerbose(this, entry.Value);
//                }
                
                
                
                // 20120917

                GetControlCmdletBase cmdlet = 
                    new GetControlCmdletBase();

                // 20120917
//                cmdlet.Class = className;
//                cmdlet.AutomationId = automationId;
//                cmdlet.ControlType = controlType;
//                cmdlet.Name = name;
                
                // 20120917
                // 20130318
                //try{ cmdlet.Class = dict["CLASS"]; } catch {}
                try{ cmdlet.Class = dict["CLASS"].ToString(); } catch {}
                // 20130318
                //try{ cmdlet.AutomationId = dict["AUTOMATIONID"]; } catch {}
                try{ cmdlet.AutomationId = dict["AUTOMATIONID"].ToString(); } catch {}
                // 20130318
                //try{ cmdlet.ControlType = dict["CONTROLTYPE"]; } catch {}
                try{ cmdlet.ControlType = dict["CONTROLTYPE"].ToString(); } catch {}
                // 20130318
                //try{ cmdlet.Name = dict["NAME"]; } catch {}
                try{ cmdlet.Name = dict["NAME"].ToString(); } catch {}
                // 20130315
                // 20130318
                //try{ cmdlet.Value = dict["VALUE"]; } catch {}
                try{ cmdlet.Value = dict["VALUE"].ToString(); } catch {}
                
//                this.WriteVerbose(this, cmdlet.Name);
                
                
                cmdlet.Timeout = timeout;
                
                // 20130315
                if (null != inputElements && null != (inputElements as AutomationElement[]) && 0 < inputElements.Length) {
                    cmdlet.InputObject = inputElements;
                } else {
                    if (UIAutomation.CurrentData.CurrentWindow == null) {
                    // WriteVerbose(this, " ==  == <<<<<<<<<<<<<<<<<!!!!!!!!!!!!!!!!!!!!!!  UIAutomation.CurrentData.CurrentWindow == null  !!!!!!!!!!!!! >  >  >  >  >  >  >  >  >  >  >  ==  ==  ==  ==  == =");
                    // WriteVerbose(this, "exiting");
                        return result;
                    }
                    // 20120824
                    //cmdlet.InputObject = UIAutomation.CurrentData.CurrentWindow;
                    // 20130315
                    //cmdlet.InputObject[0] = UIAutomation.CurrentData.CurrentWindow;
                    cmdlet.InputObject = new AutomationElement[]{ UIAutomation.CurrentData.CurrentWindow };
                }
                //cmdlet._window = //UIAutomation.CurrentData.CurrentWindow;
                // (System.Windows.Automation.AutomationElement)(cmdlet.InputObject);
                //AutomationElement elementToWorkWith = getControl(this);
                WriteVerbose(this, "getting the control");
                // 20120824
                //AutomationElement elementToWorkWith = getControl(cmdlet);
                //AutomationElementCollection elementsToWorkWith = getControl(cmdlet);
                // 20120824
                ArrayList elementsToWorkWith = GetControl(cmdlet);
                // 20120824
                //if (elementToWorkWith == null) {
                if (null == elementsToWorkWith) {

                    WriteVerbose(this, "couldn't get the control(s)");
                    //WriteObject(this, false);
                    return result;
                } else {

                    // 20120824
                    foreach (AutomationElement elementToWorkWith in elementsToWorkWith) {

                    WriteVerbose(this, "found the control:");
                    try {WriteVerbose(this, "Name = " + elementToWorkWith.Current.Name); }catch {}
                    try {WriteVerbose(this, "AutomationId = " + elementToWorkWith.Current.AutomationId); }catch {}
                    try {WriteVerbose(this, "ClassName = " + elementToWorkWith.Current.ClassName); }catch {}
                    try {WriteVerbose(this, "ControlType = " + elementToWorkWith.Current.ControlType.ProgrammaticName); }catch {}
                    
                    // 20130423
                    // // 20120917
                    //result = testControlByPropertiesFromDictionary(dict, elementToWorkWith);
                    //if (! result) {
                    //    return result;
                    //}
                    
                    // 20130423
                    result =
                        testControlByPropertiesFromDictionary(
                            //this.ConvertHashtableToDictionary(hashtable),
                            dict,
                            elementToWorkWith);
                    
                    if (result) {
                        
                        // 20130423
                        if (Preferences.HighlightCheckedControl) {
                            UIAHelper.HighlightCheckedControl(elementToWorkWith);
                        }
                        
                        return result;
                    }
                    
                    
// 20120917
                    
                    } // 20120824
                }
            }
            //WriteObject(this, true);

            // 20120917
            //result = true;
            return result;
        }
    }
}