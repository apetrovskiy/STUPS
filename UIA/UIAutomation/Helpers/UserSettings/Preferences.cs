/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 03.12.2011
 * Time: 16:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of Preferences.
    /// </summary>
    public static class Preferences
    {
        static Preferences()
        {
            Highlight = true;
            HighlighterColor = System.Drawing.Color.Red;
            HighlighterBorder = 3;
            
            HighlightParent = true;
            HighlighterColorParent = System.Drawing.Color.HotPink;
            HighlighterBorderParent = 5;
            
//            HighlightFirstChild = false; //true;
//            HighlighterColorFirstChild = System.Drawing.Color.Yellow;
//            HighlighterBorderFirstChild = 3;
            
            // 20130423
            HighlightCheckedControl = true;
            HighlighterColorCheckedControl = System.Drawing.Color.Blue;
            HighlighterBorderCheckedControl = 3;
            
			ShowExecutionPlan = false;
			ShowInfoToolTip = true;
            
            Timeout = 5000;
            AfterFailTurboTimeout = 2000;
            // 20120828
            TimeoutSetByCustomer = false;
            
            DisableExactSearch = true;
            DisableWildCardSearch = false;
            DisableWin32Search = false;
            
            ScreenShotFolder = 
                System.Environment.GetEnvironmentVariable(
                    "TEMP",
                    EnvironmentVariableTarget.User);
            //OnErrorScreenShot = false;
            OnErrorScreenShot = true; // 20120819
            OnErrorScreenShotFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
            OnSuccessScreenShot = false;
            OnSuccessScreenShotFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
            HideHighlighterOnScreenShotTaking = true;

            TranscriptInterval = 200;
            OnSuccessDelay = 500;
            OnSuccessAction = null;
            OnErrorDelay = 500;
            OnErrorAction = null;
            //OnSleepDelay = 1000;
            OnSleepDelay = 500;
            OnSleepAction = null;
            OnClickDelay = 0;
            Log = true;
            LogPath = 
                System.Environment.GetEnvironmentVariable(
                    "TEMP",
                    EnvironmentVariableTarget.User) + 
                @"\UIAutomation.log";
            // 20130430
            AutoLog = false;
            MaximumErrorCount = 256;
            MaximumEventCount = 256;
            Mode.Profile = Modes.Presentation;
            
            // CacheRequest
            //FromCache = true;
            FromCache = false;
            
            // Test Case Management
            EveryCmdletAsTestResult = false;
            FailTestResultIfFailInTestSequence = true;
            
            ClickOnControlByCoordX = 5; //3;
            ClickOnControlByCoordY = 5; //3;
            
            // 20130105
            PerformWin32ClickOnFail = true;
            
            // 20130320
            // Wizard
            OnSelectWizardStepDelay = 100;
            
            // 20130322
            BannerLeft = 100;
            BannerTop = 100;
            BannerWidth = 600;
            BannerHeight = 100; //80;
            // 20130327
            BannerFontSize = 20;
        }
        
        /// <summary>
        /// The flag that initiates the Highlighter to run.
        /// </summary>
        public static bool Highlight { get; set; }
        /// <summary>
        /// Color of Highlighter
        /// </summary>
        public static System.Drawing.Color HighlighterColor { get; set; }
        /// <summary>
        /// Thikness of Highlighter's border.
        /// </summary>
        public static int HighlighterBorder { get; set; }
        /// <summary>
        /// The flag that initiates the Highlighter to run.
        /// </summary>
        public static bool HighlightParent { get; set; }
        /// <summary>
        /// Color of Highlighter
        /// </summary>
        public static System.Drawing.Color HighlighterColorParent { get; set; }
        /// <summary>
        /// Thikness of Highlighter's border.
        /// </summary>
        public static int HighlighterBorderParent { get; set; }
//        /// <summary>
//        /// The flag that initiates the Highlighter to run.
//        /// </summary>
//        public static bool HighlightFirstChild { get; set; }
//        /// <summary>
//        /// Color of Highlighter
//        /// </summary>
//        public static System.Drawing.Color HighlighterColorFirstChild { get; set; }
//        /// <summary>
//        /// Thikness of Highlighter's border.
//        /// </summary>
//        public static int HighlighterBorderFirstChild { get; set; }
        // 20130423
        /// <summary>
        /// The flag that initiates the Highlighter to run.
        /// </summary>
        public static bool HighlightCheckedControl { get; set; }
        /// <summary>
        /// Color of Highlighter
        /// </summary>
        public static System.Drawing.Color HighlighterColorCheckedControl { get; set; }
        /// <summary>
        /// Thikness of Highlighter's border.
        /// </summary>
        public static int HighlighterBorderCheckedControl { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public static bool ShowExecutionPlan { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public static bool ShowInfoToolTip { get; set; }
        
        /// <summary>
        /// The timeout in Get- and Wait- cmdlets that abrupts
        /// the Automation tree queries' flow.
        /// MIlliseconds
        /// </summary>
        public static int Timeout
        { 
            get {
                return _timeout;
            }
            set { 
                _timeout = value;
                TimeoutSetByCustomer = true;
                StoredDefaultTimeout = 0;
            }
        }
        private static int _timeout;
        /// <summary>
        /// The timeout that is set automatically in the situation when
        /// a Get- or -Wait- cmdlet failed to retrieve an object.
        /// To prevent a series of useless queries to the Automation tree,
        /// the shorter timeout is set until an object will be caught
        /// by a cmdlet called further in code flow.
        /// After an object is gotten, the timeout that was set by default will be used.
        /// </summary>
        public static int AfterFailTurboTimeout { get; set; }
        
        
        
        internal static int StoredDefaultTimeout { get; set; }
        //public static int StoredDefaultTimeout { get; set; }
        
        
        internal static bool TimeoutSetByCustomer { get; set; }
        
        public static bool DisableExactSearch { get; set; }
        public static bool DisableWildCardSearch { get; set; }
        public static bool DisableWin32Search { get; set; }
        
        /// <summary>
        /// The folder where screenshots are stored.
        /// </summary>
        public static string ScreenShotFolder { get; set; }
        /// <summary>
        /// this flag turns on automatic saving of screenshots 
        /// if a terminating or non-terminating error has been raised.
        /// </summary>
        public static bool OnErrorScreenShot { get; set; }
        /// <summary>
        /// this flag says which format should  be used (by default, Jpeg)
        /// </summary>
        public static System.Drawing.Imaging.ImageFormat OnErrorScreenShotFormat { get; set; }
        /// <summary>
        /// this flag turns on automatic saving of screenshots 
        /// if a terminating or non-terminating error has been raised.
        /// </summary>
        public static bool OnSuccessScreenShot { get; set; }
        /// <summary>
        /// this flag says which format should  be used (by default, Jpeg)
        /// </summary>
        public static System.Drawing.Imaging.ImageFormat OnSuccessScreenShotFormat { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public static bool HideHighlighterOnScreenShotTaking { get; set; }
        
        /// <summary>
        /// This property defines an interval
        /// the Start-UIARecorer cmdlet queries the element
        /// beneath the cursor. Usually, the default value meets
        /// better conditions. Exceptions may be needed in highly 
        /// load environments.
        /// Milliseconds
        /// </summary>
        public static int TranscriptInterval { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public static ScriptBlock[] OnTranscriptIntervalAction { get; set; }
        /// <summary>
        /// The time between the requested action is performed successfully 
        /// and outputting the loot to the pipeline.
        /// Milliseconds.
        /// </summary>
        public static int OnSuccessDelay { get; set; }
        /// <summary>
        /// Common action(s) that are being run before 
        /// OnSuccessDelay and outputting to the pipeline.
        /// </summary>
        public static ScriptBlock[] OnSuccessAction { get; set; }
        /// <summary>
        /// The time interval between a terminating error 
        /// is raised and returning the error to the pipeline.
        /// Milliseconds
        /// </summary>
        public static int OnErrorDelay { get; set; }
        /// <summary>
        /// Common action(s) that are being run before 
        /// OnErrorDelay and outputting the error to the pipeline.
        /// </summary>
        public static ScriptBlock[] OnErrorAction { get; set; }
        /// <summary>
        /// The time interval of a sleep between subsequent
        /// queries of the Automation tree. Used in Get- and
        /// Wait- cmdlets.
        /// Milliseconds
        /// </summary>
        public static int OnSleepDelay { get; set; }
        /// <summary>
        /// Common action(s) that are used during the subsequent
        /// queries to the Automation tree in the Get- cmdlets.
        /// </summary>
        public static ScriptBlock[] OnSleepAction { get; set; }
        /// <summary>
        /// The time interval between a Win32 click and
        /// outputting the element clickedto the pipeline.
        /// Milliseconds
        /// </summary>
        public static int OnClickDelay { get; set; }
        /// <summary>
        /// Logging flag
        /// </summary>
        public static bool Log { get; set; }
        /// <summary>
        /// Path to the log file
        /// </summary>
        public static string LogPath { get; set; }
        
        // 20130429
        public static bool AutoLog { get; set; }
        
        private static int maximumErrorCount;
        /// <summary>
        /// The upper limit of number of errors that
        /// are stored in the Error collection.
        /// </summary>
        public static int MaximumErrorCount
        {
            get { return maximumErrorCount; } 
            set{ maximumErrorCount = value; }
        }
        
        private static int maximumEventCount;
        
        public static int MaximumEventCount
        {
            get { return maximumEventCount; } 
            set{ maximumEventCount = value; }
        }
        
        /// <summary>
        /// This flag indicates whether a control should be taken from cache
        /// or from search. Default behavior is from cache.
        /// </summary>
        public static bool FromCache { get; set; }
        
        
        // Test Case Management
        public static SwitchParameter EveryCmdletAsTestResult { get; set; }
        public static SwitchParameter FailTestResultIfFailInTestSequence { get; set; }
        
        
        public static int ClickOnControlByCoordX { get; set; }
        public static int ClickOnControlByCoordY { get; set; }
        
        // 20130105
        public static bool PerformWin32ClickOnFail { get; set; }
        
        // 20130320
        // Wizard
        public static int OnSelectWizardStepDelay { get; set; }
        
        // 20130322
        public static int BannerLeft { get; set; }
        public static int BannerTop { get; set; }
        public static int BannerWidth { get; set; }
        public static int BannerHeight { get; set; }
        // 201130327
        public static int BannerFontSize { get; set; }
    }
    
    public static class Mode
    {
        static Mode()
        {
            Profile = Modes.Presentation;
            Preferences.TimeoutSetByCustomer = false;
        }
        
        private static Modes mode;
        public static Modes Profile
        {
            get { return mode; }
            set
            {
                mode = value;
                switch (value) {
                    case UIAutomation.Modes.Normal:
                        Preferences.OnSuccessDelay = 0;
                        Preferences.OnErrorDelay = 0;
                        Preferences.OnSleepDelay = 100; // this did not work
                        Preferences.Highlight = false;
                        Preferences.HideHighlighterOnScreenShotTaking = true;
                        Preferences.Timeout = 5000;
                        Preferences.TimeoutSetByCustomer = true;
                        Preferences.AfterFailTurboTimeout = 2000;
                        Preferences.EveryCmdletAsTestResult = false;
                        Preferences.FailTestResultIfFailInTestSequence = true;
                        break;
                    case UIAutomation.Modes.Debug:
                        Preferences.OnSuccessDelay = 1000;
                        Preferences.OnErrorDelay = 2000; // there was 5000
                        Preferences.OnSleepDelay = 1000; // ??
                        Preferences.Highlight = true;
                        Preferences.HideHighlighterOnScreenShotTaking = false;
                        Preferences.Timeout = 10000; // there was 30000
                        Preferences.TimeoutSetByCustomer = true;
                        Preferences.AfterFailTurboTimeout = 2000;
                        Preferences.EveryCmdletAsTestResult = false;
                        Preferences.FailTestResultIfFailInTestSequence = true;
                        break;
                    case UIAutomation.Modes.Presentation:
                        Preferences.OnSuccessDelay = 0; // there was 500;
                        Preferences.OnErrorDelay = 0; // there was 500;
                        Preferences.OnSleepDelay = 200; // this did not work
                        Preferences.Highlight = true;
                        Preferences.HideHighlighterOnScreenShotTaking = true;
                        Preferences.Timeout = 5000;
                        Preferences.TimeoutSetByCustomer = true;
                        Preferences.AfterFailTurboTimeout = 2000;
                        Preferences.EveryCmdletAsTestResult = true;
                        Preferences.FailTestResultIfFailInTestSequence = false;
                        break;
                    case UIAutomation.Modes.AutomaticTestResults:
                        Preferences.OnSuccessDelay = 0;
                        Preferences.OnErrorDelay = 0;
                        Preferences.OnSleepDelay = 100; // this did not work
                        Preferences.Highlight = false;
                        Preferences.HideHighlighterOnScreenShotTaking = true;
                        Preferences.Timeout = 5000;
                        Preferences.TimeoutSetByCustomer = true;
                        Preferences.AfterFailTurboTimeout = 2000;
                        Preferences.EveryCmdletAsTestResult = true;
                        Preferences.FailTestResultIfFailInTestSequence = false;
                        break;
                    case UIAutomation.Modes.UserDrivenTestResults:
                        Preferences.OnSuccessDelay = 0;
                        Preferences.OnErrorDelay = 0;
                        Preferences.OnSleepDelay = 100; // this did not work
                        Preferences.Highlight = false;
                        Preferences.HideHighlighterOnScreenShotTaking = true;
                        Preferences.Timeout = 5000;
                        Preferences.TimeoutSetByCustomer = true;
                        Preferences.AfterFailTurboTimeout = 2000;
                        Preferences.EveryCmdletAsTestResult = false;
                        Preferences.FailTestResultIfFailInTestSequence = true;
                        break;
                    default:
                        throw new Exception("Invalid value for Modes"); // case Modes.Normal:
                }
            }
        }
    }
    
    public enum Modes
    {
        Normal,
        Debug,
        Presentation,
        AutomaticTestResults,
        UserDrivenTestResults
        //,
        // Custom = 3 // several custom modes?
    }
}
