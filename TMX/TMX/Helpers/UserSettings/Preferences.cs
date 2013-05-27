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
            
            // 20130429
            AutoEcho = false;
            // 20130430
            AutoLog = false;
        }
        
        public static bool TestLog { get; set; }
        
        public static bool LogScriptName_Failed { get; set; }
        public static bool LogLineNumber_Failed { get; set; }
        public static bool LogCode_Failed { get; set; }
        
        public static bool LogScriptName_Passed { get; set; }
        public static bool LogLineNumber_Passed { get; set; }
        public static bool LogCode_Passed { get; set; }
        
        // 20130429
        public static bool AutoEcho { get; set; }
        // 20130429
        public static bool AutoLog { get; set; }
        
        public static bool Storage { get; set; }
        public static string StorageServer { get; set; }
        public static string StorageDatabase { get; set; }
        public static string StorageUsername { get; set; }
        public static string StoragePassword { get; set; }
        public static bool StorageIntegratedSecurity { get; set; }
        public static string StorageConnectionString { get; internal set; }
        
    }
}
