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
    using System.Windows.Automation;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

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
        
        // 20130529
        /// <summary>
        /// This variable is used in 'negative result' cmdlets like Wait-UIANoWindow
        /// </summary>
        protected bool WaitNoWindow { get; set; }
        
        protected override void StopProcessing()
        {
            WriteVerbose(this, "User interrupted");
            this.Wait = false;
        }
        
        internal ArrayList GetWindow(
            GetWindowCmdletBase cmdlet,
            // 20130513
            bool win32,
            Process[] processes,
            string[] processNames,
            int[] processIds,
            string[] windowNames,
            string automationId,
            string className,
            bool testMode)
        {
            ArrayList aeWndCollection = 
                new ArrayList();
            
            cmdlet.WriteVerbose(cmdlet, "getting the root element");
            rootElement =
                System.Windows.Automation.AutomationElement.RootElement;
            if (rootElement == null)
            {
                cmdlet.WriteVerbose(cmdlet, "rootElement == null");
                return aeWndCollection;
            }
            else
            {
                cmdlet.WriteVerbose(cmdlet, "rootElement: " + rootElement.Current);
            }
            
            
            // 20130529
            bool wasFound = false;
            do {
                
                // 20130513
                //if (null != processes && processes.Length > 0) {
                if (win32) {
                    
                    cmdlet.WriteVerbose(cmdlet, "getting a window via Win32 API");
                    aeWndCollection = getWindowCollectionViaWin32(cmdlet.First, cmdlet.Recurse, cmdlet.Name, cmdlet.AutomationId, cmdlet.Class);
                    
                } else if (null != processes && processes.Length > 0) {
                    cmdlet.WriteVerbose(cmdlet, "getting a window by process");
                    aeWndCollection = getWindowCollectionFromProcess(processes, cmdlet.First, cmdlet.Recurse, cmdlet.Name, cmdlet.AutomationId, cmdlet.Class);

                } else if (null != processIds && processIds.Length > 0) {

                    cmdlet.WriteVerbose(cmdlet, "getting a window by PID");
                    aeWndCollection = getWindowCollectionByPID(processIds, cmdlet.First, cmdlet.Recurse, cmdlet.Name, cmdlet.AutomationId, cmdlet.Class);

                } else if (null != processNames && processNames.Length > 0) {

                    cmdlet.WriteVerbose(cmdlet, "getting a window by name");
                    aeWndCollection = getWindowCollectionByProcessName(processNames, cmdlet.First, cmdlet.Recurse, cmdlet.Name, cmdlet.AutomationId, cmdlet.Class);

                } else if ((null != windowNames && windowNames.Length > 0) ||
                           (null != automationId && 0 < automationId.Length) ||
                           (null != className && 0 < className.Length)) {

                    cmdlet.WriteVerbose(cmdlet, "getting a window by name, automationId, className");
                    aeWndCollection = getWindowCollectionByName(windowNames, automationId, className, cmdlet.Recurse);
                }
                
                // 20130228
                // filtering result window collection by SearchCriteria
                if (null != aeWndCollection && 0 < aeWndCollection.Count) {
                    
                    cmdlet.WriteVerbose(cmdlet, "one or several windows were found by name, process name, process id or process object");
                    
                    if (null != cmdlet.SearchCriteria && 0 < cmdlet.SearchCriteria.Length) {
                    
                        cmdlet.WriteVerbose(cmdlet, "processing SearchCriteria");
                        
                        aeWndCollection =
                            cmdlet.getFiltredElementsCollection(
                                cmdlet,
                                aeWndCollection);
                    }
                }
                    
                // filtering result window collection by having a control(s) with properties as from WithControl
                if (null != aeWndCollection && 0 < aeWndCollection.Count) {
                
                    cmdlet.WriteVerbose(cmdlet, "one or several windows were not excluded by SearchCriteria");
                    
                    if (null != cmdlet.WithControl && 0 < cmdlet.WithControl.Length) {
                    
                        cmdlet.WriteVerbose(cmdlet, "processing WithControl");
                        
                        ArrayList filteredWindows =
                            new ArrayList();
        
                        foreach (AutomationElement window in aeWndCollection) {
                            
                            cmdlet.WriteVerbose(cmdlet, "searching for control(s) for every window, one by one");
                            
                            GetControlCmdletBase cmdletCtrl =
                                new GetControlCmdletBase();
                            //cmdletCtrl.InputObject = (AutomationElement[])aeWndCollection.ToArray();
                            cmdletCtrl.InputObject =
                                // 20130316
                                //(AutomationElement[])aeWndCollection.ToArray(typeof(AutomationElement));
                                new AutomationElement[]{ window };
                            cmdletCtrl.SearchCriteria = cmdlet.WithControl;
                            cmdletCtrl.Timeout = 0;
                            
                            cmdlet.WriteVerbose(cmdlet, "searching for one or more controls");
                            
                            // 20130301
                            try {
                            
                                ArrayList controlsList =
                                    GetControl(cmdletCtrl);
                                
                                cmdlet.WriteVerbose(cmdlet, "after the search");
                                
                                if (null != controlsList && 0 < controlsList.Count) {
                                    
                                    cmdlet.WriteVerbose(cmdlet, "ths list of controls that are on the window is not empty");
                                    
                                    filteredWindows.Add(window);
                                }
                            
                            // 20130301
                            }
                            
                            catch (Exception eWindowIsGone) {
                                
                                // forcing to a next loop
                                aeWndCollection.Clear();
                                break;
                                
                            }
                        }
                        
                        aeWndCollection = filteredWindows;
                    }
                }
                
                // 20130529
                if (cmdlet.WaitNoWindow && wasFound && (null == aeWndCollection || 0 == aeWndCollection.Count)) {
                    
                    cmdlet.Wait = false;
                }
                
                if (cmdlet.WaitNoWindow && !wasFound && null != aeWndCollection && 0 != aeWndCollection.Count) {

                    wasFound = true;
                    aeWndCollection = null;
                }
                
                if (null != aeWndCollection && aeWndCollection.Count > 0) {

                    cmdlet.WriteVerbose(cmdlet, "aeWndCollection != null");
                    
                }
                // 20120123
                // checkTimeout(ref aeWnd, true);
                // 20120824
                //checkTimeout(cmdlet, aeWnd, true);
                checkTimeout(cmdlet, aeWndCollection, true);
                
                System.Threading.Thread.Sleep(Preferences.OnSleepDelay);
                
            } while (cmdlet.Wait);
            try {

                if (null != aeWndCollection && (int)((AutomationElement)aeWndCollection[0]).Current.ProcessId > 0) {

                    cmdlet.WriteVerbose(cmdlet, "" + aeWndCollection.ToString());
                    cmdlet.WriteVerbose(cmdlet, 
                                        "aeWnd.Current.GetType() = " +
                                        ((AutomationElement)aeWndCollection[0]).GetType().Name);

                } // 20120127

                CurrentData.CurrentWindow = (AutomationElement)aeWndCollection[aeWndCollection.Count -1];
                // 20120824
                //return aeWnd;
                //return aeWndCollection;
            } catch (Exception eEvaluatingWindowAndWritingToPipeline) {
                
                //WriteDebug(cmdlet, "exception: " +
                cmdlet.WriteVerbose(
                    cmdlet,
                    "exception: " +
                    eEvaluatingWindowAndWritingToPipeline.Message);

                cmdlet.WriteVerbose(this, "<<<< ==  ==  writing/nullifying CurrentWindow  ==  == >>>>>");

                CurrentData.CurrentWindow = null;
                
            }
            
            return aeWndCollection;
        }

        private ArrayList getWindowCollectionByProcessName(
            string[] processNames,
            bool first,
            bool recurse,
            string[] name,
            string automationId,
            string className)
        {

            ArrayList aeWndCollectionByProcId = 
                new ArrayList();
            
            System.Collections.ArrayList processIdList = 
                new System.Collections.ArrayList();
            
            foreach (string processName in processNames) {
            
                try {
                    
                    //WriteDebug(this, "getting process Id");
                    this.WriteVerbose(this, "getting process Id");
                    
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
            
            int[] processIds = (int[])processIdList.ToArray(typeof(int));
            aeWndCollectionByProcId = getWindowCollectionByPID(processIds, first, recurse, name, automationId, className);
            
            return aeWndCollectionByProcId;
        }
        
        private ArrayList getWindowCollectionByPID(
            int[] processIds,
            bool first,
            bool recurse,
            string[] name,
            string automationId,
            string className)
        {
            System.Windows.Automation.AndCondition conditionsProcessId = null;
            // 20130223
            System.Windows.Automation.AndCondition conditionsForRecurseSearch = null;
            ArrayList aeWndCollectionByProcessId = 
                new ArrayList();
            
            // 20130223
            if ((null != name && 0 < name.Length) ||
                (null != automationId && string.Empty != automationId) ||
                (null != className && string.Empty != className)) {
                
                recurse = true;
            }
            
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
                    
                    if (recurse) {
                        conditionsForRecurseSearch =
                            new System.Windows.Automation.AndCondition(
                                new System.Windows.Automation.PropertyCondition(
                                    System.Windows.Automation.AutomationElement.ProcessIdProperty,
                                    processId),
                                new System.Windows.Automation.PropertyCondition(
                                    System.Windows.Automation.AutomationElement.ControlTypeProperty,
                                    System.Windows.Automation.ControlType.Window));
                    }
                    
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
                    
                    if (recurse) {
                        conditionsForRecurseSearch =
                            new System.Windows.Automation.AndCondition(
                                new System.Windows.Automation.PropertyCondition(
                                    System.Windows.Automation.AutomationElement.ProcessIdProperty,
                                    processId),
                                new System.Windows.Automation.PropertyCondition(
                                    System.Windows.Automation.AutomationElement.ControlTypeProperty,
                                    System.Windows.Automation.ControlType.Window));
                    }
                    
                }
                
                WriteVerbose(this, "trying to get aeWndByProcId: by processId = " +
                             processId.ToString());
    
                try {
                    
                    //AutomationElementCollection tempCollection = null;
                    if (recurse) {
                        
                        if (first) {
                            
                            AutomationElement rootWindowElement =
                                rootElement.FindFirst(
                                    TreeScope.Children,
                                    conditionsProcessId);
                            
                            if (null != rootWindowElement) {
                                
                                aeWndCollectionByProcessId.Add(rootWindowElement);
                                
//                                AutomationElement lowerElement =
//                                    rootWindowElement.FindFirst(
//                                        TreeScope.Descendants,
//                                        conditionsForRecurseSearch);
//                                
//                                if (null != lowerElement) {
//                                    aeWndCollectionByProcessId.Add(lowerElement);
//                                }
                            }
                            
                        } else {
                        
                            AutomationElementCollection rootCollection =
                                rootElement.FindAll(
                                    TreeScope.Children,
                                    conditionsProcessId);
                            
                            if (null != rootCollection && 0 < rootCollection.Count) {
                                
                                aeWndCollectionByProcessId.AddRange(rootCollection);
                                
                                foreach (AutomationElement rootWindowElement in rootCollection) {
                                    
                                    AutomationElementCollection tempCollection = null;
                                    tempCollection =
                                        rootWindowElement.FindAll(
                                            TreeScope.Descendants,
                                            conditionsForRecurseSearch);
                                    
                                    if (null != tempCollection && 0 < tempCollection.Count) {
                                        aeWndCollectionByProcessId.AddRange(tempCollection);
                                    }
                                }
                            }
                        }
                        
                    } else {
                        
                        if (first) {
                            
                            AutomationElement tempElement =
                                rootElement.FindFirst(TreeScope.Children,
                                                      conditionsProcessId);
                            
                            if (null != tempElement) {
                                aeWndCollectionByProcessId.Add(tempElement);
                            }
                        } else {
                            
                            AutomationElementCollection tempCollection =
                                rootElement.FindAll(TreeScope.Children,
                                                    conditionsProcessId);
                            
                            if (null != tempCollection && 0 < tempCollection.Count) {
                                aeWndCollectionByProcessId.AddRange(tempCollection);
                            }
                        }
                    }
                    
                } catch (Exception eGetFirstChildOfRootByProcessId) {
                    
                    // 20130225
                    //WriteDebug(this, "exception: " +
                    this.WriteVerbose(
                        this,
                        "exception: " +
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
                    //WriteDebug(this, "aeWndByProcId is still null");
                    this.WriteVerbose(this, "aeWndByProcId is still null");
                }
            
            } // 20120824
            
            // 20130225
            if (recurse && 
                (null != name && 0 < name.Length ||
                null != automationId && string.Empty != automationId ||
                null != className && string.Empty != className)) {
                
                ArrayList resultList =
                    new ArrayList();
                
                if (null != name && 0 < name.Length) {
                    foreach (string n in name) {
                        
                        resultList.AddRange(
                            ReturnOnlyRightElements(
                                // 20130513
                                this,
                                aeWndCollectionByProcessId,
                                n,
                                automationId,
                                className,
                                string.Empty,
                                new string[]{ "Window" },
                                false));
                        
                    }
                } else {
                    
                    resultList.AddRange(
                        ReturnOnlyRightElements(
                            // 20130513
                            this,
                            aeWndCollectionByProcessId,
                            string.Empty,
                            automationId,
                            className,
                            string.Empty,
                            new string[]{ "Window" },
                            false));
                }
                
                aeWndCollectionByProcessId = resultList;
                
            }
            
            return aeWndCollectionByProcessId;
        }
        
        // 20130513
        private ArrayList getWindowCollectionViaWin32(
            bool first,
            bool recurse,
            string[] name,
            string automationId,
            string className)
        {
            
//Console.WriteLine("name = " + name);
//Console.WriteLine("auId = " + automationId);
//Console.WriteLine("class = " + className);
            
            ArrayList aeWndCollectionViaWin32 = 
                new ArrayList();
            ArrayList tempCollection = 
                new ArrayList();
            
            aeWndCollectionViaWin32 =
                UIAHelper.EnumChildWindowsFromHandle(
                    (GetWindowCmdletBase)this,
                    IntPtr.Zero);
            
            return aeWndCollectionViaWin32;
        }
        
        private ArrayList getWindowCollectionFromProcess(
            Process[] processes,
            bool first,
            bool recurse,
            string[] name,
            string automationId,
            string className)
        {
            int processId = 0;
            ArrayList aeWndCollectionByProcId = 
                new ArrayList();
            ArrayList tempCollection = 
                new ArrayList();
            
            System.Collections.ArrayList processIdList = 
                new System.Collections.ArrayList();
            int[] processIds = null;
            
            foreach (Process process in processes) {
            
            try {
                processId = process.Id;
                if (0 != processId) {
                    processIdList.Add(processId);
                }
                
                WriteVerbose(this, "processId = " + processId.ToString());

                processIds = (int[])processIdList.ToArray(typeof(int));
                
                if (null == processIds) {
                    WriteVerbose(this, "!!!!!!!!!!!!!!!!!!!! null == processIds !!!!!!!!!");
                }
                
                tempCollection = getWindowCollectionByPID(processIds, first, recurse, name, automationId, className);
                
                foreach (AutomationElement tempElement in tempCollection) {
                    aeWndCollectionByProcId.Add(tempElement);
                }
            }
            catch (Exception tempException) {
                
                WriteVerbose(this, tempException.Message);
                
                //return aeWndCollectionByProcId;
            }
            
            } // 20120824

            return aeWndCollectionByProcId;
        }
        
        private ArrayList getWindowCollectionByName(string[] windowNames, string automationId, string className, bool recurse)
        {
            System.Windows.Automation.OrCondition conditionsSet = null;
            
            System.Collections.ArrayList aeWndCollectionByTitle = 
                new System.Collections.ArrayList();
            System.Collections.ArrayList resultCollection = 
                new System.Collections.ArrayList();
            
            // 20130220
            if (null == windowNames) {
                windowNames = new string[]{ string.Empty };
            }
            
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
                
                // 20130221
                if (recurse) {
                    conditionsSet =
                        new System.Windows.Automation.OrCondition(
                            new System.Windows.Automation.PropertyCondition(
                                System.Windows.Automation.AutomationElement.ControlTypeProperty,
                                System.Windows.Automation.ControlType.Window),
                            System.Windows.Automation.Condition.FalseCondition);
                } else {
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
                }
                WriteVerbose(this, "trying to get window: by title = " +
                             // 20120824
                             //title);
                             windowTitle);
                #region changed 20120608
                //            aeWndByTitle =
                //                rootElement.FindFirst(System.Windows.Automation.TreeScope.Children,
                //                                    conditionsTitle);
                #endregion changed 20120608
                
                // 20130221
                AutomationElementCollection aeWndCollection = null;
                if (recurse) {
                    aeWndCollection =
                        rootElement.FindAll(TreeScope.Descendants,
                                            conditionsSet);
                } else {
                    //AutomationElementCollection aeWndCollection =
                    aeWndCollection =
                        rootElement.FindAll(TreeScope.Children,
                                            conditionsSet);
                }
                
#region commented
                // 20130220
    //            WildcardOptions options;
    //            //            if (caseSensitive) {
    //            //                options =
    //            //                    WildcardOptions.Compiled;
    //            //            } else {
    //            options =
    //                WildcardOptions.IgnoreCase |
    //                WildcardOptions.Compiled;
    //            //            }
    //            WildcardPattern wildcardName =
    //                // 20120824
    //                //new WildcardPattern(title,options);
    //                new WildcardPattern(windowTitle, options);
    //
    //            
    ////            bool matched = false;
    ////            if (name.Length > 0 && wildcardName.IsMatch(element.Current.Name)) {
    ////                matched = true;
    ////            } else if (automationId.Length > 0 &&
    ////                       wildcardAutomationId.IsMatch(element.Current.AutomationId)) {
    ////                matched = true;
    ////            } else if (className.Length > 0 &&
    ////                       wildcardClass.IsMatch(element.Current.ClassName)) {
    ////                matched = true;
    ////            }
    ////
    ////            if (matched) {
    ////                if (onlyOneResult) {
    ////                    result = element;
    ////                } else {
    ////                    WriteObject(this, element);
    ////                }
    ////            }
    //            
    //            if (aeWndCollection.Count > 0) {
    //    
    //                WriteVerbose(this, "aeWndCollection.Count > 0");
    //                
    //                foreach (AutomationElement wndInColleciton in aeWndCollection) {
    //                    if (wndInColleciton.Current.Name != null && 
    //                        wndInColleciton.Current.Name != string.Empty &&
    //                        wndInColleciton.Current.Name.Length > 0 &&
    //                        wildcardName.IsMatch(wndInColleciton.Current.Name)) {
    //                        // 20120824
    //                        //aeWndByTitle = wndInColleciton;
    //                        //break;
    //                        aeWndCollectionByTitle.Add(wndInColleciton);
    //                    }
    //                }
    //            }
    ////
    //else {
    //    WriteVerbose(this, "aeWndCollection.Count == 0");
    //}
    ////
    
                
    //            if (null != aeWndCollection && 0 < aeWndCollection.Count) {
    //                
    //                System.Collections.ArrayList tempCollection = 
    //                    new System.Collections.ArrayList();
    //                System.Windows.Automation.AndCondition conditionsForWildCards =
    //                    this.getControlConditions(this, string.Empty, false, true) as AndCondition;
    //                
    //                SearchByWildcardViaUIA((GetCmdletBase)this, ref tempCollection, AutomationElement.RootElement, windowTitle, automationId, className, string.Empty, conditionsForWildCards);
    //                
    //                if (null != tempCollection && 0 < tempCollection.Count) {
    //                    aeWndCollectionByTitle.AddRange(tempCollection);
    //                }
    //            }
#endregion commented
    
                this.WriteVerbose(this, "trying to run the returnOnlyRightElements method");
                this.WriteVerbose(this, "collected " + aeWndCollection.Count.ToString() + " elements for further selection");
                
                aeWndCollectionByTitle =
                    //(this as GetCmdletBase).returnOnlyRightElements(
                    //this.ReturnOnlyRightElements(
                    HasTimeoutCmdletBase.ReturnOnlyRightElements(
                        // 20130513
                        this,
                        aeWndCollection,
                        windowTitle,
                        automationId,
                        className,
                        string.Empty,
                        (new string[]{ "Window", "Pane", "Menu" }),
                        false);
                
                this.WriteVerbose(this, "after running the returnOnlyRightElements method");
                this.WriteVerbose(this, "collected " + aeWndCollectionByTitle.Count.ToString() + " elements");
                
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
                         ", seconds: " + (nowDate - StartDate).TotalSeconds);
            try {
                // 20120824
                //if ((aeWindow != null && (int)aeWindow.Current.ProcessId > 0) ||
                if ((null != aeWindowList && //(int)((AutomationElement)aeWindowList[0]).Current.ProcessId > 0) ||
                     aeWindowList.Count > 0) ||
                    (nowDate - StartDate).TotalSeconds > this.Timeout / 1000)
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
                    
                    // 20130529
                    //this.Wait = false;
                    if (!cmdlet.WaitNoWindow) {
                        this.Wait = false;
                    }
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
        
        // 20130513
        //internal ArrayList returnOnlyRightElements(
        internal static ArrayList ReturnOnlyRightElements(
            //AutomationElementCollection results,
            // 20130513
            HasTimeoutCmdletBase cmdlet,
            IEnumerable results,
            //System.Collections.Generic.IEnumerable<AutomationElement> results,
            string name,
            string automationId,
            string className,
            string textValue,
            string[] controlType,
            bool caseSensitive)
        {
            
            ArrayList resultCollection = new ArrayList();

            WildcardOptions options;
            if (caseSensitive) {
                options =
                    WildcardOptions.Compiled;
            } else {
                options =
                    WildcardOptions.IgnoreCase |
                    WildcardOptions.Compiled;
            }
            
            if (null == name || string.Empty == name || 0 == name.Length) { name = "*"; }
            if (null == automationId || string.Empty == automationId || 0 == automationId.Length) { automationId = "*"; }
            if (null == className || string.Empty == className || 0 == className.Length) { className = "*"; }
            if (null == textValue || string.Empty == textValue || 0 == textValue.Length) { textValue = "*"; }

//Console.WriteLine("name = " + name);
//Console.WriteLine("auId = " + automationId);
//Console.WriteLine("class = " + className);
//Console.WriteLine("value = " + textValue);
            
            WildcardPattern wildcardName = 
                new WildcardPattern(name, options);
            WildcardPattern wildcardAutomationId = 
                new WildcardPattern(automationId, options);
            WildcardPattern wildcardClass = 
                new WildcardPattern(className, options);
            WildcardPattern wildcardValue = 
                new WildcardPattern(textValue, options);
            // 20130513
            //this.WriteVerbose(this, "inside the returnOnlyRightElements method 20");
            cmdlet.WriteVerbose(cmdlet, "inside the returnOnlyRightElements method 20");
                System.Collections.Generic.List<AutomationElement> list =
                    new System.Collections.Generic.List<AutomationElement>();
                
                // 20130513
                foreach (AutomationElement elt in results) {
                
                    list.Add(elt);
                
                }
                //list.AddRange(results);
                //list.AddRange(results.AsQueryable());

            try {
                
                var query = list
//                    .Where<AutomationElement>(item => wildcardName.IsMatch(item.Current.Name))
//                    .Where<AutomationElement>(item => wildcardAutomationId.IsMatch(item.Current.AutomationId))
//                    .Where<AutomationElement>(item => wildcardClass.IsMatch(item.Current.ClassName))
//                    .Where<AutomationElement>(item => 
//                                              item.GetSupportedPatterns().Contains(ValuePattern.Pattern) ? 
//                                              //(("*" != textValue) ? wildcardValue.IsMatch((item.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern).Current.Value) : false) :
//                                              (("*" != textValue) ? (positiveMatch(item, wildcardValue, textValue)) : (negativeMatch(textValue))) :
//                                              true
//                                              )
                    .Where<AutomationElement>(
                        item => (wildcardName.IsMatch(item.Current.Name) &&
                                 wildcardAutomationId.IsMatch(item.Current.AutomationId) &&
                                 wildcardClass.IsMatch(item.Current.ClassName) &&
                                 // check whether a control has or hasn't ValuePattern
                                 (item.GetSupportedPatterns().Contains(ValuePattern.Pattern) ?
                                  // 20130513
                                  //testRealValueAndValueParameter(item, name, automationId, className, textValue, wildcardValue) :
                                  cmdlet.testRealValueAndValueParameter(item, name, automationId, className, textValue, wildcardValue) :
                                  // check whether the -Value parameter has or hasn't value
                                  ("*" == textValue ? true : false)
                                 )
                                )
                       )
                    .ToArray<AutomationElement>();

                // 20130513
                //this.WriteVerbose(
                //    this,
                cmdlet.WriteVerbose(
                        cmdlet,
                        "There are " +
                        query.Count().ToString() +
                        " elements");

                resultCollection.AddRange(query);

                // 20130513
                //this.WriteVerbose(
                //    this,
                cmdlet.WriteVerbose(
                    cmdlet,
                    "There are " +
                    resultCollection.Count.ToString() +
                    " elements");
                
            }
            catch {
                
            }
            
            return resultCollection;
        }
        
        private bool testRealValueAndValueParameter(
            AutomationElement item,
            string name,
            string automationId,
            string className,
            string textValue,
            WildcardPattern wildcardValue)
        {
            bool result = false;
            
            // getting the real value of a control
            string realValue = string.Empty;
            try {
                realValue =
                    (item.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern).Current.Value;
            }
            catch {}
            
            // if a control's ValuePattern has no value
            if (string.Empty == realValue) {
                
                if ("*" != name || "*" != automationId || "*" != className) {
                    return true;
                }
                return result;
            }
            
            // if there was not specified the -Value parameter
            if ("*" == textValue) {
                
                if ("*" != name || "*" != automationId || "*" != className) {
                    return true;
                }
                
                // 20130208
                //return result;
            }
            
            result =
                wildcardValue.IsMatch(realValue);

            return result;
        }
    }
}
