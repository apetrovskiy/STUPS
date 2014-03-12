/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/22/2012
 * Time: 5:41 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;
    using System.Management.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    
    /// <summary>
    /// Description of GetUiaShTreeItemCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAshTreeItem")]
    public class GetUiaShTreeItemCommand : SheridanCmdletBase
    {
        public GetUiaShTreeItemCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            
            if (!CheckAndPrepareInput(this)) { return; }
//            
            
//            //Handle variables
//            int hwnd = 0;
//            int treeItem = 0;
//            IntPtr hwndChild = IntPtr.Zero;
//            IntPtr treeChild = IntPtr.Zero;

//            hwnd = FindWindow(null, "Application"); //Handle for the application to be controlled
//            if (hwnd > 0)
//            {
                //Select TreeView Item
//                treeChild = FindWindowEx((IntPtr)hwnd, IntPtr.Zero, "AfxMDIFrame80", null);
//                treeChild = FindWindowEx((IntPtr)treeChild, IntPtr.Zero, "AfxMDIFrame80", null);
//                treeChild = FindWindowEx((IntPtr)treeChild, IntPtr.Zero, "SysTreeView32", null);
//                treeItem = SendMessage((int)treeChild, TVM_GETNEXTITEM, TVGN_ROOT, IntPtr.Zero);
//                treeItem = SendMessage((int)treeChild, TVM_GETNEXTITEM, TVGN_NEXT, (IntPtr)treeItem);
//                treeItem = SendMessage((int)treeChild, TVM_GETNEXTITEM, TVGN_CHILD, (IntPtr)treeItem);
//                SendMessage((int)treeChild, TV_SELECTITEM, TVGN_CARET, (IntPtr)treeItem);

                // ...Continue with my automation...
//            }
            
            // 20131109
            //foreach (AutomationElement inputObject in this.InputObject) {
            foreach (IUiElement inputObject in InputObject) {
                
                UiaHelper.GetSheridanTreeItemByName(
                    this, 
                    // 20140312
                    // (IntPtr)inputObject.Current.NativeWindowHandle,
                    (IntPtr)inputObject.GetCurrent().NativeWindowHandle,
                    Name);
                
            }

        }
    }
}
