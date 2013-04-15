using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using AVG.Automation.Cmdlets.NativeTypes;


namespace AVG.Automation.Cmdlets.NativeTypes
{
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
}

namespace AVG.Automation.Cmdlets
{
    public static class NativeMethods
    {
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
    }
}
