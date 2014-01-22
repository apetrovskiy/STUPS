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
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of GetUiaWindow.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaWindow", DefaultParameterSetName = "UIA")]
    [OutputType(typeof(UIAutomation.IUiElement[]))] // [OutputType(typeof(object))]
    public class GetUiaWindowCommand : GetWindowCmdletBase
    {
        #region Parameters
        #endregion Parameters

        protected bool TestMode { get; set; }
        
        protected override void BeginProcessing()
        {
            StartDate = DateTime.Now;
            
            CurrentData.SetCurrentWindow(null);
        }
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            CheckCmdletParameters();
            
            try {
            
                // 20140121
            List<IUiElement> returnedWindows = new List<IUiElement>();
            // List<IUiElement> returnedWindows = null;
            
            try {

                if (null == ProcessName &&
                    (null == Name && null == AutomationId && null == Class) &&
                    null == ProcessId &&
                    null == InputObject) {

                    WriteVerbose(
                        this, 
                        "no processName, name, processid or process was supplied");
                    
                    WriteError(
                        this,
                        "Neither ProcessName nor window Name are provided. Or ProcessId == 0",
                        "NoParametersInGetWindow",
                        ErrorCategory.InvalidArgument,
                        true);
                    
                } // describe
            } 
            catch (Exception eCheckParameters) {
                
                WriteVerbose(this, eCheckParameters.Message);

                WriteError(
                    this,
                    "Unknown error in '" + CmdletName(this) + "' ProcessRecord",
                    "UnknownInGetWindow",
                    ErrorCategory.InvalidResult,
                    true);
                
            } // describe
            
            try {
                
                var windowSearch =
                    AutomationFactory.GetSearchImpl<WindowSearch>();
                
                var windowSearchData =
                    new WindowSearchData {
                    Win32 = this.Win32,
                    InputObject = this.InputObject,
                    ProcessNames = this.ProcessName,
                    ProcessIds = this.ProcessId,
                    Name = this.Name,
                    AutomationId = this.AutomationId,
                    Class = this.Class,
                    WithControl = this.WithControl,
                    TestMode = this.TestMode,
                    SearchCriteria = this.SearchCriteria,
                    First = this.First,
                    Recurse = this.Recurse,
                    WaitNoWindow = this.WaitNoWindow
                };
                
                returnedWindows =
                    windowSearch.GetElements(
                        windowSearchData,
                        Timeout);
                
                // 20140121
                windowSearchData = null;
            }
            catch {}
            
            try {
                if (null != returnedWindows && returnedWindows.Count > 0) {
                    
                    if (TestMode) {
                        
                        WriteObject(this, !WaitNoWindow);
                        
                    } else {
                        
                        WriteObject(this, returnedWindows);
                    }
                    
                    returnedWindows = null;
                    
                } else {
                    
                    if (TestMode) {
                        
                        WriteObject(this, WaitNoWindow);
                        
                    } else {
                    
                        string name = string.Empty;
                        string procName = string.Empty;
                        string procId = string.Empty;
        
                        try{ 
                            foreach(string n in Name) { 
                                name += n; name += ","; 
                            }
                            name = name.Substring(0, name.Length - 1);
                        }
                        catch {}
        
                        try{ 
                            foreach(string s in ProcessName) { 
                                procName += s; procName += ","; 
                            }
                            procName = procName.Substring(0, procName.Length - 1);
                        }
                        catch {}
        
                        try {
                            foreach (int i in ProcessId) {
                                procId += i.ToString();
                                procId += ",";
                            }
                            procId = procId.Substring(0, procId.Length - 1);
                        }
                        catch {}
        
                        WriteError(
                            this,
                            "Failed to get window in " + 
                            Timeout.ToString() +
                            " milliseconds by:" +
                            " process name: '" +
                            procName +
                            "', process Id: " + 
                            procId + 
                            ", window title: '" + 
                            name +
                            "', automationId: '" +
                            AutomationId +
                            "', className: '" +
                            Class +
                            "'.",
                            "FailedToGetWindow",
                            ErrorCategory.InvalidResult,
                            true);
                    }
                }
            }
            catch (Exception eOuter) {
                WriteVerbose(
                    this,
                    eOuter.Message);
            }
            
            }
            catch (Exception eTheOutest) {
                WriteVerbose(
                    this,
                    eTheOutest.Message);
            }
        }
        
        protected override void EndProcessing()
        {
            try {
                OddRootElement = null;
            }
            catch (Exception eEndProcessing) {
                WriteVerbose(
                    this,
                    eEndProcessing.Message);
            }
        }
        
        protected override void StopProcessing()
        {
            WriteVerbose(this, "User interrupted");
            Wait = false;
        }
        
    }
}
