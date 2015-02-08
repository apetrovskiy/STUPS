/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/15/2014
 * Time: 1:06 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    using System.Management.Automation;
    using System.Linq;
    using PSTestLib;
    
    /// <summary>
    /// Description of ControlSearcher.
    /// </summary>
    [UiaSpecialBinding]
    public class ControlSearcher : SearcherTemplate
    {
        public override string TimeoutExpirationInformation { get; set; }
        
        private classic.Condition conditionsForExactSearch = null;
        private classic.Condition conditionsForWildCards = null;
        private classic.Condition conditionsForTextSearch = null;
        
        private bool notTextSearch;
        
        protected static bool caseSensitive { get; set; }
        
        internal UsedSearchType UsedSearchType { get; set; }
        
        public override void OnStartHook()
        {
            UsedSearchType = UsedSearchType.None;
            
            var data = SearcherData as ControlSearcherData;
            
            #region conditions
            notTextSearch = true;
            if (!string.IsNullOrEmpty(data.ContainsText) && !data.Regex) {
                
                notTextSearch = false;
                
                conditionsForTextSearch =
                    GetTextSearchCondition(
                        data.ContainsText,
                        data.ControlType,
                        data.CaseSensitive);
                
            } else {
                
                conditionsForExactSearch = GetExactSearchCondition(data);
                
                conditionsForWildCards =
                    GetWildcardSearchCondition(data);
            }
            #endregion conditions
            
            ResultCollection = new List<IUiElement>();            
        }
        
        public override void BeforeSearchHook()
        {
            
        }
        
        public override List<IUiElement> SearchForElements(SearcherTemplateData searchData)
        {
            if (null == ResultCollection) return new List<IUiElement>();
            if (null == searchData) return ResultCollection;
            
            var data = searchData as ControlSearcherData;
            
            if (null == data) return ResultCollection;
            if (null == data.InputObject) return ResultCollection;
            
            foreach (IUiElement inputObject in data.InputObject) {
                
                int processId = 0;
                
                #region checking processId
                if (inputObject != null &&
                    // 20140312
                    // (int)inputObject.Current.ProcessId > 0) {
                    (int)inputObject.GetCurrent().ProcessId > 0) {
                    
                    // 20140312
                    // processId = inputObject.Current.ProcessId;
                    processId = inputObject.GetCurrent().ProcessId;
                }
                #endregion checking processId
                
                // 20130204
                // don't change the order! (text->exact->wildcard->win32 to win32->text->exact->wildcard)
                #region text search
                if (0 == ResultCollection.Count) {
                    if (!notTextSearch && !data.Win32) {
                        
                        UsedSearchType = UsedSearchType.Control_TextSearch;
                        ResultCollection.AddRange(
                            SearchByContainsTextViaUia(
                                inputObject,
                                conditionsForTextSearch));
                    }
                }
                #endregion text search
                
                #region text search Win32
                if (0 == ResultCollection.Count) {
                    if (!notTextSearch && data.Win32) {
                        
                        UsedSearchType = UsedSearchType.Control_TextSearchWin32;
                        var controlFromWin32Provider = AutomationFactory.GetObject<ControlFromWin32Provider>();
                        controlFromWin32Provider.SearchData = data;
                        controlFromWin32Provider.HandleCollector = AutomationFactory.GetObject<HandleCollector>();
                        
                        ResultCollection.AddRange(
                            SearchByContainsTextViaWin32(
                                inputObject,
                                controlFromWin32Provider));
                    }
                }
                #endregion text search Win32
                
                #region exact search
                if (0 == ResultCollection.Count && notTextSearch && !data.Regex) {
                    if (!Preferences.DisableExactSearch && !data.Win32 ) {
                            
                            UsedSearchType = UsedSearchType.Control_ExactSearch;
                            ResultCollection.AddRange(
                                SearchByExactConditionsViaUia(
                                    inputObject,
                                    data.SearchCriteria,
                                    conditionsForExactSearch));
                    }
                }
                #endregion exact search
                
                #region wildcard search
                if (0 == ResultCollection.Count && notTextSearch && !data.Regex) {
                    if (!Preferences.DisableWildCardSearch && !data.Win32) {
                            
                            UsedSearchType = UsedSearchType.Control_WildcardSearch;
                            ResultCollection.AddRange(
                                SearchByWildcardOrRegexViaUia(
                                    inputObject,
                                    data,
                                    // 20140206
                                    // UiElement.RootElement,
                                    conditionsForWildCards,
                                    true));
                    }
                }
                #endregion wildcard search
                
                #region Regex search
                if (0 == ResultCollection.Count && notTextSearch && data.Regex) {
                    if (!Preferences.DisableWildCardSearch && !data.Win32) {
                        
                        UsedSearchType = UsedSearchType.Control_RegexSearch;
                        ResultCollection.AddRange(
                            SearchByWildcardOrRegexViaUia(
                                inputObject,
                                data,
                                conditionsForWildCards,
                                false));
                    }
                }
                #endregion Regex search
                
                #region Win32 search
                if (0 == ResultCollection.Count && notTextSearch && !data.Regex) {
                    if (!Preferences.DisableWin32Search && data.Win32) {
                        
                        UsedSearchType = UsedSearchType.Control_Win32Search;
                        var handleCollector = AutomationFactory.GetObject<HandleCollector>();
                        
                        ResultCollection.AddRange(
                            SearchByWildcardViaWin32(
                                inputObject,
                                data,
                                handleCollector));
                        
                    }
                } // FindWindowEx
                #endregion Win32 search                
            }
            
            return ResultCollection;
        }
        
        public override void AfterSearchHook()
        {
//            if (null != ResultCollection && ResultCollection.Count > 0) {
//                
//                // break;
//                Wait = false;
//            }
        }
        
        public override void OnFailureHook()
        {
            
        }
        
        public override void OnSuccessHook()
        {
            
        }
        
        internal static List<IUiElement> SearchByContainsTextViaUia(
            IUiElement inputObject,
            classic.Condition conditionsForTextSearch)
        {
            IUiEltCollection textSearchCollection = inputObject.FindAll(classic.TreeScope.Descendants, conditionsForTextSearch);
            return textSearchCollection.Cast<IUiElement>().ToList();
        }
        
        internal static IEnumerable<IUiElement> SearchByContainsTextViaWin32(
            IUiElement inputObject,
            ControlFromWin32Provider controlProvider)
        {
            var resultList =
                new List<IUiElement>();
            
            foreach (IUiElement elementToChoose in controlProvider.GetElements(null)) {
                
                if (null != controlProvider.SearchData.ControlType && 0 < controlProvider.SearchData.ControlType.Length) {
                    
                    foreach (string controlTypeName in controlProvider.SearchData.ControlType) {
                        
                        // 20140312
                        // if (!String.Equals(elementToChoose.Current.ControlType.ProgrammaticName.Substring(12), controlTypeName, StringComparison.CurrentCultureIgnoreCase)) {
                        if (!String.Equals(elementToChoose.GetCurrent().ControlType.ProgrammaticName.Substring(12), controlTypeName, StringComparison.CurrentCultureIgnoreCase)) {
                            continue;
                        } else {
                            resultList.Add(elementToChoose);
                            break;
                        }
                        
                    }
                    
                } else {
                    resultList.Add(elementToChoose);
                }
            }
            
            return resultList;
        }
        
        internal static List<IUiElement> SearchByExactConditionsViaUia(
            IUiElement inputObject,
            Hashtable[] searchCriteria,
            classic.Condition conditions)
        {
            if (conditions == null) return new List<IUiElement>();
            
            if (inputObject == null || (int) inputObject.GetCurrent().ProcessId <= 0) return new List<IUiElement>();
            
            IUiEltCollection tempCollection = inputObject.FindAll(classic.TreeScope.Descendants, conditions);
            
            if (null == searchCriteria || 0 == searchCriteria.Length) {
                return tempCollection.ToArray().ToList<IUiElement>();
            }
            
            return tempCollection.ToArray().Where(element => TestControlWithAllSearchCriteria(searchCriteria, element)).ToList<IUiElement>();
        }
        
        internal static List<IUiElement> SearchByWildcardOrRegexViaUia(
            IUiElement inputObject,
            ControlSearcherData data,
            classic.Condition conditionsForWildCards,
            bool viaWildcardOrRegex)
        {
            var resultCollection =
                new List<IUiElement>();
            
            if (null == inputObject) return resultCollection;
            
            try {
                var controlSearcherData =
                    new ControlSearcherData {
                    InputObject = data.InputObject ?? (new UiElement[]{ (UiElement)UiElement.RootElement }),
                    Name = data.Name,
                    AutomationId = data.AutomationId,
                    Class = data.Class,
                    Value = data.Value,
                    ControlType = null != data.ControlType && 0 < data.ControlType.Length ? data.ControlType : (new string[] {}),
                    CaseSensitive = caseSensitive
                };
                
                var cmdlet1 = new GetControlCollectionCmdletBase(controlSearcherData);
                
                try {
                    
                    List<IUiElement> tempList =
                        cmdlet1.GetAutomationElementsViaWildcards_FindAll(
                            controlSearcherData,
                            inputObject,
                            conditionsForWildCards,
                            cmdlet1.CaseSensitive,
                            false,
                            false,
                            viaWildcardOrRegex);
                    
                    if (null == data.SearchCriteria || 0 == data.SearchCriteria.Length) {
                        
                        resultCollection.AddRange(tempList);
                    } else {
                        
                        foreach (IUiElement tempElement2 in tempList.Where(elt => TestControlWithAllSearchCriteria(data.SearchCriteria, elt))) {
                            resultCollection.Add(tempElement2);
                        }
                    }
                    
                    if (null != tempList) {
                        tempList.Clear();
                        tempList = null;
                    }
                    
                    return resultCollection;
                    
                } catch (Exception eUnexpected) {

                    (new GetControlCmdletBase()).WriteError(
                        new GetControlCmdletBase(),
                        "The input control or window has been possibly lost." +
                        eUnexpected.Message,
                        "UnexpectedError",
                        ErrorCategory.ObjectNotFound,
                        true);
                }
                
                cmdlet1 = null;
                
                return resultCollection;
                
            } catch (Exception eWildCardSearch) {

                (new GetControlCmdletBase()).WriteError(
                    new GetControlCmdletBase(),
                    "The input control or window has been possibly lost." +
                    eWildCardSearch.Message,
                    "UnexpectedError",
                    ErrorCategory.ObjectNotFound,
                    true);
                
                return resultCollection;
            }
        }
        
        internal IEnumerable<IUiElement> SearchByWildcardViaWin32(
            IUiElement inputObject,
            ControlSearcherData data,
            HandleCollector handleCollector)
        {
            var tempListWin32 = new List<IUiElement>();
            
            if (!string.IsNullOrEmpty(data.Name) || !string.IsNullOrEmpty(data.Value)) {
                
                var controlFrom32Provider = AutomationFactory.GetObject<ControlFromWin32Provider>();
                
                var singleControlSearcherData = new SingleControlSearcherData {
                    InputObject = inputObject,
                    Name = data.Name,
                    Value = data.Value,
                    AutomationId = data.AutomationId,
                    Class = data.Class
                };
                
                controlFrom32Provider.HandleCollector = handleCollector;
                
                tempListWin32.AddRange(
                    controlFrom32Provider.GetElements(
                        singleControlSearcherData.ConvertSingleControlSearcherDataToControlSearcherTemplateData()));
            }
            
            var resultList = new List<IUiElement>();
            
            foreach (IUiElement tempElement3 in tempListWin32) {
                
                bool goFurther = true;
                
                if (null != data.ControlType && 0 < data.ControlType.Length) {
                    
                    // 20140312
                    // goFurther &= !data.ControlType.Any(controlTypeName => String.Equals(tempElement3.Current.ControlType.ProgrammaticName.Substring(12), controlTypeName, StringComparison.CurrentCultureIgnoreCase));
                    goFurther &= !data.ControlType.Any(controlTypeName => String.Equals(tempElement3.GetCurrent().ControlType.ProgrammaticName.Substring(12), controlTypeName, StringComparison.CurrentCultureIgnoreCase));
                    
                } else {
                    goFurther = false;
                }
                
                if (goFurther) continue;
                
                if (null == data.SearchCriteria || 0 == data.SearchCriteria.Length) {
                    
                    resultList.Add(tempElement3);
                } else {
                    
                    if (!TestControlWithAllSearchCriteria(data.SearchCriteria, tempElement3)) continue;
                    resultList.Add(tempElement3);
                }
            }
            
            if (null != tempListWin32) {
                tempListWin32.Clear();
                tempListWin32 = null;
            }
            
            return resultList;
        }
        
        internal static bool TestControlWithAllSearchCriteria(
            IEnumerable<Hashtable> hashtables,
            IUiElement element)
        {
            bool result = false;
            
            if (null == hashtables || 0 == hashtables.Count()) return result;
            
            foreach (Hashtable hashtable in hashtables) {
                
                result =
                    element.TestControlByPropertiesFromDictionary(
                        hashtable.ConvertHashtableToDictionary());
                
                if (result) {
                    
                    if (Preferences.HighlightCheckedControl) {
                        UiaHelper.HighlightCheckedControl(element);
                    }
                    
                    return result;
                }
            }
            
            return result;
        }
        
        public classic.Condition[] GetControlsConditions(ControlSearcherData data)
        {
            var conditions = new List<classic.Condition>();
            
            if (null != data.ControlType && 0 < data.ControlType.Length) {
                foreach (string controlTypeName in data.ControlType)
                {
                    conditions.Add(GetWildcardSearchCondition(data));
                }
            } else{
                conditions.Add(GetWildcardSearchCondition(data));
            }
            return conditions.ToArray();
        }
        
        #region condition methods
        internal static classic.AndCondition GetAndCondition(List<classic.PropertyCondition> propertyCollection)
        {
            if (null == propertyCollection) return null;
            var resultCondition = new UIANET::System.Windows.Automation.AndCondition(propertyCollection.ToArray());
            return resultCondition;
        }
        
        internal static classic.OrCondition GetOrCondition(List<classic.PropertyCondition> propertyCollection)
        {
            if (null == propertyCollection) return null;
            var resultCondition = new UIANET::System.Windows.Automation.OrCondition(propertyCollection.ToArray());
            return resultCondition;
        }
        
        internal static classic.Condition GetControlTypeCondition(IEnumerable<string> controlTypeNames)
        {
            if (null == controlTypeNames) return classic.Condition.TrueCondition;
            
            List<classic.PropertyCondition> controlTypeCollection =
                // 20140302
                // controlTypeNames.Select(controlTypeName => new PropertyCondition(AutomationElement.ControlTypeProperty, UiaHelper.GetControlTypeByTypeName(controlTypeName))).ToList();
                controlTypeNames.Select(controlTypeName => new classic.PropertyCondition(classic.AutomationElement.ControlTypeProperty, UiaHelper.GetControlTypeByTypeName(controlTypeName))).ToList<classic.PropertyCondition>();
            
            return 1 == controlTypeCollection.Count ? (classic.Condition)controlTypeCollection[0] : (classic.Condition)GetOrCondition(controlTypeCollection);
        }
        
        internal static classic.Condition GetTextSearchCondition(string searchString, string[] controlTypeNames, bool caseSensitive1)
        {
            if (string.IsNullOrEmpty(searchString)) return null;
            
            classic.PropertyConditionFlags flags =
                caseSensitive1 ? classic.PropertyConditionFlags.None : classic.PropertyConditionFlags.IgnoreCase;
            
            var searchStringOrCondition =
                new classic.OrCondition(
                    new classic.PropertyCondition(
                        classic.AutomationElement.AutomationIdProperty,
                        searchString,
                        flags),
                    new classic.PropertyCondition(
                        classic.AutomationElement.NameProperty,
                        searchString,
                        flags),
                    new classic.PropertyCondition(
                        classic.AutomationElement.ClassNameProperty,
                        searchString,
                        flags),
                    new classic.PropertyCondition(
                        classic.ValuePattern.ValueProperty,
                        searchString,
                        flags));
            
            if (null == controlTypeNames || 0 == controlTypeNames.Length) return searchStringOrCondition;
            
            classic.Condition controlTypeCondition =
                GetControlTypeCondition(controlTypeNames);
            
            if (null == controlTypeCondition) return searchStringOrCondition;
            
            var resultCondition =
                new classic.AndCondition(
                    new classic.Condition[] {
                        searchStringOrCondition,
                        controlTypeCondition
                    });
            
            return resultCondition;
        }
        
        internal static classic.Condition GetExactSearchCondition(ControlSearcherData data)
        {
            classic.PropertyConditionFlags flags =
                data.CaseSensitive ? classic.PropertyConditionFlags.None : classic.PropertyConditionFlags.IgnoreCase;
            
            classic.Condition controlTypeCondition = classic.Condition.TrueCondition;
            if (null != data.ControlType && 0 < data.ControlType.Length) {
                controlTypeCondition =
                    GetControlTypeCondition(
                        data.ControlType);
            }
            
            var propertyCollection =
                new List<classic.PropertyCondition>();
            
            if (!string.IsNullOrEmpty(data.Name)) {
                propertyCollection.Add(
                    new classic.PropertyCondition(
                        classic.AutomationElement.NameProperty,
                        data.Name));
            }
            if (!string.IsNullOrEmpty(data.AutomationId)) {
                propertyCollection.Add(
                    new classic.PropertyCondition(
                        classic.AutomationElement.AutomationIdProperty,
                        data.AutomationId));
            }
            if (!string.IsNullOrEmpty(data.Class)) {
                propertyCollection.Add(
                    new classic.PropertyCondition(
                        classic.AutomationElement.ClassNameProperty,
                        data.Class));
            }
            if (!string.IsNullOrEmpty(data.Value)) {
                propertyCollection.Add(
                    new classic.PropertyCondition(
                        classic.ValuePattern.ValueProperty,
                        data.Value));
            }
            
            classic.Condition propertyCondition =
                0 == propertyCollection.Count ? null : (
                    1 == propertyCollection.Count ? propertyCollection[0] : (classic.Condition)GetAndCondition(propertyCollection)
                   );
            
            if (null == propertyCondition) {
                return controlTypeCondition;
            } else {
                return null == controlTypeCondition ? propertyCondition : new classic.AndCondition(
                    new classic.Condition[] {
                        propertyCondition,
                        controlTypeCondition
                    });
            }
        }
        
        internal static classic.Condition GetWildcardSearchCondition(ControlSearcherData data)
        {
            classic.Condition controlTypeCondition = classic.Condition.TrueCondition;
            if (null == data.ControlType || 0 == data.ControlType.Length) return controlTypeCondition;
            controlTypeCondition =
                GetControlTypeCondition(
                    data.ControlType);
            return controlTypeCondition;
        }
        #endregion condition methods
        
        public ControlSearcherData ConvertCmdletToControlSearcherData(GetControlCmdletBase cmdlet)
        {
            var ControlSearcherData =
                new ControlSearcherData {
                InputObject = cmdlet.InputObject,
                ContainsText = cmdlet.ContainsText,
                Name = cmdlet.Name,
                AutomationId = cmdlet.AutomationId,
                Class = cmdlet.Class,
                Value = cmdlet.Value,
                ControlType = cmdlet.ControlType,
                Regex = cmdlet.Regex,
                CaseSensitive = cmdlet.CaseSensitive,
                Win32 = cmdlet.Win32,
                SearchCriteria = cmdlet.SearchCriteria
            };
            
            return ControlSearcherData;
        }
    }
    
    internal enum UsedSearchType
    {
        None,
        Control_TextSearch,
        Control_TextSearchWin32,
        Control_ExactSearch,
        Control_WildcardSearch,
        Control_RegexSearch,
        Control_Win32Search,
        Name,
        ProcessName,
        ProcessId,
        Process
    }
}
