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
    extern alias UIANET;
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
    using System.Threading;

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
        
        internal List<IUiElement> GetWindow(
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
            List<IUiElement> aeWndCollection = new List<IUiElement>();
            
            cmdlet.WriteVerbose(cmdlet, "getting the root element");
            
            OddRootElement =
                UiElement.RootElement;
            
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
                        
                        List<IUiElement> filteredWindows =
                            new List<IUiElement>();
        
                        cmdlet.WriteVerbose(cmdlet, "searching for control(s) for every window, one by one");
                        
                        bool exitInnerCycle = false;
                        
                        foreach (IUiElement window in aeWndCollection) {
                            
                            cmdlet.WriteVerbose(cmdlet, "Window: name='" + window.Current.Name + "', automationId='" + window.Current.AutomationId + "'");
                            
//                            if (exitInnerCycle) {
//                                //break;
//                                window = null;
//                                continue;
//                            }
                            
                            GetControlCmdletBase cmdletCtrl =
                                new GetControlCmdletBase
                                {
                                    InputObject = new UiElement[] {(UiElement) window},
                                    Timeout = 0
                                };

                            exitInnerCycle = false;
                            bool addToResultCollection = false;
                            foreach (Hashtable ht in cmdlet.WithControl)
                            {
                                cmdletCtrl.SearchCriteria = new Hashtable[] { ht };

                                cmdlet.WriteVerbose(cmdlet, "searching for controls that match the following critetion: " + ht.ToString());
                                
                                try {
                                    List<IUiElement> controlsList =
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
                
                if (null != aeWndCollection && (int)((IUiElement)aeWndCollection[0]).Current.ProcessId > 0) {
                    
                    cmdlet.WriteVerbose(cmdlet, "" + aeWndCollection.ToString());
                    
                    cmdlet.WriteVerbose(cmdlet, 
                                        "aeWnd.Current.GetType() = " +
                                        ((IUiElement)aeWndCollection[0]).GetType().Name);
                    
                } // 20120127
                
                CurrentData.CurrentWindow = (IUiElement)aeWndCollection[aeWndCollection.Count -1];
                
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
        
        private List<IUiElement> GetWindowCollectionByProcessName(
            IEnumerable<string> processNames,
            bool first,
            bool recurse,
            ICollection<string> name,
            string automationId,
            string className)
        {
            List<IUiElement> aeWndCollectionByProcId = new List<IUiElement>();
            List<int> processIdList = new List<int>();
            
            foreach (string processName in processNames) {
            
                try {
                    
                    WriteVerbose(this, "getting process Id");
                    
                    Process[] processes =
                        Process.GetProcessesByName(processName);
                    processIdList.AddRange(processes.Select(process => process.Id));
                }
                catch {
                    return aeWndCollectionByProcId;
                }
            
            } // 20120824
            
            int[] processIds = processIdList.ToArray();
            aeWndCollectionByProcId = GetWindowCollectionByPid(processIds, first, recurse, name, automationId, className);
            
            return aeWndCollectionByProcId;
        }
        
        private List<IUiElement> GetWindowCollectionByPid(
            IEnumerable<int> processIds,
            bool first,
            bool recurse,
            ICollection<string> name,
            string automationId,
            string className)
        {
            AndCondition conditionsForRecurseSearch = null;
            
            List<IUiElement> elementsByProcessId =
                new List<IUiElement>();
            
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
                            
                            IUiElement rootWindowElement =
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
                            IUiEltCollection rootCollection =
                                OddRootElement.FindAll(
                                    TreeScope.Children,
                                    conditionsProcessId);
                            
                            if (null != rootCollection && 0 < rootCollection.Count)
                            {
                                // 20131111
                                //aeWndCollectionByProcessId.AddRange(rootCollection);
                                elementsByProcessId.AddRange(rootCollection.Cast<IUiElement>());
                                /*
                                foreach (IUiElement singleElement in rootCollection) {
                                    // 20131202
                                    // aeWndCollectionByProcessId.Add(singleElement);
                                    elementsByProcessId.Add(singleElement);
                                }
                                */

                                //foreach (AutomationElementCollection tempCollection in from AutomationElement rootWindowElement in rootCollection let tempCollection = null select rootWindowElement.FindAll(
                                // 20131109
                                foreach (IUiElement singleElement in (from IUiElement rootWindowElement in rootCollection select rootWindowElement.FindAll(
                                    TreeScope.Descendants,
                                    conditionsForRecurseSearch) into tempCollection where null != tempCollection && 0 < tempCollection.Count select tempCollection).SelectMany(tempCollection => rootCollection.Cast<IUiElement>()))
                                {
                                    // 20131102
                                    // aeWndCollectionByProcessId.Add(singleElement);
                                    elementsByProcessId.Add(singleElement);
                                }
                                /*
                                foreach (IUiEltCollection tempCollection in from IUiElement rootWindowElement in rootCollection select rootWindowElement.FindAll(
                                    TreeScope.Descendants,
                                    conditionsForRecurseSearch) into tempCollection where null != tempCollection && 0 < tempCollection.Count select tempCollection)
                                {
                                    // 20131111
                                    //aeWndCollectionByProcessId.AddRange(tempCollection);
                                    foreach (IUiElement singleElement in rootCollection) {
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
                            
                            IUiElement tempElement =
                                OddRootElement.FindFirst(TreeScope.Children,
                                                      conditionsProcessId);
                            
                            if (null != tempElement) {
                                // 20131202
                                // aeWndCollectionByProcessId.Add(tempElement);
                                elementsByProcessId.Add(tempElement);
                            }
                        } else {
                            
                            IUiEltCollection tempCollection =
                                OddRootElement.FindAll(TreeScope.Children,
                                                    conditionsProcessId);
                            

                            
                            if (null != tempCollection && 0 < tempCollection.Count) {
                                
                                elementsByProcessId.AddRange(tempCollection.Cast<IUiElement>());
                            }
                        }
                    }
                } catch (Exception eGetFirstChildOfRootByProcessId) {
                    
                    WriteVerbose(
                        this,
                        "exception: " +
                        eGetFirstChildOfRootByProcessId.Message);
                }
                
                if (null != elementsByProcessId &&
                    processId > 0) {
                    WriteVerbose(this, "aeWndByProcId: " +
                                 "is caught by processId = " + processId.ToString());
                }
                else{
                    WriteVerbose(this, "aeWndByProcId is still null");
                }
            
            } // 20120824
            
            if (!recurse ||
                ((null == name || 0 >= name.Count) && string.IsNullOrEmpty(automationId) &&
                 string.IsNullOrEmpty(className))) return elementsByProcessId;
            
            List<IUiElement> resultList =
                new List<IUiElement>();
                
            if (null != name && 0 < name.Count) {
                foreach (string n in name) {
                        
                    resultList.AddRange(
                        ReturnOnlyRightElements(
                            this,
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
        
        private List<IUiElement> GetWindowCollectionViaWin32(
            bool first,
            bool recurse,
            string[] name,
            string automationId,
            string className)
        {
            List<IUiElement> aeWndCollectionViaWin32 = new List<IUiElement>();
            
            aeWndCollectionViaWin32 =
                UiaHelper.EnumChildWindowsFromHandle(
                    (GetWindowCmdletBase)this,
                    IntPtr.Zero);
            
            return aeWndCollectionViaWin32;
            
//            }
        }
        
        private List<IUiElement> GetWindowCollectionFromProcess(
            IEnumerable<Process> processes,
            bool first,
            bool recurse,
            ICollection<string> name,
            string automationId,
            string className)
        {
            List<IUiElement> aeWndCollectionByProcId = new List<IUiElement>();
            List<IUiElement> tempCollection = new List<IUiElement>();
            
            List<int> processIdList =
                new List<int>();

            foreach (Process process in processes) {
                
            try {
                int processId = process.Id;
                if (0 != processId) {
                    processIdList.Add(processId);
                }
                
                WriteVerbose(this, "processId = " + processId.ToString());
                
                int[] processIds = processIdList.ToArray();
                
                if (null == processIds) {
                    WriteVerbose(this, "!!!!!!!!!!!!!!!!!!!! null == processIds !!!!!!!!!");
                }
                
                tempCollection = GetWindowCollectionByPid(processIds, first, recurse, name, automationId, className);

                aeWndCollectionByProcId.AddRange(tempCollection);
            }
            catch (Exception tempException) {
                
                WriteVerbose(this, tempException.Message);
                
                //return aeWndCollectionByProcId;
            }
            
            } // 20120824
            
            // 20131202
            tempCollection = null;
            processIdList = null;

            return aeWndCollectionByProcId;
        }
        
        private List<IUiElement> GetWindowCollectionByName(string[] windowNames, string automationId, string className, bool recurse)
        {
            List<IUiElement> windowCollectionByProperties =
                new List<IUiElement>();
            List<IUiElement> resultCollection =
                new List<IUiElement>();
            
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
                
                IUiEltCollection windowCollection =
                    OddRootElement.FindAll(recurse ? TreeScope.Descendants : TreeScope.Children, conditionsSet);
                
                WriteVerbose(this, "trying to run the returnOnlyRightElements method");
                
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
                    foreach (IUiElement aeWndByTitle in windowCollectionByProperties.Cast<IUiElement>().Where(aeWndByTitle => aeWndByTitle != null &&
                                                                                                                                      (int)aeWndByTitle.Current.ProcessId > 0))
                    {
                        
                        WriteVerbose(this, "aeWndByTitle: " +
                                           aeWndByTitle.Current.Name +
                                           " is caught be title = " + windowTitle);
                                
                        resultCollection.Add(aeWndByTitle);
                    }
                    
                } else {
                    
                    IUiElement tempElement = null;
                    
                    // one more attempt using the FindWindow function
                    IntPtr wndHandle =
                        FindWindowByCaption(IntPtr.Zero, windowTitle);
                    if (wndHandle != null && wndHandle != IntPtr.Zero) {
                        tempElement =
                            UiElement.FromHandle(wndHandle);
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
        
        internal static List<IUiElement> ReturnOnlyRightElements(
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
            List<IUiElement> resultCollection = new List<IUiElement>();
            bool requiresValuePatternCheck =
                !string.IsNullOrEmpty(textValue);
            
            // 20131210
            if (null == inputCollection) { return resultCollection; }
            
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
            
            List<IUiElement> inputList = inputCollection.Cast<IUiElement>().ToList();
            
//            cmdlet.WriteVerbose(
//                    cmdlet,
//                    "ReturnOnlyRightElements: there are " +
//                    inputList.Count.ToString() +
//                    " elements");
            
            try {
                
                List<IUiElement> query;
                
                if (requiresValuePatternCheck) {
                
                    if (viaWildcardOrRegex) {
                        
                        query = inputList
                            .Where<IUiElement>(
                                item => (wildcardName.IsMatch(item.Current.Name) &&
                                         wildcardAutomationId.IsMatch(item.Current.AutomationId) &&
                                         wildcardClass.IsMatch(item.Current.ClassName) &&
                                         // check whether a control has or hasn't ValuePattern
                                         // 20131209
                                         // 20131211
                                         // (item.GetSupportedPatterns().AsQueryable<IBasePattern>().Any<IBasePattern>(p => p is IMySuperValuePattern) ?
                                         (item.GetSupportedPatterns().AsQueryable<IBasePattern>().Any(p => null != p && null != (p as IMySuperValuePattern)) ?
                                          //.Single<IMySuperValuePattern>() ? //.Contains(ValuePattern.Pattern) ?
                                          cmdlet.CompareElementValueAndValueParameter(item, textValue, true, wildcardValue, regexOptions) :
                                          // check whether the -Value parameter has or hasn't value
                                          ("*" == textValue ? true : false)
                                         )
                                        )
                               )
                            .ToList<IUiElement>();
                   } else {
                        
                        query = inputList
                            .Where<IUiElement>(
                                item => (Regex.IsMatch(item.Current.Name, name, regexOptions) &&
                                         Regex.IsMatch(item.Current.AutomationId, automationId, regexOptions) &&
                                         Regex.IsMatch(item.Current.ClassName, className, regexOptions) &&
                                         // check whether a control has or hasn't ValuePattern
                                         // 20131209
                                         // (item.GetSupportedPatterns().Contains(ValuePattern.Pattern) ?
                                         // 20131209
                                         // (item.GetSupportedPatterns().Contains(IMySuperValuePattern.Contains(ValuePattern.Pattern) ?
                                         // (item.GetSupportedPatterns().Contains(IMySuperValuePattern) ?
                                         // 20131211
                                         // (item.GetSupportedPatterns().AsQueryable<IBasePattern>().Any<IBasePattern>(p => p is IMySuperValuePattern) ?
                                         (item.GetSupportedPatterns().AsQueryable<IBasePattern>().Any(p => null != p && null != (p as IMySuperValuePattern)) ?
                                          cmdlet.CompareElementValueAndValueParameter(item, textValue, false, null, regexOptions) :
                                          // check whether the -Value parameter has or hasn't value
                                          (".*" == textValue ? true : false)
                                         )
                                        )
                               )
                            .ToList<IUiElement>();
                    }
                
                } else {
                    
                    if (viaWildcardOrRegex) {
                        query = inputList
                            .Where<IUiElement>(
                                item => (wildcardName.IsMatch(item.Current.Name) &&
                                         wildcardAutomationId.IsMatch(item.Current.AutomationId) &&
                                         wildcardClass.IsMatch(item.Current.ClassName)
                                        )
                               )
                            .ToList<IUiElement>();
                    } else {
                        query = inputList
                            .Where<IUiElement>(
                                item => (Regex.IsMatch(item.Current.Name, name, regexOptions) &&
                                         Regex.IsMatch(item.Current.AutomationId, automationId, regexOptions) &&
                                         Regex.IsMatch(item.Current.ClassName, className, regexOptions)
                                        )
                               )
                            .ToList<IUiElement>();
                    }
                    
                }
                
                cmdlet.WriteVerbose(
                        cmdlet,
                        "There are " +
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
        /// <param name="item">IUiElement element</param>
        /// <param name="textValue">the -Value parameter</param>
        /// <param name="viaWildcardOrRegex">true is wildcard, false is regexp</param>
        /// <param name="wildcardValue">a wildcard object</param>
        /// <param name="regexOptions">a regex options object</param>
        /// <returns></returns>
        protected internal bool CompareElementValueAndValueParameter(
            IUiElement item,
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
                    // 20131208
                    // (item.GetCurrentPattern(ValuePattern.Pattern) as IMySuperValuePattern).Current.Value;
                    // (item.GetCurrentPattern<IMySuperValuePattern, ValuePattern>(ValuePattern.Pattern) as IMySuperValuePattern).Current.Value;
                    (item.GetCurrentPattern<IMySuperValuePattern>(ValuePattern.Pattern)).Current.Value;
            }
            catch { //(Exception eGetCurrentPattern) {
                // nothing to do
                // usually this place never be reached
            }
            
            result = viaWildcardOrRegex ? wildcardValue.IsMatch(realValue) : Regex.IsMatch(realValue, textValue, regexOptions);
            return result;
        }
    }
}
