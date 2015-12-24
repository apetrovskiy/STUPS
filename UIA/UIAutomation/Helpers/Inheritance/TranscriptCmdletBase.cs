/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/2/2011
 * Time: 5:55 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;
    using System.Management.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Description of TranscriptCmdletBase.
    /// </summary>
    public class TranscriptCmdletBase : HasTimeoutCmdletBase
    {
        #region Constructor
        public TranscriptCmdletBase()
        {
            WriteCurrentPattern = true; // false; // 201020613
            NoClassInformation = false;
            NoScriptHeader = true; //false;
            NoEvents = false;
            NoUI = true; //false;
            Paused = false;
        }
        #endregion Constructor

        #region Parameters
        [UiaParameter][Parameter(Mandatory = false)]
        internal new SwitchParameter PassThru { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false)]
        public SwitchParameter WriteCurrentPattern { get; set; }
        [UiaParameter][Parameter(Mandatory = false)]
        public SwitchParameter NoClassInformation { get; set; }
        [UiaParameter][Parameter(Mandatory = false)]
        public SwitchParameter NoEvents { get; set; }
        [UiaParameter][Parameter(Mandatory = false)]
        public SwitchParameter NoScriptHeader { get; set; }
        [UiaParameter][Parameter(Mandatory = false)]
        public SwitchParameter NoUI { get; set; }
        #endregion Parameters
        
        internal bool Paused { get; set; }
        
        public List<string> LastRecordedItem =
            new List<string>();

        // the list of all recorded controls' patterns
        public ArrayList RecordingPatterns = 
            new ArrayList();
        
        protected internal IUiElement thePreviouslyUsedElement = null;
        
        internal new void StopProcessing()
        {
            Global.GTranscript = false;
            //EndProcessing(); // 20120601
        }
        
        public string WritingRecord(
            List<string> recordingItemCode,
            object recordingItemPatterns,
            StreamWriter writerToLongFile,
            StreamWriter writerToShortFile)
        {
            string result = string.Empty;
            try {
                List<string> recordList = recordingItemCode;
                
                string longRecordingString = String.Empty;
                string shortRecordingString = String.Empty;
                string tempString = String.Empty;
                for (int i = (recordList.Count - 1); i  >= 0; i--) {
                    tempString = String.Empty;
                    tempString += recordList[i];
                    if (i < (recordList.Count - 1)) {
                        if (tempString.Contains("Get-UiaWindow")) {
                            tempString = 
                                tempString.Replace("Get-UiaWindow",
                                                      "Get-UiaChildWindow");
                        }
                        // if the second or further in the pipeline
                        tempString = 
                            "\t" + tempString;
                    }
                    longRecordingString += tempString;
                    if (i > 0) {
                        // all but the last in the pipeline
                        longRecordingString += " | `\r\n";
                    } else {
                        // the last in the pipeline
                        longRecordingString += ";";
                    }
                    if (i != (recordList.Count - 1) && i != 0 && !tempString.Contains("Get-UiaChildWindow") && i != 1 &&
                        !tempString.Contains("Tree") && !tempString.Contains("Menu") && !tempString.Contains("Tool") &&
                        !tempString.Contains("Tab") && !tempString.Contains("Table") && !tempString.Contains("List") &&
                        !tempString.Contains("Grid") && !tempString.Contains("Button") && !tempString.Contains("Combo"))
                        continue;
                    shortRecordingString += tempString;
                    if (i > 0) {
                        // all but the last in the pipeline
                        shortRecordingString += " | `\r\n";
                    } else {
                        // the last in the pipeline
                        shortRecordingString += ";";
                    }

                    /*
                    if (i == (recordList.Count - 1) ||
                        i == 0 || // the last element or invoked event
                        tempString.Contains("Get-UiaChildWindow") ||
                        i == 1 || //) // the last element in case of having invoked event
                        tempString.Contains("Tree") ||
                        tempString.Contains("Menu") ||
                        tempString.Contains("Tool") ||
                        // tempString.Contains("Tab") || // also Table
                        tempString.Contains("Tab") ||
                        tempString.Contains("Table") ||
                        tempString.Contains("List") ||
                        tempString.Contains("Grid") ||
                        tempString.Contains("Button") ||
                        tempString.Contains("Combo"))
                    {
                        shortRecordingString += tempString;
                        if (i > 0) {
                            // all but the last in the pipeline
                            shortRecordingString += " | `\r\n";
                        } else {
                            // the last in the pipeline
                            shortRecordingString += ";";
                        }
                    }
                    */
                }
                if (WriteCurrentPattern) {
                    try {
                        longRecordingString +=
                            recordingItemPatterns;
                        shortRecordingString +=
                            recordingItemPatterns;
                        }
                    catch (Exception eWritingPattern) {
                        //throw (eWritingPattern);
                        Exception eWritingPattern2 = 
                            new Exception(
                                "Adding stings with patterns\r\n" + 
                                eWritingPattern.Message);
                        throw (eWritingPattern2);
                    }
                }
                result = longRecordingString;
                if (writerToLongFile != null && writerToShortFile != null) {
                    writerToLongFile.WriteLine(longRecordingString); writerToLongFile.Flush();
                    writerToShortFile.WriteLine(shortRecordingString); writerToShortFile.Flush();
                }
            } 
            catch (Exception eBuildingRecordingString) {
                WriteDebug(eBuildingRecordingString.Message);
                //throw (eBuildingRecordingString);
                Exception eBuildingRecordingString2 = 
                    new Exception(
                        "Building record strings\r\n" + 
                        eBuildingRecordingString.Message);
                throw (eBuildingRecordingString2);
            }
            return result;
        }
    }
}
