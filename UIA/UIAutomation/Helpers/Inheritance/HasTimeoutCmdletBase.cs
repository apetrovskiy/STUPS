/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 29.11.2011
 * Time: 14:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Threading;

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Description of HasTimeoutCmdletBase.
    /// </summary>
    public class HasTimeoutCmdletBase : HasControlInputCmdletBase
    {
        // http://pinvoke.net/default.aspx/user32.FindWindow
        [DllImport("user32.dll", EntryPoint="FindWindow", SetLastError = true)]
        private static extern IntPtr FindWindowByCaption(IntPtr zeroOnly, string lpWindowName);
        // You can also call FindWindow(default(string), lpWindowName) or FindWindow((string)null, lpWindowName)
        
        #region Constructor
        public HasTimeoutCmdletBase()
        {
            //this.WriteVerbose(this, "constructor");
            
            Wait = true;
            Timeout = Preferences.Timeout;
            Seconds = Timeout / 1000;
            OnErrorScreenShot = Preferences.OnErrorScreenShot;
            OnSuccessAction = null;
            OnErrorAction = null;
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
        /// This variable is used in 'negative result' cmdlets like Wait-UiaNoWindow
        /// </summary>
        protected bool WaitNoWindow { get; set; }
        
        protected override void StopProcessing()
        {
            WriteVerbose(this, "User interrupted");
            Wait = false;
        }
        
        // 20131202
        // internal ArrayList GetWindow(
        internal List<IMySuperWrapper> GetWindow(
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
            // 20131202
            // ArrayList aeWndCollection = new ArrayList();
            List<IMySuperWrapper> aeWndCollection = new List<IMySuperWrapper>();
            
            cmdlet.WriteVerbose(cmdlet, "getting the root element");
            OddRootElement =
                MySuperWrapper.RootElement;
            if (OddRootElement == null)
            {
                cmdlet.WriteVerbose(cmdlet, "rootElement == null");
                return aeWndCollection;
            }
            else
            {
                cmdlet.WriteVerbose(cmdlet, "rootElement: " + OddRootElement.Current);
            }
            
            bool wasFound = false;
            do {
                
                if (win32) {
                    
                    cmdlet.WriteVerbose(cmdlet, "getting a window via Win32 API");
                    aeWndCollection = GetWindowCollectionViaWin32(cmdlet.First, cmdlet.Recurse, cmdlet.Name, cmdlet.AutomationId, cmdlet.Class);
                    
                } else if (null != processes && processes.Length > 0) {
                    cmdlet.WriteVerbose(cmdlet, "getting a window by process");
                    aeWndCollection = GetWindowCollectionFromProcess(processes, cmdlet.First, cmdlet.Recurse, cmdlet.Name, cmdlet.AutomationId, cmdlet.Class);

                } else if (null != processIds && processIds.Length > 0) {

                    cmdlet.WriteVerbose(cmdlet, "getting a window by PID");
                    aeWndCollection = GetWindowCollectionByPid(processIds, cmdlet.First, cmdlet.Recurse, cmdlet.Name, cmdlet.AutomationId, cmdlet.Class);

                } else if (null != processNames && processNames.Length > 0) {

                    cmdlet.WriteVerbose(cmdlet, "getting a window by name");
                    aeWndCollection = GetWindowCollectionByProcessName(processNames, cmdlet.First, cmdlet.Recurse, cmdlet.Name, cmdlet.AutomationId, cmdlet.Class);

                } else if ((null != windowNames && windowNames.Length > 0) ||
                           !string.IsNullOrEmpty(automationId) ||
                           !string.IsNullOrEmpty(className)) {
                            
                            cmdlet.WriteVerbose(cmdlet, "getting a window by name, automationId, className");
                            aeWndCollection = GetWindowCollectionByName(windowNames, automationId, className, cmdlet.Recurse);
                }
                
                // filtering result window collection by SearchCriteria
                if (null != aeWndCollection && 0 < aeWndCollection.Count) {
                    
                    cmdlet.WriteVerbose(cmdlet, "one or several windows were found by name, process name, process id or process object");
                    
                    if (null != cmdlet.SearchCriteria && 0 < cmdlet.SearchCriteria.Length) {
                    
                        cmdlet.WriteVerbose(cmdlet, "processing SearchCriteria");
                        
                        aeWndCollection =
                            cmdlet.GetFilteredElementsCollection(
                                cmdlet,
                                aeWndCollection);
                    }
                }
                    
                // filtering result window collection by having a control(s) with properties as from WithControl
                if (null != aeWndCollection && 0 < aeWndCollection.Count) {
                
                    cmdlet.WriteVerbose(cmdlet, "one or several windows were not excluded by SearchCriteria");
                    
                    if (null != cmdlet.WithControl && 0 < cmdlet.WithControl.Length) {
                    
                        cmdlet.WriteVerbose(cmdlet, "processing WithControl");
                        
                        // 20131202
                        // ArrayList filteredWindows =
                        //     new ArrayList();
                        List<IMySuperWrapper> filteredWindows =
                            new List<IMySuperWrapper>();
        
                        cmdlet.WriteVerbose(cmdlet, "searching for control(s) for every window, one by one");
                        
                        bool exitInnerCycle = false;
                        
                        foreach (IMySuperWrapper window in aeWndCollection) {
                            
                            cmdlet.WriteVerbose(cmdlet, "Window: name='" + window.Current.Name + "', automaitonId='" + window.Current.AutomationId + "'");
                            
//                            if (exitInnerCycle) {
//                                //break;
//                                window = null;
//                                continue;
//                            }
                            
                            GetControlCmdletBase cmdletCtrl =
                                new GetControlCmdletBase
                                {
                                    InputObject = new MySuperWrapper[] {(MySuperWrapper) window},
                                    Timeout = 0
                                };

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
                
                CheckTimeout(cmdlet, aeWndCollection, true);
                
                Thread.Sleep(Preferences.OnSleepDelay);
                
            } while (cmdlet.Wait);
            try {
                
                if (null != aeWndCollection && (int)((IMySuperWrapper)aeWndCollection[0]).Current.ProcessId > 0) {
                    
                    cmdlet.WriteVerbose(cmdlet, "" + aeWndCollection.ToString());
                    
                    cmdlet.WriteVerbose(cmdlet, 
                                        "aeWnd.Current.GetType() = " +
                                        ((IMySuperWrapper)aeWndCollection[0]).GetType().Name);
                    
                } // 20120127
                
                CurrentData.CurrentWindow = (IMySuperWrapper)aeWndCollection[aeWndCollection.Count -1];
                
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
        
        // 20131202
        // private ArrayList GetWindowCollectionByProcessName(
        private List<IMySuperWrapper> GetWindowCollectionByProcessName(
            IEnumerable<string> processNames,
            bool first,
            bool recurse,
            ICollection<string> name,
            string automationId,
            string className)
        {
            // 20131202
            // ArrayList aeWndCollectionByProcId = new ArrayList();
            // ArrayList processIdList = new ArrayList();
            List<IMySuperWrapper> aeWndCollectionByProcId = new List<IMySuperWrapper>();
            List<int> processIdList = new List<int>();
            
            foreach (string processName in processNames) {
            
                try {
                    
                    WriteVerbose(this, "getting process Id");
                    
                    Process[] processes =
                        Process.GetProcessesByName(processName);
                    foreach (Process process in processes) {
                        processIdList.Add(process.Id);
                    }
                }
                catch {
                    return aeWndCollectionByProcId;
                }
            
            } // 20120824
            
            // int[] processIds = (int[])processIdList.ToArray(typeof(int));
            int[] processIds = processIdList.ToArray();
            aeWndCollectionByProcId = GetWindowCollectionByPid(processIds, first, recurse, name, automationId, className);
            
            return aeWndCollectionByProcId;
        }
        
        // 20131202
        // private ArrayList GetWindowCollectionByPid(
        private List<IMySuperWrapper> GetWindowCollectionByPid(
            IEnumerable<int> processIds,
            bool first,
            bool recurse,
            ICollection<string> name,
            string automationId,
            string className)
        {
            AndCondition conditionsForRecurseSearch = null;
            
            // 20131202
            // ArrayList aeWndCollectionByProcessId = 
            //     new ArrayList();
            // IMySuperCollection elementsByProcessId =
            //     new MySuperCollection(true);
            List<IMySuperWrapper> elementsByProcessId =
                new List<IMySuperWrapper>();
            
            if ((null != name && 0 < name.Count) ||
                !string.IsNullOrEmpty(automationId) ||
                !string.IsNullOrEmpty(className)) {
                
                recurse = true;
            }
            
            foreach (int processId in processIds) {
                AndCondition conditionsProcessId = null;
                try {
                    
                    conditionsProcessId =
                        new AndCondition(
                            new PropertyCondition(
                                AutomationElement.ProcessIdProperty,
                                processId),
                            new OrCondition(
                                new PropertyCondition(
                                    AutomationElement.ControlTypeProperty,
                                    ControlType.Window),
                                new PropertyCondition(
                                    AutomationElement.ControlTypeProperty,
                                    ControlType.Pane),
                                new PropertyCondition(
                                    AutomationElement.ControlTypeProperty,
                                    ControlType.Menu)));
                    
                    if (recurse) {
                        conditionsForRecurseSearch =
                            new AndCondition(
                                new PropertyCondition(
                                    AutomationElement.ProcessIdProperty,
                                    processId),
                                new PropertyCondition(
                                    AutomationElement.ControlTypeProperty,
                                    ControlType.Window));
                    }
                    
                    WriteVerbose(this, "using processId = " +
                                 processId.ToString() +
                                 " and ControlType.Window or ControlType.Pane conditions");
                } catch { // 20120206  (Exception eCouldNotGetProcessId) {
                    // if (fromCmdlet) WriteDebug(this, "" + eCouldNotGetProcessId.Message);
                    
                    conditionsProcessId =
                        new AndCondition(
                            new PropertyCondition(
                                AutomationElement.ProcessIdProperty,
                                processId),
                            new OrCondition(
                                new PropertyCondition(
                                    AutomationElement.ControlTypeProperty,
                                    ControlType.Window),
                                new PropertyCondition(
                                    AutomationElement.ControlTypeProperty,
                                    ControlType.Pane),
                                new PropertyCondition(
                                    AutomationElement.ControlTypeProperty,
                                    ControlType.Menu)));
                    
                    if (recurse) {
                        conditionsForRecurseSearch =
                            new AndCondition(
                                new PropertyCondition(
                                    AutomationElement.ProcessIdProperty,
                                    processId),
                                new PropertyCondition(
                                    AutomationElement.ControlTypeProperty,
                                    ControlType.Window));
                    }
                    
                }
                
                WriteVerbose(this, "trying to get aeWndByProcId: by processId = " +
                             processId.ToString());
    
                try {
                    
                    //AutomationElementCollection tempCollection = null;
                    if (recurse) {
                        
                        if (first) {
                            
                            // 20131109
                            //AutomationElement rootWindowElement =
                            IMySuperWrapper rootWindowElement =
                                OddRootElement.FindFirst(
                                    TreeScope.Children,
                                    conditionsProcessId);
                            
                            if (null != rootWindowElement) {
                                
                                // 20131202
                                // aeWndCollectionByProcessId.Add(rootWindowElement);
                                elementsByProcessId.Add(rootWindowElement);
                                
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
                            
                            // 20131109
                            //AutomationElementCollection rootCollection =
                            IMySuperCollection rootCollection =
                                OddRootElement.FindAll(
                                    TreeScope.Children,
                                    conditionsProcessId);
                            
                            if (null != rootCollection && 0 < rootCollection.Count)
                            {
                                // 20131111
                                //aeWndCollectionByProcessId.AddRange(rootCollection);
                                foreach (IMySuperWrapper singleElement in rootCollection) {
                                    // 20131202
                                    // aeWndCollectionByProcessId.Add(singleElement);
                                    elementsByProcessId.Add(singleElement);
                                }

                                //foreach (AutomationElementCollection tempCollection in from AutomationElement rootWindowElement in rootCollection let tempCollection = null select rootWindowElement.FindAll(
                                // 20131109
                                foreach (IMySuperWrapper singleElement in (from IMySuperWrapper rootWindowElement in rootCollection select rootWindowElement.FindAll(
                                    TreeScope.Descendants,
                                    conditionsForRecurseSearch) into tempCollection where null != tempCollection && 0 < tempCollection.Count select tempCollection).SelectMany(tempCollection => rootCollection.Cast<IMySuperWrapper>()))
                                {
                                    // 20131102
                                    // aeWndCollectionByProcessId.Add(singleElement);
                                    elementsByProcessId.Add(singleElement);
                                }
                                /*
                                foreach (IMySuperCollection tempCollection in from IMySuperWrapper rootWindowElement in rootCollection select rootWindowElement.FindAll(
                                    TreeScope.Descendants,
                                    conditionsForRecurseSearch) into tempCollection where null != tempCollection && 0 < tempCollection.Count select tempCollection)
                                {
                                    // 20131111
                                    //aeWndCollectionByProcessId.AddRange(tempCollection);
                                    foreach (IMySuperWrapper singleElement in rootCollection) {
                                        aeWndCollectionByProcessId.Add(singleElement);
                                    }
                                }
                                */

                                /*
                                foreach (AutomationElementCollection tempCollection in from AutomationElement rootWindowElement in rootCollection select rootWindowElement.FindAll(
                                    TreeScope.Descendants,
                                    conditionsForRecurseSearch) into tempCollection where null != tempCollection && 0 < tempCollection.Count select tempCollection)
                                {
                                    aeWndCollectionByProcessId.AddRange(tempCollection);
                                }
                                */

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
                            
                            IMySuperWrapper tempElement =
                                OddRootElement.FindFirst(TreeScope.Children,
                                                      conditionsProcessId);
                            
                            if (null != tempElement) {
                                // 20131202
                                // aeWndCollectionByProcessId.Add(tempElement);
                                elementsByProcessId.Add(tempElement);
                            }
                        } else {
                            
                            IMySuperCollection tempCollection =
                                OddRootElement.FindAll(TreeScope.Children,
                                                    conditionsProcessId);
                            

                            
                            if (null != tempCollection && 0 < tempCollection.Count) {
                                
                                //aeWndCollectionByProcessId.AddRange(tempCollection);
                                foreach (IMySuperWrapper newElement in tempCollection) {
                                    // 20131202
                                    // aeWndCollectionByProcessId.Add(newElement);
                                    elementsByProcessId.Add(newElement);
                                }
                            }
                        }
                    }
                } catch (Exception eGetFirstChildOfRootByProcessId) {
                    
                    WriteVerbose(
                        this,
                        "exception: " +
                        eGetFirstChildOfRootByProcessId.Message);
                }
                
                // 20131202
                // if (null != aeWndCollectionByProcessId &&
                if (null != elementsByProcessId &&
                    processId > 0) {
                    WriteVerbose(this, "aeWndByProcId: " +
                                 "is caught by processId = " + processId.ToString());
                }
                else{
                    WriteVerbose(this, "aeWndByProcId is still null");
                }
            
            } // 20120824
            
            // 20130225
            if (!recurse ||
                ((null == name || 0 >= name.Count) && string.IsNullOrEmpty(automationId) &&
                 // 20131202
                 // string.IsNullOrEmpty(className))) return aeWndCollectionByProcessId;
                 string.IsNullOrEmpty(className))) return elementsByProcessId;
            
            // 20131202
            // ArrayList resultList =
            //     new ArrayList();
            List<IMySuperWrapper> resultList =
                new List<IMySuperWrapper>();
                
            if (null != name && 0 < name.Count) {
                foreach (string n in name) {
                        
                    resultList.AddRange(
                        ReturnOnlyRightElements(
                            this,
                            // 20131202
                            // aeWndCollectionByProcessId,
                            elementsByProcessId,
                            n,
                            automationId,
                            className,
                            string.Empty,
                            new string[]{ "Window" },
                            false,
                            true));
                    
                }
            } else {
                    
                resultList.AddRange(
                    ReturnOnlyRightElements(
                        this,
                        // 20131202
                        // aeWndCollectionByProcessId,
                        elementsByProcessId,
                        string.Empty,
                        automationId,
                        className,
                        string.Empty,
                        new string[]{ "Window" },
                        false,
                        true));
            }
            
            // 20131202
            // aeWndCollectionByProcessId = resultList;
            elementsByProcessId = resultList;
            
            // 20131202
            // return aeWndCollectionByProcessId;
            return elementsByProcessId;
        }
        
        // 20131202
        // private ArrayList GetWindowCollectionViaWin32(
        private List<IMySuperWrapper> GetWindowCollectionViaWin32(
            bool first,
            bool recurse,
            string[] name,
            string automationId,
            string className)
        {
            // 20131202
            // ArrayList aeWndCollectionViaWin32 = new ArrayList();
            List<IMySuperWrapper> aeWndCollectionViaWin32 = new List<IMySuperWrapper>();
            
            aeWndCollectionViaWin32 =
                UiaHelper.EnumChildWindowsFromHandle(
                    (GetWindowCmdletBase)this,
                    IntPtr.Zero);
            
            return aeWndCollectionViaWin32;
            
//            }
        }
        
        // 20131202
        // private ArrayList GetWindowCollectionFromProcess(
        private List<IMySuperWrapper> GetWindowCollectionFromProcess(
            IEnumerable<Process> processes,
            bool first,
            bool recurse,
            ICollection<string> name,
            string automationId,
            string className)
        {
            // 20131202
            // ArrayList aeWndCollectionByProcId = new ArrayList();
            // ArrayList tempCollection = new ArrayList();
            List<IMySuperWrapper> aeWndCollectionByProcId = new List<IMySuperWrapper>();
            List<IMySuperWrapper> tempCollection = new List<IMySuperWrapper>();
            
            ArrayList processIdList = 
                new ArrayList();

            foreach (Process process in processes) {
                
            try {
                int processId = process.Id;
                if (0 != processId) {
                    processIdList.Add(processId);
                }
                
                WriteVerbose(this, "processId = " + processId.ToString());

                int[] processIds = (int[])processIdList.ToArray(typeof(int));
                
                if (null == processIds) {
                    WriteVerbose(this, "!!!!!!!!!!!!!!!!!!!! null == processIds !!!!!!!!!");
                }
                
                tempCollection = GetWindowCollectionByPid(processIds, first, recurse, name, automationId, className);
                
                foreach (IMySuperWrapper tempElement in tempCollection) {
                    
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
        
        // 20131202
        // private ArrayList GetWindowCollectionByName(string[] windowNames, string automationId, string className, bool recurse)
        private List<IMySuperWrapper> GetWindowCollectionByName(string[] windowNames, string automationId, string className, bool recurse)
        {
            /*
            System.Windows.Automation.OrCondition conditionsSet = null;
            */
           // 20131202
            // ArrayList windowCollectionByProperties = 
            //     new ArrayList();
            // ArrayList resultCollection = 
            //     new ArrayList();
            List<IMySuperWrapper> windowCollectionByProperties =
                new List<IMySuperWrapper>();
            List<IMySuperWrapper> resultCollection =
                new List<IMySuperWrapper>();
            
            if (null == windowNames) {
                windowNames = new string[]{ string.Empty };
            }
            
            foreach (string windowTitle in windowNames) {
            
                WriteVerbose(this, "processName.Length == 0");

                OrCondition conditionsSet = null;
                if (recurse) {
                    conditionsSet =
                        new OrCondition(
                            new PropertyCondition(
                                AutomationElement.ControlTypeProperty,
                                ControlType.Window),
                            Condition.FalseCondition);
                } else {
                    conditionsSet =
                        new OrCondition(
                            new PropertyCondition(
                                AutomationElement.ControlTypeProperty,
                                ControlType.Window),
                            new PropertyCondition(
                                AutomationElement.ControlTypeProperty,
                                ControlType.Pane),
                            new PropertyCondition(
                                AutomationElement.ControlTypeProperty,
                                ControlType.Menu));
                }
                WriteVerbose(this, "trying to get window: by title = " +
                             windowTitle);
                
                IMySuperCollection windowCollection =
                    OddRootElement.FindAll(recurse ? TreeScope.Descendants : TreeScope.Children, conditionsSet);
                
                WriteVerbose(this, "trying to run the returnOnlyRightElements method");
                WriteVerbose(this, "collected " + windowCollection.Count.ToString() + " elements for further selection");
                
                windowCollectionByProperties =
                    ReturnOnlyRightElements(
                        this,
                        windowCollection,
                        windowTitle,
                        automationId,
                        className,
                        string.Empty,
                        (new string[]{ "Window", "Pane", "Menu" }),
                        false,
                        true);
                
                WriteVerbose(this, "after running the returnOnlyRightElements method");
                WriteVerbose(this, "collected " + windowCollectionByProperties.Count.ToString() + " elements");
                
                if (null != windowCollectionByProperties && 0 < windowCollectionByProperties.Count) {
                    
                    // 20131109
                    foreach (IMySuperWrapper aeWndByTitle in windowCollectionByProperties.Cast<IMySuperWrapper>().Where(aeWndByTitle => aeWndByTitle != null &&
                                                                                                                                      (int)aeWndByTitle.Current.ProcessId > 0))
                    {
                        WriteVerbose(this, "aeWndByTitle: " +
                                           aeWndByTitle.Current.Name +
                                           " is caught be title = " + windowTitle);
                                
                        resultCollection.Add(aeWndByTitle);
                    }
                    
                    /*
                    foreach (AutomationElement aeWndByTitle in windowCollectionByProperties.Cast<AutomationElement>().Where(aeWndByTitle => aeWndByTitle != null &&
                                                                                                                                      (int)aeWndByTitle.Current.ProcessId > 0))
                    {
                        WriteVerbose(this, "aeWndByTitle: " +
                                           aeWndByTitle.Current.Name +
                                           " is caught be title = " + windowTitle);
                                
                        resultCollection.Add(aeWndByTitle);
                    }
                    */

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
                    
                    IMySuperWrapper tempElement = null;
                    
                    // one more attempt using the FindWindow function
                    IntPtr wndHandle =
                        FindWindowByCaption(IntPtr.Zero, windowTitle);
                    if (wndHandle != null && wndHandle != IntPtr.Zero) {
                        tempElement =
                            MySuperWrapper.FromHandle(wndHandle);
                    }

                    if (null == tempElement || (int) tempElement.Current.ProcessId <= 0) continue;
                    WriteVerbose(this, "aeWndByTitle: " +
                                       " is caught by title = " + windowTitle +
                                       " using the FindWindow function");
                        
                    resultCollection.Add(tempElement);
                }
                
            } // 20120824
            
            return resultCollection;
        }
        
        private void CheckTimeout(GetWindowCmdletBase cmdlet,
                                  ICollection aeWindowList,
                                  bool fromCmdlet)
        {
            cmdlet.WriteVerbose(cmdlet, "OnSleep scriptblocks");
            SleepAndRunScriptBlocks(this);
            DateTime nowDate = DateTime.Now;
            WriteVerbose(this, "process: " +
                         cmdlet.ProcessName +
                         ", name: " +
                         cmdlet.Name +
                         ", seconds: " + (nowDate - StartDate).TotalSeconds);
            try {
                if ((null == aeWindowList || aeWindowList.Count <= 0) &&
                    !((nowDate - StartDate).TotalSeconds > Timeout/1000)) return;
                if (null == aeWindowList) {
                    Wait = false;
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
                    Wait = false;
                }
                // break;
                
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
        
        // 20131202
        // internal static ArrayList ReturnOnlyRightElements(
        internal static List<IMySuperWrapper> ReturnOnlyRightElements(
            HasTimeoutCmdletBase cmdlet,
            IEnumerable inputCollection,
            string name,
            string automationId,
            string className,
            string textValue,
            string[] controlType,
            bool caseSensitive,
            bool viaWildcardOrRegex)
        {
            // 20131202
            // ArrayList resultCollection = new ArrayList();
            List<IMySuperWrapper> resultCollection = new List<IMySuperWrapper>();
            
            WildcardOptions options;
            if (caseSensitive) {
                options =
                    WildcardOptions.Compiled;
            } else {
                options =
                    WildcardOptions.IgnoreCase |
                    WildcardOptions.Compiled;
            }
            
            RegexOptions regexOptions = RegexOptions.Compiled;
            if (!caseSensitive) {
                regexOptions |= RegexOptions.IgnoreCase;
            }
            
            if (viaWildcardOrRegex) {
                name = string.IsNullOrEmpty(name) ? "*" : name;
                automationId = string.IsNullOrEmpty(automationId) ? "*" : automationId;
                className = string.IsNullOrEmpty(className) ? "*" : className;
                textValue = string.IsNullOrEmpty(textValue) ? "*" : textValue;
            } else {
                name = string.IsNullOrEmpty(name) ? ".*" : name;
                automationId = string.IsNullOrEmpty(automationId) ? ".*" : automationId;
                className = string.IsNullOrEmpty(className) ? ".*" : className;
                textValue = string.IsNullOrEmpty(textValue) ? ".*" : textValue;
            }
            
            /*
            if (string.IsNullOrEmpty(name) || 0 == name.Length) { name = "*"; }
            if (string.IsNullOrEmpty(automationId) || 0 == automationId.Length) { automationId = "*"; }
            if (string.IsNullOrEmpty(className) || 0 == className.Length) { className = "*"; }
            if (string.IsNullOrEmpty(textValue) || 0 == textValue.Length) { textValue = "*"; }
            */
            
            /*
            if (null == name || string.Empty == name || 0 == name.Length) { name = "*"; }
            if (null == automationId || string.Empty == automationId || 0 == automationId.Length) { automationId = "*"; }
            if (null == className || string.Empty == className || 0 == className.Length) { className = "*"; }
            if (null == textValue || string.Empty == textValue || 0 == textValue.Length) { textValue = "*"; }
            */
            
           //if (viaWildcardOrRegex) {
            WildcardPattern wildcardName = 
                new WildcardPattern(name, options);
            WildcardPattern wildcardAutomationId = 
                new WildcardPattern(automationId, options);
            WildcardPattern wildcardClass = 
                new WildcardPattern(className, options);
            WildcardPattern wildcardValue = 
                new WildcardPattern(textValue, options);
            
           //}
            /*
            WildcardPattern wildcardName = 
                new WildcardPattern(string.IsNullOrEmpty(name) ? "*" : name, options);
            WildcardPattern wildcardAutomationId = 
                new WildcardPattern(string.IsNullOrEmpty(automationId) ? "*" : automationId, options);
            WildcardPattern wildcardClass = 
                new WildcardPattern(string.IsNullOrEmpty(className) ? "*" : className, options);
            WildcardPattern wildcardValue = 
                new WildcardPattern(string.IsNullOrEmpty(textValue) ? "*" : textValue, options);
            */
            
            List<IMySuperWrapper> inputList = inputCollection.Cast<IMySuperWrapper>().ToList();
            
            cmdlet.WriteVerbose(
                    cmdlet,
                    "ReturnOnlyRightElements: there are " +
                    inputList.Count.ToString() +
                    " elements");
            
            /*
                foreach (AutomationElement elt in results)
                {

                    list.Add(elt);

                }
            */

            try {
               
                // 20131202
                // ICollection query;
                List<IMySuperWrapper> query;
                
                if (viaWildcardOrRegex) {
                    query = inputList
                        .Where<IMySuperWrapper>(
                            item => (wildcardName.IsMatch(item.Current.Name) &&
                                     wildcardAutomationId.IsMatch(item.Current.AutomationId) &&
                                     wildcardClass.IsMatch(item.Current.ClassName) &&
                                     // check whether a control has or hasn't ValuePattern
                                     (item.GetSupportedPatterns().Contains(ValuePattern.Pattern) ?
                                      cmdlet.CompareElementValueAndValueParameter(item, textValue, true, wildcardValue, regexOptions) :
                                      // check whether the -Value parameter has or hasn't value
                                      ("*" == textValue ? true : false)
                                     )
                                    )
                           )
                        .ToList<IMySuperWrapper>();
                        // .ToArray<IMySuperWrapper>();
               } else {
                   
                    query = inputList
                        .Where<IMySuperWrapper>(
                            item => (Regex.IsMatch(item.Current.Name, name, regexOptions) &&
                                     Regex.IsMatch(item.Current.AutomationId, automationId, regexOptions) &&
                                     Regex.IsMatch(item.Current.ClassName, className, regexOptions) &&
                                     // check whether a control has or hasn't ValuePattern
                                     (item.GetSupportedPatterns().Contains(ValuePattern.Pattern) ?
                                      cmdlet.CompareElementValueAndValueParameter(item, textValue, false, null, regexOptions) :
                                      // check whether the -Value parameter has or hasn't value
                                      (".*" == textValue ? true : false)
                                     )
                                    )
                           )
                        .ToList<IMySuperWrapper>();
                        // .ToArray<IMySuperWrapper>();
               }
                
                cmdlet.WriteVerbose(
                        cmdlet,
                        "There are " +
                        //query.Count().ToString() +
                        query.Count.ToString() +
                        " elements");
                
                resultCollection.AddRange(query);
                
                cmdlet.WriteVerbose(
                    cmdlet,
                    "There are " +
                    resultCollection.Count.ToString() +
                    " elements");
                
            }
            catch (Exception eProcessing) {
                cmdlet.WriteVerbose(eProcessing.Message);
            }
            
            return resultCollection;
        }
        
        /// <summary>
        /// Checks that the -Value parameter matches the value ValuePattern of the element returns
        /// </summary>
        /// <param name="item">IMySuperWrapper element</param>
        /// <param name="textValue">the -Value parameter</param>
        /// <param name="viaWildcardOrRegex">true is wildcard, false is regexp</param>
        /// <param name="wildcardValue">a wildcard object</param>
        /// <param name="regexOptions">a regex options object</param>
        /// <returns></returns>
        protected internal bool CompareElementValueAndValueParameter(
            IMySuperWrapper item,
            string textValue,
            bool viaWildcardOrRegex,
            WildcardPattern wildcardValue,
            RegexOptions regexOptions)
        {
            bool result = false;
            
            // getting the real value of a control
            string realValue = string.Empty;
            try {
                realValue =
                    (item.GetCurrentPattern(ValuePattern.Pattern) as IMySuperValuePattern).Current.Value;
            }
            catch { //(Exception eGetCurrentPattern) {
                // nothing to do
                // usually this place never be reached
            }
            
            result = viaWildcardOrRegex ? wildcardValue.IsMatch(realValue) : Regex.IsMatch(realValue, textValue, regexOptions);
            /*
            if (viaWildcardOrRegex) {
                
                result =
                    wildcardValue.IsMatch(realValue);
            } else {
                
                result =
                    Regex.IsMatch(realValue, textValue, regexOptions);
            }
            */

            return result;
        }
    }
}
