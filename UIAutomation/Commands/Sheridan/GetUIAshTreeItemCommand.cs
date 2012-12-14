using System.Windows.Automation;
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
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetUIAshTreeItemCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAshTreeItem")]
    public class GetUIAshTreeItemCommand : SheridanCmdletBase
    {
        public GetUIAshTreeItemCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            
            if (!this.CheckControl(this)) { return; }
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

            foreach (AutomationElement inputObject in this.InputObject) {
                
                UIAHelper.GetSheridanTreeItemByName(
                    this, 
                    (IntPtr)inputObject.Current.NativeWindowHandle,
                    this.Name);
                
            }

        }
    }
}
