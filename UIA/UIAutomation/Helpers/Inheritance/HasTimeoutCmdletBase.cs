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
            
            bool wasFound = false;
            do {
                
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
                           !string.IsNullOrEmpty(automationId) ||
                           !string.IsNullOrEmpty(className)) {

                    /*
                            (null != automationId && 0 < automationId.Length) ||
                            (null != className && 0 < className.Length)) {
                    */

                               cmdlet.WriteVerbose(cmdlet, "getting a window by name, automationId, className");
                    aeWndCollection = getWindowCollectionByName(windowNames, automationId, className, cmdlet.Recurse);
                }
                
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
        
                        cmdlet.WriteVerbose(cmdlet, "searching for control(s) for every window, one by one");
                        
                        bool exitInnerCycle = false;
                        
                        foreach (AutomationElement window in aeWndCollection) {
                            
                            cmdlet.WriteVerbose(cmdlet, "Window: name='" + window.Current.Name + "', automaitonId='" + window.Current.AutomationId + "'");
                            
//                            if (exitInnerCycle) {
//                                //break;
//                                window = null;
//                                continue;
//                            }
                            
                            GetControlCmdletBase cmdletCtrl =
                                new GetControlCmdletBase();
                            cmdletCtrl.InputObject =
                                new AutomationElement[]{ window };
                            cmdletCtrl.Timeout = 0;
                            
                            
                            
                            exitInnerCycle = false;
                            bool addToResultCollection = false;
                            foreach (Hashtable ht in cmdlet.WithControl)
                            {
                                cmdletCtrl.SearchCriteria = new Hashtable[] { ht };

                                cmdlet.WriteVerbose(cmdlet, "searching for controls that match the following critetion: " + ht.ToString());
                                
                                try {
                                
                                    ArrayList controlsList =
                                        GetControl(cmdletCtrl);
                                    
                                    if (null != controlsList && 0 < controlsList.Count) {
                                        
                                        cmdlet.WriteVerbose(cmdlet, "there are " + controlsList.Count.ToString() + " result(s) after the search");
                                        addToResultCollection = true;
                                    } else { //20130713
                                        
                                        cmdlet.WriteVerbose(cmdlet, "there weren't found controls that match the criterion");
                                        exitInnerCycle = true;
                                        addToResultCollection = false;
                                        break;
                                    }
                            
                                }
                                
                                catch (Exception eWindowIsGone) {
                                    
                                    // forcing to a next loop
                                    aeWndCollection.Clear();
                                    break;
                                    
                                }
                            }

                            /*
                            for (int iSearchCriterion = 0; iSearchCriterion < cmdlet.WithControl.Length; iSearchCriterion++) {
                                
                                cmdletCtrl.SearchCriteria = new Hashtable[]{ cmdlet.WithControl[iSearchCriterion] };
                                
                                cmdlet.WriteVerbose(cmdlet, "searching for controls that match the following critetion: " + cmdlet.WithControl[iSearchCriterion].ToString());
                                
                                try {
                                
                                    ArrayList controlsList =
                                        GetControl(cmdletCtrl);
                                    
                                    if (null != controlsList && 0 < controlsList.Count) {
                                        
                                        cmdlet.WriteVerbose(cmdlet, "there are " + controlsList.Count.ToString() + " result(s) after the search");
                                        addToResultCollection = true;
                                    } else { //20130713
                                        
                                        cmdlet.WriteVerbose(cmdlet, "there weren't found controls that match the criterion");
                                        exitInnerCycle = true;
                                        addToResultCollection = false;
                                        break;
                                    }
                            
                                }
                                
                                catch (Exception eWindowIsGone) {
                                    
                                    // forcing to a next loop
                                    aeWndCollection.Clear();
                                    break;
                                    
                                }
                            
                            } //20130713
                            */

                            if (addToResultCollection) {
                                filteredWindows.Add(window);
                            }
                        }
                        
                        aeWndCollection = filteredWindows;
                    }
                }
                
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
                
            } catch (Exception eEvaluatingWindowAndWritingToPipeline) {
                
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
            // 20131105
            // refactoring
            IEnumerable<string> processNames,
            /*
            string[] processNames,
            */
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
                    foreach (Process process in processes) {
                        processIdList.Add(process.Id);
                    }
                }
                catch {
                    return aeWndCollectionByProcId;
                }
            
            } // 20120824
            
            int[] processIds = (int[])processIdList.ToArray(typeof(int));
            aeWndCollectionByProcId = getWindowCollectionByPID(processIds, first, recurse, name, automationId, className);
            
            return aeWndCollectionByProcId;
        }
        
        private ArrayList getWindowCollectionByPID(
            // 20131105
            // refactoring
            IEnumerable<int> processIds,
            /*
            int[] processIds,
            */
            bool first,
            bool recurse,
            ICollection<string> name,
            //string[] name,
            string automationId,
            string className)
        {
            System.Windows.Automation.AndCondition conditionsProcessId = null;
            System.Windows.Automation.AndCondition conditionsForRecurseSearch = null;
            ArrayList aeWndCollectionByProcessId = 
                new ArrayList();
            
            if ((null != name && 0 < name.Count) ||
                !string.IsNullOrEmpty(automationId) ||
                !string.IsNullOrEmpty(className)) {
                
                recurse = true;
            }

            /*
            if ((null != name && 0 < name.Length) ||
                (null != automationId && string.Empty != automationId) ||
                (null != className && string.Empty != className)) {
                
                recurse = true;
            }
            */

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
                            
                            if (null != rootCollection && 0 < rootCollection.Count)
                            {
                                aeWndCollectionByProcessId.AddRange(rootCollection);

                                //foreach (AutomationElementCollection tempCollection in from AutomationElement rootWindowElement in rootCollection let tempCollection = null select rootWindowElement.FindAll(
                                foreach (AutomationElementCollection tempCollection in from AutomationElement rootWindowElement in rootCollection select rootWindowElement.FindAll(
                                    TreeScope.Descendants,
                                    conditionsForRecurseSearch) into tempCollection where null != tempCollection && 0 < tempCollection.Count select tempCollection)
                                {
                                    aeWndCollectionByProcessId.AddRange(tempCollection);
                                }

                                /*
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
                                */
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
                    processId > 0) {
                    WriteVerbose(this, "aeWndByProcId: " +
                                 "is caught by processId = " + processId.ToString());
                }
                else{
                    this.WriteVerbose(this, "aeWndByProcId is still null");
                }
            
            } // 20120824
            
            // 20130225
            if (!recurse ||
                ((null == name || 0 >= name.Count) && string.IsNullOrEmpty(automationId) &&
                 string.IsNullOrEmpty(className))) return aeWndCollectionByProcessId;

            /*
            if (!recurse ||
                ((null == name || 0 >= name.Length) && (null == automationId || string.Empty == automationId) &&
                 (null == className || string.Empty == className))) return aeWndCollectionByProcessId;
            */
            ArrayList resultList =
                new ArrayList();
                
            if (null != name && 0 < name.Count) {
                foreach (string n in name) {
                        
                    resultList.AddRange(
                        ReturnOnlyRightElements(
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

            /*
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
            */

            return aeWndCollectionByProcessId;
        }
        
        private ArrayList getWindowCollectionViaWin32(
            bool first,
            bool recurse,
            string[] name,
            string automationId,
            string className)
        {
            
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
            IEnumerable<Process> processes,
            /*
            Process[] processes,
            */
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
            
            if (null == windowNames) {
                windowNames = new string[]{ string.Empty };
            }
            
            foreach (string windowTitle in windowNames) {
            
                WriteVerbose(this, "processName.Length == 0");
                
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
                             windowTitle);
                
                AutomationElementCollection aeWndCollection = null;
                aeWndCollection = rootElement.FindAll(recurse ? TreeScope.Descendants : TreeScope.Children, conditionsSet);

                /*
                if (recurse) {
                    aeWndCollection =
                        rootElement.FindAll(TreeScope.Descendants,
                                            conditionsSet);
                } else {
                    
                    aeWndCollection =
                        rootElement.FindAll(TreeScope.Children,
                                            conditionsSet);
                }
                */

                this.WriteVerbose(this, "trying to run the returnOnlyRightElements method");
                this.WriteVerbose(this, "collected " + aeWndCollection.Count.ToString() + " elements for further selection");
                
                aeWndCollectionByTitle =
                    HasTimeoutCmdletBase.ReturnOnlyRightElements(
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
                
                if (null != aeWndCollectionByTitle && 0 < aeWndCollectionByTitle.Count) {
                    
                    foreach (AutomationElement aeWndByTitle in aeWndCollectionByTitle.Cast<AutomationElement>().Where(aeWndByTitle => aeWndByTitle != null &&
                                                                                                                                      (int)aeWndByTitle.Current.ProcessId > 0))
                    {
                        WriteVerbose(this, "aeWndByTitle: " +
                                           aeWndByTitle.Current.Name +
                                           " is caught be title = " + windowTitle);
                                
                        resultCollection.Add(aeWndByTitle);
                    }

                    /*
                    foreach (AutomationElement aeWndByTitle in aeWndCollectionByTitle) {
                        
                        if (aeWndByTitle != null &&
                            (int)aeWndByTitle.Current.ProcessId > 0) {
                            WriteVerbose(this, "aeWndByTitle: " +
                                         aeWndByTitle.Current.Name +
                                         " is caught be title = " + windowTitle);
                                
                                resultCollection.Add(aeWndByTitle);
                                
                        } 
                        
                    } // 20120831
                    */

                } else {
                    
                    AutomationElement tempElement = null;
                    
                    // one more attempt using the FindWindow function
                    System.IntPtr wndHandle =
                        FindWindowByCaption(System.IntPtr.Zero, windowTitle);
                    if (wndHandle != null && wndHandle != System.IntPtr.Zero) {
                        tempElement =
                            AutomationElement.FromHandle(wndHandle);
                    }

                    if (null == tempElement || (int) tempElement.Current.ProcessId <= 0) continue;
                    WriteVerbose(this, "aeWndByTitle: " +
                                       " is caught by title = " + windowTitle +
                                       " using the FindWindow function");
                        
                    resultCollection.Add(tempElement);

                    /*
                    if (null != tempElement && (int)tempElement.Current.ProcessId > 0) {
                        WriteVerbose(this, "aeWndByTitle: " +
                                     " is caught by title = " + windowTitle +
                                     " using the FindWindow function");
                        
                        resultCollection.Add(tempElement);
                        
                    }
                    */
                }
                
            } // 20120824
            
            return resultCollection;
        }
        
        private void checkTimeout(GetWindowCmdletBase cmdlet,
                                  ArrayList aeWindowList,
                                  bool fromCmdlet)
        {
            SleepAndRunScriptBlocks(this);
            System.DateTime nowDate = System.DateTime.Now;
            WriteVerbose(this, "process: " +
                         cmdlet.ProcessName +
                         ", name: " +
                         cmdlet.Name +
                         ", seconds: " + (nowDate - StartDate).TotalSeconds);
            try {
                if ((null == aeWindowList || aeWindowList.Count <= 0) &&
                    !((nowDate - StartDate).TotalSeconds > this.Timeout/1000)) return;
                if (null == aeWindowList) {
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
                    
                if (!cmdlet.WaitNoWindow) {
                    this.Wait = false;
                }
                // break;

                /*
                if ((null != aeWindowList && //(int)((AutomationElement)aeWindowList[0]).Current.ProcessId > 0) ||
                     aeWindowList.Count > 0) ||
                    (nowDate - StartDate).TotalSeconds > this.Timeout / 1000)
                {
                    if (null == aeWindowList) {
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
                    
                    if (!cmdlet.WaitNoWindow) {
                        this.Wait = false;
                    }
                    // break;
                }
                */

            } catch (Exception eEvaluatingWindowOrMeasuringTimeout) {
                WriteDebug(this, "exception: " +
                           eEvaluatingWindowOrMeasuringTimeout.Message);
                
                cmdlet.WriteError(
                    cmdlet,
                    "An error raised during checking the timeout. " +
                    eEvaluatingWindowOrMeasuringTimeout.Message,
                    "CheckingTimeout",
                    ErrorCategory.InvalidOperation,
                    true);
            }
        }
        
        internal static ArrayList ReturnOnlyRightElements(
            HasTimeoutCmdletBase cmdlet,
            IEnumerable results,
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
            
            if (string.IsNullOrEmpty(name) || 0 == name.Length) { name = "*"; }
            if (string.IsNullOrEmpty(automationId) || 0 == automationId.Length) { automationId = "*"; }
            if (string.IsNullOrEmpty(className) || 0 == className.Length) { className = "*"; }
            if (string.IsNullOrEmpty(textValue) || 0 == textValue.Length) { textValue = "*"; }

            /*
            if (null == name || string.Empty == name || 0 == name.Length) { name = "*"; }
            if (null == automationId || string.Empty == automationId || 0 == automationId.Length) { automationId = "*"; }
            if (null == className || string.Empty == className || 0 == className.Length) { className = "*"; }
            if (null == textValue || string.Empty == textValue || 0 == textValue.Length) { textValue = "*"; }
            */

            WildcardPattern wildcardName = 
                new WildcardPattern(name, options);
            WildcardPattern wildcardAutomationId = 
                new WildcardPattern(automationId, options);
            WildcardPattern wildcardClass = 
                new WildcardPattern(className, options);
            WildcardPattern wildcardValue = 
                new WildcardPattern(textValue, options);
            cmdlet.WriteVerbose(cmdlet, "inside the returnOnlyRightElements method 20");
                System.Collections.Generic.List<AutomationElement> list = results.Cast<AutomationElement>().ToList();
            /*
                foreach (AutomationElement elt in results)
                {

                    list.Add(elt);

                }
            */

            try {
                
                var query = list
                    .Where<AutomationElement>(
                        item => (wildcardName.IsMatch(item.Current.Name) &&
                                 wildcardAutomationId.IsMatch(item.Current.AutomationId) &&
                                 wildcardClass.IsMatch(item.Current.ClassName) &&
                                 // check whether a control has or hasn't ValuePattern
                                 (item.GetSupportedPatterns().Contains(ValuePattern.Pattern) ?
                                  cmdlet.testRealValueAndValueParameter(item, name, automationId, className, textValue, wildcardValue) :
                                  // check whether the -Value parameter has or hasn't value
                                  ("*" == textValue ? true : false)
                                 )
                                )
                       )
                    .ToArray<AutomationElement>();

                cmdlet.WriteVerbose(
                        cmdlet,
                        "There are " +
                        query.Count().ToString() +
                        " elements");

                resultCollection.AddRange(query);

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
