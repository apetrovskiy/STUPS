/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 29.11.2011
 * Time: 4:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    
    using System.Windows.Automation;
    using System.Collections;

    /// <summary>
    /// Description of GetUIAWindow.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAWindow")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAWindowCommand : GetWindowCmdletBase
    {
        
        #region Constructor
        public GetUIAWindowCommand()
        {
            //WriteVerbose(this, "constructor");
        }
        #endregion Constructor

        #region Parameters
        #endregion Parameters

        protected override void BeginProcessing()
        {
            startDate = System.DateTime.Now;
        }
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            WriteVerbose(this, "Input parameters:");
            WriteVerbose(this, "ProcessName = " + this.ProcessName);
            WriteVerbose(this, "ProcessId = " + this.ProcessId);
            // 20120824
            //try{WriteVerbose(this, "Process = " + this.InputObject.ProcessName);} 
            //try{WriteVerbose(this, "Process = " + this.InputObject[0].ProcessName);}
            //catch {}
            WriteVerbose(this, "Name = " + this.Name);
            WriteVerbose(this, "Timeout " + this.Timeout.ToString());
            
            //startDate = System.DateTime.Now;
            
            // 20120824
            //System.Windows.Automation.AutomationElement _returnedWindow = null;
            ArrayList _returnedWindows = new ArrayList();
            //WriteVerbose(this, "002");
            
            try {
                // if (this.ProcessName == "" && this.Title == "") 
                // 20120824
                //if (this.ProcessName == string.Empty && 
                if (null == this.ProcessName && //0 == this.ProcessName.Length) &&
                    // 20120824
                    //this.Name == string.Empty &&
                    // 20130220
                    //null == this.Name && //0 == this.Name.Length) &&
                    (null == this.Name && null == this.AutomationId && null == this.Class) &&
                    // 20120824
                    //(this.InputObject as System.Diagnostics.Process) == null &&
                    //null == (this.InputObject[0] as System.Diagnostics.Process) &&
                    null == this.ProcessId &&
                    null == this.InputObject) { // &&
                    // 20120824
                    //this.ProcessId == 0)
                    //0 == this.ProcessId[0]) {
                // 20120824
                //{
                    WriteVerbose(
                        this, 
                        //"this.ProcessName == string.Empty && this.Name == string.Empty && this.Process == null && this.ProcessId == 0");
                        "no processName, name, processid or process was supplied");
                    //WriteObject(this, _returnedWindow);
                    
                    // 20120927
//                    //UIAHelper.GetDesktopScreenshot(this, CmdletName(this) + "_ProcessNameEqNullAndTitleEqNull", true, 0, 0, 0, 0, string.Empty);
//                    // return;
//                    ErrorRecord err = 
//                        new ErrorRecord(
//                            new Exception("Neither ProcessName nor window Name are provided. Or ProcessId == 0"),
//                            "NoParametersInGetWindow",
//                            ErrorCategory.InvalidArgument,
//                            this);
//                    err.ErrorDetails = 
//                        new ErrorDetails(
//                            "Neither ProcessName nor window Name are provided. Or ProcessId == 0");
//                    WriteError(this, err, true);
                    
                    this.WriteError(
                        this,
                        "Neither ProcessName nor window Name are provided. Or ProcessId == 0",
                        "NoParametersInGetWindow",
                        ErrorCategory.InvalidArgument,
                        true);
                    
                    //return; //// ????????????????
                } // describe
//                WriteVerbose(
//                    this, 
//                    "timeout countdown started for process: " +
//                    this.ProcessName + ", name: " + this.Name);
//                             // this.ProcessName + ", title: " + this.Title);
            } 
            catch (Exception eCheckParameters) {
                
                WriteVerbose(this, eCheckParameters.Message);
                //WriteObject(this, _returnedWindow);
                
                // 20120927
//                UIAHelper.GetScreenshotOfAutomationElement(this, CmdletName(this) + "_BeginProcessing", true, 0, 0, 0, 0, string.Empty, System.Drawing.Imaging.ImageFormat.Jpeg);
//                
                
                this.WriteError(
                    this,
                    "Unknown error in '" + CmdletName(this) + "' ProcessRecord",
                    "UnknownInGetWindow",
                    ErrorCategory.InvalidResult,
                    true);
                
                //return; //// ????????????????
            } // describe
            
            //System.Windows.Automation.AutomationElement _returnedWindow = 
            // 20120824
            //_returnedWindow =
            _returnedWindows =
                GetWindow(this, this.InputObject, this.ProcessName, this.ProcessId, this.Name, this.AutomationId, this.Class);
            
                // GetWindow(this.ProcessName, this.Title);
            // 20120824
            //if (_returnedWindow != null) {
            if (null != _returnedWindows && _returnedWindows.Count > 0) {
                
                // 20120824
                //WriteObject(this, _returnedWindow);
                
                // 20120828
                ArrayList filteredWindows = 
                    new ArrayList();
                if (null != this.SearchCriteria && this.SearchCriteria.Length > 0) {
                    filteredWindows = 
                        getFiltredElementsCollection(this, _returnedWindows);
                    WriteObject(this, filteredWindows);
                } else {
                    WriteObject(this, _returnedWindows);
                }
            } else {
                
                ErrorRecord err = 
                    new ErrorRecord(
                        new Exception("Failed to get the window"),
                        "FailedToGetWindow",
                        ErrorCategory.InvalidResult,
                        // 20120824
                        //_returnedWindow);
                        _returnedWindows.ToString());
                
                //WriteVerbose(this, "012");
                
                // 20120824
                string name = string.Empty;
                string procName = string.Empty;
                string procId = string.Empty;
                // 20120824
                try{ 
                    foreach(string n in this.Name) { 
                        name += n; name += ","; 
                    }
                    name = name.Substring(0, name.Length - 1);
                }
                catch {}
                // 20120824
                //try{ procName = this.ProcessName; }
                //catch {}
                try{ 
                    foreach(string s in this.ProcessName) { 
                        procName += s; procName += ","; 
                    }
                    procName = procName.Substring(0, procName.Length - 1);
                }
                catch {}
                // 20120824
                //try{ procId = this.ProcessId.ToString(); }
                try {
                    foreach (int i in this.ProcessId) {
                        procId += i.ToString();
                        procId += ",";
                    }
                    procId = procId.Substring(0, procId.Length - 1);
                }
                catch {}
                // 20120824
                //try{ if (procName.Length == 0) { procName = this.InputObject.ProcessName; } }
                //catch {}
                // 20120824
                //try{ if (procId.Length == 0 || procId == "0") { procId = this.InputObject.Id.ToString(); } }
                //catch {}
                err.ErrorDetails = 
                    new ErrorDetails(
                        "Failed to get the window by:" + 
                        " process name: '" +
                        procName +
                        "' process Id: " + 
                        procId + 
                        " window title: '" + 
                        name +
                        "'");
                        
                WriteError(this, err, true);
            }
        }
        
        protected override void EndProcessing()
        {
            // 20120206 aeForm = null;
            rootElement = null;
        }
        
//        protected override void StopProcessing()
//        {
//            // 20120620
//            WriteVerbose(this, "User interrupted");
//            this.Wait = false;
//        }
        
    }
}
