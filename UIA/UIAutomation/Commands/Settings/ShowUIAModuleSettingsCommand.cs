/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/13/2012
 * Time: 12:01 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ShowUIAModuleSettingsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Show, "UIAModuleSettings")]
    public class ShowUIAModuleSettingsCommand : CommonCmdletBase
    {
        public ShowUIAModuleSettingsCommand()
        {
        }
        
        #region Show-UIAModuleSettings
        //protected override void BeginProcessing()
        protected sealed override void BeginProcessing()
        {
            WriteObject("\r\nTimeout settings:");
            WriteObject("[UIAutomation.Preferences]::Timeout = " + 
                        Preferences.Timeout.ToString());
            WriteObject("[UIAutomation.Preferences]::AfterFailTurboTimeout = " + 
                        Preferences.AfterFailTurboTimeout.ToString());
            
            WriteObject("\r\nWork with window ans controls settings:");
            WriteObject("[UIAutomation.Preferences]::DisableExactSearch = $" + 
                        Preferences.DisableExactSearch.ToString());
            WriteObject("[UIAutomation.Preferences]::DisableWildCardSearch = $" + 
                        Preferences.DisableWildCardSearch.ToString());
            WriteObject("[UIAutomation.Preferences]::DisableWin32Search = $" + 
                        Preferences.DisableWin32Search.ToString());
            
            WriteObject("\r\nError collection settings:");
            WriteObject("[UIAutomation.Preferences]::MaximumErrorCount = " + 
                        Preferences.MaximumErrorCount.ToString());
            
            WriteObject("\r\nCommon actions:");
            WriteObject("[UIAutomation.Preferences]::OnErrorAction = " + 
                        Preferences.OnErrorAction);
            WriteObject("[UIAutomation.Preferences]::OnSleepAction = " + 
                        Preferences.OnSleepAction);
            WriteObject("[UIAutomation.Preferences]::OnSuccessAction = " + 
                        Preferences.OnSuccessAction);
            
            WriteObject("\r\nScreenshot settings:");
            WriteObject("[UIAutomation.Preferences]::OnErrorScreenShot = $" +
                        Preferences.OnErrorScreenShot.ToString());
            WriteObject("[UIAutomation.Preferences]::OnErrorScreenShotFormat = '" +
                        Preferences.OnErrorScreenShotFormat.ToString() + "'");
            WriteObject("[UIAutomation.Preferences]::OnSuccessScreenShot = $" +
                        Preferences.OnSuccessScreenShot.ToString());
            WriteObject("[UIAutomation.Preferences]::OnSuccessScreenShotFormat = '" +
                        Preferences.OnSuccessScreenShotFormat.ToString() + "'");
            WriteObject("[UIAutomation.Preferences]::ScreenShotFolder = " + 
                        Preferences.ScreenShotFolder);
            
            WriteObject("\r\nLog settings:");
            WriteObject("[UIAutomation.Preferences]::Log = $" + 
                        Preferences.Log.ToString());
            WriteObject("[UIAutomation.Preferences]::LogPath = " + 
                        Preferences.LogPath);
            
            WriteObject("\r\nDebugging delays:");
            WriteObject("[UIAutomation.Preferences]::OnClickDelay = " + 
                        Preferences.OnClickDelay.ToString());
            WriteObject("[UIAutomation.Preferences]::OnErrorDelay = " + 
                        Preferences.OnErrorDelay.ToString());
            WriteObject("[UIAutomation.Preferences]::OnSleepDelay = " + 
                        Preferences.OnSleepDelay.ToString());
            WriteObject("[UIAutomation.Preferences]::OnSuccessDelay = " + 
                        Preferences.OnSuccessDelay.ToString());
            
            WriteObject("\r\nTranscript settings");
            WriteObject("[UIAutomation.Preferences]::TranscriptInterval = " + 
                        Preferences.TranscriptInterval.ToString());
            
            WriteObject("\r\nHighlighter settings:");
            WriteObject("[UIAutomation.Preferences]::Highlight = $" + 
                        Preferences.Highlight.ToString());
            WriteObject("[UIAutomation.Preferences]::HighlighterBorder = " + 
                        Preferences.HighlighterBorder.ToString());
            WriteObject("[UIAutomation.Preferences]::HighlighterColor = " + 
                        Preferences.HighlighterColor.ToString());
            WriteObject("[UIAutomation.Preferences]::HighlightParent = $" + 
                        Preferences.HighlightParent.ToString());
            WriteObject("[UIAutomation.Preferences]::HighlighterBorderParent = " + 
                        Preferences.HighlighterBorderParent.ToString());
            WriteObject("[UIAutomation.Preferences]::HighlighterColorParent = " + 
                        Preferences.HighlighterColorParent.ToString());
            // 20130423
            WriteObject("[UIAutomation.Preferences]::HighlightCheckedControl = $" + 
                        Preferences.HighlightCheckedControl.ToString());
            WriteObject("[UIAutomation.Preferences]::HighlighterBorderCheckedControl = " + 
                        Preferences.HighlighterBorderCheckedControl.ToString());
            WriteObject("[UIAutomation.Preferences]::HighlighterColorCheckedControl = " + 
                        Preferences.HighlighterColorCheckedControl.ToString());
        }
        #endregion Show-UIAModuleSettings
    }
}
