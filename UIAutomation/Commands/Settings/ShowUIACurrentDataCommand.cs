/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/1/2012
 * Time: 8:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ShowUIACurrentDataCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Show, "UIACurrentData")]
    public class ShowUIACurrentDataCommand : CommonCmdletBase
    {
        public ShowUIACurrentDataCommand()
        {
        }
        
        protected sealed override void BeginProcessing()
        {
            //WriteObject("\r\nCu settings:");
            try {
            WriteObject(
                    "[UIAutomation.CurrentData]::CurrentWindow.Current.Name = " +
                    CurrentData.CurrentWindow.Current.Name);
            }
            catch {}
            WriteObject("[UIAutomation.CurrentData]::Error = " + 
                        CurrentData.Error);
            
            //WriteObject("\r\nWork with window ans controls settings:");
            
            WriteObject("[UIAutomation.CurrentData]::Events = " + 
                        CurrentData.Events);
            
            WriteObject("[UIAutomation.CurrentData]::LastCmdlet = " + 
                        CurrentData.LastCmdlet);
            
            WriteObject("[UIAutomation.CurrentData]::LastEventArgs = " + 
                        CurrentData.LastEventArgs);
            
            //WriteObject("\r\nError collection settings:");
            WriteObject("[UIAutomation.CurrentData]::LastEventInfoAdded = " + 
                        CurrentData.LastEventInfoAdded);
            
            //WriteObject("\r\nCommon actions:");
            WriteObject("[UIAutomation.CurrentData]::LastEventSource = " + 
                        CurrentData.LastEventSource);
            WriteObject("[UIAutomation.CurrentData]::LastEventType = " + 
                        CurrentData.LastEventType);
            WriteObject("[UIAutomation.CurrentData]::LastResult = " + 
                        CurrentData.LastResult);
            
            //WriteObject("\r\nScreenshot settings:");
            WriteObject("[UIAutomation.CurrentData]::Profiles = " +
                        CurrentData.Profiles);
//            WriteObject("[UIAutomation.CurrentData]::OnErrorScreenShotFormat = '" +
//                        CurrentData.OnErrorScreenShotFormat.ToString()) + "'";
//            WriteObject("[UIAutomation.CurrentData]::OnSuccessScreenShot = $" +
//                        CurrentData.OnSuccessScreenShot.ToString());
//            WriteObject("[UIAutomation.CurrentData]::OnSuccessScreenShotFormat = '" +
//                        CurrentData.OnSuccessScreenShotFormat.ToString()) + "'";
//            WriteObject("[UIAutomation.CurrentData]::ScreenShotFolder = " + 
//                        CurrentData.ScreenShotFolder);
//            
//            WriteObject("\r\nLog settings:");
//            WriteObject("[UIAutomation.CurrentData]::Log = $" + 
//                        CurrentData.Log.ToString());
//            WriteObject("[UIAutomation.CurrentData]::LogPath = " + 
//                        CurrentData.LogPath);
//            
//            WriteObject("\r\nDebugging delays:");
//            WriteObject("[UIAutomation.CurrentData]::OnClickDelay = " + 
//                        CurrentData.OnClickDelay.ToString());
//            WriteObject("[UIAutomation.CurrentData]::OnErrorDelay = " + 
//                        CurrentData.OnErrorDelay.ToString());
//            WriteObject("[UIAutomation.CurrentData]::OnSleepDelay = " + 
//                        CurrentData.OnSleepDelay.ToString());
//            WriteObject("[UIAutomation.CurrentData]::OnSuccessDelay = " + 
//                        CurrentData.OnSuccessDelay.ToString());
//            
//            WriteObject("\r\nTranscript settings");
//            WriteObject("[UIAutomation.CurrentData]::TranscriptInterval = " + 
//                        CurrentData.TranscriptInterval.ToString());
//            
//            WriteObject("\r\nHighlighter settings:");
//            WriteObject("[UIAutomation.CurrentData]::Highlight = $" + 
//                        CurrentData.Highlight.ToString());
//            WriteObject("[UIAutomation.CurrentData]::HighlighterBorder = " + 
//                        CurrentData.HighlighterBorder.ToString());
//            WriteObject("[UIAutomation.CurrentData]::HighlighterColor = " + 
//                        CurrentData.HighlighterColor.ToString());
//            WriteObject("[UIAutomation.CurrentData]::HighlightParent = $" + 
//                        CurrentData.HighlightParent.ToString());
//            WriteObject("[UIAutomation.CurrentData]::HighlighterBorderParent = " + 
//                        CurrentData.HighlighterBorderParent.ToString());
//            WriteObject("[UIAutomation.CurrentData]::HighlighterColorParent = " + 
//                        CurrentData.HighlighterColorParent.ToString());
        }
    }
}
