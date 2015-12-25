
//namespace AVG.Automation.Cmdlets
namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;
    using System.Management.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    using System.Runtime.InteropServices;
    // using NativeTypes;

    /// <summary>
    /// Invokes selected WindowPattern on AutomationElement
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaWindowPattern")]
    public class InvokeUiaWindowPattern : Cmdlet
    {
        /// <summary>
        /// Parent object that is target for pattern
        /// </summary>
        [UiaParameter][Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        // 20131109
        //public AutomationElement InputObject { get; set; }
        public IUiElement InputObject { get; set; }

        /// <summary>
        /// Pattern name to be invoked
        /// </summary>
        [UiaParameter][Parameter(Mandatory = true, Position = 2)]
        [ValidateSet("Close", "Maximize", "Minimize", "Restore")]
        public string PatternName { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            // 20140312
            // if (InputObject.Current.ControlType == classic.ControlType.Window)
            if (InputObject.GetCurrent().ControlType == classic.ControlType.Window)
            {
                // 20131208
                // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                // WindowPattern windowPattern = InputObject.GetCurrentPattern(classic.WindowPattern.Pattern) as WindowPattern;
                // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                IWindowPattern windowPattern = InputObject.GetCurrentPattern<IWindowPattern>(classic.WindowPattern.Pattern);

                try
                {
                    switch (PatternName.ToLower())
                    {
                        case "close":
                            windowPattern.Close();
                            break;

                        case "maximize":
                            windowPattern.SetWindowVisualState(classic.WindowVisualState.Maximized);
                            break;

                        case "minimize":
                            windowPattern.SetWindowVisualState(classic.WindowVisualState.Minimized);
                            break;

                        case "restore":
                            windowPattern.SetWindowVisualState(classic.WindowVisualState.Normal);
                            break;
                    }
                }
                catch (InvalidOperationException)
                {
                    ArgumentException ex = new ArgumentException("Target window doesn't support '" + PatternName + "' pattern.");
                    ThrowTerminatingError(new ErrorRecord(ex, "WrongInputObject", ErrorCategory.InvalidArgument, null));
                }
            }
            else
            {
                ArgumentException ex = new ArgumentException("Cannot call WindowPattern on object that is not a Window.");
                ThrowTerminatingError(new ErrorRecord(ex, "WrongInputObject", ErrorCategory.InvalidArgument, null));
            }
        }
    }

    /// <summary>
    /// Sets control to foreground
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaControlForeground")]
    public class SetUiaControlForeground : Cmdlet
    {
        /// <summary>
        /// Window to be set to foreground
        /// </summary>
        [UiaParameter][Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        // 20131109
        //public AutomationElement InputObject { get; set; }
        public IUiElement InputObject { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            // 20140312
            // if (InputObject.Current.NativeWindowHandle != 0)
            if (InputObject.GetCurrent().NativeWindowHandle != 0)
            {
                // 20140312
                // NativeMethods.SetForegroundWindow((IntPtr)InputObject.Current.NativeWindowHandle);
                NativeMethods.SetForegroundWindow((IntPtr)InputObject.GetCurrent().NativeWindowHandle);
            }
            else
            {
                InputObject.SetFocus();
            }

            WriteObject(InputObject);
        }
    }

    /// <summary>
    /// Puts DateTime into DateTimePicker Win32 object
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaDateTimePickerDate")]
    public class SetUiaDateTimePickerDate : Cmdlet
    {
        /// <summary>
        /// DateTimePicker input object
        /// </summary>
        [UiaParameter][Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        // 20131109
        //public AutomationElement InputObject { get; set; }
        public IUiElement InputObject { get; set; }

        /// <summary>
        /// DateTime to bet set
        /// </summary>
        [UiaParameter][Parameter(Mandatory = true, Position = 2)]
        public DateTime Date { get; set; }

        const uint DTM_FIRST = 0x1000;
        const uint DTM_SETSYSTEMTIME = DTM_FIRST + 2;
        const ushort GDT_VALID = 0;

        private void injectMemory(int procId, byte[] buffer, out IntPtr hndProc, out IntPtr lpAddress)
        {
            // open process and get handle
            // hndProc = NativeMethods.OpenProcess(ProcessAccessFlags.All, true, procId);
            hndProc = NativeMethods.OpenProcess(NativeMethods.ProcessAccessFlags.All, true, procId);

            if (hndProc == (IntPtr)0)
            {
                AccessViolationException ex = new AccessViolationException("Unable to attach to process with an id " + procId);
                ThrowTerminatingError(new ErrorRecord(ex, "AccessDenined", ErrorCategory.SecurityError, null));
            }

            // allocate memory for object to be injected
            lpAddress = NativeMethods.VirtualAllocEx(hndProc, (IntPtr)null, (uint)buffer.Length,
                // AllocationType.Commit | AllocationType.Reserve, MemoryProtection.ExecuteReadWrite);
                NativeMethods.AllocationType.Commit | NativeMethods.AllocationType.Reserve, NativeMethods.MemoryProtection.ExecuteReadWrite);

            if (lpAddress == (IntPtr)0)
            {
                AccessViolationException ex = new AccessViolationException("Unable to allocate memory to proces with an id " + procId);
                ThrowTerminatingError(new ErrorRecord(ex, "AccessDenined", ErrorCategory.SecurityError, null));
            }

            // write data to process
            const uint wrotelen = 0;
            // uint wrotelen = 0;
            NativeMethods.WriteProcessMemory(hndProc, lpAddress, buffer, (uint)buffer.Length, (UIntPtr)wrotelen);

            if (Marshal.GetLastWin32Error() == 0) return;
            AccessViolationException ex2 = new AccessViolationException("Unable to write memory to process with an id " + procId);
            ThrowTerminatingError(new ErrorRecord(ex2, "AccessDenined", ErrorCategory.SecurityError, null));

            /*
            if (Marshal.GetLastWin32Error() != 0)
            {
                AccessViolationException ex = new AccessViolationException("Unable to write memory to process with an id " + procId);
                ThrowTerminatingError(new ErrorRecord(ex, "AccessDenined", ErrorCategory.SecurityError, null));
            }
            */
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            // initialize SYSTEMTIME
            // int structMemLen = Marshal.SizeOf(typeof(SYSTEMTIME));
            int structMemLen = Marshal.SizeOf(typeof(NativeMethods.SYSTEMTIME));
            // 20140312
            // byte[] buffer = new byte[structMemLen];
            var buffer = new byte[structMemLen];
            // SYSTEMTIME sysTime = new SYSTEMTIME(Date);
            // 20140312
            // NativeMethods.SYSTEMTIME sysTime = new NativeMethods.SYSTEMTIME(Date);
            var sysTime = new NativeMethods.SYSTEMTIME(Date);

            // get memory size of SYSTEMTIME
            IntPtr dataPtr = Marshal.AllocHGlobal(structMemLen);
            Marshal.StructureToPtr(sysTime, dataPtr, true);
            Marshal.Copy(dataPtr, buffer, 0, structMemLen);
            Marshal.FreeHGlobal(dataPtr);

            IntPtr hndProc = IntPtr.Zero;
            IntPtr lpAddress = IntPtr.Zero;
            // 20140312
//            int procId = InputObject.Current.ProcessId;
//            int inputHandle = InputObject.Current.NativeWindowHandle;
            int procId = InputObject.GetCurrent().ProcessId;
            int inputHandle = InputObject.GetCurrent().NativeWindowHandle;

            try
            {
                // inject new SYSTEMTIME into process memory
                injectMemory(procId, buffer, out hndProc, out lpAddress);

                // set DateTime to object via pointer to injected SYSTEMTIME
                NativeMethods.SendMessage((IntPtr)inputHandle, DTM_SETSYSTEMTIME, (IntPtr)GDT_VALID, lpAddress);
            }
            finally
            {
                // release memory and close handle
                if (lpAddress != (IntPtr)0 || lpAddress != IntPtr.Zero)
                {
                    // we don't really care about the result because if release fails there is nothing we can do about it
                    // bool relState = NativeMethods.VirtualFreeEx(hndProc, lpAddress, 0, FreeType.Release);
                    bool relState = NativeMethods.VirtualFreeEx(hndProc, lpAddress, 0, NativeMethods.FreeType.Release);
                }

                if (hndProc != (IntPtr)0 || hndProc != IntPtr.Zero)
                {
                    NativeMethods.CloseHandle(hndProc);
                }
            }
        }
    }
}
