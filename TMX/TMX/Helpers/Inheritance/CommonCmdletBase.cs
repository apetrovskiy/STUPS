/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 18/02/2012
 * Time: 01:36 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    using PSTestLib;
    
    /// <summary>
    /// Description of CmdletBase.
    /// </summary>
    public partial class CommonCmdletBase : PSCmdletBase
    {
        public CommonCmdletBase()
        {
//            if (null == UnitTestOutput) {
//                UnitTestOutput =
//                    new System.Collections.Generic.List<object>();
//            }
        }
        
        //protected internal new bool UnitTestMode { get; set; }
        //protected internal override bool UnitTestMode { get; set; }
        //protected internal override bool UnitTestMode { get; set; }
        //protected 
        //internal new bool UnitTestMode { get; set; }
        //protected internal override bool UnitTestMode { get; set; }
        //[Parameter(Mandatory = false)]
        //public new SwitchParameter UnitTestMode { get; set; }
        //protected internal new System.Collections.Generic.List<object> UnitTestOutput { get; set; }
        //internal static System.Collections.Generic.List<object> UnitTestOutput { get; set; }
        //public static System.Collections.Generic.List<object> UnitTestOutput { get; set; }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty()]
        public string Name { get; set; }
        [Parameter(Mandatory = false)]
        //[ValidateNotNullOrEmpty()]
        public string Id { get; set; }
        #endregion Parameters
        
        protected void notImplementedCase()
        {
            ErrorRecord err = 
                new ErrorRecord(
                    new Exception(),
                    "",
                    ErrorCategory.NotImplemented,
                    null);
            err.ErrorDetails = 
                new ErrorDetails("Not implemented");
            //WriteError(err);
            ThrowTerminatingError(err);
        }
        
        protected override void WriteLog(string logRecord)
        {
            Console.WriteLine("Here should be logging");
        }
        
// protected override void BeginProcessing()
// {
// TMX.TMXHelper.AddTestScenario(this.Name, this.Id);
// }
        
//        protected internal string GetInvocationInfo()
//        {
//            string result = string.Empty;
//            try{
//                ErrorRecord err = 
//                    new ErrorRecord(
//                        new Exception(),
//                        "",
//                        ErrorCategory.NotSpecified,
//                        null);
//                result += 
//                    "script name: " + 
//                    err.InvocationInfo.ScriptName +
//                    "\r\nline number: " +
//                    err.InvocationInfo.ScriptLineNumber.ToString() +
//                    "\r\ncode:" + 
//                    err.InvocationInfo.Line;
//                err = null;
//            }
//            catch {}
//            return result;
//        }
        
//        internal void ExportResultsToHTML(string path)
//        {
//            const string ulOpen = @"<ul>";
//            const string ulClose = @"</ul>";
//            const string liOpen = @"<li>";
//            const string liClose = @"</li>";
//            const string aOpen = "<a href=\"file:///";
//            const string aMid = "\">";
//            const string aClose = @"</a>";
//            const string space = @" ";
//            const string newLineCS = "\r\n";
//            const string tab = "    ";
//            const string colorOpenGray = "<font color=\"grey\">";
//            const string colorOpenRed = "<font color=\"red\">";
//            const string colorOpenGreen = "<font color=\"green\">";
//            const string colorClose = "</font>";
//            const string pgfOpen = "<p>";
//            const string pgfClose = "</p>";
//            const string headerSuiteOpen = "<h2>";
//            const string headerSuiteClose = "</h2>";
//            const string headerScenarioOpen = "<h3>";
//            const string headerScenarioClose = "</h3>";
//            
//            const string newLineHTML = "<br />";
//            
//            WriteVerbose("exporting test suites into HTML");
//            
//            string resultHTML = string.Empty;
//            // generate HTML in memory
//            foreach (TestSuite ts in TestData.TestSuites) {
//                WriteVerbose("Test Suite: " + ts.Name);
//                string color = colorOpenGray;
//                if (ts.enStatus == TestSuiteStatuses.Passed) {
//                    color = colorOpenGreen;
//                }
//                if (ts.enStatus == TestSuiteStatuses.Failed) {
//                    color = colorOpenRed;
//                }
//                resultHTML +=
//                    newLineCS +
//                    liOpen +
//                    color +
//                    headerSuiteOpen +
//                    ts.Id +
//                    space +
//                    ts.Name + 
//                    space +
//                    ts.Status + 
//                    headerSuiteClose +
//                    colorClose;
//                try{
//                    if (ts.Description != string.Empty && 
//                        ts.Description.Length > 0) {
//                        resultHTML +=
//                            //liOpen +
//                            pgfOpen +
//                            color +
//                            ts.Description +
//                            colorClose +
//                            pgfClose;
//                            //liClose;
//                    }
//                }
//                catch {}
//                resultHTML += 
//                    newLineCS + 
//                    tab + 
//                    ulOpen;
//                foreach (TestScenario tsc in ts.TestScenarios) {
//                    WriteVerbose("Test Scenario: " + tsc.Name);
//                    color = colorOpenGray;
//                    if (tsc.enStatus == TestScenarioStatuses.Passed) {
//                        color = colorOpenGreen;
//                    }
//                    if (tsc.enStatus == TestScenarioStatuses.Failed) {
//                        color = colorOpenRed;
//                    }
//                    resultHTML +=
//                        newLineCS +
//                        tab +
//                        tab +
//                        liOpen +
//                        color +
//                        headerScenarioOpen +
//                        tsc.Id +
//                        space +
//                        tsc.Name + 
//                        space + 
//                        tsc.Status + 
//                        headerScenarioClose +
//                        colorClose;
//                    try{
//                        if (tsc.Description != string.Empty && 
//                            tsc.Description.Length > 0) {
//                            resultHTML +=
//                                //liOpen +
//                                pgfOpen +
//                                color +
//                                tsc.Description +
//                                colorClose +
//                                pgfClose;
//                                //liClose;
//                        }
//                    }
//                    catch {}
//                    resultHTML +=
//                        newLineCS +
//                        tab +
//                        tab +
//                        tab +
//                        ulOpen;
//                    foreach (TestResult tr in tsc.TestResults) {
//                        WriteVerbose("Test Result: " + tr.Name);
//                        color = colorOpenGray;
//                        if (tr.enStatus == TestResultStatuses.Passed) {
//                            color = colorOpenGreen;
//                        }
//                        if (tr.enStatus == TestResultStatuses.Failed) {
//                            color = colorOpenRed;
//                        }
//                        resultHTML +=
//                            newLineCS +
//                            tab +
//                            tab +
//                            tab +
//                            tab +
//                            liOpen +
//                            color +
//                            tr.Id +
//                            space +
//                            tr.Name + 
//                            space +
//                            tr.Status + 
//                            colorClose;
//                        resultHTML +=
//                            newLineCS +
//                            tab +
//                            tab +
//                            tab +
//                            tab +
//                            tab +
//                            ulOpen;
//                        
//                        // test result detail colelction
//                        foreach (TestResultDetail td in tr.Details) {
//                            WriteVerbose(
//                                "Test Result Detail: " + 
//                                td.Name + 
//                                "\t" + 
//                                td.DetailType.ToString());
//                            resultHTML +=
//                                newLineCS +
//                                tab +
//                                tab +
//                                tab +
//                                tab +
//                                tab +
//                                tab +
//                                liOpen + 
//                                color;
//                            switch (td.DetailType) {
//                                case TestResultDetailTypes.Comment:
//                                    resultHTML +=
//                                        td.TextDetail +
//                                        liClose;
//                                    break;
//                                case TestResultDetailTypes.ErrorRecord:
//                                    resultHTML +=
//                                        td.ErrorDetail.ErrorDetails +
//                                        liClose;
//                                    break;
//                                case TestResultDetailTypes.Screenshot:
//                                    string fileName = 
//                                        td.ScreenshotDetail.Substring(
//                                            td.ScreenshotDetail.LastIndexOf('\\') + 1);
//                                    WriteVerbose(fileName);
//                                    resultHTML +=
//                                        aOpen +
//                                        td.ScreenshotDetail +
//                                        aMid + 
//                                        fileName + 
//                                        aClose;
//                                    break;
//                                default:
//                                    resultHTML +=
//                                        td.Name;
//                                    break;
//                            }
//                            resultHTML +=
//                                newLineCS +
//                                tab +
//                                tab +
//                                tab +
//                                tab +
//                                tab +
//                                tab +
//                                colorClose +
//                                liClose;
//                        }
//                        
//                        // test result code
//                        if (tr.Code != null && 
//                            tr.Code != string.Empty && 
//                            tr.Code.Length > 0){
//                            resultHTML +=
//                                newLineCS + 
//                                tab +
//                                tab +
//                                tab +
//                                tab +
//                                tab +
//                                tab +
//                                liOpen + 
//                                color;
//                            resultHTML +=
//                                tr.Code.Replace(newLineCS, newLineHTML);
//                            resultHTML +=
//                                newLineCS +
//                                tab +
//                                tab +
//                                tab +
//                                tab +
//                                tab +
//                                tab +
//                                colorClose +
//                                liClose;
//                        }
//                        
//                        // test result
//                        resultHTML +=
//                            newLineCS +
//                            tab +
//                            tab +
//                            tab +
//                            tab +
//                            tab +
//                            ulClose;
//                        resultHTML +=
//                            newLineCS +
//                            tab +
//                            tab +
//                            tab +
//                            tab +
//                            liClose;
//                    }
//                    resultHTML +=
//                        newLineCS +
//                        tab +
//                        tab +
//                        tab +
//                        ulClose;
//                    resultHTML +=
//                        newLineCS +
//                        tab +
//                        tab +
//                        liClose;
//                }
//                resultHTML +=
//                    newLineCS +
//                    tab +
//                    ulClose;
//                resultHTML += 
//                    newLineCS +
//                    liClose;
//            }
//            // create an HTML file
//            string reportFileName = string.Empty;
//            string generatedFileName = string.Empty;
//            WriteVerbose("deciding on which path to use for the report");
//            //if (((Commands.ExportTMXTestResultsCommand)this).Path != string.Empty &&
//            //    System.IO.File.Exists(((Commands.ExportTMXTestResultsCommand)this).Path)){
//            generatedFileName =
//                System.Environment.GetEnvironmentVariable(
//                    "TEMP",
//                    EnvironmentVariableTarget.User);
//            generatedFileName += @"\";
//            generatedFileName +=
//                "test_report.htm";
//            
//            if (path != string.Empty) {
//                reportFileName = 
//                    //((Commands.ExportTMXTestResultsCommand)this).Path;
//                    path;
//                WriteVerbose(reportFileName);
//            } else {
//                reportFileName = generatedFileName;
//                WriteVerbose(reportFileName);
//            }
//            
//            // write the report
//            System.IO.StreamWriter writer = null;
//            try{
//                WriteVerbose(
//                    "writing report to " +
//                    reportFileName);
//                writer =
//                    new System.IO.StreamWriter(reportFileName);
//                writer.WriteLine(resultHTML);
//                writer.Flush();
//                writer.Close();
//            }
//            catch (Exception eee) {
//                try{
//                    writer = 
//                        new System.IO.StreamWriter(generatedFileName);
//                    writer.WriteLine(resultHTML);
//                    writer.Flush();
//                    writer.Close();
//                    return;
//                }
//                catch (Exception ee) {
//                    ErrorRecord err = 
//                        new ErrorRecord(
//                            new Exception("Unable to create the report file: " +
//                                          reportFileName),
//                            "CantCreateReportFile",
//                            ErrorCategory.InvalidArgument,
//                            writer);
//                    err.ErrorDetails = 
//                        new ErrorDetails(
//                            "Unable to create the report file: " +
//                            generatedFileName + 
//                            "\r\n" + 
//                            ee.Message);
//                    ThrowTerminatingError(err);
//                }
//                ErrorRecord err2 = 
//                    new ErrorRecord(
//                        new Exception("Unable to create the report file: " +
//                                      reportFileName),
//                        "CantCreateReportFile",
//                        ErrorCategory.InvalidArgument,
//                        writer);
//                err2.ErrorDetails = 
//                    new ErrorDetails(
//                        "Unable to create the report file: " +
//                        reportFileName + 
//                        "\r\n" +
//                        eee.Message);
//                ThrowTerminatingError(err2);
//            }
//        }
//        
//        internal void ExportResultsToCSV(string path)
//        {
//            
//        }
//        
//        internal void ExportResultsToTEXT(string path)
//        {
//            
//        }
//        
//        internal void ExportSummaryToHTML(string path)
//        {
//            
//        }
//        
//        internal void ExportSummaryToCSV(string path)
//        {
//            
//        }
//        
//        internal void ExportSummaryToTEXT(string path)
//        {
//            
//        }

        protected override bool WriteObjectMethod010CheckOutputObject(object obj)
        {
            this.WriteVerbose(this, "OutputMethod010CheckOutputObject TMX");
            
            return true;
        }

        protected override void WriteObjectMethod020Highlight(PSCmdletBase cmdlet, object obj)
        {
            this.WriteVerbose(this, "OutputMethod020Highlight TMX");
        }
        
        protected override void WriteObjectMethod030RunScriptBlocks(PSCmdletBase cmdlet, object outputObject)
        {
            this.WriteVerbose(this, "OutputMethod030RunScriptBlocks TMX");
        }
        
        protected override void WriteObjectMethod040SetTestResult(PSCmdletBase cmdlet, object outputObject)
        {
            this.WriteVerbose(this, "OutputMethod040SetTestResult TMX");
        }
        
        protected override void WriteObjectMethod045OnSuccessScreenshot(PSCmdletBase cmdlet, object outputObject)
        {
            this.WriteVerbose(this, " TMX");
        }
        
        protected override void WriteObjectMethod050OnSuccessDelay(PSCmdletBase cmdlet, object outputObject)
        {
            this.WriteVerbose(this, "OutputMethod050OnSuccessDelay TMX");
        }
        
        protected override void WriteObjectMethod060OutputResult(PSCmdletBase cmdlet, object outputObject)
        {
            
            try {

                    base.WriteObject(outputObject);
            }
            catch {}
        }
        
        protected override void WriteObjectMethod070Report(PSCmdletBase cmdlet, object outputObject)
        {
            this.WriteVerbose(this, "OutputMethod070Report TMX");
        }
        
        protected override void WriteObjectMethod080ReportFailure()
        {
            this.WriteVerbose(this, "OutputMethod070Report TMX");
        }

        protected override void WriteErrorMethod010RunScriptBlocks(PSCmdletBase cmdlet)
        {
            this.WriteVerbose(this, " TMX");
        }
        
        protected override void WriteErrorMethod020SetTestResult(PSCmdletBase cmdlet, ErrorRecord errorRecord)
        {
            this.WriteVerbose(this, " TMX");
        }
        
        protected override void WriteErrorMethod030ChangeTimeoutSettings(PSCmdletBase cmdlet, bool terminating)
        {
            this.WriteVerbose(this, " TMX");
        }
        
        protected override void WriteErrorMethod040AddErrorToErrorList(PSCmdletBase cmdlet, ErrorRecord errorRecord)
        {
            this.WriteVerbose(this, " TMX");
        }

        protected override void WriteErrorMethod045OnErrorScreenshot(PSCmdletBase cmdlet)
        {
            WriteVerbose(this, "WriteErrorMethod045OnErrorScreenshot TMX");
        }
        
        protected override void WriteErrorMethod050OnErrorDelay(PSCmdletBase cmdlet)
        {
            this.WriteVerbose(this, " TMX");
        }

        protected override void WriteErrorMethod060OutputError(PSCmdletBase cmdlet, ErrorRecord errorRecord, bool terminating)
        {
            if (terminating) {
                this.WriteVerbose(this, "terminating error !!!");
                try {
                    ThrowTerminatingError(errorRecord);
                }
                catch {}
            } else {
                this.WriteVerbose(this, "regular error !!!");
                try {
                    WriteError(errorRecord);
                }
                catch {}
            }
        }
        
        protected override void WriteErrorMethod070Report(PSCmdletBase cmdlet)
        {
            this.WriteVerbose(this, " TMX");
        }

    }
}
