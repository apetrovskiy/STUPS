/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 09/02/2012
 * Time: 05:20 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
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
            
            this.Cmdlet = cmdlet;
            
            //  // The InitializeComponent() call is required for Windows Forms designer support.
            // 
            InitializeComponent();
            
            //  // TODO: Add constructor code after the InitializeComponent() call.
            // 
        }
        
        // internal CommonCmdletBase Cmdlet { get; set; }
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
                Application.DoEvents();
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
            this.btnStart.Enabled = false;
            this.btnPause.Enabled = true;
            this.btnStop.Enabled = true;
            
            
            // this.Cmdlet.NoUI = true;
            // UIAHelper.ProcessingTranscript(this.Cmdlet)
            if (!this.Cmdlet.Paused) {
                StartRecording startRec = new RecorderForm.StartRecording(startRecording);
                this.Invoke(startRec, this.Cmdlet);
            }
            this.Cmdlet.Paused = false;
        }
        
        void BtnPauseClick(object sender, EventArgs e)
        {
            this.btnPause.Enabled = false;
            this.btnStart.Enabled = true;
            this.btnStop.Enabled = true;
            
            this.Cmdlet.Paused = true;
            // System.Windows.Forms.MessageBox.Show("Paused!");
            PauseRecording pauseRec = new RecorderForm.PauseRecording(pauseRecording);
            this.Invoke(pauseRec, this.Cmdlet);
        }
        
        void BtnStopClick(object sender, EventArgs e)
        {
            this.btnStop.Enabled = false;
            this.btnStart.Enabled = true;
            this.btnPause.Enabled = false;
            
            StopRecording stopRec = new RecorderForm.StopRecording(stopRecording);
            this.Invoke(stopRec, this.Cmdlet);
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
