/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/28/2012
 * Time: 6:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIARunner
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using TMX;
    //using UIARunner;
    using System.Threading;
    using PSTestRunner;
    
    /// <summary>
    /// Description of UIARunnerForm.
    /// </summary>
    public partial class UIARunnerForm : Form
    {
        public UIARunnerForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
            
            this.cellStylePassed.BackColor = System.Drawing.Color.Green;
            this.cellStyleFailed.BackColor = System.Drawing.Color.Red;
            this.cellStylePassedWithBadSmell.BackColor = System.Drawing.Color.Olive;
            this.cellStyleOutput.BackColor = System.Drawing.Color.LightBlue;
        }
        
        
        DataGridViewCellStyle cellStylePassed = 
            new DataGridViewCellStyle();
        DataGridViewCellStyle cellStyleFailed = 
            new DataGridViewCellStyle();
        DataGridViewCellStyle cellStylePassedWithBadSmell = 
            new DataGridViewCellStyle();
        DataGridViewCellStyle cellStyleOutput = 
            new DataGridViewCellStyle();
        
        private int testResultsPassed = 0;
        private int testResultsFailed = 0;
        private DateTime startTime = System.DateTime.Now;
        private int testResultsAll = 0;
        
        private const string rowStateOutput = "OUTPUT";
        
        void UIARunnerFormLeave(object sender, EventArgs e)
        {
            this.TopMost = true;
        }
        
        void UIARunnerFormDeactivate(object sender, EventArgs e)
        {
            this.TopMost = true;
        }
        
        void UIARunnerFormResize(object sender, EventArgs e)
        {
            this.TopMost = true;
        }
        
        void UIARunnerFormLoad(object sender, EventArgs e)
        {
            this.TopMost = true;
        }
        
        void OpenToolStripMenuItemClick(object sender, EventArgs e)
        {
            //this.openFileDialog.AddExtension = "*.ps1";
            this.openFileDialog.CheckFileExists = true;
            this.openFileDialog.CheckPathExists = true;
            DialogResult res = this.openFileDialog.ShowDialog();
            
            PSTestRunner.TestRunner.ScriptPath = 
                this.openFileDialog.FileName;
            
            if (PSTestRunner.TestRunner.ScriptPath != null && PSTestRunner.TestRunner.ScriptPath != string.Empty &&
                PSTestRunner.TestRunner.ScriptPath.Length > 0 && System.IO.File.Exists(PSTestRunner.TestRunner.ScriptPath)) {
                setToReadyToRunState();
                setCaption(PSTestRunner.TestRunner.ScriptPath);
            } else {
                resetCaption();
            }
        }
        
        void RunToolStripMenuItemClick(object sender, EventArgs e)
        {
        }
        
        internal void OnRunScript(object sender, EventArgs e)
        {
            setToRunningState();

            this.dgvTestResults.Rows.Clear();

            TMX.TestData.ResetData();

            try {
                unregisterEvents();
            }
            catch {}
            
            int index = 0;
            
            bool res = false;

            try {
                if (this.inputToolStripTextBox.Text.Length > 0) {
                    PSTestRunner.TestRunner.ScriptParameters =
                        this.inputToolStripTextBox.Text;
                }
                
                res =
                    PSTestRunner.TestRunner.InitScript();
                if (!res) {
                    index = 
                        this.dgvTestResults.Rows.Add(
                            System.DateTime.Now.ToString(),
                            TMX.TestData.TestStateFailed,
                            "UIARunner.ps1",
                            string.Empty,
                            string.Empty,
                            "UIARunner.ps1");

                    setRowStatus(index, TMX.TestData.TestStateFailed);
                    setTestResultsCounters(TMX.TestData.TestStateFailed, 1);
                    setToReadyToRunState();
                    Application.DoEvents();
                    return;
                }
            }
            catch (Exception eInitException) {
                index = 
                    this.dgvTestResults.Rows.Add(
                        System.DateTime.Now.ToString(),
                        TMX.TestData.TestStateFailed,
                        "UIARunner.ps1",
                        string.Empty,
                        string.Empty,
                        "UIARunner.ps1",
                        eInitException.Message,
                        string.Empty);

                setRowStatus(index, TMX.TestData.TestStateFailed);
                setTestResultsCounters(TMX.TestData.TestStateFailed, 1);
                setToReadyToRunState();
                Application.DoEvents();
                return;
            }

            registerEvents();

            try {
                res = PSTestRunner.TestRunner.RunScriptCode();
                if (!res) {
                    index = 
                        this.dgvTestResults.Rows.Add(
                            System.DateTime.Now.ToString(),
                            TMX.TestData.TestStateFailed,
                            PSTestRunner.TestRunner.ScriptPath,
                            string.Empty,
                            string.Empty,
                            PSTestRunner.TestRunner.ScriptPath);

                    setRowStatus(index, TMX.TestData.TestStateFailed);
                    setTestResultsCounters(TMX.TestData.TestStateFailed, 1);
                    setToReadyToRunState();
                    Application.DoEvents();
                }
            }
            catch (Exception eRunScript) {
                index = 
                    this.dgvTestResults.Rows.Add(
                        System.DateTime.Now.ToString(),
                        TMX.TestData.TestStateFailed,
                        PSTestRunner.TestRunner.ScriptPath,
                         string.Empty,
                         string.Empty,
                         PSTestRunner.TestRunner.ScriptPath,
                         eRunScript.Message,
                         string.Empty);

                setRowStatus(index, TMX.TestData.TestStateFailed);
                setTestResultsCounters(TMX.TestData.TestStateFailed, 1);
                setToReadyToRunState();
                Application.DoEvents();
                return;
            }
            
            autoresizeColumns();

            setToReadyToRunState();
            Application.DoEvents();
        }
        
        void NewTestResultClosed(object sender, EventArgs e)
        {
            
            DataGridViewCellStyle cellStyle = 
                new DataGridViewCellStyle();
            cellStyle.BackColor = System.Drawing.Color.Red;
            
            string screenShotPath = string.Empty;
            try {
                screenShotPath = 
                    @"files:///" + 
                    ((ITestResult)sender).Screenshot.Replace(@"\", @"/").Replace(@":", "");
            }
            catch {}

            string errorMessage = string.Empty;
            try {
                if (((ITestResult)sender).Error != null) {
                    errorMessage = 
                        ((ITestResult)sender).Error.ErrorDetails.Message;
                }
            } 
            catch {}
            
            int index = 
                this.dgvTestResults.Rows.Add(
                    ((ITestResult)sender).Timestamp,
                    ((ITestResult)sender).Status,
                    ((ITestResult)sender).Name,
                    ((ITestResult)sender).LineNumber.ToString(),
                    ((ITestResult)sender).Position.ToString(),
                    ((ITestResult)sender).ScriptName,
                    errorMessage,
                    screenShotPath);
            setRowStatus(index, ((ITestResult)sender).Status);
            
            PSTestRunner.TestRunner.WriteTestResultToLog(((ITestResult)sender));
            
            Application.DoEvents();
        }
        
        void PSStateRunning(string msg)
        {
            this.toolStripStatusLabelState.Text = "Running...";
        }
        
        void PSStateCodeCompleted(string msg)
        {
            this.toolStripStatusLabelState.Text = "Completed";
        }
        
        void PSStateNotStarted(string msg)
        {
            this.toolStripStatusLabelState.Text = "Not started";
        }
        
        void PSStateCodeStopped(string msg)
        {
            this.toolStripStatusLabelState.Text = "Stopped";
        }
        
        void PSStateCodeStopping(string msg)
        {
            this.toolStripStatusLabelState.Text = "Stopping...";
        }
        
        public void PSStateErrorThrown(string msg)
        {
            this.toolStripStatusLabelState.Text = "Error thrown";
            
            string timestamp = 
                System.DateTime.Now.ToString();
            
            int index = 
                this.dgvTestResults.Rows.Add(
                    timestamp,
                    TMX.TestData.TestStateFailed,
                    msg,
                    string.Empty,
                    string.Empty,
                    PSTestRunner.TestRunner.ScriptPath,
                    msg,
                    string.Empty);
            
            setRowStatus(index, TMX.TestData.TestStateFailed);
            setTestResultsCounters(TMX.TestData.TestStateFailed, 1);
            setToReadyToRunState();
            
            PSTestRunner.TestRunner.WriteTestResultToLog(
               timestamp,
               TMX.TestData.TestStateFailed,
               msg,
               string.Empty,
               string.Empty,
               PSTestRunner.TestRunner.ScriptPath,
               msg,
               string.Empty);
            
            Application.DoEvents();
        }
        
        public void PSOutputArrived(object data)
        {
            string timestamp = 
                System.DateTime.Now.ToString();
            
            int index = 
                this.dgvTestResults.Rows.Add(
                    timestamp,
                    rowStateOutput,
                    data,
                    string.Empty,
                    string.Empty,
                    PSTestRunner.TestRunner.ScriptPath,
                    string.Empty,
                    string.Empty);
            
            setRowStatus(index, rowStateOutput);
            
            this.dgvTestResults.AutoResizeColumns();
            
            PSTestRunner.TestRunner.WriteTestResultToLog(
               timestamp,
               rowStateOutput,
               data,
               string.Empty,
               string.Empty,
               PSTestRunner.TestRunner.ScriptPath,
               string.Empty,
               string.Empty);
            
            Application.DoEvents();
        }
        
        void PSErrorArrived(object data)
        {
            this.dgvTestResults.AutoResizeColumns();
            Application.DoEvents();
        }
        
        private void registerEvents()
        {
            TMX.TestData.TMXNewTestResultClosed += 
                new TMX.TMXStructureChangedEventHandler(
                    NewTestResultClosed);
            
            // Runspace and Pipeline events
            PSRunner.Runner.PSCodeRunning +=
                new PSRunner.PSStateChangedEventHandler(
                    PSStateRunning);
            PSRunner.Runner.PSCodeCompleted += 
                new PSRunner.PSStateChangedEventHandler(
                    PSStateCodeCompleted);
            PSRunner.Runner.PSCodeNotStarted += 
                new PSRunner.PSStateChangedEventHandler(
                    PSStateNotStarted);
            PSRunner.Runner.PSCodeStopped +=
                new PSRunner.PSStateChangedEventHandler(
                    PSStateCodeStopped);
            PSRunner.Runner.PSCodeStopping +=
                new PSRunner.PSStateChangedEventHandler(
                    PSStateCodeStopping);
            PSRunner.Runner.PSErrorThrown += 
                new PSRunner.PSStateChangedEventHandler(
                    PSStateErrorThrown);
            PSRunner.Runner.PSOutputArrived +=
                new PSRunner.PSDataArrivedEventHandler(
                    PSOutputArrived);
            PSRunner.Runner.PSErrorArrived +=
                new PSRunner.PSDataArrivedEventHandler(
                    PSErrorArrived);
        }
        
        private void unregisterEvents()
        {
            TMX.TestData.TMXNewTestResultClosed -= 
                new TMX.TMXStructureChangedEventHandler(
                NewTestResultClosed);
            
            
            // Runspace and Pipeline events
            PSRunner.Runner.PSCodeRunning -=
                new PSRunner.PSStateChangedEventHandler(
                    PSStateRunning);
            PSRunner.Runner.PSCodeCompleted -= 
                new PSRunner.PSStateChangedEventHandler(
                    PSStateCodeCompleted);
            PSRunner.Runner.PSCodeNotStarted -= 
                new PSRunner.PSStateChangedEventHandler(
                    PSStateNotStarted);
            PSRunner.Runner.PSCodeStopped -=
                new PSRunner.PSStateChangedEventHandler(
                    PSStateCodeStopped);
            PSRunner.Runner.PSCodeStopping -=
                new PSRunner.PSStateChangedEventHandler(
                    PSStateCodeStopping);
            PSRunner.Runner.PSErrorThrown -= 
                new PSRunner.PSStateChangedEventHandler(
                    PSStateErrorThrown);
            PSRunner.Runner.PSOutputArrived -=
                new PSRunner.PSDataArrivedEventHandler(
                    PSOutputArrived);
            PSRunner.Runner.PSErrorArrived -=
                new PSRunner.PSDataArrivedEventHandler(
                    PSErrorArrived);
        }
        
        private void autoresizeColumns()
        {
            this.dgvTestResults.AutoResizeColumn(0);
            this.dgvTestResults.AutoResizeColumn(1);
            this.dgvTestResults.AutoResizeColumn(2);
        }
        
        private void setRowStatus(int index, string status)
        {
            if (status != TMX.TestData.TestStateNotTested) {
                foreach (DataGridViewCell cell in this.dgvTestResults.Rows[index].Cells) {
                    if (status == TMX.TestData.TestStatePassed) {
                        cell.Style = this.cellStylePassed;
                    }
                    if (status == TMX.TestData.TestStateFailed) {
                        cell.Style = this.cellStyleFailed;
                    }
                    if (status == TMX.TestData.TestStateKnownIssue) {
                        cell.Style = this.cellStylePassedWithBadSmell;
                    }
                    if (status == rowStateOutput) {
                        cell.Style = this.cellStyleOutput;
                    }
                }
            }
            setTestResultsCounters(status, 1);
        }

        private void setTestResultsCounters(string type, int count)
        {
            TestResultTypes tsType = TestResultTypes.NotTested;
            switch (type) {
                case TMX.TestData.TestStatePassed:
                    tsType = TestResultTypes.Passed;
                    break;
                case TMX.TestData.TestStateFailed:
                    tsType = TestResultTypes.Failed;
                    break;
                case TMX.TestData.TestStateKnownIssue:
                    tsType = PSTestRunner.TestResultTypes.PassedWithBadSmell;
                    break;
            }
            
            PSTestRunner.TestRunner.SetTestResultsCounters(
                tsType,
                count,
                ref this.testResultsPassed,
                ref this.testResultsFailed,
                ref this.testResultsAll,
                this.toolStripStatusLabelPassedCount,
                this.toolStripStatusLabelFailedCount,
                this.toolStripStatusLabelAverageCount,
                this.startTime);
        }
        
        private void setToReadyToRunState()
        {
            // MainMenu
            this.runToolStripMenuItem.Enabled = true;
            this.inputToolStripTextBox.Enabled = true;
            this.breakToolStripMenuItem.Enabled = false;
            this.openToolStripMenuItem.Enabled = true;
            
            // ToolBar
            this.toolStripButtonRun.Enabled = true;
            this.toolStripTextBoxInput.Enabled = true;
            this.toolStripButtonBreak.Enabled = false;
            this.toolStripButtonOpen.Enabled = true;
        }
        
        private void setToRunningState()
        {
            // MainMenu
            this.runToolStripMenuItem.Enabled = false;
            this.inputToolStripTextBox.Enabled = false;
            this.breakToolStripMenuItem.Enabled = true;
            this.openToolStripMenuItem.Enabled = false;
            
            // ToolBar
            this.toolStripButtonRun.Enabled = false;
            this.toolStripTextBoxInput.Enabled = false;
            this.toolStripButtonBreak.Enabled = true;
            this.toolStripButtonOpen.Enabled = false;
            
            // variables
            this.testResultsPassed = 0;
            this.testResultsFailed = 0;
            this.startTime = System.DateTime.Now;
            this.testResultsAll = 0;
            setTestResultsCounters(TMX.TestData.TestStatePassed, 0);
            setTestResultsCounters(TMX.TestData.TestStateFailed, 0);
        }
        
        private void setCaption(string scriptPath)
        {
            string scriptFileName = 
                scriptPath.Split('\\')[scriptPath.Split('\\').Length - 1];
            this.Text = 
                "UIARunner - " +
                scriptFileName;
        }
        
        private void resetCaption()
        {
            this.Text = 
                "UIARunner";
        }
        
        void DgvTestResultsMouseMove(object sender, MouseEventArgs e)
        {
            Application.DoEvents();
        }
        
        void ToolStripButtonOpenClick(object sender, EventArgs e)
        {
            this.openToolStripMenuItem.PerformClick();
        }
        
        void ToolStripButtonRunClick(object sender, EventArgs e)
        {
            this.runToolStripMenuItem.PerformClick();
        }
        
        void ToolStripButtonBreakClick(object sender, EventArgs e)
        {
            this.breakToolStripMenuItem.PerformClick();
        }
        
        void BreakToolStripMenuItemClick(object sender, EventArgs e)
        {
            PSTestRunner.TestRunner.BreakScript();
        }
        
        void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        void UIARunnerFormMouseMove(object sender, MouseEventArgs e)
        {
            Application.DoEvents();
        }
        
        void AboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }
        
        void ToolStripTextBoxInputParametersModifiedChanged(object sender, EventArgs e)
        {
            this.toolStripTextBoxInput.Text =
                this.inputToolStripTextBox.Text;
        }
        
        void ToolStripTextBoxInputModifiedChanged(object sender, EventArgs e)
        {
            this.inputToolStripTextBox.Text =
                this.toolStripTextBoxInput.Text;
        }
    }
    
    delegate void RunScriptDelegate(object sender, EventArgs e);
}
