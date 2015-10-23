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
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Commands;

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
        
        public static IUiElement CurrentWindow { get; internal set; }
        // 20131202
        // public static ArrayList Error { get; set; }
        public static List<ErrorRecord> Error { get; set; }
        public static string LastCmdlet { get; internal set; }
        public static object LastResult { get; internal set; }
        public static List<Profile> Profiles { get; set; }
        //internal static System.Collections.Generic.List<System.Windows.Automation.AutomationEventHandler> Events { get; set; }
        //internal static System.Collections.Generic.List<object> Events { get; set; }
public static List<object> Events { get; set; } // temporary ??
        
        internal static RecorderForm formRecorder { get; set; }
        
        // 20131109
        //public static AutomationElement LastEventSource { get; set; }
        public static IUiElement LastEventSource { get; set; }
        //internal static EventArgs LastEventArgs { get; set; }
        public static EventArgs LastEventArgs { get; set; }
        //internal static string LastEventType { get; set; }
        public static string LastEventType { get; set; }
        //internal static bool LastEventInfoAdded { get; set; }
        public static bool LastEventInfoAdded { get; set; }
        
        public static classic.CacheRequest CacheRequest = null;
        
        internal static void InitializeData()
        {
            // 20131202
            // Error = new ArrayList(Preferences.MaximumErrorCount);
            Error = new List<ErrorRecord>(Preferences.MaximumErrorCount);
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
                // 20140130
                // TODO:
                classic.Automation.RemoveAllEventHandlers();
                Events.Clear();
            }
            catch {
                
            }
            
            // 20140109
            // WizardCollection.ResetData();
            // ExecutionPlan.DisposeHighlighers();
            
            // 20140108
            //
//            try {
//                AutomationFactory.Reset();
//            }
//            catch {}
            //
        }
        
        public static void SetCurrentWindow(IUiElement window)
        {
            CurrentWindow = window ?? null;
        }

        internal static Profile GetProfile(string name)
        {
            return Profiles.FirstOrDefault(profile => name == profile.Name);
        }
    }
}
