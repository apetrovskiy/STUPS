/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/1/2012
 * Time: 8:45 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PSTestLib
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ISettings.
    /// </summary>
    public interface ISettings
    {
        
        
#region commented
//        /// <summary>
//        /// The flag that initiates the Highlighter to run.
//        /// </summary>
//        public static bool Highlight { get; set; }
//        /// <summary>
//        /// Color of Highlighter
//        /// </summary>
//        public static System.Drawing.Color HighlighterColor { get; set; }
//        /// <summary>
//        /// Thikness of Highlighter's border.
//        /// </summary>
//        public static int HighlighterBorder { get; set; }
//        /// <summary>
//        /// The flag that initiates the Highlighter to run.
//        /// </summary>
//        public static bool HighlightParent { get; set; }
//        /// <summary>
//        /// Color of Highlighter
//        /// </summary>
//        public static System.Drawing.Color HighlighterColorParent { get; set; }
//        /// <summary>
//        /// Thikness of Highlighter's border.
//        /// </summary>
//        public static int HighlighterBorderParent { get; set; }
////        /// <summary>
////        /// The flag that initiates the Highlighter to run.
////        /// </summary>
////        public static bool HighlightFirstChild { get; set; }
////        /// <summary>
////        /// Color of Highlighter
////        /// </summary>
////        public static System.Drawing.Color HighlighterColorFirstChild { get; set; }
////        /// <summary>
////        /// Thikness of Highlighter's border.
////        /// </summary>
////        public static int HighlighterBorderFirstChild { get; set; }
#endregion commented
        
        /// <summary>
        /// The timeout in Get- and Wait- cmdlets that abrupts
        /// the Automation tree queries' flow.
        /// MIlliseconds
        /// </summary>
        int Timeout { get; set; }
//        { 
//            get {
//                return _timeout;
//            }
//            set { 
//                _timeout = value;
//                TimeoutSetByCustomer = true;
//                StoredDefaultTimeout = 0;
//            }
//        }
//        private static int _timeout;

//        /// <summary>
//        /// The timeout that is set automatically in the situation when
//        /// a Get- or -Wait- cmdlet failed to retrieve an object.
//        /// To prevent a series of useless queries to the Automation tree,
//        /// the shorter timeout is set until an object will be caught
//        /// by a cmdlet called further in code flow.
//        /// After an object is gotten, the timeout that was set by default will be used.
//        /// </summary>
//        public static int AfterFailTurboTimeout { get; set; }
        
        
        
//        internal static int StoredDefaultTimeout { get; set; }
//        //public static int StoredDefaultTimeout { get; set; }
        
        
//        internal static bool TimeoutSetByCustomer { get; set; }
        
//        public static bool DisableExactSearch { get; set; }
//        public static bool DisableWildCardSearch { get; set; }
//        public static bool DisableWin32Search { get; set; }
        
//        /// <summary>
//        /// The folder where screenshots are stored.
//        /// </summary>
//        public static string ScreenShotFolder { get; set; }
//        /// <summary>
//        /// this flag turns on automatic saving of screenshots 
//        /// if a terminating or non-terminating error has been raised.
//        /// </summary>
//        public static bool OnErrorScreenShot { get; set; }
//        /// <summary>
//        /// this flag says which format should  be used (by default, Jpeg)
//        /// </summary>
//        public static System.Drawing.Imaging.ImageFormat OnErrorScreenShotFormat { get; set; }
//        /// <summary>
//        /// this flag turns on automatic saving of screenshots 
//        /// if a terminating or non-terminating error has been raised.
//        /// </summary>
//        public static bool OnSuccessScreenShot { get; set; }
//        /// <summary>
//        /// this flag says which format should  be used (by default, Jpeg)
//        /// </summary>
//        public static System.Drawing.Imaging.ImageFormat OnSuccessScreenShotFormat { get; set; }
        
//        /// <summary>
//        /// This property defines an interval
//        /// the Start-UIARecorer cmdlet queries the element
//        /// beneath the cursor. Usually, the default value meets
//        /// better conditions. Exceptions may be needed in highly 
//        /// load environments.
//        /// Milliseconds
//        /// </summary>
//        public static int TranscriptInterval { get; set; }

        /// <summary>
        /// The time between the requested action is performed successfully 
        /// and outputting the loot to the pipeline.
        /// Milliseconds.
        /// </summary>
        int OnSuccessDelay { get; set; }
        /// <summary>
        /// Common action(s) that are being run before 
        /// OnSuccessDelay and outputting to the pipeline.
        /// </summary>
        ScriptBlock[] OnSuccessAction { get; set; }
        /// <summary>
        /// The time interval between a terminating error 
        /// is raised and returning the error to the pipeline.
        /// Milliseconds
        /// </summary>
        int OnErrorDelay { get; set; }
        /// <summary>
        /// Common action(s) that are being run before 
        /// OnErrorDelay and outputting the error to the pipeline.
        /// </summary>
        ScriptBlock[] OnErrorAction { get; set; }
        
//        /// <summary>
//        /// The time interval of a sleep between subsequent
//        /// queries of the Automation tree. Used in Get- and
//        /// Wait- cmdlets.
//        /// Milliseconds
//        /// </summary>
//        public static int OnSleepDelay { get; set; }
//        /// <summary>
//        /// Common action(s) that are used during the subsequent
//        /// queries to the Automation tree in the Get- cmdlets.
//        /// </summary>
//        public static ScriptBlock[] OnSleepAction { get; set; }
        
//        /// <summary>
//        /// The time interval between a Win32 click and
//        /// outputting the element clickedto the pipeline.
//        /// Milliseconds
//        /// </summary>
//        public static int OnClickDelay { get; set; }
        
        /// <summary>
        /// Logging flag
        /// </summary>
        bool Log { get; set; }
        /// <summary>
        /// Path to the log file
        /// </summary>
        string LogPath { get; set; }
        
        
//        private static int maximumErrorCount;
        /// <summary>
        /// The upper limit of number of errors that
        /// are stored in the Error collection.
        /// </summary>
        int MaximumErrorCount { get; set; }
//        {
//            get { return maximumErrorCount; } 
//            set{ maximumErrorCount = value; }
//        }
        
//        private static int maximumEventCount;
        
        int MaximumEventCount { get; set; }
//        {
//            get { return maximumEventCount; } 
//            set{ maximumEventCount = value; }
//        }
        
//        /// <summary>
//        /// This flag indicates whether a control should be taken from cache
//        /// or from search. Default behavior is from cache.
//        /// </summary>
//        public static bool FromCache { get; set; }
        
        
        // Test Case Management
        SwitchParameter EveryCmdletAsTestResult { get; set; }
        SwitchParameter FailTestResultIfFailInTestSequence { get; set; }
        
        
    }
}
