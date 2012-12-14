/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/25/2012
 * Time: 9:33 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of HotkeyCmdletBase.
    /// </summary>
    public class HotkeyCmdletBase : HasScriptBlockCmdletBase
    {
        public HotkeyCmdletBase()
        {
        }
        
        protected System.Collections.Generic.List<byte> keyCodes = 
            new System.Collections.Generic.List<byte>();
        
        protected void processKeys() //System.Collections.Generic.List<byte> keysList)
        {
            for (int i = 0; i < keyCodes.Count; i++) {
                NativeMethods.keybd_event( keyCodes[i],
                                          0x45,
                                          NativeMethods.KEYEVENTF_EXTENDEDKEY | 0,
                                          0 );
            }
            
            for (int i = keyCodes.Count; i > 0; i--) {
                NativeMethods.keybd_event( keyCodes[i-1],
                                          0x45,
                                          NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP,
                                          0);
            }
        }
    }
}
