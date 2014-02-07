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
    
    using System.Data; // ?
    
    /// <summary>
    /// Description of WindowSeatcher.
    /// </summary>
    public class WindowSearcher : SearcherTemplate
    {
        public override string TimeoutExpirationInformation { get; set; }
        internal bool wasFound = false;
        
        public override void OnStartHook()
        {
        }
        
        public override void BeforeSearchHook()
        {
        }
        
        public override List<IUiElement> SearchForElements(SearcherTemplateData searchData)
        {
            try {
                
                WindowSearcherData data = searchData as WindowSearcherData;
                
                AutomationFactory.InitializeChildKernel();
                
                if (data.Win32) {
                    
                    if (null == ResultCollection || 0 == ResultCollection.Count) {
                        ResultCollection = GetWindowCollectionViaWin32(data.First, data.Recurse, data.Name, data.AutomationId, data.Class);
                    }
                } else if (null != data.InputObject && data.InputObject.Length > 0) {
                    
                    if (null == ResultCollection || 0 == ResultCollection.Count) {
                        ResultCollection = GetWindowCollectionFromProcess(data.InputObject, data.First, data.Recurse, data.Name, data.AutomationId, data.Class);
                    }
                } else if (null != data.ProcessIds && data.ProcessIds.Length > 0) {
                    
                    if (null == ResultCollection || 0 == ResultCollection.Count) {
                        ResultCollection = GetWindowCollectionByPid(UiElement.RootElement, data.ProcessIds, data.First, data.Recurse, data.Name, data.AutomationId, data.Class);
                    }
                } else if (null != data.ProcessNames && data.ProcessNames.Length > 0) {
                    
                    if (null == ResultCollection || 0 == ResultCollection.Count) {
                        ResultCollection = GetWindowCollectionByProcessName(UiElement.RootElement, data.ProcessNames, data.First, data.Recurse, data.Name, data.AutomationId, data.Class);
                    }
                } else if ((null != data.Name && data.Name.Length > 0) ||
                           !string.IsNullOrEmpty(data.AutomationId) ||
                           !string.IsNullOrEmpty(data.Class)) {
                    
                    if (null == ResultCollection || 0 == ResultCollection.Count) {
                        ResultCollection = GetWindowCollectionByName(UiElement.RootElement, data.Name, data.AutomationId, data.Class, data.Recurse);
                    }
                }
                
                if (null == ResultCollection || 0 == ResultCollection.Count) {
                    
                    AutomationFactory.ChildKernel.Release(ResultCollection);
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
                
                if (null != (SearcherData as WindowSearcherData).SearchCriteria && 0 < (SearcherData as WindowSearcherData).SearchCriteria.Length) {
                    
                    ResultCollection =
                        ResultCollection.GetFilteredElementsCollection();
                }
            }
            
            // filtering result window collection by having a control(s) with properties as from WithControl
            if (null != ResultCollection && 0 < ResultCollection.Count) {
                
                if (null != (SearcherData as WindowSearcherData).WithControl && 0 < (SearcherData as WindowSearcherData).WithControl.Length) {
                    
                    FilterResultCollectionByWithControlParameter();
                }
            }
            
            if ((SearcherData as WindowSearcherData).WaitNoWindow && wasFound && (null == ResultCollection || 0 == ResultCollection.Count)) {
                
                Wait = false;
            }
            
            if ((SearcherData as WindowSearcherData).WaitNoWindow && !wasFound && null != ResultCollection && 0 != ResultCollection.Count) {

                wasFound = true;
                
                ResultCollection.Clear();
                ResultCollection = null;
            }
        }

        internal void FilterResultCollectionByWithControlParameter()
        {
            List<IUiElement> filteredWindows = new List<IUiElement>();
            bool exitInnerCycle = false;

            foreach (IUiElement window in ResultCollection) {

                if (!window.IsValid())
                    continue;

                var ControlSearcherData = new ControlSearcherData { InputObject = new UiElement[] { (UiElement)window } };

                exitInnerCycle = false;
                bool addToResultCollection = false;
                foreach (Hashtable ht in (SearcherData as WindowSearcherData).WithControl) {
                    ControlSearcherData.SearchCriteria = new Hashtable[] { ht };

                    try {

                        var controlSearch = AutomationFactory.GetSearchImpl<ControlSearcher>() as ControlSearcher;

                        List<IUiElement> controlsList = controlSearch.GetElements(ControlSearcherData, 0);

                        if (null != controlsList && 0 < controlsList.Count) {

                            addToResultCollection = true;
                            break;

                        } else {

                            exitInnerCycle = true;
                            addToResultCollection = false;
                            continue;
                        }


                    } catch (Exception eWindowIsGone) {

                        // forcing to a next loop
                        ResultCollection.Clear();
                        break;
                    }
                }

                ControlSearcherData = null;

                if (addToResultCollection) {
                    filteredWindows.Add(window);
                }
            }

            ResultCollection = filteredWindows;
        }
        
        public override void OnFailureHook()
        {
            
        }
        
        public override void OnSuccessHook()
        {
            try {
                
                CurrentData.CurrentWindow = (IUiElement)ResultCollection[ResultCollection.Count - 1];
                
            } catch (Exception eEvaluatingWindowAndWritingToPipeline) {
                
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
            List<IUiElement> aeWndCollectionViaWin32 =
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
            List<IUiElement> tempCollection = null;
            
            List<int> processIdList =
                new List<int>();
            
            foreach (Process process in processes) {
                
                try {
                    int processId = process.Id;
                    if (0 != processId) {
                        processIdList.Add(processId);
                    }
                    
                    int[] processIds = processIdList.ToArray();
                    
                    tempCollection = GetWindowCollectionByPid(UiElement.RootElement, processIds, first, recurse, name, automationId, className);

                    aeWndCollectionByProcId.AddRange(tempCollection);
                }
                catch (Exception tempException) {
                    continue;
                }
                
            }
            
            if (null != tempCollection) {
                // 20140131
                // 20140201
//                if (0 < tempCollection.Count) {
//                    foreach (IUiElement element in tempCollection) {
//                        element.Dispose();
//                    }
//                }
                tempCollection.Clear();
                tempCollection = null;
            }
            if (null != processIdList) {
                processIdList.Clear();
                processIdList = null;
            }
            
            return aeWndCollectionByProcId;
        }
        
        private List<IUiElement> GetWindowCollectionByName(
            IUiElement rootElement,
            string[] windowNames,
            string automationId,
            string className,
            bool recurse)
        {
            List<IUiElement> windowCollectionByProperties =
                new List<IUiElement>();
            List<IUiElement> resultCollection =
                new List<IUiElement>();
            
            if (null == windowNames) {
                windowNames = new string[]{ string.Empty };
            }
            
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
            
            foreach (string windowTitle in windowNames) {
                
                IUiEltCollection windowCollection =
                    rootElement.FindAll(recurse ? TreeScope.Descendants : TreeScope.Children, conditionsSet);
                
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
                    
                try {
                    if (null != windowCollectionByProperties && 0 < windowCollectionByProperties.Count) {
                        
                        foreach (IUiElement aeWndByTitle in windowCollectionByProperties.Cast<IUiElement>()
                                 .Where(aeWndByTitle => aeWndByTitle != null && (int)aeWndByTitle.Current.ProcessId > 0))
                        {
                            resultCollection.Add(aeWndByTitle);
                        }
                        
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
                
                // 20140122
                // AutomationFactory.DisposeChildKernel();
                
                // 20140131
//                if (null != windowCollectionByProperties && 0 < windowCollectionByProperties.Count) {
//                    foreach (IUiElement element in windowCollectionByProperties) {
//                        element.Dispose();
//                    }
//                }
//                if (null != windowCollection && 0 < windowCollection.Count) {
//                    foreach (IUiElement element in windowCollection) {
//                        element.Dispose();
//                    }
//                }
            }
            
            return resultCollection;
        }
        
        private List<IUiElement> GetWindowCollectionByProcessName(
            IUiElement rootElement,
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
                    continue;
                }
                
            }
            
            int[] processIds = processIdList.ToArray();
            aeWndCollectionByProcId = GetWindowCollectionByPid(rootElement, processIds, first, recurse, name, automationId, className);
            
            // 20140121
            //            if (null != processIdList) {
            //                processIdList.Clear();
            //                processIdList = null;
            //            }
            
            return aeWndCollectionByProcId;
        }
        
        internal List<IUiElement> GetWindowCollectionByPid(
            IUiElement rootElement,
            IEnumerable<int> processIds,
            bool first,
            bool recurse,
            IEnumerable<string> names,
            string automationId,
            string className)
        {
            AndCondition conditionsForRecurseSearch = null;
            
            List<IUiElement> elementsByProcessId =
                new List<IUiElement>();
            
            if ((null != names && 0 < names.Count()) ||
                !string.IsNullOrEmpty(automationId) ||
                !string.IsNullOrEmpty(className)) {
                
                recurse = true;
            }
            
            OrCondition conditionWindowPaneMenu =
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
            
            foreach (int processId in processIds) {
                
                AndCondition conditionsProcessId = null;
                conditionsForRecurseSearch =
                    new AndCondition(
                        new PropertyCondition(
                            AutomationElement.ProcessIdProperty,
                            processId),
                        new PropertyCondition(
                            AutomationElement.ControlTypeProperty,
                            ControlType.Window));
                    
                conditionsProcessId =
                    new AndCondition(
                        new PropertyCondition(
                            AutomationElement.ProcessIdProperty,
                            processId),
                        conditionWindowPaneMenu);
                
                try {
                    
                    if (recurse) {
                        if (first) {
                            
                            IUiElement rootWindowElement =
                                rootElement.FindFirst(
                                    TreeScope.Children,
                                    conditionsProcessId);
                            
                            if (null != rootWindowElement) {
                                elementsByProcessId.Add(rootWindowElement);
                            }
                            
                        } else {
                            
                            IUiEltCollection rootCollection =
                                rootElement.FindAll(
                                    TreeScope.Children,
                                    conditionsProcessId);
                            
                            if (null != rootCollection && 0 < rootCollection.Count)
                            {
                                elementsByProcessId.AddRange(rootCollection.Cast<IUiElement>());
                                
                                // 20140203-20140205
//                                foreach (IUiElement singleElement in (
//                                    from IUiElement rootWindowElement in rootCollection select rootWindowElement.FindAll(
//                                        TreeScope.Descendants,
//                                        conditionsForRecurseSearch)
//                                    into tempCollection
//                                    where null != tempCollection && 0 < tempCollection.Count
//                                    select tempCollection)
//                                    .SelectMany(tempCollection => rootCollection.Cast<IUiElement>()))
//                                {
//                                    elementsByProcessId.Add(singleElement);
//                                }
                            }
                        }
                        
                    } else {
                        
                        if (first) {
                            
                            IUiElement tempElement =
                                rootElement.FindFirst(
                                    TreeScope.Children,
                                    conditionsProcessId);
                            
                            if (null != tempElement) {
                                
                                elementsByProcessId.Add(tempElement);
                            }
                        } else {
                            
                            IUiEltCollection tempCollection =
                                rootElement.FindAll(
                                    TreeScope.Children,
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
            }
            
            if (!recurse ||
                ((null == names || 0 >= names.Count()) && string.IsNullOrEmpty(automationId) &&
                 string.IsNullOrEmpty(className))) return elementsByProcessId;
            
            List<IUiElement> resultList =
                new List<IUiElement>();
            
            if (null != names && 0 < names.Count()) {
                foreach (string name in names) {
                    
                    resultList.AddRange(
                        ReturnOnlyRightElements(
                            elementsByProcessId,
                            name,
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
            // never !
            //            if (null != resultList) {
            //                resultList.Clear();
            //                resultList = null;
            //            }
            
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
            
            WildcardPattern wildcardName =
                new WildcardPattern(name, options);
            WildcardPattern wildcardAutomationId =
                new WildcardPattern(automationId, options);
            WildcardPattern wildcardClass =
                new WildcardPattern(className, options);
            WildcardPattern wildcardValue =
                new WildcardPattern(textValue, options);
            
            List<IUiElement> inputList = inputCollection.Cast<IUiElement>().ToList();
            
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
                                         (item.GetSupportedPatterns().AsQueryable<IBasePattern>().Any(pattern => null != pattern && null != (pattern as IValuePattern)) ?
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
                                         (item.GetSupportedPatterns().AsQueryable<IBasePattern>().Any(p => null != p && null != (p as IValuePattern)) ?
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
                
                resultCollection.AddRange(query);
            }
            catch (Exception eProcessing) {
                //                cmdlet.WriteVerbose(eProcessing.Message);
            }
            
            // 20140121
            //            if (null != inputList) {
            //                inputList.Clear();
            //                inputList = null;
            //            }
            
            // 20140131
//            foreach (IUiElement element in inputList) {
//                element.Dispose();
//            }
            
            // 20140121
            // inputCollection ??
            
            // 20140121
            wildcardName = wildcardAutomationId = wildcardClass = wildcardValue = null;
            
            return resultCollection;
        }
    }
}
