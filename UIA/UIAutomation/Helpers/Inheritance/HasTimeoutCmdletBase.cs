/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 29.11.2011
 * Time: 14:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    
    using System.Collections;

    /// <summary>
    /// Description of HasTimeoutCmdletBase.
    /// </summary>
    public class HasTimeoutCmdletBase : HasControlInputCmdletBase
    {
        // http://pinvoke.net/default.aspx/user32.FindWindow
        [DllImport("user32.dll", EntryPoint="FindWindow", SetLastError = true)]
        private static extern System.IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);
        // You can also call FindWindow(default(string), lpWindowName) or FindWindow((string)null, lpWindowName)
        
        #region Constructor
        public HasTimeoutCmdletBase()
        {
            //this.WriteVerbose(this, "constructor");
            
            this.Wait = true;
            this.Timeout = Preferences.Timeout;
            this.Seconds = Timeout / 1000;
            this.OnErrorScreenShot = Preferences.OnErrorScreenShot;
            this.OnSuccessAction = null;
            this.OnErrorAction = null;
        }
        #endregion Constructor

        #region Parameters
        [Parameter(Mandatory = false)]
        internal SwitchParameter Wait { get; set; }
        [Alias("Milliseconds")]
        [Parameter(Mandatory = false)]
        public int Timeout { get; set; }
        [Parameter(Mandatory = false)]
        public int Seconds {
            get { return Timeout / 1000; }
            set{ Timeout = value * 1000; }
        }
        
        // 20120830
        [Parameter(Mandatory = false)]
        public SwitchParameter IsCritical { get; set; }
        
        // 20120816
//        [Parameter(Mandatory = false)]
//        public ScriptBlock[] OnSleepAction { get; set; }
        #endregion Parameters
        
        protected override void StopProcessing()
        {
            // 20120620
            WriteVerbose(this, "User interrupted");
            this.Wait = false;
        }
        
        // 20120824
        //internal System.Windows.Automation.AutomationElement GetWindow(
        //internal AutomationElementCollection GetWindow(
        internal ArrayList GetWindow(
            GetWindowCmdletBase cmdlet,
            // 20120824
            //Process process,
            Process[] processes,
            // 20120824
            //string processName,
            string[] processNames,
            // 20120824
            //int processId,
            int[] processIds,
            // 20120824
            //string title)
            string[] windowNames)
        {
            // 20120824
            //System.Windows.Automation.AutomationElement aeWnd = null;
            //AutomationElementCollection aeWndCollection = null;
            ArrayList aeWndCollection = 
                new ArrayList();
            
            WriteDebug(cmdlet, "getting the root element");
            rootElement =
                System.Windows.Automation.AutomationElement.RootElement;
            if (rootElement == null)
            {
                WriteVerbose(cmdlet, "rootElement == null");
                // 20120831
                //return null;
                return aeWndCollection;
            }
            else
            {
                // try { WriteDebug(cmdlet, "rootElement: " + rootElement.Current); } catch { }
                WriteDebug(cmdlet, "rootElement: " + rootElement.Current);
            }
            
            do {
                // 20120824
                //aeWnd = null; // ??????
                // 20120824 ??
                
                // 20120824
                //if (process != null) {
                if (null != processes && processes.Length > 0) {
                    // 20120824
                    //aeWnd = getWindowFromProcess(process);
                    aeWndCollection = getWindowCollectionFromProcess(processes);
                // 20120824
                //} else if (processId > 0) {
                } else if (null != processIds && processIds.Length > 0) {
                    // 20120824
                    //aeWnd = getWindowByPID(processId);
                    aeWndCollection = getWindowCollectionByPID(processIds);
                // 20120824
                //} else if (processName.Length > 0) {
                } else if (null != processNames && processNames.Length > 0) {
                    // 20120824
                    //aeWnd = getWindowByProcessName(processName);
                    aeWndCollection = getWindowCollectionByProcessName(processNames);
                // 20120824
                //} else if (title != string.Empty) {
                } else if (null != windowNames && windowNames.Length > 0) {
                    // 20120824
                    //aeWnd = getWindowByTitle(title);
                    aeWndCollection = getWindowCollectionByName(windowNames);
                }
                // 20120824
                //if (aeWnd != null && (int)aeWnd.Current.ProcessId > 0)
                //if (null != aeWndCollection && (int)((AutomationElement)aeWndCollection[0]).Current.ProcessId > 0) {
                if (null != aeWndCollection && aeWndCollection.Count > 0) {
                // 20120824
                //{
                    // 20120824
                    //WriteDebug(cmdlet, "aeWnd != null");
                    WriteDebug(cmdlet, "aeWndCollection != null");
                }
                // 20120123
                // checkTimeout(ref aeWnd, true);
                // 20120824
                //checkTimeout(cmdlet, aeWnd, true);
                checkTimeout(cmdlet, aeWndCollection, true);
                
                //WriteVerbose(this, "!!!!!!!!!!!!!! sleep !!!!!!!!!!!!!!!!!!");
                //WriteVerbose(this, Preferences.OnSleepDelay.ToString());
                System.Threading.Thread.Sleep(Preferences.OnSleepDelay);
                
            } while (cmdlet.Wait);
            try {
                // 20120824
                //if (aeWnd != null && (int)aeWnd.Current.ProcessId > 0)
                if (null != aeWndCollection && (int)((AutomationElement)aeWndCollection[0]).Current.ProcessId > 0) {
                // 20120824
                //{
                    // 20120824
                    //WriteDebug(cmdlet, "" + aeWnd);
                    WriteDebug(cmdlet, "" + aeWndCollection.ToString());
                    WriteDebug(cmdlet, "aeWnd.Current.GetType() = " +
                               // 20120824
                               //aeWnd.Current.GetType().Name);
                               ((AutomationElement)aeWndCollection[0]).GetType().Name);
                    //} // 20120127
                    // 20120208 if (Highlight) { Global.PaintRectangle(aeWnd); }
                } // 20120127
                // 20120824
                //CurrentData.CurrentWindow = aeWnd;
                CurrentData.CurrentWindow = (AutomationElement)aeWndCollection[aeWndCollection.Count -1];
                // 20120824
                //return aeWnd;
                //return aeWndCollection;
            } catch (Exception eEvaluatingWindowAndWritingToPipeline) {
                WriteDebug(cmdlet, "exception: " +
                           eEvaluatingWindowAndWritingToPipeline.Message);
                // 20120206 return aeWnd; // ??
                // 20120206
                WriteVerbose(this, "<<<< ==  ==  writing/nullifying CurrentWindow  ==  == >>>>>");
                // 20120824
                //CurrentData.CurrentWindow = aeWnd;
                //CurrentData.CurrentWindow = (AutomationElement)aeWndCollection[aeWndCollection.Count - 1];
                CurrentData.CurrentWindow = null;
                
                //WriteVerbose(this, "000001");
                
                //try {WriteVerbose(this, "<<<< ==  ==  " + CurrentData.CurrentWindow.Current.Name + "  ==  == >>>>>"); } catch {}
                
                // 20121001
                //UIAHelper.GetScreenshotOfAutomationElement(this, CmdletName(cmdlet) + "_WindowEqNull", true, 0, 0, 0, 0, string.Empty, System.Drawing.Imaging.ImageFormat.Jpeg);
//                cmdlet.WriteError(
//                    cmdlet,
//                    "An unknown error raised while working with the results of GetWindow. " +
//                    eEvaluatingWindowAndWritingToPipeline.Message,
//                    "AnalyzingResults",
//                    ErrorCategory.InvalidOperation,
//                    true);
                
                //WriteVerbose(this, "000002");
                
                // 20120824
                //return aeWnd; // ??
                //return aeWndCollection;
            }
            
            //WriteVerbose(this, "000003");
            
            
            return aeWndCollection;
        }
        //}
        
        // 20120824
        //private System.Windows.Automation.AutomationElement getWindowByProcessName(string processName)
        private ArrayList getWindowCollectionByProcessName(string[] processNames)
        {
            //int processId = 0;
            //System.Windows.Automation.AndCondition conditionsProcessId = null;
            // 20120824
            //System.Windows.Automation.AutomationElement aeWndByProcId = null;
            ArrayList aeWndCollectionByProcId = 
                new ArrayList();
            
            // 20120824
            System.Collections.ArrayList processIdList = 
                new System.Collections.ArrayList();
            
            foreach (string processName in processNames) {
            
            //WriteDebug(this, "processName.Length > 0");
            try {
                WriteDebug(this, "getting process Id");
                System.Diagnostics.Process[] processes =
                    System.Diagnostics.Process.GetProcessesByName(processName);
                // only the first
                // 20120824
                //processId = processes[0].Id;
                // 20120824
                //if (processId == 0) {
                //    return aeWndByProcId;
                //}
                // 20120824
                //WriteVerbose(this, "processId = " + processId.ToString());
                // 20120824
                //aeWndByProcId = getWindowCollectionByPID(processId);
                
                
                // 20120824
                //return aeWndByProcId;
                
                // 20120824
                //processIdList.AddRange(processes);
                foreach (Process process in processes) {
                    processIdList.Add(process.Id);
                }
            }
            catch {
                // 20120824
                //return aeWndByProcId;
                return aeWndCollectionByProcId;
            }
            
            } // 20120824
            
            // 20120824
            int[] processIds = (int[])processIdList.ToArray(typeof(int));
            aeWndCollectionByProcId = getWindowCollectionByPID(processIds);
            
            // 20120824
            return aeWndCollectionByProcId;
        }
        
        // 20120824
        //private AutomationElement getWindowByPID(int processId)
        private ArrayList getWindowCollectionByPID(int[] processIds)
        {
            System.Windows.Automation.AndCondition conditionsProcessId = null;
            // 20120824
            //System.Windows.Automation.AutomationElement aeWndByProcId = null;
            ArrayList aeWndCollectionByProcessId = 
                new ArrayList();
            
            // 20120824
            foreach (int processId in processIds) {
            
            try {
                conditionsProcessId =
                    new System.Windows.Automation.AndCondition(
                        new System.Windows.Automation.PropertyCondition(
                            System.Windows.Automation.AutomationElement.ProcessIdProperty,
                            processId),
                        new System.Windows.Automation.OrCondition(
                            new System.Windows.Automation.PropertyCondition(
                                System.Windows.Automation.AutomationElement.ControlTypeProperty,
                                System.Windows.Automation.ControlType.Window),
                            new System.Windows.Automation.PropertyCondition(
                                System.Windows.Automation.AutomationElement.ControlTypeProperty,
                                System.Windows.Automation.ControlType.Pane),
                            new System.Windows.Automation.PropertyCondition(
                                System.Windows.Automation.AutomationElement.ControlTypeProperty,
                                System.Windows.Automation.ControlType.Menu)));
                
                WriteVerbose(this, "using processId = " +
                             processId.ToString() +
                             " and ControlType.Window or ControlType.Pane conditions");
            } catch { // 20120206  (Exception eCouldNotGetProcessId) {
                // if (fromCmdlet) WriteDebug(this, "" + eCouldNotGetProcessId.Message);
                conditionsProcessId =
                    new System.Windows.Automation.AndCondition(
                        new System.Windows.Automation.PropertyCondition(
                            System.Windows.Automation.AutomationElement.ProcessIdProperty,
                            processId),
                        new System.Windows.Automation.OrCondition(
                            new System.Windows.Automation.PropertyCondition(
                                System.Windows.Automation.AutomationElement.ControlTypeProperty,
                                System.Windows.Automation.ControlType.Window),
                            new System.Windows.Automation.PropertyCondition(
                                System.Windows.Automation.AutomationElement.ControlTypeProperty,
                                System.Windows.Automation.ControlType.Pane),
                            new System.Windows.Automation.PropertyCondition(
                                System.Windows.Automation.AutomationElement.ControlTypeProperty,
                                System.Windows.Automation.ControlType.Menu)));
                
            }
            
            WriteVerbose(this, "trying to get aeWndByProcId: by processId = " +
                         processId.ToString());

            // 20120824
            //if (rootElement == null) { WriteDebug(this, "rootEl is null"); }
            try {
                // 20120824
                //aeWndByProcId =
                //aeWndCollectionByProcessId =
                
                //WriteVerbose(this, "010");
                
                AutomationElementCollection tempCollection =
                    // 20120824
                    //rootElement.FindFirst(System.Windows.Automation.TreeScope.Children,
                    rootElement.FindAll(TreeScope.Children,
                                          conditionsProcessId);
                //WriteVerbose(this, "011");
                
                // 20120824
                foreach (AutomationElement tempElement in tempCollection) {
                    //WriteVerbose(this, "012");
                    aeWndCollectionByProcessId.Add(tempElement);
                }
                //WriteVerbose(this, "015");
                
            } catch (Exception eGetFirstChildOfRootByProcessId) {
                WriteDebug(this, "exception: " +
                           eGetFirstChildOfRootByProcessId.Message);
            }
            // 20120824
            //if (aeWndByProcId != null &&
            if (null != aeWndCollectionByProcessId &&
                // 20120824
                //(int)aeWndByProcId.Current.ProcessId > 0) {
                //(int)((AutomationElement)aeWndCollectionByProcessId[0]).Current.ProcessId > 0) {
                processId > 0) {
                WriteVerbose(this, "aeWndByProcId: " +
                             // 20120824
                             //aeWndByProcId.Current.Name +
                             //((AutomationElement)aeWndCollectionByProcessId[0]).Current.Name +
                             "is caught by processId = " + processId.ToString());
            }
            else{
                WriteDebug(this, "aeWndByProcId is still null");
            }
            
            } // 20120824
            
            // 20120824
            //return aeWndByProcId;
            return aeWndCollectionByProcessId;
        }
        
        // 20120824
        //private AutomationElement getWindowFromProcess(Process process)
        private ArrayList getWindowCollectionFromProcess(Process[] processes)
        {
            int processId = 0;
            // 20120824
            //System.Windows.Automation.AutomationElement aeWndByProcId = null;
            ArrayList aeWndCollectionByProcId = 
                new ArrayList();
            ArrayList tempCollection = 
                new ArrayList();
            
            System.Collections.ArrayList processIdList = 
                new System.Collections.ArrayList();
            int[] processIds = null;
            
            // 20120824
            foreach (Process process in processes) {
            
                //WriteVerbose(this, "0001");
                
            //WriteDebug(this, "processName.Length > 0");
            try {
                processId = process.Id;
                // 20120824
                //if (processId == 0) {
                if (0 != processId) {
                    // 20120824
                    //return aeWndByProcId;
                    //return aeWndCollectionByProcId;
                    // 20120824
                    processIdList.Add(processId);
                }
                
                //WriteVerbose(this, "0002");
                
                WriteVerbose(this, "processId = " + processId.ToString());
                // 20120824
                //aeWndByProcId = getWindowByPID(processId);
                processIds = (int[])processIdList.ToArray(typeof(int));
                
                //WriteVerbose(this, "0003");
                if (null == processIds) {
                    WriteVerbose(this, "!!!!!!!!!!!!!!!!!!!! null == processIds !!!!!!!!!");
                }
                
                //aeWndCollectionByProcId = getWindowCollectionByPID(processIds);
                tempCollection = getWindowCollectionByPID(processIds);
                
                foreach (AutomationElement tempElement in tempCollection) {
                    aeWndCollectionByProcId.Add(tempElement);
                }
                
                //WriteVerbose(this, "0004");
                
                // 20120824
                //return aeWndByProcId;
                //return aeWndCollectionByProcId;
            }
            catch (Exception tempException) {
                // 20120824
                //return aeWndByProcId;
                
                WriteVerbose(this, tempException.Message);
                //WriteVerbose(this, "0005catch");
                
                //return aeWndCollectionByProcId;
            }
            
            } // 20120824
            
            // 20120824
            //WriteVerbose(this, "0006");
            return aeWndCollectionByProcId;
        }
        
        // 20120824
        //private System.Windows.Automation.AutomationElement getWindowByTitle(string title)
        private ArrayList getWindowCollectionByName(string[] windowNames)
        {
            #region changed 20120608
            //            System.Windows.Automation.AndCondition conditionsTitle = null;
            #endregion changed 20120608
            System.Windows.Automation.OrCondition conditionsSet = null;
            
            // 20120824
            //System.Windows.Automation.AutomationElement aeWndByTitle = null;
            //AutomationElementCollection aeWndCollectionByTitle = null;
            System.Collections.ArrayList aeWndCollectionByTitle = 
                new System.Collections.ArrayList();
            System.Collections.ArrayList resultCollection = 
                new System.Collections.ArrayList();
            
            // 20120824
            foreach (string windowTitle in windowNames) {
            
            WriteVerbose(this, "processName.Length == 0");
            #region changed 20120608
            //            conditionsTitle =
            //                new AndCondition(
            //                    new System.Windows.Automation.OrCondition(
            //                        new System.Windows.Automation.PropertyCondition(
            //                            System.Windows.Automation.AutomationElement.ControlTypeProperty,
            //                            System.Windows.Automation.ControlType.Window),
            //                        new System.Windows.Automation.PropertyCondition(
            //                            System.Windows.Automation.AutomationElement.ControlTypeProperty,
            //                            System.Windows.Automation.ControlType.Pane),
            //                        new System.Windows.Automation.PropertyCondition(
            //                            System.Windows.Automation.AutomationElement.ControlTypeProperty,
            //                            System.Windows.Automation.ControlType.Menu)),
            //                    new PropertyCondition(
            //                        System.Windows.Automation.AutomationElement.NameProperty,
            //                        title));
            #endregion changed 20120608
            conditionsSet =
                new System.Windows.Automation.OrCondition(
                    new System.Windows.Automation.PropertyCondition(
                        System.Windows.Automation.AutomationElement.ControlTypeProperty,
                        System.Windows.Automation.ControlType.Window),
                    new System.Windows.Automation.PropertyCondition(
                        System.Windows.Automation.AutomationElement.ControlTypeProperty,
                        System.Windows.Automation.ControlType.Pane),
                    new System.Windows.Automation.PropertyCondition(
                        System.Windows.Automation.AutomationElement.ControlTypeProperty,
                        System.Windows.Automation.ControlType.Menu));
            WriteVerbose(this, "trying to get window: by title = " +
                         // 20120824
                         //title);
                         windowTitle);
            #region changed 20120608
            //            aeWndByTitle =
            //                rootElement.FindFirst(System.Windows.Automation.TreeScope.Children,
            //                                    conditionsTitle);
            #endregion changed 20120608
            
            AutomationElementCollection aeWndCollection =
                rootElement.FindAll(TreeScope.Children,
                                    conditionsSet);
            
            WildcardOptions options;
            //            if (caseSensitive) {
            //                options =
            //                    WildcardOptions.Compiled;
            //            } else {
            options =
                WildcardOptions.IgnoreCase |
                WildcardOptions.Compiled;
            //            }
            WildcardPattern wildcardName =
                // 20120824
                //new WildcardPattern(title,options);
                new WildcardPattern(windowTitle, options);

            
//            bool matched = false;
//            if (name.Length > 0 && wildcardName.IsMatch(element.Current.Name)) {
//                matched = true;
//            } else if (automationId.Length > 0 &&
//                       wildcardAutomationId.IsMatch(element.Current.AutomationId)) {
//                matched = true;
//            } else if (className.Length > 0 &&
//                       wildcardClass.IsMatch(element.Current.ClassName)) {
//                matched = true;
//            }
//
//            if (matched) {
//                if (onlyOneResult) {
//                    result = element;
//                } else {
//                    WriteObject(this, element);
//                }
//            }
            
            if (aeWndCollection.Count > 0) {
    
                WriteVerbose(this, "aeWndCollection.Count > 0");
                
                foreach (AutomationElement wndInColleciton in aeWndCollection) {
                    if (wndInColleciton.Current.Name != null && 
                        wndInColleciton.Current.Name != string.Empty &&
                        wndInColleciton.Current.Name.Length > 0 &&
                        wildcardName.IsMatch(wndInColleciton.Current.Name)) {
                        // 20120824
                        //aeWndByTitle = wndInColleciton;
                        //break;
                        aeWndCollectionByTitle.Add(wndInColleciton);
                    }
                }
            }
//
else {
    WriteVerbose(this, "aeWndCollection.Count == 0");
}
//
            // 20120831
            if (null != aeWndCollectionByTitle && 0 < aeWndCollectionByTitle.Count) {
                // 20120824
                foreach (AutomationElement aeWndByTitle in aeWndCollectionByTitle) {
                    
                    // 20120831
                    //AutomationElement tempElement = null;
                
                    if (aeWndByTitle != null &&
                        (int)aeWndByTitle.Current.ProcessId > 0) {
                        WriteVerbose(this, "aeWndByTitle: " +
                                     aeWndByTitle.Current.Name +
                                     // 20120824
                                     //" is caught by title = " + title);
                                     " is caught be title = " + windowTitle);
                            
                            // 20120824
                            resultCollection.Add(aeWndByTitle);
                            
                    } 
                    
                } // 20120831
                
            } else {
                
                // 20120831
                AutomationElement tempElement = null;
                
                // one more attempt using the FindWindow function
                System.IntPtr wndHandle =
                    // 20120824
                    //FindWindowByCaption(System.IntPtr.Zero, title);
                    FindWindowByCaption(System.IntPtr.Zero, windowTitle);
                if (wndHandle != null && wndHandle != System.IntPtr.Zero) {
                    // 20120824
                    //aeWndByTitle =
                    tempElement =
                        AutomationElement.FromHandle(wndHandle);
                }
                // 20120824
                //if (aeWndByTitle != null && (int)aeWndByTitle.Current.ProcessId > 0) {
                if (null != tempElement && (int)tempElement.Current.ProcessId > 0) {
                    WriteVerbose(this, "aeWndByTitle: " +
                                 // 20120824
                                 //aeWndByTitle.Current.Name +
                                 // 20120824
                                 //" is caught by title = " + title +
                                 " is caught by title = " + windowTitle +
                                 " using the FindWindow function");
                    
                    // 20120824
                    resultCollection.Add(tempElement);
                    
                }
            }
            
            // 20120831                
            //} // 20120824
            
            } // 20120824
            
            // 20120824
            //return aeWndByTitle;
            return resultCollection;
        }
        
        // 20120123
        // private void checkTimeout(ref System.Windows.Automation.AutomationElement aeWindow,
        private void checkTimeout(GetWindowCmdletBase cmdlet,
                                  //System.Windows.Automation.AutomationElement aeWindow,
                                  ArrayList aeWindowList,
                                  bool fromCmdlet)
        {
            // RunOnRefreshScriptBlocks(this);
            // System.Threading.Thread.Sleep(Preferences.SleepInterval);
            // RunScriptBlocks(this);
            SleepAndRunScriptBlocks(this);
            System.DateTime nowDate = System.DateTime.Now;
            WriteVerbose(this, "process: " +
                         // processName +
                         cmdlet.ProcessName +
                         ", name: " +
                         cmdlet.Name +
                         ", seconds: " + (nowDate - startDate).TotalSeconds);
            try {
                // 20120824
                //if ((aeWindow != null && (int)aeWindow.Current.ProcessId > 0) ||
                if ((null != aeWindowList && //(int)((AutomationElement)aeWindowList[0]).Current.ProcessId > 0) ||
                     aeWindowList.Count > 0) ||
                    (nowDate - startDate).TotalSeconds > this.Timeout / 1000)
                {
                    // 20120824
                    //if (aeWindow == null) {
                    if (null == aeWindowList) {
                        //                        ErrorRecord err =
                        //                            new ErrorRecord(
                        //                                new Exception(),
                        //                                "ControlIsNull",
                        //                                ErrorCategory.OperationTimeout,
                        //                                aeWindow);
                        //                        err.ErrorDetails =
                        //                            new ErrorDetails(
                        //                                CmdletName(this) + ": timeout expired for process: " +
                        //                                cmdlet.ProcessName + ", title: " + cmdlet.Name);
                        //                        WriteError(this, err, false);
                        //                        //WriteError(this, err, true); //// 20120306
                        //return;
                        this.Wait = false;
                        Exception eReturn =
                            new Exception(
                                CmdletName(this) + ": timeout expired for process: " +
                                cmdlet.ProcessName + ", title: " + cmdlet.Name);
                        throw(eReturn);
                    }else{
//                        WriteVerbose(this, "got the window: " +
//                                     // 20120824
//                                     //aeWindow.Current.Name);
//                                     ((AutomationElement)aeWindowList[0]).Current.Name);
                    }
                    this.Wait = false;
                    // break;
                }
            } catch (Exception eEvaluatingWindowOrMeasuringTimeout) {
                // try { WriteDebug(CmdletName(this) + ": exception: " +
                // eEvaluatingWindowOrMeasuringTimeout.Message); } catch { }
                WriteDebug(this, "exception: " +
                           eEvaluatingWindowOrMeasuringTimeout.Message);
                
                // 20121001
                //UIAHelper.GetScreenshotOfAutomationElement(this, CmdletName(this) + "_Timeout", true, 0, 0, 0, 0, string.Empty, System.Drawing.Imaging.ImageFormat.Jpeg);
                cmdlet.WriteError(
                    cmdlet,
                    "An error raised during checking the timeout. " +
                    eEvaluatingWindowOrMeasuringTimeout.Message,
                    "CheckingTimeout",
                    ErrorCategory.InvalidOperation,
                    true);
            }
        }
    }
}
