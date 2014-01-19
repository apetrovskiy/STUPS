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
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Windows.Automation;
    using System.Management.Automation;
    using System.Linq;
    using PSTestLib;
    
    /// <summary>
    /// Description of ControlSearch.
    /// </summary>
    public class ControlSearch : SearchTemplate
    {
        public override string TimeoutExpirationInformation { get; set; }
        
        private Condition conditionsForExactSearch = null;
        private Condition conditionsForWildCards = null;
        private Condition conditionsForTextSearch = null;
        
        private GetControlCmdletBase tempCmdlet;
        private bool notTextSearch;
        
        protected static bool caseSensitive { get; set; }
        
        internal UsedSearchType UsedSearchType { get; set; }
        
        public override void OnStartHook()
        {
            UsedSearchType = UsedSearchType.None;
            
            ControlSearchData data = SearchData as ControlSearchData;
            
            #region conditions
            // GetControlCmdletBase tempCmdlet =
            tempCmdlet =
                new GetControlCmdletBase {ControlType = data.ControlType};

            // bool notTextSearch = true;
            notTextSearch = true;
            if (!string.IsNullOrEmpty(data.ContainsText) && !data.Regex) {
                tempCmdlet.ContainsText = data.ContainsText;
                notTextSearch = false;
                
                conditionsForTextSearch =
                    GetTextSearchCondition(
                        data.ContainsText,
                        data.ControlType,
                        data.CaseSensitive);
                
            } else {
                
                // conditionsForExactSearch = GetExactSearchCondition(cmdlet);
                conditionsForExactSearch = GetExactSearchCondition(data);
                
                conditionsForWildCards =
                    // GetWildcardSearchCondition(cmdlet);
                    GetWildcardSearchCondition(data);
                
            }
            #endregion conditions
            
            ResultCollection = new List<IUiElement>();            
        }
        
        public override void BeforeSearchHook()
        {
            
        }
        
        public override List<IUiElement> SearchForElements(SearchTemplateData searchData)
        {
            ControlSearchData data = searchData as ControlSearchData;
            tempCmdlet = null;
            
            foreach (IUiElement inputObject in data.InputObject) {
                
                int processId = 0;
                
                #region checking processId
                if (inputObject != null &&
                    (int)inputObject.Current.ProcessId > 0) {
                    
                    processId = inputObject.Current.ProcessId;
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
                        ResultCollection.AddRange(
                            SearchByTextViaWin32(
                                inputObject,
                                data.ContainsText,
                                data.ControlType));
                    }
                }
                #endregion text search Win32
                
                #region exact search
                if (0 == ResultCollection.Count && notTextSearch && !data.Regex) {
                    if (!Preferences.DisableExactSearch && !data.Win32 ) {
                        // if (!exactSearchDone || !wildcardSearchDone) {
                            
                            UsedSearchType = UsedSearchType.Control_ExactSearch;
                            ResultCollection.AddRange(
                                SearchByExactConditionsViaUia(
                                    inputObject,
                                    data.SearchCriteria,
                                    conditionsForExactSearch));
                            
                        //     exactSearchDone = true;
                        // }
                        // 
                        // wildcardSearchDone = false;
                    }
                }
                #endregion exact search
                
                #region wildcard search
                if (0 == ResultCollection.Count && notTextSearch && !data.Regex) {
                    if (!Preferences.DisableWildCardSearch && !data.Win32) {
                        // if (!wildcardSearchDone || !exactSearchDone) {
                            
                            UsedSearchType = UsedSearchType.Control_WildcardSearch;
                            ResultCollection.AddRange(
                                SearchByWildcardOrRegexViaUia(
                                    inputObject,
                                    data.InputObject,
                                    data.Name,
                                    data.AutomationId,
                                    data.Class,
                                    data.Value,
                                    data.SearchCriteria,
                                    data.ControlType,
                                    conditionsForWildCards,
                                    true));
                            
                        //     wildcardSearchDone = true;
                        // }
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
                                data.InputObject,
                                data.Name,
                                data.AutomationId,
                                data.Class,
                                data.Value,
                                data.SearchCriteria,
                                data.ControlType,
                                conditionsForWildCards,
                                false));
                    }
                }
                #endregion Regex search
                
                #region Win32 search
                if (0 == ResultCollection.Count && notTextSearch && !data.Regex) {
                    // 20140117
                    // if (!Preferences.DisableWin32Search || data.Win32) {
                    if (!Preferences.DisableWin32Search && data.Win32) {
                        
                        UsedSearchType = UsedSearchType.Control_Win32Search;
                        ResultCollection.AddRange(
                            SearchByWildcardViaWin32(
                                inputObject,
                                data.Name,
                                data.Value,
                                data.SearchCriteria,
                                data.ControlType));
                        
                    } // if (!Preferences.DisableWin32Search || cmdlet.Win32)
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
        
        public override void OnSleepHook()
        {
            
        }
        
        public override void OnFailureHook()
        {
            
        }
        
        public override void OnSuccessHook()
        {
            
        }
        
        
        // internal List<IUiElement> SearchByContainsTextViaUia(
        internal static List<IUiElement> SearchByContainsTextViaUia(
            // GetControlCmdletBase cmdlet,
            IUiElement inputObject,
            Condition conditionsForTextSearch)
        {
            IUiEltCollection textSearchCollection = inputObject.FindAll(TreeScope.Descendants, conditionsForTextSearch);
            
            return textSearchCollection.Cast<IUiElement>().ToList();
        }
        
        internal IEnumerable<IUiElement> SearchByTextViaWin32(
        /*
        internal List<IUiElement> SearchByTextViaWin32(
        */
            IUiElement inputObject,
            string containsText,
            string[] controlTypeNames)
        {
            List<IUiElement> textSearchWin32List =
                inputObject.GetControlByNameViaWin32(
                    containsText,
                    string.Empty);
            
            List<IUiElement> resultList =
                new List<IUiElement>();
            
            if (null != textSearchWin32List && 0 < textSearchWin32List.Count) {
                
                foreach (IUiElement elementToChoose in textSearchWin32List) {
                    
                    if (null != controlTypeNames && 0 < controlTypeNames.Length) {
                        
                        foreach (string controlTypeName in controlTypeNames) {
                            
                            if (!String.Equals(elementToChoose.Current.ControlType.ProgrammaticName.Substring(12), controlTypeName, StringComparison.CurrentCultureIgnoreCase)) {
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
            }
            
            if (null != textSearchWin32List) {
                textSearchWin32List.Clear();
                textSearchWin32List = null;
            }
            return resultList;
        }
        
        internal static List<IUiElement> SearchByExactConditionsViaUia(
            IUiElement inputObject,
            Hashtable[] searchCriteria,
            Condition conditions)
        {
            #region the -First story
            // 20120824
            //aeCtrl =
            // 20120921
            #region -First
            //                                    if (cmdlet.First) {
            //                                        AutomationElement tempFirstElement =
            //                                            inputObject.FindFirst(
            //                                                System.Windows.Automation.TreeScope.Descendants,
            //                                                conditions);
            //                                        if (null != tempFirstElement) {
            //                                            if (null == cmdlet.SearchCriteria || 0 == cmdlet.SearchCriteria.Length) {
            //                                                aeCtrl.Add(tempFirstElement);
            //                                            } else {
            //                                                if (testControlWithAllSearchCriteria(
            //                                                    cmdlet,
            //                                                    cmdlet.SearchCriteria,
            //                                                    tempFirstElement)) {
            //                                                    aeCtrl.Add(tempFirstElement);
            //                                                }
            //                                            }
            //                                        }
            //                                    } else {
            #endregion -First
            // 20120823
            //cmdlet.InputObject.FindFirst(System.Windows.Automation.TreeScope.Descendants,

            // 20120824
            // 20120917
            #region -First
            //                                    }
            #endregion -First
            //else if (UIAutomation.CurrentData.LastResult
            #endregion the -First story
            
            List<IUiElement> listOfColllectedResults =
                new List<IUiElement>();
            
            if (conditions == null) return listOfColllectedResults;
            
            if (inputObject == null || (int) inputObject.Current.ProcessId <= 0) return listOfColllectedResults;
            
            IUiEltCollection tempCollection = inputObject.FindAll(TreeScope.Descendants, conditions);
            
            foreach (IUiElement tempElement in tempCollection) {
                
                if (null == searchCriteria || 0 == searchCriteria.Length) {
                    
                    listOfColllectedResults.Add(tempElement);
                    
                    // cmdlet.WriteVerbose(cmdlet, "ExactSearch: element added to the result collection");
                    
                } else {
                    
                    if (!TestControlWithAllSearchCriteria(searchCriteria, tempElement)) continue;
                    
                    listOfColllectedResults.Add(tempElement);
                }
            }
            
            if (null != tempCollection) {
                tempCollection = null;
            }
            
            return listOfColllectedResults;
        }
        
        // internal List<IUiElement> SearchByWildcardOrRegexViaUia(
        internal static List<IUiElement> SearchByWildcardOrRegexViaUia(
            IUiElement inputObject,
            IUiElement[] InputObject,
            string name,
            string automationId,
            string className,
            string strValue,
            Hashtable[] searchCriteria,
            string[] controlType,
            Condition conditionsForWildCards,
            bool viaWildcardOrRegex)
        {
            List<IUiElement> resultCollection =
                new List<IUiElement>();
            
            try {
                
                GetControlCollectionCmdletBase cmdlet1 =
                    new GetControlCollectionCmdletBase(
                        // cmdlet.InputObject ?? (new UiElement[]{ (UiElement)UiElement.RootElement }),
                        InputObject ?? (new UiElement[]{ (UiElement)UiElement.RootElement }),
                        name, //cmdlet.Name,
                        automationId, //cmdlet.AutomationId,
                        className, //cmdlet.Class,
                        strValue,
                        // 20131128
                        // null != cmdlet.ControlType ? (new string[] {cmdlet.ControlType}) : (new string[] {}),
                        // null != cmdlet.ControlType && 0 < cmdlet.ControlType.Length ? cmdlet.ControlType : (new string[] {}),
                        null != controlType && 0 < controlType.Length ? controlType : (new string[] {}),
                        caseSensitive);
                
                try {
                    // WriteVerbose((cmdlet as PSCmdletBase), "using the GetAutomationElementsViaWildcards_FindAll method");
                    
                    List<IUiElement> tempList =
                        cmdlet1.GetAutomationElementsViaWildcards_FindAll(
                            cmdlet1,
                            inputObject,
                            conditionsForWildCards,
                            cmdlet1.CaseSensitive,
                            false,
                            false,
                            viaWildcardOrRegex);

                    // cmdlet.WriteVerbose(
                    //     cmdlet, 
                    //     "there are " +
                    //     tempList.Count.ToString() +
                    //     " elements that match the conditions");
                    
                    // if (null == cmdlet.SearchCriteria || 0 == cmdlet.SearchCriteria.Length) {
                    if (null == searchCriteria || 0 == searchCriteria.Length) {
                        
                        resultCollection.AddRange(tempList);
                    } else {
                        
                        foreach (IUiElement tempElement2 in tempList) {
                            
                            if (!TestControlWithAllSearchCriteria(searchCriteria, tempElement2)) continue;
                            
                            resultCollection.Add(tempElement2);
                        }
                    }
                    
                    if (null != tempList) {
                        tempList.Clear();
                        tempList = null;
                    }

                    /*
                    if (null != tempList) {
                        tempList.Clear();
                        tempList = null;
                    }
                    */

                    // 20131203
                    return resultCollection;
                    
                } catch (Exception eUnexpected) {

                    (new GetControlCmdletBase()).WriteError(
                        // this,
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
        
        // internal IEnumerable<IUiElement> SearchByWildcardViaWin32(GetControlCmdletBase cmdlet, IUiElement inputObject)
        internal IEnumerable<IUiElement> SearchByWildcardViaWin32(
            IUiElement inputObject,
            string name,
            string value,
            Hashtable[] searchCriteria,
            string[] controlType)
        /*
        internal List<IUiElement> SearchByWildcardViaWin32(GetControlCmdletBase cmdlet, IUiElement inputObject)
        */
        {
            List<IUiElement> tempListWin32 = new List<IUiElement>();
            // 20140111
            // if (!string.IsNullOrEmpty(cmdlet.Name)) {
            // if (!string.IsNullOrEmpty(cmdlet.Name) || !string.IsNullOrEmpty(cmdlet.Value)) {
            if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(value)) {
                // tempListWin32.AddRange(inputObject.GetControlByNameViaWin32(cmdlet, cmdlet.Name, cmdlet.Value));
                tempListWin32.AddRange(inputObject.GetControlByNameViaWin32(name, value));
            }
            
            List<IUiElement> resultList = new List<IUiElement>();
            
            foreach (IUiElement tempElement3 in tempListWin32) {
                
                // 20131128
//                if (!string.IsNullOrEmpty(cmdlet.ControlType)) {
//                    if (!tempElement3.Current.ControlType.ProgrammaticName.ToUpper().Contains(cmdlet.ControlType.ToUpper()) || 
//                        tempElement3.Current.ControlType.ProgrammaticName.ToUpper().Substring(12).Length != cmdlet.ControlType.ToUpper().Length) {
//                        continue;
//                    }
//                }
                bool goFurther = true;
                // if (null != cmdlet.ControlType && 0 < cmdlet.ControlType.Length) {
                if (null != controlType && 0 < controlType.Length) {
                    
                    // if (cmdlet.ControlType.Any(controlTypeName => String.Equals(tempElement3.Current.ControlType.ProgrammaticName.Substring(12), controlTypeName, StringComparison.CurrentCultureIgnoreCase)))
                    if (controlType.Any(controlTypeName => String.Equals(tempElement3.Current.ControlType.ProgrammaticName.Substring(12), controlTypeName, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        goFurther = false;
                    }
                    /*
                    foreach (string controlTypeName in cmdlet.ControlType) {
                        
                        if (String.Equals(tempElement3.Current.ControlType.ProgrammaticName.Substring(12), controlTypeName, StringComparison.CurrentCultureIgnoreCase)) {
                            
                            goFurther = false;
                            break;
                        }
                    }
                    */
                } else {
                    goFurther = false;
                }
                
                if (goFurther) continue;
                
                // if (null == cmdlet.SearchCriteria || 0 == cmdlet.SearchCriteria.Length) {
                if (null == searchCriteria || 0 == searchCriteria.Length) {
                    
                    resultList.Add(tempElement3);
                    // cmdlet.WriteVerbose(cmdlet, "Win32Search: element added to the result collection");
                } else {
                    
                    // cmdlet.WriteVerbose(cmdlet, "Win32Search: checking search criteria");
                    // if (!TestControlWithAllSearchCriteria(cmdlet, cmdlet.SearchCriteria, tempElement3)) continue;
                    if (!TestControlWithAllSearchCriteria(searchCriteria, tempElement3)) continue;
                    // cmdlet.WriteVerbose(cmdlet, "Win32Search: the control matches the search criteria");
                    resultList.Add(tempElement3);
                    // cmdlet.WriteVerbose(cmdlet, "Win32Search: element added to the result collection");
                }
            }
            
            if (null != tempListWin32) {
                tempListWin32.Clear();
                tempListWin32 = null;
            }
            /*
            if (null != tempListWin32) {
                tempListWin32.Clear();
                tempListWin32 = null;
            }
            */

            return resultList;
        }
        
        // protected internal bool TestControlWithAllSearchCriteria(
        internal static bool TestControlWithAllSearchCriteria(
            IEnumerable<Hashtable> hashtables,
            IUiElement element)
        {
            bool result = false;
            
            foreach (Hashtable hashtable in hashtables) {
                
                result =
                    // TestControlByPropertiesFromDictionary(
                    //     ConvertHashtableToDictionary(hashtable),
                    //     element);
                    element.TestControlByPropertiesFromDictionary(
                        // ConvertHashtableToDictionary(hashtable));
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
        
        // public Condition[] GetControlsConditions(GetControlCollectionCmdletBase cmdlet)
        public Condition[] GetControlsConditions(ControlSearchData data)
        {
            List<Condition> conditions =
                new List<Condition>();
            
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
        internal static AndCondition GetAndCondition(List<PropertyCondition> propertyCollection)
        {
            if (null == propertyCollection) return null;
            AndCondition resultCondition = new AndCondition(propertyCollection.ToArray());
            return resultCondition;
        }
        
        internal static OrCondition GetOrCondition(List<PropertyCondition> propertyCollection)
        {
            if (null == propertyCollection) return null;
            OrCondition resultCondition = new OrCondition(propertyCollection.ToArray());
            return resultCondition;
        }
        
        internal static Condition GetControlTypeCondition(IEnumerable<string> controlTypeNames)
        /*
        protected internal Condition GetControlTypeCondition(string[] controlTypeNames)
        */
        {
            if (null == controlTypeNames) return Condition.TrueCondition;
            
            List<PropertyCondition> controlTypeCollection =
                controlTypeNames.Select(controlTypeName => new PropertyCondition(AutomationElement.ControlTypeProperty, UiaHelper.GetControlTypeByTypeName(controlTypeName))).ToList();
            /*
            foreach (string controlTypeName in controlTypeNames) {
                
                controlTypeCollection.Add(
                    new PropertyCondition(
                        AutomationElement.ControlTypeProperty,
                        UiaHelper.GetControlTypeByTypeName(controlTypeName)));
            }
            */

            // return 1 == controlTypeCollection.Count ? controlTypeCollection[0] : GetOrCondition(controlTypeCollection);
            
            if (1 == controlTypeCollection.Count) {
                return controlTypeCollection[0];
            } else {
                return GetOrCondition(controlTypeCollection);
            }
        }
        
        internal static Condition GetTextSearchCondition(string searchString, string[] controlTypeNames, bool caseSensitive1)
        {
            if (string.IsNullOrEmpty(searchString)) return null;
            
            PropertyConditionFlags flags =
                caseSensitive1 ? PropertyConditionFlags.None : PropertyConditionFlags.IgnoreCase;
            
            OrCondition searchStringCondition =
                new OrCondition(
                    new PropertyCondition(
                        AutomationElement.AutomationIdProperty,
                        searchString,
                        flags),
                    new PropertyCondition(
                        AutomationElement.NameProperty,
                        searchString,
                        flags),
                    new PropertyCondition(
                        AutomationElement.ClassNameProperty,
                        searchString,
                        flags),
                    new PropertyCondition(
                        ValuePattern.ValueProperty,
                        searchString,
                        flags));
            
            if (null == controlTypeNames || 0 == controlTypeNames.Length) return searchStringCondition;
            
            Condition controlTypeCondition =
                GetControlTypeCondition(controlTypeNames);
            
            if (null == controlTypeCondition) return searchStringCondition;
            
            AndCondition resultCondition =
                new AndCondition(
                    new Condition[] {
                        searchStringCondition,
                        controlTypeCondition
                    });
            
            return resultCondition;
        }
        
        internal static Condition GetExactSearchCondition(ControlSearchData data)
        {
            PropertyConditionFlags flags =
                data.CaseSensitive ? PropertyConditionFlags.None : PropertyConditionFlags.IgnoreCase;
            
            Condition controlTypeCondition = Condition.TrueCondition;
            if (null != data.ControlType && 0 < data.ControlType.Length) {
                controlTypeCondition =
                    GetControlTypeCondition(
                        data.ControlType);
            }
            
            List<PropertyCondition> propertyCollection =
                new List<PropertyCondition>();
            if (!string.IsNullOrEmpty(data.Name)) {
                propertyCollection.Add(
                    new PropertyCondition(
                        AutomationElement.NameProperty,
                        data.Name));
            }
            if (!string.IsNullOrEmpty(data.AutomationId)) {
                propertyCollection.Add(
                    new PropertyCondition(
                        AutomationElement.AutomationIdProperty,
                        data.AutomationId));
            }
            if (!string.IsNullOrEmpty(data.Class)) {
                propertyCollection.Add(
                    new PropertyCondition(
                        AutomationElement.ClassNameProperty,
                        data.Class));
            }
            if (!string.IsNullOrEmpty(data.Value)) {
                propertyCollection.Add(
                    new PropertyCondition(
                        ValuePattern.ValueProperty,
                        data.Value));
            }
            
            Condition propertyCondition =
                0 == propertyCollection.Count ? null : (
                    1 == propertyCollection.Count ? propertyCollection[0] : (Condition)GetAndCondition(propertyCollection)
                   );
            
            if (null == propertyCondition) {
                return controlTypeCondition;
            } else {
                return null == controlTypeCondition ? propertyCondition : new AndCondition(
                    new Condition[] {
                        propertyCondition,
                        controlTypeCondition
                    });
            }
        }
        
        internal static Condition GetWildcardSearchCondition(ControlSearchData data)
        {
            Condition controlTypeCondition = Condition.TrueCondition;
            if (null == data.ControlType || 0 >= data.ControlType.Length) return controlTypeCondition;
            controlTypeCondition =
                GetControlTypeCondition(
                    data.ControlType);
            return controlTypeCondition;
            /*
            if (null != cmdlet.ControlType && 0 < cmdlet.ControlType.Length) {
                controlTypeCondition =
                    GetControlTypeCondition(
                        cmdlet.ControlType);
            }
            return controlTypeCondition;
            */
        }
        #endregion condition methods
        
        public ControlSearchData ConvertCmdletToControlSearchData(GetControlCmdletBase cmdlet)
        {
            var controlSearchData =
                new ControlSearchData {
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
            
            return controlSearchData;
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
