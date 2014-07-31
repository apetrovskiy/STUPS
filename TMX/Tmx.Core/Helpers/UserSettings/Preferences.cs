/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/7/2012
 * Time: 6:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
	using NHibernate.Event.Default;
    
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
            
            AutoEcho = false;
            AutoLog = false;
            
            ClientRegistrationTimeoutSeconds = 3600;
            ReceivingTaskTimeoutSeconds = 3600;
            ClientRegistrationSleepIntervalMilliseconds = 5000;
            ReceivingTaskSleepIntervalMilliseconds = 2000;
        }
        
        public static bool TestLog { get; set; }
        
        public static bool LogScriptName_Failed { get; set; }
        public static bool LogLineNumber_Failed { get; set; }
        public static bool LogCode_Failed { get; set; }
        
        public static bool LogScriptName_Passed { get; set; }
        public static bool LogLineNumber_Passed { get; set; }
        public static bool LogCode_Passed { get; set; }
        
        public static bool AutoEcho { get; set; }
        public static bool AutoLog { get; set; }
        
        public static bool Storage { get; set; }
        public static string StorageServer { get; set; }
        public static string StorageDatabase { get; set; }
        public static string StorageUsername { get; set; }
        public static string StoragePassword { get; set; }
        public static bool StorageIntegratedSecurity { get; set; }
        public static string StorageConnectionString { get; internal set; }
        
        public static int ClientRegistrationTimeoutSeconds { get; set; }
        public static int ReceivingTaskTimeoutSeconds { get; set; }
        public static int ClientRegistrationSleepIntervalMilliseconds { get; set; }
        public static int ReceivingTaskSleepIntervalMilliseconds { get; set; }
    }
}
