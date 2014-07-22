/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/3/2012
 * Time: 2:52 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PSTestRunner
{
    using System;
    using PSRunner;
    using System.Management.Automation;
	using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of TestRunner.
    /// </summary>
    public static class TestRunner
    {
        public static string ScriptPath { get; set; }
        public static string ScriptParameters { get; set; }
        public static System.IO.StreamWriter testLogWriter = null;
        
        public static bool InitScript()
        {
            bool result = false;
            
            string currDir = Environment.CurrentDirectory;

            // load the binaries and initialization script
            string strUIAutomationPath = 
                @"ipmo '" +
                currDir +
                @"\UIAutomation.dll" +
                @"';" + 
                "\r\n";
            string strTmxPath = 
                @"ipmo '" +
                currDir +
                @"\Tmx.dll" +
                @"';" +
                "\r\n";
            string strInitScriptPath = 
                @"& '" +
                currDir +
                @"\UiaRunner.ps1" +
                @"'";
            try {
                //result = Runner.ResetRunspace();
                result = Runner.CloseRunspace();
                result = true;
            }
            catch (Exception eResetRunspace) {
                //return result; // ?
                throw (eResetRunspace);
            }
            
            try {
                result = 
                    Runner.InitializeRunspace(
                        strUIAutomationPath + 
                        strTmxPath +
                        strInitScriptPath);
            }
            catch (Exception eInitRunspace) {
                //return result;
                throw (eInitRunspace);
            }
            
            return result;
        }
        
//        public static void InitScript2()
//        //public static void InitScript()
//        {
//            bool result = false;
//            
//            string currDir = System.Environment.CurrentDirectory;
//            
//            // load the initialization script
//            string strInitScriptPath = 
//                currDir +
//                @"\UiaRunner.ps1";
//            
//            try {
//                result = Runner.IitializeRunspaceAsync(strInitScriptPath);
//            }
//            catch (Exception eInitRunspace) {
////                System.Windows.Forms.MessageBox.Show(
////                    eInitRunspace.Message,
////                    "Initialize runspace");
//                //return result;
//            }
//            
//            //return result;
//        }
        
        public static bool RunScriptCode() //bool fromCommandLine)
        {
            bool result = false;
            
            // 20120716
            string scriptCode = string.Empty;
            System.IO.StreamReader reader = null;
            try {
                reader = 
                    new System.IO.StreamReader(ScriptPath);
                scriptCode = 
                    reader.ReadToEnd();
                reader.Close();
            }
            catch (Exception eReadingScript) {
                reader.Close();
                throw (eReadingScript);
                //return result;
            }
            
            StartTestLogger();
            
            try {
                // 20120716
                //result = PSRunner.Runner.RunPSScriptAsync(scriptCode);
                result = 
                    PSRunner.Runner.RunPSScriptAsync(
                        //@"powershell.exe -command {" +
                        //"& " +
                        //ScriptPath, // + 
                        scriptCode); //,
                        //" " + 
                        //ScriptParameters //+ 
                        //"}"
                        //);
            }
            catch (Exception eRunPSCode) {
                //System.Windows.Forms.MessageBox.Show(eRunPSCode.Message);
//                System.Windows.Forms.MessageBox.Show(
//                    eRunPSCode.Message,
//                    "Run Script");
                StopTestLogger();
                //result = false;
                throw (eRunPSCode);
            }
            StopTestLogger();
            return result;
        }
        
        public static bool RunScript() //bool fromCommandLine)
        {
            return RunScript(ScriptPath, false); //fromCommandLine);
        }
        
        public static bool RunScript(string scriptPath, bool fromCommandLine)
        {
            bool result = false;
            
            
            
//            string currDir = System.Environment.CurrentDirectory;
//            
//            // load the initialization script
//            string strInitScriptPath = 
//                currDir +
//                @"\UiaRunner.ps1";
//            
//            try {
//                result = Runner.IitializeRunspace(strInitScriptPath);
//            }
//            catch (Exception eInitRunspace) {
//                System.Windows.Forms.MessageBox.Show(eInitRunspace.Message);
//                return result;
//            }

            //if (fromCommandLine) {
            StartTestLogger();
//                try {
//                    testLogWriter = 
//                        new System.IO.StreamWriter(@".\UiaRunner_report.csv");
//                    string quote = @"""";
//                    string quotesWithComma = @""",""";
//                    
//                    testLogWriter.WriteLine(
//                        quote  +
//                        "Date/Time" + 
//                        quotesWithComma + 
//                        "Status" +
//                        quotesWithComma + 
//                        "Name" +
//                        quotesWithComma + 
//                        "Line" +
//                        quotesWithComma + 
//                        "Pos." +
//                        quotesWithComma + 
//                        "Script" +
//                        quotesWithComma + 
//                        "Screenshot" +
//                        quote);
//                    testLogWriter.Flush();
//                }
//                catch {}
            //}
            
            try {
                //PSRunner.Runner.RunPSCode(scriptPath);
                PSRunner.Runner.RunPSCodeAsync(scriptPath);

            }
            catch (Exception eRunPSCode) {
                System.Windows.Forms.MessageBox.Show(eRunPSCode.Message);
//                System.Windows.Forms.MessageBox.Show(
//                    eRunPSCode.Message,
//                    "Run Script");
                StopTestLogger();
                result = false;
            }
            
            StopTestLogger();
            //if (fromCommandLine) {
//                try {
//                    testLogWriter.Flush();
//                    testLogWriter.Close();
//                    testLogWriter = null;
//                }
//                catch {}
            //}
            
            try {
                result = false;
                result = PSRunner.Runner.CloseRunspace();
                result = true;
            }
            catch (Exception eCloseRunspace) {
//                System.Windows.Forms.MessageBox.Show(
//                    eCloseRunspace.Message,
//                    "Close runspace");
                return result;
            }
            
            return result;
        }
        
        public static void BreakScript()
        {
            PSRunner.Runner.StopScriptAsync();
        }
        
        public static object GetVariable(string variableName)
        {
            return Runner.GetVariable(variableName);
        }
        
        //internal static void SetTestResultsCounters(
        public static void SetTestResultsCounters(
            TestResultTypes type, 
            int count,
            ref int testResultsPassed,
            ref int testResultsFailed,
            ref int testResultsAll,
            System.Windows.Forms.ToolStripStatusLabel passed,
            System.Windows.Forms.ToolStripStatusLabel failed,
            System.Windows.Forms.ToolStripStatusLabel average,
            System.DateTime startTime)
        {
            switch (type) {
                case TestResultTypes.Passed:
                    testResultsPassed += count;
                    if (passed != null) {
                        passed.Text = 
                            testResultsPassed.ToString();
                    }
                    break;
                case TestResultTypes.Failed:
                    testResultsFailed += count;
                    if (failed != null) {
                        failed.Text = 
                            testResultsFailed.ToString();
                    }
                    break;
                case TestResultTypes.NotTested:
                    
                    break;
                case TestResultTypes.PassedWithBadSmell:
                    
                    break;
                default:
                    //throw new Exception("Invalid value for TestResultTypes");case TestResultTypes.Passed:
                    break;
            }
            testResultsAll++;
            string trps = 
               (testResultsAll / (System.DateTime.Now - startTime).TotalSeconds).ToString();
            average.Text = 
                trps.Substring(0, trps.IndexOf(".") + 2) +
                " trps";
        }
        
        //internal static void NewTestResultClosed(object sender, EventArgs e)
        public static void NewTestResultClosed(object sender, EventArgs e)
        {
            WriteTestResultToLog(((ITestResult)sender));
        }
        
        //internal static void WriteTestResultToLog(ITestResult testResult)
        public static void WriteTestResultToLog(ITestResult testResult)
        {
            try {
                string quote = @"""";
                string quotesWithComma = @""",""";
                
                string errorMessage = string.Empty;
                try {
                    if (testResult.Error != null) {
                        errorMessage = 
                            testResult.Error.ErrorDetails.Message;
                    }
                } 
                catch {}
                
                testLogWriter.WriteLine(
                    quote  +
                    testResult.Timestamp + 
                    quotesWithComma + 
                    testResult.Status +
                    quotesWithComma + 
                    testResult.Name +
                    quotesWithComma + 
                    testResult.LineNumber.ToString() +
                    quotesWithComma + 
                    testResult.Position.ToString() +
                    quotesWithComma + 
                    testResult.ScriptName +
                    quotesWithComma + 
                    errorMessage +
                    quotesWithComma + 
                    testResult.Screenshot +
                    quote);
                
                testLogWriter.Flush();
            }
            catch {
                
            }
        }
        
        public static void WriteTestResultToLog(
            string timestamp,
            string testResultStatus,
            object name,
            string lineNumber,
            string position,
            string scriptPath,
            string errorDescription,
            string screenshotPath)
        {
            try {
                string quote = @"""";
                string quotesWithComma = @""",""";
                
//                string errorMessage = string.Empty;
//                try {
//                    if (testResult.Error != null) {
//                        errorMessage = 
//                            testResult.Error.ErrorDetails.Message;
//                    }
//                } 
//                catch {}
                
                testLogWriter.WriteLine(
                    quote  +
                    //testResult.Timestamp + 
                    timestamp +
                    quotesWithComma + 
                    //testResult.Status +
                    testResultStatus +
                    quotesWithComma + 
                    //testResult.Name +
                    name + 
                    quotesWithComma + 
                    //testResult.LineNumber.ToString() +
                    lineNumber +
                    quotesWithComma + 
                    //testResult.Position.ToString() +
                    position +
                    quotesWithComma + 
                    //testResult.ScriptName +
                    scriptPath +
                    quotesWithComma + 
                    //errorMessage +
                    errorDescription +
                    quotesWithComma + 
                    //testResult.Screenshot +
                    screenshotPath +
                    quote);
                
                testLogWriter.Flush();
            }
            catch {
                
            }
        }
        
        private static void StartTestLogger()
        {
            try {
                testLogWriter = 
                    new System.IO.StreamWriter(@".\UiaRunner_report.csv");
                string quote = @"""";
                string quotesWithComma = @""",""";
                
                testLogWriter.WriteLine(
                    quote  +
                    "Date/Time" + 
                    quotesWithComma + 
                    "Status" +
                    quotesWithComma + 
                    "Name" +
                    quotesWithComma + 
                    "Line" +
                    quotesWithComma + 
                    "Pos." +
                    quotesWithComma + 
                    "Script" +
                    quotesWithComma + 
                    "Error" +
                    quotesWithComma + 
                    "Screenshot" +
                    quote);
                testLogWriter.Flush();
            }
            catch {}
        }
        
        private static void StopTestLogger()
        {
            try {
                testLogWriter.Flush();
                testLogWriter.Close();
                testLogWriter = null;
            }
            catch {}
        }
    }
    
    public enum TestResultTypes
    {
        Passed = 1,
        Failed = 2,
        NotTested = 3,
        PassedWithBadSmell = 4
    }
}
