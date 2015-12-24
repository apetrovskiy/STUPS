/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 15/02/2012
 * Time: 07:56 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows;

namespace UIAutomation.Commands
{
    /// <summary>
    /// Interaction logic for RecorderFrom.xaml
    /// </summary>
    public partial class RecorderFrom : Window
    {
        public RecorderFrom(TranscriptCmdletBase cmdlet)
        {
            Cmdlet = cmdlet;
            
            InitializeComponent();
        }
        
        internal TranscriptCmdletBase Cmdlet { get; set; }
        delegate void StartRecordingDelegate(TranscriptCmdletBase cmdlet);
        private void StartRecordingMethod(TranscriptCmdletBase cmdlet)
        {
            // UiaHelper.ProcessingTranscript(cmdlet);
            Global.GTranscript = true;
            int counter = 0;
            cmdlet.OddRootElement =
                // 20131109
                //System.Windows.Automation.AutomationElement.RootElement;
                UiElement.RootElement;
            cmdlet.StartDate =
                DateTime.Now;
            do{
                //Application.DoEvents();
                // 20131107
                counter++;
                //
                bool res =
                    // 20131114
                    //UiaHelper.ProcessingTranscriptOnce(cmdlet, counter);
                    UiaHelper.ProcessingTranscriptOnce(cmdlet, counter, System.Windows.Forms.Cursor.Position);
                if (!res) break;
            } while (Global.GTranscript);
            
        }
        delegate void PauseRecordingDelegate(TranscriptCmdletBase cmdlet);
        private void PauseRecordingMethod(TranscriptCmdletBase cmdlet)
        {
            Cmdlet.Paused = true;
            //System.Windows.Forms.MessageBox.Show("Paused!");
        }
        delegate void StopRecordingDelegate(TranscriptCmdletBase cmdlet);
        private void StopRecordingMethod(TranscriptCmdletBase cmdlet)
        {
            Global.GTranscript = false;
            //System.Windows.Forms.MessageBox.Show("Stopped!");
            Cmdlet.StopProcessing();
        }
        
        void BtnStartClick(object sender, EventArgs e)
        {
            btnStart.IsEnabled = false;
            btnPause.IsEnabled = true;
            btnStop.IsEnabled = true;
            
            
            //// this.Cmdlet.NoUI = true;
            //// UiaHelper.ProcessingTranscript(this.Cmdlet)
            if (!Cmdlet.Paused) {
                ////StartRecordingDelegate startRec = new RecorderFrom.StartRecordingDelegate(StartRecordingMethod);
                ////this.Invoke(startRec, this.Cmdlet);
                ////RecorderFrom.StartRecordingDelegate(StartRecordingMethod);
            }
            Cmdlet.Paused = false;
        }
        
        void BtnPauseClick(object sender, EventArgs e)
        {
            btnPause.IsEnabled = false;
            btnStart.IsEnabled = true;
            btnStop.IsEnabled = true;
            
            Cmdlet.Paused = true;
            //// System.Windows.Forms.MessageBox.Show("Paused!");
            ////PauseRecordingDelegate pauseRec = new RecorderFrom.PauseRecordingDelegate(PauseRecordingMethod);
            ////this.in.Invoke(pauseRec, this.Cmdlet);
            ////RecorderFrom.PauseRecordingDelegate(PauseRecordingMethod);
        }
        
        void BtnStopClick(object sender, EventArgs e)
        {
            btnStop.IsEnabled = false;
            btnStart.IsEnabled = true;
            btnPause.IsEnabled = false;
            
            StopRecordingDelegate stopRec = new StopRecordingDelegate(StopRecordingMethod);
            ////this.Invoke(stopRec, this.Cmdlet);
            //// this.Cmdlet.Paused = true;
//// Global.GTranscript = false;
//// System.Windows.Forms.MessageBox.Show("Stopped!");
 ////this.Cmdlet.StopProcessing();
        }
        
        void BtnWatchClick(object sender, EventArgs e)
        {
            // open the watch window
        }
        
        void BtnEditClick(object sender, EventArgs e)
        {
            // open the script steps window
        }
    }
}