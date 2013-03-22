/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/12/2012
 * Time: 1:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    using System.Linq;
    using System.Xml.Linq;
    
    /// <summary>
    /// Description of ImportExportCmdletBase.
    /// </summary>
    public class ImportExportCmdletBase : SearchCmdletBase
    {
        public ImportExportCmdletBase()
        {
            this.As = string.Empty;
            this.Name = string.Empty;
            this.Path = string.Empty;
            // 20130322
            this.ExcludeAutomatic = false;
        }
        
        #region Parameters
        // 20130219
        //[Parameter(Mandatory = true,
        //           Position = 0)]
        [Parameter(Mandatory = true,
                   Position = 0,
                   ParameterSetName = "Common")]
        public string As { get; set; }
        
        // 20130219
        //[Parameter(Mandatory = false)]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Common")]
        public string Path { get; set; }
        
        // 20130219
        //[Parameter(Mandatory = false)]
        [Parameter(Mandatory = false,
                   ParameterSetName = "Common")]
        internal new string Name { get; set; }
        
        // 20130322
        [Parameter(Mandatory = false)]
        public SwitchParameter ExcludeAutomatic { get; set; }
        #endregion Parameters
        
        private const string styleExpand = 
            @"<style type=""text/css"">" + "\r\n" +
            @"UL                   { cursor: hand; }" + "\r\n" +
            @"UL LI                { display: none;font: 18pt;list-style: square; }" + "\r\n" +
            @"UL.showList LI       { display: block; }" + "\r\n" +
            @".defaultStyles UL    { color: gold; }" + "\r\n" +
            @"UL.defaultStyles LI  { display: none; }" + "\r\n" +
            @"</style>" + "\r\n";
            //
        private const string styleLink = 
            @"<style type=""text/css"">" + "\r\n" +
            @"a.link                 { color: blue; }" + "\r\n" +
            @"</style>" + "\r\n";
            //
        private const string styleGlobal = 
            @"<style type=""text/css"">" + "\r\n" +
            @"#global            { " + "\r\n" +
            @"                      font-size: x-small;" + "\r\n" +
            @"                      border: 1px solid gray;" + "\r\n" +
            @"                     }" + "\r\n" +
            @"</style>" + "\r\n";
        private const string styleOverallStat = 
            @"<style type=""text/css"">" + "\r\n" +
            @"#overallstat         { " + "\r\n" +
            @"                      position: relative;" + "\r\n" +
            @"                      left: 20px;" + "\r\n" +
            @"                      top: auto;" + "\r\n" +
            @"                      width: auto;" + "\r\n" +
            @"                      border: 1px solid gray;" + "\r\n" +
            @"                     }" + "\r\n" +
            @"</style>" + "\r\n";
        private const string styleSuite = 
            @"<style type=""text/css"">" + "\r\n" +
            @"#suite               { " + "\r\n" +
            @"                      position: relative;" + "\r\n" +
            @"                      left: 20px;" + "\r\n" +
            @"                      top: auto;" + "\r\n" +
            @"                      width: auto;" + "\r\n" +
            @"                      border: 1px solid gray;" + "\r\n" +
            @"                      margin: 0px 0px 0px 0px;" + "\r\n" +
            @"                     }" + "\r\n" +
            @"</style>" + "\r\n";
        private const string styleSuiteStat = 
            @"<style type=""text/css"">" + "\r\n" +
            @"#suitestat           { " + "\r\n" +
            @"                      position: relative;" + "\r\n" +
            @"                      left: 40px;" + "\r\n" +
            @"                      top: 0px;" + "\r\n" +
            @"                      width: auto;" + "\r\n" +
            @"                      border: 1px solid gray;" + "\r\n" +
            @"                     }" + "\r\n" +
            @"</style>" + "\r\n";
        private const string styleSuiteDescription = 
            @"<style type=""text/css"">" + "\r\n" +
            @"#suitedescription    { " + "\r\n" +
            @"                      position: relative;" + "\r\n" +
            @"                      left: 0px;" + "\r\n" +
            @"                      top: 0px;" + "\r\n" +
            @"                      width: auto;" + "\r\n" +
            @"                      border: 1px solid gray;" + "\r\n" +
            @"                     }" + "\r\n" +
            @"</style>" + "\r\n";
        private const string styleScenario = 
            @"<style type=""text/css"">" + "\r\n" +
            @"#scenario            { " + "\r\n" +
            @"                      position: relative;" + "\r\n" +
            @"                      left: 20px;" + "\r\n" +
            @"                      top: auto;" + "\r\n" +
            @"                      width: auto;" + "\r\n" +
            @"                      border: 1px solid gray;" + "\r\n" +
            @"                      margin: 0px 0px 0px 0px;" + "\r\n" +
            @"                     }" + "\r\n" +
            @"</style>" + "\r\n";
        private const string styleScenarioStat = 
            @"<style type=""text/css"">" + "\r\n" +
            @"#scenariostat        { " + "\r\n" +
            @"                      position: relative;" + "\r\n" +
            @"                      left: 20px;" + "\r\n" +
            @"                      top: 0px;" + "\r\n" +
            @"                      width: auto;" + "\r\n" +
            @"                      border: 1px solid gray;" + "\r\n" +
            @"                     }" + "\r\n" +
            @"</style>" + "\r\n";
        private const string styleScenarioDescription = 
            @"<style type=""text/css"">" + "\r\n" +
            @"#scenariodescription { " + "\r\n" +
            @"                      position: relative;" + "\r\n" +
            @"                      left: 0px;" + "\r\n" +
            @"                      top: 0px;" + "\r\n" +
            @"                      width: auto;" + "\r\n" +
            @"                      border: 1px solid gray;" + "\r\n" +
            @"                     }" + "\r\n" +
            @"</style>" + "\r\n";
        private const string styleTestResult = 
            @"<style type=""text/css"">" + "\r\n" +
            @"#testresult          { " + "\r\n" +
            @"                      position: relative;" + "\r\n" +
            @"                      left: 20px;" + "\r\n" +
            @"                      top: auto;" + "\r\n" +
            @"                      width: auto;" + "\r\n" +
            @"                      border: 1px solid gray;" + "\r\n" +
            @"                      margin: 0px 0px 0px 0px;" + "\r\n" +
            @"                     }" + "\r\n" +
            @"</style>" + "\r\n";
        private const string styleTestResultStat = 
            @"<style type=""text/css"">" + "\r\n" +
            @"#testresultstat      { " + "\r\n" +
            @"                      position: relative;" + "\r\n" +
            @"                      left: 20px;" + "\r\n" +
            @"                      top: 0px;" + "\r\n" +
            @"                      width: auto;" + "\r\n" +
            @"                      border: 1px solid gray;" + "\r\n" +
            @"                     }" + "\r\n" +
            @"</style>" + "\r\n";
        private const string styleTestResultDescription = 
            @"<style type=""text/css"">" + "\r\n" +
            @"#testresultdescription{ " + "\r\n" +
            @"                      position: relative;" + "\r\n" +
            @"                      left: 0px;" + "\r\n" +
            @"                      top: 0px;" + "\r\n" +
            @"                      width: auto;" + "\r\n" +
            @"                      border: 1px solid gray;" + "\r\n" +
            @"                     }" + "\r\n" +
            @"</style>" + "\r\n";
        private const string styleTestResultDetail = 
            @"<style type=""text/css"">" + "\r\n" +
            @"#testresultdetail    { " + "\r\n" +
            @"                      position: relative;" + "\r\n" +
            @"                      left: 20px;" + "\r\n" +
            @"                      top: auto;" + "\r\n" +
            @"                      width: auto;" + "\r\n" +
            @"                      border: 1px solid gray;" + "\r\n" +
            @"                      margin: 0px 0px 0px 0px;" + "\r\n" +
            @"                     }" + "\r\n" +
            @"</style>" + "\r\n";
        
        private const string stylePassed = 
            @"<style type=""text/css"">" + "\r\n" +
            @".passed             { " + "\r\n" +
            @"                      color: green;" + "\r\n" +
            @"                     }" + "\r\n" +
            @"</style>" + "\r\n";
        private const string styleFailed = 
            @"<style type=""text/css"">" + "\r\n" +
            @".failed             { " + "\r\n" +
            @"                      color: red;" + "\r\n" +
            @"                     }" + "\r\n" +
            @"</style>" + "\r\n";
        private const string styleKnownIssue = 
            @"<style type=""text/css"">" + "\r\n" +
            @".knownissue          { " + "\r\n" +
            @"                      color: olive;" + "\r\n" +
            @"                     }" + "\r\n" +
            @"</style>" + "\r\n";
        private const string styleNotTested = 
            @"<style type=""text/css"">" + "\r\n" +
            @".nottested          { " + "\r\n" +
            @"                      color: gray;" + "\r\n" +
            @"                     }" + "\r\n" +
            @"</style>" + "\r\n";
        
        private const string ulOpen = @"<ul onclick = ""this.className = 'showList';"" ondblclick = ""this.className = 'defaultStyles';"" onmouseover = ""this.style.color = 'blue';"" onselectstart = ""event.returnValue = false;"">";
        private const string ulOpenAfterDescription = @"</a>";
        private const string ulClose = @"</ul>";
        private const string liOpen = @"<li>";
        private const string liClose = @"</li>";
        private const string aOpen = "<a href=\"file:///";
        private const string aMid = @""" target='top'>";
        private const string aClose = @"</a>";
        private const string space = @" ";
        private const string newLineCS = "\r\n";
        private const string pgfClose = "</p>";
        
        private const string pgfSuiteOpenPassed = @"<p class=""suite passed"">";
        private const string pgfSuiteOpenFailed = @"<p class=""suite failed"">";
        private const string pgfSuiteOpenNotTested = @"<p class=""suite nottested"">";
        private const string pgfScenarioOpenPassed = @"<p class=""scenario passed"">";
        private const string pgfScenarioOpenFailed = @"<p class=""scenario failed"">";
        private const string pgfScenarioOpenNotTested = @"<p class=""scenario nottested"">";
        private const string pgfTestResultOpenPassed = @"<p class=""testresult passed"">";
        private const string pgfTestResultOpenFailed = @"<p class=""testresult failed"">";
        private const string pgfTestResultOpenKnownIssue = @"<p class=""testresult knownissue"">";
        private const string pgfTestResultOpenNotTested = @"<p class=""testresult nottested"">";
        
        private const string styleGlobalOpen = @"<div id=""global"">";
        private const string styleGlobalClose = @"</div>";
        private const string headerTitleOpen = "<h1>";
        private const string headerTitleClose = "</h1>";
        private const string headerSuiteOpen = @"<h2>";
        private const string headerSuiteClose = @"</h2>";
        private const string headerScenarioOpen = @"<h3>";
        private const string headerScenarioClose = @"</h3>";
        
        private const string styleSuiteOpenPassed = @"<div id=""suite"" class=""suite passed"">";
        private const string styleSuiteOpenFailed = @"<div id=""suite"" class=""suite failed"">";
        private const string styleSuiteOpenNotTested = @"<div id=""suite"" class=""suite nottested"">";
        private const string styleSuiteClose = @"</div>";
        private const string styleScenarioOpenPassed = @"<div id=""scenario"" class=""scenario passed"">";
        private const string styleScenarioOpenFailed = @"<div id=""scenario"" class=""scenario failed"">";
        private const string styleScenarioOpenNotTested = @"<div id=""scenario"" class=""scenario nottested"">";
        private const string styleScenarioClose = @"</div>";
        private const string styleTestResultOpenPassed = @"<div id=""testresult"" class=""testresult passed"">";
        private const string styleTestResultOpenFailed = @"<div id=""testresult"" class=""testresult failed"">";
        private const string styleTestResultOpenKnownIssue = @"<div id=""testresult"" class=""testresult knownissue"">";
        private const string styleTestResultOpenNotTested = @"<div id=""testresult"" class=""testresult nottested"">";
        private const string styleTestResultClose = @"</div>";
        
        private const string styleSuiteDescriptionOpen = @"<div id=""suitedescription"">";
        private const string styleSuiteDescriptionClose = @"</div>";
        private const string styleScenarioDescriptionOpen = @"<div id=""scenariodescription"">";
        private const string styleScenarioDescriptionClose = @"</div>";
        private const string styleTestResultDescriptionOpen = @"<div id=""testresultdescription"">";
        private const string styleTestResultDescriptionClose = @"</div>";
        
        private const string docType = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">" +
            "\r\n\t" +
            @"<html xmlns=""http://www.w3.org/1999/xhtml"">";

        
        private const string htmlOpen = "<html>";
        private const string htmlClose = "</html>";
        private const string headOpen = "<head>";
        private const string headClose = "</head>";
        private const string titleOpen = "<title>";
        private const string titleClose = "</title>";
        private const string bodyOpen = "<body>";
        private const string bodyClose = "</body>";
        private const string tabTitleBody = "    ";
        private const string tabTestSuite = "        ";
        private const string tabTestSuite2 = "            ";
        private const string tabTestScenario = "                ";
        private const string tabTestScenario2 = "                    ";
        private const string tabTestResult = "                        ";
        private const string tabTestResult2 = "                            ";
        private const string tabTestResult3 = "                                ";
        private const string tabTestResultDetail = "                                    ";
        
        private const string newLineHTML = "<br />";
        
        protected internal void ExportToHTML(
            string path,
            // 20130322
            //bool fullReport)
            bool fullReport,
            bool skipAutomatic)
        {
            WriteVerbose(this, "exporting test suites into HTML");
            
            int globalLinkId = 0;
            
            string resultHTML = string.Empty;
            
            // generate HTML in memory
            
            // report test data
            foreach (TestSuite ts in TestData.TestSuites) {
                WriteVerbose(this, "Test Suite: " + ts.Name);
                string pgfSuite = pgfSuiteOpenNotTested;
                string styleSuite = styleSuiteOpenNotTested;
                if (ts.enStatus == TestSuiteStatuses.Passed) {
                    pgfSuite = pgfSuiteOpenPassed;
                    styleSuite = styleSuiteOpenPassed;
                }
                if (ts.enStatus == TestSuiteStatuses.Failed) {
                    pgfSuite = pgfSuiteOpenFailed;
                    styleSuite = styleSuiteOpenFailed;
                }
                resultHTML +=
                    newLineCS +
                    styleSuite +
                    liOpen +
                    headerSuiteOpen +
                    ts.Id +
                    space +
                    ts.Name + 
                    space +
                    ts.Status + 
                    headerSuiteClose;
                
                // statistics
                resultHTML +=
                    //liOpen +
                    //pgfSuite + 
                    // 20130322
                    //getStatisticsStringSuite(ts); // +
                    getStatisticsStringSuite(ts, skipAutomatic);
                    //pgfClose;

                globalLinkId++;
                resultHTML += 
                    newLineCS + 
                    tabTestSuite2 + 
                    ulOpen;

                // description
                string descriptionSuite = "Expand";
                try{
                    if (ts.Description != string.Empty && 
                        ts.Description.Length > 0) {
                        descriptionSuite = ts.Description;
                    }
                }
                catch {}
                resultHTML +=
                    descriptionSuite;
                resultHTML += ulOpenAfterDescription;
                
                foreach (TestScenario tsc in ts.TestScenarios) {
                    WriteVerbose(this, "Test Scenario: " + tsc.Name);
                    string pgfScenario = pgfScenarioOpenNotTested;
                    string styleScenario = styleScenarioOpenNotTested;
                    if (tsc.enStatus == TestScenarioStatuses.Passed) {
                        pgfScenario = pgfScenarioOpenPassed;
                        styleScenario = styleScenarioOpenPassed;
                    }
                    if (tsc.enStatus == TestScenarioStatuses.Failed) {
                        pgfScenario = pgfScenarioOpenFailed;
                        styleScenario = styleScenarioOpenFailed;
                    }
                    resultHTML +=
                        newLineCS +
                        tabTestScenario +
                        styleScenario +
                        liOpen +
                        headerScenarioOpen +
                        tsc.Id +
                        space +
                        tsc.Name + 
                        space + 
                        tsc.Status + 
                        headerScenarioClose;
                    
                    // statistics
                    resultHTML +=
                        getStatisticsStringScenario(tsc, skipAutomatic);
                    
                    globalLinkId++;
                    resultHTML +=
                        newLineCS +
                        tabTestScenario2 +
                        ulOpen;
                    
                    // description
                    string descriptionScenario = "Expand";
                    try{
                        if (tsc.Description != string.Empty && 
                            tsc.Description.Length > 0) {
                            descriptionScenario = tsc.Description;
                        }
                    }
                    catch {}
                    resultHTML +=
                        descriptionScenario;
                    resultHTML += ulOpenAfterDescription;
                    
                if (fullReport) {
                    foreach (TestResult tr in tsc.TestResults) {
                        WriteVerbose(this, "Test Result: " + tr.Name);
                        string pgfTestResult = pgfTestResultOpenNotTested;
                        string styleTestResult = styleTestResultOpenNotTested;
                        if (tr.enStatus == TestResultStatuses.Passed) {
                            pgfTestResult = pgfTestResultOpenPassed;
                            styleTestResult = styleTestResultOpenPassed;
                        }
                        if (tr.enStatus == TestResultStatuses.Failed) {
                            pgfTestResult = pgfTestResultOpenFailed;
                            styleTestResult = styleTestResultOpenFailed;
                        }
                        if (tr.enStatus == TestResultStatuses.KnownIssue) {
                            pgfTestResult = pgfTestResultOpenKnownIssue;
                            styleTestResult = styleTestResultOpenKnownIssue;
                        }
                        // 20130322
                        if (skipAutomatic) {
                            if (TestResultOrigins.Automatic == tr.Origin) {
                                continue;
                            }
                        }
                        resultHTML +=
                            newLineCS +
                            tabTestResult +
                            styleTestResult +
                            liOpen +
                            tr.Id +
                            space +
                            tr.Name + 
                            space +
                            tr.Status;

                        // statistics
                        resultHTML +=
                            getStatisticsStringTestResult(tr);
                        
                        globalLinkId++;
                        resultHTML +=
                            newLineCS +
                            tabTestResult2 +
                            ulOpen;
                        
                        // description
                        string descriptionTestResult = "Expand";
                        try{
                            if (tr.Description != string.Empty && 
                                tr.Description.Length > 0) {
                                descriptionTestResult = tr.Description;
                            }
                        }
                        catch {}
                        resultHTML +=
                            descriptionTestResult;
                        resultHTML += ulOpenAfterDescription;
                        
                        // test result detail collection
                        foreach (TestResultDetail td in tr.Details) {
                            WriteVerbose(
                                this,
                                "Test Result Detail: " + 
                                td.Name + 
                                "\t" + 
                                td.DetailType.ToString());
                            resultHTML +=
                                newLineCS +
                                tabTestResultDetail +
                                liOpen;
                            switch (td.DetailType) {
                                case TestResultDetailTypes.Comment:
                                    resultHTML +=
                                        td.TextDetail;
                                    break;
                                case TestResultDetailTypes.ErrorRecord:
                                    resultHTML +=
                                        td.ErrorDetail.ErrorDetails;
                                    break;
                                case TestResultDetailTypes.Screenshot:
                                    string fileName = 
                                        td.ScreenshotDetail.Substring(
                                            td.ScreenshotDetail.LastIndexOf('\\') + 1);
                                    WriteVerbose(this, fileName);
                                    resultHTML +=
                                        aOpen +
                                        td.ScreenshotDetail +
                                        aMid + 
                                        fileName + 
                                        aClose;
                                    break;
                                default:
                                    resultHTML +=
                                        td.Name;
                                    break;
                            }
                            resultHTML +=
                                liClose;
                        }
                        
                        // test result code
                        if (tr.Code != null && 
                            tr.Code != string.Empty && 
                            tr.Code.Length > 0){
                            resultHTML +=
                                newLineCS + 
                                tabTestResult3 +
                                liOpen;
                            resultHTML +=
                                tr.Code.Replace(newLineCS, newLineHTML);
                            resultHTML +=
                                newLineCS +
                                tabTestResult3 +
                                liClose;
                        }
                        
                        // test result
                        resultHTML +=
                            newLineCS +
                            tabTestResult2 +
                            ulClose;
                        resultHTML +=
                            newLineCS +
                            tabTestResult +
                            liClose +
                            styleTestResultClose;
                    }
                } // full report
                    resultHTML +=
                        newLineCS +
                        tabTestScenario2 +
                        ulClose;
                    resultHTML +=
                        newLineCS +
                        tabTestScenario +
                        liClose +
                        styleScenarioClose;
                }
                resultHTML +=
                    newLineCS +
                    tabTestSuite2 +
                    ulClose;
                resultHTML += 
                    newLineCS +
                    liClose +
                    styleSuiteClose;
            }
            
            // document structure bottom
            resultHTML += newLineCS;
            resultHTML += styleGlobalClose;
            resultHTML += newLineCS;
            resultHTML += bodyClose;
            resultHTML += newLineCS;
            resultHTML += htmlClose;
            
            // document structure top
            resultHTML = 
                generateDocumentStructureTop() +
                resultHTML;
            
            // create an HTML file
            string reportFileName = string.Empty;
            string generatedFileName = string.Empty;
            WriteVerbose(this, "deciding on which path to use for the report");
            generatedFileName =
                System.Environment.GetEnvironmentVariable(
                    "TEMP",
                    EnvironmentVariableTarget.User);
            generatedFileName += @"\";
            generatedFileName +=
                "test_report.htm";
            
            if (path != string.Empty) {
                reportFileName = 
                    path;
                WriteVerbose(this, reportFileName);
            } else {
                reportFileName = generatedFileName;
                WriteVerbose(this, reportFileName);
            }
            
            // write the report
            System.IO.StreamWriter writer = null;
            try{
                WriteVerbose(
                    this,
                    "writing report to " +
                    reportFileName);
                writer =
                    new System.IO.StreamWriter(reportFileName);
                writer.WriteLine(resultHTML);
                writer.Flush();
                writer.Close();
            }
            catch (Exception eee) {
                try{
                    writer = 
                        new System.IO.StreamWriter(generatedFileName);
                    writer.WriteLine(resultHTML);
                    writer.Flush();
                    writer.Close();
                    return;
                }
                catch (Exception ee) {
                    ErrorRecord err = 
                        new ErrorRecord(
                            new Exception("Unable to create the report file: " +
                                          reportFileName),
                            "CantCreateReportFile",
                            ErrorCategory.InvalidArgument,
                            writer);
                    err.ErrorDetails = 
                        new ErrorDetails(
                            "Unable to create the report file: " +
                            generatedFileName + 
                            "\r\n" + 
                            ee.Message);
                    ThrowTerminatingError(err);
                }
                ErrorRecord err2 = 
                    new ErrorRecord(
                        new Exception("Unable to create the report file: " +
                                      reportFileName),
                        "CantCreateReportFile",
                        ErrorCategory.InvalidArgument,
                        writer);
                err2.ErrorDetails = 
                    new ErrorDetails(
                        "Unable to create the report file: " +
                        reportFileName + 
                        "\r\n" +
                        eee.Message);
                ThrowTerminatingError(err2);
            }
        }
        
        // 20130322
        //protected internal void ExportResultsToHTML(string path)
        protected internal void ExportResultsToHTML(ImportExportCmdletBase cmdlet, string path)
        {
            // 20130322
            //ExportToHTML(path, true);
            ExportToHTML(path, true, cmdlet.ExcludeAutomatic);
        }
        
        protected internal void ExportResultsToCSV(string path)
        {
            this.notImplementedCase();
        }
        
        protected internal void ExportResultsToTEXT(string path)
        {
            this.notImplementedCase();
        }
        
        protected internal void ExportResultsToZIP(string path)
        {
            this.notImplementedCase();
        }
        
        protected internal void ExportSummaryToHTML(ImportExportCmdletBase cmdlet, string path)
        {
            // 20130322
            //ExportToHTML(path, false);
            ExportToHTML(path, false, cmdlet.ExcludeAutomatic);
        }
        
        protected internal void ExportSummaryToCSV(string path)
        {
            this.notImplementedCase();
        }
        
        protected internal void ExportSummaryToTEXT(string path)
        {
            this.notImplementedCase();
        }
        
        protected internal void ExportSummaryToZIP(string path)
        {
            this.notImplementedCase();
        }
        
        protected internal void ExportLogToHTML(string path)
        {
            this.notImplementedCase();
        }
        
        protected internal void ExportLogToCSV(string path)
        {
            this.notImplementedCase();
        }
        
        protected internal void ExportLogToTEXT(string path)
        {
            this.notImplementedCase();
        }
        
        protected internal void ExportLogToZIP(string path)
        {
            this.notImplementedCase();
        }
        
        private string generateDocumentStructureTop()
        {
            string resultHTML = string.Empty;
            // document structure
            resultHTML += docType;
            resultHTML += newLineCS;
            resultHTML += htmlOpen;
            resultHTML += newLineCS;
            resultHTML += headOpen;
            resultHTML += newLineCS;
            resultHTML += titleOpen;
            resultHTML += newLineCS;
            resultHTML += "Test results";
            resultHTML += newLineCS;
            resultHTML += titleClose;
            resultHTML += newLineCS;
            
            // styles
            resultHTML += styleExpand;
            resultHTML += newLineCS;
            resultHTML += styleGlobal;
            resultHTML += newLineCS;
            
            //
            resultHTML += styleLink;
            resultHTML += newLineCS;
            //
            
            resultHTML += styleOverallStat;
            resultHTML += newLineCS;
            resultHTML += styleSuite;
            resultHTML += newLineCS;
            resultHTML += styleSuiteStat;
            resultHTML += newLineCS;
            resultHTML += styleSuiteDescription;
            resultHTML += newLineCS;
            resultHTML += styleScenario;
            resultHTML += newLineCS;
            resultHTML += styleScenarioStat;
            resultHTML += newLineCS;
            resultHTML += styleScenarioDescription;
            resultHTML += newLineCS;
            resultHTML += styleTestResult;
            resultHTML += newLineCS;
            resultHTML += styleTestResultStat;
            resultHTML += newLineCS;
            resultHTML += styleTestResultDescription;
            resultHTML += newLineCS;
            resultHTML += styleTestResultDetail;
            resultHTML += newLineCS;
            resultHTML += stylePassed;
            resultHTML += newLineCS;
            resultHTML += styleFailed;
            resultHTML += newLineCS;
            resultHTML += styleKnownIssue;
            resultHTML += newLineCS;
            resultHTML += styleNotTested;
            resultHTML += newLineCS;
            
            // close the head
            resultHTML += headClose;
            resultHTML += newLineCS;
            resultHTML += bodyOpen;
            resultHTML += newLineCS;
            resultHTML += headerTitleOpen;
            resultHTML += "Test results ";
            resultHTML +=  System.DateTime.Now.ToShortDateString();
            resultHTML += " ";
            resultHTML +=  System.DateTime.Now.ToShortTimeString();
            resultHTML += headerTitleClose;
            resultHTML += newLineCS;
            resultHTML += getStatisticsStringOverall();
            resultHTML += styleGlobalOpen;
            resultHTML += newLineCS;
            return resultHTML;
        }

        private string getStatisticsStringTestResult(TestResult testResult)
        {
            string result = string.Empty;
            result += @"<div id=""testresultstat"">Time spent:";
            result += Convert.ToInt32(testResult.TimeSpent).ToString();
            result += @" seconds</div>";
            return result;
        }
        
        private string getStatisticsStringScenario(TestScenario scenario, bool skipAutomatic)
        {
            string result = string.Empty;
            // 20130322
            //TestData.RefreshScenarioStatistics(scenario);
            TestData.RefreshScenarioStatistics(scenario, skipAutomatic);
            result += @"<div id=""scenariostat"">";
            
            // test results
            result += @"Test cases:";
            result += scenario.Statistics.All.ToString();
            result += "  Passed:";
            result += scenario.Statistics.Passed.ToString();
            result += "  Failed:";
            result += scenario.Statistics.Failed.ToString();
            result += "  Not tested:";
            result += scenario.Statistics.NotTested.ToString();
            result += "  Time spent:";
            result += Convert.ToInt32(scenario.Statistics.TimeSpent).ToString();
            result += @" seconds</div>";
            return result;
        }
        
        private string getStatisticsStringSuite(TestSuite suite, bool skipAutomatic)
        {
            string result = string.Empty;
            TestData.RefreshSuiteStatistics(suite, skipAutomatic);
            result += @"<div id=""suitestat"">";
            
            int scPassed = 0;
            int scFailed = 0;
            int scNotTested = 0;
            foreach (TestScenario tsc in suite.TestScenarios) {
                switch (tsc.enStatus) {
                    case TestScenarioStatuses.Passed:
                        scPassed++;
                        break;
                    case TestScenarioStatuses.Failed:
                        scFailed++;
                        break;
                    case TestScenarioStatuses.NotTested:
                        scNotTested++;
                        break;
                    default:
                        throw new Exception("Invalid value for TestScenarioStatuses");
                }
            }
            
            // scenarios
            result += @"Scenarios:";
            result += suite.TestScenarios.Count.ToString();
            result += "  Passed:";
            result += scPassed.ToString();
            result += "  Failed:";
            result += scFailed.ToString();
            result += "  Not tested:";
            result += scNotTested.ToString();
            result += newLineHTML;
            
            // test results
            result += @"Test cases:";
            result += suite.Statistics.All.ToString();
            result += "  Passed:";
            result += suite.Statistics.Passed.ToString();
            result += "  Failed:";
            result += suite.Statistics.Failed.ToString();
            result += "  Not tested:";
            result += suite.Statistics.NotTested.ToString();
            result += "  Time spent:";
            result += Convert.ToInt32(suite.Statistics.TimeSpent).ToString();
            result += @" seconds</div>";
            return result;
        }
        
        private string getStatisticsStringOverall()
        {
            string result = string.Empty;
            TestStat ts = new TestStat();
            
            int suPassed = 0;
            int suFailed = 0;
            int suNotTested = 0;
            int scPassed = 0;
            int scFailed = 0;
            int scNotTested = 0;
            
            foreach (TestSuite tsuite in TestData.TestSuites) {
                ts.All += tsuite.Statistics.All;
                ts.Passed += tsuite.Statistics.Passed;
                ts.Failed += tsuite.Statistics.Failed;
                ts.NotTested += tsuite.Statistics.NotTested;
                ts.TimeSpent += tsuite.Statistics.TimeSpent;
                ts.PassedButWithBadSmell += tsuite.Statistics.PassedButWithBadSmell;
                
                switch (tsuite.enStatus) {
                    case TestSuiteStatuses.Passed:
                        suPassed++;
                        break;
                    case TestSuiteStatuses.Failed:
                        suFailed++;
                        break;
                    case TestSuiteStatuses.NotTested:
                        suNotTested++;
                        break;
                    default:
                        throw new Exception("Invalid value for TestSuiteStatuses");
                }
                
                foreach (TestScenario tsc in tsuite.TestScenarios) {
                    switch (tsc.enStatus) {
                        case TestScenarioStatuses.Passed:
                            scPassed++;
                            break;
                        case TestScenarioStatuses.Failed:
                            scFailed++;
                            break;
                        case TestScenarioStatuses.NotTested:
                            scNotTested++;
                            break;
                        default:
                            throw new Exception("Invalid value for TestScenarioStatuses");
                    }
                }
            }
            
            result += @"<div id=""overallstat"">";
            
            // suites
            result += @"Suites:";
            result += (suPassed + suFailed + suNotTested).ToString();
            result += "  Passed:";
            result += suPassed.ToString();
            result += "  Failed:";
            result += suFailed.ToString();
            result += "  Not tested:";
            result += suNotTested.ToString();
            result += newLineHTML;
            
            // scenarios
            result += @"Scenarios:";
            result += (scPassed + scFailed + scNotTested).ToString();
            result += "  Passed:";
            result += scPassed.ToString();
            result += "  Failed:";
            result += scFailed.ToString();
            result += "  Not tested:";
            result += scNotTested.ToString();
            result += newLineHTML;
            
            // test results
            result += @"Test cases:";
            result += ts.All.ToString();
            result += "  Passed:";
            result += ts.Passed.ToString();
            result += "  Failed:";
            result += ts.Failed.ToString();
            result += "  Not tested:";
            result += ts.NotTested.ToString();
            result += "  Time spent:";
            result += Convert.ToInt32(ts.TimeSpent).ToString();
            result += @" seconds";
            
            if (ts.PassedButWithBadSmell > 0){
                result += newLineHTML;
                
                // bad smell test resutls
                result += ts.PassedButWithBadSmell.ToString();
                result += @" cases of non-critical issues are counted as Passed";
            }
            
            result += @"</div>";
            
            return result;
        }
    }
}
