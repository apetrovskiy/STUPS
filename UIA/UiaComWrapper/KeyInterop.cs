// (c) Copyright Microsoft, 2012.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.


using System;

namespace System.Windows.Input 
{
    /// <summary>
    ///     Provides static methods to convert between Win32 VirtualKeys
    ///     and our Key enum.
    /// </summary>
    public static class KeyInterop
    {
        private const int  VK_LBUTTON        = 0x01;
        private const int  VK_RBUTTON        = 0x02;
        private const int  VK_CANCEL         = 0x03;
        private const int  VK_MBUTTON        = 0x04;
        private const int  VK_XBUTTON1       = 0x05;
        private const int  VK_XBUTTON2       = 0x06;
        private const int  VK_BACK           = 0x08;
        private const int  VK_TAB            = 0x09;
        private const int  VK_CLEAR          = 0x0C;
        private const int  VK_RETURN         = 0x0D;
        private const int  VK_SHIFT          = 0x10;
        private const int  VK_CONTROL        = 0x11;
        private const int  VK_MENU           = 0x12;
        private const int  VK_PAUSE          = 0x13;
        private const int  VK_CAPITAL        = 0x14;
        private const int  VK_KANA           = 0x15;
        private const int  VK_HANGEUL        = 0x15;
        private const int  VK_HANGUL         = 0x15;
        private const int  VK_JUNJA          = 0x17;
        private const int  VK_FINAL          = 0x18;
        private const int  VK_HANJA          = 0x19;
        private const int  VK_KANJI          = 0x19;
        private const int  VK_ESCAPE         = 0x1B;
        private const int  VK_CONVERT        = 0x1C;
        private const int  VK_NONCONVERT     = 0x1D;
        private const int  VK_ACCEPT         = 0x1E;
        private const int  VK_MODECHANGE     = 0x1F;
        private const int  VK_SPACE          = 0x20;
        private const int  VK_PRIOR          = 0x21;
        private const int  VK_NEXT           = 0x22;
        private const int  VK_END            = 0x23;
        private const int  VK_HOME           = 0x24;
        private const int  VK_LEFT           = 0x25;
        private const int  VK_UP             = 0x26;
        private const int  VK_RIGHT          = 0x27;
        private const int  VK_DOWN           = 0x28;
        private const int  VK_SELECT         = 0x29;
        private const int  VK_PRINT          = 0x2A;
        private const int  VK_EXECUTE        = 0x2B;
        private const int  VK_SNAPSHOT       = 0x2C;
        private const int  VK_INSERT         = 0x2D;
        private const int  VK_DELETE         = 0x2E;
        private const int  VK_HELP           = 0x2F;
        private const int  VK_0              = 0x30;
        private const int  VK_1              = 0x31;
        private const int  VK_2              = 0x32;
        private const int  VK_3              = 0x33;
        private const int  VK_4              = 0x34;
        private const int  VK_5              = 0x35;
        private const int  VK_6              = 0x36;
        private const int  VK_7              = 0x37;
        private const int  VK_8              = 0x38;
        private const int  VK_9              = 0x39;
        private const int  VK_A              = 0x41;
        private const int  VK_B              = 0x42;
        private const int  VK_C              = 0x43;
        private const int  VK_D              = 0x44;
        private const int  VK_E              = 0x45;
        private const int  VK_F              = 0x46;
        private const int  VK_G              = 0x47;
        private const int  VK_H              = 0x48;
        private const int  VK_I              = 0x49;
        private const int  VK_J              = 0x4A;
        private const int  VK_K              = 0x4B;
        private const int  VK_L              = 0x4C;
        private const int  VK_M              = 0x4D;
        private const int  VK_N              = 0x4E;
        private const int  VK_O              = 0x4F;
        private const int  VK_P              = 0x50;
        private const int  VK_Q              = 0x51;
        private const int  VK_R              = 0x52;
        private const int  VK_S              = 0x53;
        private const int  VK_T              = 0x54;
        private const int  VK_U              = 0x55;
        private const int  VK_V              = 0x56;
        private const int  VK_W              = 0x57;
        private const int  VK_X              = 0x58;
        private const int  VK_Y              = 0x59;
        private const int  VK_Z              = 0x5A;
        private const int  VK_LWIN           = 0x5B;
        private const int  VK_RWIN           = 0x5C;
        private const int  VK_APPS           = 0x5D;
        private const int  VK_POWER          = 0x5E;
        private const int  VK_SLEEP          = 0x5F;
        private const int  VK_NUMPAD0        = 0x60;
        private const int  VK_NUMPAD1        = 0x61;
        private const int  VK_NUMPAD2        = 0x62;
        private const int  VK_NUMPAD3        = 0x63;
        private const int  VK_NUMPAD4        = 0x64;
        private const int  VK_NUMPAD5        = 0x65;
        private const int  VK_NUMPAD6        = 0x66;
        private const int  VK_NUMPAD7        = 0x67;
        private const int  VK_NUMPAD8        = 0x68;
        private const int  VK_NUMPAD9        = 0x69;
        private const int  VK_MULTIPLY       = 0x6A;
        private const int  VK_ADD            = 0x6B;
        private const int  VK_SEPARATOR      = 0x6C;
        private const int  VK_SUBTRACT       = 0x6D;
        private const int  VK_DECIMAL        = 0x6E;
        private const int  VK_DIVIDE         = 0x6F;
        private const int  VK_F1             = 0x70;
        private const int  VK_F2             = 0x71;
        private const int  VK_F3             = 0x72;
        private const int  VK_F4             = 0x73;
        private const int  VK_F5             = 0x74;
        private const int  VK_F6             = 0x75;
        private const int  VK_F7             = 0x76;
        private const int  VK_F8             = 0x77;
        private const int  VK_F9             = 0x78;
        private const int  VK_F10            = 0x79;
        private const int  VK_F11            = 0x7A;
        private const int  VK_F12            = 0x7B;
        private const int  VK_F13            = 0x7C;
        private const int  VK_F14            = 0x7D;
        private const int  VK_F15            = 0x7E;
        private const int  VK_F16            = 0x7F;
        private const int  VK_F17            = 0x80;
        private const int  VK_F18            = 0x81;
        private const int  VK_F19            = 0x82;
        private const int  VK_F20            = 0x83;
        private const int  VK_F21            = 0x84;
        private const int  VK_F22            = 0x85;
        private const int  VK_F23            = 0x86;
        private const int  VK_F24            = 0x87;
        private const int  VK_NUMLOCK        = 0x90;
        private const int  VK_SCROLL         = 0x91;
        private const int  VK_LSHIFT         = 0xA0;
        private const int  VK_RSHIFT         = 0xA1;
        private const int  VK_LCONTROL       = 0xA2;
        private const int  VK_RCONTROL       = 0xA3;
        private const int  VK_LMENU          = 0xA4;
        private const int  VK_RMENU          = 0xA5;
        private const int  VK_BROWSER_BACK        = 0xA6;
        private const int  VK_BROWSER_FORWARD     = 0xA7;
        private const int  VK_BROWSER_REFRESH     = 0xA8;
        private const int  VK_BROWSER_STOP        = 0xA9;
        private const int  VK_BROWSER_SEARCH      = 0xAA;
        private const int  VK_BROWSER_FAVORITES   = 0xAB;
        private const int  VK_BROWSER_HOME        = 0xAC;
        private const int  VK_VOLUME_MUTE         = 0xAD;
        private const int  VK_VOLUME_DOWN         = 0xAE;
        private const int  VK_VOLUME_UP           = 0xAF;
        private const int  VK_MEDIA_NEXT_TRACK    = 0xB0;
        private const int  VK_MEDIA_PREV_TRACK    = 0xB1;
        private const int  VK_MEDIA_STOP          = 0xB2;
        private const int  VK_MEDIA_PLAY_PAUSE    = 0xB3;
        private const int  VK_LAUNCH_MAIL         = 0xB4;
        private const int  VK_LAUNCH_MEDIA_SELECT = 0xB5;
        private const int  VK_LAUNCH_APP1         = 0xB6;
        private const int  VK_LAUNCH_APP2         = 0xB7;
        private const int  VK_OEM_1          = 0xBA;
        private const int  VK_OEM_PLUS       = 0xBB;
        private const int  VK_OEM_COMMA      = 0xBC;
        private const int  VK_OEM_MINUS      = 0xBD;
        private const int  VK_OEM_PERIOD     = 0xBE;
        private const int  VK_OEM_2          = 0xBF;
        private const int  VK_OEM_3          = 0xC0;
        private const int  VK_C1             = 0xC1;   // Brazilian ABNT_C1 key (not defined in winuser.h).
        private const int  VK_C2             = 0xC2;   // Brazilian ABNT_C2 key (not defined in winuser.h).
        private const int  VK_OEM_4          = 0xDB;
        private const int  VK_OEM_5          = 0xDC;
        private const int  VK_OEM_6          = 0xDD;
        private const int  VK_OEM_7          = 0xDE;
        private const int  VK_OEM_8          = 0xDF;
        private const int  VK_OEM_AX         = 0xE1;
        private const int  VK_OEM_102        = 0xE2;
        private const int  VK_ICO_HELP       = 0xE3;
        private const int  VK_ICO_00         = 0xE4;
        private const int  VK_PROCESSKEY     = 0xE5;
        private const int  VK_PACKET         = 0xE7;
        private const int  VK_OEM_RESET      = 0xE9;
        private const int  VK_OEM_JUMP       = 0xEA;
        private const int  VK_OEM_PA1        = 0xEB;
        private const int  VK_OEM_PA2        = 0xEC;
        private const int  VK_OEM_PA3        = 0xED;
        private const int  VK_OEM_WSCTRL     = 0xEE;
        private const int  VK_OEM_CUSEL      = 0xEF;
        private const int  VK_OEM_ATTN       = 0xF0;
        private const int  VK_OEM_FINISH     = 0xF1;
        private const int  VK_OEM_COPY       = 0xF2;
        private const int  VK_OEM_AUTO       = 0xF3;
        private const int  VK_OEM_ENLW       = 0xF4;
        private const int  VK_OEM_BACKTAB    = 0xF5;
        private const int  VK_ATTN           = 0xF6;
        private const int  VK_CRSEL          = 0xF7;
        private const int  VK_EXSEL          = 0xF8;
        private const int  VK_EREOF          = 0xF9;
        private const int  VK_PLAY           = 0xFA;
        private const int  VK_ZOOM           = 0xFB;
        private const int  VK_NONAME         = 0xFC;
        private const int  VK_PA1            = 0xFD;
        private const int  VK_OEM_CLEAR      = 0xFE;
                
        /// <summary>
        ///     Convert a Win32 VirtualKey into our Key enum.
        /// </summary>
        public static Key KeyFromVirtualKey(int virtualKey)
        {
            Key key = Key.None;
            
            switch(virtualKey)
            {
                case VK_CANCEL:
                    key = Key.Cancel;
                    break;
                    
                case VK_BACK:
                    key = Key.Back;
                    break;
                    
                case VK_TAB:
                    key = Key.Tab;
                    break;
                    
                case VK_CLEAR:
                    key = Key.Clear;
                    break;
                    
                case VK_RETURN:
                    key = Key.Return;
                    break;
                    
                case VK_PAUSE:
                    key = Key.Pause;
                    break;
                    
                case VK_CAPITAL:
                    key = Key.Capital;
                    break;
                    
                case VK_KANA:
                    key = Key.KanaMode;
                    break;
                    
                case VK_JUNJA:
                    key = Key.JunjaMode;
                    break;
                    
                case VK_FINAL:
                    key = Key.FinalMode;
                    break;
                    
                case VK_KANJI:
                    key = Key.KanjiMode;
                    break;
                    
                case VK_ESCAPE:
                    key = Key.Escape;
                    break;
                    
                case VK_CONVERT:
                    key = Key.ImeConvert;
                    break;
                    
                case VK_NONCONVERT:
                    key = Key.ImeNonConvert;
                    break;
                    
                case VK_ACCEPT:
                    key = Key.ImeAccept;
                    break;
                    
                case VK_MODECHANGE:
                    key = Key.ImeModeChange;
                    break;
                    
                case VK_SPACE:
                    key = Key.Space;
                    break;
                    
                case VK_PRIOR:
                    key = Key.Prior;
                    break;
                    
                case VK_NEXT:
                    key = Key.Next;
                    break;
                    
                case VK_END:
                    key = Key.End;
                    break;
                    
                case VK_HOME:
                    key = Key.Home;
                    break;
                    
                case VK_LEFT:
                    key = Key.Left;
                    break;
                    
                case VK_UP:
                    key = Key.Up;
                    break;
                    
                case VK_RIGHT:
                    key = Key.Right;
                    break;
                    
                case VK_DOWN:
                    key = Key.Down;
                    break;
                    
                case VK_SELECT:
                    key = Key.Select;
                    break;
                    
                case VK_PRINT:
                    key = Key.Print;
                    break;
                    
                case VK_EXECUTE:
                    key = Key.Execute;
                    break;
                    
                case VK_SNAPSHOT:
                    key = Key.Snapshot;
                    break;
                    
                case VK_INSERT:
                    key = Key.Insert;
                    break;
                    
                case VK_DELETE:
                    key = Key.Delete;
                    break;
                    
                case VK_HELP:
                    key = Key.Help;
                    break;
                    
                case VK_0:
                    key = Key.D0;
                    break;
                    
                case VK_1:
                    key = Key.D1;
                    break;
                    
                case VK_2:
                    key = Key.D2;
                    break;
                    
                case VK_3:
                    key = Key.D3;
                    break;
                    
                case VK_4:
                    key = Key.D4;
                    break;
                    
                case VK_5:
                    key = Key.D5;
                    break;
                    
                case VK_6:
                    key = Key.D6;
                    break;
                    
                case VK_7:
                    key = Key.D7;
                    break;
                    
                case VK_8:
                    key = Key.D8;
                    break;
                    
                case VK_9:
                    key = Key.D9;
                    break;
                    
                case VK_A:
                    key = Key.A;
                    break;
                    
                case VK_B:
                    key = Key.B;
                    break;
                    
                case VK_C:
                    key = Key.C;
                    break;
                    
                case VK_D:
                    key = Key.D;
                    break;
                    
                case VK_E:
                    key = Key.E;
                    break;
                    
                case VK_F:
                    key = Key.F;
                    break;
                    
                case VK_G:
                    key = Key.G;
                    break;
                    
                case VK_H:
                    key = Key.H;
                    break;
                    
                case VK_I:
                    key = Key.I;
                    break;
                    
                case VK_J:
                    key = Key.J;
                    break;
                    
                case VK_K:
                    key = Key.K;
                    break;
                    
                case VK_L:
                    key = Key.L;
                    break;
                    
                case VK_M:
                    key = Key.M;
                    break;
                    
                case VK_N:
                    key = Key.N;
                    break;
                    
                case VK_O:
                    key = Key.O;
                    break;
                    
                case VK_P:
                    key = Key.P;
                    break;
                    
                case VK_Q:
                    key = Key.Q;
                    break;
                    
                case VK_R:
                    key = Key.R;
                    break;
                    
                case VK_S:
                    key = Key.S;
                    break;
                    
                case VK_T:
                    key = Key.T;
                    break;
                    
                case VK_U:
                    key = Key.U;
                    break;
                    
                case VK_V:
                    key = Key.V;
                    break;
                    
                case VK_W:
                    key = Key.W;
                    break;
                    
                case VK_X:
                    key = Key.X;
                    break;
                    
                case VK_Y:
                    key = Key.Y;
                    break;
                    
                case VK_Z:
                    key = Key.Z;
                    break;
                    
                case VK_LWIN:
                    key = Key.LWin;
                    break;
                    
                case VK_RWIN:
                    key = Key.RWin;
                    break;
                    
                case VK_APPS:
                    key = Key.Apps;
                    break;
                    
                case VK_SLEEP:
                    key = Key.Sleep;
                    break;
                    
                case VK_NUMPAD0:
                    key = Key.NumPad0;
                    break;
                    
                case VK_NUMPAD1:
                    key = Key.NumPad1;
                    break;
                    
                case VK_NUMPAD2:
                    key = Key.NumPad2;
                    break;
                    
                case VK_NUMPAD3:
                    key = Key.NumPad3;
                    break;
                    
                case VK_NUMPAD4:
                    key = Key.NumPad4;
                    break;
                    
                case VK_NUMPAD5:
                    key = Key.NumPad5;
                    break;
                    
                case VK_NUMPAD6:
                    key = Key.NumPad6;
                    break;
                    
                case VK_NUMPAD7:
                    key = Key.NumPad7;
                    break;
                    
                case VK_NUMPAD8:
                    key = Key.NumPad8;
                    break;
                    
                case VK_NUMPAD9:
                    key = Key.NumPad9;
                    break;
                    
                case VK_MULTIPLY:
                    key = Key.Multiply;
                    break;
                    
                case VK_ADD:
                    key = Key.Add;
                    break;
                    
                case VK_SEPARATOR:
                    key = Key.Separator;
                    break;
                    
                case VK_SUBTRACT:
                    key = Key.Subtract;
                    break;
                    
                case VK_DECIMAL:
                    key = Key.Decimal;
                    break;
                    
                case VK_DIVIDE:
                    key = Key.Divide;
                    break;
                    
                case VK_F1:
                    key = Key.F1;
                    break;
                    
                case VK_F2:
                    key = Key.F2;
                    break;
                    
                case VK_F3:
                    key = Key.F3;
                    break;
                    
                case VK_F4:
                    key = Key.F4;
                    break;
                    
                case VK_F5:
                    key = Key.F5;
                    break;
                    
                case VK_F6:
                    key = Key.F6;
                    break;
                    
                case VK_F7:
                    key = Key.F7;
                    break;
                    
                case VK_F8:
                    key = Key.F8;
                    break;
                    
                case VK_F9:
                    key = Key.F9;
                    break;
                    
                case VK_F10:
                    key = Key.F10;
                    break;
                    
                case VK_F11:
                    key = Key.F11;
                    break;
                    
                case VK_F12:
                    key = Key.F12;
                    break;
                    
                case VK_F13:
                    key = Key.F13;
                    break;
                    
                case VK_F14:
                    key = Key.F14;
                    break;
                    
                case VK_F15:
                    key = Key.F15;
                    break;
                    
                case VK_F16:
                    key = Key.F16;
                    break;
                    
                case VK_F17:
                    key = Key.F17;
                    break;
                    
                case VK_F18:
                    key = Key.F18;
                    break;
                    
                case VK_F19:
                    key = Key.F19;
                    break;
                    
                case VK_F20:
                    key = Key.F20;
                    break;
                    
                case VK_F21:
                    key = Key.F21;
                    break;
                    
                case VK_F22:
                    key = Key.F22;
                    break;
                    
                case VK_F23:
                    key = Key.F23;
                    break;
                    
                case VK_F24:
                    key = Key.F24;
                    break;
                    
                case VK_NUMLOCK:
                    key = Key.NumLock;
                    break;
                    
                case VK_SCROLL:
                    key = Key.Scroll;
                    break;
                    
                case VK_SHIFT:
                case VK_LSHIFT:
                    key = Key.LeftShift;
                    break;
                    
                case VK_RSHIFT:
                    key = Key.RightShift;
                    break;
                    
                case VK_CONTROL:
                case VK_LCONTROL:
                    key = Key.LeftCtrl;
                    break;
                    
                case VK_RCONTROL:
                    key = Key.RightCtrl;
                    break;
                    
                case VK_MENU:
                case VK_LMENU:
                    key = Key.LeftAlt;
                    break;
                    
                case VK_RMENU:
                    key = Key.RightAlt;
                    break;
                    
                case VK_BROWSER_BACK:
                    key = Key.BrowserBack;
                    break;
                    
                case VK_BROWSER_FORWARD:
                    key = Key.BrowserForward;
                    break;
                    
                case VK_BROWSER_REFRESH:
                    key = Key.BrowserRefresh;
                    break;
                    
                case VK_BROWSER_STOP:
                    key = Key.BrowserStop;
                    break;
                    
                case VK_BROWSER_SEARCH:
                    key = Key.BrowserSearch;
                    break;
                    
                case VK_BROWSER_FAVORITES:
                    key = Key.BrowserFavorites;
                    break;
                    
                case VK_BROWSER_HOME:
                    key = Key.BrowserHome;
                    break;
                    
                case VK_VOLUME_MUTE:
                    key = Key.VolumeMute;
                    break;
                    
                case VK_VOLUME_DOWN:
                    key = Key.VolumeDown;
                    break;
                    
                case VK_VOLUME_UP:
                    key = Key.VolumeUp;
                    break;
                    
                case VK_MEDIA_NEXT_TRACK:
                    key = Key.MediaNextTrack;
                    break;
                    
                case VK_MEDIA_PREV_TRACK:
                    key = Key.MediaPreviousTrack;
                    break;
                    
                case VK_MEDIA_STOP:
                    key = Key.MediaStop;
                    break;
                    
                case VK_MEDIA_PLAY_PAUSE:
                    key = Key.MediaPlayPause;
                    break;
                    
                case VK_LAUNCH_MAIL:
                    key = Key.LaunchMail;
                    break;
                    
                case VK_LAUNCH_MEDIA_SELECT:
                    key = Key.SelectMedia;
                    break;
                    
                case VK_LAUNCH_APP1:
                    key = Key.LaunchApplication1;
                    break;
                    
                case VK_LAUNCH_APP2:
                    key = Key.LaunchApplication2;
                    break;
                    
                case VK_OEM_1:
                    key = Key.OemSemicolon;
                    break;
                    
                case VK_OEM_PLUS:
                    key = Key.OemPlus;
                    break;
                    
                case VK_OEM_COMMA:
                    key = Key.OemComma;
                    break;
                    
                case VK_OEM_MINUS:
                    key = Key.OemMinus;
                    break;
                    
                case VK_OEM_PERIOD:
                    key = Key.OemPeriod;
                    break;
                    
                case VK_OEM_2:
                    key = Key.OemQuestion;
                    break;
                    
                case VK_OEM_3:
                    key = Key.OemTilde;
                    break;

                case VK_C1:
                    key = Key.AbntC1;
                    break;
                    
                case VK_C2:
                    key = Key.AbntC2;
                    break;
                    
                case VK_OEM_4:
                    key = Key.OemOpenBrackets;
                    break;
                    
                case VK_OEM_5:
                    key = Key.OemPipe;
                    break;
                    
                case VK_OEM_6:
                    key = Key.OemCloseBrackets;
                    break;
                    
                case VK_OEM_7:
                    key = Key.OemQuotes;
                    break;
                    
                case VK_OEM_8:
                    key = Key.Oem8;
                    break;
                    
                case VK_OEM_102:
                    key = Key.OemBackslash;
                    break;
                    
                case VK_PROCESSKEY:
                    key = Key.ImeProcessed;
                    break;

                case VK_OEM_ATTN: // VK_DBE_ALPHANUMERIC
                    key = Key.OemAttn;          // DbeAlphanumeric
                    break;

                case VK_OEM_FINISH: // VK_DBE_KATAKANA
                    key = Key.OemFinish;          // DbeKatakana
                    break;

                case VK_OEM_COPY: // VK_DBE_HIRAGANA
                    key = Key.OemCopy;          // DbeHiragana
                    break;

                case VK_OEM_AUTO: // VK_DBE_SBCSCHAR
                    key = Key.OemAuto;          // DbeSbcsChar
                    break;

                case VK_OEM_ENLW: // VK_DBE_DBCSCHAR
                    key = Key.OemEnlw;          // DbeDbcsChar
                    break;

                case VK_OEM_BACKTAB: // VK_DBE_ROMAN
                    key = Key.OemBackTab;          // DbeRoman
                    break;

                case VK_ATTN: // VK_DBE_NOROMAN
                    key = Key.Attn;         // DbeNoRoman
                    break;
                    
                case VK_CRSEL: // VK_DBE_ENTERWORDREGISTERMODE
                    key = Key.CrSel;         // DbeEnterWordRegisterMode
                    break;
                    
                case VK_EXSEL: // VK_DBE_ENTERIMECONFIGMODE
                    key = Key.ExSel;         // DbeEnterImeConfigMode
                    break;
                    
                case VK_EREOF: // VK_DBE_FLUSHSTRING
                    key = Key.EraseEof;      // DbeFlushString
                    break;
                    
                case VK_PLAY: // VK_DBE_CODEINPUT
                    key = Key.Play;         // DbeCodeInput
                    break;
                    
                case VK_ZOOM: // VK_DBE_NOCODEINPUT
                    key = Key.Zoom;         // DbeNoCodeInput
                    break;
                    
                case VK_NONAME: // VK_DBE_DETERMINESTRING
                    key = Key.NoName;         // DbeDetermineString
                    break;
                    
                case VK_PA1: // VK_DBE_ENTERDLGCONVERSIONMODE
                    key = Key.Pa1;         // DbeEnterDlgConversionMode
                    break;
                    
                case VK_OEM_CLEAR:
                    key = Key.OemClear;
                    break;

                default:
                    key = Key.None;
                    break;
            }

            return key;
        }

        /// <summary>
        ///     Convert our Key enum into a Win32 VirtualKey.
        /// </summary>
        public static int VirtualKeyFromKey(Key key)
        {
            int virtualKey = 0;
            
            switch(key)
            {
                case Key.Cancel:
                    virtualKey = VK_CANCEL;
                    break;
                    
                case Key.Back:
                    virtualKey = VK_BACK;
                    break;
                    
                case Key.Tab:
                    virtualKey = VK_TAB;
                    break;
                    
                case Key.Clear:
                    virtualKey = VK_CLEAR;
                    break;
                    
                case Key.Return:
                    virtualKey = VK_RETURN;
                    break;
                    
                case Key.Pause:
                    virtualKey = VK_PAUSE;
                    break;
                    
                case Key.Capital:
                    virtualKey = VK_CAPITAL;
                    break;
                    
                case Key.KanaMode:
                    virtualKey = VK_KANA;
                    break;
                    
                case Key.JunjaMode:
                    virtualKey = VK_JUNJA;
                    break;
                    
                case Key.FinalMode:
                    virtualKey = VK_FINAL;
                    break;
                    
                case Key.KanjiMode:
                    virtualKey = VK_KANJI;
                    break;
                    
                case Key.Escape:
                    virtualKey = VK_ESCAPE;
                    break;
                    
                case Key.ImeConvert:
                    virtualKey = VK_CONVERT;
                    break;
                    
                case Key.ImeNonConvert:
                    virtualKey = VK_NONCONVERT;
                    break;
                    
                case Key.ImeAccept:
                    virtualKey = VK_ACCEPT;
                    break;
                    
                case Key.ImeModeChange:
                    virtualKey = VK_MODECHANGE;
                    break;
                    
                case Key.Space:
                    virtualKey = VK_SPACE;
                    break;
                    
                case Key.Prior:
                    virtualKey = VK_PRIOR;
                    break;
                    
                case Key.Next:
                    virtualKey = VK_NEXT;
                    break;
                    
                case Key.End:
                    virtualKey = VK_END;
                    break;
                    
                case Key.Home:
                    virtualKey = VK_HOME;
                    break;
                    
                case Key.Left:
                    virtualKey = VK_LEFT;
                    break;
                    
                case Key.Up:
                    virtualKey = VK_UP;
                    break;
                    
                case Key.Right:
                    virtualKey = VK_RIGHT;
                    break;
                    
                case Key.Down:
                    virtualKey = VK_DOWN;
                    break;
                    
                case Key.Select:
                    virtualKey = VK_SELECT;
                    break;
                    
                case Key.Print:
                    virtualKey = VK_PRINT;
                    break;
                    
                case Key.Execute:
                    virtualKey = VK_EXECUTE;
                    break;
                    
                case Key.Snapshot:
                    virtualKey = VK_SNAPSHOT;
                    break;
                    
                case Key.Insert:
                    virtualKey = VK_INSERT;
                    break;
                    
                case Key.Delete:
                    virtualKey = VK_DELETE;
                    break;
                    
                case Key.Help:
                    virtualKey = VK_HELP;
                    break;
                    
                case Key.D0:
                    virtualKey = VK_0;
                    break;
                    
                case Key.D1:
                    virtualKey = VK_1;
                    break;
                    
                case Key.D2:
                    virtualKey = VK_2;
                    break;
                    
                case Key.D3:
                    virtualKey = VK_3;
                    break;
                    
                case Key.D4:
                    virtualKey = VK_4;
                    break;
                    
                case Key.D5:
                    virtualKey = VK_5;
                    break;
                    
                case Key.D6:
                    virtualKey = VK_6;
                    break;
                    
                case Key.D7:
                    virtualKey = VK_7;
                    break;
                    
                case Key.D8:
                    virtualKey = VK_8;
                    break;
                    
                case Key.D9:
                    virtualKey = VK_9;
                    break;
                    
                case Key.A:
                    virtualKey = VK_A;
                    break;
                    
                case Key.B:
                    virtualKey = VK_B;
                    break;
                    
                case Key.C:
                    virtualKey = VK_C;
                    break;
                    
                case Key.D:
                    virtualKey = VK_D;
                    break;
                    
                case Key.E:
                    virtualKey = VK_E;
                    break;
                    
                case Key.F:
                    virtualKey = VK_F;
                    break;
                    
                case Key.G:
                    virtualKey = VK_G;
                    break;
                    
                case Key.H:
                    virtualKey = VK_H;
                    break;
                    
                case Key.I:
                    virtualKey = VK_I;
                    break;
                    
                case Key.J:
                    virtualKey = VK_J;
                    break;
                    
                case Key.K:
                    virtualKey = VK_K;
                    break;
                    
                case Key.L:
                    virtualKey = VK_L;
                    break;
                    
                case Key.M:
                    virtualKey = VK_M;
                    break;
                    
                case Key.N:
                    virtualKey = VK_N;
                    break;
                    
                case Key.O:
                    virtualKey = VK_O;
                    break;
                    
                case Key.P:
                    virtualKey = VK_P;
                    break;
                    
                case Key.Q:
                    virtualKey = VK_Q;
                    break;
                    
                case Key.R:
                    virtualKey = VK_R;
                    break;
                    
                case Key.S:
                    virtualKey = VK_S;
                    break;
                    
                case Key.T:
                    virtualKey = VK_T;
                    break;
                    
                case Key.U:
                    virtualKey = VK_U;
                    break;
                    
                case Key.V:
                    virtualKey = VK_V;
                    break;
                    
                case Key.W:
                    virtualKey = VK_W;
                    break;
                    
                case Key.X:
                    virtualKey = VK_X;
                    break;
                    
                case Key.Y:
                    virtualKey = VK_Y;
                    break;
                    
                case Key.Z:
                    virtualKey = VK_Z;
                    break;
                    
                case Key.LWin:
                    virtualKey = VK_LWIN;
                    break;
                    
                case Key.RWin:
                    virtualKey = VK_RWIN;
                    break;
                    
                case Key.Apps:
                    virtualKey = VK_APPS;
                    break;
                    
                case Key.Sleep:
                    virtualKey = VK_SLEEP;
                    break;
                    
                case Key.NumPad0:
                    virtualKey = VK_NUMPAD0;
                    break;
                    
                case Key.NumPad1:
                    virtualKey = VK_NUMPAD1;
                    break;
                    
                case Key.NumPad2:
                    virtualKey = VK_NUMPAD2;
                    break;
                    
                case Key.NumPad3:
                    virtualKey = VK_NUMPAD3;
                    break;
                    
                case Key.NumPad4:
                    virtualKey = VK_NUMPAD4;
                    break;
                    
                case Key.NumPad5:
                    virtualKey = VK_NUMPAD5;
                    break;
                    
                case Key.NumPad6:
                    virtualKey = VK_NUMPAD6;
                    break;
                    
                case Key.NumPad7:
                    virtualKey = VK_NUMPAD7;
                    break;
                    
                case Key.NumPad8:
                    virtualKey = VK_NUMPAD8;
                    break;
                    
                case Key.NumPad9:
                    virtualKey = VK_NUMPAD9;
                    break;
                    
                case Key.Multiply:
                    virtualKey = VK_MULTIPLY;
                    break;
                    
                case Key.Add:
                    virtualKey = VK_ADD;
                    break;
                    
                case Key.Separator:
                    virtualKey = VK_SEPARATOR;
                    break;
                    
                case Key.Subtract:
                    virtualKey = VK_SUBTRACT;
                    break;
                    
                case Key.Decimal:
                    virtualKey = VK_DECIMAL;
                    break;
                    
                case Key.Divide:
                    virtualKey = VK_DIVIDE;
                    break;
                    
                case Key.F1:
                    virtualKey = VK_F1;
                    break;
                    
                case Key.F2:
                    virtualKey = VK_F2;
                    break;
                    
                case Key.F3:
                    virtualKey = VK_F3;
                    break;
                    
                case Key.F4:
                    virtualKey = VK_F4;
                    break;
                    
                case Key.F5:
                    virtualKey = VK_F5;
                    break;
                    
                case Key.F6:
                    virtualKey = VK_F6;
                    break;
                    
                case Key.F7:
                    virtualKey = VK_F7;
                    break;
                    
                case Key.F8:
                    virtualKey = VK_F8;
                    break;
                    
                case Key.F9:
                    virtualKey = VK_F9;
                    break;
                    
                case Key.F10:
                    virtualKey = VK_F10;
                    break;
                    
                case Key.F11:
                    virtualKey = VK_F11;
                    break;
                    
                case Key.F12:
                    virtualKey = VK_F12;
                    break;
                    
                case Key.F13:
                    virtualKey = VK_F13;
                    break;
                    
                case Key.F14:
                    virtualKey = VK_F14;
                    break;
                    
                case Key.F15:
                    virtualKey = VK_F15;
                    break;
                    
                case Key.F16:
                    virtualKey = VK_F16;
                    break;
                    
                case Key.F17:
                    virtualKey = VK_F17;
                    break;
                    
                case Key.F18:
                    virtualKey = VK_F18;
                    break;
                    
                case Key.F19:
                    virtualKey = VK_F19;
                    break;
                    
                case Key.F20:
                    virtualKey = VK_F20;
                    break;
                    
                case Key.F21:
                    virtualKey = VK_F21;
                    break;
                    
                case Key.F22:
                    virtualKey = VK_F22;
                    break;
                    
                case Key.F23:
                    virtualKey = VK_F23;
                    break;
                    
                case Key.F24:
                    virtualKey = VK_F24;
                    break;
                    
                case Key.NumLock:
                    virtualKey = VK_NUMLOCK;
                    break;
                    
                case Key.Scroll:
                    virtualKey = VK_SCROLL;
                    break;
                    
                case Key.LeftShift:
                    virtualKey = VK_LSHIFT;
                    break;
                    
                case Key.RightShift:
                    virtualKey = VK_RSHIFT;
                    break;
                    
                case Key.LeftCtrl:
                    virtualKey = VK_LCONTROL;
                    break;
                    
                case Key.RightCtrl:
                    virtualKey = VK_RCONTROL;
                    break;
                    
                case Key.LeftAlt:
                    virtualKey = VK_LMENU;
                    break;
                    
                case Key.RightAlt:
                    virtualKey = VK_RMENU;
                    break;
                    
                case Key.BrowserBack:
                    virtualKey = VK_BROWSER_BACK;
                    break;
                    
                case Key.BrowserForward:
                    virtualKey = VK_BROWSER_FORWARD;
                    break;
                    
                case Key.BrowserRefresh:
                    virtualKey = VK_BROWSER_REFRESH;
                    break;
                    
                case Key.BrowserStop:
                    virtualKey = VK_BROWSER_STOP;
                    break;
                    
                case Key.BrowserSearch:
                    virtualKey = VK_BROWSER_SEARCH;
                    break;
                    
                case Key.BrowserFavorites:
                    virtualKey = VK_BROWSER_FAVORITES;
                    break;
                    
                case Key.BrowserHome:
                    virtualKey = VK_BROWSER_HOME;
                    break;
                    
                case Key.VolumeMute:
                    virtualKey = VK_VOLUME_MUTE;
                    break;
                    
                case Key.VolumeDown:
                    virtualKey = VK_VOLUME_DOWN;
                    break;
                    
                case Key.VolumeUp:
                    virtualKey = VK_VOLUME_UP;
                    break;
                    
                case Key.MediaNextTrack:
                    virtualKey = VK_MEDIA_NEXT_TRACK;
                    break;
                    
                case Key.MediaPreviousTrack:
                    virtualKey = VK_MEDIA_PREV_TRACK;
                    break;
                    
                case Key.MediaStop:
                    virtualKey = VK_MEDIA_STOP;
                    break;
                    
                case Key.MediaPlayPause:
                    virtualKey = VK_MEDIA_PLAY_PAUSE;
                    break;
                    
                case Key.LaunchMail:
                    virtualKey = VK_LAUNCH_MAIL;
                    break;
                    
                case Key.SelectMedia:
                    virtualKey = VK_LAUNCH_MEDIA_SELECT;
                    break;
                    
                case Key.LaunchApplication1:
                    virtualKey = VK_LAUNCH_APP1;
                    break;
                    
                case Key.LaunchApplication2:
                    virtualKey = VK_LAUNCH_APP2;
                    break;
                    
                case Key.OemSemicolon:
                    virtualKey = VK_OEM_1;
                    break;
                    
                case Key.OemPlus:
                    virtualKey = VK_OEM_PLUS;
                    break;
                    
                case Key.OemComma:
                    virtualKey = VK_OEM_COMMA;
                    break;
                    
                case Key.OemMinus:
                    virtualKey = VK_OEM_MINUS;
                    break;
                    
                case Key.OemPeriod:
                    virtualKey = VK_OEM_PERIOD;
                    break;
                    
                case Key.OemQuestion:
                    virtualKey = VK_OEM_2;
                    break;
                    
                case Key.OemTilde:
                    virtualKey = VK_OEM_3;
                    break;
                    
                case Key.AbntC1:
                    virtualKey = VK_C1;
                    break;
                    
                case Key.AbntC2:
                    virtualKey = VK_C2;
                    break;
                    
                case Key.OemOpenBrackets:
                    virtualKey = VK_OEM_4;
                    break;
                    
                case Key.OemPipe:
                    virtualKey = VK_OEM_5;
                    break;
                    
                case Key.OemCloseBrackets:
                    virtualKey = VK_OEM_6;
                    break;
                    
                case Key.OemQuotes:
                    virtualKey = VK_OEM_7;
                    break;
                    
                case Key.Oem8:
                    virtualKey = VK_OEM_8;
                    break;
                    
                case Key.OemBackslash:
                    virtualKey = VK_OEM_102;
                    break;
                    
                case Key.ImeProcessed:
                    virtualKey = VK_PROCESSKEY;
                    break;

                case Key.OemAttn:                           // DbeAlphanumeric
                    virtualKey = VK_OEM_ATTN; // VK_DBE_ALPHANUMERIC
                    break;

                case Key.OemFinish:                           // DbeKatakana
                    virtualKey = VK_OEM_FINISH; // VK_DBE_KATAKANA
                    break;

                case Key.OemCopy:                           // DbeHiragana
                    virtualKey = VK_OEM_COPY; // VK_DBE_HIRAGANA
                    break;

                case Key.OemAuto:                           // DbeSbcsChar
                    virtualKey = VK_OEM_AUTO; // VK_DBE_SBCSCHAR
                    break;

                case Key.OemEnlw:                           // DbeDbcsChar
                    virtualKey = VK_OEM_ENLW; // VK_DBE_DBCSCHAR
                    break;

                case Key.OemBackTab:                           // DbeRoman
                    virtualKey = VK_OEM_BACKTAB; // VK_DBE_ROMAN
                    break;
                    
                case Key.Attn:                          // DbeNoRoman
                    virtualKey = VK_ATTN; // VK_DBE_NOROMAN
                    break;
                    
                case Key.CrSel:                          // DbeEnterWordRegisterMode
                    virtualKey = VK_CRSEL; // VK_DBE_ENTERWORDREGISTERMODE
                    break;
                    
                case Key.ExSel:                          // EnterImeConfigureMode
                    virtualKey = VK_EXSEL; // VK_DBE_ENTERIMECONFIGMODE
                    break;
                    
                case Key.EraseEof:                       // DbeFlushString
                    virtualKey = VK_EREOF; // VK_DBE_FLUSHSTRING
                    break;
                    
                case Key.Play:                           // DbeCodeInput
                    virtualKey = VK_PLAY;  // VK_DBE_CODEINPUT
                    break;
                    
                case Key.Zoom:                           // DbeNoCodeInput
                    virtualKey = VK_ZOOM;  // VK_DBE_NOCODEINPUT
                    break;
                    
                case Key.NoName:                          // DbeDetermineString
                    virtualKey = VK_NONAME; // VK_DBE_DETERMINESTRING
                    break;
                    
                case Key.Pa1:                          // DbeEnterDlgConversionMode
                    virtualKey = VK_PA1; // VK_ENTERDLGCONVERSIONMODE
                    break;
                    
                case Key.OemClear:
                    virtualKey = VK_OEM_CLEAR;
                    break;
        
                default:
                    virtualKey = 0;
                    break;
            }
        
            return virtualKey;
        }
    }
}

