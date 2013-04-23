///*
// * Created by SharpDevelop.
// * User: Alexander Petrovskiy
// * Date: 3/13/2013
// * Time: 8:31 AM
// * 
// * To change this template use Tools | Options | Coding | Edit Standard Headers.
// */
//
//namespace UIAutomation.Commands
//{
//    using System;
//    using System.Management.Automation;
//    using System.Windows.Automation;
//    using System.Runtime.InteropServices;
//    
//    /// <summary>
//    /// Puts DateTime into DateTimePicker Win32 object
//    /// by Crowcz from AVG
//    /// </summary>
//    [Cmdlet(VerbsCommon.Set, "DateTimePickerDate")]
//    public class SetUIADateTimePickerDateCommand : Win32CmdletBase //GetControlCmdletBase //Cmdlet
//    {
////        [DllImport("user32.dll")]
////        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
////        [DllImport("kernel32.dll", SetLastError = true)]
////        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, UIntPtr lpNumberOfBytesWritten);
////        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
////        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, AllocationType flAllocationType, MemoryProtection flProtect);
////        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
////        static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, int dwSize, FreeType dwFreeType);
////        [DllImport("kernel32.dll")]
////        static extern IntPtr OpenProcess(ProcessAccessFlags dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, int dwProcessId);
////        [DllImport("kernel32.dll", SetLastError = true)]
////        static extern bool CloseHandle(IntPtr hHandle);
//
//        /// <summary>
//        /// DateTimePicker input object
//        /// </summary>
//        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
//        //public AutomationElement InputObject
//        public new AutomationElement InputObject { get; set; }
//        //{
//        //    get { return inputObject; }
//        //    set { inputObject = value; }
//        //}
//
//        /// <summary>
//        /// DateTime to bet set
//        /// </summary>
//        [Parameter(Mandatory = true, Position = 2)]
//        //public DateTime Date
//        public DateTime Date { get; set; }
//        //{
//        //    get { return date; }
//        //    set { date = value; }
//        //}
//
//        AutomationElement inputObject;
//        DateTime date;
//
////        // SYSTEMTIME c++ struct to be injected into process
////        [StructLayoutAttribute(LayoutKind.Sequential)]
////        private struct SYSTEMTIME
////        {
////            public short wYear;
////            public short wMonth;
////            public short wDayOfWeek;
////            public short wDay;
////            public short wHour;
////            public short wMinute;
////            public short wSecond;
////            public short wMilliseconds;
////
////            public SYSTEMTIME(DateTime value)
////            {
////                wYear = (short)value.Year;
////                wMonth = (short)value.Month;
////                wDayOfWeek = (short)value.DayOfWeek;
////                wDay = (short)value.Day;
////                wHour = (short)value.Hour;
////                wMinute = (short)value.Minute;
////                wSecond = (short)value.Second;
////                wMilliseconds = 0;
////            }
////        }
////
////        [Flags]
////        public enum AllocationType
////        {
////            Commit = 0x1000,
////            Reserve = 0x2000,
////            Decommit = 0x4000,
////            Release = 0x8000,
////            Reset = 0x80000,
////            Physical = 0x400000,
////            TopDown = 0x100000,
////            WriteWatch = 0x200000,
////            LargePages = 0x20000000
////        }
////
////        [Flags]
////        public enum MemoryProtection
////        {
////            Execute = 0x10,
////            ExecuteRead = 0x20,
////            ExecuteReadWrite = 0x40,
////            ExecuteWriteCopy = 0x80,
////            NoAccess = 0x01,
////            ReadOnly = 0x02,
////            ReadWrite = 0x04,
////            WriteCopy = 0x08,
////            GuardModifierflag = 0x100,
////            NoCacheModifierflag = 0x200,
////            WriteCombineModifierflag = 0x400
////        }
////
////        [Flags]
////        enum ProcessAccessFlags : uint
////        {
////            All = 0x001F0FFF,
////            Terminate = 0x00000001,
////            CreateThread = 0x00000002,
////            VMOperation = 0x00000008,
////            VMRead = 0x00000010,
////            VMWrite = 0x00000020,
////            DupHandle = 0x00000040,
////            SetInformation = 0x00000200,
////            QueryInformation = 0x00000400,
////            Synchronize = 0x00100000
////        }
////
////        [Flags]
////        public enum FreeType
////        {
////            Decommit = 0x4000,
////            Release = 0x8000,
////        }
////
////        const uint DTM_FIRST = 0x1000;
////        const uint DTM_SETSYSTEMTIME = DTM_FIRST + 2;
////        const ushort GDT_VALID = 0;
////        const uint WM_COMMAND = 0x0111;
//
//        private void injectMemory(int procId, byte[] buffer, out IntPtr hndProc, out IntPtr lpAddress)
//        {
//            // open process and get handle
//            //hndProc = OpenProcess(ProcessAccessFlags.All, true, procId);
//            hndProc = NativeMethods.OpenProcess(NativeMethods.ProcessAccessFlags.All, true, procId);
//
//            if (hndProc == (IntPtr)0)
//            {
//                //AccessViolationException ex = new AccessViolationException("Unable to attach to process with an id " + procId);
//                //ThrowTerminatingError(new ErrorRecord(ex, "AccessDenined", ErrorCategory.SecurityError, null));
//                this.WriteError(
//                    this,
//                    "Unable to attach to process with an id " + procId,
//                    "AccessDenined",
//                    ErrorCategory.SecurityError,
//                    true);
//            }
//
//            // allocate memory for object to be injected
//            //lpAddress = VirtualAllocEx(hndProc, (IntPtr)null, (uint)buffer.Length,
//            lpAddress = NativeMethods.VirtualAllocEx(hndProc, (IntPtr)null, (uint)buffer.Length,
//                //AllocationType.Commit | AllocationType.Reserve, MemoryProtection.ExecuteReadWrite);
//                NativeMethods.AllocationType.Commit | NativeMethods.AllocationType.Reserve, NativeMethods.MemoryProtection.ExecuteReadWrite);
//
//            if (lpAddress == (IntPtr)0)
//            {
//                //AccessViolationException ex = new AccessViolationException("Unable to allocate memory to proces with an id " + procId);
//                //ThrowTerminatingError(new ErrorRecord(ex, "AccessDenined", ErrorCategory.SecurityError, null));
//                this.WriteError(
//                    this,
//                    "Unable to allocate memory to proces with an id " + procId,
//                    "AccessDenined",
//                    ErrorCategory.SecurityError,
//                    true);
//            }
//
//            // write data to process
//            uint wrotelen = 0;
//            //WriteProcessMemory(hndProc, lpAddress, buffer, (uint)buffer.Length, (UIntPtr)wrotelen);
//            NativeMethods.WriteProcessMemory(hndProc, lpAddress, buffer, (uint)buffer.Length, (UIntPtr)wrotelen);
//
//            if (Marshal.GetLastWin32Error() != 0)
//            //if (NativeMethods.GetLastWin32Error() != 0)
//            {
//                //AccessViolationException ex = new AccessViolationException("Unable to write memory to process with an id " + procId);
//                //ThrowTerminatingError(new ErrorRecord(ex, "AccessDenined", ErrorCategory.SecurityError, null));
//                this.WriteError(
//                    this,
//                    "Unable to write memory to process with an id " + procId,
//                    "AccessDenined",
//                    ErrorCategory.SecurityError,
//                    true);
//            }
//        }
//
//        protected override void ProcessRecord()
//        {
//            base.ProcessRecord();
//
//            // initialize SYSTEMTIME
//            //int structMemLen = Marshal.SizeOf(typeof(SYSTEMTIME));
//            int structMemLen = Marshal.SizeOf(typeof(NativeMethods.SYSTEMTIME));
//            byte[] buffer = new byte[structMemLen];
//            //SYSTEMTIME sysTime = new SYSTEMTIME(date);
//            NativeMethods.SYSTEMTIME sysTime = new NativeMethods.SYSTEMTIME(date);
//
//            // get memory size of SYSTEMTIME
//            IntPtr dataPtr = Marshal.AllocHGlobal(structMemLen);
//            Marshal.StructureToPtr(sysTime, dataPtr, true);
//            Marshal.Copy(dataPtr, buffer, 0, structMemLen);
//            Marshal.FreeHGlobal(dataPtr);
//            //IntPtr dataPtr = NativeMethods.AllocHGlobal(structMemLen);
//            //NativeMethods.StructureToPtr(sysTime, dataPtr, true);
//            //NativeMethods.Copy(dataPtr, buffer, 0, structMemLen);
//            //NativeMethods.FreeHGlobal(dataPtr);
//
//            IntPtr hndProc = IntPtr.Zero;
//            IntPtr lpAddress = IntPtr.Zero;
//            int procId = inputObject.Current.ProcessId;
//            int inputHandle = inputObject.Current.NativeWindowHandle;
//
//            try
//            {
//                // inject new SYSTEMTIME into process memory
//                injectMemory(procId, buffer, out hndProc, out lpAddress);
//
//                // set DateTime to object via pointer to injected SYSTEMTIME
//                //SendMessage((IntPtr)inputHandle, DTM_SETSYSTEMTIME, (IntPtr)GDT_VALID, lpAddress);
//                NativeMethods.SendMessage((IntPtr)inputHandle, NativeMethods.DTM_SETSYSTEMTIME, (IntPtr)NativeMethods.GDT_VALID, lpAddress);
//            }
//            finally
//            {
//                // release memory and close handle
//                if (lpAddress != (IntPtr)0 || lpAddress != IntPtr.Zero)
//                {
//                    // we don't really care about the result because if release fails there is nothing we can do about it
//                    //bool relState = VirtualFreeEx(hndProc, lpAddress, 0, FreeType.Release);
//                    bool relState = NativeMethods.VirtualFreeEx(hndProc, lpAddress, 0, NativeMethods.FreeType.Release);
//                }
//
//                if (hndProc != (IntPtr)0 || hndProc != IntPtr.Zero)
//                {
//                    //CloseHandle(hndProc);
//                    NativeMethods.CloseHandle(hndProc);
//                }
//            }
//        }
//    }
//}
