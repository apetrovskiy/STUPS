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
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of HotkeyCmdletBase.
    /// </summary>
    public class HotkeyCmdletBase : HasScriptBlockCmdletBase
    {
        public HotkeyCmdletBase()
        {
        }
        
        protected List<byte> keyCodes = 
            new List<byte>();
        
        protected void processKeys() //System.Collections.Generic.List<byte> keysList)
        {
            foreach (byte bt in keyCodes)
            {
                NativeMethods.keybd_event( bt,
                    0x45,
                    NativeMethods.KEYEVENTF_EXTENDEDKEY | 0,
                    0 );
            }

            /*
            for (int i = 0; i < keyCodes.Count; i++) {
                NativeMethods.keybd_event( keyCodes[i],
                                          0x45,
                                          NativeMethods.KEYEVENTF_EXTENDEDKEY | 0,
                                          0 );
            }
            */

            for (int i = keyCodes.Count; i > 0; i--) {
                NativeMethods.keybd_event( keyCodes[i-1],
                                          0x45,
                                          NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP,
                                          0);
            }
        }
    }
}
