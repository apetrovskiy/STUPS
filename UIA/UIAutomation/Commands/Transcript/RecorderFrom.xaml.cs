/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 15/02/2012
 * Time: 07:56 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace UIAutomation.Commands
{
    /// <summary>
    /// Interaction logic for RecorderFrom.xaml
    /// </summary>
    public partial class RecorderFrom : Window
    {
        public RecorderFrom(TranscriptCmdletBase cmdlet)
        {
            this.Cmdlet = cmdlet;
            
            InitializeComponent();
        }
        
        internal TranscriptCmdletBase Cmdlet { get; set; }
        delegate void StartRecording(TranscriptCmdletBase cmdlet);
        private void startRecording(TranscriptCmdletBase cmdlet)
        {
            // UIAHelper.ProcessingTranscript(cmdlet);
            Global.GTranscript = true;
            int counter = 0;
            cmdlet.rootElement = 
                System.Windows.Automation.AutomationElement.RootElement;
            cmdlet.StartDate =
                System.DateTime.Now;
            do{
                //Application.DoEvents();
                bool res = 
                    UIAHelper.ProcessingTranscriptOnce(cmdlet, counter);
                if (!res) break;
            } while (Global.GTranscript);
            
        }
        delegate void PauseRecording(TranscriptCmdletBase cmdlet);
        private void pauseRecording(TranscriptCmdletBase cmdlet)
        {
            this.Cmdlet.Paused = true;
            //System.Windows.Forms.MessageBox.Show("Paused!");
        }
        delegate void StopRecording(TranscriptCmdletBase cmdlet);
        private void stopRecording(TranscriptCmdletBase cmdlet)
        {
            Global.GTranscript = false;
            //System.Windows.Forms.MessageBox.Show("Stopped!");
            this.Cmdlet.StopProcessing();
        }
        
        void BtnStartClick(object sender, EventArgs e)
        {
            this.btnStart.IsEnabled = false;
            this.btnPause.IsEnabled = true;
            this.btnStop.IsEnabled = true;
            
            
            //// this.Cmdlet.NoUI = true;
            //// UIAHelper.ProcessingTranscript(this.Cmdlet)
            if (!this.Cmdlet.Paused) {
                ////StartRecording startRec = new RecorderFrom.StartRecording(startRecording);
                ////this.Invoke(startRec, this.Cmdlet);
                ////RecorderFrom.StartRecording(startRecording);
            }
            this.Cmdlet.Paused = false;
        }
        
        void BtnPauseClick(object sender, EventArgs e)
        {
            this.btnPause.IsEnabled = false;
            this.btnStart.IsEnabled = true;
            this.btnStop.IsEnabled = true;
            
            this.Cmdlet.Paused = true;
            //// System.Windows.Forms.MessageBox.Show("Paused!");
            ////PauseRecording pauseRec = new RecorderFrom.PauseRecording(pauseRecording);
            ////this.in.Invoke(pauseRec, this.Cmdlet);
            ////RecorderFrom.PauseRecording(pauseRecording);
        }
        
        void BtnStopClick(object sender, EventArgs e)
        {
            this.btnStop.IsEnabled = false;
            this.btnStart.IsEnabled = true;
            this.btnPause.IsEnabled = false;
            
            StopRecording stopRec = new RecorderFrom.StopRecording(stopRecording);
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