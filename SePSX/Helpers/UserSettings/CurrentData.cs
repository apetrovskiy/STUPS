using System.Collections.Generic;
/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/18/2012
 * Time: 9:43 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System;
    using OpenQA.Selenium;
    
    //using System.Diagnostics;
    
    /// <summary>
    /// Description of CurrentData.
    /// </summary>
    public static class CurrentData
    {
        static CurrentData()
        {
//            Error = new System.Collections.ArrayList(Preferences.MaximumErrorCount);
//            //Profiles = new System.Collections.Generic.List<Profile>();
//            Drivers = new System.Collections.Generic.Dictionary<string, IWebDriver>();
//            DriverPIDs = new System.Collections.Generic.Dictionary<string, int>();
//            DriverHandles = new System.Collections.Generic.Dictionary<string, IntPtr>();
            
            Init();
        }
        
//        public static AutomationElement CurrentWindow { get; internal set; }
        public static IWebDriver CurrentWebDriver { get; internal set; }
        public static int CurrentWebDriverPID { get; internal set; }
        public static IntPtr CurrentWebDriverHandle { get; internal set; }
        public static System.Collections.ArrayList Error { get; set; }
        
        public static System.Collections.Generic.Dictionary<string, IWebDriver> Drivers { get; set; }
        public static System.Collections.Generic.Dictionary<string, int> DriverPIDs { get; set; }
        public static System.Collections.Generic.Dictionary<string, IntPtr> DriverHandles { get; set; }
        public static string LastCmdlet { get; internal set; }
        public static object LastResult { get; internal set; }
//        public static System.Collections.Generic.List<Profile> Profiles { get; set; }
//        internal static System.Collections.Generic.List<object> Events { get; set; }
        
//        internal static Commands.RecorderForm formRecorder { get; set; }
        
//        public static AutomationElement LastEventSource { get; set; }
//        //internal static EventArgs LastEventArgs { get; set; }
//        public static EventArgs LastEventArgs { get; set; }
//        //internal static string LastEventType { get; set; }
//        public static string LastEventType { get; set; }
//        //internal static bool LastEventInfoAdded { get; set; }
//        public static bool LastEventInfoAdded { get; set; }
        
//        public static CacheRequest CacheRequest = null;
        
        private static bool initFlag = false;

        internal static void Init()
        {
            if (!initFlag) {
                Error = new System.Collections.ArrayList(Preferences.MaximumErrorCount);
                //Profiles = new System.Collections.Generic.List<Profile>();
                Drivers = new System.Collections.Generic.Dictionary<string, IWebDriver>();
                DriverPIDs = new System.Collections.Generic.Dictionary<string, int>();
                DriverHandles = new System.Collections.Generic.Dictionary<string, IntPtr>();
                initFlag = true;
            }
        }
        
        internal static void InitUnconditional()
        {
            initFlag = false;
            Init();
        }
        
        public static void ResetData()
        {
//            CurrentWebDriver = null;
//            CurrentWebDriverPID = 0;
//            CurrentWebDriverHandle = IntPtr.Zero;
            Error.Clear();
//            LastCmdlet = null;
//            LastResult = null;
            
//            // Events
//            LastEventSource = null;
//            LastEventType = string.Empty;
//            LastEventArgs = null;
//            LastEventInfoAdded = false;
            
            System.Collections.Generic.Dictionary<string, IWebDriver>.KeyCollection keys = Drivers.Keys;
            foreach (string key in keys) {
//                try { Drivers[key].Close(); } catch {}
//                try { Drivers[key].Dispose(); } catch {}
                try { Drivers[key].Quit(); } catch {}
            }
            
            CurrentWebDriver = null;
            CurrentWebDriverPID = 0;
            CurrentWebDriverHandle = IntPtr.Zero;
            Drivers.Clear();
            DriverPIDs.Clear();
            DriverHandles.Clear();
        }
        
//        public static void SetCurrentWindow(AutomationElement window)
//        {
//            if (window is AutomationElement) {
//                CurrentData.CurrentWindow = window;
//            } else {
//                CurrentData.CurrentWindow = null;
//            }
//        }
    }
}
