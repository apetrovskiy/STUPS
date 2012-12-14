/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/20/2012
 * Time: 10:43 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Runtime.InteropServices;
    //using 
    
    /// <summary>
    /// Description of JavaHelper.
    /// </summary>
    public static class JavaHelper
    {
        [DllImport("windowsaccessbridge.dll", SetLastError = true)]
        internal extern static void Windows_run();
        
        static JavaHelper()
        {
        }
        
 
        public static void JavaAPIFunc ()
        {
            Windows_run();
        }
    }
}
