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
        
        // 20140208
        private CacheRequest ClonedCacheRequest { get; set; }
        
        public override void OnStartHook()
        {
        }
        
        public override void BeforeSearchHook()
        {
        }
        
        public override List<IUiElement> SearchForElements(SearcherTemplateData searchData)
        {
            
            // 20140208
            if (Preferences.CacheRequestCalled && null != CurrentData.CacheRequest) {
                try {
                    Preferences.FromCache = false;
                    // CurrentData.CacheRequest.Pop();
                    ClonedCacheRequest = null;
                }
                catch (Exception eeeee) {
                    
//Console.WriteLine("failed to stop the cache request");
//Console.WriteLine(eeeee.Message);
                }
            } else {
                if (null == CurrentData.CacheRequest) {
//Console.WriteLine("cache request is null");
                }
            }
            
            try {
                
                WindowSearcherData data = searchData as WindowSearcherData;
                
                AutomationFactory.InitializeChildKernel();
                
                if (data.Win32) {
                    
                    if (null == ResultCollection || 0 == ResultCollection.Count) {
                        ResultCollection = GetWindowCollectionViaWin32(data);
                    }
                } else if (null != data.InputObject && data.InputObject.Length > 0) {
                    
                    if (null == ResultCollection || 0 == ResultCollection.Count) {
                        ResultCollection = GetWindowCollectionFromProcess(data);
                    }
                } else if (null != data.ProcessIds && data.ProcessIds.Length > 0) {
                    
                    if (null == ResultCollection || 0 == ResultCollection.Count) {
                        ResultCollection = GetWindowCollectionByPid(UiElement.RootElement, data);
                    }
                } else if (null != data.ProcessNames && data.ProcessNames.Length > 0) {
                    
                    if (null == ResultCollection || 0 == ResultCollection.Count) {
                        ResultCollection = GetWindowCollectionByProcessName(UiElement.RootElement, data);
                    }
                } else if ((null != data.Name && data.Name.Length > 0) ||
                           !string.IsNullOrEmpty(data.AutomationId) ||
                           !string.IsNullOrEmpty(data.Class)) {
                    
                    if (null == ResultCollection || 0 == ResultCollection.Count) {
                        ResultCollection = GetWindowCollectionByName(UiElement.RootElement, data);
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
            
            // 20140208
            if (null != ResultCollection && 0 < ResultCollection.Count) {
                if (Preferences.CacheRequestCalled && null != CurrentData.CacheRequest) {
                    try {
                        // CurrentData.CacheRequest.Push();
                        // var cacheRequest = CurrentData.CacheRequest.Clone();
                        ClonedCacheRequest = CurrentData.CacheRequest.Clone();
                        ClonedCacheRequest.Push();
                        Preferences.FromCache = true;
                    } catch (Exception eeee) {
                        Preferences.FromCache = false;
//Console.WriteLine("failed to start cache request");
//Console.WriteLine(eeee.Message);
                    }
                }
            } else {
                if (null == CurrentData.CacheRequest) {
//Console.WriteLine("cache request is null");
                }
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

                        var controlSearch = AutomationFactory.GetSearcherImpl<ControlSearcher>() as ControlSearcher;

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
            WindowSearcherData data)
        {
            return UiaHelper.EnumChildWindowsFromHandle(
                data.Name,
                data.AutomationId,
                data.Class,
                IntPtr.Zero);
        }
        
        private List<IUiElement> GetWindowCollectionFromProcess(
            WindowSearcherData data)
        {
            data.ProcessIds = (from process in data.InputObject where null != process && 0 != process.Id select process.Id).ToList().ToArray();
            return GetWindowCollectionByPid(UiElement.RootElement, data);
        }
        
        /*
        private List<IUiElement> GetWindowCollectionFromProcess(
            WindowSearcherData data)
        {
            List<IUiElement> aeWndCollectionByProcId = new List<IUiElement>();
            List<IUiElement> tempCollection = null;
            
            List<int> processIdList =
                new List<int>();
            
            foreach (Process process in data.InputObject) {
                
                try {
                    int processId = process.Id;
                    if (0 != processId) {
                        processIdList.Add(processId);
                    }
                    
                    int[] processIds = processIdList.ToArray();
                    
                    var windowSearcherData =
                        new WindowSearcherData {
                        ProcessIds = processIds,
                        First = data.First,
                        Recurse = data.Recurse,
                        Name = data.Name,
                        AutomationId = data.AutomationId,
                        Class = data.Class
                    };
                    tempCollection = GetWindowCollectionByPid(UiElement.RootElement, windowSearcherData);

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
        */
        
        private List<IUiElement> GetWindowCollectionByName(
            IUiElement rootElement,
            WindowSearcherData data)
        {
            List<IUiElement> windowCollectionByProperties =
                new List<IUiElement>();
            List<IUiElement> resultCollection =
                new List<IUiElement>();
            
            if (null == data.Name) {
                data.Name = new string[]{ string.Empty };
            }
            
            OrCondition conditionsSet = null;
            if (data.Recurse) {
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
            
            foreach (string windowTitle in data.Name) {
                
                IUiEltCollection windowCollection =
                    rootElement.FindAll(data.Recurse ? TreeScope.Descendants : TreeScope.Children, conditionsSet);
                
                var controlSearcherData =
                    new ControlSearcherData {
                    Name = windowTitle,
                    AutomationId = data.AutomationId,
                    Class = data.Class,
                    Value = string.Empty,
                    ControlType = (new string[]{ "Window", "Pane", "Menu" })
                };
                
                windowCollectionByProperties =
                    ReturnOnlyRightElements(
                        windowCollection,
                        controlSearcherData,
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
            WindowSearcherData data)
        {
            data.InputObject = data.ProcessNames.SelectMany(processName => Process.GetProcessesByName(processName)).ToList().ToArray();
            return GetWindowCollectionFromProcess(data);
        }
        
        /*
        private List<IUiElement> GetWindowCollectionByProcessName(
            IUiElement rootElement,
            WindowSearcherData data)
        {
            List<IUiElement> aeWndCollectionByProcId = new List<IUiElement>();
            List<int> processIdList = new List<int>();
            
            foreach (string processName in data.ProcessNames) {
                
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
            data.ProcessIds = processIds;
            aeWndCollectionByProcId = GetWindowCollectionByPid(rootElement, data);
            
            // 20140121
            //            if (null != processIdList) {
            //                processIdList.Clear();
            //                processIdList = null;
            //            }
            
            return aeWndCollectionByProcId;
        }
        */
        
        internal List<IUiElement> GetWindowCollectionByPid(
            IUiElement rootElement,
            WindowSearcherData data)
        {
            AndCondition conditionsForRecurseSearch = null;
            
            List<IUiElement> elementsByProcessId =
                new List<IUiElement>();
            
            if ((null != data.Name && 0 < data.Name.Count()) ||
                !string.IsNullOrEmpty(data.AutomationId) ||
                !string.IsNullOrEmpty(data.Class)) {
                
                data.Recurse = true;
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
            
            foreach (int processId in data.ProcessIds) {
                
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
                    
                    if (data.Recurse) {
                        if (data.First) {
                            
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
                            }
                        }
                        
                    } else {
                        
                        if (data.First) {
                            
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
            
            if (!data.Recurse ||
                ((null == data.Name || 0 == data.Name.Count()) && string.IsNullOrEmpty(data.AutomationId) &&
                 string.IsNullOrEmpty(data.Class))) return elementsByProcessId;
            
            List<IUiElement> resultList =
                new List<IUiElement>();
            
            if (null != data.Name && 0 < data.Name.Count()) {
                foreach (string name in data.Name) {
                    
                    var controlSearcherData =
                        new ControlSearcherData {
                        Name = name,
                        AutomationId = data.AutomationId,
                        Class = data.Class,
                        Value = string.Empty,
                        ControlType = new string[]{ "Window" } 
                    };
                    
                    resultList.AddRange(
                        ReturnOnlyRightElements(
                            elementsByProcessId,
                            controlSearcherData,
                            false,
                            true));
                    
                }
            } else {
                
                var controlSearcherData =
                    new ControlSearcherData {
                    Name = string.Empty,
                    AutomationId = data.AutomationId,
                    Class = data.Class,
                    Value = string.Empty,
                    ControlType = new string[]{ "Window" } 
                };
                
                resultList.AddRange(
                    ReturnOnlyRightElements(
                        elementsByProcessId,
                        controlSearcherData,
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
            SearcherTemplateData searcherData,
            bool caseSensitive,
            bool viaWildcardOrRegex)
        {
            // ControlSearcherData data = searcherData as ControlSearcherData;
            var data = searcherData as ControlSearcherData;
            
            // List<IUiElement> resultCollection = new List<IUiElement>();
            var resultCollection = new List<IUiElement>();
            bool requiresValuePatternCheck =
                !string.IsNullOrEmpty(data.Value);
            
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
                data.Name = string.IsNullOrEmpty(data.Name) ? "*" : data.Name;
                data.AutomationId = string.IsNullOrEmpty(data.AutomationId) ? "*" : data.AutomationId;
                data.Class = string.IsNullOrEmpty(data.Class) ? "*" : data.Class;
                data.Value = string.IsNullOrEmpty(data.Value) ? "*" : data.Value;
            } else {
                data.Name = string.IsNullOrEmpty(data.Name) ? ".*" : data.Name;
                data.AutomationId = string.IsNullOrEmpty(data.AutomationId) ? ".*" : data.AutomationId;
                data.Class = string.IsNullOrEmpty(data.Class) ? ".*" : data.Class;
                data.Value = string.IsNullOrEmpty(data.Value) ? ".*" : data.Value;
            }
            
            var wildcardName =
                new WildcardPattern(data.Name, options);
            var wildcardAutomationId =
                new WildcardPattern(data.AutomationId, options);
            var wildcardClass =
                new WildcardPattern(data.Class, options);
            var wildcardValue =
                new WildcardPattern(data.Value, options);
            /*
            WildcardPattern wildcardName =
                new WildcardPattern(data.Name, options);
            WildcardPattern wildcardAutomationId =
                new WildcardPattern(data.AutomationId, options);
            WildcardPattern wildcardClass =
                new WildcardPattern(data.Class, options);
            WildcardPattern wildcardValue =
                new WildcardPattern(data.Value, options);
            */
            
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
                                          item.CompareElementValueAndValueParameter(data.Value, true, wildcardValue, regexOptions) :
                                          // check whether the -Value parameter has or hasn't value
                                          ("*" == data.Value ? true : false)
                                         )
                                        )
                               )
                            .ToList<IUiElement>();
                    } else {
                        
                        query = inputList
                            .Where<IUiElement>(
                                item => (Regex.IsMatch(item.Current.Name, data.Name, regexOptions) &&
                                         Regex.IsMatch(item.Current.AutomationId, data.AutomationId, regexOptions) &&
                                         Regex.IsMatch(item.Current.ClassName, data.Class, regexOptions) &&
                                         // check whether a control has or hasn't ValuePattern
                                         (item.GetSupportedPatterns().AsQueryable<IBasePattern>().Any(p => null != p && null != (p as IValuePattern)) ?
                                          item.CompareElementValueAndValueParameter(data.Value, false, null, regexOptions) :
                                          // check whether the -Value parameter has or hasn't value
                                          (".*" == data.Value ? true : false)
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
                                item => (Regex.IsMatch(item.Current.Name, data.Name, regexOptions) &&
                                         Regex.IsMatch(item.Current.AutomationId, data.AutomationId, regexOptions) &&
                                         Regex.IsMatch(item.Current.ClassName, data.Class, regexOptions)
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
