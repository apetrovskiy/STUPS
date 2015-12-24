/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 31/01/2012
 * Time: 07:44 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of SetUiaControlTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaControlText")]
    public class SetUiaControlTextCommand : HasControlInputCmdletBase
    {
        #region Parameters
        [UiaParameter][Parameter(Mandatory = true,
                   Position = 0)]
        [AllowEmptyString]
        public string Text { get; set; }
        #endregion Parameters
        
//        #region declarations
//        uint WM_CHAR                        = 0x0102;
//        // 20120206 uint WM_SETTEXT                        = 0x000C;
//// uint WM_KEYDOWN                        = 0x0100;
//// uint WM_KEYUP                        = 0x0100;
//
//
//            
//        [DllImport("user32.dll", EntryPoint="SendMessage", CharSet=CharSet.Auto)]
//        [return: MarshalAs(UnmanagedType.Bool)]
//        private static extern bool SendMessage1(IntPtr hWnd, uint Msg,
//                                        int wParam, int lParam);
//        #endregion declarations
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!CheckAndPrepareInput(this)) { return; }
            
            foreach (IUiElement inputObject in InputObject) {
                
                // 20140312
                // if (0 == inputObject.Current.NativeWindowHandle) {
                if (0 == inputObject.GetCurrent().NativeWindowHandle) {
                    
                    WriteError(
                        this,
                        "The handle of this control equals to zero",
                        "ZeroHandle",
                        ErrorCategory.InvalidArgument,
                        true);
                }
                
                // 20140312
//                IntPtr handle =
//                    new IntPtr(inputObject.Current.NativeWindowHandle);
                var handle =
                    new IntPtr(inputObject.GetCurrent().NativeWindowHandle);
                
                // 20130208
                // clean up the box
                NativeMethods.SendMessage3(handle, NativeMethods.WM_SETTEXT, IntPtr.Zero, "");

                foreach (char c in Text) {
    // if (c  > = 65 && c <= 122) {
    // c1 = c. - System.Char. (char)32;
    // } else {
                    char c1 = c;
    // }
                    NativeMethods.SendMessage1(handle, 
                                 NativeMethods.WM_KEYDOWN, 
                                 c1,
                                 0);
                    NativeMethods.SendMessage1(handle, 
                                 NativeMethods.WM_CHAR, 
                                 c1,
                                 1);
                    // System.Threading.Thread.Sleep(200);
                    NativeMethods.SendMessage1(handle, 
                                 NativeMethods.WM_KEYUP, 
                                 c1,
                                 65539);
                }
                
                // 20130208
                if (PassThru) {
                    WriteObject(
                        this,
                        inputObject);
                }
            }
            
        } // 20120823
        
    }
}
