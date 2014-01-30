/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/27/2013
 * Time: 11:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests
{
    using System;
    
    
    using System.Collections;
    using System.Collections.Generic;
    // using System.Collections.ObjectModel;
    using UIAutomation;
    using System.Windows.Automation;
    
    /// <summary>
    /// Description of RealCodeCaller.
    /// </summary>
    public static class RealCodeCaller
    {
        public static List<IUiElement> GetResultList_ViaWildcards_Legacy(GetControlCmdletBase cmdlet, IUiElement element, Condition condition)
        {
            GetControlCollectionCmdletBase cmdletDerived = new GetControlCollectionCmdletBase();
            
            List<IUiElement> resultList =
                cmdletDerived.GetAutomationElementsWithFindAll(
                    element,
                    cmdlet.Name,
                    cmdlet.AutomationId,
                    cmdlet.Class,
                    cmdlet.Value,
                    cmdlet.ControlType,
                    condition,
                    false,
                    false,
                    false,
                    true);
            
            return resultList;
        }
        
        public static List<IUiElement> GetResultList_ViaWildcards(GetControlCmdletBase cmdlet, IUiElement element, Condition condition)
        {
            // 20140130
            var data =
                new ControlSearchData {
                InputObject = cmdlet.InputObject,
                Name = cmdlet.Name,
                AutomationId = cmdlet.AutomationId,
                Class = cmdlet.Class,
                Value = cmdlet.Value,
                ControlType = cmdlet.ControlType,
                SearchCriteria = cmdlet.SearchCriteria
            };
            
            List<IUiElement> resultList =
                ControlSearch.SearchByWildcardOrRegexViaUia(
                    element,
                    data,
//                    cmdlet.InputObject,
//                    cmdlet.Name,
//                    cmdlet.AutomationId,
//                    cmdlet.Class,
//                    cmdlet.Value,
//                    cmdlet.SearchCriteria,
//                    cmdlet.ControlType,
                    condition,
                    true);
            
            return resultList;
        }
        
        public static List<IUiElement> GetResultList_ExactSearch(GetControlCmdletBase cmdlet, IUiElement element, Condition conditions)
        {
            cmdlet.ResultListOfControls =
                ControlSearch.SearchByExactConditionsViaUia(
                    element,
                    cmdlet.SearchCriteria,
                    conditions);
            return cmdlet.ResultListOfControls;
        }
        
        public static List<IUiElement> GetResultList_TextSearch(GetControlCmdletBase cmdlet, IUiElement element, Condition conditions)
        {
            cmdlet.ResultListOfControls =
                ControlSearch.SearchByContainsTextViaUia(element, conditions);
            return cmdlet.ResultListOfControls;
        }
        
        public static List<IUiElement> GetResultList_ReturnOnlyRightElements(GetControlCmdletBase cmdlet, IEnumerable<IUiElement> elements, bool useWildcardOrRegex)
        {
            List<IUiElement> resultList =
                WindowSearch.ReturnOnlyRightElements(
                    elements,
                    cmdlet.Name,
                    cmdlet.AutomationId,
                    cmdlet.Class,
                    cmdlet.Value,
                    cmdlet.ControlType,
                    false,
                    useWildcardOrRegex);
            
            return resultList;
        }
        
        public static bool GetResult_IsStepActive(Hashtable[] searchCriteria, IUiEltCollection elements)
        {
            var step = new WizardStep("stepName", 1) {
                Description = "description",
                SearchCriteria = searchCriteria
            };
            
            var wizard = new Wizard("wizardName");
            
            return wizard.IsStepActive(step, elements);
        }
        
        public static List<IUiElement> GetResultList_GetWindowCollectionByPid(
            IUiElement rootElement,
            IEnumerable<int> processIds,
            bool first,
            bool recurse,
            // ICollection<string> names,
            IEnumerable<string> names,
            string automationId,
            string className)
        {
            var windowSearch = new WindowSearch();
            
            List<IUiElement> resultList =
                windowSearch.GetWindowCollectionByPid(
                    rootElement,
                    processIds,
                    first,
                    recurse,
                    names,
                    automationId,
                    className);
            
            return resultList;
                    
        }
    }
}
