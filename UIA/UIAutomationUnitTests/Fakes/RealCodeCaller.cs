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
        
        public static List<IUiElement> GetResultList_ViaWildcards(ControlSearcherData data, IUiElement element, Condition condition)
        {
            List<IUiElement> resultList =
                ControlSearcher.SearchByWildcardOrRegexViaUia(
                    element,
                    data,
                    // 20140206
                    // UiElement.RootElement,
                    // element,
                    condition,
                    true);
            
            return resultList;
        }
        
        public static List<IUiElement> GetResultList_ExactSearch(GetControlCmdletBase cmdlet, IUiElement element, Condition conditions)
        {
            cmdlet.ResultListOfControls =
                ControlSearcher.SearchByExactConditionsViaUia(
                    element,
                    cmdlet.SearchCriteria,
                    conditions);
            return cmdlet.ResultListOfControls;
        }
        
        public static List<IUiElement> GetResultList_TextSearch(GetControlCmdletBase cmdlet, IUiElement element, Condition conditions)
        {
            cmdlet.ResultListOfControls =
                ControlSearcher.SearchByContainsTextViaUia(element, conditions);
            return cmdlet.ResultListOfControls;
        }
        
        public static List<IUiElement> GetResultList_ReturnOnlyRightElements(GetControlCmdletBase cmdlet, IEnumerable<IUiElement> elements, bool useWildcardOrRegex)
        {
            List<IUiElement> resultList =
                WindowSearcher.ReturnOnlyRightElements(
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
            IEnumerable<string> names,
            string automationId,
            string className)
        {
            var windowSearcher = new WindowSearcher();
            
            List<IUiElement> resultList =
                windowSearcher.GetWindowCollectionByPid(
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
