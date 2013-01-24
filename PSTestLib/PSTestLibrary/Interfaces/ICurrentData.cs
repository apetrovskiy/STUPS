/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/1/2012
 * Time: 9:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PSTestLib
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ICurrentData.
    /// </summary>
    public interface ICurrentData
    {
        
    //}
    
        //public static AutomationElement CurrentWindow { get; internal set; }
        System.Collections.ArrayList Error { get; set; }
        //string LastCmdlet { get; internal set; }
        string LastCmdlet { get; }
        //object LastResult { get; internal set; }
        object LastResult { get; }
        //public static System.Collections.Generic.List<Profile> Profiles { get; set; }
        //internal static System.Collections.Generic.List<System.Windows.Automation.AutomationEventHandler> Events { get; set; }
        System.Collections.Generic.List<object> Events { get; set; }
        
        //internal static Commands.RecorderForm formRecorder { get; set; }
        
//        public static AutomationElement LastEventSource { get; set; }
//        //internal static EventArgs LastEventArgs { get; set; }
//        public static EventArgs LastEventArgs { get; set; }
//        //internal static string LastEventType { get; set; }
//        public static string LastEventType { get; set; }
//        //internal static bool LastEventInfoAdded { get; set; }
//        public static bool LastEventInfoAdded { get; set; }
        
//        public static CacheRequest CacheRequest = null;
        
        void ResetData();
//        {
//            CurrentWindow = null;
//            Error.Clear();
//            LastCmdlet = null;
//            LastResult = null;
//            
//            // Events
//            LastEventSource = null;
//            LastEventType = string.Empty;
//            LastEventArgs = null;
//            LastEventInfoAdded = false;
//        }
        
//        public static void SetCurrentWindow(AutomationElement window)
//        {
//            if (window is AutomationElement) {
//                CurrentData.CurrentWindow = window;
//            } else {
//                CurrentData.CurrentWindow = null;
//            }
//        }
        
//        internal static Profile GetProfile(string name)
//        {
//            Profile result = null;
//            foreach (Profile profile in CurrentData.Profiles) {
//                if (name == profile.Name) {
//                    result = profile;
//                    break;
//                }
//            }
//            
//            return result;
//        }
    }
}
