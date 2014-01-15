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
    // using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Description of GetUiaWindow.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaWindow", DefaultParameterSetName = "UIA")]
    [OutputType(typeof(object))]
    
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
            
            WriteVerbose(this, "Input parameters:");
            WriteVerbose(this, "ProcessName = " + ProcessName);
            WriteVerbose(this, "ProcessId = " + ProcessId);
            WriteVerbose(this, "Name = " + Name);
            WriteVerbose(this, "AutomationId = " + AutomationId);
            WriteVerbose(this, "Class = " + Class);
            WriteVerbose(this, "Recurse = " + Recurse.ToString());
            WriteVerbose(this, "Timeout " + Timeout.ToString());
            
            List<IUiElement> returnedWindows = new List<IUiElement>();
            
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
            
            // 20140110
            try {
                // returnedWindows =
                //     GetWindow(this, Win32, InputObject, ProcessName, ProcessId, Name, AutomationId, Class, TestMode);
//            GetWindowCmdletBase cmdlet,
//            bool win32,
//            Process[] processes,
//            string[] processNames,
//            int[] processIds,
//            string[] windowNames,
//            string automationId,
//            string className,
//            bool testMode)
                
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
                    // OddRootElement = this.OddRootElement,
                    TestMode = this.TestMode,
                    SearchCriteria = this.SearchCriteria,
                    First = this.First,
                    Recurse = this.Recurse,
                    WaitNoWindow = this.WaitNoWindow
                };
                
//Console.WriteLine("before processing");
//if (null == windowSearchData.OddRootElement) {
//    Console.WriteLine("null == windowSearchData.OddRootElement");
//} else {
//    Console.WriteLine("null != windowSearchData.OddRootElement");
//    if (null == windowSearchData.OddRootElement.Current) {
//        Console.WriteLine("null == windowSearchData.OddRootElement.Current");
//    } else {
//        Console.WriteLine("null != windowSearchData.OddRootElement.Current");
//        Console.WriteLine("root element = " + windowSearchData.OddRootElement.Current.Name);
//        Console.WriteLine("root element = " + windowSearchData.OddRootElement.Current.AutomationId);
//        Console.WriteLine("root element = " + windowSearchData.OddRootElement.Current.ClassName);
//    }
//}
                
                returnedWindows =
                    windowSearch.GetElements(windowSearchData, Timeout);
            }
            catch {}
            
            // 20140110
            try {
                if (null != returnedWindows && returnedWindows.Count > 0) {
                    
                    if (TestMode) {
                        
                        WriteObject(this, !WaitNoWindow);
                        
                    } else {
                        
                        WriteObject(this, returnedWindows);
                    }
                    
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
                            // 20140110
                            // " seconds by:" +
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
        
//        protected override void StopProcessing()
//        {
//            // 20120620
//            WriteVerbose(this, "User interrupted");
//            this.Wait = false;
//        }

        // 20131019
        protected override void StopProcessing()
        {
            WriteVerbose(this, "User interrupted");
            Wait = false;
        }
        
    }
}
