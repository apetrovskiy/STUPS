/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/15/2014
 * Time: 1:05 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Windows.Automation;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using PSTestLib;
    
    /// <summary>
    /// Description of WindowSeatch.
    /// </summary>
    public class WindowSearch : SearchTemplate
    {
        public override string TimeoutExpirationInformation { get; set; }
             // "timeout expired for process: " +
                        // cmdlet.ProcessName + ", title: " + cmdlet.Name
        internal bool wasFound = false;
        
        public override void OnStartHook()
        {
        }
        
        public override void BeforeSearchHook()
        {
        }
        
        public override List<IUiElement> SearchForElements(SearchTemplateData searchData)
        {
            try {
                
                WindowSearchData data = searchData as WindowSearchData;
                
                if (data.Win32) {
                    
                    // cmdlet.WriteVerbose(cmdlet, "getting a window via Win32 API");
                    ResultCollection = GetWindowCollectionViaWin32(data.First, data.Recurse, data.Name, data.AutomationId, data.Class);
                    
                } else if (null != data.InputObject && data.InputObject.Length > 0) {
                    
                    // cmdlet.WriteVerbose(cmdlet, "getting a window by process");
                    ResultCollection = GetWindowCollectionFromProcess(data.InputObject, data.First, data.Recurse, data.Name, data.AutomationId, data.Class);
                    
                } else if (null != data.ProcessIds && data.ProcessIds.Length > 0) {
                    
                    // cmdlet.WriteVerbose(cmdlet, "getting a window by PID");
                    ResultCollection = GetWindowCollectionByPid(data.ProcessIds, data.First, data.Recurse, data.Name, data.AutomationId, data.Class);

                } else if (null != data.ProcessNames && data.ProcessNames.Length > 0) {
                    
                    // cmdlet.WriteVerbose(cmdlet, "getting a window by name");
                    ResultCollection = GetWindowCollectionByProcessName(data.ProcessNames, data.First, data.Recurse, data.Name, data.AutomationId, data.Class);

                } else if ((null != data.Name && data.Name.Length > 0) ||
                           !string.IsNullOrEmpty(data.AutomationId) ||
                           !string.IsNullOrEmpty(data.Class)) {
                    
                    // cmdlet.WriteVerbose(cmdlet, "getting a window by name, automationId, className");
                    ResultCollection = GetWindowCollectionByName(data.Name, data.AutomationId, data.Class, data.Recurse);
                }
                
            } catch (Exception eSearchFailure) {
                
                // 
                // throw;
            }
            
            return ResultCollection;
        }
        
        public override void AfterSearchHook()
        {
            // filtering result window collection by SearchCriteria
            if (null != ResultCollection && 0 < ResultCollection.Count) {
                
                // cmdlet.WriteVerbose(cmdlet, "one or several windows were found by name, process name, process id or process object");
                
                if (null != (SearchData as WindowSearchData).SearchCriteria && 0 < (SearchData as WindowSearchData).SearchCriteria.Length) {
                
                    // cmdlet.WriteVerbose(cmdlet, "processing SearchCriteria");
                    ResultCollection =
                        ResultCollection.GetFilteredElementsCollection();
                }
            }
                
            // filtering result window collection by having a control(s) with properties as from WithControl
            if (null != ResultCollection && 0 < ResultCollection.Count) {
            
                // cmdlet.WriteVerbose(cmdlet, "one or several windows were not excluded by SearchCriteria");
                if (null != (SearchData as WindowSearchData).WithControl && 0 < (SearchData as WindowSearchData).WithControl.Length) {
                
                    // cmdlet.WriteVerbose(cmdlet, "processing WithControl");
                    List<IUiElement> filteredWindows =
                        new List<IUiElement>();
    
                    // cmdlet.WriteVerbose(cmdlet, "searching for control(s) for every window, one by one");
                    bool exitInnerCycle = false;
                    
                    // 20140110
                    // try { // this was added as an experiment
                        
                        foreach (IUiElement window in ResultCollection) {
                            
                            // 20140110
                            if (!window.IsValid()) continue;
                            
                            // cmdlet.WriteVerbose(cmdlet, "Window: name='" + window.Current.Name + "', automationId='" + window.Current.AutomationId + "'");
                            
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
                            foreach (Hashtable ht in (SearchData as WindowSearchData).WithControl)
                            {
                                cmdletCtrl.SearchCriteria = new Hashtable[] { ht };

                                // cmdlet.WriteVerbose(cmdlet, "searching for controls that match the following critetion: " + ht.ToString());
                                try {
                                    
                                    var controlSearch =
                                        AutomationFactory.GetSearchImpl<ControlSearch>() as ControlSearch;
                                    
                                    // 20140116
                                    List<IUiElement> controlsList =
                                        // (new CommonCmdletBase()).GetControl(cmdletCtrl);
                                        controlSearch.GetElements(

                                            controlSearch.ConvertCmdletToControlSearchData(cmdletCtrl),
                                            cmdletCtrl.Timeout);
                                    
                                    if (null != controlsList && 0 < controlsList.Count) {
                                        
                                        // cmdlet.WriteVerbose(cmdlet, "there are " + controlsList.Count.ToString() + " result(s) after the search");
                                        addToResultCollection = true;
                                    } else { //20130713
                                        
                                        // cmdlet.WriteVerbose(cmdlet, "there weren't found controls that match the criterion");
                                        exitInnerCycle = true;
                                        addToResultCollection = false;
                                        break;
                                    }
                            
                                }
                                
                                catch (Exception eWindowIsGone) {
                                    
                                    // forcing to a next loop
                                    ResultCollection.Clear();
                                    break;
                                }
                            }

                            if (addToResultCollection) {
                                filteredWindows.Add(window);
                            }
                        }
                        
                        ResultCollection = filteredWindows;
                        
                        // 20140121
                        if (null != filteredWindows) {
                            filteredWindows.Clear();
                            filteredWindows = null;
                        }
                    // }
                    // catch {}
                }
            }
            
            if ((SearchData as WindowSearchData).WaitNoWindow && wasFound && (null == ResultCollection || 0 == ResultCollection.Count)) {
                
                Wait = false;
            }
            
            if ((SearchData as WindowSearchData).WaitNoWindow && !wasFound && null != ResultCollection && 0 != ResultCollection.Count) {

                wasFound = true;
                
                // 20140121
                ResultCollection.Clear();
                
                ResultCollection = null;
            }
        }
        
        public override void OnSleepHook()
        {
            int timeout = Timeout;
            if (0 == timeout) {
                timeout = 5;
            }
            System.Threading.Thread.Sleep(Timeout / 20);
        }
        
        public override void OnFailureHook()
        {
            
        }
        
        public override void OnSuccessHook()
        {
            try {
                
//                if (null != ResultCollection && (int)((IUiElement)ResultCollection[0]).Current.ProcessId > 0) {
//                    
//                    // cmdlet.WriteVerbose(cmdlet, "" + aeWndCollection.ToString());
//                    
//                    // cmdlet.WriteVerbose(cmdlet, 
//                    //                     "aeWnd.Current.GetType() = " +
//                    //                     ((IUiElement)aeWndCollection[0]).GetType().Name);
//                    
//                } // 20120127
                
                CurrentData.CurrentWindow = (IUiElement)ResultCollection[ResultCollection.Count -1];
                
            } catch (Exception eEvaluatingWindowAndWritingToPipeline) {
                
                // cmdlet.WriteVerbose(
                //     cmdlet,
                //     "exception: " +
                //     eEvaluatingWindowAndWritingToPipeline.Message);
                
                // cmdlet.WriteVerbose(this, "<<<< ==  ==  writing/nullifying CurrentWindow  ==  == >>>>>");
                    
                CurrentData.CurrentWindow = null;
                
            }
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
                    name,
                    automationId,
                    className,
                    IntPtr.Zero);
            
            return aeWndCollectionViaWin32;
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
                
                int[] processIds = processIdList.ToArray();
                
                tempCollection = GetWindowCollectionByPid(processIds, first, recurse, name, automationId, className);

                aeWndCollectionByProcId.AddRange(tempCollection);
            }
            catch (Exception tempException) {
                
                // WriteVerbose(this, tempException.Message);
                
                //return aeWndCollectionByProcId;
            }
            
            } // 20120824
            
            // 20131202
            // 20140121
            if (null != tempCollection) {
                tempCollection.Clear();
                tempCollection = null;
            }
            if (null != processIdList) {
                processIdList.Clear();
                processIdList = null;
            }
            // tempCollection = null;
            // processIdList = null;

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
                
                IUiEltCollection windowCollection =
                    UiElement.RootElement.FindAll(recurse ? TreeScope.Descendants : TreeScope.Children, conditionsSet);
                
                try {
                    windowCollectionByProperties =
                        ReturnOnlyRightElements(
                            windowCollection,
                            windowTitle,
                            automationId,
                            className,
                            string.Empty,
                            (new string[]{ "Window", "Pane", "Menu" }),
                            false,
                            true);
                    
                    // 20140121
                    if (null != windowCollection) {
                        windowCollection.Dispose();
                        windowCollection = null;
                    }
                }
                catch {
                    
                    // 20140110
                    // ???
                    try {
                        windowCollectionByProperties =
                            ReturnOnlyRightElements(
                                // this,
                                windowCollection,
                                windowTitle,
                                automationId,
                                className,
                                string.Empty,
                                (new string[]{ "Window", "Pane", "Menu" }),
                                false,
                                true);
                        
                        // 20140121
                        if (null != windowCollection) {
                            windowCollection.Dispose();
                            windowCollection = null;
                        }
                    }
                    catch {
                        
                        // 20140121
                        if (null != windowCollection) {
                            windowCollection.Dispose();
                            windowCollection = null;
                        }
                    }
                }
                
                try {
                    if (null != windowCollectionByProperties && 0 < windowCollectionByProperties.Count) {
                        
                        foreach (IUiElement aeWndByTitle in windowCollectionByProperties.Cast<IUiElement>().Where(aeWndByTitle => aeWndByTitle != null &&
                                                                                                                                          (int)aeWndByTitle.Current.ProcessId > 0))
                        {
                            resultCollection.Add(aeWndByTitle);
                        }
                        
                        // 20140121
                        windowCollectionByProperties.Clear();
                        
                    } else {
                        
                        IUiElement tempElement = null;
                        
                        // one more attempt using the FindWindow function
                        IntPtr wndHandle =
                            NativeMethods.FindWindowByCaption(IntPtr.Zero, windowTitle);
                        if (wndHandle != null && wndHandle != IntPtr.Zero) {
                            tempElement =
                                UiElement.FromHandle(wndHandle);
                        }
    
                        if (null == tempElement || (int) tempElement.Current.ProcessId <= 0) continue;
                        
                        resultCollection.Add(tempElement);
                    }
                }
                catch {}
                
            } // 20120824
            
            return resultCollection;
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
            
            // 20140121
            if (null != processIdList) {
                processIdList.Clear();
                processIdList = null;
            }
            
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
                
                try {
                    
                    if (recurse) {
                        if (first) {
                            
                            IUiElement rootWindowElement =
                                UiElement.RootElement.FindFirst(
                                    TreeScope.Children,
                                    conditionsProcessId);
                            
                            if (null != rootWindowElement) {
                                
                                elementsByProcessId.Add(rootWindowElement);
                            }
                            
                        } else {
                            
                            IUiEltCollection rootCollection =
                                UiElement.RootElement.FindAll(
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
                                UiElement.RootElement.FindFirst(TreeScope.Children,
                                                      conditionsProcessId);
                            
                            if (null != tempElement) {
                                
                                elementsByProcessId.Add(tempElement);
                            }
                        } else {
                            
                            IUiEltCollection tempCollection =
                                UiElement.RootElement.FindAll(TreeScope.Children,
                                                    conditionsProcessId);
                            
                            if (null != tempCollection && 0 < tempCollection.Count) {
                                
                                elementsByProcessId.AddRange(tempCollection.Cast<IUiElement>());
                            }
                        }
                    }
                } catch (Exception eGetFirstChildOfRootByProcessId) {
                    
                    // WriteVerbose(
                    //     this,
                    //     "exception: " +
                    //     eGetFirstChildOfRootByProcessId.Message);
                }
                
                if (null != elementsByProcessId &&
                    processId > 0) {
                    // WriteVerbose(this, "aeWndByProcId: " +
                    //              "is caught by processId = " + processId.ToString());
                }
                else{
                    // WriteVerbose(this, "aeWndByProcId is still null");
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
                        elementsByProcessId,
                        string.Empty,
                        automationId,
                        className,
                        string.Empty,
                        new string[]{ "Window" },
                        false,
                        true));
            }
            
            elementsByProcessId = resultList;
            
            // 20140121
            if (null != resultList) {
                resultList.Clear();
                resultList = null;
            }
            
            return elementsByProcessId;
        }
        
        internal static List<IUiElement> ReturnOnlyRightElements(
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
                                         // (item.GetSupportedPatterns().AsQueryable<IBasePattern>().Any<IBasePattern>(p => p is IValuePattern) ?
                                         (item.GetSupportedPatterns().AsQueryable<IBasePattern>().Any(p => null != p && null != (p as IValuePattern)) ?
                                          //.Single<IValuePattern>() ? //.Contains(ValuePattern.Pattern) ?
                                          // (new HasTimeoutCmdletBase()).CompareElementValueAndValueParameter(item, textValue, true, wildcardValue, regexOptions) :
                                          item.CompareElementValueAndValueParameter(textValue, true, wildcardValue, regexOptions) :
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
                                         // (item.GetSupportedPatterns().Contains(IValuePattern.Contains(ValuePattern.Pattern) ?
                                         // (item.GetSupportedPatterns().Contains(IValuePattern) ?
                                         // 20131211
                                         // (item.GetSupportedPatterns().AsQueryable<IBasePattern>().Any<IBasePattern>(p => p is IValuePattern) ?
                                         (item.GetSupportedPatterns().AsQueryable<IBasePattern>().Any(p => null != p && null != (p as IValuePattern)) ?
                                          // (new HasTimeoutCmdletBase()).CompareElementValueAndValueParameter(item, textValue, false, null, regexOptions) :
                                          item.CompareElementValueAndValueParameter(textValue, false, null, regexOptions) :
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
                
//                cmdlet.WriteVerbose(
//                        cmdlet,
//                        "There are " +
//                        query.Count.ToString() +
//                        " elements");
                
                resultCollection.AddRange(query);
                
//                cmdlet.WriteVerbose(
//                    cmdlet,
//                    "There are " +
//                    resultCollection.Count.ToString() +
//                    " elements");
                
            }
            catch (Exception eProcessing) {
//                cmdlet.WriteVerbose(eProcessing.Message);
            }
            
            // 20140121
            if (null != inputList) {
                inputList.Clear();
                inputList = null;
            }
            
            // 20140121
            // inputCollection ??
            
            // 20140121
            wildcardName = wildcardAutomationId = wildcardClass = wildcardValue = null;
            
            return resultCollection;
        }
    }
}
