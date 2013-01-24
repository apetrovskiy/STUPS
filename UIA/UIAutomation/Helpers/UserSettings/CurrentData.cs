/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 16/12/2011
 * Time: 11:43 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Windows.Automation;

    /// <summary>
    /// Description of CurrentData.
    /// </summary>
    public static class CurrentData
    {
        static CurrentData()
        {
            // 20130109
//            Error = new System.Collections.ArrayList(Preferences.MaximumErrorCount);
//            //TestResults = 
//            // new System.Collections.Generic.List<TestResult > ();
//            ////initTestResults();
//            Profiles = new System.Collections.Generic.List<Profile>();
//            
//            // 20130109
//            Events = new System.Collections.Generic.List<object>();
            
            InitializeData();
        }
        
        public static AutomationElement CurrentWindow { get; internal set; }
        public static System.Collections.ArrayList Error { get; set; }
        public static string LastCmdlet { get; internal set; }
        public static object LastResult { get; internal set; }
        public static System.Collections.Generic.List<Profile> Profiles { get; set; }
        //internal static System.Collections.Generic.List<System.Windows.Automation.AutomationEventHandler> Events { get; set; }
        //internal static System.Collections.Generic.List<object> Events { get; set; }
public static System.Collections.Generic.List<object> Events { get; set; } // temporary ??
        
        internal static Commands.RecorderForm formRecorder { get; set; }
        
        public static AutomationElement LastEventSource { get; set; }
        //internal static EventArgs LastEventArgs { get; set; }
        public static EventArgs LastEventArgs { get; set; }
        //internal static string LastEventType { get; set; }
        public static string LastEventType { get; set; }
        //internal static bool LastEventInfoAdded { get; set; }
        public static bool LastEventInfoAdded { get; set; }
        
        public static CacheRequest CacheRequest = null;
        
        internal static void InitializeData()
        {
            Error = new System.Collections.ArrayList(Preferences.MaximumErrorCount);
            Profiles = new System.Collections.Generic.List<Profile>();
            
            InitializeEventCollection();
        }
        
        internal static void InitializeEventCollection()
        {
            Events = new System.Collections.Generic.List<object>();
        }
        
        public static void ResetData()
        {
            CurrentWindow = null;
            Error.Clear();
            LastCmdlet = null;
            LastResult = null;
            
            // Events
            LastEventSource = null;
            LastEventType = string.Empty;
            LastEventArgs = null;
            LastEventInfoAdded = false;
            
            // 20130109
            try {
                Automation.RemoveAllEventHandlers();
                Events.Clear();
            }
            catch {
                
            }
        }
        
        public static void SetCurrentWindow(AutomationElement window)
        {
            if (window is AutomationElement) {
                CurrentData.CurrentWindow = window;
            } else {
                CurrentData.CurrentWindow = null;
            }
        }
        
        internal static Profile GetProfile(string name)
        {
            Profile result = null;
            foreach (Profile profile in CurrentData.Profiles) {
                if (name == profile.Name) {
                    result = profile;
                    break;
                }
            }
            
            return result;
        }
        
// private static void initTestResults()
// {
// if (TestResults.Count<1) {
// TestResults.Add(new TestResult());
// }
// }
    }
}
