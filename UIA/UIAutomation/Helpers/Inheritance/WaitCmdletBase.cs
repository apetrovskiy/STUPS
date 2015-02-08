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
    using System.Linq;
    
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
        
        protected internal void WaitIfCondition(
            IUiElement _control,
            bool isEnabledOrIsVisible)
        {
            _control = InputObject.Cast<IUiElement>().ToArray()[0];
            
            // 20140312
//            if (isEnabledOrIsVisible) {
//                Wait = !(_control.Current).IsEnabled;
//            } else {
//                Wait = (_control.Current).IsOffscreen;
//            }
            Wait = isEnabledOrIsVisible ? !(_control.GetCurrent()).IsEnabled : (_control.GetCurrent()).IsOffscreen;
            do
            {
                SleepAndRunScriptBlocks(this);
                
                DateTime nowDate = DateTime.Now;
                try {
                    string tempIsReport = string.Empty;
                    // 20140312
                    // tempIsReport = isEnabledOrIsVisible ? _control.Current.IsEnabled.ToString() : _control.Current.IsOffscreen.ToString();
                    tempIsReport = isEnabledOrIsVisible ? _control.GetCurrent().IsEnabled.ToString() : _control.GetCurrent().IsOffscreen.ToString();
                    
                } catch { }
                if (!CheckAndPrepareInput(this))
                {
                    WriteObject(this, false);
                    
                    WriteError(
                        this,
                        "An unknown error while checking the control.",
                        "CheckingControl",
                        ErrorCategory.InvalidResult,
                        true);
                    
                    return;
                }
                
                // 20140312
//                if (isEnabledOrIsVisible) {
//                    Wait = !(_control.Current).IsEnabled;
//                } else {
//                    Wait = (_control.Current).IsOffscreen;
//                }
                Wait = isEnabledOrIsVisible ? !(_control.GetCurrent()).IsEnabled : (_control.GetCurrent()).IsOffscreen;
                if ((nowDate - StartDate).TotalSeconds > Timeout / 1000)
                {
                    // 20140312
//                    WriteVerbose(this, "timeout expired for AutomationId: " + 
//                                 _control.Current.AutomationId +
//                                ", title: " +
//                                 _control.Current.Name);
                    // 20140312
//                    WriteError(
//                        this,
//                        CmdletName(this) + ": timeout expired for AutomationId: " + 
//                        _control.Current.AutomationId +
//                        ", title: " +
//                        _control.Current.Name,
//                        "TimeoutExpired",
//                        ErrorCategory.OperationTimeout,
//                        true);
                    WriteError(
                        this,
                        CmdletName(this) + ": timeout expired for AutomationId: " + 
                        _control.GetCurrent().AutomationId +
                        ", title: " +
                        _control.GetCurrent().Name,
                        "TimeoutExpired",
                        ErrorCategory.OperationTimeout,
                        true);
                }
                if (_control != null) continue;
                
            } while (Wait);
        }
    }
}
