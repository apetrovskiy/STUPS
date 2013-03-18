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
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of WaitCmdletBase.
    /// </summary>
    public class WaitCmdletBase : HasTimeoutCmdletBase
    {
        #region Constructor
        public WaitCmdletBase()
        {
            // duplicated !!!
            InputObject = null;
        }
        #endregion Constructor

        #region Parameters
        #endregion Parameters
        
        protected void WaitIfCondition(
            AutomationElement _control,
            bool isEnabledOrIsVisible)
        {
            // 20120824
            //_control = this.InputObject;
            _control = this.InputObject[0];
            
            
            // 20120620
            //this.Wait = !(_control.Current).IsEnabled;
            if (isEnabledOrIsVisible) {
                this.Wait = !(_control.Current).IsEnabled;
            } else {
                this.Wait = (_control.Current).IsOffscreen;
            }
            do
            {
                // RunOnRefreshScriptBlocks(this);
                // System.Threading.Thread.Sleep(Preferences.SleepInterval);
                SleepAndRunScriptBlocks(this);
                // if (
                System.DateTime nowDate = System.DateTime.Now;
                try {
                    string tempIsReport = string.Empty;
                    if (isEnabledOrIsVisible) {
                        tempIsReport = _control.Current.IsEnabled.ToString();
                    } else {
                        tempIsReport = _control.Current.IsOffscreen.ToString();
                    }
                    WriteVerbose(this,
                                 "AutomationID: " + 
                                 _control.Current.AutomationId +
                                 ", title: " + 
                                 _control.Current.Name + 
                                 ", Enabled = " + 
                                 //_control.Current.IsEnabled.ToString() +
                                 tempIsReport +
                                 ", seconds: " + 
                                 ((nowDate - StartDate).TotalSeconds).ToString());
                } catch { }
                if (!this.CheckControl(this))
                {
                    WriteObject(this, false);
                    
                    // 20121001
                    //UIAHelper.GetScreenshotOfAutomationElement(this, CmdletName(this) + "_NoControl", true, 0, 0, 0, 0, string.Empty, System.Drawing.Imaging.ImageFormat.Jpeg);
                    this.WriteError(
                        this,
                        "An unknown error while checking the control.",
                        "CheckingControl",
                        ErrorCategory.InvalidResult,
                        true);
                    
                    return;
                }
                // 20120620
                //this.Wait = !(_control.Current).IsEnabled;
                if (isEnabledOrIsVisible) {
                    this.Wait = !(_control.Current).IsEnabled;
                } else {
                    this.Wait = (_control.Current).IsOffscreen;
                }
                if ((nowDate - StartDate).TotalSeconds > this.Timeout / 1000)
                {
                    WriteVerbose(this, "timeout expired for AutomationId: " + 
                                 _control.Current.AutomationId +
                                ", title: " +
                                 _control.Current.Name);
                    
                    // 20120927
//                    UIAHelper.GetScreenshotOfAutomationElement(this, CmdletName(this) + "_Timeout", true, 0, 0, 0, 0, string.Empty, System.Drawing.Imaging.ImageFormat.Jpeg);
//                    WriteError(this, new ErrorRecord(new Exception(),
//                                               CmdletName(this) + ": timeout expired for AutomationId: " + 
//                                               _control.Current.AutomationId +
//                                               ", title: " +
//                                               _control.Current.Name,
//                                               ErrorCategory.OperationTimeout,
//                                               _control), true);
                    
                    this.WriteError(
                        this,
                        CmdletName(this) + ": timeout expired for AutomationId: " + 
                        _control.Current.AutomationId +
                        ", title: " +
                        _control.Current.Name,
                        "TimeoutExpired",
                        ErrorCategory.OperationTimeout,
                        true);
                }
                if (_control == null) {
                    WriteVerbose(this, "the control is unavailable");
                    
                    // 20120927
//                    UIAHelper.GetScreenshotOfAutomationElement(this, CmdletName(this) + "_ControlEqNull", true, 0, 0, 0, 0, string.Empty, System.Drawing.Imaging.ImageFormat.Jpeg);
//                    WriteError(this, new ErrorRecord(new Exception(),
//                                               CmdletName(this) + ": control is unavailable. AutomationId: " + 
//                                               _control.Current.AutomationId +
//                                               ", title: " +
//                                               _control.Current.Name,
//                                               ErrorCategory.OperationTimeout,
//                                               _control), true);
                    
                    this.WriteError(
                        this,
                        CmdletName(this) + ": control is unavailable. AutomationId: " + 
                        _control.Current.AutomationId +
                        ", title: " +
                        _control.Current.Name,
                        "TimeoutExpired",
                        ErrorCategory.OperationTimeout,
                        true);
                }
            } while (this.Wait);
        }
    }
}
