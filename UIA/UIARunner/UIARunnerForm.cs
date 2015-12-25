/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/28/2012
 * Time: 6:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UiaRunner
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    // using Tmx.Core;
    using Tmx;
    using Tmx.Interfaces.TestStructure;
    using PSTestRunner;
    
    /// <summary>
    /// Description of UiaRunnerForm.
    /// </summary>
    public partial class UiaRunnerForm : Form
    {
        public UiaRunnerForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
            
            cellStylePassed.BackColor = Color.Green;
            cellStyleFailed.BackColor = Color.Red;
            cellStylePassedWithBadSmell.BackColor = Color.Olive;
            cellStyleOutput.BackColor = Color.LightBlue;
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
        private DateTime startTime = DateTime.Now;
        private int testResultsAll = 0;
        
        private const string rowStateOutput = "OUTPUT";
        
        void UiaRunnerFormLeave(object sender, EventArgs e)
        {
            TopMost = true;
        }
        
        void UiaRunnerFormDeactivate(object sender, EventArgs e)
        {
            TopMost = true;
        }
        
        void UiaRunnerFormResize(object sender, EventArgs e)
        {
            TopMost = true;
        }
        
        void UiaRunnerFormLoad(object sender, EventArgs e)
        {
            TopMost = true;
        }
        
        void OpenToolStripMenuItemClick(object sender, EventArgs e)
        {
            //this.openFileDialog.AddExtension = "*.ps1";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            DialogResult res = openFileDialog.ShowDialog();
            
            TestRunner.ScriptPath = 
                openFileDialog.FileName;
            
            if (TestRunner.ScriptPath != null && TestRunner.ScriptPath != string.Empty &&
                TestRunner.ScriptPath.Length > 0 && System.IO.File.Exists(TestRunner.ScriptPath)) {
                setToReadyToRunState();
                setCaption(TestRunner.ScriptPath);
            } else {
                resetCaption();
            }
        }
        
        // 20131105
        // refactoring
        /*
        void RunToolStripMenuItemClick(object sender, EventArgs e)
        {
        }
        */
        
        internal void OnRunScript(object sender, EventArgs e)
        {
            setToRunningState();

            dgvTestResults.Rows.Clear();

            TestData.ResetData();

            try {
                unregisterEvents();
            }
            catch {}
            
            int index = 0;
            
            bool res = false;

            try {
                if (inputToolStripTextBox.Text.Length > 0) {
                    TestRunner.ScriptParameters =
                        inputToolStripTextBox.Text;
                }
                
                res =
                    TestRunner.InitScript();
                /*
                if (res) return;
                index = 
                    this.dgvTestResults.Rows.Add(
                        System.DateTime.Now.ToString(),
                        TestData.TestStateFailed,
                        "UiaRunner.ps1",
                        string.Empty,
                        string.Empty,
                        "UiaRunner.ps1");

                setRowStatus(index, TestData.TestStateFailed);
                setTestResultsCounters(TestData.TestStateFailed, 1);
                setToReadyToRunState();
                Application.DoEvents();
                return;
                */
                
                if (!res)
                {
                    index =
                        dgvTestResults.Rows.Add(
                            DateTime.Now.ToString(),
                            TestData.TestStateFailed,
                            "UiaRunner.ps1",
                            string.Empty,
                            string.Empty,
                            "UiaRunner.ps1");

                    setRowStatus(index, TestData.TestStateFailed);
                    setTestResultsCounters(TestData.TestStateFailed, 1);
                    setToReadyToRunState();
                    Application.DoEvents();
                    return;
                }
                
            }
            catch (Exception eInitException) {
                index = 
                    dgvTestResults.Rows.Add(
                    DateTime.Now.ToString(),
                    TestData.TestStateFailed,
                    "UiaRunner.ps1",
                    string.Empty,
                    string.Empty,
                    "UiaRunner.ps1",
                    eInitException.Message,
                    string.Empty);

                setRowStatus(index, TestData.TestStateFailed);
                setTestResultsCounters(TestData.TestStateFailed, 1);
                setToReadyToRunState();
                Application.DoEvents();
                return;
            }

            registerEvents();

            try {
                res = TestRunner.RunScriptCode();
                if (!res) {
                    index = 
                        dgvTestResults.Rows.Add(
                        DateTime.Now.ToString(),
                        TestData.TestStateFailed,
                        TestRunner.ScriptPath,
                        string.Empty,
                        string.Empty,
                        TestRunner.ScriptPath);

                    setRowStatus(index, TestData.TestStateFailed);
                    setTestResultsCounters(TestData.TestStateFailed, 1);
                    setToReadyToRunState();
                    Application.DoEvents();
                }
            }
            catch (Exception eRunScript) {
                index = 
                    dgvTestResults.Rows.Add(
                    DateTime.Now.ToString(),
                    TestData.TestStateFailed,
                    TestRunner.ScriptPath,
                    string.Empty,
                    string.Empty,
                    TestRunner.ScriptPath,
                    eRunScript.Message,
                    string.Empty);

                setRowStatus(index, TestData.TestStateFailed);
                setTestResultsCounters(TestData.TestStateFailed, 1);
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
            
            var cellStyle = new DataGridViewCellStyle {BackColor = Color.Red};
            /*
            DataGridViewCellStyle cellStyle =
                new DataGridViewCellStyle();
            cellStyle.BackColor = System.Drawing.Color.Red;
            */

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
                    // 20150116
                    /*
                    errorMessage = 
                        ((ITestResult)sender).Error.ErrorDetails.Message;
                    */
                    errorMessage = ((ITestResult)sender).Error.Message;
                }
            } 
            catch {}
            
            int index = 
                dgvTestResults.Rows.Add(
                    ((ITestResult)sender).Timestamp,
                    ((ITestResult)sender).Status,
                    ((ITestResult)sender).Name,
                    ((ITestResult)sender).LineNumber.ToString(),
                    ((ITestResult)sender).Position.ToString(),
                    ((ITestResult)sender).ScriptName,
                    errorMessage,
                    screenShotPath);
            setRowStatus(index, ((ITestResult)sender).Status);
            
            TestRunner.WriteTestResultToLog(((ITestResult)sender));
            
            Application.DoEvents();
        }
        
        void PSStateRunning(string msg)
        {
            toolStripStatusLabelState.Text = "Running...";
        }
        
        void PSStateCodeCompleted(string msg)
        {
            toolStripStatusLabelState.Text = "Completed";
        }
        
        void PSStateNotStarted(string msg)
        {
            toolStripStatusLabelState.Text = "Not started";
        }
        
        void PSStateCodeStopped(string msg)
        {
            toolStripStatusLabelState.Text = "Stopped";
        }
        
        void PSStateCodeStopping(string msg)
        {
            toolStripStatusLabelState.Text = "Stopping...";
        }
        
        public void PSStateErrorThrown(string msg)
        {
            toolStripStatusLabelState.Text = "Error thrown";
            
            string timestamp = DateTime.Now.ToString();
            
            int index = 
                dgvTestResults.Rows.Add(
                    timestamp,
                    TestData.TestStateFailed,
                    msg,
                    string.Empty,
                    string.Empty,
                    TestRunner.ScriptPath,
                    msg,
                    string.Empty);
            
            setRowStatus(index, TestData.TestStateFailed);
            setTestResultsCounters(TestData.TestStateFailed, 1);
            setToReadyToRunState();
            
            TestRunner.WriteTestResultToLog(
                timestamp,
                TestData.TestStateFailed,
                msg,
                string.Empty,
                string.Empty,
                TestRunner.ScriptPath,
                msg,
                string.Empty);
            
            Application.DoEvents();
        }
        
        public void PSOutputArrived(object data)
        {
            string timestamp = DateTime.Now.ToString();
            
            int index = 
                dgvTestResults.Rows.Add(
                    timestamp,
                    rowStateOutput,
                    data,
                    string.Empty,
                    string.Empty,
                    TestRunner.ScriptPath,
                    string.Empty,
                    string.Empty);
            
            setRowStatus(index, rowStateOutput);
            
            dgvTestResults.AutoResizeColumns();
            
            TestRunner.WriteTestResultToLog(
                timestamp,
                rowStateOutput,
                data,
                string.Empty,
                string.Empty,
                TestRunner.ScriptPath,
                string.Empty,
                string.Empty);
            
            Application.DoEvents();
        }
        
        void PSErrorArrived(object data)
        {
            dgvTestResults.AutoResizeColumns();
            Application.DoEvents();
        }
        
        void registerEvents()
        {
            TestData.TmxNewTestResultClosed += 
                new TmxStructureChangedEventHandler(
                    NewTestResultClosed);
            
            // Runspace and Pipeline events
            PSRunner.Runner.PSCodeRunning += PSStateRunning;
            PSRunner.Runner.PSCodeCompleted += PSStateCodeCompleted;
            PSRunner.Runner.PSCodeNotStarted += PSStateNotStarted;
            PSRunner.Runner.PSCodeStopped += PSStateCodeStopped;
            PSRunner.Runner.PSCodeStopping += PSStateCodeStopping;
            PSRunner.Runner.PSErrorThrown += PSStateErrorThrown;
            PSRunner.Runner.PSOutputArrived += PSOutputArrived;
            PSRunner.Runner.PSErrorArrived += PSErrorArrived;
            
            /*
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
            */
        }
        
        void unregisterEvents()
        {
            TestData.TmxNewTestResultClosed -= 
                new TmxStructureChangedEventHandler(
                NewTestResultClosed);
            
            
            // Runspace and Pipeline events
            PSRunner.Runner.PSCodeRunning -= PSStateRunning;
            PSRunner.Runner.PSCodeCompleted -= PSStateCodeCompleted;
            PSRunner.Runner.PSCodeNotStarted -= PSStateNotStarted;
            PSRunner.Runner.PSCodeStopped -= PSStateCodeStopped;
            PSRunner.Runner.PSCodeStopping -= PSStateCodeStopping;
            PSRunner.Runner.PSErrorThrown -= PSStateErrorThrown;
            PSRunner.Runner.PSOutputArrived -= PSOutputArrived;
            PSRunner.Runner.PSErrorArrived -= PSErrorArrived;
            
            /*
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
                new PSRunner.PSDataArri
            */
        }
        
        void autoresizeColumns()
        {
            dgvTestResults.AutoResizeColumn(0);
            dgvTestResults.AutoResizeColumn(1);
            dgvTestResults.AutoResizeColumn(2);
        }
        
        void setRowStatus(int index, string status)
        {
            if (status != TestData.TestStateNotTested) {
                foreach (DataGridViewCell cell in dgvTestResults.Rows[index].Cells) {
                    if (status == TestData.TestStatePassed) {
                        cell.Style = cellStylePassed;
                    }
                    if (status == TestData.TestStateFailed) {
                        cell.Style = cellStyleFailed;
                    }
                    if (status == TestData.TestStateKnownIssue) {
                        cell.Style = cellStylePassedWithBadSmell;
                    }
                    if (status == rowStateOutput) {
                        cell.Style = cellStyleOutput;
                    }
                }
            }
            setTestResultsCounters(status, 1);
        }

        void setTestResultsCounters(string type, int count)
        {
            TestResultTypes tsType = TestResultTypes.NotTested;
            switch (type) {
                case TestData.TestStatePassed:
                    tsType = TestResultTypes.Passed;
                    break;
                case TestData.TestStateFailed:
                    tsType = TestResultTypes.Failed;
                    break;
                case TestData.TestStateKnownIssue:
                    tsType = TestResultTypes.PassedWithBadSmell;
                    break;
            }
            
            TestRunner.SetTestResultsCounters(
                tsType,
                count,
                ref testResultsPassed,
                ref testResultsFailed,
                ref testResultsAll,
                toolStripStatusLabelPassedCount,
                toolStripStatusLabelFailedCount,
                toolStripStatusLabelAverageCount,
                startTime);
        }
        
        void setToReadyToRunState()
        {
            // MainMenu
            runToolStripMenuItem.Enabled = true;
            inputToolStripTextBox.Enabled = true;
            breakToolStripMenuItem.Enabled = false;
            openToolStripMenuItem.Enabled = true;
            
            // ToolBar
            toolStripButtonRun.Enabled = true;
            toolStripTextBoxInput.Enabled = true;
            toolStripButtonBreak.Enabled = false;
            toolStripButtonOpen.Enabled = true;
        }
        
        void setToRunningState()
        {
            // MainMenu
            runToolStripMenuItem.Enabled = false;
            inputToolStripTextBox.Enabled = false;
            breakToolStripMenuItem.Enabled = true;
            openToolStripMenuItem.Enabled = false;
            
            // ToolBar
            toolStripButtonRun.Enabled = false;
            toolStripTextBoxInput.Enabled = false;
            toolStripButtonBreak.Enabled = true;
            toolStripButtonOpen.Enabled = false;
            
            // variables
            testResultsPassed = 0;
            testResultsFailed = 0;
            startTime = DateTime.Now;
            testResultsAll = 0;
            setTestResultsCounters(TestData.TestStatePassed, 0);
            setTestResultsCounters(TestData.TestStateFailed, 0);
        }
        
        void setCaption(string scriptPath)
        {
            string scriptFileName = scriptPath.Split('\\')[scriptPath.Split('\\').Length - 1];
            Text = "UiaRunner - " + scriptFileName;
        }
        
        void resetCaption()
        {
            Text = 
                "UiaRunner";
        }
        
        void DgvTestResultsMouseMove(object sender, MouseEventArgs e)
        {
            Application.DoEvents();
        }
        
        void ToolStripButtonOpenClick(object sender, EventArgs e)
        {
            openToolStripMenuItem.PerformClick();
        }
        
        void ToolStripButtonRunClick(object sender, EventArgs e)
        {
            runToolStripMenuItem.PerformClick();
        }
        
        void ToolStripButtonBreakClick(object sender, EventArgs e)
        {
            breakToolStripMenuItem.PerformClick();
        }
        
        void BreakToolStripMenuItemClick(object sender, EventArgs e)
        {
            TestRunner.BreakScript();
        }
        
        void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        void UiaRunnerFormMouseMove(object sender, MouseEventArgs e)
        {
            Application.DoEvents();
        }
        
        void AboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            var aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }
        
        void ToolStripTextBoxInputParametersModifiedChanged(object sender, EventArgs e)
        {
            toolStripTextBoxInput.Text = inputToolStripTextBox.Text;
        }
        
        void ToolStripTextBoxInputModifiedChanged(object sender, EventArgs e)
        {
            inputToolStripTextBox.Text = toolStripTextBoxInput.Text;
        }
    }
    
    delegate void RunScriptDelegate(object sender, EventArgs e);
}
