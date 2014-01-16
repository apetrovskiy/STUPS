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
    using System.Collections.ObjectModel;
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
            GetControlCollectionCmdletBase cmdletDerived = new GetControlCollectionCmdletBase();
            
            List<IUiElement> resultList =
                // cmdletDerived.SearchByWildcardOrRegexViaUia(
                ControlSearch.SearchByWildcardOrRegexViaUia(
                    // cmdlet,
                    element,
                    cmdlet.InputObject,
                    cmdlet.Name,
                    cmdlet.AutomationId,
                    cmdlet.Class,
                    cmdlet.Value,
                    cmdlet.SearchCriteria,
                    cmdlet.ControlType,
                    condition,
                    true);
            
            return resultList;
        }
        
        public static List<IUiElement> GetResultList_ExactSearch(GetControlCmdletBase cmdlet, IUiElement element, Condition conditions)
        {
            cmdlet.ResultListOfControls =
                // cmdlet.SearchByExactConditionsViaUia(cmdlet, element, conditions);
                // ControlSearch.SearchByWildcardOrRegexViaUia(cmdlet, element, conditions);
                ControlSearch.SearchByExactConditionsViaUia(
                    element,
                    cmdlet.SearchCriteria,
                    conditions);
            return cmdlet.ResultListOfControls;
        }
        
        public static List<IUiElement> GetResultList_TextSearch(GetControlCmdletBase cmdlet, IUiElement element, Condition conditions)
        {
            cmdlet.ResultListOfControls =
                // cmdlet.SearchByContainsTextViaUia(cmdlet, element, conditions);
                ControlSearch.SearchByContainsTextViaUia(element, conditions);
            return cmdlet.ResultListOfControls;
        }
        
        public static List<IUiElement> GetResultList_ReturnOnlyRightElements(GetControlCmdletBase cmdlet, IUiElement[] elements, bool useWildcardOrRegex)
        {
            HasTimeoutCmdletBase cmdletDerived = new HasTimeoutCmdletBase();
            
            List<IUiElement> resultList =
                // HasTimeoutCmdletBase.ReturnOnlyRightElements(
                WindowSearch.ReturnOnlyRightElements(
                    // cmdletDerived,
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
    }
}
