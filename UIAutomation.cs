using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using System.Windows.Automation;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Collections;
using System.Diagnostics;
using AVG.Automation.Cmdlets.NativeTypes;

namespace AVG.Automation.Cmdlets
{
    /// <summary>
    /// Invokes selected WindowPattern on AutomationElement
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAWindowPattern")]
    public class InvokeUIAWindowPattern : Cmdlet
    {
        /// <summary>
        /// Parent object that is target for pattern
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        public AutomationElement InputObject { get; set; }

        /// <summary>
        /// Pattern name to be invoked
        /// </summary>
        [Parameter(Mandatory = true, Position = 2)]
        [ValidateSet("Close", "Maximize", "Minimize", "Restore")]
        public string PatternName { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (InputObject.Current.ControlType == ControlType.Window)
            {
                WindowPattern windowPattern = InputObject.GetCurrentPattern(WindowPattern.Pattern) as WindowPattern;

                try
                {
                    switch (PatternName.ToLower())
                    {
                        case "close":
                            windowPattern.Close();
                            break;

                        case "maximize":
                            windowPattern.SetWindowVisualState(WindowVisualState.Maximized);
                            break;

                        case "minimize":
                            windowPattern.SetWindowVisualState(WindowVisualState.Minimized);
                            break;

                        case "restore":
                            windowPattern.SetWindowVisualState(WindowVisualState.Normal);
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
    [Cmdlet(VerbsCommon.Set, "UIAControlForeground")]
    public class SetUIAControlForeground : Cmdlet
    {
        /// <summary>
        /// Window to be set to foreground
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        public AutomationElement InputObject { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (InputObject.Current.NativeWindowHandle != 0)
            {
                NativeMethods.SetForegroundWindow((IntPtr)InputObject.Current.NativeWindowHandle);
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
    [Cmdlet(VerbsCommon.Set, "UIADateTimePickerDate")]
    public class SetUIADateTimePickerDate : Cmdlet
    {
        /// <summary>
        /// DateTimePicker input object
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        public AutomationElement InputObject { get; set; }

        /// <summary>
        /// DateTime to bet set
        /// </summary>
        [Parameter(Mandatory = true, Position = 2)]
        public DateTime Date { get; set; }

        const uint DTM_FIRST = 0x1000;
        const uint DTM_SETSYSTEMTIME = DTM_FIRST + 2;
        const ushort GDT_VALID = 0;

        private void injectMemory(int procId, byte[] buffer, out IntPtr hndProc, out IntPtr lpAddress)
        {
            // open process and get handle
            hndProc = NativeMethods.OpenProcess(ProcessAccessFlags.All, true, procId);

            if (hndProc == (IntPtr)0)
            {
                AccessViolationException ex = new AccessViolationException("Unable to attach to process with an id " + procId);
                ThrowTerminatingError(new ErrorRecord(ex, "AccessDenined", ErrorCategory.SecurityError, null));
            }

            // allocate memory for object to be injected
            lpAddress = NativeMethods.VirtualAllocEx(hndProc, (IntPtr)null, (uint)buffer.Length,
                AllocationType.Commit | AllocationType.Reserve, MemoryProtection.ExecuteReadWrite);

            if (lpAddress == (IntPtr)0)
            {
                AccessViolationException ex = new AccessViolationException("Unable to allocate memory to proces with an id " + procId);
                ThrowTerminatingError(new ErrorRecord(ex, "AccessDenined", ErrorCategory.SecurityError, null));
            }

            // write data to process
            uint wrotelen = 0;
            NativeMethods.WriteProcessMemory(hndProc, lpAddress, buffer, (uint)buffer.Length, (UIntPtr)wrotelen);

            if (Marshal.GetLastWin32Error() != 0)
            {
                AccessViolationException ex = new AccessViolationException("Unable to write memory to process with an id " + procId);
                ThrowTerminatingError(new ErrorRecord(ex, "AccessDenined", ErrorCategory.SecurityError, null));
            }
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            // initialize SYSTEMTIME
            int structMemLen = Marshal.SizeOf(typeof(SYSTEMTIME));
            byte[] buffer = new byte[structMemLen];
            SYSTEMTIME sysTime = new SYSTEMTIME(Date);

            // get memory size of SYSTEMTIME
            IntPtr dataPtr = Marshal.AllocHGlobal(structMemLen);
            Marshal.StructureToPtr(sysTime, dataPtr, true);
            Marshal.Copy(dataPtr, buffer, 0, structMemLen);
            Marshal.FreeHGlobal(dataPtr);

            IntPtr hndProc = IntPtr.Zero;
            IntPtr lpAddress = IntPtr.Zero;
            int procId = InputObject.Current.ProcessId;
            int inputHandle = InputObject.Current.NativeWindowHandle;

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
                    bool relState = NativeMethods.VirtualFreeEx(hndProc, lpAddress, 0, FreeType.Release);
                }

                if (hndProc != (IntPtr)0 || hndProc != IntPtr.Zero)
                {
                    NativeMethods.CloseHandle(hndProc);
                }
            }
        }
    }
}
