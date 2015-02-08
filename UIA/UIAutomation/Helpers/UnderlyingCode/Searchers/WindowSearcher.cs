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
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    
    /// <summary>
    /// Description of WindowSeatcher.
    /// </summary>
    [UiaSpecialBinding]
    public class WindowSearcher : SearcherTemplate
    {
        public override string TimeoutExpirationInformation { get; set; }
        internal bool wasFound = false;
        
        // 20140208
        classic.CacheRequest ClonedCacheRequest { get; set; }
        
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
                catch (Exception) {
//Console.WriteLine("failed to stop the cache request");
//Console.WriteLine(eeeee.Message);
                }
            } else {
                if (null == CurrentData.CacheRequest) {
//Console.WriteLine("cache request is null");
                }
            }
            
            try {
                
                var data = searchData as WindowSearcherData;
                // WindowSearcherData data = searchData as WindowSearcherData;
                
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
                        // 20141001
                        // ResultCollection = GetWindowCollectionByProcessName(UiElement.RootElement, data);
                        ResultCollection = GetWindowCollectionByProcessName(data);
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
                
            } catch (Exception) {
                
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
            
            Wait &= !(SearcherData as WindowSearcherData).WaitNoWindow || !wasFound || (null != ResultCollection && 0 != ResultCollection.Count);
            
//            wasFound = true;
//            ResultCollection.Clear();
//            ResultCollection = null;
            
            if ((SearcherData as WindowSearcherData).WaitNoWindow && !wasFound && null != ResultCollection && 0 != ResultCollection.Count) {

                wasFound = true;
                
                ResultCollection.Clear();
                ResultCollection = null;
            }
            
            if (null != ResultCollection && 0 < ResultCollection.Count) {
                if (Preferences.CacheRequestCalled && null != CurrentData.CacheRequest) {
                    try {
                        // CurrentData.CacheRequest.Push();
                        // var cacheRequest = CurrentData.CacheRequest.Clone();
                        ClonedCacheRequest = CurrentData.CacheRequest.Clone();
                        ClonedCacheRequest.Push();
                        Preferences.FromCache = true;
                    } catch (Exception) {
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
            var filteredWindows = new List<IUiElement>();
            bool exitInnerCycle;

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

                        if (null == controlsList || 0 == controlsList.Count) {
                            exitInnerCycle = true;
                            addToResultCollection = false;
                            continue;
                        } else {
                            addToResultCollection = true;
                            break;
                        }
                        
                    } catch (Exception) {

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
                
            } catch (Exception) {
                
                CurrentData.CurrentWindow = null;
                
            }
        }
        
        List<IUiElement> GetWindowCollectionViaWin32(
            WindowSearcherData data)
        {
            return UiaHelper.EnumChildWindowsFromHandle(
                data.Name,
                data.AutomationId,
                data.Class,
                IntPtr.Zero);
        }
        
        List<IUiElement> GetWindowCollectionFromProcess(
            WindowSearcherData data)
        {
            data.ProcessIds = (from process in data.InputObject where null != process && 0 != process.Id select process.Id).ToList().ToArray();
            return GetWindowCollectionByPid(UiElement.RootElement, data);
        }
        
        List<IUiElement> GetWindowCollectionByName(
            IUiElement rootElement,
            WindowSearcherData data)
        {
            var windowCollectionByProperties =
                new List<IUiElement>();
            var resultCollection =
                new List<IUiElement>();
            
            if (null == data.Name) {
                // 20141001
                // data.Name = new string[]{ string.Empty };
                data.Name = new []{ string.Empty };
            }
            
            classic.OrCondition conditionsSet = null;
            if (data.Recurse) {
                conditionsSet =
                    new classic.OrCondition(
                        new classic.PropertyCondition(
                            classic.AutomationElement.ControlTypeProperty,
                            classic.ControlType.Window),
                        classic.Condition.FalseCondition);
            } else {
                conditionsSet =
                    new classic.OrCondition(
                        new classic.PropertyCondition(
                            classic.AutomationElement.ControlTypeProperty,
                            classic.ControlType.Window),
                        new classic.PropertyCondition(
                            classic.AutomationElement.ControlTypeProperty,
                            classic.ControlType.Pane),
                        new classic.PropertyCondition(
                            classic.AutomationElement.ControlTypeProperty,
                            classic.ControlType.Menu));
            }
            
            foreach (string windowTitle in data.Name) {
                
                IUiEltCollection windowCollection =
                    rootElement.FindAll(data.Recurse ? classic.TreeScope.Descendants : classic.TreeScope.Children, conditionsSet);
                
                var controlSearcherData =
                    new ControlSearcherData {
                    Name = windowTitle,
                    AutomationId = data.AutomationId,
                    Class = data.Class,
                    Value = string.Empty,
                    // 20141001
                    // ControlType = (new string[]{ "Window", "Pane", "Menu" })
                    ControlType = (new []{ "Window", "Pane", "Menu" })
                };
                
                windowCollectionByProperties =
                    ReturnOnlyRightElements(
                        windowCollection,
                        controlSearcherData,
                        false,
                        true);
                    
                try {
                    
                    if (null != windowCollectionByProperties && 0 < windowCollectionByProperties.Count) {
                        
                        foreach (IUiElement aeWndByTitle in windowCollectionByProperties
                            .Where(aeWndByTitle => aeWndByTitle != null && (int)aeWndByTitle.GetCurrent().ProcessId > 0))
                        {
                            resultCollection.Add(aeWndByTitle);
                        }
                        
                        windowCollectionByProperties.Clear();
                        
                    } else {
                        
                        IUiElement tempElement = null;
                        
                        // one more attempt using the FindWindow function
                        IntPtr wndHandle = NativeMethods.FindWindowByCaption(IntPtr.Zero, windowTitle);
                        // 20141001
                        // if (wndHandle != null && wndHandle != IntPtr.Zero) {
                        if (wndHandle != IntPtr.Zero) {
                            tempElement =
                                UiElement.FromHandle(wndHandle);
                        }
                        
                        if (null == tempElement || (int) tempElement.GetCurrent().ProcessId <= 0) continue;
                        
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
        
        // 20141001
        List<IUiElement> GetWindowCollectionByProcessName(
            // IUiElement rootElement,
            WindowSearcherData data)
        {
            data.InputObject = data.ProcessNames.SelectMany(processName => Process.GetProcessesByName(processName)).ToList().ToArray();
            return GetWindowCollectionFromProcess(data);
        }
        
        internal List<IUiElement> GetWindowCollectionByPid(
            IUiElement rootElement,
            WindowSearcherData data)
        {
            classic.AndCondition conditionsForRecurseSearch = null;
            
            var elementsByProcessId =
                new List<IUiElement>();
            
            // 20141001
            // if ((null != data.Name && 0 < data.Name.Count()) ||
            if ((null != data.Name && data.Name.Any()) ||
                !string.IsNullOrEmpty(data.AutomationId) ||
                !string.IsNullOrEmpty(data.Class)) {
                
                data.Recurse = true;
            }
            
            var conditionWindowPaneMenu =
                new classic.OrCondition(
                    new classic.PropertyCondition(
                        classic.AutomationElement.ControlTypeProperty,
                        classic.ControlType.Window),
                    new classic.PropertyCondition(
                        classic.AutomationElement.ControlTypeProperty,
                        classic.ControlType.Pane),
                    new classic.PropertyCondition(
                        classic.AutomationElement.ControlTypeProperty,
                        classic.ControlType.Menu));
            
            foreach (int processId in data.ProcessIds) {
                
                conditionsForRecurseSearch =
                    new classic.AndCondition(
                        new classic.PropertyCondition(
                            classic.AutomationElement.ProcessIdProperty,
                            processId),
                        new classic.PropertyCondition(
                            classic.AutomationElement.ControlTypeProperty,
                            classic.ControlType.Window));
                    
                var conditionsProcessId =
                    new classic.AndCondition(
                        new classic.PropertyCondition(
                            classic.AutomationElement.ProcessIdProperty,
                            processId),
                        conditionWindowPaneMenu);
                
                try {
                    
                    if (data.Recurse) {
                        if (data.First) {
                            
                            IUiElement rootWindowElement =
                                rootElement.FindFirst(
                                    classic.TreeScope.Children,
                                    conditionsProcessId);
                            
                            if (null != rootWindowElement) {
                                elementsByProcessId.Add(rootWindowElement);
                            }
                            
                        } else {
                            
                            IUiEltCollection rootCollection =
                                rootElement.FindAll(
                                    classic.TreeScope.Children,
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
                                    classic.TreeScope.Children,
                                    conditionsProcessId);
                            
                            if (null != tempElement) {
                                
                                elementsByProcessId.Add(tempElement);
                            }
                        } else {
                            
                            IUiEltCollection tempCollection =
                                rootElement.FindAll(
                                    classic.TreeScope.Children,
                                    conditionsProcessId);
                            
                            if (null != tempCollection && 0 < tempCollection.Count) {
                                
                                elementsByProcessId.AddRange(tempCollection.Cast<IUiElement>());
                            }
                        }
                    }
                } catch (Exception) {
                    
                    // WriteVerbose(
                    //     this,
                    //     "exception: " +
                    //     eGetFirstChildOfRootByProcessId.Message);
                }
            }
            
            if (!data.Recurse ||
                // 20141001
                // ((null == data.Name || 0 == data.Name.Count()) && string.IsNullOrEmpty(data.AutomationId) &&
                ((null == data.Name || !data.Name.Any()) && string.IsNullOrEmpty(data.AutomationId) &&
                 string.IsNullOrEmpty(data.Class))) return elementsByProcessId;
            
            var resultList =
                new List<IUiElement>();
            /*
            List<IUiElement> resultList =
                new List<IUiElement>();
            */
            
            // 20141001
            // if (null != data.Name && 0 < data.Name.Count()) {
            if (null != data.Name && data.Name.Any()) {
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
            
            var inputList = inputCollection.Cast<IUiElement>().ToList();
            
            try {
                
                List<IUiElement> query;
                
                if (requiresValuePatternCheck) {
                    
                    if (viaWildcardOrRegex) {
                        
                        query = inputList
                            .Where<IUiElement>(
                                item => (wildcardName.IsMatch(item.GetCurrent().Name) &&
                                         wildcardAutomationId.IsMatch(item.GetCurrent().AutomationId) &&
                                         wildcardClass.IsMatch(item.GetCurrent().ClassName) &&
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
                                item => (Regex.IsMatch(item.GetCurrent().Name, data.Name, regexOptions) &&
                                         Regex.IsMatch(item.GetCurrent().AutomationId, data.AutomationId, regexOptions) &&
                                         Regex.IsMatch(item.GetCurrent().ClassName, data.Class, regexOptions) &&
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
                                item => (wildcardName.IsMatch(item.GetCurrent().Name) &&
                                         wildcardAutomationId.IsMatch(item.GetCurrent().AutomationId) &&
                                         wildcardClass.IsMatch(item.GetCurrent().ClassName)
                                        )
                               )
                            .ToList<IUiElement>();
                    } else {
                        query = inputList
                            .Where<IUiElement>(
                                item => (Regex.IsMatch(item.GetCurrent().Name, data.Name, regexOptions) &&
                                         Regex.IsMatch(item.GetCurrent().AutomationId, data.AutomationId, regexOptions) &&
                                         Regex.IsMatch(item.GetCurrent().ClassName, data.Class, regexOptions)
                                        )
                               )
                            .ToList<IUiElement>();
                    }
                    
                }
                
                resultCollection.AddRange(query);
            }
            catch (Exception) {
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
