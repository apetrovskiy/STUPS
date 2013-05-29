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
    [Cmdlet(VerbsCommon.Get, "UIAWindow", DefaultParameterSetName = "UIA")]
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

        protected bool TestMode { get; set; }
//        // 20130529
//        protected bool WaitNoWindow { get; set; }
        
        protected override void BeginProcessing()
        {
            StartDate = System.DateTime.Now;
            
            // 20130314
            CurrentData.SetCurrentWindow(null);
        }
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            this.CheckCmdletParameters();
            
            WriteVerbose(this, "Input parameters:");
            WriteVerbose(this, "ProcessName = " + this.ProcessName);
            WriteVerbose(this, "ProcessId = " + this.ProcessId);
            WriteVerbose(this, "Name = " + this.Name);
            // 20130316
            WriteVerbose(this, "AutomationId = " + this.AutomationId);
            WriteVerbose(this, "Class = " + this.Class);
            WriteVerbose(this, "Recurse = " + this.Recurse.ToString());
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
                // 20130513
                //GetWindow(this, this.InputObject, this.ProcessName, this.ProcessId, this.Name, this.AutomationId, this.Class, this.TestMode); //, this.SearchCriteria, this.WithControl);
                GetWindow(this, this.Win32, this.InputObject, this.ProcessName, this.ProcessId, this.Name, this.AutomationId, this.Class, this.TestMode); //, this.SearchCriteria, this.WithControl);
            
            if (null != _returnedWindows && _returnedWindows.Count > 0) {

#region commented
//                ArrayList filteredWindows = 
//                    new ArrayList();
//                if (null != this.SearchCriteria && this.SearchCriteria.Length > 0) {
//                    filteredWindows = 
//                        getFiltredElementsCollection(this, _returnedWindows);
//                    
//                    if (this.TestMode && null != filteredWindows && 0 < filteredWindows.Count) {
//                        
//                        this.WriteObject(this, true);
//                    } else {
//                        
//                        this.WriteObject(this, filteredWindows);
//                    }
//                } else {
//                    
//                    if (this.TestMode && null != _returnedWindows && 0 < _returnedWindows.Count) {
//                        
//                        this.WriteObject(this, true);
//                    } else {
//                        
//                        this.WriteObject(this, _returnedWindows);
//                    }
//                }
//                
//                // 20130228
//                if (null != this.WithControl && 0 < this.WithControl.Length) {
//                    
//                    
//                }
#endregion commented
      
#region commented
//                if (null != this.SearchCriteria && 0 < this.SearchCriteria.Length) {
//                    
//                    _returnedWindows =
//                        getFiltredElementsCollection(
//                            this,
//                            _returnedWindows);
//                }
//                
//                if (null != this.WithControl && 0 < this.WithControl.Length) {
//                    
//                    ArrayList filteredWindows =
//                        new ArrayList();
//    
//                    foreach (AutomationElement window in _returnedWindows) {
//                        
//                        GetUIAControlCommand cmdlet =
//                            new GetUIAControlCommand();
//                        cmdlet.SearchCriteria = this.WithControl;
//                        
//                        ArrayList controlsList =
//                            getControl(cmdlet);
//                        
//                        if (null != controlsList && 0 < controlsList.Count) {
//                            filteredWindows.Add(window);
//                        }
//                    }
//                    
//                    _returnedWindows = filteredWindows;
//                }
//                
//                if (null != _returnedWindows && 0 < _returnedWindows.Count) {
#endregion commented

                    if (this.TestMode) {
                        
                        // 20130529
                        //this.WriteObject(this, true);
                        if (this.WaitNoWindow) {
                            this.WriteObject(this, false);
                        } else {
                            this.WriteObject(this, true);
                        }
                        
                    } else {
                        this.WriteObject(this, _returnedWindows);
                    }
//                }
                
            } else {
                
                if (this.TestMode) {
                    
                    // 20130529
                    // this.WriteObject(this, false);
                    if (this.WaitNoWindow) {
                        this.WriteObject(this, true);
                    } else {
                        this.WriteObject(this, false);
                    }
    
                } else {
                
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
    
                    this.WriteError(
                        this,
                        "Failed to get the window by:" + 
                        " process name: '" +
                        procName +
                        "', process Id: " + 
                        procId + 
                        ", window title: '" + 
                        name +
                        // 20130316
                        //"'",
                        "', automationId: '" +
                        this.AutomationId +
                        "', className: '" +
                        this.Class +
                        ",",
                        "FailedToGetWindow",
                        ErrorCategory.InvalidResult,
                        true);
                }
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
