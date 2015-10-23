/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 29.11.2011
 * Time: 14:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;
    using System.Management.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    using System.Collections;

    /// <summary>
    /// Description of HasTimeoutCmdletBase.
    /// </summary>
    public class HasTimeoutCmdletBase : HasControlInputCmdletBase
    {
        #region Constructor
        public HasTimeoutCmdletBase()
        {
            Wait = true;
            Timeout = Preferences.Timeout;
            Seconds = Timeout / 1000;
            OnErrorScreenShot = Preferences.OnErrorScreenShot;
            OnSuccessAction = null;
            OnErrorAction = null;
        }
        #endregion Constructor

        #region Parameters
        [UiaParameter][Parameter(Mandatory = false)]
        internal SwitchParameter Wait { get; set; }
        
        [Alias("Milliseconds")]
        [UiaParameter][Parameter(Mandatory = false)]
        public int Timeout { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false)]
        public int Seconds {
            get { return Timeout / 1000; }
            set{ Timeout = value * 1000; }
        }
        
        [UiaParameter][Parameter(Mandatory = false)]
        public SwitchParameter IsCritical { get; set; }
        #endregion Parameters
        
        // 20130529
        /// <summary>
        /// This variable is used in 'negative result' cmdlets like Wait-UiaNoWindow
        /// </summary>
        protected internal bool WaitNoWindow { get; set; }
        
        protected override void StopProcessing()
        {
            WriteVerbose(this, "User interrupted");
            Wait = false;
        }
        
        private void CheckTimeout(GetWindowCmdletBase cmdlet,
                                  ICollection aeWindowList,
                                  bool fromCmdlet)
        {
            cmdlet.WriteVerbose(cmdlet, "OnSleep scriptblocks");
            SleepAndRunScriptBlocks(this);
            DateTime nowDate = DateTime.Now;
            WriteVerbose(this, "process: " +
                         cmdlet.ProcessName +
                         ", name: " +
                         cmdlet.Name +
                         ", seconds: " + (nowDate - StartDate).TotalSeconds);
            try {
                if ((null == aeWindowList || aeWindowList.Count <= 0) &&
                    !((nowDate - StartDate).TotalSeconds > Timeout/1000)) return;
                if (null == aeWindowList) {
                    Wait = false;
                    var eReturn =
                    // Exception eReturn =
                        new Exception(
                            CmdletName(this) + ": timeout expired for process: " +
                            cmdlet.ProcessName + ", title: " + cmdlet.Name);
                    throw(eReturn);
                } // else{ // OK
                // }
                    
                Wait &= cmdlet.WaitNoWindow;
                /*
                if (!cmdlet.WaitNoWindow) {
                    Wait = false;
                }
                */
                // break;
                
            } catch (Exception eEvaluatingWindowOrMeasuringTimeout) {
                WriteDebug(this, "exception: " +
                           eEvaluatingWindowOrMeasuringTimeout.Message);
                
                cmdlet.WriteError(
                    cmdlet,
                    "An error raised during checking the timeout. " +
                    eEvaluatingWindowOrMeasuringTimeout.Message,
                    "CheckingTimeout",
                    ErrorCategory.InvalidOperation,
                    true);
            }
        }
    }
}
