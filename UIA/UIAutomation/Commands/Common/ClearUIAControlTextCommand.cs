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
    //using System.Runtime.InteropServices;
    //using System.Text;
    using System.Windows.Automation;
    
    /// <summary>
    /// Description of ClearUIAControlTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Clear, "UIAControlText")]
    public class ClearUIAControlTextCommand : HasControlInputCmdletBase
    {
        public ClearUIAControlTextCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            if (!this.CheckControl(this)) { return; }
            
            foreach (AutomationElement inputObject in this.InputObject) {
                
                if (0 == inputObject.Current.NativeWindowHandle) {
                        
                    this.WriteError(
                        this,
                        "The handle of this control equals to zero",
                        "ZeroHandle",
                        ErrorCategory.InvalidArgument,
                        true);
                }
                
                System.IntPtr handle =
                    new System.IntPtr(inputObject.Current.NativeWindowHandle);
                
                NativeMethods.SendMessage3(handle, NativeMethods.WM_SETTEXT, IntPtr.Zero, "");
                
                if (this.PassThru) {
                    this.WriteObject(
                        this,
                        inputObject);
                }
            }
            
        } // 20120823
    }
}
