/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/22/2012
 * Time: 5:40 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of SheridanCmdletBase.
    /// </summary>
    public class SheridanCmdletBase : HasControlInputCmdletBase
    {
        public SheridanCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   Position = 0)]
        public string Name { get; set; }
        #endregion Parameters
        
//        //Define TreeView Flags and Messages
//        protected const int BN_CLICKED = 0xF5;
//        protected const int TV_FIRST = 0x1100;
//        protected const int TVGN_ROOT = 0x0;
//        protected const int TVGN_NEXT = 0x1;
//        protected const int TVGN_CHILD = 0x4;
//        protected const int TVGN_FIRSTVISIBLE = 0x5;
//        protected const int TVGN_NEXTVISIBLE = 0x6;
//        protected const int TVGN_CARET = 0x9;
//        protected const int TVM_SELECTITEM = (TV_FIRST + 11);
//        protected const int TVM_GETNEXTITEM = (TV_FIRST + 10);
//        protected const int TVM_GETITEM = (TV_FIRST + 12);
        
        
    }
}
