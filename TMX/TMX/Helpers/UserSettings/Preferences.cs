/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/7/2012
 * Time: 6:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    
    /// <summary>
    /// Description of Preferences.
    /// </summary>
    public static class Preferences
    {
        static Preferences()
        {
            TestLog = false;
            
            LogScriptName_Failed = false;
            LogLineNumber_Failed = true;
            LogCode_Failed = true;
            
            LogScriptName_Passed = false;
            LogLineNumber_Passed = false;
            LogCode_Passed = false;
        }
        
        public static bool TestLog { get; set; }
        
        public static bool LogScriptName_Failed { get; set; }
        public static bool LogLineNumber_Failed { get; set; }
        public static bool LogCode_Failed { get; set; }
        
        public static bool LogScriptName_Passed { get; set; }
        public static bool LogLineNumber_Passed { get; set; }
        public static bool LogCode_Passed { get; set; }
    }
}
