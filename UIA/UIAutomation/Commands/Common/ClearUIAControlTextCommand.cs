/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/8/2013
 * Time: 11:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ClearUiaControlTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Clear, "UiaControlText")]
    public class ClearUiaControlTextCommand : HasControlInputCmdletBase
    {
        protected override void ProcessRecord()
        {
            if (!CheckAndPrepareInput(this)) { return; }
            
            foreach (IMySuperWrapper inputObject in InputObject) {
                
                if (0 == inputObject.Current.NativeWindowHandle) {
                        
                    WriteError(
                        this,
                        "The handle of this control equals to zero",
                        "ZeroHandle",
                        ErrorCategory.InvalidArgument,
                        true);
                }
                
                IntPtr handle =
                    new IntPtr(inputObject.Current.NativeWindowHandle);
                
                NativeMethods.SendMessage3(handle, NativeMethods.WM_SETTEXT, IntPtr.Zero, "");
                
                if (PassThru) {
                    WriteObject(
                        this,
                        inputObject);
                }
            }
            
        } // 20120823
    }
}
