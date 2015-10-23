/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 09/02/2012
 * Time: 05:20 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace UIAutomation.Commands
{
    /// <summary>
    /// Description of RecorderForm.
    /// </summary>
    public partial class RecorderForm : Form
    {
        public RecorderForm(TranscriptCmdletBase cmdlet)
        {
            
            Cmdlet = cmdlet;
            
            //  // The InitializeComponent() call is required for Windows Forms designer support.
            // 
            InitializeComponent();
            
            //  // TODO: Add constructor code after the InitializeComponent() call.
            // 
        }
        
        // internal CommonCmdletBase Cmdlet { get; set; }
        internal TranscriptCmdletBase Cmdlet { get; set; }
        delegate void StartRecording(TranscriptCmdletBase cmdlet);
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
                Application.DoEvents();
                // 20131107
                counter++;
                //
                bool res =
                    // 20131114
                    //UiaHelper.ProcessingTranscriptOnce(cmdlet, counter);
                    UiaHelper.ProcessingTranscriptOnce(cmdlet, counter, Cursor.Position);
                if (!res) break;
            } while (Global.GTranscript);
            
        }
        delegate void PauseRecording(TranscriptCmdletBase cmdlet);
        private void PauseRecordingMethod(TranscriptCmdletBase cmdlet)
        {
            Cmdlet.Paused = true;
            //System.Windows.Forms.MessageBox.Show("Paused!");
        }
        delegate void StopRecording(TranscriptCmdletBase cmdlet);
        private void StopRecordingMethod(TranscriptCmdletBase cmdlet)
        {
            Global.GTranscript = false;
            //System.Windows.Forms.MessageBox.Show("Stopped!");
            Cmdlet.StopProcessing();
        }
        
        void BtnStartClick(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnPause.Enabled = true;
            btnStop.Enabled = true;
            
            
            // this.Cmdlet.NoUI = true;
            // UiaHelper.ProcessingTranscript(this.Cmdlet)
            if (!Cmdlet.Paused) {
                StartRecording startRec = new StartRecording(StartRecordingMethod);
                Invoke(startRec, Cmdlet);
            }
            Cmdlet.Paused = false;
        }
        
        void BtnPauseClick(object sender, EventArgs e)
        {
            btnPause.Enabled = false;
            btnStart.Enabled = true;
            btnStop.Enabled = true;
            
            Cmdlet.Paused = true;
            // System.Windows.Forms.MessageBox.Show("Paused!");
            PauseRecording pauseRec = new PauseRecording(PauseRecordingMethod);
            Invoke(pauseRec, Cmdlet);
        }
        
        void BtnStopClick(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            btnStart.Enabled = true;
            btnPause.Enabled = false;
            
            StopRecording stopRec = new StopRecording(StopRecordingMethod);
            Invoke(stopRec, Cmdlet);
            // this.Cmdlet.Paused = true;
// Global.GTranscript = false;
// System.Windows.Forms.MessageBox.Show("Stopped!");
// this.Cmdlet.StopProcessing();
        }
        
        void BtnWatchClick(object sender, EventArgs e)
        {
            // open the watch window
        }
        
        void BtnEditClick(object sender, EventArgs e)
        {
            // open the script steps window
        }
        
        void FrmRecorderMouseMove(object sender, MouseEventArgs e)
        {
            Application.DoEvents();
        }
        
        void FrmRecorderLoad(object sender, EventArgs e)
        {
            // 
        }
        
        void FrmRecorderFormClosing(object sender, FormClosingEventArgs e)
        {
            // this.Cmdlet.Paused = 
            Global.GTranscript = false;
            //System.Windows.Forms.MessageBox.Show("Stopped (click)!");
        }
        
        void BtnStartMouseMove(object sender, MouseEventArgs e)
        {
            Application.DoEvents();
        }
        
        void BtnPauseMouseMove(object sender, MouseEventArgs e)
        {
            Application.DoEvents();
        }
        
        void BtnStopMouseMove(object sender, MouseEventArgs e)
        {
            Application.DoEvents();
        }
        
        void BtnWatchMouseMove(object sender, MouseEventArgs e)
        {
            Application.DoEvents();
        }
        
        void BtnEditMouseMove(object sender, MouseEventArgs e)
        {
            Application.DoEvents();
        }
    }
}
