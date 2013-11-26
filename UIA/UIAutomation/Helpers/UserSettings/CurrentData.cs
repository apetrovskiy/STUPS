/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 16/12/2011
 * Time: 11:43 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UIAutomation.Commands;

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
//            // new System.Collections.Generic.List<TestResult>();
//            ////initTestResults();
//            Profiles = new System.Collections.Generic.List<Profile>();
//            
//            // 20130109
//            Events = new System.Collections.Generic.List<object>();
            
            InitializeData();
        }
        
        // 20131109
        //public static AutomationElement CurrentWindow { get; internal set; }
        public static IMySuperWrapper CurrentWindow { get; internal set; }
        public static ArrayList Error { get; set; }
        public static string LastCmdlet { get; internal set; }
        public static object LastResult { get; internal set; }
        public static List<Profile> Profiles { get; set; }
        //internal static System.Collections.Generic.List<System.Windows.Automation.AutomationEventHandler> Events { get; set; }
        //internal static System.Collections.Generic.List<object> Events { get; set; }
public static List<object> Events { get; set; } // temporary ??
        
        internal static RecorderForm formRecorder { get; set; }
        
        // 20131109
        //public static AutomationElement LastEventSource { get; set; }
        public static IMySuperWrapper LastEventSource { get; set; }
        //internal static EventArgs LastEventArgs { get; set; }
        public static EventArgs LastEventArgs { get; set; }
        //internal static string LastEventType { get; set; }
        public static string LastEventType { get; set; }
        //internal static bool LastEventInfoAdded { get; set; }
        public static bool LastEventInfoAdded { get; set; }
        
        public static CacheRequest CacheRequest = null;
        
        internal static void InitializeData()
        {
            Error = new ArrayList(Preferences.MaximumErrorCount);
            Profiles = new List<Profile>();
            
            InitializeEventCollection();
        }
        
        internal static void InitializeEventCollection()
        {
            Events = new List<object>();
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
        
        // 20131109
        //public static void SetCurrentWindow(AutomationElement window)
        public static void SetCurrentWindow(IMySuperWrapper window)
        {
            CurrentWindow = window ?? null;

            /*
            if (window != null) {
                CurrentData.CurrentWindow = window;
            } else {
                CurrentData.CurrentWindow = null;
            }
            */

            /*
            if (window is AutomationElement) {
                CurrentData.CurrentWindow = window;
            } else {
                CurrentData.CurrentWindow = null;
            }
            */
        }

        internal static Profile GetProfile(string name)
        {
            return Profiles.FirstOrDefault(profile => name == profile.Name);
            /*
            Profile result = null;
            foreach (Profile profile in CurrentData.Profiles)
            {
                if (name == profile.Name)
                {
                    result = profile;
                    break;
                }
            }

            return result;
            */
        }

// private static void initTestResults()
// {
// if (TestResults.Count<1) {
// TestResults.Add(new TestResult());
// }
// }
    }
}
