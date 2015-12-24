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
        public static int CurrentWebDriverPid { get; internal set; }
        public static IntPtr CurrentWebDriverHandle { get; internal set; }
        public static System.Collections.ArrayList Error { get; set; }
        
        public static System.Collections.Generic.Dictionary<string, IWebDriver> Drivers { get; set; }
        public static System.Collections.Generic.Dictionary<string, int> DriverPiDs { get; set; }
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
        
        private static bool _initFlag = false;

        internal static void Init()
        {
            if (!_initFlag) {
                Error = new System.Collections.ArrayList(Preferences.MaximumErrorCount);
                //Profiles = new System.Collections.Generic.List<Profile>();
                Drivers = new System.Collections.Generic.Dictionary<string, IWebDriver>();
                DriverPiDs = new System.Collections.Generic.Dictionary<string, int>();
                DriverHandles = new System.Collections.Generic.Dictionary<string, IntPtr>();
                _initFlag = true;
            }
        }
        
        internal static void InitUnconditional()
        {
            _initFlag = false;
            Init();
        }
        
        public static void ResetData()
        {
Console.WriteLine("ResetData: 00001");
//            CurrentWebDriver = null;
//            CurrentWebDriverPID = 0;
//            CurrentWebDriverHandle = IntPtr.Zero;
            Error.Clear();
//            LastCmdlet = null;
//            LastResult = null;
Console.WriteLine("ResetData: 00002");
//            // Events
//            LastEventSource = null;
//            LastEventType = string.Empty;
//            LastEventArgs = null;
//            LastEventInfoAdded = false;
            
            var keys = Drivers.Keys;
Console.WriteLine("ResetData: 00002-1 keys.Count = " + keys.Count.ToString());
Console.WriteLine("ResetData: 00003");
            foreach (var key in keys) {
Console.WriteLine("ResetData: 00004 key = " + key);
//                try { Drivers[key].Close(); } catch {}
//                try { Drivers[key].Dispose(); } catch {}
if (null == Drivers) {
    Console.WriteLine("Drivers == null");
}
if (null == Drivers[key]) {
    Console.WriteLine("Drivers[key] == null");
}
                try { Drivers[key].Quit(); } catch {}
Console.WriteLine("ResetData: 00004-1");
            }
Console.WriteLine("ResetData: 00005");
            CurrentWebDriver = null;
            CurrentWebDriverPid = 0;
Console.WriteLine("ResetData: 00007");
            CurrentWebDriverHandle = IntPtr.Zero;
Console.WriteLine("ResetData: 00008");
            Drivers.Clear();
Console.WriteLine("ResetData: 00009");
            DriverPiDs.Clear();
Console.WriteLine("ResetData: 00010");
            DriverHandles.Clear();
Console.WriteLine("ResetData: 00011");
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
