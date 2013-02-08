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
    using System.Runtime.InteropServices;
    using System.Text;
    
    
    // 20120823
    using System.Windows.Automation;
    
    /// <summary>
    /// Description of SetUIAControlTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAControlText")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIAControlTextCommand : HasControlInputCmdletBase
    {
        #region Constructor
        public SetUIAControlTextCommand()
        {
        }
        #endregion Constructor
        
        #region Parameters
        [Parameter(Mandatory = true,
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
            if (!this.CheckControl(this)) { return; }
            
            foreach (AutomationElement inputObject in this.InputObject) {
                
                if (0 == inputObject.Current.NativeWindowHandle) {
        //                ErrorRecord err = 
        //                    new ErrorRecord(new Exception("The handle of this control equals to zero"),
        //                                    "ZeroHandle",
        //                                    ErrorCategory.InvalidArgument,
        //                                    // 20130105
        //                                    //this.InputObject);
        //                                    inputObject);
        //                err.ErrorDetails = 
        //                    new ErrorDetails("This control does not have a handle. Try to use its parent");
        //// 20120209 
        //// WriteError(this, err);
        //// return;
        //                WriteError(this, err, true);
                        
                    this.WriteError(
                        this,
                        "The handle of this control equals to zero",
                        "ZeroHandle",
                        ErrorCategory.InvalidArgument,
                        true);
                }
                
                System.IntPtr handle =
                    new System.IntPtr(inputObject.Current.NativeWindowHandle);
                
                // 20130208
                // clean up the box
                NativeMethods.SendMessage3(handle, NativeMethods.WM_SETTEXT, IntPtr.Zero, "");
                    
                char c1;
                foreach (char c in this.Text) {
    // if (c  > = 65 && c <= 122) {
    // c1 = c. - System.Char. (char)32;
    // } else {
                    c1 = c;
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
                if (this.PassThru) {
                    this.WriteObject(
                        this,
                        inputObject);
                }
            }
            
        } // 20120823
        
    }
}
