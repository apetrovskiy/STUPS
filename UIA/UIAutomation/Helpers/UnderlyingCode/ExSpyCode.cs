/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/11/2013
 * Time: 12:28 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System.Windows.Automation;
    
    /// <summary>
    /// Description of ExSpyCode.
    /// </summary>
    public static class ExSpyCode
    {
        public static string WritingAvailablePatterns(IUiElement element)
        {
            string resultString = string.Empty;
            
            try {
                resultString = "available patterns";
                resultString += "\r\n";
                
                // 20120618 UiaCOMWrapper
                // 20131209
                // AutomationPattern[] supportedPatterns =
                //     element.GetSupportedPatterns();
                IBasePattern[] supportedPatterns =
                    element.GetSupportedPatterns();
                //UiaCOM::System.Windows.Automation.AutomationPattern[] supportedPatterns =
                //    element.GetSupportedPatterns();                                    

                if (supportedPatterns == null || supportedPatterns.Length <= 0) return resultString;
                for (int i = 0; i < supportedPatterns.Length; i++) {
                    if (i > 0) {
                        resultString += "\r\n";
                    }
                    resultString +=
                        // 20131209
                        // supportedPatterns[i].ProgrammaticName.Replace("Identifiers.Pattern", "");
                        // 20131210
                        // (supportedPatterns[i] as AutomationPattern).ProgrammaticName.Replace("Identifiers.Pattern", "");
                        // (supportedPatterns[i].SourcePattern as AutomationPattern).ProgrammaticName.Replace("Identifiers.Pattern", "");
                        (supportedPatterns[i].SourcePattern as AutomationPattern).ProgrammaticName.Replace("Identifiers.Pattern", string.Empty);
                }

                /*
                if (supportedPatterns != null &&
                    supportedPatterns.Length > 0) {
                    for (int i = 0; i < supportedPatterns.Length; i++) {
                        if (i > 0) {
                            this.richPatterns.Text += "\r\n";
                        }
                        this.richPatterns.Text += 
                            supportedPatterns[i].ProgrammaticName.Replace("Identifiers.Pattern", "");
                    }
                }
                */
               return resultString;
            }
            catch {
                return resultString;
            }
        }
        
        public static TranscriptCmdletBase CreateTranscriptingCmdlet()
        {
            TranscriptCmdletBase cmdlet = 
                new TranscriptCmdletBase
                {
                    NoClassInformation = false,
                    NoScriptHeader = true,
                    NoUI = true,
                    WriteCurrentPattern = true,
                    Timeout = 600000000,
                    Highlight = true,
                    HighlightParent = true,
                    PassThru = false
                };

            Preferences.TranscriptInterval = 500;
            return cmdlet;
        }
        
        public static IUiElement GetElementFromPoint(System.Drawing.Point mousePoint)
        {
            // 20131109
            //AutomatIUiElement element = null;
            IUiElement element = null;
            
            // use Windows forms mouse code instead of WPF
            // 20131114
            //System.Drawing.Point mouse = System.Windows.Forms.Cursor.Position;

            // commented 20120618 to switch to UiaCOMWrapper
            element =
                // 20131109
                //System.Windows.Automation.AutomationElement.FromPoint(
                UiElement.FromPoint(
                    // 20131114
                    //new System.Windows.Point(mouse.X, mouse.Y));
                    new System.Windows.Point(mousePoint.X, mousePoint.Y));
            //element = 
            //	//(UiaNET::System.Windows.Automation.AutomationElement)
            //	UiaCOM3.UiaCOMHelper.GetAutomationElementFromPoint();
            
            return element;
        }
        
//        public static void RunPowerShellCode(string executablePath, spymodes)
//        {
//            bool result = false;
//            try {
//                string initScript = 
//                    @"ipmo '" + 
//                    executablePath.Substring(0, executablePath.LastIndexOf('\\')) +
//                    @"\UIAutomation.dll';" + 
//                    "\r\n" +
//                    @"ipmo '" + 
//                    executablePath.Substring(0, executablePath.LastIndexOf('\\')) +
//                    @"\TMX.dll';";
//                if (SpyModes.seleniumSpy == spyMode) {
//                    initScript +=
//                        "\r\n" +
//                        @"try {" +
//                        @"ipmo '" + 
//                        executablePath.Substring(0, executablePath.LastIndexOf('\\')) +
//                        @"\SePSX.dll'; } catch {}";
//                }
//                result = createRunspace(initScript);
//                if (result) {
//                    string autoInitScript = executablePath.Replace("exe", "ps1");
//                    if (System.IO.File.Exists(autoInitScript)) {
//                        processScript(autoInitScript);
//                    }
//                    processScript(this.codeToRun);
//                }
//                destroyRunspace();
//            }
//            catch {
//                
//            }
//        }

//        public static bool CreateRunspace(string command)
//        {
//            bool result = false;
//            try {
//                testRunSpace = null;
//                testRunSpace = RunspaceFactory.CreateRunspace();
//                testRunSpace.Open();
//                Pipeline cmd = 
//                    testRunSpace.CreatePipeline(command);
//                cmd.Invoke();
//                result = true;
//            } 
//            catch (Exception eInitRunspace) {
//
//                this.richResults.Text += eInitRunspace.Message;
//                this.richResults.Text += "\r\n";
//                result = false;
//            }
//            return result;
//            //Screen.PrimaryScreen.Bounds.Width
//        }
    }
}
