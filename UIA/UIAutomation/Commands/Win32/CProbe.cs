/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/6/2013
 * Time: 1:52 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands.Win32
{
    using System;
    using System.Runtime.InteropServices;
    
//    /// <summary>
//    /// Description of CProbe.
//    /// </summary>
//    public class CProbe
//    {
//        public CProbe()
//        {
//        }
//    }
    
    // http://stackoverflow.com/questions/78161/assistance-porting-commctrl-commands-to-c-sharp
    static class Interop {

        public static IntPtr TreeView_SetCheckState(HandleRef hwndTV, IntPtr hti, bool fCheck) {
            return TreeView_SetItemState(hwndTV, hti, INDEXTOSTATEIMAGEMASK((fCheck) ? 2 : 1), (uint)TVIS.TVIS_STATEIMAGEMASK);
        }
        
        public static IntPtr TreeView_SetItemState(HandleRef hwndTV, IntPtr hti, uint data, uint _mask) {
            TVITEM _ms_TVi = new TVITEM();
            _ms_TVi.mask = (uint)TVIF.TVIF_STATE;
            _ms_TVi.hItem = (hti);
            _ms_TVi.stateMask = (_mask);
            _ms_TVi.state = (data);
            IntPtr p = Marshal.AllocCoTaskMem(Marshal.SizeOf(_ms_TVi));
            Marshal.StructureToPtr(_ms_TVi, p, false);
            IntPtr r = SendMessage(hwndTV, (int)TVM.TVM_SETITEMW, IntPtr.Zero, p);
            Marshal.FreeCoTaskMem(p);
            return r;
        }
        
//        UINT TreeView_GetItemState(
//          HWND hwndTV,
//          HTREEITEM hItem,
//          UINT stateMask
//        );

//        public static uint TreeView_GetItemState(HandleRef hwndTV, IntPtr hItem, uint stateMask)
//        {
//            
//        }
        
        private static uint INDEXTOSTATEIMAGEMASK(int i) { return ((uint)(i) << 12); }
        
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(HandleRef hWnd, int msg, IntPtr wParam, IntPtr lParam);
        
        private enum TVIF : uint {
            TVIF_STATE = 0x0008
        }
        
        private enum TVIS : uint {
            TVIS_STATEIMAGEMASK = 0xF000
        }
        
        private enum TVM : int {
            TV_FIRST = 0x1100,
            TVM_SETITEMA = (TV_FIRST + 13),
            TVM_SETITEMW = (TV_FIRST + 63)
        }
        
        private struct TVITEM {
            public uint mask;
            public IntPtr hItem;
            public uint state;
            public uint stateMask;
            public IntPtr pszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage;
            public int cChildren;
            public IntPtr lParam;
        }
    }
}
