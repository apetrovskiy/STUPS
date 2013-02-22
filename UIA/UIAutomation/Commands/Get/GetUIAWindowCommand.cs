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
            WriteVerbose(this, "Name = " + this.Name);
            WriteVerbose(this, "Timeout " + this.Timeout.ToString());
            
            ArrayList _returnedWindows = new ArrayList();
            
            try {

                if (null == this.ProcessName &&
                    (null == this.Name && null == this.AutomationId && null == this.Class) &&
                    null == this.ProcessId &&
                    null == this.InputObject) { // &&

                    WriteVerbose(
                        this, 
                        "no processName, name, processid or process was supplied");
                    
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

                this.WriteError(
                    this,
                    "Unknown error in '" + CmdletName(this) + "' ProcessRecord",
                    "UnknownInGetWindow",
                    ErrorCategory.InvalidResult,
                    true);
                
                //return; //// ????????????????
            } // describe
            
            _returnedWindows =
                GetWindow(this, this.InputObject, this.ProcessName, this.ProcessId, this.Name, this.AutomationId, this.Class);
            
            if (null != _returnedWindows && _returnedWindows.Count > 0) {

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
                        _returnedWindows.ToString());
                
                string name = string.Empty;
                string procName = string.Empty;
                string procId = string.Empty;

                try{ 
                    foreach(string n in this.Name) { 
                        name += n; name += ","; 
                    }
                    name = name.Substring(0, name.Length - 1);
                }
                catch {}

                try{ 
                    foreach(string s in this.ProcessName) { 
                        procName += s; procName += ","; 
                    }
                    procName = procName.Substring(0, procName.Length - 1);
                }
                catch {}

                try {
                    foreach (int i in this.ProcessId) {
                        procId += i.ToString();
                        procId += ",";
                    }
                    procId = procId.Substring(0, procId.Length - 1);
                }
                catch {}

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
