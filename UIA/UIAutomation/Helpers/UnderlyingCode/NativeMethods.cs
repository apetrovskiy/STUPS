/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/5/2012
 * Time: 9:29 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Runtime.InteropServices;
    // http://msdn.microsoft.com/ru-ru/library/windows/desktop/aa379560(v=vs.85).aspx
    using DWORD = System.UInt32; // Optional alias, used below.
    using System.ComponentModel;
    
    /// <summary>
    /// Description of NativeMethods.
    /// </summary>
    internal static class NativeMethods
    {
        static NativeMethods()
        {
        }
        
        #region Screenshot taking
        [DllImport("user32.dll")] 
        internal extern static IntPtr GetDesktopWindow();
  
        [DllImport("user32.dll")] 
        internal static extern IntPtr GetWindowDC(IntPtr hwnd);
         
        [DllImport("user32.dll")] 
        internal static extern IntPtr ReleaseDC(IntPtr hwnd, IntPtr hDc); 
  
        [DllImport("gdi32.dll")] 
         internal static extern UInt64 BitBlt 
             (IntPtr hDestDC, 
             int x, int y, int nWidth, int nHeight, 
             IntPtr hSrcDC, 
             int xSrc, int ySrc, 
             System.Int32 dwRop); 
         
        [Flags]
        internal enum DrawingOptions
        {
            PRF_CHECKVISIBLE = 0x00000001,
            PRF_NONCLIENT = 0x00000002,
            PRF_CLIENT = 0x00000004,
            PRF_ERASEBKGND = 0x00000008,
            PRF_CHILDREN = 0x00000010,
            PRF_OWNED = 0x00000020
        }

        internal const int WM_PRINT = 0x0317;
        internal const int WM_PRINTCLIENT = 0x0318;

        [DllImport("user32.dll")]
        internal static extern int SendMessage(IntPtr hWnd, int msg, IntPtr dc,
            DrawingOptions opts);

        #endregion Screenshot taking
        
        [DllImport("user32.dll")] 
        internal extern static IntPtr GetFocus();
        
        #region getting a control
        [DllImport("user32.dll", EntryPoint="FindWindowEx", CharSet=CharSet.Auto)]
        internal static extern IntPtr FindWindowEx(IntPtr hwndParent, 
                                          IntPtr hwndChildAfter,
                                          string lpszClass,
                                          string lpszWindow);
        
        [DllImport("user32.dll", EntryPoint="FindWindowEx", CharSet=CharSet.Auto)]
        internal static extern IntPtr GetClassName(IntPtr hwnd,
                                                   string lpClassName,
                                                   int maxCount);
        
        // 20121022
        //DllImport("user32.dll", SetLastError = true)]
//        [DllImport("user32.dll", EntryPoint="FindWindowEx", CharSet=CharSet.Auto)]
//        public static extern IntPtr FindWindowEx(IntPtr parentHandle, 
//                                                     IntPtr childAfter, 
//                                                     string className, 
//                                                     string windowTitle);
        
        
//int WINAPI GetClassName(
//  _In_   HWND hWnd,
//  _Out_  LPTSTR lpClassName,
//  _In_   int nMaxCount
//);
        
        #endregion getting a control
        
        #region getting windows
        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        //public static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);
        internal static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);
        #endregion getting windows
        
        #region Highligher
        internal struct CursorPoint
        {
            internal int X;
            internal int Y;
        }
        
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetPhysicalCursorPos(ref CursorPoint lpPoint);
        
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool PhysicalToLogicalPoint(IntPtr hWnd, ref CursorPoint lpPoint);
        #endregion Highlighter
        
        #region remoting
//        [StructLayout(LayoutKind.Sequential)]
//        public struct SECURITY_ATTRIBUTES
//        {
//            public DWORD nLength;
//            public IntPtr lpSecurityDescriptor;
//            public bool bInheritHandle;
//        }
//        
//        [DllImport("advapi32.dll", CharSet=CharSet.Auto, SetLastError=true)]
//        internal static extern bool CreateProcessAsUser(
//            SafeHandle hToken,
//            string lpApplicationName,
//            string lpCommandLine,
//            SECURITY_ATTRIBUTES lpProcessAttributes,
//            SECURITY_ATTRIBUTES lpThreadAttributes,
//            bool bInheritHandles,
//            int dwCreationFlags,
//            HandleRef lpEnvironment,
//            string lpCurrentDirectory,
//            STARTUPINFO lpStartupInfo,
//            PROCESS_INFORMATION lpProcessInformation);


//Code Snippet
//#include "userenv.h"
//// Global Typedefs for function pointers in USERENV.DLL
//typedef BOOL (STDMETHODCALLTYPE FAR * LPFNCREATEENVIRONMENTBLOCK)
//    ( LPVOID  *lpEnvironment,
//      HANDLE  hToken,
//      BOOL    bInherit );
//typedef BOOL (STDMETHODCALLTYPE FAR * LPFNDESTROYENVIRONMENTBLOCK)
//    ( LPVOID lpEnvironment );
//void InvokeApp()
//{
//    // Local Variable Declarations
//    HANDLE hToken    = NULL;
//    HANDLE hTokenDup = NULL;
//    STARTUPINFO si;
//    PROCESS_INFORMATION pi;
//    ZeroMemory( &si, sizeof( STARTUPINFO ) );
//    ZeroMemory( &pi, sizeof( PROCESS_INFORMATION ) );
//    
//    si.cb = sizeof( STARTUPINFO );
//    si.lpDesktop = _T("Winsta0\\Default");
//    
//    DWORD  dwCreationFlag = NORMAL_PRIORITY_CLASS | CREATE_NEW_CONSOLE;
//    LPVOID pEnvironment = NULL;
//    LPFNCREATEENVIRONMENTBLOCK  lpfnCreateEnvironmentBlock  = NULL;
//    LPFNDESTROYENVIRONMENTBLOCK lpfnDestroyEnvironmentBlock = NULL;
//    HMODULE hUserEnvLib = NULL;
//    hUserEnvLib = LoadLibrary( _T("userenv.dll") );
//    if ( NULL != hUserEnvLib ) {
//        lpfnCreateEnvironmentBlock  = (LPFNCREATEENVIRONMENTBLOCK)
//        GetProcAddress( hUserEnvLib, "CreateEnvironmentBlock" );
//        
//        lpfnDestroyEnvironmentBlock = (LPFNDESTROYENVIRONMENTBLOCK)
//        GetProcAddress( hUserEnvLib, "DestroyEnvironmentBlock" );
//    }
//    OpenThreadToken( GetCurrentThread(), TOKEN_DUPLICATE, TRUE, &hToken );
//    DuplicateTokenEx( hToken,
//                      TOKEN_IMPERSONATE|TOKEN_READ|TOKEN_ASSIGN_PRIMARY|TOKEN_DUPLICATE,
//                      NULL, SecurityImpersonation, TokenPrimary, &hTokenDup );
//    RevertToSelf( );
//    CloseHandle( hToken );
//    if ( NULL != lpfnCreateEnvironmentBlock ) {
//        if ( lpfnCreateEnvironmentBlock( &pEnvironment, hTokenDup, FALSE ) ) {
//            dwCreationFlag |= CREATE_UNICODE_ENVIRONMENT;   // must specify
//        }
//        else {
//            pEnvironment = NULL;
//            OutputDebugString( _T(" CreateEnvironmentBlock() -- FAILED") );
//        }
//    }
//    else {
//        OutputDebugString(_T(" FAILED - GetProcAddress(CreateEnvironmentBlock)"));
//    }
//    CreateProcessAsUser( hTokenDup, NULL, _T("c:\\windows\\notepad.exe"),
//                         NULL, NULL, FALSE, dwCreationFlag,
//                         pEnvironment, NULL, &si, &pi );
//    if ( NULL != lpfnDestroyEnvironmentBlock )
//        lpfnDestroyEnvironmentBlock( pEnvironment );
//    if ( NULL != hUserEnvLib ) FreeLibrary( hUserEnvLib );
//    CloseHandle( hTokenDup );
//}
//What I fixed? The issue I was facing was that the application I wanted my Print Monitor to launch using CreateProcessAsUser() was not getting the logged-on user's environment. The after-effect was that, because of this reason, when my application used to show the File Open common dialog box, it would behave strange while trying to browse to the Desktop in it. This was in Vista.
// 
//In Windows XP, the File Open dialog would let you browse to the Desktop folder but the object icons on the Desktop would not appear right in it.
// 
//Now it works. Thanks for your help, suggestions etc. Have a nice day. 

        #endregion remoting
        
        #region the click
        #region declarations
        // http://msdn.microsoft.com/en-us/library/windows/desktop/ms646244(v=vs.85).aspx
        internal static uint WM_MOUSEACTIVATE             = 0x0021;
        internal static uint WM_MOUSEMOVE                 = 0x0200;
        internal static uint WM_LBUTTONDOWN               = 0x0201;
        internal static uint WM_LBUTTONUP                 = 0x0202;
        internal static uint WM_LBUTTONDBLCLK             = 0x0203;
        internal static uint WM_RBUTTONDOWN               = 0x0204;
        internal static uint WM_RBUTTONUP                 = 0x0205;
        internal static uint WM_RBUTTONDBLCLK             = 0x0206;
        internal static uint WM_MBUTTONDOWN               = 0x0207;
        internal static uint WM_MBUTTONUP                 = 0x0208;
        internal static uint WM_MBUTTONDBLCLK             = 0x0209;
        
        internal static uint MK_CONTROL                    = 0x0008;    // The CTRL key is down.
        internal static uint MK_LBUTTON                    = 0x0001;    // The left mouse button is down.
        internal static uint MK_MBUTTON                    = 0x0010;    // The middle mouse button is down.
        internal static uint MK_RBUTTON                    = 0x0002;    // The right mouse button is down.
        internal static uint MK_SHIFT                        = 0x0004;    // The SHIFT key is down.
        // 20120206 internal static uint MK_XBUTTON1                    = 0x0020;    // The first X button is down.
        // 20120206 internal static uint MK_XBUTTON2                    = 0x0040;    // The second X button is down.
        
        internal static uint WM_KEYDOWN                   = 0x0100;
        internal static uint WM_KEYUP                     = 0x0101;
        internal static uint WM_SYSKEYDOWN                = 0x0104;
        internal static uint WM_SYSKEYUP                  = 0x0105;
        
//        // http://msdn.microsoft.com/en-us/library/ms927178.aspx
//        internal static uint VK_SHIFT                        = 0x0010;    // SHIFT key
//        internal static uint VK_CONTROL                    = 0x0011;    // CTRL key
//        
//        internal static uint VK_LSHIFT                    = 0xA0;    // Left SHIFT
//        internal static uint VK_RSHIFT                    = 0xA1;    // Right SHIFT
//        internal static uint VK_LCONTROL                    = 0xA2;    // Left CTRL
//        internal static uint VK_RCONTROL                    = 0xA3;    // Right CTRL
        
        
        
        
        // http://msdn.microsoft.com/en-us/library/windows/desktop/dd375731(v=vs.85).aspx
        internal static byte VK_LBUTTON = 0x01; // Left mouse button
        internal static byte VK_RBUTTON = 0x02; // Right mouse button
        internal static byte VK_CANCEL = 0x03; // Control-break processing
        internal static byte VK_MBUTTON = 0x04; // Middle mouse button (three-button mouse)
        internal static byte VK_XBUTTON1 = 0x05; // X1 mouse button
        internal static byte VK_XBUTTON2 = 0x06; // X2 mouse button
        internal static byte VK_0x07 = 0x07; // Undefined
        internal static byte VK_BACK = 0x08; // BACKSPACE key
        internal static byte VK_TAB = 0x09; // TAB key
        internal static byte VK_0x0A = 0x0A; // Reserved
        internal static byte VK_0x0B = 0x0B; // Reserved
        internal static byte VK_CLEAR = 0x0C; // CLEAR key
        internal static byte VK_RETURN = 0x0D; // ENTER key
        internal static byte VK_0x0E = 0x0E; // Undefined
        internal static byte VK_0x0F = 0x0F; // Undefined
        internal static byte VK_SHIFT = 0x10; // SHIFT key
        internal static byte VK_CONTROL = 0x11; // CTRL key
        internal static byte VK_MENU = 0x12; // ALT key
        internal static byte VK_PAUSE = 0x13; // PAUSE key
        internal static byte VK_CAPITAL = 0x14; // CAPS LOCK key
        internal static byte VK_KANA = 0x15; // IME Kana mode
        internal static byte VK_HANGUEL = 0x15; // IME Hanguel mode (maintained for compatibility; use VK_HANGUL)
        internal static byte VK_HANGUL = 0x15; // IME Hangul mode
        internal static byte VK_0x16 = 0x16; // Undefined
        internal static byte VK_JUNJA = 0x17; // IME Junja mode
        internal static byte VK_FINAL = 0x18; // IME final mode
        internal static byte VK_HANJA = 0x19; // IME Hanja mode
        internal static byte VK_KANJI = 0x19; // IME Kanji mode
        internal static byte VK_0x1A = 0x1A; // Undefined
        internal static byte VK_ESCAPE = 0x1B; // ESC key
        internal static byte VK_CONVERT = 0x1C; // IME convert
        internal static byte VK_NONCONVERT = 0x1D; // IME nonconvert
        internal static byte VK_ACCEPT = 0x1E; // IME accept
        internal static byte VK_MODECHANGE = 0x1F; // IME mode change request
        internal static byte VK_SPACE = 0x20; // SPACEBAR
        internal static byte VK_PRIOR = 0x21; // PAGE UP key
        internal static byte VK_NEXT = 0x22; // PAGE DOWN key
        internal static byte VK_END = 0x23; // END key
        internal static byte VK_HOME = 0x24; // HOME key
        internal static byte VK_LEFT = 0x25; // LEFT ARROW key
        internal static byte VK_UP = 0x26; // UP ARROW key
        internal static byte VK_RIGHT = 0x27; // RIGHT ARROW key
        internal static byte VK_DOWN = 0x28; // DOWN ARROW key
        internal static byte VK_SELECT = 0x29; // SELECT key
        internal static byte VK_PRINT = 0x2A; // PRINT key
        internal static byte VK_EXECUTE = 0x2B; // EXECUTE key
        internal static byte VK_SNAPSHOT = 0x2C; // PRINT SCREEN key
        internal static byte VK_INSERT = 0x2D; // INS key
        internal static byte VK_DELETE = 0x2E; // DEL key
        internal static byte VK_HELP = 0x2F; // HELP key
        internal static byte VK_0x30 = 0x30; // 0 key
        internal static byte VK_0x31 = 0x31; // 1 key
        internal static byte VK_0x32 = 0x32; // 2 key
        internal static byte VK_0x33 = 0x33; // 3 key
        internal static byte VK_0x34 = 0x34; // 4 key
        internal static byte VK_0x35 = 0x35; // 5 key
        internal static byte VK_0x36 = 0x36; // 6 key
        internal static byte VK_0x37 = 0x37; // 7 key
        internal static byte VK_0x38 = 0x38; // 8 key
        internal static byte VK_0x39 = 0x39; // 9 key
        internal static byte VK_0x3A = 0x3A; // Undefined
        internal static byte VK_0x3B = 0x3B; // Undefined
        internal static byte VK_0x3C = 0x3C; // Undefined
        internal static byte VK_0x3D = 0x3D; // Undefined
        internal static byte VK_0x3E = 0x3E; // Undefined
        internal static byte VK_0x3F = 0x3F; // Undefined
        internal static byte VK_0x40 = 0x40; // Undefined
        internal static byte VK_0x41 = 0x41; // A key
        internal static byte VK_0x42 = 0x42; // B key
        internal static byte VK_0x43 = 0x43; // C key
        internal static byte VK_0x44 = 0x44; // D key
        internal static byte VK_0x45 = 0x45; // E key
        internal static byte VK_0x46 = 0x46; // F key
        internal static byte VK_0x47 = 0x47; // G key
        internal static byte VK_0x48 = 0x48; // H key
        internal static byte VK_0x49 = 0x49; // I key
        internal static byte VK_0x4A = 0x4A; // J key
        internal static byte VK_0x4B = 0x4B; // K key
        internal static byte VK_0x4C = 0x4C; // L key
        internal static byte VK_0x4D = 0x4D; // M key
        internal static byte VK_0x4E = 0x4E; // N key
        internal static byte VK_0x4F = 0x4F; // O key
        internal static byte VK_0x50 = 0x50; // P key
        internal static byte VK_0x51 = 0x51; // Q key
        internal static byte VK_0x52 = 0x52; // R key
        internal static byte VK_0x53 = 0x53; // S key
        internal static byte VK_0x54 = 0x54; // T key
        internal static byte VK_0x55 = 0x55; // U key
        internal static byte VK_0x56 = 0x56; // V key
        internal static byte VK_0x57 = 0x57; // W key
        internal static byte VK_0x58 = 0x58; // X key
        internal static byte VK_0x59 = 0x59; // Y key
        internal static byte VK_0x5A = 0x5A; // Z key
        internal static byte VK_LWIN = 0x5B; // Left Windows key (Natural keyboard)
        internal static byte VK_RWIN = 0x5C; // Right Windows key (Natural keyboard)
        internal static byte VK_APPS = 0x5D; // Applications key (Natural keyboard)
        internal static byte VK_0x5E = 0x5E; // Reserved
        internal static byte VK_SLEEP = 0x5F; // Computer Sleep key
        internal static byte VK_NUMPAD0 = 0x60; // Numeric keypad 0 key
        internal static byte VK_NUMPAD1 = 0x61; // Numeric keypad 1 key
        internal static byte VK_NUMPAD2 = 0x62; // Numeric keypad 2 key
        internal static byte VK_NUMPAD3 = 0x63; // Numeric keypad 3 key
        internal static byte VK_NUMPAD4 = 0x64; // Numeric keypad 4 key
        internal static byte VK_NUMPAD5 = 0x65; // Numeric keypad 5 key
        internal static byte VK_NUMPAD6 = 0x66; // Numeric keypad 6 key
        internal static byte VK_NUMPAD7 = 0x67; // Numeric keypad 7 key
        internal static byte VK_NUMPAD8 = 0x68; // Numeric keypad 8 key
        internal static byte VK_NUMPAD9 = 0x69; // Numeric keypad 9 key
        internal static byte VK_MULTIPLY = 0x6A; // Multiply key
        internal static byte VK_ADD = 0x6B; // Add key
        internal static byte VK_SEPARATOR = 0x6C; // Separator key
        internal static byte VK_SUBTRACT = 0x6D; // Subtract key
        internal static byte VK_DECIMAL = 0x6E; // Decimal key
        internal static byte VK_DIVIDE = 0x6F; // Divide key
        internal static byte VK_F1 = 0x70; // F1 key
        internal static byte VK_F2 = 0x71; // F2 key
        internal static byte VK_F3 = 0x72; // F3 key
        internal static byte VK_F4 = 0x73; // F4 key
        internal static byte VK_F5 = 0x74; // F5 key
        internal static byte VK_F6 = 0x75; // F6 key
        internal static byte VK_F7 = 0x76; // F7 key
        internal static byte VK_F8 = 0x77; // F8 key
        internal static byte VK_F9 = 0x78; // F9 key
        internal static byte VK_F10 = 0x79; // F10 key
        internal static byte VK_F11 = 0x7A; // F11 key
        internal static byte VK_F12 = 0x7B; // F12 key
        internal static byte VK_F13 = 0x7C; // F13 key
        internal static byte VK_F14 = 0x7D; // F14 key
        internal static byte VK_F15 = 0x7E; // F15 key
        internal static byte VK_F16 = 0x7F; // F16 key
        internal static byte VK_F17 = 0x80; // F17 key
        internal static byte VK_F18 = 0x81; // F18 key
        internal static byte VK_F19 = 0x82; // F19 key
        internal static byte VK_F20 = 0x83; // F20 key
        internal static byte VK_F21 = 0x84; // F21 key
        internal static byte VK_F22 = 0x85; // F22 key
        internal static byte VK_F23 = 0x86; // F23 key
        internal static byte VK_F24 = 0x87; // F24 key
        internal static byte VK_0x88 = 0x88; // Unassigned
        internal static byte VK_0x89 = 0x89; // Unassigned
        internal static byte VK_0x8A = 0x8A; // Unassigned
        internal static byte VK_0x8B = 0x8B; // Unassigned
        internal static byte VK_0x8C = 0x8C; // Unassigned
        internal static byte VK_0x8D = 0x8D; // Unassigned
        internal static byte VK_0x8E = 0x8E; // Unassigned
        internal static byte VK_0x8F = 0x8F; // Unassigned
        internal static byte VK_NUMLOCK = 0x90; // NUM LOCK key
        internal static byte VK_SCROLL = 0x91; // SCROLL LOCK key
        internal static byte VK_0x92 = 0x92; // OEM specific
        internal static byte VK_0x93 = 0x93; // OEM specific
        internal static byte VK_0x94 = 0x94; // OEM specific
        internal static byte VK_0x95 = 0x95; // OEM specific
        internal static byte VK_0x96 = 0x96; // OEM specific
        internal static byte VK_0x97 = 0x97; // Unassigned
        internal static byte VK_0x98 = 0x98; // Unassigned
        internal static byte VK_0x99 = 0x99; // Unassigned
        internal static byte VK_0x9A = 0x9A; // Unassigned
        internal static byte VK_0x9B = 0x9B; // Unassigned
        internal static byte VK_0x9C = 0x9C; // Unassigned
        internal static byte VK_0x9D = 0x9D; // Unassigned
        internal static byte VK_0x9E = 0x9E; // Unassigned
        internal static byte VK_0x9F = 0x9F; // Unassigned
        internal static byte VK_LSHIFT = 0xA0; // Left SHIFT key
        internal static byte VK_RSHIFT = 0xA1; // Right SHIFT key
        internal static byte VK_LCONTROL = 0xA2; // Left CONTROL key
        internal static byte VK_RCONTROL = 0xA3; // Right CONTROL key
        internal static byte VK_LMENU = 0xA4; // Left MENU key
        internal static byte VK_RMENU = 0xA5; // Right MENU key
        internal static byte VK_BROWSER_BACK = 0xA6; // Browser Back key
        internal static byte VK_BROWSER_FORWARD = 0xA7; // Browser Forward key
        internal static byte VK_BROWSER_REFRESH = 0xA8; // Browser Refresh key
        internal static byte VK_BROWSER_STOP = 0xA9; // Browser Stop key
        internal static byte VK_BROWSER_SEARCH = 0xAA; // Browser Search key
        internal static byte VK_BROWSER_FAVORITES = 0xAB; // Browser Favorites key
        internal static byte VK_BROWSER_HOME = 0xAC; // Browser Start and Home key
        internal static byte VK_VOLUME_MUTE = 0xAD; // Volume Mute key
        internal static byte VK_VOLUME_DOWN = 0xAE; // Volume Down key
        internal static byte VK_VOLUME_UP = 0xAF; // Volume Up key
        internal static byte VK_MEDIA_NEXT_TRACK = 0xB0; // Next Track key
        internal static byte VK_MEDIA_PREV_TRACK = 0xB1; // Previous Track key
        internal static byte VK_MEDIA_STOP = 0xB2; // Stop Media key
        internal static byte VK_MEDIA_PLAY_PAUSE = 0xB3; // Play/Pause Media key
        internal static byte VK_LAUNCH_MAIL = 0xB4; // Start Mail key
        internal static byte VK_LAUNCH_MEDIA_SELECT = 0xB5; // Select Media key
        internal static byte VK_LAUNCH_APP1 = 0xB6; // Start Application 1 key
        internal static byte VK_LAUNCH_APP2 = 0xB7; // Start Application 2 key
        internal static byte VK_0xB8 = 0xB8; // Reserved
        internal static byte VK_0xB9 = 0xB9; // Reserved
        internal static byte VK_OEM_1 = 0xBA; // Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the ';:' key
        internal static byte VK_OEM_PLUS = 0xBB; // For any country/region, the '+' key
        internal static byte VK_OEM_COMMA = 0xBC; // For any country/region, the ',' key
        internal static byte VK_OEM_MINUS = 0xBD; // For any country/region, the '-' key
        internal static byte VK_OEM_PERIOD = 0xBE; // For any country/region, the '.' key
        internal static byte VK_OEM_2 = 0xBF; // Used for miscellaneous characters; it can vary by keyboard.
        internal static byte VK_OEM_3 = 0xC0; // Used for miscellaneous characters; it can vary by keyboard.
        internal static byte VK_0xC1 = 0xC1; // Reserved
        internal static byte VK_0xC2 = 0xC2; // Reserved
        internal static byte VK_0xC3 = 0xC3; // Reserved
        internal static byte VK_0xC4 = 0xC4; // Reserved
        internal static byte VK_0xC5 = 0xC5; // Reserved
        internal static byte VK_0xC6 = 0xC6; // Reserved
        internal static byte VK_0xC7 = 0xC7; // Reserved
        internal static byte VK_0xC8 = 0xC8; // Reserved
        internal static byte VK_0xC9 = 0xC9; // Reserved
        internal static byte VK_0xCA = 0xCA; // Reserved
        internal static byte VK_0xCB = 0xCB; // Reserved
        internal static byte VK_0xCC = 0xCC; // Reserved
        internal static byte VK_0xCD = 0xCD; // Reserved
        internal static byte VK_0xCE = 0xCE; // Reserved
        internal static byte VK_0xCF = 0xCF; // Reserved
        internal static byte VK_0xD0 = 0xD0; // Reserved
        internal static byte VK_0xD1 = 0xD1; // Reserved
        internal static byte VK_0xD2 = 0xD2; // Reserved
        internal static byte VK_0xD3 = 0xD3; // Reserved
        internal static byte VK_0xD4 = 0xD4; // Reserved
        internal static byte VK_0xD5 = 0xD5; // Reserved
        internal static byte VK_0xD6 = 0xD6; // Reserved
        internal static byte VK_0xD7 = 0xD7; // Reserved
        internal static byte VK_0xD8 = 0xD8; // Unassigned
        internal static byte VK_0xD9 = 0xD9; // Unassigned
        internal static byte VK_0xDA = 0xDA; // Unassigned
        internal static byte VK_OEM_4 = 0xDB; // Used for miscellaneous characters; it can vary by keyboard.
        internal static byte VK_OEM_5 = 0xDC; // Used for miscellaneous characters; it can vary by keyboard.
        internal static byte VK_OEM_6 = 0xDD; // Used for miscellaneous characters; it can vary by keyboard.
        internal static byte VK_OEM_7 = 0xDE; // Used for miscellaneous characters; it can vary by keyboard.
        internal static byte VK_OEM_8 = 0xDF; // Used for miscellaneous characters; it can vary by keyboard.
        internal static byte VK_0xE0 = 0xE0; // Reserved
        internal static byte VK_0xE1 = 0xE1; // OEM specific
        internal static byte VK_OEM_102 = 0xE2; // Either the angle bracket key or the backslash key on the RT 102-key keyboard
        internal static byte VK_0xE3 = 0xE3; // OEM specific
        internal static byte VK_0xE4 = 0xE4; // OEM specific
        internal static byte VK_PROCESSKEY = 0xE5; // IME PROCESS key
        internal static byte VK_0xE6 = 0xE6; // OEM specific
        internal static byte VK_PACKET = 0xE7; // Used to pass Unicode characters as if they were keystrokes. The VK_PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods. For more information, see Remark in KEYBDINPUT,SendInput, WM_KEYDOWN, and WM_KEYUP
        internal static byte VK_0xE8 = 0xE8; // Unassigned
        internal static byte VK_0xE9 = 0xE9; // OEM specific
        internal static byte VK_0xEA = 0xEA; // OEM specific
        internal static byte VK_0xEB = 0xEB; // OEM specific
        internal static byte VK_0xEC = 0xEC; // OEM specific
        internal static byte VK_0xED = 0xED; // OEM specific
        internal static byte VK_0xEE = 0xEE; // OEM specific
        internal static byte VK_0xEF = 0xEF; // OEM specific
        internal static byte VK_0xF0 = 0xF0; // OEM specific
        internal static byte VK_0xF1 = 0xF1; // OEM specific
        internal static byte VK_0xF2 = 0xF2; // OEM specific
        internal static byte VK_0xF3 = 0xF3; // OEM specific
        internal static byte VK_0xF4 = 0xF4; // OEM specific
        internal static byte VK_0xF5 = 0xF5; // OEM specific
        internal static byte VK_ATTN = 0xF6; // Attn key
        internal static byte VK_CRSEL = 0xF7; // CrSel key
        internal static byte VK_EXSEL = 0xF8; // ExSel key
        internal static byte VK_EREOF = 0xF9; // Erase EOF key
        internal static byte VK_PLAY = 0xFA; // Play key
        internal static byte VK_ZOOM = 0xFB; // Zoom key
        internal static byte VK_NONAME = 0xFC; // Reserved
        internal static byte VK_PA1 = 0xFD; // PA1 key
        internal static byte VK_OEM_CLEAR = 0xFE; // Clear key

        
        
            
        [DllImport("user32.dll", EntryPoint = "PostMessage", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool PostMessage1(IntPtr hWnd, uint Msg,
                                                IntPtr wParam, IntPtr lParam);
        
        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SendMessage1(IntPtr hWnd, uint Msg,
                                                IntPtr wParam, IntPtr lParam);
        
        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        //[return: MarshalAs(UnmanagedType.)]
        internal static extern long SendMessage2(IntPtr hWnd, int Msg,
                                                 IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        //[return: MarshalAs(UnmanagedType.)]
        internal static extern long SendMessage2(IntPtr hWnd, int Msg,
                                                 IntPtr wParam, string lParam);
        
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SetCursorPos(int X, int Y);
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "INPUT")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "MOUSE")]
        internal static int INPUT_MOUSE = 0;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "INPUT")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "KEYBOARD")]
        internal static int INPUT_KEYBOARD = 1;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "INPUT")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "HARDWARE")]
        internal static int INPUT_HARDWARE = 2;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "KEYEVENTF")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "EXTENDEDKEY")]
        internal static uint KEYEVENTF_EXTENDEDKEY = 0x0001;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "KEYEVENTF")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "KEYUP")]
        internal static uint KEYEVENTF_KEYUP = 0x0002;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "KEYEVENTF")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UNICODE")]
        internal static uint KEYEVENTF_UNICODE = 0x0004;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "KEYEVENTF")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "SCANCODE")]
        internal static uint KEYEVENTF_SCANCODE = 0x0008;
        

        
        [DllImport("user32.dll", SetLastError = true)]
        // internal static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);
        //internal static extern uint SendInput(uint nInputs, INPUT pInputs, int cbSize);
        private static extern uint SendInput(uint nInputs, INPUT pInputs, int cbSize);
        
// [DllImport("user32.dll")]
// internal static extern void keybd_event(byte bVk, byte bScan, uint dwFlags,
// UIntPtr dwExtraInfo);
        
        [DllImport("user32.dll")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "keybd")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "event")]
        internal static extern void keybd_event(byte bVk, byte bScan, uint dwFlags,
           int dwExtraInfo);
        
        
        [DllImport("user32.dll")]
        internal static extern short GetKeyState(uint vkCode);
        
        #endregion declarations
        #endregion the click
        
        #region Set-UIAControlText
        #region declarations
        internal static uint WM_CHAR                        = 0x0102;
        // 20120206 uint WM_SETTEXT                        = 0x000C;
// uint WM_KEYDOWN                        = 0x0100;
// uint WM_KEYUP                        = 0x0100;


        [DllImport("user32.dll", EntryPoint="SendMessage", CharSet=CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SendMessage1(IntPtr hWnd, uint Msg,
                                        int wParam, int lParam);
        #endregion declarations
        #endregion Set-UIAControlText
        #region Clear-UIAControlText
        [return: MarshalAs (UnmanagedType.Bool)]
        //[DllImport ("user32.dll", SetLastError = true)]
        [DllImport("user32.dll", EntryPoint="SendMessage", CharSet=CharSet.Auto, SetLastError = true)]
        internal static extern bool SendMessage3 (IntPtr hWnd, uint Msg, IntPtr wParam, string s);  
        //const uint WM_SETTEXT = 0x000c;
        internal static uint WM_SETTEXT                        = 0x000c;
        #endregion Clear-UIAControlText
        
        #region Get-UIAActiveWindow
        #region declarations
        [DllImport("user32.dll")]
        internal static extern IntPtr GetForegroundWindow();
        #endregion declarations
        #endregion Get-UIAActiveWindow
        
        #region Sheridan
        #region declarations
        //Define TreeView Flags and Messages
        internal static int BN_CLICKED = 0xF5;
        internal static int TV_FIRST = 0x1100;
        internal static int TVGN_ROOT = 0x0;
        internal static int TVGN_NEXT = 0x1;
        internal static int TVGN_CHILD = 0x4;
        internal static int TVGN_FIRSTVISIBLE = 0x5;
        internal static int TVGN_NEXTVISIBLE = 0x6;
        internal static int TVGN_CARET = 0x9;
        internal static int TVM_SELECTITEM = (TV_FIRST + 11);
        internal static int TVM_GETNEXTITEM = (TV_FIRST + 10);
        internal static int TVM_GETITEM = (TV_FIRST + 12);
        
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(int hWnd, int msg, int wParam, IntPtr lParam);
        
        internal static int WM_GETTEXT = 0x000D;
        internal static int WM_GETTEXTLENGTH = 0x000E;
        
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, string lpString, int nMaxCount);
//        int WINAPI GetWindowText(
//          _In_   HWND hWnd,
//          _Out_  LPTSTR lpString,
//          _In_   int nMaxCount
//        );
        
        
        
        // TreeView constants
//; ======================================================================================================================
//; Function:         Constants for TreeView controls
//; AHK version:      1.1.05+
//; Language:         English
//; Version:          1.0.00.00/2012-04-01/just me
//; ======================================================================================================================
//; CCM_FIRST = 0x2000
//; TV_FIRST  = 0x1100
//; TVN_FIRST = -400
//; ======================================================================================================================
//; Class ================================================================================================================
//Global WC_TREEVIEW             := "SysTreeView32"
//; Messages =============================================================================================================
//Global TVM_CREATEDRAGIMAGE     := 0x1112 ; (TV_FIRST + 18)
//Global TVM_DELETEITEM          := 0x1101 ; (TV_FIRST + 1)
//Global TVM_EDITLABELA          := 0x110E ; (TV_FIRST + 14)
//Global TVM_EDITLABELW          := 0x1141 ; (TV_FIRST + 65)
//Global TVM_ENDEDITLABELNOW     := 0x1116 ; (TV_FIRST + 22)
//Global TVM_ENSUREVISIBLE       := 0x1114 ; (TV_FIRST + 20)
//Global TVM_EXPAND              := 0x1102 ; (TV_FIRST + 2)
//Global TVM_GETBKCOLOR          := 0x112F ; (TV_FIRST + 31)
//Global TVM_GETCOUNT            := 0x1105 ; (TV_FIRST + 5)
//Global TVM_GETEDITCONTROL      := 0x110F ; (TV_FIRST + 15)
//Global TVM_GETEXTENDEDSTYLE    := 0x112D ; (TV_FIRST + 45)
//Global TVM_GETIMAGELIST        := 0x1108 ; (TV_FIRST + 8)
//Global TVM_GETINDENT           := 0x1106 ; (TV_FIRST + 6)
//Global TVM_GETINSERTMARKCOLOR  := 0x1126 ; (TV_FIRST + 38)
//Global TVM_GETISEARCHSTRINGA   := 0x1117 ; (TV_FIRST + 23)
//Global TVM_GETISEARCHSTRINGW   := 0x1140 ; (TV_FIRST + 64)
//Global TVM_GETITEMA            := 0x110C ; (TV_FIRST + 12)
//Global TVM_GETITEMHEIGHT       := 0x111C ; (TV_FIRST + 28)
//Global TVM_GETITEMPARTRECT     := 0x1148 ; (TV_FIRST + 72) ; >= Vista
//Global TVM_GETITEMRECT         := 0x1104 ; (TV_FIRST + 4)
//Global TVM_GETITEMSTATE        := 0x1127 ; (TV_FIRST + 39)
//Global TVM_GETITEMW            := 0x113E ; (TV_FIRST + 62)
//Global TVM_GETLINECOLOR        := 0x1129 ; (TV_FIRST + 41)
//Global TVM_GETNEXTITEM         := 0x110A ; (TV_FIRST + 10)
//Global TVM_GETSCROLLTIME       := 0x1122 ; (TV_FIRST + 34)
//Global TVM_GETSELECTEDCOUNT    := 0x1146 ; (TV_FIRST + 70) ; >= Vista
//Global TVM_GETTEXTCOLOR        := 0x1120 ; (TV_FIRST + 32)
//Global TVM_GETTOOLTIPS         := 0x1119 ; (TV_FIRST + 25)
//Global TVM_GETUNICODEFORMAT    := 0x2006 ; (CCM_FIRST + 6) CCM_GETUNICODEFORMAT
//Global TVM_GETVISIBLECOUNT     := 0x1110 ; (TV_FIRST + 16)
//Global TVM_HITTEST             := 0x1111 ; (TV_FIRST + 17)
//Global TVM_INSERTITEMA         := 0x1100 ; (TV_FIRST + 0)
//Global TVM_INSERTITEMW         := 0x1142 ; (TV_FIRST + 50)
//Global TVM_MAPACCIDTOHTREEITEM := 0x112A ; (TV_FIRST + 42)
//Global TVM_MAPHTREEITEMTOACCID := 0x112B ; (TV_FIRST + 43)
//Global TVM_SELECTITEM          := 0x110B ; (TV_FIRST + 11)
//Global TVM_SETAUTOSCROLLINFO   := 0x113B ; (TV_FIRST + 59)
//Global TVM_SETBKCOLOR          := 0x111D ; (TV_FIRST + 29)
//Global TVM_SETEXTENDEDSTYLE    := 0x112C ; (TV_FIRST + 44)
//Global TVM_SETIMAGELIST        := 0x1109 ; (TV_FIRST + 9)
//Global TVM_SETINDENT           := 0x1107 ; (TV_FIRST + 7)
//Global TVM_SETINSERTMARK       := 0x111A ; (TV_FIRST + 26)
//Global TVM_SETINSERTMARKCOLOR  := 0x1125 ; (TV_FIRST + 37)
//Global TVM_SETITEMA            := 0x110D ; (TV_FIRST + 13)
//Global TVM_SETITEMHEIGHT       := 0x111B ; (TV_FIRST + 27)
//Global TVM_SETITEMW            := 0x113F ; (TV_FIRST + 63)
//Global TVM_SETLINECOLOR        := 0x1128 ; (TV_FIRST + 40)
//Global TVM_SETSCROLLTIME       := 0x1121 ; (TV_FIRST + 33)
//Global TVM_SETTEXTCOLOR        := 0x111E ; (TV_FIRST + 30)
//Global TVM_SETTOOLTIPS         := 0x1118 ; (TV_FIRST + 24)
//Global TVM_SETUNICODEFORMAT    := 0x2005 ; (CCM_FIRST + 5) ; CCM_SETUNICODEFORMAT
//Global TVM_SHOWINFOTIP         := 0x1147 ; (TV_FIRST + 71) ; >= Vista
//Global TVM_SORTCHILDREN        := 0x1113 ; (TV_FIRST + 19)
//Global TVM_SORTCHILDRENCB      := 0x1115 ; (TV_FIRST + 21)
//; Notifications ========================================================================================================
//Global TVN_ASYNCDRAW           := -420 ; (TVN_FIRST - 20) >= Vista
//Global TVN_BEGINDRAGA          := -427 ; (TVN_FIRST - 7)
//Global TVN_BEGINDRAGW          := -456 ; (TVN_FIRST - 56)
//Global TVN_BEGINLABELEDITA     := -410 ; (TVN_FIRST - 10)
//Global TVN_BEGINLABELEDITW     := -456 ; (TVN_FIRST - 59)
//Global TVN_BEGINRDRAGA         := -408 ; (TVN_FIRST - 8)
//Global TVN_BEGINRDRAGW         := -457 ; (TVN_FIRST - 57)
//Global TVN_DELETEITEMA         := -409 ; (TVN_FIRST - 9)
//Global TVN_DELETEITEMW         := -458 ; (TVN_FIRST - 58)
//Global TVN_ENDLABELEDITA       := -411 ; (TVN_FIRST - 11)
//Global TVN_ENDLABELEDITW       := -460 ; (TVN_FIRST - 60)
//Global TVN_GETDISPINFOA        := -403 ; (TVN_FIRST - 3)
//Global TVN_GETDISPINFOW        := -452 ; (TVN_FIRST - 52)
//Global TVN_GETINFOTIPA         := -412 ; (TVN_FIRST - 13)
//Global TVN_GETINFOTIPW         := -414 ; (TVN_FIRST - 14)
//Global TVN_ITEMCHANGEDA        := -418 ; (TVN_FIRST - 18) ; >= Vista
//Global TVN_ITEMCHANGEDW        := -419 ; (TVN_FIRST - 19) ; >= Vista
//Global TVN_ITEMCHANGINGA       := -416 ; (TVN_FIRST - 16) ; >= Vista
//Global TVN_ITEMCHANGINGW       := -417 ; (TVN_FIRST - 17) ; >= Vista
//Global TVN_ITEMEXPANDEDA       := -406 ; (TVN_FIRST - 6)
//Global TVN_ITEMEXPANDEDW       := -455 ; (TVN_FIRST - 55)
//Global TVN_ITEMEXPANDINGA      := -405 ; (TVN_FIRST - 5)
//Global TVN_ITEMEXPANDINGW      := -454 ; (TVN_FIRST - 54)
//Global TVN_KEYDOWN             := -412 ; (TVN_FIRST - 12)
//Global TVN_SELCHANGEDA         := -402 ; (TVN_FIRST - 2)
//Global TVN_SELCHANGEDW         := -451 ; (TVN_FIRST - 51)
//Global TVN_SELCHANGINGA        := -401 ; (TVN_FIRST - 1)
//Global TVN_SELCHANGINGW        := -450 ; (TVN_FIRST - 50)
//Global TVN_SETDISPINFOA        := -404 : (TVN_FIRST - 4)
//Global TVN_SETDISPINFOW        := -453 ; (TVN_FIRST - 53)
//Global TVN_SINGLEEXPAND        := -415 ; (TVN_FIRST - 15)
//; Styles ===============================================================================================================
//Global TVS_CHECKBOXES          := 0x0100
//Global TVS_DISABLEDRAGDROP     := 0x0010
//Global TVS_EDITLABELS          := 0x0008
//Global TVS_FULLROWSELECT       := 0x1000
//Global TVS_HASBUTTONS          := 0x0001
//Global TVS_HASLINES            := 0x0002
//Global TVS_INFOTIP             := 0x0800
//Global TVS_LINESATROOT         := 0x0004
//Global TVS_NOHSCROLL           := 0x8000 ; TVS_NOSCROLL overrides this
//Global TVS_NONEVENHEIGHT       := 0x4000
//Global TVS_NOSCROLL            := 0x2000
//Global TVS_NOTOOLTIPS          := 0x0080
//Global TVS_RTLREADING          := 0x0040
//Global TVS_SHOWSELALWAYS       := 0x0020
//Global TVS_SINGLEEXPAND        := 0x0400
//Global TVS_TRACKSELECT         := 0x0200
//; Exstyles =============================================================================================================
//Global TVS_EX_AUTOHSCROLL         := 0x0020 ; >= Vista
//Global TVS_EX_DIMMEDCHECKBOXES    := 0x0200 ; >= Vista
//Global TVS_EX_DOUBLEBUFFER        := 0x0004 ; >= Vista
//Global TVS_EX_DRAWIMAGEASYNC      := 0x0400 ; >= Vista
//Global TVS_EX_EXCLUSIONCHECKBOXES := 0x0100 ; >= Vista
//Global TVS_EX_FADEINOUTEXPANDOS   := 0x0040 ; >= Vista
//Global TVS_EX_MULTISELECT         := 0x0002 ; >= Vista - Not supported. Do not use.
//Global TVS_EX_NOINDENTSTATE       := 0x0008 ; >= Vista
//Global TVS_EX_NOSINGLECOLLAPSE    := 0x0001 ; >= Vista - Intended for internal use; not recommended for use in applications.
//Global TVS_EX_PARTIALCHECKBOXES   := 0x0080 ; >= Vista
//Global TVS_EX_RICHTOOLTIP         := 0x0010 ; >= Vista
//; Others ===============================================================================================================
//; Item flags
//Global TVIF_CHILDREN           := 0x0040
//Global TVIF_DI_SETITEM         := 0x1000
//Global TVIF_EXPANDEDIMAGE      := 0x0200 ; >= Vista
//Global TVIF_HANDLE             := 0x0010
//Global TVIF_IMAGE              := 0x0002
//Global TVIF_INTEGRAL           := 0x0080
//Global TVIF_PARAM              := 0x0004
//Global TVIF_SELECTEDIMAGE      := 0x0020
//Global TVIF_STATE              := 0x0008
//Global TVIF_STATEEX            := 0x0100 ; >= Vista
//Global TVIF_TEXT               := 0x0001
//; Item states
//Global TVIS_BOLD               := 0x0010
//Global TVIS_CUT                := 0x0004
//Global TVIS_DROPHILITED        := 0x0008
//Global TVIS_EXPANDED           := 0x0020
//Global TVIS_EXPANDEDONCE       := 0x0040
//Global TVIS_EXPANDPARTIAL      := 0x0080
//Global TVIS_OVERLAYMASK        := 0x0F00
//Global TVIS_SELECTED           := 0x0002
//Global TVIS_STATEIMAGEMASK     := 0xF000
//Global TVIS_USERMASK           := 0xF000
//; TVITEMEX uStateEx
//Global TVIS_EX_ALL             := 0x0002 ; not documented
//Global TVIS_EX_DISABLED        := 0x0002 ; >= Vista
//Global TVIS_EX_FLAT            := 0x0001
//; TVINSERTSTRUCT hInsertAfter
//Global TVI_FIRST               := -65535 ; (-0x0FFFF)
//Global TVI_LAST                := -65534 ; (-0x0FFFE)
//Global TVI_ROOT                := -65536 ; (-0x10000)
//Global TVI_SORT                := -65533 ; (-0x0FFFD)
//; TVM_EXPAND wParam
//Global TVE_COLLAPSE            := 0x0001
//Global TVE_COLLAPSERESET       := 0x8000
//Global TVE_EXPAND              := 0x0002
//Global TVE_EXPANDPARTIAL       := 0x4000
//Global TVE_TOGGLE              := 0x0003
//; TVM_GETIMAGELIST wParam
//Global TVSIL_NORMAL            := 0
//Global TVSIL_STATE             := 2
//; TVM_GETNEXTITEM wParam
//Global TVGN_CARET              := 0x0009
//Global TVGN_CHILD              := 0x0004
//Global TVGN_DROPHILITE         := 0x0008
//Global TVGN_FIRSTVISIBLE       := 0x0005
//Global TVGN_LASTVISIBLE        := 0x000A
//Global TVGN_NEXT               := 0x0001
//Global TVGN_NEXTSELECTED       := 0x000B ; >= Vista (MSDN)     
//Global TVGN_NEXTVISIBLE        := 0x0006
//Global TVGN_PARENT             := 0x0003
//Global TVGN_PREVIOUS           := 0x0002
//Global TVGN_PREVIOUSVISIBLE    := 0x0007
//Global TVGN_ROOT               := 0x0000
//; TVM_SELECTITEM wParam
//Global TVSI_NOSINGLEEXPAND     := 0x8000 ; Should not conflict with TVGN flags.
//; TVHITTESTINFO flags
//Global TVHT_ABOVE              := 0x0100
//Global TVHT_BELOW              := 0x0200
//Global TVHT_NOWHERE            := 0x0001
//Global TVHT_ONITEMBUTTON       := 0x0010
//Global TVHT_ONITEMICON         := 0x0002
//Global TVHT_ONITEMINDENT       := 0x0008
//Global TVHT_ONITEMLABEL        := 0x0004
//Global TVHT_ONITEMRIGHT        := 0x0020
//Global TVHT_ONITEMSTATEICON    := 0x0040
//Global TVHT_TOLEFT             := 0x0800
//Global TVHT_TORIGHT            := 0x0400
//Global TVHT_ONITEM             := 0x0046 ; (TVHT_ONITEMICON | TVHT_ONITEMLABEL | TVHT_ONITEMSTATEICON)
//; TVGETITEMPARTRECTINFO partID (>= Vista)
//Global TVGIPR_BUTTON           := 0x0001
//; NMTREEVIEW action
//Global TVC_BYKEYBOARD          := 0x0002
//Global TVC_BYMOUSE             := 0x0001
//Global TVC_UNKNOWN             := 0x0000
//; TVN_SINGLEEXPAND return codes
//Global TVNRET_DEFAULT          := 0
//Global TVNRET_SKIPOLD          := 1
//Global TVNRET_SKIPNEW          := 2
//; ======================================================================================================================
        
        
        
        #endregion declarations
        #endregion Sheridan
        
        // 20130423
//        [DllImport("user32.dll")]
//        internal static extern bool SetForegroundWindow(IntPtr hWnd);
        
        #region screensaver prevention
        
        #endregion screensaver prevention
        
        #region DateTimePicker by Josef Nemec
        #region old?
//        [DllImport("user32.dll")]
//        internal static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
//        [DllImport("kernel32.dll", SetLastError = true)]
//        internal static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, UIntPtr lpNumberOfBytesWritten);
//        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
//        internal static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, AllocationType flAllocationType, MemoryProtection flProtect);
//        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
//        internal static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, int dwSize, FreeType dwFreeType);
//        [DllImport("kernel32.dll")]
//        internal static extern IntPtr OpenProcess(ProcessAccessFlags dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, int dwProcessId);
//        [DllImport("kernel32.dll", SetLastError = true)]
//        internal static extern bool CloseHandle(IntPtr hHandle);
//        
//        // SYSTEMTIME c++ struct to be injected into process
//        [StructLayoutAttribute(LayoutKind.Sequential)]
//        internal  struct SYSTEMTIME
//        {
//            public short wYear;
//            public short wMonth;
//            public short wDayOfWeek;
//            public short wDay;
//            public short wHour;
//            public short wMinute;
//            public short wSecond;
//            public short wMilliseconds;
//
//            public SYSTEMTIME(DateTime value)
//            {
//                wYear = (short)value.Year;
//                wMonth = (short)value.Month;
//                wDayOfWeek = (short)value.DayOfWeek;
//                wDay = (short)value.Day;
//                wHour = (short)value.Hour;
//                wMinute = (short)value.Minute;
//                wSecond = (short)value.Second;
//                wMilliseconds = 0;
//            }
//        }
//
//        [Flags]
//        public enum AllocationType
//        {
//            Commit = 0x1000,
//            Reserve = 0x2000,
//            Decommit = 0x4000,
//            Release = 0x8000,
//            Reset = 0x80000,
//            Physical = 0x400000,
//            TopDown = 0x100000,
//            WriteWatch = 0x200000,
//            LargePages = 0x20000000
//        }
//
//        [Flags]
//        public enum MemoryProtection
//        {
//            Execute = 0x10,
//            ExecuteRead = 0x20,
//            ExecuteReadWrite = 0x40,
//            ExecuteWriteCopy = 0x80,
//            NoAccess = 0x01,
//            ReadOnly = 0x02,
//            ReadWrite = 0x04,
//            WriteCopy = 0x08,
//            GuardModifierflag = 0x100,
//            NoCacheModifierflag = 0x200,
//            WriteCombineModifierflag = 0x400
//        }
//
//        [Flags]
//        internal enum ProcessAccessFlags : uint
//        {
//            All = 0x001F0FFF,
//            Terminate = 0x00000001,
//            CreateThread = 0x00000002,
//            VMOperation = 0x00000008,
//            VMRead = 0x00000010,
//            VMWrite = 0x00000020,
//            DupHandle = 0x00000040,
//            SetInformation = 0x00000200,
//            QueryInformation = 0x00000400,
//            Synchronize = 0x00100000
//        }
//
//        [Flags]
//        public enum FreeType
//        {
//            Decommit = 0x4000,
//            Release = 0x8000,
//        }
//
//        internal const uint DTM_FIRST = 0x1000;
//        internal const uint DTM_SETSYSTEMTIME = DTM_FIRST + 2;
//        internal const ushort GDT_VALID = 0;
//        internal const uint WM_COMMAND = 0x0111;
        #endregion old?

//        internal static void InjectMemory(int procId, byte[] buffer, out IntPtr hndProc, out IntPtr lpAddress)
//        {
//            // open process and get handle
//            hndProc = OpenProcess(ProcessAccessFlags.All, true, procId);
//
//            if (hndProc == (IntPtr)0)
//            {
//                AccessViolationException ex = new AccessViolationException("Unable to attach to process with an id " + procId);
//                ThrowTerminatingError(new ErrorRecord(ex, "AccessDenined", ErrorCategory.SecurityError, null));
//            }
//
//            // allocate memory for object to be injected
//            lpAddress = VirtualAllocEx(hndProc, (IntPtr)null, (uint)buffer.Length,
//                AllocationType.Commit | AllocationType.Reserve, MemoryProtection.ExecuteReadWrite);
//
//            if (lpAddress == (IntPtr)0)
//            {
//                AccessViolationException ex = new AccessViolationException("Unable to allocate memory to proces with an id " + procId);
//                ThrowTerminatingError(new ErrorRecord(ex, "AccessDenined", ErrorCategory.SecurityError, null));
//            }
//
//            // write data to process
//            uint wrotelen = 0;
//            WriteProcessMemory(hndProc, lpAddress, buffer, (uint)buffer.Length, (UIntPtr)wrotelen);
//
//            if (Marshal.GetLastWin32Error() != 0)
//            {
//                AccessViolationException ex = new AccessViolationException("Unable to write memory to process with an id " + procId);
//                ThrowTerminatingError(new ErrorRecord(ex, "AccessDenined", ErrorCategory.SecurityError, null));
//            }
//        }
        
        
        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public short wYear;
            public short wMonth;
            public short wDayOfWeek;
            public short wDay;
            public short wHour;
            public short wMinute;
            public short wSecond;
            public short wMilliseconds;
    
            public SYSTEMTIME(DateTime value)
            {
                wYear = (short)value.Year;
                wMonth = (short)value.Month;
                wDayOfWeek = (short)value.DayOfWeek;
                wDay = (short)value.Day;
                wHour = (short)value.Hour;
                wMinute = (short)value.Minute;
                wSecond = (short)value.Second;
                wMilliseconds = 0;
            }
        }
    
        [Flags]
        public enum AllocationType : uint
        {
            Commit = 0x1000,
            Reserve = 0x2000,
            Decommit = 0x4000,
            Release = 0x8000,
            Reset = 0x80000,
            Physical = 0x400000,
            TopDown = 0x100000,
            WriteWatch = 0x200000,
            LargePages = 0x20000000
        }
    
        [Flags]
        public enum MemoryProtection : uint
        {
            Execute = 0x10,
            ExecuteRead = 0x20,
            ExecuteReadWrite = 0x40,
            ExecuteWriteCopy = 0x80,
            NoAccess = 0x01,
            ReadOnly = 0x02,
            ReadWrite = 0x04,
            WriteCopy = 0x08,
            GuardModifierflag = 0x100,
            NoCacheModifierflag = 0x200,
            WriteCombineModifierflag = 0x400
        }
    
        [Flags]
        public enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VMOperation = 0x00000008,
            VMRead = 0x00000010,
            VMWrite = 0x00000020,
            DupHandle = 0x00000040,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            Synchronize = 0x00100000
        }
    
        [Flags]
        public enum FreeType : uint
        {
            Decommit = 0x4000,
            Release = 0x8000,
        }
    
        [Flags]
        public enum MK : uint
        {
            LButton = 0x1,
            RButton = 0x2,
            Shift = 0x4,
            Control = 0x8,
            MButton = 0x10,
            XButton1 = 0x20,
            XButton2 = 0x40
        }
    
        [Flags]
        public enum WM : uint
        {
            LeftButtonDown = 0x201,
            LeftButtonUp = 0x202,
            LeftButtonDoubleClick = 0x203,
    
            RightButtonDown = 0x204,
            RightButtonUp = 0x205,
            RightButtonDoubleClick = 0x206,
    
            MiddleButtonDown = 0x207,
            MiddleButtonUp = 0x208,
            MiddleButtonDoubleClick = 0x209,
    
            XButtonDoubleClick = 0x20D,
            XButtonDown = 0x20B,
            XButtonUp = 0x20C,
    
            KeyDown = 0x100,
            KeyFirst = 0x100,
            KeyLast = 0x108,
            KeyUp = 0x101,
    
            NonClientHitTest = 0x084,
            NonClientLeftButtonDown = 0x0A1,
            NonClientLeftButtonUp = 0x0A2,
            NonClientLeftButtonDoubleClick = 0x0A3,
    
            NonClientRightButtonDown = 0x0A4,
            NonClientRightButtonUp = 0x0A5,
            NonClientRightButtonDoubleClick = 0x0A6,
    
            NonClientMiddleButtonDown = 0x0A7,
            NonClientMiddleButtonUp = 0x0A8,
            NonClientMiddleButtonDoubleClick = 0x0A9,
    
            NonClientXButtonDown = 0x0AB,
            NonClientXButtonUp = 0x0AC,
            NonClientXButtonDoubleClick = 0x0AD,
    
            Activate = 0x006,
            ActivateApp = 0x01C,
            SysCommand = 0x112,
            GetText = 0x00D,
            GetTextLength = 0x00E,
        }
        
        public static int MakeLong(int HiWord, int LoWord)
        {
            return (HiWord << 16) | (LoWord & 0xffff);
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("User32", SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, WM Msg, int wParam, int lParam);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("User32", SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, WM Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, UIntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, AllocationType flAllocationType, MemoryProtection flProtect);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, int dwSize, FreeType dwFreeType);

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(ProcessAccessFlags dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool CloseHandle(IntPtr hHandle);
        #endregion DateTimePicker by Josef Nemec
        
        #region Protect/Unprotect Data
        // http://www.obviex.com/samples/dpapi.aspx
        
        // Wrapper for DPAPI CryptProtectData function.
        [DllImport( "crypt32.dll",
                    SetLastError=true,
                    CharSet=System.Runtime.InteropServices.CharSet.Auto)]
        internal static extern
            bool CryptProtectData(  ref DATA_BLOB     pPlainText,
                                        string        szDescription,
                                    ref DATA_BLOB     pEntropy,
                                        IntPtr        pReserved,
                                    ref CRYPTPROTECT_PROMPTSTRUCT pPrompt,
                                        int           dwFlags,
                                    ref DATA_BLOB     pCipherText);
        
        // Wrapper for DPAPI CryptUnprotectData function.
        [DllImport( "crypt32.dll",
                    SetLastError=true,
                    CharSet=System.Runtime.InteropServices.CharSet.Auto)]
        internal static extern
            bool CryptUnprotectData(ref DATA_BLOB       pCipherText,
                                    ref string          pszDescription,
                                    ref DATA_BLOB       pEntropy,
                                        IntPtr          pReserved,
                                    ref CRYPTPROTECT_PROMPTSTRUCT pPrompt,
                                        int             dwFlags,
                                    ref DATA_BLOB       pPlainText);
        
        // BLOB structure used to pass data to DPAPI functions.
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
        internal struct DATA_BLOB
        {
            public int     cbData;
            public IntPtr  pbData;
        }
        
        // Prompt structure to be used for required parameters.
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
        internal struct CRYPTPROTECT_PROMPTSTRUCT
        {
            public int      cbSize;
            public int      dwPromptFlags;
            public IntPtr   hwndApp;
            public string   szPrompt;
        }
        
        // Wrapper for the NULL handle or pointer.
        static internal IntPtr NullPtr = ((IntPtr)((int)(0)));
        
        // DPAPI key initialization flags.
        internal const int CRYPTPROTECT_UI_FORBIDDEN  = 0x1;
        internal const int CRYPTPROTECT_LOCAL_MACHINE = 0x4;
        
        [DllImport("kernel32.dll", SetLastError=true)]
        internal static extern IntPtr LocalFree(IntPtr hMem);
        
        #endregion Protect/Unprotect Data
    }
}
